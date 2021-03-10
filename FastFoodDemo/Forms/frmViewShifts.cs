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
        SqlDataAdapter daEmpShift, daEmpShiftDet;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBEmpShift, cmbBEmpShiftDet;
        SqlCommand cmbEmpShift, cmbEmpShiftDet;
        DataRow drEmpShift, drEmpShiftDet;
        String connStr, sqlEmpShift, sqlEmpShiftDet;



        public frmViewShifts()
        {
            InitializeComponent();
        }

        private void frmViewShifts_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

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

            dgvEmpShift.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            dgvEmpShift.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);

            dgvEmpShift.DataSource = dsFujitsuPayments.Tables["EmployeeShift"];
            // resize the datagridview columns to fit the newly loaded content
            dgvEmpShift.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            sqlEmpShiftDet = @"select * from EmployeeShiftDetails";
            daEmpShiftDet = new SqlDataAdapter(sqlEmpShiftDet, connStr);
            cmbBEmpShiftDet = new SqlCommandBuilder(daEmpShiftDet);
            daEmpShiftDet.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShiftDetails");
            daEmpShiftDet.Fill(dsFujitsuPayments, "EmployeeShiftDetails");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void selectionChanged(object sender, EventArgs e)
        {

            if (dgvEmpShift.Focused == true)
            {

                dsFujitsuPayments.Tables["EmployeeShiftDetails"].Clear();

                // dgvEmpShiftDetails.DataSource = null;

                sqlEmpShiftDet = @"select * from EmployeeShiftDetails where ShiftID like @ShiftID";
                conn = new SqlConnection(connStr);
                cmbEmpShiftDet = new SqlCommand(sqlEmpShiftDet, conn);
                cmbEmpShiftDet.Parameters.Add("@ShiftID", SqlDbType.Int);
                daEmpShiftDet = new SqlDataAdapter(cmbEmpShiftDet);
                daEmpShiftDet.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShiftDetails");

                

                cmbEmpShiftDet.Parameters["@ShiftID"].Value = Convert.ToInt32(dgvEmpShift.SelectedRows[0].Cells[0].Value);
                daEmpShiftDet.Fill(dsFujitsuPayments, "EmployeeShiftDetails");

                dgvEmpShiftDetails.DefaultCellStyle.Font = new Font("Century Gothic", 9);
                dgvEmpShiftDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
                dgvEmpShiftDetails.DataSource = dsFujitsuPayments.Tables["EmployeeShiftDetails"];

                // resize the datagridview columns to fit the newly loaded content
                dgvEmpShiftDetails.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                dgvEmpShiftDetails.Refresh();
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

                drEmpShiftDet = dsFujitsuPayments.Tables["EmployeeShiftDetails"].Rows.Find(primaryKey);
                string tempName = drEmpShiftDet["ShiftID"].ToString() + "\'s";


                if (MessageBox.Show("Are you sure you want to delete " + tempName + "details?", "Add Shift", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drEmpShiftDet.Delete();
                    daEmpShiftDet.Update(dsFujitsuPayments, "EmployeeShiftDetails");
                }
            }
        }
    }
}
