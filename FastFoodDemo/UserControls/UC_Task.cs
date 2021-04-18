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
    public partial class UC_Task : UserControl
    {
        SqlDataAdapter daTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBTask;
        DataRow drTask;
        String connStr, sqlTask;

        public static int selectedTab = 0;
        public static bool tskSelected = false;
        public static int tskNoSelected = 0, prjNoSelected = 0;
        public UC_Task()
        {
            InitializeComponent();
            // style fornt of data grid cell and header
            this.dvgTask.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dvgTask.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);



            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlTask = @"select * from ProjectTask";
            daTask = new SqlDataAdapter(sqlTask, connStr);
            cmbBTask = new SqlCommandBuilder(daTask);
            daTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");
            daTask.Fill(dsFujitsuPayments, "ProjectTask");
            dvgTask.DataSource = dsFujitsuPayments.Tables["ProjectTask"];


            // resize the datagridview columns to fit the newly loaded content
            //dvgProject.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dvgTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTaskAdd_Click(object sender, EventArgs e)
        {
            frmAddTask frm = new frmAddTask();
           
            frm.Location = new Point(180, 100);
            frm.FormBorderStyle = FormBorderStyle.None;
           
            frm.ShowDialog();

        }

        private void btnTaskEdit_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgTask.SelectedRows.Count == 0)
            {
                tskSelected = false;
                tskNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select ProjectTask");
            }
            else if (dvgTask.SelectedRows.Count > 1)
            {
                tskSelected = false;
                tskNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select ProjectTask");

            }

            else if (dvgTask.SelectedRows.Count == 1)
            {
                tskSelected = true;
                tskNoSelected = Convert.ToInt32(dvgTask.SelectedRows[0].Cells[1].Value);
                prjNoSelected = Convert.ToInt32(dvgTask.SelectedRows[0].Cells[0].Value);

                frmEditTask frm = new frmEditTask();
                frm.Location = new Point(180, 100);
                frm.FormBorderStyle = FormBorderStyle.None;

                frm.ShowDialog();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTaskDel_Click(object sender, EventArgs e)
        {
            if (dvgTask.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Project from the list.", "Select ProjectTask");
            }
            else
            {
                object[] primaryKey = new object[2];


                tskNoSelected = Convert.ToInt32(dvgTask.SelectedRows[0].Cells[1].Value);
                prjNoSelected = Convert.ToInt32(dvgTask.SelectedRows[0].Cells[0].Value);


                primaryKey[0] = Convert.ToInt32(prjNoSelected.ToString());
                primaryKey[1] = Convert.ToInt32(tskNoSelected.ToString());
                drTask = dsFujitsuPayments.Tables["ProjectTask"].Rows.Find(primaryKey);

                

                string tempName = drTask["TaskDesc"].ToString();

                if (MessageBox.Show("Are you sure you want to delete Task " + tempName + "?", "Delete Task", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    { 
                    drTask.Delete();
                    daTask.Update(dsFujitsuPayments, "ProjectTask");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Cannot delete a Project Task that has related records, please delete all related records first", "Delete Project Task");
                    }
                    // update grid and clear errors
                    UC_Task_Load(sender, e);
                    drTask.ClearErrors();
                }
            }
        }
        private void UC_Task_Load(object sender, EventArgs e)
        {

           
        }

    }

        
    
}
