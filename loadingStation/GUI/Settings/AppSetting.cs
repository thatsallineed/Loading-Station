using Core;
using loadingStation.Base.Connection.Devices.Smartdevice;
using loadingStation.Base.Function;
using System;
using System.Windows.Forms;

namespace loadingStation.GUI.Settings
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

        private ModbusOutput DeviceOutput;
        private bool ModeChanged = false;

        // status true if is not filling & mixing
        private bool Status = !(GlobalProperties.CurrentStatus is GlobalProperties.Status.Filling) && !(GlobalProperties.CurrentStatus is GlobalProperties.Status.Mixing);

        public AppSetting()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);
            Helper.AnimateBounce(this, 550, Location.X, Location.Y + 15);
        }

        #region Event
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            ModeSaveSetting();

            lblDashboard.Text = "Restart Safely, Please Wait";

            Application.DoEvents();

            foreach (ModbusOutput sd in GlobalProperties.DevicesOutput.Values)
            {
                // Close All Valve
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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            ModeSaveSetting();

            // STOP LOGGING
            GlobalProperties.FLAG_LOGGING = false;

            lblDashboard.BackColor = System.Drawing.Color.FromArgb(235, 77, 75);
            lblDashboard.Text = "Exit Safely, Please Wait";

            Application.DoEvents();

            foreach (ModbusOutput sd in GlobalProperties.DevicesOutput.Values)
            {
                // Close All Valve
                sd.ResetAllBit();
            }

            System.Threading.Thread.Sleep(1100);

            foreach (ModbusInput sd in GlobalProperties.DevicesInput.Values)
            {
                sd.StopLogging();
            }

            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }
        private void ListProperties_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void AppSetting_Load(object sender, EventArgs e)
        {
            DeviceOutput = GlobalProperties.ModbusOutput != null ? GlobalProperties.ModbusOutput : null;

            bool ModeIndicator = GlobalProperties.Configuration.IndicatorOnly;
            bool ModeDebug = GlobalProperties.Configuration.IsDebugging;
            bool ManualState = GlobalProperties.ManualState;

            rbIndicator.Checked = ModeIndicator ? true : false;
            rbDebug.Checked = ModeDebug ? true : false;
            rbRelease.Checked = !ModeDebug && !ModeIndicator ? true : false;

            rbManualOn.Checked = ManualState;

            cbPropeler.Checked = GlobalProperties.AllowPropeler;
            cbCoolant.Checked = GlobalProperties.ManualCoolant;
            cbWater.Checked = GlobalProperties.ManualWater;
        }

        private void RbRelease_CheckedChanged(object sender, EventArgs e)
        {
            ModeChanged = true;
        }

        private void RbDebug_CheckedChanged(object sender, EventArgs e)
        {
            ModeChanged = true;
        }

        private void RbIndicator_CheckedChanged(object sender, EventArgs e)
        {
            ModeChanged = true;
        }

        private void ModeSaveSetting()
        {
            if (ModeChanged)
            {
                bool Release = rbRelease.Checked;
                bool Debug = rbDebug.Checked;
                bool Indicator = rbIndicator.Checked;

                GlobalProperties.Configuration.IsDebugging = Release ? false : true;
                GlobalProperties.Configuration.IsDebugging = Debug ? true : false;
                GlobalProperties.Configuration.IndicatorOnly = Indicator ? true : false;

                Base.Configuration.Jsonconfig.GenerateConfig();
            }
        }

        private void BtnSecurity_Click(object sender, EventArgs e)
        {
            using (SecuritySetting n = new SecuritySetting())
            {
                n.ShowDialog();
            }
        }

        private void btnConfigurations_Click(object sender, EventArgs e)
        {
            using (LSSetting ls = new LSSetting())
            {
                ls.ShowDialog();
            }
        }

        private void btnSmartdevice_Click(object sender, EventArgs e)
        {
            using (Smartdevices sd = new Smartdevices())
            {
                sd.ShowDialog();
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPropeler_CheckedChanged(object sender, EventArgs e)
        {
            GlobalProperties.AllowPropeler = cbPropeler.Checked ? true : false;
        }

        private void cbCoolant_CheckedChanged(object sender, EventArgs e)
        {
            GlobalProperties.ManualCoolant = cbCoolant.Checked ? true : false;

            if (DeviceOutput != null && GlobalProperties.ManualState)
            {
                if (GlobalProperties.ManualCoolant && GlobalProperties.ManualState)
                {
                    DeviceOutput.SetBit(11);
                    DeviceOutput.SetBit(14);
                    Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.ValveCoolant);
                }

                else if(!GlobalProperties.ManualCoolant && GlobalProperties.ManualState)
                {
                    DeviceOutput.ResetBit(11);
                    DeviceOutput.ResetBit(14);
                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveCoolant);
                }
            }
        }

        private void cbWater_CheckedChanged(object sender, EventArgs e)
        {
            GlobalProperties.ManualWater = cbWater.Checked ? true : false;

            if (DeviceOutput != null && GlobalProperties.ManualState)
            {
                if (GlobalProperties.ManualWater && GlobalProperties.ManualState)
                {
                    DeviceOutput.SetBit(13);
                    Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.ValveWater);
                }

                else if (!GlobalProperties.ManualWater && GlobalProperties.ManualState)
                {
                    DeviceOutput.ResetBit(13);
                    Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveWater);
                }
            }
        }

        private void rbManualOn_CheckedChanged(object sender, EventArgs e)
        {
            GlobalProperties.ManualState = true;
        }

        private void rbManualOff_CheckedChanged(object sender, EventArgs e)
        {
            GlobalProperties.ManualState = false;

            // Uncheck
            cbCoolant.Checked = false;
            cbWater.Checked = false;

            // Close Coolant
            DeviceOutput.ResetBit(11);
            DeviceOutput.ResetBit(14);
            Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveCoolant);

            // Close Water
            DeviceOutput.ResetBit(13);
            Actions.SetIndicator(GlobalProperties.Valve.Close, GlobalProperties.Type.ValveWater);
        }
    }
}
