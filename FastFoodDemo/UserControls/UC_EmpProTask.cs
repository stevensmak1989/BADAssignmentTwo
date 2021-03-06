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
    public partial class UC_EmpProTask : UserControl
    {
        SqlDataAdapter daEmpTask;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBempTask;
        DataRow drEmpTask;
        String connStr, sqlEmpTask;

        public static int selectedTab = 0;
        public static bool tskSelected = false;
        public static int tskNoSelected = 0, prjNoSelected = 0, empNoSelected =0;

        private void btnEmpTaskDel_Click(object sender, EventArgs e)
        {//checks if a user slected a row
            if (dvgEmpTask.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Project from the list.", "Select ProjectTask");
            }
            else
            {
                //creates the object for the primary key values
                object[] primaryKey = new object[3];

                //adds project, task and employee from datagrid
                tskNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[1].Value);
                prjNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[0].Value);
                empNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[2].Value);


                primaryKey[0] = Convert.ToInt32(UC_EmpProTask.prjNoSelected);
                primaryKey[1] = Convert.ToInt32(UC_EmpProTask.tskNoSelected);
                primaryKey[2] = Convert.ToInt32(UC_EmpProTask.empNoSelected);

                //finds the record based on pk values
                drEmpTask = dsFujitsuPayments.Tables["ProjectTaskEmployee"].Rows.Find(primaryKey);



                string tempTask = drEmpTask["TaskID"].ToString();
                string tempName = drEmpTask["EmployeeID"].ToString();
                string tempProj = drEmpTask["ProjectID"].ToString();

                // asks the user if they would confirm the delete
                if (MessageBox.Show("Are you sure you want to delete Project Task: " + tempProj +"/"+ tempTask + "for employee ID: "+ tempName+ "?", "Delete Task", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //tries to delete the record
                    try
                    {
                        drEmpTask.Delete();
                        daEmpTask.Update(dsFujitsuPayments, "ProjectTaskEmployee");
                    }
                    //if the task has records assigned it will not update
                    catch (SqlException )
                    {
                        MessageBox.Show("Cannot delete a Project Task that has related records, please delete all related records first", "Delete Project Task");
                    }
                    // update grid and clear errors
                    UC_EmpProTask_Load (sender, e);
                    //drTask.ClearErrors();
                }
            }
        }

        private void btnEmpTaskEdit_Click(object sender, EventArgs e)
        {
            // condition to check if a row has been selected to pass to edit form
            if (dvgEmpTask.SelectedRows.Count == 0)
            {
                tskSelected = false;
                tskNoSelected = 0;
                MessageBox.Show("Please select a record.", "Select ProjectTask");
            } // checks if more than one row selected
            else if (dvgEmpTask.SelectedRows.Count > 1)
            {
                tskSelected = false;
                tskNoSelected = 0;
                MessageBox.Show("Please select a single record, cannot edit multiple records", "Select ProjectTask");

            }

            else if (dvgEmpTask.SelectedRows.Count == 1)
            {
                tskSelected = true;
                //sets the variables to the datagrid values
                tskNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[1].Value);
                prjNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[0].Value);
                empNoSelected = Convert.ToInt32(dvgEmpTask.SelectedRows[0].Cells[2].Value);
                frmEditEmpTask frm = new frmEditEmpTask();
                frm.Location = new Point(180, 100);
                frm.FormBorderStyle = FormBorderStyle.None;

                frm.ShowDialog();
            }
        }

     

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UC_EmpProTask_Load(sender, e);
        }

        public void UC_EmpProTask_Load(object sender, EventArgs e)
        {
            this.dvgEmpTask.DefaultCellStyle.Font = new Font("Century Gothic", 9);
            this.dvgEmpTask.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);



            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = FujitsuPayments; Integrated Security = true";

            sqlEmpTask = @"select * from ProjectTaskEmployee";
            daEmpTask = new SqlDataAdapter(sqlEmpTask, connStr);
            cmbBempTask = new SqlCommandBuilder(daEmpTask);
            daEmpTask.FillSchema(dsFujitsuPayments, SchemaType.Source, "ProjectTaskEmployee");
            daEmpTask.Fill(dsFujitsuPayments, "ProjectTaskEmployee");

            dvgEmpTask.DataSource = dsFujitsuPayments.Tables["ProjectTaskEmployee"];
            // resize the datagridview columns to fit the newly loaded content
            //dvgProject.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        public UC_EmpProTask()
        {
            InitializeComponent();
           
        }
        //called when the add is selected
        private void btnEmpTaskAdd_Click(object sender, EventArgs e)
        {
            frmEmpTaskAdd frm = new frmEmpTaskAdd();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Visible = true;
            frm.Location = new Point(180, 100);
            this.Controls.Add(frm);
            frm.BringToFront();
        }
    }
}
