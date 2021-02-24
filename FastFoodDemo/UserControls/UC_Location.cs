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
    public partial class UC_Location : UserControl
    {


        // database connectors
        SqlDataAdapter daLocation;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBLocation;
        DataRow drLocation;
        String connStr, sqlLocation;

        // Static varibales to pass to form's
        public static int selectedTab = 0;
        public static bool locSelected = false;
        public static int locNoSelected = 0;


        public UC_Location()
        {
            InitializeComponent();

        }

        private void UC_Location_Load(object sender, EventArgs e)
        {
            // style fornt of data grid cell and header
            this.dgvLocation.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dgvLocation.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);



            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";

            sqlLocation = @"select * from OfficeLocation";
            daLocation = new SqlDataAdapter(sqlLocation, connStr);
            cmbBLocation = new SqlCommandBuilder(daLocation);
            daLocation.FillSchema(dsFujitsuPayments, SchemaType.Source, "OfficeLocation");
            daLocation.Fill(dsFujitsuPayments, "OfficeLocation");

            dgvLocation.DataSource = dsFujitsuPayments.Tables["OfficeLocation"];
            // resize the datagridview columns to fit the newly loaded content
            dgvLocation.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnEditLocation_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dgvLocation.SelectedRows.Count == 0)
            {
                locSelected = false;
                locNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select Location");
            }
            else if (dgvLocation.SelectedRows.Count > 1)
            {
                locSelected = false;
                locNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select Location");

            }
            else if (dgvLocation.SelectedRows.Count == 1)
            {
                locSelected = true;
                locNoSelected = Convert.ToInt32(dgvLocation.SelectedRows[0].Cells[0].Value);

                frmEditLocation frm = new frmEditLocation();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Visible = true;
                frm.Location = new Point(180, 100);
                this.Controls.Add(frm);
                frm.BringToFront();
            }
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (dgvLocation.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Office Location from the list.", "Select Office Location");
            }
            else
            {
                drLocation = dsFujitsuPayments.Tables["OfficeLocation"].Rows.Find(dgvLocation.SelectedRows[0].Cells[0].Value);

                string tempName = drLocation["LocationName"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete " + tempName + "details?", "Add Account", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    drLocation.Delete();
                    daLocation.Update(dsFujitsuPayments, "OfficeLocation");
                }
            }
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            frmAddLocation frm = new frmAddLocation();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Location = new Point(180, 100);
            this.Controls.Add(frm);
            frm.BringToFront();
        }
    }
}
