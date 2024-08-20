using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Web.Http;

namespace Delmon_Managment_System
{
    public partial class FrmLogin : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        public int EmployeeID = 0;
        public int UserID = 0;
        public int DeptID = 0;
        public string CompName;
        public string UserType;
        public string UserName;
        public string Email;
        public string EmployeeName;
        string encryptionKey = "0pqnU2X00mf+i8mDTzyPVw==", iv = "0pqnU2X00mf+i8mDTzyPVw==";


        //string latestVersionNumber = GetLatestVersionNumber(@"\\MyPC\ShareFolder\version.txt");



        public FrmLogin()
        {
            InitializeComponent();


        }

        private void remembercheck_CheckedChanged(object sender, EventArgs e)
        {
            if (remembercheck.Checked)
            {
                //Delmon_Managment_System.Properties.Settings.Default.UserName = Usertxt.Text;
                //Delmon_Managment_System.Properties.Settings.Default.Password = passtxt.Text;
                //Delmon_Managment_System.Properties.Settings.Default.Save();

            }

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

        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramUserName = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramUserName.Value = Usertxt.Text;
            SqlParameter paramPassword = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramPassword.Value = passtxt.Text;

            // Generate a random encryption key and IV
            string originalValue = passtxt.Text.ToString();
            string encryptedValue = Encrypt(originalValue, encryptionKey, iv);
            paramPassword.Value = encryptedValue;


            SQLCONN.OpenConection();
            //SqlDataReader dr = SQLCONN.DataReader("select username,pass from tblUser where UserName='" + Usertxt.Text + "'and Password='" + passtxt.Text + "'");

            SqlDataReader dr = SQLCONN.DataReader(" select CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) " +
                "AS 'FullName',COMPName_EN,DeptID,tblUser.UserID,tblUser.EmployeeID,UserType,[Email], UserName,Password " +
                "from tblUser,Employees ,[Companies], tblUserType where tblUser.[UserTypeID] =tblUserType.UserTypeID " +
                "and Employees.EmployeeID =tblUser.EmployeeID and [Companies].COMPID= Employees.COMPID " +
                "and  UserName=@C1 and Password=@C2 and IsActive=1;", paramUserName, paramPassword);
            if (dr.Read())

            {
                //after successful it will redirect  to next page .
                //saving user info
                UserID = int.Parse(dr["UserID"].ToString());
                EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                CompName = (dr["COMPName_EN"].ToString());
                DeptID = int.Parse(dr["DeptID"].ToString());

                UserType = (dr["UserType"].ToString());
                UserName = (dr["UserName"].ToString());
                Email = (dr["Email"].ToString());
                EmployeeName = (dr["FullName"].ToString());

                CommonClass.UserID = UserID;
                CommonClass.LoginUserName = UserName;
                CommonClass.Usertype = UserType;
                CommonClass.Email = Email;
                CommonClass.EmployeeID = EmployeeID;
                CommonClass.LoginEmployeeName = EmployeeName;
                CommonClass.CompName = CompName;
                CommonClass.DeptID = DeptID;


                //saving user info
                FormMainMenu mainMenu = new FormMainMenu();

                mainMenu.Show();
                this.Hide();
                if (remembercheck.Checked)
                {
                    Delmon_Managment_System.Properties.Settings.Default.UserName = Usertxt.Text;
                    Delmon_Managment_System.Properties.Settings.Default.Password = passtxt.Text;
                    Delmon_Managment_System.Properties.Settings.Default.Save();

                }
            }


            else
            {
                MessageBox.Show("Please check username and password / Contact administrator to activate your user !", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            SQLCONN.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void BTNcLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

      
    

    private void FrmLogin_Load(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.UserName != string.Empty)
            {
                Usertxt.Text = Properties.Settings.Default.UserName;
                passtxt.Text = Properties.Settings.Default.Password;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

   
    }
}


