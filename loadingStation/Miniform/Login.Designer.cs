namespace loadingStation.Miniform
{
    partial class Login
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
            this.panelBack = new System.Windows.Forms.Panel();
            this.btnClose = new loadingStation.Core.Components.RoundButtons();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtRfid = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bgwAuth = new System.ComponentModel.BackgroundWorker();
            this.bgwAnimate = new System.ComponentModel.BackgroundWorker();
            this.panelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.White;
            this.panelBack.Controls.Add(this.btnClose);
            this.panelBack.Controls.Add(this.pictureBox2);
            this.panelBack.Controls.Add(this.txtRfid);
            this.panelBack.Controls.Add(this.lblDescription);
            this.panelBack.Controls.Add(this.label2);
            this.panelBack.Controls.Add(this.pictureBox3);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(304, 386);
            this.panelBack.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(94, 305);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 48);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::loadingStation.Properties.Resources.RollingLoader1;
            this.pictureBox2.Location = new System.Drawing.Point(135, 248);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 25);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // txtRfid
            // 
            this.txtRfid.BackColor = System.Drawing.Color.White;
            this.txtRfid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRfid.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtRfid.ForeColor = System.Drawing.Color.White;
            this.txtRfid.Location = new System.Drawing.Point(69, 286);
            this.txtRfid.Name = "txtRfid";
            this.txtRfid.PasswordChar = ' ';
            this.txtRfid.Size = new System.Drawing.Size(160, 13);
            this.txtRfid.TabIndex = 30;
            this.txtRfid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRfid.UseSystemPasswordChar = true;
            this.txtRfid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRfid_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.White;
            this.lblDescription.Font = new System.Drawing.Font("SF Pro Display", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.lblDescription.Location = new System.Drawing.Point(16, 100);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(274, 19);
            this.lblDescription.TabIndex = 29;
            this.lblDescription.Text = "Need Permission to Access";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.label2.Location = new System.Drawing.Point(65, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Scan Your ID Card";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = global::loadingStation.Properties.Resources.id_card;
            this.pictureBox3.Location = new System.Drawing.Point(87, 153);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(120, 79);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // bgwAuth
            // 
            this.bgwAuth.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwAuth_DoWork);
            this.bgwAuth.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgwAuth_ProgressChanged);
            this.bgwAuth.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwAuth_RunWorkerCompleted);
            // 
            // bgwAnimate
            // 
            this.bgwAnimate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwAnimate_DoWork);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(304, 386);
            this.Controls.Add(this.panelBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login";
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.panelBack.ResumeLayout(false);
            this.panelBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtRfid;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.ComponentModel.BackgroundWorker bgwAuth;
        private Core.Components.RoundButton btnExit;
        private Core.Components.RoundButtons btnClose;
        private System.ComponentModel.BackgroundWorker bgwAnimate;
    }
}