﻿using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
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

namespace Delmon_Managment_System.Forms
{
    public partial class PrintingFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int loggedEmployee;
      //  int companyidfordisplayreport;
      //  int StatusIDfordisplayreport;
        int Visacompanyidfordisplayreport;
        int VisaREservedToidfordisplayreport;
        int VisaStatusIDfordisplayreport;
        int VisaFileNumberfordisplayreport;
        DateTime dtpfromreport;
        DateTime dtptoreport;
        bool hasViewVISA = false;
        bool hasViewCANDIDATES = false;



        public PrintingFrm()
        {
            InitializeComponent();
            dataGridView2.CellClick += dataGridView2_CellClick;

        }

        private void PrintingFrm_Load(object sender, EventArgs e)
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
                if (permissionName.Contains("VisaReport"))

                {
                    hasViewVISA = true;
                }
                if (permissionName.Contains("CandidatesReport"))
                {
                    hasViewCANDIDATES = true;
                }

            }
            dr.Close();

            if (hasViewVISA == false)
            {

                MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
                button3.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                picvisascreen.Enabled = false;

            }
            else
            {
                picvisascreen.Enabled = false;
                button1.Enabled = true;
                button3.Enabled = true;
                groupBox3.Enabled = true;
                groupBox2.Enabled = true;


            }




            lblusername.Text = CommonClass.LoginUserName;
            lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            loggedEmployee = CommonClass.EmployeeID;
            lblPC.Text = Environment.MachineName;







          
              
               


            //if (lblusertype.Text == "SuperAdmin")
            //{
                //LoadTheme(); 

             
                cmbPersonalStatusStatus.ValueMember = "StatusID";
                cmbPersonalStatusStatus.DisplayMember = "StatusValue";
                cmbPersonalStatusStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  StatusID , StatusValue  from StatusTBL where RefrenceID=2 or RefrenceID=0  ");
                cmbPersonalStatusStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbPersonalStatusStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

                string querycomp = "SELECT COMPID,ShortCompName FROM Companies where compid !=1";
                string querycomp2 = "SELECT COMPID,ShortCompName FROM Companies where compid !=1 ";

                cmbCompany.ValueMember = "COMPID";
                cmbCompany.DisplayMember = "ShortCompName";

                cmbcomp.ValueMember = "COMPID";
                cmbcomp.DisplayMember = "ShortCompName";

                cmbReservedTo.ValueMember = "COMPID";
                cmbReservedTo.DisplayMember = "ShortCompName";

                cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox(querycomp);
                cmbcomp.DataSource = cmbReservedTo.DataSource = SQLCONN.ShowDataInGridViewORCombobox(querycomp2);
                cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbReservedTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbReservedTo.AutoCompleteSource = AutoCompleteSource.ListItems;



                cmbcandidates2.ValueMember = "EmployeeID";
                cmbcandidates2.DisplayMember = "Name";
                cmbcandidates2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees]       order by EmployeeID");
                cmbcandidates2.Text = "Select";
                cmbcandidates2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbcandidates2.AutoCompleteSource = AutoCompleteSource.ListItems;


                string query3 = "select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId";
                cmbConsulate.ValueMember = "Consulates.ConsulateID";
                cmbConsulate.DisplayMember = "ConsulateCity";
                cmbConsulate.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query3);






            //}
            //else
            //{

            //    SqlParameter paramloggiedemployeeid = new SqlParameter("@C1", SqlDbType.NVarChar);
            //    paramloggiedemployeeid.Value = loggedEmployee;
            //    //cmbStatus.ValueMember = "statusid";
            //    //cmbStatus.DisplayMember = "status";
            //    //cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select statusid,status  from Visastatus where RefrenceID =1 or RefrenceID = 0 order by statusid");
            //    //cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    //cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

            //    cmbPersonalStatusStatus.ValueMember = "StatusID";
            //    cmbPersonalStatusStatus.DisplayMember = "StatusValue";
            //    cmbPersonalStatusStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  StatusID , StatusValue  from StatusTBL where RefrenceID=2  ");
            //    cmbPersonalStatusStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    cmbPersonalStatusStatus.AutoCompleteSource = AutoCompleteSource.ListItems;



            //    cmbCompany.ValueMember = "Companies.COMPID";
            //    cmbCompany.DisplayMember = "COMPName_EN";
            //    cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Companies.COMPID,COMPName_EN FROM Companies,Employees where Employees.COMPID=Companies.COMPID and Employees.EmployeeID=@C1", paramloggiedemployeeid);
            //    cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            //    cmbCompany.Enabled = false;


            //    cmbcomp.ValueMember = "Companies.COMPID";
            //    cmbcomp.DisplayMember = "COMPName_EN";
            //    cmbcomp.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Companies.COMPID,COMPName_EN FROM Companies,Employees where Employees.COMPID=Companies.COMPID and Employees.EmployeeID=@C1", paramloggiedemployeeid);
            //    cmbcomp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    cmbcomp.AutoCompleteSource = AutoCompleteSource.ListItems;
            //    cmbcomp.Text = "Select";
            //    cmbcomp.Enabled = false;


            //    cmbcandidates2.ValueMember = "EmployeeID";
            //    cmbcandidates2.DisplayMember = "Name";
            //    cmbcandidates2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees],DEPARTMENTS where Employees.DeptID = DEPARTMENTS.DEPTID  " +
            //        " AND Employees.DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = @C1 )", paramloggiedemployeeid);
            //    cmbcandidates2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    cmbcandidates2.AutoCompleteSource = AutoCompleteSource.ListItems;



            //    string query3 = "select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId";
            //    cmbConsulate.ValueMember = "Consulates.ConsulateID";
            //    cmbConsulate.DisplayMember = "ConsulateCity";
            //    cmbConsulate.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query3);







            //}
            SQLCONN.CloseConnection();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            //  label4.ForeColor = ThemeColor.SecondaryColor;
            //  label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void emptxt_TextChanged(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();
            // dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from PrintLog  where  UserName LIKE '%" + emptxt.Text + "%'");
            SQLCONN.CloseConnection();

        }

        private void VisaReq_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets.Add("General");
                ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add("Details");

                ExportDataGridViewToExcel(dataGridView2, worksheet1);
                ExportDataGridViewToExcel(dataGridView4, worksheet2);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save as Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    package.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                }
            }



        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //            // Show the report viewer
            //            reportViewer2.Visible = true;

            //            // Get the logged in employee ID
            //            int loggedEmployee = CommonClass.EmployeeID;

            //            // Set the query parameters
            //            SqlParameter paramDateFrom = new SqlParameter("@param3", SqlDbType.Date);
            //            paramDateFrom.Value = FromDate.Value;

            //            SqlParameter paramDateTo = new SqlParameter("@param4", SqlDbType.Date);
            //            paramDateTo.Value = todate.Value;

            //            SqlParameter paramVisaStatus = new SqlParameter("@param5", SqlDbType.NVarChar);
            //            paramVisaStatus.Value = cmbPersonalStatusStatus.SelectedValue;

            //            SqlParameter paramCompany = new SqlParameter("@param6", SqlDbType.NVarChar);
            //            paramCompany.Value = cmbcomp.SelectedValue;

            //            SqlParameter paramCandidate = new SqlParameter("@param7", SqlDbType.NVarChar);
            //            paramCandidate.Value = cmbcandidates2.SelectedValue;

            //            // Create a new DataTable to store the report data
            //            DataTable CandidateReport = new DataTable();

            //            // Connect to the database and retrieve the report data
            //            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            //            {
            //                connection.Open();

            //                // Build the query based on the user's selected options
            //                string query = @"
            //    SELECT TRIM(COALESCE(CONCAT(FirstName, ' '), '') +
            //COALESCE(CONCAT(SecondName, ' '), '') +
            //COALESCE(CONCAT(ThirdName, ' '), '') +
            //COALESCE(Lastname, '')) [FullName],
            //       StatusTBL.StatusValue,COMPName_EN,    CONVERT(NVARCHAR(10), StartDate, 103) AS [Date] ,
            //       COUNT(*) AS Total
            //FROM Employees
            //JOIN Companies ON Employees.COMPID = Companies.COMPID
            //JOIN StatusTBL ON Employees.EmploymentStatusID = StatusTBL.StatusID
            //WHERE TRY_CONVERT(DATE, StartDate, 103) BETWEEN @param3 AND @param4 ";

            //                if (lblusertype.Text == "Admin")
            //                {

            //                    if (cmbPersonalStatusStatus.Text != "Select")
            //                    {
            //                        query += " AND Employees.EmploymentStatusID = @param5";
            //                    }

            //                    if (cmbcomp.Text != "Select")
            //                    {
            //                        query += " AND Employees.COMPID = @param6";
            //                    }

            //                    if (cmbcandidates2.Text != "Select")
            //                    {
            //                        query += " AND Employees.EmployeeID = @param7";
            //                    }

            //                    query += " GROUP BY  StatusTBL.StatusValue ,TRIM(COALESCE(CONCAT(FirstName, ' '), '') +  COALESCE(CONCAT(SecondName, ' '), '') +   COALESCE(CONCAT(ThirdName, ' '), '') +  COALESCE(Lastname, '')), StatusTBL.StatusValue,COMPName_EN,StartDate";

            //                }
            //                else
            //                {

            //                    if (cmbPersonalStatusStatus.Text != "Select")
            //                    {
            //                        query += " AND Employees.EmploymentStatusID = @param5";
            //                    }

            //                    if (cmbcomp.Text != "Select")
            //                    {
            //                        query += " AND Employees.COMPID = @param6";
            //                    }

            //                    if (cmbcandidates2.Text != "Select")
            //                    {
            //                        query += " AND Employees.EmployeeID = @param7";
            //                    }

            //                    query += " GROUP BY  StatusTBL.StatusValue ,TRIM(COALESCE(CONCAT(FirstName, ' '), '') +  COALESCE(CONCAT(SecondName, ' '), '') +   COALESCE(CONCAT(ThirdName, ' '), '') +  COALESCE(Lastname, '')), StatusTBL.StatusValue,COMPName_EN,StartDate";






            //                }
            //                // Create a new SqlCommand object with the query and parameters
            //                using (SqlCommand command = new SqlCommand(query, connection))
            //                {
            //                    command.Parameters.Add(paramDateFrom);
            //                    command.Parameters.Add(paramDateTo);
            //                    command.Parameters.Add(paramVisaStatus);
            //                    command.Parameters.Add(paramCompany);
            //                    command.Parameters.Add(paramCandidate);

            //                    // Execute the query and fill the DataTable with the results
            //                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            //                    {
            //                        adapter.Fill(CandidateReport);
            //                    }
            //                }
            //            }

            //            // Set the report viewer's data source to the DataTable
            //            reportViewer2.LocalReport.DataSources.Clear();
            //            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", CandidateReport));
            //            // reportViewer1.LocalReport.DataSources.Add(dataSource);
            //            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("param3", FromDate.Value.ToString("dd/MM/yyyy")) });
            //            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("param4", todate.Value.ToString("dd/MM/yyyy")) });

            //            // Refresh the report viewer
            //            reportViewer2.RefreshReport();


            //                SQLCONN.CloseConnection();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    // Set the report for the first tab page
                    break;
                case 1:
                    // Set the report for the second tab page

                    cmbPersonalStatusStatus.Text = "Select";
                    cmbcandidates2.Text = "Select";
                    break;
                // Add additional cases for more tab pages and reports as needed
                default:
                    break;
            }
        }

        private void cmbcandidates2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPersonalStatusStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbcomp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbVISAStamped_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbVISAExpiredAfterStamped_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbNotused_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbRefunded_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbReserved_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbExpired_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbUnderProcess_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbUsed_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelect.Checked == true)
            {
                cbUsed.Checked = cbNotused.Checked = cbExpired.Checked = cbReserved.Checked = cbRefunded.Checked = cbUnderProcess.Checked
                        = cbVISAExpiredAfterStamped.Checked = cbVISAStamped.Checked = true;
            }
            else
            {
                cbUsed.Checked = cbNotused.Checked = cbExpired.Checked = cbReserved.Checked = cbRefunded.Checked = cbUnderProcess.Checked
              = cbVISAExpiredAfterStamped.Checked = cbVISAStamped.Checked = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /**/
            // Set the query parameters
            SqlParameter paramDateFrom = new SqlParameter("@param3", SqlDbType.Date);
            paramDateFrom.Value = FromDate.Value;

            SqlParameter paramDateTo = new SqlParameter("@param4", SqlDbType.Date);
            paramDateTo.Value = todate.Value;

            SqlParameter paramVisaStatus = new SqlParameter("@param5", SqlDbType.NVarChar);
            paramVisaStatus.Value = cmbPersonalStatusStatus.SelectedValue;

            SqlParameter paramCompany = new SqlParameter("@param6", SqlDbType.NVarChar);
            paramCompany.Value = cmbcomp.SelectedValue;

            SqlParameter paramCandidate = new SqlParameter("@param7", SqlDbType.NVarChar);
            paramCandidate.Value = cmbcandidates2.SelectedValue;

            // Create a new DataTable to store the report data
            DataTable CandidateReport = new DataTable();

            // Connect to the database and retrieve the report data
            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            {
                connection.Open();

                // Build the query based on the user's selected options
                string query = @"
        SELECT  Companies.COMPID,StatusTBL.StatusID,Companies.ShortCompName 'Company',
                StatusTBL.StatusValue 'Status',      
                COUNT(*) AS Total
        FROM Employees
        JOIN Companies ON Employees.COMPID = Companies.COMPID
        JOIN StatusTBL ON Employees.EmploymentStatusID = StatusTBL.StatusID

        WHERE TRY_CONVERT(DATE, StartDate, 103) BETWEEN @param3 AND @param4 ";

                if (lblusertype.Text == "Admin")
                {
                    if (cmbPersonalStatusStatus.Text != "Select")
                    {
                        query += " AND Employees.EmploymentStatusID = @param5";
                    }

                    if (cmbcomp.Text != "Select")
                    {
                        query += " AND Employees.COMPID = @param6";
                    }

                    if (cmbcandidates2.Text != "Select")
                    {
                        query += " AND Employees.EmployeeID = @param7";
                    }

                    query += " GROUP BY   StatusTBL.StatusID,Companies.COMPID,StatusTBL.StatusValue, Companies.ShortCompName";
                }
                else
                {
                    if (cmbPersonalStatusStatus.Text != "Select")
                    {
                        query += " AND Employees.EmploymentStatusID = @param5";
                    }

                    if (cmbcomp.Text != "Select")
                    {
                        query += " AND Employees.COMPID = @param6";
                    }

                    if (cmbcandidates2.Text != "Select")
                    {
                        query += " AND Employees.EmployeeID = @param7";
                    }

                    query += " GROUP BY   StatusTBL.StatusID,Companies.COMPID,StatusTBL.StatusValue, Companies.ShortCompName";
                }

                // Create a new SqlCommand object with the query and parameters
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(paramDateFrom);
                    command.Parameters.Add(paramDateTo);
                    command.Parameters.Add(paramVisaStatus);
                    command.Parameters.Add(paramCompany);
                    command.Parameters.Add(paramCandidate);

                    // Execute the query and fill the DataTable with the results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(CandidateReport);
                    }
                }
            }

            // Set the DataTable as the DataSource for the DataGridView
            dataGridView3.DataSource = CandidateReport;
            dataGridView3.Columns[0].Visible = false; // Replace "ColumnName" with the actual name of the column
            dataGridView3.Columns[1].Visible = false; // Replace "ColumnName" with the actual name of the column
            dataGridView3.Columns[2].Width = 150; // Replace "ColumnName" with the actual name of the column
                                                  //dataGridView3.Columns[2].Width = 50; // Replace "ColumnName" with the actual name of the column

            // Calculate the sum of the column
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    int quantity;
                    if (int.TryParse(row.Cells[4].Value.ToString(), out quantity))
                    {
                        sum += quantity;
                    }
                }
            }

            // Create a new DataRow for the total row
            DataTable dataTable = (DataTable)dataGridView3.DataSource;
            DataRow totalRow = dataTable.NewRow();
            totalRow[2] = "Total";
            totalRow[4] = sum;
            // Add the total row to the DataTable
            dataTable.Rows.Add(totalRow);

            // Get the DataGridViewRow for the total row
            DataGridViewRow totalDataGridViewRow = dataGridView3.Rows[dataTable.Rows.Count - 1];

            // Set the cell style for the new row
            totalDataGridViewRow.DefaultCellStyle.BackColor = Color.YellowGreen;

            // Refresh the DataGridView to reflect the changes
            dataGridView3.Refresh();


        }


        private bool shouldUpdateData = true;
        private void button3_Click(object sender, EventArgs e)
        {
            // Clear the DataGridView's data source
            dataGridView2.DataSource = null;

            // Define loggedEmployee and other variables
            loggedEmployee = CommonClass.EmployeeID;

            // Construct SQL query
            string query = @"
        SELECT 
            V.ComapnyID, 
            J.ReservedTo, 
            S.StatusID, 
            C.ShortCompName as [Company], 
            CO.ShortCompName as [Reserved To], 
            S.Status as [VisaStatus], 
            COUNT (DISTINCT J.FileNumber) AS [TotalFiles] 
        FROM 
            DelmonGroupDB.dbo.VISA V 
        JOIN 
            DelmonGroupDB.dbo.VISAJobList J ON V.VisaNumber = J.VISANumber 
        JOIN 
            DelmonGroupDB.dbo.Companies C ON V.ComapnyID = C.COMPID 
        JOIN 
            DelmonGroupDB.dbo.Companies CO ON J.ReservedTo = CO.COMPID 
        JOIN 
            DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID AND S.RefrenceID = 1 
        JOIN 
            DelmonGroupDB.dbo.Employees E ON E.EmployeeID = J.EmployeeID 
        WHERE 
            TRY_CONVERT(DATETIME, v.IssueDateEN, 103) BETWEEN @fromDate AND @toDate";

            // Add conditions based on checkbox filters
            List<int> selectedStatus = new List<int>();

            if (cbNotused.Checked)
            {
                query += " AND J.StatusID = @statusNotUsed";
                selectedStatus.Add(2);
            }

            if (cbReserved.Checked)
            {
                query += " AND J.StatusID = @statusReserved";
                selectedStatus.Add(3);
            }

            // Add conditions based on combobox selections
            if ((int)cmbCompany.SelectedValue != 0)
            {
                query += " AND V.ComapnyID = @companyId";
            }

            if ((int)cmbReservedTo.SelectedValue != 0)
            {
                query += " AND J.ReservedTo = @reservedToId";
            }

            if ((int)cmbConsulate.SelectedValue != 0)
            {
                query += " AND J.ConsulateID = @consulateId";
            }

            // Add fixed date conditions
            query += @"
        GROUP BY 
            V.ComapnyID, J.ReservedTo, S.StatusID, C.ShortCompName, CO.ShortCompName, S.Status 
        ORDER BY 
            V.ComapnyID, J.ReservedTo, S.StatusID, C.ShortCompName, S.Status, CO.ShortCompName";

            // Execute the SQL query
            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters
                command.Parameters.AddWithValue("@fromDate", dtpfrom.Value);
                command.Parameters.AddWithValue("@toDate", dtpto.Value);

                // Add parameters for checkbox filters
                if (selectedStatus.Contains(2))
                {
                    command.Parameters.AddWithValue("@statusNotUsed", 2);
                }

                if (selectedStatus.Contains(3))
                {
                    command.Parameters.AddWithValue("@statusReserved", 3);
                }

                // Add parameters for combobox selections
                if ((int)cmbCompany.SelectedValue != 0)
                {
                    command.Parameters.AddWithValue("@companyId", cmbCompany.SelectedValue);
                }

                if ((int)cmbReservedTo.SelectedValue != 0)
                {
                    command.Parameters.AddWithValue("@reservedToId", cmbReservedTo.SelectedValue);
                }

                if ((int)cmbConsulate.SelectedValue != 0)
                {
                    command.Parameters.AddWithValue("@consulateId", cmbConsulate.SelectedValue);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable VisaReport = new DataTable();
                adapter.Fill(VisaReport);
                connection.Close();

                // Bind the DataTable to the DataGridView
                dataGridView2.DataSource = VisaReport;

                // Set column visibility and width
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].Visible = false;
                dataGridView2.Columns[3].Width = 150;
                dataGridView2.Columns[4].Width = 150;
                dataGridView2.Columns[5].Width = 150;

                // Calculate total
                int sum = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[6].Value != null)
                    {
                        int quantity;
                        if (int.TryParse(row.Cells[6].Value.ToString(), out quantity))
                        {
                            sum += quantity;
                        }
                    }
                }

                // Add total row
                DataTable dataTable = (DataTable)dataGridView2.DataSource;
                DataRow totalRow = dataTable.NewRow();
                totalRow[3] = "Total";
                totalRow[6] = sum;
                dataTable.Rows.Add(totalRow);

                // Get the DataGridViewRow for the total row
                DataGridViewRow totalDataGridViewRow = dataGridView2.Rows[dataTable.Rows.Count - 1];

                // Set the cell style for the new row
                totalDataGridViewRow.DefaultCellStyle.BackColor = Color.YellowGreen;

                // Refresh the DataGridView
                dataGridView2.Refresh();

                // Store filter dates
                dtpfromreport = dtpfrom.Value;
                dtptoreport = dtpto.Value;
            }
        }

        private DataTable LoadData(bool isLastRow, SqlParameter paramDateFrom, SqlParameter paramDateTo, SqlParameter paramVisaStatus, SqlParameter paramCompany, SqlParameter paramCell1, SqlParameter paramCell2)
        {
            if (!shouldUpdateData)
            {
                return new DataTable();
            }

            DataTable CandidateReport = new DataTable();

            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            {
                connection.Open();

                string query;

                if (isLastRow)
                {
                    // Query for the last row
                    query = @"
                SELECT 
                    VISAJobList.[FileNumber],
                    VISA.[VisaNumber],
                    Employees.EmployeeID,
                    TRIM(COALESCE(CONCAT(FirstName, ' '), '') +
                         COALESCE(CONCAT(SecondName, ' '), '') +
                         COALESCE(CONCAT(ThirdName, ' '), '') +
                         COALESCE(Lastname, '')) AS [FullName],
                    CompaniesSponsor.COMPName_EN AS [Sponsor],
                    CompaniesReservedTo.COMPName_EN AS [ReservedTO],
                    DeptTypes.Dept_Type_Name AS [Department],
                    Countries.NationalityName AS [Nationality],
                    StatusTBL.StatusValue AS [Status],
                    CONVERT(NVARCHAR(10), StartDate, 103) AS [Date]
                FROM [DelmonGroupDB].[dbo].[VISAJobList] AS VISAJobList
                LEFT JOIN [DelmonGroupDB].[dbo].[VISA] AS VISA ON VISAJobList.[VISANumber] = VISA.[VisaNumber]
                RIGHT JOIN [DelmonGroupDB].[dbo].[Employees] AS Employees ON VISAJobList.[EmployeeID] = Employees.[EmployeeID]
                LEFT JOIN [DelmonGroupDB].[dbo].[Companies] AS CompaniesSponsor ON VISA.[ComapnyID] = CompaniesSponsor.[COMPID]
                LEFT JOIN [DelmonGroupDB].[dbo].[Companies] AS CompaniesReservedTo ON VISAJobList.[ReservedTo] = CompaniesReservedTo.[COMPID]
                LEFT JOIN [DelmonGroupDB].[dbo].[DEPARTMENTS] AS departments ON Employees.[DeptID] = departments.DEPTID
                LEFT JOIN [DelmonGroupDB].[dbo].[DeptTypes] AS DeptTypes ON departments.[DeptName] = DeptTypes.[Dept_Type_ID]
                LEFT JOIN [DelmonGroupDB].[dbo].[Countries] AS Countries ON Employees.[NationalityID] = Countries.[CountryId]
                LEFT JOIN [DelmonGroupDB].[dbo].[StatusTBL] AS StatusTBL ON Employees.[EmploymentStatusID] = StatusTBL.[StatusID]
                WHERE TRY_CONVERT(DATE, StartDate, 103) BETWEEN @param3 AND @param4 ";

                    if (cmbPersonalStatusStatus.Text != "Select")
                    {
                        query += "  AND Employees.[EmploymentStatusID] = @param5";
                    }

                    if (cmbcomp.Text != "Select")
                    {
                        query += "  AND Employees.[COMPID] = @param6";
                    }

                    query += " GROUP BY VISAJobList.[FileNumber], VISA.[VisaNumber], CompaniesSponsor.COMPName_EN, CompaniesReservedTo.COMPName_EN, DeptTypes.Dept_Type_Name, Countries.NationalityName, Employees.EmployeeID, StatusTBL.StatusValue, TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') + COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')), StartDate;";
                }
                else
                {
                    // Query for other rows
                    query = @"
                SELECT 
                    VISAJobList.[FileNumber],
                    VISA.[VisaNumber],
                    Employees.EmployeeID,
                    TRIM(COALESCE(CONCAT(FirstName, ' '), '') +
                         COALESCE(CONCAT(SecondName, ' '), '') +
                         COALESCE(CONCAT(ThirdName, ' '), '') +
                         COALESCE(Lastname, '')) AS [FullName],
                    CompaniesSponsor.COMPName_EN AS [Sponsor],
                    CompaniesReservedTo.COMPName_EN AS [ReservedTO],
                    DeptTypes.Dept_Type_Name AS [Department],
                    Countries.NationalityName AS [Nationality],
                    StatusTBL.StatusValue AS [Status],
                    CONVERT(NVARCHAR(10), StartDate, 103) AS [Date]
                FROM [DelmonGroupDB].[dbo].[VISAJobList] AS VISAJobList
                LEFT JOIN [DelmonGroupDB].[dbo].[VISA] AS VISA ON VISAJobList.[VISANumber] = VISA.[VisaNumber]
                RIGHT JOIN [DelmonGroupDB].[dbo].[Employees] AS Employees ON VISAJobList.[EmployeeID] = Employees.[EmployeeID]
                LEFT JOIN [DelmonGroupDB].[dbo].[Companies] AS CompaniesSponsor ON VISA.[ComapnyID] = CompaniesSponsor.[COMPID]
                LEFT JOIN [DelmonGroupDB].[dbo].[Companies] AS CompaniesReservedTo ON VISAJobList.[ReservedTo] = CompaniesReservedTo.[COMPID]
                LEFT JOIN [DelmonGroupDB].[dbo].[DEPARTMENTS] AS departments ON Employees.[DeptID] = departments.DEPTID
                LEFT JOIN [DelmonGroupDB].[dbo].[DeptTypes] AS DeptTypes ON departments.[DeptName] = DeptTypes.[Dept_Type_ID]
                LEFT JOIN [DelmonGroupDB].[dbo].[Countries] AS Countries ON Employees.[NationalityID] = Countries.[CountryId]
                LEFT JOIN [DelmonGroupDB].[dbo].[StatusTBL] AS StatusTBL ON Employees.[EmploymentStatusID] = StatusTBL.[StatusID]
                WHERE TRY_CONVERT(DATE, StartDate, 103) BETWEEN @param3 AND @param4 
                AND Employees.[EmploymentStatusID] = @param8
                AND Employees.[COMPID] = @param7
               
                GROUP BY VISAJobList.[FileNumber], VISA.[VisaNumber], CompaniesSponsor.COMPName_EN, CompaniesReservedTo.COMPName_EN, DeptTypes.Dept_Type_Name, Countries.NationalityName, Employees.EmployeeID, StatusTBL.StatusValue, TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') + COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')), StartDate;";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(paramDateFrom);
                    command.Parameters.Add(paramDateTo);
                    command.Parameters.Add(paramVisaStatus);
                    command.Parameters.Add(paramCompany);

                    if (!isLastRow)
                    {
                        command.Parameters.Add(paramCell1);
                        command.Parameters.Add(paramCell2);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(CandidateReport);
                    }
                }
            }

            return CandidateReport;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the header (last row)
            if (e.RowIndex == -1)
            {
                // Clicked on a header cell, don't update data
                shouldUpdateData = false;
                return;
            }

            shouldUpdateData = true;

            // Set the query parameters
            SqlParameter paramDateFrom = new SqlParameter("@param3", SqlDbType.Date);
            paramDateFrom.Value = FromDate.Value;

            SqlParameter paramDateTo = new SqlParameter("@param4", SqlDbType.Date);
            paramDateTo.Value = todate.Value;

            SqlParameter paramVisaStatus = new SqlParameter("@param5", SqlDbType.NVarChar);
            paramVisaStatus.Value = cmbPersonalStatusStatus.SelectedValue;

            SqlParameter paramCompany = new SqlParameter("@param6", SqlDbType.Int);
            paramCompany.Value = cmbcomp.SelectedValue;

            dataGridView1.Visible = true;

            bool isLastRow = (e.RowIndex == dataGridView3.Rows.Count - 1);

            DataTable CandidateReport;

            if (isLastRow)
            {
                // When it's the last row, call LoadData with only 4 parameters
                CandidateReport = LoadData(isLastRow, paramDateFrom, paramDateTo, paramVisaStatus, paramCompany, null, null);
            }
            else
            {
                // When it's not the last row, get the values from cell 0 and cell 1
                string cell1Value = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                string cell2Value = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();

                SqlParameter paramCell1 = new SqlParameter("@param7", SqlDbType.NVarChar);
                paramCell1.Value = cell1Value;

                SqlParameter paramCell2 = new SqlParameter("@param8", SqlDbType.NVarChar);
                paramCell2.Value = cell2Value;

                // Call LoadData with 6 parameters
                CandidateReport = LoadData(isLastRow, paramDateFrom, paramDateTo, paramVisaStatus, paramCompany, paramCell1, paramCell2);
            }

            dataGridView1.DataSource = CandidateReport;

            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
        }


        private void CalculateAndDisplayTotal()
        {
            int sum = 0;

            // Calculate the sum of the column
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    int quantity;
                    if (int.TryParse(row.Cells[4].Value.ToString(), out quantity))
                    {
                        sum += quantity;
                    }
                }
            }

            // Add a new row at the end
            int newRowId = dataGridView3.Rows.Add();

            // Set the values for each cell in the new row
            dataGridView3.Rows[newRowId].Cells[2].Value = "Total";
            dataGridView3.Rows[newRowId].Cells[4].Value = sum;

            // Set the cell style for the new row
            dataGridView3.Rows[newRowId].DefaultCellStyle.BackColor = Color.LightGray;
        }

        // Call the CalculateAndDisplayTotal method whenever you want to update the total row


        

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //   if (e.RowIndex == -1)

            dataGridView4.Visible = true;
            // Check if the clicked cell is in the last row
            //if (e.RowIndex == dataGridView2.Rows.Count - 1)
            //{
            //    // Prevent any action for the last row
            //    return;
            //}

            foreach (DataGridViewRow rw in this.dataGridView2.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    if (e.RowIndex != dataGridView2.Rows.Count - 1)
                    {

                        Visacompanyidfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        VisaREservedToidfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString());
                        VisaStatusIDfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                        VisaFileNumberfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString());

                    }
                }
                // Set the query parameters
                SqlParameter paramDateFrom = new SqlParameter("@param3", SqlDbType.Date);
                paramDateFrom.Value = dtpfromreport;

                SqlParameter paramDateTo = new SqlParameter("@param4", SqlDbType.Date);
                paramDateTo.Value = dtptoreport;

                SqlParameter paramVisaStatus = new SqlParameter("@param5", SqlDbType.NVarChar);
                paramVisaStatus.Value = VisaStatusIDfordisplayreport;

                SqlParameter paramCompany = new SqlParameter("@param6", SqlDbType.Int);
                paramCompany.Value = Visacompanyidfordisplayreport;

                SqlParameter paramreservedto = new SqlParameter("@param7", SqlDbType.NVarChar);
                paramreservedto.Value = VisaREservedToidfordisplayreport;

                SqlParameter paramrFileNumber = new SqlParameter("@param8", SqlDbType.NVarChar);
                paramrFileNumber.Value = VisaFileNumberfordisplayreport;

                // Create a new DataTable to store the report data
                DataTable VisaReport = new DataTable();

              // when user click total cell
                if (e.RowIndex == dataGridView2.Rows.Count - 1)
                {
                    // Connect to the database and retrieve the report data
                    using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
                    {
                        connection.Open();

                        // Build the query based on the user's selected options

                        string query0 = @"
    SELECT J.FileNumber,
           TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') +
           COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')) AS [FullName],
           J.Visanumber, V_COMP.COMPName_EN AS [Sponsor],CO_COMP.COMPName_EN AS [ReservedTO],
           CON.ConsulateCity AS [Consulate],
           Jo.[JobTitleEN], Jo.[JobTitleAR], S.Status AS [Status],
           CONVERT(NVARCHAR(10), V.IssueDateEN, 103) AS [Date]
       
    FROM VISAJobList J
    LEFT JOIN DelmonGroupDB.dbo.Employees E ON E.EmployeeID = J.EmployeeID
    LEFT JOIN DelmonGroupDB.dbo.Consulates CON ON CON.ConsulateID = J.ConsulateID
    LEFT JOIN DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID
    LEFT JOIN DelmonGroupDB.dbo.VISA V ON V.VisaNumber = J.VISANumber
    LEFT JOIN DelmonGroupDB.dbo.Companies CO ON J.ReservedTo = CO.COMPID
    LEFT JOIN DelmonGroupDB.dbo.Jobs Jo ON Jo.jobid = j.jobid
    LEFT JOIN DelmonGroupDB.dbo.Companies CO_COMP ON J.ReservedTo = CO_COMP.COMPID
    LEFT JOIN DelmonGroupDB.dbo.Companies V_COMP ON V.ComapnyID = V_COMP.COMPID
    WHERE 
     TRY_CONVERT(DATETIME, V.IssueDateEN, 103) BETWEEN @param3 AND @param4
     
    GROUP BY J.FileNumber, J.Visanumber, S.Status, CO_COMP.COMPName_EN, V_COMP.COMPName_EN,
             TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') +
             COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')), E.EmployeeID,
             CON.ConsulateCity, V.IssueDateEN, Jo.[JobTitleEN], Jo.[JobTitleAR]";



                        // Create a new SqlCommand object with the query and parameters
                        using (SqlCommand command = new SqlCommand(query0, connection))
                        {
                            command.Parameters.Add(paramDateFrom);
                            command.Parameters.Add(paramDateTo);
                            command.Parameters.Add(paramVisaStatus);
                            command.Parameters.Add(paramCompany);
                            command.Parameters.Add(paramreservedto);
                            //command.Parameters.Add(paramrFileNumber);
                            //  command.Parameters.Add(paramCandidate);

                            // Execute the query and fill the DataTable with the results
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(VisaReport);
                            }
                        }
                    }

                         // Set the DataTable as the DataSource for the DataGridView
                         dataGridView4.DataSource = VisaReport;
                        //     dataGridView4.Columns[5].Width = 300; // Replace "ColumnName" with the actual name of the column



                }

                // when user click any cell except 'total'
                else
                {
                    // Connect to the database and retrieve the report data
                    using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
                    {
                        connection.Open();

                        // Build the query based on the user's selected options


                        string query = @"
           	 SELECT J.FileNumber, J.Visanumber, E.EmployeeID,
                     TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') +
                     COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')) AS [FullName],
                     CON.ConsulateCity AS [Consulate],
                     S.Status AS [Status],
                    CONVERT(NVARCHAR(10), StartDate, 103) AS [Date]
                    FROM VISAJobList J
              LEFT JOIN DelmonGroupDB.dbo.Employees E ON E.EmployeeID = J.EmployeeID
              LEFT JOIN DelmonGroupDB.dbo.Consulates CON  ON CON.ConsulateID = J.ConsulateID
              LEFT JOIN DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID
              LEFT JOIN DelmonGroupDB.dbo.VISA V ON V.VisaNumber = J.VISANumber
              LEFT JOIN DelmonGroupDB.dbo.Companies CO ON J.ReservedTo = CO.COMPID
              LEFT JOIN DelmonGroupDB.dbo.Jobs Jo ON Jo.jobid = j.jobid

 WHERE TRY_CONVERT(DATETIME, V.IssueDateEN, 103) BETWEEN @param3 AND @param4  
  and  J.StatusID = @param5 and V.ComapnyID=@param6  and J.ReservedTo =  @param7

    GROUP BY J.FileNumber, J.Visanumber, S.Status, Jo.JobTitleEN, CO.COMPName_EN,
    TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') +
    COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')), E.EmployeeID,CON.ConsulateCity,E.startDate";



                        // Create a new SqlCommand object with the query and parameters
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add(paramDateFrom);
                            command.Parameters.Add(paramDateTo);
                            command.Parameters.Add(paramVisaStatus);
                            command.Parameters.Add(paramCompany);
                            command.Parameters.Add(paramreservedto);
                            //command.Parameters.Add(paramrFileNumber);
                            //  command.Parameters.Add(paramCandidate);
                            // Execute the query and fill the DataTable with the results
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(VisaReport);
                            }
                        }
                    }
                    // Set the DataTable as the DataSource for the DataGridView
                    dataGridView4.DataSource = VisaReport;
                    dataGridView4.Columns[3].Width = 300; // Replace "ColumnName" with the actual name of the column
               }
            }
        }
            private void ExportToExcelButton_Click(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets.Add("Data1");
                ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add("Data2");

                ExportDataGridViewToExcel(dataGridView2, worksheet1);
                ExportDataGridViewToExcel(dataGridView4, worksheet2);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save as Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    package.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                }
            }
        }
        private void ExportDataGridViewToExcel(DataGridView dataGridView, ExcelWorksheet worksheet)
        {
            for (int i = 1; i <= dataGridView.ColumnCount; i++)
            {
                worksheet.Cells[1, i].Value = dataGridView.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value;
                }
            }
        }

        private void ExportToExcelButton_Click_1(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets.Add("General");
                ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add("Details");

                ExportDataGridViewToExcel(dataGridView1, worksheet1);
                ExportDataGridViewToExcel(dataGridView3, worksheet2);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save as Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    package.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                }
            }
        }

        private void picvisascreen_Click(object sender, EventArgs e)
        {
            VisaFrm visaform = new VisaFrm();
            // this.Hide();
            visaform.Show();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
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
                if (permissionName.Contains("VisaReport"))

                {
                    hasViewVISA = true;
                }
                if (permissionName.Contains("CandidatesReport"))
                {
                    hasViewCANDIDATES = true;
                }

            }
            dr.Close();
         
             if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                if (hasViewVISA == false)
                {

                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button1.Enabled = false;
                    button3.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    picvisascreen.Enabled = false;

                }
                else
                {
                    picvisascreen.Enabled = false;
                    button1.Enabled = true;
                    button3.Enabled = true;
                    groupBox3.Enabled = true;
                    groupBox2.Enabled = true;

                }
            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                if (hasViewCANDIDATES == false)
                {
                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button4.Enabled = false;
                    ExportToExcelButton.Enabled = false;
                    groupBox4.Enabled = false;
                }
                else
                {
                    button4.Enabled = true;
                    ExportToExcelButton.Enabled = true;
                    groupBox4.Enabled = true;

                }
            }


            SQLCONN.CloseConnection();
        }
    }
}

