using FastFoodDemo.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            SidePanel.Height = btnTimeSheet.Height;
            SidePanel.Top = btnTimeSheet.Top;     
            pictureBox2.Visible = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTimeSheet.Height;
            SidePanel.Top = btnTimeSheet.Top;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnOvertime.Height;
            SidePanel.Top = btnOvertime.Top;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnOnCall.Height;
            SidePanel.Top = btnOnCall.Top;
        }

     

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnEmployee.Height;
            SidePanel.Top = btnEmployee.Top;
            UC_Employee uc = new UC_Employee();
            addControls(uc);

            // frmEmployee frm = new frmEmployee();
            //frm.TopLevel = false;
            // frm.FormBorderStyle = FormBorderStyle.None;
            // frm.WindowState = FormWindowState.Maximized;
            // pnlForm.Controls.Add(frm);
            //  frm.Show();
            //  pictureBox2.Visible = false;
        }

        private void addControls(UserControl uc)
        {
            pnlForm.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(uc);
            uc.BringToFront();

        }

        private void btnCustomer_Click(object sender, EventArgs e) // accounts
        {
            SidePanel.Height = btnCustomer.Height;
            SidePanel.Top = btnCustomer.Top;
            UC_Accounts uc = new UC_Accounts();
            addControls(uc);

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnSettings.Height;
            SidePanel.Top = btnSettings.Top;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = btnSettings.Height;
            SidePanel.Top = btnSettings.Top;
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMore.Height;
            SidePanel.Top = btnMore.Top;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            UC_Main um = new UC_Main();
            addControls(um);
        }
    }
}
