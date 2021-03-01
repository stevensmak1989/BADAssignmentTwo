
namespace FujitsuPayments.Forms
{
    partial class frmAddTask
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
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAccountId = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTaskDesc = new System.Windows.Forms.Label();
            this.txtTaskDesc = new System.Windows.Forms.TextBox();
            this.lblTaskCode = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTaskId = new System.Windows.Forms.Label();
            this.cmbProjectId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblAccountId.Location = new System.Drawing.Point(152, 68);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.Size = new System.Drawing.Size(63, 16);
            this.lblAccountId.TabIndex = 14;
            this.lblAccountId.Text = "ProjectID";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.button2.Location = new System.Drawing.Point(174, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 27);
            this.button2.TabIndex = 13;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.btnSave.Location = new System.Drawing.Point(324, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 27);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTaskDesc
            // 
            this.lblTaskDesc.AutoSize = true;
            this.lblTaskDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTaskDesc.Location = new System.Drawing.Point(152, 166);
            this.lblTaskDesc.Name = "lblTaskDesc";
            this.lblTaskDesc.Size = new System.Drawing.Size(74, 16);
            this.lblTaskDesc.TabIndex = 10;
            this.lblTaskDesc.Text = "Task Desc";
            // 
            // txtTaskDesc
            // 
            this.txtTaskDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskDesc.Location = new System.Drawing.Point(274, 161);
            this.txtTaskDesc.Name = "txtTaskDesc";
            this.txtTaskDesc.Size = new System.Drawing.Size(222, 24);
            this.txtTaskDesc.TabIndex = 9;
            // 
            // lblTaskCode
            // 
            this.lblTaskCode.AutoSize = true;
            this.lblTaskCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTaskCode.Location = new System.Drawing.Point(152, 115);
            this.lblTaskCode.Name = "lblTaskCode";
            this.lblTaskCode.Size = new System.Drawing.Size(75, 16);
            this.lblTaskCode.TabIndex = 2;
            this.lblTaskCode.Text = "Task Code";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbTitle.Location = new System.Drawing.Point(219, 14);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(171, 18);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Add a Task to Project";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTaskId);
            this.panel1.Controls.Add(this.cmbProjectId);
            this.panel1.Controls.Add(this.lblAccountId);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblTaskDesc);
            this.panel1.Controls.Add(this.txtTaskDesc);
            this.panel1.Controls.Add(this.lblTaskCode);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 279);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblTaskId
            // 
            this.lblTaskId.AutoSize = true;
            this.lblTaskId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTaskId.Location = new System.Drawing.Point(271, 115);
            this.lblTaskId.Name = "lblTaskId";
            this.lblTaskId.Size = new System.Drawing.Size(12, 16);
            this.lblTaskId.TabIndex = 21;
            this.lblTaskId.Text = "-";
            // 
            // cmbProjectId
            // 
            this.cmbProjectId.FormattingEnabled = true;
            this.cmbProjectId.Location = new System.Drawing.Point(274, 68);
            this.cmbProjectId.Name = "cmbProjectId";
            this.cmbProjectId.Size = new System.Drawing.Size(138, 21);
            this.cmbProjectId.TabIndex = 20;
            // 
            // frmAddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(628, 295);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddTask";
            this.Text = "frmAddTask";
            this.Load += new System.EventHandler(this.frmAddTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTaskDesc;
        private System.Windows.Forms.TextBox txtTaskDesc;
        private System.Windows.Forms.Label lblTaskCode;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ComboBox cmbProjectId;
        private System.Windows.Forms.Label lblTaskId;
    }
}