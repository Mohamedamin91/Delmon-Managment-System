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
            SQLCONN.OpenConection();
            SqlDataReader dr = SQLCONN.DataReader("select username,pass from PersonalInformation where username='" + Usertxt.Text + "'and pass='" + passtxt.Text + "'");
            if (dr.HasRows)

            {
                MessageBox.Show("done!");

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
