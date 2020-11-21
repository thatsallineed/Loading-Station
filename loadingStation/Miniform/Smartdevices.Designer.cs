namespace loadingStation.Miniform
{
    partial class Smartdevices
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnCancel = new loadingStation.Core.Components.RoundButtons();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSmartIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.listInput = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listOutput = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnValidation = new loadingStation.Core.Components.RoundButtons();
            this.txtBitvalue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timerBit = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblStatus.Location = new System.Drawing.Point(363, 58);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(367, 16);
            this.lblStatus.TabIndex = 32;
            this.lblStatus.Text = "-";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("SF Pro Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.White;
            this.lblCount.Location = new System.Drawing.Point(359, 33);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(371, 24);
            this.lblCount.TabIndex = 31;
            this.lblCount.Text = "-";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(650, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 48);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtStatus.Location = new System.Drawing.Point(449, 209);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(281, 23);
            this.txtStatus.TabIndex = 28;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(356, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Status    : ";
            // 
            // txtSmartIp
            // 
            this.txtSmartIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtSmartIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSmartIp.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSmartIp.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtSmartIp.Location = new System.Drawing.Point(449, 183);
            this.txtSmartIp.Name = "txtSmartIp";
            this.txtSmartIp.ReadOnly = true;
            this.txtSmartIp.Size = new System.Drawing.Size(281, 23);
            this.txtSmartIp.TabIndex = 26;
            this.txtSmartIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(356, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "SmartIP : ";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("SF Pro Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.ForeColor = System.Drawing.Color.White;
            this.lblSelected.Location = new System.Drawing.Point(355, 144);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(105, 24);
            this.lblSelected.TabIndex = 24;
            this.lblSelected.Text = "Select List";
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("SF Pro Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(28, 26);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(113, 33);
            this.lblDashboard.TabIndex = 21;
            this.lblDashboard.Text = "Devices";
            // 
            // listInput
            // 
            this.listInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.listInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listInput.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listInput.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.listInput.FormattingEnabled = true;
            this.listInput.ItemHeight = 15;
            this.listInput.Location = new System.Drawing.Point(33, 117);
            this.listInput.Margin = new System.Windows.Forms.Padding(12);
            this.listInput.Name = "listInput";
            this.listInput.Size = new System.Drawing.Size(143, 152);
            this.listInput.TabIndex = 23;
            this.listInput.SelectedIndexChanged += new System.EventHandler(this.ListInput_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Watcher";
            // 
            // listOutput
            // 
            this.listOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.listOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listOutput.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOutput.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.listOutput.FormattingEnabled = true;
            this.listOutput.ItemHeight = 15;
            this.listOutput.Location = new System.Drawing.Point(188, 117);
            this.listOutput.Margin = new System.Windows.Forms.Padding(12);
            this.listOutput.Name = "listOutput";
            this.listOutput.Size = new System.Drawing.Size(142, 152);
            this.listOutput.TabIndex = 34;
            this.listOutput.SelectedIndexChanged += new System.EventHandler(this.ListOutput_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(185, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "Output";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(33, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Input";
            // 
            // btnValidation
            // 
            this.btnValidation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnValidation.FlatAppearance.BorderSize = 0;
            this.btnValidation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnValidation.ForeColor = System.Drawing.Color.White;
            this.btnValidation.Location = new System.Drawing.Point(479, 266);
            this.btnValidation.Name = "btnValidation";
            this.btnValidation.Size = new System.Drawing.Size(161, 48);
            this.btnValidation.TabIndex = 37;
            this.btnValidation.Text = "Disable Validation";
            this.btnValidation.UseVisualStyleBackColor = false;
            this.btnValidation.Click += new System.EventHandler(this.BtnValidation_Click);
            // 
            // txtBitvalue
            // 
            this.txtBitvalue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtBitvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBitvalue.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBitvalue.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtBitvalue.Location = new System.Drawing.Point(103, 291);
            this.txtBitvalue.Name = "txtBitvalue";
            this.txtBitvalue.ReadOnly = true;
            this.txtBitvalue.Size = new System.Drawing.Size(227, 23);
            this.txtBitvalue.TabIndex = 38;
            this.txtBitvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(33, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "BitValue : ";
            // 
            // timerBit
            // 
            this.timerBit.Enabled = true;
            this.timerBit.Interval = 1000;
            this.timerBit.Tick += new System.EventHandler(this.TimerBit_Tick);
            // 
            // Smartdevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(765, 344);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBitvalue);
            this.Controls.Add(this.btnValidation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listOutput);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSmartIp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.listInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Smartdevices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Smartdevices";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCount;
        private Core.Components.RoundButtons btnCancel;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSmartIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.ListBox listInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Core.Components.RoundButtons btnValidation;
        private System.Windows.Forms.TextBox txtBitvalue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerBit;
    }
}