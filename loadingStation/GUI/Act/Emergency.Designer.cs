namespace loadingStation.GUI.Act
{
    partial class Emergency
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
            this.lblDetails = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.btnOk = new loadingStation.Base.Components.RoundButtons();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(61, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(899, 45);
            this.label4.TabIndex = 27;
            this.label4.Text = "TERJADI KEGAGALAN!";
            // 
            // lblDetails
            // 
            this.lblDetails.Font = new System.Drawing.Font("SF Pro Display", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.Color.White;
            this.lblDetails.Location = new System.Drawing.Point(64, 219);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(896, 33);
            this.lblDetails.TabIndex = 39;
            this.lblDetails.Text = "Coolant Valve (V1) ERROR.\r\nPlease Check && Restart Application\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 29);
            this.label1.TabIndex = 40;
            this.label1.Text = "Masalah: ";
            // 
            // lblReason
            // 
            this.lblReason.Font = new System.Drawing.Font("SF Pro Display", 18F, System.Drawing.FontStyle.Bold);
            this.lblReason.ForeColor = System.Drawing.Color.White;
            this.lblReason.Location = new System.Drawing.Point(65, 321);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(895, 280);
            this.lblReason.TabIndex = 41;
            this.lblReason.Text = "-";
            // 
            // lblClose
            // 
            this.lblClose.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblClose.Location = new System.Drawing.Point(953, 34);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(33, 28);
            this.lblClose.TabIndex = 42;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(66, 634);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(894, 80);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // Emergency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Emergency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActionRestart_FormClosing);
            this.Load += new System.EventHandler(this.ActionRestart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Base.Components.RoundButtons btnOk;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblClose;
    }
}