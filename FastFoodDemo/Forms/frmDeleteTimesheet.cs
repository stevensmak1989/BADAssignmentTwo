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
    public partial class frmDeleteTimesheet : Form
    {
        SqlDataAdapter daProject, daCount, daEmployee, daEmpTask, daClaim, daMan, daTimesheet, daTimeDets, daCost;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBClaim, cmbBEmp, cmbBTimesheet, cmbBTimeDets, cmbBCost;

        private Boolean repeat = false; 

        SqlCommand cmdEmp, cmdProj, cmdCount;
        DataRow drProject, drCount, drClaim, drTimeDets;
        String connStr, sqlProject, sqlEmp, sqlCount, sqlEmpTask, sqlClaim, sqlMan, sqlTimesheet, sqlTimeDets, sqlCost;
        SqlConnection conn;
        private double count;
        private int numb, no, timesheetValue;
        private double basic1 = 0;
        private double oncall1 = 0;
        private double ot1 = 0;
        public frmDeleteTimesheet()
        {
            InitializeComponent();
        }

        private void frmDeleteTimesheet_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

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


            string timeDets = UC_Timesheet.timeNoSelected.ToString();
            timesheetValue = Convert.ToInt32(timeDets);
            drClaim = dsFujitsuPayments.Tables["Timesheet"].Rows.Find(timeDets);

            timesheetHours();
        }
        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjectId.Focused == true)
            {
                if(repeat == true)
                {
                    daProject.Dispose();
                }

                int index = (int)cmbProjectId.SelectedIndex;
                int timeID = (int)UC_Timesheet.timeNoSelected;

                switch(index)
                {
                    case 0:
                 

                        sqlProject = @"Select  * from TimesheetDetails where TimesheetID = @Timesheet";
                        conn = new SqlConnection(connStr);
                        cmdProj = new SqlCommand(sqlProject, conn);
                        cmdProj.Parameters.Add("@Timesheet", SqlDbType.Int);
                        daProject = new SqlDataAdapter(cmdProj);
                        daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets");

                        cmdProj.Parameters["@Timesheet"].Value = Convert.ToInt32(timeID);
                       

                        daProject.Fill(dsFujitsuPayments, "Timesheets");



                        break;
                    case 1:
                        sqlProject = @"Select  * from TimesheetDetails where TimesheetID = @Timesheet and ClaimTypeID = 1";
                        conn = new SqlConnection(connStr);
                        cmdProj = new SqlCommand(sqlProject, conn);
                        cmdProj.Parameters.Add("@Timesheet", SqlDbType.Int);
                        daProject = new SqlDataAdapter(cmdProj);
                        daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets");

                        cmdProj.Parameters["@Timesheet"].Value = Convert.ToInt32(timeID);


                        daProject.Fill(dsFujitsuPayments, "Timesheets");



                        break;
                    case 2:
                        sqlProject = @"Select  * from TimesheetDetails where TimesheetID = @Timesheet and ClaimTypeID = 3";
                        conn = new SqlConnection(connStr);
                        cmdProj = new SqlCommand(sqlProject, conn);
                        cmdProj.Parameters.Add("@Timesheet", SqlDbType.Int);
                        daProject = new SqlDataAdapter(cmdProj);
                        daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets");

                        cmdProj.Parameters["@Timesheet"].Value = Convert.ToInt32(timeID);


                        daProject.Fill(dsFujitsuPayments, "Timesheets");



                        break;
                    case 3:
                        sqlProject = @"Select  * from TimesheetDetails where TimesheetID = @Timesheet and ClaimTypeID = 2";
                        conn = new SqlConnection(connStr);
                        cmdProj = new SqlCommand(sqlProject, conn);
                        cmdProj.Parameters.Add("@Timesheet", SqlDbType.Int);
                        daProject = new SqlDataAdapter(cmdProj);
                        daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets");

                        cmdProj.Parameters["@Timesheet"].Value = Convert.ToInt32(timeID);


                        daProject.Fill(dsFujitsuPayments, "Timesheets");
                        break;
                    default:
                        MessageBox.Show("Please select a valid delete option");
                        break;
                }



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            DataTable dt = dsFujitsuPayments.Tables["Timesheets"];
           
            

            int numb = 0;
            foreach (DataRow row in dt.Rows)
            {
                numb++;
            }

            if (numb != 0)
            {



                string tempName = drClaim["TimesheetID"].ToString() + "\'s";
                if (MessageBox.Show("Are you sure you want to delete claims for " + tempName + "?", "Delete timesheet", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if ((int)cmbProjectId.SelectedIndex == 0)
                    {
                        string timeDets = UC_Timesheet.timeNoSelected.ToString();
                        timesheetValue = Convert.ToInt32(timeDets);
                        drClaim = dsFujitsuPayments.Tables["Timesheet"].Rows.Find(timeDets);
                        drClaim.Delete();
                        daTimesheet.Update(dsFujitsuPayments, "Timesheet");
                    }
                   

                    foreach (DataRow row in dt.Rows)
                    {
                        object[] primaryKey = new object[3];

                        primaryKey[0] = row.Field<int>("TimesheetID");
                        primaryKey[1] = row.Field<DateTime>("WorkedDay");
                        primaryKey[2] = row.Field<TimeSpan>("StartTime");



                        drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Find(primaryKey);
                        drTimeDets.Delete();
                        daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                    }
                    if ((int)cmbProjectId.SelectedIndex == 0)
                    {
                        MessageBox.Show("The timesheet and timesheet details have now been deleted", "Exit Timesheet");
                        this.Dispose();
                    }
                   

                    this.Dispose();
                   
                }
                
            }
            else
            {
                MessageBox.Show("There are no remaining hours for this claim?", "Exit Timesheet");
                    this.Dispose();
                
             
                    
                
            }
            

        }

        private void timesheetHours()
        {
           
           sqlCount = @" select TimesheetID, DATEDIFF ( MINUTE, StartTime, EndTime )/ 60 as Hours, ClaimTypeID from TimesheetDetails where TimesheetID = @Timesheet1";
            conn = new SqlConnection(connStr);
            cmdCount = new SqlCommand(sqlCount, conn);
            cmdCount.Parameters.Add("@Timesheet1", SqlDbType.Int);

            daCount = new SqlDataAdapter(cmdCount);
            daCount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Count");

            int timesheet = Convert.ToInt32(UC_Timesheet.timeNoSelected);

            cmdCount.Parameters["@Timesheet1"].Value = timesheet;

            daCount.Fill(dsFujitsuPayments, "Count");



            DataTable dt = dsFujitsuPayments.Tables["Count"];
            if (repeat == true)
            {
                dt.Reset(); 
            }
            
             dt = dsFujitsuPayments.Tables["Count"];
            int numb = 0, count = 0, x = 0;

  



            foreach (DataRow row in dt.Rows)
            {

                numb++;

            }

             basic1 = 0;
             oncall1 = 0;
             ot1 = 0;



            if (numb != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    drCount = row;
                    
                    int cType = Convert.ToInt32(drCount["ClaimTypeID"].ToString());
                    drCount = row;

                        switch (cType)
                        {
                            case 1:
                                basic1 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 2:
                                ot1 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                            case 3:
                                oncall1 += Convert.ToDouble(drCount["Hours"].ToString());
                                break;
                        }

                }

                lblTimesheet.Text = Convert.ToString(timesheet);
                lblBasicHours.Text  = Convert.ToString(basic1);
                lblOTHours.Text = Convert.ToString(ot1);
                lblOCHours.Text = Convert.ToString(oncall1);


                

            }
            else
            {

            }

        }
    }
}
