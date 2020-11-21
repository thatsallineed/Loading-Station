namespace loadingStation.GUI.Main
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbWaterTime = new System.Windows.Forms.ComboBox();
            this.cbCoolantTime = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRunningTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblWaterConsumption = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblCoolantConsumption = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblOPName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelNotifyDrum = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bgworkHistory = new System.ComponentModel.BackgroundWorker();
            this.timerFilling = new System.Windows.Forms.Timer(this.components);
            this.timerValve = new System.Windows.Forms.Timer(this.components);
            this.panelMaintenance = new System.Windows.Forms.Panel();
            this.btnAppconfig = new System.Windows.Forms.Button();
            this.panelUnlock = new System.Windows.Forms.Panel();
            this.bgwConsumption = new System.ComponentModel.BackgroundWorker();
            this.timerConsumption = new System.Windows.Forms.Timer(this.components);
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.lblTimelapseValveWater = new System.Windows.Forms.Label();
            this.lblTimelapseValveCoolant = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.btnDrumElapsed = new System.Windows.Forms.Button();
            this.btnFilling = new System.Windows.Forms.Button();
            this.lblPercentageDrum = new System.Windows.Forms.Label();
            this.lblPercentageMixing = new System.Windows.Forms.Label();
            this.pbPropeler = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbChangeDrum = new System.Windows.Forms.PictureBox();
            this.greendotFlow = new System.Windows.Forms.PictureBox();
            this.greendotP2 = new System.Windows.Forms.PictureBox();
            this.greendotT2 = new System.Windows.Forms.PictureBox();
            this.greendotV2 = new System.Windows.Forms.PictureBox();
            this.greendotV1 = new System.Windows.Forms.PictureBox();
            this.greendotCoolant = new System.Windows.Forms.PictureBox();
            this.greendotP1 = new System.Windows.Forms.PictureBox();
            this.greendotStatus = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ProgressDrum1 = new loadingStation.Base.Components.progressvertical();
            this.ProgressDrum3 = new loadingStation.Base.Components.progressvertical();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panelNotifyDrum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPropeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChangeDrum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotCoolant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // cbWaterTime
            // 
            this.cbWaterTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(113)))), ((int)(((byte)(123)))));
            this.cbWaterTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWaterTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbWaterTime.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWaterTime.ForeColor = System.Drawing.Color.White;
            this.cbWaterTime.FormattingEnabled = true;
            this.cbWaterTime.Items.AddRange(new object[] {
            "All Time",
            "Monthly",
            "Today"});
            this.cbWaterTime.Location = new System.Drawing.Point(867, 545);
            this.cbWaterTime.Name = "cbWaterTime";
            this.cbWaterTime.Size = new System.Drawing.Size(89, 22);
            this.cbWaterTime.TabIndex = 45;
            this.cbWaterTime.SelectedIndexChanged += new System.EventHandler(this.CbWaterTime_SelectedIndexChanged);
            // 
            // cbCoolantTime
            // 
            this.cbCoolantTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(113)))), ((int)(((byte)(123)))));
            this.cbCoolantTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoolantTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCoolantTime.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCoolantTime.ForeColor = System.Drawing.Color.White;
            this.cbCoolantTime.FormattingEnabled = true;
            this.cbCoolantTime.Items.AddRange(new object[] {
            "All Time",
            "Monthly",
            "Today"});
            this.cbCoolantTime.Location = new System.Drawing.Point(552, 545);
            this.cbCoolantTime.Name = "cbCoolantTime";
            this.cbCoolantTime.Size = new System.Drawing.Size(89, 22);
            this.cbCoolantTime.TabIndex = 44;
            this.cbCoolantTime.SelectedIndexChanged += new System.EventHandler(this.CbCoolantTime_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lblStatus.Location = new System.Drawing.Point(537, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 19);
            this.lblStatus.TabIndex = 37;
            this.lblStatus.Text = "Filling";
            // 
            // lblRunningTime
            // 
            this.lblRunningTime.AutoSize = true;
            this.lblRunningTime.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lblRunningTime.Location = new System.Drawing.Point(212, 21);
            this.lblRunningTime.Name = "lblRunningTime";
            this.lblRunningTime.Size = new System.Drawing.Size(131, 19);
            this.lblRunningTime.TabIndex = 38;
            this.lblRunningTime.Text = "Running Time :   -";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(25, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 28);
            this.label9.TabIndex = 39;
            this.label9.Text = "Overview";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(627, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 28);
            this.label8.TabIndex = 25;
            this.label8.Text = "History";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.label18.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(204)))), ((int)(((byte)(208)))));
            this.label18.Location = new System.Drawing.Point(705, 571);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 18);
            this.label18.TabIndex = 36;
            this.label18.Text = "Consumption";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.label15.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(204)))), ((int)(((byte)(208)))));
            this.label15.Location = new System.Drawing.Point(385, 571);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 18);
            this.label15.TabIndex = 35;
            this.label15.Text = "Consumption";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.label16.Font = new System.Drawing.Font("SF Pro Display", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(698, 534);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 37);
            this.label16.TabIndex = 33;
            this.label16.Text = "Water";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.label20.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(874, 614);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 31);
            this.label20.TabIndex = 40;
            this.label20.Text = "Liter";
            // 
            // lblWaterConsumption
            // 
            this.lblWaterConsumption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.lblWaterConsumption.Font = new System.Drawing.Font("SF Pro Display", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterConsumption.ForeColor = System.Drawing.Color.White;
            this.lblWaterConsumption.Location = new System.Drawing.Point(691, 601);
            this.lblWaterConsumption.Name = "lblWaterConsumption";
            this.lblWaterConsumption.Size = new System.Drawing.Size(191, 51);
            this.lblWaterConsumption.TabIndex = 32;
            this.lblWaterConsumption.Text = "120.000";
            this.lblWaterConsumption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.label19.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(554, 616);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 31);
            this.label19.TabIndex = 31;
            this.label19.Text = "Liter";
            // 
            // lblCoolantConsumption
            // 
            this.lblCoolantConsumption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.lblCoolantConsumption.Font = new System.Drawing.Font("SF Pro Display", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoolantConsumption.ForeColor = System.Drawing.Color.White;
            this.lblCoolantConsumption.Location = new System.Drawing.Point(371, 603);
            this.lblCoolantConsumption.Name = "lblCoolantConsumption";
            this.lblCoolantConsumption.Size = new System.Drawing.Size(191, 51);
            this.lblCoolantConsumption.TabIndex = 30;
            this.lblCoolantConsumption.Text = "120.000";
            this.lblCoolantConsumption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.label13.Font = new System.Drawing.Font("SF Pro Display", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(378, 534);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 37);
            this.label13.TabIndex = 29;
            this.label13.Text = "Coolant";
            // 
            // lblOPName
            // 
            this.lblOPName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.lblOPName.Font = new System.Drawing.Font("SF Pro Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOPName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblOPName.Location = new System.Drawing.Point(63, 581);
            this.lblOPName.Name = "lblOPName";
            this.lblOPName.Size = new System.Drawing.Size(217, 76);
            this.lblOPName.TabIndex = 28;
            this.lblOPName.Text = "_";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.label10.Font = new System.Drawing.Font("SF Pro Display", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(62, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 37);
            this.label10.TabIndex = 27;
            this.label10.Text = "Filling to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 28);
            this.label4.TabIndex = 26;
            this.label4.Text = "Loading Station";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvHistory.ColumnHeadersHeight = 35;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.dgvType,
            this.NRP,
            this.dgvDatetime});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.dgvHistory.Location = new System.Drawing.Point(622, 48);
            this.dgvHistory.Name = "dgvHistory";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.Size = new System.Drawing.Size(382, 397);
            this.dgvHistory.TabIndex = 46;
            // 
            // No
            // 
            this.No.FillWeight = 79.18782F;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // dgvType
            // 
            this.dgvType.HeaderText = "Type";
            this.dgvType.Name = "dgvType";
            this.dgvType.ReadOnly = true;
            this.dgvType.Visible = false;
            // 
            // NRP
            // 
            this.NRP.FillWeight = 120F;
            this.NRP.HeaderText = "NRP";
            this.NRP.Name = "NRP";
            this.NRP.ReadOnly = true;
            // 
            // dgvDatetime
            // 
            this.dgvDatetime.FillWeight = 160F;
            this.dgvDatetime.HeaderText = "Datetime";
            this.dgvDatetime.Name = "dgvDatetime";
            this.dgvDatetime.ReadOnly = true;
            // 
            // panelNotifyDrum
            // 
            this.panelNotifyDrum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.panelNotifyDrum.Controls.Add(this.label1);
            this.panelNotifyDrum.Controls.Add(this.label7);
            this.panelNotifyDrum.Controls.Add(this.pictureBox1);
            this.panelNotifyDrum.Location = new System.Drawing.Point(69, 190);
            this.panelNotifyDrum.Name = "panelNotifyDrum";
            this.panelNotifyDrum.Size = new System.Drawing.Size(111, 172);
            this.panelNotifyDrum.TabIndex = 111;
            this.panelNotifyDrum.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Drum First";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.label7.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Please Change";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::loadingStation.Properties.Resources.exclamation_mark;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(15, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 79);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bgworkHistory
            // 
            this.bgworkHistory.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgworkHistory_DoWork);
            // 
            // timerFilling
            // 
            this.timerFilling.Tick += new System.EventHandler(this.TimerFilling_Tick);
            // 
            // timerValve
            // 
            this.timerValve.Interval = 500;
            this.timerValve.Tick += new System.EventHandler(this.TimerValve_Tick);
            // 
            // panelMaintenance
            // 
            this.panelMaintenance.Controls.Add(this.btnAppconfig);
            this.panelMaintenance.Location = new System.Drawing.Point(216, 451);
            this.panelMaintenance.Name = "panelMaintenance";
            this.panelMaintenance.Size = new System.Drawing.Size(386, 37);
            this.panelMaintenance.TabIndex = 115;
            // 
            // btnAppconfig
            // 
            this.btnAppconfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.btnAppconfig.FlatAppearance.BorderSize = 0;
            this.btnAppconfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppconfig.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppconfig.ForeColor = System.Drawing.Color.White;
            this.btnAppconfig.Location = new System.Drawing.Point(241, 1);
            this.btnAppconfig.Name = "btnAppconfig";
            this.btnAppconfig.Size = new System.Drawing.Size(142, 36);
            this.btnAppconfig.TabIndex = 9;
            this.btnAppconfig.Text = "Application Settings";
            this.btnAppconfig.UseVisualStyleBackColor = false;
            this.btnAppconfig.Click += new System.EventHandler(this.BtnAppconfig_Click);
            // 
            // panelUnlock
            // 
            this.panelUnlock.Location = new System.Drawing.Point(907, 6);
            this.panelUnlock.Name = "panelUnlock";
            this.panelUnlock.Size = new System.Drawing.Size(97, 36);
            this.panelUnlock.TabIndex = 116;
            this.panelUnlock.Click += new System.EventHandler(this.PanelUnlock_Click);
            // 
            // bgwConsumption
            // 
            this.bgwConsumption.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwConsumption_DoWork);
            this.bgwConsumption.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwConsumption_RunWorkerCompleted);
            // 
            // timerConsumption
            // 
            this.timerConsumption.Interval = 150000;
            this.timerConsumption.Tick += new System.EventHandler(this.TimerConsumption_Tick);
            // 
            // lblStatus2
            // 
            this.lblStatus2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(79)))), ((int)(((byte)(92)))));
            this.lblStatus2.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus2.ForeColor = System.Drawing.Color.White;
            this.lblStatus2.Location = new System.Drawing.Point(20, 411);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(581, 34);
            this.lblStatus2.TabIndex = 117;
            this.lblStatus2.Text = "Ready";
            this.lblStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimelapseValveWater
            // 
            this.lblTimelapseValveWater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.lblTimelapseValveWater.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimelapseValveWater.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lblTimelapseValveWater.Location = new System.Drawing.Point(319, 128);
            this.lblTimelapseValveWater.Name = "lblTimelapseValveWater";
            this.lblTimelapseValveWater.Size = new System.Drawing.Size(119, 19);
            this.lblTimelapseValveWater.TabIndex = 118;
            this.lblTimelapseValveWater.Text = "00:00:00";
            this.lblTimelapseValveWater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimelapseValveCoolant
            // 
            this.lblTimelapseValveCoolant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.lblTimelapseValveCoolant.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimelapseValveCoolant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lblTimelapseValveCoolant.Location = new System.Drawing.Point(258, 297);
            this.lblTimelapseValveCoolant.Name = "lblTimelapseValveCoolant";
            this.lblTimelapseValveCoolant.Size = new System.Drawing.Size(102, 19);
            this.lblTimelapseValveCoolant.TabIndex = 119;
            this.lblTimelapseValveCoolant.Text = "00:00:00";
            this.lblTimelapseValveCoolant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.lblTimeElapsed.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimeElapsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lblTimeElapsed.Location = new System.Drawing.Point(49, 384);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(303, 19);
            this.lblTimeElapsed.TabIndex = 120;
            this.lblTimeElapsed.Text = "-";
            this.lblTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDrumElapsed
            // 
            this.btnDrumElapsed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.btnDrumElapsed.FlatAppearance.BorderSize = 0;
            this.btnDrumElapsed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrumElapsed.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrumElapsed.ForeColor = System.Drawing.Color.White;
            this.btnDrumElapsed.Location = new System.Drawing.Point(846, 451);
            this.btnDrumElapsed.Name = "btnDrumElapsed";
            this.btnDrumElapsed.Size = new System.Drawing.Size(157, 37);
            this.btnDrumElapsed.TabIndex = 121;
            this.btnDrumElapsed.Text = "Drum Countdown Setting";
            this.btnDrumElapsed.UseVisualStyleBackColor = false;
            this.btnDrumElapsed.Click += new System.EventHandler(this.BtnDrumElapsed_Click);
            // 
            // btnFilling
            // 
            this.btnFilling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.btnFilling.FlatAppearance.BorderSize = 0;
            this.btnFilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilling.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilling.ForeColor = System.Drawing.Color.White;
            this.btnFilling.Location = new System.Drawing.Point(740, 451);
            this.btnFilling.Name = "btnFilling";
            this.btnFilling.Size = new System.Drawing.Size(100, 37);
            this.btnFilling.TabIndex = 122;
            this.btnFilling.Text = "Filling Details";
            this.btnFilling.UseVisualStyleBackColor = false;
            this.btnFilling.Click += new System.EventHandler(this.btnFilling_Click);
            // 
            // lblPercentageDrum
            // 
            this.lblPercentageDrum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.lblPercentageDrum.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentageDrum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lblPercentageDrum.Location = new System.Drawing.Point(192, 325);
            this.lblPercentageDrum.Name = "lblPercentageDrum";
            this.lblPercentageDrum.Size = new System.Drawing.Size(50, 19);
            this.lblPercentageDrum.TabIndex = 123;
            this.lblPercentageDrum.Text = "0%";
            this.lblPercentageDrum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPercentageMixing
            // 
            this.lblPercentageMixing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.lblPercentageMixing.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentageMixing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.lblPercentageMixing.Location = new System.Drawing.Point(449, 257);
            this.lblPercentageMixing.Name = "lblPercentageMixing";
            this.lblPercentageMixing.Size = new System.Drawing.Size(50, 19);
            this.lblPercentageMixing.TabIndex = 124;
            this.lblPercentageMixing.Text = "0%";
            this.lblPercentageMixing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPropeler
            // 
            this.pbPropeler.Image = global::loadingStation.Properties.Resources.creopped;
            this.pbPropeler.Location = new System.Drawing.Point(380, 333);
            this.pbPropeler.Name = "pbPropeler";
            this.pbPropeler.Size = new System.Drawing.Size(58, 30);
            this.pbPropeler.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPropeler.TabIndex = 47;
            this.pbPropeler.TabStop = false;
            // 
            // pictureBox22
            // 
            this.pictureBox22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox22.Image = global::loadingStation.Properties.Resources.botRight;
            this.pictureBox22.Location = new System.Drawing.Point(996, 420);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(8, 8);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox22.TabIndex = 5;
            this.pictureBox22.TabStop = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox21.Image = global::loadingStation.Properties.Resources.botLeft;
            this.pictureBox21.Location = new System.Drawing.Point(622, 420);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(8, 8);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox21.TabIndex = 20;
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox20.Image = global::loadingStation.Properties.Resources.topRight;
            this.pictureBox20.Location = new System.Drawing.Point(996, 61);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(8, 8);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox20.TabIndex = 21;
            this.pictureBox20.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox4.Image = global::loadingStation.Properties.Resources.topLeft1;
            this.pictureBox4.Location = new System.Drawing.Point(622, 48);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(8, 8);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 22;
            this.pictureBox4.TabStop = false;
            // 
            // pbChangeDrum
            // 
            this.pbChangeDrum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pbChangeDrum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbChangeDrum.Image = global::loadingStation.Properties.Resources.newDrum;
            this.pbChangeDrum.Location = new System.Drawing.Point(466, 77);
            this.pbChangeDrum.Name = "pbChangeDrum";
            this.pbChangeDrum.Size = new System.Drawing.Size(106, 106);
            this.pbChangeDrum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbChangeDrum.TabIndex = 23;
            this.pbChangeDrum.TabStop = false;
            this.pbChangeDrum.Click += new System.EventHandler(this.PbChangeDrum_Click);
            // 
            // greendotFlow
            // 
            this.greendotFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.greendotFlow.Image = global::loadingStation.Properties.Resources.yellow;
            this.greendotFlow.Location = new System.Drawing.Point(513, 298);
            this.greendotFlow.Name = "greendotFlow";
            this.greendotFlow.Size = new System.Drawing.Size(12, 12);
            this.greendotFlow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.greendotFlow.TabIndex = 24;
            this.greendotFlow.TabStop = false;
            // 
            // greendotP2
            // 
            this.greendotP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.greendotP2.Image = global::loadingStation.Properties.Resources.yellow;
            this.greendotP2.Location = new System.Drawing.Point(455, 298);
            this.greendotP2.Name = "greendotP2";
            this.greendotP2.Size = new System.Drawing.Size(12, 12);
            this.greendotP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.greendotP2.TabIndex = 18;
            this.greendotP2.TabStop = false;
            // 
            // greendotT2
            // 
            this.greendotT2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.greendotT2.Image = global::loadingStation.Properties.Resources.yellow;
            this.greendotT2.Location = new System.Drawing.Point(356, 225);
            this.greendotT2.Name = "greendotT2";
            this.greendotT2.Size = new System.Drawing.Size(12, 12);
            this.greendotT2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.greendotT2.TabIndex = 17;
            this.greendotT2.TabStop = false;
            // 
            // greendotV2
            // 
            this.greendotV2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.greendotV2.Image = global::loadingStation.Properties.Resources.yellow;
            this.greendotV2.Location = new System.Drawing.Point(352, 150);
            this.greendotV2.Name = "greendotV2";
            this.greendotV2.Size = new System.Drawing.Size(12, 12);
            this.greendotV2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.greendotV2.TabIndex = 16;
            this.greendotV2.TabStop = false;
            // 
            // greendotV1
            // 
            this.greendotV1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.greendotV1.Image = global::loadingStation.Properties.Resources.yellow;
            this.greendotV1.Location = new System.Drawing.Point(278, 247);
            this.greendotV1.Name = "greendotV1";
            this.greendotV1.Size = new System.Drawing.Size(12, 12);
            this.greendotV1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.greendotV1.TabIndex = 15;
            this.greendotV1.TabStop = false;
            // 
            // greendotCoolant
            // 
            this.greendotCoolant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.greendotCoolant.Image = global::loadingStation.Properties.Resources.yellow;
            this.greendotCoolant.Location = new System.Drawing.Point(31, 153);
            this.greendotCoolant.Name = "greendotCoolant";
            this.greendotCoolant.Size = new System.Drawing.Size(12, 12);
            this.greendotCoolant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.greendotCoolant.TabIndex = 19;
            this.greendotCoolant.TabStop = false;
            // 
            // greendotP1
            // 
            this.greendotP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.greendotP1.Image = global::loadingStation.Properties.Resources.yellow;
            this.greendotP1.Location = new System.Drawing.Point(154, 107);
            this.greendotP1.Name = "greendotP1";
            this.greendotP1.Size = new System.Drawing.Size(12, 12);
            this.greendotP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.greendotP1.TabIndex = 12;
            this.greendotP1.TabStop = false;
            // 
            // greendotStatus
            // 
            this.greendotStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.greendotStatus.Image = global::loadingStation.Properties.Resources.yellow;
            this.greendotStatus.Location = new System.Drawing.Point(519, 25);
            this.greendotStatus.Name = "greendotStatus";
            this.greendotStatus.Size = new System.Drawing.Size(12, 12);
            this.greendotStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.greendotStatus.TabIndex = 11;
            this.greendotStatus.TabStop = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox18.Image = global::loadingStation.Properties.Resources.overviewInner;
            this.pictureBox18.Location = new System.Drawing.Point(679, 527);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(297, 136);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox18.TabIndex = 10;
            this.pictureBox18.TabStop = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox17.Image = global::loadingStation.Properties.Resources.overviewInner;
            this.pictureBox17.Location = new System.Drawing.Point(363, 527);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(297, 136);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox17.TabIndex = 9;
            this.pictureBox17.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox16.Image = global::loadingStation.Properties.Resources.overviewInner;
            this.pictureBox16.Location = new System.Drawing.Point(46, 527);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(297, 136);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox16.TabIndex = 8;
            this.pictureBox16.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::loadingStation.Properties.Resources.overview;
            this.pictureBox5.Location = new System.Drawing.Point(20, 494);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(983, 202);
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox6.Image = global::loadingStation.Properties.Resources.diagramillustration2;
            this.pictureBox6.Location = new System.Drawing.Point(48, 97);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(524, 282);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox3.Image = global::loadingStation.Properties.Resources.diagram1;
            this.pictureBox3.Location = new System.Drawing.Point(20, 48);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(581, 397);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // ProgressDrum1
            // 
            this.ProgressDrum1.Location = new System.Drawing.Point(380, 246);
            this.ProgressDrum1.Name = "ProgressDrum1";
            this.ProgressDrum1.Size = new System.Drawing.Size(58, 96);
            this.ProgressDrum1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressDrum1.TabIndex = 114;
            // 
            // ProgressDrum3
            // 
            this.ProgressDrum3.Location = new System.Drawing.Point(69, 190);
            this.ProgressDrum3.Name = "ProgressDrum3";
            this.ProgressDrum3.Size = new System.Drawing.Size(111, 172);
            this.ProgressDrum3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressDrum3.TabIndex = 112;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1024, 708);
            this.Controls.Add(this.ProgressDrum1);
            this.Controls.Add(this.pbPropeler);
            this.Controls.Add(this.lblPercentageMixing);
            this.Controls.Add(this.lblPercentageDrum);
            this.Controls.Add(this.btnFilling);
            this.Controls.Add(this.btnDrumElapsed);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.lblTimelapseValveCoolant);
            this.Controls.Add(this.lblTimelapseValveWater);
            this.Controls.Add(this.lblStatus2);
            this.Controls.Add(this.panelUnlock);
            this.Controls.Add(this.panelMaintenance);
            this.Controls.Add(this.panelNotifyDrum);
            this.Controls.Add(this.ProgressDrum3);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.cbWaterTime);
            this.Controls.Add(this.pbChangeDrum);
            this.Controls.Add(this.cbCoolantTime);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRunningTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.greendotFlow);
            this.Controls.Add(this.greendotP2);
            this.Controls.Add(this.greendotT2);
            this.Controls.Add(this.greendotV2);
            this.Controls.Add(this.greendotV1);
            this.Controls.Add(this.greendotCoolant);
            this.Controls.Add(this.greendotP1);
            this.Controls.Add(this.greendotStatus);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblWaterConsumption);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblCoolantConsumption);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblOPName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.dgvHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panelNotifyDrum.ResumeLayout(false);
            this.panelNotifyDrum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMaintenance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPropeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChangeDrum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotCoolant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greendotStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ComboBox cbWaterTime;
        private System.Windows.Forms.PictureBox pbChangeDrum;
        private System.Windows.Forms.ComboBox cbCoolantTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRunningTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox greendotFlow;
        private System.Windows.Forms.PictureBox greendotP2;
        private System.Windows.Forms.PictureBox greendotT2;
        private System.Windows.Forms.PictureBox greendotV2;
        private System.Windows.Forms.PictureBox greendotV1;
        private System.Windows.Forms.PictureBox greendotCoolant;
        private System.Windows.Forms.PictureBox greendotP1;
        private System.Windows.Forms.PictureBox greendotStatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblWaterConsumption;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblCoolantConsumption;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblOPName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.PictureBox pbPropeler;
        private System.Windows.Forms.Panel panelNotifyDrum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker bgworkHistory;
        private System.Windows.Forms.Timer timerFilling;
        private System.Windows.Forms.Timer timerValve;
        private Base.Components.progressvertical ProgressDrum3;
        private Base.Components.progressvertical ProgressDrum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvType;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDatetime;
        private System.Windows.Forms.Panel panelMaintenance;
        private System.Windows.Forms.Button btnAppconfig;
        private System.Windows.Forms.Panel panelUnlock;
        private System.ComponentModel.BackgroundWorker bgwConsumption;
        private System.Windows.Forms.Timer timerConsumption;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.Label lblTimelapseValveWater;
        private System.Windows.Forms.Label lblTimelapseValveCoolant;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.Button btnDrumElapsed;
        private System.Windows.Forms.Button btnFilling;
        private System.Windows.Forms.Label lblPercentageDrum;
        private System.Windows.Forms.Label lblPercentageMixing;
    }
}