﻿using CsvHelper;
using ExcelDataReader;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class ReportFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        SQLCONNECTION SQLCONN3 = new SQLCONNECTION();
        SQLCONNECTION SQLCONN4 = new SQLCONNECTION();
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
        bool hasViewAssets = false;
        DataTable originalDataCand;



        public ReportFrm()
        {
            InitializeComponent();
            dataGridView2.CellClick += dataGridView2_CellClick;
            cmbcandidates2.TextChanged += new EventHandler(cmbcandidates2_TextChanged);

            LoadComboBoxDataCand();

        }

        private void LoadComboBoxDataCand()
        {

            SQLCONN.OpenConection();

            var data = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees]  order by EmployeeID");
            if (data != null)
            {
                cmbcandidates2.DataSource = data;
                cmbcandidates2.DisplayMember = "Name";
                cmbcandidates2.ValueMember = "EmployeeID";
            }
            SQLCONN.CloseConnection();
        }

        private void UncheckAllCheckboxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (control.HasChildren)
                {
                    UncheckAllCheckboxes(control);
                }
            }
        }
        private void PrintingFrm_Load(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();
            SQLCONN3.OpenConection3();
            SQLCONN4.OpenConection4();
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
                if (permissionName.Contains("ViewVisaReport"))

                {
                    hasViewVISA = true;
                }
                if (permissionName.Contains("ViewCandidatesReport"))
                {
                    hasViewCANDIDATES = true;
                }
                if (permissionName.Contains("ViewAssetsReport"))
                {
                    hasViewAssets = true;
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
                groupBox4.Enabled = false;
                picvisascreen.Enabled = false;
                label11.Enabled = false;

                groupBox5.Enabled = groupBox6.Enabled = false;


            }
            else
            {
                picvisascreen.Enabled = true;
                label11.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                groupBox3.Enabled = true;
                groupBox2.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = groupBox6.Enabled = true;


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



                //cmbcandidates2.ValueMember = "EmployeeID";
                //cmbcandidates2.DisplayMember = "Name";
                //cmbcandidates2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees]       order by EmployeeID");
                //cmbcandidates2.Text = "Select";
                //cmbcandidates2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmbcandidates2.AutoCompleteSource = AutoCompleteSource.ListItems;


            // Retrieve data from the database
            DataTable assetsData = (DataTable)SQLCONN3.ShowDataInGridViewORCombobox(@"SELECT AssetID FROM [DelmonGroupAssests].[dbo].[Assets] WHERE AssetTypeID=2");

            // Create a new DataTable to store the ComboBox items
            DataTable comboBoxData = new DataTable();
            comboBoxData.Columns.Add("AssetID", typeof(string));

            // Add the "Select" option as the first item
            DataRow selectRow = comboBoxData.NewRow();
            selectRow["AssetID"] = "Select";
            comboBoxData.Rows.Add(selectRow);

            // Merge the retrieved data with the new DataTable
            foreach (DataRow row in assetsData.Rows)
            {
                comboBoxData.ImportRow(row);
            }

            // Bind the new data source to the ComboBox
            cmbPrinter.ValueMember = "AssetID";
            cmbPrinter.DisplayMember = "AssetID";
            cmbPrinter.DataSource = comboBoxData;

            // Set additional ComboBox properties
            cmbPrinter.SelectedIndex = 0; // Set the "Select" option as the default selected item
            cmbPrinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPrinter.AutoCompleteSource = AutoCompleteSource.ListItems;






            string query3 = "select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId";
                cmbConsulate.ValueMember = "Consulates.ConsulateID";
                cmbConsulate.DisplayMember = "ConsulateCity";
                cmbConsulate.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query3);






           
            SQLCONN.CloseConnection();
            SQLCONN3.CloseConnection();
            SQLCONN4.CloseConnection();

        }
        //private void LoadTheme()
        //{
        //    foreach (Control btns in this.Controls)
        //    {
        //        if (btns.GetType() == typeof(Button))
        //        {
        //            Button btn = (Button)btns;
        //            btn.BackColor = ThemeColor.PrimaryColor;
        //            btn.ForeColor = Color.White;
        //            btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
        //        }
        //    }
        //    //  label4.ForeColor = ThemeColor.SecondaryColor;
        //    //  label5.ForeColor = ThemeColor.PrimaryColor;
        //}

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
        SELECT 
            Companies.COMPID,StatusTBL.StatusID,Companies.ShortCompName 'Company',
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

        private DataTable UpdateVisaReport(DataTable existingTable)
        {
            // Construct SQL query based on filter conditions
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

            // check boxes
            if (cbNotused.Checked) selectedStatus.Add(2);
            if (cbReserved.Checked) selectedStatus.Add(3);
            if (cbUnderProcess.Checked) selectedStatus.Add(4);
            if (cbVISAStamped.Checked) selectedStatus.Add(5);
            if (cbUsed.Checked) selectedStatus.Add(6);
            if (cbExpired.Checked) selectedStatus.Add(7);
            if (cbRefunded.Checked) selectedStatus.Add(8);
            if (cbVISAExpiredAfterStamped.Checked) selectedStatus.Add(9);

            if (selectedStatus.Count > 0)
            {
                string statusFilter = string.Join(",", selectedStatus);
                query += $" AND J.StatusID IN ({statusFilter})";
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
                DataTable updatedTable = new DataTable();
                adapter.Fill(updatedTable);
                connection.Close();

                // Return the updated DataTable
                return updatedTable;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Get the existing DataTable
            DataTable existingTable = (DataTable)dataGridView2.DataSource;

            // If the existing DataTable is null, create a new one
            if (existingTable == null)
            {
                existingTable = new DataTable();
            }

            // Update the DataTable with new filter conditions
            DataTable updatedTable = UpdateVisaReport(existingTable);

            // Bind the updated DataTable to the DataGridView
            dataGridView2.DataSource = updatedTable;

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


        //private void CalculateAndDisplayTotal()
        //{
        //    int sum = 0;

        //    // Calculate the sum of the column
        //    foreach (DataGridViewRow row in dataGridView3.Rows)
        //    {
        //        if (row.Cells[4].Value != null)
        //        {
        //            int quantity;
        //            if (int.TryParse(row.Cells[4].Value.ToString(), out quantity))
        //            {
        //                sum += quantity;
        //            }
        //        }
        //    }

        //    // Add a new row at the end
        //    int newRowId = dataGridView3.Rows.Add();

        //    // Set the values for each cell in the new row
        //    dataGridView3.Rows[newRowId].Cells[2].Value = "Total";
        //    dataGridView3.Rows[newRowId].Cells[4].Value = sum;

        //    // Set the cell style for the new row
        //    dataGridView3.Rows[newRowId].DefaultCellStyle.BackColor = Color.LightGray;
        //}

        //// Call the CalculateAndDisplayTotal method whenever you want to update the total row




        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView4.Visible = true;

            if (e.RowIndex == -1) return; // Ignore header row

            // Set the query parameters
            SqlParameter paramDateFrom = new SqlParameter("@param3", SqlDbType.Date);
            paramDateFrom.Value = dtpfrom.Value;
            SqlParameter paramDateTo = new SqlParameter("@param4", SqlDbType.Date);
            paramDateTo.Value = dtpto.Value;
            SqlParameter paramCompany2 = new SqlParameter("@param8", SqlDbType.NVarChar);
            paramCompany2.Value = cmbCompany.SelectedValue;
            SqlParameter paramReservedTo2 = new SqlParameter("@param9", SqlDbType.NVarChar);
            paramReservedTo2.Value = cmbReservedTo.SelectedValue;
            SqlParameter paramConsulate = new SqlParameter("@param10", SqlDbType.NVarChar);
            paramConsulate.Value = cmbConsulate.SelectedValue;


            if (e.RowIndex == dataGridView2.Rows.Count - 1) // Total row
            {
                // Build and execute the query for the "Total" row
                DataTable VisaReport = new DataTable();
                using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
                {
                    connection.Open();
                    string queryTotal = @"
                SELECT 
                    J.FileNumber,
                    TRIM(COALESCE(CONCAT(E.FirstName, ' '), '') + COALESCE(CONCAT(E.SecondName, ' '), '') +
                    COALESCE(CONCAT(E.ThirdName, ' '), '') + COALESCE(E.Lastname, '')) AS [FullName],
                    J.Visanumber, 
                    V_COMP.ID_Number AS [Sponsor ID], 
                    V_COMP.COMPName_EN AS [Sponsor Name], 
                    CO_COMP.ID_Number AS [ReservedTO ID],
                    CO_COMP.COMPName_EN AS [ReservedTO Name],
                    CON.ConsulateCity AS [Consulate], 
                    Jo.[JobTitleEN], 
                    Jo.[JobTitleAR], 
                    S.Status AS [Status],
                    CONVERT(NVARCHAR(10), V.IssueDateEN, 103) AS [Issue Date],
                    CONVERT(NVARCHAR(10), E.StartDate, 103) AS [Arrival Date]

                FROM 
                    VISAJobList J
                LEFT JOIN 
                    DelmonGroupDB.dbo.Employees E ON E.EmployeeID = J.EmployeeID
                LEFT JOIN 
                    DelmonGroupDB.dbo.Consulates CON ON CON.ConsulateID = J.ConsulateID
                LEFT JOIN 
                    DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID
                LEFT JOIN 
                    DelmonGroupDB.dbo.VISA V ON V.VisaNumber = J.VISANumber
                LEFT JOIN 
                    DelmonGroupDB.dbo.Companies CO ON J.ReservedTo = CO.COMPID
                LEFT JOIN 
                    DelmonGroupDB.dbo.Jobs Jo ON Jo.jobid = J.jobid
                LEFT JOIN 
                    DelmonGroupDB.dbo.Companies CO_COMP ON J.ReservedTo = CO_COMP.COMPID
                LEFT JOIN 
                    DelmonGroupDB.dbo.Companies V_COMP ON V.ComapnyID = V_COMP.COMPID
                WHERE 
                    TRY_CONVERT(DATETIME, V.IssueDateEN, 103) BETWEEN @param3 AND @param4";


                    if (cmbCompany.Text != "Select")
                    {
                        queryTotal += " AND V.ComapnyID = @param8";
                    }
                    if (cmbReservedTo.Text != "Select")
                    {
                        queryTotal += " AND J.ReservedTo = @param9";
                    }
                    if (cmbConsulate.Text != "Select")
                    {
                        queryTotal += " AND J.ConsulateID = @param10";
                    }

                    if (cbSelect.Checked == false)
                    {

                       
                        if (cbRefunded.Checked)
                        {
                            queryTotal += " AND S.Status = 'Refunded' ";
                        }
                        if (cbExpired.Checked)
                        {
                            queryTotal += " AND S.Status = 'Expired' ";
                        }
                        if (cbNotused.Checked)
                        {
                            queryTotal += " AND S.Status = 'Notused' ";
                        }
                        if (cbReserved.Checked)
                        {
                            queryTotal += " AND S.Status = 'Reserved' ";
                        }
                        if (cbVISAExpiredAfterStamped.Checked)
                        {
                            queryTotal += " AND S.Status = 'VISA Expired After Stamped' ";
                        }
                       
                        if (cbUsed.Checked)
                        {
                            queryTotal += " AND S.Status = 'Used' ";
                        }
                        if (cbVISAStamped.Checked)
                        {
                            queryTotal += " AND S.Status = 'VISA Stamped' ";
                        }
                        if (cbUnderProcess.Checked)
                        {
                            queryTotal += " AND S.Status = 'Under Process' ";
                        }


                    }


                    using (SqlCommand command = new SqlCommand(queryTotal, connection))
                    {
                        command.Parameters.Add(paramDateFrom);
                        command.Parameters.Add(paramDateTo);
                        if (cmbCompany.Text != "Select")

                        {
                            command.Parameters.Add(paramCompany2);
                        }
                        if (cmbReservedTo.Text != "Select")
                        {
                            command.Parameters.Add(paramReservedTo2);
                        }
                        if (cmbConsulate.Text != "Select")
                        {
                            command.Parameters.Add(paramConsulate);

                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(VisaReport);
                        }
                    }
                }

                dataGridView4.DataSource = VisaReport;
                dataGridView4.Columns[4].Width = 300; // Adjust column width if needed
            }
            else // Specific row
            {
                int Visacompanyidfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                int VisaREservedToidfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[1].Value);
                int VisaStatusIDfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[2].Value);

                SqlParameter paramVisaStatus = new SqlParameter("@param5", SqlDbType.Int) { Value = VisaStatusIDfordisplayreport };
                SqlParameter paramCompany = new SqlParameter("@param6", SqlDbType.Int) { Value = Visacompanyidfordisplayreport };
                SqlParameter paramReservedTo = new SqlParameter("@param7", SqlDbType.Int) { Value = VisaREservedToidfordisplayreport };

                DataTable VisaReport = new DataTable();
                using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
                {
                    connection.Open();
                    string queryRow = @"
                SELECT 
                    J.FileNumber,
                    J.Visanumber,
                    TRIM(COALESCE(CONCAT(E.FirstName, ' '), '') + COALESCE(CONCAT(E.SecondName, ' '), '') +
                    COALESCE(CONCAT(E.ThirdName, ' '), '') + COALESCE(E.Lastname, '')) AS [FullName],
                    CON.ConsulateCity AS [Consulate],
                    S.Status AS [Status],
                    CONVERT(NVARCHAR(10), V.IssueDateEN, 103) AS [Issue Date],
                    CONVERT(NVARCHAR(10), E.StartDate, 103) AS [Arrival Date]


                FROM 
                    VISAJobList J
                LEFT JOIN 
                    DelmonGroupDB.dbo.Employees E ON E.EmployeeID = J.EmployeeID
                LEFT JOIN 
                    DelmonGroupDB.dbo.Consulates CON ON CON.ConsulateID = J.ConsulateID
                LEFT JOIN 
                    DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID
                LEFT JOIN 
                    DelmonGroupDB.dbo.VISA V ON V.VisaNumber = J.VISANumber
                LEFT JOIN 
                    DelmonGroupDB.dbo.Companies CO ON J.ReservedTo = CO.COMPID
                LEFT JOIN 
                    DelmonGroupDB.dbo.Jobs Jo ON Jo.jobid = J.jobid
                LEFT JOIN 
                    DelmonGroupDB.dbo.Companies CO_COMP ON J.ReservedTo = CO_COMP.COMPID
                LEFT JOIN 
                    DelmonGroupDB.dbo.Companies V_COMP ON V.ComapnyID = V_COMP.COMPID
                WHERE 
                    TRY_CONVERT(DATETIME, V.IssueDateEN, 103) BETWEEN @param3 AND @param4
                    AND J.StatusID = @param5
                    AND V.ComapnyID = @param6
                    AND J.ReservedTo = @param7";

                    using (SqlCommand command = new SqlCommand(queryRow, connection))
                    {
                        command.Parameters.Add(paramDateFrom);
                        command.Parameters.Add(paramDateTo);
                        command.Parameters.Add(paramVisaStatus);
                        command.Parameters.Add(paramCompany);
                        command.Parameters.Add(paramReservedTo);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(VisaReport);
                        }
                    }
                }

                dataGridView4.DataSource = VisaReport;
                dataGridView4.Columns[3].Width = 300; // Adjust column width if needed
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
                if (permissionName.Contains("ViewVisaReport"))

                {
                    hasViewVISA = true;
                }
                if (permissionName.Contains("ViewCandidatesReport"))
                {
                    hasViewCANDIDATES = true;
                }
                if (permissionName.Contains("ViewAssetsReport"))
                {
                    hasViewAssets = true;
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
             if(tabControl1.SelectedTab==tabControl1.TabPages[2])
            {
                cmbPrinter.Text = "Select";
                if (hasViewAssets == false)
                {
                    MessageBox.Show("Sorry, You are not allowed to view this Module/Screen , kindly contact the administrator !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button2.Enabled= button5.Enabled = btnuplode.Enabled = false;
                    radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled =radioButton4.Enabled= radioButton5.Enabled=false;
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = false;
                    groupBox5.Enabled = groupBox6.Enabled = false;


                }
                else
                {
                    groupBox5.Enabled = groupBox6.Enabled = true;
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = true;
                          btnuplode.Enabled = true;
                         button2.Enabled = button5.Enabled = true;
                    radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = radioButton4.Enabled =radioButton5.Enabled = true;

                }

            }


            SQLCONN.CloseConnection();
        }




        private void btnuplode_Click(object sender, EventArgs e)
        {
            SqlParameter ParamUserPrinter = new SqlParameter("@C0", SqlDbType.NVarChar) { Value = cmbPrinter.SelectedValue };


            if (cmbPrinter.Text == "Select")
            {
                MessageBox.Show("Please select Printer !.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    // Open file dialog to select file
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm;*.csv";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Get the selected file path
                            string filePath = openFileDialog.FileName;
                            string fileExtension = Path.GetExtension(filePath).ToLower();

                            DataTable table = new DataTable();

                            // Check if the file is already open
                            try
                            {
                                using (System.IO.File.OpenRead(filePath))
                                {
                                    // File is not already open, proceed with reading and processing
                                }
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("The file is already open. Please close it and try again.");
                                return; // Exit the method if the file is already open
                            }

                            // Read data based on file type
                            if (fileExtension == ".csv")
                            {
                                using (var reader = new StreamReader(filePath))
                                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                                {
                                    using (var dr1 = new CsvDataReader(csv))
                                    {
                                        table.Load(dr1);
                                    }
                                }
                            }
                            else if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".xlsm")
                            {
                                using (var stream = System.IO.File.Open(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                                {
                                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                                    {
                                        var result = reader.AsDataSet();
                                        table = result.Tables[0]; // Assuming data is in first sheet
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Unsupported file format. Please select a CSV or Excel file.");
                                return;
                            }

                            if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            {
                                // Establish connection to SQL Server
                                SQLCONN4.OpenConection4();

                                // Check for existing JobID and AssetID combinations
                                HashSet<string> existingRecords = new HashSet<string>();
                                SqlDataReader dr = SQLCONN4.DataReader("SELECT JobID, AssetID FROM LogReport");
                                while (dr.Read())
                                {
                                    string jobID = dr["JobID"].ToString();
                                    string assetID = dr["AssetID"].ToString();
                                    existingRecords.Add($"{jobID}_{assetID}");
                                }
                                dr.Close();

                                bool duplicatesFound = false; // Flag to track if duplicates were found
                                bool dataInserted = false; // Flag to track if data has been inserted
                                Dictionary<string, string> fileRecordTracker = new Dictionary<string, string>(); // To track duplicates within the file

                                // Iterate through each row in the DataTable
                                for (int i = 0; i < table.Rows.Count; i++)
                                {
                                    DataRow row = table.Rows[i];
                                    string jobID = row[0].ToString();
                                    string assetID = cmbPrinter.Text.ToString();
                                    string recordKey = $"{jobID}_{assetID}";

                                    // Check for duplicates within the file
                                    if (fileRecordTracker.ContainsKey(recordKey))
                                    {
                                        duplicatesFound = true;
                                        // Log the duplicate within the file
                                        string duplicatePrintDate = fileRecordTracker[recordKey];
                                        SqlParameter paramDupAssetID = new SqlParameter("@AssetID", SqlDbType.NVarChar) { Value = assetID };
                                        SqlParameter paramDupJobID = new SqlParameter("@JobID", SqlDbType.NVarChar) { Value = jobID };
                                        SqlParameter paramDupPrintDate = new SqlParameter("@PrintDate", SqlDbType.NVarChar) { Value = duplicatePrintDate };

                                        SQLCONN4.ExecuteQueries("INSERT INTO DuplicateLog (AssetID, JobID, PrintDate) VALUES (@AssetID, @JobID, @PrintDate)",
                                        paramDupAssetID, paramDupJobID, paramDupPrintDate);
                                    }
                                    else
                                    {
                                        fileRecordTracker[recordKey] = row[4].ToString(); // Store PrintDate for the current recordKey

                                        if (existingRecords.Contains(recordKey))
                                        {
                                            duplicatesFound = true;

                                            // Retrieve the duplicate record details from LogReport
                                            SqlParameter paramJobID = new SqlParameter("@JobID", SqlDbType.NVarChar) { Value = jobID };
                                            SqlParameter paramAssetID = new SqlParameter("@AssetID", SqlDbType.NVarChar) { Value = assetID };
                                            SqlDataReader duplicateReader = SQLCONN4.DataReader("SELECT * FROM LogReport WHERE JobID = @JobID AND AssetID = @AssetID", paramJobID, paramAssetID);

                                            List<DuplicateRecord> duplicateRecords = new List<DuplicateRecord>();

                                            while (duplicateReader.Read())
                                            {
                                                string duplicatePrintDate = duplicateReader["PrintDate"].ToString();
                                                duplicateRecords.Add(new DuplicateRecord { AssetID = assetID, JobID = jobID, PrintDate = duplicatePrintDate });
                                            }
                                            duplicateReader.Close(); // Close the SqlDataReader after use

                                            // Insert duplicate job into DuplicateLog table
                                            foreach (var record in duplicateRecords)
                                            {
                                                // Format PrintDate as a string
                                                string formattedPrintDate = record.PrintDate.Replace('T', ' ');

                                                SqlParameter paramDupAssetID = new SqlParameter("@AssetID", SqlDbType.NVarChar) { Value = record.AssetID };
                                                SqlParameter paramDupJobID = new SqlParameter("@JobID", SqlDbType.NVarChar) { Value = record.JobID };
                                                SqlParameter paramDupPrintDate = new SqlParameter("@PrintDate", SqlDbType.NVarChar) { Value = formattedPrintDate };
                                                
                                                SQLCONN4.ExecuteQueries("INSERT INTO DuplicateLog (AssetID, JobID, PrintDate) VALUES (@AssetID, @JobID, @PrintDate)",
                                                paramDupAssetID, paramDupJobID, paramDupPrintDate);
                                            }
                                        }
                                        else
                                        {
                                            // Map file columns to SQL Server table columns based on their positions
                                            string UserName = row[1].ToString();
                                            string Domain = row[2].ToString();
                                            string Documentname = row[3].ToString();
                                            string PrintDate = row[4].ToString();
                                            string type = row[5].ToString().Split(' ')[0].Trim();
                                            string Department = row[6].ToString();
                                            string Pages = row[7].ToString();
                                            string Size = row[8].ToString();
                                            string Status = row[9].ToString();
                                            string Sets = row[10].ToString();

                                            // Calculate total
                                            int pages = int.Parse(Pages);
                                            int sets = int.Parse(Sets);
                                            int total = pages * sets;

                                            // Multiply by 2 if Size is A3
                                            if (Size.ToUpper() == "A3")
                                            {
                                                total *= 2;
                                            }

                                            // Format PrintDate as a string
                                            PrintDate = PrintDate.Replace('T', ' ');

                                            // Set parameter values
                                            SqlParameter paramNewAssetID = new SqlParameter("@AssetID", SqlDbType.NVarChar) { Value = assetID };
                                            SqlParameter paramNewJobid = new SqlParameter("@Jobid", SqlDbType.NVarChar) { Value = jobID };
                                            SqlParameter paramUserName = new SqlParameter("@UserName", SqlDbType.NVarChar) { Value = UserName };
                                            SqlParameter paramDomain = new SqlParameter("@Domain", SqlDbType.NVarChar) { Value = Domain };
                                            SqlParameter paramDocumentname = new SqlParameter("@Documentname", SqlDbType.NVarChar) { Value = Documentname };
                                            SqlParameter paramDate = new SqlParameter("@Date", SqlDbType.NVarChar) { Value = PrintDate };
                                            SqlParameter paramType = new SqlParameter("@Type", SqlDbType.NVarChar) { Value = type };
                                            SqlParameter paramDepartment = new SqlParameter("@Department", SqlDbType.NVarChar) { Value = Department };
                                            SqlParameter paramPages = new SqlParameter("@Pages", SqlDbType.Int) { Value = pages };
                                            SqlParameter paramSize = new SqlParameter("@Size", SqlDbType.NVarChar) { Value = Size };
                                            SqlParameter paramStatus = new SqlParameter("@Status", SqlDbType.NVarChar) { Value = Status };
                                            SqlParameter paramSets = new SqlParameter("@Sets", SqlDbType.Int) { Value = sets };
                                            SqlParameter paramTotal = new SqlParameter("@Total", SqlDbType.Int) { Value = total };

                                            // Execute INSERT command using SQLCONN4.ExecuteQueries
                                            SQLCONN4.ExecuteQueries("INSERT INTO LogReport (AssetID, jobid, username, domain, Documentname, PrintDate, type, Department, Pages, Size, Status, Sets, Total) " +
                                                                    "VALUES (@AssetID, @Jobid, @UserName, @Domain, @Documentname, @Date, @Type, @Department, @Pages, @Size, @Status, @Sets, @Total)",
                                                                    paramNewAssetID, paramNewJobid, paramUserName, paramDomain, paramDocumentname, paramDate, paramType, paramDepartment, paramPages, paramSize, paramStatus, paramSets, paramTotal);

                                            dataInserted = true; // Set flag to true if data is inserted
                                        }
                                    }
                                }

                                // Show message after all rows are processed
                                if (dataInserted)
                                {
                                    MessageBox.Show("Data uploaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dataGridView5.DataSource = SQLCONN4.ShowDataInGridViewORCombobox(@"SELECT * FROM LogReport WHERE AssetId=@C0 ;", ParamUserPrinter);
                                    // calculate sum
                                    int sum = 0;

                                    foreach (DataGridViewRow row in dataGridView5.Rows)
                                    {
                                        if (row.Cells[12].Value != null)
                                        {
                                            int quantity;
                                            if (int.TryParse(row.Cells[12].Value.ToString(), out quantity))
                                            {
                                                sum += quantity;
                                            }
                                        }
                                    }

                                    // Create a new DataRow for the total row
                                    DataTable dataTable = (DataTable)dataGridView5.DataSource;
                                    DataRow totalRow = dataTable.NewRow();
                                    totalRow[0] = "Total";
                                    totalRow[12] = sum;
                                    // Add the total row to the DataTable
                                    dataTable.Rows.Add(totalRow);

                                    // Get the DataGridViewRow for the total row
                                    DataGridViewRow totalDataGridViewRow = dataGridView5.Rows[dataTable.Rows.Count - 1];

                                    // Set the cell style for the new row
                                    totalDataGridViewRow.DefaultCellStyle.BackColor = Color.YellowGreen;
                                }

                                if (duplicatesFound)
                                {
                                    MessageBox.Show("Some duplicate Job IDs were found and logged into the DuplicateLog table,Kindly check ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                SQLCONN4.CloseConnection();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private class DuplicateRecord
        {
            public string AssetID { get; set; }
            public string JobID { get; set; }
            public string PrintDate { get; set; }
        }




        private void button2_Click_1(object sender, EventArgs e)
        {
            // Open the database connections for both databases
            SQLCONN.OpenConection();  // Open connection for DelmonGroupDB (Department, Employees)
            SQLCONN4.OpenConection4();    // Open connection for DelmonPrintersLog (LogReport, PrinterUsernameID)

            // Create the SQL parameters
            SqlParameter ParamUserPrinter = new SqlParameter("@C0", SqlDbType.NVarChar) { Value = cmbPrinter.SelectedValue };
            SqlParameter ParamFrom = new SqlParameter("@C1", SqlDbType.Date) { Value = dateTimePicker1.Value };
            SqlParameter ParamTo = new SqlParameter("@C2", SqlDbType.Date) { Value = dateTimePicker2.Value };

            // Ensure a radio button is selected
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked&&!radioButton5.Checked)
            {
                MessageBox.Show("Kindly select one of the Radio buttons! / Printer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a printer is selected if needed
            if ((radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked) && cmbPrinter.Text == "Select")
            {
                MessageBox.Show("Kindly select one of the Printers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Execute the appropriate query based on the selected radio button
            if (radioButton1.Checked) // By user
            {

            

                dataGridView5.DataSource = SQLCONN4.ShowDataInGridViewORCombobox(@"
SELECT 
    CASE 
        WHEN Username LIKE '%DELMONGROUP\nasser%' THEN 'Nasser'
        WHEN Username LIKE '%IT_Akram%' THEN 'Akram'
        WHEN Username LIKE '%Custom_Zamzam%' THEN 'Zamzam'
        WHEN Username LIKE '%Cutsom_Zamzam%' THEN 'Zamzam'
        WHEN Username LIKE '%Custom_Islam%' THEN 'Islam'
        WHEN Username LIKE '%Custom_Anshif%' THEN 'Anshif'
        WHEN Username LIKE '%Salt_Ravindra Yadav%' THEN 'Ravindra Yadav'
        WHEN Username LIKE '%Travels_Monir%' THEN 'Monir'
        WHEN Username LIKE '%Salt_Aafaque%' THEN 'Aafaque'
        WHEN Username LIKE '%Salt_Shakil%' THEN 'Shakil'
        WHEN Username LIKE '%Salt-Nabil%' THEN 'Nabil'
        WHEN Username LIKE '%AGB_Abdou%' THEN 'Abdou'
        WHEN Username LIKE '%Transportation_Naadi%' THEN 'Naadi'
        WHEN Username LIKE '%Admin_Khorshed%' THEN 'Khorshed'
        WHEN Username LIKE '%Accounts_Safthar%' THEN 'Safthar'
        WHEN Username LIKE '%IT Wesam%' THEN 'Wesam'
        WHEN Username LIKE '%Accounts_Akeel%' THEN 'Akeel'
        WHEN Username LIKE '%IT Abdullah%' THEN 'Abdullah'
        WHEN Username LIKE '%Account-Nasser%' THEN 'Nasser'
        WHEN Username LIKE '%NS_Diea%' THEN 'Deia_nabhan'
        WHEN Username LIKE '%Diea%' THEN 'Deia_nabhan'
        WHEN Username LIKE '%Silica_Ayat%' THEN 'Ayat'
        WHEN Username LIKE '%Silica_Rajesh%' THEN 'Rajesh'
        WHEN Username LIKE '%Silica_Krishna%' THEN 'Krishna'
        WHEN Username LIKE '%Silica_Ivan%' THEN 'Ivan'
        WHEN Username LIKE '%FM_Sarasdeen%' THEN 'Sarasdeen'
        WHEN Username LIKE '%MB_Shareek%' THEN 'Shareek'
        WHEN Username LIKE '%Travels_Shajeer%' THEN 'Shajeer'
        WHEN Username LIKE '%Lukoil_Manibhakta%' THEN 'Manibhakta'
        WHEN Username LIKE '%Admin_Khorshed%' THEN 'Khorshed'
        WHEN Username LIKE '%OP4_Ivan%' THEN 'Ivan'
        WHEN Username LIKE '%OP4_Reynaldo%' THEN 'Reynaldo'
        WHEN Username LIKE '%DFT_Fawzy%' THEN 'Fawzy'
        WHEN Username LIKE '%Salt_Mohammed Qasim%' THEN 'Mohammed Qasim'
        WHEN Username LIKE '%SAP_Balaji%' THEN 'Balaji'
        WHEN Username LIKE '%Lukoil_Mazen%' THEN 'Mazen'
        WHEN Username LIKE '%OP4_Hussain%' THEN 'Hussain'
        WHEN Username LIKE '%Lukoil_Nawaz%' THEN 'Nawaz'
        WHEN Username LIKE '%Mohammed Nawaz%' THEN 'Nawaz'
        WHEN Username LIKE '%SAP_Varaprasad%' THEN 'Varaprasad'
        WHEN Username LIKE '%Lukoil_Hamad%' THEN 'Hamad'
        WHEN Username LIKE '%Abdul Rahman Alghuna%' THEN 'Abdul Rahman'
        WHEN Username LIKE '%SAP_Syed Gesudaraz%' THEN 'Syed Gesudaraz'
        WHEN Username LIKE '%OP4_Sebastian%' THEN 'Sebastian'
        WHEN Username LIKE '%IT_Usama%' THEN 'Usama'
        WHEN Username LIKE '%DELMONGROUP\PC0092$%' THEN 'Akram'
        WHEN Username LIKE '%AzureAD\ShaheedAmeen%' THEN 'ShaheedAmeen'
        WHEN Username LIKE '%WORKGROUP\PC0250$%' THEN 'ShaheedAmeen'
        WHEN Username LIKE '%Custom_Moneam%' THEN 'Moneam'
        ELSE Username 
    END AS UnifiedUsername,
    SUM(Total) AS Count,
    FORMAT(SUM(Total) * 100.0 / (SELECT SUM(Total) FROM LogReport WHERE 
        CONVERT(DATE, Printdate, 120) BETWEEN @C1 AND @C2 AND AssetId = @C0), 'N2') AS Percentage
FROM LogReport
WHERE 
    CONVERT(DATE, Printdate, 120) BETWEEN @C1 AND @C2 AND AssetId=@C0
GROUP BY 
    CASE 
        WHEN Username LIKE '%DELMONGROUP\nasser%' THEN 'Nasser'
        WHEN Username LIKE '%IT_Akram%' THEN 'Akram'
        WHEN Username LIKE '%Custom_Zamzam%' THEN 'Zamzam'
        WHEN Username LIKE '%Cutsom_Zamzam%' THEN 'Zamzam'
        WHEN Username LIKE '%Custom_Islam%' THEN 'Islam'
        WHEN Username LIKE '%Custom_Anshif%' THEN 'Anshif'
        WHEN Username LIKE '%Salt_Ravindra Yadav%' THEN 'Ravindra Yadav'
        WHEN Username LIKE '%Travels_Monir%' THEN 'Monir'
        WHEN Username LIKE '%Salt_Aafaque%' THEN 'Aafaque'
        WHEN Username LIKE '%Salt_Shakil%' THEN 'Shakil'
        WHEN Username LIKE '%Salt-Nabil%' THEN 'Nabil'
        WHEN Username LIKE '%AGB_Abdou%' THEN 'Abdou'
        WHEN Username LIKE '%Transportation_Naadi%' THEN 'Naadi'
        WHEN Username LIKE '%Admin_Khorshed%' THEN 'Khorshed'
        WHEN Username LIKE '%Accounts_Safthar%' THEN 'Safthar'
        WHEN Username LIKE '%IT Wesam%' THEN 'Wesam'
        WHEN Username LIKE '%Accounts_Akeel%' THEN 'Akeel'
        WHEN Username LIKE '%IT Abdullah%' THEN 'Abdullah'
        WHEN Username LIKE '%Account-Nasser%' THEN 'Nasser'
        WHEN Username LIKE '%NS_Diea%' THEN 'Deia_nabhan'
        WHEN Username LIKE '%Diea%' THEN 'Deia_nabhan'
        WHEN Username LIKE '%Silica_Ayat%' THEN 'Ayat'
        WHEN Username LIKE '%Silica_Rajesh%' THEN 'Rajesh'
        WHEN Username LIKE '%Silica_Krishna%' THEN 'Krishna'
        WHEN Username LIKE '%Silica_Ivan%' THEN 'Ivan'
        WHEN Username LIKE '%FM_Sarasdeen%' THEN 'Sarasdeen'
        WHEN Username LIKE '%MB_Shareek%' THEN 'Shareek'
        WHEN Username LIKE '%Travels_Shajeer%' THEN 'Shajeer'
        WHEN Username LIKE '%Lukoil_Manibhakta%' THEN 'Manibhakta'
        WHEN Username LIKE '%Admin_Khorshed%' THEN 'Khorshed'
        WHEN Username LIKE '%OP4_Ivan%' THEN 'Ivan'
        WHEN Username LIKE '%OP4_Reynaldo%' THEN 'Reynaldo'
        WHEN Username LIKE '%DFT_Fawzy%' THEN 'Fawzy'
        WHEN Username LIKE '%Salt_Mohammed Qasim%' THEN 'Mohammed Qasim'
        WHEN Username LIKE '%SAP_Balaji%' THEN 'Balaji'
        WHEN Username LIKE '%Lukoil_Mazen%' THEN 'Mazen'
        WHEN Username LIKE '%OP4_Hussain%' THEN 'Hussain'
        WHEN Username LIKE '%Lukoil_Nawaz%' THEN 'Nawaz'
        WHEN Username LIKE '%Mohammed Nawaz%' THEN 'Nawaz'
        WHEN Username LIKE '%SAP_Varaprasad%' THEN 'Varaprasad'
        WHEN Username LIKE '%Lukoil_Hamad%' THEN 'Hamad'
        WHEN Username LIKE '%Abdul Rahman Alghuna%' THEN 'Abdul Rahman'
        WHEN Username LIKE '%SAP_Syed Gesudaraz%' THEN 'Syed Gesudaraz'
        WHEN Username LIKE '%OP4_Sebastian%' THEN 'Sebastian'
        WHEN Username LIKE '%IT_Usama%' THEN 'Usama'
        WHEN Username LIKE '%DELMONGROUP\PC0092$%' THEN 'Akram'
        WHEN Username LIKE '%AzureAD\ShaheedAmeen%' THEN 'ShaheedAmeen'
        WHEN Username LIKE '%WORKGROUP\PC0250$%' THEN 'ShaheedAmeen'
        WHEN Username LIKE '%Custom_Moneam%' THEN 'Moneam'
 
        ELSE Username 
    END
ORDER BY Count DESC;
", ParamFrom, ParamTo, ParamUserPrinter);
            }
            else if (radioButton2.Checked) // By department
            {
                // Query with multiple databases: DelmonGroupDB and DelmonPrintersLog
                dataGridView5.DataSource = SQLCONN4.ShowDataInGridViewORCombobox(@"
           SELECT dt.Dept_Type_Name as Department,
    SUM(lr.Total) AS Count,
    FORMAT(SUM(Total) * 100.0 / (SELECT SUM(Total) FROM LogReport WHERE CONVERT(DATE, Printdate, 120) BETWEEN @C1 AND @C2 AND AssetId = @C0), 'N2') AS Percentage

 FROM DelmonGroupDB.dbo.DEPARTMENTS d,
DelmonGroupDB.dbo.DeptTypes dt,
DelmonGroupDB.dbo.Employees e,
DelmonPrintersLog.dbo.LogReport lr,
DelmonPrintersLog.dbo.PrinterUsernameID pd 
WHERE 
            pd.Username=lr.Username 
			and pd.ID = e.EmployeeID
			and e.DeptID = d.DEPTID
			and d.DeptName = dt.Dept_Type_ID
            and CONVERT(DATE, lr.Printdate, 120) BETWEEN @C1 AND @C2
            AND lr.AssetId = @C0
            GROUP BY dt.Dept_Type_Name
            ORDER BY Count;", ParamFrom, ParamTo, ParamUserPrinter);
            }
            else if (radioButton3.Checked) // Full report
            {
                if (cmbPrinter.Text == "Select")
                {
                    dataGridView5.DataSource = SQLCONN4.ShowDataInGridViewORCombobox(@"SELECT * FROM LogReport WHERE 
                CONVERT(DATE, Printdate, 120) BETWEEN @C1 AND @C2;", ParamFrom, ParamTo);
                }
                else
                {
                    dataGridView5.DataSource = SQLCONN4.ShowDataInGridViewORCombobox(@"SELECT * FROM LogReport WHERE 
                CONVERT(DATE, Printdate, 120) BETWEEN @C1 AND @C2 AND AssetId=@C0;", ParamFrom, ParamTo, ParamUserPrinter);
                }
            }
            else if (radioButton4.Checked) // Duplicate log
            {
                if (cmbPrinter.Text == "Select")
                {
                    dataGridView5.DataSource = SQLCONN4.ShowDataInGridViewORCombobox(@"SELECT * FROM [DuplicateLog] WHERE 
                CONVERT(DATE, Printdate, 120) BETWEEN @C1 AND @C2;", ParamFrom, ParamTo);
                }
                else
                {
                    dataGridView5.DataSource = SQLCONN4.ShowDataInGridViewORCombobox(@"SELECT * FROM [DuplicateLog] WHERE 
                CONVERT(DATE, Printdate, 120) BETWEEN @C1 AND @C2 AND AssetId=@C0;", ParamFrom, ParamTo, ParamUserPrinter);
                }
            }
            else if (radioButton5.Checked) // Combined user and department report
            {
                dataGridView5.DataSource = SQLCONN4.ShowDataInGridViewORCombobox(@"
               SELECT 
    e.FirstName + ' ' + e.SecondName + ' ' + e.ThirdName + ' ' + e.LastName AS [User Name],
    dt.Dept_Type_Name as Department,
    SUM(lr.Total) AS [Print Count],
    FORMAT(SUM(lr.Total) * 100.0 / 
           (SELECT SUM(Total) 
            FROM DelmonPrintersLog.dbo.LogReport 
            WHERE CONVERT(DATE, Printdate, 120) BETWEEN @C1 AND @C2 
              AND AssetId = @C0), 'N2') AS [Percentage]
FROM DelmonPrintersLog.dbo.LogReport lr
LEFT JOIN DelmonPrintersLog.dbo.PrinterUsernameID pd ON pd.Username = lr.Username
LEFT JOIN DelmonGroupDB.dbo.Employees e ON pd.ID = e.EmployeeID
LEFT JOIN DelmonGroupDB.dbo.DEPARTMENTS d ON e.DeptID = d.DEPTID
LEFT JOIN DelmonGroupDB.dbo.DeptTypes dt ON d.DeptName = dt.Dept_Type_ID
WHERE CONVERT(DATE, lr.Printdate, 120) BETWEEN @C1 AND @C2 
  AND lr.AssetId = @C0
GROUP BY 
    e.FirstName + ' ' + e.SecondName + ' ' + e.ThirdName + ' ' + e.LastName,
    dt.Dept_Type_Name
ORDER BY [Print Count] DESC;
", ParamFrom, ParamTo, ParamUserPrinter);
            }




            // Adjust DataGridView settings and add total row if applicable
            AdjustDataGridView();

            // Close the database connections
            SQLCONN.CloseConnection();
            SQLCONN4.CloseConnection();
        }


        private void AdjustDataGridView()
        {
            // Common adjustments for the DataGridView
            dataGridView5.Columns[0].Width = 150;

            if (radioButton1.Checked || radioButton2.Checked) // By user or by department
            {
                int sum = 0;
                int sum2 = 0;

                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    if (row.Cells[1].Value != null && int.TryParse(row.Cells[1].Value.ToString(), out int quantity))
                    {
                        sum += quantity;
                    }
                    if (row.Cells[2].Value != null && int.TryParse(row.Cells[2].Value.ToString(), out int quantity2))
                    {
                        sum2 += quantity2;
                    }
                }

                // Add total row and calculate percentage
                AddTotalRow(sum, 1);
                AddTotalRow(sum2, 2);

                // Remove the last row (Total row)
                if (dataGridView5.Rows.Count > 0)
                {
                    dataGridView5.Rows.RemoveAt(dataGridView5.Rows.Count - 1);
                }

                // Calculate and add percentage column
                if (sum > 0)
                {
                    foreach (DataGridViewRow row in dataGridView5.Rows)
                    {
                        if (row.Cells[1].Value != null && int.TryParse(row.Cells[1].Value.ToString(), out int quantity))
                        {
                            double percentage = (double)quantity / sum * 100;
                            row.Cells["Percentage"].Value = percentage.ToString("F2");
                        }
                    }
                }
            }
            else if (radioButton3.Checked) // Full report
            {
                int sum = 0;
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    if (row.Cells[12].Value != null && int.TryParse(row.Cells[12].Value.ToString(), out int quantity))
                    {
                        sum += quantity;
                    }
                }

                AddTotalRow(sum, 12);
                lblSum.Text = sum.ToString();
            }
            else if (radioButton4.Checked) // Duplicate log
            {
                dataGridView5.Columns[2].Width = 300;
                int rowCount = dataGridView5.RowCount;
                lblSum.Text = rowCount.ToString();
            }
            else if (radioButton5.Checked) // Combined user and department report
            {
                dataGridView5.Columns[2].Width = 300;
                int rowCount = dataGridView5.RowCount;
                lblSum.Text = rowCount.ToString();
            }

            dataGridView5.Refresh();
        }

        private void AddTotalRow(int sum, int columnIndex)
        {
            DataTable dataTable = (DataTable)dataGridView5.DataSource;
            DataRow totalRow = dataTable.NewRow();
            totalRow[0] = "Total";
            totalRow[columnIndex] = sum;
            dataTable.Rows.Add(totalRow);

            DataGridViewRow totalDataGridViewRow = dataGridView5.Rows[dataTable.Rows.Count - 1];
            totalDataGridViewRow.DefaultCellStyle.BackColor = Color.YellowGreen;

            // Add the percentage if it's available
            if (columnIndex == 1 || columnIndex == 2) // Percentage is calculated for these columns
            {
                totalDataGridViewRow.Cells["Percentage"].Value = "100.00"; // 100% for the total row
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets.Add("Report");

                ExportDataGridViewToExcel(dataGridView5, worksheet1);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save as Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    package.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = dataGridView4.DataSource = null;
            cmbCompany.Text = cmbReservedTo.Text = cmbConsulate.Text = "Select";
            dtpfrom.Value =dtpto.Value= DateTime.Now;
            UncheckAllCheckboxes(this);
        }

        private void cmbcandidates2_TextChanged(object sender, EventArgs e)
        {
            // Simple debugging log to see when this event gets triggered

            // This is just to check if the ComboBox is working without filtering
            if (originalDataCand != null)
            {
                // Set DataSource to original data to check for any issues
                cmbcandidates2.DataSource = originalDataCand;
                cmbcandidates2.ValueMember = "EmployeeID";
                cmbcandidates2.DisplayMember = "Name";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

