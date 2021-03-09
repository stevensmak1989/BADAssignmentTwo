using FujitsuPayments.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FujitsuPayments.UserControls
{
    public partial class UC_Schedule : UserControl
    {
        SqlDataAdapter daShift;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBShift;
        DataRow drShift;
        String connStr, sqlShift;

        // Static varibales to pass to form's
        public static bool shiftSelected = false;
        public static int shiftIdSelected = 0, accIdSelected = 0, projIdSelected = 0, taskIdSelected = 0; 

        public UC_Schedule()
        {
            InitializeComponent();
            
        }

        private void UC_Schedule_Load(object sender, EventArgs e)
        {
            // style fornt of data grid cell and header
            this.dgvShift.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dgvShift.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            this.calShift.MaxSelectionCount = 1;

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlShift = @"select * from EmployeeShift";
            daShift = new SqlDataAdapter(sqlShift, connStr);
            cmbBShift = new SqlCommandBuilder(daShift);
            daShift.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShift");
            daShift.Fill(dsFujitsuPayments, "EmployeeShift");

            dgvShift.DataSource = dsFujitsuPayments.Tables["EmployeeShift"];
            // resize the datagridview columns to fit the newly loaded content
            dgvShift.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            hidePanels();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            frmAddShift frm = new frmAddShift();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Location = new Point(180, 100);
            this.Controls.Add(frm);
            frm.BringToFront();
        }

        private void btnAssignShift_Click(object sender, EventArgs e)
        {
            if (dgvShift.SelectedRows.Count == 0)
            {
                shiftSelected = false;
                shiftIdSelected = 0;
                MessageBox.Show("Please select a record.", "Select Shift");
            }
            else if (dgvShift.SelectedRows.Count > 1)
            {
                shiftSelected = false;
                shiftIdSelected = 0;
                MessageBox.Show("Please select a single record, cannot assign multiple shifts", "Select Shift");

            }
            else if (dgvShift.SelectedRows.Count == 1)
            {
                shiftSelected = true;
                shiftIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[0].Value);
                accIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[1].Value);
                projIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[2].Value);
                taskIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[3].Value);

                frmAssignShift frm = new frmAssignShift();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Visible = true;
                frm.Location = new Point(180, 100);
                this.Controls.Add(frm);
                frm.BringToFront();
            }

        }

        private void calShift_DateChanged(object sender, DateRangeEventArgs e)
        {
            String dayOfWeek = calShift.SelectionRange.Start.DayOfWeek.ToString();

            switch(dayOfWeek)
            {
                case "Monday":
                    lblMonDate.Text = calShift.SelectionRange.Start.ToShortDateString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(1).ToShortDateString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(2).ToShortDateString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(3).ToShortDateString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(4).ToShortDateString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(5).ToShortDateString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(6).ToShortDateString();
                    break;
                case "Tuesday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-1).ToShortDateString();
                    lblTueDate.Text = calShift.SelectionRange.Start.ToShortDateString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(1).ToShortDateString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(2).ToShortDateString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(3).ToShortDateString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(4).ToShortDateString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(5).ToShortDateString();
                    break;
                case "Wednesday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-2).ToShortDateString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-1).ToShortDateString();
                    lblWedDate.Text = calShift.SelectionRange.Start.ToShortDateString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(1).ToShortDateString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(2).ToShortDateString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(3).ToShortDateString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(4).ToShortDateString();
                    break;
                case "Thursday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-3).ToShortDateString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-2).ToShortDateString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(-1).ToShortDateString();
                    lblThuDate.Text = calShift.SelectionRange.Start.ToShortDateString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(1).ToShortDateString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(2).ToShortDateString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(3).ToShortDateString();
                    break;
                case "Friday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-4).ToShortDateString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-3).ToShortDateString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(-2).ToShortDateString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(-1).ToShortDateString();
                    lblFriDate.Text = calShift.SelectionRange.Start.ToShortDateString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(1).ToShortDateString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(2).ToShortDateString();
                    break;
                case "Saturday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-5).ToShortDateString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-4).ToShortDateString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(-3).ToShortDateString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(-2).ToShortDateString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(-1).ToShortDateString();
                    lblSatDate.Text = calShift.SelectionRange.Start.ToShortDateString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(1).ToShortDateString();
                    break;
                case "Sunday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-6).ToShortDateString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-5).ToShortDateString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(-4).ToShortDateString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(-3).ToShortDateString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(-2).ToShortDateString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(-1).ToShortDateString();
                    lblSunDate.Text = calShift.SelectionRange.Start.ToShortDateString();
                    break;

            }
           
        }



        private void hidePanels()
        {
            pnlMonShift1.Visible = false;
            pnlMonShift2.Visible = false;
            pnlMonShift3.Visible = false;
            pnlMonShift4.Visible = false;
            pnlTueShift1.Visible = false;
            pnlTueShift2.Visible = false;
            pnlTueShift3.Visible = false;
            pnlTueShift4.Visible = false;
            pnlWedShift1.Visible = false;
            pnlWedShift2.Visible = false;
            pnlWedShift3.Visible = false;
            pnlWedShift4.Visible = false;
            pnlThuShift1.Visible = false;
            pnlThuShift2.Visible = false;
            pnlThuShift3.Visible = false;
            pnlThuShift4.Visible = false;
            pnlFriShift1.Visible = false;
            pnlFriShift2.Visible = false;
            pnlFriShift3.Visible = false;
            pnlFriShift4.Visible = false;
            pnlSatShift1.Visible = false;
            pnlSatShift2.Visible = false;
            pnlSatShift3.Visible = false;
            pnlSatShift4.Visible = false;
            pnlSunShift1.Visible = false;
            pnlSunShift2.Visible = false;
            pnlSunShift3.Visible = false;
            pnlSunShift4.Visible = false;
        }

        private void btnViewShifts_Click(object sender, EventArgs e)
        {

            frmViewShifts frm = new frmViewShifts();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Location = new Point(100, 100);
            this.Controls.Add(frm);
            frm.BringToFront();
        }

        private void btnEditShift_Click(object sender, EventArgs e)
        {
            if (dgvShift.SelectedRows.Count == 0)
            {
                shiftSelected = false;
                shiftIdSelected = 0;
                MessageBox.Show("Please select a record.", "Select Shift");
            }
            else if (dgvShift.SelectedRows.Count > 1)
            {
                shiftSelected = false;
                shiftIdSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select Account");

            }
            else if (dgvShift.SelectedRows.Count == 1)
            {
                shiftSelected = true;
                shiftIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[0].Value);
                accIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[1].Value);
                projIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[2].Value);
                taskIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[3].Value);

                frmEditShift frm = new frmEditShift();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Visible = true;
                frm.Location = new Point(180, 100);
                this.Controls.Add(frm);
                frm.BringToFront();
            }
        }

        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            if (dgvShift.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Shift from the list.", "Select Shift");
            }
            else
            {
                drShift = dsFujitsuPayments.Tables["EmployeeShift"].Rows.Find(dgvShift.SelectedRows[0].Cells[0].Value);

                string tempName = drShift["ShiftID"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete " + tempName + "details?", "Add Shift", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drShift.Delete();
                    daShift.Update(dsFujitsuPayments, "EmployeeShift");
                }
            }
        }



        public static int calLocYAxis(String startTime)
        {
            // var charsToRemove = new string[] { "@", ",", ".", ";", "'", ":" };
            // foreach (var c in charsToRemove)
            // {
            //     startTime = startTime.Replace(c, string.Empty);
            // }
            // start time as a whole integer

            string[] splitTime = startTime.Split(':');
            int hr = Convert.ToInt32(startTime[0]);
            int min = Convert.ToInt32(startTime[1]);
            int newMin = 0; ;

            if(min == 15)
            {
                newMin = 20;
            }
            else if(min == 30)
            {
                newMin = 40;
            }
            else if(min == 45)
            {
                newMin = 60;
            }

            return (hr*80) + newMin; // returns y axis value to position panel
        }


        public static int calSizeHeight(string startTime, string endTime)
        {
  
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", ":" };
            foreach (var c in charsToRemove)
            {
                startTime = startTime.Replace(c, string.Empty);
            }
            foreach (var c in charsToRemove)
            {
                endTime = endTime.Replace(c, string.Empty);
            }
            int st = Convert.ToInt32(startTime);
            int et = Convert.ToInt32(endTime);

            return (((et - st)-100) * 20);
        }
    }

}
