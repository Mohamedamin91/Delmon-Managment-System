using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class SettingFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int EmployeeID;
        int LoggedEmployeeID;
        int agaencyid;
        int contactID;
        int jobid;
        int CompID;
        int DeptID;
        int countryID;
        int CounslateID;
        double num1, num2;
        int userpermissionID;

        bool hasViewcountr = false;
        bool hasEditcountr = false;
        bool hasDeletecountr = false;
        bool hasAddcountr = false;


        bool hasViewcompan = false;
        bool hasEditcompan = false;
        bool hasDeletecompan = false;
        bool hasAddcompan = false;


        bool hasViewAgenc = false;
        bool hasEditAgenc = false;
        bool hasDeleteAgenc = false;
        bool hasAddAgenc = false;

        bool hasViewJob = false;
        bool hasEditJob = false;
        bool hasDeleteJob = false;
        bool hasAddJob = false;

        bool hasViewUser = false;
        bool hasEditUser = false;
        bool hasDeleteUser = false;
        bool hasAddUser = false;


        bool hasViewEmployeelog = false;
        DataTable originalDataEmployee, originalDataGeneralManager,
            originalDataDepartment, originalDataHeadOFDepartment, originalDataWorkField, originalDataCountry;





        string encryptionKey = "0pqnU2X00mf+i8mDTzyPVw==", iv = "0pqnU2X00mf+i8mDTzyPVw==";


        static Regex validate_emailaddress = email_validation();



        public SettingFrm()
        {
            InitializeComponent();
            LoadComboBoxDataEmployee();
            LoadComboBoxDataGenralManager();
            LoadComboBoxDataDepartment();
            LoadComboBoxDataHeadofdepartment();
            LoadComboBoxDataworkfield();
            LoadComboBoxDataCountry();
            cmbemployee.TextChanged += new EventHandler(cmbemployee_TextChanged);
            cmbemployee2.TextChanged += new EventHandler(cmbemployee2_TextChanged);
            cmbDepartment.TextChanged += new EventHandler(cmbDepartment_TextChanged);
            cmbemployee1.TextChanged += new EventHandler(cmbemployee1_TextChanged);
            cmbworkfield.TextChanged += new EventHandler(cmbworkfield_TextChanged);
            cmbcont.TextChanged += new EventHandler(cmbcont_TextChanged);

            // Attach the CheckedChanged event handler to each radio button
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton_CheckedChanged;
            radioButton4.CheckedChanged += RadioButton_CheckedChanged;
            radioButton5.CheckedChanged += RadioButton_CheckedChanged;
            radioButton6.CheckedChanged += RadioButton_CheckedChanged;
            radioButton7.CheckedChanged += RadioButton_CheckedChanged;
            radioButton8.CheckedChanged += RadioButton_CheckedChanged;
            radioButton9.CheckedChanged += RadioButton_CheckedChanged;
            radioButton10.CheckedChanged += RadioButton_CheckedChanged;
            radioButton11.CheckedChanged += RadioButton_CheckedChanged;
            radioButton12.CheckedChanged += RadioButton_CheckedChanged;
            radioButton13.CheckedChanged += RadioButton_CheckedChanged;
            radioButton14.CheckedChanged += RadioButton_CheckedChanged;
            radioButton15.CheckedChanged += RadioButton_CheckedChanged;
            radioButton16.CheckedChanged += RadioButton_CheckedChanged;
            radioButton17.CheckedChanged += RadioButton_CheckedChanged;
            radioButton18.CheckedChanged += RadioButton_CheckedChanged;
            radioButton19.CheckedChanged += RadioButton_CheckedChanged;
            radioButton20.CheckedChanged += RadioButton_CheckedChanged;
            radioButton21.CheckedChanged += RadioButton_CheckedChanged;
            radioButton22.CheckedChanged += RadioButton_CheckedChanged;

            // Set Tag properties for all checkboxes
            ViewCountriesTabx.Tag = 39;
            AddCountriesTabx.Tag = 40;
            EditCountriesTabx.Tag = 41;
            DeleteCountriesTabx.Tag = 42;

            ViewCompaniesTabx.Tag = 35;
            AddCompaniesTabx.Tag = 36;
            EditCompaniesTabx.Tag = 37;
            DeleteCompaniesTabx.Tag = 38;

            ViewJobTabx.Tag = 27;
            AddJobTabx.Tag = 28;
            editJobTabx.Tag = 29;
            DeleteJobTabx.Tag = 30;

            ViewUserTabx.Tag = 23;
            AddUserTabx.Tag = 24;
            EditUserTabx.Tag = 25;
            DeleteUserTabx.Tag = 26;

            ViewAlertsbx.Tag = 19;
            AddAlertsbx.Tag = 20;
            EditAlertsbx.Tag = 21;
            DeleteAlertsBx.Tag = 22;

            ViewAssetsbx.Tag = 15;
            AddAssetsbx.Tag = 16;
            EditAssetsbx.Tag = 17;
            DeleteAssetsbx.Tag = 18;

            ViewBillsbx.Tag = 11;
            AddBillsbx.Tag = 12;
            EditBillsbx.Tag = 13;
            DeleteBillsbx.Tag = 14;

            ViewCandidatesReportbx.Tag = 10;
            ViewVisaReportbx.Tag = 9;
            ViewAssetReportbx.Tag = 43;

            ViewPersonalInformationbx.Tag = 5;
            AddPersonalInformationbx.Tag = 6;
            EditPersonalInformationbx.Tag = 7;
            DeletePersonalInformationbx.Tag = 8;

            ViewVisabx.Tag = 1;
            AddVisabx.Tag = 2;
            EditVisabx.Tag = 3;
            DeleteVisabx.Tag = 4;

            ViewAgenciesTabx.Tag = 31;
            AddAgenciesTabx.Tag = 32;
            EditAgenciesTabx.Tag = 33;
            DeleteAgenciesTabx.Tag = 34;

            ViewEmployeelogs.Tag = 44;




            // Add event handlers for all checkboxes
            ViewCountriesTabx.CheckedChanged += CheckBox_CheckedChanged;
            AddCountriesTabx.CheckedChanged += CheckBox_CheckedChanged;
            EditCountriesTabx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteCountriesTabx.CheckedChanged += CheckBox_CheckedChanged;
            ViewCompaniesTabx.CheckedChanged += CheckBox_CheckedChanged;
            AddCompaniesTabx.CheckedChanged += CheckBox_CheckedChanged;
            EditCompaniesTabx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteCompaniesTabx.CheckedChanged += CheckBox_CheckedChanged;
            ViewJobTabx.CheckedChanged += CheckBox_CheckedChanged;
            AddJobTabx.CheckedChanged += CheckBox_CheckedChanged;
            editJobTabx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteJobTabx.CheckedChanged += CheckBox_CheckedChanged;
            ViewUserTabx.CheckedChanged += CheckBox_CheckedChanged;
            AddUserTabx.CheckedChanged += CheckBox_CheckedChanged;
            EditUserTabx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteUserTabx.CheckedChanged += CheckBox_CheckedChanged;
            ViewAlertsbx.CheckedChanged += CheckBox_CheckedChanged;
            AddAlertsbx.CheckedChanged += CheckBox_CheckedChanged;
            EditAlertsbx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteAlertsBx.CheckedChanged += CheckBox_CheckedChanged;
            ViewAssetsbx.CheckedChanged += CheckBox_CheckedChanged;
            AddAssetsbx.CheckedChanged += CheckBox_CheckedChanged;
            EditAssetsbx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteAssetsbx.CheckedChanged += CheckBox_CheckedChanged;
            ViewBillsbx.CheckedChanged += CheckBox_CheckedChanged;
            AddBillsbx.CheckedChanged += CheckBox_CheckedChanged;
            EditBillsbx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteBillsbx.CheckedChanged += CheckBox_CheckedChanged;
            ViewCandidatesReportbx.CheckedChanged += CheckBox_CheckedChanged;
            ViewVisaReportbx.CheckedChanged += CheckBox_CheckedChanged;
            ViewAssetReportbx.CheckedChanged += CheckBox_CheckedChanged;
            ViewPersonalInformationbx.CheckedChanged += CheckBox_CheckedChanged;
            AddPersonalInformationbx.CheckedChanged += CheckBox_CheckedChanged;
            EditPersonalInformationbx.CheckedChanged += CheckBox_CheckedChanged;
            DeletePersonalInformationbx.CheckedChanged += CheckBox_CheckedChanged;
            ViewVisabx.CheckedChanged += CheckBox_CheckedChanged;
            AddVisabx.CheckedChanged += CheckBox_CheckedChanged;
            EditVisabx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteVisabx.CheckedChanged += CheckBox_CheckedChanged;
            ViewAgenciesTabx.CheckedChanged += CheckBox_CheckedChanged;
            AddAgenciesTabx.CheckedChanged += CheckBox_CheckedChanged;
            EditAgenciesTabx.CheckedChanged += CheckBox_CheckedChanged;
            DeleteAgenciesTabx.CheckedChanged += CheckBox_CheckedChanged;
            ViewEmployeelogs.CheckedChanged += CheckBox_CheckedChanged;


        }

        private void LoadComboBoxDataEmployee()
        {
           
        

            SQLCONN.OpenConection();

            originalDataEmployee = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            if (originalDataEmployee != null)
            {
                cmbemployee.DataSource = originalDataEmployee;
                cmbemployee.ValueMember = "EmployeeID";
                cmbemployee.DisplayMember = "FullName";
            }
            SQLCONN.CloseConnection();
        }

        private void LoadComboBoxDataGenralManager()
        {

            SQLCONN.OpenConection();

            originalDataGeneralManager = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            if (originalDataGeneralManager != null)
            {
                cmbemployee2.DataSource = originalDataGeneralManager;
                cmbemployee2.ValueMember = "EmployeeID";
                cmbemployee2.DisplayMember = "FullName";
            }
            SQLCONN.CloseConnection();
        }

        
         private void LoadComboBoxDataworkfield()
        {
       
              SQLCONN.OpenConection();
              originalDataWorkField = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT WorkID,Name FROM [WorkLocations]");
            if (originalDataWorkField != null)
            {
                cmbworkfield.DataSource = originalDataWorkField;
                cmbworkfield.ValueMember = "WorkID";
                cmbworkfield.DisplayMember = "Name";
            }

            SQLCONN.CloseConnection();
        }

        private void LoadComboBoxDataHeadofdepartment()
        {

            SQLCONN.OpenConection();

            originalDataHeadOFDepartment = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            if (originalDataHeadOFDepartment != null)
            {
                cmbemployee1.DataSource = originalDataHeadOFDepartment;
                cmbemployee1.ValueMember = "EmployeeID";
                cmbemployee1.DisplayMember = "FullName";
            }
            SQLCONN.CloseConnection();
        }

        private void LoadComboBoxDataCountry()
        {

        
            SQLCONN.OpenConection();

            originalDataCountry = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT CountryId,CountryName FROM Countries ");
            if (originalDataCountry != null)
            {
                cmbcont.DataSource = originalDataCountry;
                cmbcont.ValueMember = "CountryId";
                cmbcont.DisplayMember = "CountryName";
            }

            SQLCONN.CloseConnection();

        }


        private void LoadComboBoxDataDepartment()
        {
       SQLCONN.OpenConection();

            originalDataDepartment = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT Dept_Type_ID,Dept_Type_Name FROM [DeptTypes] ");
            if (originalDataDepartment != null)
            {
                cmbDepartment.DataSource = originalDataDepartment;
                cmbDepartment.ValueMember = "Dept_Type_ID";
                cmbDepartment.DisplayMember = "Dept_Type_Name";

            }
            SQLCONN.CloseConnection();
        }


        public static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }


        // Method to populate the ComboBox



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



        public void SettingFrm_Load(object sender, EventArgs e)
        {
            if (CommonClass.Usertype == "SuperAdmin")

            {
                cmbusertype.Enabled = true;
            }
            else
            {
                cmbusertype.Enabled = false;
                cmbusertype.SelectedValue = 2;
            }
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
                /*user*/
                if (permissionName.Contains("ViewUserTab"))
                {
                    hasViewUser = true;
                }
                if (permissionName.Contains("AddUserTab"))
                {
                    hasAddUser = true;
                }
                if (permissionName.Contains("EditUserTab"))
                {
                    hasEditUser = true;
                }
                if (permissionName.Contains("DeleteUserTab"))
                {
                    hasDeleteUser = true;
                }

            }
            dr.Close();

            if (hasViewUser == false)
            {
                dataGridView1.DataSource = null;


                MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                groupBox10.Enabled = false;


            }
            else
            {
                groupBox10.Enabled = true;


                if (hasAddUser)
                {
                    btnnew.Enabled = addbtn.Enabled = true;

                      dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
                     (" SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive from Employees,tblUserType ,tblUser  where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID    ");
                    dataGridView1.Columns["password"].Visible = false;


                }
                else
                {
                    btnnew.Enabled = addbtn.Enabled = false;

                }
                if (hasEditUser)
                {
                    updatebtn.Enabled = true;
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
                    (" SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive from Employees,tblUserType ,tblUser  where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID    ");

                }
                else
                {
                    updatebtn.Enabled = false;

                }
                if (hasDeleteUser)
                {
                    deletebtn.Enabled = true;
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
                    (

                        " SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive from Employees,tblUserType ,tblUser  " +
                        "where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID    "
                        );
                }
                else
                {
                    deletebtn.Enabled = false;

                }
            }



            SqlParameter paramloggedemployee = new SqlParameter("@LoggedEmployeeid", SqlDbType.NVarChar);
            paramloggedemployee.Value = LoggedEmployeeID;
            this.timer1.Interval = 1000;
            timer1.Start();
            LoadTheme();
            lblusername.Text = CommonClass.LoginUserName;
            lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
            LoggedEmployeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;

    

        
            cmbUserPermission.ValueMember = "EmployeeID";
            cmbUserPermission.DisplayMember = "FullName";
            cmbUserPermission.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT u.EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' 
from Employees e,tblUser u  
where u.EmployeeID= e.EmployeeID
order by EmployeeID  ");
            cmbUserPermission.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUserPermission.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbUserPermission.Text = "Select";


            cmbUserLog.ValueMember = "UserID";
            cmbUserLog.DisplayMember = "Username";
            cmbUserLog.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT tblUser.[UserID], tblUser.Username from tblUser  ");
            cmbUserLog.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbUserLog.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbUserLog.Text = "Select";




            cmbusertype.ValueMember = "UserTypeID";
            cmbusertype.DisplayMember = "UserType";
            cmbusertype.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT UserTypeID,UserType  from [tblUserType] order by UserTypeID desc ");
            cmbusertype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbusertype.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbusertype.Text = "Select";





            cmbcontact.ValueMember = "ContTypeID";
            cmbcontact.DisplayMember = "ContType";
            cmbcontact.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT ContTypeID ,ContType FROM ContactTypes ");
            cmbcontact.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbcontact.AutoCompleteSource = AutoCompleteSource.ListItems;




            cmbCountry.ValueMember = "CountryId";
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT CountryId,CountryName FROM Countries");
            cmbCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCountry.AutoCompleteSource = AutoCompleteSource.ListItems;


           

          

      
            dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox
              (" SELECT * from jobs   ");


            dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox

              (" SELECT * from  Agencies   ");



            SQLCONN.CloseConnection();


        }
        private void LoadTheme()
        {

        }

        private void Generatebtn_Click(object sender, EventArgs e)
        {
            int passwordLength = 10; // specify the length of the password
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()"; // specify the valid characters that can be used in the password
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            // generate the password
            for (int i = 0; i < passwordLength; i++)
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            // assign the password to the text box
            passwordtxt.Text = password.ToString();
        }

        private void employeetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void userTap_Click(object sender, EventArgs e)
        {


        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramemployee = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramemployee.Value = cmbemployee.SelectedValue;
            SqlParameter paramusername = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramusername.Value = usernametxt.Text;
            SqlParameter parampassword = new SqlParameter("@C3", SqlDbType.NVarChar);
            parampassword.Value = passwordtxt.Text;
            SqlParameter paramusertype = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramusertype.Value = cmbusertype.SelectedValue;
            SqlParameter paramisActive = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramisActive.Value = isactivecheck.Checked;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            SqlDataReader dr;

            // Generate a random encryption key and IV
            string originalValue = passwordtxt.Text.ToString();
            string encryptedValue = Encrypt(originalValue, encryptionKey, iv);
            parampassword.Value = encryptedValue;




            if ((int)cmbemployee.SelectedValue != 0 && usernametxt.Text != "" && passwordtxt.Text != "")
            {
                SQLCONN.OpenConection();
                dr = SQLCONN.DataReader("select  * from tblUser  where " +
                    " EmployeeID=  @C1 or username = @C2", paramemployee, paramusername);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'User'/ 'Username'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        dr.Dispose();
                        dr.Close();
                        if (isactivecheck.Checked)
                        {
                            dr.Dispose();
                            dr.Close();


                            if (lblusertype.Text == "Admin")

                            {
                                SQLCONN.ExecuteQueries("insert into tblUser ( [EmployeeID] ,[UserName],[Password],[UserTypeID],[IsActive]) values (@C1,@C2,@C3,@C4,1)",
                                                   paramemployee, paramusername, parampassword, paramusertype, paramisActive);
                            }
                            else
                            {
                                SQLCONN.ExecuteQueries("insert into tblUser ( [EmployeeID] ,[UserName],[Password],[UserTypeID],[IsActive]) values (@C1,@C2,@C3,2,1)",
                                               paramemployee, paramusername, parampassword, paramusertype, paramisActive);
                            }

                            MessageBox.Show("Record saved Successfully");

                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@C1 ,'#','#',@datetime,@pc,@user,'Insert')", paramemployee, paramdatetimeLOG, parampc, paramuser);
                            btnnew.Visible = true;

                        }
                        else
                        {
                            dr.Dispose();
                            dr.Close();


                            if (lblusertype.Text == "Admin")

                            {
                                SQLCONN.ExecuteQueries("insert into tblUser ( [EmployeeID] ,[UserName],[Password],[UserTypeID],[IsActive]) values (@C1,@C2,@C3,@C4,0)",


                               paramemployee, paramusername, parampassword, paramusertype, paramisActive);
                            }
                            else
                            {
                                SQLCONN.ExecuteQueries("insert into tblUser ( [EmployeeID] ,[UserName],[Password],[UserTypeID],[IsActive]) values (@C1,@C2,@C3,2,0)",


                                    paramemployee, paramusername, parampassword, paramusertype, paramisActive);
                            }

                            MessageBox.Show("Record saved Successfully");



                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@C1 ,'#','#',@datetime,@pc,@user,'Insert')", paramemployee, paramdatetimeLOG, parampc, paramuser);
                            btnnew.Visible = true;


                        }

                        cmbusertype.Text = cmbemployee.Text = "Select";
                        usernametxt.Text = passwordtxt.Text = "";
                        isactivecheck.Checked = false;

                        //   dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from tblUser where EmployeeID= @C1 order by EmployeeID ", paramemployee);
                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
                         (" SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive " +
                         "from Employees,tblUserType ,tblUser  where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID  and Employees.EmployeeID= @C1    ", paramemployee);


                        dr.Dispose();
                        dr.Close();



                    }
                    else
                    {

                    }
                }



            }
            else
            {
                MessageBox.Show("Please Fill the missing fields  ");

            }
            SQLCONN.CloseConnection();
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

                        EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        CommonClass.UserPermissionID = EmployeeID;
                        cmbemployee.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbusertype.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        usernametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        passwordtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        string encryptedValue = passwordtxt.Text;
                        // Decrypt the value using the stored key and IV
                        string decryptedValue = Decrypt(encryptedValue, encryptionKey, iv);

                        passwordtxt.Text = decryptedValue;

                        // Check if the clicked cell is in the IsActive column

                        // Get the value of the cell
                        int cellValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IsActive"].Value);

                        // Check or uncheck the IsActive checkbox based on the cell value
                        if (cellValue == 1)
                        {
                            isactivecheck.Checked = true;
                        }
                        else
                        {
                            isactivecheck.Checked = false;
                        }



                        // Check if the value in the first column is 'OS_Key'


                    }









                    EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    ////CurrentEmployeeIDtxt.Text = EmployeeID.ToString();
                    ////addbtn.Visible = false;
                    //btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
                    //firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
                    //cmbMartialStatus.Enabled = cmbGender.Enabled = cmbCompany.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = true;
                    //StartDatePicker.Enabled = true;

                }
            }

        }


        private void updatebtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramemployee = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramemployee.Value = cmbemployee.SelectedValue;
            SqlParameter paramusername = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramusername.Value = usernametxt.Text;
            SqlParameter parampassword = new SqlParameter("@C3", SqlDbType.NVarChar);
            parampassword.Value = passwordtxt.Text;


            SqlParameter paramusertype = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramusertype.Value = cmbusertype.SelectedValue;
            SqlParameter paramisActive = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramisActive.Value = isactivecheck.Checked;
            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            // Generate a random encryption key and IV
            string originalValue1 = passwordtxt.Text.ToString();
            string encryptedValue = Encrypt(originalValue1, encryptionKey, iv);
            parampassword.Value = encryptedValue;




            if (EmployeeID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    if (cmbemployee.Text == "Select")

                    {
                        MessageBox.Show("Please Select a Job !!");


                    }
                    else if (cmbemployee.Text == "Select")
                    {
                        MessageBox.Show("Please Select User Type !!");
                    }
                    else if (usernametxt.Text == "")

                    {
                        MessageBox.Show("Please insert username !!");


                    }
                    else if (passwordtxt.Text == "")

                    {
                        MessageBox.Show("Please insert a password !!");


                    }
                    else
                    {
                        SQLCONN.OpenConection();

                        // MessageBox.Show(EMPID.ToString());

                        /**logtable */
                        DataTable originalData = new DataTable();
                        string connectionString = SQLCONN.ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM tblUser WHERE userid = @EmployeeId";
                            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                            da.SelectCommand.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                            originalData = new DataTable();
                            da.Fill(originalData);
                        }


                        //   paramEmployeeID.Value = CurrentEmployeeIDtxt.Text;


                        if (isactivecheck.Checked)
                        {

                            SQLCONN.ExecuteQueries("update tblUser set employeeid =@C1,username=@C2,password=@C3,usertypeid=@C4,isActive=1 where  userid=@id  ", paramPID, paramemployee, paramusername, parampassword, paramusertype);

                        }

                        else
                        {
                            SQLCONN.ExecuteQueries("update tblUser set employeeid =@C1,username=@C2,password=@C3,usertypeid=@C4,isActive=0 where  userid=@id  ", paramPID, paramemployee, paramusername, parampassword, paramusertype);

                        }







                        MessageBox.Show("Record Updated Successfully");
                         dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
               (" SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive " +
               "from Employees,tblUserType ,tblUser  where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID  and tblUser.userid=@id   ", paramPID);



                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM tblUser WHERE userid = @EmployeeId";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                            adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                            DataTable updatedData = new DataTable();
                            adapter.Fill(updatedData);

                            // Compare the two DataTables and find the changed columns
                            List<string> changedColumns = new List<string>();
                            foreach (DataColumn column in originalData.Columns)
                            {
                                object originalValue = originalData.Rows[0][column.ColumnName];
                                object updatedValue = updatedData.Rows[0][column.ColumnName];
                                if (!Equals(originalValue, updatedValue) && (originalValue != null || updatedData != null))
                                {
                                    changedColumns.Add(column.ColumnName);
                                }
                            }

                            // Insert the changes into the log table
                            if (changedColumns.Count > 0)
                            {
                                using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeId, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                                {
                                    command.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                                    foreach (string columnName in changedColumns)
                                    {
                                        object originalValue = originalData.Rows[0][columnName];
                                        object updatedValue = updatedData.Rows[0][columnName];
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@EmployeeId", EmployeeID + " - " + "User");
                                        command.Parameters.AddWithValue("@ColumnName", columnName);
                                        command.Parameters.AddWithValue("@OldValue", originalValue);
                                        command.Parameters.AddWithValue("@NewValue", updatedValue);
                                        command.Parameters.AddWithValue("@datetime", lbldatetime.Text);
                                        command.Parameters.AddWithValue("@pc", lblPC.Text);
                                        command.Parameters.AddWithValue("@user", lblusername.Text);
                                        command.Parameters.AddWithValue("@type", "Update");
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }



                        /**logtable*/









                        tabControl1.Enabled = true;
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

        private void deletebtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramemployee = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramemployee.Value = cmbemployee.SelectedValue;

            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EmployeeID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if (EmployeeID == 0)
            {
                MessageBox.Show("Please select visa Employee first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  tblUser where userid=@id", paramPID);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([UserID]) from [tblUser] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[tblUser]', RESEED, @max)");
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
                                      (" SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive " +
                                      "from Employees,tblUserType ,tblUser  where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID  and Employees.EmployeeID= @C1    ", paramemployee);
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramPID, paramdatetimeLOG, parampc, paramuser);
                    SQLCONN.CloseConnection();



                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbldatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;
            SqlParameter paramAgencyid = new SqlParameter("@id", SqlDbType.NVarChar);
            paramAgencyid.Value = agaencyid;

            if (agaencyid == 0)
            {
                MessageBox.Show("Please select Agency first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  Agencies where AgencID=@id", paramAgencyid);
                    SQLCONN.ExecuteQueries("delete  Contacts where CR_ID=@id and RefrenceID=3 ", paramAgencyid);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([AgencID]) from [Agencies] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[Agencies]', RESEED, @max)");
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max(Contact_ID) from[Contacts] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[Contacts]', RESEED, @max)");
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Agencies ");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Agency + Contact Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramAgencyid, paramdatetimeLOG, parampc, paramuser);
                    SQLCONN.CloseConnection();



                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter paramagencyname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramagencyname.Value = AgencyNametxt.Text;
            SqlParameter paramlicensenumber = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramlicensenumber.Value = LicenseNumbertxt.Text;
            SqlParameter paramcountry = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramcountry.Value = cmbCountry.SelectedValue;
            SqlParameter paramcity = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramcity.Value = cmbCity.SelectedValue;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SqlParameter paramAgencyid = new SqlParameter("@id", SqlDbType.NVarChar);

            SqlParameter paramContactType = new SqlParameter("@C5", SqlDbType.Int);
            paramContactType.Value = cmbcontact.SelectedValue;
            SqlParameter paramContact = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramContact.Value = Contacttxt.Text;
            SqlParameter paramRefrenceID = new SqlParameter("@C7", SqlDbType.Int);
            paramRefrenceID.Value = 3;
            SQLCONN.OpenConection();
      
            
            /*adding contact info */
            
            if (checkContact.Checked == true)
            {

                if (AgencyNametxt.Text != "" && AgencyNametxt.Text != "" && LicenseNumbertxt.Text != "" && Contacttxt.Text != "")
                {
                    SQLCONN.OpenConection();
                    SqlDataReader dr = SQLCONN.DataReader("select  * from Agencies  where " +
                         " AgenceName=  @C1 and    LicenseNumber =  @C2 ", paramagencyname, paramlicensenumber);
                    dr.Read();


                    if (dr.HasRows)
                    {
                        MessageBox.Show("This 'Agency'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    dr.Dispose();
                    SqlDataReader dr3 = SQLCONN.DataReader("select  ContValue from Contacts where  ContValue= @C6  ", paramContact);
                    dr3.Read();
                    if (dr3.HasRows)
                    {
                        MessageBox.Show("This 'Contact Value'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    if ((int)cmbcontact.SelectedValue == 2)
                    {
                        if (validate_emailaddress.IsMatch(Contacttxt.Text) != true)
                        {
                            MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Contacttxt.Focus();
                            return;
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {


                            dr.Dispose();
                            dr.Close();
                            dr3.Dispose();
                            dr3.Close();

                            SQLCONN.ExecuteQueries("insert into Agencies (  [AgenceName] ,[LicenseNumber],[CountryID],[CityID]) values (@C1,@C2,@C3,@C4)",
                                                           paramagencyname, paramlicensenumber, paramcountry, paramcity);

                            SqlDataReader dr2 = SQLCONN.DataReader("Select max (AgencID) 'ID' from Agencies ");
                            if (dr2.Read())
                            {
                                agaencyid = int.Parse(dr2["ID"].ToString());
                                paramAgencyid.Value = agaencyid;
                            }




                            else { paramAgencyid.Value = 0; }
                            dr2.Close();
                            dr.Dispose();
                            SQLCONN.ExecuteQueries("insert into Contacts ( ContTypeID,ContValue,RefrenceID,CR_ID) values (@C5,@C6,@C7,@id)",
                                                     paramContactType, paramContact, paramRefrenceID, paramAgencyid);


                            MessageBox.Show("Record saved Successfully");
                            BtnnewAgaency.Visible = true;

                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Agency Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramAgencyid, paramdatetimeLOG, parampc, paramuser);
                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Contact Agency Info , @id ,'#','#',@datetime,@pc,@user,'Insert')", paramContactType, paramAgencyid, paramdatetimeLOG, parampc, paramuser);


                            dr2.Dispose();
                            dr2.Close();
                            dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Agencies where AgencID= @id order by AgencID ", paramAgencyid);
                            dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + agaencyid + " ");


                            AgencyNametxt.Text = LicenseNumbertxt.Text = "";
                            cmbCountry.SelectedValue = cmbCity.SelectedValue = 0;



                        }
                        else
                        {
                            dr.Dispose();
                            dr.Close();
                            dr3.Dispose();
                            dr3.Close();

                        }
                    }

                }


                else
                {
                    MessageBox.Show("Please Fill the missing fields  ");

                }
            }
            else
            {

                if (AgencyNametxt.Text != "" && AgencyNametxt.Text != "" && LicenseNumbertxt.Text != "")
                {
                    SQLCONN.OpenConection();
                    SqlDataReader dr = SQLCONN.DataReader("select  * from Agencies  where " +
                         " AgenceName=  @C1 and    LicenseNumber =  @C2 ", paramagencyname, paramlicensenumber);
                    dr.Read();


                    if (dr.HasRows)
                    {
                        MessageBox.Show("This 'Agency'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    else {
                     if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {


                            dr.Dispose();
                            dr.Close();
                            SQLCONN.ExecuteQueries("insert into Agencies (  [AgenceName] ,[LicenseNumber],[CountryID],[CityID]) values (@C1,@C2,@C3,@C4)",
                                                           paramagencyname, paramlicensenumber, paramcountry, paramcity);
                            MessageBox.Show("Record saved Successfully");

                            SqlDataReader dr2 = SQLCONN.DataReader("Select max (AgencID) 'ID' from Agencies ");
                            if (dr2.Read())
                            {
                                agaencyid = int.Parse(dr2["ID"].ToString());
                                paramAgencyid.Value = agaencyid;
                            }

                            else { paramAgencyid.Value = 0; }
                            dr2.Close();
                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Agency Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramAgencyid, paramdatetimeLOG, parampc, paramuser);


                            dr2.Dispose();
                            dr2.Close();
                            dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Agencies where AgencID= @id order by AgencID ", paramAgencyid);


                            AgencyNametxt.Text = LicenseNumbertxt.Text = "";
                            cmbCountry.SelectedValue = cmbCity.SelectedValue = 0;



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

            }






            SQLCONN.CloseConnection();
        }
        public void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            //    cmbjobgrade.SelectedIndex = cmbworkfield.SelectedIndex = -1;
            jobtitleartxt.Text = JobTitleENtxt.Text = Descriptiontxt.Text = mintxt.Text = maxtxt.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlParameter paramjobtitleEN = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramjobtitleEN.Value = JobTitleENtxt.Text;
            SqlParameter paramjobtitleAR = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramjobtitleAR.Value = jobtitleartxt.Text;
            SqlParameter ParamDescription = new SqlParameter("@C3", SqlDbType.NVarChar);
            ParamDescription.Value = Descriptiontxt.Text;
            //SqlParameter paramWorkField = new SqlParameter("@C4", SqlDbType.NVarChar);
            //paramWorkField.Value = cmbworkfield.SelectedValue;
            //SqlParameter paramJobGrade = new SqlParameter("@C5", SqlDbType.NVarChar);
            //paramJobGrade.Value = cmbjobgrade.SelectedValue;
            SqlParameter paramminsalary = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramminsalary.Value = mintxt.Text;
            SqlParameter parammaxsalary = new SqlParameter("@C7", SqlDbType.NVarChar);
            parammaxsalary.Value = maxtxt.Text;

            SqlParameter paramjobid = new SqlParameter("@id", SqlDbType.NVarChar);
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;



            if (jobtitleartxt.Text != "" && JobTitleENtxt.Text != "" && Descriptiontxt.Text != "")
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  * from jobs where " +
                     " JobTitleEN=  @C1 and    JobTitleAR =  @C2 ", paramjobtitleEN, paramjobtitleAR);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Job'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    dr.Dispose();
                    dr.Close();

                    if (double.TryParse(mintxt.Text, out num1) && double.TryParse(maxtxt.Text, out num2))
                    {
                        if (num1 > num2)
                        {
                            MessageBox.Show("The min salary is greater than the max salary , Please fix it.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else if (num1 < num2)
                        {
                            SQLCONN.ExecuteQueries("insert into jobs (  [JobTitleEN] ,[JobTitleAR],[JobDescription],[MinSalary],[MaxSalary]) values (@C1,@C2,@C3,@C6,@C7)",
                                                paramjobtitleEN, paramjobtitleAR, ParamDescription, paramminsalary, parammaxsalary);
                            MessageBox.Show("Record saved Successfully");
                            dr.Dispose();
                            dr.Close();
                            SqlDataReader dr2 = SQLCONN.DataReader("Select max (JobID) 'ID' from jobs ");
                            if (dr2.Read())
                            {
                                agaencyid = int.Parse(dr2["ID"].ToString());
                                paramjobid.Value = agaencyid;
                            }




                            else { paramjobid.Value = 0; }

                            dr2.Dispose();
                            dr2.Close();
                            dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  [JOBS] where  [JobID] = @id  ", paramjobid);

                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Job Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramjobid, paramdatetimeLOG, parampc, paramuser);


                            dr.Dispose();
                            dr.Close();
                            dr2.Dispose();
                            dr2.Close();
                            ClearTextBoxes();
                            BtnnewJob.Visible = true;


                        }
                        else
                        {
                            MessageBox.Show("The two numbers are equal.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid numbers in both text boxes.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }



                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Fill the missing fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            SQLCONN.CloseConnection();
        }

        private void cmbCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dr;
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.8;Initial Catalog=DelmonGroupDB;User ID=sa;password=Ram72763@");


            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " SELECT [ConsulateID],ConsulateCity FROM [DelmonGroupDB].[dbo].[Consulates] where  CountryId=@C1 ";


            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.Int));
            cmd.Parameters["@C1"].Value = cmbCountry.SelectedValue;


            //Creating Sql Data Adapter
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            dr = dt.NewRow();


            if (dt != null && dt.Rows.Count >= 0)
            {

                cmbCity.ValueMember = "ConsulateID";
                cmbCity.DisplayMember = "ConsulateCity";
                cmbCity.DataSource = dt;
                cmbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCity.AutoCompleteSource = AutoCompleteSource.ListItems;





            }

            conn.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SQLCONN.OpenConection();
            if (e.RowIndex == -1) return;

            foreach (DataGridViewRow rw in this.dataGridView2.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    SqlParameter paramacounrtry = new SqlParameter("@C1", SqlDbType.NVarChar);

                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {



                        agaencyid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        AgencyNametxt.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                        LicenseNumbertxt.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbCountry.SelectedValue = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();

                        //   cmbCity.SelectedValue = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();


                    }
                    paramacounrtry.Value = cmbCountry.SelectedValue;
                    cmbCity.ValueMember = "ConsulateID";
                    cmbCity.DisplayMember = "ConsulateCity";
                    cmbCity.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT [ConsulateID],ConsulateCity FROM [DelmonGroupDB].[dbo].[Consulates] where  CountryId=@C1", paramacounrtry);

                }

            }

            SQLCONN.CloseConnection();
        }

        private void agenciesTap_Click(object sender, EventArgs e)
        {

        }

        private void checkContact_CheckedChanged(object sender, EventArgs e)
        {
            if (checkContact.Checked == true)
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;

            }
        }

        private void AgencyNametxt_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramAgencyeeSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramAgencyeeSearch.Value = AgencyNametxt.Text;
            SQLCONN.OpenConection();
            dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  Agencies where  AgenceName like '%' + @C1 + '%'   ", paramAgencyeeSearch);



            SQLCONN.CloseConnection();
            //  firstnametxt.Text = secondnametxt.Text = thirdnametxt.Text = lastnametxt.Text = "";
            //  cmbMartialStatus.Text = cmbGender.Text = "";
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            button1.Visible = false;
            BtnnewAgaency.Visible = button2.Visible = button3.Visible = true;
            SQLCONN.OpenConection();
            cmbCity.ValueMember = "ConsulateID";
            cmbCity.DisplayMember = "ConsulateCity";
            cmbCity.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT [ConsulateID],ConsulateCity FROM [DelmonGroupDB].[dbo].[Consulates]   ");

            if (e.RowIndex == -1) return;


            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView2.Columns.Count)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {
                    agaencyid = Convert.ToInt32(row.Cells[0].Value.ToString());
                    AgencyNametxt.Text = row.Cells[1].Value?.ToString();
                    LicenseNumbertxt.Text = row.Cells[2].Value?.ToString();
                    if (cmbCountry != null && row.Cells[3].Value != null)
                    {
                        cmbCountry.SelectedValue = row.Cells[3].Value.ToString();

                    }
                    if (cmbCity != null && row.Cells[4].Value != null)
                    {
                        cmbCity.SelectedValue = row.Cells[4].Value.ToString();

                    }
                }

            }
            dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + agaencyid + " ");


            SQLCONN.CloseConnection();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlParameter paramagencyname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramagencyname.Value = AgencyNametxt.Text;
            SqlParameter paramlicensenumber = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramlicensenumber.Value = LicenseNumbertxt.Text;
            SqlParameter paramcountry = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramcountry.Value = cmbCountry.SelectedValue;
            SqlParameter paramcity = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramcity.Value = cmbCity.SelectedValue;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SqlParameter paramAgencyid = new SqlParameter("@id", SqlDbType.NVarChar);
            paramAgencyid.Value = agaencyid;

            SqlParameter paramContactType = new SqlParameter("@C5", SqlDbType.Int);
            paramContactType.Value = cmbcontact.SelectedValue;
            SqlParameter paramContact = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramContact.Value = Contacttxt.Text;
            SqlParameter paramRefrenceID = new SqlParameter("@C7", SqlDbType.Int);
            paramRefrenceID.Value = 3;


            if (agaencyid != 0)
            {


                if ((AgencyNametxt.Text != "" && AgencyNametxt.Text != "" && LicenseNumbertxt.Text != "") || (Contacttxt.Text != ""))
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        SQLCONN.OpenConection();

                        // MessageBox.Show(EMPID.ToString());

                        /**logtable */
                        DataTable originalData = new DataTable();
                        string connectionString = SQLCONN.ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [Agencies] WHERE [AgencID] = @id";
                            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                            da.SelectCommand.Parameters.AddWithValue("@id", agaencyid);
                            originalData = new DataTable();
                            da.Fill(originalData);
                        }


                        //   paramEmployeeID.Value = CurrentEmployeeIDtxt.Text;


                        if (checkContact.Checked == true)
                        {
                            if (Contacttxt.Text != "")
                            {
                                SQLCONN.ExecuteQueries("update Agencies set AgenceName =@C1,LicenseNumber=@C2,CountryID=@C3,CityID=@C4  where  AgencID=@id  ", paramagencyname, paramlicensenumber, paramcountry, paramcity, paramAgencyid);
                                SQLCONN.ExecuteQueries("update  Contacts  set ContTypeID=@C5,ContValue=@C6,RefrenceID=@C7 where CR_ID=@id", paramContactType, paramContact, paramRefrenceID, paramAgencyid);
                            }
                            else
                            {
                                MessageBox.Show("Please Fill the missing fields  ");

                            }

                        }

                        else
                        {
                            SQLCONN.ExecuteQueries("update Agencies set AgenceName =@C1,LicenseNumber=@C2,CountryID=@C3,CityID=@C4  where  AgencID=@id  ", paramagencyname, paramlicensenumber, paramcountry, paramcity, paramAgencyid);
                        }

                        MessageBox.Show("Record Updated Successfully");
                        dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT * FROM [Agencies] WHERE [AgencID] = @id", paramAgencyid);



                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [Agencies] WHERE [AgencID] = @id";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                            adapter.SelectCommand.Parameters.AddWithValue("@id", agaencyid);
                            DataTable updatedData = new DataTable();
                            adapter.Fill(updatedData);

                            // Compare the two DataTables and find the changed columns
                            List<string> changedColumns = new List<string>();
                            foreach (DataColumn column in originalData.Columns)
                            {
                                object originalValue = originalData.Rows[0][column.ColumnName];
                                object updatedValue = updatedData.Rows[0][column.ColumnName];
                                if (!Equals(originalValue, updatedValue) && (originalValue != null || updatedData != null))
                                {
                                    changedColumns.Add(column.ColumnName);
                                }
                            }

                            // Insert the changes into the log table
                            if (changedColumns.Count > 0)
                            {
                                using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeId, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                                {
                                    command.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                                    foreach (string columnName in changedColumns)
                                    {
                                        object originalValue = originalData.Rows[0][columnName];
                                        object updatedValue = updatedData.Rows[0][columnName];
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@EmployeeId", "For Agency : " + "-" + agaencyid);
                                        command.Parameters.AddWithValue("@ColumnName", columnName);
                                        command.Parameters.AddWithValue("@OldValue", originalValue);
                                        command.Parameters.AddWithValue("@NewValue", updatedValue);
                                        command.Parameters.AddWithValue("@datetime", lbldatetime.Text);
                                        command.Parameters.AddWithValue("@pc", lblPC.Text);
                                        command.Parameters.AddWithValue("@user", lblusername.Text);
                                        command.Parameters.AddWithValue("@type", "Update");
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }



                        /**logtable*/









                        tabControl1.Enabled = true;
                        SQLCONN.CloseConnection();
                    }

                }

                else
                {
                    MessageBox.Show("Please Fill the missing fields  ");

                }
            }


            else
            {

                MessageBox.Show("Please select Agency first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }

            SQLCONN.CloseConnection();
        }

        private void JobTitleENtxt_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramjOBSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramjOBSearch.Value = JobTitleENtxt.Text;
            SQLCONN.OpenConection();
            dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  [JOBS] where  (JobTitleEN like '%' + @C1 + '%')  OR (JobTitleAR LIKE '%' + @C1 + '%')  ", paramjOBSearch);
            SQLCONN.CloseConnection();
            //  firstnametxt.Text = secondnametxt.Text = thirdnametxt.Text = lastnametxt.Text = "";
            //  cmbMartialStatus.Text = cmbGender.Text = "";
        }

        private void jobsTap_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

                        jobid = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                        JobTitleENtxt.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                        jobtitleartxt.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                        Descriptiontxt.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                        //cmbworkfield.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                        //cmbjobgrade.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
                        //mintxt.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
                        maxtxt.Text = dataGridView3.Rows[e.RowIndex].Cells[7].Value.ToString();


                        // Check if the clicked cell is in the IsActive column

                        // Get the value of the cell






                        EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

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

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            button4.Visible = false;
            btnnew.Visible = button5.Visible = button6.Visible = true;
            if (e.RowIndex == -1) return;
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView3.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView3.Columns.Count)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {
                    jobid = Convert.ToInt32(row.Cells[0].Value.ToString());
                    JobTitleENtxt.Text = row.Cells[1].Value?.ToString();
                    jobtitleartxt.Text = row.Cells[2].Value?.ToString();
                    Descriptiontxt.Text = row.Cells[3].Value?.ToString();
                    //if (cmbworkfield != null && row.Cells[4].Value != null)
                    //{
                    //    cmbworkfield.SelectedValue = row.Cells[4].Value.ToString();
                    //}
                    //if (cmbjobgrade != null && row.Cells[5].Value != null)
                    //{
                    //    cmbjobgrade.SelectedValue = row.Cells[5].Value.ToString();
                    //}
                    mintxt.Text = row.Cells[6].Value?.ToString();
                    maxtxt.Text = row.Cells[7].Value?.ToString();
                }
            }

        }

        private void mintxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // suppress the key press event
                MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void mintxt_Validating(object sender, CancelEventArgs e)
        {


        }

        private void JobTitleENtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                jobtitleartxt.Focus();
                e.Handled = true;

            }
        }

        private void jobtitleartxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Descriptiontxt.Focus();
                e.Handled = true;

            }
        }

        private void cmbworkfield_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //   cmbjobgrade.Focus();
                e.Handled = true;

            }
        }

        private void Descriptiontxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // cmbworkfield.Focus();
                e.Handled = true;

            }
        }

        private void cmbjobgrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mintxt.Focus();
                e.Handled = true;

            }
        }

        private void mintxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                maxtxt.Focus();
                e.Handled = true;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlParameter paramjobid = new SqlParameter("@id", SqlDbType.NVarChar);
            paramjobid.Value = jobid;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if (jobid == 0)
            {
                MessageBox.Show("Please select  Job first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  JOBS where jobid=@id", paramjobid);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([jobid]) from [JOBS] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[JOBS]', RESEED, @max)");
                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from JOBS ");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Job Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramjobid, paramdatetimeLOG, parampc, paramuser);
                    SQLCONN.CloseConnection();



                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlParameter paramjobtitleEN = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramjobtitleEN.Value = JobTitleENtxt.Text;
            SqlParameter paramjobtitleAR = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramjobtitleAR.Value = jobtitleartxt.Text;
            SqlParameter ParamDescription = new SqlParameter("@C3", SqlDbType.NVarChar);
            ParamDescription.Value = Descriptiontxt.Text;
            //SqlParameter paramWorkField = new SqlParameter("@C4", SqlDbType.NVarChar);
            //paramWorkField.Value = cmbworkfield.SelectedValue;
            //SqlParameter paramJobGrade = new SqlParameter("@C5", SqlDbType.NVarChar);
            //paramJobGrade.Value = cmbjobgrade.SelectedValue;
            SqlParameter paramminsalary = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramminsalary.Value = mintxt.Text;
            SqlParameter parammaxsalary = new SqlParameter("@C7", SqlDbType.NVarChar);
            parammaxsalary.Value = maxtxt.Text;

            SqlParameter paramjobid = new SqlParameter("@id", SqlDbType.NVarChar);
            paramjobid.Value = jobid;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if (jobid != 0)
            {


                if (JobTitleENtxt.Text != "" && jobtitleartxt.Text != "" && Descriptiontxt.Text != "" && mintxt.Text != "" && maxtxt.Text != "")
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        SQLCONN.OpenConection();

                        // MessageBox.Show(EMPID.ToString());

                        /**logtable */
                        DataTable originalData = new DataTable();
                        string connectionString = SQLCONN.ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [jobs] WHERE [jobid] = @id";
                            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                            da.SelectCommand.Parameters.AddWithValue("@id", jobid);
                            originalData = new DataTable();
                            da.Fill(originalData);
                        }


                        //   paramEmployeeID.Value = CurrentEmployeeIDtxt.Text;

                        if (double.TryParse(mintxt.Text, out num1) && double.TryParse(maxtxt.Text, out num2))
                        {
                            if (num1 > num2)
                            {
                                MessageBox.Show("The min salary is greater than the max salary , Please fix it.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else if (num1 < num2)
                            {
                                SQLCONN.ExecuteQueries("update jobs set [JobTitleEN] =@C1,[JobTitleAR]=@C2,[JobDescription]=@C3,[MinSalary]=@C6,[MaxSalary]=@C7  where  jobid=@id  ", paramjobtitleEN, paramjobtitleAR, ParamDescription, paramminsalary, parammaxsalary, paramjobid);
                                MessageBox.Show("Record updated Successfully");


                                dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  [JOBS] where  [JobID] = @id  ", paramjobid);

                                SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Job Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramjobid, paramdatetimeLOG, parampc, paramuser);



                                ClearTextBoxes();

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    string sql = "SELECT * FROM [jobs] WHERE [jobid] = @id";
                                    SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                                    da.SelectCommand.Parameters.AddWithValue("@id", jobid);
                                    DataTable updatedData = new DataTable();
                                    da.Fill(updatedData);

                                    // Compare the two DataTables and find the changed columns
                                    List<string> changedColumns = new List<string>();
                                    foreach (DataColumn column in originalData.Columns)
                                    {
                                        object originalValue = originalData.Rows[0][column.ColumnName];
                                        object updatedValue = updatedData.Rows[0][column.ColumnName];
                                        if (!Equals(originalValue, updatedValue) && (originalValue != null || updatedData != null))
                                        {
                                            changedColumns.Add(column.ColumnName);
                                        }
                                    }

                                    // Insert the changes into the log table
                                    if (changedColumns.Count > 0)
                                    {
                                        using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeId, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                                        {
                                            command.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                                            foreach (string columnName in changedColumns)
                                            {
                                                object originalValue = originalData.Rows[0][columnName];
                                                object updatedValue = updatedData.Rows[0][columnName];
                                                command.Parameters.Clear();
                                                command.Parameters.AddWithValue("@EmployeeId", "For job id : " + " " + jobid);
                                                command.Parameters.AddWithValue("@ColumnName", columnName);
                                                command.Parameters.AddWithValue("@OldValue", originalValue);
                                                command.Parameters.AddWithValue("@NewValue", updatedValue);
                                                command.Parameters.AddWithValue("@datetime", lbldatetime.Text);
                                                command.Parameters.AddWithValue("@pc", lblPC.Text);
                                                command.Parameters.AddWithValue("@user", lblusername.Text);
                                                command.Parameters.AddWithValue("@type", "Update");
                                                command.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }



                                /**logtable*/


                            }
                            else
                            {
                                MessageBox.Show("The two numbers are equal.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid numbers in both text boxes.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }





                        dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT * FROM [jobs] WHERE [jobid] = @id", paramjobid);











                        tabControl1.Enabled = true;
                        SQLCONN.CloseConnection();
                    }

                }

                else
                {
                    MessageBox.Show("Please Fill the missing fields", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }


            else
            {

                MessageBox.Show("Please select Job first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }

            SQLCONN.CloseConnection();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            //SqlParameter paramDEPARTMENTNAME = new SqlParameter("@C1", SqlDbType.NVarChar);
            //paramDEPARTMENTNAME.Value = cmbDepartment654.SelectedValue;
            //SqlParameter paramHEADOFDEPARTMENT = new SqlParameter("@C3", SqlDbType.NVarChar);
            //paramHEADOFDEPARTMENT.Value = cmbemployee13633.SelectedValue;
            ////SqlParameter paramHEADPOSTION = new SqlParameter("@C4", SqlDbType.NVarChar);
            ////paramHEADPOSTION.Value = cmbHeadPostion.SelectedValue;
            //SqlParameter PARAMCOMPANY = new SqlParameter("@C5", SqlDbType.NVarChar);
            //PARAMCOMPANY.Value = cmbCompany.SelectedValue;


            ////SqlParameter Paramdepartmentid = new SqlParameter("@id", SqlDbType.NVarChar);
            ////Paramdepartmentid.Value = departmentid;

            //SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            //paramuser.Value = lblusername.Text;
            //SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            //paramdatetimeLOG.Value = lbldatetime.Text;
            //SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            //parampc.Value = lblPC.Text;

            ////if (cmbDepartment654.Text != "Select" && cmbemployee13633.Text != "Select" && cmbCompany.Text != "Select")
            //{ }
            //else
            //{
            //    MessageBox.Show("Please Fill the missing fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}




        }

        private void DepartmentTap_Click(object sender, EventArgs e)
        {

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            addbtn.Visible = true;
            ClearTextBoxes();
            usernametxt.Text = passwordtxt.Text = "";
            cmbusertype.Text = cmbemployee.Text = "Select ";


        }

        private void BtnnewJob_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            ClearTextBoxes();

        }

        private void BtnnewAgaency_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button3.Visible = button2.Visible = false;
            button19.Visible = button18.Visible = button24.Visible = false ;

            ClearTextBoxes();
            cmbcontact.Text = cmbCountry.Text = cmbCity.Text = "Select";
            dataGridView2.DataSource = dataGridView4.DataSource = null;
            AgencyNametxt.Text = LicenseNumbertxt.Text = Contacttxt.Text = string.Empty;

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            cmbUserPermission.Text = "Select";
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
                /*Countries*/
                string permissionName = dr["PermissionName"].ToString();
                if (permissionName.Contains("ViewCountriesTab"))

                {
                    hasViewcountr = true;
                }
                if (permissionName.Contains("AddCountriesTab"))
                {
                    hasAddcountr = true;
                }
                if (permissionName.Contains("EditCountriesTab"))
                {
                    hasEditcountr = true;
                }
                if (permissionName.Contains("DeleteCountriesTab"))
                {
                    hasDeletecountr = true;
                }
                /*Companies*/
                if (permissionName.Contains("ViewCompaniesTab"))

                {
                    hasViewcompan = true;
                }
                if (permissionName.Contains("AddCompaniesTab"))
                {
                    hasAddcompan = true;
                }
                if (permissionName.Contains("EditCompaniesTab"))
                {
                    hasEditcompan = true;
                }
                if (permissionName.Contains("DeleteCompaniesTab"))
                {
                    hasDeletecompan = true;
                }
                /*Agency*/
                if (permissionName.Contains("ViewAgenciesTab"))

                {
                    hasViewAgenc = true;
                }
                if (permissionName.Contains("AddAgenciesTab"))
                {
                    hasAddAgenc = true;
                }
                if (permissionName.Contains("EditAgenciesTab"))
                {
                    hasEditAgenc = true;
                }
                if (permissionName.Contains("DeleteAgenciesTab"))
                {
                    hasDeleteAgenc = true;
                }
                /*job*/
                if (permissionName.Contains("ViewJobTab"))
                {
                    hasViewJob = true;
                }
                if (permissionName.Contains("AddJobTab"))
                {
                    hasAddJob = true;
                }
                if (permissionName.Contains("EditJobTab"))
                {
                    hasEditJob = true;
                }
                if (permissionName.Contains("DeleteJobTab"))
                {
                    hasDeleteJob = true;
                }

                /*user*/
                if (permissionName.Contains("ViewUserTab"))
                {
                    hasViewUser = true;
                }
                if (permissionName.Contains("AddUserTab"))
                {
                    hasAddUser = true;
                }
                if (permissionName.Contains("EditUserTab"))
                {
                    hasEditUser = true;
                }
                if (permissionName.Contains("DeleteUserTab"))
                {
                    hasDeleteUser = true;
                }
                if (permissionName.Contains("ViewEmployeeLog"))
                {
                    hasViewEmployeelog = true;
                }

                
            }
            dr.Close();


                SQLCONN.CloseConnection();


            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                if (hasViewUser == false)
                {

                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    groupBox10.Enabled = false;
                    dataGridView1.DataSource = null;


                }
                else
                {
                    groupBox10.Enabled = true;


                    if (hasAddUser)
                    {
                        btnnew.Enabled = addbtn.Enabled = true;

                    }
                    else
                    {
                        btnnew.Enabled = addbtn.Enabled = false;

                    }
                    if (hasEditUser)
                    {
                        updatebtn.Enabled = true;
                    }
                    else
                    {
                        updatebtn.Enabled = false;

                    }
                    if (hasDeleteUser)
                    {
                        deletebtn.Enabled = true;
                    }
                    else
                    {
                        deletebtn.Enabled = false;

                    }
                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                tabControl1.TabPages[1].Visible = false;
                if (lblusertype.Text != "SuperAdmin")
                {

                    MessageBox.Show("Sorry This Section for SuperAdmin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    tabControl1.TabPages[1].Visible = true;

                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                if (hasViewJob == false)
                {

                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    groupBox9.Enabled = false;
                    dataGridView3.DataSource = null;


                }
                else
                {
                    groupBox9.Enabled = true;


                    if (hasAddJob)
                    {
                        button4.Enabled = BtnnewJob.Enabled = true;

                    }
                    else
                    {
                        button4.Enabled = BtnnewJob.Enabled = false;

                    }
                    if (hasEditJob)
                    {
                        button5.Enabled = true;
                    }
                    else
                    {
                        button5.Enabled = false;

                    }
                    if (hasDeleteJob)
                    {
                        button6.Enabled = true;
                    }
                    else
                    {
                        button6.Enabled = false;

                    }
                }

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[3])
            {
                if (hasViewAgenc == false)
                {

                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    groupBox2.Enabled = false;
                    groupBox8.Enabled = false;
                    dataGridView2.DataSource = null;

                }
                else
                {
                    groupBox2.Enabled = true;
                    groupBox8.Enabled = true;


                    if (hasAddAgenc)
                    {
                        button1.Enabled = BtnnewAgaency.Enabled = true;

                    }
                    else
                    {
                        button1.Enabled = BtnnewAgaency.Enabled = false;

                    }
                    if (hasEditAgenc)
                    {
                        button3.Enabled = true;
                    }
                    else
                    {
                        button3.Enabled = false;

                    }
                    if (hasDeletecompan)
                    {
                        button2.Enabled = true;
                    }
                    else
                    {
                        button2.Enabled = false;

                    }
                }

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[4])
            {
                if (hasViewcountr == false)
                {

                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    groupBox3.Enabled = false;
                    groupBox4.Enabled = false;

                }
                else
                {
                    groupBox3.Enabled = true;
                    groupBox4.Enabled = true;

                    if (hasAddcompan)
                    {
                        button13.Enabled = button9.Enabled = button10.Enabled = true;
                        button14.Enabled = button17.Enabled = button7.Enabled = button8.Enabled = true;

                    }
                    else
                    {
                        button13.Enabled = button9.Enabled = button10.Enabled = false;
                        button14.Enabled = button17.Enabled = button7.Enabled = button8.Enabled = false;

                    }
                    if (hasEditcompan)
                    {
                        button16.Enabled = button12.Enabled = true;
                    }
                    else
                    {
                        button16.Enabled = button12.Enabled = false;

                    }
                    if (hasDeletecompan)
                    {
                        button11.Enabled = button15.Enabled = true;
                    }
                    else
                    {
                        button11.Enabled = button15.Enabled = false;

                    }

                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[5])
            {
                if (hasViewcountr == false)
                {

                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    groupBox6.Enabled = false;
                    groupBox5.Enabled = false;

                }
                else
                {
                    groupBox6.Enabled = true;
                    groupBox5.Enabled = true;

                    if (hasAddcountr)
                    {
                        button28.Enabled = button26.Enabled = true;
                        button23.Enabled = button20.Enabled = true;

                    }
                    else
                    {
                        button23.Enabled = button20.Enabled = false;
                        button28.Enabled = button26.Enabled = false;

                    }
                    if (hasEditcountr)
                    {
                        button22.Enabled = button27.Enabled = true;
                    }
                    else
                    {
                        button22.Enabled = button27.Enabled = false;

                    }
                    if (hasDeletecountr)
                    {
                        button21.Enabled = button25.Enabled = true;
                    }
                    else
                    {
                        button21.Enabled = button25.Enabled = false;

                    }


                }

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[6])
            {
                if (hasViewEmployeelog)
                {
                    cmbUserLog.Text =  cmbsection.Text = "Select";
                    cmbUserLog.Enabled =cmbsection.Enabled = true;
                    button30.Enabled = button29.Enabled = true;
                    deleterb.Enabled = allrb.Enabled = updaterb.Enabled = insertrb.Enabled = true;
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = true;

                }
                else
                { 
                    cmbUserLog.Enabled = cmbsection.Enabled = false;
                    cmbUserLog.Text = cmbsection.Text = "Select";
                    button30.Enabled = button29.Enabled = false;
                    deleterb.Enabled = allrb.Enabled = updaterb.Enabled = insertrb.Enabled = false;
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;

                }


                //  MessageBox.Show("Comming Soon  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[7])
            {
                MessageBox.Show("Comming Soon  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            //SqlParameter paramHeadepartment = new SqlParameter("@C0", SqlDbType.NVarChar);
            //paramHeadepartment.Value = cmbemployee13633.SelectedValue;
            //SqlParameter paramDepartment = new SqlParameter("@C1", SqlDbType.NVarChar);
            //paramDepartment.Value = cmbDepartment654.SelectedValue;

            //SQLCONN.OpenConection();

            //if ((int)cmbemployee13633.SelectedValue != 0)
            //{
            //    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            //    {


            //        //     SQLCONN.ExecuteQueries("update  Contacts set ContTypeID=@C1,ContValue=@C2 where Contact_ID=@C4",

            //        SQLCONN.ExecuteQueries("update  DEPARTMENTS set DeptHeadID=@C0  where DEPTID=@C1",
            //                                      paramHeadepartment, paramDepartment );
            //        MessageBox.Show("Record Updated Successfully");

            //        dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  * FROM [DelmonGroupDB].[dbo].[DEPARTMENTS] where DEPTID =  " + cmbDepartment654.SelectedValue + " ");

            //    }
            //    else
            //    {

            //    }


            //}
            //else
            //{
            //    MessageBox.Show("Please Select Record to Update");
            //}
            //SQLCONN.CloseConnection();

        }

        private void cmbCompany_SelectionChangeCommitted(object sender, EventArgs e)
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

            //    //cmbDepartment654.ValueMember = "DEPTID";
            //    //cmbDepartment654.DisplayMember = "Dept_Type_Name";
            //    //cmbDepartment654.DataSource = dt;
            //    //cmbDepartment654.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    //cmbDepartment654.AutoCompleteSource = AutoCompleteSource.ListItems;





            //}

            //conn.Close();
        }
        private void cmbemployee1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbemployee1_KeyDown(object sender, KeyEventArgs e)
        {
            //  if (e.KeyCode == Keys.Enter)
            //  {
            //      // Handle the Enter key press
            ////      var selectedItem = cmbemployee13633.SelectedItem as DataRowView;

            //     // if (selectedItem != null)
            //      {
            //          // Access the selected item's properties
            //          var employeeID = selectedItem["EmployeeID"].ToString();
            //          var fullName = selectedItem["FullName"].ToString();

            //          // Use the selected item for further processing or display
            //          // For example:
            //      }
            //  }
        }

        private void cmbemployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Handle the Enter key press
                var selectedItem = cmbemployee.SelectedItem as DataRowView;

                if (selectedItem != null)
                {
                    // Access the selected item's properties
                    var employeeID = selectedItem["EmployeeID"].ToString();
                    var fullName = selectedItem["FullName"].ToString();

                    // Use the selected item for further processing or display
                    // For example:
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button13.Visible = true;
            ClearTextBoxes();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlParameter paramcompEn = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcompEn.Value = txtcompnameEN.Text;
            SqlParameter paramcompAR = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramcompAR.Value = txtcompnameAR.Text;
            SqlParameter ParamCR = new SqlParameter("@C3", SqlDbType.NVarChar);
            ParamCR.Value = txtCR.Text;
            SqlParameter paramSponser = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramSponser.Value = txtSponser.Text;
            SqlParameter paramVat = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramVat.Value = txtVat.Text;
            SqlParameter paramHD = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramHD.Value = txtHD.Text;
            SqlParameter paramAD = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramAD.Value = txtAD.Text;
            SqlParameter paramGeneralManager = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramGeneralManager.Value = cmbemployee2.SelectedValue;

            SqlParameter paramShortName = new SqlParameter("@C10", SqlDbType.NVarChar);
            paramShortName.Value = txtshort.Text;



            SqlParameter paramCompid = new SqlParameter("@id", SqlDbType.NVarChar);
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            SQLCONN.OpenConection();
            if (txtcompnameEN.Text == "" || txtcompnameAR.Text == "" || txtCR.Text == "" || txtVat.Text == "")
            {
                MessageBox.Show("Please Fill Missing Fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else {
                // Retrieve the last comp ID from the table
                SqlDataReader dr = SQLCONN.DataReader("SELECT TOP 1 COMPID FROM Companies ORDER BY COMPID DESC");
                if (dr.Read())
                {
                    CompID = int.Parse(dr["COMPID"].ToString());
                    CompID = CompID + 1000;
                }
                paramCompid.Value = CompID;
                dr.Dispose();
                dr.Close();
                SQLCONN.ExecuteQueries("insert into Companies (COMPID,COMPName_EN,COMPName_AR,CRNumber,ID_Number,VAT_NO,EstablishedHD,EstablishedAD,General_Manager,ShortCompName)" +
                    " values (@id,@C1,@C2,@C3,@C4,@C5,@C7,@C8,@C9,@C10) ", paramCompid, paramcompEn, paramcompAR, ParamCR, paramSponser, paramVat, paramHD, paramAD, paramGeneralManager, paramShortName);


                MessageBox.Show("Record saved Successfully");
                dr.Dispose();
                dr.Close();
                SqlDataReader dr2 = SQLCONN.DataReader("Select max (COMPID) 'ID' from Companies ");
                if (dr2.Read())
                {
                    CompID = int.Parse(dr2["ID"].ToString());
                    paramCompid.Value = CompID;
                }




                else { paramCompid.Value = 0; }

                dr2.Dispose();
                dr2.Close();
                dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  [Companies] where  [COMPID] = @id  ", paramCompid);

                SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Company Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramCompid, paramdatetimeLOG, parampc, paramuser);


                dr.Dispose();
                dr.Close();
                dr2.Dispose();
                dr2.Close();
                ClearTextBoxes();
                button10.Visible = true;


                SQLCONN.CloseConnection();
            }





        }

        private void txtCR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // suppress the key press event
                MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSponser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // suppress the key press event
                MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // suppress the key press event
                MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtcompnameEN_TextChanged(object sender, EventArgs e)
        {
            string query = @"
   SELECT DISTINCT Companies.COMPID,
       [CRNumber],
       [ID_Number],
       [COMPName_EN],
       [COMPName_AR],
       [ShortCompName],
       [VAT_NO],
       [EstablishedHD],
       [EstablishedAD],
       CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) AS 'General_Manager'
FROM [DelmonGroupDB].[dbo].[Companies]
JOIN Employees ON Employees.EmployeeID = Companies.General_Manager
WHERE (COMPName_EN LIKE '%' + @C1 + '%')
   OR (COMPName_AR LIKE '%' + @C1 + '%')
   OR (CRNumber LIKE '%' + @C1 + '%')
   OR (ID_Number LIKE '%' + @C1 + '%')
   AND Companies.General_Manager IN (SELECT EmployeeID FROM Employees)
";

            SqlParameter paramCompSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramCompSearch.Value = txtcompnameEN.Text;

            SQLCONN.OpenConection();
            dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramCompSearch);
            SQLCONN.CloseConnection();






        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button13.Visible = false;
            button10.Visible = button12.Visible = button11.Visible = button9.Visible = true;

            if (e.RowIndex == -1) return;

            if (e.RowIndex >= 0 && e.RowIndex < dataGridView6.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView6.Columns.Count)
            {
                DataGridViewRow row = dataGridView6.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    CompID = Convert.ToInt32(row.Cells[0].Value.ToString());
                    CommonClass.CompanyId = Convert.ToInt32(row.Cells[0].Value.ToString());
                    txtCR.Text = row.Cells[1].Value?.ToString();
                    CommonClass.CRNmber = txtCR.Text;
                    txtSponser.Text = row.Cells[2].Value?.ToString();
                    txtcompnameEN.Text = row.Cells[3].Value?.ToString();
                    CommonClass.CompName = txtcompnameEN.Text;
                    txtcompnameAR.Text = row.Cells[4].Value?.ToString();
                    txtshort.Text = row.Cells[5].Value?.ToString();
                    CommonClass.ShortName = txtshort.Text;
                    txtVat.Text = row.Cells[6].Value?.ToString();
                    txtHD.Text = row.Cells[7].Value?.ToString();
                    txtAD.Text = row.Cells[8].Value?.ToString();
                    cmbemployee2.Text = row.Cells[9].Value?.ToString();

                    dataGridView7.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT * FROM [DEPARTMENTS] WHERE CompID=" + CompID);
                }
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {
            SqlParameter paramcompEn = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcompEn.Value = txtcompnameEN.Text;
            SqlParameter paramcompAR = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramcompAR.Value = txtcompnameAR.Text;
            SqlParameter ParamCR = new SqlParameter("@C3", SqlDbType.NVarChar);
            ParamCR.Value = txtCR.Text;
            SqlParameter paramSponser = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramSponser.Value = txtSponser.Text;
            SqlParameter paramVat = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramVat.Value = txtVat.Text;
            //SqlParameter paramWorkLocation = new SqlParameter("@C6", SqlDbType.NVarChar);
            //paramWorkLocation.Value = cmbworkfield.SelectedValue;
            SqlParameter paramHD = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramHD.Value = txtHD.Text;
            SqlParameter paramAD = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramAD.Value = txtAD.Text;
            SqlParameter paramGeneralManager = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramGeneralManager.Value = cmbemployee2.SelectedValue;

            SqlParameter paramShortName = new SqlParameter("@C10", SqlDbType.NVarChar);
            paramShortName.Value = txtshort.Text;


            SqlParameter paramCompid = new SqlParameter("@id", SqlDbType.NVarChar);
            paramCompid.Value = CompID;

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if (CompID != 0)
            {


                if (txtcompnameEN.Text != "" && txtcompnameAR.Text != "" && txtCR.Text != "" && txtVat.Text != "" && txtSponser.Text != "")
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        SQLCONN.OpenConection();

                        // MessageBox.Show(EMPID.ToString());

                        /**logtable */
                        DataTable originalData = new DataTable();
                        string connectionString = SQLCONN.ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [Companies] WHERE [COMPID] = @id";
                            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                            da.SelectCommand.Parameters.AddWithValue("@id", CompID);
                            originalData = new DataTable();
                            da.Fill(originalData);
                        }


                        //   paramEmployeeID.Value = CurrentEmployeeIDtxt.Text;






                        SQLCONN.ExecuteQueries("update Companies set [COMPName_EN] =@C1,[COMPName_AR]=@C2,[CRNumber]=@C3,[ID_Number]=@C4,[VAT_NO]=@C5,[EstablishedHD]=@C7,[EstablishedAD]=@C8, [General_Manager]=@C9,[ShortCompName]=@C10 where  COMPID=@id  ", paramcompEn, paramcompAR, ParamCR, paramSponser, paramVat, paramHD, paramAD, paramGeneralManager, paramShortName, paramCompid);
                        MessageBox.Show("Record updated Successfully");


                        dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT * FROM [Companies] where  [COMPID] = @id  ", paramCompid);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Company Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramCompid, paramdatetimeLOG, parampc, paramuser);



                        ClearTextBoxes();

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [Companies] WHERE [COMPID] = @id";
                            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                            da.SelectCommand.Parameters.AddWithValue("@id", CompID);
                            DataTable updatedData = new DataTable();
                            da.Fill(updatedData);

                            // Compare the two DataTables and find the changed columns
                            List<string> changedColumns = new List<string>();
                            foreach (DataColumn column in originalData.Columns)
                            {
                                object originalValue = originalData.Rows[0][column.ColumnName];
                                object updatedValue = updatedData.Rows[0][column.ColumnName];
                                if (!Equals(originalValue, updatedValue) && (originalValue != null || updatedData != null))
                                {
                                    changedColumns.Add(column.ColumnName);
                                }
                            }

                            // Insert the changes into the log table
                            if (changedColumns.Count > 0)
                            {
                                using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeId, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                                {
                                    command.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                                    foreach (string columnName in changedColumns)
                                    {
                                        object originalValue = originalData.Rows[0][columnName];
                                        object updatedValue = updatedData.Rows[0][columnName];
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@EmployeeId", "For Company id : " + " " + CompID);
                                        command.Parameters.AddWithValue("@ColumnName", columnName);
                                        command.Parameters.AddWithValue("@OldValue", originalValue);
                                        command.Parameters.AddWithValue("@NewValue", updatedValue);
                                        command.Parameters.AddWithValue("@datetime", lbldatetime.Text);
                                        command.Parameters.AddWithValue("@pc", lblPC.Text);
                                        command.Parameters.AddWithValue("@user", lblusername.Text);
                                        command.Parameters.AddWithValue("@type", "Update");
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }



                        /**logtable*/


                        dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT * FROM [Companies] WHERE [COMPID]  = @id", paramCompid);



                        tabControl1.Enabled = true;
                        SQLCONN.CloseConnection();
                    }

                }

                else
                {
                    MessageBox.Show("Please Fill the missing fields", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }


            else
            {

                MessageBox.Show("Please select Company first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }

            SQLCONN.CloseConnection();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlParameter paramCompid = new SqlParameter("@id", SqlDbType.NVarChar);
            paramCompid.Value = CompID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if (CompID == 0)
            {
                MessageBox.Show("Please select Company first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("Delete FROM [Companies] WHERE [COMPID] = @id", paramCompid);
                    //   SQLCONN.ExecuteQueries(" declare @max int select @max = max([jobid]) from [JOBS] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[JOBS]', RESEED, @max)");
                    dataGridView6.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Companies ");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Company Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramCompid, paramdatetimeLOG, parampc, paramuser);
                    SQLCONN.CloseConnection();
                    ClearTextBoxes();
                    txtcompnameEN.Text = txtcompnameAR.Text = txtCR.Text = txtVat.Text = txtSponser.Text = txtAD.Text = txtHD.Text = "";

                    cmbemployee2.Text = "Select";





                }

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button17.Visible = true;
            ClearTextBoxes();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (CompID == 0)
            {
                MessageBox.Show("Please Select Company First.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                SqlParameter paramDeptName = new SqlParameter("@C1", SqlDbType.NVarChar);
                paramDeptName.Value = cmbDepartment.SelectedValue;
                SqlParameter paramWorkLocation = new SqlParameter("@C2", SqlDbType.NVarChar);
                paramWorkLocation.Value = cmbworkfield.SelectedValue;
                SqlParameter paramDeptHead = new SqlParameter("@C3", SqlDbType.NVarChar);
                paramDeptHead.Value = cmbemployee1.SelectedValue;

                SqlParameter paramCompid = new SqlParameter("@id", SqlDbType.NVarChar);
                paramCompid.Value = CompID;
                SqlParameter paramDeptID = new SqlParameter("@DeptID", SqlDbType.NVarChar);

                SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
                paramuser.Value = lblusername.Text;
                SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
                paramdatetimeLOG.Value = lbldatetime.Text;
                SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
                parampc.Value = lblPC.Text;


                SQLCONN.OpenConection();
                // Retrieve the last comp ID from the table
                SqlDataReader dr = SQLCONN.DataReader("SELECT TOP 1 DEPTID FROM DEPARTMENTS where COMPID=@id ORDER BY DEPTID DESC", paramCompid);
                if (dr.Read())
                {
                    DeptID = int.Parse(dr["DEPTID"].ToString());
                    DeptID = DeptID + 1;
                }
                else
                {
                    DeptID = CompID + 101;
                }
                paramDeptID.Value = DeptID;
                dr.Dispose();
                dr.Close();
                SQLCONN.ExecuteQueries("insert into DEPARTMENTS (DEPTID,DeptName,WorkLoctionID,DeptHeadID,COMPID)" +
              " values (@DeptID,@C1,@C2,@C3,@id) ", paramDeptID, paramDeptName, paramWorkLocation, paramDeptHead, paramCompid);

                MessageBox.Show("Record saved Successfully");
                dr.Dispose();
                dr.Close();




                dataGridView7.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  [DEPARTMENTS] where  [DEPTID] = " + DeptID + "  ");

                SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Department Info',@DeptID ,'#','#',@datetime,@pc,@user,'Insert')", paramDeptID, paramdatetimeLOG, parampc, paramuser);


                dr.Dispose();
                dr.Close();

                ClearTextBoxes();
                button14.Visible = true;

                SQLCONN.CloseConnection();




            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SqlParameter paramDeptID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramDeptID.Value = DeptID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;

            if (DeptID == 0)
            {
                MessageBox.Show("Please select Company first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("Delete FROM [DEPARTMENTS] WHERE [DEPTID] = @id", paramDeptID);
                    //   SQLCONN.ExecuteQueries(" declare @max int select @max = max([jobid]) from [JOBS] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[JOBS]', RESEED, @max)");
                    dataGridView7.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT * FROM [DEPARTMENTS] WHERE [DEPTID]  = @id", paramDeptID);
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Department Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramDeptID, paramdatetimeLOG, parampc, paramuser);
                    SQLCONN.CloseConnection();
                    ClearTextBoxes();
                    txtcompnameEN.Text = txtcompnameAR.Text = txtCR.Text = txtVat.Text = txtSponser.Text = txtAD.Text = txtHD.Text = "";

                    cmbemployee2.Text = "Select";





                }

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {


            SqlParameter paramDeptName = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramDeptName.Value = cmbDepartment.SelectedValue;
            SqlParameter paramWorkLocation = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramWorkLocation.Value = cmbworkfield.SelectedValue;
            SqlParameter paramDeptHead = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramDeptHead.Value = cmbemployee1.SelectedValue;

            SqlParameter paramCompid = new SqlParameter("@id2", SqlDbType.NVarChar);
            paramCompid.Value = CompID;
            SqlParameter paramDeptID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramDeptID.Value = DeptID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;



            if (DeptID != 0 && CompID != 0)
            {



                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    SQLCONN.OpenConection();

                    // MessageBox.Show(EMPID.ToString());

                    /**logtable */
                    DataTable originalData = new DataTable();
                    string connectionString = SQLCONN.ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM [DEPARTMENTS] WHERE [DEPTID] = @id";
                        SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                        da.SelectCommand.Parameters.AddWithValue("@id", DeptID);
                        originalData = new DataTable();
                        da.Fill(originalData);
                    }


                    //   paramEmployeeID.Value = CurrentEmployeeIDtxt.Text;






                    SQLCONN.ExecuteQueries("update DEPARTMENTS set [DeptName] =@C1,[WorkLoctionID]=@C2,[DeptHeadID]=@C3,[COMPID]=@id2 where  DEPTID=@id  ", paramDeptName, paramWorkLocation, paramDeptHead, paramCompid, paramDeptID);
                    MessageBox.Show("Record updated Successfully");


                    dataGridView7.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT * FROM [DEPARTMENTS] where  [DEPTID] = @id  ", paramDeptID);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (logvalue,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Department Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramDeptID, paramdatetimeLOG, parampc, paramuser);



                    ClearTextBoxes();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM [DEPARTMENTS] WHERE [DEPTID] = @id";
                        SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                        da.SelectCommand.Parameters.AddWithValue("@id", DeptID);
                        DataTable updatedData = new DataTable();
                        da.Fill(updatedData);

                        // Compare the two DataTables and find the changed columns
                        List<string> changedColumns = new List<string>();
                        foreach (DataColumn column in originalData.Columns)
                        {
                            object originalValue = originalData.Rows[0][column.ColumnName];
                            object updatedValue = updatedData.Rows[0][column.ColumnName];
                            if (!Equals(originalValue, updatedValue) && (originalValue != null || updatedData != null))
                            {
                                changedColumns.Add(column.ColumnName);
                            }
                        }

                        // Insert the changes into the log table
                        if (changedColumns.Count > 0)
                        {
                            using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeId, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                            {
                                command.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                                foreach (string columnName in changedColumns)
                                {
                                    object originalValue = originalData.Rows[0][columnName];
                                    object updatedValue = updatedData.Rows[0][columnName];
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@EmployeeId", "For Department id : " + " " + DeptID);
                                    command.Parameters.AddWithValue("@ColumnName", columnName);
                                    command.Parameters.AddWithValue("@OldValue", originalValue);
                                    command.Parameters.AddWithValue("@NewValue", updatedValue);
                                    command.Parameters.AddWithValue("@datetime", lbldatetime.Text);
                                    command.Parameters.AddWithValue("@pc", lblPC.Text);
                                    command.Parameters.AddWithValue("@user", lblusername.Text);
                                    command.Parameters.AddWithValue("@type", "Update");
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }



                    /**logtable*/


                    dataGridView7.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT * FROM [DEPARTMENTS] WHERE [DEPTID]  = @id", paramDeptID);



                    tabControl1.Enabled = true;
                    SQLCONN.CloseConnection();
                }




            }


            else
            {

                MessageBox.Show("Please select Department first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }

            SQLCONN.CloseConnection();
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            button17.Visible = false;
            button14.Visible = button15.Visible = button16.Visible = true;

            if (e.RowIndex == -1) return;

            if (e.RowIndex >= 0 && e.RowIndex < dataGridView7.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView7.Columns.Count)
            {
                DataGridViewRow row = dataGridView7.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    DeptID = Convert.ToInt32(row.Cells[0].Value.ToString());
                    cmbDepartment.SelectedValue = row.Cells[1].Value?.ToString();
                    cmbworkfield.SelectedValue = row.Cells[2].Value?.ToString();
                    cmbemployee1.SelectedValue = row.Cells[3].Value?.ToString();


                }

            }

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            FrmDeptNew frmDeptNew = new FrmDeptNew();
            // this.Hide();
            frmDeptNew.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmNewWorkLoc frmNewWork = new FrmNewWorkLoc();
            // this.Hide();
            frmNewWork.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            FrmDocShow frmDocShow = new FrmDocShow();
            // this.Hide();
            frmDocShow.Show();
        }

        private void Companiestap_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        

        private void cmbemployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbemployee.DroppedDown = false;

        }

        private void cmbemployee2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbemployee2.DroppedDown = false;

        }

        private void cmbDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbDepartment.DroppedDown = false;

        }

       

      
        private void button26_Click(object sender, EventArgs e)
        {
            button28.Visible = true;
            button27.Visible = button25.Visible = false;


        }


        private void button20_Click(object sender, EventArgs e)
        {
            button23.Visible = true;

        }

        private void button28_Click(object sender, EventArgs e)
        {
            SqlParameter paramtxtcountryname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramtxtcountryname.Value = txtcontname.Text;
            SqlParameter paramnationality = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramnationality.Value = txtnationname.Text;


            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;



            if (txtcontname.Text != "" && txtnationname.Text != "")
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader(@" SELECT 
      [CountryName] ,[NationalityName]  FROM [DelmonGroupDB].[dbo].[Countries] where  CountryName=  @C1 and  NationalityName =  @C2 ", paramtxtcountryname, paramnationality);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Country'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    dr.Dispose();
                    dr.Close();



                    SQLCONN.ExecuteQueries("insert into Countries ([CountryName] ,[NationalityName]) values (@C1,@C2)",
                                                paramtxtcountryname, paramnationality);
                    MessageBox.Show("Record saved Successfully. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dr.Dispose();
                    dr.Close();





                    dataGridView8.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT TOP 1
    [CountryId],
    [CountryName],
    [NationalityName]
FROM 
    [DelmonGroupDB].[dbo].[Countries]
ORDER BY 
    [CountryId] DESC");

                    // SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Country Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramjobid, paramdatetimeLOG, parampc, paramuser);



                    ClearTextBoxes();
                    BtnnewJob.Visible = true;


                }

            }
            else
            {
                MessageBox.Show("Please Fill the missing fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            SQLCONN.CloseConnection();
        }

        private void txtcontname_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramCountrSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramCountrSearch.Value = txtcontname.Text;
            SQLCONN.OpenConection();
            dataGridView8.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  [Countries] where  (CountryName like '%' + @C1 + '%')  OR (NationalityName LIKE '%' + @C1 + '%')  ", paramCountrSearch);
            SQLCONN.CloseConnection();

        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button28.Visible = false;
            button25.Visible = button26.Visible = button27.Visible = true;

            if (e.RowIndex == -1) return;


            if (e.RowIndex >= 0 && e.RowIndex < dataGridView8.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView8.Columns.Count)
            {
                DataGridViewRow row = dataGridView8.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {
                    countryID = Convert.ToInt32(row.Cells[0].Value.ToString());
                    txtcontname.Text = row.Cells[1].Value?.ToString();
                    txtnationname.Text = row.Cells[2].Value?.ToString();
                }

            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            SqlParameter paramtxtcountryname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramtxtcountryname.Value = txtcontname.Text;
            SqlParameter paramnationality = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramnationality.Value = txtnationname.Text;
            SqlParameter paramCountryID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramCountryID.Value = countryID;


            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;


            if (countryID != 0)
            {


                if (txtcontname.Text != "" && txtnationname.Text != "")
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        SQLCONN.OpenConection();

                        // MessageBox.Show(EMPID.ToString());

                        /**logtable */
                        DataTable originalData = new DataTable();
                        string connectionString = SQLCONN.ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [Countries] WHERE [CountryId] = @id";
                            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                            da.SelectCommand.Parameters.AddWithValue("@id", countryID);
                            originalData = new DataTable();
                            da.Fill(originalData);
                        }


                        //   paramEmployeeID.Value = CurrentEmployeeIDtxt.Text;



                        SQLCONN.ExecuteQueries("update Countries set CountryName =@C1,NationalityName=@C2 where CountryId=@id  ", paramtxtcountryname, paramnationality, paramCountryID);
                        MessageBox.Show("Record upddated Successfully. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        dataGridView8.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT TOP 1
    [CountryId],
    [CountryName],
    [NationalityName]
FROM 
    [DelmonGroupDB].[dbo].[Countries]
ORDER BY 
    [CountryId] DESC");


                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [Countries] WHERE [CountryId] = @id";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                            adapter.SelectCommand.Parameters.AddWithValue("@id", countryID);
                            DataTable updatedData = new DataTable();
                            adapter.Fill(updatedData);

                            // Compare the two DataTables and find the changed columns
                            List<string> changedColumns = new List<string>();
                            foreach (DataColumn column in originalData.Columns)
                            {
                                object originalValue = originalData.Rows[0][column.ColumnName];
                                object updatedValue = updatedData.Rows[0][column.ColumnName];
                                if (!Equals(originalValue, updatedValue) && (originalValue != null || updatedData != null))
                                {
                                    changedColumns.Add(column.ColumnName);
                                }
                            }

                            // Insert the changes into the log table
                            if (changedColumns.Count > 0)
                            {
                                using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeId, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                                {
                                    command.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                                    foreach (string columnName in changedColumns)
                                    {
                                        object originalValue = originalData.Rows[0][columnName];
                                        object updatedValue = updatedData.Rows[0][columnName];
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@EmployeeId", "For Countries : " + "-" + countryID);
                                        command.Parameters.AddWithValue("@ColumnName", columnName);
                                        command.Parameters.AddWithValue("@OldValue", originalValue);
                                        command.Parameters.AddWithValue("@NewValue", updatedValue);
                                        command.Parameters.AddWithValue("@datetime", lbldatetime.Text);
                                        command.Parameters.AddWithValue("@pc", lblPC.Text);
                                        command.Parameters.AddWithValue("@user", lblusername.Text);
                                        command.Parameters.AddWithValue("@type", "Update");
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }



                        /**logtable*/


                        tabControl1.Enabled = true;
                        SQLCONN.CloseConnection();
                    }

                }

                else
                {
                    MessageBox.Show("Please Fill the missing fields " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select Country first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SQLCONN.CloseConnection();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;
            SqlParameter paramCountryID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramCountryID.Value = countryID;

            if (countryID == 0)
            {
                MessageBox.Show("Please select Country first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to perform this operation? Please keep in mind all consulates that are related to the requested country will be deleted. ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete Countries where CountryId=@id", paramCountryID);
                    SQLCONN.ExecuteQueries("delete  Consulates where CountryId=@id  ", paramCountryID);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([CountryId]) from [Countries] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[Countries]', RESEED, @max)");
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max(ConsulateID) from[Consulates] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[Consulates]', RESEED, @max)");
                    dataGridView8.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Countries ");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Country',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramCountryID, paramdatetimeLOG, parampc, paramuser);
                    SQLCONN.CloseConnection();



                }

            }
        }

        private void txtconsulatcity_TextChanged(object sender, EventArgs e)
        {

            SqlParameter paramCounslSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramCounslSearch.Value = txtconsulatcity.Text;
            SQLCONN.OpenConection();
            dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  [Consulates] where  (ConsulateCity like '%' + @C1 + '%')   ", paramCounslSearch);
            SQLCONN.CloseConnection();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SqlParameter paramcmbcountryname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcmbcountryname.Value = cmbcont.SelectedValue;
            SqlParameter paramnconsulate = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramnconsulate.Value = txtconsulatcity.Text;


            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;



            if ((int)cmbcont.SelectedValue != 0 & txtconsulatcity.Text != "")
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader(@" SELECT 
    [ConsulateID],ConsulateCity FROM [DelmonGroupDB].[dbo].[Consulates] where  Countryid=  @C1 and  ConsulateCity =  @C2 ", paramcmbcountryname, paramnconsulate);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Consulate'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    dr.Dispose();
                    dr.Close();



                    SQLCONN.ExecuteQueries("insert into Consulates ( [CountryId],[ConsulateCity]) values (@C1,@C2)",
                                               paramcmbcountryname, paramnconsulate);
                    MessageBox.Show("Record saved Successfully. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dr.Dispose();
                    dr.Close();





                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT TOP 1
    [ConsulateID],ConsulateCity,CountryId FROM [DelmonGroupDB].[dbo].[Consulates] 
ORDER BY 
    [ConsulateID] DESC");

                    // SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Country Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramjobid, paramdatetimeLOG, parampc, paramuser);



                    ClearTextBoxes();
                    BtnnewJob.Visible = true;


                }

            }
            else
            {
                MessageBox.Show("Please Fill the missing fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            SQLCONN.CloseConnection();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SqlParameter paramcmbcountryname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramcmbcountryname.Value = cmbcont.SelectedValue;
            countryID = (int)cmbcont.SelectedValue;
            SqlParameter paramnconsulate = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramnconsulate.Value = txtconsulatcity.Text;
            SqlParameter paramnconsulateID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramnconsulateID.Value = CounslateID;


            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;
            if (countryID != 0)
            {


                if (cmbcont.Text != "" && txtconsulatcity.Text != "")
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        SQLCONN.OpenConection();

                        // MessageBox.Show(EMPID.ToString());

                        /**logtable */
                        DataTable originalData = new DataTable();
                        string connectionString = SQLCONN.ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [Consulates] WHERE [ConsulateID] = @id";
                            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                            da.SelectCommand.Parameters.AddWithValue("@id", CounslateID);
                            originalData = new DataTable();
                            da.Fill(originalData);
                        }


                        //   paramEmployeeID.Value = CurrentEmployeeIDtxt.Text;

                        //                  SELECT TOP(5000) [ConsulateID]
                        //,[ConsulateCity]
                        //,[CountryId]
                        //                  FROM[DelmonGroupDB].[dbo].[Consulates]

                        SQLCONN.ExecuteQueries("update Consulates set CountryId =@C1,ConsulateCity=@C2 where ConsulateID=@id  ", paramcmbcountryname, paramnconsulate, paramnconsulateID);
                        MessageBox.Show("Record upddated Successfully. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT TOP 1
    [ConsulateID],
    [ConsulateCity],
    [CountryId]
FROM 
    [DelmonGroupDB].[dbo].[Consulates]
ORDER BY 
    [ConsulateID] DESC");


                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM [Consulates] WHERE [ConsulateID] = @id";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                            adapter.SelectCommand.Parameters.AddWithValue("@id", CounslateID);
                            DataTable updatedData = new DataTable();
                            adapter.Fill(updatedData);

                            // Compare the two DataTables and find the changed columns
                            List<string> changedColumns = new List<string>();
                            foreach (DataColumn column in originalData.Columns)
                            {
                                object originalValue = originalData.Rows[0][column.ColumnName];
                                object updatedValue = updatedData.Rows[0][column.ColumnName];
                                if (!Equals(originalValue, updatedValue) && (originalValue != null || updatedData != null))
                                {
                                    changedColumns.Add(column.ColumnName);
                                }
                            }

                            // Insert the changes into the log table
                            if (changedColumns.Count > 0)
                            {
                                using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeId, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                                {
                                    command.Parameters.AddWithValue("@EmployeeId", EmployeeID);
                                    foreach (string columnName in changedColumns)
                                    {
                                        object originalValue = originalData.Rows[0][columnName];
                                        object updatedValue = updatedData.Rows[0][columnName];
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@EmployeeId", "For Consulates : " + "-" + CounslateID);
                                        command.Parameters.AddWithValue("@ColumnName", columnName);
                                        command.Parameters.AddWithValue("@OldValue", originalValue);
                                        command.Parameters.AddWithValue("@NewValue", updatedValue);
                                        command.Parameters.AddWithValue("@datetime", lbldatetime.Text);
                                        command.Parameters.AddWithValue("@pc", lblPC.Text);
                                        command.Parameters.AddWithValue("@user", lblusername.Text);
                                        command.Parameters.AddWithValue("@type", "Update");
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }



                        /**logtable*/


                        tabControl1.Enabled = true;
                        SQLCONN.CloseConnection();
                    }

                }

                else
                {
                    MessageBox.Show("Please Fill the missing fields " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select Consulate/Country first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SQLCONN.CloseConnection();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button23.Visible = false;
            button20.Visible = button21.Visible = button22.Visible = true;

            if (e.RowIndex == -1) return;


            if (e.RowIndex >= 0 && e.RowIndex < dataGridView5.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView5.Columns.Count)
            {
                DataGridViewRow row = dataGridView5.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {
                    CounslateID = Convert.ToInt32(row.Cells[0].Value.ToString());
                    txtconsulatcity.Text = row.Cells[1].Value?.ToString();
                    cmbcont.SelectedValue = Convert.ToInt32(row.Cells[2].Value?.ToString());
                }

            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;
            SqlParameter paramnconsulateID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramnconsulateID.Value = CounslateID;

            if (CounslateID == 0)
            {
                MessageBox.Show("Please select Consulate first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to perform this operation?. ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {



                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete Consulates where ConsulateID=@id", paramnconsulateID);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([ConsulateID]) from [Consulates] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[Consulates]', RESEED, @max)");
                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Consulates ");
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Country',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramnconsulateID, paramdatetimeLOG, parampc, paramuser);
                    SQLCONN.CloseConnection();
                    txtconsulatcity.Text = "";
                    cmbcont.Text = "Select";



                }

            }
        }



        private void UpdatePermissions()
        {
           
                // Retrieve userID from ComboBox
                int userID = Convert.ToInt32(cmbUserPermission.SelectedValue);

                // Prepare SQL connection and open it
                SQLCONN.OpenConection();

                // List of permission checkboxes and their corresponding permission IDs
                var permissions = new Dictionary<CheckBox, int>
        {
            { ViewCountriesTabx, 39 },
            { AddCountriesTabx, 40 },
            { EditCountriesTabx, 41 },
            { DeleteCountriesTabx, 42 },
            { ViewCompaniesTabx, 35 },
            { AddCompaniesTabx, 36 },
            { EditCompaniesTabx, 37 },
            { DeleteCompaniesTabx, 38 },
            { ViewJobTabx, 27 },
            { AddJobTabx, 28 },
            { editJobTabx, 29 },
            { DeleteJobTabx, 30 },
            { ViewUserTabx, 23 },
            { AddUserTabx, 24 },
            { EditUserTabx, 25 },
            { DeleteUserTabx, 26 },
            { ViewAlertsbx, 19 },
            { AddAlertsbx, 20 },
            { EditAlertsbx, 21 },
            { DeleteAlertsBx, 22 },
            { ViewAssetsbx, 15 },
            { AddAssetsbx, 16 },
            { EditAssetsbx, 17 },
            { DeleteAssetsbx, 18 },
            { ViewBillsbx, 11 },
            { AddBillsbx, 12 },
            { EditBillsbx, 13 },
            { DeleteBillsbx, 14 },
            { ViewCandidatesReportbx, 10 },
            { ViewVisaReportbx, 9 },
            { ViewAssetReportbx, 43 },
            { ViewPersonalInformationbx, 5 },
            { AddPersonalInformationbx, 6 },
            { EditPersonalInformationbx, 7 },
            { DeletePersonalInformationbx, 8 },
            { ViewVisabx, 1 },
            { AddVisabx, 2 },
            { EditVisabx, 3 },
            { DeleteVisabx, 4 },
            { ViewAgenciesTabx, 31 },
            { AddAgenciesTabx, 32 },
            { EditAgenciesTabx, 33 },
            { DeleteAgenciesTabx, 34 },
            { ViewEmployeelogs, 44 }
        };

                foreach (var permission in permissions)
                {
                    CheckBox checkbox = permission.Key;
                    int permissionID = permission.Value;

                    SqlDataReader dr = null; // Initialize dr to null

                    try
                    {
                        // Check if the checkbox is checked
                        if (checkbox.Checked)
                        {
                            // Check if the permission already exists
                            string checkQuery = "SELECT * FROM [UserPermissions] WHERE UserID = @UserID AND PermissionID = @PermissionID";
                            SqlParameter[] checkParams = new SqlParameter[]
                            {
                        new SqlParameter("@UserID", SqlDbType.Int) { Value = userID },
                        new SqlParameter("@PermissionID", SqlDbType.Int) { Value = permissionID }
                            };

                            // Execute the query to check if the permission exists
                            dr = SQLCONN.DataReader(checkQuery, checkParams);

                            if (!dr.HasRows)
                            {
                                dr.Dispose();
                                dr.Close();
                                // Insert the new permission
                                string insertQuery = "INSERT INTO [UserPermissions] (UserID, PermissionID) VALUES (@UserID, @PermissionID)";
                                SQLCONN.ExecuteQueries(insertQuery, checkParams);
                            }
                        }
                        else
                        {
                            // Delete the permission if it exists
                            string deleteQuery = "DELETE FROM [UserPermissions] WHERE UserID = @UserID AND PermissionID = @PermissionID";
                            SqlParameter[] deleteParams = new SqlParameter[]
                            {
                        new SqlParameter("@UserID", SqlDbType.Int) { Value = userID },
                        new SqlParameter("@PermissionID", SqlDbType.Int) { Value = permissionID }
                            };

                            SQLCONN.ExecuteQueries(deleteQuery, deleteParams);
                        }
                    }
                    finally
                    {
                        if (dr != null)
                        {
                            dr.Dispose();
                            dr.Close();
                        }
                    }
                }

                // Close the SQL connection
                SQLCONN.CloseConnection();

              //  MessageBox.Show("Permissions updated successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void button19_Click(object sender, EventArgs e)
        {
          }

        private void dataGridView10_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == dataGridView10.Columns["Name"].Index && e.Value != null)
            //{
            //    string permission = e.Value.ToString();
            //    Color color = GetGroupColor(permission);
            //    e.CellStyle.BackColor = color;
            //}
        }
        //private Color GetGroupColor(string permission)
        //{
        //    // Define the group keywords and their associated colors
        //    var groupColors = new Dictionary<string, Color>
        //{
        //    { "VisaReport", Color.AliceBlue },
        //    { "CandidatesReport", Color.AliceBlue },
        //    { "AssetsReport", Color.AliceBlue },
        //    { "Visa", Color.LightGreen },
        //    { "PersonalInformation", Color.LightCoral },
        //    { "Bills", Color.LightGoldenrodYellow },
        //    { "Assets", Color.LightPink },
        //    { "Alerts", Color.LightCyan },
        //    { "UserTab", Color.LightSalmon },
        //    { "JobTab", Color.LightSeaGreen },
        //    { "AgenciesTab", Color.LightSlateGray },
        //    { "CompaniesTab", Color.LightSteelBlue },
        //    { "CountriesTab", Color.LightSkyBlue }
        //};

        //    // Specific checks to ensure accurate group color assignment
        //    if (permission.Contains("VisaReport"))
        //    {
        //        return groupColors["VisaReport"];
        //    }
        //    if (permission.Contains("CandidatesReport"))
        //    {
        //        return groupColors["CandidatesReport"];
        //    }

        //    if (permission.Contains("AssetsReport"))
        //    {
        //        return groupColors["AssetsReport"];
        //    }
        //    // General group detection based on the keyword
        //    foreach (var group in groupColors)
        //    {
        //        if (permission.Contains(group.Key) && !permission.Contains("Report"))
        //        {
        //            return groupColors[group.Key];
        //        }
        //    }

        //    // Default color if no group matches
        //    return Color.White;
        //}
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
           // ValidatePermissions();
            UpdatePermissions(); // Call the UpdatePermissions() method whenever a checkbox state changes

        }

      

      

   
        private void ToggleCheckBoxState(string permissionName)
        {
            switch (permissionName)
            {
                case "ViewVisa":
                    ViewVisabx.Checked = !ViewVisabx.Checked;
                    break;
                case "AddVisa":
                    AddVisabx.Checked = !AddVisabx.Checked;
                    break;
                case "EditVisa":
                    EditVisabx.Checked = !EditVisabx.Checked;
                    break;
                case "DeleteVisa":
                    DeleteVisabx.Checked = !DeleteVisabx.Checked;
                    break;
                case "ViewPersonalInformation":
                    ViewPersonalInformationbx.Checked = !ViewPersonalInformationbx.Checked;
                    break;
                case "AddPersonalInformation":
                    AddPersonalInformationbx.Checked = !AddPersonalInformationbx.Checked;
                    break;
                case "EditPersonalInformation":
                    EditPersonalInformationbx.Checked = !EditPersonalInformationbx.Checked;
                    break;
                case "DeletePersonalInformation":
                    DeletePersonalInformationbx.Checked = !DeletePersonalInformationbx.Checked;
                    break;
                case "ViewVisaReport":
                    ViewVisaReportbx.Checked = !ViewVisaReportbx.Checked;
                    break;
                case "ViewCandidatesReport":
                    ViewCandidatesReportbx.Checked = !ViewCandidatesReportbx.Checked;
                    break;
                case "ViewAssetsReport":
                    ViewAssetReportbx.Checked = !ViewAssetReportbx.Checked;
                    break;
                case "ViewAssets":
                    ViewAssetsbx.Checked = !ViewAssetsbx.Checked;
                    break;
                case "AddAssets":
                    AddAssetsbx.Checked = !AddAssetsbx.Checked;
                    break;
                case "EditAssets":
                    EditAssetsbx.Checked = !EditAssetsbx.Checked;
                    break;
                case "DeleteAssets":
                    DeleteAssetsbx.Checked = !DeleteAssetsbx.Checked;
                    break;
                case "ViewUserTab":
                    ViewUserTabx.Checked = !ViewUserTabx.Checked;
                    break;
                case "AddUserTab":
                    AddUserTabx.Checked = !AddUserTabx.Checked;
                    break;
                case "EditUserTab":
                    EditUserTabx.Checked = !EditUserTabx.Checked;
                    break;
                case "DeleteUserTab":
                    DeleteUserTabx.Checked = !DeleteUserTabx.Checked;
                    break;
                case "ViewJobTab":
                    ViewJobTabx.Checked = !ViewJobTabx.Checked;
                    break;
                case "AddJobTab":
                    AddJobTabx.Checked = !AddJobTabx.Checked;
                    break;
                case "EditJobTab":
                    editJobTabx.Checked = !editJobTabx.Checked;
                    break;
                case "DeleteJobTab":
                    DeleteJobTabx.Checked = !DeleteJobTabx.Checked;
                    break;
                case "ViewAgenciesTab":
                    ViewAgenciesTabx.Checked = !ViewAgenciesTabx.Checked;
                    break;
                case "AddAgenciesTab":
                    AddAgenciesTabx.Checked = !AddAgenciesTabx.Checked;
                    break;
                case "EditAgenciesTab":
                    EditAgenciesTabx.Checked = !EditAgenciesTabx.Checked;
                    break;
                case "DeleteAgenciesTab":
                    DeleteAgenciesTabx.Checked = !DeleteAgenciesTabx.Checked;
                    break;
                case "ViewCompaniesTab":
                    ViewCompaniesTabx.Checked = !ViewCompaniesTabx.Checked;
                    break;
                case "AddCompaniesTab":
                    AddCompaniesTabx.Checked = !AddCompaniesTabx.Checked;
                    break;
                case "EditCompaniesTab":
                    EditCompaniesTabx.Checked = !EditCompaniesTabx.Checked;
                    break;
                case "DeleteCompaniesTab":
                    DeleteCompaniesTabx.Checked = !DeleteCompaniesTabx.Checked;
                    break;
                case "ViewCountriesTab":
                    ViewCountriesTabx.Checked = !ViewCountriesTabx.Checked;
                    break;
                case "AddCountriesTab":
                    AddCountriesTabx.Checked = !AddCountriesTabx.Checked;
                    break;
                case "EditCountriesTab":
                    EditCountriesTabx.Checked = !EditCountriesTabx.Checked;
                    break;
                case "DeleteCountriesTab":
                    DeleteCountriesTabx.Checked = !DeleteCountriesTabx.Checked;
                    break;
                case "ViewEmployeelogs":
                    ViewEmployeelogs.Checked = !ViewEmployeelogs.Checked;
                    break;
                default:
                    MessageBox.Show($"Permission '{permissionName}' not recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }



        private void cmbUserPermission_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(cmbUserPermission.SelectedValue);

            // Prepare SQL parameters
            SqlParameter paramUser = new SqlParameter("@C1", SqlDbType.Int) { Value = userID };

            // Retrieve the data from the database
            DataTable dataTable = (DataTable)SQLCONN.ShowDataInGridViewORCombobox(@"
        SELECT us.PermissionID
        FROM [DelmonGroupDB].[dbo].[UserPermissions] as us
        WHERE us.UserID = @C1", paramUser);

            // Clear all checkboxes
            var permissions = new List<CheckBox>
    {
        ViewCountriesTabx,
        AddCountriesTabx,
        EditCountriesTabx,
        DeleteCountriesTabx,
        ViewCompaniesTabx,
        AddCompaniesTabx,
        EditCompaniesTabx,
        DeleteCompaniesTabx,
        ViewJobTabx,
        AddJobTabx,
        editJobTabx,
        DeleteJobTabx,
        ViewUserTabx,
        AddUserTabx,
        EditUserTabx,
        DeleteUserTabx,
        ViewAlertsbx,
        AddAlertsbx,
        EditAlertsbx,
        DeleteAlertsBx,
        ViewAssetsbx,
        AddAssetsbx,
        EditAssetsbx,
        DeleteAssetsbx,
        ViewBillsbx,
        AddBillsbx,
        EditBillsbx,
        DeleteBillsbx,
        ViewCandidatesReportbx,
        ViewVisaReportbx,
        ViewAssetReportbx,
        ViewPersonalInformationbx,
        AddPersonalInformationbx,
        EditPersonalInformationbx,
        DeletePersonalInformationbx,
        ViewVisabx,
        AddVisabx,
        EditVisabx,
        DeleteVisabx,
        ViewAgenciesTabx,
        AddAgenciesTabx,
        EditAgenciesTabx,
        DeleteAgenciesTabx,
        ViewEmployeelogs
    };

            // Uncheck all checkboxes initially
            foreach (var checkbox in permissions)
            {
                checkbox.Checked = false;
            }

            // Check checkboxes based on the retrieved data
            foreach (DataRow row in dataTable.Rows)
            {
                int permissionID = row.Field<int>("PermissionID");

                // Find the corresponding checkbox and check it
                var checkbox = permissions.FirstOrDefault(cb => (int)cb.Tag == permissionID);
                if (checkbox != null)
                {
                    checkbox.Checked = true;
                }
            }
        }

        private void ViewCandidatesReportbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button19.Visible = button18.Visible = button24.Visible = true;
            SQLCONN.OpenConection();
         
            if (e.RowIndex == -1) return;


            if (e.RowIndex >= 0 && e.RowIndex < dataGridView4.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView2.Columns.Count)
            {
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {
                    contactID = Convert.ToInt32(row.Cells[0].Value.ToString());
                    agaencyid = Convert.ToInt32(row.Cells[1].Value.ToString());
                    cmbcontact.Text = row.Cells[2].Value?.ToString();
                    Contacttxt.Text = row.Cells[3].Value?.ToString();
                   
                }

            }
           // dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + agaencyid + " ");


            SQLCONN.CloseConnection();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (cmbUserPermission.Text == "Select")
            {
                MessageBox.Show("Please select a User first.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userID = Convert.ToInt32(cmbUserPermission.SelectedValue);
            SqlParameter paramUserpermission = new SqlParameter("@C0", SqlDbType.Int) { Value = userpermissionID };

            // Confirm the operation
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                string deleteQuery = "DELETE FROM [DelmonGroupDB].[dbo].[UserPermissions] WHERE UserPermissionID = @C0";

                // Execute the delete query
                SQLCONN.OpenConection();
                SQLCONN.ExecuteQueries(deleteQuery, paramUserpermission);
                SQLCONN.CloseConnection();

                MessageBox.Show("Record deleted successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox)
                    {
                        ((CheckBox)control).Checked = false;
                    }
                }
              

            }

        }

       

     
      


      

        private void button24_Click(object sender, EventArgs e)
        {
            SqlParameter paramContactType = new SqlParameter("@C1", SqlDbType.Int);
            paramContactType.Value = cmbcontact.SelectedValue;
            SqlParameter paramContact = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramContact.Value = Contacttxt.Text;
            SqlParameter paramRefrenceID = new SqlParameter("@C3", SqlDbType.Int);
            paramRefrenceID.Value = 3;
            SqlParameter paramPID = new SqlParameter("@C4", SqlDbType.Int);
            paramPID.Value = agaencyid;

            if (agaencyid != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    SQLCONN.OpenConection();
                    if ((int)cmbcontact.SelectedValue == 2)
                    {
                        if (validate_emailaddress.IsMatch(Contacttxt.Text) != true)
                        {
                            MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Contacttxt.Focus();
                            return;
                        }
                        else
                        {
                        }
                    }
                    SqlDataReader dr = SQLCONN.DataReader("select  ContValue from Contacts where  ContValue= @C2  ", paramContact);
                    dr.Read();

                    if (dr.HasRows)
                    {
                        dr.Dispose();
                        dr.Close();
                        MessageBox.Show("Contact Value already there, kindly check again.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }

                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        SQLCONN.ExecuteQueries("insert into Contacts ( ContTypeID,ContValue,RefrenceID,CR_ID) values (@C1,@C2,@C3,@C4)",
                                                       paramContactType, paramContact, paramRefrenceID, paramPID);
                        MessageBox.Show("Record saved Successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID] ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + agaencyid + " ");
                        Contacttxt.Text = "";
                        cmbcontact.Text = "Select";
                        SQLCONN.CloseConnection();

                    }
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record !");

            }

            paramPID.Value = EmployeeID;
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            SqlParameter paramContactType = new SqlParameter("@C1", SqlDbType.Int);
            paramContactType.Value = cmbcontact.SelectedValue;
            SqlParameter paramContact = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramContact.Value = Contacttxt.Text;
            SqlParameter paramRefrenceID = new SqlParameter("@C3", SqlDbType.Int);
            paramRefrenceID.Value = 3;
            SqlParameter paramPID = new SqlParameter("@C4", SqlDbType.Int);
            paramPID.Value = contactID;

            string userInput = Contacttxt.Text;
            if (decimal.TryParse(userInput, out decimal inputValue)) // Try to parse input as decimal
            {
                string formattedValue = inputValue.ToString("N2"); // Format decimal as string with 2 decimal places and thousands separator
                Contacttxt.Text = formattedValue; // Set the second text box to the formatted value
            }


            if (contactID != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    SQLCONN.OpenConection();

                    SQLCONN.ExecuteQueries("update  Contacts set ContTypeID=@C1,ContValue=@C2 where Contact_ID=@C4",
                                                           paramContactType, paramContact, paramPID);
                    MessageBox.Show("Record Updated Successfully");

                  
                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID]  FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + agaencyid + " ");
                    // ClearTextBoxes();
                    Contacttxt.Text = "";
                    cmbcontact.Text = "Select";
                    SQLCONN.CloseConnection();

                }
                else
                {

                }


            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
            paramPID.Value = EmployeeID;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            SqlParameter paramPID = new SqlParameter("@ID", SqlDbType.Int);
            paramPID.Value = contactID;
            if (contactID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from Contacts where Contact_ID=@ID", paramPID);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max(Contact_ID) from[Contacts] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[Contacts]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");


                    SQLCONN.CloseConnection();
                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + EmployeeID + " ");
                    Contacttxt.Text = "";
                    cmbcontact.Text = "Select";
                    //    ClearTextBoxes();



                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void cmbcontact_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Contacttxt.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ViewVisabx_CheckedChanged(object sender, EventArgs e)
        {

        }
        //SELECT*
        //    FROM EmployeeLog
        //    WHERE CONVERT(DATETIME, LogDatetime, 120) BETWEEN CONVERT(DATETIME, @C1, 120) AND CONVERT(DATETIME, @C2, 120)
        //    and UserID = @C0";
        private void button30_Click(object sender, EventArgs e)
        {
            // Open the database connection
            SQLCONN.OpenConection();

            // Create the SQL parameters
            SqlParameter ParamUserLog = new SqlParameter("@C0", SqlDbType.NVarChar) { Value = cmbUserLog.Text.Trim() };
            SqlParameter ParamFrom = new SqlParameter("@C1", SqlDbType.Date) { Value = dateTimePicker1.Value };
            SqlParameter ParamTo = new SqlParameter("@C2", SqlDbType.Date) { Value = dateTimePicker2.Value };
            SqlParameter ParamScreen = new SqlParameter("@C3", SqlDbType.NVarChar) { Value = cmbsection.Text?.ToString() };

            // Ensure a radio button is selected
            if (!allrb.Checked && !insertrb.Checked && !updaterb.Checked && !deleterb.Checked)
            {
                MessageBox.Show("Kindly select one of the Radio buttons! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a user is selected if needed
            if ((allrb.Checked || insertrb.Checked || updaterb.Checked || deleterb.Checked) && cmbUserLog.Text == "Select")
            {
                MessageBox.Show("Kindly select one of users", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build the base query
            string baseQuery = @"SELECT * FROM EmployeeLog WHERE CONVERT(DATE, LogDatetime, 120) BETWEEN @C1 AND @C2";

            // Add the screen filter if selected
            if (!string.IsNullOrEmpty(ParamScreen.Value.ToString()) && cmbsection.Text != "Select")
            {
                baseQuery += " AND LogValueID LIKE '%' + @C3 + '%'";
            }

            // Append additional conditions based on selected radio buttons
            if (allrb.Checked)
            {
                baseQuery += " AND Userid=@C0 ";
            }
            else if (insertrb.Checked)
            {
                baseQuery += " AND Userid=@C0 AND Type='Insert' ";
            }
            else if (updaterb.Checked)
            {
                baseQuery += " AND Userid=@C0 AND Type='Update'";
            }
            else if (deleterb.Checked)
            {
                baseQuery += " AND Userid=@C0 AND Type='Delete'";
            }

            // Prepare the parameters based on the selected radio button
            List<SqlParameter> parameters = new List<SqlParameter> { ParamFrom, ParamTo };

            if (!allrb.Checked || !string.IsNullOrEmpty(ParamUserLog.Value.ToString()))
            {
                parameters.Add(ParamUserLog);
            }

            if (!string.IsNullOrEmpty(ParamScreen.Value.ToString()));
            {
                parameters.Add(ParamScreen);
            }

            // Execute the query and populate the DataGridView
            dataGridView9.DataSource = SQLCONN.ShowDataInGridViewORCombobox(baseQuery, parameters.ToArray());

            // Adjust DataGridView settings and add total row if applicable
            // AdjustDataGridView();

            // Close the database connection
            SQLCONN.CloseConnection();
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

        private void button29_Click(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets.Add("Report");

                ExportDataGridViewToExcel(dataGridView9, worksheet1);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save as Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    package.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                }
            }
        }

        private void cmbcont_TextChanged(object sender, EventArgs e)
        {
            if (originalDataCountry != null)
            {
                cmbcont.DataSource = originalDataCountry;
                cmbcont.ValueMember = "CountryId";
                cmbcont.DisplayMember = "CountryName";
            }
        }

        private void cmbworkfield_TextChanged(object sender, EventArgs e)
        {
            if (originalDataWorkField != null)
            {
                cmbworkfield.DataSource = originalDataWorkField;
                cmbworkfield.ValueMember = "WorkID";
                cmbworkfield.DisplayMember = "Name";
            }
        }

        private void cmbDepartment_TextChanged(object sender, EventArgs e)
        {
            if (originalDataDepartment != null)
            {
                cmbDepartment.DataSource = originalDataDepartment;
                cmbDepartment.ValueMember = "Dept_Type_ID";
                cmbDepartment.DisplayMember = "Dept_Type_Name";
            }
        }

        private void cmbemployee1_TextChanged(object sender, EventArgs e)
        {

            // Simple debugging log to see when this event gets triggered

            // This is just to check if the ComboBox is working without filtering
            if (originalDataHeadOFDepartment != null)
            {
                // Set DataSource to original data to check for any issues
                cmbemployee1.DataSource = originalDataHeadOFDepartment;
                cmbemployee1.ValueMember = "EmployeeID";
                cmbemployee1.DisplayMember = "FullName";
            }
        }

        private void cmbemployee2_TextChanged(object sender, EventArgs e)
        {
            // Simple debugging log to see when this event gets triggered

            // This is just to check if the ComboBox is working without filtering
            if (originalDataGeneralManager != null)
            {
                // Set DataSource to original data to check for any issues
                cmbemployee2.DataSource = originalDataGeneralManager;
                cmbemployee2.ValueMember = "EmployeeID";
                cmbemployee2.DisplayMember = "FullName";
            }
        }

        private void cmbemployee_TextChanged(object sender, EventArgs e)
        {
            // Simple debugging log to see when this event gets triggered

            // This is just to check if the ComboBox is working without filtering
            if (originalDataEmployee != null)
            {
                // Set DataSource to original data to check for any issues
                cmbemployee.DataSource = originalDataEmployee;
                cmbemployee.ValueMember = "EmployeeID";
                cmbemployee.DisplayMember = "FullName";
            }
        }

        private void maxtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // suppress the key press event
                MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Cast the sender to a RadioButton
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                // Get the parent group box
                GroupBox parentGroupBox = radioButton.Parent as GroupBox;

                if (parentGroupBox != null)
                {
                    // Determine the action based on the radio button's text
                    bool check = radioButton.Text == "Select All";

                    // Iterate through the controls of the group box
                    foreach (Control control in parentGroupBox.Controls)
                    {
                        // Check or uncheck all checkboxes
                        if (control is CheckBox checkBox)
                        {
                            checkBox.Checked = check;
                        }
                    }
                }
            }
        }
    }
    }





    

