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

        private void cmbEmpTask6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(projId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        DataRow drProject, drMan, drTask,drClaim, drEmp, drEmpTask, drTimesheet, drTimeDets, drCost;
        String connStr, sqlProject, sqlTask, sqlEmp, sqlEmpTask, sqlClaim, sqlMan,sqlTime, sqlTimesheet, sqlTimeDets, sqlCost;
        SqlConnection conn;
        string projectId, taskID;
       private double count;


        private int no;





        private void cmbApprovedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        private void label16_Click(object sender, EventArgs e)
        {

        }
       // public static int Compare(TimeSpan t1, TimeSpan t2);
        private void btnSave_Click(object sender, EventArgs e)
        {

            TextBox[] start = { txtStart1, txtStart2, txtStart3, txtStart4, txtStart5, txtStart6, txtStart7 };
            TextBox[] end = { txtEnd1, txtEnd2, txtEnd3, txtEnd4, txtEnd5, txtEnd6, txtEnd7 };
            ComboBox[] task = { cmbEmpTask, cmbEmpTask2, cmbEmpTask3, cmbEmpTask4, cmbEmpTask5, cmbEmpTask6, cmbEmpTask7 };
            ComboBox[] project = { cmbProject, cmbProject2, cmbProject3, cmbProject4, cmbProject5, cmbProject6, cmbProject7 };
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
                    int claimtype = Convert.ToInt32(cmbClaimType.SelectedValue.ToString());

                    switch (claimtype)
                    {
                        case 1:
                            foreach (Control c in panel1.Controls)
                            {
                                if (c is Panel && ok)
                                {
                                    if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                    {
                                        TimeSpan ts = TimeSpan.Parse(start[no].Text);
                                        TimeSpan te = TimeSpan.Parse(end[no].Text);
                                        DateTime timeStart = DateTime.Parse("07:59 AM");
                                        DateTime timeEnd = DateTime.Parse("06:01 PM");

                                        TimeSpan ds = timeStart.TimeOfDay;
                                        TimeSpan de = timeEnd.TimeOfDay;

                                        if (ts.CompareTo(te) == -1)
                                        {
                                            if (ds.CompareTo(ts) != -1 || te.CompareTo(de) != -1)
                                            {
                                                MessageBox.Show("Basic hours must be between 8AM and 6PM");
                                                ok = false;
                                                break;

                                            }
                                            else
                                            {

                                                try
                                                {
                                                    timeDets.TimesheetId = Convert.ToInt32(lblTimsheetId.Text.Trim());
                                                    //passed to employee Class to check

                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(lblTimsheetId, MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {
                                                    timeDets.ClaimTypeId = Convert.ToInt32(cmbClaimType.SelectedValue.ToString());

                                                    MessageBox.Show(cmbClaimType.SelectedValue.ToString());
                                                    //passed to employee Class to check

                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(cmbCostCentID, MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {
                                                    DateTime datee = DateTime.Parse(date[no].Text.Trim());
                                                    timeDets.WorkedDay = datee;
                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(cmbDates, MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {


                                                    string str = start[no].Text;
                                                    MessageBox.Show(str);
                                                    timeDets.StartTime = str.ToString();


                                                }

                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(start[no], MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {

                                                    timeDets.EndTime = end[no].Text;
                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(end[no], MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {

                                                    timeDets.ProjectId = Convert.ToInt32(project[no].SelectedValue.ToString());
                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(project[no], MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {

                                                    timeDets.TaskId = Convert.ToInt32(task[no].SelectedValue.ToString());
                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(task[no], MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }


                                                if (ok)
                                                {
                                                    TimeSpan timediff = DateTime.Parse(end[no].Text).Subtract(DateTime.Parse(start[no].Text));
                                                    count += (double)timediff.TotalMinutes;
                                                    MessageBox.Show(Convert.ToString(count));
                                                    no++;



                                                }
                                            }


                                        }
                                        else
                                        {
                                            MessageBox.Show("Start time must be less than end time");
                                            ok = false;
                                            break;
                                        }

                                    }


                                }
                            }
                            if (count != 2400)
                            {
                                MessageBox.Show("Basic hours must be 40 hours a week ");
                                ok = false;
                                count = 0;
                                no = 0;

                            }

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
                                MessageBox.Show("Timesheet Added");
                                no = 0;
                                foreach (Control c in panel1.Controls)
                                {
                                    if (c is Panel && ok)
                                    {
                                        if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                        {
                                            drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();


                                            DateTime dt = Convert.ToDateTime(start[no].Text);
                                            TimeSpan ts = dt.TimeOfDay;

                                            DateTime dte = Convert.ToDateTime(end[no].Text);
                                            TimeSpan tse = dt.TimeOfDay;

                                            drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();
                                            drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                            drTimeDets["WorkedDay"] = date[no].Text.Trim();
                                            drTimeDets["StartTime"] = ts;
                                            drTimeDets["EndTime"] = tse;
                                            drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                            drTimeDets["ProjectID"] = Convert.ToInt32(project[no].SelectedValue);
                                            drTimeDets["TaskID"] = Convert.ToInt32(task[no].SelectedValue);

                                            dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Add(drTimeDets);
                                            daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                        }
                                    }
                                    no++;
                                }
                                if (MessageBox.Show("Do you wish to add On Call or Overtime claims?", "Add Claim", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    clear();
                                }
                                else
                                {
                                    this.Dispose();
                                }
                                
                            }
                            break;
                        case 2:
                            foreach (Control c in panel1.Controls)
                            {
                                if (c is Panel && ok)
                                {
                                    if (start[no].Text.Length != 0 && end[no].Text.Length != 0 )
                                    {
                                        TimeSpan ts = TimeSpan.Parse(start[no].Text);
                                        TimeSpan te = TimeSpan.Parse(end[no].Text);
                                        DateTime timeStart = DateTime.Parse("07:59 AM");
                                        DateTime timeEnd = DateTime.Parse("05:59 PM");

                                        TimeSpan ds = timeStart.TimeOfDay;
                                        TimeSpan de = timeEnd.TimeOfDay;

                                       
                                            if (no < 5 && te.CompareTo(de) != 1 || ts.CompareTo(ds) != 1 )
                                            {
                                                MessageBox.Show("Overtime hours must be between 6PM and 8PM Mon - Friday or All day Sat and Sun");
                                                ok = false;
                                                break;

                                            }
                                            else
                                            {

                                                try
                                                {
                                                    timeDets.TimesheetId = Convert.ToInt32(lblTimsheetId.Text.Trim());
                                                    //passed to employee Class to check

                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(lblTimsheetId, MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {
                                                    timeDets.ClaimTypeId = Convert.ToInt32(cmbClaimType.SelectedValue.ToString());

                                                    MessageBox.Show(cmbClaimType.SelectedValue.ToString());
                                                    //passed to employee Class to check

                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(cmbCostCentID, MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {
                                                    DateTime datee = DateTime.Parse(date[no].Text.Trim());
                                                    timeDets.WorkedDay = datee;
                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(cmbDates, MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {


                                                    string str = start[no].Text;
                                                    MessageBox.Show(str);
                                                    timeDets.StartTime = str.ToString();


                                                }

                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(start[no], MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {

                                                    timeDets.EndTime = end[no].Text;
                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(end[no], MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {

                                                    timeDets.ProjectId = Convert.ToInt32(project[no].SelectedValue.ToString());
                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(project[no], MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }
                                                try
                                                {

                                                    timeDets.TaskId = Convert.ToInt32(task[no].SelectedValue.ToString());
                                                }
                                                catch (MyException MyEx)
                                                {
                                                    ok = false;
                                                    errP.SetError(task[no], MyEx.toString());
                                                    count = 0;
                                                    no = 0;
                                                    break;
                                                }


                                               
                                            }


                                        
                                        
                                    }


                                }
                                no++;
                            }


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
                                MessageBox.Show("Timesheet Added");
                                no = 0;
                                foreach (Control c in panel1.Controls)
                                {
                                    if (c is Panel && ok)
                                    {
                                        if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                        {
                                            drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();


                                            DateTime dt = Convert.ToDateTime(start[no].Text);
                                            TimeSpan ts = dt.TimeOfDay;

                                            DateTime dte = Convert.ToDateTime(end[no].Text);
                                            TimeSpan tse = dte.TimeOfDay;

                                            drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();
                                            drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                            drTimeDets["WorkedDay"] = date[no].Text.Trim();
                                            drTimeDets["StartTime"] = ts;
                                            drTimeDets["EndTime"] = tse;
                                            drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                            drTimeDets["ProjectID"] = Convert.ToInt32(project[no].SelectedValue);
                                            drTimeDets["TaskID"] = Convert.ToInt32(task[no].SelectedValue);

                                            dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Add(drTimeDets);
                                            daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                        }
                                    }
                                    no++;
                                }

                                if (MessageBox.Show("Do you wish to add On Call or Basic hours claims?", "Add Claim", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    clear();
                                }
                                else
                                {
                                    this.Dispose();
                                }
                            }
                            break;
                        case 3:
                            foreach (Control c in panel1.Controls)
                            {
                                if (c is Panel && ok)
                                {
                                    if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                    {
                                        TimeSpan ts = TimeSpan.Parse(start[no].Text);
                                        TimeSpan te = TimeSpan.Parse(end[no].Text);
                                        DateTime timeStart = DateTime.Parse("07:59 AM");
                                        DateTime timeEnd = DateTime.Parse("05:59 PM");

                                        TimeSpan ds = timeStart.TimeOfDay;
                                        TimeSpan de = timeEnd.TimeOfDay;


                                        if (no < 5 && te.CompareTo(de) != 1 || ts.CompareTo(ds) != 1)
                                        {
                                            MessageBox.Show("OnCall hours must be between 6PM and 8PM Mon - Friday or All day Sat and Sun");
                                            ok = false;
                                            break;

                                        }
                                        else
                                        {

                                            try
                                            {
                                                timeDets.TimesheetId = Convert.ToInt32(lblTimsheetId.Text.Trim());
                                                //passed to employee Class to check

                                            }
                                            catch (MyException MyEx)
                                            {
                                                ok = false;
                                                errP.SetError(lblTimsheetId, MyEx.toString());
                                                count = 0;
                                                no = 0;
                                                break;
                                            }
                                            try
                                            {
                                                timeDets.ClaimTypeId = Convert.ToInt32(cmbClaimType.SelectedValue.ToString());

                                                MessageBox.Show(cmbClaimType.SelectedValue.ToString());
                                                //passed to employee Class to check

                                            }
                                            catch (MyException MyEx)
                                            {
                                                ok = false;
                                                errP.SetError(cmbCostCentID, MyEx.toString());
                                                count = 0;
                                                no = 0;
                                                break;
                                            }
                                            try
                                            {
                                                DateTime datee = DateTime.Parse(date[no].Text.Trim());
                                                timeDets.WorkedDay = datee;
                                            }
                                            catch (MyException MyEx)
                                            {
                                                ok = false;
                                                errP.SetError(cmbDates, MyEx.toString());
                                                count = 0;
                                                no = 0;
                                                break;
                                            }
                                            try
                                            {


                                                string str = start[no].Text;
                                                MessageBox.Show(str);
                                                timeDets.StartTime = str.ToString();


                                            }

                                            catch (MyException MyEx)
                                            {
                                                ok = false;
                                                errP.SetError(start[no], MyEx.toString());
                                                count = 0;
                                                no = 0;
                                                break;
                                            }
                                            try
                                            {

                                                timeDets.EndTime = end[no].Text;
                                            }
                                            catch (MyException MyEx)
                                            {
                                                ok = false;
                                                errP.SetError(end[no], MyEx.toString());
                                                count = 0;
                                                no = 0;
                                                break;
                                            }
                                            try
                                            {

                                                timeDets.ProjectId = Convert.ToInt32(project[no].SelectedValue.ToString());
                                            }
                                            catch (MyException MyEx)
                                            {
                                                ok = false;
                                                errP.SetError(project[no], MyEx.toString());
                                                count = 0;
                                                no = 0;
                                                break;
                                            }
                                            try
                                            {

                                                timeDets.TaskId = Convert.ToInt32(task[no].SelectedValue.ToString());
                                            }
                                            catch (MyException MyEx)
                                            {
                                                ok = false;
                                                errP.SetError(task[no], MyEx.toString());
                                                count = 0;
                                                no = 0;
                                                break;
                                            }



                                        }




                                    }


                                }
                                no++;
                            }


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
                                MessageBox.Show("Timesheet Added");
                                no = 0;
                                foreach (Control c in panel1.Controls)
                                {
                                    if (c is Panel && ok)
                                    {
                                        if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                        {
                                            drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();


                                            DateTime dt = Convert.ToDateTime(start[no].Text);
                                            TimeSpan ts = dt.TimeOfDay;

                                            DateTime dte = Convert.ToDateTime(end[no].Text);
                                            TimeSpan tse = dte.TimeOfDay;

                                            drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();
                                            drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                            drTimeDets["WorkedDay"] = date[no].Text.Trim();
                                            drTimeDets["StartTime"] = ts;
                                            drTimeDets["EndTime"] = tse;
                                            drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                            drTimeDets["ProjectID"] = Convert.ToInt32(project[no].SelectedValue);
                                            drTimeDets["TaskID"] = Convert.ToInt32(task[no].SelectedValue);

                                            dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Add(drTimeDets);
                                            daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                        }
                                    }
                                    no++;
                                }

                                if (MessageBox.Show("Do you wish to add basic hours or Overtime claims?", "Add Claim", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    clear();
                                }
                                else
                                {
                                    this.Dispose();
                                }
                            }
                            break;
                        default: MessageBox.Show("Please enter a claim type");
                            ok = false;
                            break;
                    }

                    
                    



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }


        }
        private void clear()
        {
            
            TextBox[] start = { txtStart1, txtStart2, txtStart3, txtStart4, txtStart5, txtStart6, txtStart7 };
            TextBox[] end = { txtEnd1, txtEnd2, txtEnd3, txtEnd4, txtEnd5, txtEnd6, txtEnd7 };
            
            for(int i = 0; i< 7; i++)
            {
                start[i].Clear();
               end[i].Clear
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



            sqlEmpTask = @"select ProjectID , TaskID , EmployeeID from ProjectTaskEmployee where EmployeeID like @EmployeeID";
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
            int numb = 0;

            if (cmbEmployee.Focused == true)
            {
                ComboBox[] task = { cmbEmpTask, cmbEmpTask2, cmbEmpTask3, cmbEmpTask4, cmbEmpTask5, cmbEmpTask6, cmbEmpTask7 };
                ComboBox[] project = { cmbProject, cmbProject2, cmbProject3, cmbProject4, cmbProject5, cmbProject6, cmbProject7 };
                dsFujitsuPayments.Tables["ProjectTaskEmployee"].Clear();
                cmdEmp.Parameters["@EmployeeID"].Value = cmbEmployee.SelectedValue;

                daEmpTask.Fill(dsFujitsuPayments, "ProjectTaskEmployee");
                for(int i = 0; i<7; i++)
                {



                    project[i].DataSource = dsFujitsuPayments.Tables["ProjectTaskEmployee"];
                    project[i].ValueMember = "ProjectID";
                    project[i].DisplayMember = "ProjectID";

                    task[i].DataSource = dsFujitsuPayments.Tables["ProjectTaskEmployee"];
                    task[i].ValueMember = "TaskID";
                    task[i].DisplayMember = "TaskID";

                    numb++;
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
