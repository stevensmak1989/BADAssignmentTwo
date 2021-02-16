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
    public partial class UC_Schedule : UserControl
    {
        

        public UC_Schedule()
        {
            InitializeComponent();
            pnlAddTask.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlAddTask.Visible = true;
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            pnlAddTask.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
