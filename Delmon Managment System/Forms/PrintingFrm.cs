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
        public PrintingFrm()
        {
            InitializeComponent();
        }

        private void PrintingFrm_Load(object sender, EventArgs e)
        {

            // Set report parameters
            ReportParameter param1 = new ReportParameter("param1", DateTime.Now.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(param1);
            // Set report parameters
            ReportParameter param2 = new ReportParameter("param2", DateTime.Now.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(param2);

            ReportParameter param3 = new ReportParameter("param1", DateTime.Now.ToString("dd/MM/yyyy"));
            reportViewer2.LocalReport.SetParameters(param3);
            // Set report parameters
            ReportParameter param4 = new ReportParameter("param2", DateTime.Now.ToString("dd/MM/yyyy"));
            reportViewer2.LocalReport.SetParameters(param4);


            lblusername.Text = CommonClass.LoginUserName;
            lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            loggedEmployee = CommonClass.EmployeeID;
            lblPC.Text = Environment.MachineName;

            //LoadTheme(); 
            SQLCONN.OpenConection();
            this.reportViewer1.RefreshReport();
            cmbStatus.ValueMember = "statusid";
            cmbStatus.DisplayMember = "status";
            cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select statusid,status  from Visastatus where RefrenceID =1 or RefrenceID = 0 order by statusid");
            cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbPersonalStatusStatus.ValueMember = "StatusID";
            cmbPersonalStatusStatus.DisplayMember = "StatusValue";
            cmbPersonalStatusStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(" select  StatusID , StatusValue  from StatusTBL where RefrenceID=2  ");
            cmbPersonalStatusStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbPersonalStatusStatus.AutoCompleteSource = AutoCompleteSource.ListItems;


            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID,COMPName_EN FROM Companies");
            cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
         
            
            cmbcomp.ValueMember = "COMPID";
            cmbcomp.DisplayMember = "COMPName_EN";
            cmbcomp.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID,COMPName_EN FROM Companies");
            cmbcomp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbcomp.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbcandidates2.ValueMember = "EmployeeID";
            cmbcandidates2.DisplayMember = "Name";
            cmbcandidates2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees]       order by EmployeeID");
            cmbcandidates2.Text = "Select";
            cmbcandidates2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbcandidates2.AutoCompleteSource = AutoCompleteSource.ListItems;



            SQLCONN.CloseConnection();
            this.reportViewer2.RefreshReport();
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



                reportViewer1.Visible = true;

                SQLCONN.OpenConection();

                loggedEmployee = CommonClass.EmployeeID;

                SqlParameter paramDateFrom = new SqlParameter("@param1", SqlDbType.Date);
                paramDateFrom.Value = dtpfrom.Value;
                SqlParameter paramDateTo = new SqlParameter("@param2", SqlDbType.Date);
                paramDateTo.Value = dtpto.Value;
                SqlParameter paramVisaStatus = new SqlParameter("@param3", SqlDbType.NVarChar);
                paramVisaStatus.Value = cmbStatus.SelectedValue;
                SqlParameter paramCompany = new SqlParameter("@param4", SqlDbType.NVarChar);
                paramCompany.Value = cmbCompany.SelectedValue;

                 DataTable VisaReport = new DataTable();

                using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
                {
                    connection.Open();
                string query = "SELECT C.COMPName_EN as [CompanyName],  S.Status as [VisaStatus], COUNT(*) AS [TotalVisas] " +
                                "FROM DelmonGroupDB.dbo.VISA V " +
                                "JOIN DelmonGroupDB.dbo.VISAJobList J ON V.VisaNumber = J.VISANumber " +
                                "JOIN DelmonGroupDB.dbo.Companies C ON V.ComapnyID = C.COMPID " +
                                "JOIN DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID " +
                                "WHERE TRY_CONVERT(DATETIME, IssueDateEN, 103) BETWEEN @param1 AND @param2 " +
                                "{0}" + // this is where the optional status or company filter will be added
                                "GROUP BY C.COMPName_EN, S.Status " +
                                "ORDER BY C.COMPName_EN, S.Status";

                // add optional status or company filter based on user's selection
                if (cmbStatus.SelectedIndex != 0 && cmbCompany.SelectedIndex == 0)
                {
                    query = string.Format(query, "AND j.StatusID = @param3 ");
                }
                else if (cmbStatus.SelectedIndex == 0 && cmbCompany.SelectedIndex != 0)
                {
                    query = string.Format(query, "AND v.ComapnyID = @param4 ");
                }
                else if (cmbStatus.SelectedIndex != 0 && cmbCompany.SelectedIndex != 0)
                {
                    query = string.Format(query, "AND j.StatusID = @param3 AND v.ComapnyID = @param4 ");
                }
                else
                {
                    query = string.Format(query, "");
                }
             



                SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@param1", dtpfrom.Value);
                    command.Parameters.AddWithValue("@param2", dtpto.Value);
                    command.Parameters.Add(paramVisaStatus); // add the parameter to the command object
                    command.Parameters.Add(paramCompany); // add the parameter to the command object
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(VisaReport);
                    connection.Close();
                }

                ReportDataSource dataSource = new ReportDataSource("DataSet1", VisaReport);
            reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("param1", dtpfrom.Value.ToString("dd/MM/yyyy")) });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("param2", dtpto.Value.ToString("dd/MM/yyyy")) });
            this.reportViewer1.RefreshReport();
                SQLCONN.CloseConnection();


            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportViewer2.Visible = true;

            SQLCONN.OpenConection();

            loggedEmployee = CommonClass.EmployeeID;

            SqlParameter paramDateFrom = new SqlParameter("@param1", SqlDbType.Date);
            paramDateFrom.Value = FromDate.Value;
            SqlParameter paramDateTo = new SqlParameter("@param2", SqlDbType.Date);
            paramDateTo.Value = todate.Value;
            SqlParameter paramVisaStatus = new SqlParameter("@param3", SqlDbType.NVarChar);
            paramVisaStatus.Value = cmbPersonalStatusStatus.SelectedValue;
            SqlParameter paramCompany = new SqlParameter("@param4", SqlDbType.NVarChar);
            paramCompany.Value = cmbCompany.SelectedValue;

            SqlParameter paramCandidate = new SqlParameter("@param5", SqlDbType.NVarChar);
            paramCandidate.Value = cmbcandidates2.SelectedValue;

            DataTable VisaReport = new DataTable();

            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            {
                connection.Open();
                string query = "SELECT C.COMPName_EN as [CompanyName],  S.Status as [VisaStatus], COUNT(*) AS [TotalVisas] " +
                                "FROM DelmonGroupDB.dbo.VISA V " +
                                "JOIN DelmonGroupDB.dbo.VISAJobList J ON V.VisaNumber = J.VISANumber " +
                                "JOIN DelmonGroupDB.dbo.Companies C ON V.ComapnyID = C.COMPID " +
                                "JOIN DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID " +
                                "WHERE TRY_CONVERT(DATETIME, IssueDateEN, 103) BETWEEN @param1 AND @param2 " +
                                "{0}" + // this is where the optional status or company filter will be added
                                "GROUP BY C.COMPName_EN, S.Status " +
                                "ORDER BY C.COMPName_EN, S.Status";

                // add optional status or company filter based on user's selection
                if (cmbStatus.SelectedIndex != 0 && cmbCompany.SelectedIndex == 0)
                {
                    query = string.Format(query, "AND j.StatusID = @param3 ");
                }
                else if (cmbStatus.SelectedIndex == 0 && cmbCompany.SelectedIndex != 0)
                {
                    query = string.Format(query, "AND v.ComapnyID = @param4 ");
                }
                else if (cmbStatus.SelectedIndex != 0 && cmbCompany.SelectedIndex != 0)
                {
                    query = string.Format(query, "AND j.StatusID = @param3 AND v.ComapnyID = @param4 ");
                }
                else
                {
                    query = string.Format(query, "");
                }




                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@param1", FromDate.Value);
                command.Parameters.AddWithValue("@param2", todate.Value);
                command.Parameters.Add(paramVisaStatus); // add the parameter to the command object
                command.Parameters.Add(paramCompany); // add the parameter to the command object
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(VisaReport);
                connection.Close();
            }

            ReportDataSource dataSource = new ReportDataSource("DataSet1", VisaReport);
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(dataSource);
            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("param1", FromDate.Value.ToString("dd/MM/yyyy")) });
            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("param2", todate.Value.ToString("dd/MM/yyyy")) });
            this.reportViewer2.RefreshReport();
            SQLCONN.CloseConnection();


        }
    }
}
