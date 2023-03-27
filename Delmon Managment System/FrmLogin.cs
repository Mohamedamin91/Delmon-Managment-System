using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
    public partial class FrmLogin : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        public int EmployeeID = 0;
        public int UserID = 0;
        public int DeptID = 0;
        public string CompName;
        public string UserType ;
        public string UserName;
        public string Email;
        public string EmployeeName;
        string latestVersionNumber = GetLatestVersionNumber(@"\\MyPC\ShareFolder\version.txt");



        public FrmLogin()
        {
            InitializeComponent();
            Font newFont = new Font("Times New Roman", 12);

            // Loop through all controls on the form and change their font properties
            foreach (Control control in Controls)
            {
                control.Font = newFont;
            }
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

        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramUserName = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramUserName.Value = Usertxt.Text;
            SqlParameter paramPassword= new SqlParameter("@C2", SqlDbType.NVarChar);
            paramPassword.Value = passtxt.Text;
            SQLCONN.OpenConection();
            //SqlDataReader dr = SQLCONN.DataReader("select username,pass from tblUser where UserName='" + Usertxt.Text + "'and Password='" + passtxt.Text + "'");
           
            SqlDataReader dr = SQLCONN.DataReader(" select CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) AS 'FullName',COMPName_EN,DeptID,tblUser.UserID,tblUser.EmployeeID,UserType,[Email], UserName,Password from tblUser,Employees ,[Companies], tblUserType where tblUser.[UserTypeID] =tblUserType.UserTypeID and Employees.EmployeeID =tblUser.EmployeeID and [Companies].COMPID= Employees.COMPID and  UserName=@C1 and Password=@C2 and IsActive=1;", paramUserName,paramPassword );
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
                MessageBox.Show("Invalid Login please check username and password");
            }
            SQLCONN.CloseConnection();
        }
        public static string GetLatestVersionNumber(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    return line.Trim();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }

            return "";
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        { //**check version/
            //if (latestVersionNumber != "" && latestVersionNumber != Application.ProductVersion)
            //{
            //    DialogResult dialogResult = MessageBox.Show("An update is available. Please download and install the latest version :)", "Update Available", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        // Download the latest version of the application and install it
            //    }
            //    // Notify user that an update is available
            //    // Provide a download link to the latest version of the application
            //}
            //***check version/
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                Usertxt.Text = Properties.Settings.Default.UserName;
                passtxt.Text = Properties.Settings.Default.Password;
            }
        }
    }
}
