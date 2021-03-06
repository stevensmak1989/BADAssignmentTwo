﻿using FujitsuPayments.Forms;
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

namespace FujitsuPayments.UserControls
{
    public partial class UC_Project : UserControl
    {
        //database connectors
        SqlDataAdapter daProject;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBProject;
        DataRow drProject;
        String connStr, sqlProject;

        //holds the value of the project id
        public static int selectedTab = 0;
        public static bool prjSelected = false;
        public static int prjNoSelected = 0;
       


        public UC_Project()
        {
            InitializeComponent();
        }
        //called when the form loads
        private void UC_Project_Load(object sender, EventArgs e)
        {
            // style fornt of data grid cell and header
            this.dvgProject.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dvgProject.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);


            //selects all project details from the database
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlProject = @"select * from Project";
            daProject = new SqlDataAdapter(sqlProject, connStr);
            cmbBProject = new SqlCommandBuilder(daProject);
            daProject.FillSchema(dsFujitsuPayments, SchemaType.Source, "Project");
            daProject.Fill(dsFujitsuPayments, "Project");

            //stores the data in the data grid
            dvgProject.DataSource = dsFujitsuPayments.Tables["Project"];
            // resize the datagridview columns to fit the newly loaded content
            //dvgProject.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

   
        //is called when the save button is pressed
        private void btnProjectAdd_Click(object sender, EventArgs e)
        {
            //initialises the add form and sets the position
            frmAddProject frm = new frmAddProject();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(190, 110);
            frm.ShowDialog();
        }

       

     

        private void btnProjectEdit_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgProject.SelectedRows.Count == 0)
            {
                prjSelected = false;
                prjNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select Project");
            }
            // condition to check if more than on row has been selected to pass to edit form
            else if (dvgProject.SelectedRows.Count > 1)
            {
                prjSelected = false;
                prjNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select Project");

            }
            
            else if (dvgProject.SelectedRows.Count == 1)
            {
                //sets the project no to the datagrid value selected
                prjSelected = true;
                prjNoSelected = Convert.ToInt32(dvgProject.SelectedRows[0].Cells[0].Value);

                //initialises the form 
                frmEditProject frm = new frmEditProject();
                
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Location = new Point(180, 100);
                frm.ShowDialog();
            }
        }

     

       

        private void btnProjectDel_Click_1(object sender, EventArgs e)
        {
            if (dvgProject.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Project from the list.", "Select Project");
            }
            else
            {
                drProject = dsFujitsuPayments.Tables["Project"].Rows.Find(dvgProject.SelectedRows[0].Cells[0].Value);

                string tempName = drProject["ProjDesc"].ToString();

                if (MessageBox.Show("Are you sure you want to delete project " + tempName + "?", "Delete Project", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        drProject.Delete();
                        daProject.Update(dsFujitsuPayments, "Project");
                    }
                    
                    catch (SqlException ex)
                    {
                    MessageBox.Show("Cannot delete a Project that has related records, please delete all related records first", "Delete Project");
                     }
                // update grid and clear errors
                       UC_Project_Load(sender, e);
                         drProject.ClearErrors();
            }
            }
        }

   
    }
}
