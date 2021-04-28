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
    public partial class frmAddProject : Form
    {
        // creates the sql adaptors
        SqlDataAdapter daProject, daClient;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBClient;
        DataRow drProject, drClient;
        String connStr, sqlProject, sqlClient;

        public frmAddProject()
        {
            InitializeComponent();
        }
        //is called when the project is loaded
        private void frmAddProject_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlProject = @"select * from Project";
            daProject = new SqlDataAdapter(sqlProject, connStr);
            cmbBProject = new SqlCommandBuilder(daProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");
            daProject.Fill(dsFujitsuPayments, "Project");

            sqlClient = @"select * from Account";
            daClient = new SqlDataAdapter(sqlClient, connStr);
            cmbBClient = new SqlCommandBuilder(daClient);
            daClient.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daClient.Fill(dsFujitsuPayments, "Account");

            //sets the combo box to the account data table
            cmbAccountId.DataSource = dsFujitsuPayments.Tables["Account"];
            cmbAccountId.ValueMember = "AccountID";
            cmbAccountId.DisplayMember = "ClientName";

            //checks the row numbers in the project
            int noRows = dsFujitsuPayments.Tables["Project"].Rows.Count;

            //if it is 0 sets the value to 1
            if (noRows == 0)
                lblPrjIDAdd.Text = "1";
            //checks the number of rows
            else
            {
                getNumber(noRows);
            }
        }

        // is called when the close button is pressed and will dispose the form
        private void btnEmpClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //called when the save button is pressed
        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            Project myProject = new Project();
            bool ok = true;
            errP.Clear();

           //sets the projet id
            try
            {
                myProject.ProjectId = Convert.ToInt32(lblPrjIDAdd.Text.Trim());
            

            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblPrjIDAdd, MyEx.toString());
            }
          
            try
            {
                myProject.ProjDesc = txtProjDesc.Text.Trim();
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtProjDesc, MyEx.toString());
            }
          
            try
            {
                myProject.AccountID = Convert.ToInt32(cmbAccountId.SelectedValue);
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAccountId, MyEx.toString());
            }
          
            try
            {
                myProject.StartDate = DateTime.Parse(dtpStartDate.Text.Trim());
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(dtpStartDate, MyEx.toString());
            }
            
        
            try
            {
                myProject.Duration = txtDuration.Text.Trim();
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtDuration, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException )
            {
                ok = false;
                errP.SetError(txtDuration, "Duration must not be larger than 600 days");

            }
          
            try
            {
                myProject.CappedHrs = txtCappedhoursAdd.Text.Trim();
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCappedhoursAdd, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException )
            {
                ok = false;
                errP.SetError(txtCappedhoursAdd, "Capped Hours must not be larger than 10000 hours");

            }
           
            try
            {
                myProject.B48Rate = txtBasicAdd.Text;
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtBasicAdd, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException )
            {
                ok = false;
                errP.SetError(txtBasicAdd, "basic Hours must not be larger than 1");
            }

            try
            {
                myProject.A48Rate = txtOvertimeAdd.Text;
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtOvertimeAdd, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException )
            {
                ok = false;
                errP.SetError(txtOvertimeAdd, "Overtime Hours must not be greater than 1 and less than 2");

            }
         
            try
            {
                myProject.BHRate = txtlblBankHolAdd.Text;
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtlblBankHolAdd, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException )
            {
                ok = false;
                errP.SetError(txtlblBankHolAdd, "Bank Holiday Hours must not be greater than 1.9 and less than 4.1");
            }
            try
            {
                //if the validation is passed
                if (ok)
                {
                    //creates the new row to be added
                    drProject = dsFujitsuPayments.Tables["Project"].NewRow();

                    drProject["ProjectID"] = myProject.ProjectId;
                    drProject["ProjDesc"] = myProject.ProjDesc;
                    drProject["AccountID"] = myProject.AccountID;
                    drProject["StartDate"] = myProject.StartDate;
                    drProject["Duration"] = Convert.ToInt32(myProject.Duration);
                    drProject["CappedHrs"] = Convert.ToDecimal(myProject.CappedHrs);
                    
                    drProject["A48Rate"] = Convert.ToDecimal(myProject.A48Rate);
                    drProject["BHRate"] = Convert.ToDecimal(myProject.BHRate);
                    drProject["B48Rate"] = Convert.ToDecimal(myProject.B48Rate);

                    //inserts the row into the database
                    dsFujitsuPayments.Tables["Project"].Rows.Add(drProject);
                    daProject.Update(dsFujitsuPayments, "Project");

                    MessageBox.Show("Project Added");
                    this.Dispose();

                }
            }
            //catches the errors from the class
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

       

        private void getNumber(int noRows)
        {
            drProject = dsFujitsuPayments.Tables["Project"].Rows[noRows - 1];
            lblPrjIDAdd.Text = (int.Parse(drProject["ProjectID"].ToString()) + 1).ToString();
        }
    }
}
