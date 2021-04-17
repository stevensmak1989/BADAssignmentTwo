
namespace FujitsuPayments.UserControls
{
    partial class UC_Task
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Task));
            this.dvgTask = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTaskView = new System.Windows.Forms.Button();
            this.btnTaskDel = new System.Windows.Forms.Button();
            this.btnTaskEdit = new System.Windows.Forms.Button();
            this.btnTaskAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTask)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgTask
            // 
            this.dvgTask.AllowUserToAddRows = false;
            this.dvgTask.AllowUserToDeleteRows = false;
            this.dvgTask.BackgroundColor = System.Drawing.Color.Silver;
            this.dvgTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgTask.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgTask.Location = new System.Drawing.Point(3, 48);
            this.dvgTask.Name = "dvgTask";
            this.dvgTask.ReadOnly = true;
            this.dvgTask.Size = new System.Drawing.Size(1081, 332);
            this.dvgTask.TabIndex = 0;
            this.dvgTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgTask_CellContentClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 386);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1087, 91);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnTaskView);
            this.panel1.Controls.Add(this.btnTaskDel);
            this.panel1.Controls.Add(this.btnTaskEdit);
            this.panel1.Controls.Add(this.btnTaskAdd);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 42);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnTaskView
            // 
            this.btnTaskView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTaskView.FlatAppearance.BorderSize = 0;
            this.btnTaskView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnTaskView.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskView.Image")));
            this.btnTaskView.Location = new System.Drawing.Point(488, 0);
            this.btnTaskView.Name = "btnTaskView";
            this.btnTaskView.Size = new System.Drawing.Size(163, 42);
            this.btnTaskView.TabIndex = 3;
            this.btnTaskView.Text = "View Task";
            this.btnTaskView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaskView.UseVisualStyleBackColor = true;
            // 
            // btnTaskDel
            // 
            this.btnTaskDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTaskDel.FlatAppearance.BorderSize = 0;
            this.btnTaskDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnTaskDel.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskDel.Image")));
            this.btnTaskDel.Location = new System.Drawing.Point(321, 0);
            this.btnTaskDel.Name = "btnTaskDel";
            this.btnTaskDel.Size = new System.Drawing.Size(167, 42);
            this.btnTaskDel.TabIndex = 2;
            this.btnTaskDel.Text = "Delete Task";
            this.btnTaskDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaskDel.UseVisualStyleBackColor = true;
            this.btnTaskDel.Click += new System.EventHandler(this.btnTaskDel_Click);
            // 
            // btnTaskEdit
            // 
            this.btnTaskEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTaskEdit.FlatAppearance.BorderSize = 0;
            this.btnTaskEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnTaskEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskEdit.Image")));
            this.btnTaskEdit.Location = new System.Drawing.Point(158, 0);
            this.btnTaskEdit.Name = "btnTaskEdit";
            this.btnTaskEdit.Size = new System.Drawing.Size(163, 42);
            this.btnTaskEdit.TabIndex = 1;
            this.btnTaskEdit.Text = "Edit Task";
            this.btnTaskEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaskEdit.UseVisualStyleBackColor = true;
            this.btnTaskEdit.Click += new System.EventHandler(this.btnTaskEdit_Click);
            // 
            // btnTaskAdd
            // 
            this.btnTaskAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTaskAdd.FlatAppearance.BorderSize = 0;
            this.btnTaskAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnTaskAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskAdd.Image")));
            this.btnTaskAdd.Location = new System.Drawing.Point(0, 0);
            this.btnTaskAdd.Name = "btnTaskAdd";
            this.btnTaskAdd.Size = new System.Drawing.Size(158, 42);
            this.btnTaskAdd.TabIndex = 0;
            this.btnTaskAdd.Text = "Add Task";
            this.btnTaskAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaskAdd.UseVisualStyleBackColor = true;
            this.btnTaskAdd.Click += new System.EventHandler(this.btnTaskAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dvgTask);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1087, 477);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UC_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "UC_Task";
            this.Size = new System.Drawing.Size(1087, 477);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTask)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgTask;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTaskView;
        private System.Windows.Forms.Button btnTaskDel;
        private System.Windows.Forms.Button btnTaskEdit;
        private System.Windows.Forms.Button btnTaskAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
