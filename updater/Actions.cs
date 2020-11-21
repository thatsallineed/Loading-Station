using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace updater
{
    class Actions
    {
        /// <summary>
        /// Function For Relaunch Application
        /// </summary>
        public static void RelaunchApplication()
        {
            string Location = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            Process.Start(Location);
            Environment.Exit(0);
        }


        /// <summary>
        /// Function For Ask & Relaunch Application
        /// </summary>
        public static void AskRelaunchApplication(string messageStackTrace)
        {
            MessageBox.Show("ERROR : " + messageStackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            RelaunchApplication();
        }


        /// <summary>
        /// Function For Save String data to File
        /// </summary>
        public static void StringToFile(string filepath, string text)
        {
            File.WriteAllText(filepath, text);
        }


        /// <summary>
        /// Function For Load File to String
        /// </summary>
        public static string FileToString(string filepath)
        {
            string result = "";
            if (File.Exists(filepath))
            {
                result = File.ReadAllText(filepath);
            }
            return result;
        }


        /// <summary>
        /// Function For Rounded Corner Form
        /// INPUT THIS CODE TO FORM : 
        ///  Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        /// </summary>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );


        /// <summary>
        /// Re-Center Form Manually (X-Y)
        /// </summary>
        public static Form RecenterLocation(Form form)
        {
            Screen screen = Screen.FromControl(form);

            System.Drawing.Rectangle workingArea = screen.WorkingArea;
            form.Location = new System.Drawing.Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - form.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - form.Height) / 2)
            };

            return form;
        }


        /// <summary>
        /// Function For Kill While Already Running
        /// </summary>
        public static void KillWhileRunning()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
