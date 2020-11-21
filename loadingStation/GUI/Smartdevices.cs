using System;
using System.Drawing;
using System.Windows.Forms;
using Transitions;

using loadingStation.Core.Function;
using loadingStation.Core.Modbus;

namespace loadingStation.GUI
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
        int index = 0;

        int bitvalue = 0;

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

            foreach(ModbusInput input in GlobalProperties.DevicesInput)
            {
                if (input.ConnectionStatus){ inputconnected++; }

                listInput.Items.Add(input.IpAddress.ToString());
                countinput++;
            }

            foreach(ModbusOutput output in GlobalProperties.DevicesOutput)
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
            index = listInput.SelectedIndex;
            txtSmartIp.Text = listInput.Items[index].ToString();
            txtStatus.Text = GlobalProperties.DevicesInput[index].ConnectionStatus.ToString();
            sdtype = type.input;
        }

        private void ListOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listOutput.SelectedIndex;
            txtSmartIp.Text = listOutput.Items[index].ToString();
            txtStatus.Text = GlobalProperties.DevicesOutput[index].ConnectionStatus.ToString();
            sdtype = type.output;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnValidation_Click(object sender, EventArgs e)
        {
            if(sdtype == type.input)
            {
                GlobalProperties.DevicesInput[index].StopLogging();
                GlobalProperties.DevicesInput[index].ForceValid = true;
                System.Threading.Thread.Sleep(1000);
                GlobalProperties.DevicesInput[index].StartLogging();
            }
            else
            {
                GlobalProperties.DevicesOutput[index].StopLogging();
                GlobalProperties.DevicesOutput[index].ForceValid = true;
                System.Threading.Thread.Sleep(1000);
                GlobalProperties.DevicesOutput[index].StartLogging();
            }
            MessageBox.Show("Successfully Applied.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnChk_Click(object sender, EventArgs e)
        {
            if(sdtype == type.input)
            {
                if (GlobalProperties.DevicesInput[index].ConnectionStatus)
                {
                    using (GUI.ValueChecker vc = new GUI.ValueChecker())
                    {
                        vc.IP = GlobalProperties.DevicesInput[index].IpAddress;
                        vc.DeviceInputIndex = index;
                        vc.ShowDialog();
                    }
                }
            }
        }

        private void TimerBit_Tick(object sender, EventArgs e)
        {
            txtBitvalue.Text = (sdtype == type.output) ? GlobalProperties.DevicesOutput[index].Value.ToString() : "-";
        }


    }
}
