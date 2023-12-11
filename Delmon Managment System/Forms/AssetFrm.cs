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

namespace Delmon_Managment_System.Forms
{
    public partial class AssetFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        SQLCONNECTION SQLCONN3= new SQLCONNECTION();
        public AssetFrm()
        {
            InitializeComponent();
        }

        private void cmbemployee_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Generatebtn_Click(object sender, EventArgs e)
        {

        }

        private void AssetFrm_Load(object sender, EventArgs e)
        {

            SQLCONN.OpenConection3();
            cmbtype.ValueMember = "AssetTypeID";
            cmbtype.DisplayMember = "AssettypeValue";
            cmbtype.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT AssetTypeID,AssettypeValue FROM AssetType");
            SQLCONN.CloseConnection();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            lblusername.Text = CommonClass.LoginUserName;
          //  lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
           // LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;
        }

        private void cmbtype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupAssests;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT [AssetBrandID],[AssetBrandValue] FROM [DelmonGroupAssests].[dbo].[AssetBrand] where AssetTypeID=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbtype.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbbrand.ValueMember = "AssetBrandID";
                cmbbrand.DisplayMember = "AssetBrandValue";
                cmbbrand.DataSource = dt;
                cmbbrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbbrand.AutoCompleteSource = AutoCompleteSource.ListItems;





            }

            conn.Close();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            addbtn.Visible = true;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramcmbtype = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcmbtype.Value = cmbtype.SelectedValue;
            SqlParameter paramcmbrand = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramcmbrand.Value = cmbbrand.SelectedValue;
            SqlParameter paramassetmodel = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramassetmodel.Value = Assetmodeltxt.Text;



            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = CommonClass.EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            SqlDataReader dr, dr2;
            if ((int)cmbtype.SelectedValue != 0 && (int)cmbbrand.SelectedValue != 0 && Assetmodeltxt.Text != "")
            {
                SQLCONN.OpenConection();
                SQLCONN3.OpenConection3();
                dr = SQLCONN.DataReader("select  * from AssetDetials  where " +
                    " brand=@C2 or model = @C3", paramcmbrand, paramassetmodel);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Asset'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        dr.Dispose();
                        dr.Close();
                     
                         
                        SQLCONN3.ExecuteQueries("insert into AssetDetials ( [type] ,[brand],[model]) values (@C1,@C2,@C3)",
                                                     paramcmbtype, paramcmbrand, paramassetmodel);
                            MessageBox.Show("Record saved Successfully");

                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Asset Info',@C1 ,'#','#',@datetime,@pc,@user,'Insert')", paramassetmodel, paramdatetimeLOG, parampc, paramuser);
                            btnnew.Visible = true;

                       
                   
                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from AssetDetials where type= @C1 and brand=@C2 and model=@C3", paramcmbtype, paramcmbrand, paramassetmodel);





                    }
                    else
                    {

                        dr.Dispose();
                        dr.Close();
                    }
                }



            }
            else
            {
                MessageBox.Show("Please Fill the missing fields  ");

            }
            SQLCONN.CloseConnection();
            SQLCONN3.CloseConnection();
            cmbtype.Text = cmbbrand.Text = "Select";
            Assetmodeltxt.Text = "";
        }

        private void seratchassettxt_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramAssetSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramAssetSearch.Value = Assetmodeltxt.Text;
            SQLCONN3.OpenConection3();
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"

  select AssetDetials.AssetDetailsID AssetDetailsID, AssetBrand.AssetBrandValue,AssetDetials.Model from AssetDetials ,AssetBrand
  where  Brand=AssetBrand.AssetBrandID", paramAssetSearch);
            SQLCONN3.CloseConnection();


        }
    }
}
