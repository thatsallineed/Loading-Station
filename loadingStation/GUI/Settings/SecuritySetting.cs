using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

using loadingStation.Base.Configuration.Config;
using loadingStation.Base.Function;
using loadingStation.Base.Connection.Devices.Smartdevice;

namespace loadingStation.GUI.Settings
{
    public partial class SecuritySetting : Form
    {
        #region DropShadow Properties
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        int index = 0;
        List<string> ListName = new List<string>();
        List<bool> ListValue = new List<bool>();
        System.Collections.IEnumerator enumerator = Security.Default.Properties.GetEnumerator();

        public SecuritySetting()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(550));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);

            while (enumerator.MoveNext())
            {
                ListName.Add((((System.Configuration.SettingsProperty)enumerator.Current).Name));
            }

            foreach(System.Configuration.SettingsProperty settings in Security.Default.Properties)
            {
                ListValue.Add(bool.Parse(Security.Default[settings.Name].ToString()));
            }

            LoadDgv();
        }

        private void LoadDgv()
        {
            try
            {
                index = 0;
                foreach(string n in ListName)
                {
                    dgvValue.Rows.Add(new string[] { n, ListValue[index].ToString() });
                    index++;
                }
            }
            catch (Exception x)
            {
                Base.Log.Error.Collect(x.ToString());
            }
        }

        private void DgvValue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                try
                {
                    ListValue[e.RowIndex] = bool.Parse(dgvValue.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                catch (FormatException)
                {
                    MessageBox.Show("UNKNOWN VALUE!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            index = 0;
            foreach(string x in ListName)
            {
                Security.Default[x] = ListValue[index];
                index++;
            }

            Security.Default.Save();
            Security.Default.Upgrade();

            string result = string.Format("Saved At: {0}\nRestart to take effect",DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            labelSave.Visible = true;
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Restart may terminate all proccess. Are you sure ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("shutdown /r /t 010");
                Base.Function.GlobalProperties.FLAG_LOGGING = false;

                foreach (ModbusOutput sd in GlobalProperties.DevicesOutput.Values)
                {
                    sd.ResetAllBit();
                }

                System.Threading.Thread.Sleep(1000);

                foreach (ModbusInput sd in GlobalProperties.DevicesInput.Values)
                {
                    sd.StopLogging();
                }

                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}
