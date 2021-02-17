using FujitsuPayments.Forms;
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

namespace FujitsuPayments.UserControls
{
    public partial class UC_Accounts : UserControl
    {

        SqlDataAdapter daAccount;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBAccount;
        DataRow drAccount;
        String connStr, sqlAccount; 


        public UC_Accounts()
        {
            InitializeComponent();
            //this.dgvAccounts.DefaultCellStyle.Font = new Font("Century Gothic", 10);
        }

        private void UC_Accounts_Load(object sender, EventArgs e)
        {
            // style fornt of data grid cell and header
            this.dgvAccounts.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dgvAccounts.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);



            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";

            sqlAccount = @"select * from Account";
            daAccount = new SqlDataAdapter(sqlAccount, connStr);
            cmbBAccount = new SqlCommandBuilder(daAccount);
            daAccount.FillSchema(dsFujitsuPayments, SchemaType.Source, "Account");
            daAccount.Fill(dsFujitsuPayments, "Account");

            dgvAccounts.DataSource = dsFujitsuPayments.Tables["Account"];
            // resize the datagridview columns to fit the newly loaded content
           dgvAccounts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddAccount frm = new frmAddAccount();
            frm.ShowDialog();
            frm.BringToFront();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
