using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
    public partial class JobOfferLTR : Form
    {
        int EmpIDRPT;
        string EmployeeName;
        SQLCONNECTION sql=new SQLCONNECTION();
        public JobOfferLTR()
        { 
            InitializeComponent();
        }

        private void JobOfferLTR_Load(object sender, EventArgs e)
        {
            sql.OpenConection();
            EmpIDRPT = CommonClass.EmployeeID;

            SqlParameter paramEmployeeID = new SqlParameter("@EmployeeID", SqlDbType.NVarChar);
            paramEmployeeID.Value = EmpIDRPT;

            DataTable employeeSalaryTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(sql.ConnectionString))
            {
                connection.Open();
                string query = "SELECT  CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName',VISAJobList.FileNumber,DocumentType.Doc_Type,Documents.Number 'Passport' ,SalaryTypes.SalaryTypeName, SalaryDetails.Value, JOBS.JobTitleEN,WorkLocations.Name,cast(Employees.StartDate as Date)'Date',Employees.EmployeeID,Countries.NationalityName, (SELECT CONCAT(FirstName, ' ', LastName)  FROM Employees  WHERE DEPARTMENTS.DeptHeadID = Employees.EmployeeID) AS 'HeadofDeparment' , JOBS.JobDescription 'JobDescription' from DEPARTMENTS, DeptTypes, WorkLocations, JOBS, Employees, VISAJobList, Documents, DocumentType, SalaryDetails, SalaryTypes, Countries, Consulates, Companies where VISAJobList.EmployeeID = Employees.EmployeeID and VISAJobList.ConsulateID = Consulates.ConsulateID and Consulates.CountryId = Countries.CountryId and Employees.EmployeeID = Documents.CR_ID and Documents.DocTypeID = DocumentType.DocType_ID and Documents.RefrenceID = 2 and DocumentType.DocType_ID = 1 and SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and Employees.EmployeeID = SalaryDetails.EmployeeID and SalaryDetails.EmployeeID = Employees.EmployeeID and Employees.JobID = JOBS.JobID and Employees.DeptID = DEPARTMENTS.DEPTID and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and DEPARTMENTS.WorkLoctionID = WorkLocations.WorkID and Employees.COMPID = Companies.COMPID and DEPARTMENTS.COMPID = Companies.COMPID  and Employees.EmployeeID = @EmployeeID "; // your SQL query here

                SqlDataReader dr = sql.DataReader("   SELECT  CONCAT(FirstName , ' ', SecondName, ' ' ,ThirdName , ' ', LastName)  'FullName',VISAJobList.FileNumber,DocumentType.Doc_Type,Documents.Number 'Passport' ,SalaryTypes.SalaryTypeName, SalaryDetails.Value, JOBS.JobTitleEN,WorkLocations.Name,cast(Employees.StartDate as Date)'Date',Employees.EmployeeID,Countries.NationalityName, (SELECT CONCAT(FirstName, ' ', LastName)  FROM Employees  WHERE DEPARTMENTS.DeptHeadID = Employees.EmployeeID) AS 'HeadofDeparment' , JOBS.JobDescription 'JobDescription' from DEPARTMENTS, DeptTypes, WorkLocations, JOBS, Employees, VISAJobList, Documents, DocumentType, SalaryDetails, SalaryTypes, Countries, Consulates, Companies where VISAJobList.EmployeeID = Employees.EmployeeID and VISAJobList.ConsulateID = Consulates.ConsulateID and Consulates.CountryId = Countries.CountryId and Employees.EmployeeID = Documents.CR_ID and Documents.DocTypeID = DocumentType.DocType_ID and Documents.RefrenceID = 2 and DocumentType.DocType_ID = 1 and SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID and Employees.EmployeeID = SalaryDetails.EmployeeID and SalaryDetails.EmployeeID = Employees.EmployeeID and Employees.JobID = JOBS.JobID and Employees.DeptID = DEPARTMENTS.DEPTID and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and DEPARTMENTS.WorkLoctionID = WorkLocations.WorkID and Employees.COMPID = Companies.COMPID and DEPARTMENTS.COMPID = Companies.COMPID  and Employees.EmployeeID = @EmployeeID  ", paramEmployeeID);
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
            sql.CloseConnection();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mimeType;
            string encoding;
            string filenameExtension;
            string[] streamIds;
            Warning[] warnings;

            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamIds, out warnings);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("dgsqlserver@delmon-its.com.sa");
            mail.To.Add("Saleem@delmon.com.sa");
            mail.Subject = "Job Offer PDF";
            mail.Body = "Kindlly Check The Attached Job Offer for the Employee : " + EmployeeName;

            // Attach the PDF file
            MemoryStream stream = new MemoryStream(bytes);
            Attachment attachment = new Attachment(stream, "JobOffer.pdf");
            mail.Attachments.Add(attachment);

            SmtpClient client = new SmtpClient();
            client.Host = "mail.delmon-its.com.sa"; // Replace with your SMTP server address
            client.Port = 587; // Replace with your SMTP server port number
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("dgsqlserver@delmon-its.com.sa", "PAbx9DeBn8");
            client.EnableSsl = true;

            // Send the email
            client.Send(mail);
            MessageBox.Show("Your Mail Hase been sent succesfully ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);




            //try
            //{

            //    MailMessage msg = new MailMessage();
            //    msg.From = new MailAddress("dgsqlserver@delmon-its.com.sa");
            //    msg.To.Add("m.amin@delmon.com.sa");
            //    msg.Subject = "Test";
            //    msg.Body = "Hello";

            //    SmtpClient smt = new SmtpClient();
            //    smt.Host = "mail.delmon-its.com.sa";
            //    System.Net.NetworkCredential ntcd = new NetworkCredential();
            //    ntcd.UserName = "dgsqlserver@delmon-its.com.sa";
            //    ntcd.Password = "PAbx9DeBn8";
            //    smt.Credentials = ntcd;
            //    smt.EnableSsl = false;
            //    smt.Port = 587;
            //    smt.Send(msg);

            //    MessageBox.Show("Your Mail was sended");

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
