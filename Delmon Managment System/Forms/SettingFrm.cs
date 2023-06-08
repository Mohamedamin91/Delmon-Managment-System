using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        int jobid;
        int CompID;
        int DeptID;
        double num1, num2;

        static Regex validate_emailaddress = email_validation();



        public SettingFrm()
        {
            InitializeComponent();
            // Define the new font
            //Font newFont = new Font("Times New Roman", 12);

            //// Loop through all controls on the form and change their font properties
            //foreach (Control control in Controls)
            //{
            //    control.Font = newFont;
            //}

        }
        public static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        private void SettingFrm_Load(object sender, EventArgs e)
        {
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
            SQLCONN.OpenConection();
            cmbemployee.ValueMember = "EmployeeID";
            cmbemployee.DisplayMember = "FullName";
            cmbemployee.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            cmbemployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee.AutoCompleteSource = AutoCompleteSource.ListItems;

            //cmbemployee13633.ValueMember = "EmployeeID";
            //cmbemployee13633.DisplayMember = "FullName";
            //cmbemployee13633.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            //cmbemployee13633.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbemployee13633.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbemployee13633.KeyDown += cmbemployee1_KeyDown;

            cmbemployee2.ValueMember = "EmployeeID";
            cmbemployee2.DisplayMember = "FullName";
            cmbemployee2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            cmbemployee2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee2.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbemployee2.KeyDown += cmbemployee1_KeyDown;


            cmbemployee1.ValueMember = "EmployeeID";
            cmbemployee1.DisplayMember = "FullName";
            cmbemployee1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT EmployeeID ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName' from Employees   order by EmployeeID ");
            cmbemployee1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbemployee1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbemployee1.KeyDown += cmbemployee1_KeyDown;





            cmbusertype.ValueMember = "UserTypeID";
            cmbusertype.DisplayMember = "UserType";
            cmbusertype.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT UserTypeID,UserType  from [tblUserType] ");
            cmbusertype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbusertype.AutoCompleteSource = AutoCompleteSource.ListItems;




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


            //cmbworkfield.ValueMember = "Work_Field_ID";
            //cmbworkfield.DisplayMember = "Work_Field_Name";
            //cmbworkfield.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Work_Field_ID,Work_Field_Name FROM WorkFields");
            //cmbworkfield.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbworkfield.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbworkfield.ValueMember = "WorkID";
            cmbworkfield.DisplayMember = "Name";
            cmbworkfield.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT WorkID,Name FROM [WorkLocations]");
            cmbworkfield.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbworkfield.AutoCompleteSource = AutoCompleteSource.ListItems;


            //cmbjobgrade.ValueMember = "Job_Grade_ID";
            //cmbjobgrade.DisplayMember = "Job_Grade_Name";
            //cmbjobgrade.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Job_Grade_ID,Job_Grade_Name FROM JobGrades");
            //cmbjobgrade.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbjobgrade.AutoCompleteSource = AutoCompleteSource.ListItems;

            //cmbCompany.ValueMember = "COMPID";
            //cmbCompany.DisplayMember = "COMPName_EN";
            //cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID,COMPName_EN FROM Companies");
            //cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;

            //cmbDepartment654.ValueMember = "Dept_Type_ID";
            //cmbDepartment654.DisplayMember = "Dept_Type_Name";
            //cmbDepartment654.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Dept_Type_ID,Dept_Type_Name FROM [DeptTypes]");
            //cmbDepartment654.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbDepartment654.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbDepartment.ValueMember = "Dept_Type_ID";
            cmbDepartment.DisplayMember = "Dept_Type_Name";
            cmbDepartment.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Dept_Type_ID,Dept_Type_Name FROM [DeptTypes]");
            cmbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;




            //cmbHeadPostion.ValueMember = "[DEPTID]";
            //cmbHeadPostion.DisplayMember = "DeptHeadPosition";
            //cmbHeadPostion.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT DISTINCT DeptHeadPosition FROM DEPARTMENTS WHERE DeptHeadPosition IS NOT NULL ORDER BY DeptHeadPosition DESC  ");
            //cmbHeadPostion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbHeadPostion.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (lblusertype.Text == "Admin")
            {
                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
             (" SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive from Employees,tblUserType ,tblUser  where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID    ");

            }
            else

            {
                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
                  (" SELECT tblUser.[UserID]  ,tblUser.EmployeeID  ,CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName', [tblUserType].UserType ,[UserName] ,[Password],isactive from Employees,tblUserType ,tblUser  where tblUser.EmployeeID = Employees.EmployeeID and tblUser.UserTypeID = tblUserType.UserTypeID and tblUser.EmployeeID=" + LoggedEmployeeID + " ");

            }

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


            SqlDataReader dr, dr2;
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

                            SQLCONN.ExecuteQueries("insert into tblUser ( [EmployeeID] ,[UserName],[Password],[UserTypeID],[IsActive]) values (@C1,@C2,@C3,@C4,1)",
                                                     paramemployee, paramusername, parampassword, paramusertype, paramisActive);
                            MessageBox.Show("Record saved Successfully");

                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@C1 ,'#','#',@datetime,@pc,@user,'Insert')", paramemployee, paramdatetimeLOG, parampc, paramuser);
                            btnnew.Visible = true;

                        }
                        else
                        {
                            dr.Dispose();
                            dr.Close();




                            SQLCONN.ExecuteQueries("insert into tblUser ( [EmployeeID] ,[UserName],[Password],[UserTypeID],[IsActive]) values (@C1,@C2,@C3,@C4,0)",


                                paramemployee, paramusername, parampassword, paramusertype, paramisActive);
                            MessageBox.Show("Record saved Successfully");



                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('User Info',@C1 ,'#','#',@datetime,@pc,@user,'Insert')", paramemployee, paramdatetimeLOG, parampc, paramuser);
                            btnnew.Visible = true;


                        }

                        cmbusertype.Text = cmbemployee.Text = "Select";
                        usernametxt.Text = passwordtxt.Text = "";
                        isactivecheck.Checked = false;

                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from tblUser where EmployeeID= @C1 order by EmployeeID ", paramemployee);


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
                            SQLCONN.ExecuteQueries("update tblUser set employeeid =@C1,username=@C2,password=@C3,usertypeid=@C4,isActive=1 where  userid=@id  ", paramPID, paramemployee, paramusername, parampassword, paramusertype);

                        }

                        else
                        {
                            SQLCONN.ExecuteQueries("update tblUser set employeeid =@C1,username=@C2,password=@C3,usertypeid=@C4,isActive=0 where  userid=@id  ", paramPID, paramemployee, paramusername, parampassword, paramusertype);

                        }







                        MessageBox.Show("Record Updated Successfully");
                        // dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],NewID,StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate],[UserID],[DatetimeLog]  FROM[DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and  NEWID = @C14  ", paramNewID);
                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from tblUser where    userid=@id", paramPID);



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

                    else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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


                    else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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


        }

        private void BtnnewJob_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            ClearTextBoxes();

        }

        private void BtnnewAgaency_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            ClearTextBoxes();

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                tabControl1.TabPages[1].Visible = false;
                if (lblusertype.Text != "Admin")
                {

                    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    tabControl1.TabPages[1].Visible = true;

                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                tabControl1.TabPages[2].Visible = false;

                if (lblusertype.Text != "Admin")
                {

                    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    tabControl1.TabPages[2].Visible = true;

                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[3])
            {
                tabControl1.TabPages[3].Visible = false;
                // MessageBox.Show("Comming Soon  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (lblusertype.Text != "Admin")
                {

                    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    tabControl1.TabPages[3].Visible = true;

                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[4])
            {
                //tabControl1.TabPages[4].Visible = false;
                //MessageBox.Show("Comming Soon  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //if (lblusertype.Text != "Admin")
                //{

                //    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //}
                //else
                //{
                //    tabControl1.TabPages[4].Visible = true;

                //}
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[5])
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
                    " values (@id,@C1,@C2,@C3,@C4,@C5,@C7,@C8,@C9,@C10) ", paramCompid, paramcompEn, paramcompAR, ParamCR, paramSponser, paramVat, paramHD, paramAD, paramGeneralManager,paramShortName);


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
                    CommonClass.CompanyId= Convert.ToInt32(row.Cells[0].Value.ToString());
                    txtCR.Text = row.Cells[1].Value?.ToString();
                    CommonClass.CRNmber = txtCR.Text;
                    txtSponser.Text = row.Cells[2].Value?.ToString();
                    txtcompnameEN.Text = row.Cells[3].Value?.ToString();
                    CommonClass.CompName= txtcompnameEN.Text;
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






                        SQLCONN.ExecuteQueries("update Companies set [COMPName_EN] =@C1,[COMPName_AR]=@C2,[CRNumber]=@C3,[ID_Number]=@C4,[VAT_NO]=@C5,[EstablishedHD]=@C7,[EstablishedAD]=@C8, [General_Manager]=@C9 where  COMPID=@id  ", paramcompEn, paramcompAR, ParamCR, paramSponser, paramVat, paramHD, paramAD, paramGeneralManager, paramCompid);
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
                    txtcompnameEN.Text = txtcompnameAR.Text =  txtCR.Text = txtVat.Text = txtSponser.Text = txtAD.Text=txtHD.Text="";

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
            if (CompID ==0 )
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
                SqlDataReader dr = SQLCONN.DataReader("SELECT TOP 1 DEPTID FROM DEPARTMENTS where COMPID=@id ORDER BY DEPTID DESC",paramCompid);
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
              " values (@DeptID,@C1,@C2,@C3,@id) ", paramDeptID,paramDeptName,paramWorkLocation,paramDeptHead, paramCompid);

                MessageBox.Show("Record saved Successfully");
                dr.Dispose();
                dr.Close();
               


               
                dataGridView7.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  * from  [DEPARTMENTS] where  [DEPTID] = "+DeptID+"  ");

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



            if (DeptID != 0 && CompID!=0)
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
            FrmDocShow frmDocShow   = new FrmDocShow();
            // this.Hide();
            frmDocShow.Show();
        }

        private void Companiestap_Click(object sender, EventArgs e)
        {

        }

        private void maxtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // suppress the key press event
                MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }





    

