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
    public partial class frmAddTimesheet : Form
    {

        SqlDataAdapter daProject, daTask, daEmployee, daEmpTask,daClaim, daTime, daMan;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject,cmbBClaim, cmbBMan,cmbBTask, cmbBEmp, cmbBEmpTask,cmbBTime;
        SqlCommand cmdEmp, cmdMan;
        DataRow drProject, drMan, drTask,drClaim, drEmp, drEmpTask;
        String connStr, sqlProject, sqlTask, sqlEmp, sqlEmpTask, sqlClaim, sqlMan,sqlTime;
        SqlConnection conn;

       private int no;





        private void cmbApprovedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        



        public frmAddTimesheet()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void frmAddTimesheet_Load(object sender, EventArgs e)
        {

            setDates(0);
            findMondays();

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlClaim = @"select * from ClaimType";
            daClaim = new SqlDataAdapter(sqlClaim, connStr);
            cmbBClaim = new SqlCommandBuilder(daClaim);
            daClaim.FillSchema(dsFujitsuPayments, SchemaType.Source, "ClaimType");
            daClaim.Fill(dsFujitsuPayments, "ClaimType");

            sqlEmp = @"select EmployeeID, Surname + ' ' + Forename as EmpName from Employee";
            daEmployee = new SqlDataAdapter(sqlEmp, connStr);
            cmbBEmp = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

            sqlTime = @"select * from Timesheet";
            daTime = new SqlDataAdapter(sqlTime, connStr);
            cmbBTime = new SqlCommandBuilder(daTime);
            daTime.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheet");
            daTime.Fill(dsFujitsuPayments, "Timesheet");


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


            cmbEmployee.DataSource = dsFujitsuPayments.Tables["Employee"];
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.DisplayMember = "EmpName";


            cmbClaimType.DataSource = dsFujitsuPayments.Tables["ClaimType"];
            cmbClaimType.ValueMember = "ClaimTypeID";
            cmbClaimType.DisplayMember = "ClaimTypeDesc";



            sqlEmpTask = @"select * from ProjectTaskEmployee where EmployeeID like @EmployeeID";
            conn = new SqlConnection(connStr);
            cmdEmp = new SqlCommand(sqlEmpTask, conn);
            cmdEmp.Parameters.Add("@EmployeeID", SqlDbType.Int);
            daEmpTask = new SqlDataAdapter(cmdEmp);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");


            

            

            int noRows = dsFujitsuPayments.Tables["Timesheet"].Rows.Count;

            if (noRows == 0)
                lblTimsheetId.Text = "1000";
            else
            {
                getNumber(noRows);
            }

        }

        private void findMondays()
        {
            DateTime mon = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday));
            var date = mon.Date;
            DateTime[] startDate = new DateTime[7];
            int count = 0;


            for(int i = 0; i <7; i++)
            {
                
                startDate[i] = date.AddDays(count);
                count += 7;
            }

            for(int i=0; i <7; i++ )
            {
                cmbDates.Items.Add(startDate[i].ToString());
                
            }
        }

        private void setDates(int count)
        {

            DateTime start = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday));
            var date = start.Date;
            DateTime mon = date.AddDays(count).Date;
            lblDateMon.Text = mon.ToShortDateString();
            DateTime tue = mon.AddDays(1).Date;
            lblDateTue.Text = tue.ToShortDateString();
            DateTime wed = tue.AddDays(1).Date;
            lblDateWed.Text = wed.ToShortDateString();
            DateTime thurs = wed.AddDays(1).Date;
            lblDateThur.Text = thurs.ToShortDateString();
            DateTime fri = thurs.AddDays(1).Date;
            lblDateFri.Text = fri.ToShortDateString();
            DateTime sat = fri.AddDays(1).Date;
            lblDateSat.Text = sat.ToShortDateString();
            DateTime sun = sat.AddDays(1).Date;
            lblDateSun.Text = sun.ToShortDateString();
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbEmployee.Focused == true)
            {


                dsFujitsuPayments.Tables["ProjectTaskEmployee"].Clear();
                cmdEmp.Parameters["@EmployeeID"].Value = cmbEmployee.SelectedValue;

                daEmpTask.Fill(dsFujitsuPayments, "ProjectTaskEmployee");
                foreach (Control c in panel1.Controls)
                {
                    
                    if (c is ComboBox)
                    {
                        ComboBox x = (ComboBox)c;
                        x.DataSource = dsFujitsuPayments.Tables["ProjectTaskEmployee"];
                        x.ValueMember = "TaskID";
                        x.DisplayMember = "ProjectID" + "TaskID";
                    }
                    
                }
            }
        }

        private void cmbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int selectedIndex = cmbDates.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    setDates(0);
                    break;
                case 1:
                    setDates(7);
                    break;
                case 2:
                    setDates(14);
                    break;
                case 3:
                    setDates(21);
                    break;
                case 4:
                    setDates(28);
                    break;
                case 5:
                    setDates(35);
                    break;
                case 6:
                    setDates(42);
                    break;
                default:
                    // code block
                    break;
            }
        }
        private void getNumber(int noRows)
        {
            drClaim = dsFujitsuPayments.Tables["Timesheet"].Rows[noRows - 1];
            lblTimesheetId.Text = (int.Parse(drClaim["TimesheetID"].ToString()) + 1).ToString();
        }
    }
}
