using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

using loadingStation.Core.Database;
using loadingStation.Core.Function;
using loadingStation.Core.Log;

namespace loadingStation.Miniform
{
    public partial class Dashboard : Form
    {
        int ValueMaintenance = 0;

        int Waterconsumption = 0;
        int Coolantconsumption = 0;

        // Selection Consumption, Alltime,Monthly,Today
        int IndexOfConsumption = 0;

        char typeCoolant;
        Stopwatch swElapsedTime = new Stopwatch();

        bool FLAG_ERROR_TRIGGER = false;

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

            typeCoolant = PublicProperties.CoolantType;

            dgvHistory.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistory.Columns["NRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            swElapsedTime.Start();
            timerFilling.Start();
            timerValve.Start();
            timerConsumption.Start();
            bgworkHistory.RunWorkerAsync();

            panelMaintenance.Visible = (Core.Configuration.Config.App.Default.IsDebugging) ? true : false;
        }

        #region Valve Indicator
        private void ValveSetOnLoad()
        {
            PublicProperties.ValveDrum = PublicProperties.ValveDist = PublicProperties.ValveCoolant = PublicProperties.ValveWater = PublicProperties.Valve.Close;
            PublicProperties.CurrentStatus = PublicProperties.Status.Ready;
            Actions.SetIndicator(PublicProperties.Valve.Open, PublicProperties.Type.Propeler);
        }

        private void ValveIndicator()
        {
            // Reset First
            ValveIndicatorReset();

            // Valve P1
            greendotP1.Image = (PublicProperties.ValveDrum == PublicProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // Valve P2
            greendotP2.Image = (PublicProperties.ValveDist == PublicProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // Valve V1
            greendotV1.Image = (PublicProperties.ValveCoolant == PublicProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // Valve V2
            greendotV2.Image = (PublicProperties.ValveWater == PublicProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // FlowMeter
            greendotFlow.Image = (PublicProperties.FlowMeter == PublicProperties.Valve.Open) ? loadingStation.Properties.Resources.yellow : loadingStation.Properties.Resources.red;

            // Propeler
            pbPropeler.Image = (PublicProperties.Propeler == PublicProperties.Valve.Open) ? loadingStation.Properties.Resources.creopped : loadingStation.Properties.Resources.propelerstop;

            // Change Drum Notification
            panelNotifyDrum.Visible = (PublicProperties.ChangeDrumNotify == PublicProperties.Drum.Alert) ? true : false;

            // Current Status
            if(PublicProperties.CurrentStatus == PublicProperties.Status.Ready)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.yellow;
                lblStatus.Text = PublicProperties.Status.Ready.ToString();
            }

            if(PublicProperties.CurrentStatus == PublicProperties.Status.Filling)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.yellow;
                lblStatus.Text = PublicProperties.Status.Filling.ToString();
            }

            if (PublicProperties.CurrentStatus == PublicProperties.Status.Error)
            {
                greendotStatus.Image = loadingStation.Properties.Resources.red;
                lblStatus.Text = PublicProperties.Status.Error.ToString();
            }

            bool _ValveCoolant = PublicProperties.ValveCoolant == PublicProperties.Valve.Open;
            bool _ValveWater = PublicProperties.ValveWater == PublicProperties.Valve.Open;
            bool ModbusInput = PublicProperties.ModbusInputStatus;
            bool ModbusOutput = PublicProperties.ModbusOutputStatus;

            if (ModbusInput && ModbusOutput)
            {
                if (_ValveCoolant || _ValveWater)
                { Actions.SetIndicator(2); }
                else
                { Actions.SetIndicator(1); }
            }
            else
            { Actions.SetIndicator(3); }
        }

        private void ValveIndicatorReset()
        {
            greendotStatus.Image = loadingStation.Properties.Resources.yellow;
            lblStatus.Text = PublicProperties.Status.Ready.ToString();
        }
        #endregion

        #region ProgressBar : <ProgressSetColor>
        private void ProgressSetColor(ProgressType type, ProgressStatus status)
        {
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
                    if (status == ProgressStatus.Max) { ProgressDrum3.ForeColor = Color.FromArgb(MAX_R, MAX_G, MAX_B); }
                    if (status == ProgressStatus.Mid) { ProgressDrum3.ForeColor = Color.FromArgb(MID_R, MID_G, MID_B); }
                    if (status == ProgressStatus.Min) { ProgressDrum3.ForeColor = Color.FromArgb(MIN_R, MIN_G, MIN_B); }
                    break;

                case ProgressType.Measure:
                    if (status == ProgressStatus.Max) { ProgressDrum2.ForeColor = Color.FromArgb(MAX_R, MAX_G, MAX_B); }
                    if (status == ProgressStatus.Mid) { ProgressDrum2.ForeColor = Color.FromArgb(MID_R, MID_G, MID_B); }
                    if (status == ProgressStatus.Min) { ProgressDrum2.ForeColor = Color.FromArgb(MIN_R, MIN_G, MIN_B); }
                    break;

                case ProgressType.Mixing:
                    if (status == ProgressStatus.Max) { ProgressDrum1.ForeColor = Color.FromArgb(MAX_R, MAX_G, MAX_B); }
                    if (status == ProgressStatus.Mid) { ProgressDrum1.ForeColor = Color.FromArgb(MID_R, MID_G, MID_B); }
                    if (status == ProgressStatus.Min) { ProgressDrum1.ForeColor = Color.FromArgb(MIN_R, MIN_G, MIN_B); }
                    break;
            }
        }
        #endregion

        private void SelectionChanged()
        {
            timerConsumption.Interval = (IndexOfConsumption == 2) ? 150000 : 43200000;
            bgwConsumption.RunWorkerAsync();
            timerConsumption.Stop();
            timerConsumption.Start();
        }
        private void BgworkHistory_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (PublicProperties.DatabaseStatus)
                    {
                        var dtHistory = DB_SFDB.PopulateHistory(typeCoolant);

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
                catch { }
                Thread.Sleep(3000);
            }
        }

        private void TimerFilling_Tick(object sender, EventArgs e)
        {
            try
            {
                // GET Max min value mixing
                const int MaxMixing = 80;
                const int MinMixing = 10;
                const int ThresholdMixing = 30;

                // GET Max min value measure
                const int MaxMeasure = 70;
                const int MinMeasure = 20;
                const int ThresholdMeasure = 40;

                // GET Max min value drum
                const int MaxDrum = 90;
                const int MinDrum = 10;
                const int ThresholdDrum = 30;

                int Mixing = PublicProperties.Value[0];
                int Measure = PublicProperties.Value[1];
                int Coolant = PublicProperties.Value[2];

                ProgressDrum1.Value = Mixing;
                ProgressDrum2.Value = Measure;
                ProgressDrum3.Value = Coolant;

                if (ProgressDrum1.Value > ThresholdMixing)
                { ProgressSetColor(ProgressType.Mixing, ProgressStatus.Max); }

                if (ProgressDrum2.Value > ThresholdMeasure)
                { ProgressSetColor(ProgressType.Measure, ProgressStatus.Max); }

                if (ProgressDrum3.Value > ThresholdDrum)
                { ProgressSetColor(ProgressType.Coolant, ProgressStatus.Max); }

                if (ProgressDrum1.Value <= ThresholdMixing && ProgressDrum1.Value > MinMixing)
                { ProgressSetColor(ProgressType.Mixing, ProgressStatus.Mid); }

                if (ProgressDrum2.Value <= ThresholdMeasure && ProgressDrum2.Value > MinMeasure)
                { ProgressSetColor(ProgressType.Measure, ProgressStatus.Mid); }

                if (ProgressDrum3.Value <= ThresholdDrum && ProgressDrum3.Value > MinDrum)
                { ProgressSetColor(ProgressType.Coolant, ProgressStatus.Mid); }

                if (ProgressDrum1.Value <= MinMixing)
                { ProgressSetColor(ProgressType.Mixing, ProgressStatus.Min); }

                if (ProgressDrum2.Value <= MinMeasure)
                { ProgressSetColor(ProgressType.Measure, ProgressStatus.Min); }

                if (ProgressDrum3.Value <= MinDrum)
                { ProgressSetColor(ProgressType.Coolant, ProgressStatus.Min); }

                string opname = "_";
                if (Tasklist.TableTasklist != null)
                {
                    foreach (DataRow dr in Tasklist.TableTasklist.Rows)
                    {
                        if (dr["status"].ToString() == "FILLING")
                        {
                            if(dr["status"].ToString() != null)
                            {
                                opname = dr["op_name"].ToString();
                                break;
                            }
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
                    using(ActionRestart rs = new ActionRestart())
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
        }

        private void PbChangeDrum_Click(object sender, EventArgs e)
        {
            if (PublicProperties.DatabaseStatus && PublicProperties.ModbusInputStatus && PublicProperties.ModbusOutputStatus)
            {
                using (Login login = new Login())
                {
                    login.ShowDialog();
                    if(login.DialogResult == DialogResult.OK)
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
                MessageBox.Show("Cannot Change Drum While Reconnecting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            using(Smartdevices sd = new Smartdevices())
            {
                sd.ShowDialog();
            }
        }

        private void BtnLsConfig_Click(object sender, EventArgs e)
        {
            using(LSSetting ls = new LSSetting())
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
                if (PublicProperties.DatabaseStatus)
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
