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
        //sql connections used for database controls
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
          

        }
        //called when the form loads to set the sql connections
        private void UC_Employee__Load(object sender, EventArgs e)
        {
            // style fornt of data grid cell and header
            this.dvgEmployee.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            this.dvgEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 8);

         
            //sets the datasource to employee 
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlEmployee = @"select * from Employee";
            daEmployee = new SqlDataAdapter(sqlEmployee, connStr);
            cmbBEmployee = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

            //sets the datagrid to the datasource
            dvgEmployee.DataSource = dsFujitsuPayments.Tables["Employee"];
            // resize the datagridview columns to fit the newly loaded content
            dvgEmployee.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            checkRefresh();

        }

     

        public void checkRefresh()
        {

            dvgEmployee.DataSource = dsFujitsuPayments.Tables["Employee"];
            
        }
        //edit button
        private void btnEmployeeEdit_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgEmployee.SelectedRows.Count == 0)
            {
                empSelected = false;
                empNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select Employee");
            }
            //checks if more than one row is selected
            else if (dvgEmployee.SelectedRows.Count > 1)
            {
                empSelected = false;
                empNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select Employee");

            }
            //if one row is selected it sets the employee number from the datagrid to empselected so it can be accessed in the edit
            else if (dvgEmployee.SelectedRows.Count == 1)
            {
                empSelected = true;
                empNoSelected = Convert.ToInt32(dvgEmployee.SelectedRows[0].Cells[0].Value);
                //initialises the edit form and sets the location
                frmEditEmployee frm = new frmEditEmployee();
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Location = new Point(135, 109);
                frm.ShowDialog();

            }
        }
        //delete button
        private void btnEmployeeDel_Click(object sender, EventArgs e)
        {
            //checks if no records are selected
            if (dvgEmployee.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Employee from the list.", "Select Employee");
            }
            else
            {
                // sets the data row to the datagrid row selected
                drEmployee = dsFujitsuPayments.Tables["Employee"].Rows.Find(dvgEmployee.SelectedRows[0].Cells[0].Value);

                string tempName = drEmployee["Forename"].ToString() + " " + drEmployee["Surname"].ToString() + "'s";
                //asks the user to confirm deletion
                if (MessageBox.Show("Are you sure you want to delete " + tempName + " details?", "Add Employee", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // trys the delete
                    try
                    {
                        drEmployee.Delete();
                        daEmployee.Update(dsFujitsuPayments, "Employee");
                    }
                    // will catch any error if the employee has related records
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
        //used to refresh the employee data grid
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UC_Employee__Load(sender, e);
        }
        // add button
        private void btnEmployeeAdd_Click(object sender, EventArgs e)
        {
            //initialises the add form and sets location
            frmAddEmployee frmAdd = new frmAddEmployee();
            frmAdd.FormBorderStyle = FormBorderStyle.None;
            frmAdd.Location = new Point(135, 109);
            frmAdd.ShowDialog();

        }
    }
}
