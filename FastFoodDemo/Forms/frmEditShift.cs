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

            // format date time to only show time for combo box
            DateTime st = DateTime.Parse(drShift["StartTime"].ToString());
            cmbStartTime.Text = st.ToString("HH:mm");

            DateTime et = DateTime.Parse(drShift["EndTime"].ToString());
            cmbEndTime.Text = et.ToString("HH:mm");

        }

        private void btnEditClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void btnEditSave_Click(object sender, EventArgs e)
        {


            EmployeeShift myShift = new EmployeeShift();

            bool ok = true;
            errP.Clear();
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
                String time = cmbStartTime.SelectedItem.ToString();
                myShift.StartTime = DateTime.Parse(time);
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbStartTime, MyEx.toString());
            }

            try
            {
                String time = cmbEndTime.SelectedItem.ToString();
                myShift.EndTime = DateTime.Parse(time);
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
