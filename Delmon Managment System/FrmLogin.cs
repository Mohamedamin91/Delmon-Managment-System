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

namespace Delmon_Managment_System
{
    public partial class FrmLogin : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        public int PI_ID = 0;
        public string UserType ;
        public string UserName;
        public string Email ;

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

        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramUserName = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramUserName.Value = Usertxt.Text;
            SqlParameter paramPassword= new SqlParameter("@C2", SqlDbType.NVarChar);
            paramPassword.Value = passtxt.Text;
            SQLCONN.OpenConection();
            //SqlDataReader dr = SQLCONN.DataReader("select username,pass from tblUser where UserName='" + Usertxt.Text + "'and Password='" + passtxt.Text + "'");
           
            SqlDataReader dr = SQLCONN.DataReader(" select [UserID],[PI_ID],UserType,[Email], UserName,Password from tblUser , tblUserType where tblUser.UserTypeID=tblUserType.UserTypeID and UserName=@C1 and Password=@C2 and IsActive=1", paramUserName,paramPassword );
            if (dr.Read())

            {
                //after successful it will redirect  to next page .
                //saving user info
                PI_ID = int.Parse(dr["PI_ID"].ToString());
                UserType = (dr["UserType"].ToString());
                UserName = (dr["UserName"].ToString());
                Email = (dr["Email"].ToString());

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

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                Usertxt.Text = Properties.Settings.Default.UserName;
                passtxt.Text = Properties.Settings.Default.Password;

            }
        }
    }
}
