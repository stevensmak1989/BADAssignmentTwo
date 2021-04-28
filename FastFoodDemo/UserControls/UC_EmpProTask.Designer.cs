
namespace FujitsuPayments.UserControls
{
    partial class UC_EmpProTask
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_EmpProTask));
            this.dvgEmpTask = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEmpTaskDel = new System.Windows.Forms.Button();
            this.btnEmpTaskEdit = new System.Windows.Forms.Button();
            this.btnEmpTaskAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpTask)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgEmpTask
            // 
            this.dvgEmpTask.AllowUserToAddRows = false;
            this.dvgEmpTask.AllowUserToDeleteRows = false;
            this.dvgEmpTask.BackgroundColor = System.Drawing.Color.Silver;
            this.dvgEmpTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgEmpTask.DefaultCellStyle = dataGridViewCellStyle1;
            this.dvgEmpTask.Location = new System.Drawing.Point(3, 48);
            this.dvgEmpTask.Name = "dvgEmpTask";
            this.dvgEmpTask.ReadOnly = true;
            this.dvgEmpTask.Size = new System.Drawing.Size(1087, 477);
            this.dvgEmpTask.TabIndex = 0;
            
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 386);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1087, 91);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnEmpTaskDel);
            this.panel1.Controls.Add(this.btnEmpTaskEdit);
            this.panel1.Controls.Add(this.btnEmpTaskAdd);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 42);
            this.panel1.TabIndex = 3;
           
            // 
            // btnEmpTaskDel
            // 
            this.btnEmpTaskDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmpTaskDel.FlatAppearance.BorderSize = 0;
            this.btnEmpTaskDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpTaskDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnEmpTaskDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmpTaskDel.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpTaskDel.Image")));
            this.btnEmpTaskDel.Location = new System.Drawing.Point(321, 0);
            this.btnEmpTaskDel.Name = "btnEmpTaskDel";
            this.btnEmpTaskDel.Size = new System.Drawing.Size(167, 42);
            this.btnEmpTaskDel.TabIndex = 2;
            this.btnEmpTaskDel.Text = "Del Employee Task";
            this.btnEmpTaskDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmpTaskDel.UseVisualStyleBackColor = true;
            this.btnEmpTaskDel.Click += new System.EventHandler(this.btnEmpTaskDel_Click);
            // 
            // btnEmpTaskEdit
            // 
            this.btnEmpTaskEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmpTaskEdit.FlatAppearance.BorderSize = 0;
            this.btnEmpTaskEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpTaskEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnEmpTaskEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmpTaskEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpTaskEdit.Image")));
            this.btnEmpTaskEdit.Location = new System.Drawing.Point(158, 0);
            this.btnEmpTaskEdit.Name = "btnEmpTaskEdit";
            this.btnEmpTaskEdit.Size = new System.Drawing.Size(163, 42);
            this.btnEmpTaskEdit.TabIndex = 1;
            this.btnEmpTaskEdit.Text = "Edit Employee Task";
            this.btnEmpTaskEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmpTaskEdit.UseVisualStyleBackColor = true;
            this.btnEmpTaskEdit.Click += new System.EventHandler(this.btnEmpTaskEdit_Click);
            // 
            // btnEmpTaskAdd
            // 
            this.btnEmpTaskAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmpTaskAdd.FlatAppearance.BorderSize = 0;
            this.btnEmpTaskAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpTaskAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnEmpTaskAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmpTaskAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpTaskAdd.Image")));
            this.btnEmpTaskAdd.Location = new System.Drawing.Point(0, 0);
            this.btnEmpTaskAdd.Name = "btnEmpTaskAdd";
            this.btnEmpTaskAdd.Size = new System.Drawing.Size(158, 42);
            this.btnEmpTaskAdd.TabIndex = 0;
            this.btnEmpTaskAdd.Text = "Add Employee Task";
            this.btnEmpTaskAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmpTaskAdd.UseVisualStyleBackColor = true;
            this.btnEmpTaskAdd.Click += new System.EventHandler(this.btnEmpTaskAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dvgEmpTask);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 477);
            this.panel2.TabIndex = 9;
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
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UC_EmpProTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "UC_EmpProTask";
            this.Size = new System.Drawing.Size(1087, 477);
            this.Load += new System.EventHandler(this.UC_EmpProTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgEmpTask)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgEmpTask;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEmpTaskDel;
        private System.Windows.Forms.Button btnEmpTaskEdit;
        private System.Windows.Forms.Button btnEmpTaskAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnRefresh;
    }
}
