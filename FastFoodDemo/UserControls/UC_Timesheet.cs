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
    public partial class UC_Timesheet : UserControl
    {
        //variables used for sql 
        SqlDataAdapter daTime;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBTime;
        String connStr, sqlTime;
        public static int selectedTab = 0;
        public static bool timeSelected = false, buttons = false;
        public static int timeNoSelected = 0;

       

        public UC_Timesheet()
        {
            InitializeComponent();
           
        }

        //called when the add button is selected
        private void btnAddTimesheet_Click(object sender, EventArgs e)
        {
            //initialises the add form
            frmAddTimesheet frm = new frmAddTimesheet();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(135, 109);
            frm.ShowDialog();
           
        }
        //runs on load
        private void UC_Timesheet_Load(object sender, EventArgs e)
        {
            this.dvgTimesheetDets.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dvgTimesheetDets.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);

            //gets timesheet data

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlTime = @"select * from Timesheet";
            daTime = new SqlDataAdapter(sqlTime, connStr);
            cmbBTime = new SqlCommandBuilder(daTime);
            daTime.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheet");
            daTime.Fill(dsFujitsuPayments, "Timesheet");

            //adds timesheet data to the dataview
            dvgTimesheetDets.DataSource = dsFujitsuPayments.Tables["Timesheet"];
            // resize the datagridview columns to fit the newly loaded content
            //dvgProject.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void btnTimesheetEdit_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgTimesheetDets.SelectedRows.Count == 0)
            {
                timeSelected = false;
                timeNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select ProjectTask");
            }
            //checks if more than one record is seleceted
            else if (dvgTimesheetDets.SelectedRows.Count > 1)
            {
                timeSelected = false;
                timeNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select ProjectTask");

            }
            //
            else if (dvgTimesheetDets.SelectedRows.Count == 1)
            {
                //gets the timesheet id
                timeSelected = true;
                timeNoSelected = Convert.ToInt32(dvgTimesheetDets.SelectedRows[0].Cells[0].Value);

                //initialises the edit form

                frmEditTimesheet frm = new frmEditTimesheet();
                frm.FormBorderStyle = FormBorderStyle.None;

                frm.Location = new Point(135, 109);

                frm.ShowDialog();

            }

        }

        

        private void btnTaskDel_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgTimesheetDets.SelectedRows.Count == 0)
            {
                timeSelected = false;
                timeNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select Timesheet");
            }
            //checks if more than one record is selected
            else if (dvgTimesheetDets.SelectedRows.Count > 1)
            {
                timeSelected = false;
                timeNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select Timesheet");

            }

            else if (dvgTimesheetDets.SelectedRows.Count == 1)
            {
                //runs the delete form
                timeSelected = true;
                timeNoSelected = Convert.ToInt32(dvgTimesheetDets.SelectedRows[0].Cells[0].Value);
             
               
                frmDeleteTimesheet frm = new frmDeleteTimesheet();
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Location = new Point(135, 109);
                frm.ShowDialog();


            }
        }

     
    }
}
