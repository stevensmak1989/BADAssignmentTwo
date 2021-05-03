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
    {// variables for sql connections
        SqlDataAdapter daEmployee, daMan, daGrade, daGrades;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBEmployee;
        DataRow drEmployee, drSalary;
        String connStr, sqlEmployee, sqlMan, sqlGrade, sqlGrades;
        //vars to compare grades against salary
        decimal start, end;
        SqlConnection conn;
        Boolean sal = true;
        SqlCommand cmdGrades;

        private void cmbGradeEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //will only run the code if the grade is selected
            if (cmbGradeEdit.Focused == true)
            {
                //clears the grade table to prevent any old data being used
                dsFujitsuPayments.Tables["Grades"].Clear();
                //sets the parameter to the selected grade
                cmdGrades.Parameters["@Grade"].Value = cmbGradeEdit.SelectedValue.ToString();

                daGrades.Fill(dsFujitsuPayments, "Grades");
                DataTable dt = dsFujitsuPayments.Tables["Grades"];

                //sets the datarow to the grade
                foreach (DataRow row in dt.Rows)
                {
                    drSalary = row;
                }

                //sets the start and end var to the salary max and min for validation
                start = Convert.ToDecimal(drSalary["StartSal"].ToString());
                end = Convert.ToDecimal(drSalary["EndSal"].ToString());
            }
        }

   


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

            //gets all employees that are managers
            sqlMan = @"Select  EmployeeID, Surname + ' ' + Forename as EmpName from Employee where Manager = 1";
            daMan = new SqlDataAdapter(sqlMan, connStr);
            daMan.Fill(dsFujitsuPayments, "Manager");

            //populates the approved by cmb with the manager table
            foreach (DataRow dr in dsFujitsuPayments.Tables["Manager"].Rows)
            {
                cmbApprovedBy.DataSource = dsFujitsuPayments.Tables["Manager"];
                cmbApprovedBy.ValueMember = "EmployeeID";
                cmbApprovedBy.DisplayMember = "EmpName";
            }

            //selects all from grade
            sqlGrade = @"Select  Grade, GradeDesc from Grade ";
            daGrade = new SqlDataAdapter(sqlGrade, connStr);
            daGrade.Fill(dsFujitsuPayments, "Grade");

            //will then populate the grade cmb with the grade info
            foreach (DataRow dr in dsFujitsuPayments.Tables["Grade"].Rows)
            {
                cmbGradeEdit.DataSource = dsFujitsuPayments.Tables["Grade"];
                cmbGradeEdit.ValueMember = "Grade";
                cmbGradeEdit.DisplayMember = "GradeDesc";

            }

            //gets the employee number from the user control
            lblEmpNoEdit.Text = UC_Employee.empNoSelected.ToString();

            //sets the datarow to the employee
            drEmployee = dsFujitsuPayments.Tables["Employee"].Rows.Find(lblEmpNoEdit.Text);

            sqlGrades = @"select * from Grade where Grade =  @Grade";
            conn = new SqlConnection(connStr);
            cmdGrades = new SqlCommand(sqlGrades, conn);
            cmdGrades.Parameters.Add("@Grade", SqlDbType.VarChar);
            daGrades = new SqlDataAdapter(cmdGrades);
            daGrades.FillSchema(dsFujitsuPayments, SchemaType.Source, "Grades");

            //sets the form fields to the database values
            cmbTitle.Text= drEmployee["Title"].ToString();
            txtSurnameEdit.Text = drEmployee["Surname"].ToString();
            txtFirstNameEdit.Text = drEmployee["Forename"].ToString();
            txtStreetEdit.Text = drEmployee["Street"].ToString();
            txtTownEdit.Text = drEmployee["Town"].ToString();
            txtCountyEdit.Text = drEmployee["County"].ToString();
            txtPostcodeEdit.Text = drEmployee["Postcode"].ToString();
            txtPhoneNumberEdit.Text = drEmployee["TelNo"].ToString();
            dtpDOBEdit.Text =  drEmployee["DOB"].ToString();
            cmbApprovedBy.Text = drEmployee["ManagerID"].ToString();
            cmbGradeEdit.Text = drEmployee["Grade"].ToString();
            txtEditSalary.Text =  drEmployee["Salary"].ToString();

     
            //checks if manager is true or false
            if (drEmployee["Manager"].ToString().Equals("True"))
                cbManager.Checked = true;
            else
                cbManager.Checked = false;
        }
        //called when the save button is selected
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
                myEmployee.Title = cmbTitle.SelectedItem.ToString();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbTitle, MyEx.toString());
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
            try
            {
                if (cbManager.Checked == true)
                {
                    myEmployee.Manager = 1;
                }
                else
                {
                    myEmployee.Manager = 0;
                }
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cbManager, MyEx.toString());
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
                myEmployee.Grade = cmbGradeEdit.SelectedValue.ToString();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbGradeEdit, MyEx.toString());
            }
            //employee Manager number
            try
            {
                myEmployee.ManagerId = Convert.ToInt32(cmbApprovedBy.SelectedValue.ToString());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbApprovedBy, MyEx.toString());
            }
            try
            {
                

                myEmployee.Salary = txtEditSalary.Text;
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtEditSalary, MyEx.toString());
            }
            try
            {
                //checks if the salary is validated
                if (sal == true)
                {
                    //checks if salary is within the boundary
                    if (Convert.ToDecimal(txtEditSalary.Text) < start || Convert.ToDecimal(txtEditSalary.Text) > end)
                    {
                        MessageBox.Show("Salary must be between £" + Convert.ToString(start) + " and £" + Convert.ToString(end));
                    }
                    else
                    {
                        //if all validation is passed
                        if (ok)
                        {
                            //starts the edit
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
                            drEmployee["Manager"] = myEmployee.Manager;
                            drEmployee["Grade"] = myEmployee.Grade;
                            drEmployee["Salary"] = Convert.ToDecimal(myEmployee.Salary);

                            drEmployee.EndEdit();
                            daEmployee.Update(dsFujitsuPayments, "Employee");

                            MessageBox.Show("Employee Updated");
                            this.Dispose();
                            UC_Employee.refresh = true;

                        }
                    }
                }
            }
            //catches errors
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
       //closes the form
        private void btnEmpClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      
    }
}
