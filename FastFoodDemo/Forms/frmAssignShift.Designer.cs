
namespace FujitsuPayments.Forms
{
    partial class frmAssignShift
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
            this.btnAssignClose = new System.Windows.Forms.Button();
            this.btnAssignSave = new System.Windows.Forms.Button();
            this.lblAssignShift = new System.Windows.Forms.Label();
            this.cmbEmployeeID = new System.Windows.Forms.ComboBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.txtProjectID = new System.Windows.Forms.TextBox();
            this.lblTaskId = new System.Windows.Forms.Label();
            this.lblProjectId = new System.Windows.Forms.Label();
            this.txtAssignShiftID = new System.Windows.Forms.TextBox();
            this.lblShiftID = new System.Windows.Forms.Label();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnAssignClose);
            this.panel1.Controls.Add(this.btnAssignSave);
            this.panel1.Controls.Add(this.lblAssignShift);
            this.panel1.Controls.Add(this.cmbEmployeeID);
            this.panel1.Controls.Add(this.lblEmployeeID);
            this.panel1.Controls.Add(this.txtTaskID);
            this.panel1.Controls.Add(this.txtAccountID);
            this.panel1.Controls.Add(this.txtProjectID);
            this.panel1.Controls.Add(this.lblTaskId);
            this.panel1.Controls.Add(this.lblProjectId);
            this.panel1.Controls.Add(this.txtAssignShiftID);
            this.panel1.Controls.Add(this.lblShiftID);
            this.panel1.Controls.Add(this.lblAccountId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 287);
            this.panel1.TabIndex = 0;
            // 
            // btnAssignClose
            // 
            this.btnAssignClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignClose.FlatAppearance.BorderSize = 2;
            this.btnAssignClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnAssignClose.Location = new System.Drawing.Point(278, 214);
            this.btnAssignClose.Name = "btnAssignClose";
            this.btnAssignClose.Size = new System.Drawing.Size(97, 27);
            this.btnAssignClose.TabIndex = 56;
            this.btnAssignClose.Text = "Close";
            this.btnAssignClose.UseVisualStyleBackColor = true;
            this.btnAssignClose.Click += new System.EventHandler(this.btnAssignClose_Click);
            // 
            // btnAssignSave
            // 
            this.btnAssignSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignSave.FlatAppearance.BorderSize = 2;
            this.btnAssignSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.btnAssignSave.Location = new System.Drawing.Point(428, 214);
            this.btnAssignSave.Name = "btnAssignSave";
            this.btnAssignSave.Size = new System.Drawing.Size(97, 27);
            this.btnAssignSave.TabIndex = 55;
            this.btnAssignSave.Text = "Save";
            this.btnAssignSave.UseVisualStyleBackColor = true;
            this.btnAssignSave.Click += new System.EventHandler(this.btnAssignSave_Click);
            // 
            // lblAssignShift
            // 
            this.lblAssignShift.AutoSize = true;
            this.lblAssignShift.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignShift.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAssignShift.Location = new System.Drawing.Point(368, 28);
            this.lblAssignShift.Name = "lblAssignShift";
            this.lblAssignShift.Size = new System.Drawing.Size(87, 18);
            this.lblAssignShift.TabIndex = 54;
            this.lblAssignShift.Text = "Assign Shift";
            // 
            // cmbEmployeeID
            // 
            this.cmbEmployeeID.FormattingEnabled = true;
            this.cmbEmployeeID.Location = new System.Drawing.Point(153, 145);
            this.cmbEmployeeID.Name = "cmbEmployeeID";
            this.cmbEmployeeID.Size = new System.Drawing.Size(222, 29);
            this.cmbEmployeeID.TabIndex = 53;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblEmployeeID.Location = new System.Drawing.Point(59, 152);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(88, 17);
            this.lblEmployeeID.TabIndex = 52;
            this.lblEmployeeID.Text = "Employee ID";
            // 
            // txtTaskID
            // 
            this.txtTaskID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskID.Location = new System.Drawing.Point(497, 106);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(222, 26);
            this.txtTaskID.TabIndex = 51;
            // 
            // txtAccountID
            // 
            this.txtAccountID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountID.Location = new System.Drawing.Point(497, 66);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(222, 26);
            this.txtAccountID.TabIndex = 50;
            // 
            // txtProjectID
            // 
            this.txtProjectID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectID.Location = new System.Drawing.Point(153, 105);
            this.txtProjectID.Name = "txtProjectID";
            this.txtProjectID.Size = new System.Drawing.Size(222, 26);
            this.txtProjectID.TabIndex = 49;
            // 
            // lblTaskId
            // 
            this.lblTaskId.AutoSize = true;
            this.lblTaskId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTaskId.Location = new System.Drawing.Point(453, 112);
            this.lblTaskId.Name = "lblTaskId";
            this.lblTaskId.Size = new System.Drawing.Size(38, 17);
            this.lblTaskId.TabIndex = 48;
            this.lblTaskId.Text = "Task ";
            // 
            // lblProjectId
            // 
            this.lblProjectId.AutoSize = true;
            this.lblProjectId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblProjectId.Location = new System.Drawing.Point(94, 112);
            this.lblProjectId.Name = "lblProjectId";
            this.lblProjectId.Size = new System.Drawing.Size(53, 17);
            this.lblProjectId.TabIndex = 46;
            this.lblProjectId.Text = "Project";
            // 
            // txtAssignShiftID
            // 
            this.txtAssignShiftID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssignShiftID.Location = new System.Drawing.Point(153, 66);
            this.txtAssignShiftID.Name = "txtAssignShiftID";
            this.txtAssignShiftID.Size = new System.Drawing.Size(222, 26);
            this.txtAssignShiftID.TabIndex = 44;
            // 
            // lblShiftID
            // 
            this.lblShiftID.AutoSize = true;
            this.lblShiftID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblShiftID.Location = new System.Drawing.Point(96, 72);
            this.lblShiftID.Name = "lblShiftID";
            this.lblShiftID.Size = new System.Drawing.Size(51, 17);
            this.lblShiftID.TabIndex = 43;
            this.lblShiftID.Text = "Shift ID";
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblAccountId.Location = new System.Drawing.Point(428, 72);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(63, 17);
            this.lblAccountId.TabIndex = 42;
            this.lblAccountId.Text = "Account";
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // frmAssignShift
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(830, 303);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmAssignShift";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAssignShift";
            this.Load += new System.EventHandler(this.frmAssignShift_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTaskId;
        private System.Windows.Forms.Label lblProjectId;
        private System.Windows.Forms.TextBox txtAssignShiftID;
        private System.Windows.Forms.Label lblShiftID;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.TextBox txtProjectID;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.ComboBox cmbEmployeeID;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Label lblAssignShift;
        private System.Windows.Forms.Button btnAssignClose;
        private System.Windows.Forms.Button btnAssignSave;
        private System.Windows.Forms.ErrorProvider errP;
    }
}