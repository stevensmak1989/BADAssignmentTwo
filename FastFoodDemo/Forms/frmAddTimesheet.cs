using FujistuPayments;
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

        SqlDataAdapter daProject, daTask, daEmployee, daEmpTask,daClaim, daTime, daMan, daTimesheet, daTimeDets, daCost;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject,cmbBClaim, cmbBMan,cmbBTask, cmbBEmp, cmbBEmpTask,cmbBTime, cmbBTimesheet, cmbBTimeDets, cmbBCost;
        SqlCommand cmdEmp, cmdMan;
        DataRow drProject, drMan, drTask,drClaim, drEmp, drEmpTask, drTimesheet, drTimeDets, drCost;
        String connStr, sqlProject, sqlTask, sqlEmp, sqlEmpTask, sqlClaim, sqlMan,sqlTime, sqlTimesheet, sqlTimeDets, sqlCost;
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

            TextBox[] start = { txtStart1, txtStart2, txtStart3, txtStart4, txtStart5, txtStart6, txtStart7 };
            TextBox[] end = { txtEnd1, txtEnd2, txtEnd3, txtEnd4, txtEnd5, txtEnd6, txtEnd7 };
            ComboBox[] project = { cmbEmpTask, cmbEmpTask2, cmbEmpTask3, cmbEmpTask4, cmbEmpTask5, cmbEmpTask6, cmbEmpTask7 };
            Label[] date = { lblDateMon, lblDateTue, lblDateWed, lblDateThur, lblDateFri, lblDateSat, lblDateSun };

            Timesheet myTime = new Timesheet();
            timesheetDetails timeDets = new timesheetDetails();

            bool ok = true;
            errP.Clear();

            int timesheetNo;

            int noRows = dsFujitsuPayments.Tables["Timesheet"].Rows.Count;

            //drTimesheet = dsFujitsuPayments.Tables["Timesheet"].Rows[noRows - 1];
            //timesheetNo  = (int.Parse(drTimesheet["BookingNo"].ToString()) + 1);

            try
            {
                myTime.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue.ToString());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbEmployee, MyEx.toString());
            }
            try
            {
                myTime.TimesheetId = Convert.ToInt32(lblTimsheetId.Text.Trim());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblTimsheetId, MyEx.toString());
            }
            try
            {
                myTime.ApprovedBy = Convert.ToInt32(cmbApprovedBy.SelectedValue.ToString());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbApprovedBy, MyEx.toString());
            }
            try
            {
                myTime.CostCentreId = Convert.ToInt32(cmbCostCentID.SelectedValue.ToString());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbCostCentID, MyEx.toString());
            }
            try
            {
                DateTime datee = DateTime.Parse(lblDateMon.Text.Trim());
                myTime.WkEnding = datee;
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbDates, MyEx.toString());
            }
            try
            {
                if (ok)
                {

                    drTimesheet = dsFujitsuPayments.Tables["Timesheet"].NewRow();

                    drTimesheet["TimesheetID"] = myTime.TimesheetId;
                    drTimesheet["EmployeeID"] = myTime.EmployeeId;
                    drTimesheet["CostCentreID"] = myTime.CostCentreId;
                    drTimesheet["WKBeginning"] = myTime.WkEnding;
                    drTimesheet["ApprovedBy"] = myTime.ApprovedBy;


                    dsFujitsuPayments.Tables["Timesheet"].Rows.Add(drTimesheet);
                    daTimesheet.Update(dsFujitsuPayments, "Timesheet");


                    foreach (Control c in panel1.Controls)
                    {
                        if (c is Panel)
                        {
                            drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();

                            try
                            {
                                timeDets.TimesheetId = Convert.ToInt32(lblTimsheetId.Text.Trim());
                                //passed to employee Class to check

                            }
                            catch (MyException MyEx)
                            {
                                ok = false;
                                errP.SetError(lblTimsheetId, MyEx.toString());
                            }
                            try
                            {
                                timeDets.ClaimTypeId = Convert.ToInt32(cmbCostCentID.SelectedValue.ToString());
                                //passed to employee Class to check

                            }
                            catch (MyException MyEx)
                            {
                                ok = false;
                                errP.SetError(cmbCostCentID, MyEx.toString());
                            }
                            try
                            {
                                DateTime datee = DateTime.Parse(date[no].Text.Trim());
                                myTime.WkEnding = datee;
                            }
                            catch (MyException MyEx)
                            {
                                ok = false;
                                errP.SetError(cmbDates, MyEx.toString());
                            }
                            try
                            {

                                TimeSpan startTime = TimeSpan.Parse(start[no].Text.Trim());
                                timeDets.StartTime = startTime;
                            }
                            catch (MyException MyEx)
                            {
                                ok = false;
                                errP.SetError(start[no], MyEx.toString());
                            }
                            try
                            {
                                TimeSpan endTime = TimeSpan.Parse(end[no].Text.Trim());
                                timeDets.EndTime = endTime;
                            }
                            catch (MyException MyEx)
                            {
                                ok = false;
                                errP.SetError(end[no], MyEx.toString());
                            }

                            try
                            {
                                TimeSpan endTime = TimeSpan.Parse(end[no].Text.Trim());
                                timeDets.EndTime = endTime;
                            }
                            catch (MyException MyEx)
                            {
                                ok = false;
                                errP.SetError(end[no], MyEx.toString());
                            }
                            try
                            {
                                TimeSpan endTime = TimeSpan.Parse(end[no].Text.Trim());
                                timeDets.EndTime = endTime;
                            }
                            catch (MyException MyEx)
                            {
                                ok = false;
                                errP.SetError(end[no], MyEx.toString());
                            }


                            drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();
                            drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                            drTimeDets["WorkedDay"] = timeDets.WorkedDay;
                            drTimeDets["StartTime"] = timeDets.StartTime;
                            drTimeDets["EndTime"] = timeDets.EndTime;
                            drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                            drTimeDets["ProjectID"] = 1;
                            drTimeDets["TaskID"] = 1;

                            dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Add(drTimeDets);
                            daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");



                            MessageBox.Show(start[no].Text.Trim());

                            no++;
                        }
                    }
                    MessageBox.Show("Timesheet Added");
                    this.Dispose();



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }


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

            sqlTimesheet = @"select * from Timesheet";
            daTimesheet = new SqlDataAdapter(sqlTimesheet, connStr);
            cmbBTimesheet = new SqlCommandBuilder(daTimesheet);
            daTimesheet.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheet");
            daTimesheet.Fill(dsFujitsuPayments, "Timesheet");

            sqlTimeDets = @"select * from TimesheetDetails";
            daTimeDets = new SqlDataAdapter(sqlTimeDets, connStr);
            cmbBTimeDets = new SqlCommandBuilder(daTimeDets);
            daTimeDets.FillSchema(dsFujitsuPayments, SchemaType.Source, "TimesheetDetails");
            daTimeDets.Fill(dsFujitsuPayments, "TimesheetDetails");



          
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

            sqlCost = @"select CostCentreID, CostCentreDesc  from CostCentre";
            daCost = new SqlDataAdapter(sqlCost, connStr);
            cmbBCost = new SqlCommandBuilder(daCost);
            daCost.FillSchema(dsFujitsuPayments, SchemaType.Source, "CostCentre");
            daCost.Fill(dsFujitsuPayments, "CostCentre");

            cmbEmployee.DataSource = dsFujitsuPayments.Tables["Employee"];
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.DisplayMember = "EmpName";

            cmbCostCentID.DataSource = dsFujitsuPayments.Tables["CostCentre"];
            cmbCostCentID.ValueMember = "CostCentreID";
            cmbCostCentID.DisplayMember = "CostCentreDesc";


            cmbClaimType.DataSource = dsFujitsuPayments.Tables["ClaimType"];
            cmbClaimType.ValueMember = "ClaimTypeID";
            cmbClaimType.DisplayMember = "ClaimTypeDesc";



            sqlEmpTask = @"select ProjectID, TaskID, EmployeeID from ProjectTaskEmployee where EmployeeID like @EmployeeID";
            conn = new SqlConnection(connStr);
            cmdEmp = new SqlCommand(sqlEmpTask, conn);
            cmdEmp.Parameters.Add("@EmployeeID", SqlDbType.Int);
            daEmpTask = new SqlDataAdapter(cmdEmp);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");

            sqlEmpTask = @"select ProjectID, TaskID, EmployeeID from ProjectTaskEmployee where EmployeeID like @EmployeeID";
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
            drTimesheet = dsFujitsuPayments.Tables["Timesheet"].Rows[noRows - 1];
            lblTimsheetId.Text = (int.Parse(drTimesheet["TimesheetID"].ToString()) + 1).ToString();
        }
    }
}
