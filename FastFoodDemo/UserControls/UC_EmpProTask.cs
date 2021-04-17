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
    public partial class UC_EmpProTask : UserControl
    {
        SqlDataAdapter daEmpTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBempTask;
        DataRow drEmpTask;
        String connStr, sqlEmpTask;

        public static int selectedTab = 0;
        public static bool tskSelected = false;
        public static int tskNoSelected = 0, prjNoSelected = 0, empNoSelected =0;

        private void btnEmpTaskDel_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpTaskEdit_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgEmpTask.SelectedRows.Count == 0)
            {
                tskSelected = false;
                tskNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select ProjectTask");
            }
            else if (dvgEmpTask.SelectedRows.Count > 1)
            {
                tskSelected = false;
                tskNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select ProjectTask");

            }

            else if (dvgEmpTask.SelectedRows.Count == 1)
            {
                tskSelected = true;
                tskNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[1].Value);
                prjNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[0].Value);
                empNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[2].Value);
                frmEditEmpTask frm = new frmEditEmpTask();
                frm.Location = new Point(180, 100);
                frm.FormBorderStyle = FormBorderStyle.None;

                frm.ShowDialog();
            }
        }

        private void dvgEmpTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public UC_EmpProTask()
        {
            InitializeComponent();
            this.dvgEmpTask.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dvgEmpTask.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);



            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlEmpTask = @"select * from ProjectTaskEmployee";
            daEmpTask = new SqlDataAdapter(sqlEmpTask, connStr);
            cmbBempTask = new SqlCommandBuilder(daEmpTask);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");
            daEmpTask.Fill(dsFujitsuPayments, "ProjectTaskEmployee");

            dvgEmpTask.DataSource = dsFujitsuPayments.Tables["ProjectTaskEmployee"];
            // resize the datagridview columns to fit the newly loaded content
            //dvgProject.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnEmpTaskAdd_Click(object sender, EventArgs e)
        {
            frmEmpTaskAdd frm = new frmEmpTaskAdd();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Location = new Point(180, 100);
            this.Controls.Add(frm);
            frm.BringToFront();
        }
    }
}
