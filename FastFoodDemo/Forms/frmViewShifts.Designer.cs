
namespace FujitsuPayments.Forms
{
    partial class frmViewShifts
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteShift = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvEmpShiftDetails = new System.Windows.Forms.DataGridView();
            this.dgvEmpShift = new System.Windows.Forms.DataGridView();
            this.lblViewShift = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpShiftDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpShift)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblViewShift);
            this.panel1.Controls.Add(this.btnDeleteShift);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.dgvEmpShiftDetails);
            this.panel1.Controls.Add(this.dgvEmpShift);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 475);
            this.panel1.TabIndex = 0;
            // 
            // btnDeleteShift
            // 
            this.btnDeleteShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteShift.FlatAppearance.BorderSize = 2;
            this.btnDeleteShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteShift.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnDeleteShift.Location = new System.Drawing.Point(591, 428);
            this.btnDeleteShift.Name = "btnDeleteShift";
            this.btnDeleteShift.Size = new System.Drawing.Size(97, 27);
            this.btnDeleteShift.TabIndex = 15;
            this.btnDeleteShift.Text = "Delete";
            this.btnDeleteShift.UseVisualStyleBackColor = true;
            this.btnDeleteShift.Click += new System.EventHandler(this.btnDeleteShift_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnClose.Location = new System.Drawing.Point(710, 428);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 27);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvEmpShiftDetails
            // 
            this.dgvEmpShiftDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpShiftDetails.Location = new System.Drawing.Point(18, 238);
            this.dgvEmpShiftDetails.Name = "dgvEmpShiftDetails";
            this.dgvEmpShiftDetails.Size = new System.Drawing.Size(789, 162);
            this.dgvEmpShiftDetails.TabIndex = 1;
            // 
            // dgvEmpShift
            // 
            this.dgvEmpShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpShift.Location = new System.Drawing.Point(18, 39);
            this.dgvEmpShift.Name = "dgvEmpShift";
            this.dgvEmpShift.Size = new System.Drawing.Size(789, 162);
            this.dgvEmpShift.TabIndex = 0;
            this.dgvEmpShift.SelectionChanged += new System.EventHandler(this.selectionChanged);
            // 
            // lblViewShift
            // 
            this.lblViewShift.AutoSize = true;
            this.lblViewShift.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewShift.ForeColor = System.Drawing.Color.DarkRed;
            this.lblViewShift.Location = new System.Drawing.Point(354, 10);
            this.lblViewShift.Name = "lblViewShift";
            this.lblViewShift.Size = new System.Drawing.Size(84, 18);
            this.lblViewShift.TabIndex = 16;
            this.lblViewShift.Text = "View Shifts";
            // 
            // frmViewShifts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(840, 485);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmViewShifts";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewShifts";
            this.Load += new System.EventHandler(this.frmViewShifts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpShiftDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEmpShift;
        private System.Windows.Forms.DataGridView dgvEmpShiftDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteShift;
        private System.Windows.Forms.Label lblViewShift;
    }
}