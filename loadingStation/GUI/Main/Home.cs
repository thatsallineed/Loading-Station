using Core;
using loadingStation.Base.Configuration.Config;
using loadingStation.Base.Connection.Database;
using loadingStation.Base.Connection.Devices.Smartdevice;
using loadingStation.Base.Function;
using loadingStation.Base.Log;
using loadingStation.GUI.Act;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loadingStation.GUI.Main
{
    public partial class Home : Form
    {
        #region Properties
        private Dashboard dashboard = new Dashboard();
        private Tasklist tasklist = new Tasklist();
        private ReadyMaintenance maintenance = new ReadyMaintenance();

        private bool Logging
        {
            get { return GlobalProperties.FLAG_LOGGING; }
            set { GlobalProperties.FLAG_LOGGING = value; }
        }

        private bool DeviceLoaded
        {
            get { return GlobalProperties.FLAG_DEVICELOADED; }
            set { GlobalProperties.FLAG_DEVICELOADED = value; }
        }

        private bool FLAG_EMERGENCY 
        { 
            get { return GlobalProperties.FLAG_EMERGENCY; } 
            set { GlobalProperties.FLAG_EMERGENCY = value; } 
        }
        private bool FLAG_MAINTENANCE { 
            get { return GlobalProperties.FLAG_MAINTENANCE; } 
            set { GlobalProperties.FLAG_MAINTENANCE = value; } 
        }
        private bool FLAG_ATSTART 
        { 
            get { return GlobalProperties.FLAG_ATSTART; } 
            set { GlobalProperties.FLAG_ATSTART = value; } 
        }

        private bool ApplicationModeDebug
        {
            get { return (GlobalProperties.Configuration.IndicatorOnly || GlobalProperties.Configuration.IsDebugging); }
        }

        // Socket Client
        private Core.Connection.SocketClientSingle Socket;

        // Devices
        private ModbusInput DeviceInput;
        private ModbusOutput DeviceOutput;
        private ModbusAichi DevicePulse;
        private Task TaskLogging;

        // Tasks
        private Task TaskLoadModbus;

        // Controls
        private Form LastOpened;

        // Value Drum Modbus Input 
        private int MixingValue = 0;
        private int MeasureValue = 0;
        private int DrumValue = 0;

        // Minimum & Maximum Value
        private const int DistributionMinimum = 1;     // Distribution Minimum Mixing Value 10% Percent from max
        private const int MaximumMixingValue = 80;     // Maximum mixing value drum by percentage 80%

        // Filling Duration Timeout by Seconds
        private const int FillingWaterDuration = 101;   // (101 SECOND)
        private const int FillingCoolantDuration = 99;  // (99 SECOND)

        // Counter Timeout
        private int ValueNumberTimeout = CoreLS.Default.ValueNumberTimeout;
        private int PropelerCycleTime = (CoreLS.Default.PropelerCycleTime > 1000) ? CoreLS.Default.PropelerCycleTime : 3000;
        private int EmergencyBtnCycleTime = (CoreLS.Default.EmergencyBtnCycleTime > 200) ? CoreLS.Default.EmergencyBtnCycleTime : 500;
        private int CounterFillingTimeout = (CoreLS.Default.CounterFillingTimeout > 5000) ? CoreLS.Default.CounterFillingTimeout : 20000;
        private int CounterWaterTimeout = (CoreLS.Default.CounterWaterTimeout > 5000) ? CoreLS.Default.CounterWaterTimeout : 20000;
        private int CounterCoolantTimeout = (CoreLS.Default.CounterCoolantTimeout > 5000) ? CoreLS.Default.CounterCoolantTimeout : 20000;

        // Flags
        private bool FLAG_COUNTER_FILLING;
        private bool FLAG_COUNTER_WATER;
        private bool FLAG_COUNTER_COOLANT;
        private bool FLAG_ELAPSEDFILLING_WATER;
        private bool FLAG_ELAPSEDFILLING_COOLANT;
        #endregion

        public Home()
        {
            //LoadErrorEventHandler();
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

            // Start Task Realtime
            LoadTask();
            timerMT.Start();

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

            // SET OPENED LAST FORM
            LastOpened = dashboard;

            // Start Socket Server
            Base.Connection.Socket.Server.StartServer();

            // Start Socket Client
            Socket = new Core.Connection.SocketClientSingle(GlobalProperties.Configuration.SocketClientHost, 9090);
            Application.DoEvents();
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
            Base.Log.Error.Collect(exception);
            Base.Log.Error.Collect("is WARNING! UNEXCEPTION RESTART is");
            Actions.RelaunchApplication();
        }
        #endregion

        #region Load User Configuration
        private void LoadUserConfiguration()
        {
            // Load Logs Configuration
            int SaveDuration = Logs.Default.SaveLogDuration;
            timerErrorLogCollector.Interval = SaveDuration;
            panelDebug.Visible = (GlobalProperties.Configuration.IsDebugging || GlobalProperties.Configuration.IndicatorOnly) ? true : false;
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
                                if (GlobalProperties.FLAG_DEVICELOADED)
                                {
                                    lblTime.Text = DateTime.Now.ToString("HH:mm");
                                    lblSecond.Text = DateTime.Now.ToString("ss");

                                    bool check = (!DeviceInput.ConnectionStatus || !DeviceOutput.ConnectionStatus || !GlobalProperties.DatabaseStatus);
                                    panelNotification.Visible = (check) ? true : false;
                                    panelHeader.BackColor = (check) ? Color.FromArgb(235, 77, 75) : Color.FromArgb(88, 86, 99);
                                }

                                Debug.WriteLine($"DEVICELOADED: {DeviceLoaded}");
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
                    if (readconf is "A" || readconf is "B" || readconf is "C")
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
            string IPModbusPulse = "";

            while (GetIp)
            {
                if (IPModbusInput is "")
                {
                    try
                    {
                        if (GlobalProperties.DatabaseStatus)
                        {
                            // GET Modbus Input & Output IP Address
                            IPModbusInput = DB_SFDB.IpDigitalInput();
                            IPModbusOutput = DB_SFDB.IpDigitalOutput();
                            IPModbusPulse = DB_SFDB.IpDigitalPulse();
                            GetIp = false;
                        }

                        Debug.WriteLine($"INPUT: {IPModbusInput}, OUTPUT: {IPModbusOutput}, PULSE: {IPModbusPulse}");
                    }
                    catch { throw; }
                }
                else
                {
                    GetIp = false;
                }

                Thread.Sleep(500);
            }

            Debug.WriteLine(IPModbusInput);
            Debug.WriteLine(IPModbusOutput);
            Debug.WriteLine(IPModbusPulse);

            // Check This Application Is Debugging OR Not
            // AND Add Modbus Device(s)
            bool mode = GlobalProperties.Configuration.IsDebugging;
            Debug.WriteLine($"MODE: {mode}");

            if (mode)
            {
                GlobalProperties.DevicesInput.Add(GlobalProperties.Configuration.ModbusDebugInput, new ModbusInput(GlobalProperties.Configuration.ModbusDebugInput, GlobalProperties.Configuration.ModbusDebugInputPort, 0));
                GlobalProperties.DevicesOutput.Add(GlobalProperties.Configuration.ModbusDebugOutput, new ModbusOutput(GlobalProperties.Configuration.ModbusDebugOutput, GlobalProperties.Configuration.ModbusDebugOutputPort, 0));
                GlobalProperties.DevicesAichi.Add(GlobalProperties.Configuration.ModbusDebugInput, new ModbusAichi(GlobalProperties.Configuration.ModbusDebugInput, GlobalProperties.Configuration.ModbusDebugInputPort, 0));

                IPModbusOutput = IPModbusInput = IPModbusPulse = GlobalProperties.Configuration.ModbusDebugInput;
            }
            else
            {
                // smartdevice input
                GlobalProperties.DevicesInput.Add(IPModbusInput, new ModbusInput(IPModbusInput));

                if (GlobalProperties.CoolantType is 'A')
                {
                    // smartdevice input (pulse)
                    GlobalProperties.DevicesAichi.Add(IPModbusPulse, new ModbusAichi(IPModbusPulse));
                }

                // smartdevice output
                GlobalProperties.DevicesOutput.Add(IPModbusOutput, new ModbusOutput(IPModbusOutput));
            }

            Debug.WriteLine("doing events");
            Application.DoEvents();

            // Do Connect Modbus Input
            Debug.WriteLine("Connect to modbus input");
            foreach (ModbusInput device in GlobalProperties.DevicesInput.Values)
            {
                device.StartLogging();
            }

            // Do Connect Modbus Input Aichi
            Debug.WriteLine("Connect to modbus aichi");
            if (GlobalProperties.CoolantType is 'A')
            {
                foreach (ModbusAichi device in GlobalProperties.DevicesAichi.Values)
                {
                    device.StartLogging();
                }
            }

            // Do Connect Modbus Output
            Debug.WriteLine("Connect to modbus output");
            foreach (ModbusOutput device in GlobalProperties.DevicesOutput.Values)
            {
                device.StartLogging();
            }

            // Set Device to Actions Lamp
            Debug.WriteLine("set device output");
            Actions.DeviceOutput = GlobalProperties.DevicesOutput[IPModbusOutput];

            // Set Device
            Debug.WriteLine("set device all");
            GlobalProperties.DevicesOutput.TryGetValue(IPModbusOutput, out ModbusOutput DigitalOutput);
            GlobalProperties.DevicesInput.TryGetValue(IPModbusInput, out ModbusInput DigitalInput);
            GlobalProperties.DevicesAichi.TryGetValue(IPModbusPulse, out ModbusAichi DigitalAichi);

            Debug.WriteLine($"{DigitalOutput is null} | {DigitalInput is null} | {DigitalAichi is null}");

            DeviceOutput = DigitalOutput;
            DeviceInput = DigitalInput;

            GlobalProperties.ModbusOutput = DeviceOutput;
            GlobalProperties.ModbusInput = DeviceInput;

            if (GlobalProperties.CoolantType is 'A')
            {
                DevicePulse = DigitalAichi;
                GlobalProperties.ModbusPulse = DevicePulse;
            }

            // Start Logging
            Debug.WriteLine("start logging");
            TaskLogging.Start();

            // Set Flag
            Debug.WriteLine("set flags");
            GlobalProperties.FLAG_DEVICELOADED = true;
            Debug.WriteLine($"DEVICE LOADED, Flag: {GlobalProperties.FLAG_DEVICELOADED}");

        }
        #endregion

        #region Core - Auto
        private void DoLogging()
        {
            // GET Max Min value Mixing
            int LevelMixingMin = 38;
            int LevelMixingMax = 380;

            // GET Max Min
            int LevelDrumMin = 0;
            int LevelDrumMax = 380;

            // GET Max Min value Measure
            int LevelMeasureMin = 38;
            int LevelMeasureMax = 380;

            // GET Minimum Mixing Coolant
            int LevelMinimumCreateCoolant = 5; //by percentage (5%)

            // GET Filling Value
            double CoolantValue = CoreLS.Default.CoolantFillingValue;
            double WaterValue = CoreLS.Default.WaterFillingValue;

            // Pulse Value
            double CoolantPulse = 0;

            // Default Channel dikurang 1
            // Untuk Manual Modbus ditambah 1
            const int ValveCoolant = 14;
            const int ValveWater = 13;
            const int PumpDrum = 11;
            const int PumpDist = 10;
            const int Propeler = 12;

            const int Interlock = 9;

            // Addr Lamp
            const int LampGreen = 7;
            const int LampOrange = 6;
            const int LampRed = 8;
            const int LampWhite = 5;
            const int LampRotator = 1;

            // Value Modbus Input (Feedback)
            int StatusValveWater;
            int StatusValveCoolant;

            // Task Realtime Propeler
            Thread ThreadPropeler = new Thread(() =>
            {
                while (Logging)
                {
                    if (GlobalProperties.AllowPropeler)
                    {
                        Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.Propeler);
                        DeviceOutput.SetBit(Propeler);
                        Thread.Sleep(PropelerCycleTime);

                        Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.Propeler);
                        DeviceOutput.ResetBit(Propeler);
                        Thread.Sleep(PropelerCycleTime);
                    }

                    else
                    {
                        Thread.Sleep(2000);
                    }
                }
            });
            ThreadPropeler.Start();

            // Task Realtime Emergency
            Thread ThreadEmergency = new Thread(() =>
            {
                while (Logging)
                {
                    DeviceInput.GetData("CHA7", out int Feedback);
                    if (Feedback is 1)
                    {
                        Actions.SetIndicator(4);
                        DoEmergency("EMERGENCY\nMODE", "Emergency Alert", true);
                    }
                    Thread.Sleep(EmergencyBtnCycleTime);
                }
            });
            ThreadEmergency.Start();

            // Task Realtime
            Thread ThreadRealtime = new Thread(() =>
            {
                byte CounterError = 0;
                while (Logging)
                {
                    try
                    {
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

                            // Set to Main Variable
                            LevelDrumMin = ValueMinDrum;
                            LevelDrumMax = ValueMaxDrum;

                            LevelMeasureMin = ValueMinMeasure;
                            LevelMeasureMax = ValueMaxMeasure;

                            LevelMixingMin = ValueMinMixing;
                            LevelMixingMax = ValueMaxMixing;

                            // Real Input Value --> Global Properties
                            int Mixing = (int)Conversion.DrumPercentage(MixingValue, ValueMinMixing, ValueMaxMixing);
                            int Meassure = (int)Conversion.DrumPercentage(MeasureValue, ValueMinMeasure, ValueMaxMeasure);
                            int Drum = (int)Conversion.DrumPercentage(DrumValue, ValueMinDrum, ValueMaxDrum);

                            GlobalProperties.Value[0] = (Mixing >= 0 && Mixing <= 100) ? Mixing : 0;
                            GlobalProperties.Value[1] = (Meassure >= 0 && Meassure <= 100) ? Meassure : 0;
                            GlobalProperties.Value[2] = (Drum >= 0 && Drum <= 100) ? Drum : 0;
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
                                DoEmergency("Internal Error \nDrum Unknown Value Number", "Unknown Value", false);
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
            ThreadRealtime.Start();

            // Task Realtime Lamp Status
            Thread ThreadLampStatus = new Thread(() =>
            {
                DeviceOutput.SetBit(LampWhite);
                while (Logging)
                {
                    try
                    {
                        if (DeviceOutput.IsLogging)
                        {
                            if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Ready)
                            {
                                // Only Green
                                DeviceOutput.SetBit(LampGreen);

                                DeviceOutput.ResetBit(LampRed);
                                DeviceOutput.ResetBit(LampOrange);
                                DeviceOutput.ResetBit(LampWhite);
                            }
                            else if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Filling)
                            {
                                // Only White
                                DeviceOutput.SetBit(LampWhite);

                                DeviceOutput.ResetBit(LampRed);
                                DeviceOutput.ResetBit(LampOrange);
                                DeviceOutput.ResetBit(LampGreen);
                            }
                            else if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Changedrum)
                            {
                                // Only Orange
                                DeviceOutput.SetBit(LampOrange);

                                DeviceOutput.ResetBit(LampRed);
                                DeviceOutput.ResetBit(LampGreen);
                                DeviceOutput.ResetBit(LampWhite);
                            }
                            else if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Error)
                            {
                                // Only Red
                                DeviceOutput.SetBit(LampRed);

                                DeviceOutput.ResetBit(LampOrange);
                                DeviceOutput.ResetBit(LampGreen);
                                DeviceOutput.ResetBit(LampWhite);
                            }
                            else if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Emergency)
                            {
                                // Only Red
                                DeviceOutput.SetBit(LampRed);

                                DeviceOutput.ResetBit(LampOrange);
                                DeviceOutput.ResetBit(LampGreen);
                                DeviceOutput.ResetBit(LampWhite);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Error.Collect(e.StackTrace.ToString());
                    }
                    Thread.Sleep(1000);
                }
            });
            ThreadLampStatus.Start();

            // Task Realtime Check Pump
            Thread ThreadCheckPump = new Thread(() =>
            {
                while (Logging)
                {
                    try
                    {
                        if (GlobalProperties.DatabaseStatus && DeviceInput.IsLogging && DeviceOutput.IsLogging)
                        {
                            int result = DB_SFDB.GetPumpStatus();
                            if (result is 1 && GlobalProperties.CurrentStatus != GlobalProperties.Status.Mixing && GlobalProperties.CurrentStatus != GlobalProperties.Status.Emergency && GlobalProperties.CurrentStatus != GlobalProperties.Status.Error)
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
            ThreadCheckPump.Start();

            // Thread Realtime Device Status
            Thread ThreadDeviceStatus = new Thread(() =>
            {
                while (Logging)
                {
                    if (GlobalProperties.DatabaseStatus)
                    {
                        int State;

                        State = DeviceInput.ConnectionStatus ? 1 : 0;
                        DB_SFDB.UpdateDeviceStatus(DeviceInput.IpAddress, State);

                        State = DeviceOutput.ConnectionStatus ? 1 : 0;
                        DB_SFDB.UpdateDeviceStatus(DeviceOutput.IpAddress, State);
                    }
                    Thread.Sleep(1000);
                }
            });
            ThreadDeviceStatus.Start();

            // Thread Realtime Message Alert
            Thread ThreadMessageAlert = new Thread(() =>
            {
                while (Logging)
                {
                    try
                    {
                        if (GlobalProperties.DatabaseStatus)
                        {
                            bool MessageStatus = DB_SFDB.GetLoadingstationMessage(out string Message, out bool IsError);

                            if (MessageStatus)
                            {
                                if (IsError)
                                    DoEmergency("Error Detected from Coolant Tasklist", Message, false, true);
                                else
                                    DoInformation(Message);
                            }
                        }
                    }
                    catch (Exception x)
                    {
                        Debug.WriteLine(x.StackTrace);
                        Debug.WriteLine(x.Message);
                    }
                }
            });
            ThreadMessageAlert.Start();

            // Thread Realtime Message Alert Rotator
            // Only Loadingstation A
            Thread ThreadRotatorAlert = new Thread(() =>
            {
                while (Logging)
                {
                    try
                    {
                        if (GlobalProperties.DatabaseStatus)
                        {
                            bool MessageStatus = DB_SFDB.GetLoadingStationErrorMessageRotator();

                            if (MessageStatus)
                            {
                                DeviceOutput.SetBit(LampRotator);
                            }

                            else
                            {
                                DeviceOutput.ResetBit(LampRotator);
                            }
                        }
                    }
                    
                    catch (Exception x)
                    {
                        Debug.WriteLine(x.StackTrace);
                        Debug.WriteLine(x.Message);
                    }

                    Thread.Sleep(200);
                }
            });

            if(GlobalProperties.CoolantType is 'A')
            {
                ThreadRotatorAlert.Start();
            }



            // COUNTER ERROR
            byte DBCounter = 0;
            byte SDCounter = 0;
            byte SocketCounter = 0;

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
                                // Lock Interlock
                                DeviceOutput.SetBit(Interlock);

                                // GET Water & Coolant Pulse
                                DB_SFDB.Pulse(out CoolantPulse);

                                // Check Pulse Value
                                if (CoolantPulse <= 0)
                                    DoEmergency("Unknown Pulse Value", "Pulse Value <= 0", true);

                                FLAG_ATSTART = true;
                            }

                            Debug.WriteLine($"MixingValue: {MixingValue}, LevelMixingMin: {LevelMixingMin}, Drumvalue: {DrumValue}, Leveldrummin: {LevelDrumMin}");

                            if(GlobalProperties.CurrentStatus != GlobalProperties.Status.Manual)
                            {
                                DBCounter = 0; // error database counter
                                if (GlobalProperties.Value[0]  <= LevelMinimumCreateCoolant)
                                {
                                    if (DrumValue <= LevelDrumMin)
                                    {
                                        DeviceOutput.ResetBit(PumpDrum);
                                        DeviceOutput.ResetBit(ValveWater);
                                        DeviceOutput.ResetBit(ValveCoolant);

                                        FLAG_COUNTER_WATER = false;
                                        FLAG_COUNTER_COOLANT = false;

                                        // Close Valve Water,Coolant,Pump
                                        Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveWater);
                                        Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveCoolant);
                                        Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.PumpDrum);

                                        // Alert Change Drum
                                        GlobalProperties.ChangeDrumNotify = GlobalProperties.Drum.Alert;
                                    }
                                    else
                                    {
                                        while (true)
                                        {
                                            GlobalProperties.ChangeDrumNotify = (DrumValue <= LevelDrumMin) ? GlobalProperties.Drum.Alert : GlobalProperties.Drum.None;
                                            Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.ValveWater); // to trigger set status as (mixing)

                                            // Reset Aichi Value
                                            if (GlobalProperties.CoolantType is 'A')
                                            {
                                                DevicePulse.SetReset(GlobalProperties.CoolantType);
                                                break;
                                            }
                                            else
                                            {
                                                if (SocketCounter >= 20)
                                                {
                                                    DoEmergency("Cant Connect to Socket", "Connection Timed Out", true);
                                                }

                                                if (Socket.ConnectionState)
                                                {
                                                    var check = Socket.Query($"AICHI_RESET_{GlobalProperties.CoolantType}");
                                                    Debug.WriteLine($"check: {check}, SocketState: {Socket.ConnectionState}, IPaddr: {GlobalProperties.Configuration.SocketClientHost}");
                                                    if (check.ToString() is "")
                                                    {
                                                        DoEmergency("Error Aichi Value Reset", "Value is Null or Not Connected to Socket", true);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    SocketCounter++;
                                                }
                                            }
                                        }


                                        Thread.Sleep(5000);

                                        var resetcheck = Socket.Query($"AICHI_VALUE_{GlobalProperties.CoolantType}");
                                        if (resetcheck.ToString() != "")
                                        {
                                            double resetvalue = Helper.ConvertSplitInt(resetcheck.ToString())[3];
                                            if (resetvalue != 0)
                                            {
                                                Debug.WriteLine("Trying to Reset Aichi Value ");
                                                DevicePulse.SetReset(GlobalProperties.CoolantType);
                                                Thread.Sleep(3000);
                                            }
                                        }
                                        else
                                        {
                                            DoEmergency("Error Aichi Value Reset", "Value is Null or Not Connected to Socket", true);
                                        }


                                        // START FILLING WATER
                                        //StartCounterFilling();

                                        int CurrentLevelMixing = 0;
                                        int LimitMaxWater = CoreLS.Default.WaterFillingValue >= 0 ? CoreLS.Default.WaterFillingValue : 51; // by percentage
                                        bool FirstFillingWater = false;
                                        while (true)
                                        {
                                            Debug.WriteLine($"Water Filling, Current: {CurrentLevelMixing}, Target: {LimitMaxWater}, Mixing Value: {MixingValue},Max Level Mixing: {LevelMixingMax}");
                                            if (!FirstFillingWater)
                                            {
                                                DeviceOutput.SetBit(ValveWater);
                                                StartCounterWater();
                                                StartElapsedFillingWater();
                                                Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.ValveWater);
                                                FirstFillingWater = true;
                                            }

                                            CurrentLevelMixing = GlobalProperties.Value[0]; // converted to drum percentage value
                                            Debug.WriteLine($"Current Level Mixing {CurrentLevelMixing}");
                                            if (CurrentLevelMixing >= LimitMaxWater)
                                            {
                                                Debug.WriteLine("Current Level Mixing >=");
                                                break;
                                            }

                                            if (MixingValue >= LevelMixingMax)
                                            {
                                                Debug.WriteLine("Mixing Value >=");
                                                break;
                                            }

                                            Thread.Sleep(500);
                                        }
                                        DeviceOutput.ResetBit(ValveWater);
                                        FLAG_COUNTER_WATER = false; // STOP COUNTER WATER
                                        Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveWater);
                                        //Thread.Sleep(int.MaxValue); //testing


                                        // START FILLING COOLANT
                                        int LevelMixing = 0;
                                        double CoolantLitre = CoolantValue; // set coolantlitre as coolantvalue
                                        double CoolantLimit = Math.Round(CoolantLitre / CoolantPulse, 0);
                                        double CoolantLO;

                                        bool FirstFillingCoolant = false;

                                        CoolantValue = 0; // reset
                                        while (CoolantValue < CoolantLimit && LevelMixing <= MaximumMixingValue)
                                        {

                                            LevelMixing = GlobalProperties.Value[0]; // converted to drum percentage value

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

                                            var pulse = Socket.Query($"AICHI_VALUE_{GlobalProperties.CoolantType}");
                                            if (pulse.ToString() != "")
                                            {
                                                var value = Helper.ConvertSplitInt(pulse.ToString());

                                                CoolantLO = value[1];
                                                CoolantValue = CoolantLO;

                                                Debug.WriteLine("================================");
                                                Debug.WriteLine($"COOLANT LIMIT: {CoolantLimit}");
                                                Debug.WriteLine($"COOLANT LO: {CoolantLO}");
                                                Debug.WriteLine("================================");
                                            }
                                            else
                                            {
                                                DoEmergency("Cant Connect to Socket", "Value Null", true);
                                            }


                                            GlobalProperties.ChangeDrumNotify = (DrumValue <= LevelDrumMin) ? GlobalProperties.Drum.Alert : GlobalProperties.Drum.None;
                                            while (GlobalProperties.ChangeDrumNotify is GlobalProperties.Drum.Alert)
                                            {
                                                DeviceOutput.ResetBit(PumpDrum);
                                                DeviceOutput.ResetBit(ValveCoolant);
                                                FLAG_COUNTER_COOLANT = false;

                                                Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveCoolant);
                                                Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.PumpDrum);

                                                if (DrumValue <= LevelDrumMin)
                                                {
                                                    GlobalProperties.ChangeDrumNotify = GlobalProperties.Drum.Alert;
                                                }
                                                else if (DrumValue >= LevelDrumMax)
                                                {
                                                    GlobalProperties.ChangeDrumNotify = GlobalProperties.Drum.None;
                                                    DeviceOutput.SetBit(PumpDrum);
                                                    DeviceOutput.SetBit(ValveCoolant);
                                                    StartCounterCoolant();
                                                    StartElapsedFillingCoolant();

                                                    Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.ValveCoolant);
                                                    Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.PumpDrum);

                                                    var pulse1 = Socket.Query($"AICHI_VALUE_{GlobalProperties.CoolantType}");
                                                    if (pulse1.ToString() != "")
                                                    {
                                                        var value1 = Helper.ConvertSplitInt(pulse.ToString());

                                                        CoolantLO = value1[1];
                                                        CoolantValue = CoolantLO;

                                                        Debug.WriteLine("================================");
                                                        Debug.WriteLine($"COOLANT LIMIT: {CoolantLimit}");
                                                        Debug.WriteLine($"COOLANT LO: {CoolantLO}");
                                                        Debug.WriteLine("================================");
                                                    }
                                                    else
                                                    {
                                                        DoEmergency("Cant Connect to Socket", "Value Null", true);
                                                    }
                                                }

                                                //PublicProperties.ChangeDrumNotify = (DrumValue <= MinDrum) ? PublicProperties.Drum.Alert : PublicProperties.Drum.None;
                                                Thread.Sleep(50);
                                            }

                                            if (MixingValue >= LevelMixingMax)
                                            {
                                                CoolantValue = double.MaxValue;
                                            }

                                            Thread.Sleep(100);
                                        }

                                        // STOP COUNTER FILLING (WATER/COOLANT)
                                        FLAG_COUNTER_FILLING = false;
                                        Thread.Sleep(100);

                                        DeviceOutput.ResetBit(PumpDrum);
                                        DeviceOutput.ResetBit(ValveCoolant);
                                        FLAG_COUNTER_COOLANT = false;

                                        Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveCoolant);
                                        Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.PumpDrum);

                                        Thread.Sleep(int.MaxValue); //testing
                                    }
                                }
                            }

                            GlobalProperties.ChangeDrumNotify = (DrumValue <= LevelDrumMin) ? GlobalProperties.Drum.Alert : GlobalProperties.Drum.None;
                        }
                        else
                        {
                            if (DBCounter > 20)
                            {
                                if (!FLAG_EMERGENCY)
                                {
                                    DoEmergency("Can't Connect to Server", "Database Timeout " + DBCounter, true);
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
                                DoEmergency("Smartdevice Disconnected", DeviceInput.IpAddress + "/" + DeviceOutput.IpAddress + " Disconnected");
                                DeviceOutput.ResetAllBit();
                            }
                        }
                        else
                        {
                            SDCounter++;
                        }
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
        private Stopwatch CounterFilling = new Stopwatch();
        private Stopwatch CounterValveWater = new Stopwatch();
        private Stopwatch CounterValveCoolant = new Stopwatch();
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
                        if (MixingValue != _CompareLevelMixing)
                        {
                            CounterFilling.Reset();
                            CounterFilling.Start();
                            _CompareLevelMixing = MixingValue;
                            FLAG_EMERGENCY = false;
                        }
                        else
                        {
                            if (GlobalProperties.ChangeDrumNotify is GlobalProperties.Drum.Alert)
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
                                    DoEmergency("Level Sensor", "Level Sensor Error Timeout ",true);
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
                //ModbusInput DeviceInput = GlobalProperties.DevicesInput[0];
                CounterValveWater.Reset();
                CounterValveWater.Start();
                FLAG_COUNTER_WATER = true;

                Task task = new Task(() =>
                {
                    while (FLAG_COUNTER_WATER)
                    {
                        DeviceInput.GetData("CHA10", out int FeedbackOn);
                        DeviceInput.GetData("CHA11", out int FeedbackOff);

                        if (FeedbackOn is 1 && FeedbackOff is 0)
                        {
                            CounterValveWater.Stop();
                            FLAG_COUNTER_WATER = false;
                        }
                        else
                        {
                            if (CounterValveWater.ElapsedMilliseconds > CounterWaterTimeout)
                            {
                                DoEmergency("Valve Water Error\nCant Open Valve Water", "Unknown Feedback Result", true);
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
                //ModbusInput DeviceInput = GlobalProperties.DevicesInput[0];
                CounterValveCoolant.Reset();
                CounterValveCoolant.Start();
                FLAG_COUNTER_COOLANT = true;

                Task task = new Task(() =>
                {
                    while (FLAG_COUNTER_COOLANT)
                    {
                        DeviceInput.GetData("CHA12", out int FeedbackOn);
                        DeviceInput.GetData("CHA13", out int FeedbackOff);
                        if (FeedbackOn is 1 && FeedbackOff is 0)
                        {
                            CounterValveCoolant.Stop();
                            FLAG_COUNTER_COOLANT = false;
                        }
                        else
                        {
                            if (CounterValveCoolant.ElapsedMilliseconds > CounterCoolantTimeout)
                            {
                                DoEmergency("Valve Coolant Error\nCant Open Valve Coolant", "Unknown Feedback Result", true);
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
        public void DoEmergency(string details, string reason, bool ForceStop = false, bool AllowClose = false)
        {
            if (!FLAG_EMERGENCY)
            {
                FLAG_EMERGENCY = true;

                if (GlobalProperties.Configuration.IsDebugging)
                {
                    AllowClose = true;
                }

                if (ForceStop)
                {
                    Logging = false; // STOPPING ALL TASKS
                    FLAG_COUNTER_FILLING = FLAG_COUNTER_COOLANT = FLAG_COUNTER_WATER = false;
                }

                using (Emergency action = new Emergency())
                {
                    action.Details = details;
                    action.Reason = reason;
                    action.ForceStopAll = ForceStop;
                    action.AllowClose = AllowClose;
                    action.ShowDialog();
                }
            }
        }

        public void DoInformation(string Message)
        {
            using(Information form = new Information())
            {
                form.Message = Message;
                form.Autoclose = true;
                form.MaxTimeout = 5000;
                form.ShowDialog();
            }
        }
        #endregion

        #region Time Elapsed

        private int CountdownWater;
        private DateTime dtW = new DateTime();
        private System.Timers.Timer TimerWater;
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
            if ((GlobalProperties.ValveWater is GlobalProperties.Valve.Open) && (CountdownWater != 0) && Logging)
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

        private int CountdownCoolant;
        private DateTime dtC = new DateTime();
        private System.Timers.Timer TimerCoolant;
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
            if ((GlobalProperties.ValveCoolant is GlobalProperties.Valve.Open) && (CountdownCoolant != 0))
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
        private void HeaderNavigationSelected(Form frm, byte index = 0)
        {
            if (frm != LastOpened)
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
            Base.Log.Error.SaveLog();
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
                Base.Log.Error.Collect(x.StackTrace.ToString());
            }
        }

        private void BgwMaintenance_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!FLAG_MAINTENANCE && !GlobalProperties.Configuration.IsDebugging)
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
