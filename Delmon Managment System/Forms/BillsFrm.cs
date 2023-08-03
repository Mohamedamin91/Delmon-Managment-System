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
    public partial class BillsFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int EmployeeID;
        int LoggedEmployeeID;

        public BillsFrm()
        {
            InitializeComponent();

        }

        private void BillsFrm_Load(object sender, EventArgs e)
        {
            button5.Visible = true;
            button1.Visible = true;
            btn.Visible = true;

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
            cmbemployee.ValueMember = "EmployeeID";
            cmbemployee.DisplayMember = "FullName";
            cmbemployee.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            cmbemployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbemployee2.ValueMember = "EmployeeID";
            cmbemployee2.DisplayMember = "FullName";
            cmbemployee2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            cmbemployee2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee2.AutoCompleteSource = AutoCompleteSource.ListItems;



            string query = "SELECT COMPID,COMPName_EN FROM Companies";
            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
            cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;


            



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

            



             cmbservice.Text = "Select";
             cmbservice2.Text = "Select";



            SQLCONN.CloseConnection();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cmbCompany_SelectionChangeCommitted(object sender, EventArgs e)
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

                cmbDepartment.ValueMember = "DEPTID";
                cmbDepartment.DisplayMember = "Dept_Type_Name";
                cmbDepartment.DataSource = dt;
                cmbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;

            }

            conn.Close();
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
            cmd.Parameters["@C1"].Value = cmbDepartment.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbworkfield.ValueMember = "WorkID";
                cmbworkfield.DisplayMember = "Name";
                cmbworkfield.DataSource = dt;
                cmbworkfield.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbworkfield.AutoCompleteSource = AutoCompleteSource.ListItems;

            }

            conn.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter( "@C1", SqlDbType.NVarChar);
            paramaccount.Value =  txtaccountno.Text;
            SqlParameter paramsubscrip = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramsubscrip.Value = txtsubscription.Text;
            SqlParameter parammetersn = new SqlParameter("@C3", SqlDbType.NVarChar);
            parammetersn.Value = txtmetersn.Text;
            SqlParameter paramDepart = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramDepart.Value = cmbDepartment.SelectedValue;
            SqlParameter paramWorkloc = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramWorkloc.Value = cmbworkfield.SelectedValue;
            SqlParameter paramHeadofDept = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramHeadofDept.Value = cmbemployee.SelectedValue;
            SqlParameter paramOwner = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramOwner.Value = cmbCompany.SelectedValue;
            SqlParameter paramService = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramService.Value = cmbservice.SelectedValue;
            SqlParameter paramNote = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramNote.Value = RemarksTxt.Text;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            SqlDataReader dr;
            if ((int)cmbemployee.SelectedValue == 0 || (int)cmbservice.SelectedValue == 0 || txtaccountno.Text == "" || txtsubscription.Text == "" || txtmetersn.Text == "")
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else 
            {

                SQLCONN.OpenConection();
                dr = SQLCONN.DataReader("select  SubscriptionNo from ElectrcityBills  where " +
                    " SubscriptionNo=  @C2 ", paramsubscrip);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'SubscriptionNo'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                       
                        
                            dr.Dispose();
                            dr.Close();

                            SQLCONN.ExecuteQueries(@"INSERT INTO [dbo].[ElectrcityBills]
           ([AccountNo]
           ,[SubscriptionNo]
           ,[MeterSN]
           ,[DEPTID]
           ,[workID]
           ,[HeadOfDept]
           ,[OwnerId]
           ,[ServiceID]
           ,[Notes])
     VALUES
           (@C1,@C2,@C3,@C4,@C5,@C6 ,@C7,@C8,@C9)", paramaccount, paramsubscrip, parammetersn, paramDepart, paramWorkloc,paramHeadofDept,paramOwner,paramService,paramNote);

                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('ElectrcityBills',@C2 ,'#','#',@datetime,@pc,@user,'Insert')", paramsubscrip, paramdatetimeLOG, parampc, paramuser);
                           
                          //   btnnew.Visible = true;

                       
                            MessageBox.Show("Record saved Successfully");
                        }

                        //cmbusertype.Text = cmbemployee.Text = "Select";
                        //usernametxt.Text = passwordtxt.Text = "";
                        //isactivecheck.Checked = false;

                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [AccountNo]
      ,[SubscriptionNo]
      ,[MeterSN]
      ,Dept_Type_Name
      ,WorkLocations.Name
      ,[HeadOfDept]
      ,[OwnerId]
      ,[ServiceID]
      ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills],DEPARTMENTS,WorkLocations,DeptTypes
  where DEPARTMENTS.DEPTID=ElectrcityBills.DEPTID
  and WorkLocations.WorkID=ElectrcityBills.workID
  and DeptTypes.Dept_Type_ID=DEPARTMENTS.DeptName and SubscriptionNo = @C2 ", paramsubscrip);
              }


            }
            btn.Visible = true;
            SQLCONN.CloseConnection();
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
      ,Dept_Type_Name
      ,WorkLocations.Name
      ,[HeadOfDept]
      ,[OwnerId]
      ,[ServiceID]
      ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills],DEPARTMENTS,WorkLocations,DeptTypes
  where DEPARTMENTS.DEPTID=ElectrcityBills.DEPTID
  and WorkLocations.WorkID=ElectrcityBills.workID
  and DeptTypes.Dept_Type_ID=DEPARTMENTS.DeptName 
  and (AccountNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'
       OR SubscriptionNo LIKE '%' + REPLACE(@C0, ' ', '') + '%' ) ";

       //         string query = @"SELECT *  from [ElectrcityBills] WHERE AccountNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'
       //OR SubscriptionNo LIKE '%' + REPLACE(@C0, ' ', '') + '%'";
                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);


            }
            else
            {

                string query = "";

                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramSearch);
            }

            btn.Visible = true;

            SQLCONN.CloseConnection();
            //firstnametxt.Text = secondnametxt.Text = thirdnametxt.Text = lastnametxt.Text = "";
            //cmbMartialStatus.Text = cmbGender.Text = "";
            //ClearAllControls();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsubscription.Enabled = false;
                AddBtn.Visible = false;
            //    btnnew.Visible = updatebtn.Visible = deletebtn.Visible = true;
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

                        //EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtaccountno.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtsubscription.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtmetersn.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbDepartment.Text =  (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                        cmbworkfield.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                        cmbemployee.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        cmbCompany.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                        cmbservice.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                        RemarksTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            

            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccountno.Text;
            SqlParameter paramsubscrip = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramsubscrip.Value = txtsubscription.Text;
            SqlParameter parammetersn = new SqlParameter("@C3", SqlDbType.NVarChar);
            parammetersn.Value = txtmetersn.Text;
            SqlParameter paramDepart = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramDepart.Value = cmbDepartment.SelectedValue;
            SqlParameter paramWorkloc = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramWorkloc.Value = cmbworkfield.SelectedValue;
            SqlParameter paramHeadofDept = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramHeadofDept.Value = cmbemployee.SelectedValue;
            SqlParameter paramOwner = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramOwner.Value = cmbCompany.SelectedValue;
            SqlParameter paramService = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramService.Value = cmbservice.SelectedValue;
            SqlParameter paramNote = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramNote.Value = RemarksTxt.Text;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if ((int)cmbemployee.SelectedValue == 0 && (int)cmbservice.SelectedValue == 0 && txtaccountno.Text == "" && txtaccountno.Text == "" && txtmetersn.Text == "")
            {
                MessageBox.Show("Please Fill the missing fields  ");
            }
            else
            {

                   SQLCONN.OpenConection();

                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                    if ((int)cmbDepartment.SelectedIndex == -1 || (int)cmbworkfield.SelectedIndex == -1)

                    {

                        SQLCONN.ExecuteQueries(@"update   [dbo].[ElectrcityBills] set
           [AccountNo] =@C1
           ,[SubscriptionNo]=@C2
           ,[MeterSN]=@C3
           ,[HeadOfDept]=@C6
           ,[OwnerId]=@C7
           ,[ServiceID]=@C8
           ,[Notes]=@C9 where SubscriptionNo=  @C2  ", paramaccount, paramsubscrip, parammetersn, paramHeadofDept, paramOwner, paramService, paramNote);



                    }
                    else 
                    {

                        SQLCONN.ExecuteQueries(@"update   [dbo].[ElectrcityBills] set
           [AccountNo] =@C1
           ,[SubscriptionNo] =@C2
           ,[MeterSN]=@C3
           ,[DEPTID]=@C4
           ,[workID]=@C5
           ,[HeadOfDept]=@C6
           ,[OwnerId]=@C7
           ,[ServiceID]=@C8
           ,[Notes]=@C9 where SubscriptionNo=  @C2  ", paramaccount, paramsubscrip, parammetersn, paramDepart, paramWorkloc, paramHeadofDept, paramOwner, paramService, paramNote);



                    }



                    //   SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('ElectrcityBills',@C2 ,'#','#',@datetime,@pc,@user,'Insert')", paramsubscrip, paramdatetimeLOG, parampc, paramuser);

                    //   btnnew.Visible = true;


                    MessageBox.Show("Record saved Successfully");
                    }

                    //cmbusertype.Text = cmbemployee.Text = "Select";
                    //usernametxt.Text = passwordtxt.Text = "";
                    //isactivecheck.Checked = false;

                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [AccountNo]
      ,[SubscriptionNo]
      ,[MeterSN]
      ,Dept_Type_Name
      ,WorkLocations.Name
      ,[HeadOfDept]
      ,[OwnerId]
      ,[ServiceID]
      ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills],DEPARTMENTS,WorkLocations,DeptTypes
  where DEPARTMENTS.DEPTID=ElectrcityBills.DEPTID
  and WorkLocations.WorkID=ElectrcityBills.workID
  and DeptTypes.Dept_Type_ID=DEPARTMENTS.DeptName and SubscriptionNo = @C2 ", paramsubscrip);
              
            }
          
            SQLCONN.CloseConnection();

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramsubscrip = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramsubscrip.Value = txtsubscription.Text;

            if (txtsubscription.Text == string.Empty)
            {
                MessageBox.Show("Please select Record first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  ElectrcityBills where SubscriptionNo=@C2", paramsubscrip);
                   // SQLCONN.ExecuteQueries(" declare @max int select @max = max([UserID]) from [tblUser] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[tblUser]', RESEED, @max)");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramPID, paramdatetimeLOG, parampc, paramuser);

                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [AccountNo]
      ,[SubscriptionNo]
      ,[MeterSN]
      ,Dept_Type_Name
      ,WorkLocations.Name
      ,[HeadOfDept]
      ,[OwnerId]
      ,[ServiceID]
      ,[Notes]
  FROM [DelmonGroupDB].[dbo].[ElectrcityBills],DEPARTMENTS,WorkLocations,DeptTypes
  where DEPARTMENTS.DEPTID=ElectrcityBills.DEPTID
  and WorkLocations.WorkID=ElectrcityBills.workID
  and DeptTypes.Dept_Type_ID=DEPARTMENTS.DeptName and SubscriptionNo = @C2 ", paramsubscrip);



                    SQLCONN.CloseConnection();



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
            SqlParameter paramPackage = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramPackage.Value = cmbpackage.SelectedValue;
            SqlParameter paramService = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramService.Value = cmbservice.SelectedValue;
            SqlParameter paramExpiredate = new SqlParameter("@C6", SqlDbType.Date);
            paramExpiredate.Value = Expiredtp.Value;
            SqlParameter paramNotes = new SqlParameter("@C7", SqlDbType.NVarChar);
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
                dr = SQLCONN.DataReader("select  ServiceNo from CommunicationsBills  where " +
                    " ServiceNo=  @C2 ", paramserviceNo);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'ServiceNo'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
           ,[PackageID]
           ,[ServiceStatusID] 
           ,[ExpireDate]
           ,[Notes])
     VALUES
           (@C1,@C2,@C3,@C4,@C5,@C6 ,@C7)", paramaccount, paramserviceNo, paramenduser, paramPackage, paramService, paramExpiredate , paramNotes);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('CommunicationsBills',@C2 ,'#','#',@datetime,@pc,@user,'Insert')", paramserviceNo, paramdatetimeLOG, parampc, paramuser);

                        //   btnnew.Visible = true;


                        MessageBox.Show("Record saved Successfully");
                    }

                    //cmbusertype.Text = cmbemployee.Text = "Select";
                    //usernametxt.Text = passwordtxt.Text = "";
                    //isactivecheck.Checked = false;

                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  *
  FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
  where  ServiceNo = @C2 ", paramserviceNo);

                    txtaccountno.Text = txtsubscription.Text = txtNotes.Text =txtmetersn.Text = string.Empty;
                    cmbservice.Text = cmbemployee.Text = cmbpackage.Text = cmbDepartment.Text= cmbCompany.Text=cmbworkfield.Text= "Select";
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
            txtserviceNo.Enabled = false;
                button4.Visible = false;
            //    btnnew.Visible = updatebtn.Visible = deletebtn.Visible = true;
            if (e.RowIndex == -1) return;

            foreach (DataGridViewRow rw in this.dataGridView2.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {

                        //EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtaccount.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtserviceNo.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cmbemployee2.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                        cmbpackage.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
                        cmbservice2.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
                        Expiredtp.Value = Convert.ToDateTime(dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());
                        txtNotes.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();

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
            SqlParameter paramPackage = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramPackage.Value = cmbpackage.SelectedValue;
            SqlParameter paramService = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramService.Value = cmbservice2.SelectedValue;
            SqlParameter paramExpiredate = new SqlParameter("@C6", SqlDbType.Date);
            paramExpiredate.Value = Expiredtp.Value;
            SqlParameter paramNotes = new SqlParameter("@C7", SqlDbType.NVarChar);
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
           ,[PackageID]=@C4
           ,[ServiceStatusID]=@C5
           ,[ExpireDate]=@C6
           ,[Notes]=@C7 where ServiceNo=  @C2  ", paramaccount, paramserviceNo, paramenduser, paramPackage, paramService, paramExpiredate, paramNotes);

                    //   SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('ElectrcityBills',@C2 ,'#','#',@datetime,@pc,@user,'Insert')", paramsubscrip, paramdatetimeLOG, parampc, paramuser);

                    //   btnnew.Visible = true;


                    MessageBox.Show("Record saved Successfully");
                }

                //cmbusertype.Text = cmbemployee.Text = "Select";
                //usernametxt.Text = passwordtxt.Text = "";
                //isactivecheck.Checked = false;

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

            if (txtserviceNo.Text == string.Empty)
            {
                MessageBox.Show("Please select Record first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  CommunicationsBills where ServiceNo=@C2", paramserviceNo);
                    // SQLCONN.ExecuteQueries(" declare @max int select @max = max([UserID]) from [tblUser] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[tblUser]', RESEED, @max)");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramPID, paramdatetimeLOG, parampc, paramuser);

                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  *
  FROM [DelmonGroupDB].[dbo].[CommunicationsBills]
  where  ServiceNo = @C2 ", paramserviceNo);

                    txtaccount.Text = txtserviceNo.Text = txtNotes.Text = string.Empty;
                    cmbservice2.Text = cmbemployee2.Text = cmbpackage.Text = "Select";
                    Expiredtp.Value = DateTime.Now;


                    SQLCONN.CloseConnection();



                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount3.Text;
            SqlParameter paramissuedate = new SqlParameter("@C2", SqlDbType.Date);
            paramissuedate.Value = dtpissue.Value;
            SqlParameter paramduedate = new SqlParameter("@C3", SqlDbType.Date);
            paramduedate.Value = dtpdue.Value;
            SqlParameter paramdisconnectdate = new SqlParameter("@C4", SqlDbType.Date);
            paramdisconnectdate.Value = dtpdisconnect.Value;
            SqlParameter paramfromdate = new SqlParameter("@C5", SqlDbType.Date);
            paramfromdate.Value = dtpfrom.Value;
            SqlParameter paramtomdate = new SqlParameter("@C6", SqlDbType.Date);
            paramtomdate.Value = dtpto.Value;

            SqlParameter paramBillAmount = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramBillAmount.Value = txtBillAmount.Text;
            SqlParameter paramCheckBOX = new SqlParameter("@C8", SqlDbType.Int);

            if (chbpaymentstatus.Checked == true)
            {
                paramCheckBOX.Value = 1;
            }
            else
            {
                paramCheckBOX.Value = 0;
            }

            SqlParameter paramNOTES = new SqlParameter("@C9", SqlDbType.Date);
            paramNOTES.Value = dtpto.Value;


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
      ,[IssuedDate] = @C2
      ,[DueDate]= @C3
      ,[DisconnectDate]= @C4
      ,[FromD]= @C5
      ,[ToD]= @C6
      ,[BillAmount]= @C7
      ,[Paymentstatus]= @C8
      ,[Notes]= @C9 where AccountNo=  @C1  ", paramaccount, paramissuedate, paramduedate, paramdisconnectdate, paramfromdate, paramtomdate, paramBillAmount, paramCheckBOX, paramNOTES);

                    //   SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('ElectrcityBills',@C2 ,'#','#',@datetime,@pc,@user,'Insert')", paramsubscrip, paramdatetimeLOG, parampc, paramuser);

                    //   btnnew.Visible = true;


                    MessageBox.Show("Record saved Successfully");
                }

                //cmbusertype.Text = cmbemployee.Text = "Select";
                //usernametxt.Text = passwordtxt.Text = "";
                //isactivecheck.Checked = false;

                dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  * from BillsPaymentStatus  where " +
                " IssuedDate=  @C2 and AccountNo=@C1  ", paramissuedate, paramaccount);




            }

            SQLCONN.CloseConnection();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount3.Text;
            SqlParameter paramissuedate = new SqlParameter("@C2", SqlDbType.Date);
            paramissuedate.Value = dtpissue.Value;
            SqlParameter paramduedate = new SqlParameter("@C3", SqlDbType.Date);
            paramduedate.Value = dtpdue.Value;
            SqlParameter paramdisconnectdate = new SqlParameter("@C4", SqlDbType.Date);
            paramdisconnectdate.Value = dtpdisconnect.Value;
            SqlParameter paramfromdate = new SqlParameter("@C5", SqlDbType.Date);
            paramfromdate.Value = dtpfrom.Value;
            SqlParameter paramtomdate = new SqlParameter("@C6", SqlDbType.Date);
            paramtomdate.Value = dtpto.Value;

            SqlParameter paramBillAmount = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramBillAmount.Value = txtBillAmount.Text;
            SqlParameter paramCheckBOX = new SqlParameter("@C8", SqlDbType.Int);

            if (chbpaymentstatus.Checked == true)
            {
                paramCheckBOX.Value = 1;
            }
            else
            {
                paramCheckBOX.Value = 0;
            }

            SqlParameter paramNOTES = new SqlParameter("@C9", SqlDbType.Date);
            paramNOTES.Value = dtpto.Value;


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
                    " IssuedDate=  @C2 and AccountNo=@C1  ", paramissuedate, paramaccount);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Bill'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {




                        dr.Dispose();
                        dr.Close();

                        SQLCONN.ExecuteQueries(@"INSERT INTO [dbo].[BillsPaymentStatus]
       ([AccountNo]
      ,[IssuedDate]
      ,[DueDate]
      ,[DisconnectDate]
      ,[FromD]
      ,[ToD]
      ,[BillAmount]
      ,[Paymentstatus]
      ,[Notes])
     VALUES
          (@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8,@C9)", paramaccount, paramissuedate, paramduedate, paramdisconnectdate, paramfromdate, paramtomdate, paramBillAmount, paramCheckBOX, paramNOTES);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('BillsPaymentStatus',@C1 ,'#','#',@datetime,@pc,@user,'Insert')", paramaccount, paramdatetimeLOG, parampc, paramuser);

                        //   btnnew.Visible = true;


                        MessageBox.Show("Record saved Successfully");
                    }

                    //cmbusertype.Text = cmbemployee.Text = "Select";
                    //usernametxt.Text = passwordtxt.Text = "";
                    //isactivecheck.Checked = false;

                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"select  * from BillsPaymentStatus  where " +
                    " IssuedDate=  @C2 and AccountNo=@C1  ", paramissuedate, paramaccount);

                    //    txtaccountno.Text = txtsubscription.Text = txtNotes.Text = txtmetersn.Text = string.Empty;
                    //    cmbservice.Text = cmbemployee.Text = cmbpackage.Text = cmbDepartment.Text = cmbCompany.Text = cmbworkfield.Text = "Select";
                    //}


                }
                button5.Visible = true;
                SQLCONN.CloseConnection();
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

            foreach (DataGridViewRow rw in this.dataGridView3.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {

                        //EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtaccount3.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                        dtpissue.Value = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString());
                        dtpdue.Value = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString());
                        dtpdisconnect.Value = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString());
                        dtpfrom.Value = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString());
                        dtpto.Value = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString());
                        txtBillAmount.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
                        if (Convert.ToInt32(dataGridView3.CurrentRow.Cells[7].Value) == 1)
                        {
                            chbpaymentstatus.Checked = true;

                        }
                        else 
                        {
                            chbpaymentstatus.Checked = false;

                        }
                        txtNotes.Text = dataGridView3.Rows[e.RowIndex].Cells[8].Value.ToString();

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

        private void button7_Click(object sender, EventArgs e)
        {
            SqlParameter paramaccount = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramaccount.Value = txtaccount3.Text;

            SqlParameter paramissuedate = new SqlParameter("@C2", SqlDbType.Date);
            paramissuedate.Value = dtpissue.Value;

            if (txtaccount3.Text == string.Empty)
            {
                MessageBox.Show("Please select Record first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  BillsPaymentStatus where AccountNo=@C1 and IssuedDate=@C2 ", paramaccount,paramissuedate);
                    // SQLCONN.ExecuteQueries(" declare @max int select @max = max([UserID]) from [tblUser] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[tblUser]', RESEED, @max)");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramPID, paramdatetimeLOG, parampc, paramuser);

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

        }

        private void btn_Click(object sender, EventArgs e)
        {
            AddBtn.Visible = true;
            btn.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            button1.Visible = false;

        }
    }
}
