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
        // connectors for sql quireies
        SqlDataAdapter daProject, daCount ,daDis, daTimesheet, daTimeDets;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder  cmbBTimesheet, cmbBTimeDets;

        private Boolean repeat = false;
        private int claim;

        SqlCommand cmdProj, cmdCount, cmdDis;
        DataRow  drCount, drClaim, drTimeDets;
        String connStr, sqlProject,  sqlDis, sqlCount, sqlTimesheet, sqlTimeDets;
        SqlConnection conn;
 
        //vars to use for data storage
        private int  timesheetValue;
        private double basic1 = 0;
        private double oncall1 = 0;
        private double ot1 = 0;
 
        public frmDeleteTimesheet()
        {
            InitializeComponent();
        }
        //closes the form
         private void button2_Click(object sender, EventArgs e)
          {
                    this.Dispose();
          }

        //loads when the 
        private void frmDeleteTimesheet_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";
            //gets the timesheet details
            sqlTimesheet = @"select * from Timesheet";
            daTimesheet = new SqlDataAdapter(sqlTimesheet, connStr);
            cmbBTimesheet = new SqlCommandBuilder(daTimesheet);
            daTimesheet.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheet");
            daTimesheet.Fill(dsFujitsuPayments, "Timesheet");

            //gets all timesheet details

            sqlTimeDets = @"select * from TimesheetDetails";
            daTimeDets = new SqlDataAdapter(sqlTimeDets, connStr);
            cmbBTimeDets = new SqlCommandBuilder(daTimeDets);
            daTimeDets.FillSchema(dsFujitsuPayments, SchemaType.Source, "TimesheetDetails");
            daTimeDets.Fill(dsFujitsuPayments, "TimesheetDetails");

            //gets the timesheet id from the User Control
            string timeDets = UC_Timesheet.timeNoSelected.ToString();
            timesheetValue = Convert.ToInt32(timeDets);
            drClaim = dsFujitsuPayments.Tables["Timesheet"].Rows.Find(timeDets);

            //gets the distinct claim types to check if there is more than one claim type
            sqlDis = @"Select DISTINCT ClaimTypeID from TimesheetDetails where TimesheetID = @Timesheet1";
            conn = new SqlConnection(connStr);
            cmdDis = new SqlCommand(sqlDis, conn);
            cmdDis.Parameters.Add("@Timesheet1", SqlDbType.Int);
            daDis = new SqlDataAdapter(cmdDis);
            daDis.FillSchema(dsFujitsuPayments, SchemaType.Source, "Timesheets1");


            checkClaimTypes();
            timesheetHours();
        }

        private void checkClaimTypes()
        {
            //adds the timesheet id to the table
            cmdDis.Parameters["@Timesheet1"].Value = (int)UC_Timesheet.timeNoSelected;


            daDis.Fill(dsFujitsuPayments, "Timesheets1");

            DataTable dt = dsFujitsuPayments.Tables["Timesheets1"];
            //counts the claim types in the table
            foreach (DataRow row in dt.Rows)
            {
                claim++;
               
            }
            // if there is only one claim type
            if(claim == 1)
            {
                //sets the value of the combo box to delete all as they have only one claim
                MessageBox.Show("As there is only one claim on the timesheet you must delete both the timesheet and Timesheet claim.");
                cmbProjectId.Items.Clear();
                cmbProjectId.Items.Add("Delete Timesheet and claim");

            }
        }
        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjectId.Focused == true)
            {
               
                //sets the index and timesheet id 
                int index = (int)cmbProjectId.SelectedIndex;
                int timeID = (int)UC_Timesheet.timeNoSelected;

                
                //switch on claim type
                switch(index)
                {
                    //gets all claim types
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

                    //gets Basic claim types
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

                    //gets Overtime claim types
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

                    //gets overtime claim types
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
            //creates the data table from timesheets
            DataTable dt = dsFujitsuPayments.Tables["Timesheets"];
           
            

            int numb = 0;

            //checks the rows in the data table
            foreach (DataRow row in dt.Rows)
            {
                numb++;
            }

            //if it is over one
            if (numb != 0)
            {



                string tempName = drClaim["TimesheetID"].ToString() + "\'s";
                //confirms if the user would like to delete the claim
                if (MessageBox.Show("Are you sure you want to delete claims for " + tempName + "?", "Delete timesheet", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // if index is delete all 
                    if ((int)cmbProjectId.SelectedIndex == 0)
                    {
                        //deletes the timesheet for the record
                        string timeDets = UC_Timesheet.timeNoSelected.ToString();
                        timesheetValue = Convert.ToInt32(timeDets);
                        drClaim = dsFujitsuPayments.Tables["Timesheet"].Rows.Find(timeDets);
                        drClaim.Delete();
                        daTimesheet.Update(dsFujitsuPayments, "Timesheet");
                    }
                   
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        //finds the timesheet detail using the timesheet id, workday and starttime from the record
                        object[] primaryKey = new object[3];

                        primaryKey[0] = row.Field<int>("TimesheetID");
                        primaryKey[1] = row.Field<DateTime>("WorkedDay");
                        primaryKey[2] = row.Field<TimeSpan>("StartTime");


                        //deletes the record
                        drTimeDets = dsFujitsuPayments.Tables["TimesheetDetails"].Rows.Find(primaryKey);
                        drTimeDets.Delete();
                        daTimeDets.Update(dsFujitsuPayments, "TimesheetDetails");
                    }

                    //closes the delete after the user confirms
                    if ((int)cmbProjectId.SelectedIndex == 0)
                    {
                        MessageBox.Show("The timesheet and timesheet details have now been deleted", "Exit Timesheet");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("The timesheet details have now been deleted", "Exit Timesheet");
                        this.Dispose();

                    }
                   
                   
                }
                
            }
            //catches timesheets with no details
            else
            {
                MessageBox.Show("There are no remaining hours for this claim?", "Exit Timesheet");
                    this.Dispose();
                
            
            }
            

        }

        //used to get the hours from the timesheet
        private void timesheetHours()
        {
           //query to bring back records for a user and their hours on the timesheer
           sqlCount = @" select TimesheetID, DATEDIFF ( MINUTE, StartTime, EndTime )/ 60 as Hours, ClaimTypeID from TimesheetDetails where TimesheetID = @Timesheet1";
            conn = new SqlConnection(connStr);
            cmdCount = new SqlCommand(sqlCount, conn);
            cmdCount.Parameters.Add("@Timesheet1", SqlDbType.Int);

            daCount = new SqlDataAdapter(cmdCount);
            daCount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Count");
            //adds the timesheet d
            int timesheet = Convert.ToInt32(UC_Timesheet.timeNoSelected);

            cmdCount.Parameters["@Timesheet1"].Value = timesheet;

            daCount.Fill(dsFujitsuPayments, "Count");


       
            DataTable dt = dsFujitsuPayments.Tables["Count"];
            
            
             dt = dsFujitsuPayments.Tables["Count"];
            int numb = 0;

  



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
                    //keeps a running total of all timesheet detail hours and stores them in variables relating to their name
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
                //populates the lables
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
