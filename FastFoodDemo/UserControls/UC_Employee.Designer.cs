﻿
namespace FujitsuPayments.UserControls
{
    partial class UC_Employee
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Employee));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEmployeeDel = new System.Windows.Forms.Button();
            this.btnEmployeeEdit = new System.Windows.Forms.Button();
            this.btnEmployeeAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dvgEmployee = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnEmployeeDel);
            this.panel1.Controls.Add(this.btnEmployeeEdit);
            this.panel1.Controls.Add(this.btnEmployeeAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 42);
            this.panel1.TabIndex = 3;
           
            // 
            // btnEmployeeDel
            // 
            this.btnEmployeeDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmployeeDel.FlatAppearance.BorderSize = 0;
            this.btnEmployeeDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnEmployeeDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmployeeDel.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeDel.Image")));
            this.btnEmployeeDel.Location = new System.Drawing.Point(321, 0);
            this.btnEmployeeDel.Name = "btnEmployeeDel";
            this.btnEmployeeDel.Size = new System.Drawing.Size(167, 42);
            this.btnEmployeeDel.TabIndex = 2;
            this.btnEmployeeDel.Text = "Delete Employee";
            this.btnEmployeeDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployeeDel.UseVisualStyleBackColor = true;
            this.btnEmployeeDel.Click += new System.EventHandler(this.btnEmployeeDel_Click);
            // 
            // btnEmployeeEdit
            // 
            this.btnEmployeeEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmployeeEdit.FlatAppearance.BorderSize = 0;
            this.btnEmployeeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnEmployeeEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmployeeEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeEdit.Image")));
            this.btnEmployeeEdit.Location = new System.Drawing.Point(158, 0);
            this.btnEmployeeEdit.Name = "btnEmployeeEdit";
            this.btnEmployeeEdit.Size = new System.Drawing.Size(163, 42);
            this.btnEmployeeEdit.TabIndex = 1;
            this.btnEmployeeEdit.Text = "Edit Employee";
            this.btnEmployeeEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployeeEdit.UseVisualStyleBackColor = true;
            this.btnEmployeeEdit.Click += new System.EventHandler(this.btnEmployeeEdit_Click);
            // 
            // btnEmployeeAdd
            // 
            this.btnEmployeeAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmployeeAdd.FlatAppearance.BorderSize = 0;
            this.btnEmployeeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnEmployeeAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmployeeAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeAdd.Image")));
            this.btnEmployeeAdd.Location = new System.Drawing.Point(0, 0);
            this.btnEmployeeAdd.Name = "btnEmployeeAdd";
            this.btnEmployeeAdd.Size = new System.Drawing.Size(158, 42);
            this.btnEmployeeAdd.TabIndex = 0;
            this.btnEmployeeAdd.Text = "Add Employee";
            this.btnEmployeeAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployeeAdd.UseVisualStyleBackColor = true;
            this.btnEmployeeAdd.Click += new System.EventHandler(this.btnEmployeeAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dvgEmployee);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1090, 525);
            this.panel2.TabIndex = 5;
            // 
            // dvgEmployee
            // 
            this.dvgEmployee.AllowUserToAddRows = false;
            this.dvgEmployee.AllowUserToDeleteRows = false;
            this.dvgEmployee.BackgroundColor = System.Drawing.Color.Silver;
            this.dvgEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgEmployee.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgEmployee.Location = new System.Drawing.Point(3, 37);
            this.dvgEmployee.Name = "dvgEmployee";
            this.dvgEmployee.ReadOnly = true;
            this.dvgEmployee.Size = new System.Drawing.Size(1087, 488);
            this.dvgEmployee.TabIndex = 0;
            
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 525);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1090, 91);
            this.flowLayoutPanel1.TabIndex = 4;
            
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(488, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(163, 42);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UC_Employee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_Employee";
            this.Size = new System.Drawing.Size(1090, 616);
            this.Load += new System.EventHandler(this.UC_Employee__Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEmployeeDel;
        private System.Windows.Forms.Button btnEmployeeEdit;
        private System.Windows.Forms.Button btnEmployeeAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dvgEmployee;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnRefresh;
    }
}
