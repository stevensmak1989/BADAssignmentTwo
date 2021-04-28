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


        SqlDataAdapter daEmployeeShift, daEmployee, daAccount, daProject, daTask, daEmployeeShift2, daEmployeeShift3;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBEmployeeShift, cmbBAccount, cmbBProject, cmbBTask, cmbBEmployee, cmbBEmployeeShift2;
        SqlCommand cmbShift, cmbEmployee, cmbEmployeeShift2, cmbEmployeeShift3;
        DataRow drEmployeeShift, drEmployee, drAccount, drProject, drTask, drEmployeeShift2, drEmployeeShift3;
        String connStr, sqlEmployeeShift, sqlAccount, sqlProject, sqlTask, sqlEmployee, sqlEmployeeShift2, sqlEmployeeShift3;

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


            sqlEmployeeShift2 = @" select * from EmployeeShiftDetails where ShiftID = @ShiftID";
            conn = new SqlConnection(connStr);
            cmbEmployeeShift2 = new SqlCommand(sqlEmployeeShift2, conn);
            cmbEmployeeShift2.Parameters.Add("@ShiftID", SqlDbType.Int);
            daEmployeeShift2 = new SqlDataAdapter(cmbEmployeeShift2);
            daEmployeeShift2.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShiftDetails2");


            sqlEmployeeShift3 = @" select * from EmployeeShiftDetails where ShiftID = @ShiftID and EmployeeID = @EmployeeID";
            conn = new SqlConnection(connStr);
            cmbEmployeeShift3 = new SqlCommand(sqlEmployeeShift3, conn);
            cmbEmployeeShift3.Parameters.Add("@ShiftID", SqlDbType.Int);
            cmbEmployeeShift3.Parameters.Add("@EmployeeID", SqlDbType.Int);
            daEmployeeShift3 = new SqlDataAdapter(cmbEmployeeShift3);
            daEmployeeShift3.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShiftDetails3");
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
                // -------------------- if more than one row is selected from Schedule---------------------- // 
                if (UC_Schedule.moreThanOneRow == true)
                {
                    for(int i = 0; i < UC_Schedule.selectedRow; i++)
                    {
                        // get a list of all records in employee shift for specificed shiftID
                        cmbEmployeeShift2.Parameters["@ShiftID"].Value = UC_Schedule.selectedShiftIDs[i];
                        daEmployeeShift2.Fill(dsFujitsuPayments, "EmployeeShiftDetails2");
                        int count = 0;
                        // set variable equal to number of rows
                        foreach (DataRow dr in dsFujitsuPayments.Tables["EmployeeShiftDetails2"].Rows)
                        {
                            count = count + 1;
                        }
                        // if rows equal 4 do not add record
                        if (count == 4)
                        {
                            MessageBox.Show("Only 4 Employess can be assigned to a Shift");
                        }
                        else
                        {
                            // get a list of all records in employee shift for specificed shiftID
                            cmbEmployeeShift3.Parameters["@ShiftID"].Value = UC_Schedule.selectedShiftIDs[i];
                            cmbEmployeeShift3.Parameters["@EmployeeID"].Value = myEmployeeShift.EmployeeId;
                            daEmployeeShift3.Fill(dsFujitsuPayments, "EmployeeShiftDetails3");
                            int count1 = 0;
                            foreach (DataRow dr1 in dsFujitsuPayments.Tables["EmployeeShiftDetails3"].Rows)
                            {
                                count1 = count1 + 1;
                            }
                            if (count1 > 0)
                            {
                                MessageBox.Show("Employee has already been assigned to shift :" + UC_Schedule.selectedShiftIDs[i].ToString());
                            }
                            else
                            {
                                if (ok)
                                {
                                    drEmployeeShift = dsFujitsuPayments.Tables["EmployeeShiftDetails"].NewRow();
                                    drEmployeeShift["ShiftID"] = UC_Schedule.selectedShiftIDs[i];
                                    drEmployeeShift["EmployeeID"] = myEmployeeShift.EmployeeId;
                                    dsFujitsuPayments.Tables["EmployeeShiftDetails"].Rows.Add(drEmployeeShift);
                                    daEmployeeShift.Update(dsFujitsuPayments, "EmployeeShiftDetails");                                   
                                }
                            }
                        }
                    }
                    MessageBox.Show("Employee Shift Added");
                    this.Dispose();

                }
                else // -------------------- only one record selected ----------------------- //
                {
                    // get a list of all records in employee shift for specificed shiftID
                    cmbEmployeeShift2.Parameters["@ShiftID"].Value = myEmployeeShift.ShiftId;
                    daEmployeeShift2.Fill(dsFujitsuPayments, "EmployeeShiftDetails2");
                    int count = 0;
                    // set variable equal to number of rows
                    foreach (DataRow dr in dsFujitsuPayments.Tables["EmployeeShiftDetails2"].Rows)
                    {
                        count = count + 1;
                    }
                    // if rows equal 4 do not add record
                    if (count == 4)
                    {
                        MessageBox.Show("Only 4 Employess can be assigned to a Shift");
                    }
                    else
                    {
                        // get a list of all records in employee shift for specificed shiftID
                        cmbEmployeeShift3.Parameters["@ShiftID"].Value = myEmployeeShift.ShiftId;
                        cmbEmployeeShift3.Parameters["@EmployeeID"].Value = myEmployeeShift.EmployeeId;
                        daEmployeeShift3.Fill(dsFujitsuPayments, "EmployeeShiftDetails3");
                        int count1 = 0;
                        foreach (DataRow dr1 in dsFujitsuPayments.Tables["EmployeeShiftDetails3"].Rows)
                        {
                            count1 = count1 + 1;
                        }
                        if (count1 > 0)
                        {
                            MessageBox.Show("Employee has already been assigned to shift");
                        }
                        else
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
                    }
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
