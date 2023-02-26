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
            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID,COMPName_EN FROM Companies");
            cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;


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
            string query = "  SELECT C.COMPName_EN as [Company Name],  S.Status as [Visa Status],    COUNT(*) AS [Total Visas] FROM  DelmonGroupDB.dbo.VISA V JOIN DelmonGroupDB.dbo.VISAJobList J ON V.VisaNumber = J.VISANumber  JOIN DelmonGroupDB.dbo.Companies C ON V.ComapnyID = C.COMPID   JOIN DelmonGroupDB.dbo.VisaStatus S ON J.StatusID = S.StatusID WHERE TRY_CONVERT(DATETIME, IssueDateEN, 103) BETWEEN @param1 AND @param2 and j.StatusID = @param3  and v.ComapnyID = @param4 GROUP BY  C.COMPName_EN, S.Status ORDER BY   C.COMPName_EN, S.Status;";

            SQLCONN.OpenConection();
            loggedEmployee = CommonClass.EmployeeID;

            SqlParameter paramDateFrom = new SqlParameter("@Param1", SqlDbType.NVarChar);
            paramDateFrom.Value = dtpfrom.Value;
            SqlParameter paramDateTo = new SqlParameter("@Param2", SqlDbType.NVarChar);
            paramDateTo.Value = dtpto.Value;
            SqlParameter paramVisaStatus = new SqlParameter("@Param3", SqlDbType.NVarChar);
            paramVisaStatus.Value = cmbStatus.SelectedValue;
            SqlParameter paramCompany = new SqlParameter("@Param4", SqlDbType.NVarChar);
            paramCompany.Value = cmbCompany.SelectedValue;

            DataTable employeeSalaryTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(SQLCONN.ConnectionString))
            {
                connection.Open();
              
                SqlDataReader dr = SQLCONN.DataReader(query, paramEmployeeID);
                if (dr.Read())
                {
                    //  EmployeeID = int.Parse(dr["ID"].ToString());
                    EmployeeName = (dr["FullName"].ToString());
                }



                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", EmpIDRPT); // set the employee ID parameter
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(employeeSalaryTable);
                connection.Close();
            }

            ReportDataSource dataSource = new ReportDataSource("DataSet1", employeeSalaryTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);





            this.reportViewer1.RefreshReport();
            SQLCONN.CloseConnection();


        }
    }
}
