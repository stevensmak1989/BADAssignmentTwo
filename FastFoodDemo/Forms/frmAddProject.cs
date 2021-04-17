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

        SqlDataAdapter daProject, daClient;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject, cmbBClient;
        DataRow drProject, drClient;
        String connStr, sqlProject, sqlClient;

        public frmAddProject()
        {
            InitializeComponent();
        }

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

            cmbAccountId.DataSource = dsFujitsuPayments.Tables["Account"];
            cmbAccountId.ValueMember = "AccountID";
            cmbAccountId.DisplayMember = "ClientName";

            int noRows = dsFujitsuPayments.Tables["Project"].Rows.Count;

            if (noRows == 0)
                lblPrjIDAdd.Text = "1";
            else
            {
                getNumber(noRows);
            }
        }

        private void btnEmpClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            Project myProject = new Project();
            bool ok = true;
            errP.Clear();

            //employee number
            try
            {
                myProject.ProjectId = Convert.ToInt32(lblPrjIDAdd.Text.Trim());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblPrjIDAdd, MyEx.toString());
            }
            //employee Title
            try
            {
                myProject.ProjDesc = txtProjDesc.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtProjDesc, MyEx.toString());
            }
            //employee Surname
            try
            {
                myProject.AccountID = Convert.ToInt32(cmbAccountId.SelectedValue);
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAccountId, MyEx.toString());
            }
            //employee Forename
            try
            {
                myProject.StartDate = DateTime.Parse(dtpStartDate.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(dtpStartDate, MyEx.toString());
            }
            
            //employee Street
            try
            {
                myProject.Duration = txtDuration.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtDuration, MyEx.toString());
            }
            catch (System.OverflowException ex)
            {
                ok = false;
                errP.SetError(txtDuration, "Duration must not be larger than 600 days");

            }
            //employee Town
            try
            {
                myProject.CappedHrs = txtCappedhoursAdd.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCappedhoursAdd, MyEx.toString());
            }
            catch (System.OverflowException ex)
            {
                ok = false;
                errP.SetError(txtCappedhoursAdd, "Capped Hours must not be larger than 10000 hours");

            }
            //employee County
            try
            {
                myProject.B48Rate = txtBasicAdd.Text;
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtBasicAdd, MyEx.toString());
            }
            catch (System.OverflowException ex)
            {
                ok = false;
                errP.SetError(txtBasicAdd, "basic Hours must not be larger than 1");

            }

            //employee Postcode
            try
            {
                myProject.A48Rate = txtOvertimeAdd.Text;
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtOvertimeAdd, MyEx.toString());
            }

            catch (System.OverflowException ex)
            {
                ok = false;
                errP.SetError(txtOvertimeAdd, "Overtime Hours must not be greater than 1 and less than 2");

            }
            //employee TelNo
            try
            {
                myProject.BHRate = txtlblBankHolAdd.Text;
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtlblBankHolAdd, MyEx.toString());
            }
            catch (System.OverflowException ex)
            {
                ok = false;
                errP.SetError(txtlblBankHolAdd, "Bank Holiday Hours must not be greater than 1.9 and less than 4.1");

            }
            try
            {
                if (ok)
                {

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

                    dsFujitsuPayments.Tables["Project"].Rows.Add(drProject);
                    daProject.Update(dsFujitsuPayments, "Project");

                    MessageBox.Show("Project Added");
                    this.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }

        private void txtCappedhoursAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void getNumber(int noRows)
        {
            drProject = dsFujitsuPayments.Tables["Project"].Rows[noRows - 1];
            lblPrjIDAdd.Text = (int.Parse(drProject["ProjectID"].ToString()) + 1).ToString();
        }
    }
}
