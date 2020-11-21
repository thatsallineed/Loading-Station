namespace updater
{
    partial class Form1
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
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lbList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("SF Pro Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(22, 20);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(116, 33);
            this.lblDashboard.TabIndex = 5;
            this.lblDashboard.Text = "Updater";
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(28, 115);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(438, 23);
            this.pbDownload.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(25, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "File : ";
            // 
            // lblPercentage
            // 
            this.lblPercentage.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPercentage.Location = new System.Drawing.Point(416, 66);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(50, 16);
            this.lblPercentage.TabIndex = 8;
            this.lblPercentage.Text = "0%";
            this.lblPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(25, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Installing, Please Wait ...";
            // 
            // lblFilename
            // 
            this.lblFilename.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblFilename.Location = new System.Drawing.Point(62, 67);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(339, 16);
            this.lblFilename.TabIndex = 10;
            this.lblFilename.Text = "config.json";
            // 
            // lbList
            // 
            this.lbList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lbList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbList.ForeColor = System.Drawing.Color.DarkGray;
            this.lbList.FormattingEnabled = true;
            this.lbList.Items.AddRange(new object[] {
            "Downloading config.json",
            "Downloaded config.json OK",
            "Downloading mysql.dll"});
            this.lbList.Location = new System.Drawing.Point(28, 144);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(438, 197);
            this.lbList.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(493, 364);
            this.Controls.Add(this.lbList);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.lblDashboard);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Update";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.ListBox lbList;
    }
}

