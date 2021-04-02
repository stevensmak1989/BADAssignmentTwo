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
    public partial class frmEditTask : Form
    {

        SqlDataAdapter daProject, daTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBTask;
        DataRow drProject, drTask;
        String connStr, sqlProject, sqlTask;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                    
                    drTask.BeginEdit();

                    drTask["ProjectID"] = myProject.ProjectId;
                    drTask["TaskID"] = myProject.TaskId;
                    drTask["TaskDesc"] = myProject.TaskDesc;

                    drTask.EndEdit();
                    daTask.Update(dsFujitsuPayments, "ProjectTask");

                    MessageBox.Show("Project Task Updated");
                    this.Dispose();
                    UC_Employee.refresh = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }


        private void frmEditTask_Load(object sender, EventArgs e)
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

            lblTaskId.Text = UC_Task.tskNoSelected.ToString();
            string prjno = UC_Task.prjNoSelected.ToString();

            object[] primaryKey = new object[2];

            primaryKey[0] = Convert.ToInt32(prjno);
            primaryKey[1] = Convert.ToInt32(lblTaskId.Text);

            //cmbProjectId.Text = UC_Project.prjNoSelected.ToString();

            drTask = dsFujitsuPayments.Tables["ProjectTask"].Rows.Find(primaryKey);

            cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
            cmbProjectId.ValueMember = "ProjectID";
            cmbProjectId.DisplayMember = "ProjDesc";

            cmbProjectId.Text = drTask["ProjectID"].ToString();
            txtTaskDesc.Text = drTask["TaskDesc"].ToString();
        }

     

        public frmEditTask()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
