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
    public partial class frmAddTimesheet : Form
    {

        SqlDataAdapter daProject, daEmployee, daEmpTask,daClaim, daEmpTask1, daMan, daTimesheet, daTimeDets, daCost,daCount;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBClaim, cmbBEmp, cmbBTimesheet, cmbBTimeDets, cmbBCost, cnbBCount;
        SqlCommand cmdEmp, cmdProj, cmdCount, cmdEmp1;
       
        DataRow drProject,  drTimesheet, drTimeDets,drCount;
        String connStr, sqlProject, sqlEmpTask1, sqlEmp, sqlEmpTask, sqlClaim, sqlMan, sqlTimesheet, sqlTimeDets, sqlCost, sqlCount;
        SqlConnection conn;
        private double count;
private Boolean replay = false, Start = false;
        int location = 0;


        private int no;


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid) ;
     
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           

          
            this.Dispose();
            

        }

        private void cmbDates_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblWeekNo_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblClaimType_Click(object sender, EventArgs e)
        {

        }

        private void cmbClaimType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCostCentID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCostCentreID_Click(object sender, EventArgs e)
        {

        }

        private void cmbApprovedBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblApprovedBy_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTimsheetId_Click(object sender, EventArgs e)
        {

        }

        private void lblTimesheetId_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmployee_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblEmpID_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lvPastHours_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbProject7_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            
            dsFujitsuPayments.Tables["ProjectTaskEmployee1"].Clear();
            cmdEmp1.Parameters["@EmployeeID"].Value = cmbEmployee.SelectedValue;
            cmdEmp1.Parameters["@ProjectID"].Value = cmbProject.SelectedValue;
            ComboBox[] task = { cmbEmpTask, cmbEmpTask2, cmbEmpTask3, cmbEmpTask4, cmbEmpTask5, cmbEmpTask6, cmbEmpTask7 };
            daEmpTask1.Fill(dsFujitsuPayments, "ProjectTaskEmployee1");

            int numb = 0;

           
            numb = 0;
            for (int i = 0; i < 7; i++)
            {


                task[i].DataSource = dsFujitsuPayments.Tables["ProjectTaskEmployee1"];
                task[i].ValueMember = "TaskID";
                task[i].DisplayMember = "TaskID";

                numb++;
            }
        }

        private void lblDateSun_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask7_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblSun_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbProject6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblDateSat_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask6_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblSat_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbProject5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblDateFri_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask5_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblFri_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDateMon_Click(object sender, EventArgs e)
        {

        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblMon_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbProject4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask4_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblDateThur_Click(object sender, EventArgs e)
        {

        }

        private void lblThur_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbProject3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblDateWed_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblWed_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbProject2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpTask2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lblDateTue_Click(object sender, EventArgs e)
        {

        }

        private void lblTue_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pbSelected_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {

            TextBox[] start = { txtStart1, txtStart2, txtStart3, txtStart4, txtStart5, txtStart6, txtStart7 };
            TextBox[] end = { txtEnd1, txtEnd2, txtEnd3, txtEnd4, txtEnd5, txtEnd6, txtEnd7 };
            Panel[] pnl = { panel5, panel6, panel7, panel8, panel9, panel10, panel11 };
            //gets the name from the sender to compare;
            string name = ((TextBox)sender).Name;
            String loc = "";
           
            for (int i = 0; i <7; i ++)
            {
                if(name.CompareTo(start[i].Name) ==0 || name.CompareTo(end[i].Name) ==0)
                {
                    location = i;
                    Start = true;
                }
            }
            Panel pNew = pnl[location];
            //MessageBox.Show(Convert.ToString(pnl[location].Height));
            pbSelected.Height = pNew.Height;
            int Y = pNew.Location.Y;
            pbSelected.Location = new Point(568, Y);
            pbSelected.Height = pNew.Location.Y;
        }
       
        private void panel_Paint(object sender, PaintEventArgs e)
        {
           
        }


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

        private void txtStart1_TextChanged(object sender, EventArgs e)
        {

        }

       





        private void cmbApprovedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        private void label16_Click(object sender, EventArgs e)
        {

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


            int noRows = dsFujitsuPayments.Tables["Timesheet"].Rows.Count;

            if (noRows == 0)
                lblTimsheetId.Text = "1000";
            else
            {
                getNumber(noRows);
            }


          


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

            double basic1 =0, basic2 = 0, basic3 = 0, basic4 = 0;
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

                    if (ts1 == newTS )
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
                string[] row1 = {Convert.ToString(ts1), Convert.ToString(basic1), Convert.ToString(oncall1), Convert.ToString(ot1)};  //new object[3]; //{ basic1, basic2, basic3, basic4 };
                string[] row2 = { Convert.ToString(ts2), Convert.ToString(basic2), Convert.ToString(oncall2), Convert.ToString(ot2) };
                string[] row3 = { Convert.ToString(ts3), Convert.ToString(basic3), Convert.ToString(oncall3), Convert.ToString(ot3) };
                string[] row4  = { Convert.ToString(ts4), Convert.ToString(basic4), Convert.ToString(oncall4), Convert.ToString(ot4) };

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
                                if (!replay)
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
                                }
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
                                if (MessageBox.Show("Do you wish to add On Call or Overtime claims?", "Add Claim", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    clear();
                                    no = 0;
                                    replay = true;
                                }
                                else
                                {
                                    this.Dispose();
                                }
                                
                            }
                            break;
                        case 2:
                            int track = 0;
                            if (checkOT() == true)
                            {
                                

                                foreach (Control c in panel1.Controls)
                                {
                                    if (c is Panel && ok)
                                    {
                                        if (start[no].Text.Length != 0 && end[no].Text.Length != 0)
                                        {
                                            if(MyValidation.validTimespan1(start[no].Text) == true && MyValidation.validTimespan1(end[no].Text))
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
                                            else
                                            {
                                                ok = false;
                                                MessageBox.Show("Please enter a valid start or end Time");
                                                count = 0;
                                                no = 0;
                                                break;
                                            }


                                        }
                                        else
                                        {
                                            track++;
                                        }
                                        no++;
                                    }
                                }
                                      
                                if(track == 7)
                                {
                                   
                                    ok = false;
                                    count = 0;
                                    no = 0;
                                    MessageBox.Show("You must enter valid hours for an On Call claim");
                                }
                                        
                                           


                                if (ok)
                                {
                                    if(!replay)
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
                                    }
                                    
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
                                        no = 0;
                                        replay = true;
                                    }
                                    else
                                    {
                                        this.Dispose();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("A claim already exists for these number, please edit an existing claim.");
                                ok = false;
                                clear();
                            }
                           
                            break;
                        case 3:
                            int track1 = 0;
                            if (checkOT() == true)
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
                                        else
                                        {
                                            track1++;
                                        }
                                        no++;

                                    }
                                }
                                if(track1 == 7)
                                {
                                    ok = false;
                                    count = 0;
                                    no = 0;
                                    MessageBox.Show("You must enter valid hours for an On Call claim");

                                }

                                if (ok)
                                {
                                    if (!replay)
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
                                    }
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
                                        no = 0;
                                    }
                                    else
                                    {
                                        this.Dispose();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("A claim already exists for these number, please edit an existing claim.");
                                ok = false;
                                clear();
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
                end[i].Clear();
            }
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



            sqlEmpTask = @"select ProjectID , TaskID , EmployeeID from ProjectTaskEmployee where EmployeeID = @EmployeeID";
            conn = new SqlConnection(connStr);
            cmdEmp = new SqlCommand(sqlEmpTask, conn);
            cmdEmp.Parameters.Add("@EmployeeID", SqlDbType.Int);
            daEmpTask = new SqlDataAdapter(cmdEmp);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");

            sqlEmpTask1 = @"select ProjectID, TaskID, EmployeeID from ProjectTaskEmployee where EmployeeID = @EmployeeID and ProjectID = @ProjectID";
            conn = new SqlConnection(connStr);
            cmdEmp1 = new SqlCommand(sqlEmpTask1, conn);
            cmdEmp1.Parameters.Add("@EmployeeID", SqlDbType.Int);
            cmdEmp1.Parameters.Add("@ProjectID", SqlDbType.Int);
            daEmpTask1 = new SqlDataAdapter(cmdEmp1);
            daEmpTask1.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee1");

            project();
            listBoxValues();

            txtStart6.Enabled = false;
            txtStart7.Enabled = false;
            txtEnd7.Enabled = false;
            txtEnd6.Enabled = false;
            cmbProject6.Enabled = false;
            cmbProject7.Enabled = false;
            cmbEmpTask7.Enabled = false;
            cmbEmpTask6.Enabled = false;

            int noRows = dsFujitsuPayments.Tables["Timesheet"].Rows.Count;

            if (noRows == 0)
                lblTimsheetId.Text = "1000";
            else
            {
                getNumber(noRows);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbClaimType.Focused == true)
            {
                if ((int)cmbClaimType.SelectedValue == 1)
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
                    cmbProject6.Enabled = true; ;
                    cmbProject7.Enabled = true; ;
                    cmbEmpTask7.Enabled = true; ;
                    cmbEmpTask6.Enabled = true; ;
                }
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

        private Boolean checkOT()
        {
            Boolean ok = true;

            sqlProject = @"Select  * from TimesheetDetails where TimesheetID = @Timesheet AND (ClaimTypeID = 2 or ClaimTypeID = 3)";
            conn = new SqlConnection(connStr);
            cmdProj = new SqlCommand(sqlProject, conn);
            cmdProj.Parameters.Add("@Timesheet", SqlDbType.Int);
            daProject = new SqlDataAdapter(cmdProj);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets");

            cmdProj.Parameters["@Timesheet"].Value = Convert.ToInt32(lblTimsheetId.Text);

            daProject.Fill(dsFujitsuPayments, "Timesheets");

            TextBox[] start = { txtStart1, txtStart2, txtStart3, txtStart4, txtStart5, txtStart6, txtStart7 };
            TextBox[] end = { txtEnd1, txtEnd2, txtEnd3, txtEnd4, txtEnd5, txtEnd6, txtEnd7 };
            Label[] date = { lblDateMon, lblDateTue, lblDateWed, lblDateThur, lblDateFri, lblDateSat, lblDateSun };
           

            DataTable dt = dsFujitsuPayments.Tables["Timesheets"];
            int numb = 0, count = 0 , x = 0;

            string startime, endtime, starttimeNew, endtimeNew;



            foreach (DataRow row in dt.Rows)
             { 
                    
                    numb++;
    
             }
               
            if(numb != 0)
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

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numb = 0;

            if (cmbEmployee.Focused == true)
            {
                project();


            }
        }

        private void project()
        {
            int numb = 0;
            
            ComboBox[] project = { cmbProject, cmbProject2, cmbProject3, cmbProject4, cmbProject5, cmbProject6, cmbProject7 };
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
                MessageBox.Show("This employee has no Projects or Tasks, please assign.");
            }
            else
            {



                for (int i = 0; i < 7; i++)
                {
                    project[i].DataSource = dsFujitsuPayments.Tables["ProjectTaskEmployee"];
                    project[i].ValueMember = "ProjectID";
                    project[i].DisplayMember = "ProjectID";

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
