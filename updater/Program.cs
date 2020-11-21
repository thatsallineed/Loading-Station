using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace updater
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
                if(Args.Length != 0)
                {
                    foreach (string x in Args)
                    {
                        Arguments.Args.Add(x);
                    }
                    Arguments.Execute();
                    Launch();
                }
                else
                {
                    Launch();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown Arguments!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        static void Launch()
        {
            Actions.KillWhileRunning();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
