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
    public partial class frmEditProject : Form

    {

        SqlDataAdapter daProject,daClient;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBClient;
        DataRow drProject, drClient;
        String connStr, sqlProject, sqlClient;

        private void btnEmpClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPrjSave_Click(object sender, EventArgs e)
        {
            Project myProject = new Project();
            bool ok = true;
            errP.Clear();

            //sets the projet id
            try
            {
                myProject.ProjectId = Convert.ToInt32(lblPrjIDEdit.Text.Trim());


            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblPrjIDEdit, MyEx.toString());
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
            catch (System.OverflowException)
            {
                ok = false;
                errP.SetError(txtDuration, "Duration must not be larger than 600 days");

            }

            try
            {
                myProject.CappedHrs = txtCappedhoursEdit.Text.Trim();
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCappedhoursEdit, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException)
            {
                ok = false;
                errP.SetError(txtCappedhoursEdit, "Capped Hours must not be larger than 10000 hours");

            }

            try
            {
                myProject.B48Rate = txtBasicEdit.Text;
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtBasicEdit, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException)
            {
                ok = false;
                errP.SetError(txtBasicEdit, "basic Hours must not be larger than 1");
            }

            try
            {
                myProject.A48Rate = txtOvertimeEdit.Text;
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtOvertimeEdit, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException)
            {
                ok = false;
                errP.SetError(txtOvertimeEdit, "Overtime Hours must not be greater than 1 and less than 2");

            }

            try
            {
                myProject.BHRate = txtlblBankHolEdit.Text;
            }
            //catches the errors from the class
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtlblBankHolEdit, MyEx.toString());
            }
            //catches the errors from the class
            catch (System.OverflowException)
            {
                ok = false;
                errP.SetError(txtlblBankHolEdit, "Bank Holiday Hours must not be greater than 1.9 and less than 4.1");
            }
            try
            {
                //if the validation is passed
                if (ok)
                {
                    drProject.BeginEdit();

                    drProject["ProjectID"] = myProject.ProjectId;
                    drProject["ProjDesc"] = myProject.ProjDesc;
                    drProject["AccountID"] = myProject.AccountID;
                    drProject["StartDate"] = myProject.StartDate;
                    drProject["Duration"] = Convert.ToInt32(myProject.Duration);
                    drProject["CappedHrs"] = decimal.Parse(myProject.CappedHrs);
                    drProject["B48Rate"] = decimal.Parse(myProject.B48Rate);
                    drProject["A48Rate"] = decimal.Parse(myProject.A48Rate);
                    drProject["BHRate"] = decimal.Parse(myProject.BHRate);

                    drProject.EndEdit();
                    daProject.Update(dsFujitsuPayments, "Project");

                    MessageBox.Show("Project Updated");
                    this.Dispose();
                    UC_Employee.refresh = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
    

        public frmEditProject()
        {
            InitializeComponent();
        }

     

        private void frmEditProject_Load(object sender, EventArgs e)
        {
            //sets the datasource to project table
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlProject = @"select * from Project";
            daProject = new SqlDataAdapter(sqlProject, connStr);
            cmbBProject = new SqlCommandBuilder(daProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");
            daProject.Fill(dsFujitsuPayments, "Project");

            //gets the account information
            sqlClient = @"select * from Account";
            daClient = new SqlDataAdapter(sqlClient, connStr);
            cmbBClient = new SqlCommandBuilder(daClient);
            daClient.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daClient.Fill(dsFujitsuPayments, "Account");

            //gets the project id from the user control
            lblPrjIDEdit.Text = UC_Project.prjNoSelected.ToString();

            drProject = dsFujitsuPayments.Tables["Project"].Rows.Find(lblPrjIDEdit.Text);



            cmbAccountId.DataSource = dsFujitsuPayments.Tables["Account"];
            cmbAccountId.ValueMember = "AccountID";
            cmbAccountId.DisplayMember = "ClientName";

            //populates the fields to the database values
            cmbAccountId.Text = drProject["AccountID"].ToString();
            txtProjDesc.Text = drProject["ProjDesc"].ToString();
            dtpStartDate.Text =  drProject["StartDate"].ToString();
           txtDuration.Text =  drProject["Duration"].ToString();
           txtCappedhoursEdit.Text = drProject["CappedHrs"].ToString();
            txtBasicEdit.Text = drProject["B48Rate"].ToString();
           txtOvertimeEdit.Text= drProject["A48Rate"].ToString();
           txtlblBankHolEdit.Text = drProject["BHRate"].ToString();
        }
    }
}
