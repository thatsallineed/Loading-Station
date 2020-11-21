namespace loadingStation.Miniform
{
    partial class Changedrum
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
            this.label4 = new System.Windows.Forms.Label();
            this.lblStepCount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.bgwSubmit = new System.ComponentModel.BackgroundWorker();
            this.panelNotification = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbPrevious = new System.Windows.Forms.PictureBox();
            this.pbStep = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelDetection = new System.Windows.Forms.Panel();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelNotification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelDetection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(19, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Change Coolant Drum";
            // 
            // lblStepCount
            // 
            this.lblStepCount.Font = new System.Drawing.Font("SF Pro Display", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblStepCount.Location = new System.Drawing.Point(150, 544);
            this.lblStepCount.Name = "lblStepCount";
            this.lblStepCount.Size = new System.Drawing.Size(326, 58);
            this.lblStepCount.TabIndex = 7;
            this.lblStepCount.Text = "1 / 14";
            this.lblStepCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("SF Pro Display", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblDescription.Location = new System.Drawing.Point(158, 489);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(318, 55);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Close Water Valve System";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgwSubmit
            // 
            this.bgwSubmit.WorkerReportsProgress = true;
            this.bgwSubmit.WorkerSupportsCancellation = true;
            this.bgwSubmit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwSubmit_DoWork);
            this.bgwSubmit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwSubmit_RunWorkerCompleted);
            // 
            // panelNotification
            // 
            this.panelNotification.BackColor = System.Drawing.Color.Black;
            this.panelNotification.Controls.Add(this.btnCancel);
            this.panelNotification.Controls.Add(this.label2);
            this.panelNotification.Controls.Add(this.label1);
            this.panelNotification.Controls.Add(this.pictureBox2);
            this.panelNotification.Location = new System.Drawing.Point(-1, 0);
            this.panelNotification.Name = "panelNotification";
            this.panelNotification.Size = new System.Drawing.Size(628, 64);
            this.panelNotification.TabIndex = 9;
            this.panelNotification.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(515, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(68, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Submitting Task, Please Wait ...\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(68, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proccessing";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(514, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 35);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::loadingStation.Properties.Resources.Disk_1_1s_54px;
            this.pictureBox2.Location = new System.Drawing.Point(12, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pbNext
            // 
            this.pbNext.Image = global::loadingStation.Properties.Resources.NEXT;
            this.pbNext.Location = new System.Drawing.Point(491, 489);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(114, 113);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 2;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.PbNext_Click);
            // 
            // pbPrevious
            // 
            this.pbPrevious.Image = global::loadingStation.Properties.Resources.PREV;
            this.pbPrevious.Location = new System.Drawing.Point(17, 489);
            this.pbPrevious.Name = "pbPrevious";
            this.pbPrevious.Size = new System.Drawing.Size(114, 113);
            this.pbPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrevious.TabIndex = 3;
            this.pbPrevious.TabStop = false;
            this.pbPrevious.Visible = false;
            this.pbPrevious.Click += new System.EventHandler(this.PbPrevious_Click);
            this.pbPrevious.Paint += new System.Windows.Forms.PaintEventHandler(this.PbPrevious_Paint);
            // 
            // pbStep
            // 
            this.pbStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.pbStep.Image = global::loadingStation.Properties.Resources.CD_1;
            this.pbStep.Location = new System.Drawing.Point(19, 81);
            this.pbStep.Name = "pbStep";
            this.pbStep.Size = new System.Drawing.Size(579, 379);
            this.pbStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStep.TabIndex = 4;
            this.pbStep.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::loadingStation.Properties.Resources.drumInner;
            this.pictureBox3.Location = new System.Drawing.Point(12, 70);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(593, 401);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // panelDetection
            // 
            this.panelDetection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(92)))), ((int)(((byte)(104)))));
            this.panelDetection.Controls.Add(this.label3);
            this.panelDetection.Controls.Add(this.pbStatus);
            this.panelDetection.Location = new System.Drawing.Point(33, 98);
            this.panelDetection.Name = "panelDetection";
            this.panelDetection.Size = new System.Drawing.Size(130, 45);
            this.panelDetection.TabIndex = 13;
            // 
            // pbStatus
            // 
            this.pbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(33)))), ((int)(((byte)(50)))));
            this.pbStatus.Image = global::loadingStation.Properties.Resources.yellow;
            this.pbStatus.Location = new System.Drawing.Point(100, 15);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(12, 12);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStatus.TabIndex = 12;
            this.pbStatus.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "Status";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Changedrum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 625);
            this.Controls.Add(this.panelDetection);
            this.Controls.Add(this.panelNotification);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStepCount);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrevious);
            this.Controls.Add(this.pbStep);
            this.Controls.Add(this.pictureBox3);
            this.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Changedrum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Change Drum";
            this.TopMost = true;
            this.panelNotification.ResumeLayout(false);
            this.panelNotification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelDetection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStepCount;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.PictureBox pbPrevious;
        private System.Windows.Forms.PictureBox pbStep;
        private System.Windows.Forms.Label lblDescription;
        private System.ComponentModel.BackgroundWorker bgwSubmit;
        private System.Windows.Forms.Panel panelNotification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelDetection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbStatus;
    }
}