using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class AssetFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        SQLCONNECTION SQLCONN3 = new SQLCONNECTION();


        string AssetID;
        string AssetDetialsInfoID;
        int LoggedEmployeeID;
        string encryptionKey= "0pqnU2X00mf+i8mDTzyPVw==", iv= "0pqnU2X00mf+i8mDTzyPVw==";
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
        private void InitializeEncryptionParameters()
        {
            // Check if the key and IV are already initialized
            if (string.IsNullOrEmpty(encryptionKey) || string.IsNullOrEmpty(iv))
            {
                // If not initialized, generate new key and IV
                encryptionKey = GenerateRandomKey();
                iv = GenerateRandomIV();
            }
        }

        private void AssetFrm_Load(object sender, EventArgs e)
        {



            this.timer1.Interval = 1000;
            timer1.Start();

            lblusername.Text = CommonClass.LoginUserName;
            lblemail.Text = CommonClass.Email;
            LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;
            SQLCONN.OpenConection3();
            cmbtype.ValueMember = "AssetTypeID";
            cmbtype.DisplayMember = "AssettypeValue";
            cmbtype.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT AssetTypeID,AssettypeValue FROM AssetType");
            cmbdeviceatt.ValueMember = "DeviceDetilasID";
            cmbdeviceatt.DisplayMember = "DeviceDetialsValue";
            cmbdeviceatt.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT DeviceDetilasID ,DeviceDetialsValue FROM DeviceDetials ");

            SQLCONN.CloseConnection();
          //  InitializeEncryptionParameters();
          

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
            cmbtype.Text = "Select";
            cmbbrand.Text = "";
            Assetmodeltxt.Text = "";
            AssetIDTXT.Text = "";
            txtvalue.Text = "";
            txtsapid.Text = txtSN.Text = "";
            tabControl2.TabPages[0].ForeColor = Color.Black; // Adjust the color as needed
            dataGridView1.DataSource = null;
            dataGridView5.DataSource = null;
        }

        public int GetNextIDForAssetType(int assetTypeID)
        {
            assetTypeID = (int)cmbtype.SelectedValue;
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=192.168.1.8;Initial Catalog=DelmonGroupAssests;User ID=sa;password=Ram72763@"))
            {
                sqlConnection.Open();

                string maxIDQuery = "SELECT MAX(AssetID) FROM Assets WHERE Type = @AssetTypeID";

                using (SqlCommand cmd = new SqlCommand(maxIDQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@AssetTypeID", assetTypeID);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        string maxIDStr = result.ToString();

                        // Extract the numeric part of the AssetID
                        string numericPart = new String(maxIDStr.Where(Char.IsDigit).ToArray());

                        int maxID;
                        if (int.TryParse(numericPart, out maxID))
                        {
                            return maxID + 1;
                        }
                    }

                    return 1;
                }
            }
        }


        public static string GenerateAssetID(int assetTypeID, int nextID)
        {
            string prefix = GetPrefixForAssetType(assetTypeID);
            string formattedID = nextID.ToString("D4");

            return $"{prefix}{formattedID}";
        }

        public static string GetPrefixForAssetType(int assetTypeID)
        {
            switch (assetTypeID)
            {
                case 1:
                    return "PC";
                case 2:
                    return "PR";
                case 3:
                    return "Mo";
                case 4:
                    return "SR";
                case 5:
                    return "SC";
                case 6:
                    return "SW";
                case 7:
                    return "TL";
                case 8:
                    return "FP";
              
                default:
                    throw new ArgumentException("Unsupported asset type");

            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramcmbtype = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcmbtype.Value = cmbtype.SelectedValue;
            SqlParameter paramcmbrand = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramcmbrand.Value = cmbbrand.SelectedValue;
            SqlParameter paramassetmodel = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramassetmodel.Value = Assetmodeltxt.Text;
            SqlParameter paramSAPAssetid = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramSAPAssetid.Value = txtsapid.Text;
            SqlParameter paramSN = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramSN.Value = txtSN.Text;



            int assetTypeID = (int)cmbtype.SelectedValue; // Make sure to use the correct value
            int nextID = GetNextIDForAssetType(assetTypeID);

            // Use the generated asset ID

            string  generatedAssetID = GenerateAssetID(assetTypeID, nextID);

            SqlParameter paramgeneratedAssetID = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramgeneratedAssetID.Value = generatedAssetID;



            SqlDataReader dr;
            
                if ((int)cmbtype.SelectedValue != 0 && (int)cmbbrand.SelectedValue != 0 && Assetmodeltxt.Text != "")
                {
                    SQLCONN3.OpenConection3();
                    dr = SQLCONN3.DataReader("select  * from Assets  where " +
                        " brand=@C2 and model = @C3", paramcmbrand, paramassetmodel);
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


                            SQLCONN3.ExecuteQueries("insert into Assets ( [AssetID],[type],[brand],[model],[SapAssetID],[SN] ) values (@C0,@C1,@C2,@C3,@C4,@C5)",
                                                         paramgeneratedAssetID, paramcmbtype, paramcmbrand, paramassetmodel, paramSAPAssetid, paramSN);
                            MessageBox.Show("Record saved Successfully");

                            btnnew.Visible = true;



                            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"
                             select Assets.AssetID,Assets.SapAssetId,Assets.sn ,AssetType.AssettypeValue, AssetBrand.AssetBrandValue,Assets.Model
from Assets ,AssetBrand,AssetType
  where  Brand = AssetBrand.AssetBrandID
  and Assets.Type = AssetType.AssetTypeID and type= @C1 and brand=@C2 and model=@C3", paramcmbtype, paramcmbrand, paramassetmodel);




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
            
         
            SQLCONN3.CloseConnection();
            cmbtype.Text = cmbbrand.Text = "Select";
            Assetmodeltxt.Text = "";
        }

        private void seratchassettxt_TextChanged(object sender, EventArgs e)
        {
          
                tabControl2.TabPages[0].ForeColor = Color.Black; // Adjust the color as needed

                SqlParameter paramAssetSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramAssetSearch.Value = seratchassettxt.Text;
            SQLCONN3.OpenConection3();
         
      

            string query = @"
    SELECT Assets.AssetID, Assets.SapAssetId, Assets.sn, AssetType.AssettypeValue, AssetBrand.AssetBrandValue, Assets.Model
    FROM Assets
    INNER JOIN AssetBrand ON Assets.Brand = AssetBrand.AssetBrandID
    INNER JOIN AssetType ON Assets.Type = AssetType.AssetTypeID
    WHERE Assets.Model LIKE '%' + @C1 + '%';";

            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramAssetSearch);



            SQLCONN3.CloseConnection();
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addbtn.Visible = false;
            btnnew.Visible = updatebtn.Visible = deletebtn.Visible = true;
            if (e.RowIndex == -1) return;

            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {

                        AssetID = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        AssetIDTXT.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtsapid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtSN.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbtype.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        cmbbrand.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        Assetmodeltxt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();


                    






                    }
                }

            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramcmbtype = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcmbtype.Value = cmbtype.SelectedValue;
            SqlParameter paramcmbrand = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramcmbrand.Value = cmbbrand.SelectedValue;
            SqlParameter paramassetmodel = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramassetmodel.Value = Assetmodeltxt.Text;
            SqlParameter paramSAPAssetid = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramSAPAssetid.Value = txtsapid.Text;
            SqlParameter paramSN = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramSN.Value = txtSN.Text;
            SqlParameter paramIDD = new SqlParameter("@idd", SqlDbType.NVarChar);
            paramIDD.Value = AssetID;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = CommonClass.EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            if (AssetID != null)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    if (cmbtype.Text == "Select")

                    {
                        MessageBox.Show("Please Select a Type !!");


                    }
                    else if (cmbbrand.Text == "")
                    {
                        MessageBox.Show("Please Select Brand !!");
                    }
                    else if (Assetmodeltxt.Text == "")

                    {
                        MessageBox.Show("Please insert Asset Model !!");


                    }
                  
                    else
                    {
                        SQLCONN3.OpenConection3();
                        SQLCONN.OpenConection3();

                        // MessageBox.Show(EMPID.ToString());

                        /**logtable */
                     

                        if ((int)cmbtype.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set brand=@C2,model=@C3,SAPAssetId=@C4,Sn=@C5 where  AssetID=@idd  ", paramIDD, paramcmbrand, paramassetmodel,paramSAPAssetid,paramSN);

                        }
                        else if ((int)cmbbrand.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set type=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 where  AssetID=@idd  ", paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN);

                        }

                        else 
                        {
                            SQLCONN3.ExecuteQueries("update Assets set type=@C1,brand=@C2,model=@C3,SAPAssetId=@C4,Sn=@C5 where  AssetID=@idd  ", paramIDD, paramcmbtype, paramcmbrand, paramassetmodel,paramSAPAssetid,paramSN);

                        }

                           MessageBox.Show("Record Updated Successfully");
                        // dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],NewID,StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate],[UserID],[DatetimeLog]  FROM[DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and  NEWID = @C14  ", paramNewID);
                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"
                             select Assets.AssetID,Assets.SapAssetId,Assets.sn ,AssetType.AssettypeValue, AssetBrand.AssetBrandValue,Assets.Model
from Assets ,AssetBrand,AssetType
  where  Brand = AssetBrand.AssetBrandID
  and Assets.Type = AssetType.AssetTypeID and type= @C1 and brand=@C2 and model=@C3", paramcmbtype, paramcmbrand, paramassetmodel);




                        SQLCONN.CloseConnection();
                    }

                }
                else
                {
                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
                tabControl1.Enabled = false;
            }
            SQLCONN.CloseConnection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbldatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramIDD = new SqlParameter("@idd", SqlDbType.NVarChar);
            paramIDD.Value = AssetID;

            if (AssetID == null)
            {
                MessageBox.Show("Please select  Asset first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();
                    SQLCONN3.ExecuteQueries("delete  Assets where AssetID=@idd", paramIDD);
                   // SQLCONN3.ExecuteQueries(" declare @max int select @max = max([AssetID]) from [Assets] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[Assets]', RESEED, @max)");
                    dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("select * from Assets where AssetID=@idd", paramIDD);
                    MessageBox.Show("Record has been deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbtype.Text = "Select";
                    cmbbrand.Text = "";
                    Assetmodeltxt.Text = "";
                    AssetIDTXT.Text = "";
                    txtsapid.Text = txtSN.Text = "";
                    tabControl2.TabPages[0].ForeColor = Color.Black; // Adjust the color as needed
                    SQLCONN3.CloseConnection();
                    //cmbtype.Text = "Select";
                    //cmbbrand.Text = "";
                    //Assetmodeltxt.Text = "";
                    //AssetIDTXT.Text = "";
                    //txtsapid.Text = txtSN.Text = "";



                }

            }
        }

        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            SQLCONN3.OpenConection3();
            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetID;
            if (AssetID ==null)
            {
                MessageBox.Show("Please Choose A Record !  ");

            }
            else
            {
                if (tabControl2.SelectedTab == tabControl2.TabPages[0])
                {

                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@" select 
Assets.AssetID,
DeviceDetials.DeviceDetilasID,
 DeviceDetials.DeviceDetialsValue,AssetsDetials.Value
from Assets,AssetsDetials,DeviceDetials
where 
  DeviceDetials.DeviceDetilasID= AssetsDetials.DeviceDetilasID
 and Assets.AssetID= AssetsDetials.AssetID
 and Assets.AssetID=@ID ", paramID);
                                     
                    cmbdeviceatt.Text = "Select";
                    txtvalue.Text = "";
                    dataGridView5.Columns[0].Visible = false;
                    dataGridView5.Columns[1].Visible = false;
                    dataGridView5.Columns[3].Width = 200;
                    dataGridView5.Columns[2].Width = 200;
                }
            


            }
            SQLCONN3.CloseConnection();

        }

        static string GenerateRandomKey()
        {
            byte[] keyBytes = new byte[32]; // 256 bits for AES-256
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }
            return Convert.ToBase64String(keyBytes);
        }
        static string GenerateRandomIV()
        {
            byte[] ivBytes = new byte[16]; // 128 bits for AES
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(ivBytes);
            }
            return Convert.ToBase64String(ivBytes);
        }
        static string Encrypt(string input, string key, string iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(iv);

                // Set the padding mode
                aesAlg.Padding = PaddingMode.PKCS7;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        static string Decrypt(string input, string key, string iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(iv);

                // Set the padding mode
                aesAlg.Padding = PaddingMode.PKCS7;

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(input)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (AssetID != string.Empty & (int)cmbdeviceatt.SelectedValue!=0)
            {
                SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
                paramDeviceatt.Value = cmbdeviceatt.SelectedValue;

                SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
                paramValue.Value = txtvalue.Text;

                SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
                paramID.Value = AssetID;

                         if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();

                  //  SqlDataReader dr = SQLCONN3.DataReader("select * from [AssetDetialsInfo] where  AssetDetailsID= " + AssetDetialsID + " and DeviceDetilasID= " + cmbdeviceatt.SelectedValue + " and value= " + txtvalue.Text + " ");
                    SqlDataReader dr = SQLCONN3.DataReader("select * from [AssetsDetials] where  AssetID=@ID  and DeviceDetilasID=@C1  and value=@C2 ", paramID,paramDeviceatt,paramValue);

                    dr.Read();

                    if (dr.HasRows)
                    {
                        MessageBox.Show("This ' Value For This Asset '  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    else
                    {
                        dr.Dispose();
                        dr.Close();

                        if (cmbdeviceatt.SelectedValue != null && (int)cmbdeviceatt.SelectedValue == 21)
                        {
                            string originalValue = txtvalue.Text.ToString();

                            // Generate a random encryption key and IV
                         
                            string encryptedValue = Encrypt(originalValue, encryptionKey, iv);

                            paramValue.Value = encryptedValue;
                            // Use the encryptedValue as needed

                            // In a real-world scenario, store the encryptionKey and iv securely for later decryption
                        }


                        else { paramValue.Value = txtvalue.Text; }

                        SQLCONN3.ExecuteQueries("insert into AssetsDetials (AssetID,DeviceDetilasID,Value) values (@ID,@C1,@C2)",
                                                   paramID, paramDeviceatt, paramValue);
                        MessageBox.Show("Record saved Successfully");
                        cmbdeviceatt.SelectedValue = 0;
                        txtvalue.Text = "";


                        dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"  select 
Assets.AssetID,
DeviceDetials.DeviceDetilasID,
 DeviceDetials.DeviceDetialsValue,AssetsDetials.Value
from Assets,AssetsDetials,DeviceDetials
where 
  DeviceDetials.DeviceDetilasID= AssetsDetials.DeviceDetilasID
 and Assets.AssetID= AssetsDetials.AssetID
 and Assets.AssetID=@ID ", paramID);

                        //  this.dataGridView5.Columns["AssetDetailsID"].Visible = false;
                        //dataGridView5.Columns[6].Width = 200;
                        //dataGridView5.Columns[5].Width = 200;
                        //dataGridView5.Columns[4].Width = 200;
                        //dataGridView5.Columns[3].Width = 200;
                        //dataGridView5.Columns[1].Width = 200;
                        //dataGridView5.Columns[0].Width = 200;
                        //// ClearTextBoxes();
                        cmbdeviceatt.Text = "Select";
                        txtvalue.Text = "";
                        SQLCONN3.CloseConnection();

                    }
                }
                else
                {

                }
            //    paramemployee.Value = EmployeeID;
            }
            else
            {
                MessageBox.Show("Please Select Record or Device attribute!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
            paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramValue.Value = txtvalue.Text;
            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetID;


            if (AssetID!= string.Empty  && ((int)cmbdeviceatt.SelectedValue !=0))
            {
             

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();


                    if (cmbdeviceatt.SelectedValue != null && (int)cmbdeviceatt.SelectedValue == 21)
                    {
                        string originalValue = txtvalue.Text.ToString();

                        // Generate a random encryption key and IV

                        string encryptedValue = Encrypt(originalValue, encryptionKey, iv);

                        paramValue.Value = encryptedValue;
                        // Use the encryptedValue as needed
                        MessageBox.Show(paramValue.Value.ToString());

                        // In a real-world scenario, store the encryptionKey and iv securely for later decryption
                    }


                    else { paramValue.Value = txtvalue.Text; }





                        SQLCONN3.ExecuteQueries("update  AssetsDetials set AssetID=@ID,DeviceDetilasID=@C1,Value=@C2 where AssetID=@ID and DeviceDetilasID=@C1 ",
                                                     paramID, paramDeviceatt, paramValue);

                          MessageBox.Show("Record updated Successfully");
                        cmbdeviceatt.SelectedValue = 0;
                        txtvalue.Text = "";


                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"  select 
Assets.AssetID,
DeviceDetials.DeviceDetilasID,
 DeviceDetials.DeviceDetialsValue,AssetsDetials.Value
from Assets,AssetsDetials,DeviceDetials
where 
  DeviceDetials.DeviceDetilasID= AssetsDetials.DeviceDetilasID
 and Assets.AssetID= AssetsDetials.AssetID
 and Assets.AssetID=@ID ", paramID);

                    // this.dataGridView5.Columns["AssetDetailsID"].Visible = false;
                    //dataGridView5.Columns[6].Width = 200;
                    //dataGridView5.Columns[5].Width = 200;
                    //dataGridView5.Columns[4].Width = 200;
                    //dataGridView5.Columns[3].Width = 200;
                    //dataGridView5.Columns[1].Width = 200;
                    //dataGridView5.Columns[0].Width = 200;
                    //// ClearTextBoxes();
                    cmbdeviceatt.Text = "Select";
                        txtvalue.Text = "";
                        SQLCONN3.CloseConnection();

                    }
               
                else
                {

                }
                //    paramemployee.Value = EmployeeID;
            }
            else
            {
                MessageBox.Show("Please Select Record !!");
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell clickedCell = dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex];

            addbtn.Visible = false;
            btnnew.Visible = updatebtn.Visible = deletebtn.Visible = true;
            if (e.RowIndex == -1) return;

            foreach (DataGridViewRow rw in this.dataGridView5.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {

                        AssetDetialsInfoID = (dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString());
                        cmbdeviceatt.Text = dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtvalue.Text = dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString();


                    }


                    string cellValue = clickedCell.Value?.ToString();

                    // Check if the value in the first column is 'OS_Key'
                    if (string.Equals(cellValue, "OS_Key", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            string encryptedValue = dataGridView5.Rows[e.RowIndex].Cells[3].Value?.ToString();

                            // Decrypt the value using the stored key and IV
                            string decryptedValue = Decrypt(encryptedValue, encryptionKey, iv);

                            txtvalue.Text = decryptedValue;
                            // The first column has the value 'OS_Key'
                            // Add your logic here
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.ToString());
                        }

                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter paramID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramID.Value = AssetID;
            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
            paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramValue.Value = txtvalue.Text;




            if (AssetDetialsInfoID == string.Empty)
            {
                MessageBox.Show("Please select  Asset first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();
                    SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id and DeviceDetilasID = @C1 and value = @C2 ", paramID, paramDeviceatt, paramValue);
             
                    
                    //dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("select * from AssetsDetials where AssetID=@id and DeviceDetilasID=@C1 and value=@C2 "
                    //   , paramID,paramDeviceatt,paramValue);

                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@" select 
Assets.AssetID,
DeviceDetials.DeviceDetilasID,
 DeviceDetials.DeviceDetialsValue,AssetsDetials.Value
from Assets,AssetsDetials,DeviceDetials
where 
  DeviceDetials.DeviceDetilasID= AssetsDetials.DeviceDetilasID
 and Assets.AssetID= AssetsDetials.AssetID
 and Assets.AssetID=@ID ", paramID);
                    MessageBox.Show("Record has been deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN3.CloseConnection();
                    cmbtype.Text = "Select";
                    cmbbrand.Text = "";
                    Assetmodeltxt.Text = "";
                    txtvalue.Text = "";



                }

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtsapid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSN.Focus();
                e.Handled = true;
               
            }
       
        }

        private void txtSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbtype.Focus();
                e.Handled = true;

            }
        }

        private void cmbtype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbbrand.Focus();
                e.Handled = true;

            }
        }

       
        private void cmbbrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Assetmodeltxt.Focus();
                e.Handled = true;

            }
        }


    }
}

