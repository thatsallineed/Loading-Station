using System.Collections.Generic;
using loadingStation.Base.Connection.Devices.Smartdevice;

namespace loadingStation.Base.Function
{
    class GlobalProperties
    {
        /// <summary>
        /// Modbus Devices
        /// </summary>
        public static Dictionary<string, ModbusInput> DevicesInput = new Dictionary<string, ModbusInput>();
        public static Dictionary<string, ModbusOutput> DevicesOutput = new Dictionary<string, ModbusOutput>();
        public static Dictionary<string, ModbusAichi> DevicesAichi = new Dictionary<string, ModbusAichi>();

        /// <summary>
        /// SET User ID
        /// </summary>
        public static string UserID { get; set; }

        /// <summary>
        /// Logging FLAG
        /// </summary>
        public static bool FLAG_LOGGING = false;
        public static bool FLAG_DEVICELOADED = false;
        public static bool FLAG_CHANGEDRUM = false;
        public static bool FLAG_EMERGENCY = false;
        public static bool FLAG_MAINTENANCE = false;
        public static bool FLAG_ATSTART = false;
        

        /// <summary>
        /// SET Coolant Type (From Config.ini)
        /// </summary>
        public static char CoolantType { get; set; }

        /// <summary>
        /// SET Modbus IP & Status.
        /// </summary>
        public static ModbusOutput ModbusOutput { get; set; }
        public static ModbusInput ModbusInput { get; set; }
        public static ModbusAichi ModbusPulse { get; set; }

        /// <summary>
        /// SET Database Status
        /// </summary>
        public static bool DatabaseStatus { get; set; } = false;

        /// <summary>
        /// Value : Mixing[0], Meassure[1], Drum[2] (Converted)
        /// </summary>
        public static int[] Value = new int[3];

        /// <summary>
        /// Value : Mixing[0], Measure[1], Drum[2] (Real Value)
        /// </summary>
        public static int[] RealData = new int[3];

        /// <summary>
        /// Value : Feedback Valve1[0], Valve2[1]
        /// </summary>
        public static int[] FeedbackValve = new int[2];

        /// <summary>
        /// Load From Configuration Json (config.json)
        /// </summary>
        public static class Configuration
        {
            // Database
            public static string DatabaseHost { get; set; } = "127.0.0.1";
            public static string DatabaseDB { get; set; } = "SmartFactory";
            public static string DatabaseUsername { get; set; } = "root";
            public static string DatabasePassword { get; set; } = "root";

            // Application
            public static bool IsDebugging { get; set; } = true;
            public static bool IndicatorOnly { get; set; } = true;
            public static bool LoginUseAuthentication { get; set; } = true;

            // Modbus
            public static string ModbusDebugInput { get; set; } = "127.0.0.1";
            public static string ModbusDebugOutput { get; set; } = "127.0.0.1";
            public static int ModbusDebugInputPort { get; set; } = 502;
            public static int ModbusDebugOutputPort { get; set; } = 502;

            // Socket
            public static string SocketClientHost { get; set; } = "127.0.0.1";
        }
        

        /// <summary>
        /// Valve Indicator
        /// </summary>
        public enum Valve
        {
            Open,
            Close
        }
        public enum Type
        {
            PumpDrum,
            PumpDist,
            ValveCoolant,
            ValveWater,
            Propeler,
            FlowMeter,
            ERR,
            Emergency
        }
        public static Valve PumpDrum = new Valve();
        public static Valve PumpDist = new Valve();
        public static Valve ValveCoolant = new Valve();
        public static Valve ValveWater = new Valve();
        public static Valve Propeler = new Valve();
        public static Valve FlowMeter = new Valve();

        /// <summary>
        /// Change Drum Notification
        /// </summary>
        public enum Drum
        {
            Alert,
            None
        }
        public static Drum ChangeDrumNotify = new Drum();

        /// <summary>
        /// SET Current Status : -2,-1,0,1,2
        /// </summary>
        public enum Status
        {
            Emergency = -2,             // Emergency
            Error = -1,                 // Error
            Ready = 0,                  // Ready
            Filling = 1,                // Filling to Distribution
            Mixing = 2,                 // Mixing Progress
            Manual = 3,                 // Manual Mode
            Changedrum = 4              // Change Drum
        };
        public static Status CurrentStatus = new Status();

        /// <summary>
        /// Timelapse Count Filling Duration
        /// </summary>
        public static string TimelapseValveWater;
        public static string TimelapseValveCoolant;

        /// <summary>
        /// Manual Action
        /// </summary>
        public static bool ManualState = false;
        public static bool AllowPropeler = true;
        public static bool ManualCoolant = false;
        public static bool ManualWater = false;
    }
}
