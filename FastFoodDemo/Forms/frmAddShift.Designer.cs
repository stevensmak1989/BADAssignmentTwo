
namespace FujitsuPayments.Forms
{
    partial class frmAddShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddShift));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpShiftStartTime = new System.Windows.Forms.DateTimePicker();
            this.cmbShiftSlotCount = new System.Windows.Forms.ComboBox();
            this.lblShiftSlotCount = new System.Windows.Forms.Label();
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.lblAddShift = new System.Windows.Forms.Label();
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 316);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dtpShiftStartTime);
            this.panel2.Controls.Add(this.cmbShiftSlotCount);
            this.panel2.Controls.Add(this.lblShiftSlotCount);
            this.panel2.Controls.Add(this.lblShiftStartTime);
            this.panel2.Controls.Add(this.dtpShiftStartDate);
            this.panel2.Controls.Add(this.lblStartTime);
            this.panel2.Controls.Add(this.cmbTaskId);
            this.panel2.Controls.Add(this.lblTaskId);
            this.panel2.Controls.Add(this.cmbProjectId);
            this.panel2.Controls.Add(this.lblProjectId);
            this.panel2.Controls.Add(this.cmbAccountId);
            this.panel2.Controls.Add(this.txtShiftID);
            this.panel2.Controls.Add(this.lblShiftID);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.lblAccountId);
            this.panel2.Controls.Add(this.lblAddShift);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 316);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dtpShiftStartTime
            // 
            this.dtpShiftStartTime.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpShiftStartTime.Location = new System.Drawing.Point(481, 128);
            this.dtpShiftStartTime.Name = "dtpShiftStartTime";
            this.dtpShiftStartTime.Size = new System.Drawing.Size(115, 26);
            this.dtpShiftStartTime.TabIndex = 30;
            // 
            // cmbShiftSlotCount
            // 
            this.cmbShiftSlotCount.FormattingEnabled = true;
            this.cmbShiftSlotCount.Location = new System.Drawing.Point(133, 159);
            this.cmbShiftSlotCount.Name = "cmbShiftSlotCount";
            this.cmbShiftSlotCount.Size = new System.Drawing.Size(125, 29);
            this.cmbShiftSlotCount.TabIndex = 29;
            // 
            // lblShiftSlotCount
            // 
            this.lblShiftSlotCount.AutoSize = true;
            this.lblShiftSlotCount.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftSlotCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblShiftSlotCount.Location = new System.Drawing.Point(47, 167);
            this.lblShiftSlotCount.Name = "lblShiftSlotCount";
            this.lblShiftSlotCount.Size = new System.Drawing.Size(76, 17);
            this.lblShiftSlotCount.TabIndex = 28;
            this.lblShiftSlotCount.Text = "Slot Count";
            // 
            // lblShiftStartTime
            // 
            this.lblShiftStartTime.AutoSize = true;
            this.lblShiftStartTime.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblShiftStartTime.Location = new System.Drawing.Point(397, 135);
            this.lblShiftStartTime.Name = "lblShiftStartTime";
            this.lblShiftStartTime.Size = new System.Drawing.Size(70, 17);
            this.lblShiftStartTime.TabIndex = 27;
            this.lblShiftStartTime.Text = "Start Time";
            // 
            // dtpShiftStartDate
            // 
            this.dtpShiftStartDate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpShiftStartDate.Location = new System.Drawing.Point(133, 127);
            this.dtpShiftStartDate.Name = "dtpShiftStartDate";
            this.dtpShiftStartDate.Size = new System.Drawing.Size(222, 26);
            this.dtpShiftStartDate.TabIndex = 26;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblStartTime.Location = new System.Drawing.Point(50, 135);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(73, 17);
            this.lblStartTime.TabIndex = 25;
            this.lblStartTime.Text = "Start Date";
            // 
            // cmbTaskId
            // 
            this.cmbTaskId.FormattingEnabled = true;
            this.cmbTaskId.Location = new System.Drawing.Point(481, 93);
            this.cmbTaskId.Name = "cmbTaskId";
            this.cmbTaskId.Size = new System.Drawing.Size(222, 29);
            this.cmbTaskId.TabIndex = 24;
            this.cmbTaskId.SelectedIndexChanged += new System.EventHandler(this.cmbTaskId_SelectedIndexChanged);
            // 
            // lblTaskId
            // 
            this.lblTaskId.AutoSize = true;
            this.lblTaskId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTaskId.Location = new System.Drawing.Point(420, 100);
            this.lblTaskId.Name = "lblTaskId";
            this.lblTaskId.Size = new System.Drawing.Size(51, 17);
            this.lblTaskId.TabIndex = 23;
            this.lblTaskId.Text = "Task ID";
            // 
            // cmbProjectId
            // 
            this.cmbProjectId.FormattingEnabled = true;
            this.cmbProjectId.Location = new System.Drawing.Point(133, 92);
            this.cmbProjectId.Name = "cmbProjectId";
            this.cmbProjectId.Size = new System.Drawing.Size(222, 29);
            this.cmbProjectId.TabIndex = 22;
            this.cmbProjectId.SelectedIndexChanged += new System.EventHandler(this.cmbProjectId_SelectedIndexChanged);
            // 
            // lblProjectId
            // 
            this.lblProjectId.AutoSize = true;
            this.lblProjectId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblProjectId.Location = new System.Drawing.Point(53, 99);
            this.lblProjectId.Name = "lblProjectId";
            this.lblProjectId.Size = new System.Drawing.Size(70, 17);
            this.lblProjectId.TabIndex = 21;
            this.lblProjectId.Text = "Project ID";
            // 
            // cmbAccountId
            // 
            this.cmbAccountId.FormattingEnabled = true;
            this.cmbAccountId.Location = new System.Drawing.Point(481, 58);
            this.cmbAccountId.Name = "cmbAccountId";
            this.cmbAccountId.Size = new System.Drawing.Size(222, 29);
            this.cmbAccountId.TabIndex = 20;
            this.cmbAccountId.SelectedIndexChanged += new System.EventHandler(this.cmbAccountId_SelectedIndexChanged);
            // 
            // txtShiftID
            // 
            this.txtShiftID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShiftID.Location = new System.Drawing.Point(133, 60);
            this.txtShiftID.Name = "txtShiftID";
            this.txtShiftID.Size = new System.Drawing.Size(222, 26);
            this.txtShiftID.TabIndex = 15;
            // 
            // lblShiftID
            // 
            this.lblShiftID.AutoSize = true;
            this.lblShiftID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblShiftID.Location = new System.Drawing.Point(72, 66);
            this.lblShiftID.Name = "lblShiftID";
            this.lblShiftID.Size = new System.Drawing.Size(51, 17);
            this.lblShiftID.TabIndex = 14;
            this.lblShiftID.Text = "Shift ID";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.button2.Location = new System.Drawing.Point(264, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 27);
            this.button2.TabIndex = 13;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.btnSave.Location = new System.Drawing.Point(414, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 27);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblAccountId.Location = new System.Drawing.Point(391, 66);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(80, 17);
            this.lblAccountId.TabIndex = 2;
            this.lblAccountId.Text = "Account ID";
            // 
            // lblAddShift
            // 
            this.lblAddShift.AutoSize = true;
            this.lblAddShift.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddShift.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAddShift.Location = new System.Drawing.Point(272, 22);
            this.lblAddShift.Name = "lblAddShift";
            this.lblAddShift.Size = new System.Drawing.Size(123, 18);
            this.lblAddShift.TabIndex = 1;
            this.lblAddShift.Text = "Add a New Shift";
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // frmAddShift
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(791, 332);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddShift";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddShift";
            this.Load += new System.EventHandler(this.frmAddShift_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtShiftID;
        private System.Windows.Forms.Label lblShiftID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.Label lblAddShift;
        private System.Windows.Forms.DateTimePicker dtpShiftStartTime;
        private System.Windows.Forms.ComboBox cmbShiftSlotCount;
        private System.Windows.Forms.Label lblShiftSlotCount;
        private System.Windows.Forms.Label lblShiftStartTime;
        private System.Windows.Forms.DateTimePicker dtpShiftStartDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.ComboBox cmbTaskId;
        private System.Windows.Forms.Label lblTaskId;
        private System.Windows.Forms.ComboBox cmbProjectId;
        private System.Windows.Forms.Label lblProjectId;
        private System.Windows.Forms.ComboBox cmbAccountId;
    }
}