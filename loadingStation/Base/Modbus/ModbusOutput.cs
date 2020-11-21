using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using EasyModbus;

using loadingStation.Core.Function;
using loadingStation.Core.Configuration.Config;

namespace loadingStation.Core.Modbus
{
    class ModbusOutput : IDisposable
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
        private const int SMART_ADDRESS = 100;

        private string _IpAddress;
        private int _Value;
        private int _Port;
        private byte _UID;
        private int _TimeOut;
        private int _LoggingInterval;
        private bool _IsValidDevice;
        private bool _ForceValid = true;
        private bool _Connected;

        private int _prevValue;

        private bool IsFirstLogging;                                // return true if first logging
        private bool LogCycleEnable;

        private bool TestOnly
        {
            get { return App.Default.IndicatorTestOnly; }
        }

        private ModbusClient _ModBusClient = new ModbusClient();

        public string IpAddress
        {
            get { return _IpAddress; }
            set { _IpAddress = value; }
        }

        public int Value
        {
            get { return _Value; }
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

        public bool IsValidDevice
        {
            get { return _IsValidDevice; }
        }
        public bool ForceValid
        {
            set { _ForceValid = value; }
        }

        public bool IsLogging
        {
            get { return LogCycleEnable; }
        }

        public bool ConnectionStatus
        {
            get { return _Connected; }
        }

        #endregion

        public ModbusOutput(string ip, int port = 502, byte uid = 254, int timeout = 1000, int loggingInterval = 500)
        {
            _IpAddress = ip;
            _Port = port;
            _UID = uid;
            _TimeOut = timeout;
            _LoggingInterval = loggingInterval;
            _Value = 0b1111_1111_1111_1111;                     // Off All Output

            _ModBusClient.IPAddress = _IpAddress;
            _ModBusClient.Port = _Port;
            _ModBusClient.UnitIdentifier = _UID;
            _ModBusClient.ConnectionTimeout = _TimeOut;

            IsFirstLogging = true;
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

        ~ModbusOutput()
        {
            _ModBusClient.Disconnect();
        }

        public void ResetBit(int bitPosition)
        {
            if(!TestOnly)
                _Value |= 1 << bitPosition;
        }

        public void SetBit(int bitPosition)
        {
            if (!TestOnly)
                _Value &= ~(1 << bitPosition);
        }

        public void ToggleBit(int bitPosition)
        {
            if (!TestOnly)
                _Value ^= 1 << bitPosition;
        }

        public void ResetAllBit()
        {
            if (!TestOnly)
            {
                _Value = 0b1111_1111_1111_1111;

                // Force Off Lamp
                ResetBit(7);
                ResetBit(8);
                ResetBit(9);
            }
        }

        public void Write(int val)
        {
            try
            {
                if(!TestOnly)
                _ModBusClient.WriteSingleRegister(SMART_ADDRESS, val);
            }
            catch { }
        }

        public void StartLogging()
        {
            try
            {
                if (!App.Default.IsDebugging)
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
                        if (IsFirstLogging)
                        {
                            IsFirstLogging = false;
                            _prevValue = _Value;

                            _ModBusClient.WriteSingleRegister(SMART_ADDRESS, _Value);           // write _Value to Smart Device
                            Debug.WriteLine(_IpAddress + ": Connected..");
                        }
                        else
                        {
                            /* FORCE DISABLE
                            if ((_prevValue != _Value) || (_prevValue == _Value)) 
                            {
                                _ModBusClient.WriteSingleRegister(SMART_ADDRESS, _Value);       // write _Value to Smart Device
                                _prevValue = _Value;
                                Debug.WriteLine(_Value);
                            }*/
                            _ModBusClient.WriteSingleRegister(SMART_ADDRESS, _Value);       // write _Value to Smart Device
                            _prevValue = _Value;
                            Debug.WriteLine(_Value);

                            Debug.WriteLine(_IpAddress + ": Logging..");
                        }
                    }
                    else
                    {
                        _ModBusClient.Connect();

                        IsFirstLogging = true;
                        _prevValue = 0;
                        _Connected = true;

                        Debug.WriteLine(_IpAddress + ": Connecting..");
                    }
                    Counter = 0;                            // Reset Counter Error
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
                    //Log.Error.Collect(e.StackTrace.ToString());
                }

                myStopWatch.Stop();

                if (myStopWatch.ElapsedMilliseconds < _LoggingInterval)
                {
                    Thread.Sleep((int)(_LoggingInterval - myStopWatch.ElapsedMilliseconds));
                }

                Debug.WriteLine(String.Format("Execution Time : {0}", myStopWatch.ElapsedMilliseconds));
            }
        }
    }
}
