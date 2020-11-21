using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

using loadingStation.Base.Configuration.Config;

namespace loadingStation.Base.Function
{
    class Arguments
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        public static List<string> Args = new List<string>();
        static int map = 0;
        public static void Execute()
        {
            foreach (string commandArgs in Args)
            {
                ExecuteCommand(commandArgs, map);
                map += 1;
            }
        }


        public static void ExecuteCommand(string commandArgs, int locateArgs)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            string data = "";

            try
            {
                data = Args[locateArgs + 1].ToString();
            }
            catch
            {
                data = "";
            }

            try
            {
                switch (commandArgs)
                {
                    case "-host":
                        GlobalProperties.Configuration.DatabaseHost = data;
                        Console.WriteLine("\nHost Applied " + data);
                        break;

                    case "-db":
                        GlobalProperties.Configuration.DatabaseDB = data;
                        Console.WriteLine("\nDB Applied " + data);
                        break;

                    case "-username":
                        GlobalProperties.Configuration.DatabaseUsername = data;
                        Console.WriteLine("\nUsername Applied " + data);
                        break;

                    case "-password":
                        GlobalProperties.Configuration.DatabasePassword = data;
                        Console.WriteLine("\nPassword Applied " + data);
                        break;

                    case "$PWDNULL":
                        GlobalProperties.Configuration.DatabasePassword = string.Empty;
                        Console.WriteLine("\nPassword NULLED");
                        break;

                    case "-modbusinputip":
                        GlobalProperties.Configuration.ModbusDebugInput = data;
                        Console.WriteLine("\nModbus Input Applied " + data);
                        break;

                    case "-modbusoutputip":
                        GlobalProperties.Configuration.ModbusDebugOutput = data;
                        Console.WriteLine("\nModbus Output Applied " + data);
                        break;
                        
                    case "-errorlog":
                        Logs.Default.IsLogEnabled = (data == "true") ? true : false;
                        Console.WriteLine("\nLog Applied " + data);
                        break;

                }
            }
            catch (Exception x)
            {
                Debug.WriteLine(x);
            }
        }

    }
}
