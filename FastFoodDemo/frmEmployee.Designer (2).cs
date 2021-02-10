
namespace FastFoodDemo
{
    partial class frmEmployee
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
            this.lblFirstNameAdd = new System.Windows.Forms.Label();
            this.txtFirstNameAdd = new System.Windows.Forms.TextBox();
            this.lblSurnameAdd = new System.Windows.Forms.Label();
            this.txtSurnameAdd = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblTown = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.lblCounty = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.cmbGrade = new System.Windows.Forms.ComboBox();
            this.lblPersonnelNo = new System.Windows.Forms.Label();
            this.txtPersonnelNo = new System.Windows.Forms.TextBox();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.PersonnelNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Town = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.County = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Postcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstNameAdd
            // 
            this.lblFirstNameAdd.AutoSize = true;
            this.lblFirstNameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNameAdd.Location = new System.Drawing.Point(92, 97);
            this.lblFirstNameAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstNameAdd.Name = "lblFirstNameAdd";
            this.lblFirstNameAdd.Size = new System.Drawing.Size(73, 16);
            this.lblFirstNameAdd.TabIndex = 0;
            this.lblFirstNameAdd.Text = "First Name";
            this.lblFirstNameAdd.Click += new System.EventHandler(this.lblFirstNameAdd_Click);
            // 
            // txtFirstNameAdd
            // 
            this.txtFirstNameAdd.Location = new System.Drawing.Point(204, 97);
            this.txtFirstNameAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFirstNameAdd.Name = "txtFirstNameAdd";
            this.txtFirstNameAdd.Size = new System.Drawing.Size(132, 22);
            this.txtFirstNameAdd.TabIndex = 1;
            // 
            // lblSurnameAdd
            // 
            this.lblSurnameAdd.AutoSize = true;
            this.lblSurnameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurnameAdd.Location = new System.Drawing.Point(92, 153);
            this.lblSurnameAdd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurnameAdd.Name = "lblSurnameAdd";
            this.lblSurnameAdd.Size = new System.Drawing.Size(62, 16);
            this.lblSurnameAdd.TabIndex = 2;
            this.lblSurnameAdd.Text = "Surname";
            // 
            // txtSurnameAdd
            // 
            this.txtSurnameAdd.Location = new System.Drawing.Point(204, 149);
            this.txtSurnameAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSurnameAdd.Name = "txtSurnameAdd";
            this.txtSurnameAdd.Size = new System.Drawing.Size(132, 22);
            this.txtSurnameAdd.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(92, 205);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(98, 16);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(204, 202);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(132, 22);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreet.Location = new System.Drawing.Point(501, 50);
            this.lblStreet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(43, 16);
            this.lblStreet.TabIndex = 6;
            this.lblStreet.Text = "Street";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(606, 47);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(132, 22);
            this.txtStreet.TabIndex = 7;
            // 
            // lblTown
            // 
            this.lblTown.AutoSize = true;
            this.lblTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTown.Location = new System.Drawing.Point(501, 106);
            this.lblTown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(41, 16);
            this.lblTown.TabIndex = 8;
            this.lblTown.Text = "Town";
            // 
            // txtTown
            // 
            this.txtTown.Location = new System.Drawing.Point(606, 97);
            this.txtTown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(132, 22);
            this.txtTown.TabIndex = 9;
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounty.Location = new System.Drawing.Point(501, 159);
            this.lblCounty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(49, 16);
            this.lblCounty.TabIndex = 10;
            this.lblCounty.Text = "County";
            // 
            // txtCounty
            // 
            this.txtCounty.Location = new System.Drawing.Point(606, 150);
            this.txtCounty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(132, 22);
            this.txtCounty.TabIndex = 11;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(501, 207);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(53, 16);
            this.lblCountry.TabIndex = 12;
            this.lblCountry.Text = "Country";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(606, 203);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(132, 22);
            this.txtCountry.TabIndex = 13;
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostcode.Location = new System.Drawing.Point(501, 257);
            this.lblPostcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(66, 16);
            this.lblPostcode.TabIndex = 14;
            this.lblPostcode.Text = "Postcode";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(606, 253);
            this.txtPostcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(132, 22);
            this.txtPostcode.TabIndex = 15;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(92, 258);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(46, 16);
            this.lblGrade.TabIndex = 16;
            this.lblGrade.Text = "Grade";
            // 
            // cmbGrade
            // 
            this.cmbGrade.FormattingEnabled = true;
            this.cmbGrade.Location = new System.Drawing.Point(204, 258);
            this.cmbGrade.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbGrade.Name = "cmbGrade";
            this.cmbGrade.Size = new System.Drawing.Size(132, 24);
            this.cmbGrade.TabIndex = 17;
            // 
            // lblPersonnelNo
            // 
            this.lblPersonnelNo.AutoSize = true;
            this.lblPersonnelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonnelNo.Location = new System.Drawing.Point(92, 50);
            this.lblPersonnelNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonnelNo.Name = "lblPersonnelNo";
            this.lblPersonnelNo.Size = new System.Drawing.Size(90, 16);
            this.lblPersonnelNo.TabIndex = 18;
            this.lblPersonnelNo.Text = "Personnel No";
            // 
            // txtPersonnelNo
            // 
            this.txtPersonnelNo.Location = new System.Drawing.Point(204, 42);
            this.txtPersonnelNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPersonnelNo.Name = "txtPersonnelNo";
            this.txtPersonnelNo.Size = new System.Drawing.Size(132, 22);
            this.txtPersonnelNo.TabIndex = 19;
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonnelNo,
            this.FirstName,
            this.Surname,
            this.Grade,
            this.PhoneNo,
            this.Street,
            this.Town,
            this.County,
            this.Country,
            this.Postcode});
            this.dgvEmployee.Location = new System.Drawing.Point(80, 376);
            this.dgvEmployee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.Size = new System.Drawing.Size(717, 133);
            this.dgvEmployee.TabIndex = 20;
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            // 
            // PersonnelNo
            // 
            this.PersonnelNo.HeaderText = "Personnel No";
            this.PersonnelNo.Name = "PersonnelNo";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // Surname
            // 
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            // 
            // PhoneNo
            // 
            this.PhoneNo.HeaderText = "Phone No";
            this.PhoneNo.Name = "PhoneNo";
            // 
            // Street
            // 
            this.Street.HeaderText = "Street";
            this.Street.Name = "Street";
            // 
            // Town
            // 
            this.Town.HeaderText = "Town";
            this.Town.Name = "Town";
            // 
            // County
            // 
            this.County.HeaderText = "County";
            this.County.Name = "County";
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            // 
            // Postcode
            // 
            this.Postcode.HeaderText = "Postcode";
            this.Postcode.Name = "Postcode";
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 505);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.txtPersonnelNo);
            this.Controls.Add(this.lblPersonnelNo);
            this.Controls.Add(this.cmbGrade);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.txtPostcode);
            this.Controls.Add(this.lblPostcode);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtCounty);
            this.Controls.Add(this.lblCounty);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.lblTown);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtSurnameAdd);
            this.Controls.Add(this.lblSurnameAdd);
            this.Controls.Add(this.txtFirstNameAdd);
            this.Controls.Add(this.lblFirstNameAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEmployee";
            this.Text = "frmEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstNameAdd;
        private System.Windows.Forms.TextBox txtFirstNameAdd;
        private System.Windows.Forms.Label lblSurnameAdd;
        private System.Windows.Forms.TextBox txtSurnameAdd;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblTown;
        private System.Windows.Forms.TextBox txtTown;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblPostcode;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.ComboBox cmbGrade;
        private System.Windows.Forms.Label lblPersonnelNo;
        private System.Windows.Forms.TextBox txtPersonnelNo;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonnelNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn Town;
        private System.Windows.Forms.DataGridViewTextBoxColumn County;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Postcode;
    }
}