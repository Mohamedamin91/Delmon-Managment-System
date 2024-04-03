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
    public partial class FrmNewModel : Form
    {
        SQLCONNECTION SQLCONN3 = new SQLCONNECTION();


        public FrmNewModel()
        {
            InitializeComponent();

        }

        private void frmNewModel_Load(object sender, EventArgs e)
        {
            SQLCONN3.OpenConection3();

            cmbtype.ValueMember = "AssetTypeID";
            cmbtype.DisplayMember = "AssettypeValue";
            cmbtype.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetTypeID,AssettypeValue FROM AssetType");
            cmbtype.Text = "Select";

        }

        private void cmbtype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupAssests;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            SqlCommand cmd1 = conn.CreateCommand();
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

        private void addbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramcmbtype = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcmbtype.Value = cmbtype.SelectedValue;
            SqlParameter paramcmbrand = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramcmbrand.Value = cmbbrand.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramValue.Value = txtvalue.Text;




            if (txtvalue.Text != "")
            {
                SQLCONN3.OpenConection3();
                SqlDataReader dr = SQLCONN3.DataReader("select * from AssetsModel where " +
                     " AssetModel =@C3 and AssetTypeID=@C1 and AssetBrandID=@C2 ", paramValue,paramcmbtype,paramcmbrand);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Model Name'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        dr.Dispose();
                        dr.Close();

                      
                        SQLCONN3.ExecuteQueries("insert into AssetsModel ([AssetModel] ,[AssetTypeID],[AssetBrandID]) values (@C3,@C1,@C2) ",
                                                       paramValue, paramcmbtype, paramcmbrand);
                        MessageBox.Show("Model saved Successfully");
                        // settingFrm.SettingFrm_Load(sender, e);
                        txtvalue.Text = "";
                        cmbbrand.Text = cmbtype.Text = "Select";
                        //  Asset.AssetFrm_Load(null, EventArgs.Empty);
                    }
                }

            }
            else
            {
                MessageBox.Show("Please Fill the missing field  ");

            }

            SQLCONN3.CloseConnection();
        }
       

        private void FrmNewModel_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmNewModel_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
