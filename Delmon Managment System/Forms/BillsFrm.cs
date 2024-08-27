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


namespace Delmon_Managment_System.Forms
{
    public partial class BillsFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        SQLCONNECTION SQLCONN2 = new SQLCONNECTION();
        int EmployeeID;
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
            

            cmbendusertype.SelectedItem = "Select";
            button5.Visible = true;
            button1.Visible = true;
            btn.Visible = true;
            cmbReportType.Text = "Select";

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

            cmbemployee.ValueMember = "EmployeeID";
            cmbemployee.DisplayMember = "FullName";
            cmbemployee.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            cmbemployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID,COMPName_EN FROM Companies");

            string query = "select COMPID,COMPName_EN from Companies";
            cmbRegisterUnder.ValueMember = "COMPID";
            cmbRegisterUnder.DisplayMember = "COMPName_EN";
            cmbRegisterUnder.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
            cmbRegisterUnder.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbRegisterUnder.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbmeterlocation.ValueMember = "MeterLocationID";
            cmbmeterlocation.DisplayMember = "Meterlocation";
            cmbmeterlocation.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [MeterLocationID]
      ,[Meterlocation]
  FROM [DelmonGroupDB].[dbo].[Meterlocations] order by MeterLocationID ");
            cmbmeterlocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbmeterlocation.AutoCompleteSource = AutoCompleteSource.ListItems;


            string query1 = "select COMPID,COMPName_EN from Companies";
            cmbbillscompany.ValueMember = "COMPID";
            cmbbillscompany.DisplayMember = "COMPName_EN";
            cmbbillscompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query1);
            cmbbillscompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbbillscompany.AutoCompleteSource = AutoCompleteSource.ListItems;


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


            //string query3 = @"SELECT CONVERT(VARCHAR, OwnerID) AS OwnerID, OwnerName FROM Owners";
            //cmbOwner.ValueMember = "OwnerID";
            //cmbOwner.DisplayMember = "OwnerName";
            //cmbOwner.DataSource = SQLCONN2.ShowDataInGridViewORCombobox(query3);
            //cmbOwner.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbOwner.AutoCompleteSource = AutoCompleteSource.ListItems;


//            string query3 = @"SELECT [Dept_Type_ID]
//     ,[Dept_Type_Name]
//FROM DeptTypes
//WHERE Dept_Type_ID BETWEEN 0 AND 17";
//            cmbDvision.ValueMember = "[Dept_Type_ID]";
//            cmbDvision.DisplayMember = "Dept_Type_Name";
//            cmbDvision.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query3);
//            cmbDvision.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//            cmbDvision.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbemployee2.Enabled = false;


            cmbservice.Text = "Select";
            cmbRegisterType.Text = "Select";
            cmbBillType.Text = "Select";
            cmbservice2.Text = "Select";
            cmbDvision.Text = "Select";



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
               groupBox4.Enabled= groupBox3.Enabled = groupBox6.Enabled = false;


            }
            else

            {
                tabControl1.Enabled = true;
                groupBox4.Enabled= groupBox3.Enabled = groupBox6.Enabled = true;

                if (hasEdit)
                {
                     //btnUpdate.Visible = button2.Visible = button6.Visible = button10.Visible = true;
                    btnUpdate.Enabled = button2.Enabled = button6.Enabled = button10.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled=dtptoreport.Enabled= true;
                }
                else
                {
                    btnUpdate.Enabled = button2.Enabled = button6.Enabled = button10.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled = dtptoreport.Enabled  = false;
                }
                if (hasDelete)
                {
                    // DeleteBtn.Visible = true;
                    DeleteBtn.Enabled = button3.Enabled = button7.Enabled = button11.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled = dtpfromreport.Enabled = dtptoreport.Enabled  = true;
                }
                else 
                {
                    DeleteBtn.Enabled = button3.Enabled = button7.Enabled = button11.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled= dtpfromreport.Enabled = dtptoreport.Enabled  = false;

                }
                if (hasAdd)
                {
                    btn.Visible = button1.Visible = button5.Visible = button9.Visible = true;
                    AddBtn.Enabled = button4.Enabled = button8.Enabled = button12.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled= dtpfromreport.Enabled = dtptoreport.Enabled  = true;
                }
                else 
                {
                    btn.Visible = button1.Visible = button5.Visible = button9.Visible = false;
                    AddBtn.Enabled = button4.Enabled = button8.Enabled = button12.Enabled = btnuplode.Enabled = btnuplode.Enabled = button13.Enabled = button14.Enabled = cmbReportType.Enabled= dtpfromreport.Enabled = dtptoreport.Enabled  = false;
                }

            }

            /*permissions*/



            SQLCONN.CloseConnection();
            SQLCONN2.CloseConnection();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            cmbemployee2.Enabled = false;
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
            txtsubscription.Text = string.Empty;
            txtmetersn.Text = string.Empty;
            cmbmeterlocation.SelectedIndex = -1;
            cmbemployee.SelectedIndex = -1;
            cmbOwner.SelectedIndex = -1;
            cmbservice.SelectedIndex = -1;
            RemarksTxt.Text = string.Empty;
            cmbendusertype.SelectedIndex = -1;
            cmbbillscompany.SelectedIndex = -1;
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Create SQL parameters
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar) { Value = txtaccountno.Text };
            SqlParameter paramsubscrip = new SqlParameter("@C2", SqlDbType.NVarChar) { Value = txtsubscription.Text };
            SqlParameter parammetersn = new SqlParameter("@C3", SqlDbType.NVarChar) { Value = txtmetersn.Text };
            SqlParameter paramWorkloc = new SqlParameter("@C4", SqlDbType.NVarChar) { Value = cmbmeterlocation.SelectedValue };
            SqlParameter paramHeadofDept = new SqlParameter("@C5", SqlDbType.NVarChar) { Value = cmbemployee.SelectedValue };


            SqlParameter paramOwner = new SqlParameter("@C6", SqlDbType.BigInt);
            paramOwner.Value = cmbOwner.SelectedValue;

            SqlParameter paramService = new SqlParameter("@C7", SqlDbType.NVarChar) { Value = cmbservice.SelectedValue };
            SqlParameter paramNote = new SqlParameter("@C8", SqlDbType.NVarChar) { Value = RemarksTxt.Text };
            SqlParameter paramCmbendusertpe = new SqlParameter("@C9", SqlDbType.NVarChar) { Value = cmbendusertype.SelectedItem };
            SqlParameter paramcompanybills = new SqlParameter("@C10", SqlDbType.NVarChar) { Value = cmbbillscompany.SelectedValue };

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar) { Value = EmployeeID };
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar) { Value = lblusername.Text };
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar) { Value = lbldatetime.Text };
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar) { Value = lblPC.Text };

            // Check for missing fields
            if ( (int)cmbservice.SelectedValue == 0 ||
                string.IsNullOrEmpty(txtaccountno.Text) || string.IsNullOrEmpty(txtsubscription.Text) || string.IsNullOrEmpty(txtmetersn.Text))
            {
                MessageBox.Show("Please Fill the missing fields  ");
                return;
            }

            // Open database connection
            SQLCONN.OpenConection();

            // Check if subscription number already exists
            SqlDataReader dr = SQLCONN.DataReader("select  AccountNo from ElectrcityBills  where AccountNo=  @C1 ", paramaccount);
            dr.Read();

            if (dr.HasRows)
            {
                MessageBox.Show("This 'AccountNo' " + txtaccount.Text +" Already Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string query = string.Empty;
            SqlParameter[] parameters = null;

            if (cmbendusertype.SelectedItem.ToString() == "Company")
            {
                query = @"INSERT INTO [dbo].[ElectrcityBills]
           ([AccountNo]
        ,[SubscriptionNo]
        ,[MeterSN]
        ,[MeterLocationID]
        ,[Ownerid]
        ,[EnduserType]
        ,[EndUserID]
        ,[ServiceStatusD]
        ,[Notes])
     VALUES
           (@C1,@C2,@C3,@C4,@C6,@C9,@C10,@C7,@C8)";
                parameters = new SqlParameter[] { paramaccount, paramsubscrip, parammetersn, paramWorkloc, paramOwner, paramCmbendusertpe, paramcompanybills, paramService, paramNote };
            }
            else if (cmbendusertype.SelectedItem.ToString() == "Personal")
            {
                query = @"INSERT INTO [dbo].[ElectrcityBills]
           ([AccountNo]
        ,[SubscriptionNo]
        ,[MeterSN]
        ,[MeterLocationID]
        ,[Ownerid]
        ,[EnduserType]
        ,[EndUserID]
        ,[ServiceStatusD]
        ,[Notes])
     VALUES
           (@C1,@C2,@C3,@C4,@C6,@C9,@C5,@C7,@C8)";
                parameters = new SqlParameter[] { paramaccount, paramsubscrip, parammetersn, paramWorkloc, paramOwner, paramCmbendusertpe, paramHeadofDept, paramService, paramNote };
            }

            SQLCONN.ExecuteQueries(query, parameters);

            // Insert data into EmployeeLog table
            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('ElectrcityBills',@C2,'#','#',@datetime,@pc,@user,'Insert')",
                paramsubscrip, paramdatetimeLOG, parampc, paramuser);

            // Show success message
            MessageBox.Show("Record saved Successfully");

            // Refresh data grid view


   // Refresh data grid view
dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [AccountNo]
   ,[SubscriptionNo]
   ,[MeterSN]
   ,[MeterLocationID]
   ,[Ownerid]
   ,[EnduserType]
   ,[EndUserID]
   ,[ServiceStatusD]
   ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills] WHERE SubscriptionNo = @C2 ", paramsubscrip);

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
            paramSearch.Value = txtSearch.Text;

            SQLCONN.OpenConection();
            if (lblusertype.Text == "Admin")
            {
                string query = @"SELECT  [AccountNo]
     ,[SubscriptionNo]
     ,[MeterSN]
     ,[MeterLocationID]
     ,[OwnerId]
     ,[EnduserType]
     ,[EndUserID]
     ,[ServiceStatusD]
     ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills]
  where (AccountNo LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR SubscriptionNo LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR MeterSN LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR EndUserID LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR EnduserType LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR ServiceStatusD LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR Notes LIKE '%' + REPLACE(@C0,'', '') + '%')";

                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);
            }
            else
            {
                string query = @"SELECT  [AccountNo]
     ,[SubscriptionNo]
     ,[MeterSN]
     ,[MeterLocationID]
     ,[OwnerId]
     ,[EnduserType]
     ,[EndUserID]
     ,[ServiceStatusD]
     ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills]
  where (AccountNo LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR SubscriptionNo LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR MeterSN LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR EndUserID LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR EnduserType LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR ServiceStatusD LIKE '%' + REPLACE(@C0,'', '') + '%'
       OR Notes LIKE '%' + REPLACE(@C0,'', '') + '%')";

                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);
            }

            btn.Visible = true;

            SQLCONN.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsubscription.Enabled = false;
            AddBtn.Visible = false;
            btnUpdate.Visible = DeleteBtn.Visible = true;

            if (e.RowIndex == -1) return;

            txtaccountno.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtsubscription.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmetersn.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbmeterlocation.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
           // cmbOwner.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            cmbOwner.SelectedValue = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());


            string endUserType = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbendusertype.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();



            if (endUserType == "Personal")
            {
                cmbemployee.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                cmbbillscompany.Visible = true;
                cmbbillscompany.Enabled = cmbemployee.Enabled=true;
                cmbbillscompany.SelectedValue = 0;
            }
            else if (endUserType == "Company")
            {
                cmbbillscompany.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                cmbemployee.Visible = true;
                cmbbillscompany.Enabled = cmbemployee.Enabled = true;
                cmbemployee.SelectedValue = 0;

            }

            cmbendusertype.SelectedValue = endUserType;
            cmbservice.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            RemarksTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {


            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar) { Value = txtaccountno.Text };
            SqlParameter paramsubscrip = new SqlParameter("@C2", SqlDbType.NVarChar) { Value = txtsubscription.Text };
            SqlParameter parammetersn = new SqlParameter("@C3", SqlDbType.NVarChar) { Value = txtmetersn.Text };
            SqlParameter paramWorkloc = new SqlParameter("@C4", SqlDbType.NVarChar) { Value = cmbmeterlocation.SelectedValue };
            SqlParameter paramHeadofDept = new SqlParameter("@C5", SqlDbType.NVarChar) { Value = cmbemployee.SelectedValue };

            SqlParameter paramOwner = new SqlParameter("@C6", SqlDbType.BigInt);
            paramOwner.Value = cmbOwner.SelectedValue;

            SqlParameter paramService = new SqlParameter("@C7", SqlDbType.NVarChar) { Value = cmbservice.SelectedValue };
            SqlParameter paramNote = new SqlParameter("@C8", SqlDbType.NVarChar) { Value = RemarksTxt.Text };
            SqlParameter paramCmbendusertpe = new SqlParameter("@C9", SqlDbType.NVarChar) { Value = cmbendusertype.SelectedItem };
            SqlParameter paramcompanybills = new SqlParameter("@C10", SqlDbType.NVarChar) { Value = cmbbillscompany.SelectedValue };

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar) { Value = EmployeeID };
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar) { Value = lblusername.Text };
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar) { Value = lbldatetime.Text };
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar) { Value = lblPC.Text };

            // Check for missing fields
            if ( (int)cmbservice.SelectedValue == 0 ||
                string.IsNullOrEmpty(txtaccountno.Text) || string.IsNullOrEmpty(txtsubscription.Text) || string.IsNullOrEmpty(txtmetersn.Text))
            {
                MessageBox.Show("Please Fill the missing fields  ");
                return;
            }

            // Open database connection
            SQLCONN.OpenConection();

            // Check if subscription number already exists
            SqlDataReader dr = SQLCONN.DataReader("select  AccountNo from ElectrcityBills  where AccountNo=  @C1  ", paramaccount);
            dr.Read();

            if (dr.HasRows==false)
            {
                MessageBox.Show("This 'AccountNo' " + txtaccount.Text + " Not Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Update data in ElectrcityBills table
            string query = string.Empty;
            SqlParameter[] parameters = null;

            if (cmbendusertype.SelectedItem.ToString() == "Company")
            {
                query = @"UPDATE [dbo].[ElectrcityBills]
SET [AccountNo] = @C1
   ,[SubscriptionNo] = @C2
   ,[MeterSN] = @C3
   ,[MeterLocationID] = @C4
   ,[Ownerid] = @C6
   ,[EnduserType] = @C9
   ,[EndUserID] = @C10
   ,[ServiceStatusD] = @C7
   ,[Notes] = @C8
WHERE [SubscriptionNo] = @C2";
                parameters = new SqlParameter[] { paramaccount, paramsubscrip, parammetersn, paramWorkloc, paramOwner, paramCmbendusertpe, paramcompanybills, paramService, paramNote };
            }
            else if (cmbendusertype.SelectedItem.ToString() == "Personal")
            {
                query = @"UPDATE [dbo].[ElectrcityBills]
SET [AccountNo] = @C1
   ,[SubscriptionNo] = @C2
   ,[MeterSN] = @C3
   ,[MeterLocationID] = @C4
   ,[Ownerid] = @C6
   ,[EnduserType] = @C9
   ,[EndUserID] = @C5
   ,[ServiceStatusD] = @C7
   ,[Notes] = @C8
WHERE [SubscriptionNo] = @C2";
                parameters = new SqlParameter[] { paramaccount, paramsubscrip, parammetersn, paramWorkloc, paramOwner, paramCmbendusertpe, paramHeadofDept, paramService, paramNote };
            }

            SQLCONN.ExecuteQueries(query, parameters);

            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('ElectrcityBills',@C2,'#','#',@datetime,@pc,@user,'Update')",
     paramsubscrip, paramdatetimeLOG, parampc, paramuser);

            // Show success message
            MessageBox.Show("Record updated Successfully");

            // Refresh data grid view
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [AccountNo]
  ,[SubscriptionNo]
  ,[MeterSN]
  ,[MeterLocationID]
  ,[Ownerid]
  ,[EnduserType]
  ,[EndUserID]
  ,[ServiceStatusD]
  ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills] WHERE SubscriptionNo = @C2 ", paramsubscrip);

            // Show button
            btn.Visible = true;

            // Close database connection
            SQLCONN.CloseConnection();



        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramsubscrip = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramsubscrip.Value = txtsubscription.Text;

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
            SqlDataReader dr = SQLCONN.DataReader("select SubscriptionNo from ElectrcityBills  where  SubscriptionNo = @C2 ", paramsubscrip);
            dr.Read();

            if (!dr.HasRows)
            {
                MessageBox.Show("This 'AccountNo' " + txtsubscription.Text + " Not Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dr.Dispose();
                dr.Close();
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                  
                    SQLCONN.ExecuteQueries("delete  ElectrcityBills where SubscriptionNo=@C2", paramsubscrip);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue, LogValueID, Oldvalue, newvalue, logdatetime, PCNAME, UserId, type) VALUES ('ElectrcityBills', @C2, '#', '#', @datetime, @pc, @user, 'Delete')", paramsubscrip, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [AccountNo]
    ,[SubscriptionNo]
    ,[MeterSN]
    ,[MeterLocationID]
    ,[Ownerid]
    ,[EnduserType]
    ,[EndUserID]
    ,[ServiceStatusD]
    ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills] WHERE SubscriptionNo = @C2 ", paramsubscrip);

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
            paramenduser.Value = cmbemployee2.SelectedValue;

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

            if ((int)cmbemployee2.SelectedValue == 0 || (int)cmbservice2.SelectedValue == 0 || txtaccount.Text == "" || txtserviceNo.Text == "" || (int)cmbpackage.SelectedValue == 0)
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
          ,[Employeeid]
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

                    txtaccountno.Text = txtsubscription.Text = txtNotes.Text = txtmetersn.Text = string.Empty;
                    cmbservice.Text = cmbemployee.Text = cmbpackage.Text /*cmbDepartment.Text*/ = cmbOwner.Text = cmbmeterlocation.Text = "Select";
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
                string query = @"SELECT  * 
  FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
  where   (AccountNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'
       OR ServiceNo LIKE '%' + REPLACE(@C0, ' ', '') + '%' ) ";

                //         string query = @"SELECT *  from [ElectrcityBills] WHERE AccountNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'
                //OR SubscriptionNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'";
                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);


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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            // Disable the service number text box and button 4
            txtserviceNo.Enabled = false;
            button4.Visible = false;

            // Get the selected row
            DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

            // Populate the text boxes and combo boxes with the selected row's data
            txtaccount.Text = selectedRow.Cells[0].Value.ToString();
            txtserviceNo.Text = selectedRow.Cells[1].Value.ToString();
            cmbemployee2.SelectedValue = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
            cmbRegisterType.SelectedItem = selectedRow.Cells[3].Value.ToString();
            cmbRegisterUnder.SelectedValue = Convert.ToInt32(selectedRow.Cells[4].Value.ToString());
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
                    MessageBox.Show("Invalid date format in cell 7.");
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
                // Enable the department combo box
                cmbempdepthistory.Enabled = true;

                // Load the departments based on the chosen company
                LoadDepartmentsByCompany(Convert.ToInt32(cmbRegisterUnder.SelectedValue));
            }
            else
            {
                // Disable the department combo box
                cmbempdepthistory.Enabled = false;
            }
        }

        private void LoadDepartmentsByCompany(int companyId)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1";

            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = companyId;

            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                cmbempdepthistory.ValueMember = "DEPTID";
                cmbempdepthistory.DisplayMember = "Dept_Type_Name";
                cmbempdepthistory.DataSource = dt;
                cmbempdepthistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbempdepthistory.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

            conn.Close();
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
            paramenduser.Value = cmbemployee2.SelectedValue;

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

            if ((int)cmbemployee2.SelectedValue == 0 || (int)cmbservice2.SelectedValue == 0 || txtaccount.Text == "" || txtserviceNo.Text == "" || (int)cmbpackage.SelectedValue == 0)
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {

                SQLCONN.OpenConection();

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.ExecuteQueries(@"update   [dbo].[CommunicationsBills] set
           [AccountNo] =@C1
          ,[ServiceNo]=@C2
          ,[Employeeid]=@C3
          ,[RegisterType]=@C4
          ,[RegisterUnder]=@C5
          ,[PackageID]=@C6
          ,[ServiceStatusID]=@C7
          ,[ExpireDate]=@C8
          ,[Notes]=@C9
            where ServiceNo=@C2", paramaccount, paramserviceNo, paramenduser, paramRegisterType, paramRegisterUnder, paramPackage, paramService, paramExpiredate, paramNotes);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('CommunicationsBills',@C2,'#','#',@datetime,@pc,@user,'Update')", paramserviceNo, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Record Updated Successfully");
                }

                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  *
  FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
  where  ServiceNo = @C2 ", paramserviceNo);
            }

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
                    cmbservice2.Text = cmbemployee2.Text = cmbRegisterUnder.Text = cmbempdepthistory.Text = cmbpackage.Text = "Select";
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
      where AccountNo = @C1 and [IssuedDate] = @C3 ", paramaccount, paramBillType, paramissuedate, paramdisconnectdate, paramBillAmount);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('BillsPaymentStatus',@C1,'#','#',@datetime,@pc,@user,'Update')", paramaccount, paramdatetimeLOG, parampc, paramuser);

                    MessageBox.Show("Record Updated Successfully");
                }

                dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  * from BillsPaymentStatus  where " +
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

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;

            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;

            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SqlDataReader dr;

            if (txtaccount3.Text == "" || txtBillAmount.Text == "")
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {
                SQLCONN.OpenConection();
                dr = SQLCONN.DataReader("select  IssuedDate,AccountNo from BillsPaymentStatus  where " +
                    " IssuedDate=  @C3 and AccountNo=@C1  ", paramissuedate, paramaccount);
                dr.Read();

                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Bill'  Already Exists.!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        dr.Dispose();
                        dr.Close();

                        SQLCONN.ExecuteQueries(@"INSERT INTO [dbo].[BillsPaymentStatus]
       ([AccountNo]
     ,[BillType]
     ,[IssuedDate]
     ,[DisconnectDate]
     ,[BillAmount])
     VALUES
          (@C1,@C2,@C3,@C4,@C5)", paramaccount, paramBillType, paramissuedate, paramdisconnectdate, paramBillAmount);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('BillsPaymentStatus',@C1,'#','#',@datetime,@pc,@user,'Insert')", paramaccount, paramdatetimeLOG, parampc, paramuser);

                        MessageBox.Show("Record saved Successfully");
                    }

                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  * from BillsPaymentStatus  where " +
                        " IssuedDate=  @C3 and AccountNo=@C1  ", paramissuedate, paramaccount);

                    button5.Visible = true;
                    SQLCONN.CloseConnection();
                }
            }
        }
        private void txtBillAmount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBillAmount_KeyPress(object sender, KeyPressEventArgs e)
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
                    cmbservice2.Text = cmbemployee2.Text = cmbpackage.Text = "Select";
                    Expiredtp.Value = DateTime.Now;

                    SQLCONN.CloseConnection();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button5.Visible = false;
            txtBillAmount.Text = "";
            cmbBillType.Text= "Select";

        }

        private void btn_Click(object sender, EventArgs e)
        {
            AddBtn.Visible = true;
         btnUpdate.Visible=DeleteBtn.Visible= btn.Visible = false;
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
            cmbemployee2.SelectedIndex = -1;
            cmbRegisterType.Text = "Select";
            cmbRegisterUnder.Text = "Select";
            cmbpackage.SelectedIndex = -1;
            cmbservice2.SelectedIndex = -1;

            // Reset the date
            Expiredtp.Value = DateTime.Now;

            // Disable the department combo box
            cmbempdepthistory.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlParameter paramPackageName= new SqlParameter("@C1", SqlDbType.NVarChar);
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

            if ((int)cmbMedia.SelectedValue == 0 || (int)cmbMedia.SelectedValue == 0 || (int)cmbMedia.SelectedValue == 0|| txtpName.Text==""||txtMonthCharge.Text=="")
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

            if (PackageID<=0)
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

            if (PackageID<=0)
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
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            // SqlConnection conn = new SqlConnection(@"Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbRegisterUnder.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbempdepthistory.ValueMember = "DEPTID";
                cmbempdepthistory.DisplayMember = "Dept_Type_Name";
                cmbempdepthistory.DataSource = dt;
                cmbempdepthistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbempdepthistory.AutoCompleteSource = AutoCompleteSource.ListItems;





            }

            conn.Close();
        }

        private void cmbRegisterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegisterType.SelectedItem.ToString() == "Personal")
            {
                cmbRegisterUnder.Enabled = cmbempdepthistory.Enabled = false;
                cmbemployee2.Enabled = true;
            }
            else 
            {
                cmbRegisterUnder.Enabled = cmbempdepthistory.Enabled = true;
                cmbemployee2.Enabled = true;

            }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {

                cmbendusertype.SelectedItem = "Select";
              
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {

                cmbemployee2.Enabled =cmbempdepthistory.Enabled =cmbRegisterUnder.Enabled= false;
                cmbReportType.Text = "Select";
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                textBox2.Focus();
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[5])
            {
                comboBox2.Text = "Select";

              

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


        private void btnuplode_Click(object sender, EventArgs e)
        {
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


        /*filiter*/
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



        /*filiter */

        private void button14_Click(object sender, EventArgs e)
        {
            // Get the date range filter
            DateTime? fromDate = dtpfromreport.Checked ? dtpfromreport.Value : (DateTime?)null;
            DateTime? toDate = dtptoreport.Checked ? dtptoreport.Value : (DateTime?)null;

            // Get the selected bill type
            string billType = cmbBillType1.SelectedItem != null ? cmbBillType1.SelectedItem.ToString() : string.Empty;

            // Get the account number
            string accountNumber = txtAccountNumbe.Text.Trim();

            // Get the filtered data
            DataTable dt = GetFilteredData(fromDate, toDate, billType, accountNumber);

            // Check if the dt DataTable is not empty
            if (dt.Rows.Count > 0)
            {
                // Generate the report
                GenerateReport(dt);
            }
            else
            {
                MessageBox.Show("No data found.");
                dataGridView5.DataSource = null;
            }
        }
        private void GenerateReport(DataTable dt)
        {
            // Bind the data to the DataGridView5
            dataGridView5.DataSource = dt;
        }


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
            if (cmbendusertype.Text == "Company")
            {
                cmbemployee.Enabled = false;
                cmbbillscompany.Enabled = true;
            }
            if (cmbendusertype.Text == "Personal")
            {
                cmbemployee.Enabled = true;
                cmbbillscompany.Enabled = false;
            }
        }

        private void txtaccountno_TextChanged(object sender, EventArgs e)
        {
            txtsubscription.Text = txtaccountno.Text;

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

        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Select")
            {
                MessageBox.Show("Please select the type of report ! ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                ShowCrystalReport1();

            }
           
        }

        private void ShowCrystalReport1()
        {
            string query = "";
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            // Determine the base query
            if (cmbDvision.Text == "Select")
            {
                query = @"
            SELECT 
                bps.AccountNo,
                cb.ServiceNo,
                e.FirstName + ' ' + e.LastName AS EndUser,
                bps.IssuedDate,
                bps.DisconnectDate,
                bps.BillAmount,
                dt.Dept_Type_Name AS Division,
                hod.FirstName + ' ' + hod.LastName AS HeadOFDepartment,
				c.COMPName_EN
                FROM 
                BillsPaymentStatus bps
                INNER JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo
                INNER JOIN Employees e ON cb.Employeeid = e.EmployeeID
                INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID 
                INNER JOIN DeptTypes dt ON dt.Dept_Type_ID = d.DeptName
                INNER JOIN Employees hod ON d.DeptHeadID = hod.EmployeeID
				INNER JOIN Companies c ON d.COMPID = c.COMPID
            WHERE
                (c.COMPID=@param3) AND
                (bps.BillType = @param0) AND
                CONVERT(DATE, bps.DisconnectDate) >= @param1 AND
                CONVERT(DATE, bps.DisconnectDate) <= @param2";
            }
            else
            {
                query = @"
            SELECT 
                bps.AccountNo,
                cb.ServiceNo,
                e.FirstName + ' ' + e.LastName AS EndUser,
                bps.IssuedDate,
                bps.DisconnectDate,
                bps.BillAmount,
                dt.Dept_Type_Name AS Division,
                hod.FirstName + ' ' + hod.LastName AS HeadOFDepartment,
				c.COMPName_EN
                FROM 
                BillsPaymentStatus bps
                INNER JOIN CommunicationsBills cb ON bps.AccountNo = cb.AccountNo
                INNER JOIN Employees e ON cb.Employeeid = e.EmployeeID
                INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID 
                INNER JOIN DeptTypes dt ON dt.Dept_Type_ID = d.DeptName
                INNER JOIN Employees hod ON d.DeptHeadID = hod.EmployeeID
				INNER JOIN Companies c ON d.COMPID = c.COMPID

            WHERE 
                (c.COMPID=@param3) AND
                (dt.Dept_Type_Name = @param) AND
                (bps.BillType = @param0) AND
                CONVERT(DATE, bps.DisconnectDate) >= @param1 AND
                CONVERT(DATE, bps.DisconnectDate) <= @param2";
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

            // Continue with the rest of your code
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(SQLCONN.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@param", cmbDvision.Text);
                cmd.Parameters.AddWithValue("@param0", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@param1", startDate);
                cmd.Parameters.AddWithValue("@param2", endDate);
                cmd.Parameters.AddWithValue("@param3", cmbCompany.SelectedValue);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }

            // Set up the report
            ReportDocument report = new ReportDocument();
            string reportName = "Delmon_Managment_System.Reports.BillsReport.rpt";
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

            report.SetDataSource(dataTable);



            report.SetParameterValue("param", cmbDvision.Text);
            report.SetParameterValue("param0", comboBox2.SelectedItem);
            report.SetParameterValue("param1", startDate);
            report.SetParameterValue("param2", endDate);
            report.SetParameterValue("param3", cmbCompany.SelectedValue);

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //ShowCrystalReport1();
        }

        private void cmbCompany_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");
            // SqlConnection conn = new SqlConnection(@"Data Source=AMIN-PC;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT [DEPTID],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and COMPID=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbCompany.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbDvision.ValueMember = "DEPTID";
                cmbDvision.DisplayMember = "Dept_Type_Name";
                cmbDvision.DataSource = dt;
                cmbDvision.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbDvision.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbDvision.Text="Select";





            }

            conn.Close();
        }
    }
}
