﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodDemo.Forms
{
    public partial class frmAddEmployee : Form
    {
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
