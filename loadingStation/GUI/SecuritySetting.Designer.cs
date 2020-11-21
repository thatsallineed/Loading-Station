namespace loadingStation.GUI
{
    partial class SecuritySetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvValue = new System.Windows.Forms.DataGridView();
            this.cmConfigName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelSave = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValue)).BeginInit();
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
            this.lblDashboard.TabIndex = 6;
            this.lblDashboard.Text = "Security";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(31, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "System Role Management";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmConfigName,
            this.cmValue});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvValue.EnableHeadersVisualStyles = false;
            this.dgvValue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvValue.Location = new System.Drawing.Point(32, 88);
            this.dgvValue.MultiSelect = false;
            this.dgvValue.Name = "dgvValue";
            this.dgvValue.RowHeadersVisible = false;
            this.dgvValue.ShowCellErrors = false;
            this.dgvValue.ShowEditingIcon = false;
            this.dgvValue.ShowRowErrors = false;
            this.dgvValue.Size = new System.Drawing.Size(518, 319);
            this.dgvValue.TabIndex = 39;
            this.dgvValue.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvValue_CellValueChanged);
            // 
            // cmConfigName
            // 
            this.cmConfigName.FillWeight = 149.2386F;
            this.cmConfigName.HeaderText = "Name";
            this.cmConfigName.Name = "cmConfigName";
            this.cmConfigName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmValue
            // 
            this.cmValue.FillWeight = 50.76142F;
            this.cmValue.HeaderText = "Value";
            this.cmValue.Name = "cmValue";
            this.cmValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAction
            // 
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(34, 413);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(119, 36);
            this.btnAction.TabIndex = 40;
            this.btnAction.Text = "Save All Changes";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(267, 413);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 36);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // labelSave
            // 
            this.labelSave.Font = new System.Drawing.Font("SF Pro Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelSave.Location = new System.Drawing.Point(341, 413);
            this.labelSave.Name = "labelSave";
            this.labelSave.Size = new System.Drawing.Size(209, 36);
            this.labelSave.TabIndex = 42;
            this.labelSave.Text = "Saved At : 12/12/12 10:10:01\r\nRestart to take effect";
            this.labelSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelSave.Visible = false;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(159, 413);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(102, 36);
            this.btnRestart.TabIndex = 41;
            this.btnRestart.Text = "Restart System";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // SecuritySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(583, 478);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.labelSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.dgvValue);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SecuritySetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Security Setting";
            ((System.ComponentModel.ISupportInitialize)(this.dgvValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmConfigName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmValue;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelSave;
        private System.Windows.Forms.Button btnRestart;
    }
}