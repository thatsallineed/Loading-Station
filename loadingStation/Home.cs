using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

using loadingStation.GUI;
using loadingStation.Core.Modbus;
using loadingStation.Core.Database;
using loadingStation.Core.Function;
using loadingStation.Core.Configuration.Config;
using loadingStation.Core.Log;

namespace loadingStation
{
    public partial class Home : Form
    {
        #region Properties
        Dashboard dashboard = new Dashboard();
        Tasklist tasklist = new Tasklist();
        ReadyMaintenance maintenance = new ReadyMaintenance();

        Task TaskLogging;

        bool Logging
        {
            get { return GlobalProperties.FLAG_LOGGING; }
            set { GlobalProperties.FLAG_LOGGING = value; }
        }

        bool FLAG_EMERGENCY;
        bool FLAG_DRUM;
        bool FLAG_MAINTENANCE;
        bool FLAG_ATSTART;

        bool ApplicationModeDebug
        {
            get { return (App.Default.IndicatorTestOnly || App.Default.IsDebugging) ; }
        }

        Form LastOpened;

        // VALUE MODBUS INPUT (Drum)
        int MixingValue = 0;
        int MeasureValue = 0;
        int DrumValue = 0;

        // FILLING DURATION TIMEOUT
        const int FillingWaterDuration = 101;   // (101 SECOND)
        const int FillingCoolantDuration = 99;  // (99 SECOND)

        // COUNTER TIMEOUT
        int ValueNumberTimeout = CoreLS.Default.ValueNumberTimeout;
        int PropelerCycleTime = (CoreLS.Default.PropelerCycleTime > 1000) ? CoreLS.Default.PropelerCycleTime : 3000;

        Task TaskLoadModbus;

        int EmergencyBtnCycleTime = (CoreLS.Default.EmergencyBtnCycleTime > 200) ? CoreLS.Default.EmergencyBtnCycleTime : 500;
        int CounterFillingTimeout = (CoreLS.Default.CounterFillingTimeout > 5000) ? CoreLS.Default.CounterFillingTimeout : 20000;
        int CounterWaterTimeout = (CoreLS.Default.CounterWaterTimeout > 5000) ? CoreLS.Default.CounterWaterTimeout : 20000;
        int CounterCoolantTimeout = (CoreLS.Default.CounterCoolantTimeout > 5000) ? CoreLS.Default.CounterCoolantTimeout : 20000;

        // FLAG
        bool FLAG_COUNTER_FILLING;
        bool FLAG_COUNTER_WATER;
        bool FLAG_COUNTER_COOLANT;

        bool FLAG_ELAPSEDFILLING_WATER;
        bool FLAG_ELAPSEDFILLING_COOLANT;

        #endregion
        public Home()
        {
            LoadErrorEventHandler();
            InitializeComponent();

            // LOAD SERVICES
            Actions.DBCheckService();
            Actions.StatusService();
            Actions.ScreenPreventSleep();

            // LOAD CONFIGURATION
            LoadCoolantType();
            LoadUserConfiguration();

            // LOAD TIMER
            timerErrorLogCollector.Start();

            // LOAD MINIFORM
            dashboard.TopLevel = false;
            tasklist.TopLevel = false;

            // LOAD MINIFORM (CONTROL)
            panelForm.Controls.Add(dashboard);
            panelForm.Controls.Add(tasklist);
            dashboard.Show();

            // START TASKS
            TaskLogging = new Task(() => DoLogging());
            TaskLoadModbus = new Task(() => LoadModbus());
            TaskLoadModbus.Start();

            // SET MODBUS REAL DATA
            GlobalProperties.RealData[0] = 50;
            GlobalProperties.RealData[1] = 50;

            // SET CURRENT STATUS
            GlobalProperties.PumpDist = GlobalProperties.Valve.Open;

            // SET ALLOW LOGGING
            Logging = true;

            // SET DOT HEADER MENU
            dotPreferences.Visible = false;
            dotTasklist.Visible = false;

            // SET FLAGS TO DEFAULT
            FLAG_EMERGENCY = false;
            FLAG_COUNTER_FILLING = false;
            FLAG_COUNTER_WATER = false;
            FLAG_COUNTER_COOLANT = false;
            FLAG_ATSTART = false;

            FLAG_ELAPSEDFILLING_WATER = FLAG_ELAPSEDFILLING_COOLANT = false;

            // LOAD TASK REALTIME
            LoadTask();
            timerMT.Start();
            Application.DoEvents();

            // SET OPENED LAST FORM
            LastOpened = dashboard;
        }

        #region ErrorException EventHandler

        private void LoadErrorEventHandler()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(ApplicationThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);
        }

        [HandleProcessCorruptedStateExceptions]
        private void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionAction(e.ExceptionObject.ToString());
        }

        private void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionAction(e.Exception.StackTrace.ToString());
        }

        private void ExceptionAction(string exception)
        {
            Core.Log.Error.Collect(exception);
            Core.Log.Error.Collect("== WARNING! UNEXCEPTION RESTART ==");
            Actions.RelaunchApplication();
        }
        #endregion

        #region Load User Configuration
        private void LoadUserConfiguration()
        {
            // Load Logs Configuration
            int SaveDuration = Core.Configuration.Config.Logs.Default.SaveLogDuration;
            timerErrorLogCollector.Interval = SaveDuration;
            panelDebug.Visible = (App.Default.IsDebugging || App.Default.IndicatorTestOnly) ? true : false;
            lblCoolantType.Text = GlobalProperties.CoolantType.ToString();
        }
        #endregion

        #region Load Task
        private void LoadTask()
        {
            Task TaskRealtime = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            try
                            {
                                lblTime.Text = DateTime.Now.ToString("HH:mm");
                                lblSecond.Text = DateTime.Now.ToString("ss");

                                bool check = (!GlobalProperties.ModbusInputStatus || !GlobalProperties.ModbusOutputStatus || !GlobalProperties.DatabaseStatus);
                                panelNotification.Visible = (check) ? true : false;
                                panelHeader.BackColor = (check) ? Color.FromArgb(235, 77, 75) : Color.FromArgb(88, 86, 99);
                            }
                            catch { }
                        });
                    }
                    catch { }
                    Thread.Sleep(500);
                }
            });
            TaskRealtime.Start();
        }
        #endregion

        #region Load Coolant Type
        private static void LoadCoolantType()
        {
            try
            {
                String configfile = "config.ini";
                if (System.IO.File.Exists(configfile))
                {
                    var readconf = System.IO.File.ReadAllText(configfile);
                    if (readconf == "A" || readconf == "B" || readconf == "C")
                    {
                        var temp = char.Parse(readconf);
                        GlobalProperties.CoolantType = readconf[0];
                    }
                    else
                    {
                        MessageBox.Show("Configuration is Not Valid, Unknown Format \n Exited!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    MessageBox.Show("Configuration Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch (Exception x)
            {
                Error.Collect(x.ToString());
            }
        }
        #endregion

        #region Load Modbus
        private void LoadModbus()
        {
            bool GetIp = true;
            string IPModbusInput = "";
            string IPModbusOutput = "";

            while (GetIp)
            {
                if (IPModbusInput == "")
                {
                    try
                    {
                        if (GlobalProperties.DatabaseStatus)
                        {
                            // GET Modbus Input & Output IP Address
                            IPModbusInput = DB_SFDB.IpDigitalInput();
                            IPModbusOutput = DB_SFDB.IpDigitalOutput();
                            GetIp = false;
                        }
                    }
                    catch { }
                }
                Thread.Sleep(500);
            }

            // Check This Application Is Debugging OR Not
            // AND Add Modbus Device(s)
            bool mode = App.Default.IsDebugging;

            if (mode)
            {
                GlobalProperties.DevicesInput.Add(new ModbusInput(Modbusconfig.Default.ModbusDebugInput, Modbusconfig.Default.ModbusDebugInputPort,0));
                GlobalProperties.DevicesOutput.Add(new ModbusOutput(Modbusconfig.Default.ModbusDebugOutput, Modbusconfig.Default.ModbusDebugOutputPort,0));
            }
            else
            {
                GlobalProperties.DevicesInput.Add(new ModbusInput(IPModbusInput));
                GlobalProperties.DevicesOutput.Add(new ModbusOutput(IPModbusOutput));
            }

            Application.DoEvents();

            // Do Connect Modbus Input
            foreach (ModbusInput device in GlobalProperties.DevicesInput)
            {
                device.StartLogging();
            }

            // Do Connect Modbus Output
            foreach (ModbusOutput device in GlobalProperties.DevicesOutput)
            {
                device.StartLogging();
            }

            // Set Device to Actions Lamp
            Actions.DeviceOutput = GlobalProperties.DevicesOutput[0];

            // Start Logging
            TaskLogging.Start();
        }
        #endregion

        #region Core - Auto
        private void DoLogging()
        {
            var DeviceOutput = GlobalProperties.DevicesOutput[0];
            var DeviceInput = GlobalProperties.DevicesInput[0];

            // GET Max Min value Mixing
            int MaxMixing = CoreLS.Default.MaxMixing;
            int MinMixing = CoreLS.Default.MinMixing;

            // GET Max Min
            int MaxDrum = CoreLS.Default.MaxDrum;
            int MinDrum = CoreLS.Default.MinDrum;

            // GET Max Min value Measure
            int MaxMeasure = CoreLS.Default.MaxMeasure;
            int MinMeasure = CoreLS.Default.MinMeasure;

            // Default Channel dikurang 1
            const int ValveCoolant = 14;
            const int ValveWater   = 13;
            const int PumpDrum    = 11;
            const int PumpDist    = 10;
            const int Propeler     = 12;

            const int Interlock = 9;

            // Addr Lamp
            const int LampGreen   = 7;
            const int LampOrange  = 6;
            const int LampRed     = 8;
            const int LampWhite   = 5;

            // Value Modbus Input (Feedback)
            int StatusValveWater;
            int StatusValveCoolant;

            Task TaskPropeler = new Task(() =>
            {
                while (Logging)
                {
                    Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.Propeler);
                    DeviceOutput.SetBit(Propeler);
                    Thread.Sleep(PropelerCycleTime);

                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.Propeler);
                    DeviceOutput.ResetBit(Propeler);
                    Thread.Sleep(PropelerCycleTime);
                }
            });
            TaskPropeler.Start();

            Task TaskEmergency = new Task(() =>
            {
                while (Logging)
                {
                    DeviceInput.GetData("CHA7", out int Feedback);
                    if(Feedback == 1)
                    {
                        Actions.SetIndicator(4);
                        Emergency("EMERGENCY\nMODE","Emergency Alert",true);
                    }
                    Thread.Sleep(EmergencyBtnCycleTime);
                }
            });
            TaskEmergency.Start();

            Task TaskRealtime = new Task(() =>
            {
                byte CounterError = 0;
                while (Logging)
                {
                    try
                    {
                        // SET Modbus Status
                        if(DeviceInput.ConnectionStatus && DeviceOutput.ConnectionStatus)
                        {
                            bool result = (DeviceInput.IsLogging && DeviceOutput.IsLogging);
                            GlobalProperties.ModbusInputStatus = (result) ? true : false;
                            GlobalProperties.ModbusOutputStatus = (result) ? true : false;
                        }
                        else
                        {
                            GlobalProperties.ModbusInputStatus = false;
                            GlobalProperties.ModbusOutputStatus = false;
                        }

                        if (GlobalProperties.DatabaseStatus)
                        {
                            // GET Value from Modbus Input (Drum)
                            DeviceInput.GetData("CHA14", out MixingValue);
                            DeviceInput.GetData("CHA15", out MeasureValue);
                            DeviceInput.GetData("CHA16", out DrumValue);

                            // GET Value from Modbus Input (Feedback)
                            DeviceInput.GetData("CHA11", out StatusValveWater);
                            DeviceInput.GetData("CHA13", out StatusValveCoolant);

                            // Get Max Min Volt Level Sensor
                            DB_SFDB.GetLoadingMaxMin("DRUM", out int ValueMaxDrum, out int ValueMinDrum);
                            DB_SFDB.GetLoadingMaxMin("MEASSURE", out int ValueMaxMeasure, out int ValueMinMeasure);
                            DB_SFDB.GetLoadingMaxMin("MIXING", out int ValueMaxMixing, out int ValueMinMixing);

                            // Real Input Value --> publicproperties.value
                            GlobalProperties.Value[0] = (int)Conversion.DrumPercentage(MixingValue, ValueMaxMixing, ValueMinMixing);
                            GlobalProperties.Value[1] = (int)Conversion.DrumPercentage(MeasureValue, ValueMaxMeasure, ValueMinMeasure);
                            GlobalProperties.Value[2] = (int)Conversion.DrumPercentage(DrumValue, ValueMaxDrum, ValueMinDrum);
                        }
                        else
                        {
                            GlobalProperties.Value[0] = GlobalProperties.Value[1] = GlobalProperties.Value[2] = 0;
                        }
                        CounterError = 0;
                    }
                    catch (Exception e)
                    {
                        Error.Collect(e.StackTrace.ToString());
                        Debug.WriteLine(e.StackTrace);
                        if (!ApplicationModeDebug)
                        {
                            if (CounterError > ValueNumberTimeout)
                            {
                                Emergency("Internal Error \nDrum Unknown Value Number", "Unknown Value", true);
                            }
                            else
                            {
                                CounterError++;
                            }
                        }
                    }
                    Thread.Sleep(100);
                }
            });
            TaskRealtime.Start();

            Task TaskLampStatus = new Task(() =>
            {
                DeviceOutput.SetBit(LampWhite);
                while (Logging)
                {
                    try
                    {
                        if (DeviceOutput.IsLogging)
                        {
                            if (GlobalProperties.CurrentStatus == GlobalProperties.Status.Ready)
                            {
                                DeviceOutput.SetBit(LampGreen);
                                DeviceOutput.ResetBit(LampRed);
                                DeviceOutput.ResetBit(LampOrange);
                            }
                            else if (GlobalProperties.CurrentStatus == GlobalProperties.Status.Filling)
                            {
                                DeviceOutput.SetBit(LampGreen);
                                DeviceOutput.ResetBit(LampOrange);
                            }   
                            else if (GlobalProperties.CurrentStatus == GlobalProperties.Status.Error)
                            {
                                DeviceOutput.SetBit(LampOrange);
                                DeviceOutput.ResetBit(LampGreen);
                            }
                            else if(GlobalProperties.CurrentStatus == GlobalProperties.Status.Emergency)
                            {
                                DeviceOutput.SetBit(LampRed);
                                DeviceOutput.ResetBit(LampGreen);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Core.Log.Error.Collect(e.StackTrace.ToString());
                    }
                    Thread.Sleep(1000);
                }
            });
            TaskLampStatus.Start();

            Task TaskCheckPump = new Task(() =>
            {
                while (Logging)
                {
                    try
                    {
                        if (GlobalProperties.DatabaseStatus && DeviceInput.IsLogging && DeviceOutput.IsLogging)
                        {
                            int result = DB_SFDB.GetPumpStatus();
                            if (result == 1)
                            {
                                DeviceOutput.SetBit(PumpDist);
                                Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.PumpDist);
                            }
                            else
                            {
                                DeviceOutput.ResetBit(PumpDist);
                                Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.PumpDist);
                            }
                        }
                    }
                    catch (Exception e) 
                    {
                        Debug.WriteLine(e.ToString());
                    }
                    Thread.Sleep(1000);
                }
            });
            TaskCheckPump.Start();

            // COUNTER ERROR
            byte DBCounter = 0;
            byte SDCounter = 0;

            while (Logging)
            {
                Thread.Sleep(500);

                try
                {
                    if ((DeviceInput.ConnectionStatus && DeviceInput.IsLogging) && (DeviceOutput.ConnectionStatus && DeviceOutput.IsLogging))
                    {
                        SDCounter = 0;
                        if (GlobalProperties.DatabaseStatus)
                        {
                            // ONLY EXECUTE AT START (ONCE)
                            if (!FLAG_ATSTART)
                            {
                                DeviceOutput.SetBit(Interlock);
                                FLAG_ATSTART = true;
                            }

                            DBCounter = 0;
                            if (MixingValue <= MinMixing)
                            {
                                if (DrumValue <= MinDrum)
                                {
                                    DeviceOutput.ResetBit(PumpDrum);
                                    DeviceOutput.ResetBit(ValveWater);
                                    DeviceOutput.ResetBit(ValveCoolant);

                                    FLAG_COUNTER_WATER = false;
                                    FLAG_COUNTER_COOLANT = false;

                                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveWater);
                                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveCoolant);
                                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.PumpDrum);

                                    // Alert Change Drum
                                    GlobalProperties.ChangeDrumNotify = GlobalProperties.Drum.Alert;
                                }
                                else
                                {
                                    // START FILLING WATER
                                    GlobalProperties.ChangeDrumNotify = (DrumValue <= MinDrum) ? GlobalProperties.Drum.Alert : GlobalProperties.Drum.None;
                                    StartCounterFilling();
                                    int i = 0;
                                    bool FirstFillingWater = false;
                                    while(i < FillingWaterDuration)
                                    {
                                        if (!FirstFillingWater)
                                        {
                                            DeviceOutput.SetBit(ValveWater);
                                            StartCounterWater();
                                            StartElapsedFillingWater();
                                            Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.ValveWater);
                                            FirstFillingWater = true;
                                        }

                                        if(MixingValue >= MaxMixing)
                                        {
                                            i = 100000;
                                        }

                                        Thread.Sleep(1000);
                                        i++;
                                    }
                                    DeviceOutput.ResetBit(ValveWater);
                                    FLAG_COUNTER_WATER = false; // STOP COUNTER WATER
                                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveWater);

                                    // START FILLING COOLANT
                                    int j = 0;
                                    bool FirstFillingCoolant = false;
                                    while (j < FillingCoolantDuration)
                                    {
                                        if (!FirstFillingCoolant)
                                        {
                                            DeviceOutput.SetBit(PumpDrum);
                                            DeviceOutput.SetBit(ValveCoolant);
                                            StartCounterCoolant();
                                            StartElapsedFillingCoolant();

                                            Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.ValveCoolant);
                                            Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.PumpDrum);
                                            FirstFillingCoolant = true;
                                        }
                                        GlobalProperties.ChangeDrumNotify = (DrumValue <= MinDrum) ? GlobalProperties.Drum.Alert : GlobalProperties.Drum.None;
                                        while (GlobalProperties.ChangeDrumNotify == GlobalProperties.Drum.Alert)
                                        {
                                            DeviceOutput.ResetBit(PumpDrum);
                                            DeviceOutput.ResetBit(ValveCoolant);
                                            FLAG_COUNTER_COOLANT = false;

                                            Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveCoolant);
                                            Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.PumpDrum);
                                            if(DrumValue <= MinDrum)
                                            {
                                                GlobalProperties.ChangeDrumNotify = GlobalProperties.Drum.Alert;
                                            }
                                            else if (DrumValue >= MaxDrum)
                                            {
                                                GlobalProperties.ChangeDrumNotify = GlobalProperties.Drum.None;
                                                DeviceOutput.SetBit(PumpDrum);
                                                DeviceOutput.SetBit(ValveCoolant);
                                                StartCounterCoolant();
                                                StartElapsedFillingCoolant();

                                                Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.ValveCoolant);
                                                Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.PumpDrum);
                                            }
                                            //PublicProperties.ChangeDrumNotify = (DrumValue <= MinDrum) ? PublicProperties.Drum.Alert : PublicProperties.Drum.None;
                                            Thread.Sleep(1000);
                                        }
                                        if (MixingValue >= MaxMixing)
                                        {
                                            j = 10000;
                                        }

                                        j++;
                                        Thread.Sleep(1000);
                                    }

                                    // STOP COUNTER FILLING (WATER/COOLANT)
                                    FLAG_COUNTER_FILLING = false;
                                    Thread.Sleep(100);

                                    DeviceOutput.ResetBit(PumpDrum);
                                    DeviceOutput.ResetBit(ValveCoolant);
                                    FLAG_COUNTER_COOLANT = false;

                                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveCoolant);
                                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.PumpDrum);
                                }
                            }
                            GlobalProperties.ChangeDrumNotify = (DrumValue <= MinDrum) ? GlobalProperties.Drum.Alert : GlobalProperties.Drum.None;
                        }
                        else
                        {
                            if (DBCounter > 19)
                            {
                                if (!FLAG_EMERGENCY)
                                {
                                    Emergency("Can't Connect to Server", "Database Timeout " + DBCounter,true);
                                    DeviceOutput.ResetAllBit();
                                }
                            }
                            else { DBCounter++; }
                        }
                    }
                    else
                    {
                        if (SDCounter > 10)
                        {
                            if (!FLAG_EMERGENCY)
                            {
                                Emergency("Smartdevice Disconnected", DeviceInput.IpAddress + "/" + DeviceOutput.IpAddress + " Disconnected");
                                DeviceOutput.ResetAllBit();
                            }
                        } else
                        SDCounter++;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    Error.Collect(e.StackTrace.ToString());
                }
            }
        }
        #endregion

        #region Counter
        Stopwatch CounterFilling = new Stopwatch();
        Stopwatch CounterValveWater = new Stopwatch();
        Stopwatch CounterValveCoolant = new Stopwatch();
        private void StartCounterFilling()
        {
            if (!FLAG_COUNTER_FILLING)
            {
                CounterFilling.Reset();
                CounterFilling.Start();
                FLAG_COUNTER_FILLING = true;

                Task TaskCounterFilling = new Task(() =>
                {
                    int _CompareLevelMixing = 999;
                    while (FLAG_COUNTER_FILLING)
                    {
                        if(MixingValue != _CompareLevelMixing)
                        {
                            CounterFilling.Reset();
                            CounterFilling.Start();
                            _CompareLevelMixing = MixingValue;
                            FLAG_EMERGENCY = false;
                        }
                        else
                        {
                            if (GlobalProperties.ChangeDrumNotify == GlobalProperties.Drum.Alert)
                            {
                                CounterFilling.Reset();
                                CounterFilling.Start();
                            }
                            else
                            {
                                if (CounterFilling.ElapsedMilliseconds > CounterFillingTimeout)
                                {
                                    FLAG_COUNTER_FILLING = false;
                                    FLAG_EMERGENCY = false;
                                    Emergency("Level Sensor", "Level Sensor Error Timeout ");
                                }
                            }
                        }
                        Thread.Sleep(1000);
                    }
                });
                TaskCounterFilling.Start();
            }
        }

        private void StartCounterWater()
        {
            if (!FLAG_COUNTER_WATER)
            {
                ModbusInput DeviceInput = GlobalProperties.DevicesInput[0];
                CounterValveWater.Reset();
                CounterValveWater.Start();
                FLAG_COUNTER_WATER = true;

                Task task = new Task(() =>
                {
                    while (FLAG_COUNTER_WATER)
                    {
                        DeviceInput.GetData("CHA10", out int FeedbackOn);
                        DeviceInput.GetData("CHA11", out int FeedbackOff);

                        if (FeedbackOn == 1 && FeedbackOff == 0)
                        {
                            CounterValveWater.Stop();
                            FLAG_COUNTER_WATER = false;
                        }
                        else
                        {
                            if(CounterValveWater.ElapsedMilliseconds > CounterWaterTimeout)
                            {
                                Emergency("Valve Water Error\nCant Open Valve Water", "Unknown Feedback Result", true);
                                FLAG_COUNTER_WATER = false;
                            }
                        }
                        Thread.Sleep(1000);
                    }
                });
                task.Start();
            }
        }

        private void StartCounterCoolant()
        {
            if (!FLAG_COUNTER_COOLANT)
            {
                ModbusInput DeviceInput = GlobalProperties.DevicesInput[0];
                CounterValveCoolant.Reset();
                CounterValveCoolant.Start();
                FLAG_COUNTER_COOLANT = true;

                Task task = new Task(() =>
                {
                    while (FLAG_COUNTER_COOLANT)
                    {
                        DeviceInput.GetData("CHA12",out int FeedbackOn);
                        DeviceInput.GetData("CHA13", out int FeedbackOff);
                        if(FeedbackOn == 1 && FeedbackOff == 0)
                        {
                            CounterValveCoolant.Stop();
                            FLAG_COUNTER_COOLANT = false;
                        }
                        else
                        {
                            if(CounterValveCoolant.ElapsedMilliseconds > CounterCoolantTimeout)
                            {
                                Emergency("Valve Coolant Error\nCant Open Valve Coolant", "Unknown Feedback Result", true);
                                FLAG_COUNTER_COOLANT = false;
                            }
                        }
                        Thread.Sleep(1000);
                    }
                });
                task.Start();
            }
        }

        #endregion

        #region Safety
        public void Emergency(string details, string reason, bool ForceStop = false)
        {
            if (!FLAG_EMERGENCY)
            {
                Logging = false; // STOPPING ALL TASKS
                FLAG_COUNTER_FILLING = FLAG_COUNTER_COOLANT = FLAG_COUNTER_WATER = false;
                FLAG_EMERGENCY = true;

                using (ActionRestart action = new ActionRestart())
                {
                    action.Details = details;
                    action.Reason = reason;
                    action.ForceStopAll = ForceStop;
                    action.ShowDialog();
                }
            }
        }
        #endregion

        #region Time Elapsed
        
        int CountdownWater;
        DateTime dtW = new DateTime();
        System.Timers.Timer TimerWater;
        private void StartElapsedFillingWater()
        {
            if (!FLAG_ELAPSEDFILLING_WATER)
            {
                FLAG_ELAPSEDFILLING_WATER = true;
                CountdownWater = FillingWaterDuration;
                
                TimerWater = new System.Timers.Timer(1000);
                TimerWater.AutoReset = true;
                TimerWater.Elapsed += TimerWater_Elapsed;
                TimerWater.Enabled = false;
                TimerWater.Start();
            }
        }

        private void TimerWater_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CountdownWater--;
            if ((GlobalProperties.ValveWater == GlobalProperties.Valve.Open) && (CountdownWater != 0))
            {
                GlobalProperties.TimelapseValveWater = dtW.AddSeconds(CountdownWater).ToString("HH:mm:ss");
            }
            else
            {
                GlobalProperties.TimelapseValveWater = "00:00:00";
                FLAG_ELAPSEDFILLING_WATER = false;
                TimerWater.Stop();
            }
        }


        int CountdownCoolant;
        DateTime dtC = new DateTime();
        System.Timers.Timer TimerCoolant;
        private void StartElapsedFillingCoolant()
        {
            if (!FLAG_ELAPSEDFILLING_COOLANT)
            {
                FLAG_ELAPSEDFILLING_COOLANT = true;
                CountdownCoolant = FillingCoolantDuration;

                TimerCoolant = new System.Timers.Timer(1000);
                TimerCoolant.AutoReset = true;
                TimerCoolant.Elapsed += TimerCoolant_Elapsed;
                TimerCoolant.Enabled = false;
                TimerCoolant.Start();
            }
        }

        private void TimerCoolant_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CountdownCoolant--;
            if ((GlobalProperties.ValveCoolant == GlobalProperties.Valve.Open) && (CountdownCoolant != 0))
            {
                GlobalProperties.TimelapseValveCoolant = dtC.AddSeconds(CountdownCoolant).ToString("HH:mm:ss");
            }
            else
            {
                GlobalProperties.TimelapseValveCoolant = "00:00:00";
                FLAG_ELAPSEDFILLING_COOLANT = false;
                TimerCoolant.Stop();
            }
        }
        #endregion

        #region Header Navigation
        private void HeaderNavigationSelected(Form frm, byte index=0)
        {
            if(frm != LastOpened)
            {
                LastOpened.Hide();
                lblDashboard.ForeColor = Color.FromArgb(171, 170, 177);
                lblTasklist.ForeColor = Color.FromArgb(171, 170, 177);
                dotDashboard.Visible = dotTasklist.Visible = dotPreferences.Visible = false;

                switch (index)
                {
                    case 1:
                        lblDashboard.ForeColor = Color.White;
                        dotDashboard.Visible = true;
                        break;

                    case 2:
                        lblTasklist.ForeColor = Color.White;
                        dotTasklist.Visible = true;
                        break;

                    case 3:
                        dotPreferences.Visible = true;
                        break;

                    default:
                        break;
                }
                frm.Show();
                LastOpened = frm;
            }
        }
        #endregion

        #region Timer
        private void TimerErrorLogCollector_Tick(object sender, EventArgs e)
        {
            Core.Log.Error.SaveLog();
        }
        #endregion

        #region BackgroundWorker
        private void BgwMaintenance_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (GlobalProperties.DatabaseStatus)
                {
                    FLAG_MAINTENANCE = DB_SFDB.DailyLoadingStationCheck();
                }
            }
            catch (Exception x)
            {
                Core.Log.Error.Collect(x.StackTrace.ToString());
            }
        }

        private void BgwMaintenance_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!FLAG_MAINTENANCE)
            {
                if (!maintenance.Visible)
                {
                    maintenance.ShowDialog();
                }
            }
        }
        #endregion

        #region Event
        private void PanelMenu1_Click(object sender, EventArgs e)
        {
            HeaderNavigationSelected(dashboard, 1);
        }

        private void PanelMenu2_Click(object sender, EventArgs e)
        {
            HeaderNavigationSelected(tasklist, 2);
        }

        private void PanelMenu3_Click(object sender, EventArgs e)
        {
            //HeaderNavigationSelected(preferences, 3);
        }

        private void LblDashboard_Click(object sender, EventArgs e)
        {
            PanelMenu1_Click(panelMenu1, EventArgs.Empty);
        }

        private void LblTasklist_Click(object sender, EventArgs e)
        {
            PanelMenu2_Click(panelMenu2, EventArgs.Empty);
        }

        private void PbPreferences_Click(object sender, EventArgs e)
        {
            PanelMenu3_Click(panelMenu3, EventArgs.Empty);
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void TimerMT_Tick(object sender, EventArgs e)
        {
            if (!bgwMaintenance.IsBusy)
            {
                bgwMaintenance.RunWorkerAsync();
            }
        }
        #endregion
    }
}
