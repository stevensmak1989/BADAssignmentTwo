﻿using FujitsuPayments.Forms;
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

namespace FujitsuPayments.UserControls
{
    public partial class UC_Schedule : UserControl
    {
        SqlDataAdapter daShift;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBShift;
        DataRow drShift;
        String connStr, sqlShift;

        public UC_Schedule()
        {
            InitializeComponent();
            
        }

        private void UC_Schedule_Load(object sender, EventArgs e)
        {
            // style fornt of data grid cell and header
            this.dgvShift.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dgvShift.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);

            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";


            sqlShift = @"select * from EmployeeShift";
            daShift = new SqlDataAdapter(sqlShift, connStr);
            cmbBShift = new SqlCommandBuilder(daShift);
            daShift.FillSchema(dsFujitsuPayments, SchemaType.Source, "EmployeeShift");
            daShift.Fill(dsFujitsuPayments, "EmployeeShift");

            dgvShift.DataSource = dsFujitsuPayments.Tables["EmployeeShift"];
            // resize the datagridview columns to fit the newly loaded content
            dgvShift.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            frmAddShift frm = new frmAddShift();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Location = new Point(180, 100);
            this.Controls.Add(frm);
            frm.BringToFront();
        }

        private void lable5_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            if (dgvShift.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Shift from the list.", "Select Shift");
            }
            else
            {
                drShift = dsFujitsuPayments.Tables["EmployeeShift"].Rows.Find(dgvShift.SelectedRows[0].Cells[0].Value);

                string tempName = drShift["ShiftID"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete " + tempName + "details?", "Add Shift", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drShift.Delete();
                    daShift.Update(dsFujitsuPayments, "EmployeeShift");
                }
            }
        }
    }
}
