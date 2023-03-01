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
            EmployeeName = CommonClass.LoginEmployeeName;

            SqlParameter paramEmployeeID = new SqlParameter("@EmployeeID", SqlDbType.NVarChar);
            paramEmployeeID.Value = EmpIDRPT;

            DataTable employeeSalaryTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(sql.ConnectionString))
            {
                connection.Open();
                string query = @"SELECT CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName) AS 'FullName',
       VISAJobList.FileNumber,
       DocumentType.Doc_Type,
       Documents.Number AS 'Passport',
       SalaryTypes.SalaryTypeName,
       SalaryDetails.Value,
       JOBS.JobTitleEN,
       WorkLocations.Name,
       CAST(Employees.StartDate AS Date) AS 'Date',
       Employees.EmployeeID,
       Countries.NationalityName,
       (SELECT CONCAT(FirstName, ' ', LastName) FROM Employees WHERE DEPARTMENTS.DeptHeadID = Employees.EmployeeID) AS 'HeadofDeparment',
       JOBS.JobDescription AS 'JobDescription'
FROM Employees
LEFT JOIN VISAJobList ON VISAJobList.EmployeeID = Employees.EmployeeID
LEFT JOIN Consulates ON VISAJobList.ConsulateID = Consulates.ConsulateID
LEFT JOIN Countries ON Consulates.CountryId = Countries.CountryId
LEFT JOIN Documents ON Employees.EmployeeID = Documents.CR_ID AND Documents.DocTypeID = 1 AND Documents.RefrenceID = 2
LEFT JOIN DocumentType ON Documents.DocTypeID = DocumentType.DocType_ID
LEFT JOIN SalaryDetails ON Employees.EmployeeID = SalaryDetails.EmployeeID
LEFT JOIN SalaryTypes ON SalaryDetails.SalaryTypeID = SalaryTypes.SalaryTypeID
LEFT JOIN JOBS ON Employees.JobID = JOBS.JobID
LEFT JOIN DEPARTMENTS ON Employees.DeptID = DEPARTMENTS.DEPTID
LEFT JOIN DeptTypes ON DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID
LEFT JOIN WorkLocations ON DEPARTMENTS.WorkLoctionID = WorkLocations.WorkID
LEFT JOIN Companies ON Employees.COMPID = Companies.COMPID AND DEPARTMENTS.COMPID = Companies.COMPID
WHERE Employees.EmployeeID = @EmployeeID
GROUP BY CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName),
         VISAJobList.FileNumber,
         DocumentType.Doc_Type,
         Documents.Number,
         SalaryTypes.SalaryTypeName,
         SalaryDetails.Value,
         JOBS.JobTitleEN,
         WorkLocations.Name,
         CAST(Employees.StartDate AS Date),
         Employees.EmployeeID,
         Countries.NationalityName,
		 DEPARTMENTS.DeptHeadID,
         JOBS.JobDescription;";
                SqlDataReader dr = sql.DataReader(query, paramEmployeeID);
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

           
            // Attach the PDF file
            MemoryStream stream = new MemoryStream(bytes);
            Attachment attachment = new Attachment(stream, "JobOffer.pdf");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("recruiting@delmon.sa");
            mail.To.Add("saleem@delmon.com.sa");
            mail.Subject = "Job Offer ";
            mail.Body = "Dear sir,\nKindly Check The Attached Job Offer for the Employee : " + EmployeeName.ToUpper() + "\nThis Email has been sent to you by: "  + EmployeeName  ;
   
               mail.Attachments.Add(attachment);

            // Attach the PDF file

            SmtpClient client = new SmtpClient();
            client.Host = "mail.delmon.sa"; // Replace with your SMTP server address
            client.Port = 587; // Replace with your SMTP server port number
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("recruiting@delmon.sa", "s6#0pf85L");
            client.EnableSsl = false;

            // Send the email
            client.Send(mail);
            MessageBox.Show("Your Mail Has been sent successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
