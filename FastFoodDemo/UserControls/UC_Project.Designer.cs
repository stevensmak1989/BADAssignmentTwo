
namespace FujitsuPayments.UserControls
{
    partial class UC_Project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Project));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProjectView = new System.Windows.Forms.Button();
            this.btnProjectDel = new System.Windows.Forms.Button();
            this.btnProjectEdit = new System.Windows.Forms.Button();
            this.btnProjectAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dvgProject = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 360);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(758, 91);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnProjectView);
            this.panel1.Controls.Add(this.btnProjectDel);
            this.panel1.Controls.Add(this.btnProjectEdit);
            this.panel1.Controls.Add(this.btnProjectAdd);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 42);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnProjectView
            // 
            this.btnProjectView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProjectView.FlatAppearance.BorderSize = 0;
            this.btnProjectView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnProjectView.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectView.Image")));
            this.btnProjectView.Location = new System.Drawing.Point(488, 0);
            this.btnProjectView.Name = "btnProjectView";
            this.btnProjectView.Size = new System.Drawing.Size(163, 42);
            this.btnProjectView.TabIndex = 3;
            this.btnProjectView.Text = "View Project";
            this.btnProjectView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProjectView.UseVisualStyleBackColor = true;
            // 
            // btnProjectDel
            // 
            this.btnProjectDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProjectDel.FlatAppearance.BorderSize = 0;
            this.btnProjectDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnProjectDel.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectDel.Image")));
            this.btnProjectDel.Location = new System.Drawing.Point(321, 0);
            this.btnProjectDel.Name = "btnProjectDel";
            this.btnProjectDel.Size = new System.Drawing.Size(167, 42);
            this.btnProjectDel.TabIndex = 2;
            this.btnProjectDel.Text = "Delete Project";
            this.btnProjectDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProjectDel.UseVisualStyleBackColor = true;
            this.btnProjectDel.Click += new System.EventHandler(this.btnProjectDel_Click);
            // 
            // btnProjectEdit
            // 
            this.btnProjectEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProjectEdit.FlatAppearance.BorderSize = 0;
            this.btnProjectEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnProjectEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectEdit.Image")));
            this.btnProjectEdit.Location = new System.Drawing.Point(158, 0);
            this.btnProjectEdit.Name = "btnProjectEdit";
            this.btnProjectEdit.Size = new System.Drawing.Size(163, 42);
            this.btnProjectEdit.TabIndex = 1;
            this.btnProjectEdit.Text = "Edit Project";
            this.btnProjectEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProjectEdit.UseVisualStyleBackColor = true;
            this.btnProjectEdit.Click += new System.EventHandler(this.btnProjectEdit_Click);
            // 
            // btnProjectAdd
            // 
            this.btnProjectAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProjectAdd.FlatAppearance.BorderSize = 0;
            this.btnProjectAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnProjectAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectAdd.Image")));
            this.btnProjectAdd.Location = new System.Drawing.Point(0, 0);
            this.btnProjectAdd.Name = "btnProjectAdd";
            this.btnProjectAdd.Size = new System.Drawing.Size(158, 42);
            this.btnProjectAdd.TabIndex = 0;
            this.btnProjectAdd.Text = "Add Project";
            this.btnProjectAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProjectAdd.UseVisualStyleBackColor = true;
            this.btnProjectAdd.Click += new System.EventHandler(this.btnProjectAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dvgProject);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 451);
            this.panel2.TabIndex = 7;
            // 
            // dvgProject
            // 
            this.dvgProject.AllowUserToAddRows = false;
            this.dvgProject.AllowUserToDeleteRows = false;
            this.dvgProject.BackgroundColor = System.Drawing.Color.Silver;
            this.dvgProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgProject.DefaultCellStyle = dataGridViewCellStyle1;
            this.dvgProject.Location = new System.Drawing.Point(3, 48);
            this.dvgProject.Name = "dvgProject";
            this.dvgProject.ReadOnly = true;
            this.dvgProject.Size = new System.Drawing.Size(1087, 477);
            this.dvgProject.TabIndex = 0;
            this.dvgProject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgProject_CellContentClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UC_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "UC_Project";
            this.Size = new System.Drawing.Size(758, 451);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProjectView;
        private System.Windows.Forms.Button btnProjectDel;
        private System.Windows.Forms.Button btnProjectEdit;
        private System.Windows.Forms.Button btnProjectAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dvgProject;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
