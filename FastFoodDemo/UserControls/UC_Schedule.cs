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
        SqlDataAdapter daShift, daAccount, daProject, daTask, daEmpShift, daEmpShiftDet, daEmp;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBShift, cmbBAccount, cmbBEmpShift, cmbBEmpShiftDet, cmbBEmp;
        SqlCommand cmbProject, cmbTask, cmbEmpShift, cmbEmpShiftDet, cmbEmp;
        DataRow drShift, drEmpShift, drEmpShiftDet, drEmp;
        String connStr, sqlShift, sqlEmp;
        String sqlAccount, sqlProject, sqlTask, sqlEmpShift, sqlEmpShiftDet;

        // Static varibales to pass to form's
        public static bool shiftSelected = false;
        public static int shiftIdSelected = 0, accIdSelected = 0, projIdSelected = 0, taskIdSelected = 0;
        public static int[] selectedShiftIDs = new int[7];
        public static int selectedRow = 0;
        public static bool moreThanOneRow = false;

        // string array for tooltips
        String[] monString = new String[4];
        String[] tueString = new String[4];
        String[] wedString = new String[4];
        String[] thuString = new String[4];
        String[] friString = new String[4];
        String[] satString = new String[4];
        String[] sunString = new String[4];

        public UC_Schedule()
        {
            InitializeComponent();
            
        }

        private void dgvShift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void UC_Schedule_Load(object sender, EventArgs e)
        {

            hidePanels(); 
            // ------------------style fornt of data grid cell and header ----------------------- //
            this.dgvShift.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dgvShift.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            this.calShift.MaxSelectionCount = 1;

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";
            // ---------------- set up adapter for shift data grid view ------------------------ //
            sqlEmpShift = @"SET DATEFIRST 1 -- Define beginning of week as Monday
                        SELECT ShiftID, AccountID, ProjectID, TaskID, StartDate, StartTime, EndTime 
                        FROM EmployeeShift
                        WHERE AccountID like @AccountID
                        And ProjectID like @ProjectID and TaskID like @TaskID
                        And StartDate >= DATEADD(day, 1 - DATEPART(dw, @StartDate), CONVERT(DATE, @StartDate)) 
                        AND StartDate <  DATEADD(day, 8 - DATEPART(dw, @StartDate), CONVERT(DATE, @StartDate))";

            // --- only return shifts were account/project/task match and only records for a week range from the start date
            conn = new SqlConnection(connStr);
            cmbEmpShift = new SqlCommand(sqlEmpShift, conn);
            // add parameters
            cmbEmpShift.Parameters.Add("@AccountID", SqlDbType.Int);
            cmbEmpShift.Parameters.Add("@ProjectID", SqlDbType.Int);
            cmbEmpShift.Parameters.Add("@TaskID", SqlDbType.Int);
            cmbEmpShift.Parameters.Add("@StartDate", SqlDbType.DateTime);
            daEmpShift = new SqlDataAdapter(cmbEmpShift);
            daEmpShift.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShift");

            // -------------setup data adapter for employee details tooltip ------------------------- //
            sqlEmp = @"select * from Employee where EmployeeID = @EmployeeID";
            conn = new SqlConnection(connStr);
            cmbEmp = new SqlCommand(sqlEmp, conn);
            cmbEmp.Parameters.Add("@EmployeeID", SqlDbType.Int);
            daEmp = new SqlDataAdapter(cmbEmp);
            daEmp.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");

            // -------- set up data adpater for employee shift details, to populate panels--------------- //
            sqlEmpShiftDet = @"select * from EmployeeShiftDetails where ShiftID like @ShiftID";
            conn = new SqlConnection(connStr);
            cmbEmpShiftDet = new SqlCommand(sqlEmpShiftDet, conn);      
            cmbEmpShiftDet.Parameters.Add("@ShiftID", SqlDbType.Int);
            daEmpShiftDet = new SqlDataAdapter(cmbEmpShiftDet);
            daEmpShiftDet.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShiftDetails");

            // -------- set up data adapter for project ID drop down
            sqlProject = @"Select ProjectID, ProjDesc, AccountID from Project where AccountID like @AccountID";
            conn = new SqlConnection(connStr);
            cmbProject = new SqlCommand(sqlProject, conn);
            cmbProject.Parameters.Add("@AccountID", SqlDbType.Int);
            daProject = new SqlDataAdapter(cmbProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");

            // ----------set up data adapter for Task ID drop down
            sqlTask = @"Select ProjectID, TaskDesc, TaskID from ProjectTask where ProjectID like @ProjectID";
            conn = new SqlConnection(connStr);
            cmbTask = new SqlCommand(sqlTask, conn);
            cmbTask.Parameters.Add("@ProjectID", SqlDbType.Int);
            daTask = new SqlDataAdapter(cmbTask);
            daTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTask");

            sqlShift = @"select * from EmployeeShift";
            daShift = new SqlDataAdapter(sqlShift, connStr);
            cmbBShift = new SqlCommandBuilder(daShift);
            daShift.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShift2");
            daShift.Fill(dsFujitsuPayments, "EmployeeShift2");

            // -- basic adapater for account
            sqlAccount = @"select * from Account";
            daAccount = new SqlDataAdapter(sqlAccount, connStr);
            cmbBAccount = new SqlCommandBuilder(daAccount);
            daAccount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daAccount.Fill(dsFujitsuPayments, "Account");

           // dgvShift.DataSource = dsFujitsuPayments.Tables["EmployeeShift"];
            // resize the datagridview columns to fit the newly loaded content
            
            // ------- populate account ID combo box
            cmbAccountId.DataSource = dsFujitsuPayments.Tables["Account"];
            cmbAccountId.ValueMember = "AccountID";
            cmbAccountId.DisplayMember = "ClientName";

            cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
            cmbProjectId.ValueMember = "ProjectID";
            cmbProjectId.DisplayMember = "ProjDesc";

            cmbTaskId.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
            cmbTaskId.ValueMember = "TaskID";
            cmbTaskId.DisplayMember = "TaskDesc";            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
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
               // shiftSelected = false;
               // shiftIdSelected = 0;
               // MessageBox.Show("Please select a single record, cannot assign multiple shifts", "Select Shift");

                shiftSelected = true;
                moreThanOneRow = true;
                selectedRow = 0;

                foreach (DataGridViewRow row in dgvShift.SelectedRows)
                {
                    selectedShiftIDs[selectedRow] = Convert.ToInt32(dgvShift.SelectedRows[selectedRow].Cells[0].Value);
                    MessageBox.Show("ShiftID: " + selectedShiftIDs[selectedRow].ToString() + "Selected Row: " + selectedRow);
                    selectedRow = selectedRow + 1;
                }
                //shiftIdSelected = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[0].Value);
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
            else if (dgvShift.SelectedRows.Count == 1)
            {
                shiftSelected = true;
                moreThanOneRow = false;

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

            btnSearchShifts_Click(sender, e);
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

        private void cmbAccountId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountId.Focused == true)
            {
                // clear data set
                dsFujitsuPayments.Tables["Project"].Clear();
                // pass in account ID from combo box
                cmbProject.Parameters["@AccountID"].Value = cmbAccountId.SelectedValue;
                try
                {
                    // fill data adapter with returned values
                    daProject.Fill(dsFujitsuPayments, "Project");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex);
                }
                cmbProjectId.DataSource = dsFujitsuPayments.Tables["Project"];
                cmbProjectId.ValueMember = "ProjectID";
                cmbProjectId.DisplayMember = "ProjDesc";
                if (cmbProjectId.Focused == true)
                {
                    dsFujitsuPayments.Tables["ProjectTask"].Clear();
                    cmbTask.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue;
                    try
                    {
                        daTask.Fill(dsFujitsuPayments, "ProjectTask");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message " + ex);
                    }
                    cmbTaskId.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
                    cmbTaskId.ValueMember = "TaskID";
                    cmbTaskId.DisplayMember = "TaskDesc";
                }
                else
                {

                }
            }
            else
            {

            }
        }



        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjectId.Focused == true)
            {
                dsFujitsuPayments.Tables["ProjectTask"].Clear();
                cmbTask.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue;
                try
                {
                    daTask.Fill(dsFujitsuPayments, "ProjectTask");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message " + ex);
                }
                cmbTaskId.DataSource = dsFujitsuPayments.Tables["ProjectTask"];
                cmbTaskId.ValueMember = "TaskID";
                cmbTaskId.DisplayMember = "TaskDesc";
            }
            else
            {

            }
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
            StringBuilder errorMessages = new StringBuilder();
            if (dgvShift.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Shift from the list.", "Select Shift");
            }
            else if(dgvShift.SelectedRows.Count == 1)
            {
                drShift = dsFujitsuPayments.Tables["EmployeeShift"].Rows.Find(dgvShift.SelectedRows[0].Cells[0].Value);
                string tempName = drShift["ShiftID"].ToString() + "\'s";
                if (MessageBox.Show("Are you sure you want to delete " + tempName + "details?", "Add Shift", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        drShift.Delete();
                        daShift.Update(dsFujitsuPayments, "EmployeeShift");
                    }
                    catch(SqlException sqlex)
                    {
                        for (int i = 0; i < sqlex.Errors.Count; i++)
                        {                          
                                errorMessages.Append("Index #" + i + "\n" +
                                "Message: " + sqlex.Errors[i].Message + "\n" +
                                "LineNumber: " + sqlex.Errors[i].LineNumber + "\n" +
                                "Source: " + sqlex.Errors[i].Source + "\n" +
                                "Procedure: " + sqlex.Errors[i].Procedure + "\n");
                        }
                        MessageBox.Show(errorMessages.ToString());
                    }
                    
                }
            }
            else if(dgvShift.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please select a single shift.", "Select Shift");
            }
        }



        public static int calLocYAxis(String startTime)
        {
            //MessageBox.Show("start time: " + startTime);

            string[] splitTime = startTime.Split(':');
            String stHr = Convert.ToString(startTime[1]);
            String stMin = Convert.ToString(startTime[0]);
            int hr = Convert.ToInt32(stHr);
            int min = Convert.ToInt32(stMin);           
            //MessageBox.Show("hr: " + hr + "min: " + min);
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
            //MessageBox.Show("new min: " + newMin);

            int yAxis = (hr*80) + newMin;
            //MessageBox.Show("YAxis Value = : " + yAxis);

            return yAxis; // returns y axis value to position panel
        }


        public static int calSizeHeight(string startTime, string endTime)
        {
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", ":" };
            foreach (var c in charsToRemove)
            {
                startTime = startTime.Replace(c, string.Empty);
               // startTime.Remove(4, 2);
            }
            foreach (var c in charsToRemove)
            {
                endTime = endTime.Replace(c, string.Empty);
               // endTime.Remove(4,2);
            }
            int st = Convert.ToInt32(startTime) / 100;
            int et = Convert.ToInt32(endTime) / 100;
            //MessageBox.Show("Starttime: " + st + "endtime: " + et);
            int height = ((et - st)/20)*4*4 ;

            return height;
        }


        private void btnSearchShifts_Click(object sender, EventArgs e)
        {
            hidePanels();
            // declare array of panels to convert panels on form for for each loop
            Panel[] monArray = new Panel[] { pnlMonShift1, pnlMonShift2, pnlMonShift3, pnlMonShift4 };
            Panel[] tueArray = new Panel[] { pnlTueShift1, pnlTueShift2, pnlTueShift3, pnlTueShift4 };
            Panel[] wedArray = new Panel[] { pnlWedShift1, pnlWedShift2, pnlWedShift3, pnlWedShift4 };
            Panel[] thuArray = new Panel[] { pnlThuShift1, pnlThuShift2, pnlThuShift3, pnlThuShift4 };
            Panel[] friArray = new Panel[] { pnlFriShift1, pnlFriShift2, pnlFriShift3, pnlFriShift4 };
            Panel[] satArray = new Panel[] { pnlSatShift1, pnlSatShift2, pnlSatShift3, pnlSatShift4 };
            Panel[] sunArray = new Panel[] { pnlSunShift1, pnlSunShift2, pnlSunShift3, pnlSunShift4 };

            dsFujitsuPayments.Tables["EmployeeShift"].Clear();         

            if(calShift.SelectionRange == null || cmbAccountId.SelectedIndex < 0 || cmbProjectId.SelectedIndex < 0 || cmbTaskId.SelectedIndex < 0)
            {
                MessageBox.Show("Please select all required values");
            }
            else
            {
                // set parameters from combobox for query
                cmbEmpShift.Parameters["@AccountID"].Value = cmbAccountId.SelectedValue;
                cmbEmpShift.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue;
                cmbEmpShift.Parameters["@TaskID"].Value = cmbTaskId.SelectedValue;
                cmbEmpShift.Parameters["@StartDate"].Value = calShift.SelectionRange.Start.ToString();
                daEmpShift.Fill(dsFujitsuPayments, "EmployeeShift");

                dgvShift.DataSource = dsFujitsuPayments.Tables["EmployeeShift"];
                dgvShift.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                foreach (DataRow dr in dsFujitsuPayments.Tables["EmployeeShift"].Rows)
                {
                    // variables used to increment array of panels
                    int mon = 0, tue = 0, wed = 0, thu = 0, fri = 0, sat = 0, sun = 0;
                    // clear out data for new query
                    dsFujitsuPayments.Tables["EmployeeShiftDetails"].Clear();

                    // get date time from data row, extract day of week and set it to a string variable, used for switch
                    DateTime dateValue = Convert.ToDateTime(dr["StartDate"].ToString());
                    String dayOfWeek = dateValue.DayOfWeek.ToString();

                    // use shiftID to pass to employee shift details query
                    cmbEmpShiftDet.Parameters["@ShiftID"].Value = dr["ShiftID"].ToString();
                    daEmpShiftDet.Fill(dsFujitsuPayments, "EmployeeShiftDetails");
                    //MessageBox.Show("Day of week: " + dayOfWeek);
                    foreach (DataRow dr1 in dsFujitsuPayments.Tables["EmployeeShiftDetails"].Rows)
                    {                  
                        switch (dayOfWeek)
                        {
                            case "Monday":
                                monArray[mon].Visible = true;
                                monArray[mon].Top = calLocYAxis(dr["StartTime"].ToString());
                                monArray[mon].Height = calSizeHeight(dr["StartTime"].ToString(), dr["EndTime"].ToString());
                                cmbEmp.Parameters["@EmployeeID"].Value = dr1["EmployeeID"].ToString();
                                daEmp.Fill(dsFujitsuPayments, "Employee");
                                drEmp = dsFujitsuPayments.Tables["Employee"].Rows.Find(dr1["EmployeeID"].ToString());
                                monString[mon] = drEmp["Forename"].ToString() + " " +  drEmp["Surname"].ToString();
                                mon = mon + 1;
                                break;
                            case "Tuesday":
                                //yAxis = calLocYAxis(dr["StartTime"].ToString());
                                //height = calSizeHeight(dr["StartTime"].ToString(), dr["EndTime"].ToString());
                                tueArray[tue].Visible = true;
                                tueArray[tue].Top = calLocYAxis(dr["StartTime"].ToString());
                                tueArray[tue].Height = calSizeHeight(dr["StartTime"].ToString(), dr["EndTime"].ToString());
                                cmbEmp.Parameters["@EmployeeID"].Value = dr1["EmployeeID"].ToString();
                                daEmp.Fill(dsFujitsuPayments, "Employee");
                                drEmp = dsFujitsuPayments.Tables["Employee"].Rows.Find(dr1["EmployeeID"].ToString());
                                tueString[tue] = drEmp["Forename"].ToString() + " " + drEmp["Surname"].ToString();                               
                                tue = tue + 1;
                                break;
                            case "Wednesday":
                                wedArray[wed].Visible = true;
                                wedArray[wed].Top = calLocYAxis(dr["StartTime"].ToString());
                                wedArray[wed].Height = calSizeHeight(dr["StartTime"].ToString(), dr["EndTime"].ToString());
                                cmbEmp.Parameters["@EmployeeID"].Value = dr1["EmployeeID"].ToString();
                                daEmp.Fill(dsFujitsuPayments, "Employee");
                                drEmp = dsFujitsuPayments.Tables["Employee"].Rows.Find(dr1["EmployeeID"].ToString());
                                wedString[wed] = drEmp["Forename"].ToString() + " " + drEmp["Surname"].ToString();
                                wed = wed + 1;
                                break;
                            case "Thursday":
                                thuArray[thu].Visible = true;
                                thuArray[thu].Top = calLocYAxis(dr["StartTime"].ToString());
                                thuArray[thu].Height = calSizeHeight(dr["StartTime"].ToString(), dr["EndTime"].ToString());
                                cmbEmp.Parameters["@EmployeeID"].Value = dr1["EmployeeID"].ToString();
                                daEmp.Fill(dsFujitsuPayments, "Employee");
                                drEmp = dsFujitsuPayments.Tables["Employee"].Rows.Find(dr1["EmployeeID"].ToString());
                                thuString[thu] = drEmp["Forename"].ToString() + " " + drEmp["Surname"].ToString();
                                thu = thu + 1;
                                break;
                            case "Friday":
                                friArray[fri].Visible = true;
                                friArray[fri].Top = calLocYAxis(dr["StartTime"].ToString());
                                friArray[fri].Height = calSizeHeight(dr["StartTime"].ToString(), dr["EndTime"].ToString());
                                cmbEmp.Parameters["@EmployeeID"].Value = dr1["EmployeeID"].ToString();
                                daEmp.Fill(dsFujitsuPayments, "Employee");
                                drEmp = dsFujitsuPayments.Tables["Employee"].Rows.Find(dr1["EmployeeID"].ToString());
                                friString[fri] = drEmp["Forename"].ToString() + " " + drEmp["Surname"].ToString();
                                fri = fri + 1; 
                                break;
                            case "Saturday":
                                satArray[sat].Visible = true;
                                satArray[sat].Top = calLocYAxis(dr["StartTime"].ToString());
                                satArray[sat].Height = calSizeHeight(dr["StartTime"].ToString(), dr["EndTime"].ToString());
                                cmbEmp.Parameters["@EmployeeID"].Value = dr1["EmployeeID"].ToString();
                                daEmp.Fill(dsFujitsuPayments, "Employee");
                                drEmp = dsFujitsuPayments.Tables["Employee"].Rows.Find(dr1["EmployeeID"].ToString());
                                satString[sat] = drEmp["Forename"].ToString() + " " + drEmp["Surname"].ToString();  
                                sat = sat + 1;
                                break;
                            case "Sunday":
                                sunArray[sun].Visible = true;
                                sunArray[sun].Top = calLocYAxis(dr["StartTime"].ToString());
                                sunArray[sun].Height = calSizeHeight(dr["StartTime"].ToString(), dr["EndTime"].ToString());
                                cmbEmp.Parameters["@EmployeeID"].Value = dr1["EmployeeID"].ToString();
                                daEmp.Fill(dsFujitsuPayments, "Employee");
                                drEmp = dsFujitsuPayments.Tables["Employee"].Rows.Find(dr1["EmployeeID"].ToString());
                                sunString[sun] = drEmp["Forename"].ToString() + " " + drEmp["Surname"].ToString();
                                sun = sun + 1;
                                break;                               
                        }
                    }
                }
            }
        }


        private void DataGridSelectionChanged(object sender, EventArgs e)
        {
            if (dgvShift.Focused == true)
            {
                if (dgvShift.SelectedRows[0].Cells[0].Value == null)
                {
                    MessageBox.Show("Please select a row that contains data.");
                }
                else
                {
                    drEmpShift = dsFujitsuPayments.Tables["EmployeeShift"].Rows.Find(dgvShift.SelectedRows[0].Cells[0].Value);

                    if (drEmpShift == null)
                    {
                        MessageBox.Show("Please select a row that contains data.");
                    }
                    else
                    {
                        DateTime startDate = Convert.ToDateTime(drEmpShift["StartDate"].ToString());
                        string pnlStartDate = startDate.ToShortDateString();
                        string pnlStartTime = drEmpShift["StartTime"].ToString();
                        string pnlEndTime = drEmpShift["EndTime"].ToString();
                        //MessageBox.Show("Startdate: " + pnlStartDate + "Starttime: " + pnlStartTime.Remove(5,3) + "Endtime: " + pnlEndTime.Remove(5,3));
                    }
                }
            }
        }



        private void refreshShiftGridView()
        {
            dsFujitsuPayments.Tables["EmployeeShift2"].Clear();

            // set parameters
            cmbEmpShift.Parameters["@AccountID"].Value = cmbAccountId.SelectedValue;
            cmbEmpShift.Parameters["@ProjectID"].Value = cmbProjectId.SelectedValue;
            cmbEmpShift.Parameters["@TaskID"].Value = cmbTaskId.SelectedValue;

            daEmpShift.Fill(dsFujitsuPayments, "EmployeeShift2");
            dgvShift.DataSource = dsFujitsuPayments.Tables["EmployeeShift2"];
            dgvShift.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            hidePanels();
        }

        // methods for tooltip

        private void pnlMonShift1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(monString[0].ToString(), pnlMonShift1);
        }

        private void pnlMonShift2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(monString[1].ToString(), pnlMonShift2);
        }

        private void pnlMonShift3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(monString[2].ToString(), pnlMonShift3);
        }

        private void btnAssignShift_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Select shift from table to assign to an Employee", btnAssignShift);
        }

        private void btnViewShifts_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Select to view shifts and employees assigned to those shifts", btnViewShifts);
        }

        private void btnEditShift_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Edit selected shift", btnEditShift);
        }

        private void btnAddShift_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Select to create a new shift", btnAddShift);
        }

        private void btnDeleteShift_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Delete selected shift", btnDeleteShift);
        }

        private void pnlMonShift4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(monString[3].ToString(), pnlMonShift4);
        }

        private void pnlTueShift1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(tueString[0].ToString(), pnlTueShift1);
        }

        private void pnlTueShift2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(tueString[1].ToString(), pnlTueShift2);
        }

        private void pnlTueShift3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(tueString[2].ToString(), pnlTueShift3);
        }

        private void pnlTueShift4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(tueString[3].ToString(), pnlTueShift4);
        }

        private void pnlWedShift1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(wedString[0].ToString(), pnlWedShift1);
        }

        private void pnlWedShift2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(wedString[1].ToString(), pnlWedShift2);
        }

        private void pnlWedShift3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(wedString[2].ToString(), pnlWedShift3);
        }

        private void pnlWedShift4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(wedString[3].ToString(), pnlWedShift4);
        }

        private void pnlThuShift1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(thuString[0].ToString(), pnlThuShift1);
        }

        private void pnlThuShift2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(thuString[1].ToString(), pnlThuShift2);
        }

        private void pnlThuShift3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(thuString[2].ToString(), pnlThuShift3);
        }

        private void pnlThuShift4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(thuString[3].ToString(), pnlThuShift4);
        }

        private void pnlFriShift1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(friString[0].ToString(), pnlFriShift1);
        }

        private void pnlFriShift2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(friString[1].ToString(), pnlFriShift2);
        }

        private void pnlFriShift3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(friString[2].ToString(), pnlFriShift3);
        }

        private void pnlFriShift4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(friString[3].ToString(), pnlFriShift4);
        }

        private void pnlSatShift1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(satString[0].ToString(), pnlSatShift1);
        }

        private void pnlSatShift2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(satString[1].ToString(), pnlSatShift2);
        }

        private void pnlSatShift3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(satString[2].ToString(), pnlSatShift3);
        }

        private void pnlSatShift4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(satString[3].ToString(), pnlSatShift4);
        }

        private void pnlSunShift1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(sunString[0].ToString(), pnlSunShift1);
        }

        private void pnlSunShift2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(sunString[1].ToString(), pnlSunShift2);
        }

        private void pnlSunShift3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(sunString[2].ToString(), pnlSunShift3);
        }

        private void pnlSunShift4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(sunString[3].ToString(), pnlSunShift4);
        }

        private void pnlSunShift3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
