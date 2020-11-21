namespace loadingStation.GUI.Settings
{
    partial class ValueChecker
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.dgvValue = new System.Windows.Forms.DataGridView();
            this.btnAction = new System.Windows.Forms.Button();
            this.cmInputValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("SF Pro Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(28, 26);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(119, 33);
            this.lblDashboard.TabIndex = 23;
            this.lblDashboard.Text = "Checker";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(33, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Value";
            // 
            // lblIP
            // 
            this.lblIP.BackColor = System.Drawing.Color.Black;
            this.lblIP.Font = new System.Drawing.Font("SF Pro Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(204)))), ((int)(((byte)(208)))));
            this.lblIP.Location = new System.Drawing.Point(334, 38);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(127, 18);
            this.lblIP.TabIndex = 37;
            this.lblIP.Text = "1.1.1.1";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvValue
            // 
            this.dgvValue.AllowUserToAddRows = false;
            this.dgvValue.AllowUserToDeleteRows = false;
            this.dgvValue.AllowUserToOrderColumns = true;
            this.dgvValue.AllowUserToResizeColumns = false;
            this.dgvValue.AllowUserToResizeRows = false;
            this.dgvValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvValue.BackgroundColor = System.Drawing.Color.Black;
            this.dgvValue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmInputValue,
            this.cmValue});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValue.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvValue.EnableHeadersVisualStyles = false;
            this.dgvValue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvValue.Location = new System.Drawing.Point(34, 96);
            this.dgvValue.MultiSelect = false;
            this.dgvValue.Name = "dgvValue";
            this.dgvValue.ReadOnly = true;
            this.dgvValue.RowHeadersVisible = false;
            this.dgvValue.ShowCellErrors = false;
            this.dgvValue.ShowEditingIcon = false;
            this.dgvValue.ShowRowErrors = false;
            this.dgvValue.Size = new System.Drawing.Size(427, 274);
            this.dgvValue.TabIndex = 38;
            // 
            // btnAction
            // 
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(34, 376);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(68, 36);
            this.btnAction.TabIndex = 39;
            this.btnAction.Text = "Start";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // cmInputValue
            // 
            this.cmInputValue.FillWeight = 149.2386F;
            this.cmInputValue.HeaderText = "Input Value";
            this.cmInputValue.Name = "cmInputValue";
            this.cmInputValue.ReadOnly = true;
            // 
            // cmValue
            // 
            this.cmValue.FillWeight = 50.76142F;
            this.cmValue.HeaderText = "Value";
            this.cmValue.Name = "cmValue";
            this.cmValue.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(108, 376);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 36);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ValueChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(499, 436);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.dgvValue);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ValueChecker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ValueChecker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ValueChecker_FormClosing);
            this.Load += new System.EventHandler(this.ValueChecker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.DataGridView dgvValue;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmInputValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmValue;
        private System.Windows.Forms.Button btnClose;
    }
}