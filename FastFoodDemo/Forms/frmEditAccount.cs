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
    public partial class frmEditAccount : Form
    {

        // database connectors
        SqlDataAdapter daAccount;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBAccount;
        DataRow drAccount;
        String connStr, sqlAccount;

        public frmEditAccount()
        {
            InitializeComponent();
        }

        private void frmEditAccount_Load(object sender, EventArgs e)
        {

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";
            sqlAccount = @"select * from Account";
            daAccount = new SqlDataAdapter(sqlAccount, connStr);
            cmbBAccount = new SqlCommandBuilder(daAccount);
            daAccount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daAccount.Fill(dsFujitsuPayments, "Account");

            // Retrieve Account No from Account User Control
            txtEditAccountID.Text = UC_Accounts.accNoSelected.ToString();

            drAccount = dsFujitsuPayments.Tables["Account"].Rows.Find(txtEditAccountID.Text);

            // populate fields on edit form
            txtEditClientName.Text = drAccount["ClientName"].ToString();
            txtEditStreet.Text = drAccount["Street"].ToString();
            txtEditTown.Text = drAccount["Town"].ToString();
            txtEditCounty.Text = drAccount["County"].ToString();
            txtEditPostCode.Text = drAccount["PostCode"].ToString();
            txtEditTelNo.Text = drAccount["TelNo"].ToString();
            txtEditEmail.Text = drAccount["Email"].ToString();


        }

        private void button2_Click(object sender, EventArgs e) //Cancel button
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            // prevent nulls being entered or empty strings
            if (String.IsNullOrEmpty(txtEditClientName.Text) && String.IsNullOrEmpty(txtEditStreet.Text) && String.IsNullOrEmpty(txtEditTown.Text) &&
                String.IsNullOrEmpty(txtEditCounty.Text) && String.IsNullOrEmpty(txtEditTelNo.Text) && String.IsNullOrEmpty(txtEditPostCode.Text)
                && String.IsNullOrEmpty(txtEditEmail.Text))
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
                    myAccount.AccountId = Convert.ToInt32(txtEditAccountID.Text.Trim()); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditAccountID, MyEx.toString());
                }
                try
                {
                    myAccount.ClientName = txtEditClientName.Text.Trim(); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditClientName, MyEx.toString());
                }
                try
                {
                    myAccount.Street = txtEditStreet.Text.Trim(); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditStreet, MyEx.toString());
                }
                try
                {
                    myAccount.Town = txtEditTown.Text.Trim(); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditTown, MyEx.toString());
                }
                try
                {
                    myAccount.County = txtEditCounty.Text.Trim(); // passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditCounty, MyEx.toString());
                }
                try
                {
                    myAccount.Postcode = txtEditPostCode.Text.Trim();// passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditPostCode, MyEx.toString());
                }
                try
                {
                    myAccount.TelNo = txtEditTelNo.Text.Trim();// passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditTelNo, MyEx.toString());
                }
                try
                {
                    myAccount.Email = txtEditEmail.Text.Trim();// passed to account class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditEmail, MyEx.toString());
                }

                try
                {
                    if (ok)
                    {
                        drAccount.BeginEdit();

                        drAccount["AccountID"] = myAccount.AccountId;
                        drAccount["ClientName"] = myAccount.ClientName;
                        drAccount["Street"] = myAccount.Street;
                        drAccount["Town"] = myAccount.Town;
                        drAccount["County"] = myAccount.County;
                        drAccount["Postcode"] = myAccount.Postcode;
                        drAccount["TelNo"] = myAccount.TelNo;
                        drAccount["Email"] = myAccount.Email; ;

                        drAccount.EndEdit();
                        daAccount.Update(dsFujitsuPayments, "Account");

                        MessageBox.Show("Account Details Updated", "Account");

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

        private void pnlEditAccount_Paint(object sender, PaintEventArgs e)
        {

        }

        private void getNumber(int noRows) //function to count rows in table
        {
            drAccount = dsFujitsuPayments.Tables["Account"].Rows[noRows - 1];
            txtEditAccountID.Text = (int.Parse(drAccount["AccountID"].ToString()) + 1).ToString();
        }


    }
}
