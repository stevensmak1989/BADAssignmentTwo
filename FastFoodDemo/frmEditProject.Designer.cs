﻿
namespace FujitsuPayments.Forms
{
    partial class frmEditProject
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
            this.lblPrjIDEdit = new System.Windows.Forms.Label();
            this.lblProjectIdEdit = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtlblBankHolEdit = new System.Windows.Forms.TextBox();
            this.lblBankHolAdd = new System.Windows.Forms.Label();
            this.txtAddManagerID = new System.Windows.Forms.TextBox();
            this.lblAddManagerId = new System.Windows.Forms.Label();
            this.lblProjDesc = new System.Windows.Forms.Label();
            this.cmbAccountId = new System.Windows.Forms.ComboBox();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.txtBasicEdit = new System.Windows.Forms.TextBox();
            this.lblB8Rate = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtOvertimeEdit = new System.Windows.Forms.TextBox();
            this.txtCappedhoursEdit = new System.Windows.Forms.TextBox();
            this.lblOvertimeAdd = new System.Windows.Forms.Label();
            this.txtProjDesc = new System.Windows.Forms.TextBox();
            this.lblCappedHoursAdd = new System.Windows.Forms.Label();
            this.btnEmpClose = new System.Windows.Forms.Button();
            this.btnPrjSave = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrjIDEdit
            // 
            this.lblPrjIDEdit.AutoSize = true;
            this.lblPrjIDEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrjIDEdit.Location = new System.Drawing.Point(161, 34);
            this.lblPrjIDEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrjIDEdit.Name = "lblPrjIDEdit";
            this.lblPrjIDEdit.Size = new System.Drawing.Size(13, 18);
            this.lblPrjIDEdit.TabIndex = 48;
            this.lblPrjIDEdit.Text = "-";
            // 
            // lblProjectIdEdit
            // 
            this.lblProjectIdEdit.AutoSize = true;
            this.lblProjectIdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectIdEdit.Location = new System.Drawing.Point(36, 34);
            this.lblProjectIdEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjectIdEdit.Name = "lblProjectIdEdit";
            this.lblProjectIdEdit.Size = new System.Drawing.Size(73, 18);
            this.lblProjectIdEdit.TabIndex = 46;
            this.lblProjectIdEdit.Text = "Project ID";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(462, 31);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(106, 26);
            this.dtpStartDate.TabIndex = 45;
            this.dtpStartDate.Value = new System.DateTime(2021, 2, 26, 0, 0, 0, 0);
            // 
            // txtlblBankHolEdit
            // 
            this.txtlblBankHolEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlblBankHolEdit.Location = new System.Drawing.Point(462, 225);
            this.txtlblBankHolEdit.Margin = new System.Windows.Forms.Padding(4);
            this.txtlblBankHolEdit.Name = "txtlblBankHolEdit";
            this.txtlblBankHolEdit.Size = new System.Drawing.Size(115, 26);
            this.txtlblBankHolEdit.TabIndex = 43;
            // 
            // lblBankHolAdd
            // 
            this.lblBankHolAdd.AutoSize = true;
            this.lblBankHolAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankHolAdd.Location = new System.Drawing.Point(346, 229);
            this.lblBankHolAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBankHolAdd.Name = "lblBankHolAdd";
            this.lblBankHolAdd.Size = new System.Drawing.Size(95, 18);
            this.lblBankHolAdd.TabIndex = 42;
            this.lblBankHolAdd.Text = "Bank Holiday";
            // 
            // txtAddManagerID
            // 
            this.txtAddManagerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddManagerID.Location = new System.Drawing.Point(164, 355);
            this.txtAddManagerID.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddManagerID.Name = "txtAddManagerID";
            this.txtAddManagerID.Size = new System.Drawing.Size(106, 26);
            this.txtAddManagerID.TabIndex = 41;
            // 
            // lblAddManagerId
            // 
            this.lblAddManagerId.AutoSize = true;
            this.lblAddManagerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddManagerId.Location = new System.Drawing.Point(33, 350);
            this.lblAddManagerId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddManagerId.Name = "lblAddManagerId";
            this.lblAddManagerId.Size = new System.Drawing.Size(84, 18);
            this.lblAddManagerId.TabIndex = 40;
            this.lblAddManagerId.Text = "Manager ID";
            // 
            // lblProjDesc
            // 
            this.lblProjDesc.AutoSize = true;
            this.lblProjDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjDesc.Location = new System.Drawing.Point(33, 128);
            this.lblProjDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjDesc.Name = "lblProjDesc";
            this.lblProjDesc.Size = new System.Drawing.Size(94, 18);
            this.lblProjDesc.TabIndex = 38;
            this.lblProjDesc.Text = "Project Desc";
            // 
            // cmbAccountId
            // 
            this.cmbAccountId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccountId.FormattingEnabled = true;
            this.cmbAccountId.Location = new System.Drawing.Point(164, 72);
            this.cmbAccountId.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAccountId.Name = "cmbAccountId";
            this.cmbAccountId.Size = new System.Drawing.Size(115, 28);
            this.cmbAccountId.TabIndex = 37;
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.Location = new System.Drawing.Point(33, 70);
            this.lblAccountID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(80, 18);
            this.lblAccountID.TabIndex = 36;
            this.lblAccountID.Text = "Account ID";
            // 
            // txtBasicEdit
            // 
            this.txtBasicEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBasicEdit.Location = new System.Drawing.Point(462, 177);
            this.txtBasicEdit.Margin = new System.Windows.Forms.Padding(4);
            this.txtBasicEdit.Name = "txtBasicEdit";
            this.txtBasicEdit.Size = new System.Drawing.Size(115, 26);
            this.txtBasicEdit.TabIndex = 35;
            // 
            // lblB8Rate
            // 
            this.lblB8Rate.AutoSize = true;
            this.lblB8Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB8Rate.Location = new System.Drawing.Point(346, 181);
            this.lblB8Rate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblB8Rate.Name = "lblB8Rate";
            this.lblB8Rate.Size = new System.Drawing.Size(80, 18);
            this.lblB8Rate.TabIndex = 34;
            this.lblB8Rate.Text = "Basic Rate";
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(462, 74);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(4);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(115, 26);
            this.txtDuration.TabIndex = 29;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(346, 78);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(64, 18);
            this.lblDuration.TabIndex = 28;
            this.lblDuration.Text = "Duration";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(346, 39);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(74, 18);
            this.lblStartDate.TabIndex = 26;
            this.lblStartDate.Text = "Start Date";
            // 
            // txtOvertimeEdit
            // 
            this.txtOvertimeEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOvertimeEdit.Location = new System.Drawing.Point(164, 221);
            this.txtOvertimeEdit.Margin = new System.Windows.Forms.Padding(4);
            this.txtOvertimeEdit.Name = "txtOvertimeEdit";
            this.txtOvertimeEdit.Size = new System.Drawing.Size(106, 26);
            this.txtOvertimeEdit.TabIndex = 25;
            // 
            // txtCappedhoursEdit
            // 
            this.txtCappedhoursEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCappedhoursEdit.Location = new System.Drawing.Point(164, 177);
            this.txtCappedhoursEdit.Margin = new System.Windows.Forms.Padding(4);
            this.txtCappedhoursEdit.Name = "txtCappedhoursEdit";
            this.txtCappedhoursEdit.Size = new System.Drawing.Size(106, 26);
            this.txtCappedhoursEdit.TabIndex = 23;
            // 
            // lblOvertimeAdd
            // 
            this.lblOvertimeAdd.AutoSize = true;
            this.lblOvertimeAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOvertimeAdd.Location = new System.Drawing.Point(33, 225);
            this.lblOvertimeAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOvertimeAdd.Name = "lblOvertimeAdd";
            this.lblOvertimeAdd.Size = new System.Drawing.Size(68, 18);
            this.lblOvertimeAdd.TabIndex = 22;
            this.lblOvertimeAdd.Text = "Overtime";
            // 
            // txtProjDesc
            // 
            this.txtProjDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjDesc.Location = new System.Drawing.Point(164, 124);
            this.txtProjDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtProjDesc.Name = "txtProjDesc";
            this.txtProjDesc.Size = new System.Drawing.Size(413, 26);
            this.txtProjDesc.TabIndex = 21;
            // 
            // lblCappedHoursAdd
            // 
            this.lblCappedHoursAdd.AutoSize = true;
            this.lblCappedHoursAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCappedHoursAdd.Location = new System.Drawing.Point(33, 181);
            this.lblCappedHoursAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCappedHoursAdd.Name = "lblCappedHoursAdd";
            this.lblCappedHoursAdd.Size = new System.Drawing.Size(104, 18);
            this.lblCappedHoursAdd.TabIndex = 20;
            this.lblCappedHoursAdd.Text = "Capped Hours";
            // 
            // btnEmpClose
            // 
            this.btnEmpClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpClose.FlatAppearance.BorderSize = 2;
            this.btnEmpClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmpClose.Location = new System.Drawing.Point(195, 291);
            this.btnEmpClose.Name = "btnEmpClose";
            this.btnEmpClose.Size = new System.Drawing.Size(125, 31);
            this.btnEmpClose.TabIndex = 13;
            this.btnEmpClose.Text = "Close";
            this.btnEmpClose.UseVisualStyleBackColor = true;
            // 
            // btnPrjSave
            // 
            this.btnPrjSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrjSave.FlatAppearance.BorderSize = 2;
            this.btnPrjSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrjSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.btnPrjSave.Location = new System.Drawing.Point(339, 291);
            this.btnPrjSave.Name = "btnPrjSave";
            this.btnPrjSave.Size = new System.Drawing.Size(130, 31);
            this.btnPrjSave.TabIndex = 12;
            this.btnPrjSave.Text = "Save";
            this.btnPrjSave.UseVisualStyleBackColor = true;
            this.btnPrjSave.Click += new System.EventHandler(this.btnPrjSave_Click);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbltitle.Location = new System.Drawing.Point(204, 1);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(154, 25);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "Edit a Project";
            this.lbltitle.Click += new System.EventHandler(this.lbltitle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblPrjIDEdit);
            this.panel1.Controls.Add(this.lblProjectIdEdit);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.txtlblBankHolEdit);
            this.panel1.Controls.Add(this.lblBankHolAdd);
            this.panel1.Controls.Add(this.txtAddManagerID);
            this.panel1.Controls.Add(this.lblAddManagerId);
            this.panel1.Controls.Add(this.lblProjDesc);
            this.panel1.Controls.Add(this.cmbAccountId);
            this.panel1.Controls.Add(this.lblAccountID);
            this.panel1.Controls.Add(this.txtBasicEdit);
            this.panel1.Controls.Add(this.lblB8Rate);
            this.panel1.Controls.Add(this.txtDuration);
            this.panel1.Controls.Add(this.lblDuration);
            this.panel1.Controls.Add(this.lblStartDate);
            this.panel1.Controls.Add(this.txtOvertimeEdit);
            this.panel1.Controls.Add(this.txtCappedhoursEdit);
            this.panel1.Controls.Add(this.lblOvertimeAdd);
            this.panel1.Controls.Add(this.txtProjDesc);
            this.panel1.Controls.Add(this.lblCappedHoursAdd);
            this.panel1.Controls.Add(this.btnEmpClose);
            this.panel1.Controls.Add(this.btnPrjSave);
            this.panel1.Controls.Add(this.lbltitle);
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 335);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // frmEditProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(653, 351);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditProject";
            this.Load += new System.EventHandler(this.frmEditProject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPrjIDEdit;
        private System.Windows.Forms.Label lblProjectIdEdit;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtlblBankHolEdit;
        private System.Windows.Forms.Label lblBankHolAdd;
        private System.Windows.Forms.TextBox txtAddManagerID;
        private System.Windows.Forms.Label lblAddManagerId;
        private System.Windows.Forms.Label lblProjDesc;
        private System.Windows.Forms.ComboBox cmbAccountId;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.TextBox txtBasicEdit;
        private System.Windows.Forms.Label lblB8Rate;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtOvertimeEdit;
        private System.Windows.Forms.TextBox txtCappedhoursEdit;
        private System.Windows.Forms.Label lblOvertimeAdd;
        private System.Windows.Forms.TextBox txtProjDesc;
        private System.Windows.Forms.Label lblCappedHoursAdd;
        private System.Windows.Forms.Button btnEmpClose;
        private System.Windows.Forms.Button btnPrjSave;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errP;
    }
}