using System;
using System.Drawing;
using System.Windows.Forms;
using Transitions;

using loadingStation.GUI.Settings;
using loadingStation.Base.Function;
using loadingStation.Base.Connection.Devices.Smartdevice;

namespace loadingStation.GUI.Settings
{
    public partial class Smartdevices : Form
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

        int countinput = 0;
        int countoutput = 0;
        int inputconnected = 0;
        int outputconnected = 0;

        string IpAddress;

        int bitvalue = 0;

        bool SelectedDevice = false;

        enum type
        {
           input,
           output
        };
        type sdtype = new type();

        public Smartdevices()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.SetDoubleBuffered(this);
            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(550));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);

            foreach(ModbusInput input in GlobalProperties.DevicesInput.Values)
            {
                if (input.ConnectionStatus){ inputconnected++; }

                listInput.Items.Add(input.IpAddress.ToString());
                countinput++;
            }

            foreach(ModbusOutput output in GlobalProperties.DevicesOutput.Values)
            {
                if (output.ConnectionStatus){ outputconnected++; }

                listOutput.Items.Add(output.IpAddress.ToString());
                countoutput++;
            }

            int countresult = countinput + countoutput;
            int connectedresult = inputconnected + outputconnected;
            lblCount.Text = connectedresult + " Of " + countresult + " Connected";

            bool check = ((countresult == connectedresult) && (countresult != 0));
            lblStatus.Text = (check) ? "Connection OK" : "Some Connection Disconnected";
            lblStatus.ForeColor = (check) ? Color.FromArgb(192, 255, 192) : Color.FromArgb(235, 77, 75);
        }

        private void ListInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            IpAddress = listInput.SelectedItem.ToString();
            txtSmartIp.Text = IpAddress;
            txtStatus.Text = GlobalProperties.DevicesInput[IpAddress].ConnectionStatus.ToString();
            sdtype = type.input;
            SelectedDevice = true;
        }

        private void ListOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            IpAddress = listOutput.SelectedItem.ToString();
            txtSmartIp.Text = IpAddress;
            sdtype = type.output;
            txtStatus.Text =  GlobalProperties.DevicesOutput[IpAddress].ConnectionStatus.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnValidation_Click(object sender, EventArgs e)
        {
            if(sdtype == type.input)
            {
                GlobalProperties.DevicesInput[IpAddress].StopLogging();
                GlobalProperties.DevicesInput[IpAddress].ForceValid = true;
                System.Threading.Thread.Sleep(1000);
                GlobalProperties.DevicesInput[IpAddress].StartLogging();
            }
            else
            {
                GlobalProperties.DevicesOutput[IpAddress].StopLogging();
                GlobalProperties.DevicesOutput[IpAddress].ForceValid = true;
                System.Threading.Thread.Sleep(1000);
                GlobalProperties.DevicesOutput[IpAddress].StartLogging();
            }
            MessageBox.Show("Successfully Applied.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnChk_Click(object sender, EventArgs e)
        {
            if(SelectedDevice)
            {
                if (sdtype is type.input)
                {
                    if (GlobalProperties.DevicesInput[IpAddress].ConnectionStatus)
                    {
                        using (ValueChecker vc = new ValueChecker())
                        {
                            vc.IP = GlobalProperties.DevicesInput[IpAddress].IpAddress;
                            //vc.DeviceInputIpAddress = IpAddress;
                            vc.ShowDialog();
                        }
                    }
                }
            }
        }

        private void TimerBit_Tick(object sender, EventArgs e)
        {
            txtBitvalue.Text = (sdtype == type.output) ? GlobalProperties.DevicesOutput[IpAddress].Value.ToString() : "-";
        }


    }
}
