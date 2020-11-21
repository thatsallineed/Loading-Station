using Core;
using System;
using System.Windows.Forms;

namespace loadingStation.GUI.Act
{
    public partial class Information : Form
    {
        private bool _Autoclose = false;
        private string _Message = "";
        private int _MaxTimeout = 3000;

        public bool Autoclose { set { _Autoclose = value; } }
        public string Message { set { _Message = value; } }
        public int MaxTimeout { set { _MaxTimeout = value; } }

        public Information()
        {
            InitializeComponent();
        }

        private void Information_Load(object sender, EventArgs e)
        {
            Helper.FormRecenterLocation(this);
            Helper.FormTopMost(this);

            timerClose.Interval = _MaxTimeout;

            if (_Autoclose)
                timerClose.Start();

            lblMessage.Text = _Message;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
