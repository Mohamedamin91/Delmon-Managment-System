using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CsvHelper;
using Delmon_Managment_System.Reports;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using OfficeOpenXml;

namespace Delmon_Managment_System.Forms
{
    public partial class BillsFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        SQLCONNECTION SQLCONN2 = new SQLCONNECTION();
        int EmployeeID;
        int EnduuserID;
        int CompanyID;
        int LoggedEmployeeID;
        int PackageID;
        bool hasView = false;
        bool hasEdit = false;
        bool hasDelete = false;
        bool hasAdd = false;
        DataTable originalDataCommend, originalDataPack, originalDataendrpt, originalDataendrptBill;
        DateTime oldissueddate;



        public BillsFrm()
        {
            InitializeComponent();
            cmbpackage.TextChanged += new EventHandler(cmbpackage_TextChanged);
            cmbenduserrpt.TextChanged += new EventHandler(cmbenduserrpt_TextChanged);
            cmbenduserrptbill.TextChanged += new EventHandler(cmbenduserrptbill_TextChanged);

            LoadComboBoxDataPack();
            LoadComboBoxDataEndrpt();
            LoadComboBoxDataBillend();

        }
        private void LoadComboBoxDataEndrpt()
        {

            SQLCONN.OpenConection();

            originalDataendrpt = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT 
  distinct  CONCAT(e.FirstName,' ',e.LastName) AS DisplayValue, d.DeptHeadID As Value
	from Employees e, DEPARTMENTS d
	where e.EmployeeID = d.DeptHeadID
	and CONCAT(e.FirstName,' ',e.LastName) != 'Select'; ");
            if (originalDataendrpt != null)
            {
                cmbenduserrpt.DataSource = originalDataendrpt;
                cmbenduserrpt.DisplayMember = "DisplayValue";
                cmbenduserrpt.ValueMember = "Value";
            }
            SQLCONN.CloseConnection();
        }



        private void LoadComboBoxDataBillend()
        {

            SQLCONN.OpenConection();

            originalDataendrptBill = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT 
    CONCAT(c.ShortCompName,' / ', dt.Dept_Type_Name) AS DisplayValue,
    eu.ID AS Value
FROM 
    EndUsers eu
INNER JOIN 
    DEPARTMENTS d ON eu.ID = d.DeptID
INNER JOIN 
    Companies c ON d.COMPID = c.COMPID
INNER JOIN 
    DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
WHERE 
    eu.EndUserType = 'Company'
UNION ALL
SELECT 
    CONCAT(e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName) AS DisplayValue,
    e.EmployeeID AS Value
FROM 
    EndUsers eu
INNER JOIN 
    Employees e ON eu.ID = e.EmployeeID
WHERE 
    eu.EndUserType = 'Personal'  order by eu.ID ");
            if (originalDataendrptBill != null)
            {
                cmbenduserrptbill.DataSource = originalDataendrptBill;
                cmbenduserrptbill.DisplayMember = "DisplayValue";
                cmbenduserrptbill.ValueMember = "Value";
                cmbenduserrptbill.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbenduserrptbill.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            SQLCONN.CloseConnection();
        }




        private void LoadComboBoxDataPack()
        {

            SQLCONN.OpenConection();

            originalDataPack = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT PackageID,PackageName FROM [Packages] where PackageID !=0  ");
            if (originalDataPack != null)
            {
                cmbpackage.DataSource = originalDataPack;
                cmbpackage.DisplayMember = "PackageName";
                cmbpackage.ValueMember = "PackageID";
            }
            SQLCONN.CloseConnection();
        }

        private void BillsFrm_Load(object sender, EventArgs e)
        {
            cmbbillendusetypeelec.Text = "Select";
            cmbbillenduserdivisonelec.Text = "Select";
            cmbpaidbyelec.Text = "Select";
            cmbbillenduserelec.Text = "Select";

            button5.Visible = true;
            button1.Visible = true;
            btn.Visible = true;
            cmbReportType.Text = "Select";
            cmbBillType1.Text = "Select";
            cmbenduserrpt.Text = "Select";

            SqlParameter paramloggedemployee = new SqlParameter("@LoggedEmployeeid", SqlDbType.NVarChar);
            paramloggedemployee.Value = LoggedEmployeeID;
            this.timer1.Interval = 1000;
            timer1.Start();
            lblusername.Text = CommonClass.LoginUserName;
            lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
            LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;

            SQLCONN.OpenConection();
            SQLCONN2.OpenConection2();









            cmbenduserrpt.Text = "Select";






            cmbmeterlocation.ValueMember = "MeterLocationID";
            cmbmeterlocation.DisplayMember = "Meterlocation";
            cmbmeterlocation.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [MeterLocationID]
      ,[Meterlocation]
  FROM [DelmonGroupDB].[dbo].[Meterlocations] order by MeterLocationID ");
            cmbmeterlocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbmeterlocation.AutoCompleteSource = AutoCompleteSource.ListItems;





            cmbservice.ValueMember = "ServiceStatusID";
            cmbservice.DisplayMember = "SerivceStatusName";
            cmbservice.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT ServiceStatusID,SerivceStatusName  FROM [ServicesStatus] order by ServiceStatusID asc ");
            cmbservice.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbservice.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbservice2.ValueMember = "ServiceStatusID";
            cmbservice2.DisplayMember = "SerivceStatusName";
            cmbservice2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT ServiceStatusID,SerivceStatusName  FROM [ServicesStatus] order by ServiceStatusID asc ");
            cmbservice2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbservice2.AutoCompleteSource = AutoCompleteSource.ListItems;




            cmbConnectiontype.ValueMember = "ConnectionTypeID";
            cmbConnectiontype.DisplayMember = "ConnectionTypename";
            cmbConnectiontype.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  ConnectionTypeID,[ConnectionTypename] FROM [DelmonGroupDB].[dbo].[ConnectionType]");
            cmbConnectiontype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbConnectiontype.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbIsp.ValueMember = "ISPTypeID";
            cmbIsp.DisplayMember = "ISPTypeName";
            cmbIsp.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [ISPTypeID] ,[ISPTypeName] FROM [DelmonGroupDB].[dbo].[ISPType]");
            cmbIsp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbIsp.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbMedia.ValueMember = "MediaTypeID";
            cmbMedia.DisplayMember = "MediaTypeName";
            cmbMedia.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT [MediaTypeID],[MediaTypeName] FROM [DelmonGroupDB].[dbo].[MediaType]");
            cmbMedia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMedia.AutoCompleteSource = AutoCompleteSource.ListItems;

            // string query2 = "SELECT OwnerID, OwnerName FROM Owners";
            string query2 = "SELECT CONVERT(VARCHAR, OwnerID) AS OwnerID, OwnerName FROM Owners";
            cmbOwner.ValueMember = "OwnerID";
            cmbOwner.DisplayMember = "OwnerName";
            cmbOwner.DataSource = SQLCONN2.ShowDataInGridViewORCombobox(query2);
            cmbOwner.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbOwner.AutoCompleteSource = AutoCompleteSource.ListItems;



            //  cmbemployee2.Enabled = false;


            cmbservice.Text = "Select";
            cmbRegisterType.Text = "Select";
            cmbBillType.Text = "Select";
            cmbservice2.Text = "Select";



            /*permissions*/
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
                if (permissionName.Contains("ViewBills"))
                {
                    hasView = true;
                }
                if (permissionName.Contains("EditBills"))
                {
                    hasEdit = true;
                }
                if (permissionName.Contains("DeleteBills"))
                {
                    hasDelete = true;
                }
                if (permissionName.Contains("AddBills"))
                {
                    hasAdd = true;
                }
            }
            dr.Close();
            if (hasView == false)
            {
                MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.Enabled = false;
                groupBox3.Enabled = groupBox6.Enabled = false;


            }
            else

            {
                tabControl1.Enabled = true;
                groupBox3.Enabled = groupBox6.Enabled = true;

                if (hasEdit)
                {
                    //btnUpdate.Visible = button2.Visible = button6.Visible = button10.Visible = true;
                    btnUpdate.Enabled = button2.Enabled = button6.Enabled = button10.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled = dtptoreport.Enabled = true;
                }
                else
                {
                    btnUpdate.Enabled = button2.Enabled = button6.Enabled = button10.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled = dtptoreport.Enabled = false;
                }
                if (hasDelete)
                {
                    // DeleteBtn.Visible = true;
                    DeleteBtn.Enabled = button3.Enabled = button7.Enabled = button11.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled = dtptoreport.Enabled = true;
                }
                else
                {
                    DeleteBtn.Enabled = button3.Enabled = button7.Enabled = button11.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled = dtptoreport.Enabled = false;

                }
                if (hasAdd)
                {
                    btn.Visible = button1.Visible = button5.Visible = button9.Visible = true;
                    AddBtn.Enabled = button4.Enabled = button8.Enabled = button12.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled = dtptoreport.Enabled = true;
                }
                else
                {
                    btn.Visible = button1.Visible = button5.Visible = button9.Visible = false;
                    AddBtn.Enabled = button4.Enabled = button8.Enabled = button12.Enabled = btnuplode.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled = dtptoreport.Enabled = false;
                }

            }

            /*permissions*/



            SQLCONN.CloseConnection();
            SQLCONN2.CloseConnection();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            //cmbemployee2.Enabled = false;
        }

        private void cmbCompany_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            // SqlConnection conn = new SqlConnection(@"Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT WorkID,Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], WorkLocations where DEPARTMENTS.WorkLoctionID = WorkLocations.WorkID and DEPTID=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            // cmd.Parameters["@C1"].Value = cmbDepartment.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbmeterlocation.ValueMember = "WorkID";
                cmbmeterlocation.DisplayMember = "Name";
                cmbmeterlocation.DataSource = dt;
                cmbmeterlocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbmeterlocation.AutoCompleteSource = AutoCompleteSource.ListItems;

            }

            conn.Close();
        }
        private void ClearItems()
        {
            txtaccountno.Text = string.Empty;
            // txtsubscription.Text = string.Empty;
            txtmetersn.Text = string.Empty;
            cmbmeterlocation.SelectedIndex = -1;
            cmbOwner.SelectedIndex = -1;
            cmbservice.SelectedIndex = -1;
            RemarksTxt.Text = string.Empty;
            //cmbendusertype.SelectedIndex = -1;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Create SQL parameters
            SqlParameter paramAccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramAccount.Value = txtaccountno.Text;
            SqlParameter paramMetersn = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramMetersn.Value = txtmetersn.Text;
            SqlParameter paramMeterLocation = new SqlParameter("@C3", SqlDbType.Int);
            paramMeterLocation.Value = cmbmeterlocation.SelectedValue;
            SqlParameter paramOwner = new SqlParameter("@C4", SqlDbType.Int);
            paramOwner.Value = cmbOwner.SelectedValue;
            SqlParameter paramEnduserType = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramEnduserType.Value = cmbbillendusetypeelec.Text;
            SqlParameter paramEndUser = new SqlParameter("@C6", SqlDbType.NVarChar);

            SqlParameter paramService = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramService.Value = cmbservice.SelectedValue;
            SqlParameter paramNotes = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramNotes.Value = txtNotes.Text;
            SqlParameter paramPaidBy = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramPaidBy.Value = cmbpaidbyelec.Text;

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramUser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramUser.Value = lblusername.Text;

            SqlParameter paramDatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramDatetimeLOG.Value = lbldatetime.Text;

            SqlParameter paramPC = new SqlParameter("@pc", SqlDbType.NVarChar);
            paramPC.Value = lblPC.Text;

            // Check EndUserType and assign the correct value for @paramEnduserID
            if (cmbbillendusetypeelec.SelectedItem.ToString() == "Personal")
            {
                paramEndUser.Value = cmbbillenduserelec.SelectedValue;  // Assign value for Personal EndUser
            }
            else if (cmbbillendusetypeelec.SelectedItem.ToString() == "Company")
            {
                paramEndUser.Value = cmbbillenduserdivisonelec.SelectedValue;  // Assign value for Company EndUser
            }

            // Insert data into ElectrcityBills table
            string query = @"INSERT INTO [dbo].[ElectrcityBills] 
                     ([AccountNo], [MeterSN], [MeterLocationID],[Ownerid],[EndUserType],[EndUserID], [ServiceStatusD], [Notes], [PaidBy])
                     VALUES (@C1, @C2, @C3, @C4, @C5, @C6, @C7, @C8,@C9)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        paramAccount,
        paramMetersn,
        paramMeterLocation,
        paramOwner,
        paramEnduserType,
        paramEndUser,
        paramService,
        paramNotes,
        paramPaidBy
            };

            // Check for missing fields
            if ((int)cmbservice.SelectedValue == 0 ||
                string.IsNullOrEmpty(txtaccountno.Text) || string.IsNullOrEmpty(txtmetersn.Text))
            {
                MessageBox.Show("Please Fill the missing fields");
                return;
            }

            // Open database connection
            SQLCONN.OpenConection();

            // Check if subscription number already exists
            SqlDataReader dr = SQLCONN.DataReader("SELECT AccountNo FROM ElectrcityBills WHERE AccountNo = @C1", parameters[0]);
            dr.Read();

            if (dr.HasRows)
            {
                MessageBox.Show("This 'AccountNo' " + txtaccountno.Text + " Already Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for confirmation
            if (DialogResult.Yes != MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            // Dispose and close data reader
            dr.Dispose();
            dr.Close();

            SQLCONN.ExecuteQueries(query, parameters);

            // Insert data into EmployeeLog table
            string logQuery = @"INSERT INTO EmployeeLog 
       (logvalue, LogValueID, Oldvalue, newvalue, logdatetime, PCNAME, UserId, type) 
       VALUES ('ElectrcityBills', @C1, '#', '#', @datetime, @pc, @user, 'Insert')";

            SqlParameter[] logParameters = new SqlParameter[] { paramAccount, paramDatetimeLOG, paramPC, paramUser };
            SQLCONN.ExecuteQueries(logQuery, logParameters);

            // Show success message
            MessageBox.Show("Record saved Successfully");

            // Refresh data grid view
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT [AccountNo], [MeterSN], [MeterLocationID], [Ownerid], [EndUserID], [ServiceStatusD], [Notes],[PaidBy]
        FROM [DelmonGroupDB].[dbo].[ElectrcityBills] WHERE AccountNo = @C1", paramAccount);

            // Show button
            btn.Visible = true;

            // Close database connection
            SQLCONN.CloseConnection();
            ClearItems();
            btnUpdate.Visible = DeleteBtn.Visible = btn.Visible = true;
            AddBtn.Visible = false;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbldatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramSearch = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramSearch.Value = txtSearch.Text.Trim();

            SQLCONN.OpenConection();

            string query = @"SELECT [AccountNo]
      ,[MeterSN]
      ,[MeterLocationID]
      ,[Ownerid]
      ,[EnduserType]
      ,[EndUserID]
      ,[ServiceStatusD]
      ,[Notes]
      ,[PaidBy]
      FROM [DelmonGroupDB].[dbo].[ElectrcityBills]
                    WHERE (AccountNo LIKE '%' + @C0 + '%'
                           OR MeterSN LIKE '%' + @C0 + '%'
                           OR EndUserID LIKE '%' + @C0 + '%'
                           OR ServiceStatusD LIKE '%' + @C0 + '%'
                           OR Notes LIKE '%' + @C0 + '%'
                           OR PaidBy LIKE '%' + @C0 + '%')";

            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);

            btn.Visible = true;

            SQLCONN.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            SQLCONN.OpenConection();
            AddBtn.Visible = false;
            btnUpdate.Visible = DeleteBtn.Visible = true;

            // Set text fields
            txtaccountno.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtmetersn.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbmeterlocation.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbOwner.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string endUserType = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbbillendusetypeelec.Text = endUserType;
            int EnduserID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());


            if (endUserType == "Company")
            {
                cmbbillenduserdivisonelec.Enabled = true;

                // Clear existing data source
                cmbbillenduserelec.DataSource = null;

                // Load companies
                string query12 = "SELECT c.COMPID, c.COMPName_EN " +
                                 "FROM Companies c " +
                                 "JOIN DEPARTMENTS d ON c.compid = d.compid " +
                                 "WHERE d.DEPTID = " + EnduserID;
                var companyData = SQLCONN.ShowDataInGridViewORCombobox(query12);

                if (companyData != null && companyData.Rows.Count > 0)
                {
                    cmbbillenduserelec.ValueMember = "COMPID";
                    cmbbillenduserelec.DisplayMember = "COMPName_EN";
                    cmbbillenduserelec.DataSource = companyData;
                    cmbbillenduserelec.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillenduserelec.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbbillenduserelec.Enabled = true;
                }

                // Load divisions
                string divisionQuery = "SELECT [DEPTID], Dept_Type_Name " +
                                       "FROM [DelmonGroupDB].[dbo].[DEPARTMENTS] " +
                                       "JOIN DeptTypes ON DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID " +
                                       "WHERE compid = " + cmbbillenduserelec.SelectedValue;
                var divisionData = SQLCONN.ShowDataInGridViewORCombobox(divisionQuery);

                if (divisionData != null && divisionData.Rows.Count > 0)
                {
                    cmbbillenduserdivisonelec.ValueMember = "DEPTID";
                    cmbbillenduserdivisonelec.DisplayMember = "Dept_Type_Name";
                    cmbbillenduserdivisonelec.DataSource = divisionData;
                    cmbbillenduserdivisonelec.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillenduserdivisonelec.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbbillenduserdivisonelec.SelectedValue = EnduserID;
                }
            }
            else if (endUserType == "Personal")
            {
                cmbbillenduserelec.DataSource = null;
                cmbbillenduserdivisonelec.Enabled = false;
                cmbbillenduserelec.Text = "Select";

                // Load personal end user data (employees)
                string employeeQuery = "SELECT EmployeeID, CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) AS FullName FROM Employees";
                var employeeData = SQLCONN.ShowDataInGridViewORCombobox(employeeQuery);

                if (employeeData != null && employeeData.Rows.Count > 0)
                {
                    cmbbillenduserelec.ValueMember = "EmployeeID";
                    cmbbillenduserelec.DisplayMember = "FullName";
                    cmbbillenduserelec.DataSource = employeeData;
                    cmbbillenduserelec.SelectedValue = EnduserID;
                }
            }

            // Set the remaining fields
            cmbservice.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            RemarksTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            cmbpaidbyelec.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            SQLCONN.CloseConnection();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Create SQL parameters
            SqlParameter paramAccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramAccount.Value = txtaccountno.Text;
            SqlParameter paramMetersn = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramMetersn.Value = txtmetersn.Text;
            SqlParameter paramMeterLocation = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramMeterLocation.Value = cmbmeterlocation.SelectedValue;
            SqlParameter paramOwner = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramOwner.Value = cmbOwner.SelectedValue;
            SqlParameter paramEnduserType = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramEnduserType.Value = cmbbillendusetypeelec.Text;
            SqlParameter paramEndUser = new SqlParameter("@C6", SqlDbType.NVarChar);
            if (cmbbillendusetypeelec.SelectedItem.ToString() == "Personal")
            {
                paramEndUser.Value = cmbbillenduserelec.SelectedValue;
            }
            else if (cmbbillendusetypeelec.SelectedItem.ToString() == "Company")
            {
                paramEndUser.Value = cmbbillenduserdivisonelec.SelectedValue;
            }
            SqlParameter paramService = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramService.Value = cmbservice.SelectedValue;
            SqlParameter paramNotes = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramNotes.Value = RemarksTxt.Text;
            SqlParameter paramPaidBy = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramPaidBy.Value = cmbpaidbyelec.Text;

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramUser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramUser.Value = lblusername.Text;

            SqlParameter paramDatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramDatetimeLOG.Value = lbldatetime.Text;

            SqlParameter paramPC = new SqlParameter("@pc", SqlDbType.NVarChar);
            paramPC.Value = lblPC.Text;

            // Check for missing fields
            if ((int)cmbservice.SelectedValue == 0 ||
                string.IsNullOrEmpty(txtaccountno.Text) || string.IsNullOrEmpty(txtmetersn.Text))
            {
                MessageBox.Show("Please fill the missing fields");
                return;
            }

            // Open database connection
            SQLCONN.OpenConection();

            // Ask for confirmation
            if (DialogResult.Yes != MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return;
            }

            // Update data in ElectrcityBills table
            string query = @"UPDATE [dbo].[ElectrcityBills] SET 
           [MeterSN] = @C2,
           [MeterLocationID] = @C3,
           [Ownerid] = @C4,
           [EnduserType] = @C5,
           [EndUserID] = @C6,
           [ServiceStatusD] = @C7,
           [Notes] = @C8,
           [Paidby] = @C9
           WHERE [AccountNo] = @C1";
            SqlParameter[] parameters = new SqlParameter[] { paramAccount, paramMetersn, paramMeterLocation, paramOwner, paramEnduserType, paramEndUser, paramService, paramNotes, paramPaidBy };

            SQLCONN.ExecuteQueries(query, parameters);

            // Insert data into EmployeeLog table
            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue, LogValueID, Oldvalue, newvalue, logdatetime, PCNAME, UserId, type) VALUES ('ElectrcityBills', @C1, '#', '#', @datetime, @pc, @user, 'Update')",
                paramAccount, paramDatetimeLOG, paramPC, paramUser);

            // Show success message
            MessageBox.Show("Record updated Successfully");

            // Refresh data grid view
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT [AccountNo]
      ,[MeterSN]
      ,[MeterLocationID]
      ,[Ownerid]
      ,[EnduserType]
      ,[EndUserID]
      ,[ServiceStatusD]
      ,[Notes]
      ,[Paidby]
      FROM [DelmonGroupDB].[dbo].[ElectrcityBills] WHERE AccountNo = @C1", paramAccount);

            // Show button
            btn.Visible = true;

            // Close database connection
            SQLCONN.CloseConnection();
            //ClearItems();
            btnUpdate.Visible = DeleteBtn.Visible = btn.Visible = true;
            AddBtn.Visible = false;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramccount.Value = txtaccountno.Text;

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            // Check if subscription number already exists
            SQLCONN.OpenConection();
            SqlDataReader dr = SQLCONN.DataReader("select Accountno from ElectrcityBills  where  AccountNo = @C1 ", paramccount);
            dr.Read();

            if (!dr.HasRows)
            {
                MessageBox.Show("This 'AccountNo' " + txtaccountno.Text + " Not Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dr.Dispose();
                dr.Close();
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    SQLCONN.ExecuteQueries("delete  ElectrcityBills where AccountNo=@C1", paramccount);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue, LogValueID, Oldvalue, newvalue, logdatetime, PCNAME, UserId, type) VALUES ('ElectrcityBills', @C1, '#', '#', @datetime, @pc, @user, 'Delete')", paramccount, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT [AccountNo]
                           ,[MeterSN]
                           ,[MeterLocationID]
                           ,[OwnerId]
                           ,[EndUserID]
                           ,[ServiceStatusD]
                           ,[Notes]
                    FROM [DelmonGroupDB].[dbo].[ElectrcityBills] WHERE AccountNo = @C1 ", paramccount);

                    SQLCONN.CloseConnection();
                    ClearItems();
                    cmbbillenduserelec.Text = "Select";
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount.Text;

            SqlParameter paramserviceNo = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramserviceNo.Value = txtserviceNo.Text;

            SqlParameter paramenduser = new SqlParameter("@C3", SqlDbType.NVarChar);

            SqlParameter paramRegisterType = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramRegisterType.Value = cmbRegisterType.SelectedItem;

            SqlParameter paramRegisterUnder = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramRegisterUnder.Value = cmbRegisterUnder.SelectedValue;

            SqlParameter paramPackage = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramPackage.Value = cmbpackage.SelectedValue;

            SqlParameter paramService = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramService.Value = cmbservice2.SelectedValue;

            SqlParameter paramExpiredate = new SqlParameter("@C8", SqlDbType.Date);
            paramExpiredate.Value = Expiredtp.Value;

            SqlParameter paramNotes = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramNotes.Value = txtNotes.Text;

            SqlParameter paramEnduserType = new SqlParameter("@C10", SqlDbType.NVarChar);
            paramEnduserType.Value = cmbbillendusertypecomm.Text;

            SqlParameter paramPaidBy = new SqlParameter("@C11", SqlDbType.NVarChar);
            paramPaidBy.Value = cmbpaidbycomm.Text;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            // Check EndUserType and assign the correct value for @paramEnduserID
            if (cmbbillendusertypecomm.SelectedItem.ToString() == "Personal")
            {
                paramenduser.Value = cmbbillendusercomm.SelectedValue;  // Assign value for Personal EndUser
            }
            else if (cmbbillendusertypecomm.SelectedItem.ToString() == "Company")
            {
                paramenduser.Value = cmbbillenduserdevisionecomm.SelectedValue;  // Assign value for Company EndUser
            }

            SqlDataReader dr;

            if (cmbpaidbycomm.Text == "Select" || (int)cmbservice2.SelectedValue == 0 || txtaccount.Text == "" || txtserviceNo.Text == "" || (int)cmbpackage.SelectedValue == 0)
            {
                MessageBox.Show("Please Fill the missing fields  ");
                return;
            }
            else
            {
                SQLCONN.OpenConection();
                dr = SQLCONN.DataReader("select  ServiceNo from CommunicationsBills where " +
                    " ServiceNo =  @C2 ", paramserviceNo);
                dr.Read();

                if (dr.HasRows)
                {
                    MessageBox.Show("This 'ServiceNo'  Already Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        dr.Dispose();
                        dr.Close();

                        SQLCONN.ExecuteQueries(@"INSERT INTO [dbo].[CommunicationsBills]
           ([AccountNo]
        ,[ServiceNo]
        ,[EndUserID]
        ,[RegisterType]
        ,[RegisterUnder]
        ,[PackageID]
        ,[ServiceStatusID] 
        ,[ExpireDate]
        ,[Notes]
        ,[EndUserType]
        ,[Paidby])
            VALUES
           (@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8,@C9,@C10,@C11)", paramaccount, paramserviceNo, paramenduser, paramRegisterType, paramRegisterUnder, paramPackage, paramService, paramExpiredate, paramNotes, paramEnduserType, paramPaidBy);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('CommunicationsBills',@C2,'#','#',@datetime,@pc,@user,'Insert')", paramserviceNo, paramdatetimeLOG, parampc, paramuser);

                        MessageBox.Show("Record saved Successfully");
                    }

                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  *
  FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
  where  ServiceNo = @C2 ", paramserviceNo);

                    txtaccount.Text = txtNotes.Text = txtserviceNo.Text = string.Empty;
                    cmbservice2.Text = cmbpackage.Text /*cmbDepartment.Text*/ = cmbRegisterType.Text = cmbRegisterUnder.Text = "Select";
                }
            }
            button1.Visible = true;
            SQLCONN.CloseConnection();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramSearch = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramSearch.Value = textBox1.Text;

            SQLCONN.OpenConection();
            if (lblusertype.Text == "Admin")
            {
                string query = @"SELECT  [AccountNo]
                           ,[ServiceNo]
                           ,[EndUserType]
                           ,[EndUserID]
                           ,[RegisterType]
                           ,[RegisterUnder]
                           ,[PackageID]
                           ,[ServiceStatusID]
                           ,[ExpireDate]
                           ,[Notes]
                           ,[Paidby]
                        FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
                        WHERE (AccountNo LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR ServiceNo LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR EndUserType LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR EndUserID LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR RegisterType LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR RegisterUnder LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR PackageID LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR ServiceStatusID LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR ExpireDate LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR Notes LIKE '%' + REPLACE(@C0,'', '') + '%')";

                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);
            }
            else
            {
                string query = @"SELECT  [AccountNo]
                           ,[ServiceNo]
                           ,[EndUserType]
                           ,[EndUserID]
                           ,[RegisterType]
                           ,[RegisterUnder]
                           ,[PackageID]
                           ,[ServiceStatusID]
                           ,[ExpireDate]
                           ,[Notes]
                           ,[Paidby]
                        FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
                        WHERE (AccountNo LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR ServiceNo LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR EndUserType LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR EndUserID LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR RegisterType LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR RegisterUnder LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR PackageID LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR ServiceStatusID LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR ExpireDate LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR Notes LIKE '%' + REPLACE(@C0,'', '') + '%')";


                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);
            }

            SQLCONN.CloseConnection();
            //firstnametxt.Text = secondnametxt.Text = thirdnametxt.Text = lastnametxt.Text = "";
            //cmbMartialStatus.Text = cmbGender.Text = "";
            //ClearAllControls();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            SQLCONN.OpenConection();
            LoadComboBoxDataPack();
            if (e.RowIndex == -1) return;

            // Disable the service number text box and button 4
            txtserviceNo.Enabled = false;
            button4.Visible = false;

            // Get the selected row
            DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

            // Populate the text boxes and combo boxes with the selected row's data
            txtaccount.Text = selectedRow.Cells[0].Value.ToString();
            txtserviceNo.Text = selectedRow.Cells[1].Value.ToString();
            cmbbillendusertypecomm.Text = selectedRow.Cells[2].Value.ToString();
            //cmbcommenduser.SelectedValue = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
            cmbRegisterType.Text = selectedRow.Cells[4].Value.ToString();
            cmbRegisterUnder.SelectedValue = Convert.ToInt32(selectedRow.Cells[5].Value.ToString());
            cmbpackage.SelectedValue = Convert.ToInt32(selectedRow.Cells[6].Value.ToString());
            cmbservice2.SelectedValue = Convert.ToInt32(selectedRow.Cells[7].Value.ToString());

            // Handle the date
            string dateString = selectedRow.Cells[8].Value.ToString();
            if (!string.IsNullOrWhiteSpace(dateString))
            {
                DateTime expiredDate;
                if (DateTime.TryParse(dateString, out expiredDate))
                {
                    Expiredtp.Value = expiredDate;
                }
                else
                {
                    MessageBox.Show("Invalid date format in cell 8.");
                }
            }
            else
            {
                Expiredtp.Value = DateTime.Now; // or some other default value
            }



            /**registerunder*/

            string registertype = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbRegisterType.Text = registertype;
            int EnduserID1 = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());


            if (registertype == "Company")
            {

                // Clear existing data source
                cmbRegisterUnder.DataSource = null;

                // Load companies
                string query12 = "SELECT c.COMPID, c.COMPName_EN " +
                                 "FROM Companies c  WHERE c.compid = " + EnduserID1;
                var companyData = SQLCONN.ShowDataInGridViewORCombobox(query12);

                if (companyData != null && companyData.Rows.Count > 0)
                {
                    cmbRegisterUnder.ValueMember = "COMPID";
                    cmbRegisterUnder.DisplayMember = "COMPName_EN";
                    cmbRegisterUnder.DataSource = companyData;

                    cmbRegisterUnder.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbRegisterUnder.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbRegisterUnder.Enabled = true;
                    cmbRegisterUnder.SelectedValue = EnduserID1;
                }


            }
            else if (registertype == "Personal")
            {
                cmbRegisterUnder.DataSource = null;

                // Load personal end user data (employees)
                string employeeQuery = "SELECT EmployeeID, CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) AS FullName FROM Employees";
                var employeeData = SQLCONN.ShowDataInGridViewORCombobox(employeeQuery);

                if (employeeData != null && employeeData.Rows.Count > 0)
                {
                    cmbRegisterUnder.ValueMember = "EmployeeID";
                    cmbRegisterUnder.DisplayMember = "FullName";
                    cmbRegisterUnder.DataSource = employeeData;
                    cmbRegisterUnder.SelectedValue = EnduserID1;
                }
            }








            /**registerunbder**/











            /*enduser*/
            string endUserType = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbbillendusertypecomm.Text = endUserType;
            int EnduserID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());


            if (endUserType == "Company")
            {
                cmbbillenduserdevisionecomm.Enabled = true;

                // Clear existing data source
                cmbbillendusercomm.DataSource = null;

                // Load companies
                string query12 = "SELECT c.COMPID, c.COMPName_EN " +
                                 "FROM Companies c " +
                                 "JOIN DEPARTMENTS d ON c.compid = d.compid " +
                                 "WHERE d.DEPTID = " + EnduserID;
                var companyData = SQLCONN.ShowDataInGridViewORCombobox(query12);

                if (companyData != null && companyData.Rows.Count > 0)
                {
                    cmbbillendusercomm.ValueMember = "COMPID";
                    cmbbillendusercomm.DisplayMember = "COMPName_EN";
                    cmbbillendusercomm.DataSource = companyData;
                    cmbbillendusercomm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillendusercomm.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbbillendusercomm.Enabled = true;
                }

                // Load divisions
                string divisionQuery = "SELECT [DEPTID], Dept_Type_Name " +
                                       "FROM [DelmonGroupDB].[dbo].[DEPARTMENTS] " +
                                       "JOIN DeptTypes ON DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID " +
                                       "WHERE compid = " + cmbbillendusercomm.SelectedValue;
                var divisionData = SQLCONN.ShowDataInGridViewORCombobox(divisionQuery);

                if (divisionData != null && divisionData.Rows.Count > 0)
                {
                    cmbbillenduserdevisionecomm.ValueMember = "DEPTID";
                    cmbbillenduserdevisionecomm.DisplayMember = "Dept_Type_Name";
                    cmbbillenduserdevisionecomm.DataSource = divisionData;
                    cmbbillenduserdevisionecomm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillenduserdevisionecomm.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbbillenduserdevisionecomm.SelectedValue = EnduserID;
                }
            }
            else if (endUserType == "Personal")
            {
                cmbbillenduserelec.DataSource = null;
                cmbbillenduserdivisonelec.Enabled = false;
                cmbbillendusercomm.Text = "Select";

                // Load personal end user data (employees)
                string employeeQuery = "SELECT EmployeeID, CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) AS FullName FROM Employees";
                var employeeData = SQLCONN.ShowDataInGridViewORCombobox(employeeQuery);

                if (employeeData != null && employeeData.Rows.Count > 0)
                {
                    cmbbillendusercomm.ValueMember = "EmployeeID";
                    cmbbillendusercomm.DisplayMember = "FullName";
                    cmbbillendusercomm.DataSource = employeeData;
                    cmbbillendusercomm.SelectedValue = EnduserID;
                }
            }

            /*enduser**/
            txtNotes.Text = selectedRow.Cells[9].Value.ToString();
            cmbpaidbycomm.Text = selectedRow.Cells[10].Value.ToString();

            // Check if the register under is company or personal


        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount.Text;

            SqlParameter paramserviceNo = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramserviceNo.Value = txtserviceNo.Text;

            SqlParameter paramenduser = new SqlParameter("@C3", SqlDbType.NVarChar);

            SqlParameter paramRegisterType = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramRegisterType.Value = cmbRegisterType.SelectedItem;

            SqlParameter paramRegisterUnder = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramRegisterUnder.Value = cmbRegisterUnder.SelectedValue;

            SqlParameter paramPackage = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramPackage.Value = cmbpackage.SelectedValue;

            SqlParameter paramService = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramService.Value = cmbservice2.SelectedValue;

            SqlParameter paramExpiredate = new SqlParameter("@C8", SqlDbType.Date);
            paramExpiredate.Value = Expiredtp.Value;

            SqlParameter paramNotes = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramNotes.Value = txtNotes.Text;

            SqlParameter paramEnduserType = new SqlParameter("@C10", SqlDbType.NVarChar);
            paramEnduserType.Value = cmbbillendusertypecomm.Text;

            SqlParameter paramPaidBy = new SqlParameter("@C11", SqlDbType.NVarChar);
            paramPaidBy.Value = cmbpaidbycomm.Text;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            // Check EndUserType and assign the correct value for @paramEnduserID
            if (cmbbillendusertypecomm.SelectedItem.ToString() == "Personal")
            {
                paramenduser.Value = cmbbillendusercomm.SelectedValue;  // Assign value for Personal EndUser
            }
            else if (cmbbillendusertypecomm.SelectedItem.ToString() == "Company")
            {
                paramenduser.Value = cmbbillenduserdevisionecomm.SelectedValue;  // Assign value for Company EndUser
            }




            if (cmbpaidbycomm.Text == "Select" || (int)cmbservice2.SelectedValue == 0 || txtaccount.Text == "" || txtserviceNo.Text == "" || (int)cmbpackage.SelectedValue == 0)
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {
                SQLCONN.OpenConection();

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.ExecuteQueries(@"UPDATE [dbo].[CommunicationsBills]
SET [AccountNo] = @C1,
[EnduserType] = @C10,
[EndUserID] = @C3,
[RegisterType] = @C4,
[RegisterUnder] = @C5,
[PackageID] = @C6,
[ServiceStatusID] = @C7,
[ExpireDate] = @C8,
[Notes] = @C9,
[Paidby]= @C11
WHERE [ServiceNo] = @C2", paramaccount, paramenduser, paramRegisterType, paramRegisterUnder, paramPackage, paramService, paramExpiredate, paramNotes, paramserviceNo, paramEnduserType, paramPaidBy);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('CommunicationsBills',@C2,'#','#',@datetime,@pc,@user,'Update')", paramserviceNo, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Record updated Successfully");
                }

                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  *
  FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
  where  ServiceNo = @C2 ", paramserviceNo);
            }
            button1.Visible = true;
            SQLCONN.CloseConnection();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlParameter paramserviceNo = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramserviceNo.Value = txtserviceNo.Text;

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if (txtserviceNo.Text == string.Empty)
            {
                MessageBox.Show("Please select Record first! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  CommunicationsBills where ServiceNo=@C2", paramserviceNo);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('CommunicationsBills',@C2,'#','#',@datetime,@pc,@user,'Delete')", paramserviceNo, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  *
  FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
  where  ServiceNo = @C2 ", paramserviceNo);

                    txtaccount.Text = txtserviceNo.Text = txtNotes.Text = string.Empty;
                    cmbservice2.Text = cmbRegisterUnder.Text = cmbpackage.Text = "Select";

                    // Clear the text boxes
                    txtaccount.Text = string.Empty;
                    txtserviceNo.Text = string.Empty;
                    txtNotes.Text = string.Empty;

                    // Reset the combo boxes
                    cmbRegisterType.Text = "Select";
                    cmbRegisterUnder.Text = "Select";
                    cmbpackage.SelectedIndex = -1;
                    cmbservice2.SelectedIndex = -1;
                    cmbpackage.Text = cmbservice2.Text = cmbbillendusercomm.Text = cmbbillendusertypecomm.Text = cmbbillenduserdevisionecomm.Text = cmbpaidbycomm.Text = "Select";

                    cmbReportType.Text = "Select";
                    cmbpackage.Text = "Select";

                    // Reset the date
                    Expiredtp.Value = DateTime.Now;

                    SQLCONN.CloseConnection();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount3.Text;

            SqlParameter paramBillType = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramBillType.Value = cmbBillType.SelectedItem;

            SqlParameter paramissuedate = new SqlParameter("@C3", SqlDbType.Date);
            paramissuedate.Value = dtpissue.Value;

            SqlParameter paramissuedate2 = new SqlParameter("@C33", SqlDbType.Date);
            paramissuedate2.Value = oldissueddate;

            SqlParameter paramdisconnectdate = new SqlParameter("@C4", SqlDbType.Date);
            paramdisconnectdate.Value = dtpdisconnect.Value;

            SqlParameter paramBillAmount = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramBillAmount.Value = float.Parse(txtBillAmount.Text);

            SqlParameter paramPaymentstaus = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramPaymentstaus.Value = 0;

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SQLCONN.OpenConection();

            if (txtaccount3.Text == "" || txtBillAmount.Text == "")
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.ExecuteQueries(@"update  [dbo].[BillsPaymentStatus] set
       [AccountNo] = @C1
     ,[BillType] = @C2
     ,[IssuedDate] = @C3
     ,[DisconnectDate] = @C4
     ,[BillAmount] = @C5
      ,[PaymentStatus] = @C6

      where AccountNo = @C1 and IssuedDate=@C33 ", paramaccount, paramissuedate2, paramBillType, paramissuedate, paramdisconnectdate, paramBillAmount, paramPaymentstaus);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('BillsPaymentStatus',@C1,'#','#',@datetime,@pc,@user,'Update')", paramaccount, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Record Updated Successfully");
                }

                dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  [AccountNo]
      ,[BillType]
      ,[IssuedDate]
      ,[DisconnectDate]
      ,[BillAmount] FROM [DelmonGroupDB].[dbo].[BillsPaymentStatus] where " +
                    " IssuedDate = @C3 and AccountNo = @C1  ", paramissuedate, paramaccount);
            }

            SQLCONN.CloseConnection();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount3.Text;

            SqlParameter paramBillType = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramBillType.Value = cmbBillType.SelectedItem;

            SqlParameter paramissuedate = new SqlParameter("@C3", SqlDbType.Date);
            paramissuedate.Value = dtpissue.Value;

            SqlParameter paramdisconnectdate = new SqlParameter("@C4", SqlDbType.Date);
            paramdisconnectdate.Value = dtpdisconnect.Value;

            SqlParameter paramBillAmount = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramBillAmount.Value = float.Parse(txtBillAmount.Text);




            SqlParameter paramPaymentstaus = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramPaymentstaus.Value = 0;

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SqlDataReader dr, dr2, dr3;

            if (txtaccount3.Text == "" || txtBillAmount.Text == "" || cmbBillType.Text == "Select")
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {
                SQLCONN.OpenConection();










                dr = SQLCONN.DataReader(" select BPS.AccountNo from BillsPaymentStatus BPS, CommunicationsBills CB, ElectrcityBills EB " +
                             " where  CB.AccountNo=@C1 or EB.AccountNo=@C1", paramaccount);
                if (dr.HasRows)
                {

                    dr.Close();
                    dr.Dispose();

                    dr2 = SQLCONN.DataReader("select  IssuedDate,AccountNo from BillsPaymentStatus  where " +
                        " IssuedDate=  @C3 and AccountNo=@C1  ", paramissuedate, paramaccount);
                    dr2.Read();

                    if (dr2.HasRows)
                    {
                        MessageBox.Show("This 'Bill'  Already Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dr2.Close();
                        dr2.Dispose();
                        if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            dr.Dispose();
                            dr.Close();
                            SQLCONN.ExecuteQueries("UPDATE BillsPaymentStatus SET PaymentStatus = 1 WHERE AccountNo = @C1 AND PaymentStatus = 0", paramaccount);

                            SQLCONN.ExecuteQueries(@"INSERT INTO [dbo].[BillsPaymentStatus]
       ([AccountNo]
     ,[BillType]
     ,[IssuedDate]
     ,[DisconnectDate]
     ,[BillAmount]
     ,[PaymentStatus])

     VALUES
          (@C1,@C2,@C3,@C4,@C5,@C6)", paramaccount, paramBillType, paramissuedate, paramdisconnectdate, paramBillAmount, paramPaymentstaus);

                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('BillsPaymentStatus',@C1,'#','#',@datetime,@pc,@user,'Insert')", paramaccount, paramdatetimeLOG, parampc, paramuser);

                            MessageBox.Show("Record saved Successfully");

                            ClearItems3();
                        }

                        dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  [AccountNo]
      ,[BillType]
      ,[IssuedDate]
      ,[DisconnectDate]
      ,[BillAmount]
      from BillsPaymentStatus  where " +
                            " IssuedDate=  @C3 and AccountNo=@C1  ", paramissuedate, paramaccount);

                        button5.Visible = true;
                        SQLCONN.CloseConnection();
                    }
                }
                else
                {
                    dr.Close();
                    dr.Dispose();
                    MessageBox.Show("No records found for AccountNo: " + txtaccount3.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);




                }
            }
        }
        private void txtBillAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBillAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    If the pressed key is not a number or a control key, suppress it.
            //    e.Handled = true;
            //    MessageBox.Show("Kindly use numbers Only !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
            //else
            //{

            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramSearch = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramSearch.Value = textBox2.Text;

            SQLCONN.OpenConection();
            if (lblusertype.Text == "Admin")
            {
                string query = @"SELECT  * 
               FROM [DelmonGroupDB].[dbo].[BillsPaymentStatus] where  AccountNo LIKE '%' + @C0 + '%' ";

                //         string query = @"SELECT *  from [ElectrcityBills] WHERE AccountNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'
                //OR SubscriptionNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'";
                dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);


            }
            else
            {

                string query = "";

                dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);
            }

            SQLCONN.CloseConnection();
            //firstnametxt.Text = secondnametxt.Text = thirdnametxt.Text = lastnametxt.Text = "";
            //cmbMartialStatus.Text = cmbGender.Text = "";
            //ClearAllControls();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtaccount3.Enabled = false;
            button8.Visible = false;
            button5.Visible = true;
            //    btnnew.Visible = updatebtn.Visible = deletebtn.Visible = true;

            if (e.RowIndex == -1) return;

            // Get the selected row
            DataGridViewRow selectedRow = dataGridView3.Rows[e.RowIndex];

            // Populate the text boxes and combo boxes with the selected row's data
            txtaccount3.Text = selectedRow.Cells[0].Value.ToString();
            cmbBillType.SelectedItem = selectedRow.Cells[1].Value.ToString();
            dtpissue.Value = Convert.ToDateTime(selectedRow.Cells[2].Value.ToString());
            oldissueddate = dtpissue.Value;
            dtpdisconnect.Value = Convert.ToDateTime(selectedRow.Cells[3].Value.ToString()); // Note: The cell index was changed from 4 to 3
            txtBillAmount.Text = selectedRow.Cells[4].Value.ToString(); // Note: The cell index was changed from 7 to 4

        }
        private void ClearItems3()
        {
            txtaccount3.Clear();
            cmbBillType.Text = "Select";
            dtpissue.Value = DateTime.Now;
            dtpdisconnect.Value = DateTime.Now;
            txtBillAmount.Clear();
            lblusername.Text = "";
            lbldatetime.Text = "";
            lblPC.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount3.Text;

            SqlParameter paramissuedate = new SqlParameter("@C2", SqlDbType.Date);
            paramissuedate.Value = dtpissue.Value;

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if (txtaccount3.Text == string.Empty)
            {
                MessageBox.Show("Please select Record first! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  BillsPaymentStatus where AccountNo=@C1 and IssuedDate=@C2 ", paramaccount, paramissuedate);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('BillsPaymentStatus',@C1,'#','#',@datetime,@pc,@user,'Delete')", paramaccount, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select * from BillsPaymentStatus  where " +
                        " IssuedDate=  @C2 and AccountNo=@C1  ", paramissuedate, paramaccount);

                    txtaccount.Text = txtserviceNo.Text = txtNotes.Text = string.Empty;
                    cmbservice2.Text = cmbpackage.Text = "Select";
                    Expiredtp.Value = DateTime.Now;

                    SQLCONN.CloseConnection();
                    ClearItems3();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button5.Visible = false;
            txtBillAmount.Text = "";
            cmbBillType.Text = "Select";

        }

        private void btn_Click(object sender, EventArgs e)
        {
            AddBtn.Visible = true;
            btnUpdate.Visible = DeleteBtn.Visible = btn.Visible = false;
            ClearItems();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            button1.Visible = false;
            dataGridView1.DataSource = null;


            // Clear the text boxes
            txtaccount.Text = string.Empty;
            txtserviceNo.Text = string.Empty;
            txtNotes.Text = string.Empty;

            // Reset the combo boxes
            cmbRegisterType.Text = "Select";
            cmbRegisterUnder.Text = "Select";
            cmbpackage.SelectedIndex = -1;
            cmbservice2.SelectedIndex = -1;
            cmbpackage.Text = cmbservice2.Text = cmbbillendusercomm.Text = cmbbillendusertypecomm.Text = cmbbillenduserdevisionecomm.Text = cmbpaidbycomm.Text = "Select";

            cmbReportType.Text = "Select";
            cmbpackage.Text = "Select";

            // Reset the date
            Expiredtp.Value = DateTime.Now;


        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlParameter paramPackageName = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramPackageName.Value = txtpName.Text;
            SqlParameter paramMonthlycharge = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramMonthlycharge.Value = txtMonthCharge.Text;
            SqlParameter paramConnectionType = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramConnectionType.Value = cmbConnectiontype.SelectedValue;
            SqlParameter paramdISP = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramdISP.Value = cmbIsp.SelectedValue;
            SqlParameter paramMedia = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramMedia.Value = cmbMedia.SelectedValue;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SqlDataReader dr;

            if ((int)cmbMedia.SelectedValue == 0 || (int)cmbMedia.SelectedValue == 0 || (int)cmbMedia.SelectedValue == 0 || txtpName.Text == "" || txtMonthCharge.Text == "")
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {

                SQLCONN.OpenConection();
                dr = SQLCONN.DataReader("select  PackageName from Packages  where " +
                    "  PackageName=@C1  ", paramPackageName);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Package'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {




                        dr.Dispose();
                        dr.Close();

                        SQLCONN.ExecuteQueries(@"INSERT INTO [dbo].[Packages]
       ([PackageName]
      ,[MonthlyCharge]
      ,[ConnectionTypeID]
      ,[ISPTypeID]
      ,[MediaTypeID])
     VALUES
          (@C1,@C2,@C3,@C4,@C5)", paramPackageName, paramMonthlycharge, paramConnectionType, paramdISP, paramMedia);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('PackageBills',@C1 ,'#','#',@datetime,@pc,@user,'Insert')", paramPackageName, paramdatetimeLOG, parampc, paramuser);

                        //   btnnew.Visible = true;


                        MessageBox.Show("Record saved Successfully");
                    }

                    //cmbusertype.Text = cmbemployee.Text = "Select";
                    //usernametxt.Text = passwordtxt.Text = "";
                    //isactivecheck.Checked = false;

                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  * from Packages  where " +
                    " PackageName=@C1 and ConnectionTypeID=@C3  ", paramPackageName, paramConnectionType);

                    //    txtaccountno.Text = txtsubscription.Text = txtNotes.Text = txtmetersn.Text = string.Empty;
                    //    cmbservice.Text = cmbemployee.Text = cmbpackage.Text = cmbDepartment.Text = cmbCompany.Text = cmbworkfield.Text = "Select";
                    //}


                }
                button5.Visible = true;
                SQLCONN.CloseConnection();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button12.Visible = true;
        }

        private void txtMonthCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the pressed key is not a number or a control key, suppress it.
                e.Handled = true;
                MessageBox.Show("Kindly use numbers Only !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramSearch = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramSearch.Value = textBox3.Text;

            SQLCONN.OpenConection();
            if (lblusertype.Text == "Admin")
            {
                string query = @"SELECT  * 
               FROM [DelmonGroupDB].[dbo].[Packages] where  PackageName LIKE '%' + @C0 + '%' ";

                //         string query = @"SELECT *  from [ElectrcityBills] WHERE AccountNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'
                //OR SubscriptionNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'";
                dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);


            }
            else
            {

                string query = "";

                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);
            }

            SQLCONN.CloseConnection();
            //firstnametxt.Text = secondnametxt.Text = thirdnametxt.Text = lastnametxt.Text = "";
            //cmbMartialStatus.Text = cmbGender.Text = "";
            //ClearAllControls();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  button8.Visible = false;
            //    btnnew.Visible = updatebtn.Visible = deletebtn.Visible = true;
            if (e.RowIndex == -1) return;

            foreach (DataGridViewRow rw in this.dataGridView4.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {

                        PackageID = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtpName.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtMonthCharge.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbConnectiontype.SelectedValue = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString());
                        cmbIsp.SelectedValue = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString());
                        cmbMedia.SelectedValue = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString());



                        // Check if the clicked cell is in the IsActive column


                        ////CurrentEmployeeIDtxt.Text = EmployeeID.ToString();
                        ////addbtn.Visible = false;
                        //btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
                        //firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
                        //cmbMartialStatus.Enabled = cmbGender.Enabled = cmbCompany.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = true;
                        //StartDatePicker.Enabled = true;

                    }
                }

            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlParameter paramPackageID = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramPackageID.Value = PackageID;



            SqlParameter paramPackageName = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramPackageName.Value = txtpName.Text;
            SqlParameter paramMonthlycharge = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramMonthlycharge.Value = txtMonthCharge.Text;
            SqlParameter paramConnectionType = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramConnectionType.Value = cmbConnectiontype.SelectedValue;
            SqlParameter paramdISP = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramdISP.Value = cmbIsp.SelectedValue;
            SqlParameter paramMedia = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramMedia.Value = cmbMedia.SelectedValue;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            SQLCONN.OpenConection();

            if (PackageID <= 0)
            {
                MessageBox.Show("Please Select Record First ");
            }
            else
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {






                    SQLCONN.ExecuteQueries(@"update  [dbo].[Packages]  set
       [PackageName] =@C1
      ,[MonthlyCharge]=@C2
      ,[ConnectionTypeID]=@C3
      ,[ISPTypeID]=@C4
      ,[MediaTypeID]=@C5 where PackageID=@C0 ", paramPackageID, paramPackageName, paramMonthlycharge, paramConnectionType, paramdISP, paramMedia);

                    //   SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('ElectrcityBills',@C2 ,'#','#',@datetime,@pc,@user,'Insert')", paramsubscrip, paramdatetimeLOG, parampc, paramuser);

                    //   btnnew.Visible = true;


                    MessageBox.Show("Record Updated Successfully");
                }

                //cmbusertype.Text = cmbemployee.Text = "Select";
                //usernametxt.Text = passwordtxt.Text = "";
                //isactivecheck.Checked = false;

                dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  * from Packages  where " +
                " PackageName=@C1 and ConnectionTypeID=@C3  ", paramPackageName, paramConnectionType);



            }

            SQLCONN.CloseConnection();
        }

        private void Packages_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            SqlParameter paramPackageID = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramPackageID.Value = PackageID;

            if (PackageID <= 0)
            {
                MessageBox.Show("Please select Record first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  Packages where PackageID=@C0  ", paramPackageID);
                    // SQLCONN.ExecuteQueries(" declare @max int select @max = max([UserID]) from [tblUser] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[tblUser]', RESEED, @max)");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramPID, paramdatetimeLOG, parampc, paramuser);
                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  * from Packages " +
                               " where PackageID=@C0  ", paramPackageID);

                    //txtaccount.Text = txtserviceNo.Text = txtNotes.Text = string.Empty;
                    //cmbservice2.Text = cmbemployee2.Text = cmbpackage.Text = "Select";
                    //Expiredtp.Value = DateTime.Now;


                    SQLCONN.CloseConnection();



                }

            }
        }

        private void txtaccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtserviceNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRegisterUnder_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbRegisterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbRegisterType.SelectedItem.ToString() == "Personal")
            //{
            //    cmbcombcomm.Enabled  = false;
            //    cmbempdepthistory.Enabled = false;
            //    cmbemployee2.Enabled = true;
            //}
            //else if (cmbRegisterType.SelectedItem.ToString() == "Company")
            //{
            //    cmbcombcomm.Enabled  = true;
            //    cmbemployee2.Enabled = true;
            //    cmbempdepthistory.Enabled = false;


            //}
            //else 
            //{

            //    cmbcombcomm.Enabled  = false;
            //    cmbemployee2.Enabled = false;
            //    cmbempdepthistory.Enabled = false;

            //}

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                cmbbillendusetypeelec.Text = "Select";
                cmbbillenduserdivisonelec.Text = "Select";
                cmbpaidbyelec.Text = "Select";
                cmbbillenduserelec.Text = "Select";

            }

            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                cmbpackage.Text = cmbservice2.Text = cmbbillendusercomm.Text = cmbbillendusertypecomm.Text = cmbbillenduserdevisionecomm.Text = cmbpaidbycomm.Text = "Select";

                cmbReportType.Text = "Select";

                LoadComboBoxDataPack();
                cmbpackage.Text = "Select";
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                textBox2.Focus();
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[4])
            {

                cmbBillType1.Text = "Select";
                cmbenduserrpt.Text = "Select";
                cmbendtype.Text = "All";
                cmbenduserrptbill.Text = "Select";
                cmbpaidbyrpt.Text = "Select";
            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


        /*Uplode-import**/

        private void btnuplode_Click(object sender, EventArgs e)
        {
            SqlDataReader dr2;

            SQLCONN.OpenConection();

            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            SqlParameter paramissuedate = new SqlParameter("@C3", SqlDbType.Date);

            if (cmbReportType.Text == "Select")
            {
                MessageBox.Show("Please select report type!.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Open file dialog to select file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileExtension = Path.GetExtension(filePath).ToLower();

                    // Read data from file
                    DataTable table = ReadDataFromFile(filePath, fileExtension);

                    // Check for existing records
                    Dictionary<string, string> existingRecords = GetExistingRecords();

                    // Iterate through each row in the DataTable
                    foreach (DataRow row in table.Rows)
                    {




                        // Get the column values
                        string accountNo = row["Billing Account Number"].ToString();
                        string billType = GetBillType(cmbReportType.Text);
                        DateTime billDateGregorian = Convert.ToDateTime(row["Bill Date Gregorian (Last issued bill)"].ToString());
                        DateTime disconnectDate = billDateGregorian.AddMonths(1).AddDays(-1);
                        string balance = row["Balance"].ToString();



                        paramaccount.Value = accountNo;
                        paramissuedate.Value = billDateGregorian;



                        // Check for duplicates
                        dr2 = SQLCONN.DataReader("select  IssuedDate,AccountNo from BillsPaymentStatus  where " +
                     " IssuedDate=@C3  and AccountNo= @C1 ", paramaccount, paramissuedate);
                        dr2.Read();

                        if (dr2.HasRows)
                        {
                            MessageBox.Show("This 'Bill'  Already Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        else
                        {
                            dr2.Close();
                            dr2.Dispose();
                            // Insert data into database
                            InsertDataIntoDatabase(accountNo, billType, billDateGregorian.ToString("yyyy-MM-dd"), disconnectDate.ToString("yyyy-MM-dd"), balance);

                        }

                    }

                    MessageBox.Show("Records saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT  * FROM [DelmonGroupDB].[dbo].[BillsPaymentStatus] ");



                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SQLCONN.CloseConnection();
        }

        private DataTable ReadDataFromFile(string filePath, string fileExtension)
        {
            DataTable table = new DataTable();

            if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".xlsm")
            {
                // Read Excel file using EPPlus
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.First();
                    var rows = worksheet.Dimension.Rows;
                    var columns = worksheet.Dimension.Columns;

                    for (int i = 1; i <= columns; i++)
                    {
                        table.Columns.Add(worksheet.Cells[1, i].Value.ToString());
                    }

                    for (int i = 2; i <= rows; i++)
                    {
                        DataRow row = table.NewRow();
                        for (int j = 1; j <= columns; j++)
                        {
                            row[j - 1] = worksheet.Cells[i, j].Value;
                        }
                        table.Rows.Add(row);
                    }
                }
            }
            else if (fileExtension == ".csv")
            {
                // Read CSV file
                using (var reader = new StreamReader(filePath))
                {
                    bool isHeader = true;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (isHeader)
                        {
                            // Create columns based on the header row
                            foreach (var column in values)
                            {
                                table.Columns.Add(column);
                            }
                            isHeader = false;
                        }
                        else
                        {
                            // Add rows for each subsequent line
                            DataRow row = table.NewRow();
                            for (int i = 0; i < values.Length; i++)
                            {
                                row[i] = values[i];
                            }
                            table.Rows.Add(row);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Unsupported file format. Please select an Excel or CSV file.");
            }

            return table;
        }


        private Dictionary<string, string> GetExistingRecords()
        {
            SQLCONN.OpenConection();
            Dictionary<string, string> existingRecords = new Dictionary<string, string>();
            SqlDataReader dr = SQLCONN.DataReader("SELECT AccountNo, IssuedDate FROM BillsPaymentStatus");
            while (dr.Read())
            {
                string key = $"{dr["AccountNo"]}_{dr["IssuedDate"]}";
                existingRecords.Add(key, dr["IssuedDate"].ToString());
            }
            dr.Close();
            return existingRecords;
        }

        private string GetBillType(string reportType)
        {
            switch (reportType)
            {
                case "Communication":
                    return "Communication";
                case "Electrcity":
                    return "Electrcity";
                default:
                    throw new Exception("Invalid report type.");
            }
        }

        private void InsertDataIntoDatabase(string accountNo, string billType, string billDateGregorian, string disconnectDate, string balance)
        {
            SqlParameter ParamAccountNo = new SqlParameter("@AccountNo", SqlDbType.NVarChar) { Value = accountNo };
            SqlParameter ParamBillType = new SqlParameter("@BillType", SqlDbType.NVarChar) { Value = billType };
            SqlParameter ParamBillDateGregorian = new SqlParameter("@IssuedDate", SqlDbType.DateTime) { Value = DateTime.ParseExact(billDateGregorian, "yyyy-MM-dd", CultureInfo.InvariantCulture) };
            SqlParameter ParamBillDisconnectDate = new SqlParameter("@DisconnectDate", SqlDbType.DateTime) { Value = DateTime.ParseExact(disconnectDate, "yyyy-MM-dd", CultureInfo.InvariantCulture) };
            SqlParameter ParamBalance = new SqlParameter("@BillAmount", SqlDbType.NVarChar) { Value = balance };
            SQLCONN.ExecuteQueries("UPDATE BillsPaymentStatus SET PaymentStatus = 1 WHERE AccountNo = @AccountNo AND PaymentStatus = 0", ParamAccountNo);
            SQLCONN.ExecuteQueries(" INSERT INTO BillsPaymentStatus (AccountNo, BillType, IssuedDate, DisconnectDate, BillAmount,PaymentStatus) VALUES (@AccountNo, @BillType, @IssuedDate, @DisconnectDate, @BillAmount,0)", ParamAccountNo, ParamBillType, ParamBillDateGregorian, ParamBillDisconnectDate, ParamBalance);
            /*Uplode-import**/

        }

        /*Uplode-import**/


        /*Display*/
        private void button14_Click(object sender, EventArgs e)
        {

            dataGridView5.Visible = true;
            crystalReportViewer1.Visible = false;
            SqlParameter paramBillType = new SqlParameter("@paramBillType", SqlDbType.NVarChar);
            paramBillType.Value = cmbBillType1.Text;
            SqlParameter paramPaymentStauts = new SqlParameter("@paramPaymentStauts", SqlDbType.NVarChar);
            SqlParameter paramApprovedBy = new SqlParameter("@paramEnduserID", SqlDbType.NVarChar);
            paramApprovedBy.Value = cmbenduserrpt.SelectedValue;
            SqlParameter paramEnduserType = new SqlParameter("@paramEnduserType", SqlDbType.NVarChar);
            paramEnduserType.Value = cmbendtype.SelectedItem;
            SqlParameter paramEnduserBillID = new SqlParameter("@paramEnduserBillID", SqlDbType.NVarChar);
            paramEnduserBillID.Value = cmbenduserrptbill.SelectedValue;
            SqlParameter paramPaidBy = new SqlParameter("@paramPaidBy", SqlDbType.NVarChar);
            paramPaidBy.Value = cmbpaidbyrpt.Text;


            SqlParameter paramFrom = new SqlParameter("@paramFrom", SqlDbType.Date);
            paramFrom.Value = dtpfromreport.Value.ToString("yyyy-MM-dd");
            SqlParameter paramTo = new SqlParameter("@paramTo", SqlDbType.Date);
            paramTo.Value = dtptoreport.Value.ToString("yyyy-MM-dd");
            SqlParameter paramAccount = new SqlParameter("@paramAccount", SqlDbType.NVarChar);
            paramAccount.Value = txtAccountNumbe.Text;



            if (cmbBillType1.Text == "Select" || cmbBillType1.Text == "Select" || cmbendtype.Text == "Select" || cmbpaidbyrpt.Text == "Select")
            {
                MessageBox.Show("Please Fill the missing filters first !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            else
            {



                //unpaid
                if (cbunpaid.Checked == true)
                {
                    if (cmbenduserrpt.Text == "Select")
                    {
                        MessageBox.Show("Please Select Enduser ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    paramPaymentStauts.Value = 0;

                    //coummunication

                    if (cmbBillType1.Text == "Communication")
                    {
                        // Base query
                        string queryCommuni = @"
    SELECT *
    FROM (
        SELECT   
            bps.AccountNo,
            bps.BillType,
            cb.ServiceNo,
            bps.IssuedDate,
            CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
            bps.BillAmount,
            dt.Dept_Type_Name AS Division,
            cb.Notes,
            
            -- Get the name of the person who approved it based on EndUserType
            COALESCE(
                CASE 
                    WHEN cb.EndUserType = 'Company' THEN hod.FirstName + ' ' + hod.LastName
                    WHEN cb.EndUserType = 'Personal' THEN 
                        (SELECT FirstName + ' ' + LastName 
                         FROM Employees 
                         WHERE EmployeeID = 
                            (SELECT DeptHeadID 
                             FROM DEPARTMENTS 
                             WHERE DeptID = (SELECT DeptID 
                                             FROM Employees 
                                             WHERE EmployeeID = e.EmployeeID)))
                END, 'Unknown') AS ApprovedBy,
            
            -- Extract only the first name for ordering purposes
            CASE 
                WHEN cb.EndUserType = 'Company' THEN c.ShortCompName
                WHEN cb.EndUserType = 'Personal' THEN e.FirstName
            END AS EndUserFirstName,
            
            -- Display full EndUserName for display
            CASE 
                WHEN cb.EndUserType = 'Company' THEN CONCAT(c.ShortCompName, ' / ', dt.Dept_Type_Name)
                WHEN cb.EndUserType = 'Personal' THEN CONCAT(e.FirstName, ' ', e.LastName)
            END AS EndUserName,
            
            cb.EndUserID AS EndUserID,
            cb.EndUserType,
            
            -- New column for head of department's company
            COALESCE(
                CASE 
                    WHEN cb.EndUserType = 'Company' THEN hodCompany.ShortCompName
                    WHEN cb.EndUserType = 'Personal' THEN 
                        (SELECT ShortCompName 
                         FROM Companies 
                         WHERE COMPID = (SELECT COMPID 
                                         FROM Employees 
                                         WHERE EmployeeID = 
                                             (SELECT DeptHeadID 
                                              FROM DEPARTMENTS 
                                              WHERE DeptID = e.DeptID)))
                END, 'Unknown') AS HeadOfDepartmentCompany,

            -- Use ROW_NUMBER to remove duplicates
            ROW_NUMBER() OVER (PARTITION BY bps.AccountNo, bps.BillAmount ORDER BY bps.IssuedDate) AS RowNum
     
        FROM 
            BillsPaymentStatus bps
            LEFT JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo AND cb.EndUserID IS NOT NULL
            LEFT JOIN Employees e ON cb.EndUserID = e.EmployeeID
            LEFT JOIN DEPARTMENTS d1 ON cb.EndUserType = 'Company' AND cb.EndUserID = d1.DeptID
            LEFT JOIN DEPARTMENTS d2 ON cb.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
            LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
            LEFT JOIN Companies c ON d1.COMPID = c.COMPID
            LEFT JOIN Employees hod ON cb.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID
            LEFT JOIN Companies hodCompany ON hod.COMPID = hodCompany.COMPID  -- Company of the head of department for Company end users
            
        WHERE 
            bps.BillType = @paramBillType
            AND bps.PaymentStatus = 0
            AND (
                (cb.EndUserType = 'Company' AND d1.DeptHeadID = @paramEnduserID) OR
                (cb.EndUserType = 'Personal' AND d2.DeptHeadID = @paramEnduserID)
            )
            AND cb.PaidBy = @paramPaidBy
    ) AS TempTable
    WHERE RowNum = 1
    ";

                        // Additional filtering conditions
                        if (cmbendtype.SelectedItem.ToString() != "All")
                        {
                            queryCommuni += " AND EndUserType = @paramEnduserType";
                        }
                        if (cmbenduserrptbill.Text.ToString() != "Select" && (int)cmbenduserrptbill.SelectedValue != 0)
                        {
                            queryCommuni += " AND EnduserID= @paramEnduserBillID";
                        }

                        // Apply ordering based on radio button selection
                        if (rbTop5Amount.Checked)
                        {
                            queryCommuni += " ORDER BY bps.BillAmount DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                        }
                        else if (rbTop5DisconnectDate.Checked)
                        {
                            queryCommuni += " ORDER BY bps.DisconnectDate DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                        }
                        else
                        {
                            queryCommuni += " ORDER BY EndUserFirstName";
                        }

                        // Execute the query
                        if (!string.IsNullOrWhiteSpace(queryCommuni))
                        {
                            dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryCommuni, paramBillType, paramPaymentStauts, paramApprovedBy, paramEnduserType, paramEnduserBillID, paramPaidBy);
                            countnumber.Text = dataGridView5.Rows.Count.ToString();
                        }
                    }




                    //Electrcity
                    else
                    {
                        string queryElectrcity = @" 
    SELECT 
        bps.AccountNo,
        bps.BillType,
        bps.IssuedDate,
        Ml.Meterlocation as Location,
        CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
        bps.BillAmount,
        dt.Dept_Type_Name as Division,
        eb.Notes,
        COALESCE(
            CASE 
                WHEN eb.EndUserType = 'Company' THEN hod.FirstName + ' ' + hod.LastName
                WHEN eb.EndUserType = 'Personal' THEN 
                    (SELECT FirstName +' '+ LastName 
                     FROM Employees 
                     WHERE EmployeeID = 
                        (SELECT DeptHeadID 
                         FROM DEPARTMENTS 
                         WHERE DeptID = 
                            (SELECT DeptID 
                             FROM Employees 
                             WHERE EmployeeID = e.EmployeeID)))
            END, 'Unknown') AS Approvedby,

        -- Display all divisions managed by the department head, separated by '/'
        CASE 
            WHEN eb.EndUserType = 'Company' THEN 
                (SELECT STRING_AGG(dt2.Dept_Type_Name, ' / ') 
                 FROM DEPARTMENTS d2
                 INNER JOIN DeptTypes dt2 ON d2.DeptName = dt2.Dept_Type_ID
                 WHERE d2.DeptHeadID = hod.EmployeeID)
            WHEN eb.EndUserType = 'Personal' THEN 
                (SELECT STRING_AGG(dt2.Dept_Type_Name, ' / ') 
                 FROM DEPARTMENTS d2
                 INNER JOIN DeptTypes dt2 ON d2.DeptName = dt2.Dept_Type_ID
                 WHERE d2.DeptHeadID = e.EmployeeID)
            ELSE NULL
        END AS Divisions,

        CASE 
            WHEN eb.EndUserType = 'Company' THEN CONCAT(c.ShortCompName,' / ', dt.Dept_Type_Name)
            WHEN eb.EndUserType = 'Personal' THEN CONCAT(e.FirstName, ' ', e.LastName)
        END AS EndUserName,
        eb.EndUserID AS EndUserID

    FROM 
        BillsPaymentStatus bps
        LEFT JOIN ElectrcityBills eb ON bps.AccountNo = eb.AccountNo AND eb.EndUserID IS NOT NULL
        LEFT JOIN Employees e ON eb.EndUserID = e.EmployeeID
        LEFT JOIN DEPARTMENTS d1 ON eb.EndUserType = 'Company' AND eb.EndUserID = d1.DeptID
        LEFT JOIN DEPARTMENTS d2 ON eb.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
        LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
        LEFT JOIN Companies c ON d1.COMPID = c.COMPID
        LEFT JOIN Employees hod ON eb.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID
        LEFT JOIN Meterlocations ML ON eb.MeterLocationID = ML.MeterLocationID

    WHERE 
        bps.BillType = @paramBillType
        AND bps.PaymentStatus = 0
        AND CASE 
                WHEN eb.EndUserType = 'Company' THEN d1.DeptHeadID
                WHEN eb.EndUserType = 'Personal' THEN d2.DeptHeadID
                ELSE d2.DeptHeadID
            END = @paramEnduserID
        AND eb.PaidBy = @paramPaidBy
";

                        if (cmbendtype.SelectedItem.ToString() != "All")
                        {
                            queryElectrcity += " AND eb.EndUserType = @paramEnduserType"; // Fixed alias reference
                        }
                        if (cmbenduserrptbill.Text.ToString() != "Select" && (int)cmbenduserrptbill.SelectedValue != 0)
                        {
                            queryElectrcity += " AND eb.EndUserID = @paramEnduserBillID"; // Fixed alias reference
                        }

                        // Modify query based on the selected filter option for Top 5
                        if (rbTop5Amount.Checked)
                        {
                            queryElectrcity += " ORDER BY bps.BillAmount DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                        }
                        else if (rbTop5DisconnectDate.Checked)
                        {
                            queryElectrcity += " ORDER BY bps.DisconnectDate DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                        }

                        // Check if the query is not empty before executing it
                        if (!string.IsNullOrWhiteSpace(queryElectrcity))
                        {
                            if (cmbendtype.SelectedItem.ToString() != "All")
                            {
                                dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryElectrcity, paramBillType, paramPaymentStauts, paramApprovedBy, paramEnduserType, paramEnduserBillID, paramPaidBy);
                                countnumber.Text = dataGridView5.Rows.Count.ToString();

                            }
                            else
                            {
                                dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryElectrcity, paramBillType, paramPaymentStauts, paramApprovedBy, paramPaidBy);
                                countnumber.Text = dataGridView5.Rows.Count.ToString();

                            }
                        }



                    }

                }



                //paid
                else
                {

                    if (txtAccountNumbe.Text == string.Empty)
                    {
                        MessageBox.Show(" Please fill the account number field ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        // Communication
                        if (cmbBillType1.Text == "Communication")
                        {


                            string queryCommuni = @"    

      SELECT *
    FROM (
        SELECT   
            bps.AccountNo,
            bps.BillType,
            cb.ServiceNo,
            bps.IssuedDate,
            CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
            bps.BillAmount,
            dt.Dept_Type_Name AS Division,
            cb.Notes,
        
      -- Get the name of the person who approved it based on EndUserType
            COALESCE(
                CASE 
                    WHEN cb.EndUserType = 'Company' THEN hod.FirstName + ' ' + hod.LastName
                    WHEN cb.EndUserType = 'Personal' THEN 
                        (SELECT FirstName + ' ' + LastName 
                         FROM Employees 
                         WHERE EmployeeID = 
                            (SELECT DeptHeadID 
                             FROM DEPARTMENTS 
                             WHERE DeptID = (SELECT DeptID 
                                             FROM Employees 
                                             WHERE EmployeeID = e.EmployeeID)))
                END, 'Unknown') AS ApprovedBy,
            
            -- Extract only the first name for ordering purposes
            CASE 
                WHEN cb.EndUserType = 'Company' THEN c.ShortCompName
                WHEN cb.EndUserType = 'Personal' THEN e.FirstName
            END AS EndUserFirstName,
            
            -- Display full EndUserName for display
            CASE 
                WHEN cb.EndUserType = 'Company' THEN CONCAT(c.ShortCompName, ' / ', dt.Dept_Type_Name)
                WHEN cb.EndUserType = 'Personal' THEN CONCAT(e.FirstName, ' ', e.LastName)
            END AS EndUserName,
            
            cb.EndUserID AS EndUserID,
            cb.EndUserType,
            
            -- New column for head of department's company
            COALESCE(
                CASE 
                    WHEN cb.EndUserType = 'Company' THEN hodCompany.ShortCompName
                    WHEN cb.EndUserType = 'Personal' THEN 
                        (SELECT ShortCompName 
                         FROM Companies 
                         WHERE COMPID = (SELECT COMPID 
                                         FROM Employees 
                                         WHERE EmployeeID = 
                                             (SELECT DeptHeadID 
                                              FROM DEPARTMENTS 
                                              WHERE DeptID = e.DeptID)))
                END, 'Unknown') AS HeadOfDepartmentCompany,

            -- Use ROW_NUMBER to remove duplicates
            ROW_NUMBER() OVER (PARTITION BY bps.AccountNo, bps.BillAmount ORDER BY bps.IssuedDate) AS RowNum
     
        FROM 
            BillsPaymentStatus bps
            LEFT JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo AND cb.EndUserID IS NOT NULL
            LEFT JOIN Employees e ON cb.EndUserID = e.EmployeeID
            LEFT JOIN DEPARTMENTS d1 ON cb.EndUserType = 'Company' AND cb.EndUserID = d1.DeptID
            LEFT JOIN DEPARTMENTS d2 ON cb.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
            LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
            LEFT JOIN Companies c ON d1.COMPID = c.COMPID
            LEFT JOIN Employees hod ON cb.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID
            LEFT JOIN Companies hodCompany ON hod.COMPID = hodCompany.COMPID  -- Company of the head of department for Company end users
            

  
      where 

        bps.BillType=@paramBillType
                          AND CONVERT(DATE, bps.IssuedDate) >= @paramFrom 
                          AND CONVERT(DATE, bps.IssuedDate) <= @paramTo
                          AND bps.AccountNo= @paramAccount
                       AND (
                (cb.EndUserType = 'Company' AND d1.DeptHeadID = @paramEnduserID) OR
                (cb.EndUserType = 'Personal' AND d2.DeptHeadID = @paramEnduserID)
            )
            AND cb.PaidBy = @paramPaidBy
    ) AS TempTable
    WHERE RowNum = 1
";


                            // Additional filtering conditions
                            if (cmbendtype.SelectedItem.ToString() != "All")
                            {
                                queryCommuni += " AND EndUserType = @paramEnduserType";
                            }
                            if (cmbenduserrptbill.Text.ToString() != "Select" && (int)cmbenduserrptbill.SelectedValue != 0)
                            {
                                queryCommuni += " AND EnduserID= @paramEnduserBillID";
                            }

                            // Apply ordering based on radio button selection
                            if (rbTop5Amount.Checked)
                            {
                                queryCommuni += " ORDER BY bps.BillAmount DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                            }
                            else if (rbTop5DisconnectDate.Checked)
                            {
                                queryCommuni += " ORDER BY bps.DisconnectDate DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                            }
                            else
                            {
                                queryCommuni += " ORDER BY EndUserFirstName";
                            }

                            // Execute the query
                            if (!string.IsNullOrWhiteSpace(queryCommuni))
                            {
                                dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryCommuni, paramBillType, paramFrom, paramTo, paramAccount, paramApprovedBy, paramEnduserType, paramEnduserBillID, paramPaidBy);
                                countnumber.Text = dataGridView5.Rows.Count.ToString();
                            }


                        }


                        // Electrcity
                        if (cmbBillType1.Text == "Electrcity")
                        {
                            string queryElectrcity = @"  
                        		  SELECT 
        bps.AccountNo,
        bps.BillType,
        bps.IssuedDate,
        Ml.Meterlocation as Location,
        CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
        bps.BillAmount,
        dt.Dept_Type_Name as Division,
        eb.Notes,
        COALESCE(
            CASE 
                WHEN eb.EndUserType = 'Company' THEN hod.FirstName + ' ' + hod.LastName
                WHEN eb.EndUserType = 'Personal' THEN 
                    (SELECT FirstName +' '+ LastName 
                     FROM Employees 
                     WHERE EmployeeID = 
                        (SELECT DeptHeadID 
                         FROM DEPARTMENTS 
                         WHERE DeptID = 
                            (SELECT DeptID 
                             FROM Employees 
                             WHERE EmployeeID = e.EmployeeID)))
            END, 'Unknown') AS Approvedby,

        -- Display all divisions managed by the department head, separated by '/'
        CASE 
            WHEN eb.EndUserType = 'Company' THEN 
                (SELECT STRING_AGG(dt2.Dept_Type_Name, ' / ') 
                 FROM DEPARTMENTS d2
                 INNER JOIN DeptTypes dt2 ON d2.DeptName = dt2.Dept_Type_ID
                 WHERE d2.DeptHeadID = hod.EmployeeID)
            WHEN eb.EndUserType = 'Personal' THEN 
                (SELECT STRING_AGG(dt2.Dept_Type_Name, ' / ') 
                 FROM DEPARTMENTS d2
                 INNER JOIN DeptTypes dt2 ON d2.DeptName = dt2.Dept_Type_ID
                 WHERE d2.DeptHeadID = e.EmployeeID)
            ELSE NULL
        END AS Divisions,

        CASE 
            WHEN eb.EndUserType = 'Company' THEN CONCAT(c.ShortCompName,' / ', dt.Dept_Type_Name)
            WHEN eb.EndUserType = 'Personal' THEN CONCAT(e.FirstName, ' ', e.LastName)
        END AS EndUserName,
        eb.EndUserID AS EndUserID

    FROM 
        BillsPaymentStatus bps
        LEFT JOIN ElectrcityBills eb ON bps.AccountNo = eb.AccountNo AND eb.EndUserID IS NOT NULL
        LEFT JOIN Employees e ON eb.EndUserID = e.EmployeeID
        LEFT JOIN DEPARTMENTS d1 ON eb.EndUserType = 'Company' AND eb.EndUserID = d1.DeptID
        LEFT JOIN DEPARTMENTS d2 ON eb.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
        LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
        LEFT JOIN Companies c ON d1.COMPID = c.COMPID
        LEFT JOIN Employees hod ON eb.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID
        LEFT JOIN Meterlocations ML ON eb.MeterLocationID = ML.MeterLocationID

                         WHERE 
        bps.BillType = @paramBillType
		                  AND CONVERT(DATE, bps.DisconnectDate) >= @paramFrom 
                          AND CONVERT(DATE, bps.DisconnectDate) <= @paramTo
                          AND bps.AccountNo= @paramAccount
              AND CASE 
                WHEN eb.EndUserType = 'Company' THEN d1.DeptHeadID
                WHEN eb.EndUserType = 'Personal' THEN d2.DeptHeadID
                ELSE d2.DeptHeadID
              END = @paramEnduserID
           AND eb.PaidBy = @paramPaidBy ";

                            if (cmbendtype.SelectedItem.ToString() != "All")
                            {
                                queryElectrcity += " AND eb.EndUserType = @paramEnduserType"; // Fixed alias reference
                            }
                            if (cmbenduserrptbill.Text.ToString() != "Select" && (int)cmbenduserrptbill.SelectedValue != 0)
                            {
                                queryElectrcity += " AND eb.EndUserID = @paramEnduserBillID"; // Fixed alias reference
                            }

                            // Modify query based on the selected filter option for Top 5
                            if (rbTop5Amount.Checked)
                            {
                                queryElectrcity += " ORDER BY bps.BillAmount DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                            }
                            else if (rbTop5DisconnectDate.Checked)
                            {
                                queryElectrcity += " ORDER BY bps.DisconnectDate DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                            }

                            // Check if the query is not empty before executing it
                            if (!string.IsNullOrWhiteSpace(queryElectrcity))
                            {
                                if (cmbendtype.SelectedItem.ToString() != "All")
                                {
                                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryElectrcity, paramBillType, paramPaymentStauts, paramApprovedBy, paramEnduserType, paramEnduserBillID, paramPaidBy);
                                    countnumber.Text = dataGridView5.Rows.Count.ToString();

                                }
                                else
                                {
                                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryElectrcity, paramBillType, paramFrom, paramTo, paramAccount, paramApprovedBy, paramPaidBy);
                                    countnumber.Text = dataGridView5.Rows.Count.ToString();

                                }
                            }



                        }

                    }
                }
            }
        }


                


        
        /*Display*/



        private void GenerateReport(DataTable dt)
        {
            // Bind the data to the DataGridView5
            dataGridView5.DataSource = dt;
        }
        /*Display */







        private void picVisa_Click(object sender, EventArgs e)
        {
            if (txtaccount3.Text != string.Empty)
            {
                Clipboard.SetText(txtaccount3.Text);
                txtvisa.Visible = true;
                txtvisa.Text = "Copied!";
            }
            else
            {

            }
        }

        private void cmbBillType1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void txtAccountNumbe_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbendusertype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtaccountno_TextChanged(object sender, EventArgs e)
        {
            ///  txtsubscription.Text = txtaccountno.Text;

        }

        private void cmbOwner_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbOwner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbOwner.SelectedValue != null)
            {
                cmbOwner.SelectedValue = Convert.ToInt64(cmbOwner.SelectedValue);
            }
        }






        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //ShowCrystalReport1();
        }

        private void cmbCompany_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            //DataRow dr;
            //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            //// SqlConnection conn = new SqlConnection(@"Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            //conn.Open();
            //SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1 ";


            //cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            //cmd.Parameters["@C1"].Value = cmbCompany.SelectedValue;


            ////Creating Sql Data Adapter
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter Da = new SqlDataAdapter(cmd);
            //Da.Fill(dt);
            //dr = dt.NewRow();


            //if (dt != null && dt.Rows.Count >= 0)
            //{

            //    cmbDvision.ValueMember = "DEPTID";
            //    cmbDvision.DisplayMember = "Dept_Type_Name";
            //    cmbDvision.DataSource = dt;
            //    cmbDvision.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    cmbDvision.AutoCompleteSource = AutoCompleteSource.ListItems;
            //    cmbDvision.Text = "Select";





            //}

            //conn.Close();
        }

        private void cmbrptusertype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SQLCONN.OpenConection();

            //cmbCompany.DataSource = null; // Clear the data source
            //cmbCompany.Enabled = false;
            //cmbDvision.Enabled = false;

            //switch (cmbrptusertype.SelectedItem.ToString())
            //{
            //    case "Company":
            //        label53.Text = "Company";
            //        cmbCompany.Enabled = true;
            //        cmbDvision.Enabled = true;

            //        cmbCompany.ValueMember = "COMPID";
            //        cmbCompany.DisplayMember = "COMPName_EN";
            //        cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID, COMPName_EN FROM Companies");
            //        break;

            //    case "Personal":
            //        label53.Text = "Employee";
            //        cmbCompany.Enabled = true;
            //        cmbDvision.Enabled = false;

            //        cmbCompany.ValueMember = "EmployeeID";
            //        cmbCompany.DisplayMember = "FullName";
            //        cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID, CONCAT(FirstName,' ', SecondName,' ', ThirdName,' ', LastName) AS 'FullName' FROM Employees ORDER BY EmployeeID");
            //        cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            //        break;

            //    default:
            //        label53.Text = "Type";
            //        break;
            //}

            //SQLCONN.CloseConnection();


        }

        private void cmbbillscompany_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbcombcomm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cmbempdepthistory.Enabled = true;
            //DataRow dr;
            //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            //// SqlConnection conn = new SqlConnection(@"Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            //conn.Open();
            //SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1 ";


            //cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            //cmd.Parameters["@C1"].Value = cmbcombcomm.SelectedValue;


            ////Creating Sql Data Adapter
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter Da = new SqlDataAdapter(cmd);
            //Da.Fill(dt);
            //dr = dt.NewRow();


            //if (dt != null && dt.Rows.Count >= 0)
            //{

            //    cmbempdepthistory.ValueMember = "DEPTID";
            //    cmbempdepthistory.DisplayMember = "Dept_Type_Name";
            //    cmbempdepthistory.DataSource = dt;
            //    cmbempdepthistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    cmbempdepthistory.AutoCompleteSource = AutoCompleteSource.ListItems;

            //}

            //conn.Close();
        }

        private void cmbRegisterType_SelectionChangeCommitted(object sender, EventArgs e)
        {

            SQLCONN.OpenConection();

            cmbRegisterUnder.DataSource = null; // Clear the data source


            switch (cmbRegisterType.SelectedItem.ToString())
            {
                case "Company":
                    cmbRegisterUnder.Enabled = true;
                    //  cmbemployee2.Enabled = true;

                    cmbRegisterUnder.ValueMember = "COMPID";
                    cmbRegisterUnder.DisplayMember = "COMPName_EN";
                    cmbRegisterUnder.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID, COMPName_EN FROM Companies");
                    break;

                case "Personal":
                    cmbRegisterUnder.Enabled = true;
                    //cmbemployee2.Enabled = true;

                    cmbRegisterUnder.ValueMember = "EmployeeID";
                    cmbRegisterUnder.DisplayMember = "FullName";
                    cmbRegisterUnder.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID, CONCAT(FirstName,' ', SecondName,' ', ThirdName,' ', LastName) AS 'FullName' FROM Employees ORDER BY EmployeeID");
                    cmbRegisterUnder.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbRegisterUnder.AutoCompleteSource = AutoCompleteSource.ListItems;
                    break;

                default:
                    break;
            }

            SQLCONN.CloseConnection();
        }

        private void cmbbillendusertype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();

            SQLCONN.CloseConnection();
        }

        private void cmbbillenduser_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {



        }

        private void button17_Click(object sender, EventArgs e)
        {



        }

        private void button18_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


        }
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {







        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }





        private void cbunpaid_CheckedChanged(object sender, EventArgs e)
        {
            if (cbunpaid.Checked == true)
            {
                groupBox5.Enabled = false;
                cmbenduserrpt.Enabled = true;

            }
            else
            {
                groupBox5.Enabled = true;
                cmbenduserrpt.Enabled = false;


            }
        }
        private void ExportDataGridViewToExcel(DataGridView dataGridView, ExcelWorksheet worksheet)
        {
            for (int i = 1; i <= dataGridView.ColumnCount; i++)
            {
                worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets.Add("General");

                ExportDataGridViewToExcel(dataGridView5, worksheet1);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save as Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    package.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                }
            }

        }
        //   I want to add this line for the queries   eu.EndUserType = @paramEnduserType and if cmbendtype.SelectedItem = 'Select' remove the condition
        private void button20_Click(object sender, EventArgs e)
        {
            dataGridView5.Visible = false;
            crystalReportViewer1.Visible = true;
            string query = "";
            DateTime startDate = this.dtpfromreport.Value.Date;
            DateTime endDate = this.dtptoreport.Value.Date;

            SqlParameter paramBillType = new SqlParameter("@paramBillType", SqlDbType.NVarChar);
            paramBillType.Value = cmbBillType1.Text;
            SqlParameter paramPaymentStauts = new SqlParameter("@paramPaymentStauts", SqlDbType.NVarChar);
            SqlParameter paramEnduserID = new SqlParameter("@paramEnduserID", SqlDbType.NVarChar);
            paramEnduserID.Value = cmbenduserrpt.SelectedValue;
            SqlParameter paramEnduserType = new SqlParameter("@paramEnduserType", SqlDbType.NVarChar);
            paramEnduserType.Value = cmbendtype.SelectedItem;
            SqlParameter paramEnduserBillID = new SqlParameter("@paramEnduserBillID", SqlDbType.NVarChar);
            paramEnduserBillID.Value = cmbenduserrptbill.SelectedValue;
            SqlParameter paramPaidBy = new SqlParameter("@paramPaidBy", SqlDbType.NVarChar);
            paramPaidBy.Value = cmbpaidbyrpt.Text;

            SqlParameter paramFrom = new SqlParameter("@paramFrom", SqlDbType.Date);
            paramFrom.Value = dtpfromreport.Value.ToString("yyyy-MM-dd");
            SqlParameter paramTo = new SqlParameter("@paramTo", SqlDbType.Date);
            paramTo.Value = dtptoreport.Value.ToString("yyyy-MM-dd");


            SqlParameter paramAccount = new SqlParameter("@paramAccount", SqlDbType.NVarChar);
            paramAccount.Value = txtAccountNumbe.Text;


            if (cmbBillType1.Text == "Select")
            {
                MessageBox.Show("Please select the type of report ! ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {


                //unpaid
                if (cbunpaid.Checked == true)
                {
                    // check if enduser is selected or not 
                    if (cmbenduserrpt.Text == "Select")
                    {
                        MessageBox.Show("Please Select 'Approved By' Value ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    paramPaymentStauts.Value = 0;

                    // Communication Section
                    if (cmbBillType1.Text == "Communication")
                    {
                        query = @"
        SELECT *
        FROM (
            SELECT   
                bps.AccountNo,
                bps.BillType,
                cb.ServiceNo,
                bps.IssuedDate,
                CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
                bps.BillAmount,
                dt.Dept_Type_Name AS Division,
                cb.Notes,
                COALESCE(
                    CASE 
                        WHEN cb.EndUserType = 'Company' THEN hod.FirstName + ' ' + hod.LastName
                        WHEN cb.EndUserType = 'Personal' THEN 
                            (SELECT FirstName + ' ' + LastName 
                             FROM Employees 
                             WHERE EmployeeID = 
                                (SELECT DeptHeadID 
                                 FROM DEPARTMENTS 
                                 WHERE DeptID = (SELECT DeptID 
                                                 FROM Employees 
                                                 WHERE EmployeeID = e.EmployeeID)))
                    END, 'Unknown') AS ApprovedBy,
                CASE 
                    WHEN cb.EndUserType = 'Company' THEN c.ShortCompName
                    WHEN cb.EndUserType = 'Personal' THEN e.FirstName
                END AS EndUserFirstName,
                CASE 
                    WHEN cb.EndUserType = 'Company' THEN CONCAT(c.ShortCompName, ' / ', dt.Dept_Type_Name)
                    WHEN cb.EndUserType = 'Personal' THEN CONCAT(e.FirstName, ' ', e.LastName)
                END AS EndUserName,
                cb.EndUserID AS EndUserID,
                cb.EndUserType,
                COALESCE(
                    CASE 
                        WHEN cb.EndUserType = 'Company' THEN hodCompany.ShortCompName
                        WHEN cb.EndUserType = 'Personal' THEN 
                            (SELECT ShortCompName 
                             FROM Companies 
                             WHERE COMPID = (SELECT COMPID 
                                             FROM Employees 
                                             WHERE EmployeeID = 
                                                 (SELECT DeptHeadID 
                                                  FROM DEPARTMENTS 
                                                  WHERE DeptID = e.DeptID)))
                    END, 'Unknown') AS HeadOfDepartmentCompany,
                ROW_NUMBER() OVER (PARTITION BY bps.AccountNo, bps.BillAmount ORDER BY bps.IssuedDate) AS RowNum
            FROM 
                BillsPaymentStatus bps
                LEFT JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo AND cb.EndUserID IS NOT NULL
                LEFT JOIN Employees e ON cb.EndUserID = e.EmployeeID
                LEFT JOIN DEPARTMENTS d1 ON cb.EndUserType = 'Company' AND cb.EndUserID = d1.DeptID
                LEFT JOIN DEPARTMENTS d2 ON cb.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
                LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
                LEFT JOIN Companies c ON d1.COMPID = c.COMPID
                LEFT JOIN Employees hod ON cb.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID
                LEFT JOIN Companies hodCompany ON hod.COMPID = hodCompany.COMPID
            WHERE 
                bps.BillType = @paramBillType
                AND bps.PaymentStatus = 0
                AND (
                    (cb.EndUserType = 'Company' AND d1.DeptHeadID = @paramEnduserID) OR
                    (cb.EndUserType = 'Personal' AND d2.DeptHeadID = @paramEnduserID)
                )
                AND cb.PaidBy = @paramPaidBy 
";

                    }

                    // Electricity Section
                    else
                    {
                        query = @"
      SELECT *
    FROM (
        SELECT 
        bps.AccountNo,
        bps.BillType,
        bps.IssuedDate,
        Ml.Meterlocation as Location,
        CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
        bps.BillAmount,
        dt.Dept_Type_Name as Division,
        eb.Notes,
         -- Get the name of the person who approved it based on EndUserType
            COALESCE(
                CASE 
                    WHEN eb.EndUserType = 'Company' THEN hod.FirstName + ' ' + hod.LastName
                    WHEN eb.EndUserType = 'Personal' THEN 
                        (SELECT FirstName + ' ' + LastName 
                         FROM Employees 
                         WHERE EmployeeID = 
                            (SELECT DeptHeadID 
                             FROM DEPARTMENTS 
                             WHERE DeptID = (SELECT DeptID 
                                             FROM Employees 
                                             WHERE EmployeeID = e.EmployeeID)))
                END, 'Unknown') AS ApprovedBy,
            
            -- Extract only the first name for ordering purposes
            CASE 
                WHEN eb.EndUserType = 'Company' THEN c.ShortCompName
                WHEN eb.EndUserType = 'Personal' THEN e.FirstName
            END AS EndUserFirstName,
            
            -- Display full EndUserName for display
            CASE 
                WHEN eb.EndUserType = 'Company' THEN CONCAT(c.ShortCompName, ' / ', dt.Dept_Type_Name)
                WHEN eb.EndUserType = 'Personal' THEN CONCAT(e.FirstName, ' ', e.LastName)
            END AS EndUserName,
            
            eb.EndUserID AS EndUserID,
            eb.EndUserType,
            
            -- New column for head of department's company
            COALESCE(
                CASE 
                    WHEN eb.EndUserType = 'Company' THEN hodCompany.ShortCompName
                    WHEN eb.EndUserType = 'Personal' THEN 
                        (SELECT ShortCompName 
                         FROM Companies 
                         WHERE COMPID = (SELECT COMPID 
                                         FROM Employees 
                                         WHERE EmployeeID = 
                                             (SELECT DeptHeadID 
                                              FROM DEPARTMENTS 
                                              WHERE DeptID = e.DeptID)))
                END, 'Unknown') AS HeadOfDepartmentCompany,

            -- Use ROW_NUMBER to remove duplicates
            ROW_NUMBER() OVER (PARTITION BY bps.AccountNo, bps.BillAmount ORDER BY bps.IssuedDate) AS RowNum

    FROM 
        BillsPaymentStatus bps
            LEFT JOIN ElectrcityBills eb ON bps.AccountNo = eb.AccountNo AND eb.EndUserID IS NOT NULL
            LEFT JOIN Employees e ON eb.EndUserID = e.EmployeeID
            LEFT JOIN DEPARTMENTS d1 ON eb.EndUserType = 'Company' AND eb.EndUserID = d1.DeptID
            LEFT JOIN DEPARTMENTS d2 ON eb.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
            LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
            LEFT JOIN Companies c ON d1.COMPID = c.COMPID
            LEFT JOIN Employees hod ON eb.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID
            LEFT JOIN Companies hodCompany ON hod.COMPID = hodCompany.COMPID  -- Company of the head of department for Company end users
            LEFT JOIN Meterlocations ML ON eb.MeterLocationID = ML.MeterLocationID
	 
   
        WHERE 
                bps.BillType = @paramBillType
                AND bps.PaymentStatus = 0
                AND (
                    (eb.EndUserType = 'Company' AND d1.DeptHeadID = @paramEnduserID) OR
                    (eb.EndUserType = 'Personal' AND d2.DeptHeadID = @paramEnduserID)
                )
                AND eb.PaidBy = @paramPaidBy


";
                    }
                }

                //paid
                else
                {
                    if (txtAccountNumbe.Text == string.Empty)
                    {
                        MessageBox.Show(" Please fill the account number field ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        // Communication
                        if (cmbBillType1.Text == "Communication")
                        {
                            query = @"     SELECT *
    FROM (
        SELECT   
            bps.AccountNo,
            bps.BillType,
            cb.ServiceNo,
            bps.IssuedDate,
            CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
            bps.BillAmount,
            dt.Dept_Type_Name AS Division,
            cb.Notes,
        
      -- Get the name of the person who approved it based on EndUserType
            COALESCE(
                CASE 
                    WHEN cb.EndUserType = 'Company' THEN hod.FirstName + ' ' + hod.LastName
                    WHEN cb.EndUserType = 'Personal' THEN 
                        (SELECT FirstName + ' ' + LastName 
                         FROM Employees 
                         WHERE EmployeeID = 
                            (SELECT DeptHeadID 
                             FROM DEPARTMENTS 
                             WHERE DeptID = (SELECT DeptID 
                                             FROM Employees 
                                             WHERE EmployeeID = e.EmployeeID)))
                END, 'Unknown') AS ApprovedBy,
            
            -- Extract only the first name for ordering purposes
            CASE 
                WHEN cb.EndUserType = 'Company' THEN c.ShortCompName
                WHEN cb.EndUserType = 'Personal' THEN e.FirstName
            END AS EndUserFirstName,
            
            -- Display full EndUserName for display
            CASE 
                WHEN cb.EndUserType = 'Company' THEN CONCAT(c.ShortCompName, ' / ', dt.Dept_Type_Name)
                WHEN cb.EndUserType = 'Personal' THEN CONCAT(e.FirstName, ' ', e.LastName)
            END AS EndUserName,
            
            cb.EndUserID AS EndUserID,
            cb.EndUserType,
            
            -- New column for head of department's company
            COALESCE(
                CASE 
                    WHEN cb.EndUserType = 'Company' THEN hodCompany.ShortCompName
                    WHEN cb.EndUserType = 'Personal' THEN 
                        (SELECT ShortCompName 
                         FROM Companies 
                         WHERE COMPID = (SELECT COMPID 
                                         FROM Employees 
                                         WHERE EmployeeID = 
                                             (SELECT DeptHeadID 
                                              FROM DEPARTMENTS 
                                              WHERE DeptID = e.DeptID)))
                END, 'Unknown') AS HeadOfDepartmentCompany,

            -- Use ROW_NUMBER to remove duplicates
            ROW_NUMBER() OVER (PARTITION BY bps.AccountNo, bps.BillAmount ORDER BY bps.IssuedDate) AS RowNum
     
        FROM 
            BillsPaymentStatus bps
            LEFT JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo AND cb.EndUserID IS NOT NULL
            LEFT JOIN Employees e ON cb.EndUserID = e.EmployeeID
            LEFT JOIN DEPARTMENTS d1 ON cb.EndUserType = 'Company' AND cb.EndUserID = d1.DeptID
            LEFT JOIN DEPARTMENTS d2 ON cb.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
            LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
            LEFT JOIN Companies c ON d1.COMPID = c.COMPID
            LEFT JOIN Employees hod ON cb.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID
            LEFT JOIN Companies hodCompany ON hod.COMPID = hodCompany.COMPID  -- Company of the head of department for Company end users
            

  
      where 

        bps.BillType=@paramBillType
                          AND CONVERT(DATE, bps.IssuedDate) >= @paramFrom 
                          AND CONVERT(DATE, bps.IssuedDate) <= @paramTo
                          AND bps.AccountNo= @paramAccount
                       AND (
                (cb.EndUserType = 'Company' AND d1.DeptHeadID = @paramEnduserID) OR
                (cb.EndUserType = 'Personal' AND d2.DeptHeadID = @paramEnduserID)
            )
            AND cb.PaidBy = @paramPaidBy
   ";
                        }

                        // Electrcity

                        else
                        {



                            query = @"  	SELECT *
FROM (
    SELECT 
        bps.AccountNo,
        bps.BillType,
        bps.IssuedDate,
        Ml.Meterlocation AS Location,
        CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
        bps.BillAmount,
        dt.Dept_Type_Name AS Division,
        eb.Notes,
        
        -- Get the name of the person who approved it based on EndUserType
        COALESCE(
            CASE 
                WHEN eb.EndUserType = 'Company' THEN hod.FirstName + ' ' + hod.LastName
                WHEN eb.EndUserType = 'Personal' THEN 
                    (SELECT FirstName + ' ' + LastName 
                     FROM Employees 
                     WHERE EmployeeID = 
                        (SELECT DeptHeadID 
                         FROM DEPARTMENTS 
                         WHERE DeptID = (SELECT DeptID 
                                         FROM Employees 
                                         WHERE EmployeeID = e.EmployeeID)))
            END, 'Unknown') AS ApprovedBy,
        
        -- Extract only the first name for ordering purposes
        CASE 
            WHEN eb.EndUserType = 'Company' THEN c.ShortCompName
            WHEN eb.EndUserType = 'Personal' THEN e.FirstName
        END AS EndUserFirstName,
        
        -- Display full EndUserName for display
        CASE 
            WHEN eb.EndUserType = 'Company' THEN CONCAT(c.ShortCompName, ' / ', dt.Dept_Type_Name)
            WHEN eb.EndUserType = 'Personal' THEN CONCAT(e.FirstName, ' ', e.LastName)
        END AS EndUserName,
        
        eb.EndUserID AS EndUserID,
        eb.EndUserType,
        
        -- New column for head of department's company
        COALESCE(
            CASE 
                WHEN eb.EndUserType = 'Company' THEN hodCompany.ShortCompName
                WHEN eb.EndUserType = 'Personal' THEN 
                    (SELECT ShortCompName 
                     FROM Companies 
                     WHERE COMPID = (SELECT COMPID 
                                     FROM Employees 
                                     WHERE EmployeeID = 
                                         (SELECT DeptHeadID 
                                          FROM DEPARTMENTS 
                                          WHERE DeptID = e.DeptID)))
            END, 'Unknown') AS HeadOfDepartmentCompany,

        -- Use ROW_NUMBER to remove duplicates
        ROW_NUMBER() OVER (PARTITION BY bps.AccountNo, bps.BillAmount ORDER BY bps.IssuedDate) AS RowNum

    FROM 
        BillsPaymentStatus bps
        LEFT JOIN ElectrcityBills eb ON bps.AccountNo = eb.AccountNo AND eb.EndUserID IS NOT NULL
        LEFT JOIN Employees e ON eb.EndUserID = e.EmployeeID
        LEFT JOIN DEPARTMENTS d1 ON eb.EndUserType = 'Company' AND eb.EndUserID = d1.DeptID
        LEFT JOIN DEPARTMENTS d2 ON eb.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
        LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
        LEFT JOIN Companies c ON d1.COMPID = c.COMPID
        LEFT JOIN Employees hod ON eb.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID
        LEFT JOIN Companies hodCompany ON hod.COMPID = hodCompany.COMPID
        LEFT JOIN Meterlocations ML ON eb.MeterLocationID = ML.MeterLocationID
	 
    WHERE 
        bps.BillType = @paramBillType
        AND bps.PaymentStatus = 0
        AND (
            (eb.EndUserType = 'Company' AND d1.DeptHeadID = @paramEnduserID) OR
            (eb.EndUserType = 'Personal' AND d2.DeptHeadID = @paramEnduserID)
        )
        AND eb.PaidBy = @paramPaidBy

 


";

                        }


                    }
                }
                    
               


                        // Add additional conditions based on selected filters
             if (cmbenduserrpt.SelectedValue != null)
                {
                    if (cmbBillType1.Text == "Communication")
                    {
                        query += " AND ((cb.EndUserType = 'Company' AND d1.DeptHeadID = @paramEnduserID) OR (cb.EndUserType = 'Personal' AND d2.DeptHeadID = @paramEnduserID))";
                    }
                    else {
                        query += " AND ((eb.EndUserType = 'Company' AND d1.DeptHeadID = @paramEnduserID) OR (eb.EndUserType = 'Personal' AND d2.DeptHeadID = @paramEnduserID))";

                    }
                }

                if (cmbenduserrptbill.Text.ToString() != "Select" && (int)cmbenduserrptbill.SelectedValue != 0)
                {
                    query += " AND EnduserID= @paramEnduserBillID";
                }

                if (!string.IsNullOrWhiteSpace(cmbpaidbyrpt.Text))
                {
                    if (cmbBillType1.Text == "Communication")
                    {
                        query += " AND cb.PaidBy = @paramPaidBy";

                    }
                    else {
                        query += " AND eb.PaidBy = @paramPaidBy";

                    }
                }

                if (cmbendtype.SelectedItem != null && cmbendtype.SelectedItem.ToString() != "All")
                {
                    query += " AND EndUserType = @paramEnduserType";
                }



                if (cbunpaid.Checked == false)
                {
                    query += " AND CONVERT(DATE, bps.IssuedDate) >= @paramFrom AND CONVERT(DATE, bps.IssuedDate) <= @paramTo AND bps.AccountNo = @paramAccount ";
                 

                }

                // Append final ordering and close the main query
                query += @"
) AS TempTable
WHERE RowNum = 1 ";

                if (rbTop5Amount.Checked)
                {
                    query += " ORDER BY bps.BillAmount DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                }
                else if (rbTop5DisconnectDate.Checked)
                {
                    query += " ORDER BY bps.DisconnectDate DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                }
                else
                {
                    query += " ORDER BY EndUserFirstName";
                }

                // Execute the query and fill DataTable
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(SQLCONN.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters dynamically based on the query
                    cmd.Parameters.AddWithValue("@paramBillType", cmbBillType1.Text);
                    if (cmbenduserrpt.SelectedValue != null)
                    {
                        cmd.Parameters.AddWithValue("@paramEnduserID", cmbenduserrpt.SelectedValue);
                    }
                    if (!string.IsNullOrWhiteSpace(cmbpaidbyrpt.Text))
                    {
                        cmd.Parameters.AddWithValue("@paramPaidBy", cmbpaidbyrpt.Text);
                    }
                    if (cmbendtype.SelectedItem != null && cmbendtype.SelectedItem.ToString() != "All")
                    {
                        cmd.Parameters.AddWithValue("@paramEnduserType", cmbendtype.SelectedItem.ToString());
                    }

                    if (cmbenduserrptbill.Text.ToString() != "Select" && (int)cmbenduserrptbill.SelectedValue != 0)
                    {
                        cmd.Parameters.AddWithValue("@paramEnduserBillID", cmbenduserrptbill.SelectedValue);
                    }
                    if (cbunpaid.Checked == false)
                    {
                        cmd.Parameters.AddWithValue("@paramFrom", dtpfromreport.Value);
                        cmd.Parameters.AddWithValue("@paramTo", dtptoreport.Value);
                        cmd.Parameters.AddWithValue("@paramAccount", txtAccountNumbe.Text);

                    }



                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }

                // Set up the report
                ReportDocument report = new ReportDocument();
                string reportName;

                // Check if the BillType is "Communication" and apply additional conditions
                if (cmbBillType1.Text == "Communication")
                {
                    if (cmbenduserrptbill.Text.ToString() != "Select" && cmbpaidbyrpt.Text == "Personal")
                    {
                        // If additional conditions are met, load the specified report (e.g., a customized Communication report)
                        reportName = "Delmon_Managment_System.Reports.BillsReport2.rpt";
                    }
                    else
                    {
                        // Load the default Communication report
                        reportName = "Delmon_Managment_System.Reports.BillsReport.rpt";
                    }
                }
                else
                {

                    //if (cmbenduserrptbill.Text.ToString() != "Select" && cmbpaidbyrpt.Text == "Personal")
                    //{
                    //    If additional conditions are met, load the specified report(e.g., a customized Communication report)
                    //    reportName = "Delmon_Managment_System.Reports.BillsReportElec2.rpt";

                    //}
                    //else
                    //{
                        // For other bill types, load a different report(e.g., Electricity report)
                        reportName = "Delmon_Managment_System.Reports.BillsReportElec.rpt";

                    //}


                }

                // Load the selected report
                using (Stream rptStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(reportName))
                {
                    if (rptStream != null)
                    {
                        string tempReportPath = Path.GetTempFileName();
                        using (FileStream tempFileStream = new FileStream(tempReportPath, FileMode.Create))
                        {
                            rptStream.CopyTo(tempFileStream);
                        }

                        report.Load(tempReportPath);
                        File.Delete(tempReportPath);
                    }
                    else
                    {
                        MessageBox.Show("Could not find the embedded report resource.");
                        return;
                    }
                }

                // Set up report parameters as usual
                report.SetDataSource(dataTable);
                // (Set other parameters here)

                // Display the report
                crystalReportViewer1.ReportSource = report;
                countnumber.Text = dataTable.Rows.Count.ToString();

                using (Stream rptStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(reportName))
                {
                    if (rptStream != null)
                    {
                        string tempReportPath = Path.GetTempFileName();
                        using (FileStream tempFileStream = new FileStream(tempReportPath, FileMode.Create))
                        {
                            rptStream.CopyTo(tempFileStream);
                        }

                        report.Load(tempReportPath);
                        File.Delete(tempReportPath);
                    }
                    else
                    {
                        MessageBox.Show("Could not find the embedded report resource.");
                        return;
                    }
                }

                report.SetDataSource(dataTable);

                if (query.Contains("@paramEnduserType"))
                {
                    report.SetParameterValue("@paramEnduserType", cmbendtype.SelectedItem.ToString());
                }
                report.SetParameterValue("@paramBillType", cmbBillType1.Text);
                report.SetParameterValue("@paramEnduserID", cmbenduserrpt.SelectedValue);
                report.SetParameterValue("@paramEnduserBillID", cmbenduserrptbill.SelectedValue);
                report.SetParameterValue("@paramPaidBy", cmbpaidbyrpt.Text);



                crystalReportViewer1.ReportSource = report;
                countnumber.Text = dataTable.Rows.Count.ToString();
            }





        }

        private void cmbenduserrpt_TextChanged(object sender, EventArgs e)
        {
            // Simple debugging log to see when this event gets triggered

            // This is just to check if the ComboBox is working without filtering
            if (originalDataendrpt != null)
            {
                // Set DataSource to original data to check for any issues
                cmbenduserrpt.DataSource = originalDataendrpt;
                cmbenduserrpt.ValueMember = "Value";
                cmbenduserrpt.DisplayMember = "DisplayValue";
            }
        }

        private void cmbenduserrptbill_TextChanged(object sender, EventArgs e)
        {
            if (originalDataendrptBill != null)
            {
                cmbenduserrptbill.DataSource = originalDataendrptBill;
                cmbenduserrptbill.DisplayMember = "DisplayValue";
                cmbenduserrptbill.ValueMember = "Value";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cmbBillType1.Text = "Select";
            cmbenduserrpt.Text = "Select";
            cmbendtype.Text = "All";
            cmbenduserrptbill.Text = "Select";
            cmbpaidbyrpt.Text = "Select";
            dataGridView5.DataSource = null;

        }

        private void cmbbillendusetypeelec_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();

            cmbbillenduserelec.DataSource = null; // Clear the data source
            cmbbillenduserelec.Enabled = false;
            cmbbillenduserdivisonelec.Enabled = false;

            switch (cmbbillendusetypeelec.SelectedItem.ToString())
            {
                case "Company":
                    label44.Text = "EndUser- Company";
                    cmbbillenduserelec.DataSource = null; // Clear the data source
                    cmbbillenduserelec.Enabled = true;
                    cmbbillenduserdivisonelec.Enabled = true;

                    cmbbillenduserelec.ValueMember = "COMPID";
                    cmbbillenduserelec.DisplayMember = "COMPName_EN";
                    cmbbillenduserelec.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID, COMPName_EN FROM Companies");
                    cmbbillenduserelec.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillenduserelec.AutoCompleteSource = AutoCompleteSource.ListItems;
                    break;

                case "Personal":
                    label44.Text = "EndUser- Employee";
                    cmbbillenduserelec.Enabled = true;
                    cmbbillenduserdivisonelec.Enabled = false;
                    cmbbillenduserelec.DataSource = null; // Clear the data source


                    cmbbillenduserelec.ValueMember = "EmployeeID";
                    cmbbillenduserelec.DisplayMember = "FullName";
                    cmbbillenduserelec.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID, CONCAT(FirstName,' ', SecondName,' ', ThirdName,' ', LastName) AS 'FullName' FROM Employees ORDER BY EmployeeID");
                    cmbbillenduserelec.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillenduserelec.AutoCompleteSource = AutoCompleteSource.ListItems;
                    break;

                default:
                    label44.Text = "Type";
                    break;
            }

            SQLCONN.CloseConnection();
        }

        private void cmbbillenduserelec_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbbillenduserdivisonelec.Enabled = true;
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            // SqlConnection conn = new SqlConnection(@"Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbbillenduserelec.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbbillenduserdivisonelec.ValueMember = "DEPTID";
                cmbbillenduserdivisonelec.DisplayMember = "Dept_Type_Name";
                cmbbillenduserdivisonelec.DataSource = dt;
                cmbbillenduserdivisonelec.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbbillenduserdivisonelec.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbbillenduserdivisonelec.Text = "Select";





            }

            conn.Close();
        }

        private void cmbbillendusertypecomm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();


            cmbbillendusercomm.Enabled = false;
            cmbbillenduserdevisionecomm.Enabled = false;

            switch (cmbbillendusertypecomm.SelectedItem.ToString())
            {
                case "Company":
                    label44.Text = "EndUser- Company";
                    cmbbillendusercomm.DataSource = null; // Clear the data source
                    cmbbillendusercomm.Enabled = true;
                    cmbbillenduserdevisionecomm.Enabled = true;

                    cmbbillendusercomm.ValueMember = "COMPID";
                    cmbbillendusercomm.DisplayMember = "COMPName_EN";
                    cmbbillendusercomm.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID, COMPName_EN FROM Companies");
                    cmbbillendusercomm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillendusercomm.AutoCompleteSource = AutoCompleteSource.ListItems;
                    break;

                case "Personal":
                    label50.Text = "EndUser- Employee";
                    cmbbillendusercomm.Enabled = true;
                    cmbbillenduserdevisionecomm.Enabled = false;
                    cmbbillendusercomm.DataSource = null; // Clear the data source


                    cmbbillendusercomm.ValueMember = "EmployeeID";
                    cmbbillendusercomm.DisplayMember = "FullName";
                    cmbbillendusercomm.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID, CONCAT(FirstName,' ', SecondName,' ', ThirdName,' ', LastName) AS 'FullName' FROM Employees ORDER BY EmployeeID");
                    cmbbillendusercomm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillendusercomm.AutoCompleteSource = AutoCompleteSource.ListItems;
                    break;

                default:
                    label50.Text = "Type";
                    break;
            }



            SQLCONN.CloseConnection();
        }

        private void cmbbillendusercomm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbbillenduserdevisionecomm.Enabled = true;
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            // SqlConnection conn = new SqlConnection(@"Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbbillendusercomm.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbbillenduserdevisionecomm.ValueMember = "DEPTID";
                cmbbillenduserdevisionecomm.DisplayMember = "Dept_Type_Name";
                cmbbillenduserdevisionecomm.DataSource = dt;
                cmbbillenduserdevisionecomm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbbillenduserdevisionecomm.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbbillenduserdevisionecomm.Text = "Select";





            }

            conn.Close();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmbpackage_TextChanged(object sender, EventArgs e)
        {
            // Simple debugging log to see when this event gets triggered

            // This is just to check if the ComboBox is working without filtering
            if (originalDataPack != null)
            {
                // Set DataSource to original data to check for any issues
                cmbpackage.DataSource = originalDataPack;
                cmbpackage.ValueMember = "PackageID";
                cmbpackage.DisplayMember = "PackageName";
            }
        }

        private void cmbcommenduser_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbElecEnduser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
