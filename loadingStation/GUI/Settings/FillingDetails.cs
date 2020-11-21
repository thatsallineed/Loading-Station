using Core;
using loadingStation.Base.Configuration.Config;
using loadingStation.Base.Connection.Database;
using loadingStation.Base.Function;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace loadingStation.GUI.Settings
{
    public partial class FillingDetails : Form
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

        public FillingDetails()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Helper.FormRecenterLocation(this);
            Helper.AnimateBounce(this, 500, Location.X, Location.Y + 15);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GlobalProperties.DatabaseStatus)
            {
                CoreLS.Default.WaterFillingValue = int.Parse(txtWaterValue.Text);           // by percentage
                CoreLS.Default.CoolantFillingValue = int.Parse(txtCoolantValue.Text);       // by pulse

                CoreLS.Default.Save();
                CoreLS.Default.Upgrade();

                double CoolantPulse = double.Parse(txtPulseCoolant.Text);

                DB_SFDB.UpdatePulse(CoolantPulse);
            }
            else
            {
                MessageBox.Show("Data Unsaved Cause Reconnecting to Server", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Close();
        }

        private void FillingDetails_Load(object sender, EventArgs e)
        {
            txtWaterValue.Text = CoreLS.Default.WaterFillingValue.ToString();               // by percentage
            txtCoolantValue.Text = CoreLS.Default.CoolantFillingValue.ToString();           // by pulse

            DB_SFDB.Pulse(out double CoolantPulse);

            txtPulseCoolant.Text = CoolantPulse.ToString();
        }

        private void txtWaterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            //Helper.ExecuteCommandline("start osk",true);
            Process.Start(new ProcessStartInfo(
            ((Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\osk.exe"))));
        }
    }
}
