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
    public partial class frmAddShift : Form
    {


        SqlDataAdapter daShift, daAccount, daProject, daTask, daEmpShift;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBShift, cmbBAccount, cmbBProject, cmbBTask;
        SqlCommand cmbProject, cmbTask, cmbEmpShift;
        DataRow drShift, drAccount, drProject, drTask, drEmpShift;
        String connStr, sqlShift, sqlAccount, sqlProject, sqlTask, sqlEmpShift;
        static String startTime, endTime;


        private void button1_Click(object sender, EventArgs e)
        {

        }

        

        private void dtpShiftStartTime_ValueChanged(object sender, EventArgs e)
        {

        }

        public frmAddShift()
        {
            InitializeComponent();
        }

        private void frmAddShift_Load(object sender, EventArgs e)
        {
            // converts date time picker to time only
           // dtpShiftStartTime.CustomFormat = "hh:mm tt";
            //dtpShiftStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //dtpShiftStartTime.ShowUpDown = true;
            


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


            // -------- set up data adapter for Employee SHift Validation
            sqlEmpShift = @"  select * from EmployeeShift where AccountID = @AccountID and TaskID = @TaskID and StartDate = @StartDate";
            conn = new SqlConnection(connStr);
            cmbEmpShift = new SqlCommand(sqlEmpShift, conn);
            cmbEmpShift.Parameters.Add("@AccountID", SqlDbType.Int);
            cmbEmpShift.Parameters.Add("@ProjectID", SqlDbType.Int);
            cmbEmpShift.Parameters.Add("@TaskID", SqlDbType.Int);
            cmbEmpShift.Parameters.Add("@StartDate", SqlDbType.Date);
            daEmpShift = new SqlDataAdapter(cmbEmpShift);
            daEmpShift.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShift2");


            // ------- populate account ID combo box
            cmbAccountId.DataSource = dsFujitsuPayments.Tables["Account"];
            cmbAccountId.ValueMember = "AccountID";
            cmbAccountId.DisplayMember = "ClientName";

            cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
            cmbProjectId.ValueMember = "ProjectID";
            cmbProjectId.DisplayMember = "ProjDesc";

            cmbTaskId.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
            cmbTaskId.ValueMember = "TaskID";
            cmbTaskId.DisplayMember = "TaskDesc";

            int noRows = dsFujitsuPayments.Tables["EmployeeShift"].Rows.Count;

            if (noRows == 0)
                txtShiftID.Text = "100000";
            else
            {
                getNumberProject(noRows);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(); // close window
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ------------ check that values have been selected in combo box ------------------- //
            if (cmbAccountId.SelectedIndex == -1 || cmbProjectId.SelectedIndex == -1 || cmbTaskId.SelectedIndex == -1)
            {
                MessageBox.Show("Please select all required values from drop downs!");
            }
            else
            {
                // ----------  check that all options have been selected -------------------------- //
                if (cmbStartTime.SelectedIndex == -1 || cmbStartTimeMin.SelectedIndex == -1 ||
                    cmbEndTime.SelectedIndex == -1 || cmbEndTimeMin.SelectedIndex == -1 || rbStAM.Checked == false && rbStPM.Checked == false
                    || rbEtAM.Checked == false && rbEtPM.Checked == false)
                {
                    MessageBox.Show("Please fill in all time fields");
                }
                else
                {
                    // ---------- convert combobox and radio button to string --------------------- //
                    if (rbStAM.Checked == true)
                    {
                        startTime = cmbStartTime.SelectedItem.ToString() + ":" + cmbStartTimeMin.SelectedItem.ToString();
                    }
                    else
                    {
                        if (Convert.ToInt32(cmbStartTime.SelectedItem.ToString()) == 12)
                        {

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
                        endTime = cmbEndTime.SelectedItem.ToString() + ":" + cmbEndTimeMin.SelectedItem.ToString();
                    }
                    else
                    {
                        if (Convert.ToInt32(cmbEndTime.SelectedItem.ToString()) == 12)
                        {
                            endTime = "00" + ":" + cmbEndTimeMin.SelectedItem.ToString();
                        }
                        else
                        {
                            int endHour = Convert.ToInt32(cmbEndTime.SelectedItem.ToString()) + 12;
                            endTime = Convert.ToString(endHour) + ":" + cmbEndTimeMin.SelectedItem.ToString();
                        }
                    }

                    UC_Schedule.calSizeHeight(startTime, endTime);

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
                                //String time = cmbStartTime.SelectedItem.ToString();
                                myShift.StartTime = TimeSpan.Parse(startTime);
                            }
                            catch (MyException MyEx)
                            {
                                ok = false;
                                errP.SetError(cmbStartTime, MyEx.toString());
                            }

                            try
                            {
                                // String time = cmbEndTime.SelectedItem.ToString();
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
                                    // check for full has been selected
                                    if (rbFullWeek.Checked == true)
                                    {
                                        // add 5 shifts
                                        // gets start of week from selected date
                                        DateTime st = getFirstDayOfWeek(dtpShiftStartDate.Value, "Monday");

                                        int shiftId = Convert.ToInt32(txtShiftID.Text);

                                        for (int i = 0; i < 5; i++)
                                        {
                                            dsFujitsuPayments.Tables["EmployeeShift2"].Clear();

                                            cmbEmpShift.Parameters["@AccountID"].Value = myShift.AccountId;
                                            cmbEmpShift.Parameters["@ProjectID"].Value = myShift.ProjectId;
                                            cmbEmpShift.Parameters["@TaskID"].Value = myShift.TaskId;
                                            cmbEmpShift.Parameters["@StartDate"].Value = st;
                                            daEmpShift.Fill(dsFujitsuPayments, "EmployeeShift2");
                                            int count = 0;

                                            foreach (DataRow dr in dsFujitsuPayments.Tables["EmployeeShift2"].Rows)
                                            {
                                                count = count + 1;
                                            }

                                            if (count > 0)
                                            {
                                                MessageBox.Show("Shift already exists for selected date: " + st.ToString() + ", please select a new date");
                                                st = st.AddDays(1);
                                            }
                                            else
                                            {
                                                drShift = dsFujitsuPayments.Tables["EmployeeShift"].NewRow();

                                                drShift["ShiftID"] = shiftId;
                                                drShift["AccountID"] = myShift.AccountId;
                                                drShift["ProjectID"] = myShift.ProjectId;
                                                drShift["TaskID"] = myShift.TaskId;
                                                drShift["StartDate"] = st;
                                                drShift["StartTime"] = myShift.StartTime;
                                                drShift["EndTime"] = myShift.EndTime;

                                                dsFujitsuPayments.Tables["EmployeeShift"].Rows.Add(drShift);
                                                daShift.Update(dsFujitsuPayments, "EmployeeShift");
                                                //increments both the day or week and shiftID
                                                st = st.AddDays(1);
                                                shiftId = shiftId + 1;

                                                //MessageBox.Show("Shift Added");  

                                            }
                                        }
                                        MessageBox.Show("Shift Added");
                                        this.Dispose();
                                    }
                                    else
                                    {
                                        cmbEmpShift.Parameters["@AccountID"].Value = myShift.AccountId;
                                        cmbEmpShift.Parameters["@ProjectID"].Value = myShift.ProjectId;
                                        cmbEmpShift.Parameters["@TaskID"].Value = myShift.TaskId;
                                        cmbEmpShift.Parameters["@StartDate"].Value = myShift.StartDate;
                                        daEmpShift.Fill(dsFujitsuPayments, "EmployeeShift2");
                                        int count2 = 0;

                                        foreach (DataRow dr1 in dsFujitsuPayments.Tables["EmployeeShift2"].Rows)
                                        {
                                            count2 = count2 + 1;
                                        }

                                        if (count2 > 0)
                                        {
                                            MessageBox.Show("Shift already exists for selected date: " + myShift.StartDate.ToString() + ", please select a new date");
                                        }
                                        else
                                        {


                                            // add single shift
                                            drShift = dsFujitsuPayments.Tables["EmployeeShift"].NewRow();

                                            drShift["ShiftID"] = myShift.ShiftId;
                                            drShift["AccountID"] = myShift.AccountId;
                                            drShift["ProjectID"] = myShift.ProjectId;
                                            drShift["TaskID"] = myShift.TaskId;
                                            drShift["StartDate"] = myShift.StartDate;
                                            drShift["StartTime"] = myShift.StartTime;
                                            drShift["EndTime"] = myShift.EndTime;

                                            dsFujitsuPayments.Tables["EmployeeShift"].Rows.Add(drShift);
                                            daShift.Update(dsFujitsuPayments, "EmployeeShift");

                                            MessageBox.Show("Shift Added");
                                            this.Dispose();
                                        }
                                    }
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
        }

        private void getNumberProject(int noRows)
        {
            drShift = dsFujitsuPayments.Tables["EmployeeShift"].Rows[noRows - 1];
            txtShiftID.Text = (int.Parse(drShift["ShiftID"].ToString()) + 1).ToString();
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
                // populate combo box
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
        private void fillProjectDropDown()
        {

        }


        private void fillTaskDropDown()
        {

        }

        public static DateTime getFirstDayOfWeek(DateTime dateToCheck, string firstDay)
        {
            // monday is passed in as first day of week
            DateTime dt = new DateTime();
            for (int i = 0; i < 7; i++)
            {
                if (dateToCheck.AddDays(-i).DayOfWeek.ToString() == firstDay)
                {
                    dt = dateToCheck.AddDays(-i);
                }
            }
            return dt;
        }




    }
}
