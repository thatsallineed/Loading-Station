using System.Collections.Generic;
using loadingStation.Core.Modbus;

namespace loadingStation.Core.Function
{
    class PublicProperties
    {
        /// <summary>
        /// Modbus Devices
        /// </summary>
        public static List<ModbusInput> DevicesInput = new List<ModbusInput>();
        public static List<ModbusOutput> DevicesOutput = new List<ModbusOutput>();

        /// <summary>
        /// SET User ID
        /// </summary>
        public static string UserID { get; set; }

        /// <summary>
        /// Logging FLAG
        /// </summary>
        public static bool FLAG_LOGGING { get; set; }

        /// <summary>
        /// SET Coolant Type (From Config.ini)
        /// </summary>
        public static char CoolantType { get; set; }

        /// <summary>
        /// SET Modbus IP & Status.
        /// </summary>
        public static string ModbusInputIPaddress { get; set; }
        public static string ModbusOutputIPaddress { get; set; }
        public static bool ModbusInputStatus { get; set; }
        public static bool ModbusOutputStatus { get; set; }

        /// <summary>
        /// SET Database Status
        /// </summary>
        public static bool DatabaseStatus { get; set; }

        /// <summary>
        /// Value : Mixing[0], Measure[1], Drum[2] (Converted)
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
        /// Valve Indicator
        /// </summary>
        public enum Valve
        {
            Open,
            Close
        }
        public enum Type
        {
            ValveDrum,
            ValveDist,
            ValveCoolant,
            ValveWater,
            Propeler,
            FlowMeter,
            ERR
        }
        public static Valve ValveDrum = new Valve();
        public static Valve ValveDist = new Valve();
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
        /// SET Current Status : "Ready" "Filling" "Error"
        /// </summary>
        public enum Status
        {
            Ready,
            Filling,
            Error
        };
        public static Status CurrentStatus = new Status();
    }
}
