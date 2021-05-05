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
using FujitsuPayments.UserControls;

namespace FujitsuPayments.Forms
{
    public partial class frmEditShift : Form
    {


        SqlDataAdapter daShift, daAccount, daProject, daTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBShift, cmbBAccount, cmbBProject, cmbBTask;
        SqlCommand cmbProject, cmbTask;
        DataRow drShift, drAccount, drProject, drTask;
        String connStr, sqlShift, sqlAccount, sqlProject, sqlTask;
        static String startTime, endTime;



        public frmEditShift()
        {
            InitializeComponent();
        }

        private void frmEditShift_Load(object sender, EventArgs e)
        {

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            // -------- set up data adapter for project ID drop down
            sqlProject = @"Select ProjectID, ProjDesc, AccountID from Project where AccountID like @AccountID";
            conn = new SqlConnection(connStr);
            cmbProject = new SqlCommand(sqlProject, conn);
            cmbProject.Parameters.Add("@AccountID", SqlDbType.Int);
            daProject = new SqlDataAdapter(cmbProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");


            // ----------set up data adapter for Task ID drop down
            sqlTask = @"Select ProjectID, TaskDesc, TaskID from ProjectTask where ProjectID like @ProjectID";
            conn = new SqlConnection(connStr);
            cmbTask = new SqlCommand(sqlTask, conn);
            cmbTask.Parameters.Add("@ProjectID", SqlDbType.Int);
            daTask = new SqlDataAdapter(cmbTask);
            daTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");


            sqlShift = @"select * from EmployeeShift";
            daShift = new SqlDataAdapter(sqlShift, connStr);
            cmbBShift = new SqlCommandBuilder(daShift);
            daShift.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShift");
            daShift.Fill(dsFujitsuPayments, "EmployeeShift");

            sqlAccount = @"select * from Account";
            daAccount = new SqlDataAdapter(sqlAccount, connStr);
            cmbBAccount = new SqlCommandBuilder(daAccount);
            daAccount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daAccount.Fill(dsFujitsuPayments, "Account");

            // -------- populate fields on form ---------------- //

            // ------- populate account ID combo box
            cmbAccountId.DataSource = dsFujitsuPayments.Tables["Account"];
            cmbAccountId.ValueMember = "AccountID";
            cmbAccountId.DisplayMember = "ClientName";

            cmbTaskId.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
            cmbTaskId.ValueMember = "TaskID";
            cmbTaskId.DisplayMember = "TaskDesc";

            txtShiftID.Text = UC_Schedule.shiftIdSelected.ToString();

            drShift = dsFujitsuPayments.Tables["EmployeeShift"].Rows.Find(UC_Schedule.shiftIdSelected.ToString());
            drAccount = dsFujitsuPayments.Tables["Account"].Rows.Find(UC_Schedule.accIdSelected.ToString());

            // populate account drop down
            cmbAccountId.Text = drAccount["ClientName"].ToString();

            // -------------- populate project drop down -----------------------//
            cmbProject.Parameters["@AccountID"].Value = UC_Schedule.accIdSelected.ToString();
            try
            {
                // fill data adapter with returned values
                daProject.Fill(dsFujitsuPayments, "Project");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex);
            }
            cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
            cmbProjectId.ValueMember = "ProjectID";
            cmbProjectId.DisplayMember = "ProjDesc";
            drProject = dsFujitsuPayments.Tables["Project"].Rows.Find(UC_Schedule.projIdSelected.ToString());
            cmbProjectId.Text = drProject["ProjDesc"].ToString();
            // ----------------------------- end ---------------------------------//

            // ----------------- populate task drop down --------------------- //

            cmbTask.Parameters["@ProjectID"].Value = UC_Schedule.projIdSelected.ToString();
            try
            {
                daTask.Fill(dsFujitsuPayments, "ProjectTask");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message " + ex);
            }
            cmbTaskId.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
            cmbTaskId.ValueMember = "TaskID";
            cmbTaskId.DisplayMember = "TaskDesc";
            // create primaye key object -- composite primary key
            object[] primaryKey = new object[2];
            primaryKey[0] = Convert.ToInt32(UC_Schedule.projIdSelected.ToString());
            primaryKey[1] = Convert.ToInt32(UC_Schedule.taskIdSelected.ToString());
            drTask = dsFujitsuPayments.Tables["ProjectTask"].Rows.Find(primaryKey);
            cmbTaskId.Text = drTask["TaskDesc"].ToString();
            // ----------------------------- end ---------------------------------//


            dtpShiftStartDate.Text = drShift["StartDate"].ToString();


            // ---- setup start time drop down -------- // 
            // format date time to only show time for combo box
            DateTime st = DateTime.Parse(drShift["StartTime"].ToString());
            int startHour = Int32.Parse(st.ToString("HH"));

            // ---- convert 24hr clock back to 12 to populate drop down
            if(startHour > 12)
            {
                startHour = startHour - 12; // convert to 12 hr clock

                if(startHour > 9)
                {
                    string startTimeHr = startHour.ToString(); // append 0 to start hour
                    string startTimeMin = st.ToString("mm");
                    cmbStartTime.Text = startTimeHr;
                    cmbStartTimeMin.Text = startTimeMin;
                    rbStPM.Checked = true;
                    rbStAM.Checked = false;
                }
                else
                {
                    string startTimeHr = "0" + startHour.ToString(); // append 0 to start hour
                    string startTimeMin = st.ToString("mm");
                    cmbStartTime.Text = startTimeHr;
                    cmbStartTimeMin.Text = startTimeMin;
                    rbStPM.Checked = true;
                    rbStAM.Checked = false;
                }

                
            }
            else
            {
                string startTimeHr = st.ToString("HH");
                string startTimeMin = st.ToString("mm");
                cmbStartTime.Text = startTimeHr;
                cmbStartTimeMin.Text = startTimeMin;
                rbStPM.Checked = false;
                rbStAM.Checked = true;
            }



            // ------ setup end time drop down ------- //

            DateTime et = DateTime.Parse(drShift["EndTime"].ToString());
            int endHour = Int32.Parse(et.ToString("HH"));

            if(endHour > 12)
            {
                endHour = endHour - 12;

                if(endHour > 9)
                {
                    string endTimeHr = endHour.ToString();
                    string endTimeMin = et.ToString("mm");
                    cmbEndTime.Text = endTimeHr;
                    cmbEndTimeMin.Text = endTimeMin;
                    rbEtPM.Checked = true;
                    rbEtAM.Checked = false;
                }
                else
                {
                    string endTimeHr = "0" + endHour.ToString();
                    string endTimeMin = et.ToString("mm");
                    cmbEndTime.Text = endTimeHr;
                    cmbEndTimeMin.Text = endTimeMin;
                    rbEtPM.Checked = true;
                    rbEtAM.Checked = false;
                }
                
                
            }
            else
            {
                string endTimeHr = et.ToString("HH");
                string endTimeMin = et.ToString("mm");
                cmbEndTime.Text = endTimeHr;
                cmbEndTimeMin.Text = endTimeMin;
                rbEtPM.Checked = false;
                rbEtAM.Checked = true;
            }



        }

        private void btnEditClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void btnEditSave_Click(object sender, EventArgs e)
        {

            if (cmbStartTime.SelectedIndex == -1 || cmbStartTimeMin.SelectedIndex == -1 || cmbEndTime.SelectedIndex == -1 || cmbEndTimeMin.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all time fields");
            }
            else
            {

                startTime = cmbStartTime.SelectedItem.ToString() + ":" + cmbStartTimeMin.SelectedItem.ToString();

                endTime = cmbEndTime.SelectedItem.ToString() + ":" + cmbEndTimeMin.SelectedItem.ToString();

                /*Code removed as getting to complex, simplified by using 00-23 instead of using 00-12 and then converting based on am or pm, code was becoming less user friendly*/

                /*
                // convert combobox and radio button to string
                if (rbStAM.Checked == true)
                {
                    if (Convert.ToInt32(cmbStartTime.SelectedItem.ToString()) == 12)
                    {

                        startTime = "00" + ":" + cmbStartTimeMin.SelectedItem.ToString();
                    }
                    else if (Convert.ToInt32(cmbStartTime.SelectedItem.ToString()) == 00)
                    {
                        startTime = "12" + ":" + cmbStartTimeMin.SelectedItem.ToString();
                    }
                    else
                        startTime = cmbStartTime.SelectedItem.ToString() + ":" + cmbStartTimeMin.SelectedItem.ToString();
                }
                else
                {
                    if (Convert.ToInt32(cmbStartTime.SelectedItem.ToString()) == 00)
                    {
                        MessageBox.Show("00 pm is classed ast midnight or 00:00");
                        startTime = "00" + ":" + cmbStartTimeMin.SelectedItem.ToString();
                    }
                    else
                    {
                        int startHour = Convert.ToInt32(cmbStartTime.SelectedItem.ToString()) + 12;
                        startTime = Convert.ToString(startHour) + ":" + cmbStartTimeMin.SelectedItem.ToString();
                    }
                }

                if (rbEtAM.Checked == true)
                {
                    if (Convert.ToInt32(cmbEndTime.SelectedItem.ToString()) == 12)
                    {
                        endTime = "00" + ":" + cmbEndTimeMin.SelectedItem.ToString();
                    }
                    else if (Convert.ToInt32(cmbEndTime.SelectedItem.ToString()) == 00)
                    {
                        endTime = "12" + ":" + cmbEndTimeMin.SelectedItem.ToString();
                    }
                    else
                        endTime = cmbEndTime.SelectedItem.ToString() + ":" + cmbEndTimeMin.SelectedItem.ToString();
                }
                else
                {
                    if (Convert.ToInt32(cmbEndTime.SelectedItem.ToString()) == 00)
                    {
                        MessageBox.Show("00 pm is classed ast midnight or 00:00");
                        endTime = "00" + ":" + cmbEndTimeMin.SelectedItem.ToString();
                    }
                    else
                    {
                        int endHour = Convert.ToInt32(cmbEndTime.SelectedItem.ToString()) + 12;
                        endTime = Convert.ToString(endHour) + ":" + cmbEndTimeMin.SelectedItem.ToString();
                    }
                }
                */


                int compareTime = TimeSpan.Compare(TimeSpan.Parse(startTime), TimeSpan.Parse(endTime));
                // gets todays date
                DateTime now = DateTime.Now;
                // compares todays date to date selected
                int compareDate = DateTime.Compare(DateTime.Parse(dtpShiftStartDate.Text), now);
                //MessageBox.Show("Compare is" + compareDate);


                EmployeeShift myShift = new EmployeeShift();

                bool ok = true;
                errP.Clear();

                if (compareTime == -1)
                {
                    if (compareDate != -1)
                    {
                        // pass data to class for validation
                        try
                        {
                            myShift.ShiftId = Convert.ToInt32(txtShiftID.Text);
                        }
                        catch (MyException MyEx)
                        {
                            ok = false;
                            errP.SetError(txtShiftID, MyEx.toString());
                        }

                        try
                        {
                            myShift.AccountId = Convert.ToInt32(cmbAccountId.SelectedValue);
                        }
                        catch (MyException MyEx)
                        {
                            ok = false;
                            errP.SetError(cmbAccountId, MyEx.toString());
                        }

                        try
                        {
                            myShift.ProjectId = Convert.ToInt32(cmbProjectId.SelectedValue);
                        }
                        catch (MyException MyEx)
                        {
                            ok = false;
                            errP.SetError(cmbProjectId, MyEx.toString());
                        }

                        try
                        {
                            myShift.TaskId = Convert.ToInt32(cmbTaskId.SelectedValue);
                        }
                        catch (MyException MyEx)
                        {
                            ok = false;
                            errP.SetError(cmbTaskId, MyEx.toString());
                        }

                        try
                        {
                            myShift.StartDate = DateTime.Parse(dtpShiftStartDate.Text.Trim());
                        }
                        catch (MyException MyEx)
                        {
                            ok = false;
                            errP.SetError(dtpShiftStartDate, MyEx.toString());
                        }

                        try
                        {
                            // String time = cmbStartTime.SelectedItem.ToString();
                            myShift.StartTime = TimeSpan.Parse(startTime);
                        }
                        catch (MyException MyEx)
                        {
                            ok = false;
                            errP.SetError(cmbStartTime, MyEx.toString());
                        }

                        try
                        {
                            //String time = cmbEndTime.SelectedItem.ToString();
                            myShift.EndTime = TimeSpan.Parse(endTime);
                        }
                        catch (MyException MyEx)
                        {
                            ok = false;
                            errP.SetError(cmbEndTime, MyEx.toString());
                        }

                        try
                        {
                            if (ok)
                            {

                                drShift.BeginEdit();

                                drShift["ShiftID"] = myShift.ShiftId;
                                drShift["AccountID"] = myShift.AccountId;
                                drShift["ProjectID"] = myShift.ProjectId;
                                drShift["TaskID"] = myShift.TaskId;
                                drShift["StartDate"] = myShift.StartDate;
                                drShift["StartTime"] = myShift.StartTime;
                                drShift["EndTime"] = myShift.EndTime;

                                drShift.EndEdit();
                                daShift.Update(dsFujitsuPayments, "EmployeeShift");

                                MessageBox.Show("Shift Updated");
                                this.Dispose();

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Start date cannot be a date in the past, please enter correct date");
                    }
                }
                else
                {
                    MessageBox.Show("End time cannot be before start time, please enter correct time!");
                }
            }




        }



        private void cmbAccountId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountId.Focused == true)
            {
                // clear data set
                dsFujitsuPayments.Tables["Project"].Clear();
                // pass in account ID from combo box
                cmbProject.Parameters["@AccountID"].Value = cmbAccountId.SelectedValue;

                try
                {
                    // fill data adapter with returned values
                    daProject.Fill(dsFujitsuPayments, "Project");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex);
                }

                cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
                cmbProjectId.ValueMember = "ProjectID";
                cmbProjectId.DisplayMember = "ProjDesc";


                if (cmbProjectId.Focused == true)
                {


                    dsFujitsuPayments.Tables["ProjectTask"].Clear();
                    cmbTask.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue;

                    try
                    {
                        daTask.Fill(dsFujitsuPayments, "ProjectTask");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message " + ex);
                    }

                    cmbTaskId.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
                    cmbTaskId.ValueMember = "TaskID";
                    cmbTaskId.DisplayMember = "TaskDesc";

                }
                else
                {

                }
            }
            else
            {

            }

        }


        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjectId.Focused == true)
            {
                dsFujitsuPayments.Tables["ProjectTask"].Clear();
                cmbTask.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue;

                try
                {
                    daTask.Fill(dsFujitsuPayments, "ProjectTask");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex);
                }

                cmbTaskId.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
                cmbTaskId.ValueMember = "TaskID";
                cmbTaskId.DisplayMember = "TaskDesc";

            }
            else
            {

            }
        }

        private void cmbTaskId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}
