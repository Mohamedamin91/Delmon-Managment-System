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
    public partial class FrmDeptNew : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int DeptTypeID;
        SettingFrm settingFrm = new SettingFrm();

        public FrmDeptNew()
        {
            InitializeComponent();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramDeptID = new SqlParameter("@C1", SqlDbType.NVarChar);
            SqlParameter paramDeptTypeName = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramDeptTypeName.Value = txtDepttypeName.Text;
           

            if (txtDepttypeName.Text != "" )
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  * from DeptTypes  where " +
                     " Dept_Type_Name=@C2", paramDeptTypeName);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Department Type'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else {
                      if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                        dr.Dispose();
                        dr.Close();

                        dr = SQLCONN.DataReader("SELECT TOP 1 Dept_Type_ID FROM DeptTypes where Dept_Type_ID < 9000 ORDER BY Dept_Type_ID DESC");
                        if (dr.Read())
                        {
                            DeptTypeID = int.Parse(dr["Dept_Type_ID"].ToString());
                            DeptTypeID = DeptTypeID + 1;
                        }
                        dr.Dispose();
                        dr.Close();
                        paramDeptID.Value = DeptTypeID;
                        SQLCONN.ExecuteQueries("insert into DeptTypes ([Dept_Type_ID] ,[Dept_Type_Name]) values (@C1,@C2) ",
                                                       paramDeptID, paramDeptTypeName);
                           MessageBox.Show("Record saved Successfully");
                        settingFrm.SettingFrm_Load( sender,  e);
                        txtDepttypeName.Text = "";


                        dr.Dispose();
                        dr.Close();

                    }
                }

            }
            else
            {
                MessageBox.Show("Please Fill the missing field  ");

            }
      
            SQLCONN.CloseConnection();
        }

        private void FrmDeptNew_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void FrmDeptNew_Load(object sender, EventArgs e)
        {

        }
    }
}
