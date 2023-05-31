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
    public partial class FrmNewWorkLoc : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int WorkID;


        public FrmNewWorkLoc()
        {
            InitializeComponent();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramWorkID = new SqlParameter("@C1", SqlDbType.NVarChar);
            SqlParameter paramWorkName = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramWorkName.Value = txtWorklocation.Text;


            if (txtWorklocation.Text != "")
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  * from WorkLocations  where " +
                     " Name=@C2", paramWorkName);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Work Location '  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {


                        dr.Dispose();
                        dr.Close();

                        dr = SQLCONN.DataReader("SELECT TOP 1 WorkID FROM WorkLocations Order BY WorkID DESC");
                        if (dr.Read())
                        {
                            WorkID = int.Parse(dr["WorkID"].ToString());
                            WorkID = WorkID + 1;
                        }
                        dr.Dispose();
                        dr.Close();
                        paramWorkID.Value = WorkID;
                        SQLCONN.ExecuteQueries("insert into WorkLocations ([WorkID] ,[Name]) values (@C1,@C2) ",
                                                       paramWorkID, paramWorkName);
                        MessageBox.Show("Record saved Successfully");
                        txtWorklocation.Text = "";


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

        private void FrmNewWorkLoc_Load(object sender, EventArgs e)
        {

        }
    }
}
