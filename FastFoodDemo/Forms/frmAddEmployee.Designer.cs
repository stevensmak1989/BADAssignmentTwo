
namespace FastFoodDemo.Forms
{
    partial class frmAddEmployee
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
            this.btnEmpClose = new System.Windows.Forms.Button();
            this.btnEmpSave = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.txtPersonnelNo = new System.Windows.Forms.TextBox();
            this.lblPersonnelNo = new System.Windows.Forms.Label();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.lblCounty = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtSurnameAdd = new System.Windows.Forms.TextBox();
            this.lblSurnameAdd = new System.Windows.Forms.Label();
            this.txtFirstNameAdd = new System.Windows.Forms.TextBox();
            this.lblFirstNameAdd = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtPersonnelNo);
            this.panel1.Controls.Add(this.lblPersonnelNo);
            this.panel1.Controls.Add(this.cmbGrade);
            this.panel1.Controls.Add(this.lblGrade);
            this.panel1.Controls.Add(this.txtPostcode);
            this.panel1.Controls.Add(this.lblPostcode);
            this.panel1.Controls.Add(this.txtCountry);
            this.panel1.Controls.Add(this.lblCountry);
            this.panel1.Controls.Add(this.txtCounty);
            this.panel1.Controls.Add(this.lblCounty);
            this.panel1.Controls.Add(this.txtTown);
            this.panel1.Controls.Add(this.lblTown);
            this.panel1.Controls.Add(this.txtStreet);
            this.panel1.Controls.Add(this.lblStreet);
            this.panel1.Controls.Add(this.txtPhoneNumber);
            this.panel1.Controls.Add(this.lblPhoneNumber);
            this.panel1.Controls.Add(this.txtSurnameAdd);
            this.panel1.Controls.Add(this.lblSurnameAdd);
            this.panel1.Controls.Add(this.txtFirstNameAdd);
            this.panel1.Controls.Add(this.lblFirstNameAdd);
            this.panel1.Controls.Add(this.btnEmpClose);
            this.panel1.Controls.Add(this.btnEmpSave);
            this.panel1.Controls.Add(this.lbltitle);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 330);
            this.panel1.TabIndex = 1;
            // 
            // btnEmpClose
            // 
            this.btnEmpClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpClose.FlatAppearance.BorderSize = 2;
            this.btnEmpClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.btnEmpClose.Location = new System.Drawing.Point(153, 278);
            this.btnEmpClose.Name = "btnEmpClose";
            this.btnEmpClose.Size = new System.Drawing.Size(143, 36);
            this.btnEmpClose.TabIndex = 13;
            this.btnEmpClose.Text = "Close";
            this.btnEmpClose.UseVisualStyleBackColor = true;
            this.btnEmpClose.Click += new System.EventHandler(this.btnEmpClose_Click);
            // 
            // btnEmpSave
            // 
            this.btnEmpSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpSave.FlatAppearance.BorderSize = 2;
            this.btnEmpSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.btnEmpSave.Location = new System.Drawing.Point(350, 278);
            this.btnEmpSave.Name = "btnEmpSave";
            this.btnEmpSave.Size = new System.Drawing.Size(139, 36);
            this.btnEmpSave.TabIndex = 12;
            this.btnEmpSave.Text = "Save";
            this.btnEmpSave.UseVisualStyleBackColor = true;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbltitle.Location = new System.Drawing.Point(240, 10);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(167, 18);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "Add a New Employee";
            // 
            // txtPersonnelNo
            // 
            this.txtPersonnelNo.Location = new System.Drawing.Point(170, 66);
            this.txtPersonnelNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonnelNo.Name = "txtPersonnelNo";
            this.txtPersonnelNo.Size = new System.Drawing.Size(126, 20);
            this.txtPersonnelNo.TabIndex = 39;
            // 
            // lblPersonnelNo
            // 
            this.lblPersonnelNo.AutoSize = true;
            this.lblPersonnelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonnelNo.Location = new System.Drawing.Point(52, 74);
            this.lblPersonnelNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonnelNo.Name = "lblPersonnelNo";
            this.lblPersonnelNo.Size = new System.Drawing.Size(90, 16);
            this.lblPersonnelNo.TabIndex = 38;
            this.lblPersonnelNo.Text = "Personnel No";
            // 
            // cmbGrade
            // 
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Location = new System.Drawing.Point(170, 232);
            this.cmbGrade.Margin = new System.Windows.Forms.Padding(4);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(126, 21);
            this.cmbGrade.TabIndex = 37;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(52, 232);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(46, 16);
            this.lblGrade.TabIndex = 36;
            this.lblGrade.Text = "Grade";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(477, 229);
            this.txtPostcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(126, 20);
            this.txtPostcode.TabIndex = 35;
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostcode.Location = new System.Drawing.Point(366, 233);
            this.lblPostcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(66, 16);
            this.lblPostcode.TabIndex = 34;
            this.lblPostcode.Text = "Postcode";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(477, 183);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(4);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(126, 20);
            this.txtCountry.TabIndex = 33;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(366, 187);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(53, 16);
            this.lblCountry.TabIndex = 32;
            this.lblCountry.Text = "Country";
            // 
            // txtCounty
            // 
            this.txtCounty.Location = new System.Drawing.Point(477, 139);
            this.txtCounty.Margin = new System.Windows.Forms.Padding(4);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(126, 20);
            this.txtCounty.TabIndex = 31;
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounty.Location = new System.Drawing.Point(366, 148);
            this.lblCounty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(49, 16);
            this.lblCounty.TabIndex = 30;
            this.lblCounty.Text = "County";
            // 
            // txtTown
            // 
            this.txtTown.Location = new System.Drawing.Point(477, 98);
            this.txtTown.Margin = new System.Windows.Forms.Padding(4);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(126, 20);
            this.txtTown.TabIndex = 29;
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.Location = new System.Drawing.Point(366, 107);
            this.lblTown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(41, 16);
            this.lblTown.TabIndex = 28;
            this.lblTown.Text = "Town";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(477, 55);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(4);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(126, 20);
            this.txtStreet.TabIndex = 27;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreet.Location = new System.Drawing.Point(366, 58);
            this.lblStreet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(43, 16);
            this.lblStreet.TabIndex = 26;
            this.lblStreet.Text = "Street";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(170, 187);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(126, 20);
            this.txtPhoneNumber.TabIndex = 25;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(52, 190);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(98, 16);
            this.lblPhoneNumber.TabIndex = 24;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // txtSurnameAdd
            // 
            this.txtSurnameAdd.Location = new System.Drawing.Point(170, 148);
            this.txtSurnameAdd.Margin = new System.Windows.Forms.Padding(4);
            this.txtSurnameAdd.Name = "txtSurnameAdd";
            this.txtSurnameAdd.Size = new System.Drawing.Size(126, 20);
            this.txtSurnameAdd.TabIndex = 23;
            // 
            // lblSurnameAdd
            // 
            this.lblSurnameAdd.AutoSize = true;
            this.lblSurnameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurnameAdd.Location = new System.Drawing.Point(52, 152);
            this.lblSurnameAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurnameAdd.Name = "lblSurnameAdd";
            this.lblSurnameAdd.Size = new System.Drawing.Size(62, 16);
            this.lblSurnameAdd.TabIndex = 22;
            this.lblSurnameAdd.Text = "Surname";
            // 
            // txtFirstNameAdd
            // 
            this.txtFirstNameAdd.Location = new System.Drawing.Point(170, 108);
            this.txtFirstNameAdd.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstNameAdd.Name = "txtFirstNameAdd";
            this.txtFirstNameAdd.Size = new System.Drawing.Size(126, 20);
            this.txtFirstNameAdd.TabIndex = 21;
            // 
            // lblFirstNameAdd
            // 
            this.lblFirstNameAdd.AutoSize = true;
            this.lblFirstNameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNameAdd.Location = new System.Drawing.Point(52, 108);
            this.lblFirstNameAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstNameAdd.Name = "lblFirstNameAdd";
            this.lblFirstNameAdd.Size = new System.Drawing.Size(73, 16);
            this.lblFirstNameAdd.TabIndex = 20;
            this.lblFirstNameAdd.Text = "First Name";
            // 
            // frmAddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(717, 346);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEmployee";
            this.Load += new System.EventHandler(this.frmAddEmployee_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEmpClose;
        private System.Windows.Forms.Button btnEmpSave;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.TextBox txtPersonnelNo;
        private System.Windows.Forms.Label lblPersonnelNo;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.Label lblPostcode;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtSurnameAdd;
        private System.Windows.Forms.Label lblSurnameAdd;
        private System.Windows.Forms.TextBox txtFirstNameAdd;
        private System.Windows.Forms.Label lblFirstNameAdd;
    }
}