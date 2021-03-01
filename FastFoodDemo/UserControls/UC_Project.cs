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
    public partial class UC_Project : UserControl
    {
        SqlDataAdapter daProject;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject;
        DataRow drProject;
        String connStr, sqlProject;

        public static int selectedTab = 0;
        public static bool prjSelected = false;
        public static int prjNoSelected = 0;
        private void UC_Project_Load(object sender, EventArgs e)
        {
            
        }


        public UC_Project()
        {

            InitializeComponent();
            // style fornt of data grid cell and header
            this.dvgProject.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dvgProject.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);



            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlProject = @"select * from Project";
            daProject = new SqlDataAdapter(sqlProject, connStr);
            cmbBProject = new SqlCommandBuilder(daProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");
            daProject.Fill(dsFujitsuPayments, "Project");

            dvgProject.DataSource = dsFujitsuPayments.Tables["Project"];
            // resize the datagridview columns to fit the newly loaded content
            //dvgProject.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProjectAdd_Click(object sender, EventArgs e)
        {
            frmAddProject frm = new frmAddProject();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Location = new Point(180, 100);
            this.Controls.Add(frm);
            frm.BringToFront();
        }

        private void dvgProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnProjectEdit_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgProject.SelectedRows.Count == 0)
            {
                prjSelected = false;
                prjNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select Project");
            }
            else if (dvgProject.SelectedRows.Count > 1)
            {
                prjSelected = false;
                prjNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select Project");

            }
            else if (dvgProject.SelectedRows.Count == 1)
            {
                prjSelected = true;
                prjNoSelected = Convert.ToInt32(dvgProject.SelectedRows[0].Cells[0].Value);

                frmEditEmployee frm = new frmEditEmployee();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Visible = true;
                frm.Location = new Point(2, 25);
                this.Controls.Add(frm);
                frm.BringToFront();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
