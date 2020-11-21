using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using EasyModbus;

using loadingStation.Base.Configuration.Config;
using loadingStation.Base.Function;
using loadingStation.Base.Log;
using System.Collections;

namespace loadingStation.Base.Connection.Devices.Smartdevice
{
    class ModbusAichi : IDisposable
    {
        #region Dispose Methode
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        System.Runtime.InteropServices.SafeHandle handle = new Microsoft.Win32.SafeHandles.SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion

        #region Properties

        private const int MAX_ERROR_COUNTER = 3;

        private const string LEVEL_NAME = "LEVEL";
        private const int LEVEL_DEFAULT_VALUE = 110;
        private const int SMART_MAX_CHANNEL = 16;
        private const int SMART_START_ADDRESS = 101;

        private Queue QueueList = new Queue();

        private string _IpAddress;
        private int _Port;
        private byte _UID;
        private int _TimeOut;
        private int _LoggingInterval;
        private bool _IsValidDevice;
        private bool _ForceValid = true;
        private bool _Connected = false;

        private bool LogCycleEnable;

        private double _LevelTopVoltage;
        private double _LevelBottomVoltage;

        private readonly string[] KeyArray = { "CHA1","CHA2","CHA3", "CHA4", "CHA5", "CHA6", "CHA7", "CHA8", "CHA9", "CHA10",
                                               "CHA11", "CHA12", "CHA13", "CHA14", "CHA15","CHA16",LEVEL_NAME };

        private readonly string[] KeyStatus = { "Connected", "Disconnected", "Reconnecting", "Logging", "Paused", "Invalid" };

        private Dictionary<string, int> Dict_Key = new Dictionary<string, int>();
        private int[] intResult = new int[SMART_MAX_CHANNEL - 1];

        private ModbusClient _ModBusClient = new ModbusClient();

        public string IpAddress
        {
            get { return _IpAddress; }
            set { _IpAddress = value; }
        }

        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        public byte UID
        {
            get { return _UID; }
            set { _UID = value; }
        }

        public int TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

        public int LoggingInterval
        {
            get { return _LoggingInterval; }
            set { _LoggingInterval = value; }
        }

        public bool IsLogging
        {
            get { return LogCycleEnable; }
        }

        public bool IsValidDevice
        {
            get { return _IsValidDevice; }
        }

        public bool ForceValid
        {
            set { _ForceValid = value; }
        }
        public int[] GetDataArray()
        {
            return intResult;
        }
        public bool GetData(string key, out int Value)
        {
            try
            {
                Value = Dict_Key[key];
                return true;
            }
            catch
            {
                Value = 0;
                return false;
            }
        }

        public bool ConnectionStatus
        {
            get { return _Connected; }
        }

        #endregion

        public ModbusAichi(string ip, int port = 502, byte uid = 254, int timeout = 1000, int loggingInterval = 500)
        {
            _IpAddress = ip;
            _Port = port;
            _UID = uid;
            _TimeOut = timeout;
            _LoggingInterval = loggingInterval;

            CreateDictionary();
            ResetDictionary();

            _ModBusClient.IPAddress = _IpAddress;
            _ModBusClient.Port = _Port;
            _ModBusClient.UnitIdentifier = _UID;
            _ModBusClient.ConnectionTimeout = _TimeOut;
        }

        #region Device : <IsValidDevice>
        bool isValidDevice()
        {
            bool result = false;
            try
            {
                int[] GetSerial = _ModBusClient.ReadHoldingRegisters(1, 4);

                string SerialNumber = string.Format("{0}{1}{2}{3}"
                                                    , GetSerial[0].ToString()
                                                    , GetSerial[1].ToString()
                                                    , GetSerial[2].ToString()
                                                    , GetSerial[3].ToString());

                bool Check = Conversion.CheckDevice(int.Parse(SerialNumber));
                _IsValidDevice = (Check) ? true : false;
                result = (Check) ? true : false;
            }
            catch (Exception e)
            {
                Log.Error.Collect(e.StackTrace.ToString());
            }

            return result;
        }
        #endregion

        #region Dictionary : <CreateDictionary/ResetDictionary>
        private void CreateDictionary()
        {
            foreach (string st in KeyArray)
            {
                Dict_Key.Add(st, 0);
            }
        }
        private void ResetDictionary()
        {
            foreach (string st in KeyArray)
            {
                Dict_Key[st] = 0;
            }
            Dict_Key[LEVEL_NAME] = LEVEL_DEFAULT_VALUE;
        }
        #endregion

        public void SetReset(char CoolantType)
        {
            QueueList.Enqueue(Reset(CoolantType));
        }

        private bool Reset(char CoolantType)
        {
            try
            {
                int CoolantAddrHI = 0, CoolantAddrLO = 0;
                int WaterAddrHI = 0, WaterAddrLO = 0;

                int StartAddress;
                int[] value;

                if (CoolantType is 'A')
                {
                    CoolantAddrHI = 103; 
                    CoolantAddrLO = 104;

                    WaterAddrHI = 105;
                    WaterAddrLO = 106;

                    StartAddress = CoolantAddrHI;
                    value = new int[] { 0,0,0,0};
                }

                else if (CoolantType is 'B')
                {
                    CoolantAddrHI = 107;
                    CoolantAddrLO = 108;

                    WaterAddrHI = 109;
                    WaterAddrLO = 110;

                    StartAddress = CoolantAddrHI;
                    value = new int[] { 0, 0, 0, 0 };
                }

                else if (CoolantType is 'C')
                {
                    CoolantAddrHI = 111;
                    CoolantAddrLO = 112;

                    WaterAddrHI = 113;
                    WaterAddrLO = 114;

                    StartAddress = CoolantAddrHI;
                    value = new int[] { 0, 0, 0, 0 };
                }

                else
                {
                    StartAddress = 103;
                    value = new int[] { 0, 0, 0, 0 };
                }

                if( CoolantAddrHI != 0)
                {
                    // Reset Aichi Coolant HI LO
                    _ModBusClient.WriteMultipleRegisters(StartAddress - 1, value);

                    Debug.WriteLine($"AICHI RESET {CoolantType}");
                }
            }
            catch (Exception x)
            {
                Error.Collect(x.StackTrace.ToString());
            }

            return true;
        }

        public void StartLogging()
        {
            try
            {
                if (!GlobalProperties.Configuration.IsDebugging)
                {
                    if (_ForceValid)
                    {
                        _IsValidDevice = true;
                    }
                    else
                    {
                        isValidDevice();
                    }
                }
                else
                {
                    _IsValidDevice = true;
                }
            }
            catch (Exception e)
            {
                _IsValidDevice = false;
                Log.Error.Collect(e.StackTrace.ToString());
            }

            if (_IsValidDevice)
            {
                if (!LogCycleEnable)
                {
                    LogCycleEnable = true;

                    Task TaskLogging = new Task(() => DoLogging());
                    TaskLogging.Start();
                }
            }
        }

        public void StopLogging()
        {
            LogCycleEnable = false;
        }

        private void DoLogging()
        {
            Stopwatch myStopWatch = new Stopwatch();
            int[] Data = new int[SMART_MAX_CHANNEL];
            int Counter = 0;

            while (LogCycleEnable)
            {
                myStopWatch.Reset();
                myStopWatch.Start();

                // do stuff here
                try
                {
                    if (_Connected)
                    {
                        Debug.WriteLine(_IpAddress + ": Connected..");

                        Data = _ModBusClient.ReadHoldingRegisters(SMART_START_ADDRESS - 1, SMART_MAX_CHANNEL);

                        Dict_Key[KeyArray[0]] = Data[0];

                        Counter = 0;

                        foreach (int intData in Data)
                        {
                            Dict_Key[KeyArray[Counter]] = Data[Counter];
                            Counter++;
                        }

                        Dict_Key[LEVEL_NAME] = (int)Conversion.Maps(_LevelBottomVoltage, _LevelTopVoltage, Data[14]);

                        // Write Reset (If Added)
                        if(QueueList.Count != 0)
                        {
                            Thread.Sleep(500);
                            QueueList.Dequeue();
                        }

                        myStopWatch.Stop();
                    }
                    else
                    {
                        _ModBusClient.Connect();
                        _Connected = true;
                        Debug.WriteLine(_IpAddress + ": Connecting..");
                    }

                }
                catch (Exception e)
                {
                    Counter++;                              // Increment Counter Error

                    if (Counter > MAX_ERROR_COUNTER)        // If Counter then Reset All Result
                    {
                        Counter = 0;
                    }

                    _Connected = false;
                    Debug.WriteLine(_IpAddress + " : Error" + e);
                }

                myStopWatch.Stop();

                if (myStopWatch.ElapsedMilliseconds < _LoggingInterval)
                {
                    Thread.Sleep((int)(_LoggingInterval - myStopWatch.ElapsedMilliseconds));
                }

                Debug.WriteLine(String.Format(" Input Execution Time : {0}", myStopWatch.ElapsedMilliseconds));
            }
        }

        ~ModbusAichi()
        {
            _ModBusClient.Disconnect();
        }
    }
}
