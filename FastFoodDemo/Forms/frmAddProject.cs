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
                myProject.Duration = Convert.ToInt32(txtDuration.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtDuration, MyEx.toString());
            }
            //employee Town
            try
            {
                myProject.CappedHrs = decimal.Parse(txtCappedhoursAdd.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCappedhoursAdd, MyEx.toString());
            }
            //employee County
            try
            {
                myProject.B48Rate = decimal.Parse(txtBasicAdd.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtBasicAdd, MyEx.toString());
            }

            //employee Postcode
            try
            {
                myProject.A48Rate = decimal.Parse(txtlblBankHolAdd.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtlblBankHolAdd, MyEx.toString());
            }

            //employee TelNo
            try
            {
                myProject.BHRate = decimal.Parse(txtlblBankHolAdd.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtlblBankHolAdd, MyEx.toString());
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
                    drProject["Duration"] = myProject.Duration;
                    drProject["CappedHrs"] = myProject.CappedHrs;
                    drProject["B48Rate"] = myProject.B48Rate;
                    drProject["A48Rate"] = myProject.A48Rate;
                    drProject["BHRate"] = myProject.BHRate;


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
