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
    public partial class frmAddTask : Form
    {
        //initialises the sql connectors
        SqlDataAdapter daProject, daTask, daTasks;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBTask;
        DataRow drProject, drTask;
        String connStr, sqlProject, sqlTask, sqlTasks;
        SqlConnection conn; 
        SqlCommand cmdTasks;

        //closes the form when the exit button is selected
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //is called when the user changes the account
        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checks if the combo box has focus
            if(cmbProjectId.Focused == true)
            {
                //this will check the number of rows for tasks
                int noRows = dsFujitsuPayments.Tables["Tasks"].Rows.Count;

                //clears the tables
                dsFujitsuPayments.Tables["Tasks"].Clear();
                cmdTasks.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue.ToString();

                daTasks.Fill(dsFujitsuPayments, "Tasks");
                DataTable dt = dsFujitsuPayments.Tables["Tasks"];

                int count = 0;
                //checks the number of rows in tasks
                foreach (DataRow row in dt.Rows)
                {
                    count += 1;
                }

                //if tasks is 0 will set the value to 1
                if (count == 0)
                    lblTaskId.Text = "1";
                else
                {
                    lblTaskId.Text = Convert.ToString(count +1);
                }
            }
        }
        //this is called when the user saves
        private void btnSave_Click(object sender, EventArgs e)
        {
            ProjectTask myProject = new ProjectTask();
            bool ok = true;
            errP.Clear();

           
            try
            {
                myProject.TaskId = Convert.ToInt32(lblTaskId.Text.Trim());
                

            }
            //catches errors for class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblTaskId, MyEx.toString());
            }

            try
            {
                myProject.TaskDesc = txtTaskDesc.Text.Trim();
            }
            //catches errors for class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTaskDesc, MyEx.toString());
            }

            try
            {
                myProject.ProjectId = Convert.ToInt32(cmbProjectId.SelectedValue);
            }
            //catches errors for class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbProjectId, MyEx.toString());
            }
            try
            {
                //if validation passes
                if (ok)
                {
                    //creates the new row

                    drTask = dsFujitsuPayments.Tables["ProjectTask"].NewRow();

                    drTask["ProjectID"] = myProject.ProjectId;
                    drTask["TaskID"] = myProject.TaskId;
                    drTask["TaskDesc"] = myProject.TaskDesc;

                    //adds the row to the database
                    dsFujitsuPayments.Tables["ProjectTask"].Rows.Add(drTask);
                    daTask.Update(dsFujitsuPayments, "ProjectTask");

                    MessageBox.Show("Task Added");
                    this.Dispose();

                }
            }
            //catches unexpected errors
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
        //loads when the form is called
    private void frmAddTask_Load(object sender, EventArgs e)
        {
            //gets the project data
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlProject = @"select * from Project";
            daProject = new SqlDataAdapter(sqlProject, connStr);
            cmbBProject = new SqlCommandBuilder(daProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");
            daProject.Fill(dsFujitsuPayments, "Project");

            //gets the project task data
            sqlTask = @"select * from ProjectTask";
            daTask = new SqlDataAdapter(sqlTask, connStr);
            cmbBTask = new SqlCommandBuilder(daTask);
            daTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");
            daTask.Fill(dsFujitsuPayments, "ProjectTask");

            //sets the project id combo box to the project table
            cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
            cmbProjectId.ValueMember = "ProjectID";
            cmbProjectId.DisplayMember = "ProjDesc";

            sqlTasks = @"select * from ProjectTask where ProjectID =  @ProjectID";
            conn = new SqlConnection(connStr);
            cmdTasks = new SqlCommand(sqlTasks, conn);
            cmdTasks.Parameters.Add("@ProjectID", SqlDbType.VarChar);
            daTasks = new SqlDataAdapter(cmdTasks);
            daTasks.FillSchema(dsFujitsuPayments, SchemaType.Source, "Tasks");
        }
        private void getNumber(int noRows)
        {
            drProject = dsFujitsuPayments.Tables["Tasks"].Rows[noRows - 1];
            lblTaskId.Text = (int.Parse(drProject["TaskID"].ToString()) + 1).ToString();
        }



        public frmAddTask()
        {
            InitializeComponent();
        }

       
    }
}
