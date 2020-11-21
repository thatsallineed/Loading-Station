using System;
using System.Windows.Forms;
using loadingStation.Core.Function;
using loadingStation.Core.Modbus;
using Transitions;

namespace loadingStation.Miniform
{
    public partial class ActionRestart : Form
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
        public string Details
        {
            set { lblDetails.Text = value; }
        }
        public string Reason
        {
            set { lblReason.Text = value; }
        }
        #endregion
        public ActionRestart()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(550));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            // STOP LOGGING
            PublicProperties.FLAG_LOGGING = false;

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

        private void ActionRestart_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void ActionRestart_Load(object sender, EventArgs e)
        {
            
        }
    }
}