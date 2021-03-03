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
