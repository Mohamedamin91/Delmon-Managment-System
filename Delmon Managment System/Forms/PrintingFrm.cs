using Microsoft.Reporting.WinForms;
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
    public partial class PrintingFrm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int loggedEmployee;
        int companyidfordisplayreport;
        int StatusIDfordisplayreport;
        int Visacompanyidfordisplayreport;
        int VisaStatusIDfordisplayreport;
        public PrintingFrm()
        {
            InitializeComponent();
        }

        private void PrintingFrm_Load(object sender, EventArgs e)
        {

            //// Set report parameters
            //ReportParameter param1 = new ReportParameter("param1", DateTime.Now.ToString("dd/MM/yyyy"));
            //reportViewer1.LocalReport.SetParameters(param1);
            //// Set report parameters
            //ReportParameter param2 = new ReportParameter("param2", DateTime.Now.ToString("dd/MM/yyyy"));
            //reportViewer1.LocalReport.SetParameters(param2);

            //ReportParameter param3 = new ReportParameter("param3", DateTime.Now.ToString("dd/MM/yyyy"));
            //reportViewer2.LocalReport.SetParameters(param3);
            //// Set report parameters
            //ReportParameter param4 = new ReportParameter("param4", DateTime.Now.ToString("dd/MM/yyyy"));
            //reportViewer2.LocalReport.SetParameters(param4);


            lblusername.Text = CommonClass.LoginUserName;
            lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            loggedEmployee = CommonClass.EmployeeID;
            lblPC.Text = Environment.MachineName;

            SQLCONN.OpenConection();
            if (lblusertype.Text == "Admin")
            {
                //LoadTheme(); 

                //cmbStatus.ValueMember = "statusid";
                //cmbStatus.DisplayMember = "status";
                //cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select statusid,status  from Visastatus where RefrenceID =1 or RefrenceID = 0 order by statusid");
                //cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;


                cmbPersonalStatusStatus.ValueMember = "StatusID";
                cmbPersonalStatusStatus.DisplayMember = "StatusValue";
                cmbPersonalStatusStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  StatusID , StatusValue  from StatusTBL where RefrenceID=2 or RefrenceID=0  ");
                cmbPersonalStatusStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbPersonalStatusStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

                string querycomp = "SELECT COMPID,COMPName_EN FROM Companies";
                string querycomp2 = "SELECT COMPID,COMPName_EN FROM Companies";

                cmbCompany.ValueMember = "COMPID";
                cmbCompany.DisplayMember = "COMPName_EN";
                cmbcomp.ValueMember = "COMPID";
                cmbcomp.DisplayMember = "COMPName_EN";
                cmbReservedTo.ValueMember = "COMPID";
                cmbReservedTo.DisplayMember = "COMPName_EN";
                cmbCompany.DataSource = cmbcomp.DataSource = SQLCONN.ShowDataInGridViewORCombobox(querycomp);
                cmbReservedTo.DataSource = SQLCONN.ShowDataInGridViewORCombobox(querycomp2);
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





            }
            else
            {

                SqlParameter paramloggiedemployeeid = new SqlParameter("@C1", SqlDbType.NVarChar);
                paramloggiedemployeeid.Value = loggedEmployee;
                //cmbStatus.ValueMember = "statusid";
                //cmbStatus.DisplayMember = "status";
                //cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select statusid,status  from Visastatus where RefrenceID =1 or RefrenceID = 0 order by statusid");
                //cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbPersonalStatusStatus.ValueMember = "StatusID";
                cmbPersonalStatusStatus.DisplayMember = "StatusValue";
                cmbPersonalStatusStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  StatusID , StatusValue  from StatusTBL where RefrenceID=2  ");
                cmbPersonalStatusStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbPersonalStatusStatus.AutoCompleteSource = AutoCompleteSource.ListItems;



                cmbCompany.ValueMember = "Companies.COMPID";
                cmbCompany.DisplayMember = "COMPName_EN";
                cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Companies.COMPID,COMPName_EN FROM Companies,Employees where Employees.COMPID=Companies.COMPID and Employees.EmployeeID=@C1", paramloggiedemployeeid);
                cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbCompany.Enabled = false;


                cmbcomp.ValueMember = "Companies.COMPID";
                cmbcomp.DisplayMember = "COMPName_EN";
                cmbcomp.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Companies.COMPID,COMPName_EN FROM Companies,Employees where Employees.COMPID=Companies.COMPID and Employees.EmployeeID=@C1", paramloggiedemployeeid);
                cmbcomp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbcomp.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbcomp.Text = "Select";
                cmbcomp.Enabled = false;


                cmbcandidates2.ValueMember = "EmployeeID";
                cmbcandidates2.DisplayMember = "Name";
                cmbcandidates2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees],DEPARTMENTS where Employees.DeptID = DEPARTMENTS.DEPTID  " +
                    " AND Employees.DeptID = (SELECT DeptID FROM Employees WHERE EmployeeID = @C1 )", paramloggiedemployeeid);
                cmbcandidates2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbcandidates2.AutoCompleteSource = AutoCompleteSource.ListItems;






            }
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

            //reportViewer1.Visible = true;
            //SQLCONN.OpenConection();

            //loggedEmployee = CommonClass.EmployeeID;

            //SqlParameter paramDateFrom = new SqlParameter("@param1", SqlDbType.Date);
            //paramDateFrom.Value = dtpfrom.Value;
            //SqlParameter paramDateTo = new SqlParameter("@param2", SqlDbType.Date);
            //paramDateTo.Value = dtpto.Value;
            //SqlParameter paramCompany = new SqlParameter("@param4", SqlDbType.NVarChar);
            //paramCompany.Value = cmbCompany.SelectedValue;

            //List<int> selectedStatus = new List<int>();

            //// Code for check box selection

            //DataTable VisaReport = new DataTable();

            //using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            //{
            //    connection.Open();

            //    string query = "SELECT C.COMPName_EN as [CompanyName], CO.COMPName_EN as [ReservedTo], S.Status as [VisaStatus], COUNT(*) AS [TotalVisas] " +
            //       "FROM DelmonGroupDB.dbo.VISA V " +
            //       "JOIN DelmonGroupDB.dbo.VISAJobList J ON V.VisaNumber = J.VISANumber " +
            //       "JOIN DelmonGroupDB.dbo.Companies C ON V.ComapnyID = C.COMPID " +
            //                      "JOIN DelmonGroupDB.dbo.Companies CO ON J.ReservedTo = CO.COMPID " +
            //       "JOIN DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID AND S.RefrenceID = 1 " +
            //       "JOIN DelmonGroupDB.dbo.Employees E ON E.EmployeeID = J.EmployeeID " +
            //       "WHERE TRY_CONVERT(DATETIME, IssueDateEN, 103) BETWEEN @param1 AND @param2 ";

            //    // Append the selected status filter to the query
            //    if (selectedStatus.Count > 0)
            //    {
            //        query += "AND J.StatusID IN (";
            //        for (int i = 0; i < selectedStatus.Count; i++)
            //        {
            //            query += "@status" + i;
            //            if (i < selectedStatus.Count - 1)
            //                query += ", ";
            //        }
            //        query += ")";
            //    }

            //    // Add the employee start date filter
            //    query += "AND E.startDate >= @startDate ";

            //    query += "GROUP BY C.COMPName_EN, S.Status,CO.COMPName_EN " +
            //             "ORDER BY C.COMPName_EN, S.Status,CO.COMPName_EN ";

            //    SqlCommand command = new SqlCommand(query, connection);
            //    command.Parameters.AddWithValue("@param1", dtpfrom.Value);
            //    command.Parameters.AddWithValue("@param2", dtpto.Value);

            //    // Add parameters for selected status values
            //    for (int i = 0; i < selectedStatus.Count; i++)
            //    {
            //        command.Parameters.AddWithValue("@status" + i, selectedStatus[i]);
            //    }

            //    // Add the parameter for employee start date
            //    command.Parameters.AddWithValue("@startDate", dtpfrom.Value);

            //    // command.Parameters.Add(paramCompany); // add the parameter to the command object

            //    SqlDataAdapter adapter = new SqlDataAdapter(command);
            //    adapter.Fill(VisaReport);
            //    connection.Close();
            //}

            //ReportDataSource dataSource = new ReportDataSource("DataSet1", VisaReport);
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(dataSource);
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("param1", dtpfrom.Value.ToString("dd/MM/yyyy")) });
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("param2", dtpto.Value.ToString("dd/MM/yyyy")) });
            //this.reportViewer1.RefreshReport();
            //SQLCONN.CloseConnection();




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
        SELECT  Companies.COMPID,StatusTBL.StatusID,Companies.COMPName_EN 'Company',
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

                    query += " GROUP BY   StatusTBL.StatusID,Companies.COMPID,StatusTBL.StatusValue, Companies.COMPName_EN";
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

                    query += " GROUP BY   StatusTBL.StatusID,Companies.COMPID,StatusTBL.StatusValue, Companies.COMPName_EN";
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
            dataGridView3.Columns[2].Width = 400; // Replace "ColumnName" with the actual name of the column
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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            loggedEmployee = CommonClass.EmployeeID;

            SqlParameter paramDateFrom = new SqlParameter("@param1", SqlDbType.Date);
            paramDateFrom.Value = dtpfrom.Value;
            SqlParameter paramDateTo = new SqlParameter("@param2", SqlDbType.Date);
            paramDateTo.Value = dtpto.Value;
            SqlParameter paramCompany = new SqlParameter("@param4", SqlDbType.NVarChar);
            paramCompany.Value = cmbCompany.SelectedValue;
            SqlParameter paramReservedTo = new SqlParameter("@param5", SqlDbType.NVarChar);
            paramReservedTo.Value = cmbReservedTo.SelectedValue;

            // Define a list to store the selected status values
            List<int> selectedStatus = new List<int>();

            // Code to retrieve data and display in DataGridView
            DataTable VisaReport = new DataTable();

            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            {
                connection.Open();

                string query = "SELECT C.COMPID, S.StatusID, C.COMPName_EN as [Company], CO.COMPName_EN as [Reserved To], S.Status as [VisaStatus], COUNT(*) AS [TotalVisas] " +
                    "FROM DelmonGroupDB.dbo.VISA V " +
                    "JOIN DelmonGroupDB.dbo.VISAJobList J ON V.VisaNumber = J.VISANumber " +
                    "JOIN DelmonGroupDB.dbo.Companies C ON V.ComapnyID = C.COMPID " +
                    "JOIN DelmonGroupDB.dbo.Companies CO ON J.ReservedTo = CO.COMPID " +
                    "JOIN DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID AND S.RefrenceID = 1 " +
                    "JOIN DelmonGroupDB.dbo.Employees E ON E.EmployeeID = J.EmployeeID " +
                    "WHERE TRY_CONVERT(DATETIME, STARTDATE, 103) BETWEEN @param1 AND @param2 ";

                //company
                if ((int)cmbCompany.SelectedValue != 0)
                {
                    query += "AND V.ComapnyID = @param4 ";
                }
                if ((int)cmbReservedTo.SelectedValue != 0)
                {
                    query += "AND j.ReservedTo = @param5 ";
                }

                // Add the selected status filter to the query
                if (cbNotused.Checked)
                {
                    query += "AND J.StatusID = @status1 ";
                }

                if (cbReserved.Checked)
                {
                    query += "AND J.StatusID = @status2 ";
                }

                if (cbUnderProcess.Checked)
                {
                    query += "AND J.StatusID = @status3 ";
                }

                if (cbVISAStamped.Checked)
                {
                    query += "AND J.StatusID = @status4 ";
                }

                if (cbUsed.Checked)
                {
                    query += "AND J.StatusID = @status5 ";
                }

                if (cbExpired.Checked)
                {
                    query += "AND J.StatusID = @status6 ";
                }

                if (cbRefunded.Checked)
                {
                    query += "AND J.StatusID = @status7 ";
                }

                if (cbVISAExpiredAfterStamped.Checked)
                {
                    query += "AND J.StatusID = @status8 ";
                }

                query += "GROUP BY C.COMPID, S.StatusID, C.COMPName_EN, CO.COMPName_EN, S.Status " +
                         "ORDER BY C.COMPID, S.StatusID, C.COMPName_EN, S.Status, CO.COMPName_EN ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@param1", dtpfrom.Value);
                command.Parameters.AddWithValue("@param2", dtpto.Value);
                command.Parameters.AddWithValue("@param4", cmbCompany.SelectedValue);
                command.Parameters.AddWithValue("@param5", cmbReservedTo.SelectedValue);

                // Add parameters for selected status values
                if (cbNotused.Checked)
                {
                    command.Parameters.AddWithValue("@status1", 2); // Replace with the actual status value
                }

                if (cbReserved.Checked)
                {
                    command.Parameters.AddWithValue("@status2", 3); // Replace with the actual status value
                }

                if (cbUnderProcess.Checked)
                {
                    command.Parameters.AddWithValue("@status3", 4); // Replace with the actual status value
                }

                if (cbVISAStamped.Checked)
                {
                    command.Parameters.AddWithValue("@status4", 5); // Replace with the actual status value
                }

                if (cbUsed.Checked)
                {
                    command.Parameters.AddWithValue("@status5", 6); // Replace with the actual status value
                }

                if (cbExpired.Checked)
                {
                    command.Parameters.AddWithValue("@status6", 7); // Replace with the actual status value
                }

                if (cbRefunded.Checked)
                {
                    command.Parameters.AddWithValue("@status7", 8); // Replace with the actual status value
                }

                if (cbVISAExpiredAfterStamped.Checked)
                {
                    command.Parameters.AddWithValue("@status8", 9); // Replace with the actual status value
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(VisaReport);
                connection.Close();
            }

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = VisaReport;
            dataGridView2.Columns[0].Visible = false; // Replace "ColumnName" with the actual name of the column
            dataGridView2.Columns[1].Visible = false; // Replace "ColumnName" with the actual name of the column
            dataGridView2.Columns[2].Width = 400; // Replace "ColumnName" with the actual name of the column
            dataGridView2.Columns[3].Width = 400; // Replace "ColumnName" with the actual name of the column
            dataGridView2.Columns[4].Width = 100; // Replace "ColumnName" with the actual name of the column

            // Calculate the sum of the column
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[5].Value != null)
                {
                    int quantity;
                    if (int.TryParse(row.Cells[5].Value.ToString(), out quantity))
                    {
                        sum += quantity;
                    }
                }
            }

            // Create a new DataRow for the total row
            DataTable dataTable = (DataTable)dataGridView2.DataSource;
            DataRow totalRow = dataTable.NewRow();
            totalRow[2] = "Total";
            totalRow[5] = sum;
            // Add the total row to the DataTable
            dataTable.Rows.Add(totalRow);

            // Get the DataGridViewRow for the total row
            DataGridViewRow totalDataGridViewRow = dataGridView2.Rows[dataTable.Rows.Count - 1];

            // Set the cell style for the new row
            totalDataGridViewRow.DefaultCellStyle.BackColor = Color.YellowGreen;

            // Refresh the DataGridView to reflect the changes
            dataGridView2.Refresh();


        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            dataGridView1.Visible = true;
            // Check if the clicked cell is in the last row
            if (e.RowIndex == dataGridView3.Rows.Count - 1)
            {
                // Prevent any action for the last row
                return;
            }

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
                        companyidfordisplayreport = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                        StatusIDfordisplayreport = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString());

                    }



                }
            }

            // Set the query parameters
            SqlParameter paramDateFrom = new SqlParameter("@param3", SqlDbType.Date);
            paramDateFrom.Value = FromDate.Value;

            SqlParameter paramDateTo = new SqlParameter("@param4", SqlDbType.Date);
            paramDateTo.Value = todate.Value;

            SqlParameter paramVisaStatus = new SqlParameter("@param5", SqlDbType.NVarChar);
            paramVisaStatus.Value = StatusIDfordisplayreport;

            SqlParameter paramCompany = new SqlParameter("@param6", SqlDbType.Int);
            paramCompany.Value = companyidfordisplayreport;

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
            SELECT V.FileNumber,Employees.EmployeeID,TRIM(COALESCE(CONCAT(FirstName, ' '), '') +
                        COALESCE(CONCAT(SecondName, ' '), '') +
                        COALESCE(CONCAT(ThirdName, ' '), '') +
                        COALESCE(Lastname, '')) AS [FullName],Countries.NationalityName 'Nationality',
                    StatusTBL.StatusValue 'Status',                 
                    CONVERT(NVARCHAR(10), StartDate, 103) AS [Date]               
            FROM Employees
            JOIN Countries ON Employees.NationalityID = Countries.CountryId
            JOIN StatusTBL ON Employees.EmploymentStatusID = StatusTBL.StatusID
            LEFT JOIN VISAJobList v ON Employees.EmployeeID = v.EmployeeID

            WHERE TRY_CONVERT(DATE, StartDate, 103) BETWEEN @param3 AND @param4 AND Employees.EmploymentStatusID = @param5 AND Employees.COMPID = @param6 
               GROUP BY Countries.NationalityName,V.FileNumber,Employees.EmployeeID,StatusTBL.StatusValue, TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') + COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')), StartDate";



                // Create a new SqlCommand object with the query and parameters
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(paramDateFrom);
                    command.Parameters.Add(paramDateTo);
                    command.Parameters.Add(paramVisaStatus);
                    command.Parameters.Add(paramCompany);
                    //  command.Parameters.Add(paramCandidate);

                    // Execute the query and fill the DataTable with the results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(CandidateReport);
                    }
                }
            }

            // Set the DataTable as the DataSource for the DataGridView
            dataGridView1.DataSource = CandidateReport;
            dataGridView1.Columns[2].Width = 300; // Replace "ColumnName" with the actual name of the column


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


        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //    Check if it's the desired column and the last row
            //    if (e.ColumnIndex == dataGridView3.Columns[4].Index && e.RowIndex == dataGridView3.Rows.Count - 1)
            //    {
            //        int sum = 0;

            //        Calculate the sum of the column
            //        foreach (DataGridViewRow row in dataGridView3.Rows)
            //        {
            //            if (row.Cells[4].Value != null)
            //            {
            //                int quantity;
            //                if (int.TryParse(row.Cells[4].Value.ToString(), out quantity))
            //                {
            //                    sum += quantity;
            //                }
            //            }
            //        }

            //        Set the value of the last cell in the column to the sum
            //        e.Value = sum.ToString();
            //        e.FormattingApplied = true;
            //    }
          //  CalculateAndDisplayTotal();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            dataGridView4.Visible = true;
            // Check if the clicked cell is in the last row
            if (e.RowIndex == dataGridView4.Rows.Count - 1)
            {
                // Prevent any action for the last row
                return;
            }

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
                        Visacompanyidfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        VisaStatusIDfordisplayreport = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString());
                        

                    }



                }
            }

            // Set the query parameters
            SqlParameter paramDateFrom = new SqlParameter("@param3", SqlDbType.Date);
            paramDateFrom.Value = FromDate.Value;

            SqlParameter paramDateTo = new SqlParameter("@param4", SqlDbType.Date);
            paramDateTo.Value = todate.Value;

            SqlParameter paramVisaStatus = new SqlParameter("@param5", SqlDbType.NVarChar);
            paramVisaStatus.Value = VisaStatusIDfordisplayreport;

            SqlParameter paramCompany = new SqlParameter("@param6", SqlDbType.Int);
            paramCompany.Value = Visacompanyidfordisplayreport;

            SqlParameter paramCandidate = new SqlParameter("@param7", SqlDbType.NVarChar);
            paramCandidate.Value = cmbcandidates2.SelectedValue;

            // Create a new DataTable to store the report data
            DataTable VisaReport = new DataTable();

            // Connect to the database and retrieve the report data
            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            {
                connection.Open();

                // Build the query based on the user's selected options
                string query = @"
           SELECT VISAJobList.FileNumber, VISAJobList.Visanumber, Employees.EmployeeID,
    TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') +
    COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')) AS [FullName],
    Countries.NationalityName AS [Nationality],
    VISAStatus.Status AS [Status],
    CONVERT(NVARCHAR(10), StartDate, 103) AS [Date]
FROM Employees
LEFT JOIN VISAJobList ON Employees.EmployeeID = VISAJobList.EmployeeID
JOIN Countries ON Employees.NationalityID = Countries.CountryId
JOIN VISAStatus ON VISAJobList.StatusID = VISAStatus.StatusID
WHERE /*TRY_CONVERT(DATETIME, STARTDATE, 103) BETWEEN @param3 AND @param4 and*/  VISAJobList.StatusID = @param5
    AND Employees.COMPID = @param6
GROUP BY Countries.NationalityName, VISAJobList.FileNumber, VISAJobList.Visanumber,
    Employees.EmployeeID, VISAStatus.Status,
    TRIM(COALESCE(CONCAT(FirstName, ' '), '') + COALESCE(CONCAT(SecondName, ' '), '') +
    COALESCE(CONCAT(ThirdName, ' '), '') + COALESCE(Lastname, '')), StartDate";



                // Create a new SqlCommand object with the query and parameters
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                  //  command.Parameters.Add(paramDateFrom);
                  //  command.Parameters.Add(paramDateTo);
                    command.Parameters.Add(paramVisaStatus);
                    command.Parameters.Add(paramCompany);
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

