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

namespace FujitsuPayments.UserControls
{
    public partial class UC_Timesheet : UserControl
    {
        public UC_Timesheet()
        {
            InitializeComponent();
        }

        private void btnAddTimesheet_Click(object sender, EventArgs e)
        {
            frmAddTimesheet frm = new frmAddTimesheet();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Location = new Point(100, 60);
            this.Controls.Add(frm);
            frm.BringToFront();
        }
    }
}
