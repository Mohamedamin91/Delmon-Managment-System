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
        int LoggedEmployeeID;
        int PackageID;
        bool hasView = false;
        bool hasEdit = false;
        bool hasDelete = false;
        bool hasAdd = false;


        public BillsFrm()
        {
            InitializeComponent();

        }

        private void BillsFrm_Load(object sender, EventArgs e)
        {


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




            cmbcommenduser.ValueMember = "Value";
            cmbcommenduser.DisplayMember = "DisplayValue";
            cmbcommenduser.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT 
    CONCAT(c.ShortCompName,'/ ', dt.Dept_Type_Name) AS DisplayValue,
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
    eu.EndUserType = 'Personal' ");
            cmbcommenduser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbcommenduser.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbcommenduser.Text = "Select";




            cmbenduserrpt.ValueMember = "Value";
            cmbenduserrpt.DisplayMember = "DisplayValue";
            cmbenduserrpt.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT 
    CONCAT(c.ShortCompName,'/ ', dt.Dept_Type_Name) AS DisplayValue,
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
    eu.EndUserType = 'Personal' ");
            cmbenduserrpt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbenduserrpt.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbenduserrpt.Text = "Select";






            cmbElecEnduser.ValueMember = "Value";
            cmbElecEnduser.DisplayMember = "DisplayValue";
            cmbElecEnduser.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT 
    CONCAT(c.ShortCompName,'/ ', dt.Dept_Type_Name) AS DisplayValue,
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
    eu.EndUserType = 'Personal' ");
            cmbElecEnduser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbElecEnduser.AutoCompleteSource = AutoCompleteSource.ListItems;



            //cmbdeptelectry.ValueMember = "DEPTID";
            //cmbdeptelectry.DisplayMember = "Dept_Type_Name";
            //cmbdeptelectry.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID");
            //cmbdeptelectry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbdeptelectry.AutoCompleteSource = AutoCompleteSource.ListItems;







            //string query = "select COMPID,COMPName_EN from Companies";
            //cmbRegisterUnder.ValueMember = "COMPID";
            //cmbRegisterUnder.DisplayMember = "COMPName_EN";
            //cmbRegisterUnder.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
            //cmbRegisterUnder.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbRegisterUnder.AutoCompleteSource = AutoCompleteSource.ListItems;






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


            cmbpackage.ValueMember = "PackageID";
            cmbpackage.DisplayMember = "PackageName";
            cmbpackage.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT PackageID,PackageName FROM [Packages] where PackageID !=0");
            cmbpackage.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbpackage.AutoCompleteSource = AutoCompleteSource.ListItems;


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
            cmbElecEnduser.Text = "Select";



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
            cmbElecEnduser.SelectedIndex = -1;
            cmbOwner.SelectedIndex = -1;
            cmbservice.SelectedIndex = -1;
            RemarksTxt.Text = string.Empty;
            //cmbendusertype.SelectedIndex = -1;
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Create SQL parameters
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@C1", SqlDbType.NVarChar) { Value = txtaccountno.Text },
        new SqlParameter("@C3", SqlDbType.NVarChar) { Value = txtmetersn.Text },
        new SqlParameter("@C4", SqlDbType.NVarChar) { Value = cmbmeterlocation.SelectedValue },
        new SqlParameter("@C5", SqlDbType.NVarChar) { Value = cmbElecEnduser.SelectedValue },
        new SqlParameter("@C6", SqlDbType.BigInt) { Value = cmbOwner.SelectedValue },
        new SqlParameter("@C7", SqlDbType.NVarChar) { Value = cmbservice.SelectedValue },
        new SqlParameter("@C8", SqlDbType.NVarChar) { Value = RemarksTxt.Text },
        new SqlParameter("@id", SqlDbType.NVarChar) { Value = EmployeeID },
        new SqlParameter("@user", SqlDbType.NVarChar) { Value = lblusername.Text },
        new SqlParameter("@datetime", SqlDbType.NVarChar) { Value = lbldatetime.Text },
        new SqlParameter("@pc", SqlDbType.NVarChar) { Value = lblPC.Text }
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

            // Insert data into ElectrcityBills table
            string query = @"INSERT INTO [dbo].[ElectrcityBills] 
           ([AccountNo]
         ,[MeterSN]
         ,[MeterLocationID]
         ,[Ownerid]
         ,[EnduserType]
         ,[EndUserID]
         ,[ServiceStatusD]
         ,[Notes])
         VALUES
           (@C1,@C3,@C4,@C6,@C5,@C5,@C7,@C8)";

            SQLCONN.ExecuteQueries(query, parameters);

            // Insert data into EmployeeLog table
            string logQuery = "INSERT INTO EmployeeLog (logvalue, LogValueID, Oldvalue, newvalue, logdatetime, PCNAME, UserId, type) VALUES ('ElectrcityBills', @C1, '#', '#', @datetime, @pc, @user, 'Insert')";
            SqlParameter[] logParameters = new SqlParameter[] { parameters[0], parameters[9], parameters[10], parameters[8] };
            SQLCONN.ExecuteQueries(logQuery, logParameters);

            // Show success message
            MessageBox.Show("Record saved Successfully");

            // Refresh data grid view
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT [AccountNo]
    ,[MeterSN]
    ,[MeterLocationID]
    ,[Ownerid]
    ,[EnduserType]
    ,[EndUserID]
    ,[ServiceStatusD]
    ,[Notes]
      FROM [DelmonGroupDB].[dbo].[ElectrcityBills] WHERE AccountNo = @C1", parameters[0]);

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
      FROM [DelmonGroupDB].[dbo].[ElectrcityBills]
                    WHERE (AccountNo LIKE '%' + @C0 + '%'
                           OR MeterSN LIKE '%' + @C0 + '%'
                           OR EndUserID LIKE '%' + @C0 + '%'
                           OR ServiceStatusD LIKE '%' + @C0 + '%'
                           OR Notes LIKE '%' + @C0 + '%')";

            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);

            btn.Visible = true;

            SQLCONN.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AddBtn.Visible = false;
            btnUpdate.Visible = DeleteBtn.Visible = true;

            if (e.RowIndex == -1) return;

            txtaccountno.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtmetersn.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbmeterlocation.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbOwner.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            string endUserType = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbElecEnduser.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            cmbElecEnduser.Visible = true;
            cmbElecEnduser.Enabled = true;

            cmbservice.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            RemarksTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Create SQL parameters
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar) { Value = txtaccountno.Text };
            SqlParameter parammetersn = new SqlParameter("@C3", SqlDbType.NVarChar) { Value = txtmetersn.Text };
            SqlParameter paramWorkloc = new SqlParameter("@C4", SqlDbType.NVarChar) { Value = cmbmeterlocation.SelectedValue };
            SqlParameter paramElecEnduser = new SqlParameter("@C5", SqlDbType.NVarChar) { Value = cmbElecEnduser.SelectedValue };
            SqlParameter paramOwner = new SqlParameter("@C6", SqlDbType.BigInt) { Value = cmbOwner.SelectedValue };
            SqlParameter paramService = new SqlParameter("@C7", SqlDbType.NVarChar) { Value = cmbservice.SelectedValue };
            SqlParameter paramNote = new SqlParameter("@C8", SqlDbType.NVarChar) { Value = RemarksTxt.Text };
            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar) { Value = EmployeeID };
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar) { Value = lblusername.Text };
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar) { Value = lbldatetime.Text };
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar) { Value = lblPC.Text };

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
           [MeterSN] = @C3,
           [MeterLocationID] = @C4,
           [Ownerid] = @C6,
           [EnduserType] = @C5,
           [EndUserID] = @C5,
           [ServiceStatusD] = @C7,
           [Notes] = @C8
           WHERE [AccountNo] = @C1";
            SqlParameter[] parameters = new SqlParameter[] { paramaccount, parammetersn, paramWorkloc, paramElecEnduser, paramOwner, paramService, paramNote };

            SQLCONN.ExecuteQueries(query, parameters);

            // Insert data into EmployeeLog table
            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue, LogValueID, Oldvalue, newvalue, logdatetime, PCNAME, UserId, type) VALUES ('ElectrcityBills', @C1, '#', '#', @datetime, @pc, @user, 'Update')",
                paramaccount, paramdatetimeLOG, parampc, paramuser);

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
      FROM [DelmonGroupDB].[dbo].[ElectrcityBills] WHERE AccountNo = @C1", paramaccount);

            // Show button
            btn.Visible = true;

            // Close database connection
            SQLCONN.CloseConnection();
            ClearItems();
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
            paramenduser.Value = cmbcommenduser.SelectedValue;

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

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SqlDataReader dr;

            if ((int)cmbcommenduser.SelectedValue == 0 || (int)cmbservice2.SelectedValue == 0 || txtaccount.Text == "" || txtserviceNo.Text == "" || (int)cmbpackage.SelectedValue  == 0)
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {
                SQLCONN.OpenConection();
                dr = SQLCONN.DataReader("select  ServiceNo from CommunicationsBills where " +
                    " ServiceNo=  @C2 ", paramserviceNo);
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
        ,[Notes])
            VALUES
           (@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8,@C9)", paramaccount, paramserviceNo, paramenduser, paramRegisterType, paramRegisterUnder, paramPackage, paramService, paramExpiredate, paramNotes);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('CommunicationsBills',@C2,'#','#',@datetime,@pc,@user,'Insert')", paramserviceNo, paramdatetimeLOG, parampc, paramuser);

                        MessageBox.Show("Record saved Successfully");
                    }

                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  *
  FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
  where  ServiceNo = @C2 ", paramserviceNo);

                    txtaccount.Text = txtNotes.Text = txtserviceNo.Text = string.Empty;
                    cmbcommenduser.Text = cmbservice2.Text = cmbpackage.Text /*cmbDepartment.Text*/ = cmbRegisterType.Text = cmbRegisterUnder.Text = "Select";
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
                           ,[EndUserID]
                           ,[RegisterType]
                           ,[RegisterUnder]
                           ,[PackageID]
                           ,[ServiceStatusID]
                           ,[ExpireDate]
                           ,[Notes]
                        FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
                        WHERE (AccountNo LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR ServiceNo LIKE '%' + REPLACE(@C0,'', '') + '%'
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
                           ,[EndUserID]
                           ,[RegisterType]
                           ,[RegisterUnder]
                           ,[PackageID]
                           ,[ServiceStatusID]
                           ,[ExpireDate]
                           ,[Notes]
                        FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
                        WHERE (AccountNo LIKE '%' + REPLACE(@C0,'', '') + '%'
                            OR ServiceNo LIKE '%' + REPLACE(@C0,'', '') + '%'
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
            if (e.RowIndex == -1) return;

            // Disable the service number text box and button 4
            txtserviceNo.Enabled = false;
            button4.Visible = false;

            // Get the selected row
            DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

            // Populate the text boxes and combo boxes with the selected row's data
            txtaccount.Text = selectedRow.Cells[0].Value.ToString();
            txtserviceNo.Text = selectedRow.Cells[1].Value.ToString();
            cmbcommenduser.SelectedValue = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
            cmbRegisterType.SelectedItem = selectedRow.Cells[3].Value.ToString();
            // cmbdept.SelectedValue = Convert.ToInt32(selectedRow.Cells[5].Value.ToString());
            cmbpackage.SelectedValue = Convert.ToInt32(selectedRow.Cells[5].Value.ToString());
            cmbservice2.SelectedValue = Convert.ToInt32(selectedRow.Cells[6].Value.ToString());

            // Handle the date
            string dateString = selectedRow.Cells[7].Value.ToString();
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

            txtNotes.Text = selectedRow.Cells[8].Value.ToString();

            // Check if the register under is company or personal
            if (cmbRegisterType.SelectedIndex > -1 && cmbRegisterType.SelectedItem.ToString() == "Company")

            {
                cmbRegisterUnder.DataSource = null;

                string query = "select COMPID,COMPName_EN from Companies";
                cmbRegisterUnder.ValueMember = "COMPID";
                cmbRegisterUnder.DisplayMember = "COMPName_EN";
                cmbRegisterUnder.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
                cmbRegisterUnder.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbRegisterUnder.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbRegisterUnder.SelectedValue = Convert.ToInt32(selectedRow.Cells[4].Value.ToString());


                
                // Load the departments based on the chosen company
                // LoadDepartmentsByCompany(Convert.ToInt32(cmbRegisterUnder.SelectedValue));
            }
            if (cmbRegisterType.SelectedIndex > -1 && cmbRegisterType.SelectedItem.ToString() == "Personal")

            {
                cmbRegisterUnder.DataSource = null;

                string query = @"SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName) 'FullName' from Employees  order by EmployeeID ";
                cmbRegisterUnder.ValueMember = "EmployeeID";
                cmbRegisterUnder.DisplayMember = "FullName";
                cmbRegisterUnder.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
                cmbRegisterUnder.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbRegisterUnder.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbRegisterUnder.SelectedValue = Convert.ToInt32(selectedRow.Cells[4].Value.ToString());



                // Load the departments based on the chosen company
                // LoadDepartmentsByCompany(Convert.ToInt32(cmbRegisterUnder.SelectedValue));
            }


        }
        private void LoadDepartmentsByCompany(int companyId)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            //conn.Open();

            //SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1";

            //cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            //cmd.Parameters["@C1"].Value = companyId;

            //DataTable dt = new DataTable();
            //SqlDataAdapter Da = new SqlDataAdapter(cmd);
            //Da.Fill(dt);

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    cmbempdepthistory.ValueMember = "DEPTID";
            //    cmbempdepthistory.DisplayMember = "Dept_Type_Name";
            //    cmbempdepthistory.DataSource = dt;
            //    cmbempdepthistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    cmbempdepthistory.AutoCompleteSource = AutoCompleteSource.ListItems;
            //}

            //conn.Close();
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            //cmbservice2.Text = "Select";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount.Text;

            SqlParameter paramserviceNo = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramserviceNo.Value = txtserviceNo.Text;

            SqlParameter paramenduser = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramenduser.Value = cmbcommenduser.SelectedValue;

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

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if ((int)cmbcommenduser.SelectedValue == 0 || (int)cmbservice2.SelectedValue == 0 || txtaccount.Text == "" || txtserviceNo.Text == "" || (int)cmbpackage.SelectedValue ==0)
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
[EndUserID] = @C3,
[RegisterType] = @C4,
[RegisterUnder] = @C5,
[PackageID] = @C6,
[ServiceStatusID] = @C7,
[ExpireDate] = @C8,
[Notes] = @C9
WHERE [ServiceNo] = @C2", paramaccount, paramenduser, paramRegisterType, paramRegisterUnder, paramPackage, paramService, paramExpiredate, paramNotes, paramserviceNo);

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
                    cmbservice2.Text = cmbcommenduser.Text = cmbRegisterUnder.Text  = cmbpackage.Text = "Select";
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

            SqlParameter paramdisconnectdate = new SqlParameter("@C4", SqlDbType.Date);
            paramdisconnectdate.Value = dtpdisconnect.Value;

            SqlParameter paramBillAmount = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramBillAmount.Value = txtBillAmount.Text;
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
                    SQLCONN.ExecuteQueries(@"update   [dbo].[BillsPaymentStatus] set
       [AccountNo] = @C1
     ,[BillType] = @C2
     ,[IssuedDate] = @C3
     ,[DisconnectDate] = @C4
     ,[BillAmount] = @C5
      ,[PaymentStatus] = @C6

      where AccountNo = @C1 and [IssuedDate] = @C3 ", paramaccount, paramBillType, paramissuedate, paramdisconnectdate, paramBillAmount, paramPaymentstaus);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('BillsPaymentStatus',@C1,'#','#',@datetime,@pc,@user,'Update')", paramaccount, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Record Updated Successfully");
                }

                dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  [AccountNo]
      ,[BillType]
      ,[IssuedDate]
      ,[DisconnectDate]
      ,[BillAmount]  where " +
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
            paramBillAmount.Value = txtBillAmount.Text;

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

            SqlDataReader dr,dr2;

            if (txtaccount3.Text == "" || txtBillAmount.Text == "" || cmbBillType.Text=="Select")
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {
                SQLCONN.OpenConection();


                dr = SQLCONN.DataReader(" select BPS.AccountNo from BillsPaymentStatus BPS, CommunicationsBills CB, ElectrcityBills EB " +
                             " where BPS.AccountNo=@C1 or CB.AccountNo=@C1 or EB.AccountNo=@C1", paramaccount);
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

                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);
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
                    cmbservice2.Text = cmbcommenduser.Text = cmbpackage.Text = "Select";
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

            // Clear the text boxes
            txtaccount.Text = string.Empty;
            txtserviceNo.Text = string.Empty;
            txtNotes.Text = string.Empty;

            // Reset the combo boxes
            cmbcommenduser.SelectedIndex = -1;
            cmbRegisterType.Text = "Select";
            cmbRegisterUnder.Text = "Select";
            cmbpackage.SelectedIndex = -1;
            cmbservice2.SelectedIndex = -1;

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


            }

            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {

                cmbReportType.Text = "Select";
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                textBox2.Focus();
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[4])
            {
                cmbbillendusertype.Text = "Select";
                cmbbillenduserdvision.Text = "Select";

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[5])
            {
                
                cmbBillType1.Text = "Select";
                cmbenduserrpt.Text = "Select";

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        /*Uplode-import**/
        private void btnuplode_Click(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            if (cmbReportType.Text == "Select")
            {
                MessageBox.Show("Please select report type!.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*Communication*/
            if (cmbReportType.Text == "Communication")
            {
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
                        Dictionary<string, DateTime> existingRecords = GetExistingRecords();

                        // Iterate through each row in the DataTable


                        foreach (DataRow row in table.Rows)
                        {
                            string accountNo = row["Billing Account Number"].ToString();
                            paramaccount.Value =accountNo;

                            string billType = GetBillType(cmbReportType.Text);
                            DateTime billDateGregorian = Convert.ToDateTime(row["Bill Date Gregorian (Last issued bill)"].ToString());
                            DateTime disconnectDate = billDateGregorian.AddMonths(1).AddDays(-1);
                            string balance = row["Balance"].ToString();

                            // Check for duplicates
                            if (existingRecords.ContainsKey(accountNo) && existingRecords[accountNo].ToString("yyyy-MM-dd") == billDateGregorian.ToString("yyyy-MM-dd"))
                            {
                                MessageBox.Show($"Duplicate found for Account No: {accountNo} and Bill Date: {billDateGregorian}. Stopping the operation.", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            else
                            {
                                // update previous status for spcific account number 

                                SQLCONN.ExecuteQueries("UPDATE BillsPaymentStatus SET PaymentStatus = 1 WHERE AccountNo = @C1 AND PaymentStatus = 0", paramaccount);

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
            }
            /*Communication*/

            /*Electrcity*/
            if (cmbReportType.Text == "Electrcity")
            {
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
                        Dictionary<string, DateTime> existingRecords = GetExistingRecords();

                        // Iterate through each row in the DataTable


                        foreach (DataRow row in table.Rows)
                        {
                            string accountNo = row["AccountNo"].ToString();
                            paramaccount.Value = accountNo;


                            string billType = GetBillType(cmbReportType.Text);
                            DateTime billDateGregorian = Convert.ToDateTime(row["DisconnectDate"].ToString());
                            DateTime disconnectDate = Convert.ToDateTime(row["DisconnectDate"].ToString());

                            // DateTime disconnectDate = billDateGregorian.AddMonths(1).AddDays(-1);
                            //DisconnectDate
                            string balance = row["BillAmount"].ToString();

                            // Check for duplicates
                            if (existingRecords.ContainsKey(accountNo) && existingRecords[accountNo].ToString("yyyy-MM-dd") == billDateGregorian.ToString("yyyy-MM-dd"))
                            {
                                MessageBox.Show($"Duplicate found for Account No: {accountNo} and Bill Date: {billDateGregorian}. Stopping the operation.", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            else
                            {
                                // update previous status for spcific account number 
                                SQLCONN.ExecuteQueries("UPDATE BillsPaymentStatus SET PaymentStatus = 1 WHERE AccountNo = @C1 AND PaymentStatus = 0", paramaccount);

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
            }
            /*Electrcity*/
            SQLCONN.CloseConnection();



        }

        private DataTable ReadDataFromFile(string filePath, string fileExtension)
        {
            DataTable table = new DataTable();

            if (fileExtension == ".csv")
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    using (var dr1 = new CsvDataReader(csv))
                    {
                        table.Load(dr1);
                    }
                }
            }
            else if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".xlsm")
            {
                using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        table = result.Tables[0]; // Assuming data is in first sheet
                    }
                }
            }
            else
            {
                throw new Exception("Unsupported file format. Please select a CSV or Excel file.");
            }

            return table;
        }

        private Dictionary<string, DateTime> GetExistingRecords()
        {
            SQLCONN.OpenConection();
            Dictionary<string, DateTime> existingRecords = new Dictionary<string, DateTime>();
            SqlDataReader dr = SQLCONN.DataReader("SELECT AccountNo, IssuedDate FROM BillsPaymentStatus");
            while (dr.Read())
            {
                string dateStr = dr["IssuedDate"].ToString();
                DateTime billDateGregorian = Convert.ToDateTime(dateStr);
                existingRecords.Add(dr["AccountNo"].ToString(), billDateGregorian);
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

            SQLCONN.ExecuteQueries("INSERT INTO BillsPaymentStatus (AccountNo, BillType, IssuedDate, DisconnectDate, BillAmount) VALUES (@AccountNo, @BillType, @IssuedDate, @DisconnectDate, @BillAmount)", ParamAccountNo, ParamBillType, ParamBillDateGregorian, ParamBillDisconnectDate, ParamBalance);
        }
        /*Uplode-import**/

       
        
        
        /*Display*/
        private DataTable GetFilteredData(DateTime? fromDate, DateTime? toDate, string billType, string accountNumber)
        {
            // Create a query to get the filtered data
            string query = "SELECT * FROM BillsPaymentStatus WHERE 1=1";

            // Add filters if values are provided
            if (fromDate.HasValue)
            {
                query += " AND IssuedDate >= @fromDate";
            }
            if (toDate.HasValue)
            {
                query += " AND IssuedDate <= @toDate";
            }
            if (!string.IsNullOrEmpty(billType))
            {
                query += " AND BillType = @billType";
            }
            if (!string.IsNullOrEmpty(accountNumber))
            {
                query += " AND AccountNo LIKE @accountNumber";
            }

            // Create a DataTable to store the filtered data
            DataTable dt = new DataTable();

            // Execute the query and fill the DataTable
            using (SqlConnection conn = new SqlConnection(SQLCONN.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (fromDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    }
                    if (toDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@toDate", toDate);
                    }
                    if (!string.IsNullOrEmpty(billType))
                    {
                        cmd.Parameters.AddWithValue("@billType", billType);
                    }
                    if (!string.IsNullOrEmpty(accountNumber))
                    {
                        cmd.Parameters.AddWithValue("@accountNumber", "%" + accountNumber + "%");
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView5.Visible = true;
            crystalReportViewer1.Visible = false;
            SqlParameter paramBillType = new SqlParameter("@paramBillType", SqlDbType.NVarChar);
            paramBillType.Value = cmbBillType1.Text;
            SqlParameter paramPaymentStauts = new SqlParameter("@paramPaymentStauts", SqlDbType.NVarChar);
            SqlParameter paramEnduserID = new SqlParameter("@paramEnduserID", SqlDbType.NVarChar);
            paramEnduserID.Value = cmbenduserrpt.SelectedValue;

            SqlParameter paramFrom = new SqlParameter("@paramFrom", SqlDbType.Date);
            paramFrom.Value = dtpfromreport.Value.ToString("yyyy-MM-dd");
            SqlParameter paramTo = new SqlParameter("@paramTo", SqlDbType.Date);
            paramTo.Value = dtptoreport.Value.ToString("yyyy-MM-dd");
            SqlParameter paramAccount = new SqlParameter("@paramAccount", SqlDbType.NVarChar);
            paramAccount.Value = txtAccountNumbe.Text;




            if (cmbBillType1.Text == "Select")
            {
                MessageBox.Show("Please Select Report Type First !", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else 
            {
                if (cmbenduserrpt.Text == "Select")
                {
                    MessageBox.Show("Please Select Enduser ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //unpaid
                if (cbunpaid.Checked == true)
                {
                    paramPaymentStauts.Value = 0;

                    //coummunication

                    if (cmbBillType1.Text == "Communication")
                    {
                        string queryCommuni = @"SELECT 
    bps.AccountNo,
    cb.ServiceNo,
    bps.IssuedDate,
    CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
    bps.BillAmount,
	dt.Dept_Type_Name as Divison,
    COALESCE(
        CASE 
            WHEN eu.EndUserType = 'Company' THEN hod.FirstName +'' + hod.SecondName+''+hod.ThirdName+''+hod.LastName
            WHEN eu.EndUserType = 'Personal' THEN (SELECT FirstName +' ' + SecondName+' '+ThirdName+' '+LastName FROM Employees WHERE EmployeeID = (SELECT DeptHeadID FROM DEPARTMENTS WHERE DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = e.EmployeeID)))
        END, 'Unknown') AS HeadOFDepartment,

    CASE 
        WHEN eu.EndUserType = 'Company' THEN concat (c.ShortCompName,' / ',dt.Dept_Type_Name)
        WHEN eu.EndUserType = 'Personal' THEN concat (e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
    END AS EndUserName,
    eu.ID AS EndUserID

FROM 
    BillsPaymentStatus bps
  LEFT JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo AND cb.EndUserID IS NOT NULL
  LEFT JOIN EndUsers eu ON cb.EndUserID = eu.ID
  LEFT JOIN Employees e ON eu.ID = e.EmployeeID
  LEFT JOIN DEPARTMENTS d1 ON eu.EndUserType = 'Company' AND eu.ID = d1.DeptID
  LEFT JOIN DEPARTMENTS d2 ON eu.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
  LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
  LEFT JOIN Companies c ON d1.COMPID = c.COMPID
  LEFT JOIN Employees hod ON eu.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID

  where 

  bps.BillType=@paramBillType
  AND bps.PaymentStatus=0
  AND eu.ID=  @paramEnduserID ";
                        // Modify query based on the selected filter option
                        if (rbTop5Amount.Checked)
                        {
                            queryCommuni += " ORDER BY bps.BillAmount DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                        }
                        else if (rbTop5DisconnectDate.Checked)
                        {
                            queryCommuni += " ORDER BY bps.DisconnectDate DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                        }

                        // Check if the query is not empty before executing it
                        if (!string.IsNullOrWhiteSpace(queryCommuni))
                        {

                            dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryCommuni, paramBillType, paramPaymentStauts, paramEnduserID);
                        }
                    }
                    //Electrcity
                    else
                    {
                        string queryElectrcity = @" SELECT 
    bps.AccountNo,
    bps.IssuedDate,
    CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
    bps.BillAmount,
	dt.Dept_Type_Name as Divison,
    COALESCE(
        CASE 
            WHEN eu.EndUserType = 'Company' THEN hod.FirstName +'' + hod.SecondName+''+hod.ThirdName+''+hod.LastName
            WHEN eu.EndUserType = 'Personal' THEN (SELECT FirstName +' ' + SecondName+' '+ThirdName+' '+LastName FROM Employees WHERE EmployeeID = (SELECT DeptHeadID FROM DEPARTMENTS WHERE DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = e.EmployeeID)))
        END, 'Unknown') AS HeadOFDepartment,

    CASE 
        WHEN eu.EndUserType = 'Company' THEN concat (c.ShortCompName,' / ',dt.Dept_Type_Name)
        WHEN eu.EndUserType = 'Personal' THEN concat (e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
    END AS EndUserName,
    eu.ID AS EndUserID

FROM 
    BillsPaymentStatus bps
  LEFT JOIN ElectrcityBills eb ON bps.AccountNo = eb.AccountNo AND eb.EndUserID IS NOT NULL
  LEFT JOIN EndUsers eu ON eb.EndUserID = eu.ID
  LEFT JOIN Employees e ON eu.ID = e.EmployeeID
  LEFT JOIN DEPARTMENTS d1 ON eu.EndUserType = 'Company' AND eu.ID = d1.DeptID
  LEFT JOIN DEPARTMENTS d2 ON eu.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
  LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
  LEFT JOIN Companies c ON d1.COMPID = c.COMPID
  LEFT JOIN Employees hod ON eu.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID

  where 

  bps.BillType=@paramBillType
  AND bps.PaymentStatus=0
  AND eu.ID=  @paramEnduserID ";
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
                            dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryElectrcity, paramBillType, paramPaymentStauts, paramEnduserID);

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
                            string queryCommuni = @"SELECT 
    bps.AccountNo,
    bps.IssuedDate,
    CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
    bps.BillAmount,
	dt.Dept_Type_Name as Divison,

    COALESCE(
        CASE 
            WHEN eu.EndUserType = 'Company' THEN hod.FirstName +'' + hod.SecondName+''+hod.ThirdName+''+hod.LastName
            WHEN eu.EndUserType = 'Personal' THEN (SELECT FirstName +' ' + SecondName+' '+ThirdName+' '+LastName FROM Employees WHERE EmployeeID = (SELECT DeptHeadID FROM DEPARTMENTS WHERE DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = e.EmployeeID)))
        END, 'Unknown') AS HeadOFDepartment,

    CASE 
        WHEN eu.EndUserType = 'Company' THEN concat (c.ShortCompName,' / ',dt.Dept_Type_Name)
        WHEN eu.EndUserType = 'Personal' THEN concat (e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
    END AS EndUserName,
    eu.ID AS EndUserID

FROM 
    BillsPaymentStatus bps
  LEFT JOIN ElectrcityBills eb ON bps.AccountNo = eb.AccountNo AND eb.EndUserID IS NOT NULL
  LEFT JOIN EndUsers eu ON eb.EndUserID = eu.ID
  LEFT JOIN Employees e ON eu.ID = e.EmployeeID
  LEFT JOIN DEPARTMENTS d1 ON eu.EndUserType = 'Company' AND eu.ID = d1.DeptID
  LEFT JOIN DEPARTMENTS d2 ON eu.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
  LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
  LEFT JOIN Companies c ON d1.COMPID = c.COMPID
  LEFT JOIN Employees hod ON eu.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID

  where 

  bps.BillType=@paramBillType
  AND eu.ID=  @paramEnduserID
  AND CONVERT(DATE, bps.DisconnectDate) >= @paramFrom 
  AND CONVERT(DATE, bps.DisconnectDate) <= @paramTo
  AND bps.AccountNo= @paramAccount 
"
    ;
                            if (txtAccountNumbe.Text == "")
                            {
                                MessageBox.Show("please Fill the missing fields");
                            }
                            else
                            {
                                dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryCommuni, paramBillType, paramEnduserID, paramFrom, paramTo, paramAccount);
                            }
                        }

                        // Electrcity
                        if (cmbBillType1.Text == "Electrcity")
                        {
                            string queryElectrcity = @"SELECT 
    bps.AccountNo,
    cb.ServiceNo,
    bps.IssuedDate,
    CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
    bps.BillAmount,
	dt.Dept_Type_Name as Divison,

    COALESCE(
        CASE 
            WHEN eu.EndUserType = 'Company' THEN hod.FirstName +'' + hod.SecondName+''+hod.ThirdName+''+hod.LastName
            WHEN eu.EndUserType = 'Personal' THEN (SELECT FirstName +' ' + SecondName+' '+ThirdName+' '+LastName FROM Employees WHERE EmployeeID = (SELECT DeptHeadID FROM DEPARTMENTS WHERE DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = e.EmployeeID)))
        END, 'Unknown') AS HeadOFDepartment,

    CASE 
        WHEN eu.EndUserType = 'Company' THEN concat (c.ShortCompName,' / ',dt.Dept_Type_Name)
        WHEN eu.EndUserType = 'Personal' THEN concat (e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
    END AS EndUserName,
    eu.ID AS EndUserID

FROM 
    BillsPaymentStatus bps
  LEFT JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo AND cb.EndUserID IS NOT NULL
  LEFT JOIN EndUsers eu ON cb.EndUserID = eu.ID
  LEFT JOIN Employees e ON eu.ID = e.EmployeeID
  LEFT JOIN DEPARTMENTS d1 ON eu.EndUserType = 'Company' AND eu.ID = d1.DeptID
  LEFT JOIN DEPARTMENTS d2 ON eu.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
  LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
  LEFT JOIN Companies c ON d1.COMPID = c.COMPID
  LEFT JOIN Employees hod ON eu.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID

  where 

  bps.BillType=@paramBillType
  AND eu.ID=  @paramEnduserID
  AND CONVERT(DATE, bps.DisconnectDate) >= @paramFrom 
  AND CONVERT(DATE, bps.DisconnectDate) <= @paramTo
  AND bps.AccountNo= @paramAccount 
";
                            if (txtAccountNumbe.Text == "")
                            {
                                MessageBox.Show("please Fill the missing fields");
                            }
                            else
                            {
                                dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(queryElectrcity, paramBillType, paramEnduserID, paramFrom, paramTo, paramAccount);
                            }
                        }

                    }
                  }

           //     cmbBillType1.Text = cmbbillenduser.Text = "Select";

            }


         
        }
      
        
        
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
            //SQLCONN.OpenConection();

            //cmbbillenduser.DataSource = null; // Clear the data source
            //cmbbillenduser.Enabled = false;
            //cmbDvision.Enabled = false;

            //switch (cmbbillendusertype.SelectedItem.ToString())
            //{
            //    case "Company":
            //        label56.Text = "EndUser- Company";
            //        cmbbillenduser.Enabled = true;
            //        cmbDvision.Enabled = true;

            //        cmbbillenduser.ValueMember = "COMPID";
            //        cmbbillenduser.DisplayMember = "COMPName_EN";
            //        cmbbillenduser.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID, COMPName_EN FROM Companies");
            //        break;

            //    case "Personal":
            //        label56.Text = "EndUser- Employee";
            //        cmbbillenduser.Enabled = true;
            //        cmbDvision.Enabled = false;

            //        cmbbillenduser.ValueMember = "EmployeeID";
            //        cmbbillenduser.DisplayMember = "FullName";
            //        cmbbillenduser.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID, CONCAT(FirstName,' ', SecondName,' ', ThirdName,' ', LastName) AS 'FullName' FROM Employees ORDER BY EmployeeID");
            //        cmbbillenduser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        cmbbillenduser.AutoCompleteSource = AutoCompleteSource.ListItems;
            //        break;

            //    default:
            //        label56.Text = "Type";
            //        break;
            //}

            //SQLCONN.CloseConnection();
        }

        private void cmbbillenduser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbbillenduserdvision.Enabled = true;
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            // SqlConnection conn = new SqlConnection(@"Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbbillenduser.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbbillenduserdvision.ValueMember = "DEPTID";
                cmbbillenduserdvision.DisplayMember = "Dept_Type_Name";
                cmbbillenduserdvision.DataSource = dt;
                cmbbillenduserdvision.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbbillenduserdvision.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbbillenduserdvision.Text = "Select";





            }

            conn.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SqlParameter paramEndUserType = new SqlParameter("@EndUserType", SqlDbType.NVarChar);
            paramEndUserType.Value = cmbbillendusertype.SelectedItem;
            SqlParameter paramEnduserID = new SqlParameter("@ID", SqlDbType.NVarChar);

            if (cmbbillendusertype.SelectedItem.ToString() == "Personal")
            {
                paramEnduserID.Value = cmbbillenduser.SelectedValue;
            }
            else if (cmbbillendusertype.SelectedItem.ToString() == "Company")
            {
                paramEnduserID.Value = cmbbillenduserdvision.SelectedValue;
            }

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SqlDataReader dr;

            if (cmbbillendusertype.SelectedItem == null || (int)cmbbillenduser.SelectedValue == 0)
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {

                SQLCONN.OpenConection();
                dr = SQLCONN.DataReader("select  ID from EndUsers  where " +
                    "  EndUserType=@EndUserType and ID=@ID", paramEndUserType, paramEnduserID);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'End User'  Already Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {




                        dr.Dispose();
                        dr.Close();

                        SQLCONN.ExecuteQueries(@"INSERT INTO [dbo].[EndUsers]
       ([EndUserType]
  ,[ID])
     VALUES
          (@EndUserType,@ID)", paramEndUserType, paramEnduserID);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,logvalueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Endusers',@ID,'#','#',@datetime,@pc,@user,'Insert')", paramEnduserID, paramdatetimeLOG, parampc, paramuser);

                        //   btnnew.Visible = true;


                        MessageBox.Show("Record saved Successfully");
                    }
                    dr.Dispose();
                    dr.Close();

                    dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select eu.*,
            CASE 
                WHEN eu.EndUserType = 'Company' THEN dt.Dept_Type_Name
                WHEN eu.EndUserType = 'Personal' THEN CONCAT(e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
            END as Name,
            d.compid as CompanyID
            from EndUsers eu
            left join Departments d on eu.ID = d.DeptID
            left join DeptTypes dt on dt.Dept_Type_ID = d.deptname
            left join Employees e on eu.ID = e.EmployeeID  where " +
                    " EndUserType=@EndUserType and ID=@ID", paramEndUserType, paramEnduserID);




                }
                button15.Visible = true;
                SQLCONN.CloseConnection();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();
            SqlParameter paramEnduserID = new SqlParameter("@EndUserID", SqlDbType.NVarChar);
            paramEnduserID.Value = EnduuserID;

            SqlParameter paramEndUserType = new SqlParameter("@EndUserType", SqlDbType.NVarChar);
            paramEndUserType.Value = cmbbillendusertype.SelectedItem;

            SqlParameter paramID = new SqlParameter("@ID", SqlDbType.NVarChar);

            if (cmbbillendusertype.SelectedItem.ToString() == "Personal")
            {
                paramID.Value = cmbbillenduser.SelectedValue;
            }
            else if (cmbbillendusertype.SelectedItem.ToString() == "Company")
            {
                paramID.Value = cmbbillenduserdvision.SelectedValue;
            }

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SqlDataReader dr;

            if (cmbbillendusertype.Text == "Company")
            {
                if (cmbbillendusertype.SelectedItem == null  || (int)cmbbillenduser.SelectedValue == 0 && cmbbillenduserdvision.Text == "Select")
                {
                    MessageBox.Show("Please Fill the missing fields  ");
                }
            }

            else
            {
                string query = @"SELECT * FROM EndUsers WHERE EndUserType = @EndUserType  AND ID = @ID";
                dr = SQLCONN.DataReader(query, paramEndUserType, paramID);

                if (dr.Read())
                {
                    MessageBox.Show("Record already exists. Please update or delete the existing record.");
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to update this record", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        dr.Close();
                        dr.Dispose();


                        // Reopen the connection before executing the next query
                        SQLCONN.ExecuteQueries(@"UPDATE [dbo].[EndUsers] SET 
       [EndUserType] = @EndUserType
,[ID] = @ID
     WHERE 
          EndUserID =@EndUserID", paramEnduserID, paramEndUserType, paramID);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,logvalueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Endusers',@id,'#','#',@datetime,@pc,@user,'Update')", paramPID, paramdatetimeLOG, parampc, paramuser);

                        MessageBox.Show("Record updated Successfully");
                    }
                }

                dr.Close();
                dr.Dispose();
                dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select eu.*,
            CASE 
                WHEN eu.EndUserType = 'Company' THEN dt.Dept_Type_Name
                WHEN eu.EndUserType = 'Personal' THEN CONCAT(e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
            END as Name,
            d.compid as CompanyID
            from EndUsers eu
            left join Departments d on eu.ID = d.DeptID
            left join DeptTypes dt on dt.Dept_Type_ID = d.deptname
            left join Employees e on eu.ID = e.EmployeeID  where " +
                    " EndUserType=@EndUserType and ID=@ID ", paramID, paramEndUserType);
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlParameter paramEnduserID = new SqlParameter("@EndUserID", SqlDbType.NVarChar);
            paramEnduserID.Value = EnduuserID;

         
            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            if (cmbbillendusertype.SelectedItem == null || cmbbillenduserdvision.Text == "Select" || (int)cmbbillenduser.SelectedValue == 0)
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {

                SQLCONN.OpenConection();
              
               
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to delete this record", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {

                    

                        SQLCONN.ExecuteQueries(@"DELETE FROM [dbo].[EndUsers] WHERE EndUserID = @EndUserID ", paramEnduserID);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,logvalueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Endusers',@id,'#','#',@datetime,@pc,@user,'Delete')", paramPID, paramdatetimeLOG, parampc, paramuser);

                        MessageBox.Show("Record deleted Successfully");
                    }

                    dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select eu.*,
            CASE 
                WHEN eu.EndUserType = 'Company' THEN dt.Dept_Type_Name
                WHEN eu.EndUserType = 'Personal' THEN CONCAT(e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
            END as Name,
            d.compid as CompanyID
            from EndUsers eu
            left join Departments d on eu.ID = d.DeptID
            left join DeptTypes dt on dt.Dept_Type_ID = d.deptname
            left join Employees e on eu.ID = e.EmployeeID
           WHERE EndUserID = @EndUserID ", paramEnduserID );

                }
               

                button15.Visible = true;
                SQLCONN.CloseConnection();
            }
        

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            button19.Visible = true;
            button18.Visible = button17.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox4.Text;

            if (searchValue != "")
            {
                SQLCONN.OpenConection();
                dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select eu.*,
            CASE 
                WHEN eu.EndUserType = 'Company' THEN dt.Dept_Type_Name
                WHEN eu.EndUserType = 'Personal' THEN CONCAT(e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
            END as Name,
            d.compid as CompanyID
            from EndUsers eu
            left join Departments d on eu.ID = d.DeptID
            left join DeptTypes dt on dt.Dept_Type_ID = d.deptname
            left join Employees e on eu.ID = e.EmployeeID
            where (eu.EndUserType like @EndUserType or eu.ID like @ID or 
            (CASE 
                WHEN eu.EndUserType = 'Company' THEN dt.Dept_Type_Name
                WHEN eu.EndUserType = 'Personal' THEN CONCAT(e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
            END) like @Name) or 
            (eu.EndUserType = 'Company' and d.compid like @Compid)",
                                                            new SqlParameter("@EndUserType", "%" + searchValue + "%"),
                                                            new SqlParameter("@ID", "%" + searchValue + "%"),
                                                            new SqlParameter("@Name", "%" + searchValue + "%"),
                                                            new SqlParameter("@Compid", "%" + searchValue + "%"));

                SQLCONN.CloseConnection();
            }
        }
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            button17.Enabled = button18.Enabled = true;
            if (e.RowIndex >= 0)
            {
                SQLCONN.OpenConection();

                 EnduuserID = Convert.ToInt32(dataGridView6.Rows[e.RowIndex].Cells["EndUserID"].Value.ToString());
                string userType = dataGridView6.Rows[e.RowIndex].Cells["EndUserType"].Value.ToString();
                int ID = Convert.ToInt32(dataGridView6.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                cmbbillendusertype.Text = userType;

                if (userType == "Company")
                {
                    cmbbillenduser.DataSource = null;
                    string query12 = "select COMPID,COMPName_EN from Companies";
                    cmbbillenduser.ValueMember = "COMPID";
                    cmbbillenduser.DisplayMember = "COMPName_EN";
                    cmbbillenduser.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query12);
                    cmbbillenduser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillenduser.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbbillenduserdvision.Enabled =cmbbillenduser.Enabled= true;
                    int CompanyID = Convert.ToInt32(dataGridView6.Rows[e.RowIndex].Cells["companyid"].Value.ToString());

                    cmbbillenduser.SelectedValue = CompanyID;

                    cmbbillenduserdvision.ValueMember = "DEPTID";
                    cmbbillenduserdvision.DisplayMember = "Dept_Type_Name";
                    cmbbillenduserdvision.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and compid="+ CompanyID +"");
                    cmbbillenduserdvision.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbbillenduserdvision.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbbillenduserdvision.SelectedValue = ID;
                   
                }
                else if (userType == "Personal")
                {
                    cmbbillenduser.DataSource = cmbbillenduserdvision.DataSource=null;
                    cmbbillenduser.Enabled = true;
                    cmbbillenduserdvision.Enabled = false;
                    cmbbillenduserdvision.Text = "Select";
                    // Fill combobox with full names of employees
                    cmbbillenduser.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID, CONCAT(FirstName,' ', SecondName,' ', ThirdName,' ', LastName) AS FullName FROM Employees");
                    cmbbillenduser.ValueMember = "EmployeeID";
                    cmbbillenduser.DisplayMember = "FullName";
                    cmbbillenduser.SelectedValue = ID;

                }

                SQLCONN.CloseConnection();

            }

           
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

            }
            else 
            {
                groupBox5.Enabled = true;

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
                // check if enduser is selected or not 
                if (cmbenduserrpt.Text == "Select")
                {
                    MessageBox.Show("Please Select Enduser ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //unpaid
                if (cbunpaid.Checked == true)
                {
                    paramPaymentStauts.Value = 0;

                    //coummunication
                    if (cmbBillType1.Text == "Communication")
                    {
                        query = @"SELECT 
    bps.AccountNo,
    bps.BillType,
    cb.ServiceNo,
    bps.IssuedDate,
    CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
    bps.BillAmount,
	dt.Dept_Type_Name as Divison,

    COALESCE(
        CASE 
            WHEN eu.EndUserType = 'Company' THEN hod.FirstName +'' + hod.SecondName+''+hod.ThirdName+''+hod.LastName
            WHEN eu.EndUserType = 'Personal' THEN (SELECT FirstName +' ' + SecondName+' '+ThirdName+' '+LastName FROM Employees WHERE EmployeeID = (SELECT DeptHeadID FROM DEPARTMENTS WHERE DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = e.EmployeeID)))
        END, 'Unknown') AS HeadOFDepartment,

    CASE 
        WHEN eu.EndUserType = 'Company' THEN concat (c.ShortCompName,' / ',dt.Dept_Type_Name)
        WHEN eu.EndUserType = 'Personal' THEN concat (e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
    END AS EndUserName,
    eu.ID AS EndUserID

FROM 
    BillsPaymentStatus bps
  LEFT JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo AND cb.EndUserID IS NOT NULL
  LEFT JOIN EndUsers eu ON cb.EndUserID = eu.ID
  LEFT JOIN Employees e ON eu.ID = e.EmployeeID
  LEFT JOIN DEPARTMENTS d1 ON eu.EndUserType = 'Company' AND eu.ID = d1.DeptID
  LEFT JOIN DEPARTMENTS d2 ON eu.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
  LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
  LEFT JOIN Companies c ON d1.COMPID = c.COMPID
  LEFT JOIN Employees hod ON eu.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID

  where 

  bps.BillType=@paramBillType
  AND bps.PaymentStatus=0
  AND eu.ID=  @paramEnduserID ";

                    }
                    //Electrcity
                    else
                    {
                        query = @" SELECT 
    bps.AccountNo,
    bps.BillType,
    bps.IssuedDate,
    CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
    bps.BillAmount,
	dt.Dept_Type_Name as Divison,

    COALESCE(
        CASE 
            WHEN eu.EndUserType = 'Company' THEN hod.FirstName +'' + hod.SecondName+''+hod.ThirdName+''+hod.LastName
            WHEN eu.EndUserType = 'Personal' THEN (SELECT FirstName +' ' + SecondName+' '+ThirdName+' '+LastName FROM Employees WHERE EmployeeID = (SELECT DeptHeadID FROM DEPARTMENTS WHERE DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = e.EmployeeID)))
        END, 'Unknown') AS HeadOFDepartment,

    CASE 
        WHEN eu.EndUserType = 'Company' THEN concat (c.ShortCompName,' / ',dt.Dept_Type_Name)
        WHEN eu.EndUserType = 'Personal' THEN concat (e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
    END AS EndUserName,
    eu.ID AS EndUserID

FROM 
    BillsPaymentStatus bps
  LEFT JOIN ElectrcityBills eb ON bps.AccountNo = eb.AccountNo AND eb.EndUserID IS NOT NULL
  LEFT JOIN EndUsers eu ON eb.EndUserID = eu.ID
  LEFT JOIN Employees e ON eu.ID = e.EmployeeID
  LEFT JOIN DEPARTMENTS d1 ON eu.EndUserType = 'Company' AND eu.ID = d1.DeptID
  LEFT JOIN DEPARTMENTS d2 ON eu.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
  LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
  LEFT JOIN Companies c ON d1.COMPID = c.COMPID
  LEFT JOIN Employees hod ON eu.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID

  where 

  bps.BillType=@paramBillType
  AND bps.PaymentStatus=0
  AND eu.ID=  @paramEnduserID ";

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
                            query = @"SELECT 
    bps.AccountNo,
    bps.BillType,
    bps.IssuedDate,
    CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
    bps.BillAmount,
	dt.Dept_Type_Name as Divison,

    COALESCE(
        CASE 
            WHEN eu.EndUserType = 'Company' THEN hod.FirstName +'' + hod.SecondName+''+hod.ThirdName+''+hod.LastName
            WHEN eu.EndUserType = 'Personal' THEN (SELECT FirstName +' ' + SecondName+' '+ThirdName+' '+LastName FROM Employees WHERE EmployeeID = (SELECT DeptHeadID FROM DEPARTMENTS WHERE DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = e.EmployeeID)))
        END, 'Unknown') AS HeadOFDepartment,

    CASE 
        WHEN eu.EndUserType = 'Company' THEN concat (c.ShortCompName,' / ',dt.Dept_Type_Name)
        WHEN eu.EndUserType = 'Personal' THEN concat (e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
    END AS EndUserName,
    eu.ID AS EndUserID

FROM 
    BillsPaymentStatus bps
  LEFT JOIN ElectrcityBills eb ON bps.AccountNo = eb.AccountNo AND eb.EndUserID IS NOT NULL
  LEFT JOIN EndUsers eu ON eb.EndUserID = eu.ID
  LEFT JOIN Employees e ON eu.ID = e.EmployeeID
  LEFT JOIN DEPARTMENTS d1 ON eu.EndUserType = 'Company' AND eu.ID = d1.DeptID
  LEFT JOIN DEPARTMENTS d2 ON eu.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
  LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
  LEFT JOIN Companies c ON d1.COMPID = c.COMPID
  LEFT JOIN Employees hod ON eu.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID

  where 

  bps.BillType=@paramBillType
  AND eu.ID=  @paramEnduserID
  AND CONVERT(DATE, bps.DisconnectDate) >= @paramFrom 
  AND CONVERT(DATE, bps.DisconnectDate) <= @paramTo
  AND bps.AccountNo= @paramAccount 
"
   ;

                        }

                        // Electrcity
                        if (cmbBillType1.Text == "Electrcity")
                        {
                            query = @"SELECT 
    bps.AccountNo,
    bps.BillType,
    cb.ServiceNo,
    bps.IssuedDate,
    CONVERT(DATE, bps.DisconnectDate) AS DisconnectDate,
    bps.BillAmount,
	dt.Dept_Type_Name as Divison,

    COALESCE(
        CASE 
            WHEN eu.EndUserType = 'Company' THEN hod.FirstName +'' + hod.SecondName+''+hod.ThirdName+''+hod.LastName
            WHEN eu.EndUserType = 'Personal' THEN (SELECT FirstName +' ' + SecondName+' '+ThirdName+' '+LastName FROM Employees WHERE EmployeeID = (SELECT DeptHeadID FROM DEPARTMENTS WHERE DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = e.EmployeeID)))
        END, 'Unknown') AS HeadOFDepartment,

    CASE 
        WHEN eu.EndUserType = 'Company' THEN concat (c.ShortCompName,' / ',dt.Dept_Type_Name)
        WHEN eu.EndUserType = 'Personal' THEN concat (e.FirstName,' ', e.SecondName,' ', e.ThirdName,' ', e.LastName)
    END AS EndUserName,
    eu.ID AS EndUserID

FROM 
    BillsPaymentStatus bps
  LEFT JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo AND cb.EndUserID IS NOT NULL
  LEFT JOIN EndUsers eu ON cb.EndUserID = eu.ID
  LEFT JOIN Employees e ON eu.ID = e.EmployeeID
  LEFT JOIN DEPARTMENTS d1 ON eu.EndUserType = 'Company' AND eu.ID = d1.DeptID
  LEFT JOIN DEPARTMENTS d2 ON eu.EndUserType = 'Personal' AND e.DeptID = d2.DeptID
  LEFT JOIN DeptTypes dt ON COALESCE(d1.DeptName, d2.DeptName) = dt.Dept_Type_ID
  LEFT JOIN Companies c ON d1.COMPID = c.COMPID
  LEFT JOIN Employees hod ON eu.EndUserType = 'Company' AND d1.DeptHeadID = hod.EmployeeID

  where 

  bps.BillType=@paramBillType
  AND eu.ID=  @paramEnduserID
  AND CONVERT(DATE, bps.DisconnectDate) >= @paramFrom 
  AND CONVERT(DATE, bps.DisconnectDate) <= @paramTo
  AND bps.AccountNo= @paramAccount 
";

                        }

                    }
                    }

                // Modify query based on the selected filter option
                if (rbTop5Amount.Checked)
                {
                    query += " ORDER BY bps.BillAmount DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                }
                else if (rbTop5DisconnectDate.Checked)
                {
                    query += " ORDER BY bps.DisconnectDate DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";
                }

                // Check if the query is not empty before executing it
                if (!string.IsNullOrWhiteSpace(query))
                {

                    //...
                    DataTable dataTable = new DataTable();
                    // Check if the query is not empty before executing it
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        // Execute the query and fill the DataTable

                        using (SqlConnection conn = new SqlConnection(SQLCONN.ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand(query, conn);

                            // Add parameters dynamically based on the query
                            if (query.Contains("@paramAccount"))
                            {
                                cmd.Parameters.AddWithValue("@paramAccount", txtAccountNumbe.Text);
                            }
                            if (query.Contains("@paramBillType"))
                            {
                                cmd.Parameters.AddWithValue("@paramBillType", cmbBillType1.Text);
                            }
                            if (query.Contains("@paramFrom"))
                            {
                                cmd.Parameters.AddWithValue("@paramFrom", startDate.ToString("yyyy-MM-dd"));
                            }
                            if (query.Contains("@paramTo"))
                            {
                                cmd.Parameters.AddWithValue("@paramTo", endDate.ToString("yyyy-MM-dd"));
                            }
                          
                            if (query.Contains("@paramEnduserID"))
                            {
                                cmd.Parameters.AddWithValue("@paramEnduserID", cmbenduserrpt.SelectedValue);
                            }

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dataTable);
                        }

                        //...
                    }


                    // Set up the report
                    ReportDocument report = new ReportDocument();
                    string reportName = "";
                    if (cmbBillType1.Text == "Communication")
                    {
                         reportName = "Delmon_Managment_System.Reports.BillsReport.rpt";
                    }
                    if (cmbBillType1.Text == "Electrcity")
                    {
                        reportName = "Delmon_Managment_System.Reports.BillsReportElec.rpt";
                    }
                    using (Stream rptStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(reportName))
                    {
                        if (rptStream != null)
                        {
                            string tempReportPath = Path.GetTempFileName();
                            using (FileStream tempFileStream = new FileStream(tempReportPath, FileMode.Create))
                            {
                                rptStream.CopyTo(tempFileStream);
                                tempFileStream.Flush();
                            }

                            report.Load(tempReportPath);

                            if (File.Exists(tempReportPath))
                            {
                                File.Delete(tempReportPath);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Could not find the embedded report resource.");
                            return;
                        }
                    }

                    // Set report parameters
                    report.SetDataSource(dataTable);
                  

                    // Add parameters dynamically based on the query
                    if (query.Contains("@paramAccount"))
                    {
                        report.SetParameterValue("@paramAccount", txtAccountNumbe.Text);
                    }
                    if (query.Contains("@paramBillType"))
                    {
                        report.SetParameterValue("@paramBillType", cmbBillType1.Text);
                    }
                    if (query.Contains("@paramFrom"))
                    {
                        report.SetParameterValue("@paramFrom", startDate.ToString("yyyy-MM-dd"));
                    }
                    if (query.Contains("@paramTo"))
                    {
                        report.SetParameterValue("@paramTo", endDate.ToString("yyyy-MM-dd"));
                    }

                    if (query.Contains("@paramEnduserID"))
                    {
                        report.SetParameterValue("@paramEnduserID", cmbenduserrpt.SelectedValue);
                    }



                    // Display the report in the viewer
                    crystalReportViewer1.ReportSource = report;
                }
                //else
                //{
                //    MessageBox.Show("Please specify the filter criteria.");
                //}


            }


   //         cmbBillType1.Text = cmbbillenduser.Text = "Select";



        }






    }
}
