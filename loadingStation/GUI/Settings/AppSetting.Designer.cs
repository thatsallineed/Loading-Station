namespace loadingStation.GUI.Settings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbWater = new System.Windows.Forms.CheckBox();
            this.cbCoolant = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPropeler = new System.Windows.Forms.CheckBox();
            this.rbIndicator = new System.Windows.Forms.RadioButton();
            this.rbDebug = new System.Windows.Forms.RadioButton();
            this.rbRelease = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new loadingStation.Base.Components.RoundButtons();
            this.btnConfigurations = new loadingStation.Base.Components.RoundButtons();
            this.btnSmartdevice = new loadingStation.Base.Components.RoundButtons();
            this.btnSecurity = new loadingStation.Base.Components.RoundButtons();
            this.btnExit = new loadingStation.Base.Components.RoundButtons();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbManualOn = new System.Windows.Forms.RadioButton();
            this.rbManualOff = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.rbIndicator);
            this.panel1.Controls.Add(this.rbDebug);
            this.panel1.Controls.Add(this.rbRelease);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Location = new System.Drawing.Point(185, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 274);
            this.panel1.TabIndex = 27;
            // 
            // cbWater
            // 
            this.cbWater.AutoSize = true;
            this.cbWater.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWater.ForeColor = System.Drawing.Color.White;
            this.cbWater.Location = new System.Drawing.Point(18, 105);
            this.cbWater.Name = "cbWater";
            this.cbWater.Size = new System.Drawing.Size(56, 17);
            this.cbWater.TabIndex = 37;
            this.cbWater.Text = "Water";
            this.cbWater.UseVisualStyleBackColor = true;
            this.cbWater.CheckedChanged += new System.EventHandler(this.cbWater_CheckedChanged);
            // 
            // cbCoolant
            // 
            this.cbCoolant.AutoSize = true;
            this.cbCoolant.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCoolant.ForeColor = System.Drawing.Color.White;
            this.cbCoolant.Location = new System.Drawing.Point(18, 82);
            this.cbCoolant.Name = "cbCoolant";
            this.cbCoolant.Size = new System.Drawing.Size(65, 17);
            this.cbCoolant.TabIndex = 36;
            this.cbCoolant.Text = "Coolant";
            this.cbCoolant.UseVisualStyleBackColor = true;
            this.cbCoolant.CheckedChanged += new System.EventHandler(this.cbCoolant_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(15, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Manual Action";
            // 
            // cbPropeler
            // 
            this.cbPropeler.AutoSize = true;
            this.cbPropeler.Checked = true;
            this.cbPropeler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPropeler.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPropeler.ForeColor = System.Drawing.Color.White;
            this.cbPropeler.Location = new System.Drawing.Point(18, 59);
            this.cbPropeler.Name = "cbPropeler";
            this.cbPropeler.Size = new System.Drawing.Size(69, 17);
            this.cbPropeler.TabIndex = 34;
            this.cbPropeler.Text = "Propeler";
            this.cbPropeler.UseVisualStyleBackColor = true;
            this.cbPropeler.CheckedChanged += new System.EventHandler(this.cbPropeler_CheckedChanged);
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
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(34, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 50);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnConfigurations
            // 
            this.btnConfigurations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnConfigurations.FlatAppearance.BorderSize = 0;
            this.btnConfigurations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurations.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnConfigurations.ForeColor = System.Drawing.Color.White;
            this.btnConfigurations.Location = new System.Drawing.Point(34, 89);
            this.btnConfigurations.Name = "btnConfigurations";
            this.btnConfigurations.Size = new System.Drawing.Size(128, 50);
            this.btnConfigurations.TabIndex = 30;
            this.btnConfigurations.Text = "Configurations";
            this.btnConfigurations.UseVisualStyleBackColor = false;
            this.btnConfigurations.Click += new System.EventHandler(this.btnConfigurations_Click);
            // 
            // btnSmartdevice
            // 
            this.btnSmartdevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnSmartdevice.FlatAppearance.BorderSize = 0;
            this.btnSmartdevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmartdevice.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSmartdevice.ForeColor = System.Drawing.Color.White;
            this.btnSmartdevice.Location = new System.Drawing.Point(34, 145);
            this.btnSmartdevice.Name = "btnSmartdevice";
            this.btnSmartdevice.Size = new System.Drawing.Size(128, 50);
            this.btnSmartdevice.TabIndex = 29;
            this.btnSmartdevice.Text = "Smartdevice";
            this.btnSmartdevice.UseVisualStyleBackColor = false;
            this.btnSmartdevice.Click += new System.EventHandler(this.btnSmartdevice_Click);
            // 
            // btnSecurity
            // 
            this.btnSecurity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnSecurity.FlatAppearance.BorderSize = 0;
            this.btnSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecurity.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSecurity.ForeColor = System.Drawing.Color.White;
            this.btnSecurity.Location = new System.Drawing.Point(34, 201);
            this.btnSecurity.Name = "btnSecurity";
            this.btnSecurity.Size = new System.Drawing.Size(128, 50);
            this.btnSecurity.TabIndex = 28;
            this.btnSecurity.Text = "Security Settings";
            this.btnSecurity.UseVisualStyleBackColor = false;
            this.btnSecurity.Click += new System.EventHandler(this.BtnSecurity_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(34, 257);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 50);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit Safely";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(59)))), ((int)(((byte)(73)))));
            this.panel2.Controls.Add(this.rbManualOff);
            this.panel2.Controls.Add(this.rbManualOn);
            this.panel2.Controls.Add(this.cbPropeler);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbWater);
            this.panel2.Controls.Add(this.cbCoolant);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 141);
            this.panel2.TabIndex = 38;
            // 
            // rbManualOn
            // 
            this.rbManualOn.AutoSize = true;
            this.rbManualOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbManualOn.Font = new System.Drawing.Font("SF Pro Display", 8F, System.Drawing.FontStyle.Bold);
            this.rbManualOn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbManualOn.Location = new System.Drawing.Point(18, 34);
            this.rbManualOn.Name = "rbManualOn";
            this.rbManualOn.Size = new System.Drawing.Size(38, 17);
            this.rbManualOn.TabIndex = 38;
            this.rbManualOn.Text = "On";
            this.rbManualOn.UseVisualStyleBackColor = true;
            this.rbManualOn.CheckedChanged += new System.EventHandler(this.rbManualOn_CheckedChanged);
            // 
            // rbManualOff
            // 
            this.rbManualOff.AutoSize = true;
            this.rbManualOff.Checked = true;
            this.rbManualOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbManualOff.Font = new System.Drawing.Font("SF Pro Display", 8F, System.Drawing.FontStyle.Bold);
            this.rbManualOff.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbManualOff.Location = new System.Drawing.Point(62, 34);
            this.rbManualOff.Name = "rbManualOff";
            this.rbManualOff.Size = new System.Drawing.Size(40, 17);
            this.rbManualOff.TabIndex = 39;
            this.rbManualOff.TabStop = true;
            this.rbManualOff.Text = "Off";
            this.rbManualOff.UseVisualStyleBackColor = true;
            this.rbManualOff.CheckedChanged += new System.EventHandler(this.rbManualOff_CheckedChanged);
            // 
            // AppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(437, 383);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfigurations);
            this.Controls.Add(this.btnSmartdevice);
            this.Controls.Add(this.btnSecurity);
            this.Controls.Add(this.panel1);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label label1;
        private Base.Components.RoundButtons btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbIndicator;
        private System.Windows.Forms.RadioButton rbDebug;
        private System.Windows.Forms.RadioButton rbRelease;
        private System.Windows.Forms.Label label2;
        private Base.Components.RoundButtons btnSecurity;
        private Base.Components.RoundButtons btnSmartdevice;
        private Base.Components.RoundButtons btnConfigurations;
        private Base.Components.RoundButtons btnCancel;
        private System.Windows.Forms.CheckBox cbPropeler;
        private System.Windows.Forms.CheckBox cbWater;
        private System.Windows.Forms.CheckBox cbCoolant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbManualOff;
        private System.Windows.Forms.RadioButton rbManualOn;
    }
}