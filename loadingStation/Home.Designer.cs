namespace loadingStation
{
    partial class Home
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSecond = new System.Windows.Forms.Label();
            this.panelMenu1 = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.dotDashboard = new System.Windows.Forms.PictureBox();
            this.lblCoolantType = new System.Windows.Forms.Label();
            this.panelNotification = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelMenu3 = new System.Windows.Forms.Panel();
            this.dotPreferences = new System.Windows.Forms.PictureBox();
            this.pbPreferences = new System.Windows.Forms.PictureBox();
            this.panelMenu2 = new System.Windows.Forms.Panel();
            this.dotTasklist = new System.Windows.Forms.PictureBox();
            this.lblTasklist = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelForm = new System.Windows.Forms.Panel();
            this.timerErrorLogCollector = new System.Windows.Forms.Timer(this.components);
            this.bgwMaintenance = new System.ComponentModel.BackgroundWorker();
            this.panelDebug = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerMT = new System.Windows.Forms.Timer(this.components);
            this.panelHeader.SuspendLayout();
            this.panelMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotDashboard)).BeginInit();
            this.panelNotification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelMenu3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotPreferences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreferences)).BeginInit();
            this.panelMenu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotTasklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(77)))), ((int)(((byte)(75)))));
            this.panelHeader.Controls.Add(this.lblSecond);
            this.panelHeader.Controls.Add(this.panelMenu1);
            this.panelHeader.Controls.Add(this.lblCoolantType);
            this.panelHeader.Controls.Add(this.panelNotification);
            this.panelHeader.Controls.Add(this.panelMenu3);
            this.panelHeader.Controls.Add(this.panelMenu2);
            this.panelHeader.Controls.Add(this.lblTime);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1024, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecond.ForeColor = System.Drawing.Color.White;
            this.lblSecond.Location = new System.Drawing.Point(927, 10);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(27, 19);
            this.lblSecond.TabIndex = 1;
            this.lblSecond.Text = "15";
            // 
            // panelMenu1
            // 
            this.panelMenu1.Controls.Add(this.lblDashboard);
            this.panelMenu1.Controls.Add(this.dotDashboard);
            this.panelMenu1.Location = new System.Drawing.Point(602, 3);
            this.panelMenu1.Name = "panelMenu1";
            this.panelMenu1.Size = new System.Drawing.Size(99, 57);
            this.panelMenu1.TabIndex = 0;
            this.panelMenu1.Click += new System.EventHandler(this.PanelMenu1_Click);
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(6, 14);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(90, 19);
            this.lblDashboard.TabIndex = 1;
            this.lblDashboard.Text = "Dashboard";
            this.lblDashboard.Click += new System.EventHandler(this.LblDashboard_Click);
            // 
            // dotDashboard
            // 
            this.dotDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.dotDashboard.Image = global::loadingStation.Properties.Resources.nav;
            this.dotDashboard.Location = new System.Drawing.Point(50, 39);
            this.dotDashboard.Name = "dotDashboard";
            this.dotDashboard.Size = new System.Drawing.Size(8, 8);
            this.dotDashboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dotDashboard.TabIndex = 0;
            this.dotDashboard.TabStop = false;
            // 
            // lblCoolantType
            // 
            this.lblCoolantType.BackColor = System.Drawing.Color.White;
            this.lblCoolantType.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCoolantType.Font = new System.Drawing.Font("SF Pro Display", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoolantType.ForeColor = System.Drawing.Color.Black;
            this.lblCoolantType.Location = new System.Drawing.Point(972, 0);
            this.lblCoolantType.Name = "lblCoolantType";
            this.lblCoolantType.Size = new System.Drawing.Size(52, 60);
            this.lblCoolantType.TabIndex = 118;
            this.lblCoolantType.Text = "X";
            // 
            // panelNotification
            // 
            this.panelNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(77)))), ((int)(((byte)(75)))));
            this.panelNotification.Controls.Add(this.label2);
            this.panelNotification.Controls.Add(this.label1);
            this.panelNotification.Controls.Add(this.pictureBox2);
            this.panelNotification.Location = new System.Drawing.Point(0, 0);
            this.panelNotification.Name = "panelNotification";
            this.panelNotification.Size = new System.Drawing.Size(581, 60);
            this.panelNotification.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(68, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Smartdevice or Database Disconnected. Reconnecting...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(68, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Warning";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::loadingStation.Properties.Resources.Spinner_1s_64px;
            this.pictureBox2.Location = new System.Drawing.Point(12, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelMenu3
            // 
            this.panelMenu3.Controls.Add(this.dotPreferences);
            this.panelMenu3.Controls.Add(this.pbPreferences);
            this.panelMenu3.Location = new System.Drawing.Point(800, 3);
            this.panelMenu3.Name = "panelMenu3";
            this.panelMenu3.Size = new System.Drawing.Size(35, 57);
            this.panelMenu3.TabIndex = 0;
            this.panelMenu3.Visible = false;
            this.panelMenu3.Click += new System.EventHandler(this.PanelMenu3_Click);
            // 
            // dotPreferences
            // 
            this.dotPreferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.dotPreferences.Image = global::loadingStation.Properties.Resources.nav;
            this.dotPreferences.Location = new System.Drawing.Point(13, 35);
            this.dotPreferences.Name = "dotPreferences";
            this.dotPreferences.Size = new System.Drawing.Size(8, 8);
            this.dotPreferences.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dotPreferences.TabIndex = 3;
            this.dotPreferences.TabStop = false;
            // 
            // pbPreferences
            // 
            this.pbPreferences.Image = global::loadingStation.Properties.Resources.preferences1;
            this.pbPreferences.Location = new System.Drawing.Point(9, 15);
            this.pbPreferences.Name = "pbPreferences";
            this.pbPreferences.Size = new System.Drawing.Size(15, 15);
            this.pbPreferences.TabIndex = 0;
            this.pbPreferences.TabStop = false;
            this.pbPreferences.Click += new System.EventHandler(this.PbPreferences_Click);
            // 
            // panelMenu2
            // 
            this.panelMenu2.Controls.Add(this.dotTasklist);
            this.panelMenu2.Controls.Add(this.lblTasklist);
            this.panelMenu2.Location = new System.Drawing.Point(707, 3);
            this.panelMenu2.Name = "panelMenu2";
            this.panelMenu2.Size = new System.Drawing.Size(87, 57);
            this.panelMenu2.TabIndex = 1;
            this.panelMenu2.Click += new System.EventHandler(this.PanelMenu2_Click);
            // 
            // dotTasklist
            // 
            this.dotTasklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.dotTasklist.Image = global::loadingStation.Properties.Resources.nav;
            this.dotTasklist.Location = new System.Drawing.Point(44, 37);
            this.dotTasklist.Name = "dotTasklist";
            this.dotTasklist.Size = new System.Drawing.Size(8, 8);
            this.dotTasklist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dotTasklist.TabIndex = 2;
            this.dotTasklist.TabStop = false;
            // 
            // lblTasklist
            // 
            this.lblTasklist.AutoSize = true;
            this.lblTasklist.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(170)))), ((int)(((byte)(177)))));
            this.lblTasklist.Location = new System.Drawing.Point(8, 14);
            this.lblTasklist.Name = "lblTasklist";
            this.lblTasklist.Size = new System.Drawing.Size(73, 19);
            this.lblTasklist.TabIndex = 1;
            this.lblTasklist.Text = "Task List";
            this.lblTasklist.Click += new System.EventHandler(this.LblTasklist_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("SF Pro Display", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(850, 13);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(79, 29);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "14:30";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::loadingStation.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(26, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(365, 30);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelForm
            // 
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 60);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(1024, 681);
            this.panelForm.TabIndex = 1;
            // 
            // timerErrorLogCollector
            // 
            this.timerErrorLogCollector.Tick += new System.EventHandler(this.TimerErrorLogCollector_Tick);
            // 
            // bgwMaintenance
            // 
            this.bgwMaintenance.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwMaintenance_DoWork);
            this.bgwMaintenance.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwMaintenance_RunWorkerCompleted);
            // 
            // panelDebug
            // 
            this.panelDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(77)))), ((int)(((byte)(75)))));
            this.panelDebug.Controls.Add(this.label4);
            this.panelDebug.Controls.Add(this.label3);
            this.panelDebug.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDebug.Location = new System.Drawing.Point(0, 741);
            this.panelDebug.Name = "panelDebug";
            this.panelDebug.Size = new System.Drawing.Size(1024, 27);
            this.panelDebug.TabIndex = 2;
            this.panelDebug.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(375, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(346, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Application Entered Debug Mode, Some Function Will Disabled\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(316, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Warning : ";
            // 
            // timerMT
            // 
            this.timerMT.Interval = 5000;
            this.timerMT.Tick += new System.EventHandler(this.TimerMT_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panelDebug);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMenu1.ResumeLayout(false);
            this.panelMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotDashboard)).EndInit();
            this.panelNotification.ResumeLayout(false);
            this.panelNotification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelMenu3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dotPreferences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreferences)).EndInit();
            this.panelMenu2.ResumeLayout(false);
            this.panelMenu2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotTasklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDebug.ResumeLayout(false);
            this.panelDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox pbPreferences;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblTasklist;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.PictureBox dotDashboard;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Timer timerErrorLogCollector;
        private System.Windows.Forms.Panel panelNotification;
        private System.Windows.Forms.Panel panelMenu2;
        private System.Windows.Forms.PictureBox dotTasklist;
        private System.Windows.Forms.Panel panelMenu1;
        private System.Windows.Forms.Panel panelMenu3;
        private System.ComponentModel.BackgroundWorker bgwMaintenance;
        private System.Windows.Forms.PictureBox dotPreferences;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDebug;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCoolantType;
        private System.Windows.Forms.Timer timerMT;
    }
}

