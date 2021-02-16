using FastFoodDemo.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodDemo.UserControls
{
    public partial class UC_Accounts : UserControl
    {
        public UC_Accounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddAccount frm = new frmAddAccount();
            frm.ShowDialog();
            frm.BringToFront();
        }

        private void UC_Accounts_Load(object sender, EventArgs e)
        {

        }
    }
}
