namespace loadingStation.GUI
{
    partial class Tasklist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTasklist = new System.Windows.Forms.DataGridView();
            this.dgvNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAsset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConcentration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.bgwTasklist = new System.ComponentModel.BackgroundWorker();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timerTasklist = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTasklist
            // 
            this.dgvTasklist.AllowUserToAddRows = false;
            this.dgvTasklist.AllowUserToDeleteRows = false;
            this.dgvTasklist.AllowUserToResizeColumns = false;
            this.dgvTasklist.AllowUserToResizeRows = false;
            this.dgvTasklist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasklist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.dgvTasklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTasklist.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTasklist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SF Pro Display", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasklist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTasklist.ColumnHeadersHeight = 35;
            this.dgvTasklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTasklist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvNumber,
            this.dgvNRP,
            this.dgvDatetime,
            this.dgvAsset,
            this.op_name,
            this.dgvConcentration,
            this.dgvPH,
            this.dgvLevel,
            this.dgvType,
            this.dgvStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SF Pro Display", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTasklist.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTasklist.EnableHeadersVisualStyles = false;
            this.dgvTasklist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.dgvTasklist.Location = new System.Drawing.Point(21, 60);
            this.dgvTasklist.MultiSelect = false;
            this.dgvTasklist.Name = "dgvTasklist";
            this.dgvTasklist.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SF Pro Display", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasklist.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTasklist.RowHeadersVisible = false;
            this.dgvTasklist.ShowCellErrors = false;
            this.dgvTasklist.ShowCellToolTips = false;
            this.dgvTasklist.ShowEditingIcon = false;
            this.dgvTasklist.ShowRowErrors = false;
            this.dgvTasklist.Size = new System.Drawing.Size(983, 623);
            this.dgvTasklist.TabIndex = 54;
            // 
            // dgvNumber
            // 
            this.dgvNumber.FillWeight = 43.97208F;
            this.dgvNumber.HeaderText = "No";
            this.dgvNumber.Name = "dgvNumber";
            this.dgvNumber.ReadOnly = true;
            // 
            // dgvNRP
            // 
            this.dgvNRP.FillWeight = 43.97208F;
            this.dgvNRP.HeaderText = "NRP";
            this.dgvNRP.Name = "dgvNRP";
            this.dgvNRP.ReadOnly = true;
            // 
            // dgvDatetime
            // 
            this.dgvDatetime.HeaderText = "Datetime";
            this.dgvDatetime.Name = "dgvDatetime";
            this.dgvDatetime.ReadOnly = true;
            // 
            // dgvAsset
            // 
            this.dgvAsset.FillWeight = 50F;
            this.dgvAsset.HeaderText = "Asset Number";
            this.dgvAsset.Name = "dgvAsset";
            this.dgvAsset.ReadOnly = true;
            // 
            // op_name
            // 
            this.op_name.HeaderText = "OP Name";
            this.op_name.Name = "op_name";
            this.op_name.ReadOnly = true;
            this.op_name.Visible = false;
            // 
            // dgvConcentration
            // 
            this.dgvConcentration.FillWeight = 43.97208F;
            this.dgvConcentration.HeaderText = "Concentration";
            this.dgvConcentration.Name = "dgvConcentration";
            this.dgvConcentration.ReadOnly = true;
            // 
            // dgvPH
            // 
            this.dgvPH.FillWeight = 43.97208F;
            this.dgvPH.HeaderText = "PH";
            this.dgvPH.Name = "dgvPH";
            this.dgvPH.ReadOnly = true;
            // 
            // dgvLevel
            // 
            this.dgvLevel.FillWeight = 43.97208F;
            this.dgvLevel.HeaderText = "Level";
            this.dgvLevel.Name = "dgvLevel";
            this.dgvLevel.ReadOnly = true;
            // 
            // dgvType
            // 
            this.dgvType.FillWeight = 43.97208F;
            this.dgvType.HeaderText = "Type";
            this.dgvType.Name = "dgvType";
            this.dgvType.ReadOnly = true;
            // 
            // dgvStatus
            // 
            this.dgvStatus.FillWeight = 43.97208F;
            this.dgvStatus.HeaderText = "Status";
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SF Pro Display", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 28);
            this.label4.TabIndex = 53;
            this.label4.Text = "Task List";
            // 
            // bgwTasklist
            // 
            this.bgwTasklist.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwTasklist_DoWork);
            this.bgwTasklist.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwTasklist_RunWorkerCompleted);
            // 
            // pictureBox22
            // 
            this.pictureBox22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox22.Image = global::loadingStation.Properties.Resources.botRight;
            this.pictureBox22.Location = new System.Drawing.Point(996, 675);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(8, 8);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox22.TabIndex = 55;
            this.pictureBox22.TabStop = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox21.Image = global::loadingStation.Properties.Resources.botLeft;
            this.pictureBox21.Location = new System.Drawing.Point(21, 675);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(8, 8);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox21.TabIndex = 56;
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox20.Image = global::loadingStation.Properties.Resources.topRight;
            this.pictureBox20.Location = new System.Drawing.Point(996, 60);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(8, 8);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox20.TabIndex = 57;
            this.pictureBox20.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(86)))), ((int)(((byte)(99)))));
            this.pictureBox4.Image = global::loadingStation.Properties.Resources.topLeft1;
            this.pictureBox4.Location = new System.Drawing.Point(21, 60);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(8, 8);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 58;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::loadingStation.Properties.Resources.bgTaskList;
            this.pictureBox3.Location = new System.Drawing.Point(21, 60);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(983, 623);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 52;
            this.pictureBox3.TabStop = false;
            // 
            // timerTasklist
            // 
            this.timerTasklist.Interval = 2000;
            this.timerTasklist.Tick += new System.EventHandler(this.TimerTasklist_Tick);
            // 
            // Tasklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(67)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1024, 706);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.dgvTasklist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tasklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tasklist";
            this.Load += new System.EventHandler(this.Tasklist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridView dgvTasklist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.ComponentModel.BackgroundWorker bgwTasklist;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAsset;
        private System.Windows.Forms.DataGridViewTextBoxColumn op_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConcentration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStatus;
        private System.Windows.Forms.Timer timerTasklist;
    }
}