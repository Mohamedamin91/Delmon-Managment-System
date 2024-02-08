﻿using System;
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

        public void AssetFrm_Load(object sender, EventArgs e)
        {



            this.timer1.Interval = 1000;
            timer1.Start();

            lblusername.Text = CommonClass.LoginUserName;
            lblemail.Text = CommonClass.Email;
            LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;
            SQLCONN3.OpenConection3();
            SQLCONN.OpenConection();

            cmbemployee.ValueMember = "EmployeeID";
            cmbemployee.DisplayMember = "FullName";
            cmbemployee.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            cmbemployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbtype.ValueMember = "AssetTypeID";
            cmbtype.DisplayMember = "AssettypeValue";
            cmbtype.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetTypeID,AssettypeValue FROM AssetType");
            cmbtype.Text = "Select";
            
            cmbdeviceatt.ValueMember = "DeviceDetilasID";
            cmbdeviceatt.DisplayMember = "DeviceDetialsValue";
            cmbdeviceatt.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT DeviceDetilasID ,DeviceDetialsValue FROM DeviceDetials ");
            cmbdeviceatt.Text = "Select";

            cmbDevice.ValueMember = "DeviceTypeID";
            cmbDevice.DisplayMember = "DeviceType";
            cmbDevice.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT DeviceTypeID , DeviceType FROM DeviceTypes ");
            cmbDevice.Text = "Select";

            cmbAssetStatus.ValueMember = "AssetStatusID";
            cmbAssetStatus.DisplayMember = "AssetStatus";
            cmbAssetStatus.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetStatusID ,AssetStatus FROM AssetsStatus ");
            cmbAssetStatus.Text = "Select";

            cmbAssetModel.ValueMember = "AssetModeID";
            cmbAssetModel.DisplayMember = "AssetModel";
            cmbAssetModel.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetModeID ,AssetModel FROM AssetsModel ");
            cmbAssetModel.Text = "Select";

            cmbVersion.ValueMember = "OSVersionID";
            cmbVersion.DisplayMember = "OSVerisonValue";
            cmbVersion.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT OSVersionID ,OSVerisonValue FROM OSVerisons ");
            cmbVersion.Text = "Select";

            cmbbrand.ValueMember = "AssetBrandID";
            cmbbrand.DisplayMember = "AssetBrandValue";
            cmbbrand.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetBrandID ,AssetBrandValue FROM AssetBrand ");
            cmbbrand.Text = "Select";

            SQLCONN.CloseConnection();
            SQLCONN3.CloseConnection();
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
            SqlParameter paramAssetSearch = new SqlParameter("@C11", SqlDbType.NVarChar);
            paramAssetSearch.Value = cmbtype.SelectedValue;

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            SqlCommand cmd1= conn.CreateCommand();
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
                cmbbrand.Text = "Select";
                cmbAssetModel.Text = "Select";
            }
            if ((int)cmbtype.SelectedValue == 1 || (int)cmbtype.SelectedValue == 2 || (int)cmbtype.SelectedValue == 4)
            {
                string query2 = @"SELECT DeviceTypeID ,DeviceType FROM DeviceTypes where AssetTypeID= @C11";

                cmbDevice.ValueMember = "DeviceTypeID";
                cmbDevice.DisplayMember = "DeviceType";
                cmbDevice.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(query2, paramAssetSearch);
            }
            else
            {
                cmbDevice.Text = "Select";
            }

            conn.Close();
            //        SQLCONN3.OpenConection3();
            //        SqlParameter paramAssetSearch = new SqlParameter("@C11", SqlDbType.NVarChar);
            //        paramAssetSearch.Value = cmbtype.SelectedValue;

            //        string query = @"
            //SELECT Assets.AssetID, Assets.SapAssetId, Assets.sn, AssetType.AssettypeValue, AssetBrand.AssetBrandValue, Assets.Model
            //FROM Assets
            //INNER JOIN AssetBrand ON Assets.Brand = AssetBrand.AssetBrandID
            //INNER JOIN AssetType ON Assets.AssetTypeID = AssetType.AssetTypeID
            //WHERE AssetType.AssetTypeID=@C11 ;";
            //        dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(query, paramAssetSearch);
            //        dataGridView1.Columns[3].Width = 200;
            //        dataGridView1.Columns[4].Width = 200;
            //        dataGridView1.Columns[5].Width = 200;



            if ((int)cmbtype.SelectedValue == 1 || (int)cmbtype.SelectedValue == 2 || (int)cmbtype.SelectedValue == 4)
            {
                string query2 = @"SELECT DeviceTypeID ,DeviceType FROM DeviceTypes where AssetTypeID= @C11";

                cmbDevice.ValueMember = "DeviceTypeID";
                cmbDevice.DisplayMember = "DeviceType";
                cmbDevice.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(query2, paramAssetSearch);
                cmbDevice.Text = "Select";
            }
            else
            {
                cmbDevice.Text = "Select";
            }



            //        SQLCONN3.CloseConnection();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            addbtn.Visible = true;
            cmbtype.Text = "Select";
            cmbbrand.Text = "Select";
            cmbemployee.Text = "Select";
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

                string maxIDQuery = "SELECT MAX(AssetID) FROM Assets WHERE AssetTypeID = @AssetTypeID";

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
                    return "Bi";
              
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
            paramassetmodel.Value = cmbAssetModel.SelectedValue;
            SqlParameter paramSAPAssetid = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramSAPAssetid.Value = txtsapid.Text;
            SqlParameter paramSN = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramSN.Value = txtSN.Text;


            /*new update */
            SqlParameter paramPurchasingdate = new SqlParameter("@C6", SqlDbType.Date);
            paramPurchasingdate.Value = PurchasingDtp.Value;
            SqlParameter paramcmbDevice = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramcmbDevice.Value = cmbDevice.SelectedValue;
            SqlParameter paramcmbAssetStatus = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramcmbAssetStatus.Value = cmbAssetStatus.SelectedValue;
            /*new update */


            /*Asset Assign*/
            SqlParameter paramcmbAssignto = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramcmbAssignto.Value = cmbemployee.SelectedValue;
            SqlParameter paramAssigndate = new SqlParameter("@C10", SqlDbType.Date);
            paramAssigndate.Value = AssignDtp.Value;
            /*Asset Assign*/

            int assetTypeID = (int)cmbtype.SelectedValue; // Make sure to use the correct value
            int nextID = GetNextIDForAssetType(assetTypeID);

            // Use the generated asset ID

            string  generatedAssetID = GenerateAssetID(assetTypeID, nextID);

            SqlParameter paramgeneratedAssetID = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramgeneratedAssetID.Value = generatedAssetID;



            SqlDataReader dr;
            
                if ((int)cmbtype.SelectedValue != 0 && (int)cmbbrand.SelectedValue != 0 && (int)cmbAssetModel.SelectedValue != 0 
                && (int)cmbDevice.SelectedValue!=0 && (int) cmbAssetStatus.SelectedValue!=0 && txtSN.Text !=string.Empty)
                {
                SQLCONN3.OpenConection3();
                SQLCONN.OpenConection();
                dr = SQLCONN3.DataReader("select  * from Assets  where " +
                        " brand=@C2 and model = @C3 and sn= @C5", paramcmbrand, paramassetmodel,paramSN);
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


                            SQLCONN3.ExecuteQueries("insert into Assets ( [AssetID],[AssetTypeID],[brand],[model],[SapAssetID],[SN],[PurchasingDate],[DeviceTypeID],[AssetStatusID]) " +
                                "values (@C0,@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8)",
                                                         paramgeneratedAssetID, paramcmbtype, paramcmbrand, paramassetmodel, 
                                                         paramSAPAssetid, paramSN,paramPurchasingdate,paramcmbDevice,paramcmbAssetStatus);
                         SQLCONN3.ExecuteQueries("insert into AssetAssign ([AssetID],[EmployeeID],[AssginDate]) " +
                            "values (@C0,@C9,@C10)",
                                                     paramgeneratedAssetID, paramcmbAssignto, paramAssigndate);
                        MessageBox.Show("Record saved Successfully");

                            btnnew.Visible = true;
                        dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
    SELECT 
        Assets.AssetID, Assets.SapAssetId, Assets.sn, AssetType.AssettypeValue, 
        AssetBrand.AssetBrandValue, Assets.Model, [PurchasingDate],
        [DeviceTypeID], [AssetStatusID], [EmployeeID], [AssginDate]
    FROM 
        Assets
    INNER JOIN 
        AssetBrand ON Assets.Brand = AssetBrand.AssetBrandID
    INNER JOIN 
        AssetType ON Assets.AssetTypeID = AssetType.AssetTypeID
    LEFT JOIN 
        AssetAssign ON Assets.AssetID = AssetAssign.AssetID
    WHERE 
        AssetType.AssetTypeID = @C1 AND 
        AssetBrand.AssetBrandID = @C2 AND 
        Assets.Model = @C3 AND 
        Assets.sn = @C5 AND 
        Assets.PurchasingDate = @C6 ", paramcmbtype, paramcmbrand, paramassetmodel, paramSN, paramPurchasingdate);

                    }
                    else
                        {
                            dr.Dispose();
                            dr.Close();
                        }
                    }
                cmbtype.Text = cmbbrand.Text = "Select";
                cmbAssetModel.Text = "Select";
            }
                else
                {
                    MessageBox.Show("Please Fill the missing fields  ");

                }

            SQLCONN3.CloseConnection();
            SQLCONN.CloseConnection();

        }

        private void seratchassettxt_TextChanged(object sender, EventArgs e)
        {
          
                tabControl2.TabPages[0].ForeColor = Color.Black; // Adjust the color as needed

                SqlParameter paramAssetSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramAssetSearch.Value = seratchassettxt.Text;
            SQLCONN3.OpenConection3();

            string query = @"
    SELECT Assets.AssetID, Assets.SapAssetId, Assets.sn, AssetType.AssettypeValue, AssetBrand.AssetBrandValue, Assets.Model,[PurchasingDate]
      ,[DeviceTypeID]
      ,[AssetStatusID]
      ,[EmployeeID]
	  ,[AssginDate]
    FROM Assets
    INNER JOIN AssetBrand ON Assets.Brand = AssetBrand.AssetBrandID
    INNER JOIN AssetType ON Assets.AssetTypeID = AssetType.AssetTypeID
    LEFT JOIN AssetAssign ON Assets.AssetID = AssetAssign.AssetID
    WHERE 
        (Assets.Model LIKE '%' + @C1 + '%') OR 
        (Assets.AssetID LIKE '%' + @C1 + '%') OR
        (AssetType.AssettypeValue LIKE '%' + @C1 + '%') OR
        (AssetBrand.AssetBrandValue LIKE '%' + @C1 + '%')";





            dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(query, paramAssetSearch);



            SQLCONN3.CloseConnection();
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addbtn.Visible = false;
            btnnew.Visible = updatebtn.Visible  = true;
            SQLCONN3.OpenConection3();      
            cmbDevice.ValueMember = "DeviceTypeID";
            cmbDevice.DisplayMember = "DeviceType";
            cmbDevice.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT DeviceTypeID , DeviceType FROM DeviceTypes ");

            cmbAssetStatus.ValueMember = "AssetStatusID";
            cmbAssetStatus.DisplayMember = "AssetStatus";
            cmbAssetStatus.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetStatusID ,AssetStatus FROM AssetsStatus ");
            SQLCONN3.CloseConnection();


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
                        cmbAssetModel.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                     
                        if (dataGridView1.CurrentRow.Cells[6].Value == null || dataGridView1.CurrentRow.Cells[6].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView1.CurrentRow.Cells[6].Value.ToString()))
                        {
                            PurchasingDtp.Value = DateTime.Now;
                        }
                        else 
                        {
                            PurchasingDtp.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                        }
                        cmbDevice.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                        cmbAssetStatus.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

                        object cellValue = dataGridView1.Rows[e.RowIndex].Cells[9].Value;
                        if (cellValue != null && cellValue.ToString() != "")
                        {
                            cmbemployee.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                        }
                        else
                        {
                            cmbemployee.SelectedValue = 0; // or any default value you want to assign
                        }
                        if (dataGridView1.CurrentRow.Cells[10].Value == null || dataGridView1.CurrentRow.Cells[10].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView1.CurrentRow.Cells[10].Value.ToString()))
                        {
                            AssignDtp.Value = DateTime.Now;
                        }
                        else
                        {
                            AssignDtp.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
                        }
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
            paramassetmodel.Value = cmbAssetModel.SelectedValue;
            SqlParameter paramSAPAssetid = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramSAPAssetid.Value = txtsapid.Text;
            SqlParameter paramSN = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramSN.Value = txtSN.Text;
            SqlParameter paramIDD = new SqlParameter("@idd", SqlDbType.NVarChar);
            paramIDD.Value = AssetID;


            /*new update */
            SqlParameter paramPurchasingdate = new SqlParameter("@C6", SqlDbType.Date);
            paramPurchasingdate.Value = PurchasingDtp.Value;
            SqlParameter paramcmbDevice = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramcmbDevice.Value = cmbDevice.SelectedValue;
            SqlParameter paramcmbAssetStatus = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramcmbAssetStatus.Value = cmbAssetStatus.SelectedValue;
            /*new update */


            /*Asset Assign*/
            SqlParameter paramcmbAssignto = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramcmbAssignto.Value = cmbemployee.SelectedValue;
            SqlParameter paramAssigndate = new SqlParameter("@C10", SqlDbType.Date);
            paramAssigndate.Value = AssignDtp.Value;
            /*Asset Assign*/



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
                    else if (cmbAssetModel.Text == "Select")

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
                            SQLCONN3.ExecuteQueries("update Assets set brand=@C2,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7 ,AssetStatusID=@C8 where AssetID=@idd  ",
                                paramIDD, paramcmbrand, paramassetmodel,paramSAPAssetid,paramSN, paramPurchasingdate,paramcmbDevice,paramcmbAssetStatus);
                            SQLCONN3.ExecuteQueries("update  AssetAssign set [EmployeeID]=@C9,[AssginDate]=@C10 where AssetID=@idd ", paramIDD, paramcmbAssignto, paramAssigndate);

                        }
                        else if ((int)cmbbrand.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7 ,AssetStatusID=@C8 where  AssetID=@idd  ", 
                                paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN,paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus);
                            SQLCONN3.ExecuteQueries("update  AssetAssign set [EmployeeID]=@C9,[AssginDate]=@C10 where AssetID=@idd ", paramIDD, paramcmbAssignto, paramAssigndate);

                        }
                        else if ((int)cmbAssetModel.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7 ,AssetStatusID=@C8 where  AssetID=@idd  ", 
                                paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus);
                            SQLCONN3.ExecuteQueries("update  AssetAssign set [EmployeeID]=@C9,[AssginDate]=@C10 where AssetID=@idd ", paramIDD, paramcmbAssignto, paramAssigndate);

                        }
                        else if ((int)cmbDevice.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,AssetStatusID=@C8 where  AssetID=@idd  ",
                                paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbAssetStatus);
                            SQLCONN3.ExecuteQueries("update  AssetAssign set [EmployeeID]=@C9,[AssginDate]=@C10 where AssetID=@idd ", paramIDD, paramcmbAssignto, paramAssigndate);

                        }
                        else if ((int)cmbAssetStatus.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7  where  AssetID=@idd  "
                                , paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice);
                            SQLCONN3.ExecuteQueries("update  AssetAssign set [EmployeeID]=@C9,[AssginDate]=@C10 where AssetID=@idd ", paramIDD, paramcmbAssignto, paramAssigndate);

                        }
                        else 
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,brand=@C2,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7 ,AssetStatusID=@C8 where  AssetID=@idd  ",
                                paramIDD, paramcmbtype, paramcmbrand, paramassetmodel,paramSAPAssetid,paramSN, paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus);
                            SQLCONN3.ExecuteQueries("update  AssetAssign set [EmployeeID]=@C9,[AssginDate]=@C10 where AssetID=@idd ", paramIDD, paramcmbAssignto, paramAssigndate);

                        }






                        MessageBox.Show("Record Updated Successfully");
                        // dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],NewID,StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate],[UserID],[DatetimeLog]  FROM[DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and  NEWID = @C14  ", paramNewID);

                        dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
                              SELECT Assets.AssetID, Assets.SapAssetId, Assets.sn, AssetType.AssettypeValue, AssetBrand.AssetBrandValue, Assets.Model,[PurchasingDate]
      ,[DeviceTypeID]
      ,[AssetStatusID]
      ,[EmployeeID]
	  ,[AssginDate]
    FROM Assets
    INNER JOIN AssetBrand ON Assets.Brand = AssetBrand.AssetBrandID
    INNER JOIN AssetAssign ON Assets.AssetID = AssetAssign.AssetID
    INNER JOIN AssetType ON Assets.AssetTypeID = AssetType.AssetTypeID where  AssetBrand.AssetBrandID = Assets.Brand
  and Assets.AssetID=  @idd ", paramIDD);


                        SQLCONN3.CloseConnection();
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
          
        }

        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            SQLCONN3.OpenConection3();
            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetID;
            if (AssetID == null)
            {
                MessageBox.Show("Please Choose A Record !  ");

            }
            else
            {
                if (tabControl2.SelectedTab == tabControl2.TabPages[0])
                {

                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@" 
SELECT 
    Assets.AssetID,
    DeviceDetials.DeviceDetilasID,
    DeviceDetials.DeviceDetialsValue,
    CASE
        WHEN DeviceDetials.DeviceDetilasID = 20 THEN OSVerisons.OSVerisonValue
        ELSE AssetsDetials.Value
    END AS Value
FROM 
    Assets
JOIN 
    AssetsDetials ON Assets.AssetID = AssetsDetials.AssetID
JOIN 
    DeviceDetials ON DeviceDetials.DeviceDetilasID = AssetsDetials.DeviceDetilasID
LEFT JOIN 
    OSVerisons ON LTRIM(RTRIM(CAST(AssetsDetials.Value AS NVARCHAR(50)))) = OSVerisons.OSVersionID
WHERE 
    Assets.AssetID=@ID ", paramID);

                    cmbdeviceatt.Text = "Select";
                    txtvalue.Text = "";
                    dataGridView5.Columns[0].Visible = false;
                    dataGridView5.Columns[1].Visible = false;
                    dataGridView5.Columns[3].Width = 200;
                    dataGridView5.Columns[2].Width = 200;
                }
                if (tabControl2.SelectedTab == tabControl2.TabPages[1])
                {
                    dataGridView2.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
            SELECT  
                A.[AssetID], 
              
                CONCAT(E.[FirstName], ' ', E.[SecondName], ' ', E.[ThirdName], ' ', E.[LastName]) AS 'FullName',  A.[AssginDate]
            FROM 
                [DelmonGroupAssests].[dbo].[AssetAssign] A
            INNER JOIN 
                [DelmonGroupDB].[dbo].[Employees] E ON A.[EmployeeID] = E.[EmployeeID] AND assetid = @ID", paramID);
                    dataGridView2.Columns[1].Width = 300;

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
            if (AssetIDTXT.Text == "")
            {
                MessageBox.Show("Please Select Asset First !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else {
                if (AssetID != string.Empty & (int)cmbdeviceatt.SelectedValue != 0)
                {
                    SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
                    paramDeviceatt.Value = cmbdeviceatt.SelectedValue;

                    SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
                    paramValue.Value = txtvalue.Text;

                    SqlParameter paramcmbOS = new SqlParameter("@C3", SqlDbType.Int);
                    paramcmbOS.Value = cmbVersion.SelectedValue;


                    SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
                    paramID.Value = AssetID;

                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SQLCONN3.OpenConection3();

                        //  SqlDataReader dr = SQLCONN3.DataReader("select * from [AssetDetialsInfo] where  AssetDetailsID= " + AssetDetialsID + " and DeviceDetilasID= " + cmbdeviceatt.SelectedValue + " and value= " + txtvalue.Text + " ");
                        SqlDataReader dr = SQLCONN3.DataReader("select * from [AssetsDetials] where  AssetID=@ID  and DeviceDetilasID=@C1  and value=@C2 ", paramID, paramDeviceatt, paramValue);

                        dr.Read();

                        if (dr.HasRows)
                        {
                            MessageBox.Show("This ' Value For This Asset '  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                        else
                        {
                            dr.Dispose();
                            dr.Close();

                            if (cmbdeviceatt.SelectedValue != null && (int)cmbdeviceatt.SelectedValue == 100)
                            {
                                string originalValue = txtvalue.Text.ToString();

                                // Generate a random encryption key and IV

                                string encryptedValue = Encrypt(originalValue, encryptionKey, iv);

                                paramValue.Value = encryptedValue;
                                // Use the encryptedValue as needed

                                // In a real-world scenario, store the encryptionKey and iv securely for later decryption
                            }


                            else { paramValue.Value = txtvalue.Text; }
                            if ((int)cmbdeviceatt.SelectedValue == 20)
                            {
                                SQLCONN3.ExecuteQueries("insert into AssetsDetials (AssetID,DeviceDetilasID,Value) values (@ID,@C1,@C3)", paramID, paramDeviceatt, paramcmbOS);

                            }
                            else
                            {
                                SQLCONN3.ExecuteQueries("insert into AssetsDetials (AssetID,DeviceDetilasID,Value) values (@ID,@C1,@C2)", paramID, paramDeviceatt, paramValue);

                            }

                            MessageBox.Show("Record saved Successfully");





                            dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"select 
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
                            cmbdeviceatt.SelectedValue = 0;
                            txtvalue.Text = "";

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
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
            paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);

            SqlParameter paramcmbOS = new SqlParameter("@C3", SqlDbType.Int);
            paramcmbOS.Value = cmbVersion.SelectedValue;

            paramValue.Value = txtvalue.Text;
            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetID;

            if (AssetIDTXT.Text == "")
            {
                MessageBox.Show("Please Select Asset First. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else {
                if (AssetID != string.Empty && ((int)cmbdeviceatt.SelectedValue != 0))
                {


                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SQLCONN3.OpenConection3();


                        if (cmbdeviceatt.SelectedValue != null && (int)cmbdeviceatt.SelectedValue == 100)
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



                        if ((int)cmbdeviceatt.SelectedValue == 20)
                        {
                            SQLCONN3.ExecuteQueries("update  AssetsDetials set AssetID=@ID,DeviceDetilasID=@C1,Value=@C3 where AssetID=@ID and DeviceDetilasID=@C1 ",
                                                  paramID, paramDeviceatt, paramcmbOS);


                        }
                        else
                        {
                            SQLCONN3.ExecuteQueries("update  AssetsDetials set AssetID=@ID,DeviceDetilasID=@C1,Value=@C2 where AssetID=@ID and DeviceDetilasID=@C1 ",
                                                  paramID, paramDeviceatt, paramValue);


                        }



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

         
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            addbtn.Visible = false;
            btnnew.Visible = updatebtn.Visible  = true;

            DataGridViewCell clickedCell = dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex];

            cmbVersion.Enabled = false;
            txtvalue.Enabled = true;

            if (clickedCell.Value != null && !string.IsNullOrWhiteSpace(clickedCell.Value.ToString()))
            {
                AssetDetialsInfoID = dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbdeviceatt.Text = dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();

                string cellValue = clickedCell.Value.ToString();

                // Check if the cell value is "OS" (case-insensitive)
                if (string.Equals(cellValue, "OS", StringComparison.OrdinalIgnoreCase))
                {
                    cmbVersion.Enabled = true;
                    txtvalue.Enabled = false;

                    // You can include additional logic specific to cmbVersion here if needed
                }
                else if (e.ColumnIndex > 0)  // Check if not the first column
                {
                    DataGridViewCell adjacentCell = dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex - 1];
                    string adjacentCellValue = adjacentCell.Value?.ToString();

                    // Check if the adjacent cell value is "OS" (case-insensitive)
                    if (string.Equals(adjacentCellValue, "OS", StringComparison.OrdinalIgnoreCase))
                    {
                        cmbVersion.Enabled = true;
                        txtvalue.Enabled = false;
                        txtvalue.Text = "";

                        // You can include additional logic specific to cmbVersion here if needed
                    }
                    else
                    {
                        txtvalue.Text = cellValue;

                        // You can include additional logic specific to txtvalue here if needed
                    }
                }
                else
                {
                    txtvalue.Text = cellValue;

                    // You can include additional logic specific to txtvalue here if needed
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
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

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbbrand_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupAssests;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @" SELECT AssetModeID,AssetModel FROM AssetsModel where AssetTypeID= @C1 and AssetBrandID= @C2 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@C2", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbtype.SelectedValue;
            cmd.Parameters["@C2"].Value = cmbbrand.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbAssetModel.DataSource = dt;
                cmbAssetModel.ValueMember = "AssetModeID";
                cmbAssetModel.DisplayMember = "AssetModel";
                cmbAssetModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbAssetModel.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbAssetModel.Text = "Select";
            }
            conn.Close();



            //SQLCONN3.OpenConection();
            //SqlParameter paramAssetModelSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            //paramAssetModelSearch.Value = cmbtype.SelectedValue;
            //SqlParameter paramAssetBrandSearch = new SqlParameter("@C2", SqlDbType.NVarChar);
            //paramAssetBrandSearch.Value = cmbbrand.SelectedValue;

            //string query2 = @" SELECT AssetModeID,AssetModel FROM AssetsModel where AssetTypeID= @C1 and AssetBrandID= @C2 ";

            //cmbAssetModel.ValueMember = "AssetModeID";
            //cmbAssetModel.DisplayMember = "AssetModel";
            //cmbAssetModel.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(query2, paramAssetModelSearch, paramAssetBrandSearch);
            //cmbAssetModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbAssetModel.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbAssetModel.Text = "Select";

            //SQLCONN3.CloseConnection();


        }

        private void cmbdeviceatt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cmbdeviceatt.SelectedValue == 20)
            {
                cmbVersion.Enabled = true;
                txtvalue.Enabled = false;

            }
            else 
            {
                cmbVersion.Enabled = false;
                txtvalue.Enabled = true;

            }


        }

        private void btnnewJob_Click(object sender, EventArgs e)
        {
            frmNewModel frmmodel = new frmNewModel();
            // this.Hide();
            frmmodel.Show();
        }

        private void AssetIDTXT_TextChanged(object sender, EventArgs e)
        {
            SQLCONN3.OpenConection3();
            SQLCONN.OpenConection();
            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetIDTXT.Text;
            if (AssetID == null && AssetIDTXT.Text == string.Empty)
            {
                MessageBox.Show("Please Choose A Record !");
            }
            else
            {
                if (tabControl2.SelectedTab == tabControl2.TabPages[0])
                {
                    dataGridView2.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
            SELECT  
                A.[AssetID], 
              
                CONCAT(E.[FirstName], ' ', E.[SecondName], ' ', E.[ThirdName], ' ', E.[LastName]) AS 'FullName',  A.[AssginDate] 
            FROM 
                [DelmonGroupAssests].[dbo].[AssetAssign] A
            INNER JOIN 
                [DelmonGroupDB].[dbo].[Employees] E ON A.[EmployeeID] = E.[EmployeeID] AND assetid = @ID", paramID);
                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"    
            SELECT 
                Assets.AssetID,
                DeviceDetials.DeviceDetilasID,
                DeviceDetials.DeviceDetialsValue,
                CASE
                    WHEN DeviceDetials.DeviceDetilasID = 20 THEN OSVerisons.OSVerisonValue
                    ELSE AssetsDetials.Value
                END AS Value
            FROM 
                Assets
            JOIN 
                AssetsDetials ON Assets.AssetID = AssetsDetials.AssetID
            JOIN 
                DeviceDetials ON DeviceDetials.DeviceDetilasID = AssetsDetials.DeviceDetilasID
            LEFT JOIN 
                OSVerisons ON LTRIM(RTRIM(CAST(AssetsDetials.Value AS NVARCHAR(50)))) = OSVerisons.OSVersionID
            WHERE 
                Assets.AssetID = @ID", paramID);

                    cmbdeviceatt.Text = "Select";
                    txtvalue.Text = "";
                    dataGridView5.Columns[0].Visible = false;
                    dataGridView5.Columns[1].Visible = false;
                    dataGridView5.Columns[3].Width = 200;
                    dataGridView5.Columns[2].Width = 200;
                    dataGridView2.Columns[1].Width = 300;

                }
                if (tabControl2.SelectedTab == tabControl2.TabPages[1])
                {
                    dataGridView2.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
            SELECT  
                A.[AssetID], 
              
                CONCAT(E.[FirstName], ' ', E.[SecondName], ' ', E.[ThirdName], ' ', E.[LastName]) AS 'FullName',  A.[AssginDate], 
            FROM 
                [DelmonGroupAssests].[dbo].[AssetAssign] A
            INNER JOIN 
                [DelmonGroupDB].[dbo].[Employees] E ON A.[EmployeeID] = E.[EmployeeID] AND assetid = @ID", paramID);
                }
                dataGridView2.Columns[1].Width = 300;

            }

            // Close connections for both SQLCONN3 and SQLCONN
            SQLCONN3.CloseConnection();
            SQLCONN.CloseConnection();

        }



        private void cmbbrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAssetModel.Focus();
                e.Handled = true;

            }
        }


    }
}

