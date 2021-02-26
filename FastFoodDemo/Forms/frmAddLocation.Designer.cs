
namespace FujitsuPayments.Forms
{
    partial class frmAddLocation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTelNo = new System.Windows.Forms.TextBox();
            this.lblTelNo = new System.Windows.Forms.Label();
            this.txtLocationID = new System.Windows.Forms.TextBox();
            this.lblLocationId = new System.Windows.Forms.Label();
            this.btnAddLocationClose = new System.Windows.Forms.Button();
            this.btnAddLocationSave = new System.Windows.Forms.Button();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.lblCounty = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.lblLocationName = new System.Windows.Forms.Label();
            this.lblAddLocation = new System.Windows.Forms.Label();
            this.errP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtTelNo);
            this.panel1.Controls.Add(this.lblTelNo);
            this.panel1.Controls.Add(this.txtLocationID);
            this.panel1.Controls.Add(this.lblLocationId);
            this.panel1.Controls.Add(this.btnAddLocationClose);
            this.panel1.Controls.Add(this.btnAddLocationSave);
            this.panel1.Controls.Add(this.txtPostCode);
            this.panel1.Controls.Add(this.lblCounty);
            this.panel1.Controls.Add(this.txtCounty);
            this.panel1.Controls.Add(this.lblPostCode);
            this.panel1.Controls.Add(this.txtTown);
            this.panel1.Controls.Add(this.lblStreet);
            this.panel1.Controls.Add(this.txtStreet);
            this.panel1.Controls.Add(this.lblTown);
            this.panel1.Controls.Add(this.txtLocationName);
            this.panel1.Controls.Add(this.lblLocationName);
            this.panel1.Controls.Add(this.lblAddLocation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 330);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtTelNo
            // 
            this.txtTelNo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelNo.Location = new System.Drawing.Point(449, 135);
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(212, 26);
            this.txtTelNo.TabIndex = 36;
            // 
            // lblTelNo
            // 
            this.lblTelNo.AutoSize = true;
            this.lblTelNo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTelNo.Location = new System.Drawing.Point(397, 141);
            this.lblTelNo.Name = "lblTelNo";
            this.lblTelNo.Size = new System.Drawing.Size(47, 17);
            this.lblTelNo.TabIndex = 35;
            this.lblTelNo.Text = "Tel No";
            // 
            // txtLocationID
            // 
            this.txtLocationID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationID.Location = new System.Drawing.Point(124, 70);
            this.txtLocationID.Name = "txtLocationID";
            this.txtLocationID.Size = new System.Drawing.Size(123, 26);
            this.txtLocationID.TabIndex = 34;
            // 
            // lblLocationId
            // 
            this.lblLocationId.AutoSize = true;
            this.lblLocationId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblLocationId.Location = new System.Drawing.Point(38, 74);
            this.lblLocationId.Name = "lblLocationId";
            this.lblLocationId.Size = new System.Drawing.Size(82, 17);
            this.lblLocationId.TabIndex = 33;
            this.lblLocationId.Text = "Location ID";
            // 
            // btnAddLocationClose
            // 
            this.btnAddLocationClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLocationClose.FlatAppearance.BorderSize = 2;
            this.btnAddLocationClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLocationClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLocationClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnAddLocationClose.Location = new System.Drawing.Point(226, 238);
            this.btnAddLocationClose.Name = "btnAddLocationClose";
            this.btnAddLocationClose.Size = new System.Drawing.Size(97, 27);
            this.btnAddLocationClose.TabIndex = 32;
            this.btnAddLocationClose.Text = "Close";
            this.btnAddLocationClose.UseVisualStyleBackColor = true;
            this.btnAddLocationClose.Click += new System.EventHandler(this.btnAddLocationClose_Click);
            // 
            // btnAddLocationSave
            // 
            this.btnAddLocationSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLocationSave.FlatAppearance.BorderSize = 2;
            this.btnAddLocationSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLocationSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLocationSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.btnAddLocationSave.Location = new System.Drawing.Point(376, 238);
            this.btnAddLocationSave.Name = "btnAddLocationSave";
            this.btnAddLocationSave.Size = new System.Drawing.Size(97, 27);
            this.btnAddLocationSave.TabIndex = 31;
            this.btnAddLocationSave.Text = "Save";
            this.btnAddLocationSave.UseVisualStyleBackColor = true;
            this.btnAddLocationSave.Click += new System.EventHandler(this.btnAddLocationSave_Click);
            // 
            // txtPostCode
            // 
            this.txtPostCode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostCode.Location = new System.Drawing.Point(124, 168);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(123, 26);
            this.txtPostCode.TabIndex = 30;
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblCounty.Location = new System.Drawing.Point(59, 141);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(55, 17);
            this.lblCounty.TabIndex = 29;
            this.lblCounty.Text = "County";
            // 
            // txtCounty
            // 
            this.txtCounty.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounty.Location = new System.Drawing.Point(124, 135);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(222, 26);
            this.txtCounty.TabIndex = 28;
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblPostCode.Location = new System.Drawing.Point(38, 174);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(76, 17);
            this.lblPostCode.TabIndex = 27;
            this.lblPostCode.Text = "Post Code";
            // 
            // txtTown
            // 
            this.txtTown.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.Location = new System.Drawing.Point(449, 102);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(212, 26);
            this.txtTown.TabIndex = 26;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblStreet.Location = new System.Drawing.Point(70, 107);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(44, 17);
            this.lblStreet.TabIndex = 25;
            this.lblStreet.Text = "Street";
            // 
            // txtStreet
            // 
            this.txtStreet.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.Location = new System.Drawing.Point(124, 102);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(222, 26);
            this.txtStreet.TabIndex = 24;
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblTown.Location = new System.Drawing.Point(397, 108);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(42, 17);
            this.lblTown.TabIndex = 23;
            this.lblTown.Text = "Town";
            // 
            // txtLocationName
            // 
            this.txtLocationName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationName.Location = new System.Drawing.Point(449, 70);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(212, 26);
            this.txtLocationName.TabIndex = 22;
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.lblLocationName.Location = new System.Drawing.Point(335, 74);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(109, 17);
            this.lblLocationName.TabIndex = 21;
            this.lblLocationName.Text = "Location Name";
            // 
            // lblAddLocation
            // 
            this.lblAddLocation.AutoSize = true;
            this.lblAddLocation.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddLocation.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAddLocation.Location = new System.Drawing.Point(271, 25);
            this.lblAddLocation.Name = "lblAddLocation";
            this.lblAddLocation.Size = new System.Drawing.Size(158, 18);
            this.lblAddLocation.TabIndex = 20;
            this.lblAddLocation.Text = "Add a New Location";
            // 
            // errP
            // 
            this.errP.ContainerControl = this;
            // 
            // frmAddLocation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(717, 346);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddLocation";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "frmAddLocation";
            this.Load += new System.EventHandler(this.frmAddLocation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTelNo;
        private System.Windows.Forms.Label lblTelNo;
        private System.Windows.Forms.TextBox txtLocationID;
        private System.Windows.Forms.Label lblLocationId;
        private System.Windows.Forms.Button btnAddLocationClose;
        private System.Windows.Forms.Button btnAddLocationSave;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.Label lblLocationName;
        private System.Windows.Forms.Label lblAddLocation;
        private System.Windows.Forms.ErrorProvider errP;
    }
}