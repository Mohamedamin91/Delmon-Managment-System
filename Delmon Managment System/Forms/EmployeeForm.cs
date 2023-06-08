using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Net;
using System.Diagnostics;

namespace Delmon_Managment_System.Forms
{
    public partial class EmployeeForm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        OpenFileDialog opf = new OpenFileDialog();

        //  JobOfferLTR OfferLTR = new JobOfferLTR();
        public int EMPID;
        public int EmployeeID;
        int SalaryID = 0;
        static Regex validate_emailaddress = email_validation();
        int id_History = 0;
        //  int ID = 0;
        int loggedEmpolyeeID;
        int dOCID;
        string textFilePath;
        string destinationFilePath;
        string fileName;




        public EmployeeForm()
        {

            InitializeComponent();
          //  Font newFont = new Font("Times New Roman", 10);
            cmbEmployJobHistory.KeyDown += new KeyEventHandler(cmbEmployJobHistory_KeyDown);
            cmbCompany.KeyDown += new KeyEventHandler(cmbCompany_KeyDown);
            cmbPersonalStatusStatus.KeyDown += new KeyEventHandler(cmbPersonalStatusStatus_KeyDown);
            //  cmbPersonalStatusStatus.KeyPress += cmbPersonalStatusStatus_KeyPress;

            // Loop through all controls on the form and change their font properties
            foreach (Control control in Controls)
            {
           //     control.Font = newFont;
            }



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

            func(Controls);
            cmbGender.Text = cmbPersonalStatusStatus.Text = "";
            //    dataGridView1.DataSource = null;



        }
        public static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }



        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            









            // tabControl1.TabPages.Remove(EmploymentHistory);

            //tabControl1.TabPages.Remove(SalaryTab);


            lblusername.Text = CommonClass.LoginUserName;
            lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
            lblPC.Text = Environment.MachineName;
            loggedEmpolyeeID = CommonClass.EmployeeID;
            lblFullname.Text = CommonClass.LoginEmployeeName;

            SqlParameter paramloggiedemployeeid = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramloggiedemployeeid.Value = loggedEmpolyeeID;
            SQLCONN.OpenConection();

            if (lblusertype.Text == "Admin")
            {
                DeleteBTN.Enabled = btndeletecontact.Enabled = btndeletedoc.Enabled = button1.Enabled = button4.Enabled = true;
                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"
SELECT Employees.EmployeeID, Employees.CurrentEmpID, FirstName, SecondName, ThirdName, LastName, Gender, MartialStatus, StatusTBL.StatusValue, jobs.JobTitleEN, DeptTypes.Dept_Type_Name, Companies.COMPName_EN, startdate, enddate, NationalityName 
FROM Employees
JOIN Countries ON Countries.CountryId = Employees.NationalityID
JOIN DEPARTMENTS ON Employees.DeptID = DEPARTMENTS.DEPTID
JOIN DeptTypes ON DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID
JOIN StatusTBL ON Employees.EmploymentStatusID = StatusTBL.StatusID
JOIN JOBS ON Employees.JobID = JOBS.JobID
JOIN Companies ON Employees.COMPID = Companies.COMPID AND DEPARTMENTS.COMPID = Companies.COMPID
ORDER BY EmployeeID DESC;
");
            }
            else
            {
                string query = "SELECT Employees.EmployeeID, Employees.CurrentEmpID, FirstName, SecondName, ThirdName, LastName, Gender, MartialStatus, StatusTBL.StatusValue, jobs.JobTitleEN, DeptTypes.Dept_Type_Name, Companies.COMPName_EN, startdate, enddate,NationalityName " +
                  "FROM Employees " +
                  "INNER JOIN StatusTBL ON Employees.EmploymentStatusID = StatusTBL.StatusID " +
                  "INNER JOIN JOBS ON Employees.JobID = JOBS.JobID " +
                  "INNER JOIN DEPARTMENTS ON Employees.DeptID = DEPARTMENTS.DEPTID " +
                  "INNER JOIN DeptTypes ON DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID " +
                  "INNER JOIN Companies ON DEPARTMENTS.COMPID = Companies.COMPID " +
                  "INNER JOIN Countries ON Countries.CountryId = Employees.NationalityID " +
                  "WHERE Employees.DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = @C1) " +
                  "ORDER BY Employees.EmployeeID ASC";
               //    Doctxt.Visible = false;

                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramloggiedemployeeid);
            }




            firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = false;
            cmbMartialStatus.Enabled = cmbGender.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = cmbnationality.Enabled = false;
            StartDatePicker.Enabled = EndDatePicker.Enabled = false;

            this.timer1.Interval = 1000;
            timer1.Start();

            this.ActiveControl = firstnametxt;

            AddBtn.Visible = DeleteBTN.Visible = Updatebtn.Visible = false;
            btnNew.Visible = true;





            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID,COMPName_EN FROM Companies");



            cmbDocuments.ValueMember = "DocType_ID";
            cmbDocuments.DisplayMember = "Doc_Type";
            cmbDocuments.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT DocType_ID,Doc_Type FROM DocumentType");

            cmbcontact.ValueMember = "ContTypeID";
            cmbcontact.DisplayMember = "ContType";
            cmbcontact.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT ContTypeID ,ContType FROM ContactTypes ");


            //CmbReqierdJob.ValueMember = "JobID";
            //CmbReqierdJob.DisplayMember = "JobTitleEN";
            //CmbReqierdJob.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT JobID,JobTitleEN FROM JOBS");




            //cmbReferredBy.ValueMember = "empid";
            //cmbReferredBy.DisplayMember = "EmpName";
            //cmbReferredBy.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT empid,EmpName FROM Employees ");

            cmbPersonalStatusStatus.ValueMember = "StatusID";
            cmbPersonalStatusStatus.DisplayMember = "StatusValue";
            cmbPersonalStatusStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  StatusID , StatusValue  from StatusTBL where RefrenceID=2  ");
            cmbPersonalStatusStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbPersonalStatusStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbEmployJobHistory.ValueMember = "JobID";
            cmbEmployJobHistory.DisplayMember = "JobTitleEN";
            cmbEmployJobHistory.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT JobID,JobTitleEN FROM JOBS");
                 cmbEmployJobHistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                 cmbEmployJobHistory.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbempdepthistory.ValueMember = "DEPTID";
            cmbempdepthistory.DisplayMember = "Dept_Type_Name";
            cmbempdepthistory.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT DEPTID,[DeptName],Dept_Type_Name FROM [DelmonGroupDB].[dbo].[DEPARTMENTS], DeptTypes where DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID");
            cmbempdepthistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbempdepthistory.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbissueplace.ValueMember = "Consulates.ConsulateID";
            cmbissueplace.DisplayMember = "ConsulateCity";
            cmbissueplace.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId");
            cmbissueplace.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbissueplace.AutoCompleteSource = AutoCompleteSource.ListItems;

            //cmbCountry.ValueMember = "CountryId";
            //cmbCountry.DisplayMember = "CountryName";
            //cmbCountry.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select CountryId,CountryName from Countries ");
            cmbsalarytype.ValueMember = "SalaryTypeID";
            cmbsalarytype.DisplayMember = "SalaryTypeName";
            cmbsalarytype.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select SalaryTypeID,SalaryTypeName from SalaryTypes");
            cmbsalarytype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbsalarytype.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbnationality.ValueMember = "CountryId";
            cmbnationality.DisplayMember = "NationalityName";
            cmbnationality.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select CountryId,NationalityName from Countries");
            cmbnationality.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbnationality.AutoCompleteSource = AutoCompleteSource.ListItems;




            cmbPersonalStatusStatus.Text = "Select";
            cmbempdepthistory.Text = "Select";
            CurrentEmployeeIDtxt.Enabled = true;


            SQLCONN.CloseConnection();

        }

        private void Employeetxt_TextChanged(object sender, EventArgs e)
        {
            SqlParameter paramEmployeenameSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramEmployeenameSearch.Value = Employeetxt.Text;
            SqlParameter paramloggiedemployeeid = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramloggiedemployeeid.Value = loggedEmpolyeeID;

            SQLCONN.OpenConection();
            if (lblusertype.Text == "Admin")
            {
                string query = @"SELECT e.EmployeeID, e.CurrentEmpID, e.FirstName, e.SecondName, e.ThirdName, e.LastName, e.Gender, e.MartialStatus, s.StatusValue, j.JobTitleEN, dt.Dept_Type_Name, c.COMPName_EN, e.startdate, e.enddate, cn.NationalityName,v.FileNumber,v.VISANumber
FROM Employees e
INNER JOIN StatusTBL s ON e.EmploymentStatusID = s.StatusID
INNER JOIN JOBS j ON e.JobID = j.JobID
INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID
INNER JOIN DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
INNER JOIN Companies c ON d.COMPID = c.COMPID
INNER JOIN Countries cn ON e.NationalityID = cn.CountryId
INNER JOIN VISAJobList v  ON e.EmployeeID = v.EmployeeID
WHERE (e.EmployeeID LIKE '%' + REPLACE(@C1, ' ', '') + '%' 
       OR e.CurrentEmpID LIKE '%' + REPLACE(@C1, ' ', '') + '%' 
       OR REPLACE(e.FirstName, ' ', '') + REPLACE(e.SecondName, ' ', '') + REPLACE(e.ThirdName, ' ', '') + REPLACE(e.LastName, ' ', '') LIKE '%' + REPLACE(@C1, ' ', '') + '%'
       OR e.FirstName LIKE '%' + @C1 + '%'
       OR e.SecondName LIKE '%' + @C1 + '%'
       OR e.ThirdName LIKE '%' + @C1 + '%'
       OR e.LastName LIKE '%' + @C1 + '%'
      )
ORDER BY e.EmployeeID";
                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramEmployeenameSearch);




            }
            else
            {

                string query = "SELECT Employees.EmployeeID, Employees.CurrentEmpID, FirstName, SecondName, ThirdName, LastName, Gender, MartialStatus, StatusTBL.StatusValue, jobs.JobTitleEN, DeptTypes.Dept_Type_Name, Companies.COMPName_EN, startdate, enddate, NationalityName " +
                   "FROM Countries, Employees " +
                   "INNER JOIN StatusTBL ON Employees.EmploymentStatusID = StatusTBL.StatusID " +
                   "INNER JOIN JOBS ON Employees.JobID = JOBS.JobID " +
                   "INNER JOIN DEPARTMENTS ON Employees.DeptID = DEPARTMENTS.DEPTID " +
                   "INNER JOIN DeptTypes ON DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID " +
                   "INNER JOIN Companies ON DEPARTMENTS.COMPID = Companies.COMPID " +
                   "WHERE (REPLACE(CONCAT_WS(' ', firstname, secondname, thirdname, lastname), ' ', '') LIKE '%' + REPLACE(@C1, ' ', '') + '%' " +
                   "OR Employees.EmployeeID LIKE '%' + REPLACE(@C1, ' ', '') + '%' " +
                   "OR Employees.CurrentEmpID LIKE '%' + REPLACE(@C1, ' ', '') + '%') " +
                   "AND Employees.DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = @C2) " +
                   "AND Countries.CountryId = Employees.NationalityID " +
                   "ORDER BY Employees.EmployeeID ASC";

                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramEmployeenameSearch, paramloggiedemployeeid);

            }

            SQLCONN.CloseConnection();
            firstnametxt.Text = secondnametxt.Text = thirdnametxt.Text = lastnametxt.Text = "";
            cmbMartialStatus.Text = cmbGender.Text = "";
            ClearAllControls();
            tabControl1.Enabled = true;
        }
        private void ClearAllControls()
        {
            // Loop through each tab page
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                // Loop through each control on the tab page
                foreach (Control control in tabPage.Controls)
                {
                    // Clear the control if it's a text box, combo box, or data grid view
                    if (control is TextBox textBox)
                    {
                        textBox.Clear();
                    }
                    else if (control is ComboBox comboBox)
                    {
                        comboBox.SelectedIndex = -1;
                        comboBox.Text = "";
                    }
                    else if (control is DataGridView dataGridView)
                    {
                        dataGridView.DataSource = null;
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();
                    }
                }
            }
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }


        private void Updatebtn_Click(object sender, EventArgs e)

        {

            SqlParameter paramfirstname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramfirstname.Value = firstnametxt.Text;
            SqlParameter paramsecondname = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramsecondname.Value = secondnametxt.Text;
            SqlParameter Paramthirdname = new SqlParameter("@C3", SqlDbType.NVarChar);
            Paramthirdname.Value = thirdnametxt.Text;
            SqlParameter paramlastname = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramlastname.Value = lastnametxt.Text;
            SqlParameter paramGender = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramGender.Value = cmbGender.SelectedItem;
            SqlParameter paramMartialStatus = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramMartialStatus.Value = cmbMartialStatus.SelectedItem;

            SqlParameter paramUserID = new SqlParameter("@C10", SqlDbType.NVarChar);
            paramUserID.Value = CommonClass.UserID;
            SqlParameter paramDateTimeLOG = new SqlParameter("@C11", SqlDbType.NVarChar);
            paramDateTimeLOG.Value = lbldatetime.Text;
            SqlParameter paramRecordStatus = new SqlParameter("@C12", SqlDbType.NVarChar);
            paramRecordStatus.Value = "1";


            SqlParameter paramStatusHistory = new SqlParameter("@C13", SqlDbType.NVarChar);
            paramStatusHistory.Value = cmbPersonalStatusStatus.SelectedValue;
            SqlParameter paramJobHistory = new SqlParameter("@C14", SqlDbType.NVarChar);
            paramJobHistory.Value = cmbEmployJobHistory.SelectedValue;
            SqlParameter ParamtDepartmentHistory = new SqlParameter("@C15", SqlDbType.NVarChar);
            ParamtDepartmentHistory.Value = cmbempdepthistory.SelectedValue;
            SqlParameter paramstartdate = new SqlParameter("@C16", SqlDbType.Date);
            paramstartdate.Value = StartDatePicker.Value;
            SqlParameter paramenddate = new SqlParameter("@C17", SqlDbType.Date);
            paramenddate.Value = EndDatePicker.Value;

            SqlParameter paramcompany = new SqlParameter("@C18", SqlDbType.NVarChar);
            paramcompany.Value = cmbCompany.SelectedValue;
            SqlParameter paramNationality = new SqlParameter("@C19", SqlDbType.NVarChar);
            paramNationality.Value = cmbnationality.SelectedValue;





            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EMPID;
            SqlParameter paramEmployeeID = new SqlParameter("@CurrentEmployeeID", SqlDbType.NVarChar);

            /* for log */

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;
            SqlParameter paramType = new SqlParameter("@type", SqlDbType.NVarChar);
            paramType.Value = "Update";
            /* for log */



            if (EMPID != 0)
            {



                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    if (StartDatePicker.Checked == false)
                    {
                        DateTime enter_date = DateTime.Now.Date;
                        StartDatePicker.Value = enter_date;

                    }
                    else if (EndDatePicker.Checked == false)
                    {

                        DateTime enter_date = DateTime.Now.Date;
                        EndDatePicker.Value = enter_date;


                    }
                    else if (cmbEmployJobHistory.Text == "Select")

                    {
                        MessageBox.Show("Please Select a Job !!");

                    }
                    else if (cmbnationality.Text == "Select")

                    {
                        MessageBox.Show("Please Select a Nationality !!");

                    }
                    else if (cmbempdepthistory.Text == "Select")
                    {
                        MessageBox.Show("Please Select a department !!");
                    }
                    else if (cmbPersonalStatusStatus.Text == "Select")

                    {
                        MessageBox.Show("Please Select a Employment type !!");


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
                            string sql = "SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";
                            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                            da.SelectCommand.Parameters.AddWithValue("@EmployeeId", EMPID);
                            originalData = new DataTable();
                            da.Fill(originalData);
                        }


                        paramEmployeeID.Value = CurrentEmployeeIDtxt.Text;


                        if ((int)cmbPersonalStatusStatus.SelectedValue == 25 || (int)cmbPersonalStatusStatus.SelectedValue == 26 || (int)cmbPersonalStatusStatus.SelectedValue == 27)
                        {
                            SQLCONN.ExecuteQueries("update Employees set firstname =@C1,secondname=@C2,thirdname=@C3,lastname=@C4,Gender=@C5,MartialStatus=@C6,EmploymentStatusID=@C13,JobID=@C14,DeptID=@C15,StartDate=@C16,EndDate=@C17,COMPID=@C18,CurrentEmpID=@CurrentEmployeeID ,UserID=@user,PCNAME=@pc,NationalityID=@C19 where  EmployeeID= @id  ", paramPID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramenddate, paramcompany, paramEmployeeID, paramuser, parampc, paramNationality);

                        }

                        else
                        {
                            SQLCONN.ExecuteQueries("update Employees set firstname =@C1,secondname=@C2,thirdname=@C3,lastname=@C4,Gender=@C5,MartialStatus=@C6,EmploymentStatusID=@C13,JobID=@C14,DeptID=@C15,StartDate=@C16,COMPID=@C18,CurrentEmpID=@CurrentEmployeeID ,UserID=@user,PCNAME=@pc,NationalityID=@C19 where  EmployeeID= @id  ", paramPID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramcompany, paramEmployeeID, paramuser, parampc, paramNationality);

                        }


                        /* Update visa status **/
                        if ((int)cmbPersonalStatusStatus.SelectedValue == 24)
                        {
                            SqlDataReader dr = SQLCONN.DataReader("SELECT FileNumber,VISANumber FROM [DelmonGroupDB].[dbo].[VISAJobList] where StatusID !=6 and EmployeeID=" + EMPID + " ");
                            if (dr.Read())
                            {
                                string Visanumber = dr["VISANumber"].ToString();
                                string filenumber = dr["FileNumber"].ToString();
                                if (DialogResult.Yes == MessageBox.Show("Visa:" + Visanumber + " Status will upated Automatically to 'USED', Do You Want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    dr.Dispose();
                                    dr.Close();
                                    SQLCONN.ExecuteQueries("update VISAJobList set StatusID =6 where  FileNumber= " + filenumber + " and VISANumber= " + Visanumber + " ");

                                }
                                dr.Dispose();
                                dr.Close();

                            }
                            dr.Dispose();
                            dr.Close();
                        }
                        /* Update visa status **/









                       


                        MessageBox.Show("Record Updated Successfully");
                        // dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],NewID,StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate],[UserID],[DatetimeLog]  FROM[DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and  NEWID = @C14  ", paramNewID);
                        //  dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Employees where  EmployeeID = '" + EMPID + "'");

                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"
select Employees.EmployeeID, Employees.CurrentEmpID,FirstName,SecondName,ThirdName,LastName,Gender,MartialStatus,StatusTBL.StatusValue,jobs.JobTitleEN,DeptTypes.Dept_Type_Name,Companies.COMPName_EN,startdate, enddate,NationalityName 
from  Countries,Employees,Companies,JOBS,StatusTBL,DEPARTMENTS,DeptTypes  where Countries.CountryId = Employees.NationalityID and
Employees.DeptID = DEPARTMENTS.DEPTID  and  DEPARTMENTS.DeptName  = DeptTypes.Dept_Type_ID and Employees.EmploymentStatusID = StatusTBL.StatusID  and Employees.JobID= JOBS.JobID  and Employees.COMPID = Companies.COMPID  and DEPARTMENTS.COMPID = Companies.COMPID and EmployeeID= @id order by EmployeeID desc", paramPID);




                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sql = "SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                            adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", EMPID);
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
                                    command.Parameters.AddWithValue("@EmployeeId", EMPID);
                                    foreach (string columnName in changedColumns)
                                    {
                                        object originalValue = originalData.Rows[0][columnName];
                                        object updatedValue = updatedData.Rows[0][columnName];
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@EmployeeId", EMPID + " - " + "Employee");
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
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.NVarChar);
            paramPID.Value = EMPID;
            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;





            if (EMPID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();

                    SQLCONN.ExecuteQueries("delete from Employees where EmployeeID=@id", paramPID);
                    SQLCONN.ExecuteQueries("delete from EmployeeHistory where EmployeeID=@id", paramPID);
                    SQLCONN.ExecuteQueries("delete from Documents where RefrenceID=2 and CR_ID=@id ", paramPID);
                    SQLCONN.ExecuteQueries("delete from Contacts where RefrenceID=2 and CR_ID=@id ", paramPID);
                    SQLCONN.ExecuteQueries("delete from SalaryDetails where EmployeeID=@id ", paramPID);

                    // SQLCONN.ExecuteQueries(" declare @max int select @max = max([EmployeeID]) from[Employees] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[Employees]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");
                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES ('Employee Info',@id ,'#','#',@datetime,@pc,@user,'Delete')", paramPID, paramdatetimeLOG, parampc, paramuser);

                    SQLCONN.CloseConnection();
                    ClearTextBoxes();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Employees order by EmployeeID desc ");




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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter paramfirstname = new SqlParameter("@C1", SqlDbType.NVarChar);
                paramfirstname.Value = firstnametxt.Text.Trim();
                SqlParameter paramsecondname = new SqlParameter("@C2", SqlDbType.NVarChar);
                paramsecondname.Value = secondnametxt.Text.Trim();
                SqlParameter Paramthirdname = new SqlParameter("@C3", SqlDbType.NVarChar);
                Paramthirdname.Value = thirdnametxt.Text.Trim();
                SqlParameter paramlastname = new SqlParameter("@C4", SqlDbType.NVarChar);
                paramlastname.Value = lastnametxt.Text.Trim();
                SqlParameter paramGender = new SqlParameter("@C5", SqlDbType.NVarChar);
                paramGender.Value = cmbGender.SelectedItem;
                SqlParameter paramMartialStatus = new SqlParameter("@C6", SqlDbType.NVarChar);
                paramMartialStatus.Value = cmbMartialStatus.SelectedItem;

                SqlParameter paramUserID = new SqlParameter("@C10", SqlDbType.NVarChar);
                paramUserID.Value = CommonClass.UserID;
                SqlParameter paramDateTimeLOG = new SqlParameter("@C11", SqlDbType.NVarChar);
                paramDateTimeLOG.Value = lbldatetime.Text;
                SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
                parampc.Value = lblPC.Text;


                SqlParameter paramStatusHistory = new SqlParameter("@C13", SqlDbType.Int);
                paramStatusHistory.Value = cmbPersonalStatusStatus.SelectedValue;
                SqlParameter paramJobHistory = new SqlParameter("@C14", SqlDbType.NVarChar);
                paramJobHistory.Value = cmbEmployJobHistory.SelectedValue;

                SqlParameter ParamtDepartmentHistory = new SqlParameter("@C15", SqlDbType.Int);
                ParamtDepartmentHistory.Value = cmbempdepthistory.SelectedValue;
                SqlParameter paramstartdate = new SqlParameter("@C16", SqlDbType.Date);
                paramstartdate.Value = StartDatePicker.Value;
                SqlParameter paramenddate = new SqlParameter("@C17", SqlDbType.Date);
                paramenddate.Value = EndDatePicker.Value;

                SqlParameter paramcompany = new SqlParameter("@C18", SqlDbType.NVarChar);
                paramcompany.Value = cmbCompany.SelectedValue;

                SqlParameter paramNationality = new SqlParameter("@C19", SqlDbType.NVarChar);
                paramNationality.Value = cmbnationality.SelectedValue;



                SqlParameter paramPID = new SqlParameter("@id", SqlDbType.Int);
                paramPID.Value = EMPID;
                SqlParameter paramEmployeeID = new SqlParameter("@EmployeeID", SqlDbType.Int);

                SqlParameter paramCurrentEmployeeID = new SqlParameter("@CurrentEmployeeID", SqlDbType.NVarChar);
                paramCurrentEmployeeID.Value = CurrentEmployeeIDtxt.Text.Trim();


                /*logg*/
                SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
                paramuser.Value = lblusername.Text;
                SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
                paramdatetimeLOG.Value = lbldatetime.Text;

                /*logg*/



                if (firstnametxt.Text != "" && secondnametxt.Text != "" && thirdnametxt.Text != "" && lastnametxt.Text != "" && cmbPersonalStatusStatus.Text != "Select" && cmbempdepthistory.Text != "Select" && cmbEmployJobHistory.Text != "Select")
                {
                    SQLCONN.OpenConection();
                    SqlDataReader dr = SQLCONN.DataReader("select  * from Employees where " +
                         " firstname=  @C1 and    SecondName =  @C2 and thirdname = @C3  and lastname = @C4", paramfirstname, paramsecondname, Paramthirdname, paramlastname);
                    dr.Read();


                    if (dr.HasRows)
                    {
                        MessageBox.Show("This 'Name'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        if (StartDatePicker.Checked == false)
                        {
                            DateTime enter_date = DateTime.Now.Date;
                            StartDatePicker.Value = enter_date;

                        }
                        else if (EndDatePicker.Checked == false)
                        {

                            DateTime enter_date = DateTime.Now.Date;
                            EndDatePicker.Value = enter_date;


                        }
                        else if (cmbEmployJobHistory.Text == "Select")

                        {
                            MessageBox.Show("Please Select a Job !!");


                        }
                        else if (cmbnationality.Text == "Select")

                        {
                            MessageBox.Show("Please Select a Nationality !!");

                        }
                        else if (cmbempdepthistory.Text == "Select")
                        {
                            MessageBox.Show("Please Select a department !!");
                        }
                        else if (cmbPersonalStatusStatus.Text == "Select")

                        {
                            MessageBox.Show("Please Select a Employment type !!");


                        }
                        else
                        {
                            dr.Dispose();
                            dr.Close();
                            dr = SQLCONN.DataReader("   SELECT COALESCE(MAX(EmployeeID), 0) 'ID' FROM Employees  ");
                            if (dr.Read())
                            {


                                EmployeeID = int.Parse(dr["ID"].ToString());
                                EmployeeID = EmployeeID + 1;


                            }
                            else
                            {
                                dr.Dispose();
                                dr.Close();
                                //  EmployeeID = 0;
                            }
                            dr.Dispose();
                            dr.Close();
                            paramEmployeeID.Value = EmployeeID;

                            if ((int)cmbPersonalStatusStatus.SelectedValue == 25 || (int)cmbPersonalStatusStatus.SelectedValue == 26 || (int)cmbPersonalStatusStatus.SelectedValue == 27)
                            {
                                SQLCONN.ExecuteQueries("insert into Employees (EmployeeID, firstname,secondname,thirdname,lastname,Gender,MartialStatus,[PCNAME], EmploymentStatusID,JobID,DeptID,StartDate,EndDate,COMPID,UserID,CurrentEmpID,NationalityID)" +
                          " values (@EmployeeID,@C1,@C2,@C3,@C4,@C5,@C6,@pc,@C13,@C14,@C15,@C16,@C17,@C18,@C10,@CurrentEmployeeID,@C19)",
                                                     paramEmployeeID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, parampc, paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramenddate, paramcompany, paramUserID, paramCurrentEmployeeID, paramNationality);

                            }
                            else
                            {
                                SQLCONN.ExecuteQueries("insert into Employees (EmployeeID, firstname,secondname,thirdname,lastname,Gender,MartialStatus,[PCNAME], EmploymentStatusID,JobID,DeptID,StartDate,COMPID,UserID,CurrentEmpID,NationalityID)" +
                          " values (@EmployeeID,@C1,@C2,@C3,@C4,@C5,@C6,@pc,@C13,@C14,@C15,@C16,@C18,@C10,@CurrentEmployeeID,@C19)",
                                                     paramEmployeeID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, parampc, paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramcompany, paramUserID, paramCurrentEmployeeID, paramNationality);

                            }


                            MessageBox.Show("Record saved Successfully");


                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (Logvalueid, logvalue ,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeID, 'User Info' ,'#','#',@datetime,@pc,@user,'Insert')", paramEmployeeID, paramdatetimeLOG, parampc, paramuser);

                            btnNew.Visible = true;
                            CurrentEmployeeIDtxt.Text = EmployeeID.ToString();
                            btnaddhitory.PerformClick();

                            tabControl1.Enabled = true;


                            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"
select Employees.EmployeeID, Employees.CurrentEmpID,FirstName,SecondName,ThirdName,LastName,Gender,MartialStatus,StatusTBL.StatusValue,jobs.JobTitleEN,DeptTypes.Dept_Type_Name,Companies.COMPName_EN,startdate, enddate,NationalityName 
from  Countries,Employees,Companies,JOBS,StatusTBL,DEPARTMENTS,DeptTypes  where Countries.CountryId = Employees.NationalityID and
Employees.DeptID = DEPARTMENTS.DEPTID  and  DEPARTMENTS.DeptName  = DeptTypes.Dept_Type_ID and Employees.EmploymentStatusID = StatusTBL.StatusID  and Employees.JobID= JOBS.JobID  and Employees.COMPID = Companies.COMPID  and DEPARTMENTS.COMPID = Companies.COMPID and EmployeeID= @EmployeeID order by EmployeeID desc", paramEmployeeID);







                            SQLCONN.CloseConnection();



                        }
                    }



                }
                else
                {
                    MessageBox.Show("Please Fill the missing fields  ");
                    tabControl1.Enabled = false;
                }
                SQLCONN.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void furstnametxt_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                secondnametxt.Focus();
                e.Handled = true;
            }
        }

        private void secondnametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thirdnametxt.Focus();
                e.Handled = true;
            }
        }

        private void EmployeeForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void thirdnametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lastnametxt.Focus();
                e.Handled = true;
            }

        }

        private void lastnametxt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbMartialStatus.Focus();
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void lastnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstnametxt_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                secondnametxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                firstnametxt.Text = textInfo.ToTitleCase(firstnametxt.Text);
            }
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("Please make sure to insert 'FIRST NAME' only !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Space key was pressed
                // Add your code here to handle the space key press event
            }
        }

        private void secondnametxt_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                thirdnametxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                secondnametxt.Text = textInfo.ToTitleCase(secondnametxt.Text);
            }
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("Please make sure to insert 'SECOND NAME' only !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Space key was pressed
                // Add your code here to handle the space key press event
            }
        }

        private void thirdnametxt_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                lastnametxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                thirdnametxt.Text = textInfo.ToTitleCase(thirdnametxt.Text);
            }
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("Please make sure to insert 'THIRD NAME' only !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Space key was pressed
                // Add your code here to handle the space key press event
            }
        }

        private void lastnametxt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbnationality.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                lastnametxt.Text = textInfo.ToTitleCase(lastnametxt.Text);
            }
            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("Please make sure to insert 'LAST NAME' only !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Space key was pressed
                // Add your code here to handle the space key press event
            }


        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
        }

        private void UplodeBTN_Click(object sender, EventArgs e)
        {
            if (EMPID != 0)
            {
                if (fileName == null || destinationFilePath == string.Empty)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                    //Create the documents folder if it doesn't exist
                    //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    //string documentFolder = Path.Combine(documentsPath, "HR SW Documents");
                    //////Directory.CreateDirectory(documentFolder);

                    //// Copy the file to the documents folder
                    //string filePath = Path.Combine(documentFolder, filename);
                    //System.IO.File.Copy(opf.FileName, filePath, true);

                    // Execute the query to insert the document into the database
                    SqlParameter paramfilename = new SqlParameter("@C0", SqlDbType.NVarChar);
                    paramfilename.Value = fileName;
                    SqlParameter paramnameOFfile = new SqlParameter("@C1", SqlDbType.NVarChar);
                    paramnameOFfile.Value = destinationFilePath;
                    SqlParameter paramPID = new SqlParameter("@C2", SqlDbType.Int);
                    paramPID.Value = EmployeeID;
                    SqlParameter paramDocType = new SqlParameter("@C3", SqlDbType.Int);
                    paramDocType.Value = cmbDocuments.SelectedValue;
                    SqlParameter paramRefrenceID = new SqlParameter("@C4", SqlDbType.Int);
                    paramRefrenceID.Value = 2;

                    // Add extra fields for visa file
                    SqlParameter paramfilenumber = new SqlParameter("@C5", SqlDbType.NVarChar);
                    paramfilenumber.Value = numbertextbox.Text;
                    SqlParameter paramnafileissueplace = new SqlParameter("@C6", SqlDbType.NVarChar);
                    paramnafileissueplace.Value = issueplacetext.Text;
                    SqlParameter paramfileissuedate = new SqlParameter("@C7", SqlDbType.Date);
                    paramfileissuedate.Value = docissueplacepicker.Value;
                    SqlParameter paramfileexpiraydate = new SqlParameter("@C8", SqlDbType.Date);
                    paramfileexpiraydate.Value = docexpirefatepicker.Value;
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (cmbDocuments.Text == "Select")
                        {
                            MessageBox.Show("Please Select Document Type  . !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        if (numbertextbox.Text == "")
                        {
                            MessageBox.Show("Please insert Document  Number. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        if (issueplacetext.Text == "")
                        {
                            MessageBox.Show("Please insert Document Issue Place. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {

                            SQLCONN.OpenConection();
                            SQLCONN.ExecuteQueries("insert into Documents (name,documentValue,CR_ID,DocTypeID,RefrenceID,Number,DocIssueplace,docissuedate,docexpiredate)values(@C0,@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8)", paramfilename, paramnameOFfile, paramPID, paramDocType, paramRefrenceID, paramfilenumber, paramnafileissueplace, paramfileissuedate, paramfileexpiraydate);
                            // SQLCONN.ExecuteQueries("insert into Documents (CR_ID,DocTypeID,RefrenceID,Number,DocIssueplace,docissuedate,docexpiredate)values(@C2,@C3,@C4,@C5,@C6,@C7,@C8)", paramPID, paramDocType, paramRefrenceID, paramfilenumber, paramnafileissueplace, paramfileissuedate, paramfileexpiraydate);
                            dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Documents where CR_ID =  " + EmployeeID + " ");
                            SQLCONN.CloseConnection();
                            MessageBox.Show("Document Saved.");
                            cmbDocuments.Text = "Select";
                            Doctxt.Text = "";
                            numbertextbox.Text = "";
                            issueplacetext.Text = "";
                            docissueplacepicker.Value = DateTime.Now;
                            docexpirefatepicker.Value = DateTime.Now;
                        }
                    }


                }
            }
            else
            {
                MessageBox.Show("Please Select Record !");

            }




        }
        private void tabDoc_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                string directoryPath = @"\\192.168.1.8\HR SW Documents\";
                string variable = cmbCompany.Text;

                // Get all subfolder names in the directory
                string[] subfolderNames = Directory.GetDirectories(directoryPath)
                                                    .Select(Path.GetFileName)
                                                    .ToArray();
                // Check if the variable matches any of the subfolder names
                if (subfolderNames.Contains(variable))
                {
                    // Open file dialog to select a text file to insert into the subfolder
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                  //  openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                    openFileDialog.Title = "Select a text file to insert into the subfolder";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Insert the selected text file into the matching subfolder
                        string subfolderPath = Path.Combine(directoryPath, variable);
                         textFilePath = openFileDialog.FileName;
                         fileName = Path.GetFileName(textFilePath);
                        destinationFilePath = Path.Combine(subfolderPath, fileName);

                        File.Copy(textFilePath, destinationFilePath);
                        Doctxt.Text = textFilePath;
                       // MessageBox.Show(" Uploded Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }








        }


        private void btnaddcontact_Click(object sender, EventArgs e)
        {
            SqlParameter paramContactType = new SqlParameter("@C1", SqlDbType.Int);
            paramContactType.Value = cmbcontact.SelectedValue;
            SqlParameter paramContact = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramContact.Value = Contacttxt.Text;
            SqlParameter paramRefrenceID = new SqlParameter("@C3", SqlDbType.Int);
            paramRefrenceID.Value = 2;
            SqlParameter paramPID = new SqlParameter("@C4", SqlDbType.Int);
            paramPID.Value = EmployeeID;

            if (EMPID != 0)
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
                        MessageBox.Show("This 'Contact Value'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        SQLCONN.ExecuteQueries("insert into Contacts ( ContTypeID,ContValue,RefrenceID,CR_ID) values (@C1,@C2,@C3,@C4)",
                                                       paramContactType, paramContact, paramRefrenceID, paramPID);
                        MessageBox.Show("Record saved Successfully");

                        dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + EmployeeID + " ");
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


        }

        private void btndeletecontact_Click(object sender, EventArgs e)
        {
            SqlParameter paramPID = new SqlParameter("@ID", SqlDbType.Int);
            paramPID.Value = EmployeeID;
            if (EmployeeID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from Contacts where Contact_ID=@ID", paramPID);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max(Contact_ID) from[Contacts] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[Contacts]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");
                    

                    SQLCONN.CloseConnection();
                    EmployeeID = EMPID;
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + EmployeeID + " ");
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

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
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

                        EmployeeID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Contacttxt.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                        cmbcontact.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                        //firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();     
                        //cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


                    }
                }
            }

        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        
        }

        private void btndeletedoc_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SqlParameter paramDoc = new SqlParameter("@ID", SqlDbType.Int);
            paramDoc.Value = dOCID;
            if (EmployeeID != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();

                    // Get the file path from the database before deleting the record

                    SqlDataReader dr = SQLCONN.DataReader("SELECT documentValue FROM Documents WHERE Doc_id = " + dOCID);
                    if (dr.Read())
                    {
                        filePath = (dr["documentValue"].ToString());
                    }
                    dr.Dispose();
                    dr.Close();

                    SQLCONN.ExecuteQueries("delete from Documents where Doc_id=@ID", paramDoc);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max(Doc_id) from[Documents] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[Documents]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");

                    // Delete the file from disk
                    
                     filePath = Path.Combine(filePath);

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        Console.WriteLine("File deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("File does not exist.");
                    }

                    SQLCONN.CloseConnection();
                    cmbDocuments.Text = "Select";
                    Doctxt.Text = "";
                    numbertextbox.Text = "";
                    issueplacetext.Text = "";
                    docissueplacepicker.Value = DateTime.Now;
                    docexpirefatepicker.Value = DateTime.Now; cmbDocuments.Text = "Select";
                    EmployeeID = EMPID;
                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[CR_ID] ,[name],[documentValue] ,[DocumentType].Doc_Type ,[RefrenceID]FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and CR_ID =  " + EmployeeID + " ");
                }
                else
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }


        }

        private void btnupdatecontat_Click(object sender, EventArgs e)
        {
            SqlParameter paramContactType = new SqlParameter("@C1", SqlDbType.Int);
            paramContactType.Value = cmbcontact.SelectedValue;
            SqlParameter paramContact = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramContact.Value = Contacttxt.Text;
            SqlParameter paramRefrenceID = new SqlParameter("@C3", SqlDbType.Int);
            paramRefrenceID.Value = 2;
            SqlParameter paramPID = new SqlParameter("@C4", SqlDbType.Int);
            paramPID.Value = EmployeeID;

            string userInput = txtvalue.Text;
            if (decimal.TryParse(userInput, out decimal inputValue)) // Try to parse input as decimal
            {
                string formattedValue = inputValue.ToString("N2"); // Format decimal as string with 2 decimal places and thousands separator
                txtvalue.Text = formattedValue; // Set the second text box to the formatted value
            }


            if (EmployeeID != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    SQLCONN.OpenConection();

            SQLCONN.ExecuteQueries("update  Contacts set ContTypeID=@C1,ContValue=@C2 where Contact_ID=@C4",
                                                   paramContactType, paramContact, paramPID);
                    MessageBox.Show("Record Updated Successfully");

                    EmployeeID = EMPID;
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID]  FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + EmployeeID + " ");
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
        }

        private void tabContact_Click(object sender, EventArgs e)
        {

        }

        private void btnupdatedoc_Click(object sender, EventArgs e)
        {
            

            SqlParameter paramDoc = new SqlParameter("@ID", SqlDbType.Int);
            paramDoc.Value = dOCID;

            SqlParameter paramfilename = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramfilename.Value = fileName;
            SqlParameter paramnameOFfile = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramnameOFfile.Value = destinationFilePath;
            SqlParameter paramPID = new SqlParameter("@C2", SqlDbType.Int);
            paramPID.Value = EmployeeID;
            SqlParameter paramDocType = new SqlParameter("@C3", SqlDbType.Int);
            paramDocType.Value = cmbDocuments.SelectedValue;
            SqlParameter paramRefrenceID = new SqlParameter("@C4", SqlDbType.Int);
            paramRefrenceID.Value = 2;


            /**add extra field from visa file */
            SqlParameter paramfilenumber = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramfilenumber.Value = numbertextbox.Text;
            SqlParameter paramnafileissueplace = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramnafileissueplace.Value = issueplacetext.Text;
            SqlParameter paramfileissuedate = new SqlParameter("@C7", SqlDbType.Date);
            paramfileissuedate.Value = docissueplacepicker.Value;
            SqlParameter paramfileexpiraydate = new SqlParameter("@C8", SqlDbType.Date);
            paramfileexpiraydate.Value = docexpirefatepicker.Value;

            /**add extra field from visa file */


            if (EmployeeID != 0)
            {
             
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    if (cmbDocuments.Text == "Select")
                    {
                        MessageBox.Show("Please Select Document Type  . !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    if (numbertextbox.Text == "")
                    {
                        MessageBox.Show("Please insert Document  Number. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    if (issueplacetext.Text == "")
                    {
                        MessageBox.Show("Please insert Document Issue Place. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        SQLCONN.OpenConection();
                          SQLCONN.ExecuteQueries("update  Documents set documentValue=@C1,name=@C0,DocTypeID=@C3,Number=@C5,DocIssueplace=@C6,docissuedate=@C7,docexpiredate=@C8,CR_ID=@C2  where Doc_id = @ID ", paramfilename, paramnameOFfile, paramDocType, paramPID, paramfilenumber, paramnafileissueplace, paramfileissuedate, paramfileexpiraydate, paramDoc);
                      //  SQLCONN.ExecuteQueries("update  Documents set DocTypeID=@C3,Number=@C5,DocIssueplace=@C6,docissuedate=@C7,docexpiredate=@C8,CR_ID=@C2  where Doc_id = @ID ", paramDocType, paramPID, paramfilenumber, paramnafileissueplace, paramfileissuedate, paramfileexpiraydate, paramDoc);


                        MessageBox.Show("Record Updated Successfully");
                        EmployeeID = EMPID;
                        dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[CR_ID] ,[name],[documentValue]  ,[DocumentType].Doc_Type ,[RefrenceID],[Number] ,[DocIssueplace]  ,[docissuedate]  ,[docexpiredate] FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and CR_ID =  " + EmployeeID + " ");

                        //    ClearTextBoxes();
                        SQLCONN.CloseConnection();
                        cmbDocuments.Text = "Select";
                        Doctxt.Text = "";
                        numbertextbox.Text = "";
                        issueplacetext.Text = "";
                        docissueplacepicker.Value = DateTime.Now;
                        docexpirefatepicker.Value = DateTime.Now;
                    }
                }
                else
                {

                }


            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void firstnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddBtn.Visible = true;
            btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = false;
            firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
            cmbMartialStatus.Enabled = cmbGender.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = cmbCompany.Enabled = cmbnationality.Enabled = true;
            StartDatePicker.Enabled = true;
            EndDatePicker.Enabled = false;
            dataGridView1.DataSource = null;
            cmbCompany.Text = cmbEmployJobHistory.Text = cmbempdepthistory.Text = cmbPersonalStatusStatus.Text = "Select";
            StartDatePicker.Value = EndDatePicker.Value = DateTime.Now;
            ClearTextBoxes();

            // EmployeeForm_Load(sender, e);
            this.ActiveControl = firstnametxt;


        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            EmployeeID = EMPID;
            SqlParameter paramEmployeeID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramEmployeeID.Value = EmployeeID;
            if (EmployeeID == 0)
            {
                MessageBox.Show("Please Choose A Record !  ");

            }
            else
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID]  FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =@ID ", paramEmployeeID);

                }
                if (tabControl1.SelectedTab == tabControl1.TabPages[1])
                {


                   

                 dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[CR_ID] ,[name],[documentValue]  ,[DocumentType].Doc_Type ,[RefrenceID],[Number] ,[DocIssueplace]  ,[docissuedate]  ,[docexpiredate] FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and CR_ID =@ID ", paramEmployeeID);
                   



                }
                if (tabControl1.SelectedTab == tabControl1.TabPages[2])
                {

                      paramEmployeeID.Value = EmployeeID;

                   
                   
                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from employeehistory where employeeid=@ID", paramEmployeeID);



                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["SalaryTab"])
                {


                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  select SalaryDetID , SalaryTypeName 'Salary Type' ,SalaryDetails.Value from SalaryDetails,SalaryTypes where SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and SalaryDetails.EmployeeID = @ID ", paramEmployeeID);
                    //  this.dataGridView5.Columns["SalaryDetID"].Visible = false;

                }


            }

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

                        filenumbertxt.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        //EMPID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        CurrentEmployeeIDtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        lastnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        cmbGender.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                        cmbPersonalStatusStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                        cmbEmployJobHistory.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                        cmbempdepthistory.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                        cmbCompany.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                        if (dataGridView1.CurrentRow.Cells[13].Value == null || dataGridView1.CurrentRow.Cells[13].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView1.CurrentRow.Cells[13].Value.ToString()))
                        {
                            EndDatePicker.Value = DateTime.Now;

                        }
                        else
                        {
                            EndDatePicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString());

                        }

                        if (dataGridView1.CurrentRow.Cells[12].Value == null || dataGridView1.CurrentRow.Cells[12].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView1.CurrentRow.Cells[12].Value.ToString()))
                        {
                            StartDatePicker.Value = DateTime.Now;

                        }

                        else
                        {
                            StartDatePicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString());

                        }

                        cmbnationality.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                        txtFileNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
                        txtvisanumber.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();











                        EmployeeID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        EMPID = EmployeeID;
                        //CurrentEmployeeIDtxt.Text = EmployeeID.ToString();
                        AddBtn.Visible = false;
                        btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
                        firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
                        cmbMartialStatus.Enabled = cmbGender.Enabled = cmbCompany.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = cmbnationality.Enabled = true;
                        StartDatePicker.Enabled = true;
                        //dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[EmployeeID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] ,[EmployeeID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and EmployeeID =  " + EmployeeID + " ");
                        //dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[CR_ID] ,[name],[documentValue] ,[url] ,[last_update] ,[DocumentType].Doc_Type ,[RefrenceID]FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and CR_ID =  " + EmployeeID + " ");

                    }
                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

                        EmployeeID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Contacttxt.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                        cmbcontact.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                        //firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();     
                        //cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


                    }
                }
            }
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

                        dOCID = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                        EmployeeID = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString());
                        Doctxt.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString(); 
                        cmbDocuments.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
                        numbertextbox.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
                        issueplacetext.Text = dataGridView3.Rows[e.RowIndex].Cells[7].Value.ToString();
                        docissueplacepicker.Value = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells[8].Value.ToString());
                        docexpirefatepicker.Value = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells[9].Value.ToString());

                        CommonClass.DocPath = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();


                       
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnaddhitory_Click(object sender, EventArgs e)
        {



            if (StartDatePicker.Checked == false)
            {
                DateTime enter_date = DateTime.Now.Date;
                StartDatePicker.Value = enter_date;

            }
            else if (EndDatePicker.Checked == false)
            {

                DateTime enter_date = DateTime.Now.Date;
                EndDatePicker.Value = enter_date;


            }

            else if ((int)cmbEmployJobHistory.SelectedValue == -1)

            {
                MessageBox.Show("Please Select a Job !!");


            }
            else if ((int)cmbempdepthistory.SelectedValue == -1)

            {

                MessageBox.Show("Please Select a department !!");

            }

            else if ((int)cmbPersonalStatusStatus.SelectedValue == -1)

            {
                MessageBox.Show("Please Select a status !!");


            }
            else
            {
                SqlParameter paramStatusHistory = new SqlParameter("@C1", SqlDbType.Int);
                paramStatusHistory.Value = cmbPersonalStatusStatus.SelectedValue;
                SqlParameter paramJobHistory = new SqlParameter("@C2", SqlDbType.NVarChar);
                paramJobHistory.Value = cmbEmployJobHistory.SelectedValue;
                SqlParameter ParamtDepartmentHistory = new SqlParameter("@C3", SqlDbType.Int);
                ParamtDepartmentHistory.Value = cmbempdepthistory.SelectedValue;
                SqlParameter paramstartdate = new SqlParameter("@C4", SqlDbType.Date);
                paramstartdate.Value = StartDatePicker.Value;
                SqlParameter paramenddate = new SqlParameter("@C5", SqlDbType.Date);
                paramenddate.Value = StartDatePicker.Value;

                SqlParameter paramPID = new SqlParameter("@id", SqlDbType.Int);
                paramPID.Value = EmployeeID;
                //EmployeeID = EMPID;
                if (EmployeeID != 0)
                {
                    SQLCONN.OpenConection();



                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SQLCONN.ExecuteQueries("insert into EmploymentStatus (EmploymentStatusID,JobID,DeptID,StartDate,EndDate,EmployeeID) values (@C1,@C2,@C3,@C4,@C5,@id)",
                                                    paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramenddate, paramPID);
                        MessageBox.Show("Record saved Successfully");

                        dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT [EmployeeID],StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate]  FROM [DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and EmployeeID =  " + EmployeeID + " ");

                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Please Choose A Record !  ");
                    tabControl1.Enabled = false;
                }
                SQLCONN.CloseConnection();

            }



        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btndeletehistory_Click(object sender, EventArgs e)
        {
            SqlParameter paramid_History = new SqlParameter("@id", SqlDbType.Int);
            paramid_History.Value = id_History;



            if (EMPID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from [EmploymentStatus] where id_History=@id", paramid_History);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([id_History]) from[EmploymentStatus] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[EmploymentStatus]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");
                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate]  FROM [DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and EmployeeID =  " + EmployeeID + " ");

                    SQLCONN.CloseConnection();
                    ClearTextBoxes();



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

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            foreach (DataGridViewRow rw in this.dataGridView4.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                    }
                    else
                    {

                        id_History = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString());
                        dtphistorydate.Value = Convert.ToDateTime(dataGridView4.Rows[e.RowIndex].Cells[1].Value);
                        //EmployeeID = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString());
                        richhistoryvalue.Text = (dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString());

                    }
                }
            }
        }

        private void btnupdatehistory_Click(object sender, EventArgs e)
        {
            SqlParameter paramStatusHistory = new SqlParameter("@C1", SqlDbType.Int);
            paramStatusHistory.Value = cmbPersonalStatusStatus.SelectedValue;
            SqlParameter paramJobHistory = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramJobHistory.Value = cmbEmployJobHistory.SelectedValue;
            SqlParameter ParamtDepartmentHistory = new SqlParameter("@C3", SqlDbType.Int);
            ParamtDepartmentHistory.Value = cmbempdepthistory.SelectedValue;
            SqlParameter paramstartdate = new SqlParameter("@C4", SqlDbType.Date);
            paramstartdate.Value = StartDatePicker.Value;
            SqlParameter paramenddate = new SqlParameter("@C5", SqlDbType.Date);
            paramenddate.Value = StartDatePicker.Value;

            SqlParameter paramid_History = new SqlParameter("@id", SqlDbType.Int);
            paramid_History.Value = id_History;
            EmployeeID = EMPID;


            if (StartDatePicker.Checked == false)
            {
                DateTime enter_date = new DateTime(1900, 01, 01);
                StartDatePicker.Value = enter_date;

            }
            if (EndDatePicker.Checked == true)
            {

                DateTime enter_date = new DateTime(1900, 01, 01);
                EndDatePicker.Value = enter_date;


            }


            if (EmployeeID != 0)
            {
                SQLCONN.OpenConection();



                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.ExecuteQueries("update  EmploymentStatus set EmploymentStatusID=@C1,JobID=@C2,DeptID=@C3,StartDate=@C4,EndDate=@C5 where  id_History =@id ",
                                                paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramenddate, paramid_History);
                    MessageBox.Show("Record saved Successfully");

                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate]  FROM [DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and EmployeeID =  " + EmployeeID + " ");

                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Please Choose A Person !  ");
                tabControl1.Enabled = false;
            }
            SQLCONN.CloseConnection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbldatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");

        }

        private void cmbPersonalStatusStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeIDtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmploymentHistory_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EMPID != 0)
            {
                SqlParameter paramSalaryType = new SqlParameter("@C1", SqlDbType.Int);
                paramSalaryType.Value = cmbsalarytype.SelectedValue;
                SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);


                SqlParameter paramemployee = new SqlParameter("@ID", SqlDbType.NVarChar);
                paramemployee.Value = EmployeeID;


                /*logg*/
                SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
                paramuser.Value = lblusername.Text;
                SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
                paramdatetimeLOG.Value = lbldatetime.Text;
                SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
                parampc.Value = lblPC.Text;

                /*logg*/

                string userInput = txtvalue.Text;
                if (decimal.TryParse(userInput, out decimal inputValue)) // Try to parse input as decimal
                {
                    string formattedValue = inputValue.ToString("N2"); // Format decimal as string with 2 decimal places and thousands separator
                    txtvalue.Text = formattedValue; // Set the second text box to the formatted value
                }


                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();

                    SqlDataReader dr = SQLCONN.DataReader("select * from [SalaryDetails] where  EmployeeID= " + EmployeeID + " and SalaryTypeID= " + cmbsalarytype.SelectedValue + " ");

                    dr.Read();

                    if (dr.HasRows)
                    {
                        MessageBox.Show("This 'Salary Value For This Employee '  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        if ((int)cmbsalarytype.SelectedValue == 3)
                        { txtvalue.Text = txtvalue.Text + " " + "Houres Per Day "; }
                        if ((int)cmbsalarytype.SelectedValue == 4)
                        { txtvalue.Text = txtvalue.Text + " " + "Days Per Week "; }
                        if ((int)cmbsalarytype.SelectedValue == 5)
                        { txtvalue.Text = txtvalue.Text + " " + "Months"; }
                        if ((int)cmbsalarytype.SelectedValue == 6)
                        { txtvalue.Text = txtvalue.Text + " " + "Months"; }
                        if ((int)cmbsalarytype.SelectedValue == 8)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text =   "Provided By Company";

                            }
                        }
                        if ((int)cmbsalarytype.SelectedValue == 9)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text = "Provided By Company";

                            }
                        }
                        if ((int)cmbsalarytype.SelectedValue == 10)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text =  "Provided By Company";

                            }
                        }
                        if ((int)cmbsalarytype.SelectedValue == 11)

                        {
                            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                            TextInfo textInfo = cultureInfo.TextInfo;
                            txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                            txtvalue.Text = txtvalue.Text + " " + "Days/Year after finish Contract Period";
                        }
                        if ((int)cmbsalarytype.SelectedValue == 12)
                        {
                            if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                            {
                                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;
                                txtvalue.Text = textInfo.ToTitleCase(txtvalue.Text);
                                txtvalue.Text =   "Provided By Company";

                            }
                        }



                        paramValue.Value = txtvalue.Text;
                        SQLCONN.ExecuteQueries("insert into SalaryDetails ( EmployeeID,SalaryTypeID,Value) values (@ID,@C1,@C2)",
                                                       paramemployee, paramSalaryType, paramValue);
                        MessageBox.Show("Record saved Successfully");
                        cmbsalarytype.SelectedValue = 0;
                        txtvalue.Text = "";
                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (Logvalueid, logvalue ,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES (@C1, ' Salary Info For Employee ID : '  +  @ID  ,'#','#',@datetime,@pc,@user,'Insert')", paramSalaryType, paramemployee, paramdatetimeLOG, parampc, paramuser);


                        dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  select SalaryDetID , SalaryTypeName 'Salary Type' ,SalaryDetails.Value from SalaryDetails,SalaryTypes where SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and SalaryDetails.EmployeeID = @ID ", paramemployee);
                        this.dataGridView5.Columns["SalaryDetID"].Visible = false;
                        // ClearTextBoxes();
                        cmbsalarytype.Text = "Select";
                        txtvalue.Text = "";
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter ParamEmployee = new SqlParameter("@ID", SqlDbType.NVarChar);
            ParamEmployee.Value = EmployeeID;
            SqlParameter paramSalaryType = new SqlParameter("@C1", SqlDbType.Int);
            paramSalaryType.Value = cmbsalarytype.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramValue.Value = txtvalue.Text;

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
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from SalaryDetails where EmployeeID=@ID and SalaryDetails.Value=@C2 and SalaryDetails.SalaryTypeID=@C1 ", ParamEmployee, paramValue, paramSalaryType);
                    MessageBox.Show("Record Deleted Successfully");
                    cmbsalarytype.SelectedValue = 0;
                    txtvalue.Text = "";

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog ( logvalue ,LogValueID,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES (' Salary Info For Employee ID : '  +  @ID ,@C1 ,'#','#',@datetime,@pc,@user,'Delete')", ParamEmployee, paramSalaryType, paramdatetimeLOG, parampc, paramuser);


                    SQLCONN.CloseConnection();
                    EmployeeID = EMPID;
                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  select SalaryDetID , SalaryTypeName 'Salary Type' ,SalaryDetails.Value from SalaryDetails,SalaryTypes where SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and SalaryDetails.EmployeeID = @ID ", ParamEmployee);
                    this.dataGridView5.Columns["SalaryDetID"].Visible = false;
                    cmbsalarytype.Text = "Select";
                    txtvalue.Text = "";


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

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if ((int)cmbsalarytype.SelectedValue == 12 || (int)cmbsalarytype.SelectedValue == 10 || (int)cmbsalarytype.SelectedValue == 9 || (int)cmbsalarytype.SelectedValue == 8 || (int)cmbsalarytype.SelectedValue == 7)
            //{
            //    lblprovide.Visible = true;
            //}
            //else
            //{
            //    lblprovide.Visible = false;

            //}
            foreach (DataGridViewRow rw in this.dataGridView5.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                    }
                    else
                    {

                        cmbsalarytype.Text = (dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString());
                        txtvalue.Text = (dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString());
                        SalaryID = Convert.ToInt32(dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlParameter paramSalaryType = new SqlParameter("@C1", SqlDbType.Int);
            paramSalaryType.Value = cmbsalarytype.SelectedValue;
            SqlParameter paramValue = new SqlParameter("@C2", SqlDbType.NVarChar);

            SqlParameter paramemployee = new SqlParameter("@ID", SqlDbType.Int);
            paramemployee.Value = EmployeeID;

            SqlParameter paramSalaryID = new SqlParameter("@SalaryID", SqlDbType.Int);
            paramSalaryID.Value = SalaryID;

            /* for log */

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = lblusername.Text;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = lblPC.Text;
            SqlParameter paramType = new SqlParameter("@type", SqlDbType.NVarChar);
            paramType.Value = "Update";
            /* for log */

            string userInput = txtvalue.Text;
            if (decimal.TryParse(userInput, out decimal inputValue)) // Try to parse input as decimal
            {
                string formattedValue = inputValue.ToString("N2"); // Format decimal as string with 2 decimal places and thousands separator
                txtvalue.Text = formattedValue; // Set the second text box to the formatted value
            }


            if (EmployeeID != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    if ((int)cmbsalarytype.SelectedValue == 3)
                    { txtvalue.Text = txtvalue.Text + " " + "Houres Per Day "; }
                    if ((int)cmbsalarytype.SelectedValue == 4)
                    { txtvalue.Text = txtvalue.Text + " " + "Days Per Week "; }
                    if ((int)cmbsalarytype.SelectedValue == 5)
                    { txtvalue.Text = txtvalue.Text + " " + "Months"; }
                    if ((int)cmbsalarytype.SelectedValue == 6)
                    { txtvalue.Text = txtvalue.Text + " " + "Months"; }
                    if ((int)cmbsalarytype.SelectedValue == 8)
                    {
                        if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES"))
                        {
                            txtvalue.Text =  "Provided By Company";
                        }
                    }
                    if ((int)cmbsalarytype.SelectedValue == 9)
                    {
                        if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES"))
                        {
                            txtvalue.Text =  "Provided By Company";
                        }
                    }
                    if ((int)cmbsalarytype.SelectedValue == 10)
                    {
                        if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES"))
                        {
                            txtvalue.Text =  "Provided By Company";
                        }
                    }
                    if ((int)cmbsalarytype.SelectedValue == 11)
                    { txtvalue.Text = txtvalue.Text + " " + "Days/Year after finish Contract Period"; }
                    if ((int)cmbsalarytype.SelectedValue == 12)
                    {
                        if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                        {
                            txtvalue.Text =  "Provided By Company";
                        }
                    }


                    paramValue.Value = txtvalue.Text;


                    SQLCONN.OpenConection();


                    /**logtable */
                    DataTable originalData = new DataTable();
                    string connectionString = SQLCONN.ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = " SELECT * FROM  SalaryDetails  where EmployeeID=@ID  and SalaryDetID=@SalaryID ";
                        SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                        da.SelectCommand.Parameters.AddWithValue("@ID", EmployeeID);
                        da.SelectCommand.Parameters.AddWithValue("@SalaryID", SalaryID);
                        originalData = new DataTable();
                        da.Fill(originalData);
                    }






                    SQLCONN.ExecuteQueries("update  SalaryDetails set SalaryTypeID=@C1,Value=@C2 where EmployeeID=@ID  and SalaryDetID=@SalaryID",
                                                   paramSalaryType, paramValue, paramemployee, paramSalaryID);
                    MessageBox.Show("Record Updated Successfully");
                    

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM SalaryDetails  where EmployeeID=@ID  and SalaryDetID=@SalaryID ";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@ID", EmployeeID);
                        adapter.SelectCommand.Parameters.AddWithValue("@SalaryID", SalaryID);

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
                            using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@ID, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                            {
                                command.Parameters.AddWithValue("@ID", paramemployee);
                                foreach (string columnName in changedColumns)
                                {
                                    object originalValue = originalData.Rows[0][columnName];
                                    object updatedValue = updatedData.Rows[0][columnName];
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@ID", "For EmployeeID" + "-" + EmployeeID);
                                    command.Parameters.AddWithValue("@ColumnName", cmbsalarytype.Text);
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

                    cmbsalarytype.SelectedValue = 0;
                    txtvalue.Text = "";

                    /**logtable*/







                    EmployeeID = EMPID;
                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  select SalaryDetID , SalaryTypeName 'Salary Type' ,SalaryDetails.Value from SalaryDetails,SalaryTypes where SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and SalaryDetails.EmployeeID = @ID ", paramemployee);
                    this.dataGridView5.Columns["SalaryDetID"].Visible = false;
                    // ClearTextBoxes();
                    SQLCONN.CloseConnection();
                    cmbsalarytype.Text = "Select";
                    txtvalue.Text = "";

                }
                else
                {

                }


            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
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

                cmbempdepthistory.ValueMember = "DEPTID";
                cmbempdepthistory.DisplayMember = "Dept_Type_Name";
                cmbempdepthistory.DataSource = dt;
                cmbempdepthistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbempdepthistory.AutoCompleteSource = AutoCompleteSource.ListItems;





            }

            conn.Close();
        }

        private void cmbMartialStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPersonalStatusStatus.Focus();
                e.Handled = true;
            }
        }

        private void cmbPersonalStatusStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCompany.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
                cmbPersonalStatusStatus.SelectionStart = cmbPersonalStatusStatus.Text.Length; // set the selection start to the end of the text
                cmbPersonalStatusStatus.SelectionLength = 0; // clear the selection length
                if (cmbPersonalStatusStatus.Items.Contains(cmbPersonalStatusStatus.Text))
                {
                    cmbPersonalStatusStatus.SelectedItem = cmbPersonalStatusStatus.Text;
                }








            }
        }

        private void EmployeeIDtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                firstnametxt.Focus();
                e.Handled = true;
            }
        }

        private void cmbCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbempdepthistory.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
                cmbCompany.SelectionStart = cmbCompany.Text.Length; // set the selection start to the end of the text
                cmbCompany.SelectionLength = 0; // clear the selection length
                if (cmbCompany.Items.Contains(cmbCompany.Text))
                {
                    cmbCompany.SelectedItem = cmbCompany.Text;
                }

            }
        }

        private void cmbempdepthistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEmployJobHistory.Focus();
                e.Handled = true;
            }
        }

        private void cmbEmployJobHistory_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                // Handle the Enter key press
                var selectedItem = cmbEmployJobHistory.SelectedItem as DataRowView;

                if (selectedItem != null)
                {
                    // Access the selected item's properties
                    var JobID = selectedItem["JobID"].ToString();
                    var JobTitleEN = selectedItem["JobTitleEN"].ToString();
                }

                // Prevent the ComboBox from processing the Enter key
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void StartDatePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EndDatePicker.Focus();
                e.Handled = true;
            }

        }

        private void btnprtjoboffer_Click(object sender, EventArgs e)
        {
            CommonClass.EmployeeID = EmployeeID;
            if
                (EmployeeID == 0)
            {
                MessageBox.Show("Please Choose Record !");
            }
            else
            {
                var form = new JobOfferLTR();
                // this.Hide();
                form.ShowDialog();


            }

        }

        private void btnprtvisareq_Click(object sender, EventArgs e)
        {
            CommonClass.EmployeeID = EmployeeID;
            if
                (EmployeeID == 0)
            {
                MessageBox.Show("Please Choose Record !");
            }
            else
            {
                var form = new VisaOfferLTR();
                //    this.Hide();
                form.ShowDialog();


            }
        }

        private void cmbCompany_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void filenumbertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void cmbsalarytype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cmbsalarytype.SelectedValue == 12 || (int)cmbsalarytype.SelectedValue == 10 || (int)cmbsalarytype.SelectedValue == 9 || (int)cmbsalarytype.SelectedValue == 8 || (int)cmbsalarytype.SelectedValue == 7)
            {
                lblprovide.Visible = true;
            }
            else
            {
                lblprovide.Visible = false;

            }
        }

        private void btnnewJob_Click(object sender, EventArgs e)
        {
            FrmJobsNew frmJobs = new FrmJobsNew();
            // this.Hide();
            frmJobs.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void txtvalue_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbsalarytype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SalaryTab_Click(object sender, EventArgs e)
        {

        }

        private void issueplacetext_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Visible = true;
        }

        private void cmbnationality_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
                e.Handled = true;

            }
        }

        private void cmbEmployJobHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
          

        }

        private void cmbPersonalStatusStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                // Perform some action here, such as selecting the current value
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlParameter paramPID = new SqlParameter("@C1", SqlDbType.Int);
            paramPID.Value = EmployeeID;
            SqlParameter paramHistoryValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramHistoryValue.Value = richhistoryvalue.Text;
            SqlParameter paramDateHistory = new SqlParameter("@C3", SqlDbType.Date);
            paramDateHistory.Value = dtphistorydate.Value;


            if (EmployeeID != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    SQLCONN.OpenConection();
                    SqlDataReader dr = SQLCONN.DataReader("select  EmployeeID,HistoryValue,HistoryDate from EmployeeHistory where  EmployeeID= @C1 and HistoryValue=@C2 and HistoryDate=@C3  ", paramPID, paramHistoryValue, paramDateHistory);
                    dr.Read();


                    if (dr.HasRows)
                    {
                        MessageBox.Show("The 'Value' For This Employee  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        SQLCONN.ExecuteQueries("insert into EmployeeHistory ( EmployeeID,HistoryValue,HistoryDate) values (@C1,@C2,@C3) ",
                                                      paramPID, paramHistoryValue, paramDateHistory);
                        MessageBox.Show("Record saved Successfully");
                        dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  * FROM [DelmonGroupDB].[dbo].[EmployeeHistory] where EmployeeID =  " + EmployeeID + " ");
                        SQLCONN.CloseConnection();
                        richhistoryvalue.Text = "";
                        dtphistorydate.Value = DateTime.Now;

                    }
                }
                else
                {

                }
            }
            else 
            {
                MessageBox.Show("Please Select Record to Update");

            }


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlParameter paramid_History = new SqlParameter("@C0", SqlDbType.Int);
            paramid_History.Value = id_History;
            SqlParameter paramPID = new SqlParameter("@C1", SqlDbType.Int);
            paramPID.Value = EmployeeID;
            SqlParameter paramHistoryValue = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramHistoryValue.Value = richhistoryvalue.Text;
            SqlParameter paramDateHistory = new SqlParameter("@C3", SqlDbType.Date);
            paramDateHistory.Value = dtphistorydate.Value;
            SQLCONN.OpenConection();

            if (EmployeeID != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                 
                    //     SQLCONN.ExecuteQueries("update  Contacts set ContTypeID=@C1,ContValue=@C2 where Contact_ID=@C4",

                    SQLCONN.ExecuteQueries("update  EmployeeHistory set EmployeeID=@C1 ,HistoryValue=@C2,HistoryDate=@C3 where HistoryID=@C0",
                                                  paramPID, paramHistoryValue, paramDateHistory, paramid_History);
                    MessageBox.Show("Record Updated Successfully");

                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  * FROM [DelmonGroupDB].[dbo].[EmployeeHistory] where EmployeeID =  " + EmployeeID + " ");
                    richhistoryvalue.Text = "";
                    dtphistorydate.Value = DateTime.Now;

                }
                else
                {

                }


            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
            SQLCONN.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // SQLCONN.ExecuteQueries("update  EmployeeHistory set EmployeeID=@C1 ,HistoryValue=@C2,HistoryDate=@C3 where HistoryID=@C0",


            SqlParameter paramid_History = new SqlParameter("@C0", SqlDbType.Int);
            paramid_History.Value = id_History;
            if (id_History != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from EmployeeHistory where HistoryID=@C0", paramid_History);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max(HistoryID) from[EmployeeHistory] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[EmployeeHistory]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");
                    SQLCONN.CloseConnection();
                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  * FROM [DelmonGroupDB].[dbo].[EmployeeHistory] where EmployeeID =  " + EmployeeID + " ");
                    richhistoryvalue.Text = "";
                    richhistoryvalue.Text = "";
                    dtphistorydate.Value = DateTime.Now;


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

        private void btnshowDoc_Click(object sender, EventArgs e)
        {

             string fileName = CommonClass.DocPath;
       
            try
            {

                if (File.Exists(fileName))
                {
                    // Open the PDF document using the default PDF viewer application
                    Process.Start(fileName);
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }




        }

        private void btnnewJob_Click_1(object sender, EventArgs e)
        {
            FrmJobsNew frmJobs = new FrmJobsNew();
            // this.Hide();
            frmJobs.Show();
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (lblusertype.Text != "Admin")
            {
                if (e.ColumnIndex == 3) // Check if the cell is in the column you want to encrypt
                {
                    // string originalText = e.Value.ToString();
                    string encryptedText = "##Encrypted##";
                    // Use your own encryption method here
                    e.Value = encryptedText;
                }

            }
        }

        private void cmbEmployJobHistory_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Handle the Enter key press
                var selectedItem = cmbEmployJobHistory.SelectedItem as DataRowView;

                if (selectedItem != null)
                {
                    // Access the selected item's properties
                    var JobID = selectedItem["JobID"].ToString();
                    var JobTitleEN = selectedItem["JobTitleEN"].ToString();

                    // Use the selected item for further processing or display
                }

                // Prevent the ComboBox from processing the Enter key
                e.IsInputKey = true;
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

    

  

