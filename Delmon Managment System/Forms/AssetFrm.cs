using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader; // You need to install ExcelDataReader package via NuGet
using System.Runtime.InteropServices;



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
            AssignDtp.Format = DateTimePickerFormat.Custom;
            AssignDtp.CustomFormat = "yyyy-MM-dd HH:mm:ss";
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

       

        public async void AssetFrm_Load(object sender, EventArgs e)
        {
          

            await Task.Run(() =>
            {
                // Load user permissions asynchronously
                LoadUserPermissions();

                // Load combo box data asynchronously with the appropriate connection string
                var employeeTask = Task.Run(() => GetDataTable("SELECT EmployeeID, CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) 'FullName' FROM Employees ORDER BY EmployeeID", SQLCONN.ConnectionString));
                var assetTypeTask = Task.Run(() => GetDataTable("SELECT AssetTypeID,AssettypeValue FROM AssetType", SQLCONN3.ConnectionString3));
                var deviceDetailsTask = Task.Run(() => GetDataTable("SELECT DeviceDetilasID ,DeviceDetialsValue FROM DeviceDetials", SQLCONN3.ConnectionString3));
                var deviceTypesTask = Task.Run(() => GetDataTable("SELECT DeviceTypeID , DeviceType FROM DeviceTypes", SQLCONN3.ConnectionString3));
                var assetStatusTask = Task.Run(() => GetDataTable("SELECT AssetStatusID ,AssetStatus FROM AssetsStatus", SQLCONN3.ConnectionString3));
                var assetModelTask = Task.Run(() => GetDataTable("SELECT AssetModeID ,AssetModel FROM AssetsModel", SQLCONN3.ConnectionString3));
                var osVersionTask = Task.Run(() => GetDataTable("SELECT OSVersionID ,OSVerisonValue FROM OSVerisons", SQLCONN3.ConnectionString3));
                var assetBrandTask = Task.Run(() => GetDataTable("SELECT AssetBrandID ,AssetBrandValue FROM AssetBrand", SQLCONN3.ConnectionString3));

                // Wait for all tasks to complete
                Task.WaitAll(employeeTask, assetTypeTask, deviceDetailsTask, deviceTypesTask, assetStatusTask, assetModelTask, osVersionTask, assetBrandTask);

                // Update UI on the main thread
                this.Invoke((Action)(() =>
                {
                    // Set combo box data sources
                    SetComboBoxDataSource(cmbemployee, employeeTask.Result, "EmployeeID", "FullName");
                    SetComboBoxDataSource(cmbtype, assetTypeTask.Result, "AssetTypeID", "AssettypeValue");
                    SetComboBoxDataSource(cmbdeviceatt, deviceDetailsTask.Result, "DeviceDetilasID", "DeviceDetialsValue");
                    SetComboBoxDataSource(cmbDevice, deviceTypesTask.Result, "DeviceTypeID", "DeviceType");
                    SetComboBoxDataSource(cmbAssetStatus, assetStatusTask.Result, "AssetStatusID", "AssetStatus");
                    SetComboBoxDataSource(cmbAssetModel, assetModelTask.Result, "AssetModeID", "AssetModel");
                    SetComboBoxDataSource(cmbVersion, osVersionTask.Result, "OSVersionID", "OSVerisonValue");
                    SetComboBoxDataSource(cmbbrand, assetBrandTask.Result, "AssetBrandID", "AssetBrandValue");

                    // Set other properties
                    SetComboBoxDefaults();

                    // Initialize other controls
                    InitializeControls();
                }));
            });
        }

        private DataTable GetDataTable(string query, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }

        private void LoadUserPermissions()
        {
            using (var connection = new SqlConnection(SQLCONN.ConnectionString))
            using (var command = new SqlCommand(@"
        SELECT ps.PermissionName
        FROM UserPermissions us
        JOIN tblUser u ON us.UserID = u.EmployeeID
        JOIN Permissions ps ON us.PermissionID = ps.PermissionID
        WHERE u.EmployeeID = @UserID", connection))
            {
                command.Parameters.Add(new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = CommonClass.EmployeeID });
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string permissionName = reader["PermissionName"].ToString();
                        if (permissionName.Contains("ViewAssets")) hasView = true;
                        if (permissionName.Contains("EditAssets")) hasEdit = true;
                        if (permissionName.Contains("DeleteAssets")) hasDelete = true;
                        if (permissionName.Contains("AddAssets")) hasAdd = true;
                    }
                }
            }

            this.Invoke((Action)(() =>
            {
                if (!hasView)
                {
                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    groupBox1.Enabled = false;
                    tabControl2.Enabled = false;
                }
                else
                {
                    groupBox1.Enabled = true;
                    tabControl2.Enabled = true;

                    updatebtn.Enabled = hasEdit;
                    button3.Enabled = hasEdit;
                    btnDelete.Enabled = hasDelete;
                    button1.Enabled = hasDelete;
                    btnuplode2.Enabled = hasAdd;
                    button2.Enabled = hasAdd;
                    btnnew.Enabled = hasAdd;
                    btnuplode.Enabled = hasAdd;
                    addbtn.Enabled = hasAdd;
                    btnDownload.Enabled = hasAdd;
                }
            }));
        }
        private void SetComboBoxDataSource(ComboBox comboBox, DataTable dataSource, string valueMember, string displayMember)
        {
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.DataSource = dataSource;
        }

        private void SetComboBoxDefaults()
        {
            cmbemployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbtype.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbtype.Text = "Select";
            cmbdeviceatt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbdeviceatt.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbdeviceatt.Text = "Select";
            cmbDevice.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDevice.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbDevice.Text = "Select";
            cmbAssetStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAssetStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAssetStatus.Text = "Select";
            cmbAssetModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAssetModel.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAssetModel.Text = "Select";
            cmbVersion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbVersion.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbVersion.Text = "Select";
            cmbbrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbbrand.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbbrand.Text = "Select";
        }

        private void InitializeControls()
        {
            timer1.Interval = 1000;
            timer1.Start();
            lblusername.Text = CommonClass.LoginUserName;
            lblemail.Text = CommonClass.Email;
            LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;
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
            if ((int)cmbtype.SelectedValue == 1 || (int)cmbtype.SelectedValue == 2 || (int)cmbtype.SelectedValue == 4 || (int)cmbtype.SelectedValue == 9  || (int)cmbtype.SelectedValue == 10)
            {
                SQLCONN3.OpenConection3();
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

            conn.Close();



            //if ((int)cmbtype.SelectedValue == 1 || (int)cmbtype.SelectedValue == 2 || (int)cmbtype.SelectedValue == 4)
            //{
            //    string query2 = @"SELECT DeviceTypeID ,DeviceType FROM DeviceTypes where AssetTypeID= @C11";

            //    cmbDevice.ValueMember = "DeviceTypeID";
            //    cmbDevice.DisplayMember = "DeviceType";
            //    cmbDevice.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(query2, paramAssetSearch);
            //    cmbDevice.Text = "Select";
            //}
            //else
            //{
            //    cmbDevice.Text = "Select";
            //}



            //        SQLCONN3.CloseConnection();
            SQLCONN3.CloseConnection();

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            addbtn.Visible =btnDownload.Visible= true;
            updatebtn.Visible = false;
            btnuplode.Visible = true;
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
                case 9:
                    return "CM";
                case 10:
                    return "PH";

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

            /*price*/
            SqlParameter paramAssestPrice = new SqlParameter("@C11", SqlDbType.NVarChar);
            paramAssestPrice.Value = string.IsNullOrEmpty(PriceTXT.Text) ? "0" : PriceTXT.Text;
            /*price*/

            /*username*/
            SqlParameter paramAssinedBy = new SqlParameter("@C12", SqlDbType.NVarChar);
            paramAssinedBy.Value = CommonClass.LoginUserName;
            /*username*/

            int assetTypeID = (int)cmbtype.SelectedValue;
            int nextID = GetNextIDForAssetType(assetTypeID);
            string generatedAssetID = GenerateAssetID(assetTypeID, nextID);

            SqlParameter paramgeneratedAssetID = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramgeneratedAssetID.Value = generatedAssetID;

            SqlDataReader dr;

            if ((int)cmbtype.SelectedValue != 0 && (int)cmbbrand.SelectedValue != 0 && (int)cmbAssetModel.SelectedValue != 0
                && (int)cmbDevice.SelectedValue != 0 && (int)cmbAssetStatus.SelectedValue != 0 && !string.IsNullOrEmpty(txtSN.Text))
            {
                SQLCONN3.OpenConection3();
                SQLCONN.OpenConection();
                dr = SQLCONN3.DataReader("select * from Assets where (brand=@C2 and model=@C3 and sn=@C5) or (sn=@C5)", paramcmbrand, paramassetmodel, paramSN);

                dr.Read();

                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Asset / SN '  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dr.Dispose();

                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        dr.Dispose();
                        dr.Close();

                        // Insert into Assets
                        SQLCONN3.ExecuteQueries("insert into Assets ([AssetID],[AssetTypeID],[brand],[model],[SapAssetID],[SN],[PurchasingDate],[DeviceTypeID],[AssetStatusID],Price) " +
                            "values (@C0,@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8,@C11)",
                            paramgeneratedAssetID, paramcmbtype, paramcmbrand, paramassetmodel,
                            paramSAPAssetid, paramSN, paramPurchasingdate, paramcmbDevice, paramcmbAssetStatus, paramAssestPrice);

                        // Insert into AssetAssign
                        SQLCONN3.ExecuteQueries("insert into AssetAssign ([AssetID],[EmployeeID],[AssginDate],AssignedBy) " +
                            "values (@C0,@C9,@C10,@C12)",
                            paramgeneratedAssetID, paramcmbAssignto, paramAssigndate, paramAssinedBy);

                        MessageBox.Show("Record saved Successfully");

                        // Fetch the max AssetID and log the changes
                        string maxAssetID = GetMaxAssetID();
                        LogAssetChanges(maxAssetID);

                        btnnew.Visible = true;
                        dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
                    SELECT 
                        Assets.AssetID, Assets.SapAssetId, Assets.sn, AssetType.AssettypeValue, 
                        AssetBrand.AssetBrandValue, Assets.Model, [PurchasingDate],
                        [DeviceTypeID], [AssetStatusID], [EmployeeID], [AssginDate], Price, AssignedBy
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
                        Assets.PurchasingDate = @C6", paramcmbtype, paramcmbrand, paramassetmodel, paramSN, paramPurchasingdate);
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
                MessageBox.Show("Please Fill the missing fields");
            }

            SQLCONN3.CloseConnection();
            SQLCONN.CloseConnection();
        }

        private string GetMaxAssetID()
        {
            string maxAssetID = "";
            string assetDbConnectionString = SQLCONN.ConnectionString3;
            DataTable assetData = new DataTable();

            using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
            {
                assetDbConnection.Open();
                string sql = "SELECT MAX(AssetID) AS MaxAssetID FROM Assets";
                SqlDataAdapter da = new SqlDataAdapter(sql, assetDbConnection);
                da.Fill(assetData);
                if (assetData.Rows.Count > 0)
                {
                    maxAssetID = assetData.Rows[0]["MaxAssetID"].ToString();
                }
            }
            return maxAssetID;
        }

        private void LogAssetChanges(string assetID)
        {
            // Log the details of the newly added asset
            string assetDbConnectionString = SQLCONN.ConnectionString3;
            DataTable assetData = new DataTable();

            using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
            {
                assetDbConnection.Open();
                string sql = "SELECT * FROM Assets WHERE AssetID = @AssetID";
                SqlDataAdapter da = new SqlDataAdapter(sql, assetDbConnection);
                da.SelectCommand.Parameters.AddWithValue("@AssetID", assetID);
                da.Fill(assetData);
            }

            using (SqlConnection logDbConnection = new SqlConnection(SQLCONN.ConnectionString))
            {
                logDbConnection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue, logdatetime, PCNAME, UserId, type) VALUES (@FileNumberid, @ColumnName, @OldValue, @NewValue, @datetime, @pc, @user, @type)", logDbConnection))
                {
                    foreach (DataColumn column in assetData.Columns)
                    {
                        object value = assetData.Rows[0][column.ColumnName];
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@FileNumberid", assetID + " - " + "Assets");
                        command.Parameters.AddWithValue("@ColumnName", column.ColumnName);
                        command.Parameters.AddWithValue("@OldValue", DBNull.Value); // No old value since it's a new insert
                        command.Parameters.AddWithValue("@NewValue", value ?? DBNull.Value);
                        command.Parameters.AddWithValue("@datetime", DateTime.Parse(lbldatetime.Text));
                        command.Parameters.AddWithValue("@pc", Environment.MachineName);
                        command.Parameters.AddWithValue("@user", CommonClass.LoginUserName);
                        command.Parameters.AddWithValue("@type", "Insert");

                        command.ExecuteNonQuery();
                    }
                }
            }
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
        asi.AssignedBy,
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
    DT.DeviceType,
    A.AssetStatusID,
    CONCAT(E.FirstName, ' ', E.SecondName, ' ', E.ThirdName, ' ', E.LastName) AS FullName,
    LA.EmployeeID AS LastEmployeeID,
    LA.AssginDate AS LastAssignDate,
    A.Price

FROM
    Assets A
INNER JOIN 
    DeviceTypes DT ON A.DeviceTypeID = DT.DeviceTypeID
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
    DT.DeviceType LIKE '%' + @C1 + '%' OR
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

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            addbtn.Visible = false;
            btnnew.Visible = updatebtn.Visible = btnDelete.Visible = true;

            await LoadComboBoxDataAsync();

            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            // Populate fields
            AssetID = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
            AssetIDTXT.Text = AssetID;
            txtsapid.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;
            txtSN.Text = selectedRow.Cells[2].Value?.ToString() ?? string.Empty;
            cmbtype.Text = selectedRow.Cells[3].Value?.ToString() ?? string.Empty;
            cmbbrand.Text = selectedRow.Cells[4].Value?.ToString() ?? string.Empty;
            cmbAssetModel.SelectedValue = selectedRow.Cells[5].Value?.ToString() ?? string.Empty;

            DateTime.TryParse(selectedRow.Cells[6].Value?.ToString(), out DateTime purchasingDate);
            PurchasingDtp.Value = purchasingDate == DateTime.MinValue ? DateTime.Now : purchasingDate;

            cmbDevice.Text = selectedRow.Cells[7].Value?.ToString() ?? string.Empty;
            cmbAssetStatus.SelectedValue = selectedRow.Cells[8].Value?.ToString() ?? string.Empty;

            if (selectedRow.Cells[9].Value != null && !string.IsNullOrEmpty(selectedRow.Cells[9].Value.ToString()))
            {
                cmbemployee.Text = selectedRow.Cells[9].Value.ToString();
            }
            else
            {
                cmbemployee.SelectedValue = 0; // or any default value you want to assign
            }

            DateTime.TryParse(selectedRow.Cells[11].Value?.ToString(), out DateTime assignDate);
            AssignDtp.Value = assignDate == DateTime.MinValue ? DateTime.Now : assignDate;
            PriceTXT.Text = string.IsNullOrEmpty(selectedRow.Cells[12].Value?.ToString()) ? "0" : selectedRow.Cells[12].Value.ToString();

           
        }

        private async Task LoadComboBoxDataAsync()
        {
            await Task.Run(() =>
            {
                SQLCONN3.OpenConection3();
                var deviceTypes = SQLCONN3.ShowDataInGridViewORCombobox("SELECT DeviceTypeID, DeviceType FROM DeviceTypes");
                var assetStatuses = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetStatusID, AssetStatus FROM AssetsStatus");
                var assetModels = SQLCONN3.ShowDataInGridViewORCombobox("SELECT AssetModeID, AssetModel FROM AssetsModel");

                this.Invoke((Action)(() =>
                {
                    cmbDevice.ValueMember = "DeviceTypeID";
                    cmbDevice.DisplayMember = "DeviceType";
                    cmbDevice.DataSource = deviceTypes;

                    cmbAssetStatus.ValueMember = "AssetStatusID";
                    cmbAssetStatus.DisplayMember = "AssetStatus";
                    cmbAssetStatus.DataSource = assetStatuses;

                    cmbAssetModel.ValueMember = "AssetModeID";
                    cmbAssetModel.DisplayMember = "AssetModel";
                    cmbAssetModel.DataSource = assetModels;
                    cmbAssetModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbAssetModel.AutoCompleteSource = AutoCompleteSource.ListItems;
                }));

                SQLCONN3.CloseConnection();
            });
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (AssetID == null)
            {
                MessageBox.Show("Please Select Record to Update");
                tabControl1.Enabled = false;
                return;
            }

            if (cmbtype.Text == "Select")
            {
                MessageBox.Show("Please Select a Type !!");
                return;
            }

            if (cmbbrand.Text == "")
            {
                MessageBox.Show("Please Select Brand !!");
                return;
            }

            if (cmbAssetModel.Text == "Select")
            {
                MessageBox.Show("Please insert Asset Model !!");
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            try
            {
                // Prepare parameters
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@C1", SqlDbType.NVarChar) { Value = cmbtype.SelectedValue },
            new SqlParameter("@C2", SqlDbType.NVarChar) { Value = cmbbrand.SelectedValue },
            new SqlParameter("@C3", SqlDbType.NVarChar) { Value = cmbAssetModel.SelectedValue },
            new SqlParameter("@C4", SqlDbType.NVarChar) { Value = txtsapid.Text },
            new SqlParameter("@C5", SqlDbType.NVarChar) { Value = txtSN.Text },
            new SqlParameter("@idd", SqlDbType.NVarChar) { Value = AssetID },
            new SqlParameter("@C6", SqlDbType.DateTime) { Value = PurchasingDtp.Value },
            new SqlParameter("@C7", SqlDbType.NVarChar) { Value = cmbDevice.SelectedValue },
            new SqlParameter("@C8", SqlDbType.NVarChar) { Value = cmbAssetStatus.SelectedValue },
            new SqlParameter("@C9", SqlDbType.NVarChar) { Value = cmbemployee.SelectedValue },
            new SqlParameter("@C10", SqlDbType.DateTime) { Value = AssignDtp.Value },
            new SqlParameter("@C11", SqlDbType.Decimal) { Value = decimal.Parse(PriceTXT.Text) },
            new SqlParameter("@id", SqlDbType.NVarChar) { Value = CommonClass.EmployeeID },
            new SqlParameter("@user", SqlDbType.NVarChar) { Value = lblusername.Text },
            new SqlParameter("@datetime", SqlDbType.DateTime) { Value = DateTime.Parse(lbldatetime.Text) },
            new SqlParameter("@pc", SqlDbType.NVarChar) { Value = lblPC.Text },
            new SqlParameter("@C12", SqlDbType.NVarChar) { Value = CommonClass.LoginUserName }
        };

                SQLCONN3.OpenConection3();
                SQLCONN.OpenConection3();

                // Fetch original data from DelmonGroupAssets database
                DataTable originalData = new DataTable();
                string assetDbConnectionString = SQLCONN.ConnectionString3;
                using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
                {
                    assetDbConnection.Open();
                    string sql = "SELECT * FROM Assets WHERE AssetID = @AssetID";
                    SqlDataAdapter da = new SqlDataAdapter(sql, assetDbConnection);
                    da.SelectCommand.Parameters.AddWithValue("@AssetID", AssetID);
                    da.Fill(originalData);
                }

                // Query the current values for the asset assignment
                string checkQuery = @"
            SELECT TOP 1 EmployeeID, AssginDate 
            FROM AssetAssign 
            WHERE AssetID = @idd 
            ORDER BY AssginDate DESC";

                SqlDataReader dr = SQLCONN3.DataReader(checkQuery, new SqlParameter("@idd", AssetID));
                bool valuesChanged = true;

                if (dr.Read())
                {
                    string currentEmployeeID = dr["EmployeeID"].ToString();
                    DateTime currentAssignDate = DateTime.Parse(dr["AssginDate"].ToString());

                    valuesChanged = currentEmployeeID != cmbemployee.SelectedValue.ToString() ||
                                    currentAssignDate != AssignDtp.Value;
                }
                dr.Close();

                // Update Assets
                string updateQuery = "UPDATE Assets SET AssetTypeID=@C1, Brand=@C2, Model=@C3, SAPAssetId=@C4, Sn=@C5, PurchasingDate=@C6, DeviceTypeID=@C7, AssetStatusID=@C8, Price=@C11 WHERE AssetID=@idd";
                SQLCONN3.ExecuteQueries(updateQuery, parameters.ToArray());

                // Insert into AssetAssign only if values have changed
                if (valuesChanged)
                {
                    string insertQuery = "INSERT INTO AssetAssign (AssetID, EmployeeID, AssginDate,AssignedBy) VALUES (@idd, @C9, @C10,@C12)";
                    SQLCONN3.ExecuteQueries(insertQuery, parameters.ToArray());
                }

                MessageBox.Show("Record Updated Successfully");

                // Fetch updated data from DelmonGroupAssets database
                DataTable updatedData = new DataTable();
                using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
                {
                    assetDbConnection.Open();
                    string sql = "SELECT * FROM Assets WHERE AssetID = @AssetID";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, assetDbConnection);
                    adapter.SelectCommand.Parameters.AddWithValue("@AssetID", AssetID);
                    adapter.Fill(updatedData);
                }

                // Compare the two DataTables and find the changed columns
                List<string> changedColumns = new List<string>();
                foreach (DataColumn column in originalData.Columns)
                {
                    object originalValue = originalData.Rows[0][column.ColumnName];
                    object updatedValue = updatedData.Rows[0][column.ColumnName];

                  
                    if (!Equals(originalValue, updatedValue))
                    {
                        changedColumns.Add(column.ColumnName);
                    }
                }

                // Insert the changes into the log table in DelmonGroupDB
                if (changedColumns.Count > 0)
                {
                    using (SqlConnection logDbConnection = new SqlConnection(SQLCONN.ConnectionString))
                    {
                        logDbConnection.Open();
                        using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue, logdatetime, PCNAME, UserId, type) VALUES (@FileNumberid, @ColumnName, @OldValue, @NewValue, @datetime, @pc, @user, @type)", logDbConnection))
                        {
                            foreach (string columnName in changedColumns)
                            {
                                object originalValue = originalData.Rows[0][columnName];
                                object updatedValue = updatedData.Rows[0][columnName];
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@FileNumberid", AssetID + " - " + "Asset");
                                command.Parameters.AddWithValue("@ColumnName", columnName);
                                command.Parameters.AddWithValue("@OldValue", originalValue ?? DBNull.Value);
                                command.Parameters.AddWithValue("@NewValue", updatedValue ?? DBNull.Value);
                                command.Parameters.AddWithValue("@datetime", DateTime.Parse(lbldatetime.Text));
                                command.Parameters.AddWithValue("@pc", Environment.MachineName);
                                command.Parameters.AddWithValue("@user", CommonClass.LoginUserName);
                                command.Parameters.AddWithValue("@type", "Update");

                              
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
           
                // Refresh DataGridView
                string selectQuery = @"
 
WITH LastAssignments AS (
    SELECT 
        asi.AssetID, 
        asi.EmployeeID, 
        asi.AssginDate,
        asi.AssignedBy,
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
    DT.DeviceType,
    A.AssetStatusID,
    CONCAT(E.FirstName, ' ', E.SecondName, ' ', E.ThirdName, ' ', E.LastName) AS FullName,
    LA.EmployeeID AS LastEmployeeID,
    LA.AssginDate AS LastAssignDate,
    A.Price

FROM
    Assets A
INNER JOIN 
    DeviceTypes DT ON A.DeviceTypeID = DT.DeviceTypeID
INNER JOIN 
    AssetBrand AB ON A.Brand = AB.AssetBrandID
INNER JOIN 
    AssetType AT ON A.AssetTypeID = AT.AssetTypeID
LEFT JOIN 
    LastAssignments LA ON A.AssetID = LA.AssetID AND LA.RowNum = 1
LEFT JOIN
    [DelmonGroupDB].[dbo].[Employees] E ON LA.EmployeeID = E.EmployeeID
WHERE A.AssetID = @idd";
                dataGridView1.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(selectQuery, new SqlParameter("@idd", AssetID));

                SQLCONN3.CloseConnection();
                SQLCONN.CloseConnection();
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Format Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SQLCONN3.CloseConnection();
                SQLCONN.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SQLCONN3.CloseConnection();
                SQLCONN.CloseConnection();
            }
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
    A.[AssginDate],A.[AssignedBy]
FROM 
    [AssetAssign] A  
INNER JOIN 
    [DelmonGroupDB].[dbo].[Employees] E ON A.[EmployeeID] = E.[EmployeeID]  
WHERE 
    A.[AssetID] = @ID
ORDER BY 
    A.[ID] DESC;", paramID);
                    dataGridView2.Columns[1].Width = 100;
                    dataGridView2.Columns[2].Width = 300;
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView2.Columns["AssginDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    dataGridView2.Columns["AssignedBy"].Width = 120;



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
            if (string.IsNullOrEmpty(AssetIDTXT.Text))
            {
                MessageBox.Show("Please Select Asset First !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!string.IsNullOrEmpty(AssetID) && (int)cmbdeviceatt.SelectedValue != 0)
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

                        SqlDataReader dr = SQLCONN3.DataReader("select * from [AssetsDetials] where AssetID=@ID and DeviceDetilasID=@C1 and value=@C2", paramID, paramDeviceatt, paramValue);
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
                                string encryptedValue = Encrypt(originalValue, encryptionKey, iv);
                                paramValue.Value = encryptedValue;
                            }
                            else
                            {
                                paramValue.Value = txtvalue.Text;
                            }

                            if ((int)cmbdeviceatt.SelectedValue == 20)
                            {
                                SQLCONN3.ExecuteQueries("insert into AssetsDetials (AssetID, DeviceDetilasID, Value) values (@ID, @C1, @C3)", paramID, paramDeviceatt, paramcmbOS);
                                LogAssetDetailChanges(AssetID,(int)cmbVersion.SelectedValue,txtvalue.Text);
                            }
                            else
                            {
                                SQLCONN3.ExecuteQueries("insert into AssetsDetials (AssetID, DeviceDetilasID, Value) values (@ID, @C1, @C2)", paramID, paramDeviceatt, paramValue);
                                LogAssetDetailChanges(AssetID,(int)cmbdeviceatt.SelectedValue,txtvalue.Text);
                            }

                            MessageBox.Show("Record saved Successfully");

                            // Fetch the max AssetDetailsID and log the changes
                           

                            dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"select 
                        Assets.AssetID,
                        DeviceDetials.DeviceDetilasID,
                        DeviceDetials.DeviceDetialsValue,
                        AssetsDetials.Value
                        from Assets, AssetsDetials, DeviceDetials
                        where 
                        DeviceDetials.DeviceDetilasID = AssetsDetials.DeviceDetilasID
                        and Assets.AssetID = AssetsDetials.AssetID
                        and Assets.AssetID = @ID", paramID);

                            cmbdeviceatt.Text = "Select";
                            txtvalue.Text = "";
                            SQLCONN3.CloseConnection();
                            cmbdeviceatt.SelectedValue = 0;
                            txtvalue.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Record or Device attribute!");
                }
            }
        }

        private string GetMaxAssetDetailsID()
        {
            string maxAssetDetailsID = "";
            string assetDbConnectionString = SQLCONN.ConnectionString3;
            DataTable assetDetailsData = new DataTable();

            using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
            {
                assetDbConnection.Open();
                string sql = "SELECT MAX(CONVERT(int, SUBSTRING(AssetID, PATINDEX('%[0-9]%', AssetID), LEN(AssetID)))) AS MaxAssetDetailsID FROM AssetsDetials";
                SqlDataAdapter da = new SqlDataAdapter(sql, assetDbConnection);
                da.Fill(assetDetailsData);
                if (assetDetailsData.Rows.Count > 0 && assetDetailsData.Rows[0]["MaxAssetDetailsID"] != DBNull.Value)
                {
                    maxAssetDetailsID = assetDetailsData.Rows[0]["MaxAssetDetailsID"].ToString();
                }
            }
            return maxAssetDetailsID;
        }


        private void LogAssetDetailChanges(string assetDetailsID, int Deviceattribute, string value)
        {
            string assetDbConnectionString = SQLCONN.ConnectionString3;
            DataTable assetDetailsData = new DataTable();

            using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
            {
                assetDbConnection.Open();
                string sql = "SELECT * FROM AssetsDetials WHERE AssetID = @AssetDetailsID";
                SqlDataAdapter da = new SqlDataAdapter(sql, assetDbConnection);
                da.SelectCommand.Parameters.AddWithValue("@AssetDetailsID", assetDetailsID);
                da.Fill(assetDetailsData);
            }

            // Ensure there are rows in the DataTable
            if (assetDetailsData.Rows.Count > 0)
            {
                using (SqlConnection logDbConnection = new SqlConnection(SQLCONN.ConnectionString))
                {
                    logDbConnection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue, logdatetime, PCNAME, UserId, type) VALUES (@FileNumberid, @ColumnName, @OldValue, @NewValue, @datetime, @pc, @user, @type)", logDbConnection))
                    {
                       
                            //object value = assetDetailsData.Rows[0][column.ColumnName];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@FileNumberid", assetDetailsID + " - " + "AssetsDetials");
                            command.Parameters.AddWithValue("@ColumnName", cmbdeviceatt.SelectedValue);
                            command.Parameters.AddWithValue("@OldValue", DBNull.Value); // No old value since it's a new insert
                            command.Parameters.AddWithValue("@NewValue", txtvalue.Text);
                            command.Parameters.AddWithValue("@datetime", DateTime.Parse(lbldatetime.Text));
                            command.Parameters.AddWithValue("@pc", Environment.MachineName);
                            command.Parameters.AddWithValue("@user", CommonClass.LoginUserName);
                            command.Parameters.AddWithValue("@type", "Insert");

                            command.ExecuteNonQuery();
                        
                    }
                }
            }
            else
            {
                // Handle the case where no data is found
                MessageBox.Show("No asset details found for the specified AssetID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LogAssetDetailDeleted(string assetDetailsID,int Deviceattribute,string value)
        {
            string assetDbConnectionString = SQLCONN.ConnectionString3;
            DataTable assetDetailsData = new DataTable();

            using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
            {
                assetDbConnection.Open();
                string sql = "SELECT * FROM AssetsDetials WHERE AssetID = @AssetDetailsID";
                SqlDataAdapter da = new SqlDataAdapter(sql, assetDbConnection);
                da.SelectCommand.Parameters.AddWithValue("@AssetDetailsID", assetDetailsID);
                da.Fill(assetDetailsData);
            }

            // Ensure there are rows in the DataTable
            if (assetDetailsData.Rows.Count > 0)
            {
                using (SqlConnection logDbConnection = new SqlConnection(SQLCONN.ConnectionString))
                {
                    logDbConnection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, NewValue, logdatetime, PCNAME, UserId, type) VALUES (@FileNumberid, @ColumnName, @NewValue, @datetime, @pc, @user, @type)", logDbConnection))
                    {
                        
                            //object value = assetDetailsData.Rows[0][column.ColumnName];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@FileNumberid", assetDetailsID + " - " + "AssetsDetials");
                            command.Parameters.AddWithValue("@ColumnName", cmbdeviceatt.SelectedValue);
                            //command.Parameters.AddWithValue("@OldValue", DBNull.Value); // No old value since it's a new insert
                            command.Parameters.AddWithValue("@NewValue", txtvalue.Text );
                            command.Parameters.AddWithValue("@datetime", DateTime.Parse(lbldatetime.Text));
                            command.Parameters.AddWithValue("@pc", Environment.MachineName);
                            command.Parameters.AddWithValue("@user", CommonClass.LoginUserName);
                            command.Parameters.AddWithValue("@type", "Delete");

                            command.ExecuteNonQuery();
                        
                    }
                }
            }
            else
            {
                // Handle the case where no data is found
                MessageBox.Show("No asset details found for the specified AssetID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AssetIDTXT.Text == "")
            {
                MessageBox.Show("Please Select Asset First. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
            paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            SqlParameter paramcmbOS = new SqlParameter("@C3", SqlDbType.Int);
            paramcmbOS.Value = cmbVersion.SelectedValue;
            paramValue.Value = txtvalue.Text;
            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramID.Value = AssetID;

            // Fetch original data from DelmonGroupAssets database
            DataTable originalData = new DataTable();
            string assetDbConnectionString = SQLCONN.ConnectionString3;
            using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
            {
                assetDbConnection.Open();
                string sql = "SELECT * FROM AssetsDetials WHERE AssetID = @AssetID AND DeviceDetilasID = @C1";
                SqlDataAdapter da = new SqlDataAdapter(sql, assetDbConnection);
                da.SelectCommand.Parameters.AddWithValue("@AssetID", AssetID);
                da.SelectCommand.Parameters.AddWithValue("@C1", paramDeviceatt.Value);
                da.Fill(originalData);
            }

            if (AssetID != string.Empty && ((int)cmbdeviceatt.SelectedValue != 0))
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();

                    if (cmbdeviceatt.SelectedValue != null && (int)cmbdeviceatt.SelectedValue == 100)
                    {
                        string originalValue = txtvalue.Text.ToString();
                        string encryptedValue = Encrypt(originalValue, encryptionKey, iv);
                        paramValue.Value = encryptedValue;
                        MessageBox.Show(paramValue.Value.ToString());
                    }
                    else
                    {
                        paramValue.Value = txtvalue.Text;
                    }

                    if ((int)cmbdeviceatt.SelectedValue == 20)
                    {
                        SQLCONN3.ExecuteQueries("UPDATE AssetsDetials SET AssetID=@ID, DeviceDetilasID=@C1, Value=@C3 WHERE AssetID=@ID AND DeviceDetilasID=@C1",
                                                paramID, paramDeviceatt, paramcmbOS);
                    }
                    else
                    {
                        SQLCONN3.ExecuteQueries("UPDATE AssetsDetials SET AssetID=@ID, DeviceDetilasID=@C1, Value=@C2 WHERE AssetID=@ID AND DeviceDetilasID=@C1",
                                                paramID, paramDeviceatt, paramValue);
                    }

                    MessageBox.Show("Record updated Successfully");

                    // Fetch updated data from DelmonGroupAssets database
                    DataTable updatedData = new DataTable();
                    using (SqlConnection assetDbConnection = new SqlConnection(assetDbConnectionString))
                    {
                        assetDbConnection.Open();
                        string sql = "SELECT * FROM AssetsDetials WHERE AssetID = @AssetID AND DeviceDetilasID = @C1";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, assetDbConnection);
                        adapter.SelectCommand.Parameters.AddWithValue("@AssetID", AssetID);
                        adapter.SelectCommand.Parameters.AddWithValue("@C1", paramDeviceatt.Value);
                        adapter.Fill(updatedData);
                    }

                    // Compare the two DataTables and find the changed columns
                    List<string> changedColumns = new List<string>();
                    foreach (DataColumn column in originalData.Columns)
                    {
                        object originalValue = originalData.Rows[0][column.ColumnName];
                        object updatedValue = updatedData.Rows[0][column.ColumnName];

                        if (!Equals(originalValue, updatedValue))
                        {
                            changedColumns.Add(column.ColumnName);
                        }
                    }

                    // Insert the changes into the log table in DelmonGroupDB
                    if (changedColumns.Count > 0)
                    {
                        using (SqlConnection logDbConnection = new SqlConnection(SQLCONN.ConnectionString))
                        {
                            logDbConnection.Open();
                            using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue, logdatetime, PCNAME, UserId, type) VALUES (@FileNumberid, @ColumnName, @OldValue, @NewValue, @datetime, @pc, @user, @type)", logDbConnection))
                            {
                                foreach (string columnName in changedColumns)
                                {
                                    object originalValue = originalData.Rows[0][columnName];
                                    object updatedValue = updatedData.Rows[0][columnName];
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@FileNumberid", AssetID + " - " + "AssetsDetials");
                                    command.Parameters.AddWithValue("@ColumnName", columnName);
                                    command.Parameters.AddWithValue("@OldValue", originalValue ?? DBNull.Value);
                                    command.Parameters.AddWithValue("@NewValue", updatedValue ?? DBNull.Value);
                                    command.Parameters.AddWithValue("@datetime", DateTime.Parse(lbldatetime.Text));
                                    command.Parameters.AddWithValue("@pc", Environment.MachineName);
                                    command.Parameters.AddWithValue("@user", CommonClass.LoginUserName);
                                    command.Parameters.AddWithValue("@type", "Update");

                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    cmbdeviceatt.SelectedValue = 0;
                    txtvalue.Text = "";

                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"SELECT 
                Assets.AssetID,
                DeviceDetials.DeviceDetilasID,
                DeviceDetials.DeviceDetialsValue,
                AssetsDetials.Value
                FROM Assets, AssetsDetials, DeviceDetials
                WHERE DeviceDetials.DeviceDetilasID = AssetsDetials.DeviceDetilasID
                AND Assets.AssetID = AssetsDetials.AssetID
                AND Assets.AssetID = @ID", paramID);

                    cmbdeviceatt.Text = "Select";
                    txtvalue.Text = "";
                    SQLCONN3.CloseConnection();
                }
                else
                {
                    // Handle case where user chooses not to perform the operation
                }
            }
            else
            {
                MessageBox.Show("Please Select Record !!");
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
                    if (cellValue == "1" || cellValue == "2" || cellValue == "3" || cellValue == "4" || cellValue == "5" || cellValue == "6"
                                                || cellValue == "7")
                    {
                        cmbVersion.SelectedValue = cellValue;
                    }
                    else
                    {
                        cmbVersion.Text = cellValue;
                    }
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
                        if (cellValue == "1" || cellValue == "2" || cellValue == "3" || cellValue == "4" || cellValue == "5" || cellValue == "6"
                            || cellValue == "7")
                        {
                            cmbVersion.SelectedValue = cellValue;
                        }
                        else 
                        {
                            cmbVersion.Text = cellValue;
                        }
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
              
                CONCAT(E.[FirstName], ' ', E.[SecondName], ' ', E.[ThirdName], ' ', E.[LastName]) AS 'FullName',  A.[AssginDate] ,A.[AssignedBy]
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
                //assign history 
                if (tabControl2.SelectedTab == tabControl2.TabPages[1])
                {
                    dataGridView2.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"
            SELECT  
                A.[AssetID], 
              
                CONCAT(E.[FirstName], ' ', E.[SecondName], ' ', E.[ThirdName], ' ', E.[LastName]) AS 'FullName',  A.[AssginDate],A.[AssignedBy]
            FROM
                [DelmonGroupAssests].[dbo].[AssetAssign] A
            INNER JOIN 
                [DelmonGroupDB].[dbo].[Employees] E ON A.[EmployeeID] = E.[EmployeeID] AND assetid = @ID", paramID);
                }
                dataGridView2.Columns[1].Width = 100;
                dataGridView2.Columns[2].Width = 300;
                dataGridView2.Columns["AssginDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";


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
                MessageBox.Show("Please select Asset first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    // Fetch the asset details before deletion
                    //DataTable assetDetailsData = GetAssetDetailsBeforeDeletion(paramID, paramDeviceatt, paramValue, paramcmbOS);

                    SQLCONN3.OpenConection3();

                    if ((int)cmbdeviceatt.SelectedValue == 20)
                    {
                        SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id and DeviceDetilasID = @C1 and value = @C3", paramID, paramDeviceatt, paramcmbOS);
                        cmbVersion.Text = "";
                    }
                    else
                    {
                        SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id and DeviceDetilasID = @C1 and value = @C2", paramID, paramDeviceatt, paramValue);
                    }

                    // Log the deleted asset details
                    if ((int)cmbdeviceatt.SelectedValue == 20)
                    {
                        LogAssetDetailDeleted(AssetID, (int)cmbVersion.SelectedValue, txtvalue.Text);

                    }
                    else 
                    {
                        LogAssetDetailDeleted(AssetID, (int)cmbdeviceatt.SelectedValue, txtvalue.Text);

                    }
                       
                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"select 
                Assets.AssetID,
                DeviceDetials.DeviceDetilasID,
                DeviceDetials.DeviceDetialsValue,
                AssetsDetials.Value
            from Assets, AssetsDetials, DeviceDetials
            where 
                DeviceDetials.DeviceDetilasID = AssetsDetials.DeviceDetilasID
                and Assets.AssetID = AssetsDetials.AssetID
                and Assets.AssetID = @ID", paramID);

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


        /***download asset template ***/
        // Define the GUID for the Downloads folder
        private static readonly Guid DownloadsFolderGuid = new Guid("374DE290-123F-4565-9164-39C4925E467B");

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);

        private string GetDownloadsPath()
        {
            IntPtr ppszPath;
            Guid folderGuid = DownloadsFolderGuid;  // Create a local variable
            SHGetKnownFolderPath(ref folderGuid, 0, IntPtr.Zero, out ppszPath);
            string path = Marshal.PtrToStringAuto(ppszPath);
            Marshal.FreeCoTaskMem(ppszPath);
            return path;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // Source file path
            string sourceFilePath = @"\\192.168.1.15\Development\AssetImport.xlsx";

            // Destination file path in the Downloads folder
            string downloadsPath = GetDownloadsPath();
            string destinationFilePath = Path.Combine(downloadsPath, "AssetImport.xlsx");

            try
            {
                // Copy the file from the source to the destination
                File.Copy(sourceFilePath, destinationFilePath, true);
                MessageBox.Show($"File downloaded successfully to {destinationFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle any errors that occurred during the file copy
                MessageBox.Show($"An error occurred while downloading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /***download asset template ***/


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
            SqlParameter paramID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramID.Value = AssetID;
            SqlParameter paramDeviceatt = new SqlParameter("@C1", SqlDbType.Int);
            paramDeviceatt.Value = cmbdeviceatt.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramValue.Value = txtvalue.Text;
            SqlParameter paramcmbOS = new SqlParameter("@C3", SqlDbType.Int);
            paramcmbOS.Value = cmbVersion.SelectedValue;

            if (string.IsNullOrEmpty(AssetDetialsInfoID))
            {
                MessageBox.Show("Please select Asset first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation? All the Asset Detials will be deleted !", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN3.OpenConection3();

                    // Fetch the asset details before deletion
                    DataTable assetDetailsData = GetAssetDetailsBeforeDeletion(paramID, paramDeviceatt, paramValue, paramcmbOS);

                    if ((int)cmbdeviceatt.SelectedValue == 20)
                    {
                        SQLCONN3.ExecuteQueries("delete Assets where AssetID =@id  ", paramID);
                        SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id  ", paramID);
                        cmbVersion.Text = "";
                    }
                    else
                    {
                        SQLCONN3.ExecuteQueries("delete Assets where AssetID =@id  ", paramID);
                        SQLCONN3.ExecuteQueries("delete AssetsDetials where AssetID =@id  ", paramID);
                    }

                    // Log the deleted asset details
                    LogAssetDetailChanges(assetDetailsData, "Delete");

                    dataGridView5.DataSource = SQLCONN3.ShowDataInGridViewORCombobox(@"select 
                Assets.AssetID,
                DeviceDetials.DeviceDetilasID,
                DeviceDetials.DeviceDetialsValue,
                AssetsDetials.Value
                from Assets, AssetsDetials, DeviceDetials
                where 
                DeviceDetials.DeviceDetilasID = AssetsDetials.DeviceDetilasID
                and Assets.AssetID = AssetsDetials.AssetID
                and Assets.AssetID = @ID", paramID);

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

        private DataTable GetAssetDetailsBeforeDeletion(SqlParameter paramID, SqlParameter paramDeviceatt, SqlParameter paramValue, SqlParameter paramcmbOS)
        {
            DataTable assetDetailsData = new DataTable();
            using (SqlConnection assetDbConnection = new SqlConnection(SQLCONN3.ConnectionString3))
            {
                assetDbConnection.Open();
                string sql = "SELECT * FROM AssetsDetials WHERE AssetID = @id AND DeviceDetilasID = @C1 AND (Value = @C2 OR Value = @C3)";
                SqlDataAdapter da = new SqlDataAdapter(sql, assetDbConnection);
                da.SelectCommand.Parameters.Add(paramID);
                da.SelectCommand.Parameters.Add(paramDeviceatt);
                da.SelectCommand.Parameters.Add(paramValue);
                da.SelectCommand.Parameters.Add(paramcmbOS);
                da.Fill(assetDetailsData);
                da.Dispose();
                
            }
            return assetDetailsData;
            
        }

        private void LogAssetDetailChanges(DataTable assetDetailsData, string operationType)
        {
            using (SqlConnection logDbConnection = new SqlConnection(SQLCONN.ConnectionString))
            {
                logDbConnection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue, logdatetime, PCNAME, UserId, type) VALUES (@FileNumberid, @ColumnName, @OldValue, @NewValue, @datetime, @pc, @user, @type)", logDbConnection))
                {
                    foreach (DataRow row in assetDetailsData.Rows)
                    {
                        foreach (DataColumn column in assetDetailsData.Columns)
                        {
                            object value = row[column.ColumnName];
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@FileNumberid", row["AssetID"] + " - " + "AssetsDetials");
                            command.Parameters.AddWithValue("@ColumnName", column.ColumnName);
                            command.Parameters.AddWithValue("@OldValue", value ?? DBNull.Value);
                            command.Parameters.AddWithValue("@NewValue", DBNull.Value); // No new value since it's a delete
                            command.Parameters.AddWithValue("@datetime", DateTime.Parse(lbldatetime.Text));
                            command.Parameters.AddWithValue("@pc", Environment.MachineName);
                            command.Parameters.AddWithValue("@user", CommonClass.LoginUserName);
                            command.Parameters.AddWithValue("@type", operationType);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void picVisa_Click(object sender, EventArgs e)
        {
            if (AssetIDTXT.Text != string.Empty)
            {
                Clipboard.SetText(AssetIDTXT.Text);
                AssetIDTXT.Visible = true;
                AssetIDTXT.Text = "Copied !";
            }
            else
            {

            }
        }

        private void btnDownload2_Click(object sender, EventArgs e)
        {
            // Source file path
            string sourceFilePath = @"\\192.168.1.15\Development\DetailsImport.xlsx";

            // Destination file path in the Downloads folder
            string downloadsPath = GetDownloadsPath();
            string destinationFilePath = Path.Combine(downloadsPath, "DetailsImport.xlsx");

            try
            {
                // Copy the file from the source to the destination
                File.Copy(sourceFilePath, destinationFilePath, true);
                MessageBox.Show($"File downloaded successfully to {destinationFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle any errors that occurred during the file copy
                MessageBox.Show($"An error occurred while downloading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsapid_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtSN.Text != string.Empty)
            {
                Clipboard.SetText(txtSN.Text);
                label26.Visible = true;
                label26.Text = "Copied !";
            }
            else
            {

            }
        }

        private void cmbbrand_KeyDown(object sender, KeyEventArgs e)
        {

        }


    }
}



