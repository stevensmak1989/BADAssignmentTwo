using System;
using System.Collections.Generic;
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
    public partial class frmViewShifts : Form
    {
        SqlDataAdapter daEmpShift, daEmpShiftDet, daEmpShiftDet2;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBEmpShift, cmbBEmpShiftDet, cmbBEmpShiftDet2;
        SqlCommand cmbEmpShift, cmbEmpShiftDet, cmbEmpShiftDet2;
        DataRow drEmpShift, drEmpShiftDet, drEmpShiftDet2;
        String connStr, sqlEmpShift, sqlEmpShiftDet, sqlEmpShiftDet2;



        public frmViewShifts()
        {
            InitializeComponent();
        }

        private void frmViewShifts_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";



            // -------------------set up adapter for employee shift gridview
            sqlEmpShift = @"select emp.ShiftID, emp.AccountID, a.ClientName, emp.ProjectID ,p.ProjDesc, emp.TaskID, pj.TaskDesc, emp.StartDate, 
		                    emp.StartTime, emp.EndTime 
                            from EmployeeShift emp
                            inner join Account a
                            on emp.AccountID = a.AccountID
                            inner join Project p
                            on emp.ProjectID = p.ProjectID
                            inner join ProjectTask pj
                            on emp.ProjectID = pj.ProjectID and emp.TaskID = pj.TaskID";
            daEmpShift = new SqlDataAdapter(sqlEmpShift, connStr);
            cmbBEmpShift = new SqlCommandBuilder(daEmpShift);
            daEmpShift.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShift");
            daEmpShift.Fill(dsFujitsuPayments, "EmployeeShift");


            // -------------------set up adapter for employeeshiftdetails gridiview
            sqlEmpShiftDet = @" select esd.ShiftID, esd.EmployeeID, e.Forename, e.Surname
                                from EmployeeShiftDetails esd
                                inner join Employee e
                                on esd.EmployeeID = e.EmployeeID where ShiftID like @ShiftID";
            conn = new SqlConnection(connStr);
            cmbEmpShiftDet = new SqlCommand(sqlEmpShiftDet, conn);
            cmbEmpShiftDet.Parameters.Add("@ShiftID", SqlDbType.Int);
            daEmpShiftDet = new SqlDataAdapter(cmbEmpShiftDet);
            daEmpShiftDet.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShiftDetails");


            // ---------------basic adapter for deleting employee shift details
            sqlEmpShiftDet2 = @"select * from EmployeeShiftDetails";
            daEmpShiftDet2 = new SqlDataAdapter(sqlEmpShiftDet2, connStr);
            cmbBEmpShiftDet2 = new SqlCommandBuilder(daEmpShiftDet2);
            daEmpShiftDet2.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShiftDetails2");
            daEmpShiftDet2.Fill(dsFujitsuPayments, "EmployeeShiftDetails2");


            //  populate employee shift datagridview
            dgvEmpShift.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvEmpShift.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvEmpShift.DataSource = dsFujitsuPayments.Tables["EmployeeShift"];
            dgvEmpShift.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void selectionChanged(object sender, EventArgs e)
        {

            if (dgvEmpShift.Focused == true)
            {
                refreshEmpoyeeShiftDetGridView();
            }
            else
            {
                
            }
        }


        private void btnDeleteShift_Click(object sender, EventArgs e)
        {

            if (dgvEmpShiftDetails.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Employee Shift from the list.", "Select Shift");
            }
            else
            {
                object[] primaryKey = new object[2];
                primaryKey[0] = Convert.ToInt32(dgvEmpShiftDetails.SelectedRows[0].Cells[0].Value);
                primaryKey[1] = Convert.ToInt32(dgvEmpShiftDetails.SelectedRows[0].Cells[1].Value);

                drEmpShiftDet2 = dsFujitsuPayments.Tables["EmployeeShiftDetails2"].Rows.Find(primaryKey);
                string tempName = drEmpShiftDet2["ShiftID"].ToString() + " " + drEmpShiftDet2["EmployeeID"].ToString() + "\'s";


                if (MessageBox.Show("Are you sure you want to delete " + tempName +  "details?", "Add Shift", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drEmpShiftDet2.Delete();
                    daEmpShiftDet2.Update(dsFujitsuPayments, "EmployeeShiftDetails2");
                    MessageBox.Show("Record Deleted");

                    refreshEmpoyeeShiftDetGridView();

                }
            }
        }



        private void refreshEmpoyeeShiftDetGridView()
        {
            dsFujitsuPayments.Tables["EmployeeShiftDetails"].Clear();

            if (dgvEmpShift.SelectedRows[0].Cells[0].Value == null || String.IsNullOrEmpty(dgvEmpShift.SelectedRows[0].Cells[0].Value.ToString()))
            {
                MessageBox.Show("Please select a row that contains valid data");
            }
            else
            {
                cmbEmpShiftDet.Parameters["@ShiftID"].Value = Convert.ToInt32(dgvEmpShift.SelectedRows[0].Cells[0].Value);
                daEmpShiftDet.Fill(dsFujitsuPayments, "EmployeeShiftDetails");
                dgvEmpShiftDetails.DefaultCellStyle.Font = new Font("Century Gothic", 9);

                dgvEmpShiftDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
                dgvEmpShiftDetails.DataSource = dsFujitsuPayments.Tables["EmployeeShiftDetails"];
                dgvEmpShiftDetails.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }
    }
}
