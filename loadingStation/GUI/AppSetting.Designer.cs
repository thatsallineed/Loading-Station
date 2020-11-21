namespace loadingStation.GUI
{
    partial class AppSetting
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
            this.lblDashboard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.listProperties = new System.Windows.Forms.ListBox();
            this.btnCancel = new loadingStation.Core.Components.RoundButtons();
            this.btnRestart = new loadingStation.Core.Components.RoundButtons();
            this.btnExit = new loadingStation.Core.Components.RoundButtons();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbIndicator = new System.Windows.Forms.RadioButton();
            this.rbDebug = new System.Windows.Forms.RadioButton();
            this.rbRelease = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSecurity = new loadingStation.Core.Components.RoundButtons();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("SF Pro Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(26, 23);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(119, 33);
            this.lblDashboard.TabIndex = 4;
            this.lblDashboard.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Application (Read Only)";
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValue.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtValue.Location = new System.Drawing.Point(32, 271);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(268, 23);
            this.txtValue.TabIndex = 24;
            // 
            // listProperties
            // 
            this.listProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.listProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listProperties.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProperties.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.listProperties.FormattingEnabled = true;
            this.listProperties.ItemHeight = 15;
            this.listProperties.Location = new System.Drawing.Point(32, 89);
            this.listProperties.Margin = new System.Windows.Forms.Padding(12);
            this.listProperties.Name = "listProperties";
            this.listProperties.Size = new System.Drawing.Size(268, 167);
            this.listProperties.TabIndex = 25;
            this.listProperties.SelectedIndexChanged += new System.EventHandler(this.ListProperties_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(32, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 54);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(111, 309);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(109, 50);
            this.btnRestart.TabIndex = 21;
            this.btnRestart.Text = "Restart Safely";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(226, 309);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 50);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit Safely";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbIndicator);
            this.panel1.Controls.Add(this.rbDebug);
            this.panel1.Controls.Add(this.rbRelease);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Location = new System.Drawing.Point(315, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 205);
            this.panel1.TabIndex = 27;
            // 
            // rbIndicator
            // 
            this.rbIndicator.AutoSize = true;
            this.rbIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbIndicator.Font = new System.Drawing.Font("SF Pro Display", 8F, System.Drawing.FontStyle.Bold);
            this.rbIndicator.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbIndicator.Location = new System.Drawing.Point(18, 92);
            this.rbIndicator.Name = "rbIndicator";
            this.rbIndicator.Size = new System.Drawing.Size(94, 17);
            this.rbIndicator.TabIndex = 33;
            this.rbIndicator.TabStop = true;
            this.rbIndicator.Text = "Indicator Only";
            this.rbIndicator.UseVisualStyleBackColor = true;
            this.rbIndicator.CheckedChanged += new System.EventHandler(this.RbIndicator_CheckedChanged);
            // 
            // rbDebug
            // 
            this.rbDebug.AutoSize = true;
            this.rbDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDebug.Font = new System.Drawing.Font("SF Pro Display", 8F, System.Drawing.FontStyle.Bold);
            this.rbDebug.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbDebug.Location = new System.Drawing.Point(18, 69);
            this.rbDebug.Name = "rbDebug";
            this.rbDebug.Size = new System.Drawing.Size(87, 17);
            this.rbDebug.TabIndex = 32;
            this.rbDebug.TabStop = true;
            this.rbDebug.Text = "Debug Local";
            this.rbDebug.UseVisualStyleBackColor = true;
            this.rbDebug.CheckedChanged += new System.EventHandler(this.RbDebug_CheckedChanged);
            // 
            // rbRelease
            // 
            this.rbRelease.AutoSize = true;
            this.rbRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbRelease.Font = new System.Drawing.Font("SF Pro Display", 8F, System.Drawing.FontStyle.Bold);
            this.rbRelease.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbRelease.Location = new System.Drawing.Point(18, 46);
            this.rbRelease.Name = "rbRelease";
            this.rbRelease.Size = new System.Drawing.Size(64, 17);
            this.rbRelease.TabIndex = 31;
            this.rbRelease.TabStop = true;
            this.rbRelease.Text = "Release";
            this.rbRelease.UseVisualStyleBackColor = true;
            this.rbRelease.CheckedChanged += new System.EventHandler(this.RbRelease_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "App Mode";
            // 
            // btnSecurity
            // 
            this.btnSecurity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnSecurity.FlatAppearance.BorderSize = 0;
            this.btnSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecurity.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSecurity.ForeColor = System.Drawing.Color.White;
            this.btnSecurity.Location = new System.Drawing.Point(319, 309);
            this.btnSecurity.Name = "btnSecurity";
            this.btnSecurity.Size = new System.Drawing.Size(157, 50);
            this.btnSecurity.TabIndex = 28;
            this.btnSecurity.Text = "Security Settings";
            this.btnSecurity.UseVisualStyleBackColor = false;
            this.btnSecurity.Click += new System.EventHandler(this.BtnSecurity_Click);
            // 
            // AppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(509, 389);
            this.Controls.Add(this.btnSecurity);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listProperties);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AppSetting";
            this.Load += new System.EventHandler(this.AppSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label label1;
        private Core.Components.RoundButtons btnExit;
        private Core.Components.RoundButtons btnRestart;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ListBox listProperties;
        private Core.Components.RoundButtons btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbIndicator;
        private System.Windows.Forms.RadioButton rbDebug;
        private System.Windows.Forms.RadioButton rbRelease;
        private System.Windows.Forms.Label label2;
        private Core.Components.RoundButtons btnSecurity;
    }
}