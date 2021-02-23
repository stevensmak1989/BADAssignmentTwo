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
    public partial class frmEditAccount : Form
    {

        SqlDataAdapter daAccount;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBAccount;
        DataRow drAccount;
        String connStr, sqlAccount;

        bool accSelected = false;
        int accNoSelected = 0;


        public frmEditAccount()
        {
            InitializeComponent();
        }

        private void frmEditAccount_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";

            sqlAccount = @"select * from Account";
            daAccount = new SqlDataAdapter(sqlAccount, connStr);
            cmbBAccount = new SqlCommandBuilder(daAccount);
            daAccount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daAccount.Fill(dsFujitsuPayments, "Account");


        }

        private void button2_Click(object sender, EventArgs e) //Cancel button
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void getNumber(int noRows)
        {
            drAccount = dsFujitsuPayments.Tables["Account"].Rows[noRows - 1];
            txtEditAccountID.Text = (int.Parse(drAccount["AccountID"].ToString()) + 1).ToString();
        }


    }
}
