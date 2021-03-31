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

namespace FujitsuPayments.Forms
{
    public partial class frmAddLocation : Form
    {

        SqlDataAdapter daLocation;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBLocation;
        DataRow drLocation;
        String connStr, sqlLocation;

        public frmAddLocation()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAddLocation_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";

            sqlLocation = @"select * from OfficeLocation";
            daLocation = new SqlDataAdapter(sqlLocation, connStr);
            cmbBLocation = new SqlCommandBuilder(daLocation);
            daLocation.FillSchema(dsFujitsuPayments, SchemaType.Source, "OfficeLocation");
            daLocation.Fill(dsFujitsuPayments, "OfficeLocation");


            int noRows = dsFujitsuPayments.Tables["OfficeLocation"].Rows.Count;

            if (noRows == 0)
                txtLocationID.Text = "1000";
            else
            {
                getNumber(noRows);
            }
        }

        private void btnAddLocationClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddLocationSave_Click(object sender, EventArgs e)
        {
            //Location myLocation = new Location();

            // prevent nulls being entered or empty strings
            if (String.IsNullOrEmpty(txtLocationName.Text) || String.IsNullOrEmpty(txtStreet.Text) || String.IsNullOrEmpty(txtTown.Text) ||
                String.IsNullOrEmpty(txtCounty.Text) || String.IsNullOrEmpty(txtTelNo.Text) || String.IsNullOrEmpty(txtPostCode.Text))
            {
                MessageBox.Show("Please fill in all required fields!");
            }
            else
            {
                OfficeLocation myLocation = new OfficeLocation();
                bool ok = true;

                errP.Clear();

                // -----------  TRY CATCH INPUT VALIDATION -------------------- //
                try
                {
                    myLocation.LocationId = Convert.ToInt32(txtLocationID.Text.Trim()); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblLocationId, MyEx.toString());
                }
                try
                {
                    myLocation.LocationName = txtLocationName.Text.Trim(); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblLocationName, MyEx.toString());
                }
                try
                {
                    myLocation.Street = txtStreet.Text.Trim(); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblStreet, MyEx.toString());
                }
                try
                {
                    myLocation.Town = txtTown.Text.Trim(); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblTown, MyEx.toString());
                }
                try
                {
                    myLocation.County = txtCounty.Text.Trim(); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblCounty, MyEx.toString());
                }
                try
                {
                    myLocation.Postcode = txtPostCode.Text.Trim();// passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblPostCode, MyEx.toString());
                }
                try
                {
                    myLocation.TelNo = txtTelNo.Text.Trim();// passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(lblTelNo, MyEx.toString());
                }

                // ----------- END TRY CATCH INPUT VALIDATION -------------------- //
                try
                {
                    if (ok)
                    {
                        drLocation = dsFujitsuPayments.Tables["OfficeLocation"].NewRow();

                        drLocation["LocationID"] = myLocation.LocationId;
                        drLocation["LocationName"] = myLocation.LocationName;
                        drLocation["Street"] = myLocation.Street;
                        drLocation["Town"] = myLocation.Town;
                        drLocation["County"] = myLocation.County;
                        drLocation["Postcode"] = myLocation.Postcode;
                        drLocation["TelNo"] = myLocation.TelNo;


                        dsFujitsuPayments.Tables["OfficeLocation"].Rows.Add(drLocation);
                        daLocation.Update(dsFujitsuPayments, "OfficeLocation");

                        MessageBox.Show("Location Added");
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
            }
        }


        private void getNumber(int noRows)
        {
            drLocation = dsFujitsuPayments.Tables["OfficeLocation"].Rows[noRows - 1];
            txtLocationID.Text = (int.Parse(drLocation["LocationID"].ToString()) + 1).ToString();
        }
    }
}
