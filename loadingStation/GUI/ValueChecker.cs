using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using loadingStation.Core.Function;
using Transitions;

namespace loadingStation.GUI
{


    public partial class ValueChecker : Form
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

        public string IP { get; set; }
        public int DeviceInputIndex { get; set; }

        private int IndexCount;
        private bool IsRun = false;

        private List<string> ColumnList = new List<string>();
        private List<string> InputName = new List<string>();
        private List<string> InputAddr = new List<string>();
        private List<int> InputValue = new List<int>();

        public ValueChecker()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(550));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);
        }
        private void ValueChecker_Load(object sender, EventArgs e)
        {
            lblIP.Text = (IP != null) ? IP : "UNKNOWN";

            ListValue();
            LoadDgv();
        }

        private void ListValue()
        {

            // ADD or REMOVE HERE
            Add("LevelMixing", "CHA14");
            Add("LevelMeasure", "CHA15");
            Add("LevelDrum", "CHA16");

            Add("FeedbackOn Water", "CHA10");
            Add("FeedbackOff Water", "CHA11");

            Add("FeedbackOn Coolant", "CHA12");
            Add("FeedbackOff Coolant", "CHA13");

            Add("FeedbackOn Interlock LOCK", "CHA9");
            Add("FeedbackOff Interlock LOCK", "CHA8");

            Add("FeedbackOn Interlock UNLOCK", "CHA8");
            Add("FeedbackOff Interlock UNLOCK", "CHA9");
        }


        private void Add(string Name, string Addr)
        {
            InputName.Add(Name);
            InputAddr.Add(Addr);
            InputValue.Add(0);
        }

        private void LoadDgv()
        {
            try
            {
                IndexCount = 0;
                foreach (string n in InputName)
                {
                    dgvValue.Rows.Add(new string[] { n, InputValue[IndexCount].ToString() });
                    IndexCount++;
                }
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine(x);
            }
            
        }

        BackgroundWorker bgwRTValue = new BackgroundWorker();
        private void StartRealtimeValue()
        {
            Task task = new Task(() =>
            {
                while (IsRun)
                {
                    if (!bgwRTValue.IsBusy)
                    {
                        bgwRTValue.DoWork += BgwRTValue_DoWork;
                        bgwRTValue.RunWorkerAsync();
                        Application.DoEvents();
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            });
            task.Start();
        }

        private void BgwRTValue_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IndexCount = 0;
                foreach(string n in InputAddr)
                {
                    IndexCount++;
                    GlobalProperties.DevicesInput[DeviceInputIndex].GetData(n, out int x);
                    InputValue[IndexCount - 1] = x;
                }

                IndexCount = 0;
                foreach (int n in InputValue)
                {
                    dgvValue.Rows[IndexCount].Cells[1].Value = n;
                    IndexCount++;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString() + "\n " + IndexCount);
            }
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Start")
            {
                IsRun = true;
                btnClose.Visible = false;
                btnAction.Text = "Stop";
                StartRealtimeValue();
            }
            else
            {
                IsRun = false;
                btnClose.Visible = true;
                btnAction.Text = "Start";
            }
        }

        private void ValueChecker_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsRun = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
