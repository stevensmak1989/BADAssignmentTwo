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


        SqlDataAdapter daShift, daAccount, daProject, daTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBShift, cmbBAccount, cmbBProject, cmbBTask;
        SqlCommand cmbProject, cmbTask;
        DataRow drShift, drAccount, drProject, drTask;



        private void button1_Click(object sender, EventArgs e)
        {

        }

        String connStr, sqlShift, sqlAccount, sqlProject, sqlTask;



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
            if (cmbAccountId.Focused == true)
            {

                dsFujitsuPayments.Tables["Project"].Clear();
                cmbProject.Parameters["@AccountID"].Value = cmbAccountId.SelectedValue;

               // MessageBox.Show("Selected Value = " + cmbAccountId.SelectedValue);
                try
                {
                    daProject.Fill(dsFujitsuPayments, "Project");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex);
                }

                cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
                cmbProjectId.ValueMember = "ProjectID";
                cmbProjectId.DisplayMember = "ProjDesc";
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

                MessageBox.Show("Project ID = " + cmbProjectId.SelectedValue);

                cmbTask.Parameters["ProjectID"].Value = cmbProjectId.SelectedValue;

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
    }
}
