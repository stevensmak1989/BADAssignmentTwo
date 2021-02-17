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
        frmAddEmployee frmAdd = new frmAddEmployee();
        public UC_Employee()
        {
            InitializeComponent();
            // style fornt of data grid cell and header
            this.dvgEmployee.DefaultCellStyle.Font = new Font("Century Gothic", 8);
            this.dvgEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 8);

            dvgEmployee.Visible = false;

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";

            sqlEmployee = @"select * from Employee";
            daEmployee = new SqlDataAdapter(sqlEmployee, connStr);
            cmbBEmployee = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

            dvgEmployee.DataSource = dsFujitsuPayments.Tables["Employee"];
            // resize the datagridview columns to fit the newly loaded content
            dvgEmployee.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            

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
            dvgEmployee.Visible = true;
            frmAdd.Visible = false;
            frmAdd.Location = new Point(2, 25);
        }

        private void btnEmployeeAdd_Click(object sender, EventArgs e)
        {            
            
            frmAdd.TopLevel = false;
            frmAdd.FormBorderStyle = FormBorderStyle.None;
            frmAdd.Visible = true;
            frmAdd.Location = new Point(2, 25);
            this.Controls.Add(frmAdd);
            frmAdd.BringToFront();
            dvgEmployee.Visible = false;
        }
    }
}
