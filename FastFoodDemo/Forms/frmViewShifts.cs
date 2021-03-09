using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FujitsuPayments.UserControls;

namespace FujitsuPayments.Forms
{
    public partial class frmViewShifts : Form
    {
        SqlDataAdapter daEmpShift, daEmpShiftDet;
        DataSet dsFujitsuPayments = new DataSet();
        SqlConnection conn;
        SqlCommandBuilder cmbBEmpShift, cmbBEmpShiftDet;
        SqlCommand cmbEmpShift, cmbEmpShiftDet;
        DataRow drEmpShift, drEmpShiftDet;
        String connStr, sqlEmpShift, sqlEmpShiftDet;
 



        public frmViewShifts()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
