using FujistuPayments;
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
    public partial class frmEditTimesheet : Form
    {
        SqlDataAdapter daProject, daCount, daEmployee, daEmpTask, daEmpTask1, daClaim,  daMan, daTimesheet, daTimeDets, daCost;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder  cmbBClaim,  cmbBEmp,  cmbBTimesheet, cmbBTimeDets, cmbBCost;

       

        SqlCommand cmdEmp,  cmdProj, cmdCount, cmdEmp1 ;

        DataRow drProject, drCount,  drClaim,  drTimeDets;

        private void cmbProject3_SelectedIndexChanged(object sender, EventArgs e)
        {
            task(2);
        }

        private void cmbProject4_SelectedIndexChanged(object sender, EventArgs e)
        {
            task(3);
        }

        private void cmbProject5_SelectedIndexChanged(object sender, EventArgs e)
        {
            task(4);
        }

        private void cmbProject6_SelectedIndexChanged(object sender, EventArgs e)
        {
            task(5);
        }

        private void cmbProject7_SelectedIndexChanged(object sender, EventArgs e)
        {
            task(6);
        }

        private void cmbProject2_SelectedIndexChanged(object sender, EventArgs e)
        {
            task(1);
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            task(0);
        }

        String connStr, sqlProject, sqlEmp, sqlCount, sqlEmpTask, sqlClaim, sqlMan,  sqlTimesheet, sqlTimeDets, sqlCost, sqlEmpTask1;
        SqlConnection conn;
        private double count;
        private int numb,no, timesheetValue;

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
                                        if (MyValidation.validTimespan1(start[no].Text) == true && MyValidation.validTimespan1(end[no].Text))
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

                                                        if (project[no] != null && project[no].SelectedIndex != -1)
                                                        {
                                                            timeDets.ProjectId = Convert.ToInt32(project[no].SelectedItem.ToString());
                                                        }
                                                        else
                                                            throw new MyException("Please enter a valid Project");
                                                    }
                                                    catch (MyException MyEx)
                                                    {
                                                        ok = false;
                                                        errP.SetError(project[no], MyEx.toString());
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    catch (System.NullReferenceException ex)
                                                    {
                                                        ok = false;
                                                        errP.SetError(project[no], "please select a Project");
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    try
                                                    {

                                                        if (task[no] != null && task[no].SelectedIndex != -1)
                                                        {

                                                            timeDets.TaskId = Convert.ToInt32(task[no].SelectedItem.ToString());
                                                        }
                                                        else
                                                            throw new MyException("Please enter a valid Task");
                                                    }
                                                    catch (MyException MyEx)
                                                    {
                                                        ok = false;
                                                        errP.SetError(task[no], MyEx.toString());
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    catch (System.NullReferenceException ex)
                                                    {
                                                        ok = false;
                                                        errP.SetError(task[no], "please select a Task");
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }


                                                    if (ok)
                                                    {
                                                        TimeSpan timediff = DateTime.Parse(end[no].Text).Subtract(DateTime.Parse(start[no].Text));
                                                        count += (double)timediff.TotalMinutes;

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
                                drClaim.BeginEdit();

                                drClaim["TimesheetID"] = myTime.TimesheetId;
                                drClaim["EmployeeID"] = myTime.EmployeeId;
                                drClaim["CostCentreID"] = myTime.CostCentreId;
                                drClaim["WKBeginning"] = myTime.WkEnding;
                                drClaim["ApprovedBy"] = myTime.ApprovedBy;

                                drClaim.EndEdit();
                                daTimesheet.Update(dsFujitsuPayments, "Timesheet");

                                MessageBox.Show("Timesheet Updated");
                                no = 0;
                                foreach (Control c in panel1.Controls)
                                {
                                    if (c is Panel && ok)
                                    {
                                        if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                        {
                                            DataTable dtable = dsFujitsuPayments.Tables["Timesheets"];
                                            int x = 0, total = 0, iterator = 0;
                                            Boolean exists = false;

                                            foreach (DataRow row in dtable.Rows)
                                            {
                                                x++;
                                            }

                                            DateTime[] datesEx = new DateTime[x];

                                            foreach (DataRow row in dtable.Rows)
                                            {
                                                for (int w = 0; w < 7; w++)
                                                {
                                                    DateTime newDT = Convert.ToDateTime(date[w].Text);
                                                    DateTime dbDT = Convert.ToDateTime(row.Field<DateTime>("WorkedDay"));

                                                    if (newDT == dbDT)
                                                    {
                                                        datesEx[iterator] = row.Field<DateTime>("WorkedDay");
                                                        exists = true;
                                                        total = w;
                                                        iterator++;

                                                    }

                                                }
                                                if (exists)
                                                {
                                                    object[] primaryKey = new object[3];

                                                    primaryKey[0] = row.Field<int>("TimesheetID");
                                                    primaryKey[1] = row.Field<DateTime>("WorkedDay");
                                                    primaryKey[2] = row.Field<TimeSpan>("StartTime");



                                                    drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Find(primaryKey);
                                                    drTimeDets.BeginEdit();


                                                    DateTime dt = Convert.ToDateTime(start[total].Text);
                                                    TimeSpan ts = dt.TimeOfDay;

                                                    DateTime dte = Convert.ToDateTime(end[total].Text);
                                                    TimeSpan tse = dte.TimeOfDay;


                                                    drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                                    drTimeDets["WorkedDay"] = date[total].Text.Trim();
                                                    drTimeDets["StartTime"] = ts;
                                                    drTimeDets["EndTime"] = tse;
                                                    drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                                    drTimeDets["ProjectID"] = Convert.ToInt32(project[total].SelectedItem);
                                                    drTimeDets["TaskID"] = Convert.ToInt32(task[total].SelectedItem);

                                                    drTimeDets.EndEdit();
                                                    daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                                }

                                            }
                                            exists = true;
                                            DateTime compDT = Convert.ToDateTime(end[no].Text);
                                            for (int z = 0; z < iterator; z++)
                                            {

                                                if (compDT == datesEx[z])
                                                {
                                                    exists = false;

                                                }

                                            }
                                            if (exists)
                                            {
                                                drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();


                                                DateTime dt = Convert.ToDateTime(start[no].Text);
                                                TimeSpan ts = dt.TimeOfDay;

                                                DateTime dte = Convert.ToDateTime(end[no].Text);
                                                TimeSpan tse = dte.TimeOfDay;


                                                drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                                drTimeDets["WorkedDay"] = date[total].Text.Trim();
                                                drTimeDets["StartTime"] = ts;
                                                drTimeDets["EndTime"] = tse;
                                                drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                                drTimeDets["ProjectID"] = Convert.ToInt32(project[no].SelectedItem);
                                                drTimeDets["TaskID"] = Convert.ToInt32(task[no].SelectedItem);

                                                dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Add(drTimeDets);
                                                daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                            }




                                            x++;
                                            break;
                                        }







                                    }
                                    no++;
                                }
                                if (MessageBox.Show("Do you wish to update On Call or Overtime claims?", "Update Claim", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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
                            int claimType = (int)cmbClaimType.SelectedValue + 1;
                            if (checkOT(claimType) == true)
                            {


                                foreach (Control c in panel1.Controls)
                                {


                                    if (c is Panel && ok)
                                    {
                                        if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                        {
                                            if (MyValidation.validTimespan1(start[no].Text) == true && MyValidation.validTimespan1(end[no].Text))
                                            {
                                                TimeSpan ts = TimeSpan.Parse(start[no].Text);
                                                TimeSpan te = TimeSpan.Parse(end[no].Text);
                                                DateTime timeStart = DateTime.Parse("07:59 AM");
                                                DateTime timeEnd = DateTime.Parse("05:59 PM");

                                                TimeSpan ds = timeStart.TimeOfDay;
                                                TimeSpan de = timeEnd.TimeOfDay;


                                                if (no < 5 && te.CompareTo(de) != 1 || ts.CompareTo(ds) != 1 && no < 5)
                                                {
                                                    MessageBox.Show("Overtime hours must be between 6PM and 8AM Mon - Friday or All day Sat and Sun");
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

                                                        if (project[no] != null && project[no].SelectedIndex != -1)
                                                        {
                                                            timeDets.ProjectId = Convert.ToInt32(project[no].SelectedItem.ToString());
                                                        }
                                                        else
                                                            throw new MyException("Please enter a valid Project");
                                                    }
                                                    catch (MyException MyEx)
                                                    {
                                                        ok = false;
                                                        errP.SetError(project[no], MyEx.toString());
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    catch (System.NullReferenceException ex)
                                                    {
                                                        ok = false;
                                                        errP.SetError(project[no], "please select a Project");
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    try
                                                    {

                                                        if (task[no] != null && task[no].SelectedIndex != -1)
                                                        {

                                                            timeDets.TaskId = Convert.ToInt32(task[no].SelectedItem.ToString());
                                                        }
                                                        else
                                                            throw new MyException("Please enter a valid Task");
                                                    }
                                                    catch (MyException MyEx)
                                                    {
                                                        ok = false;
                                                        errP.SetError(task[no], MyEx.toString());
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    catch (System.NullReferenceException ex)
                                                    {
                                                        ok = false;
                                                        errP.SetError(task[no], "please select a Task");
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }




                                                }




                                            }
                                            else
                                            {
                                                ok = false;
                                                MessageBox.Show("Please enter a valid start or end Time");
                                                count = 0;
                                                no = 0;
                                                break;
                                            }


                                        }
                                        no++;
                                    }
                                }





                                if (ok)
                                {
                                    drClaim.BeginEdit();

                                    drClaim["TimesheetID"] = myTime.TimesheetId;
                                    drClaim["EmployeeID"] = myTime.EmployeeId;
                                    drClaim["CostCentreID"] = myTime.CostCentreId;
                                    drClaim["WKBeginning"] = myTime.WkEnding;
                                    drClaim["ApprovedBy"] = myTime.ApprovedBy;

                                    drClaim.EndEdit();
                                    daTimesheet.Update(dsFujitsuPayments, "Timesheet");

                                    MessageBox.Show("Timesheet Updated");
                                    no = 0;
                                    foreach (Control c in panel1.Controls)
                                    {
                                        if (c is Panel && ok)
                                        {
                                            if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                            {
                                                DataTable dtable = dsFujitsuPayments.Tables["Timesheets"];
                                                int x = 0, total = 0, iterator = 0;
                                                Boolean exists = false;

                                                foreach (DataRow row in dtable.Rows)
                                                {
                                                    x++;
                                                }

                                                DateTime[] datesEx = new DateTime[x];

                                                foreach (DataRow row in dtable.Rows)
                                                {
                                                    for (int w = 0; w < 7; w++)
                                                    {
                                                        DateTime newDT = Convert.ToDateTime(date[w].Text);
                                                        DateTime dbDT = Convert.ToDateTime(row.Field<DateTime>("WorkedDay"));

                                                        if (newDT == dbDT)
                                                        {
                                                            datesEx[iterator] = row.Field<DateTime>("WorkedDay");
                                                            exists = true;
                                                            total = w;
                                                            iterator++;

                                                        }

                                                    }
                                                    if (exists)
                                                    {
                                                        object[] primaryKey = new object[3];

                                                        primaryKey[0] = row.Field<int>("TimesheetID");
                                                        primaryKey[1] = row.Field<DateTime>("WorkedDay");
                                                        primaryKey[2] = row.Field<TimeSpan>("StartTime");



                                                        drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Find(primaryKey);
                                                        drTimeDets.BeginEdit();


                                                        DateTime dt = Convert.ToDateTime(start[total].Text);
                                                        TimeSpan ts = dt.TimeOfDay;

                                                        DateTime dte = Convert.ToDateTime(end[total].Text);
                                                        TimeSpan tse = dte.TimeOfDay;


                                                        drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                                        drTimeDets["WorkedDay"] = date[total].Text.Trim();
                                                        drTimeDets["StartTime"] = ts;
                                                        drTimeDets["EndTime"] = tse;
                                                        drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                                        drTimeDets["ProjectID"] = Convert.ToInt32(project[total].SelectedItem);
                                                        drTimeDets["TaskID"] = Convert.ToInt32(task[total].SelectedItem);

                                                        drTimeDets.EndEdit();
                                                        daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                                    }

                                                }
                                                exists = true;
                                                DateTime compDT = Convert.ToDateTime(end[no].Text);
                                                for (int z = 0; z < iterator; z++)
                                                {

                                                    if (compDT == datesEx[z])
                                                    {
                                                        exists = false;

                                                    }

                                                }
                                                if (exists)
                                                {
                                                    drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();


                                                    DateTime dt = Convert.ToDateTime(start[no].Text);
                                                    TimeSpan ts = dt.TimeOfDay;

                                                    DateTime dte = Convert.ToDateTime(end[no].Text);
                                                    TimeSpan tse = dte.TimeOfDay;


                                                    drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                                    drTimeDets["WorkedDay"] = date[total].Text.Trim();
                                                    drTimeDets["StartTime"] = ts;
                                                    drTimeDets["EndTime"] = tse;
                                                    drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                                    drTimeDets["ProjectID"] = Convert.ToInt32(project[no].SelectedItem);
                                                    drTimeDets["TaskID"] = Convert.ToInt32(task[no].SelectedItem);

                                                    dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Add(drTimeDets);
                                                    daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                                }




                                                x++;
                                                break;
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
                            }
                            else
                            {
                                MessageBox.Show("An on call claim already exists for these number, please edit an existing claim.");
                                ok = false;
                                clear();
                            }

                            break;
                        case 3:
                            int claimType1 = (int)cmbClaimType.SelectedValue - 1;
                            if (checkOT(claimType1))
                            {
                                foreach (Control c in panel1.Controls)
                                {



                                    if (c is Panel && ok)
                                    {
                                        if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                        {

                                            if (MyValidation.validTimespan1(start[no].Text) == true && MyValidation.validTimespan1(end[no].Text))
                                            {

                                                TimeSpan ts = TimeSpan.Parse(start[no].Text);
                                                TimeSpan te = TimeSpan.Parse(end[no].Text);
                                                DateTime timeStart = DateTime.Parse("07:59 AM");
                                                DateTime timeEnd = DateTime.Parse("05:59 PM");

                                                TimeSpan ds = timeStart.TimeOfDay;
                                                TimeSpan de = timeEnd.TimeOfDay;


                                                if (no < 5 && te.CompareTo(de) != 1 || ts.CompareTo(ds) != 1 && no < 5)
                                                {
                                                    MessageBox.Show("OnCall hours must be between 6PM and 8AM Mon - Friday or All day Sat and Sun");
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

                                                        if (project[no] != null && project[no].SelectedIndex != -1)
                                                        {
                                                            timeDets.ProjectId = Convert.ToInt32(project[no].SelectedItem.ToString());
                                                        }
                                                        else
                                                            throw new MyException("Please enter a valid Project");
                                                    }
                                                    catch (MyException MyEx)
                                                    {
                                                        ok = false;
                                                        errP.SetError(project[no], MyEx.toString());
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    catch (System.NullReferenceException ex)
                                                    {
                                                        ok = false;
                                                        errP.SetError(project[no], "please select a Project");
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    try
                                                    {

                                                        if (task[no] != null && task[no].SelectedIndex != -1)
                                                        {

                                                            timeDets.TaskId = Convert.ToInt32(task[no].SelectedItem.ToString());
                                                        }
                                                        else
                                                            throw new MyException("Please enter a valid Task");
                                                    }
                                                    catch (MyException MyEx)
                                                    {
                                                        ok = false;
                                                        errP.SetError(task[no], MyEx.toString());
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }
                                                    catch (System.NullReferenceException ex)
                                                    {
                                                        ok = false;
                                                        errP.SetError(task[no], "please select a Task");
                                                        count = 0;
                                                        no = 0;
                                                        break;
                                                    }



                                                }




                                            }




                                        }
                                        no++;

                                    }
                                }


                                if (ok)
                                {
                                    drClaim.BeginEdit();

                                    drClaim["TimesheetID"] = myTime.TimesheetId;
                                    drClaim["EmployeeID"] = myTime.EmployeeId;
                                    drClaim["CostCentreID"] = myTime.CostCentreId;
                                    drClaim["WKBeginning"] = myTime.WkEnding;
                                    drClaim["ApprovedBy"] = myTime.ApprovedBy;

                                    drClaim.EndEdit();
                                    daTimesheet.Update(dsFujitsuPayments, "Timesheet");

                                    MessageBox.Show("Timesheet Updated");
                                    no = 0;
                                    foreach (Control c in panel1.Controls)
                                    {
                                        if (c is Panel && ok)
                                        {
                                            if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                            {
                                                DataTable dtable = dsFujitsuPayments.Tables["Timesheets"];
                                                int x = 0, total = 0, iterator = 0;
                                                Boolean exists = false;

                                                foreach (DataRow row in dtable.Rows)
                                                {
                                                    x++;
                                                }

                                                DateTime[] datesEx = new DateTime[x];

                                                foreach (DataRow row in dtable.Rows)
                                                {
                                                    for (int w = 0; w < 7; w++)
                                                    {
                                                        DateTime newDT = Convert.ToDateTime(date[w].Text);
                                                        DateTime dbDT = Convert.ToDateTime(row.Field<DateTime>("WorkedDay"));

                                                        if (newDT == dbDT)
                                                        {
                                                            datesEx[iterator] = row.Field<DateTime>("WorkedDay");
                                                            exists = true;
                                                            total = w;
                                                            iterator++;

                                                        }

                                                    }
                                                    if (exists)
                                                    {
                                                        object[] primaryKey = new object[3];

                                                        primaryKey[0] = row.Field<int>("TimesheetID");
                                                        primaryKey[1] = row.Field<DateTime>("WorkedDay");
                                                        primaryKey[2] = row.Field<TimeSpan>("StartTime");



                                                        drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Find(primaryKey);
                                                        drTimeDets.BeginEdit();


                                                        DateTime dt = Convert.ToDateTime(start[total].Text);
                                                        TimeSpan ts = dt.TimeOfDay;

                                                        DateTime dte = Convert.ToDateTime(end[total].Text);
                                                        TimeSpan tse = dte.TimeOfDay;


                                                        drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                                        drTimeDets["WorkedDay"] = date[total].Text.Trim();
                                                        drTimeDets["StartTime"] = ts;
                                                        drTimeDets["EndTime"] = tse;
                                                        drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                                        drTimeDets["ProjectID"] = Convert.ToInt32(project[total].SelectedItem);
                                                        drTimeDets["TaskID"] = Convert.ToInt32(task[total].SelectedItem);

                                                        drTimeDets.EndEdit();
                                                        daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                                    }

                                                }
                                                exists = true;
                                                DateTime compDT = Convert.ToDateTime(end[no].Text);
                                                for (int z = 0; z < iterator; z++)
                                                {

                                                    if (compDT == datesEx[z])
                                                    {
                                                        exists = false;

                                                    }

                                                }
                                                if (exists)
                                                {
                                                    drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].NewRow();


                                                    DateTime dt = Convert.ToDateTime(start[no].Text);
                                                    TimeSpan ts = dt.TimeOfDay;

                                                    DateTime dte = Convert.ToDateTime(end[no].Text);
                                                    TimeSpan tse = dte.TimeOfDay;


                                                    drTimeDets["TimesheetID"] = timeDets.TimesheetId;
                                                    drTimeDets["WorkedDay"] = date[total].Text.Trim();
                                                    drTimeDets["StartTime"] = ts;
                                                    drTimeDets["EndTime"] = tse;
                                                    drTimeDets["ClaimTypeID"] = timeDets.ClaimTypeId;
                                                    drTimeDets["ProjectID"] = Convert.ToInt32(project[no].SelectedItem);
                                                    drTimeDets["TaskID"] = Convert.ToInt32(task[no].SelectedItem);

                                                    dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Add(drTimeDets);
                                                    daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                                                }




                                                x++;
                                                break;
                                            }







                                        }
                                        no++;
                                    }

                                    if (MessageBox.Show("Do you wish to update basic hours or Overtime claims?", "Add Claim", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        clear();
                                    }
                                    else
                                    {
                                        this.Dispose();
                                    }
                                }
                            }
                            else
                            {
                                ok = false;
                                MessageBox.Show("An overtime claim already exists for these hours");
                                count = 0;
                                no = 0;
                                break;
                            }

                            break;
                        default:
                            MessageBox.Show("Please enter a claim type");
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

            for (int i = 0; i < 7; i++)
            {
                start[i].Clear();
                end[i].Clear();
            }
        }
        private Boolean checkOT(int claimType)
        {
            Boolean ok = true;

            sqlProject = @"Select  * from TimesheetDetails where TimesheetID = @Timesheet AND ClaimTypeID = @ClaimType";
            conn = new SqlConnection(connStr);
            cmdProj = new SqlCommand(sqlProject, conn);
            cmdProj.Parameters.Add("@Timesheet", SqlDbType.Int);
            cmdProj.Parameters.Add("@ClaimType", SqlDbType.Int);
            daProject = new SqlDataAdapter(cmdProj);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets");

            cmdProj.Parameters["@Timesheet"].Value = Convert.ToInt32(lblTimsheetId.Text);
            cmdProj.Parameters["@ClaimType"].Value = claimType;


            daProject.Fill(dsFujitsuPayments, "Timesheets");

            TextBox[] start = { txtStart1, txtStart2, txtStart3, txtStart4, txtStart5, txtStart6, txtStart7 };
            TextBox[] end = { txtEnd1, txtEnd2, txtEnd3, txtEnd4, txtEnd5, txtEnd6, txtEnd7 };
            Label[] date = { lblDateMon, lblDateTue, lblDateWed, lblDateThur, lblDateFri, lblDateSat, lblDateSun };


            DataTable dt = dsFujitsuPayments.Tables["Timesheets"];
            int numb = 0, count = 0, x = 0;

            string startime, endtime, starttimeNew, endtimeNew;



            foreach (DataRow row in dt.Rows)
            {

                numb++;

            }

            if (numb != 0)
            {
                DateTime[] startTime = new DateTime[numb];
                DateTime[] endTime = new DateTime[numb];
                TimeSpan[] startTimes = new TimeSpan[numb];
                TimeSpan[] endTimes = new TimeSpan[numb];
                DateTime[] dbDate = new DateTime[numb];


                DateTime[] startTimeNew = new DateTime[numb];
                DateTime[] endTimeNew = new DateTime[numb];
                TimeSpan[] startTimesNew = new TimeSpan[numb];
                TimeSpan[] endTimesNew = new TimeSpan[numb];
                DateTime[] labelDay = new DateTime[numb];



                foreach (DataRow row in dt.Rows)
                {
                    drProject = row;
                    startime = Convert.ToString(drProject["StartTime"].ToString());

                    endtime = Convert.ToString(drProject["EndTime"].ToString());

                    startTime[x] = Convert.ToDateTime(startime);
                    endTime[x] = Convert.ToDateTime(endtime);
                    startTimes[x] = startTime[x].TimeOfDay;
                    endTimes[x] = endTime[x].TimeOfDay;
                    dbDate[x] = Convert.ToDateTime(drProject["WorkedDay"].ToString());


                    x++;

                }
                int size = 0;

                for (int c = 0; c < 7; c++)
                {
                    if (start[c].Text != "")
                    {
                        DateTime ndt = Convert.ToDateTime(start[c].Text);
                        DateTime edt = Convert.ToDateTime(end[c].Text);

                        startTimeNew[size] = ndt;
                        endTimeNew[size] = edt;
                        startTimesNew[size] = startTimeNew[size].TimeOfDay;
                        endTimesNew[size] = endTimeNew[size].TimeOfDay;
                        labelDay[size] = Convert.ToDateTime(date[c].Text);

                        size++;
                    }
                }



                for (int i = 0; i < numb; i++)
                {
                    if (labelDay[i].CompareTo(dbDate[i]) == 0)
                    {
                        if ((startTimesNew[i] >= startTimes[i]) && (startTimesNew[i] <= endTimes[i]) || (endTimesNew[i] >= startTimes[i]) && (endTimesNew[i] <= endTimes[i]))
                        {
                            count++;
                        }
                    }
                }


                if (count > 0)
                {
                    ok = false;
                }

            }
            else
            {
                ok = true;
            }




            return ok;
        }


        public frmEditTimesheet()
        {
            InitializeComponent();
        } 
        


        private void frmEditTimesheet_Load(object sender, EventArgs e)
        {
            

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

            txtStart6.Enabled = false;
            txtStart7.Enabled = false;
            txtEnd7.Enabled = false;
            txtEnd6.Enabled = false;
            cmbProject6.Enabled = false;
            cmbProject7.Enabled = false;
            cmbEmpTask7.Enabled = false;
            cmbEmpTask6.Enabled = false;

            sqlEmpTask = @"select DISTINCT ProjectID from ProjectTaskEmployee where EmployeeID = @EmployeeID";
            conn = new SqlConnection(connStr);
            cmdEmp = new SqlCommand(sqlEmpTask, conn);
            cmdEmp.Parameters.Add("@EmployeeID", SqlDbType.Int);
            daEmpTask = new SqlDataAdapter(cmdEmp);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");

            sqlEmpTask1 = @"select  TaskID from ProjectTaskEmployee where EmployeeID = @EmployeeID and ProjectID = @ProjectID";
            conn = new SqlConnection(connStr);
            cmdEmp1 = new SqlCommand(sqlEmpTask1, conn);
            cmdEmp1.Parameters.Add("@EmployeeID", SqlDbType.Int);
            cmdEmp1.Parameters.Add("@ProjectID", SqlDbType.Int);
            daEmpTask1 = new SqlDataAdapter(cmdEmp1);
            daEmpTask1.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee1");

            string timeDets = UC_Timesheet.timeNoSelected.ToString();
            timesheetValue = Convert.ToInt32(timeDets);
            drClaim = dsFujitsuPayments.Tables["Timesheet"].Rows.Find(timeDets);

            lblTimsheetId.Text = drClaim["TimesheetID"].ToString();
            cmbEmployee.SelectedValue = drClaim["EmployeeID"].ToString();
            cmbDates.Text = drClaim["WkBeginning"].ToString();
            cmbDates.Enabled = false;

            sqlProject = @"Select  * from TimesheetDetails where TimesheetID = @Timesheet AND ClaimTypeID = @ClaimType";
            conn = new SqlConnection(connStr);
            cmdProj = new SqlCommand(sqlProject, conn);
            cmdProj.Parameters.Add("@Timesheet", SqlDbType.Int);
            cmdProj.Parameters.Add("@ClaimType", SqlDbType.Int);
            daProject = new SqlDataAdapter(cmdProj);
            daProject.Dispose();
            daProject = new SqlDataAdapter(cmdProj);
            listBoxValues();
            findMondays(cmbDates.Text);
            setDates(0, cmbDates.Text);
            //int claim = Convert.ToInt32(drClaim["ClaimTypeID"].ToString());
            cmbClaimType.SelectedValue = 1;
            int claim = Convert.ToInt32(cmbClaimType.SelectedValue.ToString());
            setData(claim, Convert.ToInt32(timeDets));

            projects();

            //MessageBox.Show(drClaim["EmployeeID"].ToString());
            //int noRows = dsFujitsuPayments.Tables["Timesheet"].Rows.Count;

            //if (noRows == 0)
            //    lblTimsheetId.Text = "1000";
            //else
            //{
            //    getNumber(noRows);
            //}

        }
        private void projects()
        {
            int numb = 0;

            ComboBox[] project = { cmbProject, cmbProject2, cmbProject3, cmbProject4, cmbProject5, cmbProject6, cmbProject7 };
            ComboBox[] task = { cmbEmpTask, cmbEmpTask2, cmbEmpTask3, cmbEmpTask4, cmbEmpTask5, cmbEmpTask6, cmbEmpTask7 };

            dsFujitsuPayments.Tables["ProjectTaskEmployee"].Clear();
            cmdEmp.Parameters["@EmployeeID"].Value = cmbEmployee.SelectedValue;

            int count = 0;
            daEmpTask.Fill(dsFujitsuPayments, "ProjectTaskEmployee");

            // daEmpTask.


            DataTable dt = dsFujitsuPayments.Tables["ProjectTaskEmployee"];
            foreach (DataRow row in dt.Rows)
            {
                count++;

            }

            if (count == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    task[i].Items.Clear();
                    project[i].Items.Clear();
                }
                MessageBox.Show("This employee has no Projects or Tasks, please assign.");
            }
            else
            {



                for (int i = 0; i < 7; i++)
                {
                    //project[i].DataSource = dsFujitsuPayments.Tables["ProjectTaskEmployee"];
                    //project[i].ValueMember = "ProjectID";
                    //project[i].DisplayMember = "ProjectID";

                    foreach (DataRow row in dt.Rows)
                    {
                        project[i].Items.Add(row.Field<int>("ProjectID"));
                    }

                    numb++;
                }
            }
        }

        private void task(int projectBox)
        {
            try
            {
                int pos = projectBox;

                ComboBox[] task = { cmbEmpTask, cmbEmpTask2, cmbEmpTask3, cmbEmpTask4, cmbEmpTask5, cmbEmpTask6, cmbEmpTask7 };
                ComboBox[] project = { cmbProject, cmbProject2, cmbProject3, cmbProject4, cmbProject5, cmbProject6, cmbProject7 };
                dsFujitsuPayments.Tables["ProjectTaskEmployee1"].Clear();
                cmdEmp1.Parameters["@EmployeeID"].Value = cmbEmployee.SelectedValue;
                cmdEmp1.Parameters["@ProjectID"].Value = project[pos].SelectedItem;

                daEmpTask1.Fill(dsFujitsuPayments, "ProjectTaskEmployee1");


                DataTable dt = dsFujitsuPayments.Tables["ProjectTaskEmployee1"];


                foreach (DataRow row in dt.Rows)
                {
                    task[pos].Items.Add(row.Field<int>("TaskID"));
                }

            }
            catch (System.InvalidCastException ex)
            { }
            catch (System.Data.SqlClient.SqlException ex)
            { }
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numb = 0;

            if (cmbEmployee.Focused == true)
            {
                projects();
            }
        }

        private void findMondays(string wkBeginning)
        {
            DateTime dt = Convert.ToDateTime(wkBeginning);

            DateTime mon = dt.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday));
            var date = mon.Date;
            DateTime[] startDate = new DateTime[7];
            int count = 0;


            for (int i = 0; i < 7; i++)
            {

                startDate[i] = date.AddDays(count);
                count += 7;
            }

            for (int i = 0; i < 7; i++)
            {
                cmbDates.Items.Add(startDate[i].ToString());

            }
        }

        private void setData(int claimtype, int timesheetID)
        {
            TextBox[] start = { txtStart7, txtStart1, txtStart2, txtStart3, txtStart4, txtStart5, txtStart6  };
            TextBox[] end = { txtEnd7,txtEnd1, txtEnd2, txtEnd3, txtEnd4, txtEnd5, txtEnd6 };
            ComboBox[] task = { cmbEmpTask7, cmbEmpTask, cmbEmpTask2, cmbEmpTask3, cmbEmpTask4, cmbEmpTask5, cmbEmpTask6 };
            ComboBox[] project = { cmbProject7, cmbProject, cmbProject2, cmbProject3, cmbProject4, cmbProject5, cmbProject6 };
            Label[] date = { lblDateSun, lblDateMon, lblDateTue, lblDateWed, lblDateThur, lblDateFri, lblDateSat };


            
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets");


            cmdProj.Parameters["@Timesheet"].Value = timesheetID;
            cmdProj.Parameters["@ClaimType"].Value = cmbClaimType.SelectedValue;

            daProject.Fill(dsFujitsuPayments, "Timesheets");
            

            DataTable dt = dsFujitsuPayments.Tables["Timesheets"];
           

            foreach (DataRow row in dt.Rows)
            {
                    numb++;
                
            }
            int x = 0;
            DateTime[] rowArray = new DateTime[numb];
            TimeSpan[] startTime = new TimeSpan[numb];
            TimeSpan[] endTime = new TimeSpan[numb];
            int[] proj = new int[numb];
            int[] tasks = new int[numb];
            int[] claimType = new int[numb];


            if (numb !=0 )
            {
                
                foreach (DataRow row in dt.Rows)
                {
                    rowArray[x] = row.Field<DateTime>("WorkedDay");
                    startTime[x] = row.Field<TimeSpan>("StartTime");
                    endTime[x] = row.Field<TimeSpan>("EndTime");
                    proj[x] = row.Field<int>("ProjectID");
                    tasks[x] = row.Field<int>("TaskID");
                    claimType[x] = row.Field<int>("ClaimTypeID");

                    x++;
                }
                int cType = (int) cmbClaimType.SelectedValue;

                for (int i = 0; i < numb; i++)
                {
                    if (claimType[i] == cType)
                    {

                        int day = (int)rowArray[i].DayOfWeek;

                        start[day].Text = startTime[i].ToString();
                        end[day].Text = endTime[i].ToString();
                        date[day].Text = rowArray[i].ToShortDateString();
                        project[day].Text = proj[i].ToString();
                        task[day].Text =  tasks[i].ToString();

                    }
                   
                    else
                    {
                        for (int y = 0; y < 7; y++)
                        {
                            start[y].Text = "";
                            end[y].Text = "";
                            // date[day].Text = rowArray[i].ToShortDateString();
                        }
                    }


                }
                for(int i = 0; i < 7; i ++)
                {
                    //if(start[i].Text == "")
                    //{
                    //    start[i].Enabled = false;
                    //    end[i].Enabled = false;
                    //}
                    //else
                    //{
                    //    start[i].Enabled = true;
                    //    end[i].Enabled = true;
                    //}
                }

            }
            else
            {
                for(int y = 0; y< 7; y ++)
                {
                    start[y].Text = "";
                    end[y].Text = "";
                   // date[day].Text = rowArray[i].ToShortDateString();
                }
            }

            numb = 0;
        }


        private void setDates(int count, string wkBeginning)
        {
            DateTime dt = Convert.ToDateTime(wkBeginning);
            DateTime start = dt;
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
        private void cmbClaimType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbClaimType.Focused == true)
            {

                int claim = (int)cmbClaimType.SelectedValue;
                setData(claim, timesheetValue);

                
                    if (claim == 1)
                    {
                        txtStart6.Enabled = false;
                        txtStart7.Enabled = false;
                        txtEnd7.Enabled = false;
                        txtEnd6.Enabled = false;
                    cmbProject6.Enabled = false;
                    cmbProject7.Enabled = false;
                    cmbEmpTask7.Enabled = false;
                    cmbEmpTask6.Enabled = false;
                }
                    else
                    {
                        txtStart6.Enabled = true;
                        txtStart7.Enabled = true;
                        txtEnd7.Enabled = true;
                        txtEnd6.Enabled = true;
                    cmbProject6.Enabled = true;
                    cmbProject7.Enabled = true;
                    cmbEmpTask7.Enabled = true;
                    cmbEmpTask6.Enabled = true;
                }
                
            }
        }
        private void listBoxValues()
        {
            lvPastHours.View = View.Details;
            lvPastHours.GridLines = true;
            lvPastHours.FullRowSelect = true;


            lvPastHours.Columns.Add("TimesheetID", 80);
            lvPastHours.Columns.Add("Basic", 70);
            lvPastHours.Columns.Add("OnCall", 60);
            lvPastHours.Columns.Add("Overtime", 60);


           





            sqlCount = @" select TimesheetID, DATEDIFF ( MINUTE, StartTime, EndTime )/ 60 as Hours, ClaimTypeID from TimesheetDetails
            where (TimesheetID = @Timesheet1 or TimesheetID = @Timesheet2 or TimesheetID = @Timesheet3 or TimesheetID = @Timesheet4)";
            conn = new SqlConnection(connStr);
            cmdCount = new SqlCommand(sqlCount, conn);
            cmdCount.Parameters.Add("@Timesheet1", SqlDbType.Int);
            cmdCount.Parameters.Add("@Timesheet2", SqlDbType.Int);
            cmdCount.Parameters.Add("@Timesheet3", SqlDbType.Int);
            cmdCount.Parameters.Add("@Timesheet4", SqlDbType.Int);
            daCount = new SqlDataAdapter(cmdCount);
            daCount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Count");

            int timesheet = Convert.ToInt32(lblTimsheetId.Text);

            cmdCount.Parameters["@Timesheet1"].Value = timesheet - 1;
            cmdCount.Parameters["@Timesheet2"].Value = timesheet - 2;
            cmdCount.Parameters["@Timesheet3"].Value = timesheet - 3;
            cmdCount.Parameters["@Timesheet4"].Value = timesheet - 4;
            daCount.Fill(dsFujitsuPayments, "Count");


            int ts1 = timesheet - 1;
            int ts2 = timesheet - 2;
            int ts3 = timesheet - 3;
            int ts4 = timesheet - 4;

            DataTable dt = dsFujitsuPayments.Tables["Count"];
            int numb = 0, count = 0, x = 0;

            string startime, endtime, starttimeNew, endtimeNew;



            foreach (DataRow row in dt.Rows)
            {

                numb++;

            }

            double basic1 = 0, basic2 = 0, basic3 = 0, basic4 = 0;
            double oncall1 = 0, oncall2 = 0, oncall3 = 0, oncall4 = 0;
            double ot1 = 0, ot2 = 0, ot3 = 0, ot4 = 0;



            if (numb != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    drCount = row;
                    int newTS = Convert.ToInt32(drCount["TimesheetID"].ToString());
                    int cType = Convert.ToInt32(drCount["ClaimTypeID"].ToString());
                    drCount = row;

                    if (ts1 == newTS)
                    {
                        switch (cType)
                        {
                            case 1:
                                basic1 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 2:
                                ot1 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 3:
                                oncall1 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                        }

                    }
                    else if (ts2 == newTS)
                    {
                        switch (cType)
                        {
                            case 1:
                                basic2 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 2:
                                ot2 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 3:
                                oncall2 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                        }

                    }
                    else if (ts3 == newTS)
                    {
                        switch (cType)
                        {
                            case 1:
                                basic3 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 2:
                                ot3 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 3:
                                oncall3 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                        }

                    }
                    else if (ts4 == newTS)
                    {
                        switch (cType)
                        {
                            case 1:
                                basic4 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 2:
                                ot4 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 3:
                                oncall4 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                        }

                    }
                }
                string[] row1 = { Convert.ToString(ts1), Convert.ToString(basic1), Convert.ToString(oncall1), Convert.ToString(ot1) };  //new object[3]; //{ basic1, basic2, basic3, basic4 };
                string[] row2 = { Convert.ToString(ts2), Convert.ToString(basic2), Convert.ToString(oncall2), Convert.ToString(ot2) };
                string[] row3 = { Convert.ToString(ts3), Convert.ToString(basic3), Convert.ToString(oncall3), Convert.ToString(ot3) };
                string[] row4 = { Convert.ToString(ts4), Convert.ToString(basic4), Convert.ToString(oncall4), Convert.ToString(ot4) };

                ListViewItem item1, item2, item3, item4;
                item1 = new ListViewItem(row1);
                item2 = new ListViewItem(row2);
                item3 = new ListViewItem(row3);
                item4 = new ListViewItem(row4);
                lvPastHours.Items.Add(item1);
                lvPastHours.Items.Add(item2);
                lvPastHours.Items.Add(item3);
                lvPastHours.Items.Add(item4);

            }
            else
            {

            }
     
        }
      
    }
}
