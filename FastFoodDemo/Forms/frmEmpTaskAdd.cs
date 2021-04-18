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
    public partial class frmEmpTaskAdd : Form
    {
        SqlDataAdapter daProject, daTask, daEmployee, daEmpTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBTask, cmbBEmp, cmbBEmpTask;
        SqlCommand cmdTask;
        DataRow drProject, drTask, drEmp, drEmpTask;

        String connStr, sqlProject, sqlTask, sqlEmp, sqlEmpTask;
        SqlConnection conn;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeTask myProject = new EmployeeTask();
            bool ok = true;
            errP.Clear();

            try
            {
                myProject.TaskId = Convert.ToInt32(cmbTaskCode.SelectedValue);
            

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbTaskCode, MyEx.toString());
            }

            try
            {
                myProject.EmployeeId = Convert.ToInt32(cmbEmp.SelectedValue);
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbEmp, MyEx.toString());
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
                    drEmpTask = dsFujitsuPayments.Tables["ProjectTaskEmployee"].NewRow();

                    drEmpTask["ProjectID"] = myProject.ProjectId;
                    drEmpTask["TaskID"] = myProject.TaskId;
                    drEmpTask["EmployeeID"] = myProject.EmployeeId;

                    dsFujitsuPayments.Tables["ProjectTaskEmployee"].Rows.Add(drEmpTask);
                    daEmpTask.Update(dsFujitsuPayments, "ProjectTaskEmployee");

                    MessageBox.Show("Task Added");
                    this.Dispose();

                }
            }
            catch(System.Data.ConstraintException ex)
            {
                MessageBox.Show("This user already has this task assigned, please select a new project");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbProjectId.Focused == true)
            {
                

                dsFujitsuPayments.Tables["ProjectTask"].Clear();
                cmdTask.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue;

                daTask.Fill(dsFujitsuPayments, "ProjectTask");

             
                cmbTaskCode.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
                cmbTaskCode.ValueMember = "TaskID";
                cmbTaskCode.DisplayMember = "TaskDesc";
            }
        }




        public frmEmpTaskAdd()
        {
            InitializeComponent();
        }



        private void frmEmpTaskAdd_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlProject = @"select * from Project";
            daProject = new SqlDataAdapter(sqlProject, connStr);
            cmbBProject = new SqlCommandBuilder(daProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");
            daProject.Fill(dsFujitsuPayments, "Project");




            sqlTask = @"Select ProjectID, TaskDesc, TaskID from ProjectTask where ProjectID like @ProjectID";
            conn = new SqlConnection(connStr);
            cmdTask = new SqlCommand(sqlTask, conn);
            cmdTask.Parameters.Add("@ProjectID", SqlDbType.Int);
            daTask = new SqlDataAdapter(cmdTask);
            daTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");

            sqlEmp = @"select EmployeeID, Surname + ' ' + Forename as EmpName from Employee";
            daEmployee = new SqlDataAdapter(sqlEmp, connStr);
            cmbBEmp = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

           

            sqlEmpTask = @"select * from ProjectTaskEmployee";
            daEmpTask = new SqlDataAdapter(sqlEmpTask, connStr);
            cmbBEmpTask = new SqlCommandBuilder(daEmpTask);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");
            daEmpTask.Fill(dsFujitsuPayments, "ProjectTaskEmployee");

            cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
            cmbProjectId.ValueMember = "ProjectID";
            cmbProjectId.DisplayMember = "ProjDesc";

            cmbEmp.DataSource = dsFujitsuPayments.Tables["Employee"];
            cmbEmp.ValueMember = "EmployeeID";
            cmbEmp.DisplayMember = "EmpName";

        }

        private void cmbTaskCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            

           

        }
    }
}
