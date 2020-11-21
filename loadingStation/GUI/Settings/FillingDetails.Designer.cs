namespace loadingStation.GUI.Settings
{
    partial class FillingDetails
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
            this.txtCoolantValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWaterValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPulseCoolant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new loadingStation.Base.Components.RoundButtons();
            this.btnCancel = new loadingStation.Base.Components.RoundButtons();
            this.btnKeyboard = new loadingStation.Base.Components.RoundButtons();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("SF Pro Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(26, 23);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(179, 33);
            this.lblDashboard.TabIndex = 6;
            this.lblDashboard.Text = "Filling Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Details Filling Water Coolant";
            // 
            // txtCoolantValue
            // 
            this.txtCoolantValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtCoolantValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoolantValue.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoolantValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtCoolantValue.Location = new System.Drawing.Point(113, 126);
            this.txtCoolantValue.Name = "txtCoolantValue";
            this.txtCoolantValue.Size = new System.Drawing.Size(129, 23);
            this.txtCoolantValue.TabIndex = 32;
            this.txtCoolantValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterValue_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(35, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "Coolant ";
            // 
            // txtWaterValue
            // 
            this.txtWaterValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtWaterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaterValue.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaterValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtWaterValue.Location = new System.Drawing.Point(113, 100);
            this.txtWaterValue.Name = "txtWaterValue";
            this.txtWaterValue.Size = new System.Drawing.Size(129, 23);
            this.txtWaterValue.TabIndex = 30;
            this.txtWaterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterValue_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(35, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "Water  ";
            // 
            // txtPulseCoolant
            // 
            this.txtPulseCoolant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.txtPulseCoolant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPulseCoolant.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPulseCoolant.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPulseCoolant.Location = new System.Drawing.Point(324, 126);
            this.txtPulseCoolant.Name = "txtPulseCoolant";
            this.txtPulseCoolant.Size = new System.Drawing.Size(89, 23);
            this.txtPulseCoolant.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(260, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Pulse";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(342, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 54);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(263, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 54);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.btnKeyboard.FlatAppearance.BorderSize = 0;
            this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyboard.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnKeyboard.ForeColor = System.Drawing.Color.White;
            this.btnKeyboard.Location = new System.Drawing.Point(178, 168);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(79, 54);
            this.btnKeyboard.TabIndex = 37;
            this.btnKeyboard.Text = "Keyboard";
            this.btnKeyboard.UseVisualStyleBackColor = false;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // FillingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(456, 238);
            this.Controls.Add(this.btnKeyboard);
            this.Controls.Add(this.txtPulseCoolant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCoolantValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWaterValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FillingDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FillingDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label label1;
        private Base.Components.RoundButtons btnCancel;
        private Base.Components.RoundButtons btnSave;
        private System.Windows.Forms.TextBox txtCoolantValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWaterValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPulseCoolant;
        private System.Windows.Forms.Label label2;
        private Base.Components.RoundButtons btnKeyboard;
    }
}