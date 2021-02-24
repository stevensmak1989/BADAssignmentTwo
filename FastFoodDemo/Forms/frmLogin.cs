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

namespace FujitsuPayments
{
    public partial class frmLogin : Form
    {


        SqlDataAdapter daEmployeeLogin;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBEmployeeLogin;
        DataRow drEmployeeLogin;
        String connStr, sqlEmployeeLogin;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                frmMain frm = new frmMain();
                //frm.ShowDialog();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Visible = true;
                frm.Location = new Point(0, 0);
                this.Controls.Add(frm);
                frm.BringToFront();


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";

            sqlEmployeeLogin = @"select * from EmployeeLogin";
            daEmployeeLogin = new SqlDataAdapter(sqlEmployeeLogin, connStr);
            cmbBEmployeeLogin = new SqlCommandBuilder(daEmployeeLogin);
            daEmployeeLogin.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeLogin");
            daEmployeeLogin.Fill(dsFujitsuPayments, "EmployeeLogin");
        }
    }
}
