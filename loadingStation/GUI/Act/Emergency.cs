using System;
using System.Windows.Forms;
using loadingStation.Base.Function;
using loadingStation.Base.Connection.Devices.Smartdevice;
using Core;

namespace loadingStation.GUI.Act
{
    public partial class Emergency : Form
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

        #region Properties
        private bool _ForceStopAll = false;
        private bool _AllowClose = false;
        private const int LampRed = 8;
        public string Details
        {
            set { lblDetails.Text = value; }
        }
        public string Reason
        {
            set { lblReason.Text = value; }
        }
        public bool ForceStopAll
        {
            set { _ForceStopAll = value; }
        }
        public bool AllowClose
        {
            set { _AllowClose = value; }
        }
        #endregion

        public Emergency()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);
            Helper.AnimateBounce(this, 550, Location.X, Location.Y + 15);
        }

        private void ActionRestart_Load(object sender, EventArgs e)
        {
            Helper.FormTopMost(this);
            Terminate();

            if (_ForceStopAll)
            {
                // STOP LOGGING
                GlobalProperties.FLAG_LOGGING = false;
                btnOk.Text = "Restart";
            }

            else
            {
                btnOk.Text = "OK";
            }

            lblClose.Visible = _AllowClose;
        }

        private void Terminate()
        {
            foreach (ModbusOutput sd in GlobalProperties.DevicesOutput.Values)
            {
                // Close All Valve
                sd.ResetAllBit();
                sd.SetBit(LampRed);
            }

            System.Threading.Thread.Sleep(1000);

/*            foreach (ModbusInput sd in GlobalProperties.DevicesInput.Values)
            {
                sd.StopLogging();
            }

            System.Threading.Thread.Sleep(1000);*/
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            if (_ForceStopAll)
            {
                Actions.RelaunchApplication();
            }

            else
            {
                GlobalProperties.FLAG_EMERGENCY = false;
                _AllowClose = true;
                this.Close();
            }
        }

        private void ActionRestart_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (_AllowClose) ? false : true;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            _AllowClose = true;
            this.Close();
        }
    }
}