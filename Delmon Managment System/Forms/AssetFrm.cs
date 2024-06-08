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
using ExcelDataReader; // You need to install ExcelDataReader package via NuGet


namespace Delmon_Managment_System.Forms
{
    public partial class AssetFrm : Form
    {
        private AutoCompleteStringCollection employeeNames;

        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        SQLCONNECTION SQLCONN3 = new SQLCONNECTION();
        string AssetID;
        string AssetDetialsInfoID;
        int LoggedEmployeeID;
        string encryptionKey = "0pqnU2X00mf+i8mDTzyPVw==", iv = "0pqnU2X00mf+i8mDTzyPVw==";
        private List<string> originalData = new List<string>(); // List to store original data
        bool hasView = false;
        bool hasEdit = false;
        bool hasDelete = false;
        bool hasAdd = false;


        public AssetFrm()
        {
            InitializeComponent();
            employeeNames = new AutoCompleteStringCollection();
       
            // Attach event handlers for combo box selected index changed events
            cmbtyperpt.SelectedIndexChanged += FilterData;
            cmbbrandrpt.SelectedIndexChanged += FilterData;
            cmbdevicerpt.SelectedIndexChanged += FilterData;
            cmbmodelrpt.SelectedIndexChanged += FilterData;
            cmbstatusrpt.SelectedIndexChanged += FilterData;
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

        public void RefreshData()
        {
            // Call your method to populate comboboxes or reload data
            generteModel(); // Assuming generteModel is responsible for populating combobox data
        }


        public void AssetFrm_Load(object sender, EventArgs e)
        {
            SQLCONN3.OpenConection3();
            SQLCONN.OpenConection();





            SqlDataReader dr = SQLCONN.DataReader(@"
        SELECT ps.PermissionName
        FROM UserPermissions us
        	JOIN tblUser u ON us.UserID = u.EmployeeID
        JOIN Permissions ps ON us.PermissionID = ps.PermissionID
               WHERE u.EmployeeID = @UserID",
                new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = CommonClass.EmployeeID });


            while (dr.Read())
            {
                string permissionName = dr["PermissionName"].ToString();
                if (permissionName.Contains("ViewAssets"))
                {
                    hasView = true;
                }
                if (permissionName.Contains("EditAssets"))
                {
                    hasEdit = true;
                }
                if (permissionName.Contains("DeleteAssets"))
                {
                    hasDelete = true;
                }
                if (permissionName.Contains("AddAssets"))
                {
                    hasAdd = true;
                }
            }
            dr.Close();
            if (hasView == false)
            {
                MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                groupBox1.Enabled = false;
                tabControl2.Enabled = false;
            }
            else

            {
                groupBox1.Enabled = true;
                tabControl2.Enabled = true;



                if (hasEdit)
                {
                    updatebtn.Enabled = true;
                    button3.Enabled = true;                }
                if (hasDelete)
                {
                    btnDelete.Enabled = true;

                     button1.Enabled = true;
                }
                if (hasAdd)
                {
                  btnuplode2.Enabled= button2.Enabled= btnnew.Enabled= btnuplode.Enabled = addbtn.Enabled = btnDownload.Enabled= true;
                }

            }




            this.timer1.Interval = 1000;
            timer1.Start();

            lblusername.Text = CommonClass.LoginUserName;
            lblemail.Text = CommonClass.Email;
            LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;
          

            cmbemployee.ValueMember = "EmployeeID";
            cmbemployee.DisplayMember = "FullName";
            cmbemployee.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID, CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) 'FullName' FROM Employees ORDER BY EmployeeID"); // Initial data load");
            cmbemployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbtype.ValueMember = "AssetTypeID";
            cmbtype.DisplayMember = "AssettypeValue";
            cmbtype.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetTypeID,AssettypeValue FROM AssetType");
            cmbtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbtype.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbtype.Text = "Select";


            cmbdeviceatt.ValueMember = "DeviceDetilasID";
            cmbdeviceatt.DisplayMember = "DeviceDetialsValue";
            cmbdeviceatt.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT DeviceDetilasID ,DeviceDetialsValue FROM DeviceDetials ");
            cmbdeviceatt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbdeviceatt.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbdeviceatt.Text = "Select";


            cmbDevice.ValueMember = "DeviceTypeID";
            cmbDevice.DisplayMember = "DeviceType";
            cmbDevice.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT DeviceTypeID , DeviceType FROM DeviceTypes ");
            cmbDevice.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDevice.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbDevice.Text = "Select";


            cmbAssetStatus.ValueMember = "AssetStatusID";
            cmbAssetStatus.DisplayMember = "AssetStatus";
            cmbAssetStatus.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetStatusID ,AssetStatus FROM AssetsStatus ");
            cmbAssetStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAssetStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAssetStatus.Text = "Select";


            cmbAssetModel.ValueMember = "AssetModeID";
            cmbAssetModel.DisplayMember = "AssetModel";
            cmbAssetModel.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetModeID ,AssetModel FROM AssetsModel ");
            cmbAssetModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAssetModel.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAssetModel.Text = "Select";


            cmbVersion.ValueMember = "OSVersionID";
            cmbVersion.DisplayMember = "OSVerisonValue";
            cmbVersion.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT OSVersionID ,OSVerisonValue FROM OSVerisons ");
            cmbVersion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbVersion.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbVersion.Text = "Select";


            cmbbrand.ValueMember = "AssetBrandID";
            cmbbrand.DisplayMember = "AssetBrandValue";
            cmbbrand.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetBrandID ,AssetBrandValue FROM AssetBrand ");
            cmbbrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbbrand.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbbrand.Text = "Select";



            SQLCONN.CloseConnection();
            SQLCONN3.CloseConnection();
            //  InitializeEncryptionParameters();


        }


        public void generteModel()
        {
            SQLCONN3.OpenConection3();
            cmbAssetModel.ValueMember = "AssetModeID";
            cmbAssetModel.DisplayMember = "AssetModel";
            cmbAssetModel.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetModeID ,AssetModel FROM AssetsModel ");
            cmbAssetModel.Text = "Select";
            SQLCONN3.CloseConnection();

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
            updatebtn.Visible = false;
            btnuplode.Visible = false;
            btnnew.Visible = false;
            cmbtype.Text = "Select";
            cmbbrand.Text = "Select";
            cmbemployee.Text = "Select";
            cmbdeviceatt.Text = "Select";
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
                    return "MO";
                case 4:
                    return "SR";
                case 5:
                    return "SC";
                case 6:
                    return "SW";
                case 7:
                    return "TL";
                case 8:
                    return "BI";

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

            string generatedAssetID = GenerateAssetID(assetTypeID, nextID);

            SqlParameter paramgeneratedAssetID = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramgeneratedAssetID.Value = generatedAssetID;



            SqlDataReader dr;

            if ((int)cmbtype.SelectedValue != 0 && (int)cmbbrand.SelectedValue != 0 && (int)cmbAssetModel.SelectedValue != 0
            && (int)cmbDevice.SelectedValue != 0 && (int)cmbAssetStatus.SelectedValue != 0 && txtSN.Text != string.Empty)
            {
                SQLCONN3.OpenConection3();
                SQLCONN.OpenConection();
                dr = SQLCONN3.DataReader("select  * from Assets  where " +
                        " brand=@C2 and model = @C3 and sn= @C5", paramcmbrand, paramassetmodel, paramSN);
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
                                                     paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus);
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
WITH LastAssignments AS (
    SELECT 
        asi.AssetID, 
        asi.EmployeeID, 
        asi.AssginDate,
        ROW_NUMBER() OVER (PARTITION BY asi.AssetID ORDER BY asi.ID DESC) AS RowNum
    FROM
        AssetAssign asi
)
SELECT 
    A.AssetID, 
    A.SapAssetId, 
    A.sn, 
    AT.AssettypeValue, 
    AB.AssetBrandValue, 
    A.Model,
    A.PurchasingDate,
    A.DeviceTypeID,
    A.AssetStatusID,
    CONCAT(E.FirstName, ' ', E.SecondName, ' ', E.ThirdName, ' ', E.LastName) AS FullName,
    LA.EmployeeID AS LastEmployeeID,
    LA.AssginDate AS LastAssignDate
FROM
    Assets A
INNER JOIN 
    AssetBrand AB ON A.Brand = AB.AssetBrandID
INNER JOIN 
    AssetType AT ON A.AssetTypeID = AT.AssetTypeID
LEFT JOIN 
    LastAssignments LA ON A.AssetID = LA.AssetID AND LA.RowNum = 1
LEFT JOIN
    [DelmonGroupDB].[dbo].[Employees] E ON LA.EmployeeID = E.EmployeeID
WHERE 
    A.sn LIKE '%' + @C1 + '%' OR 
    A.Model LIKE '%' + @C1 + '%' OR 
    A.AssetID LIKE '%' + @C1 + '%' OR
    AT.AssettypeValue LIKE '%' + @C1 + '%' OR
    AB.AssetBrandValue LIKE '%' + @C1 + '%' OR
    REPLACE(CONCAT_WS(' ', E.FirstName, E.SecondName, E.ThirdName, E.LastName), ' ', '') LIKE '%' + REPLACE(@C1, ' ', '') + '%'
ORDER BY 
    A.AssetID;"

;





            dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(query, paramAssetSearch);



            SQLCONN3.CloseConnection();
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addbtn.Visible = false;
            btnnew.Visible = updatebtn.Visible = btnDelete.Visible= true;
            SQLCONN3.OpenConection3();
            cmbDevice.ValueMember = "DeviceTypeID";
            cmbDevice.DisplayMember = "DeviceType";
            cmbDevice.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT DeviceTypeID , DeviceType FROM DeviceTypes ");

            cmbAssetStatus.ValueMember = "AssetStatusID";
            cmbAssetStatus.DisplayMember = "AssetStatus";
            cmbAssetStatus.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetStatusID ,AssetStatus FROM AssetsStatus ");


            cmbAssetModel.ValueMember = "AssetModeID";
            cmbAssetModel.DisplayMember = "AssetModel";
            cmbAssetModel.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetModeID ,AssetModel FROM AssetsModel ");
            cmbAssetModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAssetModel.AutoCompleteSource = AutoCompleteSource.ListItems;

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
                        //MessageBox.Show(AssetID);
                        //AssetIDTXT.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        AssetIDTXT.Text = AssetID;
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

                        object cellValue = dataGridView1.Rows[e.RowIndex].Cells[10].Value;
                        if (cellValue != null && cellValue.ToString() != "")
                        {
                            cmbemployee.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                        }
                        else
                        {
                            cmbemployee.SelectedValue = 0; // or any default value you want to assign
                        }
                        if (dataGridView1.CurrentRow.Cells[11].Value == null || dataGridView1.CurrentRow.Cells[11].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView1.CurrentRow.Cells[11].Value.ToString()))
                        {
                            AssignDtp.Value = DateTime.Now;
                        }
                        else
                        {
                            AssignDtp.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString());
                        }
                    }
                }

            }

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

            SqlDataReader dr;
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
                                paramIDD, paramcmbrand, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus);

                            SQLCONN3.ExecuteQueries("insert into AssetAssign ([AssetID],[EmployeeID],[AssginDate]) " +
                         "values (@idd,@C9,@C10)",
                                                  paramIDD, paramcmbAssignto, paramAssigndate);

                           

                        }
                        else if ((int)cmbbrand.SelectedIndex == -1)
                        {

                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7 ,AssetStatusID=@C8 where  AssetID=@idd  ",
                                paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus);

                            SQLCONN3.ExecuteQueries("insert into AssetAssign ([AssetID],[EmployeeID],[AssginDate]) " +
                         "values (@idd,@C9,@C10)",
                                                  paramIDD, paramcmbAssignto, paramAssigndate);



                        }
                        else if ((int)cmbAssetModel.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7 ,AssetStatusID=@C8 where  AssetID=@idd  ",
                                paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus);

                            SQLCONN3.ExecuteQueries("insert into AssetAssign ([AssetID],[EmployeeID],[AssginDate]) " +
                         "values (@idd,@C9,@C10)",
                                                  paramIDD, paramcmbAssignto, paramAssigndate);


                         

                        }
                        else if ((int)cmbDevice.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,AssetStatusID=@C8 where  AssetID=@idd  ",
                                paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbAssetStatus);


                            SQLCONN3.ExecuteQueries("insert into AssetAssign ([AssetID],[EmployeeID],[AssginDate]) " +
                         "values (@idd,@C9,@C10)",
                                                  paramIDD, paramcmbAssignto, paramAssigndate);

                       
                        }
                        else if ((int)cmbAssetStatus.SelectedIndex == -1)
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7  where  AssetID=@idd  "
                                , paramIDD, paramcmbtype, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice);


                            SQLCONN3.ExecuteQueries("insert into AssetAssign ([AssetID],[EmployeeID],[AssginDate]) " +
                         "values (@idd,@C9,@C10)",
                                                  paramIDD, paramcmbAssignto, paramAssigndate);

                           
                        }
                        else
                        {
                            SQLCONN3.ExecuteQueries("update Assets set AssetTypeID=@C1,brand=@C2,model=@C3,SAPAssetId=@C4,Sn=@C5 ,PurchasingDate=@C6 ,DeviceTypeID=@C7 ,AssetStatusID=@C8 where  AssetID=@idd  ",
                                paramIDD, paramcmbtype, paramcmbrand, paramassetmodel, paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus);

                            SQLCONN3.ExecuteQueries("insert into AssetAssign ([AssetID],[EmployeeID],[AssginDate]) " +
                         "values (@idd,@C9,@C10)",
                                                  paramIDD, paramcmbAssignto, paramAssigndate);


                       

                        }






                        MessageBox.Show("Record Updated Successfully");

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
                        SQLCONN.CloseConnection();
                      //  dr.Close();

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
                MessageBox.Show("Please Choose A Record !");

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
from 
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

                // asset history tab
                if (tabControl2.SelectedTab == tabControl2.TabPages[1])
                {
                    dataGridView2.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
         SELECT  A.ID,
    A.[AssetID], 
    CONCAT(E.[FirstName], ' ', E.[SecondName], ' ', E.[ThirdName], ' ', E.[LastName]) AS 'FullName',  
    A.[AssginDate]
FROM 
    [AssetAssign] A  
INNER JOIN 
    [DelmonGroupDB].[dbo].[Employees] E ON A.[EmployeeID] = E.[EmployeeID]  
WHERE 
    A.[AssetID] = @ID
ORDER BY 
    A.[ID] DESC;", paramID);
                    dataGridView2.Columns[2].Width = 300;
                    dataGridView2.Columns["ID"].Visible = false;


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
            else
            {
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
                            MessageBox.Show("The ' Value For This Asset '  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            else
            {
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
            btnnew.Visible = updatebtn.Visible = true;

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
            AssetFrm assetForm = new AssetFrm();

            // Pass the instance of AssetFrm to the constructor of FrmNewModel
            FrmNewModel frmmodel = new FrmNewModel();

            // Show the FrmNewModel form
            frmmodel.Show();
        }

        private void AssetIDTXT_TextChanged(object sender, EventArgs e)
        {
            SqlDataReader dr;

            SQLCONN3.OpenConection3();
            SQLCONN.OpenConection();
            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetIDTXT.Text;

            dr = SQLCONN3.DataReader("select  PurchasingDate  from Assets  where " +
                    " AssetID=@ID ", paramID);
            dr.Read();


            if (dr != null && dr.HasRows && !string.IsNullOrEmpty(dr["PurchasingDate"].ToString()))

            {
                AssignDtp.Value = Convert.ToDateTime(dr["PurchasingDate"].ToString());
            }
            else
            {
                AssignDtp.Value = DateTime.Now;
            }

            dr.Close();





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
              
                CONCAT(E.[FirstName], ' ', E.[SecondName], ' ', E.[ThirdName], ' ', E.[LastName]) AS 'FullName',  A.[AssginDate]
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlParameter paramID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramID.Value = AssetID;
            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
            paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramValue.Value = txtvalue.Text;
            SqlParameter paramcmbOS = new SqlParameter("@C3", SqlDbType.Int);
            paramcmbOS.Value = cmbVersion.SelectedValue;

            if (AssetDetialsInfoID == string.Empty)
            {
                MessageBox.Show("Please select  Asset first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();

                    if ((int)cmbdeviceatt.SelectedValue == 20)
                    {
                        SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id and DeviceDetilasID = @C1 and value = @C3 ", paramID, paramDeviceatt, paramcmbOS);
                        cmbVersion.Text = "";
                    }
                    else

                    {
                        SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id and DeviceDetilasID = @C1 and value = @C2 ", paramID, paramDeviceatt, paramValue);

                    }



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
                    cmbdeviceatt.Text = "Select";
                    cmbbrand.Text = "";
                    cmbAssetModel.Text = "Select";
                    txtvalue.Text = "";



                }

            }
        }



        private void btnuplode_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            SqlParameter paramAssetID = new SqlParameter("@C1", SqlDbType.NVarChar);
            try
            {
                // Open file dialog to select Excel file
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the selected file path
                        string filePath = openFileDialog.FileName;

                        // Check if the file is already open
                        try
                        {
                            using (System.IO.File.OpenRead(filePath))
                            {
                                // File is not already open, proceed with reading and processing
                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("The file is already open. Please close it and try again.");
                            return; // Exit the method if the file is already open
                        }

                        // Read data from Excel using ExcelDataReader
                        using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                // Use dataset to store the data from Excel
                                var result = reader.AsDataSet();
                                DataTable table = result.Tables[0]; // Assuming data is in first sheet

                                // Establish connection to SQL Server
                                string connectionString = SQLCONN.ConnectionString3;
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    // Iterate through each row in the DataTable
                                    for (int i = 0; i < table.Rows.Count; i++)
                                    {
                                        DataRow row = table.Rows[i];

                                        // Map Excel columns to SQL Server table columns based on their positions
                                        string assetID = row[0].ToString(); // Assuming AssetID is the first column in Excel
                                        string brand = row[1].ToString();   // Assuming Brand is the second column in Excel
                                        string model = row[2].ToString();   // Assuming Model is the third column in Excel
                                        string assetTypeID = row[3].ToString(); // Assuming AssetTypeID is the fourth column in Excel
                                        string sAPAssetID = row[4].ToString();   // Assuming SAPAssetID is the fifth column in Excel
                                        string SN = row[5].ToString();           // Assuming SN is the sixth column in Excel
                                        string purchasingDateString = row[6].ToString().Split(' ')[0].Trim(); // Trim the string to remove leading/trailing spaces and time component
                                        string deviceTypeID = row[7].ToString();    // Assuming DeviceTypeID is the eighth column in Excel
                                        string assetStatusID = row[8].ToString();   // Assuming AssetStatusID is the ninth column in Excel

                                        DateTime purchasingDate;

                                        if (DateTime.TryParseExact(purchasingDateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out purchasingDate))
                                        {
                                            SQLCONN3.OpenConection3();
                                            paramAssetID.Value = assetID;

                                            dr = SQLCONN3.DataReader("select  * from Assets  where " +
                                                 " AssetID=@C1 ", paramAssetID);
                                            dr.Read();

                                            if (dr.HasRows)
                                            {
                                                MessageBox.Show("This 'Asset' : " + assetID + "  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                dr.Dispose();
                                                dr.Close();

                                                // Prepare INSERT statement
                                                string insertQuery = "INSERT INTO Assets (AssetID, Brand, Model, AssetTypeID, SAPAssetID, SN, PurchasingDate, DeviceTypeID, AssetStatusID) " +
                                                                "VALUES (@AssetID, @Brand, @Model, @AssetTypeID, @SAPAssetID, @SN, @PurchasingDate, @DeviceTypeID, @AssetStatusID)";

                                                // Create SqlCommand object
                                                SqlCommand command = new SqlCommand(insertQuery, connection);

                                                // Set parameter values
                                                command.Parameters.AddWithValue("@AssetID", assetID);
                                                command.Parameters.AddWithValue("@Brand", brand);
                                                command.Parameters.AddWithValue("@Model", model);
                                                command.Parameters.AddWithValue("@AssetTypeID", assetTypeID);
                                                command.Parameters.AddWithValue("@SAPAssetID", sAPAssetID);
                                                command.Parameters.AddWithValue("@SN", SN);
                                                command.Parameters.AddWithValue("@PurchasingDate", purchasingDate);
                                                command.Parameters.AddWithValue("@DeviceTypeID", deviceTypeID);
                                                command.Parameters.AddWithValue("@AssetStatusID", assetStatusID);
                                                // Execute INSERT command

                                                command.ExecuteNonQuery();
                                                MessageBox.Show("Data uploaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            }
                                        }
                                        else
                                        {
                                            // Date parsing failed, handle the error
                                            // For example, you can log an error message or display a warning to the user
                                            //  MessageBox.Show($"Invalid date format: {purchasingDateString}. Please ensure the date format is dd/MM/yyyy.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void btnuplode2_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            SqlParameter paramAssetID = new SqlParameter("@ID", SqlDbType.NVarChar);
            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            try
            {
                // Open file dialog to select Excel file
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the selected file path
                        string filePath = openFileDialog.FileName;

                        // Check if the file is already open
                        try
                        {
                            using (System.IO.File.OpenRead(filePath))
                            {
                                // File is not already open, proceed with reading and processing
                            }
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("The file is already open. Please close it and try again.");
                            return; // Exit the method if the file is already open
                        }

                        // Read data from Excel using ExcelDataReader
                        using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                // Use dataset to store the data from Excel
                                var result = reader.AsDataSet();
                                DataTable table = result.Tables[0]; // Assuming data is in first sheet

                                // Establish connection to SQL Server
                                string connectionString = SQLCONN.ConnectionString3;
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    // Iterate through each row in the DataTable
                                    for (int i = 1; i < table.Rows.Count; i++)
                                    {
                                        DataRow row = table.Rows[i];

                                        // Map Excel columns to SQL Server table columns based on their positions
                                        string assetID = row[0].ToString(); // Assuming AssetID is the first column in Excel
                                        string DeviceDetilasIDstring = row[1].ToString().Split(' ')[0].Trim();   // Assuming Brand is the second column in Excel
                                        string Value = row[2].ToString();   // Assuming Model is the third column in Excel

                                        int DeviceDetilasID;
                                        if (int.TryParse(DeviceDetilasIDstring.ToString(), out DeviceDetilasID))
                                        {
                                            SQLCONN3.OpenConection3();
                                            paramAssetID.Value = assetID;
                                            paramDeviceatt.Value = DeviceDetilasID;
                                            paramValue.Value = Value;

                                            dr = SQLCONN3.DataReader("select * from [AssetsDetials] where  AssetID=@ID  and DeviceDetilasID=@C1  and value=@C2 ", paramAssetID, paramDeviceatt, paramValue);

                                            dr.Read();

                                            if (dr.HasRows)
                                            {
                                                MessageBox.Show("The ' Value: " + Value + " For This Asset '  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                dr.Dispose();
                                                dr.Close();
                                                // Prepare INSERT statement
                                                string insertQuery = "INSERT INTO AssetsDetials (AssetID, DeviceDetilasID,Value) " +
                                                                    "VALUES (@AssetID,@DeviceDetilasID, @Value)";
                                                // Create SqlCommand object
                                                SqlCommand command = new SqlCommand(insertQuery, connection);

                                                // Set parameter values
                                                command.Parameters.AddWithValue("@AssetID", assetID);
                                                command.Parameters.AddWithValue("@DeviceDetilasID", DeviceDetilasID);
                                                command.Parameters.AddWithValue("@Value", Value);
                                                // Execute INSERT command

                                                command.ExecuteNonQuery();
                                                MessageBox.Show("Data uploaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }


                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FetchData();

        }


        // Define the event handler method
        private void FilterData(object sender, EventArgs e)
        {
            // Call the method to fetch data with the updated filters
            FetchData();
        }

        // Define a method to fetch data based on current filters
        private void FetchData()
        {
            dataGridView3.DataSource = null;
            string query = @"
    SELECT  A.AssetID, A.SapAssetId, A.sn, AT.AssettypeValue, AB.AssetBrandValue, AM.AssetModel, A.PurchasingDate,
           A.DeviceTypeID, A.AssetStatusID
    FROM [DelmonGroupAssests].[dbo].[Assets] A
    INNER JOIN [DelmonGroupAssests].[dbo].[AssetBrand] AB ON A.Brand = AB.AssetBrandID
    INNER JOIN [DelmonGroupAssests].[dbo].[AssetType] AT ON A.AssetTypeID = AT.AssetTypeID
    INNER JOIN [DelmonGroupAssests].[dbo].[AssetsModel] AM ON A.Model = AM.AssetModeID
    WHERE A.PurchasingDate BETWEEN @param1 AND @param2
    AND (AT.AssetTypeID = @param3 OR @param3 IS NULL)
    AND (AB.AssetBrandID = @param4 OR @param4 IS NULL)
    AND (A.DeviceTypeID = @param5 OR @param5 IS NULL)
    AND (AM.AssetModeID = @param6 OR @param6 IS NULL)
    AND (A.AssetStatusID = @param7 OR @param7 IS NULL)";



            // Assuming SQLCONN3 is your SQL connection class
            SQLCONN3.OpenConection3();

            // Assuming ShowDataInGridViewORCombobox is a method that executes the query and fetches data
            dataGridView3.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(query,
                new SqlParameter("@param1", SqlDbType.Date) { Value = dtpfrom.Value },
                new SqlParameter("@param2", SqlDbType.Date) { Value = dtpto.Value },
                new SqlParameter("@param3", SqlDbType.NVarChar) { Value = cmbtyperpt.SelectedValue ?? DBNull.Value },
                new SqlParameter("@param4", SqlDbType.NVarChar) { Value = cmbbrandrpt.SelectedValue ?? DBNull.Value },
                new SqlParameter("@param5", SqlDbType.NVarChar) { Value = cmbdevicerpt.SelectedValue ?? DBNull.Value },
                new SqlParameter("@param6", SqlDbType.NVarChar) { Value = cmbmodelrpt.SelectedValue ?? DBNull.Value },
                new SqlParameter("@param7", SqlDbType.NVarChar) { Value = cmbstatusrpt.SelectedValue ?? DBNull.Value });

            SQLCONN3.CloseConnection();
        }
        private void RefreshComboBoxes()
        {
            SQLCONN3.OpenConection3();

            // Populate cmbtyperpt
            cmbtyperpt.DisplayMember = "AssettypeValue";
            cmbtyperpt.ValueMember = "AssetTypeID";
            cmbtyperpt.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetTypeID, AssettypeValue FROM AssetType");
            cmbtyperpt.Text = "Select";

            // Populate cmbstatusrpt
            cmbstatusrpt.DisplayMember = "AssetStatus";
            cmbstatusrpt.ValueMember = "AssetStatusID";
            cmbstatusrpt.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetStatusID, AssetStatus FROM AssetsStatus");
            cmbstatusrpt.Text = "Select";

            // Populate cmbmodelrpt
            cmbmodelrpt.DisplayMember = "AssetModel";
            cmbmodelrpt.ValueMember = "AssetModeID";
            cmbmodelrpt.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetModeID, AssetModel FROM AssetsModel");
            cmbmodelrpt.Text = "Select";

            // Populate cmbbrandrpt
            cmbbrandrpt.DisplayMember = "AssetBrandValue";
            cmbbrandrpt.ValueMember = "AssetBrandID";
            cmbbrandrpt.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetBrandID, AssetBrandValue FROM AssetBrand");
            cmbbrandrpt.Text = "Select";

            // Populate cmbdevicerpt
            cmbdevicerpt.DisplayMember = "DeviceType";
            cmbdevicerpt.ValueMember = "DeviceTypeID";
            cmbdevicerpt.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT DeviceTypeID, DeviceType FROM DeviceTypes");
            cmbdevicerpt.Text = "Select";

            SQLCONN3.CloseConnection();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            RefreshComboBoxes();

        }
        private void cmbtyperpt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            RefreshComboBoxes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmMoreinfo frmMoreinfo = new FrmMoreinfo();
            // this.Hide();
            frmMoreinfo.Show();
        }

        private void cmbemployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonClass.EndUserID = (int)cmbemployee.SelectedValue;


        }

        private void cmbemployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbemployee.DroppedDown = false;

        }

        private void cmbtype_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbtype.DroppedDown = false;

        }

        private void cmbbrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbbrand.DroppedDown = false;

        }

        private void cmbDevice_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbDevice.DroppedDown = false;

        }

        private void cmbAssetModel_KeyPress(object sender, KeyPressEventArgs e)
        {
           cmbAssetModel.DroppedDown = false;
          


        }

        private void cmbAssetStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbAssetStatus.DroppedDown = false;

        }

      
        public void RefreshComboBox()
        {
            SQLCONN3.OpenConection3();
            cmbAssetModel.ValueMember = "AssetModeID";
            cmbAssetModel.DisplayMember = "AssetModel";
            cmbAssetModel.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetModeID ,AssetModel FROM AssetsModel ");
            SQLCONN3.CloseConnection();
        }

        private void cmbAssetModel_Click(object sender, EventArgs e)
        {
            //SQLCONN3.OpenConection3();
            //cmbAssetModel.ValueMember = "AssetModeID";
            //cmbAssetModel.DisplayMember = "AssetModel";
            //cmbAssetModel.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetModeID ,AssetModel FROM AssetsModel ");
            ////cmbAssetModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ////cmbAssetModel.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbAssetModel.Text = "Select";
            //SQLCONN3.CloseConnection();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
//            SqlParameter paramID = new SqlParameter("@id", SqlDbType.NVarChar);
//            paramID.Value = AssetID;
//            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
//            paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
//            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
//            paramValue.Value = txtvalue.Text;
//            SqlParameter paramcmbOS = new SqlParameter("@C3", SqlDbType.Int);
//            paramcmbOS.Value = cmbVersion.SelectedValue;

//            if (AssetDetialsInfoID == string.Empty)
//            {
//                MessageBox.Show("Please select  Asset first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

//            }
//            else
//            {
//                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
//                {
//                    SQLCONN3.OpenConection3();

//                    if ((int)cmbdeviceatt.SelectedValue == 20)
//                    {
//                        SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id and DeviceDetilasID = @C1 and value = @C3 ", paramID, paramDeviceatt, paramcmbOS);
//                        cmbVersion.Text = "";
//                    }
//                    else

//                    {
//                        SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id and DeviceDetilasID = @C1 and value = @C2 ", paramID, paramDeviceatt, paramValue);

//                    }



//                    //dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox("select * from AssetsDetials where AssetID=@id and DeviceDetilasID=@C1 and value=@C2 "
//                    //   , paramID,paramDeviceatt,paramValue);

//                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@" select 
//Assets.AssetID,
//DeviceDetials.DeviceDetilasID,
// DeviceDetials.DeviceDetialsValue,AssetsDetials.Value
//from Assets,AssetsDetials,DeviceDetials
//where 
//  DeviceDetials.DeviceDetilasID= AssetsDetials.DeviceDetilasID
// and Assets.AssetID= AssetsDetials.AssetID
// and Assets.AssetID=@ID ", paramID);
//                    MessageBox.Show("Record has been deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                    SQLCONN3.CloseConnection();
//                    cmbtype.Text = "Select";
//                    cmbdeviceatt.Text = "Select";
//                    cmbbrand.Text = "";
//                    cmbAssetModel.Text = "Select";
//                    txtvalue.Text = "";



//                }

//            }
        }

        private void cmbbrand_KeyDown(object sender, KeyEventArgs e)
        {

        }


    }
}



