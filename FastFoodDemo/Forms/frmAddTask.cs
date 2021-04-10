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
        SqlDataAdapter daProject, daTask, daTasks;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBTask;
        DataRow drProject, drTask;
        String connStr, sqlProject, sqlTask, sqlTasks;
        SqlConnection conn; 
        SqlCommand cmdTasks;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbProjectId.Focused == true)
            {
                int noRows = dsFujitsuPayments.Tables["Tasks"].Rows.Count;

                MessageBox.Show(cmbProjectId.SelectedValue.ToString());

                dsFujitsuPayments.Tables["Tasks"].Clear();
                cmdTasks.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue.ToString();

                daTasks.Fill(dsFujitsuPayments, "Tasks");
                DataTable dt = dsFujitsuPayments.Tables["Tasks"];

                int count = 0;
                foreach (DataRow row in dt.Rows)
                {

                    count += 1;

                }

                if (count == 0)
                    lblTaskId.Text = "1";
                else
                {
                    lblTaskId.Text = Convert.ToString(count +1);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProjectTask myProject = new ProjectTask();
            bool ok = true;
            errP.Clear();

            //employee number
            try
            {
                myProject.TaskId = Convert.ToInt32(lblTaskId.Text.Trim());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblTaskId, MyEx.toString());
            }

            try
            {
                myProject.TaskDesc = txtTaskDesc.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtTaskDesc, MyEx.toString());
            }

            try
            {
                myProject.ProjectId = Convert.ToInt32(cmbProjectId.SelectedValue);
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbProjectId, MyEx.toString());
            }
            try
            {
                if (ok)
                {

                    drTask = dsFujitsuPayments.Tables["ProjectTask"].NewRow();

                    drTask["ProjectID"] = myProject.ProjectId;
                    drTask["TaskID"] = myProject.TaskId;
                    drTask["TaskDesc"] = myProject.TaskDesc;

                    dsFujitsuPayments.Tables["ProjectTask"].Rows.Add(drTask);
                    daTask.Update(dsFujitsuPayments, "ProjectTask");

                    MessageBox.Show("Task Added");
                    this.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

    private void frmAddTask_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlProject = @"select * from Project";
            daProject = new SqlDataAdapter(sqlProject, connStr);
            cmbBProject = new SqlCommandBuilder(daProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");
            daProject.Fill(dsFujitsuPayments, "Project");

            sqlTask = @"select * from ProjectTask";
            daTask = new SqlDataAdapter(sqlTask, connStr);
            cmbBTask = new SqlCommandBuilder(daTask);
            daTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");
            daTask.Fill(dsFujitsuPayments, "ProjectTask");

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
