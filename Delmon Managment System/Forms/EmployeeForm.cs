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

        // for check datagridview1
        private bool isUpdating = false;


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

        bool hasView = false;
        bool hasEdit = false;
        bool hasDelete = false;
        bool hasAdd = false;

        private byte[] fileContent;
        private string fileNames;
        private int currentRowIndex;





        public EmployeeForm()
        {

            InitializeComponent();
            //next and previous


            //  Font newFont = new Font("Times New Roman", 10);
            cmbEmployJobHistory.KeyDown += new KeyEventHandler(cmbEmployJobHistory_KeyDown);
            cmbCompany.KeyDown += new KeyEventHandler(cmbCompany_KeyDown);
            cmbPersonalStatusStatus.KeyDown += new KeyEventHandler(cmbPersonalStatusStatus_KeyDown);
            dtpDOB.ValueChanged += dtpDOB_ValueChanged;

            //  cmbPersonalStatusStatus.KeyPress += cmbPersonalStatusStatus_KeyPress;

         



        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }


        public void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox && control != filenumbertxt)
                    {
                        (control as TextBox).Clear();
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };

            func(Controls);

            // Clear combo boxes
            cmbGender.Text = "";
            cmbPersonalStatusStatus.Text = "";

            // Set filenumbertxt to its default value
            filenumbertxt.Text = "-";

            // Uncomment if you need to clear the DataGridView
            // dataGridView1.DataSource = null;
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
                if (permissionName.Contains("ViewPersonalInformation"))

                {
                    hasView = true;
                }
                if (permissionName.Contains("EditPersonalInformation"))
                {
                    hasEdit = true;
                }
                if (permissionName.Contains("DeletePersonalInformation"))
                {
                    hasDelete = true;
                }
                if (permissionName.Contains("AddPersonalInformation"))
                {
                    hasAdd = true;
                }
            }
            dr.Close();
            SQLCONN.CloseConnection();
            if (hasView == false)
            {
                MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Employeetxt.Enabled = false;
                groupBox2.Enabled = false;
                tabControl1.Enabled = false;

            }
            else

            {
                //PopulateDataGridView();

                groupBox2.Enabled = true;
                tabControl1.Enabled = true;
                Employeetxt.Enabled = true;
                if (hasEdit)
                {
                    // btnUpdate.Visible = true;
                    Updatebtn.Enabled = true;
                }
                else
                {
                    Updatebtn.Enabled = false;
                }
                if (hasDelete)
                {
                    DeleteBTN.Enabled = btndeletecontact.Enabled = btndeletedoc.Enabled = button4.Enabled = button1.Enabled = true;
                }
                else
                {
                    DeleteBTN.Enabled = btndeletecontact.Enabled = btndeletedoc.Enabled = button4.Enabled = button1.Enabled = false;

                }
                if (hasAdd)
                {
                    btnCancel.Enabled = AddBtn.Enabled = true;
                    btnNew.Enabled = true;

                }
                else
                {
                    btnCancel.Enabled = AddBtn.Enabled = false;
                    btnNew.Enabled = false;


                }




                firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = false;
                cmbMartialStatus.Enabled = cmbGender.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = cmbnationality.Enabled = false;
                StartDatePicker.Enabled = EndDatePicker.Enabled = false;






                lblusername.Text = CommonClass.LoginUserName;
                lblusertype.Text = CommonClass.Usertype;
                lblemail.Text = CommonClass.Email;
                lblPC.Text = Environment.MachineName;
                loggedEmpolyeeID = CommonClass.EmployeeID;
                lblFullname.Text = CommonClass.LoginEmployeeName;

                SqlParameter paramloggiedemployeeid = new SqlParameter("@C1", SqlDbType.NVarChar);
                paramloggiedemployeeid.Value = loggedEmpolyeeID;
                SQLCONN.OpenConection();






                this.timer1.Interval = 1000;
                timer1.Start();

                this.ActiveControl = firstnametxt;







                cmbCompany.ValueMember = "COMPID";
                cmbCompany.DisplayMember = "COMPName_EN";
                cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID,COMPName_EN FROM Companies");



                cmbDocuments.ValueMember = "DocType_ID";
                cmbDocuments.DisplayMember = "Doc_Type";
                cmbDocuments.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT DocType_ID,Doc_Type FROM DocumentType");

                cmbcontact.ValueMember = "ContTypeID";
                cmbcontact.DisplayMember = "ContType";
                cmbcontact.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT ContTypeID ,ContType FROM ContactTypes ");

                cmbPersonalStatusStatus.ValueMember = "StatusID";
                cmbPersonalStatusStatus.DisplayMember = "StatusValue";
                cmbPersonalStatusStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  StatusID , StatusValue  from StatusTBL where RefrenceID=2  ");
                cmbPersonalStatusStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbPersonalStatusStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbEmployJobHistory.ValueMember = "JobID";
                cmbEmployJobHistory.DisplayMember = "JobTitleEN";
                cmbEmployJobHistory.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT JobID,JobTitleEN FROM JOBS ORDER BY JobTitleEN;");
                cmbEmployJobHistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbEmployJobHistory.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbissueplace.ValueMember = "Consulates.ConsulateID";
                cmbissueplace.DisplayMember = "ConsulateCity";
                cmbissueplace.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId ORDER BY ConsulateCity;");
                cmbissueplace.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbissueplace.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbsalarytype.ValueMember = "SalaryTypeID";
                cmbsalarytype.DisplayMember = "SalaryTypeName";
                cmbsalarytype.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select SalaryTypeID,SalaryTypeName from SalaryTypes");
                cmbsalarytype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbsalarytype.AutoCompleteSource = AutoCompleteSource.ListItems;


                cmbnationality.ValueMember = "CountryId";
                cmbnationality.DisplayMember = "NationalityName";
                cmbnationality.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select CountryId,NationalityName from Countries ORDER BY NationalityName;");
                cmbnationality.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbnationality.AutoCompleteSource = AutoCompleteSource.ListItems;




                cmbPersonalStatusStatus.Text = "Select";
                cmbempdepthistory.Text = "Select";
                CurrentEmployeeIDtxt.Enabled = true;


                SQLCONN.CloseConnection();
            }

        }

        //next

        private DataTable employeeDataTable = new DataTable();
        private void PopulateDataGridView(string filter = "")
        {
            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            {
                string query = @"
            SELECT e.EmployeeID, e.CurrentEmpID, e.FirstName, e.SecondName, e.ThirdName, e.LastName, e.Gender, e.MartialStatus, s.StatusValue, j.JobTitleEN, dt.Dept_Type_Name, c.COMPName_EN, e.startdate, e.enddate, cn.NationalityName, v.FileNumber, v.VISANumber,e.DOB
            FROM Employees e
            INNER JOIN StatusTBL s ON e.EmploymentStatusID = s.StatusID
            INNER JOIN JOBS j ON e.JobID = j.JobID
            INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID
            INNER JOIN DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
            INNER JOIN Companies c ON d.COMPID = c.COMPID
            INNER JOIN Countries cn ON e.NationalityID = cn.CountryId
            LEFT JOIN VISAJobList v ON e.EmployeeID = v.EmployeeID
            WHERE (e.EmployeeID = @filter OR @filter = '')
            AND (e.EmployeeID != 0)
            ORDER BY e.EmployeeID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@filter", filenumbertxt.Text);
                }
                else
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@filter", filter);
                }

                employeeDataTable.Clear();
                adapter.Fill(employeeDataTable);

                dataGridView1.DataSource = employeeDataTable;

                if (employeeDataTable.Rows.Count > 0)
                {
                    DisplayEmployeeData(currentRowIndex);
                }
                else
                {
                    // Clear text boxes if no data found
                    ClearEmployeeData();
                }
            }
        }
        private void DisplayEmployeeData(int rowIndex)
        {
            if (employeeDataTable.Rows.Count == 0 || rowIndex < 0 || rowIndex >= employeeDataTable.Rows.Count)
            {
                return;
            }

            DataRow row = employeeDataTable.Rows[rowIndex];

            filenumbertxt.Text = row["EmployeeID"].ToString();
            CurrentEmployeeIDtxt.Text = row["CurrentEmpID"].ToString();
            firstnametxt.Text = row["FirstName"].ToString();
            secondnametxt.Text = row["SecondName"].ToString();
            thirdnametxt.Text = row["ThirdName"].ToString();
            lastnametxt.Text = row["LastName"].ToString();
            cmbGender.Text = row["Gender"].ToString();
            cmbMartialStatus.Text = row["MartialStatus"].ToString();
            cmbPersonalStatusStatus.Text = row["StatusValue"].ToString();
            cmbEmployJobHistory.Text = row["JobTitleEN"].ToString();
            cmbempdepthistory.Text = row["Dept_Type_Name"].ToString();
            cmbCompany.Text = row["COMPName_EN"].ToString();

            if (row["enddate"] == DBNull.Value)
            {
                EndDatePicker.Value = DateTime.Now;
            }
            else
            {
                EndDatePicker.Value = Convert.ToDateTime(row["enddate"]);
            }

            if (row["startdate"] == DBNull.Value)
            {
                StartDatePicker.Value = DateTime.Now;
            }
            else
            {
                StartDatePicker.Value = Convert.ToDateTime(row["startdate"]);
            }
            if (row["DOB"] == DBNull.Value)
            {
                dtpDOB.Value = DateTime.Now;
            }
            else
            {
                dtpDOB.Value = Convert.ToDateTime(row["DOB"]);
            }

            cmbnationality.Text = row["NationalityName"].ToString();
            txtFileNumber.Text = row["FileNumber"].ToString();
            txtvisanumber.Text = row["VISANumber"].ToString();
            // Set the DataGridView's current cell to the corresponding row
            dataGridView1.ClearSelection();
            // dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0]; // Assuming the first column is always visible
            //dataGridView1.Rows[rowIndex].Selected = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();

            EMPID = EmployeeID;
            AddBtn.Visible = false;
            btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
            firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
            cmbMartialStatus.Enabled = cmbGender.Enabled = cmbCompany.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = cmbnationality.Enabled = true;
            StartDatePicker.Enabled = true;



            if (employeeDataTable.Rows.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(filenumbertxt.Text))
            {
                // Increment the currentRowIndex if filenumbertxt is empty
                if (currentRowIndex < employeeDataTable.Rows.Count - 1)
                {
                    currentRowIndex++;
                    DisplayEmployeeData(currentRowIndex);
                }
            }
            else
            {
                // Try to find the index corresponding to filenumbertxt.Text
                int requestedRowIndex = FindRowIndexByEmployeeID(filenumbertxt.Text);

                // If found and not the last row, move to the next row
                if (requestedRowIndex != -1 && requestedRowIndex < employeeDataTable.Rows.Count - 1)
                {
                    currentRowIndex = requestedRowIndex + 1;
                    DisplayEmployeeData(currentRowIndex);
               
                }

                SQLCONN.OpenConection();
                SqlParameter paramwemployeeID = new SqlParameter("@C1", SqlDbType.NVarChar);
                paramwemployeeID.Value = filenumbertxt.Text.Trim();
                dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT e.EmployeeID, e.CurrentEmpID, e.FirstName, e.SecondName, e.ThirdName, e.LastName, e.Gender, e.MartialStatus, s.StatusValue, j.JobTitleEN, dt.Dept_Type_Name, c.COMPName_EN, e.startdate, e.enddate, cn.NationalityName, v.FileNumber, v.VISANumber
            FROM Employees e
            INNER JOIN StatusTBL s ON e.EmploymentStatusID = s.StatusID
            INNER JOIN JOBS j ON e.JobID = j.JobID
            INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID
            INNER JOIN DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
            INNER JOIN Companies c ON d.COMPID = c.COMPID
            INNER JOIN Countries cn ON e.NationalityID = cn.CountryId
            LEFT JOIN VISAJobList v ON e.EmployeeID = v.EmployeeID
            WHERE  e.EmployeeID  != 0  AND e.EmployeeID =@C1 ORDER BY e.EmployeeID ",paramwemployeeID );
                SQLCONN.CloseConnection();


            }
        }

        private int FindRowIndexByEmployeeID(string employeeID)
        {
            // Iterate through the DataTable to find the row index based on the EmployeeID
            for (int i = 0; i < employeeDataTable.Rows.Count; i++)
            {
                if (employeeDataTable.Rows[i]["EmployeeID"].ToString() == employeeID)
                {
                    return i;
                }
            }
            // Return -1 if the EmployeeID is not found
            return -1;
        }


    

    

    private void btnPrevious_Click(object sender, EventArgs e)
        {
            EMPID = EmployeeID;
            AddBtn.Visible = false;
            btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
            firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
            cmbMartialStatus.Enabled = cmbGender.Enabled = cmbCompany.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = cmbnationality.Enabled = true;
            StartDatePicker.Enabled = true;

            if (employeeDataTable.Rows.Count == 0)
            {
                return;
            }

            // Decrement the currentRowIndex only if it is greater than 0
            if (currentRowIndex > 0)
            {
                currentRowIndex--;
                DisplayEmployeeData(currentRowIndex);
            }
            SQLCONN.OpenConection();
            SqlParameter paramwemployeeID = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramwemployeeID.Value = filenumbertxt.Text.Trim();
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@" SELECT e.EmployeeID, e.CurrentEmpID, e.FirstName, e.SecondName, e.ThirdName, e.LastName, e.Gender, e.MartialStatus, s.StatusValue, j.JobTitleEN, dt.Dept_Type_Name, c.COMPName_EN, e.startdate, e.enddate, cn.NationalityName, v.FileNumber, v.VISANumber
            FROM Employees e
            INNER JOIN StatusTBL s ON e.EmploymentStatusID = s.StatusID
            INNER JOIN JOBS j ON e.JobID = j.JobID
            INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID
            INNER JOIN DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
            INNER JOIN Companies c ON d.COMPID = c.COMPID
            INNER JOIN Countries cn ON e.NationalityID = cn.CountryId
            LEFT JOIN VISAJobList v ON e.EmployeeID = v.EmployeeID
            WHERE  e.EmployeeID  != 0  AND e.EmployeeID =@C1 ORDER BY e.EmployeeID ", paramwemployeeID);
            SQLCONN.CloseConnection();
        }
        private void ClearEmployeeData()
        {
            filenumbertxt.Clear();
            CurrentEmployeeIDtxt.Clear();
            firstnametxt.Clear();
            secondnametxt.Clear();
            thirdnametxt.Clear();
            lastnametxt.Clear();
            cmbGender.SelectedIndex = -1;
            cmbMartialStatus.SelectedIndex = -1;
            cmbPersonalStatusStatus.SelectedIndex = -1;
            cmbEmployJobHistory.SelectedIndex = -1;
            cmbempdepthistory.SelectedIndex = -1;
            cmbCompany.SelectedIndex = -1;
            EndDatePicker.Value = DateTime.Now;
            StartDatePicker.Value = DateTime.Now;
            cmbnationality.SelectedIndex = -1;
            txtFileNumber.Clear();
            txtvisanumber.Clear();
        }


        private void Employeetxt_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            try
            {
                string searchText = Employeetxt.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    dataGridView1.DataSource = null;
                    return;
                }

                SqlParameter paramEmployeenameSearch = new SqlParameter("@C1", SqlDbType.NVarChar);
                paramEmployeenameSearch.Value = searchText;
                SqlParameter paramloggiedemployeeid = new SqlParameter("@C2", SqlDbType.NVarChar);
                paramloggiedemployeeid.Value = loggedEmpolyeeID;

                SQLCONN.OpenConection();

                // if employess belong to IT showes all employee else show for the certian department 
                if (CommonClass.DeptID == 10103)
                {
                    string query = @"SELECT e.EmployeeID, e.CurrentEmpID, e.FirstName, e.SecondName, e.ThirdName, e.LastName, e.Gender, e.MartialStatus, s.StatusValue, j.JobTitleEN, dt.Dept_Type_Name, c.COMPName_EN, e.startdate, e.enddate, cn.NationalityName, v.FileNumber, v.VISANumber,e.DOB
    FROM Employees e
    INNER JOIN StatusTBL s ON e.EmploymentStatusID = s.StatusID
    INNER JOIN JOBS j ON e.JobID = j.JobID
    INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID
    INNER JOIN DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
    INNER JOIN Companies c ON d.COMPID = c.COMPID
    INNER JOIN Countries cn ON e.NationalityID = cn.CountryId
    LEFT JOIN VISAJobList v ON e.EmployeeID = v.EmployeeID
    WHERE ((LEN(@C1) = 1 AND (e.EmployeeID LIKE @C1 OR e.CurrentEmpID LIKE @C1))
           OR (LEN(@C1) > 1 AND (
               e.EmployeeID LIKE '%' + REPLACE(@C1, ' ', '') + '%'
               OR REPLACE(e.FirstName, ' ', '') + REPLACE(e.SecondName, ' ', '') + REPLACE(e.ThirdName, ' ', '') + REPLACE(e.LastName, ' ', '') LIKE '%' + REPLACE(@C1, ' ', '') + '%'
               OR e.FirstName LIKE '%' + @C1 + '%'
               OR e.SecondName LIKE '%' + @C1 + '%'
               OR e.ThirdName LIKE '%' + @C1 + '%'
               OR e.LastName LIKE '%' + @C1 + '%'
           )))
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
                        "WHERE (LEN(@C1) = 1 AND Employees.EmployeeID LIKE '%' + @C1 + '%' " +
                        "OR REPLACE(CONCAT_WS(' ', firstname, secondname, thirdname, lastname), ' ', '') LIKE '%' + REPLACE(@C1, ' ', '') + '%' " +
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
            catch (Exception ex)
            {
                // Display the error message
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            SqlParameter paramDOB = new SqlParameter("@C20", SqlDbType.Date);
            paramDOB.Value = dtpDOB.Value;





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
                    else if (dtpDOB.Checked == false)
                    {

                        DateTime enter_date = DateTime.Now.Date;
                        dtpDOB.Value = enter_date;


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

                        if ((int)cmbCompany.SelectedIndex == -1 || (int)cmbempdepthistory.SelectedIndex == -1)
                        {
                            if ((int)cmbPersonalStatusStatus.SelectedValue == 25 || (int)cmbPersonalStatusStatus.SelectedValue == 26 || (int)cmbPersonalStatusStatus.SelectedValue == 27)
                            {
                                SQLCONN.ExecuteQueries("update Employees set firstname =@C1,secondname=@C2,thirdname=@C3,lastname=@C4,Gender=@C5,MartialStatus=@C6,EmploymentStatusID=@C13,JobID=@C14,StartDate=@C16,EndDate=@C17,CurrentEmpID=@CurrentEmployeeID ,UserID=@user,PCNAME=@pc,NationalityID=@C19,DOB=@C20 where  EmployeeID= @id  ", paramPID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, paramStatusHistory, paramJobHistory, paramstartdate, paramenddate, paramEmployeeID, paramuser, parampc, paramNationality,paramDOB);

                            }

                            else
                            {
                                SQLCONN.ExecuteQueries("update Employees set firstname =@C1,secondname=@C2,thirdname=@C3,lastname=@C4,Gender=@C5,MartialStatus=@C6,EmploymentStatusID=@C13,JobID=@C14,StartDate=@C16,CurrentEmpID=@CurrentEmployeeID ,UserID=@user,PCNAME=@pc,NationalityID=@C19 , DOB=@C20 where  EmployeeID= @id  ", paramPID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, paramStatusHistory, paramJobHistory, paramstartdate, paramEmployeeID, paramuser, parampc, paramNationality, paramDOB);

                            }


                        }

                        else
                        {
                            if ((int)cmbPersonalStatusStatus.SelectedValue == 25 || (int)cmbPersonalStatusStatus.SelectedValue == 26 || (int)cmbPersonalStatusStatus.SelectedValue == 27)
                            {
                                SQLCONN.ExecuteQueries("update Employees set firstname =@C1,secondname=@C2,thirdname=@C3,lastname=@C4,Gender=@C5,MartialStatus=@C6,EmploymentStatusID=@C13,JobID=@C14,DeptID=@C15,StartDate=@C16,EndDate=@C17,COMPID=@C18,CurrentEmpID=@CurrentEmployeeID ,UserID=@user,PCNAME=@pc,NationalityID=@C19,DOB=@C20 where  EmployeeID= @id  ", paramPID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramenddate, paramcompany, paramEmployeeID, paramuser, parampc, paramNationality, paramDOB);

                            }

                            else
                            {
                                SQLCONN.ExecuteQueries("update Employees set firstname =@C1,secondname=@C2,thirdname=@C3,lastname=@C4,Gender=@C5,MartialStatus=@C6,EmploymentStatusID=@C13,JobID=@C14,DeptID=@C15,StartDate=@C16,COMPID=@C18,CurrentEmpID=@CurrentEmployeeID ,UserID=@user,PCNAME=@pc,NationalityID=@C19 , DOB=@C20 where  EmployeeID= @id  ", paramPID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramcompany, paramEmployeeID, paramuser, parampc, paramNationality, paramDOB);

                            }

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


                        /* Update visa Candidate status **/
                        if ((int)cmbPersonalStatusStatus.SelectedValue == 20)
                        {
                            SqlDataReader dr = SQLCONN.DataReader("SELECT FileNumber,VISANumber FROM [DelmonGroupDB].[dbo].[VISAJobList] where StatusID !=6 and EmployeeID=" + EMPID + " ");
                            if (dr.Read())
                            {
                                string Visanumber = dr["VISANumber"].ToString();
                                string filenumber = dr["FileNumber"].ToString();
                                if (DialogResult.Yes == MessageBox.Show("File number :" + filenumber + " for a requested candidate will realsed Automatically to 'SELECT/0', Do You Want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {
                                    dr.Dispose();
                                    dr.Close();
                                    SQLCONN.ExecuteQueries("update VISAJobList set [EmployeeID] =0 where  FileNumber= " + filenumber + " and VISANumber= " + Visanumber + " ");
                                }
                                dr.Dispose();
                                dr.Close();
                            }
                            dr.Dispose();
                            dr.Close();
                        }
                        /* Update visa Candidate status **/



                        MessageBox.Show("Record Updated Successfully");
                        // dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" SELECT id_History,[EmployeeID],NewID,StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate],[UserID],[DatetimeLog]  FROM[DelmonGroupDB].[dbo].[EmploymentStatus], JOBS, DEPARTMENTS, StatusTBL, DeptTypes  where   StatusTBL.StatusID = EmploymentStatus.EmploymentStatusID and DEPARTMENTS.DeptName = EmploymentStatus.DeptID   and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID  and JOBS.JobID = EmploymentStatus.JobID  and  NEWID = @C14  ", paramNewID);
                        //  dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Employees where  EmployeeID = '" + EMPID + "'");
                        string query = @"SELECT e.EmployeeID, e.CurrentEmpID, e.FirstName, e.SecondName, e.ThirdName, e.LastName, e.Gender, e.MartialStatus,
       s.StatusValue, j.JobTitleEN, dt.Dept_Type_Name, c.COMPName_EN, e.startdate, e.enddate,
       cn.NationalityName, v.FileNumber, v.VISANumber,e.DOB
FROM Employees e
INNER JOIN StatusTBL s ON e.EmploymentStatusID = s.StatusID
INNER JOIN JOBS j ON e.JobID = j.JobID
INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID
INNER JOIN DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
INNER JOIN Companies c ON d.COMPID = c.COMPID
INNER JOIN Countries cn ON e.NationalityID = cn.CountryId
LEFT JOIN VISAJobList v ON e.EmployeeID = v.EmployeeID
WHERE e.EmployeeID !=0 and e.EmployeeID= @id
ORDER BY e.EmployeeID";


                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramPID);




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

                SqlParameter paramDOB= new SqlParameter("@C20", SqlDbType.Date);
                paramDOB.Value = dtpDOB.Value;

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



                if (firstnametxt.Text != "" && cmbPersonalStatusStatus.Text != "Select" && cmbempdepthistory.Text != "Select" && cmbEmployJobHistory.Text != "Select")
                {
                    SQLCONN.OpenConection();
                    SqlDataReader dr = SQLCONN.DataReader("select  * from Employees where " +
                         " firstname=  @C1 and   SecondName =  @C2 and thirdname = @C3  and lastname = @C4", paramfirstname, paramsecondname, Paramthirdname, paramlastname);
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
                        
                        else if (dtpDOB.Checked==false)
                            {
                            DateTime enter_date = DateTime.Now.Date;
                            dtpDOB.Value = enter_date;
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
                            if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            {

                                if ((int)cmbPersonalStatusStatus.SelectedValue == 25 || (int)cmbPersonalStatusStatus.SelectedValue == 26 || (int)cmbPersonalStatusStatus.SelectedValue == 27)
                                {
                                    SQLCONN.ExecuteQueries("insert into Employees (EmployeeID, firstname,secondname,thirdname,lastname,Gender,MartialStatus,[PCNAME], EmploymentStatusID,JobID,DeptID,StartDate,EndDate,COMPID,UserID,CurrentEmpID,NationalityID,DOB)" +
                              " values (@EmployeeID,@C1,@C2,@C3,@C4,@C5,@C6,@pc,@C13,@C14,@C15,@C16,@C17,@C18,@C10,@CurrentEmployeeID,@C19,@C20)",
                                                         paramEmployeeID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, parampc, paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramenddate, paramcompany, paramUserID, paramCurrentEmployeeID, paramNationality, paramDOB);

                                }
                                else
                                {
                                    SQLCONN.ExecuteQueries("insert into Employees (EmployeeID, firstname,secondname,thirdname,lastname,Gender,MartialStatus,[PCNAME], EmploymentStatusID,JobID,DeptID,StartDate,COMPID,UserID,CurrentEmpID,NationalityID,DOB)" +
                              " values (@EmployeeID,@C1,@C2,@C3,@C4,@C5,@C6,@pc,@C13,@C14,@C15,@C16,@C18,@C10,@CurrentEmployeeID,@C19,@C20)",
                                                         paramEmployeeID, paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, parampc, paramStatusHistory, paramJobHistory, ParamtDepartmentHistory, paramstartdate, paramcompany, paramUserID, paramCurrentEmployeeID, paramNationality, paramDOB);

                                }


                                MessageBox.Show("Record saved Successfully");
                            }

                            SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (Logvalueid, logvalue ,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES (@EmployeeID, 'User Info' ,'#','#',@datetime,@pc,@user,'Insert')", paramEmployeeID, paramdatetimeLOG, parampc, paramuser);

                            btnNew.Visible = true;
                            CurrentEmployeeIDtxt.Text = EmployeeID.ToString();
                            btnaddhitory.PerformClick();

                            tabControl1.Enabled = true;

                            string query = @"SELECT e.EmployeeID, e.CurrentEmpID, e.FirstName, e.SecondName, e.ThirdName, e.LastName, e.Gender, e.MartialStatus,
       s.StatusValue, j.JobTitleEN, dt.Dept_Type_Name, c.COMPName_EN, e.startdate, e.enddate,
       cn.NationalityName, v.FileNumber, v.VISANumber, e.DOB
FROM Employees e
INNER JOIN StatusTBL s ON e.EmploymentStatusID = s.StatusID
INNER JOIN JOBS j ON e.JobID = j.JobID
INNER JOIN DEPARTMENTS d ON e.DeptID = d.DEPTID
INNER JOIN DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
INNER JOIN Companies c ON d.COMPID = c.COMPID
INNER JOIN Countries cn ON e.NationalityID = cn.CountryId
LEFT JOIN VISAJobList v ON e.EmployeeID = v.EmployeeID
WHERE e.EmployeeID !=0 and e.EmployeeID= @EmployeeID
ORDER BY e.EmployeeID";


                            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query, paramEmployeeID);







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

        private void UplodeBTN_Click(object sender, EventArgs e)
        {
            if (EMPID != 0)
            {
                if (cmbDocuments.Text == "Select" || cmbDocuments.Text == string.Empty)
                {
                    MessageBox.Show("Please select a document type.");
                }
                else
                {
                    SqlParameter paramFilename = new SqlParameter("@C0", SqlDbType.NVarChar);
                    SqlParameter paramFileContent = new SqlParameter("@C1", SqlDbType.VarBinary);
                    SqlParameter paramPID = new SqlParameter("@C2", SqlDbType.Int);
                    SqlParameter paramDocType = new SqlParameter("@C3", SqlDbType.Int);
                    SqlParameter paramRefrenceID = new SqlParameter("@C4", SqlDbType.Int);
                    SqlParameter paramFileNumber = new SqlParameter("@C5", SqlDbType.NVarChar);
                    SqlParameter paramFileIssuePlace = new SqlParameter("@C6", SqlDbType.NVarChar);
                    SqlParameter paramFileIssueDate = new SqlParameter("@C7", SqlDbType.Date);
                    SqlParameter paramFileExpiryDate = new SqlParameter("@C8", SqlDbType.Date);

                    if (fileName == null || fileContent == null)
                    {
                        paramFilename.Value = "";
                        paramFileContent.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFilename.Value = fileName;
                        paramFileContent.Value = fileContent;
                    }

                    paramPID.Value = EmployeeID;
                    paramDocType.Value = cmbDocuments.SelectedValue;
                    paramRefrenceID.Value = 2;
                    paramFileNumber.Value = numbertextbox.Text;
                    paramFileIssuePlace.Value = issueplacetext.Text;
                    paramFileIssueDate.Value = docissueplacepicker.Value;
                    paramFileExpiryDate.Value = docexpirefatepicker.Value;

                    if (DialogResult.Yes == MessageBox.Show("Do you want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        if (cmbDocuments.Text == "Select")
                        {
                            MessageBox.Show("Please select Document Type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (string.IsNullOrEmpty(numbertextbox.Text))
                        {
                            MessageBox.Show("Please insert Document Number.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (string.IsNullOrEmpty(issueplacetext.Text))
                        {
                            MessageBox.Show("Please insert Document Issue Place.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            SQLCONN.OpenConection();
                            SQLCONN.ExecuteQueries("INSERT INTO Documents" +
                                " (name, documentValue, CR_ID, DocTypeID, RefrenceID, Number, DocIssueplace, docissuedate, docexpiredate)" +
                                " VALUES (@C0, @C1, @C2, @C3, @C4, @C5, @C6, @C7, @C8)",
                                  paramFilename, paramFileContent, paramPID, paramDocType, paramRefrenceID, paramFileNumber, paramFileIssuePlace, paramFileIssueDate, paramFileExpiryDate);
                            dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [Doc_id]
      ,[CR_ID]
      ,[name]
      ,[documentValue]
      , Doc_Type
      ,[RefrenceID]
      ,[Number]
      ,[DocIssueplace]
      ,[docissuedate]
      ,[docexpiredate]
  FROM [DelmonGroupDB].[dbo].[Documents],DocumentType
  where DocumentType.DocType_ID=Documents.DocTypeID AND CR_ID = " + EmployeeID);
                            dataGridView3.Columns["documentValue"].Visible = false;
                            dataGridView3.Columns["name"].Visible = false;


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
                MessageBox.Show("Please select a record!");
            }



        }
        private void tabDoc_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            // Open file dialog to select a file to insert into the subfolder
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file to upload";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Check if the selected file exceeds 2 MB
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                const long twoMB = 2 * 1024 * 1024; // 2 MB in bytes

                if (fileInfo.Length > twoMB)
                {
                    MessageBox.Show("The selected file exceeds 2 MB. Please select a smaller file.", "File Size Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // Read the selected file into a byte array
                    fileContent = File.ReadAllBytes(openFileDialog.FileName);
                    fileName = Path.GetFileName(openFileDialog.FileName);
                    Doctxt.Text = openFileDialog.FileName;
                }


                ///* old methode save to sharea folder //
                //string directoryPath = @"\\192.168.1.8\HR SW Documents\";
                //string variable = cmbCompany.Text;

                //// Get all subfolder names in the directory
                //string[] subfolderNames = Directory.GetDirectories(directoryPath)
                //                                    .Select(Path.GetFileName)
                //                                    .ToArray();

                //// Check if the variable matches any of the subfolder names
                //if (subfolderNames.Contains(variable))
                //{
                //    // Open file dialog to select a file to insert into the subfolder
                //    OpenFileDialog openFileDialog = new OpenFileDialog();
                //    openFileDialog.Title = "Select a file to insert into the subfolder";

                //    if (openFileDialog.ShowDialog() == DialogResult.OK)
                //    {
                //        // Check if the selected file exceeds 2 MB
                //        FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                //        const long twoMB = 2 * 1024 * 1024; // 2 MB in bytes

                //        if (fileInfo.Length > twoMB)
                //        {
                //            MessageBox.Show("The selected file exceeds 2 MB. Please select a smaller file.", "File Size Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return;
                //        }
                //        else
                //        {
                //            // Insert the selected file into the matching subfolder
                //            string subfolderPath = Path.Combine(directoryPath, variable);
                //            textFilePath = openFileDialog.FileName;
                //            fileName = Path.GetFileName(textFilePath);
                //            destinationFilePath = Path.Combine(subfolderPath, fileName);

                //            byte[] fileContent = File.ReadAllBytes(textFilePath);

                //            Doctxt.Text = textFilePath;
                //            // MessageBox.Show("Uploaded Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("There is no folder in the server with company name " + cmbCompany.Text + " ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
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
                        dr.Dispose();
                        dr.Close();
                        SQLCONN.ExecuteQueries("insert into Contacts ( ContTypeID,ContValue,RefrenceID,CR_ID) values (@C1,@C2,@C3,@C4)",
                                                       paramContactType, paramContact, paramRefrenceID, paramPID);
                        MessageBox.Show("Record saved Successfully");

                        dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID] ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + EmployeeID + " ");
                        Contacttxt.Text = "";
                        cmbcontact.Text = "Select";
                        SQLCONN.CloseConnection();
                    }

                    else
                    {
                        dr.Dispose();
                        dr.Close();
                        SQLCONN.ExecuteQueries("insert into Contacts ( ContTypeID,ContValue,RefrenceID,CR_ID) values (@C1,@C2,@C3,@C4)",
                                                       paramContactType, paramContact, paramRefrenceID, paramPID);
                        MessageBox.Show("Record saved Successfully");

                        dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID] ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =  " + EmployeeID + " ");
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
                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [Doc_id]
      ,[CR_ID]
      ,[name]
      ,[documentValue]
      , Doc_Type
      ,[RefrenceID]
      ,[Number]
      ,[DocIssueplace]
      ,[docissuedate]
      ,[docexpiredate]
  FROM [DelmonGroupDB].[dbo].[Documents],DocumentType
  where DocumentType.DocType_ID=Documents.DocTypeID AND CR_ID = " + EmployeeID);
                    dataGridView3.Columns["documentValue"].Visible = false;
                    dataGridView3.Columns["name"].Visible = false;
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
            paramPID.Value = EmployeeID;

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
            //SqlParameter paramnameOFfile = new SqlParameter("@C1", SqlDbType.NVarChar);
            //paramnameOFfile.Value = destinationFilePath;

            SqlParameter paramFileContent = new SqlParameter("@C1", SqlDbType.VarBinary);

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

                        if (fileName == null || fileContent == null)
                        {
                            paramfilename.Value = "";
                            paramFileContent.Value = DBNull.Value;
                        }
                        else
                        {
                            paramfilename.Value = fileName;
                            paramFileContent.Value = fileContent;
                        }

                        SQLCONN.OpenConection();
                        SQLCONN.ExecuteQueries("update  Documents set documentValue=@C1,name=@C0,DocTypeID=@C3,Number=@C5,DocIssueplace=@C6,docissuedate=@C7,docexpiredate=@C8,CR_ID=@C2  where Doc_id = @ID ", paramfilename, paramFileContent, paramDocType, paramPID, paramfilenumber, paramnafileissueplace, paramfileissuedate, paramfileexpiraydate, paramDoc);
                        //  SQLCONN.ExecuteQueries("update  Documents set DocTypeID=@C3,Number=@C5,DocIssueplace=@C6,docissuedate=@C7,docexpiredate=@C8,CR_ID=@C2  where Doc_id = @ID ", paramDocType, paramPID, paramfilenumber, paramnafileissueplace, paramfileissuedate, paramfileexpiraydate, paramDoc);


                        MessageBox.Show("Record Updated Successfully");
                        EmployeeID = EMPID;
                        dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [Doc_id]
      ,[CR_ID]
      ,[name]
      ,[documentValue]
      , Doc_Type
      ,[RefrenceID]
      ,[Number]
      ,[DocIssueplace]
      ,[docissuedate]
      ,[docexpiredate]
  FROM [DelmonGroupDB].[dbo].[Documents],DocumentType
  where DocumentType.DocType_ID=Documents.DocTypeID  and CR_ID =  " + EmployeeID + " ");
                        dataGridView3.Columns["documentValue"].Visible = false;
                        dataGridView3.Columns["name"].Visible = false;



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
            paramPID.Value = EmployeeID;

        }

        private void firstnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (hasAdd)
            {
                AddBtn.Visible = true;
            }
            this.ActiveControl = firstnametxt;
            btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = false;
            firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
            dataGridView2.DataSource = dataGridView3.DataSource = dataGridView4.DataSource = dataGridView5.DataSource = null;
            cmbMartialStatus.Enabled = cmbGender.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = cmbCompany.Enabled = cmbnationality.Enabled = true;
            StartDatePicker.Enabled = true;
            dtpDOB.Enabled = true;
            EndDatePicker.Enabled = false;
            dataGridView1.DataSource = null;
            cmbCompany.Text = cmbEmployJobHistory.Text = cmbempdepthistory.Text = cmbPersonalStatusStatus.Text = cmbnationality.Text=cmbMartialStatus.Text = "Select";
            dtpDOB.Value= StartDatePicker.Value = EndDatePicker.Value = DateTime.Now;
            ClearTextBoxes();
            filenumbertxt.Text = "-";
            // EmployeeForm_Load(sender, e);
            EmployeeID = 0;

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            EmployeeID = EMPID;
            SqlParameter paramEmployeeID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramEmployeeID.Value = EmployeeID;
            if (EmployeeID == 0 || filenumbertxt.Text == string.Empty)
            {
                MessageBox.Show(" Please Choose A Record !  ");

            }
            else
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID]  FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =@ID ", paramEmployeeID);
                    Contacttxt.Text = "";
                    cmbcontact.Text = "Select";
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages[1])
                {




                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [Doc_id]
      ,[CR_ID]
      ,[name]
      ,[documentValue]
      , Doc_Type
      ,[RefrenceID]
      ,[Number]
      ,[DocIssueplace]
      ,[docissuedate]
      ,[docexpiredate]
  FROM [DelmonGroupDB].[dbo].[Documents],DocumentType
  where DocumentType.DocType_ID=Documents.DocTypeID  and CR_ID =@ID ", paramEmployeeID);
                    dataGridView3.Columns["documentValue"].Visible = false;
                    dataGridView3.Columns["name"].Visible = false;


                    cmbDocuments.Text = "Select";
                    Doctxt.Text = "";
                    numbertextbox.Text = "";
                    issueplacetext.Text = "";
                    docissueplacepicker.Value = DateTime.Now;
                    docexpirefatepicker.Value = DateTime.Now;


                }
                if (tabControl1.SelectedTab == tabControl1.TabPages[2])
                {

                    paramEmployeeID.Value = EmployeeID;



                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from employeehistory where employeeid=@ID", paramEmployeeID);

                    richhistoryvalue.Text = "";
                    dtphistorydate.Value = DateTime.Now;

                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["SalaryTab"])
                {

                    cmbsalarytype.Text = "Select";
                    txtvalue.Text = "";
                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  select SalaryDetID , SalaryTypeName 'Salary Type' ,SalaryDetails.Value from SalaryDetails,SalaryTypes where SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and SalaryDetails.EmployeeID = @ID ", paramEmployeeID);
                    //  this.dataGridView5.Columns["SalaryDetID"].Visible = false;
                    dataGridView5.Columns["Salary Type"].Width = 200;


                }


            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (isUpdating) return;  // Prevent reentrant call

            isUpdating = true;

            try
            {
                currentRowIndex = e.RowIndex; // Update the currentRowIndex

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                filenumbertxt.Text = row.Cells["EmployeeID"].Value?.ToString() ?? string.Empty;
                CurrentEmployeeIDtxt.Text = row.Cells["CurrentEmpID"].Value?.ToString() ?? string.Empty;
                firstnametxt.Text = row.Cells["FirstName"].Value?.ToString() ?? string.Empty;
                secondnametxt.Text = row.Cells["SecondName"].Value?.ToString() ?? string.Empty;
                thirdnametxt.Text = row.Cells["ThirdName"].Value?.ToString() ?? string.Empty;
                lastnametxt.Text = row.Cells["LastName"].Value?.ToString() ?? string.Empty;
                cmbGender.Text = row.Cells["Gender"].Value?.ToString() ?? string.Empty;
                cmbMartialStatus.Text = row.Cells["MartialStatus"].Value?.ToString() ?? string.Empty;
                cmbPersonalStatusStatus.Text = row.Cells["StatusValue"].Value?.ToString() ?? string.Empty;
                cmbEmployJobHistory.Text = row.Cells["JobTitleEN"].Value?.ToString() ?? string.Empty;
                cmbempdepthistory.Text = row.Cells["Dept_Type_Name"].Value?.ToString() ?? string.Empty;
                cmbCompany.Text = row.Cells["COMPName_EN"].Value?.ToString() ?? string.Empty;

                if (row.Cells["enddate"].Value == DBNull.Value)
                {
                    EndDatePicker.Value = DateTime.Now;
                }
                else
                {
                    EndDatePicker.Value = Convert.ToDateTime(row.Cells["enddate"].Value);
                }

                if (row.Cells["startdate"].Value == DBNull.Value)
                {
                    StartDatePicker.Value = DateTime.Now;
                }
                else
                {
                    StartDatePicker.Value = Convert.ToDateTime(row.Cells["startdate"].Value);
                }
                if (row.Cells["DOB"].Value == DBNull.Value)
                {
                    dtpDOB.Value = DateTime.Now;
                }
                else
                {
                    dtpDOB.Value = Convert.ToDateTime(row.Cells["DOB"].Value);
                }

                cmbnationality.Text = row.Cells["NationalityName"].Value?.ToString() ?? string.Empty;
                txtFileNumber.Text = row.Cells["FileNumber"].Value?.ToString() ?? string.Empty;
                txtvisanumber.Text = row.Cells["VISANumber"].Value?.ToString() ?? string.Empty;

                if (hasEdit)
                {
                    Updatebtn.Enabled = true;
                }
                else
                {
                    Updatebtn.Enabled = false;
                }

                if (hasDelete)
                {
                    DeleteBTN.Enabled = btndeletecontact.Enabled = btndeletedoc.Enabled = button4.Enabled = button1.Enabled = true;
                }
                else
                {
                    DeleteBTN.Enabled = btndeletecontact.Enabled = btndeletedoc.Enabled = button4.Enabled = button1.Enabled = false;
                }

                if (hasAdd)
                {
                    btnCancel.Enabled = AddBtn.Enabled = true;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnCancel.Enabled = AddBtn.Enabled = false;
                    btnNew.Enabled = false;
                }

                EmployeeID = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                EMPID = EmployeeID;
                AddBtn.Visible = false;
                btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
                firstnametxt.Enabled = secondnametxt.Enabled = thirdnametxt.Enabled = lastnametxt.Enabled = true;
                cmbMartialStatus.Enabled = cmbGender.Enabled = cmbCompany.Enabled = cmbempdepthistory.Enabled = cmbEmployJobHistory.Enabled = cmbPersonalStatusStatus.Enabled = cmbnationality.Enabled = true;
                StartDatePicker.Enabled = dtpDOB.Enabled=true ;

                // Selection will be handled by the SelectionChanged event
            }
            finally
            {
                isUpdating = false;  // Reset the flag
            }
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
                                txtvalue.Text = "Provided By Company";

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
                                txtvalue.Text = "Provided By Company";

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
                                txtvalue.Text = "Provided By Company";

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
                paramemployee.Value = EmployeeID;
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
            if (e.RowIndex == -1) return;

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
                            txtvalue.Text = "Provided By Company";
                        }
                    }
                    if ((int)cmbsalarytype.SelectedValue == 9)
                    {
                        if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES"))
                        {
                            txtvalue.Text = "Provided By Company";
                        }
                    }
                    if ((int)cmbsalarytype.SelectedValue == 10)
                    {
                        if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES"))
                        {
                            txtvalue.Text = "Provided By Company";
                        }
                    }
                    if ((int)cmbsalarytype.SelectedValue == 11)
                    { txtvalue.Text = txtvalue.Text + " " + "Days/Year after finish Contract Period"; }
                    if ((int)cmbsalarytype.SelectedValue == 12)
                    {
                        if (txtvalue.Text.Contains("yes") || txtvalue.Text.Contains("YES") || txtvalue.Text.Contains("Yes") || txtvalue.Text.Contains("YEs"))
                        {
                            txtvalue.Text = "Provided By Company";
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

                paramemployee.Value = EmployeeID;
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

            //if (e.KeyCode == Keys.Enter)
            //{
            //    // Handle the Enter key press
            //    var selectedItem = cmbEmployJobHistory.SelectedItem as DataRowView;

            //    if (selectedItem != null)
            //    {
            //        // Access the selected item's properties
            //        var JobID = selectedItem["JobID"].ToString();
            //        var JobTitleEN = selectedItem["JobTitleEN"].ToString();
            //    }

            //    // Prevent the ComboBox from processing the Enter key
            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //}

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
            EmployeeID = EMPID;
            SqlParameter paramEmployeeID = new SqlParameter("@ID", SqlDbType.NVarChar);
            paramEmployeeID.Value = filenumbertxt.Text;
            if (EmployeeID==0&& filenumbertxt.Text == string.Empty)
            {
                MessageBox.Show("Please Choose A Record !  ");

            }
            else
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CR_ID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID]  FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and CR_ID =@ID ", paramEmployeeID);
                    Contacttxt.Text = "";
                    cmbcontact.Text = "Select";
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages[1])
                {




                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[CR_ID] ,[name],[documentValue]  ,[DocumentType].Doc_Type ,[RefrenceID],[Number] ,[DocIssueplace]  ,[docissuedate]  ,[docexpiredate] FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and CR_ID =@ID ", paramEmployeeID);

                    cmbDocuments.Text = "Select";
                    dataGridView3.Columns["name"].Visible = false;
                    dataGridView3.Columns["documentValue"].Visible = false;

                    Doctxt.Text = "";
                    numbertextbox.Text = "";
                    issueplacetext.Text = "";
                    docissueplacepicker.Value = DateTime.Now;
                    docexpirefatepicker.Value = DateTime.Now;


                }
                if (tabControl1.SelectedTab == tabControl1.TabPages[2])
                {

                    paramEmployeeID.Value = EmployeeID;



                    dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from employeehistory where employeeid=@ID", paramEmployeeID);

                    richhistoryvalue.Text = "";
                    dtphistorydate.Value = DateTime.Now;

                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["SalaryTab"])
                {

                    cmbsalarytype.Text = "Select";
                    txtvalue.Text = "";
                    dataGridView5.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  select SalaryDetID , SalaryTypeName 'Salary Type' ,SalaryDetails.Value from SalaryDetails,SalaryTypes where SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and SalaryDetails.EmployeeID = @ID ", paramEmployeeID);
                    //  this.dataGridView5.Columns["SalaryDetID"].Visible = false;

                }


            }
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
            cmbEmployJobHistory.DroppedDown = false;


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
            paramPID.Value = EmployeeID;


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
            paramPID.Value = EmployeeID;

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

            // Check if a row is selected

            if (dOCID == 0)
            {
                MessageBox.Show("Please select a record.");

            }
            else
            {
                // Check if a row is selected
                if (dataGridView3.CurrentRow != null)
                {
                    try
                    {
                        // Get the selected document's ID (assuming the column contains the ID)
                        DataGridViewRow selectedRow = dataGridView3.CurrentRow;
                        int selectedDocId = Convert.ToInt32(selectedRow.Cells["Doc_id"].Value);

                        // Fetch the document data from the database
                        byte[] documentBinary = null;
                        string fileName = string.Empty;
                        using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
                        {
                            string query = "SELECT name, documentValue FROM Documents WHERE Doc_id = @DocumentID";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@DocumentID", selectedDocId);

                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    fileName = reader["name"].ToString();
                                    documentBinary = (byte[])reader["documentValue"];
                                }
                            }
                        }

                        // Check if document data is fetched
                        if (documentBinary != null)
                        {
                            // Save the binary data to a temporary file
                            string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);
                            File.WriteAllBytes(tempFilePath, documentBinary);

                            // Open the file using the default viewer
                            Process.Start(tempFilePath);
                        }
                        else
                        {
                            MessageBox.Show("Document not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a document.");
                }
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

        private void button7_Click(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();
            cmbEmployJobHistory.ValueMember = "JobID";
            cmbEmployJobHistory.DisplayMember = "JobTitleEN";
            cmbEmployJobHistory.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT JobID,JobTitleEN FROM JOBS");
            cmbEmployJobHistory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEmployJobHistory.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();

        }

        private void cmbempdepthistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbempdepthistory.DroppedDown = false;

        }

        private void picVisa_Click(object sender, EventArgs e)
        {
           
        }

        private void picVisa_Click_1(object sender, EventArgs e)
        {
            
        }

        private void picVisa_Click_2(object sender, EventArgs e)
        {
            if (txtvisanumber.Text != string.Empty)
            {
                Clipboard.SetText(txtvisanumber.Text);
                txtvisa.Visible = true;
                txtvisa.Text = "Copied !";
            }
            else
            {
                
            }
        }

        private void picvisascreen_Click(object sender, EventArgs e)
        {
            VisaFrm visaform = new VisaFrm();
            // this.Hide();
            visaform.Show();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            // Calculate the age and update the lblAge label
            DateTime selectedDate = dtpDOB.Value;
            int age = CalculateAge(selectedDate);
            lblage.Visible=lblyears.Visible = true;
            lblage.Text = age.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

    

  

