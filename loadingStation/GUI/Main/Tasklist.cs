using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

using loadingStation.Base.Log;
using loadingStation.Base.Function;
using loadingStation.Base.Connection.Database;

namespace loadingStation.GUI.Main
{
    public partial class Tasklist : Form
    {
        #region Properties
        private static DataTable dtTasklist;

        public static DataTable TableTasklist
        {
            get { return dtTasklist; }
        }
        #endregion

        public Tasklist()
        {
            InitializeComponent();
        }

        private void Tasklist_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvTasklist, new object[] { true });

            timerTasklist.Start();
        }

        private void BgwTasklist_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (GlobalProperties.DatabaseStatus)
                {
                    dtTasklist = DB_SFDB.PopulateTasklist();
                }
            }
            catch (Exception m)
            {
                Error.Collect(m.StackTrace.ToString());
                Debug.WriteLine(m);
            }
        }

        private void BgwTasklist_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if(dtTasklist != null)
                {
                    dgvTasklist.Rows.Clear();

                    int row = 0;
                    foreach (DataRow dr in dtTasklist.Rows)
                    {
                        dgvTasklist.Rows.Add(dr.ItemArray);
                        dgvTasklist.Rows[row].Cells[0].Value = row + 1;
                        row += 1;
                    }
                }
            }
            catch (Exception x)
            {
                Error.Collect(x.StackTrace.ToString());
            }
        }

        private void TimerTasklist_Tick(object sender, EventArgs e)
        {
            if (!bgwTasklist.IsBusy)
            {
                bgwTasklist.RunWorkerAsync();
            }
        }
    }
}
