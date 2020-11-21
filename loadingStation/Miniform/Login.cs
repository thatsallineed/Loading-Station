using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Transitions;

using loadingStation.Core.Database;
using loadingStation.Core.Function;
using loadingStation.Core.Log;

namespace loadingStation.Miniform
{
    public partial class Login : Form
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
        bool _AuthenticationResult = false;
        string ID = "";

        public string Description
        {
            set { lblDescription.Text = value; }
        }
        #endregion

        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(550));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            txtRfid.Select();
        }

        private void TxtRfid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!bgwAuth.IsBusy)
                {
                    ID = txtRfid.Text;
                    bgwAuth.RunWorkerAsync();
                }
            }
        }

        private void BgwAuth_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (txtRfid.Text != "")
                {
                    _AuthenticationResult = false;

                    if (PublicProperties.DatabaseStatus && PublicProperties.ModbusInputStatus && PublicProperties.ModbusOutputStatus)
                    {
                       _AuthenticationResult = DB_SFDB.LoginAuthentication(ID);
                    }
                    else
                    {
                        MessageBox.Show("Cannot Login While Reconnecting!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception m)
            {
                Error.Collect(m.StackTrace.ToString());
            }
        }

        private void BgwAuth_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_AuthenticationResult)
            {
                PublicProperties.UserID = txtRfid.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblDescription.Text = "Unknown ID, Please Re-Tap Again";
                lblDescription.ForeColor = Color.FromArgb(197, 95, 95);
                txtRfid.Text = "";

                lblDescription.Location = new Point(16,100);

                if (!bgwAnimate.IsBusy)
                {
                    bgwAnimate.RunWorkerAsync();
                }
            }
        }

        private void BgwAuth_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblDescription.Text = "Logging in";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BgwAnimate_DoWork(object sender, DoWorkEventArgs e)
        {
            Transition.run(lblDescription, "Left", 25, new TransitionType_Bounce(450));
        }
    }
}
