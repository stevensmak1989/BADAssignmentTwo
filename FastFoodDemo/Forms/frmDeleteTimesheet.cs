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

       

        SqlCommand cmdEmp, cmdProj, cmdCount;
        DataRow drProject, drCount, drClaim, drTimeDets;
        String connStr, sqlProject, sqlEmp, sqlCount, sqlEmpTask, sqlClaim, sqlMan, sqlTimesheet, sqlTimeDets, sqlCost;
        SqlConnection conn;
        private double count;
        private int numb, no, timesheetValue;

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



            
        }
        private void cmbProjectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjectId.Focused == true)
            {

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
                        daProject.Dispose();
                        daProject = new SqlDataAdapter(cmdProj);

                        cmdProj.Parameters["@Timesheet"].Value = timeID;

                        daProject.Fill(dsFujitsuPayments, "Timesheets");


                        DataTable dt = dsFujitsuPayments.Tables["Timesheets"];

                        foreach (DataRow row in dt.Rows)
                        {
                            MessageBox.Show(Convert.ToString(row.Field<int>("TimesheetID");))

                        }

                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        MessageBox.Show("Please select a valid delete option");
                        break;
                }



            }
        }
    }
}
