using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;
using loadingStation.Base.Connection.Devices.Smartdevice;
using loadingStation.Base.Connection.Database;

namespace loadingStation.Base.Function
{
    class Actions
    {
        static BackgroundWorker DBServiceWorker = new BackgroundWorker();
        static BackgroundWorker StatusServiceWorker = new BackgroundWorker();
        static BackgroundWorker ScreenPrevent = new BackgroundWorker();
        public static ModbusOutput DeviceOutput;

        #region Indicator : <SetIndicator>

        /// <summary>
        /// Function For Change System Indicator
        /// </summary>
        /// <param name="Value">1: Ready, 2: Filling, 3: Mixing, 4: Emergency, 5: Error, 6: Manual </param>
        public static void SetIndicator(byte Value)
        {
            switch (Value)
            {
                case 1:
                    GlobalProperties.CurrentStatus = GlobalProperties.Status.Ready;
                    break;
                case 2:
                    GlobalProperties.CurrentStatus = GlobalProperties.Status.Filling;
                    break;
                case 3:
                    GlobalProperties.CurrentStatus = GlobalProperties.Status.Mixing;
                    break;
                case 4:
                    GlobalProperties.CurrentStatus = GlobalProperties.Status.Emergency;
                    break;
                case 5:
                    GlobalProperties.CurrentStatus = GlobalProperties.Status.Error;
                    break;
                case 6:
                    GlobalProperties.CurrentStatus = GlobalProperties.Status.Manual;
                    break;
                case 7:
                    GlobalProperties.CurrentStatus = GlobalProperties.Status.Changedrum;
                    break;
            }
        }
        public static void SetIndicator(GlobalProperties.Valve valve, GlobalProperties.Type type)
        {
            switch (type)
            {
                case GlobalProperties.Type.PumpDrum:
                    if (valve == GlobalProperties.Valve.Open)
                    {
                        GlobalProperties.PumpDrum = GlobalProperties.Valve.Open;
                        SetIndicator(3); // Mixing
                    }
                    else
                    {
                        GlobalProperties.PumpDrum = GlobalProperties.Valve.Close;
                        //SetIndicator(1); // Ready
                    }
                    break;

                case GlobalProperties.Type.PumpDist:
                    if (valve == GlobalProperties.Valve.Open)
                    {
                        GlobalProperties.PumpDist = GlobalProperties.Valve.Open;
                        SetIndicator(2); // Filling
                    }
                    else
                    {
                        GlobalProperties.PumpDist = GlobalProperties.Valve.Close;
                        //SetIndicator(1); // Ready
                    }
                    break;

                case GlobalProperties.Type.ValveCoolant:
                    GlobalProperties.ValveCoolant = (valve == GlobalProperties.Valve.Open) ? GlobalProperties.Valve.Open : GlobalProperties.Valve.Close;
                    break;

                case GlobalProperties.Type.ValveWater:
                    GlobalProperties.ValveWater = (valve == GlobalProperties.Valve.Open) ? GlobalProperties.Valve.Open : GlobalProperties.Valve.Close;
                    break;

                case GlobalProperties.Type.Propeler:
                    GlobalProperties.Propeler = (valve == GlobalProperties.Valve.Open) ? GlobalProperties.Valve.Open : GlobalProperties.Valve.Close;
                    break;

                case GlobalProperties.Type.FlowMeter:
                    GlobalProperties.FlowMeter = (valve == GlobalProperties.Valve.Open) ? GlobalProperties.Valve.Open : GlobalProperties.Valve.Close;
                    break;

                case GlobalProperties.Type.ERR:
                    SetIndicator(5); // Error
                    break;

                case GlobalProperties.Type.Emergency:
                    SetIndicator(4); // Emergency
                    break;
            }
        }
        #endregion

        #region Service : <DBCheckService/StatusService/ScreenPreventSleep>
        /// <summary>
        /// Realtime DB Connection Watcher
        /// </summary>
        [HandleProcessCorruptedStateExceptions]

        private static void DBServiceWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    GlobalProperties.DatabaseStatus = (Database.IsConnected()) ? true : false;
                }
                catch (Exception x)
                {
                    Log.Error.Collect(x.StackTrace.ToString());
                    GlobalProperties.DatabaseStatus = false;
                }
                Thread.Sleep(500);
            }
        }

        public static void DBCheckService()
        {
            DBServiceWorker.DoWork += DBServiceWorker_DoWork;
            Application.DoEvents();

            DBServiceWorker.WorkerReportsProgress = false;
            DBServiceWorker.RunWorkerAsync();
        }

        private static void StatusServiceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (GlobalProperties.DatabaseStatus)
                    {
                        DB_SFDB.CurrentStatusState();
                    }
                }
                catch (Exception x)
                {
                    Log.Error.Collect(x.StackTrace.ToString());
                    Debug.WriteLine(x);
                }
                Thread.Sleep(1000);
            }
        }

        public static void StatusService()
        {
            StatusServiceWorker.DoWork += StatusServiceWorker_DoWork;
            Application.DoEvents();

            StatusServiceWorker.WorkerReportsProgress = false;
            StatusServiceWorker.RunWorkerAsync();
        }

        private static void ScreenPrevent_DoWork(object sender, DoWorkEventArgs e)
        {
            while (GlobalProperties.FLAG_LOGGING)
            {
                PreventSleep();
                Thread.Sleep(20000);
            }
        }

        public static void ScreenPreventSleep()
        {
            ScreenPrevent.DoWork += ScreenPrevent_DoWork;
            Application.DoEvents();

            ScreenPrevent.WorkerReportsProgress = false;
            ScreenPrevent.RunWorkerAsync();
        }
        #endregion

        /// <summary>
        /// Function For Relaunch Application
        /// </summary>
        public static void RelaunchApplication()
        {
            Base.Log.Error.SaveLog();
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
        /// Function For Take Screenshot & Return As Image
        /// </summary>
        public static Image TakeScreenshot()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                using (var stream = new MemoryStream())
                {
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    return Image.FromStream(stream);
                }
            }
        }


        /// <summary>
        /// Prevent Idle Screen to Sleep (Must Call Periodically!)
        /// </summary>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        [FlagsAttribute]
        private enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
        public static void PreventSleep()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
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
        /// Function For Check Directory if Exist
        /// </summary>
        public static bool CheckDirectory(string path)
        {
            bool result = false;
            if (Directory.Exists(path))
            {
                result = true;
            }
            else
            {
                Directory.CreateDirectory(path);
            }

            return result;
        }


        /// <summary>
        /// Function For Remove File Older Than //Date
        /// </summary>
        public static void RemoveOlderFile(string path, int days = -7)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(days))
                    fi.Delete();
            }
        }


        /// <summary>
        /// Function For Kill While Already Running
        /// </summary>
        public static void KillWhileRunning()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();
        }


        /// <summary>
        /// Function For AlwaysOnTop Form
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X = 0, int Y = 0, int cx = 0, int cy = 0, uint uFlags = 0x0001 | 0x0002);


        /// <summary>
        /// Function For Check Database Before Application Running
        /// </summary>
        public static void CheckDBisAlive()
        {
            var check = Database.IsConnected();
            if (!check)
            {
                MessageBox.Show("Can't Connect to Database!, Is Server Running?", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RelaunchApplication();
            }
        }

        /// <summary>
        /// Function For Ping Request Alive OR Not
        /// </summary>
        public static bool PingRequest(string IP)
        {
            bool result = false;

            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply reply = ping.Send(IP);
                result = reply.Status == System.Net.NetworkInformation.IPStatus.Success;
            }

            catch
            {
                result = false;
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
        /// Enable DoubleBuffering
        /// </summary>
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        /// <summary>
        /// Re-Center Form Manually (X-Y)
        /// </summary>
        public static Form RecenterLocation(Form form)
        {
            Screen screen = Screen.FromControl(form);

            Rectangle workingArea = screen.WorkingArea;
            form.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - form.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - form.Height) / 2)
            };

            return form;
        }
    }

}
