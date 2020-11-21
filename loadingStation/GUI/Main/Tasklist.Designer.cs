namespace loadingStation.GUI.Main
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
            this.label4 = new System.Windows.Forms.Label();
            this.bgwTasklist = new System.ComponentModel.BackgroundWorker();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timerTasklist = new System.Windows.Forms.Timer(this.components);
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_machineid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currentconcentrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currentph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currentcoolantlevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_calculatedaddedwater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_calculatedaddedcoolant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currentaddedwater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_currentaddedcoolant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_startdatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_finishdatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_errorcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.col_id,
            this.col_machineid,
            this.col_datetime,
            this.col_nrp,
            this.col_currentconcentrate,
            this.col_currentph,
            this.col_currentcoolantlevel,
            this.col_calculatedaddedwater,
            this.col_calculatedaddedcoolant,
            this.col_currentaddedwater,
            this.col_currentaddedcoolant,
            this.col_startdatetime,
            this.col_finishdatetime,
            this.col_status,
            this.col_errorcode});
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
            // col_id
            // 
            this.col_id.HeaderText = "Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_machineid
            // 
            this.col_machineid.HeaderText = "Machine Id";
            this.col_machineid.Name = "col_machineid";
            this.col_machineid.ReadOnly = true;
            // 
            // col_datetime
            // 
            this.col_datetime.HeaderText = "Datetime";
            this.col_datetime.Name = "col_datetime";
            this.col_datetime.ReadOnly = true;
            // 
            // col_nrp
            // 
            this.col_nrp.HeaderText = "NRP";
            this.col_nrp.Name = "col_nrp";
            this.col_nrp.ReadOnly = true;
            // 
            // col_currentconcentrate
            // 
            this.col_currentconcentrate.HeaderText = "Current Concentrate";
            this.col_currentconcentrate.Name = "col_currentconcentrate";
            this.col_currentconcentrate.ReadOnly = true;
            // 
            // col_currentph
            // 
            this.col_currentph.HeaderText = "Current Ph";
            this.col_currentph.Name = "col_currentph";
            this.col_currentph.ReadOnly = true;
            // 
            // col_currentcoolantlevel
            // 
            this.col_currentcoolantlevel.HeaderText = "Current Coolant Level";
            this.col_currentcoolantlevel.Name = "col_currentcoolantlevel";
            this.col_currentcoolantlevel.ReadOnly = true;
            // 
            // col_calculatedaddedwater
            // 
            this.col_calculatedaddedwater.HeaderText = "Calculated Added Water";
            this.col_calculatedaddedwater.Name = "col_calculatedaddedwater";
            this.col_calculatedaddedwater.ReadOnly = true;
            // 
            // col_calculatedaddedcoolant
            // 
            this.col_calculatedaddedcoolant.HeaderText = "Calculated Added Coolant";
            this.col_calculatedaddedcoolant.Name = "col_calculatedaddedcoolant";
            this.col_calculatedaddedcoolant.ReadOnly = true;
            // 
            // col_currentaddedwater
            // 
            this.col_currentaddedwater.HeaderText = "Current Added Water";
            this.col_currentaddedwater.Name = "col_currentaddedwater";
            this.col_currentaddedwater.ReadOnly = true;
            // 
            // col_currentaddedcoolant
            // 
            this.col_currentaddedcoolant.HeaderText = "Current Added Coolant";
            this.col_currentaddedcoolant.Name = "col_currentaddedcoolant";
            this.col_currentaddedcoolant.ReadOnly = true;
            // 
            // col_startdatetime
            // 
            this.col_startdatetime.HeaderText = "Start Datetime";
            this.col_startdatetime.Name = "col_startdatetime";
            this.col_startdatetime.ReadOnly = true;
            // 
            // col_finishdatetime
            // 
            this.col_finishdatetime.HeaderText = "Finish Datetime";
            this.col_finishdatetime.Name = "col_finishdatetime";
            this.col_finishdatetime.ReadOnly = true;
            // 
            // col_status
            // 
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            this.col_status.ReadOnly = true;
            // 
            // col_errorcode
            // 
            this.col_errorcode.HeaderText = "Error Code";
            this.col_errorcode.Name = "col_errorcode";
            this.col_errorcode.ReadOnly = true;
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
        private System.Windows.Forms.Timer timerTasklist;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_machineid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currentconcentrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currentph;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currentcoolantlevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_calculatedaddedwater;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_calculatedaddedcoolant;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currentaddedwater;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_currentaddedcoolant;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_startdatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_finishdatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_errorcode;
    }
}