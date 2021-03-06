﻿
namespace FujitsuPayments.UserControls
{
    partial class UC_Location
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Location));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.btnEditLocation = new System.Windows.Forms.Button();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvLocation = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDeleteLocation);
            this.panel1.Controls.Add(this.btnEditLocation);
            this.panel1.Controls.Add(this.btnAddLocation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteLocation.FlatAppearance.BorderSize = 0;
            this.btnDeleteLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnDeleteLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLocation.Image")));
            this.btnDeleteLocation.Location = new System.Drawing.Point(321, 0);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(163, 42);
            this.btnDeleteLocation.TabIndex = 3;
            this.btnDeleteLocation.Text = "Delete Location";
            this.btnDeleteLocation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // 
            // btnEditLocation
            // 
            this.btnEditLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditLocation.FlatAppearance.BorderSize = 0;
            this.btnEditLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEditLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnEditLocation.Image")));
            this.btnEditLocation.Location = new System.Drawing.Point(158, 0);
            this.btnEditLocation.Name = "btnEditLocation";
            this.btnEditLocation.Size = new System.Drawing.Size(163, 42);
            this.btnEditLocation.TabIndex = 2;
            this.btnEditLocation.Text = "Edit Location";
            this.btnEditLocation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditLocation.UseVisualStyleBackColor = true;
            this.btnEditLocation.Click += new System.EventHandler(this.btnEditLocation_Click);
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddLocation.FlatAppearance.BorderSize = 0;
            this.btnAddLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnAddLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLocation.Image")));
            this.btnAddLocation.Location = new System.Drawing.Point(0, 0);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(158, 42);
            this.btnAddLocation.TabIndex = 1;
            this.btnAddLocation.Text = "Add Location";
            this.btnAddLocation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 525);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1090, 91);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvLocation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1090, 483);
            this.panel2.TabIndex = 1;
            // 
            // dgvLocation
            // 
            this.dgvLocation.AllowUserToAddRows = false;
            this.dgvLocation.AllowUserToDeleteRows = false;
            this.dgvLocation.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocation.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocation.Location = new System.Drawing.Point(0, 0);
            this.dgvLocation.Name = "dgvLocation";
            this.dgvLocation.ReadOnly = true;
            this.dgvLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocation.Size = new System.Drawing.Size(1090, 483);
            this.dgvLocation.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(484, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(163, 42);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UC_Location
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Location";
            this.Size = new System.Drawing.Size(1090, 616);
            this.Load += new System.EventHandler(this.UC_Location_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvLocation;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.Button btnEditLocation;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.Button btnRefresh;
    }
}
