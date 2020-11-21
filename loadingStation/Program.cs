using loadingStation.Base.Configuration;
using loadingStation.Base.Function;
using loadingStation.GUI.Main;
using System;
using System.Windows.Forms;

namespace loadingStation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            try
            {
                if (Args.Length != 0)
                {
                    foreach (string x in Args)
                    {
                        Arguments.Args.Add(x);
                    }
                    Arguments.Execute();
                }
                else
                {
                    Launch();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Unknown Argument! " + e.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        static void Launch()
        {
            //Actions.KillWhileRunning();
            Jsonconfig.Loadconfig();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}
