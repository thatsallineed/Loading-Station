using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using Transitions;

using loadingStation.Core.Modbus;
using loadingStation.Core.Configuration.Config;
using loadingStation.Core.Function;

namespace loadingStation.Miniform
{
    public partial class AppSetting : Form
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
        List<string> ListValue = new List<string>();
        System.Collections.IEnumerator enumerator = App.Default.Properties.GetEnumerator();

        public AppSetting()
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

            foreach (SettingsProperty settings in App.Default.Properties)
            {
                ListValue.Add(App.Default[settings.Name].ToString());
            }

            txtValue.Text = ListValue[index].ToString();
        }

        #region Event
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            lblDashboard.Text = "Restart Safely, Please Wait";

            Application.DoEvents();

            foreach (ModbusOutput sd in PublicProperties.DevicesOutput)
            {
                // Close All Valve
                sd.ResetAllBit();
            }

            System.Threading.Thread.Sleep(1000);

            foreach (ModbusInput sd in PublicProperties.DevicesInput)
            {
                sd.StopLogging();
            }

            System.Threading.Thread.Sleep(1000);
            Actions.RelaunchApplication();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            // STOP LOGGING
            PublicProperties.FLAG_LOGGING = false;

            lblDashboard.BackColor = System.Drawing.Color.FromArgb(235, 77, 75);
            lblDashboard.Text = "Exit Safely, Please Wait";

            Application.DoEvents();

            foreach (ModbusOutput sd in PublicProperties.DevicesOutput)
            {
                // Close All Valve
                sd.ResetAllBit();
            }

            System.Threading.Thread.Sleep(1100);

            foreach (ModbusInput sd in PublicProperties.DevicesInput)
            {
                sd.StopLogging();
            }
            
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }
        private void ListProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listProperties.SelectedIndex;
            txtValue.Text = ListValue[index].ToString();
        }
        #endregion

        private void AppSetting_Load(object sender, EventArgs e)
        {

        }
    }
}
