
namespace FujitsuPayments.Forms
{
    partial class frmDeleteTimesheet
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblDeleteType = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOTHours = new System.Windows.Forms.Label();
            this.lblOT = new System.Windows.Forms.Label();
            this.lblOCHours = new System.Windows.Forms.Label();
            this.lblBasicHours = new System.Windows.Forms.Label();
            this.lblOC = new System.Windows.Forms.Label();
            this.lblBasic = new System.Windows.Forms.Label();
            this.lblTimesheet = new System.Windows.Forms.Label();
            this.lblTimeID = new System.Windows.Forms.Label();
            this.cmbProjectId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbTitle.Location = new System.Drawing.Point(251, 11);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(154, 18);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Delete A Timesheet";
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // lblDeleteType
            // 
            this.lblDeleteType.AutoSize = true;
            this.lblDeleteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblDeleteType.Location = new System.Drawing.Point(169, 69);
            this.lblDeleteType.Name = "lblDeleteType";
            this.lblDeleteType.Size = new System.Drawing.Size(158, 16);
            this.lblDeleteType.TabIndex = 14;
            this.lblDeleteType.Text = "Would you like to delete?";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.button2.Location = new System.Drawing.Point(216, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 27);
            this.button2.TabIndex = 13;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.btnDelete.Location = new System.Drawing.Point(366, 311);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 27);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblOTHours);
            this.panel1.Controls.Add(this.lblOT);
            this.panel1.Controls.Add(this.lblOCHours);
            this.panel1.Controls.Add(this.lblBasicHours);
            this.panel1.Controls.Add(this.lblOC);
            this.panel1.Controls.Add(this.lblBasic);
            this.panel1.Controls.Add(this.lblTimesheet);
            this.panel1.Controls.Add(this.lblTimeID);
            this.panel1.Controls.Add(this.cmbProjectId);
            this.panel1.Controls.Add(this.lblDeleteType);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 359);
            this.panel1.TabIndex = 3;
            // 
            // lblOTHours
            // 
            this.lblOTHours.AutoSize = true;
            this.lblOTHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOTHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblOTHours.Location = new System.Drawing.Point(426, 240);
            this.lblOTHours.Name = "lblOTHours";
            this.lblOTHours.Size = new System.Drawing.Size(12, 16);
            this.lblOTHours.TabIndex = 28;
            this.lblOTHours.Text = "-";
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblOT.Location = new System.Drawing.Point(251, 240);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(102, 16);
            this.lblOT.TabIndex = 27;
            this.lblOT.Text = "Total OverTime";
            // 
            // lblOCHours
            // 
            this.lblOCHours.AutoSize = true;
            this.lblOCHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOCHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblOCHours.Location = new System.Drawing.Point(425, 204);
            this.lblOCHours.Name = "lblOCHours";
            this.lblOCHours.Size = new System.Drawing.Size(12, 16);
            this.lblOCHours.TabIndex = 26;
            this.lblOCHours.Text = "-";
            // 
            // lblBasicHours
            // 
            this.lblBasicHours.AutoSize = true;
            this.lblBasicHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblBasicHours.Location = new System.Drawing.Point(425, 168);
            this.lblBasicHours.Name = "lblBasicHours";
            this.lblBasicHours.Size = new System.Drawing.Size(12, 16);
            this.lblBasicHours.TabIndex = 25;
            this.lblBasicHours.Text = "-";
            // 
            // lblOC
            // 
            this.lblOC.AutoSize = true;
            this.lblOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblOC.Location = new System.Drawing.Point(250, 204);
            this.lblOC.Name = "lblOC";
            this.lblOC.Size = new System.Drawing.Size(82, 16);
            this.lblOC.TabIndex = 24;
            this.lblOC.Text = "Total OnCall";
            // 
            // lblBasic
            // 
            this.lblBasic.AutoSize = true;
            this.lblBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblBasic.Location = new System.Drawing.Point(250, 168);
            this.lblBasic.Name = "lblBasic";
            this.lblBasic.Size = new System.Drawing.Size(76, 16);
            this.lblBasic.TabIndex = 23;
            this.lblBasic.Text = "Total Basic";
            // 
            // lblTimesheet
            // 
            this.lblTimesheet.AutoSize = true;
            this.lblTimesheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimesheet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTimesheet.Location = new System.Drawing.Point(425, 133);
            this.lblTimesheet.Name = "lblTimesheet";
            this.lblTimesheet.Size = new System.Drawing.Size(12, 16);
            this.lblTimesheet.TabIndex = 22;
            this.lblTimesheet.Text = "-";
            // 
            // lblTimeID
            // 
            this.lblTimeID.AutoSize = true;
            this.lblTimeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTimeID.Location = new System.Drawing.Point(250, 133);
            this.lblTimeID.Name = "lblTimeID";
            this.lblTimeID.Size = new System.Drawing.Size(88, 16);
            this.lblTimeID.TabIndex = 21;
            this.lblTimeID.Text = "Timesheet ID";
            // 
            // cmbProjectId
            // 
            this.cmbProjectId.FormattingEnabled = true;
            this.cmbProjectId.Items.AddRange(new object[] {
            "Delete All",
            "Delete Basic Hours",
            "Delete OnCall Hours",
            "Delete Overtime Hours"});
            this.cmbProjectId.Location = new System.Drawing.Point(352, 68);
            this.cmbProjectId.Name = "cmbProjectId";
            this.cmbProjectId.Size = new System.Drawing.Size(138, 21);
            this.cmbProjectId.TabIndex = 20;
            this.cmbProjectId.SelectedIndexChanged += new System.EventHandler(this.cmbProjectId_SelectedIndexChanged);
            // 
            // frmDeleteTimesheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(709, 383);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDeleteTimesheet";
            this.Text = "frmDeleteTimesheet";
            this.Load += new System.EventHandler(this.frmDeleteTimesheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ErrorProvider errP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbProjectId;
        private System.Windows.Forms.Label lblDeleteType;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblOTHours;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.Label lblOCHours;
        private System.Windows.Forms.Label lblBasicHours;
        private System.Windows.Forms.Label lblOC;
        private System.Windows.Forms.Label lblBasic;
        private System.Windows.Forms.Label lblTimesheet;
        private System.Windows.Forms.Label lblTimeID;
    }
}