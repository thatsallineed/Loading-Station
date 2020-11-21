using loadingStation.Base.Configuration.Config;
using loadingStation.Base.Connection.Database;
using loadingStation.Base.Function;
using loadingStation.Base.Log;
using loadingStation.GUI.Act;
using loadingStation.GUI.Settings;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loadingStation.GUI.Main
{
    public partial class Dashboard : Form
    {
        int ValueMaintenance = 0;

        string TimeToChange;

        int Waterconsumption = 0;
        int Coolantconsumption = 0;

        // Selection Consumption, Monthly,Today
        int IndexOfConsumption = 0;

        char typeCoolant;
        Stopwatch swElapsedTime = new Stopwatch();

        bool FLAG_ERROR_TRIGGER = false;
        bool Logging { get { return GlobalProperties.FLAG_LOGGING; } }
        bool DeviceLoaded { get { return GlobalProperties.FLAG_DEVICELOADED; } }

        enum ProgressType
        {
            Coolant,
            Measure,
            Mixing
        }
        enum ProgressStatus
        {
            Max,
            Mid,
            Min
        }
        public Dashboard() => InitializeComponent();

        private void Dashboard_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvHistory, new object[] { true });

            ValveSetOnLoad();

            typeCoolant = GlobalProperties.CoolantType;

            dgvHistory.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistory.Columns["NRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            swElapsedTime.Start();
            timerFilling.Start();
            timerValve.Start();
            timerConsumption.Start();
            bgworkHistory.RunWorkerAsync();
            TaskElapsedDrum();

            //panelMaintenance.Visible = (GlobalProperties.Configuration.IsDebugging) ? true : false; testing
        }

        #region Valve Indicator
        private void ValveSetOnLoad()
        {
            GlobalProperties.PumpDrum = GlobalProperties.PumpDist = GlobalProperties.ValveCoolant = GlobalProperties.ValveWater = GlobalProperties.Valve.Close;
            GlobalProperties.CurrentStatus = GlobalProperties.Status.Ready;
            Actions.SetIndicator(GlobalProperties.Valve.Open, GlobalProperties.Type.Propeler);
        }

        private void ValveIndicator()
        {
            // Reset First
            ValveIndicatorReset();

            // Valve P1
            greendotP1.Image = (GlobalProperties.PumpDrum is GlobalProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // Valve P2
            greendotP2.Image = (GlobalProperties.PumpDist is GlobalProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // Valve V1
            greendotV1.Image = (GlobalProperties.ValveCoolant is GlobalProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // Valve V2
            greendotV2.Image = (GlobalProperties.ValveWater is GlobalProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // FlowMeter
            greendotFlow.Image = (GlobalProperties.FlowMeter is GlobalProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // Propeler
            pbPropeler.Image = (GlobalProperties.Propeler is GlobalProperties.Valve.Open) ? loadingStation.Properties.Resources.creopped : loadingStation.Properties.Resources.propelerstop;

            // Change Drum Notification
            panelNotifyDrum.Visible = (GlobalProperties.ChangeDrumNotify is GlobalProperties.Drum.Alert) ? true : false;

            // Current Status
            if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Ready)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.yellow;
                lblStatus.Text = GlobalProperties.Status.Ready.ToString();

                lblStatus2.Text = GlobalProperties.Status.Ready.ToString();
                lblStatus2.BackColor = Color.FromArgb(81, 79, 92);
            }

            if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Filling)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.yellow;
                lblStatus.Text = GlobalProperties.Status.Filling.ToString();

                lblStatus2.Text = GlobalProperties.Status.Filling.ToString();
                lblStatus2.BackColor = Color.FromArgb(0, 192, 0);
            }

            if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Mixing)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.yellow;
                lblStatus.Text = GlobalProperties.Status.Mixing.ToString();

                lblStatus2.Text = GlobalProperties.Status.Mixing.ToString();
                lblStatus2.BackColor = Color.FromArgb(0, 192, 0);
            }

            if(GlobalProperties.CurrentStatus is GlobalProperties.Status.Changedrum)
            {
                greendotStatus.Image = Properties.Resources.yellow;
                lblStatus.Text = GlobalProperties.Status.Changedrum.ToString();

                lblStatus2.Text = GlobalProperties.Status.Changedrum.ToString();
                lblStatus2.BackColor = Color.FromArgb(235, 77, 75);
            }

            if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Error)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.red;
                lblStatus.Text = GlobalProperties.Status.Error.ToString();

                lblStatus2.Text = GlobalProperties.Status.Error.ToString();
                lblStatus2.BackColor = Color.FromArgb(235, 77, 75);
            }

            if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Emergency)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.red;
                lblStatus.Text = GlobalProperties.Status.Emergency.ToString();

                lblStatus2.Text = GlobalProperties.Status.Emergency.ToString();
                lblStatus2.BackColor = Color.FromArgb(235, 77, 75);
            }

            if (GlobalProperties.CurrentStatus is GlobalProperties.Status.Manual)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.red;
                lblStatus.Text = GlobalProperties.Status.Manual.ToString();

                lblStatus2.Text = GlobalProperties.Status.Manual.ToString();
                lblStatus2.BackColor = Color.FromArgb(235, 77, 75);
            }

            bool ValveCoolant = GlobalProperties.ValveCoolant is GlobalProperties.Valve.Open;
            bool ValveWater = GlobalProperties.ValveWater is GlobalProperties.Valve.Open;

            bool Distribution = GlobalProperties.PumpDist is GlobalProperties.Valve.Open;
            bool Changedrum = GlobalProperties.ChangeDrumNotify is GlobalProperties.Drum.Alert || GlobalProperties.FLAG_CHANGEDRUM;

            bool Error = GlobalProperties.FLAG_EMERGENCY;
            bool Manual = GlobalProperties.ManualState;

            if (DeviceLoaded)
            {
                bool ModbusInput = GlobalProperties.ModbusInput.ConnectionStatus;
                bool ModbusOutput = GlobalProperties.ModbusOutput.ConnectionStatus;

                // device status connected
                if (ModbusInput && ModbusOutput)
                {
                    // if valve coolant or valve water is opened
                    if ((ValveCoolant || ValveWater) && !Manual)
                        Actions.SetIndicator(3);

                    // if pump distribution is opened
                    else if (Distribution)
                        Actions.SetIndicator(2);

                    // if changedrum alert
                    else if (Changedrum)
                        Actions.SetIndicator(7);

                    // if manual state is true
                    else if (Manual)
                        Actions.SetIndicator(6);

                    // if emergency
                    else if (Error)
                        Actions.SetIndicator(5);

                    // if all been closed
                    else
                        Actions.SetIndicator(1);
                }

                // device status is disconnect
                else
                    Actions.SetIndicator(5);
            }
        }

        private void ValveIndicatorReset()
        {
            greendotStatus.Image = loadingStation.Properties.Resources.yellow;
            lblStatus.Text = GlobalProperties.Status.Ready.ToString();
        }
        #endregion

        #region ProgressBar : <ProgressSetColor>
        private void ProgressSetColor(ProgressType type, ProgressStatus status)
        {
            // Only ProgressBar Coloring

            const int MAX_R = 50;
            const int MAX_G = 168;
            const int MAX_B = 62;

            const int MID_R = 255;
            const int MID_G = 192;
            const int MID_B = 56;

            const int MIN_R = 255;
            const int MIN_G = 71;
            const int MIN_B = 71;

            switch (type)
            {
                case ProgressType.Coolant:
                    if (status is ProgressStatus.Max) { ProgressDrum3.ForeColor = Color.FromArgb(MAX_R, MAX_G, MAX_B); }
                    if (status is ProgressStatus.Mid) { ProgressDrum3.ForeColor = Color.FromArgb(MID_R, MID_G, MID_B); }
                    if (status is ProgressStatus.Min) { ProgressDrum3.ForeColor = Color.FromArgb(MIN_R, MIN_G, MIN_B); }
                    break;

/*                case ProgressType.Measure:
                    if (status is ProgressStatus.Max) { ProgressDrum2.ForeColor = Color.FromArgb(MAX_R, MAX_G, MAX_B); }
                    if (status is ProgressStatus.Mid) { ProgressDrum2.ForeColor = Color.FromArgb(MID_R, MID_G, MID_B); }
                    if (status is ProgressStatus.Min) { ProgressDrum2.ForeColor = Color.FromArgb(MIN_R, MIN_G, MIN_B); }
                    break;*/

                case ProgressType.Mixing:
                    if (status is ProgressStatus.Max) { ProgressDrum1.ForeColor = Color.FromArgb(MAX_R, MAX_G, MAX_B); }
                    if (status is ProgressStatus.Mid) { ProgressDrum1.ForeColor = Color.FromArgb(MID_R, MID_G, MID_B); }
                    if (status is ProgressStatus.Min) { ProgressDrum1.ForeColor = Color.FromArgb(MIN_R, MIN_G, MIN_B); }
                    break;
            }
        }
        #endregion

        private void SelectionChanged()
        {
            timerConsumption.Interval = (IndexOfConsumption is 2) ? 150000 : 43200000;
            bgwConsumption.RunWorkerAsync();
            timerConsumption.Stop();
            timerConsumption.Start();
        }
        private void BgworkHistory_DoWork(object sender, DoWorkEventArgs e)
        {
            while (GlobalProperties.FLAG_LOGGING)
            {
                try
                {
                    if (GlobalProperties.DatabaseStatus)
                    {
                        DataTable dtHistory = DB_SFDB.PopulateHistory(typeCoolant);

                        BeginInvoke((MethodInvoker)delegate
                        {
                            try
                            {
                                dgvHistory.Rows.Clear();

                                int row = 0;
                                foreach (DataRow dr in dtHistory.Rows)
                                {
                                    dgvHistory.Rows.Add(dr.ItemArray);
                                    dgvHistory.Rows[row].Cells[0].Value = row + 1;
                                    row += 1;
                                }
                            }
                            catch (Exception x)
                            {
                                Error.Collect(x.StackTrace.ToString());
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    Error.Collect(ex.StackTrace.ToString());
                }
                Thread.Sleep(3000);
            }
        }

        private void TimerFilling_Tick(object sender, EventArgs e)
        {
            try
            {
                // Default Min Max value Mixing
                const int MinMixing = 10;
                const int ThresholdMixing = 30;

                // Default Min Max value Measure
                const int MinMeasure = 20;
                const int ThresholdMeasure = 40;

                // Default Min Max value Drum
                const int MinDrum = 10;
                const int ThresholdDrum = 30;

                // Get Realtime values
                int Mixing = GlobalProperties.Value[0];
                int Measure = GlobalProperties.Value[1];
                int Coolant = GlobalProperties.Value[2];

                // Fixing values
                Mixing = Mixing > 100 ? 100 : Mixing;
                Measure = Measure > 100 ? 100 : Measure;
                Coolant = Coolant > 100 ? 100 : Coolant;

                // Set value to Drum ProgressBar
                ProgressDrum1.Value = Mixing;
                //ProgressDrum2.Value = Measure;
                ProgressDrum3.Value = Coolant;

                if (ProgressDrum1.Value > ThresholdMixing)
                { ProgressSetColor(ProgressType.Mixing, ProgressStatus.Max); }

/*                if (ProgressDrum2.Value > ThresholdMeasure)
                { ProgressSetColor(ProgressType.Measure, ProgressStatus.Max); }*/

                if (ProgressDrum3.Value > ThresholdDrum)
                { ProgressSetColor(ProgressType.Coolant, ProgressStatus.Max); }

                if (ProgressDrum1.Value <= ThresholdMixing && ProgressDrum1.Value > MinMixing)
                { ProgressSetColor(ProgressType.Mixing, ProgressStatus.Mid); }

/*                if (ProgressDrum2.Value <= ThresholdMeasure && ProgressDrum2.Value > MinMeasure)
                { ProgressSetColor(ProgressType.Measure, ProgressStatus.Mid); }*/

                if (ProgressDrum3.Value <= ThresholdDrum && ProgressDrum3.Value > MinDrum)
                { ProgressSetColor(ProgressType.Coolant, ProgressStatus.Mid); }

                if (ProgressDrum1.Value <= MinMixing)
                { ProgressSetColor(ProgressType.Mixing, ProgressStatus.Min); }

/*                if (ProgressDrum2.Value <= MinMeasure)
                { ProgressSetColor(ProgressType.Measure, ProgressStatus.Min); }*/

                if (ProgressDrum3.Value <= MinDrum)
                { ProgressSetColor(ProgressType.Coolant, ProgressStatus.Min); }

                string opname = "_";
                if (Tasklist.TableTasklist != null)
                {
                    foreach (DataRow dr in Tasklist.TableTasklist.Rows)
                    {
                        if (dr["status"].ToString() is "1")
                        {
                            opname = dr["op_name"].ToString();
                            break;
                        }
                    }
                }
                lblOPName.Invoke(new Action(() => lblOPName.Text = opname));
            }
            catch (Exception x)
            {
                Error.Collect(x.StackTrace.ToString());
                Debug.WriteLine(x);

                if (!FLAG_ERROR_TRIGGER)
                {
                    FLAG_ERROR_TRIGGER = true;
                    using (Emergency rs = new Emergency())
                    {
                        rs.Reason = "SD Input Level Number Error";
                        rs.Details = "Unknown Level Number";
                        rs.ShowDialog();
                    }
                }
            }
        }

        private void TimerValve_Tick(object sender, EventArgs e)
        {
            ValveIndicator();

            TimeSpan temp = swElapsedTime.Elapsed;
            string format = String.Format("Running Time :   {0:D2}:{1:D2}:{2:D2}:{3:D2}", temp.Days, temp.Hours, temp.Minutes, temp.Seconds);
            lblRunningTime.Text = format;
            lblTimeElapsed.Text = TimeToChange;

            lblPercentageDrum.Text = $"{GlobalProperties.Value[2]}%";
            lblPercentageMixing.Text = $"{GlobalProperties.Value[0]}%";

            if (GlobalProperties.ValveWater is GlobalProperties.Valve.Open && Logging)
            {
                lblTimelapseValveWater.Visible = true;
                lblTimelapseValveWater.Text = GlobalProperties.TimelapseValveWater;
            }
            else
            {
                lblTimelapseValveWater.Visible = false;
            }

            if (GlobalProperties.ValveCoolant is GlobalProperties.Valve.Open && Logging)
            {
                lblTimelapseValveCoolant.Visible = true;
                lblTimelapseValveCoolant.Text = GlobalProperties.TimelapseValveCoolant;
            }
            else
            {
                lblTimelapseValveCoolant.Visible = false;
            }
        }

        private void PbChangeDrum_Click(object sender, EventArgs e)
        {
            // currentstatus status mixing
            bool CurrentStatus = GlobalProperties.CurrentStatus is GlobalProperties.Status.Mixing;

            if (GlobalProperties.DatabaseStatus && GlobalProperties.FLAG_DEVICELOADED && !CurrentStatus && !GlobalProperties.FLAG_EMERGENCY && GlobalProperties.ModbusInput.ConnectionStatus && GlobalProperties.ModbusOutput.ConnectionStatus)
            {
                using (Login login = new Login())
                {
                    login.ShowDialog();
                    if (login.DialogResult is DialogResult.OK)
                    {
                        using (Changedrum fs = new Changedrum())
                        {
                            fs.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                string Message = !CurrentStatus ? "Mixing" : "Reconnect";
                MessageBox.Show($"Cannot Change Drum While {Message}!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAppconfig_Click(object sender, EventArgs e)
        {
            using (AppSetting setting = new AppSetting())
            {
                setting.ShowDialog();
            }
        }

        private void BtnSmartdevices_Click(object sender, EventArgs e)
        {

        }

        private void BtnLsConfig_Click(object sender, EventArgs e)
        {
            using (LSSetting ls = new LSSetting())
            {
                ls.ShowDialog();
            }
        }

        private void PanelUnlock_Click(object sender, EventArgs e)
        {
            ValueMaintenance = (panelMaintenance.Visible) ? 0 : ValueMaintenance;
            panelMaintenance.Visible = (ValueMaintenance > 4) ? true : false;
            ValueMaintenance++;
        }

        private void BgwConsumption_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (GlobalProperties.DatabaseStatus)
                {
                    //Waterconsumption = DB_SFDB.WaterConsumption();
                    //Coolantconsumption = DB_SFDB.CoolantConsumption();
                }
            }
            catch { }
        }

        private void BgwConsumption_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblWaterConsumption.Text = Waterconsumption.ToString();
            lblCoolantConsumption.Text = Coolantconsumption.ToString();
        }

        private void CbWaterTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexOfConsumption = cbWaterTime.SelectedIndex;
            SelectionChanged();
        }

        private void CbCoolantTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexOfConsumption = cbCoolantTime.SelectedIndex;
            SelectionChanged();
        }

        private void TimerConsumption_Tick(object sender, EventArgs e)
        {
            bgwConsumption.RunWorkerAsync();
        }

        private void BtnDrumElapsed_Click(object sender, EventArgs e)
        {
            using (ValueChange c = new ValueChange())
            {
                c.Title = "Change Value";
                c.Description = "Duration Changedrum Time";
                c.ShowDialog();
            }
        }

        private void TaskElapsedDrum()
        {
            Task task = new Task(() =>
            {
                while (GlobalProperties.FLAG_LOGGING)
                {
                    CoreLS Configuration = CoreLS.Default;
                    DateTime EndDate = Convert.ToDateTime(Configuration.ChangeDaysStart);
                    Int64 AddedDays = Convert.ToInt64(Configuration.ChangeDaysEnd);
                    EndDate = EndDate.AddDays(AddedDays);

                    int Calculation = EndDate.Day - int.Parse(DateTime.Parse(Configuration.ChangeDaysStart.ToString()).ToString("dd"));
                    //int Calculation =  int.Parse(DateTime.Parse(Configuration.ChangeDaysStart.ToString()).ToString("dd")) - EndDate.Day;
                    int Day = Calculation >= 0 ? Calculation : 0;

                    TimeToChange = $"Time to Change {Day} Days";
                    Thread.Sleep(360000);
                }
            });
            task.Start();
        }

        private void btnFilling_Click(object sender, EventArgs e)
        {
            if (GlobalProperties.DatabaseStatus)
            {
                using (FillingDetails form = new FillingDetails())
                {
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Cannot Change Value Cause Reconnecting to Server", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    #region progressbar
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
    #endregion
}
