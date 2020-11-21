using Core;
using loadingStation.Base.Connection.Devices.Smartdevice;
using loadingStation.Base.Function;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace loadingStation.Base.Connection.Socket
{
    public static class Server
    {
        public static void StartServer()
        {
            if (GlobalProperties.CoolantType is 'A')
            {
                AddCommand();

                Core.Connection.SocketServerSingle.Hostname = Helper.NetGetLocalIPAddress();
                Core.Connection.SocketServerSingle.Port = 9090;
                Core.Connection.SocketServerSingle.StartServer();
                Debug.WriteLine("Server Started");
            }
        }

        private static void AddCommand()
        {
            var Dict = Core.Connection.SocketServerSingle.DictCommandList;

            Dict.Add("AICHI_RESET_A", new AichiResetA());
            Dict.Add("AICHI_RESET_B", new AichiResetB());
            Dict.Add("AICHI_RESET_C", new AichiResetC());

            Dict.Add("AICHI_VALUE_A", new AichiValueA());
            Dict.Add("AICHI_VALUE_B", new AichiValueB());
            Dict.Add("AICHI_VALUE_C", new AichiValueC());

            Dict.Add("SYSTEM_EXIT", new SystemActioneExit());
            Dict.Add("SYSTEM_RESTART", new SystemActionRestart());
            Dict.Add("SYSTEM_EMERGENCY", new SystemActionEmergency());
        }

        #region RESET
        private class AichiResetA : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                if (GlobalProperties.ModbusPulse != null)
                    GlobalProperties.ModbusPulse.SetReset('A');
                return "RESET";
            }
        }

        private class AichiResetB : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                if (GlobalProperties.ModbusPulse != null)
                    GlobalProperties.ModbusPulse.SetReset('B');
                return "RESET";
            }
        }

        private class AichiResetC : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                if (GlobalProperties.ModbusPulse != null)
                    GlobalProperties.ModbusPulse.SetReset('C');
                return "RESET";
            }
        }
        #endregion

        #region VALUES

        private class AichiValueA : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                var Device = GlobalProperties.ModbusPulse;

                if (Device != null)
                {
                    int CoolantHI, CoolantLO;
                    int WaterHI, WaterLO;
                    string result;

                    Device.GetData("CHA3", out CoolantHI);
                    Device.GetData("CHA4", out CoolantLO);

                    Device.GetData("CHA5", out WaterHI);
                    Device.GetData("CHA6", out WaterLO);

                    result = $"{CoolantHI},{CoolantLO},{WaterHI},{WaterLO}";
                    return result;
                }
                else
                {
                    return "NULL";
                }
            }
        }

        private class AichiValueB : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                var Device = GlobalProperties.ModbusPulse;

                if (Device != null)
                {
                    int CoolantHI, CoolantLO;
                    int WaterHI, WaterLO;
                    string result;

                    Device.GetData("CHA7", out CoolantHI);
                    Device.GetData("CHA8", out CoolantLO);

                    Device.GetData("CHA9", out WaterHI);
                    Device.GetData("CHA10", out WaterLO);

                    result = $"{CoolantHI},{CoolantLO},{WaterHI},{WaterLO}";
                    return result;
                }
                else
                {
                    return "NULL";
                }

            }
        }

        private class AichiValueC : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                var Device = GlobalProperties.ModbusPulse;

                if (Device != null)
                {
                    int CoolantHI, CoolantLO;
                    int WaterHI, WaterLO;
                    string result;

                    Device.GetData("CHA11", out CoolantHI);
                    Device.GetData("CHA12", out CoolantLO);

                    Device.GetData("CHA13", out WaterHI);
                    Device.GetData("CHA14", out WaterLO);

                    result = $"{CoolantHI},{CoolantLO},{WaterHI},{WaterLO}";
                    return result;
                }
                else
                {
                    return "NULL";
                }
            }
        }
        #endregion

        #region System
        private class SystemActioneExit : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                Application.DoEvents();

                foreach (ModbusOutput sd in GlobalProperties.DevicesOutput.Values)
                {
                    // Close All Valve
                    sd.ResetAllBit();
                }

                System.Threading.Thread.Sleep(1000);

                foreach (ModbusInput sd in GlobalProperties.DevicesInput.Values)
                {
                    sd.StopLogging();
                }

                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
                return "OK";
            }
        }

        private class SystemActionRestart : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                Application.DoEvents();

                foreach (ModbusOutput sd in GlobalProperties.DevicesOutput.Values)
                {
                    // Close All Valve
                    sd.ResetAllBit();
                }

                System.Threading.Thread.Sleep(1000);

                foreach (ModbusInput sd in GlobalProperties.DevicesInput.Values)
                {
                    sd.StopLogging();
                }

                System.Threading.Thread.Sleep(1000);
                Actions.RelaunchApplication();
                return "OK";
            }
        }

        private class SystemActionEmergency : Core.Connection.SocketServerCommand
        {
            public override object Value()
            {
                using (GUI.Act.Emergency action = new GUI.Act.Emergency())
                {
                    action.Details = "Force Stopped";
                    action.Reason = "Requested Stop by Network";
                    action.ForceStopAll = true;
                    action.ShowDialog();
                    return "OK";
                }
            }
        }
        #endregion
    }
}
