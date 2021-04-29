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
using FujitsuPayments.UserControls;

namespace FujitsuPayments.Forms
{

    public partial class frmEditLocation : Form
    {

        SqlDataAdapter daLocation;
        DataSet dsFujitsuPayments = new DataSet();
        SqlCommandBuilder cmbBLocation;
        DataRow drLocation;
        String connStr, sqlLocation;

        public frmEditLocation()
        {
            InitializeComponent();
        }

        private void frmEditLocation_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = fujitsuPayments; Integrated Security = true";
            sqlLocation = @"select * from OfficeLocation";
            daLocation = new SqlDataAdapter(sqlLocation, connStr);
            cmbBLocation = new SqlCommandBuilder(daLocation);
            daLocation.FillSchema(dsFujitsuPayments, SchemaType.Source, "OfficeLocation");
            daLocation.Fill(dsFujitsuPayments, "OfficeLocation");

            // Retrieve Location No from Location User Control
            txtEditLocationID.Text = UC_Location.locNoSelected.ToString();

            drLocation = dsFujitsuPayments.Tables["OfficeLocation"].Rows.Find(txtEditLocationID.Text);

            // populate fields on edit form
            txtEditLocationName.Text = drLocation["LocationName"].ToString();
            txtEditStreet.Text = drLocation["Street"].ToString();
            txtEditTown.Text = drLocation["Town"].ToString();
            txtEditCounty.Text = drLocation["County"].ToString();
            txtEditPostCode.Text = drLocation["PostCode"].ToString();
            txtEditTelNo.Text = drLocation["TelNo"].ToString();

        }
        private void btnEditLocationClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEditLocationSave_Click(object sender, EventArgs e)
        {
            // prevent nulls being entered or empty strings
            if (String.IsNullOrEmpty(txtEditLocationName.Text) && String.IsNullOrEmpty(txtEditStreet.Text) && String.IsNullOrEmpty(txtEditTown.Text) &&
                String.IsNullOrEmpty(txtEditCounty.Text) && String.IsNullOrEmpty(txtEditTelNo.Text) && String.IsNullOrEmpty(txtEditPostCode.Text))
            {
                MessageBox.Show("All fields must be filled in!");
            }
            else
            {
                OfficeLocation myLocation = new OfficeLocation();
                bool ok = true;

                errP.Clear();

                // -----------  TRY CATCH INPUT VALIDATION -------------------- //
                try
                {
                    myLocation.LocationId = Convert.ToInt32(txtEditLocationID.Text.Trim()); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditLocationID, MyEx.toString());
                }
                try
                {
                    myLocation.LocationName = txtEditLocationName.Text.Trim(); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditLocationName, MyEx.toString());
                }
                try
                {
                    myLocation.Street = txtEditStreet.Text.Trim(); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditStreet, MyEx.toString());
                }
                try
                {
                    myLocation.Town = txtEditTown.Text.Trim(); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditTown, MyEx.toString());
                }
                try
                {
                    myLocation.County = txtEditCounty.Text.Trim(); // passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditCounty, MyEx.toString());
                }
                try
                {
                    myLocation.Postcode = txtEditPostCode.Text.Trim();// passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditPostCode, MyEx.toString());
                }
                try
                {
                    myLocation.TelNo = txtEditTelNo.Text.Trim();// passed to Location class to check
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditTelNo, MyEx.toString());
                }


                try
                {
                    if (ok)
                    {
                        drLocation.BeginEdit();

                        drLocation["LocationID"] = myLocation.LocationId;
                        drLocation["LocationName"] = myLocation.LocationName;
                        drLocation["Street"] = myLocation.Street;
                        drLocation["Town"] = myLocation.Town;
                        drLocation["County"] = myLocation.County;
                        drLocation["Postcode"] = myLocation.Postcode;
                        drLocation["TelNo"] = myLocation.TelNo;

                        drLocation.EndEdit();
                        daLocation.Update(dsFujitsuPayments, "OfficeLocation");

                        MessageBox.Show("Location Details Updated", "Location");

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

        private void getNumber(int noRows) //function to count rows in table
        {
            drLocation = dsFujitsuPayments.Tables["OfficeLocation"].Rows[noRows - 1];
            txtEditLocationID.Text = (int.Parse(drLocation["LocationID"].ToString()) + 1).ToString();
        }



    }
}
