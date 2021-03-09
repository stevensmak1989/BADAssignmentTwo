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
    public partial class frmAssignShift : Form
    {


        SqlDataAdapter daEmployeeShift, daEmployee, daAccount, daProject, daTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBEmployeeShift, cmbBAccount, cmbBProject, cmbBTask, cmbBEmployee;
        SqlCommand cmbShift, cmbEmployee;
        DataRow drEmployeeShift, drEmployee, drAccount, drProject, drTask;
        String connStr, sqlEmployeeShift, sqlAccount, sqlProject, sqlTask, sqlEmployee;

        public frmAssignShift()
        {
            InitializeComponent();
        }



        private void frmAssignShift_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";


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


            // -- setup datat adapter for employee dropdown
            sqlEmployee = @"select e.EmployeeID, e.Forename, e.Surname from Employee e
                             inner join ProjectTaskEmployee pte
                               on e.EmployeeID = pte.EmployeeID
							   where pte.TaskID like @TaskID and pte.ProjectID like @ProjectID";
            conn = new SqlConnection(connStr);
            cmbEmployee = new SqlCommand(sqlEmployee, conn);
            cmbEmployee.Parameters.Add("@TaskID", SqlDbType.Int);
            cmbEmployee.Parameters.Add("@ProjectID", SqlDbType.Int);
            daEmployee = new SqlDataAdapter(cmbEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");

            cmbEmployee.Parameters["@TaskID"].Value = UC_Schedule.taskIdSelected.ToString();
            cmbEmployee.Parameters["@ProjectID"].Value = UC_Schedule.projIdSelected.ToString();

            daEmployee.Fill(dsFujitsuPayments, "Employee");

            cmbEmployeeID.DataSource = dsFujitsuPayments.Tables["Employee"];
            cmbEmployeeID.ValueMember = "EmployeeID";
            cmbEmployeeID.DisplayMember = "Forename";

            // ---- Populate text fields on form
            txtAssignShiftID.Text = UC_Schedule.shiftIdSelected.ToString();
            drAccount = dsFujitsuPayments.Tables["Account"].Rows.Find(UC_Schedule.accIdSelected.ToString());
            txtAccountID.Text = drAccount["ClientName"].ToString();
            drProject = dsFujitsuPayments.Tables["Project"].Rows.Find(UC_Schedule.projIdSelected.ToString());
            txtProjectID.Text = drProject["ProjDesc"].ToString();

            // create primaye key object -- composite primary key
            object[] primaryKey = new object[2];
            primaryKey[0] = Convert.ToInt32(UC_Schedule.projIdSelected.ToString());
            primaryKey[1] = Convert.ToInt32(UC_Schedule.taskIdSelected.ToString());
            drTask = dsFujitsuPayments.Tables["ProjectTask"].Rows.Find(primaryKey);
            txtTaskID.Text = drTask["TaskDesc"].ToString();

            sqlEmployeeShift = @"select * from EmployeeShiftDetails";
            daEmployeeShift = new SqlDataAdapter(sqlEmployeeShift, connStr);
            cmbBEmployeeShift = new SqlCommandBuilder(daEmployeeShift);
            daEmployeeShift.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShiftDetails");
            daEmployeeShift.Fill(dsFujitsuPayments, "EmployeeShiftDetails");

        }



        private void btnAssignSave_Click(object sender, EventArgs e)
        {
            EmployeeShiftDetails myEmployeeShift = new EmployeeShiftDetails();

            bool ok = true;
            errP.Clear();


            // pass data to class for validation
            try
            {
                myEmployeeShift.ShiftId = Convert.ToInt32(txtAssignShiftID.Text);
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAssignShiftID, MyEx.toString());
            }

            // pass data to class for validation
            try
            {
                myEmployeeShift.EmployeeId = Convert.ToInt32(cmbEmployeeID.SelectedValue);
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbEmployeeID, MyEx.toString());
            }

            try
            {
                if (ok)
                {
                    drEmployeeShift = dsFujitsuPayments.Tables["EmployeeShiftDetails"].NewRow();

                    drEmployeeShift["ShiftID"] = myEmployeeShift.ShiftId;
                    drEmployeeShift["EmployeeID"] = myEmployeeShift.EmployeeId;
                    dsFujitsuPayments.Tables["EmployeeShiftDetails"].Rows.Add(drEmployeeShift);
                    daEmployeeShift.Update(dsFujitsuPayments, "EmployeeShiftDetails");

                    MessageBox.Show("Employee Shift Added");
                    this.Dispose();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }




        }


        private void btnAssignClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
