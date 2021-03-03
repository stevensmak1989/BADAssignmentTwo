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

        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";
            sqlTask = @"Select ProjectID, TaskId, TaskDesc from ProjectTask where ProjectID = @ProjectID ";
            
            cmdTask = new SqlCommand(sqlTask, conn);
            daTask = new SqlDataAdapter(cmdTask);


            label1.Text = cmbProjectId.SelectedValue.ToString();
            cmdTask.Parameters.Add("@ProjectID", SqlDbType.Int);
            cmdTask.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue.ToString();
           

            cmbBTask = new SqlCommandBuilder(daTask);

            daTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");
            cmbEmp.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
            cmbEmp.ValueMember = "TaskID";
            cmbEmp.DisplayMember = "TaskDesc";
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


            
            





            //sqlTask = @"select * from ProjectTask  WHERE ProjectID = @ProjectTask";
            //cmdTask = new SqlCommand(sqlTask, conn);
            //cmdTask.Parameters.Add("@ProjectID", SqlDbType.Int);
            //daTask = new SqlDataAdapter(cmdTask.ToString(), connStr);
            //daTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");
            //daTask.Fill(dsFujitsuPayments, "ProjectTask");

            sqlEmp = @"select EmployeeID, Surname + ' ' + Forename as EmpName from Employee";
            daEmployee = new SqlDataAdapter(sqlEmp, connStr);
            cmbBEmp = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

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
