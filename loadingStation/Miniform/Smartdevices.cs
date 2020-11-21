using System;
using System.Drawing;
using System.Windows.Forms;
using Transitions;

using loadingStation.Core.Function;
using loadingStation.Core.Modbus;

namespace loadingStation.Miniform
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

            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(550));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);

            foreach(ModbusInput input in PublicProperties.DevicesInput)
            {
                if (input.ConnectionStatus){ inputconnected++; }

                listInput.Items.Add(input.IpAddress.ToString());
                countinput++;
            }

            foreach(ModbusOutput output in PublicProperties.DevicesOutput)
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
            txtStatus.Text = PublicProperties.DevicesInput[index].ConnectionStatus.ToString();
            sdtype = type.input;
        }

        private void ListOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listOutput.SelectedIndex;
            txtSmartIp.Text = listOutput.Items[index].ToString();
            txtStatus.Text = PublicProperties.DevicesOutput[index].ConnectionStatus.ToString();
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
                PublicProperties.DevicesInput[index].StopLogging();
                PublicProperties.DevicesInput[index].ForceValid = true;
                System.Threading.Thread.Sleep(1000);
                PublicProperties.DevicesInput[index].StartLogging();
            }
            else
            {
                PublicProperties.DevicesOutput[index].StopLogging();
                PublicProperties.DevicesOutput[index].ForceValid = true;
                System.Threading.Thread.Sleep(1000);
                PublicProperties.DevicesOutput[index].StartLogging();
            }
            MessageBox.Show("Successfully Applied.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TimerBit_Tick(object sender, EventArgs e)
        {
            txtBitvalue.Text = (sdtype == type.output) ? PublicProperties.DevicesOutput[index].Value.ToString() : "-";
        }
    }
}
