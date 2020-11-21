using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

using loadingStation.Core.Modbus;
using loadingStation.Core.Log;
using loadingStation.Core.Function;
using loadingStation.Core.Database;

namespace loadingStation.Miniform
{
    public partial class Changedrum : Form
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

        bool IsOnceSubmit = false;
        bool retry = false;

        bool FLAG_NEXT = true;
        bool FLAG_PREV = true;

        bool AsyncTask = false;

        int CountStep = 0;

        ModbusInput DeviceInput;
        ModbusOutput DeviceOutput;

        List<Image> ImageList = new List<Image>();
        List<string> StepList = new List<string>();

        #endregion

        public Changedrum()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(Actions.CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Actions.RecenterLocation(this);

            Transition t1 = new Transition(new TransitionType_Bounce(500));
            t1.add(this, "Top", this.Location.Y + 15);
            Transition.runChain(t1);

            DeviceInput = PublicProperties.DevicesInput[0];
            DeviceOutput = PublicProperties.DevicesOutput[0];

            AddToDict();
            Step(0);

            pbNext.Visible = true;
        }

        #region Action: <Submit>

        private void Submit()
        {
            if (!IsOnceSubmit && !bgwSubmit.IsBusy)
            {
                DisableNav();
                panelNotification.Visible = true;
                bgwSubmit.RunWorkerAsync();
            }
        }
        private void BgwSubmit_DoWork(object sender, DoWorkEventArgs e)
        {
            IsOnceSubmit = true;
            string userid = PublicProperties.UserID;
            char coolanttype = PublicProperties.CoolantType;

            retry = true;
            while (retry)
            {
                try
                {
                    if (PublicProperties.DatabaseStatus)
                    {
                        string datenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DB_SFDB.InsertHistoryLoading(userid, coolanttype, datenow);
                        retry = false;
                    }
                }
                catch { }
                Thread.Sleep(50);
            }
        }

        private void BgwSubmit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelNotification.Visible = false;
            this.Close();
        }
        #endregion

        #region Action: <EnableNav/DisableNav>
        private void EnableNav()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                pbNext.Visible = true;
                pbPrevious.Visible = true;
            });
        }
        private void DisableNav()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                pbNext.Visible = false;
                pbPrevious.Visible = false;
            });
        }
        private void StatusIndicator(bool status)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                pbStatus.Image = (status) ? Properties.Resources.yellow : Properties.Resources.red;
            });
        }
        #endregion

        #region Function: <StepFunction/AddToDict/Step>
        private void StepFunction(int index)
        {
            //lblAutodetect.Visible = false;
            panelDetection.Visible = false;

            switch (index + 1)
            {
                case 0:
                    // Lepas Level Sensor
                    UnplugLevel(); //opsional
                    break;

                case 3:
                    // Tarik Trolley
                    //lblAutodetect.Visible = true;
                    panelDetection.Visible = true;
                    PullTrolley();
                    break;

                case 4:
                    // Ganti drum
                    ChangeDrum(); //manual
                    break;

                case 5:
                    // Masukkan Trolley
                    //lblAutodetect.Visible = true;
                    panelDetection.Visible = true;
                    PutTrolley();
                    break;

                case 7:
                    // Pasang Level Sensor
                    PlugLevel(); //opsional
                    break;

                case 8:
                    // Finish, Cek kembali case sebelumnya & submit
                    CheckAll();
                    break;
            }

            if (CountStep != 0)
            {
                pbPrevious.Visible = true;
            }
            else
            {
                pbPrevious.Visible = false;
            }

        }
        private void AddToDict()
        {
            ImageList.Add(Properties.Resources.CD_1);
            StepList.Add("Lepas Level Sensor");

            ImageList.Add(Properties.Resources.CD_2);
            StepList.Add("Lepas Pipa Drum");

            ImageList.Add(Properties.Resources.CD_3);
            StepList.Add("Tarik Trolley");

            ImageList.Add(Properties.Resources.CD_4);
            StepList.Add("Ganti Drum");

            ImageList.Add(Properties.Resources.CD_5);
            StepList.Add("Masukkan Trolley");

            ImageList.Add(Properties.Resources.CD_6);
            StepList.Add("Pasang Pipa Drum");

            ImageList.Add(Properties.Resources.CD_7);
            StepList.Add("Pasang Level Sensor");

            ImageList.Add(Properties.Resources.CD_8);
            StepList.Add("Finish");
        }

        private void Step(int index)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    if (index > ImageList.Count - 1)
                    {
                        Submit();
                    }
                    else
                    {
                        pbStep.Image = ImageList[index];
                        lblDescription.Text = StepList[index];
                        lblStepCount.Text = (index + 1) + "/" + ImageList.Count;
                        StepFunction(index);
                    }
                }
                catch { }
            });
        }
        #endregion

        #region Button: Event
        private void PbNext_Click(object sender, EventArgs e)
        {
            if (FLAG_NEXT)
            {
                if (!AsyncTask)
                {
                    CountStep++;
                    Step(CountStep);
                    FLAG_PREV = true;
                }
            }
            else
            {
                MessageBox.Show("Cannot Skip this Step!, Status Not Ready", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void PbPrevious_Click(object sender, EventArgs e)
        {
            if (FLAG_PREV)
            {
                if (CountStep != 0)
                {
                    CountStep--;
                }
                Step(CountStep);
                FLAG_NEXT = true;
                AsyncTask = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            retry = false;
            this.Close();
        }
        #endregion

        #region Action
        private void UnplugLevel()
        {
            // OPSIONAL
        }

        private void PullTrolley()
        {
            Task TaskPull = new Task(() =>
            {
                AsyncTask = true;
                StatusIndicator(false);

                while (AsyncTask)
                {
                    try
                    {
                        FLAG_NEXT = false;
                        if(PublicProperties.ModbusInputStatus && PublicProperties.ModbusOutputStatus)
                        {
                            // WRITE
                            DeviceOutput.ResetBit(13);

                            // READ
                            DeviceInput.GetData("CHA8",out int result);

                            System.Diagnostics.Debug.WriteLine(result);
                            // CHECK
                            if(result != 0)
                            {
                                StatusIndicator(true);

                                FLAG_NEXT = true;
                                AsyncTask = false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.ToString());
                    }
                    Thread.Sleep(100);
                }
            });
            TaskPull.Start();
        }

        private void ChangeDrum()
        {

        }

        private void PutTrolley()
        {
            Task TaskPull = new Task(() =>
            {
                AsyncTask = true;
                StatusIndicator(false);

                while (AsyncTask)
                {
                    try
                    {
                        FLAG_NEXT = false;
                        if (PublicProperties.ModbusInputStatus && PublicProperties.ModbusOutputStatus)
                        {
                            // WRITE
                            DeviceOutput.SetBit(13);

                            // READ
                            DeviceInput.GetData("CHA9", out int result);

                            System.Diagnostics.Debug.WriteLine(result);
                            // CHECK
                            if (result != 0)
                            {
                                StatusIndicator(true);

                                FLAG_NEXT = true;
                                AsyncTask = false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.ToString());
                    }
                    Thread.Sleep(100);
                }
            });
            TaskPull.Start();
        }

        private void PlugLevel()
        {

        }

        private void CheckAll()
        {

        }
        #endregion

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            AsyncTask = false;
            this.Close();
        }

        private void PbPrevious_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
