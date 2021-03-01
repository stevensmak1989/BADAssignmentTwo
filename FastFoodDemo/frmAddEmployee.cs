using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FujitsuPayments.Forms
{
    public partial class frmAddEmployee : Form
    {
        SqlDataAdapter daEmployee;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBEmployee;
        DataRow drEmployee;
        String connStr, sqlEmployee;


        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlEmployee = @"select * from Employee";
            daEmployee = new SqlDataAdapter(sqlEmployee, connStr);
            cmbBEmployee = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

            int noRows = dsFujitsuPayments.Tables["Employee"].Rows.Count;

            if (noRows == 0)
                lblEmpNoAdd.Text = "1000";
            else
            {
                getNumber(noRows);
            }
        }

        private void btnEmpClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            Employee myEmployee = new Employee();
            bool ok = true;
            errP.Clear();

            //employee number
            try
            {
                myEmployee.EmployeeId = Convert.ToInt32(lblEmpNoAdd.Text.Trim());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblPersonnelNo, MyEx.toString());
            }
            //employee Title
            try
            {
                myEmployee.Title = txtTitle.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTitle, MyEx.toString());
            }
            //employee Surname
            try
            {
                myEmployee.Surname = txtSurnameAdd.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtSurnameAdd, MyEx.toString());
            }
            //employee Forename
            try
            {
                myEmployee.Forename = txtFirstNameAdd.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtFirstNameAdd, MyEx.toString());
            }
            //employee Street
            try
            {
                myEmployee.Street = txtStreet.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtStreet, MyEx.toString());
            }
            //employee Town
            try
            {
                myEmployee.Town = txtTown.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTown, MyEx.toString());
            }
            //employee County
            try
            {
                myEmployee.County = txtCounty.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCounty, MyEx.toString());
            }
         
            //employee Postcode
            try
            {
                myEmployee.Postcode = txtPostcode.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtPostcode, MyEx.toString());
            }

            //employee TelNo
            try
            {
                myEmployee.TelNo = txtPhoneNumber.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtPhoneNumber, MyEx.toString());
            }
            //employee dob
            try
            {
                myEmployee.Dob = DateTime.Parse(dtpDOB.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(dtpDOB, MyEx.toString());
            }
            //employee Grade
            try
            {
                myEmployee.Grade = cmbGrade.SelectedItem.ToString();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbGrade, MyEx.toString());
            }
            //employee Manager number
            try
            {
                myEmployee.ManagerId = Convert.ToInt32(txtAddManagerID.Text.Trim());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddManagerID, MyEx.toString());
            }
            try
            {
                String temp = txtAddSalary.Text;
                Decimal tempD = Decimal.Parse(temp);

                myEmployee.Salary = tempD;
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddSalary, MyEx.toString());
            }
            try
            {
                if (ok)
                {

                    drEmployee = dsFujitsuPayments.Tables["Employee"].NewRow();

                    drEmployee["EmployeeID"] = myEmployee.EmployeeId;
                    drEmployee["Title"] = myEmployee.Title;
                    drEmployee["Surname"] = myEmployee.Surname;
                    drEmployee["Forename"] = myEmployee.Forename;
                    drEmployee["Street"] = myEmployee.Street;
                    drEmployee["Town"] = myEmployee.Town;
                    drEmployee["County"] = myEmployee.County;
                    drEmployee["Postcode"] = myEmployee.Postcode;
                    drEmployee["TelNo"] = myEmployee.TelNo;
                    drEmployee["DOB"] = myEmployee.Dob;
                    drEmployee["ManagerID"] = myEmployee.ManagerId;
                    drEmployee["Grade"] = myEmployee.Grade;
                    drEmployee["Salary"] = myEmployee.Salary;

                    dsFujitsuPayments.Tables["Employee"].Rows.Add(drEmployee);
                    daEmployee.Update(dsFujitsuPayments, "Employee");

                    MessageBox.Show("Employee Added");
                    this.Dispose();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitlee_Click(object sender, EventArgs e)
        {

        }

        private void getNumber(int noRows)
        {
            drEmployee = dsFujitsuPayments.Tables["Employee"].Rows[noRows - 1];
            lblEmpNoAdd.Text = (int.Parse(drEmployee["EmployeeID"].ToString()) + 1).ToString();
        }
    }
}


