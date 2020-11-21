using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace updater
{
    public partial class Form1 : Form
    {
        int IndexOf;

        string TargetVersion;
        string UpdateConfigLocation;
        string UpdateComments;
        string UpdateInstallationPath;

        List<string> UriList = new List<string>();
        List<string> TempFile = new List<string>();
        List<string> RealFile = new List<string>();

        /// <summary>
        /// 
        /// NOTE:
        /// ApplicationCategories Index
        /// [0] = LOADING STATION
        /// [1] = EQC
        /// 
        /// </summary>

        public Form1()
        {
            InitializeComponent();
            System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            RecenterLocation(this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Jsonconfig.Serialize();
            Environment.Exit(0);

            UpdateConfigLocation = PublicProperties.UpdateConfigLocation;

            lbList.Items.Clear();
            lblFilename.Text = "Starting";
            Box("Prepare to Install " + TargetVersion);

            Jsonconfig.Deserial(UpdateConfigLocation, out TargetVersion, out UpdateInstallationPath, out UpdateComments, out RealFile, out UriList);
            if(!File.Exists(UpdateInstallationPath))
            {
                MessageBox.Show("Invalid Update Configuration","Cancelled",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }

            Box("VERSION: " + TargetVersion);
            Box("DETAILS: " + UpdateComments);

            IndexOf = 0;
            foreach (string url in UriList)
            {
                IndexOf++;
                Add(url, RealFile[IndexOf]);
            }

            Download();
        }

        #region Function Update
        private void Add(string Uri, string Filename)
        {
            Random rd = new Random();

            UriList.Add(Uri);
            TempFile.Add(string.Format("Temp{0}{1}",Filename,rd.Next(1,20)));
            RealFile.Add(Filename);
        }

        private void Download()
        {
            try
            {
                // DOWNLOAD
                IndexOf = 0;
                foreach(string uri in UriList)
                {
                    IndexOf++; // First Execute Cause (list)
                    using (WebClient webCl = new WebClient())
                    {
                        lbList.Items.Add("Downloading " + RealFile[IndexOf]);
                        lblFilename.Text = RealFile[IndexOf];
                        webCl.DownloadProgressChanged += WebCl_DownloadProgressChanged;
                        webCl.DownloadFileCompleted += WebCl_DownloadFileCompleted;
                        webCl.DownloadFileAsync(new Uri(uri), TempFile[IndexOf]);
                    }
                }

                // INSTALL
                IndexOf = 0;
                foreach(string Filename in RealFile)
                {
                    IndexOf++; // First Execute Cause (list)
                    Install(Filename, TempFile[IndexOf]);
                }

                Finish();
            }
            catch(Exception)
            {
                MessageBox.Show("Installation Failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WebCl_DownloadFileCompleted(object sender,AsyncCompletedEventArgs e)
        {
            lbList.Items.Add("Downloaded "+RealFile[IndexOf]);
        }

        private void WebCl_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lblPercentage.Text = e.ProgressPercentage + "%";
            pbDownload.Value = e.ProgressPercentage;
        }

        private void Install(string RealName, string TempName)
        {
            lbList.Items.Add("Installing " + RealName);
            File.Replace
                (
                UpdateInstallationPath + TempName,
                UpdateInstallationPath + RealName,
                "_"+TempName
                );
        }
        private void Finish()
        {
            foreach(string file in RealFile)
            {
                lbList.Items.Add("Checking..");
                if (File.Exists(file))
                { lbList.Items.Add(string.Format("{0} Installed",file)); }
                else
                { lbList.Items.Add(string.Format("{0} Not Installed", file)); }
            }

            System.Threading.Thread.Sleep(2000);
            this.Close();
        }
        #endregion

        #region Others Function

        private void Box(string details)
        {
            lbList.Items.Add(details);
        }
        public static void KillWhileRunning()
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
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
        #endregion

    }
}
