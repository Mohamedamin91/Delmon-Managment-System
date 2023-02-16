using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class FrmAgencyNew : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        public string pc, username, datetime = "";
        // In your code for FrmAgencyNew.cs
        public FrmAgencyNew()
        {
            InitializeComponent();
            // Get the label values from the EmployeeForm
         

        }

        private void addbtn_Click(object sender, EventArgs e)
        {

            SqlParameter paramagencyname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramagencyname.Value = AgencyNametxt.Text;
            SqlParameter paramlicensenumber = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramlicensenumber.Value = LicenseNumbertxt.Text;
            SqlParameter paramcountry = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramcountry.Value = cmbCountry.SelectedValue;
            SqlParameter paramcity = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramcity.Value = cmbCity.SelectedValue;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = username;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = datetime;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = pc;

            SqlParameter paramAgencyid  = new SqlParameter("@id", SqlDbType.NVarChar);


         



            if (AgencyNametxt.Text != "" && AgencyNametxt.Text != "" && LicenseNumbertxt.Text != "")
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  * from Agencies  where " +
                     " AgenceName=  @C1 and    LicenseNumber =  @C2 ", paramagencyname, paramlicensenumber);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Agency'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    dr.Dispose();
                    dr.Close();
                    SQLCONN.ExecuteQueries("insert into Agencies (  [AgenceName] ,[LicenseNumber],[CountryID],[CityID]) values (@C1,@C2,@C3,@C4)",
                                                   paramagencyname, paramlicensenumber, paramcountry, paramcity);
                    MessageBox.Show("Record saved Successfully");
                  
                    //SqlDataReader dr2 =  SQLCONN.DataReader("select  max (AgencID) as 'ID' from Agencies ");
                    //dr2.Read();

                    //if (dr2.HasRows)
                    //{
                    //    string AgecnyID = dr2["ID"].ToString();

                    //    paramAgencyid.Value = AgecnyID;
                    //}
                    //dr2.Dispose();
                    //dr2.Close();


                  //  SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (Logvalueid, logvalue ,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES (@id, 'Agency Info' ,'#','#',@datetime,@pc,@user,'Insert')", paramAgencyid, paramdatetimeLOG, parampc, paramuser);

                    //dr = SQLCONN.DataReader("SELECT PI_ID FROM PersonalInformation WHERE PI_ID = (SELECT MAX(PI_ID) FROM PersonalInformation)");
                    //dr.Read();
                    //PI_ID = int.Parse(dr["PI_ID"].ToString());
                    dr.Dispose();
                    dr.Close();



                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Fill the missing fields  ");

            }
            SQLCONN.CloseConnection();
        }

        private void FrmAgencyNew_Load(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();


            cmbCountry.ValueMember = "CountryId";
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT CountryId,CountryName FROM Countries");


            //cmbCity.ValueMember = "Job_Grade_ID";
            //cmbCity.DisplayMember = "Job_Grade_Name";
            //cmbCity.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Job_Grade_ID,Job_Grade_Name FROM JobGrades");

            SQLCONN.CloseConnection();
        }

        private void AgencyNametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCountry.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                AgencyNametxt.Text = textInfo.ToTitleCase(AgencyNametxt.Text);
            }
        }

        private void cmbCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCity.Focus();
                e.Handled = true;
                
            }
        }

        private void cmbCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LicenseNumbertxt.Focus();
                e.Handled = true;
               
            }
        }

        private void LicenseNumbertxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addbtn.Focus();
                e.Handled = true;

            }
        }

        private void cmbCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [ConsulateID],ConsulateCity FROM [DelmonGroupDB].[dbo].[Consulates] where  CountryId=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbCountry.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbCity.ValueMember = "ConsulateID";
                cmbCity.DisplayMember = "ConsulateCity";
                cmbCity.DataSource = dt;
                cmbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCity.AutoCompleteSource = AutoCompleteSource.ListItems;





            }

            conn.Close();
        }
    }
}
