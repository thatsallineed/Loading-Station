using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

using loadingStation.Core.Function;

namespace loadingStation.GUI
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
        private string _Title,_Description;

        public string Title { set { _Title = value; } }
        public string Description { set { _Description = value; } }
        #endregion

        public ValueChange()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(550));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);
        }
        private void ValueChange_Load(object sender, EventArgs e)
        {
            lblTitle.Text = _Title;
            lblDescription.Text = _Description;
            txtValue.Text = Core.Configuration.Config.CoreLS.Default.ChangeDaysEnd.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Core.Configuration.Config.CoreLS.Default.ChangeDaysStart = DateTime.Now;
            Core.Configuration.Config.CoreLS.Default.ChangeDaysEnd = int.Parse(txtValue.Text);
            Core.Configuration.Config.CoreLS.Default.Save();
            Core.Configuration.Config.CoreLS.Default.Upgrade();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
