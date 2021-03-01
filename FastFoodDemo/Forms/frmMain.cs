using FujitsuPayments.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FujitsuPayments
{
    public partial class frmMain : Form
    {
        

        private bool isCollapsed = true;
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
            UC_Timesheet uc = new UC_Timesheet();
            addControls(uc);

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
            UC_Schedule uc = new UC_Schedule();
            addControls(uc);
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

        private void btnProject_Click(object sender, EventArgs e)
        {

           // label1.Text = "here";
            timer1.Start();
            timer1_Tick(sender,e);

            //SidePanel.Height = btnProject.Height;
            //SidePanel.Top = btnProject.Top;
            //UC_Project uc = new UC_Project();
            //addControls(uc);
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
            SidePanel.Height = btnProject.Height;
            SidePanel.Top = btnProject.Top;
        }

        private void btnMore_Click(object sender, EventArgs e) // location button
        {
            SidePanel.Height = btnLocation.Height;
            SidePanel.Top = btnLocation.Top;
            UC_Location uc = new UC_Location();
            addControls(uc);
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            UC_Main um = new UC_Main();
            addControls(um);
        }

        

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollapsed)
            {
                pnlDropDown.Size = pnlDropDown.MaximumSize;
                pnlDropDown.Height += 10;
                if(pnlDropDown.Size == pnlDropDown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                pnlDropDown.Size = pnlDropDown.MinimumSize;
                pnlDropDown.Height -= 10;
                if (pnlDropDown.Size == pnlDropDown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
