using FujitsuPayments.UserControls;
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

namespace FujitsuPayments.Forms
{
    public partial class frmEditTimesheet : Form
    {
        SqlDataAdapter daProject, daTask, daEmployee, daEmpTask, daClaim, daTime, daMan, daTimesheet, daTimeDets, daCost;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBClaim, cmbBMan, cmbBTask, cmbBEmp, cmbBEmpTask, cmbBTime, cmbBTimesheet, cmbBTimeDets, cmbBCost;

      
        SqlCommand cmdEmp, cmdMan, cmdProj;

        DataRow drProject, drMan, drTask, drClaim, drEmp, drEmpTask, drTimesheet, drTimeDets, drCost;
        String connStr, sqlProject, sqlTask, sqlEmp, sqlEmpTask, sqlClaim, sqlMan, sqlTime, sqlTimesheet, sqlTimeDets, sqlCost;
        SqlConnection conn;
        string projectId, taskID;
        private double count;
        private int numb, timesheetValue;

        public frmEditTimesheet()
        {
            InitializeComponent();
        } 
        private void cmbClaimType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int claim = Convert.ToInt32(cmbClaimType.SelectedValue);
            setData(claim,timesheetValue );
        }


        private void frmEditTimesheet_Load(object sender, EventArgs e)
        {
            setDates(0);
            findMondays();

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlClaim = @"select * from ClaimType";
            daClaim = new SqlDataAdapter(sqlClaim, connStr);
            cmbBClaim = new SqlCommandBuilder(daClaim);
            daClaim.FillSchema(dsFujitsuPayments, SchemaType.Source, "ClaimType");
            daClaim.Fill(dsFujitsuPayments, "ClaimType");

            sqlEmp = @"select EmployeeID, Surname + ' ' + Forename as EmpName from Employee";
            daEmployee = new SqlDataAdapter(sqlEmp, connStr);
            cmbBEmp = new SqlCommandBuilder(daEmployee);
            daEmployee.FillSchema(dsFujitsuPayments, SchemaType.Source, "Employee");
            daEmployee.Fill(dsFujitsuPayments, "Employee");

            sqlTimesheet = @"select * from Timesheet";
            daTimesheet = new SqlDataAdapter(sqlTimesheet, connStr);
            cmbBTimesheet = new SqlCommandBuilder(daTimesheet);
            daTimesheet.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheet");
            daTimesheet.Fill(dsFujitsuPayments, "Timesheet");

            sqlTimeDets = @"select * from TimesheetDetails";
            daTimeDets = new SqlDataAdapter(sqlTimeDets, connStr);
            cmbBTimeDets = new SqlCommandBuilder(daTimeDets);
            daTimeDets.FillSchema(dsFujitsuPayments, SchemaType.Source, "TimesheetDetails");
            daTimeDets.Fill(dsFujitsuPayments, "TimesheetDetails");




            sqlMan = @"Select  EmployeeID, Surname + ' ' + Forename as EmpName from Employee where Manager = 1";
            daMan = new SqlDataAdapter(sqlMan, connStr);
            daMan.Fill(dsFujitsuPayments, "Manager");


            foreach (DataRow dr in dsFujitsuPayments.Tables["Manager"].Rows)
            {
                // Console.WriteLine(dr["Manager"].ToString());


                cmbApprovedBy.DataSource = dsFujitsuPayments.Tables["Manager"];
                cmbApprovedBy.ValueMember = "EmployeeID";
                cmbApprovedBy.DisplayMember = "EmpName";

            }

            sqlCost = @"select CostCentreID, CostCentreDesc  from CostCentre";
            daCost = new SqlDataAdapter(sqlCost, connStr);
            cmbBCost = new SqlCommandBuilder(daCost);
            daCost.FillSchema(dsFujitsuPayments, SchemaType.Source, "CostCentre");
            daCost.Fill(dsFujitsuPayments, "CostCentre");

            cmbEmployee.DataSource = dsFujitsuPayments.Tables["Employee"];
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.DisplayMember = "EmpName";

            cmbCostCentID.DataSource = dsFujitsuPayments.Tables["CostCentre"];
            cmbCostCentID.ValueMember = "CostCentreID";
            cmbCostCentID.DisplayMember = "CostCentreDesc";


            cmbClaimType.DataSource = dsFujitsuPayments.Tables["ClaimType"];
            cmbClaimType.ValueMember = "ClaimTypeID";
            cmbClaimType.DisplayMember = "ClaimTypeDesc";



            sqlEmpTask = @"select ProjectID , TaskID , EmployeeID from ProjectTaskEmployee where EmployeeID like @EmployeeID";
            conn = new SqlConnection(connStr);
            cmdEmp = new SqlCommand(sqlEmpTask, conn);
            cmdEmp.Parameters.Add("@EmployeeID", SqlDbType.Int);
            daEmpTask = new SqlDataAdapter(cmdEmp);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");

            sqlEmpTask = @"select ProjectID, TaskID, EmployeeID from ProjectTaskEmployee where EmployeeID like @EmployeeID";
            conn = new SqlConnection(connStr);
            cmdEmp = new SqlCommand(sqlEmpTask, conn);
            cmdEmp.Parameters.Add("@EmployeeID", SqlDbType.Int);
            daEmpTask = new SqlDataAdapter(cmdEmp);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");

            string timeDets = UC_Timesheet.timeNoSelected.ToString();
            timesheetValue = Convert.ToInt32(timeDets);
            drClaim = dsFujitsuPayments.Tables["Timesheet"].Rows.Find(timeDets);



            //int claim = Convert.ToInt32(drClaim["ClaimTypeID"].ToString());
            setData(2, Convert.ToInt32(timeDets));

            //MessageBox.Show(drClaim["EmployeeID"].ToString());
            //int noRows = dsFujitsuPayments.Tables["Timesheet"].Rows.Count;

            //if (noRows == 0)
            //    lblTimsheetId.Text = "1000";
            //else
            //{
            //    getNumber(noRows);
            //}

        }

        private void findMondays()
        {
            DateTime mon = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday));
            var date = mon.Date;
            DateTime[] startDate = new DateTime[7];
            int count = 0;


            for (int i = 0; i < 7; i++)
            {

                startDate[i] = date.AddDays(count);
                count += 7;
            }

            for (int i = 0; i < 7; i++)
            {
                cmbDates.Items.Add(startDate[i].ToString());

            }
        }

        private void setData(int claimtype, int timesheetID)
        {
            TextBox[] start = { txtStart7, txtStart1, txtStart2, txtStart3, txtStart4, txtStart5, txtStart6  };
            TextBox[] end = { txtEnd7,txtEnd1, txtEnd2, txtEnd3, txtEnd4, txtEnd5, txtEnd6 };
            ComboBox[] task = { cmbEmpTask7, cmbEmpTask, cmbEmpTask2, cmbEmpTask3, cmbEmpTask4, cmbEmpTask5, cmbEmpTask6 };
            ComboBox[] project = { cmbProject7, cmbProject, cmbProject2, cmbProject3, cmbProject4, cmbProject5, cmbProject6 };
            Label[] date = { lblDateSun, lblDateMon, lblDateTue, lblDateWed, lblDateThur, lblDateFri, lblDateSat };

            sqlProject = @"Select  * from TimesheetDetails where TimesheetID = @Timesheet AND ClaimTypeID = @ClaimType";
            conn = new SqlConnection(connStr);
            cmdProj = new SqlCommand(sqlProject, conn);
            cmdProj.Parameters.Add("@Timesheet", SqlDbType.Int);
            cmdProj.Parameters.Add("@ClaimType", SqlDbType.Int);
            daProject = new SqlDataAdapter(cmdProj);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets");

            cmdProj.Parameters["@Timesheet"].Value = timesheetID;
            cmdProj.Parameters["@ClaimType"].Value = claimtype;

            daProject.Fill(dsFujitsuPayments, "Timesheets");

            DataTable dt = dsFujitsuPayments.Tables["Timesheets"];

            foreach (DataRow row in dt.Rows)
            {

                numb++;

            }
            int x = 0;
            DateTime[] rowArray = new DateTime[numb];
            TimeSpan[] startTime = new TimeSpan[numb];
            TimeSpan[] endTime = new TimeSpan[numb];
            int[] proj = new int[numb];
            int[] tasks = new int[numb];


            foreach (DataRow row in dt.Rows )
            {
                rowArray[x] = row.Field<DateTime>("WorkedDay");
                startTime[x] = row.Field<TimeSpan>("StartTime");
                endTime[x] = row.Field<TimeSpan>("EndTime");
                proj[x] = row.Field<int>("ProjectID");
                tasks[x] = row.Field<int>("TaskID");

                x++;
            }

            for(int i =0; i < numb; i++)
            {
                int day = (int)rowArray[i].DayOfWeek;

                start[day].Text = startTime[i].ToString();
                end[day].Text = endTime[i].ToString();
                date[day].Text = rowArray[i].ToShortDateString();


            }
        }


        private void setDates(int count)
        {

            DateTime start = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday));
            var date = start.Date;
            DateTime mon = date.AddDays(count).Date;
            lblDateMon.Text = mon.ToShortDateString();
            DateTime tue = mon.AddDays(1).Date;
            lblDateTue.Text = tue.ToShortDateString();
            DateTime wed = tue.AddDays(1).Date;
            lblDateWed.Text = wed.ToShortDateString();
            DateTime thurs = wed.AddDays(1).Date;
            lblDateThur.Text = thurs.ToShortDateString();
            DateTime fri = thurs.AddDays(1).Date;
            lblDateFri.Text = fri.ToShortDateString();
            DateTime sat = fri.AddDays(1).Date;
            lblDateSat.Text = sat.ToShortDateString();
            DateTime sun = sat.AddDays(1).Date;
            lblDateSun.Text = sun.ToShortDateString();
        }

    }
}
