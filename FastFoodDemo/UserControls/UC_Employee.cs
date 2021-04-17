using FujitsuPayments.Forms;
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

namespace FujitsuPayments.UserControls
{
    public partial class UC_Employee : UserControl
    {
        SqlDataAdapter daEmployee;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBEmployee;
        DataRow drEmployee;
        String connStr, sqlEmployee;

        // Static varibales to pass to form's
        public static int selectedTab = 0;
        public static bool empSelected = false;
        public static int empNoSelected = 0;
        public static bool refresh = false;

        public UC_Employee()
        {
            InitializeComponent();
            // style fornt of data grid cell and header
            this.dvgEmployee.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            this.dvgEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 8);

           // dvgEmployee.Visible = false;

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlEmployee = @"select * from Employee";
            daEmployee = new SqlDataAdapter(sqlEmployee, connStr);
            cmbBEmployee = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

            dvgEmployee.DataSource = dsFujitsuPayments.Tables["Employee"];
            // resize the datagridview columns to fit the newly loaded content
            dvgEmployee.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            checkRefresh();

        }
        private void UC_Employee__Load(object sender, EventArgs e)
        {
           

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEmployeeView_Click(object sender, EventArgs e)
        {
            
        }

        public void checkRefresh()
        {

            dvgEmployee.DataSource = dsFujitsuPayments.Tables["Employee"];
            
        }

        private void btnEmployeeEdit_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgEmployee.SelectedRows.Count == 0)
            {
                empSelected = false;
                empNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select Employee");
            }
            else if (dvgEmployee.SelectedRows.Count > 1)
            {
                empSelected = false;
                empNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select Employee");

            }
            else if (dvgEmployee.SelectedRows.Count == 1)
            {
                empSelected = true;
                empNoSelected = Convert.ToInt32(dvgEmployee.SelectedRows[0].Cells[0].Value);

                frmEditEmployee frm = new frmEditEmployee();
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Location = new Point(135, 109);
                frm.ShowDialog();

            }
        }

        private void btnEmployeeDel_Click(object sender, EventArgs e)
        {
            if (dvgEmployee.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Employee from the list.", "Select Employee");
            }
            else
            {
                drEmployee = dsFujitsuPayments.Tables["Employee"].Rows.Find(dvgEmployee.SelectedRows[0].Cells[0].Value);

                string tempName = drEmployee["Forename"].ToString() + " " + drEmployee["Surname"].ToString() + "'s";

                if (MessageBox.Show("Are you sure you want to delete " + tempName + " details?", "Add Employee", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        drEmployee.Delete();
                        daEmployee.Update(dsFujitsuPayments, "Employee");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Cannot delete an Employee that has related records, please delete all related records first", "Delete Employee");
                    }
                    // update grid and clear errors
                    UC_Employee__Load(sender, e);
                    drEmployee.ClearErrors();

                }
            }
        }

        private void btnEmployeeAdd_Click(object sender, EventArgs e)
        {
            frmAddEmployee frmAdd = new frmAddEmployee();
            frmAdd.FormBorderStyle = FormBorderStyle.None;
            frmAdd.Location = new Point(135, 109);
            frmAdd.ShowDialog();

        }
    }
}
