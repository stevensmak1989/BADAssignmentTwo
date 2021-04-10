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

        private void cmbGradeEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //will only run the code if the grade is selected
            if (cmbGradeEdit.Focused == true)
            {
                MessageBox.Show(cmbGradeEdit.SelectedValue.ToString());

                dsFujitsuPayments.Tables["Grades"].Clear();
                cmdGrades.Parameters["@Grade"].Value = cmbGradeEdit.SelectedValue.ToString();

                daGrades.Fill(dsFujitsuPayments, "Grades");
                DataTable dt = dsFujitsuPayments.Tables["Grades"];


                foreach (DataRow row in dt.Rows)
                {

                    drSalary = row;

                }
                start = Convert.ToDecimal(drSalary["StartSal"].ToString());
                end = Convert.ToDecimal(drSalary["EndSal"].ToString());
            }
        }

        SqlConnection conn;
        Boolean sal = true;
        SqlCommand cmdGrades;


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


            sqlMan = @"Select  EmployeeID, Surname + ' ' + Forename as EmpName from Employee where Manager = 1";
            daMan = new SqlDataAdapter(sqlMan, connStr);
            daMan.Fill(dsFujitsuPayments, "Manager");


            foreach (DataRow dr in dsFujitsuPayments.Tables["Manager"].Rows)
            {
                // Console.WriteLine(dr["Manager"].ToString());


                cmbApprovedBy.DataSource = dsFujitsuPayments.Tables["Manager"];
                cmbApprovedBy.ValueMember = "EmployeeID";
                cmbApprovedBy.DisplayMember = "EmpName";

            }

            sqlGrade = @"Select  Grade, GradeDesc from Grade ";
            daGrade = new SqlDataAdapter(sqlGrade, connStr);
            daGrade.Fill(dsFujitsuPayments, "Grade");

            foreach (DataRow dr in dsFujitsuPayments.Tables["Grade"].Rows)
            {
                // Console.WriteLine(dr["Manager"].ToString());


                cmbGradeEdit.DataSource = dsFujitsuPayments.Tables["Grade"];
                cmbGradeEdit.ValueMember = "Grade";
                cmbGradeEdit.DisplayMember = "GradeDesc";

            }


            lblEmpNoEdit.Text = UC_Employee.empNoSelected.ToString();

            drEmployee = dsFujitsuPayments.Tables["Employee"].Rows.Find(lblEmpNoEdit.Text);

            sqlGrades = @"select * from Grade where Grade =  @Grade";
            conn = new SqlConnection(connStr);
            cmdGrades = new SqlCommand(sqlGrades, conn);
            cmdGrades.Parameters.Add("@Grade", SqlDbType.VarChar);
            daGrades = new SqlDataAdapter(cmdGrades);
            daGrades.FillSchema(dsFujitsuPayments, SchemaType.Source, "Grades");


            txtTitleEdit.Text= drEmployee["Title"].ToString();
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

     

            if (drEmployee["Manager"].ToString().Equals("True"))
                cbManager.Checked = true;
            else
                cbManager.Checked = false;
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
                if (sal == true)
                {

                    if (Convert.ToDecimal(txtEditSalary.Text) < start || Convert.ToDecimal(txtEditSalary.Text) > end)
                    {
                        MessageBox.Show("Salary must be between £" + Convert.ToString(start) + " and £" + Convert.ToString(end));
                    }
                    else
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
