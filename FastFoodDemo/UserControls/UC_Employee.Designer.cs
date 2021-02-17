
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Employee));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEmployeeView = new System.Windows.Forms.Button();
            this.btnEmployeeDel = new System.Windows.Forms.Button();
            this.btnEmployeeEdit = new System.Windows.Forms.Button();
            this.btnEmployeeAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dvgEmployee = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnEmployeeView);
            this.panel1.Controls.Add(this.btnEmployeeDel);
            this.panel1.Controls.Add(this.btnEmployeeEdit);
            this.panel1.Controls.Add(this.btnEmployeeAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 42);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnEmployeeView
            // 
            this.btnEmployeeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmployeeView.FlatAppearance.BorderSize = 0;
            this.btnEmployeeView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeView.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmployeeView.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeView.Image")));
            this.btnEmployeeView.Location = new System.Drawing.Point(488, 0);
            this.btnEmployeeView.Name = "btnEmployeeView";
            this.btnEmployeeView.Size = new System.Drawing.Size(163, 42);
            this.btnEmployeeView.TabIndex = 3;
            this.btnEmployeeView.Text = "View Employee";
            this.btnEmployeeView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployeeView.UseVisualStyleBackColor = true;
            // 
            // btnEmployeeDel
            // 
            this.btnEmployeeDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmployeeDel.FlatAppearance.BorderSize = 0;
            this.btnEmployeeDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeDel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmployeeDel.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeDel.Image")));
            this.btnEmployeeDel.Location = new System.Drawing.Point(321, 0);
            this.btnEmployeeDel.Name = "btnEmployeeDel";
            this.btnEmployeeDel.Size = new System.Drawing.Size(167, 42);
            this.btnEmployeeDel.TabIndex = 2;
            this.btnEmployeeDel.Text = "Delete Employee";
            this.btnEmployeeDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployeeDel.UseVisualStyleBackColor = true;
            // 
            // btnEmployeeEdit
            // 
            this.btnEmployeeEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmployeeEdit.FlatAppearance.BorderSize = 0;
            this.btnEmployeeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeEdit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmployeeEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeEdit.Image")));
            this.btnEmployeeEdit.Location = new System.Drawing.Point(158, 0);
            this.btnEmployeeEdit.Name = "btnEmployeeEdit";
            this.btnEmployeeEdit.Size = new System.Drawing.Size(163, 42);
            this.btnEmployeeEdit.TabIndex = 1;
            this.btnEmployeeEdit.Text = "Edit Employee";
            this.btnEmployeeEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployeeEdit.UseVisualStyleBackColor = true;
            // 
            // btnEmployeeAdd
            // 
            this.btnEmployeeAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmployeeAdd.FlatAppearance.BorderSize = 0;
            this.btnEmployeeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dvgEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgEmployee.Location = new System.Drawing.Point(0, 0);
            this.dvgEmployee.Name = "dvgEmployee";
            this.dvgEmployee.ReadOnly = true;
            this.dvgEmployee.Size = new System.Drawing.Size(1090, 525);
            this.dvgEmployee.TabIndex = 0;
            this.dvgEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 525);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1090, 91);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // UC_Employee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_Employee";
            this.Size = new System.Drawing.Size(1090, 616);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEmployeeView;
        private System.Windows.Forms.Button btnEmployeeDel;
        private System.Windows.Forms.Button btnEmployeeEdit;
        private System.Windows.Forms.Button btnEmployeeAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dvgEmployee;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
