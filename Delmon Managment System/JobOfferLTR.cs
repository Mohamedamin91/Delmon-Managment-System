using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
    public partial class JobOfferLTR : Form
    {
        int EmpIDRPT;
        SQLCONNECTION sql=new SQLCONNECTION();
        public JobOfferLTR()
        { 
            InitializeComponent();
        }

        private void JobOfferLTR_Load(object sender, EventArgs e)
        {

            EmpIDRPT = CommonClass.EmployeeID;
            DataTable employeeSalaryTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(sql.ConnectionString))
            {
                connection.Open();
                string query = "SELECT  CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName',VISAJobList.FileNumber,DocumentType.Doc_Type,Documents.Number 'Passport' ,SalaryTypes.SalaryTypeName, SalaryDetails.Value, JOBS.JobTitleEN,WorkLocations.Name,cast(Employees.StartDate as Date)'Date',Employees.EmployeeID,Countries.NationalityName, (SELECT CONCAT(FirstName, ' ', LastName)  FROM Employees  WHERE DEPARTMENTS.DeptHeadID = Employees.EmployeeID) AS 'HeadofDeparment' , JOBS.JobDescription 'JobDescription' from DEPARTMENTS, DeptTypes, WorkLocations, JOBS, Employees, VISAJobList, Documents, DocumentType, SalaryDetails, SalaryTypes, Countries, Consulates, Companies where VISAJobList.EmployeeID = Employees.EmployeeID and VISAJobList.ConsulateID = Consulates.ConsulateID and Consulates.CountryId = Countries.CountryId and Employees.EmployeeID = Documents.CR_ID and Documents.DocTypeID = DocumentType.DocType_ID and Documents.RefrenceID = 2 and DocumentType.DocType_ID = 1 and SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and Employees.EmployeeID = SalaryDetails.EmployeeID and SalaryDetails.EmployeeID = Employees.EmployeeID and Employees.JobID = JOBS.JobID and Employees.DeptID = DEPARTMENTS.DEPTID and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and DEPARTMENTS.WorkLoctionID = WorkLocations.WorkID and Employees.COMPID = Companies.COMPID and DEPARTMENTS.COMPID = Companies.COMPID  and Employees.EmployeeID = @EmployeeID "; // your SQL query here
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", EmpIDRPT); // set the employee ID parameter
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(employeeSalaryTable);
                connection.Close();
            }

            ReportDataSource dataSource = new ReportDataSource("DataSet1", employeeSalaryTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dataSource);




            // // TODO: This line of code loads data into the 'Delmon.DataTable1' table. You can move, or remove it, as needed.
            // this.DataTable1TableAdapter.Fill(this.Delmon.DataTable1,EmpIDRPT);
            //// reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

             this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
