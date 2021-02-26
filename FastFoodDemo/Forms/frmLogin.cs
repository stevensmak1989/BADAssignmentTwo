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
        String connStr, sqlEmployeeLogin, username, password;
        int userFound;

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
            if(isFormValid())
            {
                using (SqlConnection cn = new SqlConnection(connStr))
                {
                    if(cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand("select * from EmployeeLogin where Username = @Username and UserPassword = @UserPassword", cn))
                    {
                        cmd.Parameters.AddWithValue("Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("UserPassword", txtPassword.Text);

                        DataTable tempEmployeeLogin = new DataTable();

                        daEmployeeLogin = new SqlDataAdapter(cmd);
                        daEmployeeLogin.Fill(tempEmployeeLogin);

                        if(tempEmployeeLogin.Rows.Count > 0)
                        {
                               username = (string)tempEmployeeLogin.Rows[0]["UserName"];
                               password = (string)tempEmployeeLogin.Rows[0]["UserPassword"];  

                                if (txtUsername.Text.ToString() == username && txtPassword.Text.ToString() == password)
                                {
                                    frmMain frm = new frmMain();
                                    frm.TopLevel = false;
                                    frm.FormBorderStyle = FormBorderStyle.None;
                                    frm.Visible = true;
                                    frm.Location = new Point(0, 0);
                                    this.Controls.Add(frm);
                                    frm.BringToFront();
                                }
                                else
                                {
                                    MessageBox.Show("Username or password are incorrect", "Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                        }
                        else
                        {
                            MessageBox.Show("User does not exist", "Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Clear();
                            txtPassword.Clear();

                        }

                       
                    





                    }



            }


            }







        }




        private bool isFormValid()
        {
            if (txtUsername.Text.ToString().Trim() == String.Empty || lblPassword.Text.ToString().Trim() == String.Empty)
            {
                MessageBox.Show("Required fields are empty", "Please fill in all fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
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
