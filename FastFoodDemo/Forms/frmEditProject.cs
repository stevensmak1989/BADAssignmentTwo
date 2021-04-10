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

            //employee number
            try
            {
                myProject.ProjectId = Convert.ToInt32(lblPrjIDEdit.Text.Trim());
                //passed to employee Class to check

            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblPrjIDEdit, MyEx.toString());
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
            //employee Town
            try
            {
                myProject.CappedHrs = txtCappedhoursEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtCappedhoursEdit, MyEx.toString());
            }
            //employee County
            try
            {
                myProject.B48Rate = txtBasicEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtBasicEdit, MyEx.toString());
            }

            //employee Postcode
            try
            {
                myProject.A48Rate = txtlblBankHolEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtlblBankHolEdit, MyEx.toString());
            }

            //employee TelNo
            try
            {
                myProject.BHRate = txtlblBankHolEdit.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtlblBankHolEdit, MyEx.toString());
            }

            try
            {
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

        private void lbltitle_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmEditProject_Load(object sender, EventArgs e)
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


            lblPrjIDEdit.Text = UC_Project.prjNoSelected.ToString();

            drProject = dsFujitsuPayments.Tables["Project"].Rows.Find(lblPrjIDEdit.Text);



            cmbAccountId.DataSource = dsFujitsuPayments.Tables["Account"];
            cmbAccountId.ValueMember = "AccountID";
            cmbAccountId.DisplayMember = "ClientName";

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
