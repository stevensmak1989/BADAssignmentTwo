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
                    lblMonDate.Text = calShift.SelectionRange.Start.Day.ToString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(1).Day.ToString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(2).Day.ToString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(3).Day.ToString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(4).Day.ToString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(5).Day.ToString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(6).Day.ToString();
                    break;
                case "Tuesday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-1).Day.ToString();
                    lblTueDate.Text = calShift.SelectionRange.Start.Day.ToString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(1).Day.ToString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(2).Day.ToString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(3).Day.ToString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(4).Day.ToString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(5).Day.ToString();
                    break;
                case "Wednesday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-2).Day.ToString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-1).Day.ToString();
                    lblWedDate.Text = calShift.SelectionRange.Start.Day.ToString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(1).Day.ToString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(2).Day.ToString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(3).Day.ToString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(4).Day.ToString();
                    break;
                case "Thursday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-3).Day.ToString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-2).Day.ToString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(-1).Day.ToString();
                    lblThuDate.Text = calShift.SelectionRange.Start.Day.ToString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(1).Day.ToString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(2).Day.ToString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(3).Day.ToString();
                    break;
                case "Friday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-4).Day.ToString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-3).Day.ToString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(-2).Day.ToString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(-1).Day.ToString();
                    lblFriDate.Text = calShift.SelectionRange.Start.Day.ToString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(1).Day.ToString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(2).Day.ToString();
                    break;
                case "Saturday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-5).Day.ToString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-4).Day.ToString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(-3).Day.ToString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(-2).Day.ToString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(-1).Day.ToString();
                    lblSatDate.Text = calShift.SelectionRange.Start.Day.ToString();
                    lblSunDate.Text = calShift.SelectionRange.Start.AddDays(1).Day.ToString();
                    break;
                case "Sunday":
                    lblMonDate.Text = calShift.SelectionRange.Start.AddDays(-6).Day.ToString();
                    lblTueDate.Text = calShift.SelectionRange.Start.AddDays(-5).Day.ToString();
                    lblWedDate.Text = calShift.SelectionRange.Start.AddDays(-4).Day.ToString();
                    lblThuDate.Text = calShift.SelectionRange.Start.AddDays(-3).Day.ToString();
                    lblFriDate.Text = calShift.SelectionRange.Start.AddDays(-2).Day.ToString();
                    lblSatDate.Text = calShift.SelectionRange.Start.AddDays(-1).Day.ToString();
                    lblSunDate.Text = calShift.SelectionRange.Start.Day.ToString();
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



        private void calLocYAxis()
        {

        }


        private void calSizeHeight()
        {

        }
    }

}
