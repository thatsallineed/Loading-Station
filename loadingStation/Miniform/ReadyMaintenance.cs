using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

using loadingStation.Core.Database;
using loadingStation.Core.Function;

namespace loadingStation.Miniform
{
    public partial class ReadyMaintenance : Form
    {
        bool retry = true;
        public ReadyMaintenance()
        {
            InitializeComponent();
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
                    if (PublicProperties.DatabaseStatus)
                    {
                        DB_SFDB.DailyLoadingStationReady();
                        retry = false;
                        panelNotification.Visible = false;
                    }
                }
                catch { }
                Thread.Sleep(100);
            }
        }

        private void BgwSubmit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
