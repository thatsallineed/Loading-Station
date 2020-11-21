namespace loadingStation.Miniform
{
    partial class LSSetting
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
            this.listProperties = new System.Windows.Forms.ListBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastValue = new System.Windows.Forms.TextBox();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastChanged = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRestart = new System.Windows.Forms.Label();
            this.btnRestart = new loadingStation.Core.Components.RoundButtons();
            this.btnCancel = new loadingStation.Core.Components.RoundButtons();
            this.btnSave = new loadingStation.Core.Components.RoundButtons();
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
            this.lblDashboard.TabIndex = 2;
            this.lblDashboard.Text = "Settings";
            // 
            // listProperties
            // 
            this.listProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.listProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listProperties.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProperties.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.listProperties.FormattingEnabled = true;
            this.listProperties.ItemHeight = 15;
            this.listProperties.Location = new System.Drawing.Point(31, 95);
            this.listProperties.Margin = new System.Windows.Forms.Padding(12);
            this.listProperties.Name = "listProperties";
            this.listProperties.Size = new System.Drawing.Size(247, 197);
            this.listProperties.TabIndex = 4;
            this.listProperties.SelectedIndexChanged += new System.EventHandler(this.ListProperties_SelectedIndexChanged);
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("SF Pro Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.ForeColor = System.Drawing.Color.White;
            this.lblSelected.Location = new System.Drawing.Point(295, 122);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(105, 24);
            this.lblSelected.TabIndex = 5;
            this.lblSelected.Text = "Select List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(296, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Value : ";
            // 
            // txtLastValue
            // 
            this.txtLastValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtLastValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastValue.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtLastValue.Location = new System.Drawing.Point(389, 161);
            this.txtLastValue.Name = "txtLastValue";
            this.txtLastValue.ReadOnly = true;
            this.txtLastValue.Size = new System.Drawing.Size(281, 23);
            this.txtLastValue.TabIndex = 7;
            // 
            // txtNewValue
            // 
            this.txtNewValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewValue.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtNewValue.Location = new System.Drawing.Point(389, 187);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(281, 23);
            this.txtNewValue.TabIndex = 9;
            this.txtNewValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNewValue_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(296, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "New Value : ";
            // 
            // lblLastChanged
            // 
            this.lblLastChanged.Font = new System.Drawing.Font("SF Pro Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastChanged.ForeColor = System.Drawing.Color.White;
            this.lblLastChanged.Location = new System.Drawing.Point(299, 30);
            this.lblLastChanged.Name = "lblLastChanged";
            this.lblLastChanged.Size = new System.Drawing.Size(371, 24);
            this.lblLastChanged.TabIndex = 18;
            this.lblLastChanged.Text = "Last Updated 12/12/12 04:20";
            this.lblLastChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLastChanged.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Internal Config";
            // 
            // lblRestart
            // 
            this.lblRestart.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblRestart.Location = new System.Drawing.Point(303, 55);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(367, 16);
            this.lblRestart.TabIndex = 19;
            this.lblRestart.Text = "Restart Application to Take Effect";
            this.lblRestart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRestart.Visible = false;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(363, 244);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(86, 48);
            this.btnRestart.TabIndex = 20;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(590, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 48);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(457, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 48);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LSSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(700, 320);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblRestart);
            this.Controls.Add(this.lblLastChanged);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNewValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.listProperties);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LSSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LSSetting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.ListBox listProperties;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastValue;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.Label label4;
        private Core.Components.RoundButtons btnSave;
        private Core.Components.RoundButtons btnCancel;
        private System.Windows.Forms.Label lblLastChanged;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRestart;
        private Core.Components.RoundButtons btnRestart;
    }
}