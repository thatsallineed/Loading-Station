using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using Transitions;

using loadingStation.Base.Configuration.Config;
using loadingStation.Base.Function;
using loadingStation.Base.Connection.Devices.Smartdevice;
using Core;
using System.Diagnostics;

namespace loadingStation.GUI.Settings
{
    public partial class LSSetting : Form
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
        List<int> ListValue = new List<int>();
        System.Collections.IEnumerator enumerator = CoreLS.Default.Properties.GetEnumerator();

        public LSSetting()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(550));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);

            while (enumerator.MoveNext())
            {
                listProperties.Items.Add((((System.Configuration.SettingsProperty)enumerator.Current).Name));
            }

            foreach (SettingsProperty settings in CoreLS.Default.Properties)
            {
                try
                {
                    ListValue.Add(int.Parse(CoreLS.Default[settings.Name].ToString()));
                }
                catch
                {
                    ListValue.Add(999);
                }
            }

            if((listProperties.Items.Count >= 0) && (ListValue.Count >= 0))
            {
                lblSelected.Text = listProperties.Items[index].ToString();
                txtLastValue.Text = ListValue[index].ToString();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtNewValue.Text != string.Empty)
            {
                CoreLS.Default[listProperties.Items[index].ToString()] = int.Parse(txtNewValue.Text);
                CoreLS.Default.Save();

                ListValue[index] = int.Parse(txtNewValue.Text);

                lblLastChanged.Visible = true;

                lblRestart.Visible = true;
                btnRestart.Visible = true;
            }
        }

        private void ListProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewValue.Text = "";

            index = listProperties.SelectedIndex;
            lblSelected.Text = listProperties.Items[index].ToString();
            txtLastValue.Text = ListValue[index].ToString();
        }

        private void TxtNewValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            // STOP LOGGING
            GlobalProperties.FLAG_LOGGING = false;

            lblLastChanged.BackColor = System.Drawing.Color.FromArgb(235, 77, 75);
            lblLastChanged.Text = "Restart Safely, Please Wait";
            lblLastChanged.Visible = true;

            Application.DoEvents();

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
            Actions.RelaunchApplication();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            //Helper.ExecuteCommandline("start osk.exe",false);
            Debug.WriteLine(Environment.SystemDirectory + "\\osk.exe");
            Process.Start($"{Environment.SystemDirectory}\\osk");
        }
    }
}
