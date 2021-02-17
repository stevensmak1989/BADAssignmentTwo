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
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";

            sqlAccount = @"select * from Account";
            daAccount = new SqlDataAdapter(sqlAccount, connStr);
            cmbBAccount = new SqlCommandBuilder(daAccount);
            daAccount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daAccount.Fill(dsFujitsuPayments, "Account");
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
            Account myAccount = new Account();
            bool ok = true;


            drAccount = dsFujitsuPayments.Tables["Account"].NewRow();

            drAccount["AccountID"] = Convert.ToInt32(txtAccountID.Text.Trim());
            drAccount["ClientName"] = txtClientName.Text.Trim();
            drAccount["Street"] = txtStreet.Text.Trim();
            drAccount["Town"] = txtTown.Text.Trim();
            drAccount["County"] = txtCounty.Text.Trim();
            drAccount["Postcode"] = txtPostCode.Text.Trim();
            drAccount["TelNo"] = txtTelNo.Text.Trim();
            drAccount["Email"] = txtEmail.Text.Trim();

            dsFujitsuPayments.Tables["Account"].Rows.Add(drAccount);
            daAccount.Update(dsFujitsuPayments, "Account");

            MessageBox.Show("Account Added");
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
