using Core;
using loadingStation.Base.Function;
using System;
using System.Windows.Forms;
using Transitions;

namespace loadingStation.GUI.Settings
{
    public partial class ValueChange : Form
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
        private string _Title, _Description;

        public string Title { set { _Title = value; } }
        public string Description { set { _Description = value; } }
        #endregion

        public ValueChange()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);
            Helper.AnimateBounce(this, 550, Location.X, Location.Y + 15);
        }
        private void ValueChange_Load(object sender, EventArgs e)
        {
            lblTitle.Text = _Title;
            lblDescription.Text = _Description;
            txtValue.Text = Base.Configuration.Config.CoreLS.Default.ChangeDaysEnd.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Base.Configuration.Config.CoreLS.Default.ChangeDaysStart = DateTime.Now;
            Base.Configuration.Config.CoreLS.Default.ChangeDaysEnd = int.Parse(txtValue.Text);
            Base.Configuration.Config.CoreLS.Default.Save();
            Base.Configuration.Config.CoreLS.Default.Upgrade();
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
