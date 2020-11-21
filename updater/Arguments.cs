using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace updater
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
                    case "-conf":
                        PublicProperties.UpdateConfigLocation = data;
                        Console.WriteLine("\nConfigLocation: " + data);
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
