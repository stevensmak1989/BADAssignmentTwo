using FujitsuPayments.UserControls;
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
    public partial class frmEditEmployee : Form
    {
        SqlDataAdapter daEmployee;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBEmployee;
        DataRow drEmployee;
        String connStr, sqlEmployee;

        public frmEditEmployee()
        {
            InitializeComponent();
        }

        private void frmEditEmployee_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlEmployee = @"select * from Employee";
            daEmployee = new SqlDataAdapter(sqlEmployee, connStr);
            cmbBEmployee = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

            
            lblEmpNoEdit.Text = UC_Employee.empNoSelected.ToString();

            drEmployee = dsFujitsuPayments.Tables["Employee"].Rows.Find(lblEmpNoEdit.Text);

            

                 
                   txtTitleEdit.Text= drEmployee["Title"].ToString();
                  txtSurnameEdit.Text = drEmployee["Surname"].ToString();
                  txtFirstNameEdit.Text = drEmployee["Forename"].ToString();
                   txtStreetEdit.Text = drEmployee["Street"].ToString();
                   txtTownEdit.Text = drEmployee["Town"].ToString();
                   txtCountyEdit.Text = drEmployee["County"].ToString();
                   txtPostcodeEdit.Text = drEmployee["Postcode"].ToString();
                   txtPhoneNumberEdit.Text = drEmployee["TelNo"].ToString();
                   dtpDOBEdit.Text =  drEmployee["DOB"].ToString();
                   txtEditManagerID.Text = drEmployee["ManagerID"].ToString();
                    cmbGradeEdit.Text = drEmployee["Grade"].ToString();
                   txtEditSalary.Text =  drEmployee["Salary"].ToString();
        }

        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            Employee myEmployee = new Employee();
            bool ok = true;
            errP.Clear();

            //employee number
            try
            {
                myEmployee.EmployeeId = Convert.ToInt32(lblEmpNoEdit.Text.Trim());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblEmpNoEdit, MyEx.toString());
            }
            //employee Title
            try
            {
                myEmployee.Title = txtTitleEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTitleEdit, MyEx.toString());
            }
            //employee Surname
            try
            {
                myEmployee.Surname = txtSurnameEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtSurnameEdit, MyEx.toString());
            }
            //employee Forename
            try
            {
                myEmployee.Forename = txtFirstNameEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtFirstNameEdit, MyEx.toString());
            }
            //employee Street
            try
            {
                myEmployee.Street = txtStreetEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtStreetEdit, MyEx.toString());
            }
            //employee Town
            try
            {
                myEmployee.Town = txtTownEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTownEdit, MyEx.toString());
            }
            //employee County
            try
            {
                myEmployee.County = txtCountyEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCountyEdit, MyEx.toString());
            }

            //employee Postcode
            try
            {
                myEmployee.Postcode = txtPostcodeEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtPostcodeEdit, MyEx.toString());
            }

            //employee TelNo
            try
            {
                myEmployee.TelNo = txtPhoneNumberEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtPhoneNumberEdit, MyEx.toString());
            }
            //employee dob
            try
            {
                myEmployee.Dob = DateTime.Parse(dtpDOBEdit.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(dtpDOBEdit, MyEx.toString());
            }
            //employee Grade
            try
            {
                myEmployee.Grade = cmbGradeEdit.SelectedItem.ToString();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbGradeEdit, MyEx.toString());
            }
            //employee Manager number
            try
            {
                myEmployee.ManagerId = Convert.ToInt32(txtEditManagerID.Text.Trim());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtEditManagerID, MyEx.toString());
            }
            try
            {
                String temp = txtEditSalary.Text;
                Decimal tempD = Decimal.Parse(temp);

                myEmployee.Salary = tempD;
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtEditSalary, MyEx.toString());
            }
            try
            {
                if (ok)
                {

                    drEmployee.BeginEdit();

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

                    drEmployee.EndEdit();
                    daEmployee.Update(dsFujitsuPayments, "Employee");

                    MessageBox.Show("Employee Updated");
                    this.Dispose();
                    UC_Employee.refresh = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void btnEmpClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
