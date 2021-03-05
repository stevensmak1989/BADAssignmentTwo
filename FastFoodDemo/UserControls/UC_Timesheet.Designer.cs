
namespace FujitsuPayments.UserControls
{
    partial class UC_Timesheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Timesheet));
            this.btnAddTimesheet = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dvgTimesheetDets = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTimesheetDets)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddTimesheet
            // 
            this.btnAddTimesheet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddTimesheet.FlatAppearance.BorderSize = 0;
            this.btnAddTimesheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTimesheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTimesheet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnAddTimesheet.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTimesheet.Image")));
            this.btnAddTimesheet.Location = new System.Drawing.Point(0, 0);
            this.btnAddTimesheet.Name = "btnAddTimesheet";
            this.btnAddTimesheet.Size = new System.Drawing.Size(158, 42);
            this.btnAddTimesheet.TabIndex = 1;
            this.btnAddTimesheet.Text = "Add Timesheet";
            this.btnAddTimesheet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTimesheet.UseVisualStyleBackColor = true;
            this.btnAddTimesheet.Click += new System.EventHandler(this.btnAddTimesheet_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnAddTimesheet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 42);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 91);
            this.panel2.TabIndex = 4;
            // 
            // dvgTimesheetDets
            // 
            this.dvgTimesheetDets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTimesheetDets.Location = new System.Drawing.Point(0, 46);
            this.dvgTimesheetDets.Name = "dvgTimesheetDets";
            this.dvgTimesheetDets.Size = new System.Drawing.Size(820, 269);
            this.dvgTimesheetDets.TabIndex = 5;
            // 
            // UC_Timesheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dvgTimesheetDets);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "UC_Timesheet";
            this.Size = new System.Drawing.Size(821, 406);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTimesheetDets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddTimesheet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dvgTimesheetDets;
    }
}
