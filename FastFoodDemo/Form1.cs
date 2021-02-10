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
            btnMenu.Visible = false;
            //firstCustomControl1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTimeSheet.Height;
            SidePanel.Top = btnTimeSheet.Top;
           //firstCustomControl1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnOvertime.Height;
            SidePanel.Top = btnOvertime.Top;
           // mySecondCustmControl1.BringToFront();

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
        }



        private void btnCustomer_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCustomer.Height;
            SidePanel.Top = btnCustomer.Top;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlForm.Width = 972;
            pnlForm.Location = new Point(55, 59);
            pnlMenu.Width = 56; 
            pictureBox1.Hide();
            btnMenu.Visible = true;
            pictureBox2.Location = new Point(190, 117);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlForm.Width = 832;
            pnlForm.Location = new Point(195,59);
            pnlMenu.Width = 196;
            btnMenu.Visible = false;
            pictureBox1.Show();
            pictureBox2.Location = new Point(267, 117);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
