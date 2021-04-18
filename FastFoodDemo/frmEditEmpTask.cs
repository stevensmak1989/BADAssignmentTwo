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

namespace FujitsuPayments
{
    public partial class frmEditEmpTask : Form
    {
        SqlDataAdapter daProject, daTask, daEmployee, daEmpTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBTask, cmbBEmp, cmbBEmpTask;

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeTask myProject = new EmployeeTask();
            bool ok = true;
            errP.Clear();

            try
            {
                myProject.TaskId = Convert.ToInt32(cmbTaskCode.SelectedValue);
                MessageBox.Show(Convert.ToString(cmbTaskCode.SelectedValue));

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbTaskCode, MyEx.toString());

            }

            try
            {
                myProject.EmployeeId = Convert.ToInt32(cmbEmp.SelectedValue);
                MessageBox.Show(Convert.ToString(cmbEmp.SelectedValue));
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbEmp, MyEx.toString());
            }

            try
            {
                myProject.ProjectId = Convert.ToInt32(cmbProjectId.SelectedValue);
                MessageBox.Show(Convert.ToString(cmbProjectId.SelectedValue));
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
                    drTask["EmployeeID"] = myProject.EmployeeId;

                    drTask.EndEdit();
                    daEmpTask.Update(dsFujitsuPayments, "ProjectTaskEmployee");

                    MessageBox.Show("Project Task Updated");
                    this.Dispose();
                   

                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please ensure you have selected a value");
            }
            catch (System.Data.ConstraintException ex)
            {
                MessageBox.Show("This user already has this task assigned, please select a new project");
            }
           

            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        SqlCommand cmdTask;
        DataRow drProject, drTask, drEmp, drEmpTask;

        String connStr, sqlProject, sqlTask, sqlEmp, sqlEmpTask;
        SqlConnection conn;
        public frmEditEmpTask()
        {
            InitializeComponent();
        }

        private void frmEditEmpTask_Load(object sender, EventArgs e)
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

            cmdTask.Parameters["@ProjectID"].Value = UC_EmpProTask.prjNoSelected;

            daTask.Fill(dsFujitsuPayments, "ProjectTask");


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

            cmbTaskCode.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
            cmbTaskCode.ValueMember = "TaskID";
            cmbTaskCode.DisplayMember = "TaskDesc";

            cmbEmp.DataSource = dsFujitsuPayments.Tables["Employee"];
            cmbEmp.ValueMember = "EmployeeID";
            cmbEmp.DisplayMember = "EmpName";

            cmbEmp.SelectedValue = UC_EmpProTask.empNoSelected ;
            cmbProjectId.SelectedValue = UC_EmpProTask.prjNoSelected;
            cmbTaskCode.SelectedValue = UC_EmpProTask.tskNoSelected;

        



            object[] primaryKey = new object[3];

            primaryKey[0] = Convert.ToInt32(UC_EmpProTask.prjNoSelected);
            primaryKey[1] = Convert.ToInt32(UC_EmpProTask.tskNoSelected);
            primaryKey[2] = Convert.ToInt32(UC_EmpProTask.empNoSelected);


           

            drTask = dsFujitsuPayments.Tables["ProjectTaskEmployee"].Rows.Find(primaryKey);

        }
    }
}
