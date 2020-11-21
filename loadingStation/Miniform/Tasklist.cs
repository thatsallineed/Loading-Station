using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

using loadingStation.Core.Log;
using loadingStation.Core.Function;
using loadingStation.Core.Database;

namespace loadingStation.Miniform
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

            bgwTasklist.RunWorkerAsync();
        }

        private void BgwTasklist_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (PublicProperties.DatabaseStatus)
                    {
                        dtTasklist = DB_SFDB.PopulateTasklist();

                        BeginInvoke((MethodInvoker)delegate
                        {
                            try
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
                            catch { }
                        });
                    }
                }
                catch (Exception m)
                {
                    Error.Collect(m.StackTrace.ToString());
                    Debug.WriteLine(m);
                }
                Thread.Sleep(2000);
            }
        }
    }
}
