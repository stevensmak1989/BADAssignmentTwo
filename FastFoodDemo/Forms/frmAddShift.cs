using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FujitsuPayments.Forms
{
    public partial class frmAddShift : Form
    {
        public frmAddShift()
        {
            InitializeComponent();
        }

        private void frmAddShift_Load(object sender, EventArgs e)
        {
            dtpShiftStartTime.CustomFormat = "hh:mm tt";
            dtpShiftStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpShiftStartTime.ShowUpDown = true;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
