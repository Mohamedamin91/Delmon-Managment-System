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
    public partial class SettingFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int EmployeeID;

        public SettingFrm()
        {
            InitializeComponent();
        }

        private void SettingFrm_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            timer1.Start(); 
            LoadTheme();
            lblusername.Text = CommonClass.LoginUserName;
            lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
            lblPC.Text = Environment.MachineName;
            SQLCONN.OpenConection();
            cmbemployee.ValueMember = "EmployeeID";
            cmbemployee.DisplayMember = "FullName";
            cmbemployee.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            cmbemployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbusertype.ValueMember = "UserTypeID";
            cmbusertype.DisplayMember = "UserType";
            cmbusertype.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT UserTypeID,UserType  from [tblUserType] ");
            cmbusertype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbusertype.AutoCompleteSource = AutoCompleteSource.ListItems;

            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
                (" SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive from Employees,tblUserType ,tblUser  where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID    ");

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



            if ((int)cmbemployee.SelectedValue != 0  && usernametxt.Text != "" && passwordtxt.Text != "")
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  * from tblUser  where " +
                     " EmployeeID=  @C1 and  UserName =  @C2 ", paramemployee, paramusername);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'User'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    dr.Dispose();
                    dr.Close();
                    if (isactivecheck.Checked)
                    {
                        SQLCONN.ExecuteQueries("insert into tblUser ( [EmployeeID] ,[UserName],[Password],[UserTypeID],[IsActive]) values (@C1,@C2,@C3,@C4,1)",
                                                 paramemployee, paramusername, parampassword, paramusertype, paramisActive);

                    }
                    else 
                    {
                        SQLCONN.ExecuteQueries("insert into tblUser ( [EmployeeID] ,[UserName],[Password],[UserTypeID],[IsActive]) values (@C1,@C2,@C3,@C4,0)",
                                                   paramemployee, paramusername, parampassword, paramusertype, paramisActive);

                    }

                    MessageBox.Show("Record saved Successfully");
                    cmbusertype.Text=cmbemployee.Text="Select";
                    usernametxt.Text = passwordtxt.Text = "";
                    isactivecheck.Checked = false;
                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@id ,'#','#',@datetime,@pc,@user,'Insert')", paramPID, paramdatetimeLOG, parampc, paramuser);

                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from tblUser where EmployeeID= @C1 order by EmployeeID ", paramemployee);


                    dr.Dispose();
                    dr.Close();



                }
                else
                {

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
                        cmbemployee.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbusertype.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        usernametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        passwordtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                      

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
                            SQLCONN.ExecuteQueries("update tblUser set employeeid =@C1,username=@C2,password=@C3,usertypeid=@C4,isActive=1 where  userid=@id  ", paramPID, paramemployee, paramusername, parampassword, paramusertype );

                        }

                        else
                        {
                            SQLCONN.ExecuteQueries("update tblUser set employeeid =@C1,username=@C2,password=@C3,usertypeid=@C4,isActive=0 where  userid=@id  ", paramPID, paramemployee, paramusername, parampassword, paramusertype);

                        }







                        MessageBox.Show("Record Updated Successfully");
                        // dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],NewID,StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate],[UserID],[DatetimeLog]  FROM[DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and  NEWID = @C14  ", paramNewID);
                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from tblUser where    userid=@id",paramPID);



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
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from tblUser ");
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
    }
}
