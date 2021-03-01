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
    public partial class frmAddShift : Form
    {


        SqlDataAdapter daShift, daAccount, daProject, daTask, daListProjects, daListTasks;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBShift, cmbBAccount, cmbBProject, cmbBTask;
        SqlCommand cmbListProjects, cmbListTasks;
        DataRow drShift, drAccount, drProject, drTask;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        String connStr, sqlShift, sqlAccount, sqlProject, sqlTask, sqlListProjects, sqlListTasks;



        public frmAddShift()
        {
            InitializeComponent();
        }

        private void frmAddShift_Load(object sender, EventArgs e)
        {
            // converts date time picker to time only
            dtpShiftStartTime.CustomFormat = "hh:mm tt";
            dtpShiftStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpShiftStartTime.ShowUpDown = true;


            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

           // set up data adapter for project ID drop down
            sqlListProjects = @"Select ProjectID, ProjDesc, AccountID, StartDate from Project where AccountID = @AccountID";
            conn = new SqlConnection(connStr);
            cmbListProjects = new SqlCommand(sqlListProjects, conn);
            cmbListProjects.Parameters.Add("@AccountID", SqlDbType.Int);
            daListProjects = new SqlDataAdapter(cmbListProjects);
            daListProjects.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");


            // set up data adapter for Task ID drop down
         //   sqlListTasks = "@select ProjectID, TaskID, TaskDesc from ProjectTask where ProjectID like @ProjectID";
         //   conn = new SqlConnection(connStr);
         //   cmbListTasks = new SqlCommand(sqlListTasks, conn);
          //  cmbListTasks.Parameters.Add("@ProjectID", SqlDbType.Int);
          //  daListTasks = new SqlDataAdapter(cmbListTasks);
            //daListTasks.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");


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
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void getNumberProject(int noRows)
        {
            drShift = dsFujitsuPayments.Tables["EmployeeShift"].Rows[noRows - 1];
            txtShiftID.Text = (int.Parse(drShift["ShiftID"].ToString()) + 1).ToString();
        }

        private void cmbAccountId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dsFujitsuPayments.Tables["Project"].Clear();
            //cmbListProjects.Parameters["@AccountID"].Value = cmbAccountId.SelectedValue;
            //daListProjects.Fill(dsFujitsuPayments, "Project");

            //cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
            //cmbProjectId.ValueMember = "ProjectID";
            //cmbProjectId.DisplayMember = "ProjDesc";




        }
        private void fillProjectDropDown()
        {

        }


        private void fillTaskDropDown()
        {

        }
    }
}
