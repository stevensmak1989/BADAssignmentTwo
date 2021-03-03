
namespace FujitsuPayments.Forms
{
    partial class frmEditShift
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblShiftStartTime = new System.Windows.Forms.Label();
            this.dtpShiftStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.cmbTaskId = new System.Windows.Forms.ComboBox();
            this.lblTaskId = new System.Windows.Forms.Label();
            this.cmbProjectId = new System.Windows.Forms.ComboBox();
            this.lblProjectId = new System.Windows.Forms.Label();
            this.cmbAccountId = new System.Windows.Forms.ComboBox();
            this.txtShiftID = new System.Windows.Forms.TextBox();
            this.lblShiftID = new System.Windows.Forms.Label();
            this.btnEditClose = new System.Windows.Forms.Button();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.lblEditShift = new System.Windows.Forms.Label();
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cmbStartTime);
            this.panel1.Controls.Add(this.cmbEndTime);
            this.panel1.Controls.Add(this.lblEndTime);
            this.panel1.Controls.Add(this.lblShiftStartTime);
            this.panel1.Controls.Add(this.dtpShiftStartDate);
            this.panel1.Controls.Add(this.lblStartTime);
            this.panel1.Controls.Add(this.cmbTaskId);
            this.panel1.Controls.Add(this.lblTaskId);
            this.panel1.Controls.Add(this.cmbProjectId);
            this.panel1.Controls.Add(this.lblProjectId);
            this.panel1.Controls.Add(this.cmbAccountId);
            this.panel1.Controls.Add(this.txtShiftID);
            this.panel1.Controls.Add(this.lblShiftID);
            this.panel1.Controls.Add(this.btnEditClose);
            this.panel1.Controls.Add(this.btnEditSave);
            this.panel1.Controls.Add(this.lblAccountId);
            this.panel1.Controls.Add(this.lblEditShift);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 316);
            this.panel1.TabIndex = 0;
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Items.AddRange(new object[] {
            "08:00",
            "08:15",
            "08:30",
            "08:45",
            "09:00",
            "09:15",
            "09:30",
            "09:45",
            "10:00",
            "10:15",
            "10:30",
            "10:45",
            "11:00",
            "11:15",
            "11:30",
            "11:45",
            "12:00",
            "12:15",
            "12:30",
            "12:45",
            "13:00",
            "13:15",
            "13:30",
            "13:45",
            "14:00",
            "14:15",
            "14:30",
            "14:45",
            "15:00",
            "15:15",
            "15:30",
            "15:45",
            "16:00",
            "16:15",
            "16:30",
            "16:45",
            "17:00",
            "17:15",
            "17:30",
            "17:45",
            "18:00"});
            this.cmbStartTime.Location = new System.Drawing.Point(481, 130);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(102, 29);
            this.cmbStartTime.TabIndex = 47;
            // 
            // cmbEndTime
            // 
            this.cmbEndTime.FormattingEnabled = true;
            this.cmbEndTime.Items.AddRange(new object[] {
            "08:00",
            "08:15",
            "08:30",
            "08:45",
            "09:00",
            "09:15",
            "09:30",
            "09:45",
            "10:00",
            "10:15",
            "10:30",
            "10:45",
            "11:00",
            "11:15",
            "11:30",
            "11:45",
            "12:00",
            "12:15",
            "12:30",
            "12:45",
            "13:00",
            "13:15",
            "13:30",
            "13:45",
            "14:00",
            "14:15",
            "14:30",
            "14:45",
            "15:00",
            "15:15",
            "15:30",
            "15:45",
            "16:00",
            "16:15",
            "16:30",
            "16:45",
            "17:00",
            "17:15",
            "17:30",
            "17:45",
            "18:00"});
            this.cmbEndTime.Location = new System.Drawing.Point(481, 165);
            this.cmbEndTime.Name = "cmbEndTime";
            this.cmbEndTime.Size = new System.Drawing.Size(102, 29);
            this.cmbEndTime.TabIndex = 46;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblEndTime.Location = new System.Drawing.Point(397, 172);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(65, 17);
            this.lblEndTime.TabIndex = 45;
            this.lblEndTime.Text = "End Time";
            // 
            // lblShiftStartTime
            // 
            this.lblShiftStartTime.AutoSize = true;
            this.lblShiftStartTime.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblShiftStartTime.Location = new System.Drawing.Point(397, 137);
            this.lblShiftStartTime.Name = "lblShiftStartTime";
            this.lblShiftStartTime.Size = new System.Drawing.Size(70, 17);
            this.lblShiftStartTime.TabIndex = 44;
            this.lblShiftStartTime.Text = "Start Time";
            // 
            // dtpShiftStartDate
            // 
            this.dtpShiftStartDate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpShiftStartDate.Location = new System.Drawing.Point(133, 129);
            this.dtpShiftStartDate.Name = "dtpShiftStartDate";
            this.dtpShiftStartDate.Size = new System.Drawing.Size(222, 26);
            this.dtpShiftStartDate.TabIndex = 43;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblStartTime.Location = new System.Drawing.Point(50, 137);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(73, 17);
            this.lblStartTime.TabIndex = 42;
            this.lblStartTime.Text = "Start Date";
            // 
            // cmbTaskId
            // 
            this.cmbTaskId.FormattingEnabled = true;
            this.cmbTaskId.Location = new System.Drawing.Point(481, 95);
            this.cmbTaskId.Name = "cmbTaskId";
            this.cmbTaskId.Size = new System.Drawing.Size(222, 29);
            this.cmbTaskId.TabIndex = 41;
            this.cmbTaskId.SelectedIndexChanged += new System.EventHandler(this.cmbTaskId_SelectedIndexChanged);
            // 
            // lblTaskId
            // 
            this.lblTaskId.AutoSize = true;
            this.lblTaskId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTaskId.Location = new System.Drawing.Point(420, 102);
            this.lblTaskId.Name = "lblTaskId";
            this.lblTaskId.Size = new System.Drawing.Size(51, 17);
            this.lblTaskId.TabIndex = 40;
            this.lblTaskId.Text = "Task ID";
            // 
            // cmbProjectId
            // 
            this.cmbProjectId.FormattingEnabled = true;
            this.cmbProjectId.Location = new System.Drawing.Point(133, 94);
            this.cmbProjectId.Name = "cmbProjectId";
            this.cmbProjectId.Size = new System.Drawing.Size(222, 29);
            this.cmbProjectId.TabIndex = 39;
            this.cmbProjectId.SelectedIndexChanged += new System.EventHandler(this.cmbProjectId_SelectedIndexChanged);
            // 
            // lblProjectId
            // 
            this.lblProjectId.AutoSize = true;
            this.lblProjectId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblProjectId.Location = new System.Drawing.Point(53, 101);
            this.lblProjectId.Name = "lblProjectId";
            this.lblProjectId.Size = new System.Drawing.Size(70, 17);
            this.lblProjectId.TabIndex = 38;
            this.lblProjectId.Text = "Project ID";
            // 
            // cmbAccountId
            // 
            this.cmbAccountId.FormattingEnabled = true;
            this.cmbAccountId.Location = new System.Drawing.Point(481, 60);
            this.cmbAccountId.Name = "cmbAccountId";
            this.cmbAccountId.Size = new System.Drawing.Size(222, 29);
            this.cmbAccountId.TabIndex = 37;
            this.cmbAccountId.SelectedIndexChanged += new System.EventHandler(this.cmbAccountId_SelectedIndexChanged);
            // 
            // txtShiftID
            // 
            this.txtShiftID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShiftID.Location = new System.Drawing.Point(133, 62);
            this.txtShiftID.Name = "txtShiftID";
            this.txtShiftID.Size = new System.Drawing.Size(222, 26);
            this.txtShiftID.TabIndex = 36;
            // 
            // lblShiftID
            // 
            this.lblShiftID.AutoSize = true;
            this.lblShiftID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblShiftID.Location = new System.Drawing.Point(72, 68);
            this.lblShiftID.Name = "lblShiftID";
            this.lblShiftID.Size = new System.Drawing.Size(51, 17);
            this.lblShiftID.TabIndex = 35;
            this.lblShiftID.Text = "Shift ID";
            // 
            // btnEditClose
            // 
            this.btnEditClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditClose.FlatAppearance.BorderSize = 2;
            this.btnEditClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEditClose.Location = new System.Drawing.Point(264, 238);
            this.btnEditClose.Name = "btnEditClose";
            this.btnEditClose.Size = new System.Drawing.Size(97, 27);
            this.btnEditClose.TabIndex = 34;
            this.btnEditClose.Text = "Close";
            this.btnEditClose.UseVisualStyleBackColor = true;
            this.btnEditClose.Click += new System.EventHandler(this.btnEditClose_Click);
            // 
            // btnEditSave
            // 
            this.btnEditSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditSave.FlatAppearance.BorderSize = 2;
            this.btnEditSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.btnEditSave.Location = new System.Drawing.Point(414, 238);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(97, 27);
            this.btnEditSave.TabIndex = 33;
            this.btnEditSave.Text = "Save";
            this.btnEditSave.UseVisualStyleBackColor = true;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblAccountId.Location = new System.Drawing.Point(391, 68);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(80, 17);
            this.lblAccountId.TabIndex = 32;
            this.lblAccountId.Text = "Account ID";
            // 
            // lblEditShift
            // 
            this.lblEditShift.AutoSize = true;
            this.lblEditShift.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditShift.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEditShift.Location = new System.Drawing.Point(354, 24);
            this.lblEditShift.Name = "lblEditShift";
            this.lblEditShift.Size = new System.Drawing.Size(67, 18);
            this.lblEditShift.TabIndex = 31;
            this.lblEditShift.Text = "Edit Shift";
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // frmEditShift
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(791, 332);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmEditShift";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditShift";
            this.Load += new System.EventHandler(this.frmEditShift_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errP;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.ComboBox cmbEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblShiftStartTime;
        private System.Windows.Forms.DateTimePicker dtpShiftStartDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.ComboBox cmbTaskId;
        private System.Windows.Forms.Label lblTaskId;
        private System.Windows.Forms.ComboBox cmbProjectId;
        private System.Windows.Forms.Label lblProjectId;
        private System.Windows.Forms.ComboBox cmbAccountId;
        private System.Windows.Forms.TextBox txtShiftID;
        private System.Windows.Forms.Label lblShiftID;
        private System.Windows.Forms.Button btnEditClose;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.Label lblEditShift;
    }
}