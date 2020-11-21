using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

using loadingStation.Core.Database;
using loadingStation.Core.Function;

namespace loadingStation.GUI
{
    public partial class ReadyMaintenance : Form
    {
        bool retry;
        public ReadyMaintenance()
        {
            InitializeComponent();

            Actions.SetDoubleBuffered(this);
            Actions.RecenterLocation(this);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!bgwSubmit.IsBusy)
            {
                panelNotification.Visible = true;
                btnSubmit.Visible = false;
                bgwSubmit.RunWorkerAsync();
            }
        }

        private void BgwSubmit_DoWork(object sender, DoWorkEventArgs e)
        {
            while (retry)
            {
                try
                {
                    if (GlobalProperties.DatabaseStatus)
                    {
                        DB_SFDB.DailyLoadingStationReady();
                        retry = false;
                    }
                }
                catch (Exception x)
                {
                    Core.Log.Error.Collect(x.StackTrace.ToString());
                }
                Thread.Sleep(100);
            }
        }

        private void BgwSubmit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSubmit.Visible = true;
            panelNotification.Visible = false;
            this.Close();
        }

        private void ReadyMaintenance_Load(object sender, EventArgs e)
        {
            retry = true;
            btnSubmit.Visible = true;
            panelNotification.Visible = false;
        }
    }
}
