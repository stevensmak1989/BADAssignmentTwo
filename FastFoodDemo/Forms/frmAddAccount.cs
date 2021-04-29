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
using FujitsuPayments.UserControls;

namespace FujitsuPayments.Forms
{
    public partial class frmAddAccount : Form
    {


        SqlDataAdapter daAccount;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBAccount;
        DataRow drAccount;
        String connStr, sqlAccount;


        public frmAddAccount()
        {
            InitializeComponent();
            
            
        }
        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlAccount = @"select * from Account";
            daAccount = new SqlDataAdapter(sqlAccount, connStr);
            cmbBAccount = new SqlCommandBuilder(daAccount);
            daAccount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daAccount.Fill(dsFujitsuPayments, "Account");


            int noRows = dsFujitsuPayments.Tables["Account"].Rows.Count;

            if (noRows == 0)
                txtAccountID.Text = "10000";
            else
            {
                getNumber(noRows);
            }

        }
        private void lblUsername_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder errorMessages = new StringBuilder();

            // prevent nulls being entered or empty strings
            if (String.IsNullOrEmpty(txtClientName.Text) && String.IsNullOrEmpty(txtStreet.Text) && String.IsNullOrEmpty(txtTown.Text) &&
                String.IsNullOrEmpty(txtCounty.Text) && String.IsNullOrEmpty(txtTelNo.Text) && String.IsNullOrEmpty(txtPostCode.Text)
                && String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("All fields must be filled in");

            }
            else
            {
                Account myAccount = new Account();
                bool ok = true;

                errP.Clear();

                // -----------  TRY CATCH INPUT VALIDATION -------------------- //
                try
                {
                    myAccount.AccountId = Convert.ToInt32(txtAccountID.Text.Trim()); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtAccountID, MyEx.toString());
                }
                try
                {
                    myAccount.ClientName = txtClientName.Text.Trim(); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtClientName, MyEx.toString());
                }
                try
                {
                    myAccount.Street = txtStreet.Text.Trim(); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtStreet, MyEx.toString());
                }
                try
                {
                    myAccount.Town = txtTown.Text.Trim(); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtTown, MyEx.toString());
                }
                try
                {
                    myAccount.County = txtCounty.Text.Trim(); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtCounty, MyEx.toString());
                }
                try
                {
                    myAccount.Postcode = txtPostCode.Text.Trim();// passed to account class to check
                }
                catch (ConstraintException ex)
                {
                    MessageBox.Show("Please enter a valid post code", "Add Account");
                    ok = false;
                    errP.SetError(txtPostCode, ex.ToString());
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtPostCode, MyEx.toString());
                }
                try
                {
                    myAccount.TelNo = txtTelNo.Text.Trim();// passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtTelNo, MyEx.toString());
                }
                try
                {
                    myAccount.Email = txtEmail.Text.Trim();// passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEmail, MyEx.toString());
                }
                // ----------- END TRY CATCH INPUT VALIDATION -------------------- //
                try
                {
                    if (ok)
                    {
                        drAccount = dsFujitsuPayments.Tables["Account"].NewRow();

                        drAccount["AccountID"] = myAccount.AccountId;
                        drAccount["ClientName"] = myAccount.ClientName;
                        drAccount["Street"] = myAccount.Street;
                        drAccount["Town"] = myAccount.Town;
                        drAccount["County"] = myAccount.County;
                        drAccount["Postcode"] = myAccount.Postcode;
                        drAccount["TelNo"] = myAccount.TelNo;
                        drAccount["Email"] = myAccount.Email;

                        dsFujitsuPayments.Tables["Account"].Rows.Add(drAccount);
                        daAccount.Update(dsFujitsuPayments, "Account");

                        MessageBox.Show("Account Added");
                        UC_Accounts.accountButtons = false;
                        
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //cancel button
        {
            UC_Accounts.accountButtons = false;   
            this.Dispose();
        }

        private void lblAccountId_Click(object sender, EventArgs e)
        {

        }

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblClientName_Click(object sender, EventArgs e)
        {

        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTown_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCounty_Click(object sender, EventArgs e)
        {

        }

        private void txtCounty_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPostCode_Click(object sender, EventArgs e)
        {

        }

        private void txtPostCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTelNo_Click(object sender, EventArgs e)
        {

        }

        private void txtTelNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void getNumber(int noRows)
        {
            drAccount = dsFujitsuPayments.Tables["Account"].Rows[noRows - 1];
            txtAccountID.Text = (int.Parse(drAccount["AccountID"].ToString()) + 1).ToString();
        }
    }
}
