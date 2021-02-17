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
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";

            sqlEmployee = @"select * from Employee";
            daEmployee = new SqlDataAdapter(sqlEmployee, connStr);
            cmbBEmployee = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");
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
                myEmployee.EmployeeId = Convert.ToInt32(txtPersonnelNo.Text.Trim());
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
            //employee Country
            try
            {
                myEmployee.Country = txtCountry.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCountry, MyEx.toString());
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
                   // drEmployee["Country"] = myEmployee.Country;
                    drEmployee["Postcode"] = myEmployee.Postcode;
                    drEmployee["TelNo"] = myEmployee.TelNo;
                    drEmployee["DOB"] = myEmployee.Dob;
                    drEmployee["ManagerID"] = myEmployee.ManagerId;
                    drEmployee["Grade"] = myEmployee.Grade;
                    drEmployee["Salary"] = myEmployee.Salary;

                    dsFujitsuPayments.Tables["Employee"].Rows.Add(drEmployee);
                    daEmployee.Update(dsFujitsuPayments, "Employee");

                    MessageBox.Show("Employee Added");
                    //if (MessageBox.Show("Do you wish to add another Dog?", "Add Dog", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    //{
                    //    clearAddForm();
                    //    getNumber(dsInTheDogHouse.Tables["Dog"].Rows.Count);
                    //}
                    //else
                    //{
                    //    dogTabs.SelectedIndex = 0;
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
    }
}
    

