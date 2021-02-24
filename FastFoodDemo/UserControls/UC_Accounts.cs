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
        // database connectors
        SqlDataAdapter daAccount;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBAccount;
        DataRow drAccount;
        String connStr, sqlAccount;

        // Static varibales to pass to form's
        public static int selectedTab = 0;
        public static bool accSelected = false;
        public static int accNoSelected = 0;


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

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            frmAddAccount frm = new frmAddAccount();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true; 
            frm.Location = new Point(180,100);
            this.Controls.Add(frm);
            frm.BringToFront();
            
            
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                accSelected = false;
                accNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select Account");
            }
            else if(dgvAccounts.SelectedRows.Count > 1)
            {
                accSelected = false;
                accNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select Account");

            }
            else if (dgvAccounts.SelectedRows.Count == 1)
            {
                accSelected = true;
                accNoSelected = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells[0].Value);

                frmEditAccount frm = new frmEditAccount();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Visible = true;
                frm.Location = new Point(180, 100);
                this.Controls.Add(frm);
                frm.BringToFront();
            }



        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Account from the list.", "Select Account");
            }
            else
            {
                drAccount = dsFujitsuPayments.Tables["Account"].Rows.Find(dgvAccounts.SelectedRows[0].Cells[0].Value);

                string tempName = drAccount["ClientName"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete " + tempName + "details?", "Add Account", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drAccount.Delete();
                    daAccount.Update(dsFujitsuPayments, "Account");
                }
            }
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
