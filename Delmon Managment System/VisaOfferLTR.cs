﻿using Microsoft.Reporting.WinForms;
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
    public partial class VisaOfferLTR : Form
    {
        int EmpIDRPT;
        string EmployeeName;
        SQLCONNECTION sql = new SQLCONNECTION();

        bool hasView = false;
      
        public VisaOfferLTR()
        {
            InitializeComponent();
        }

        private void VisaOfferLTR_Load(object sender, EventArgs e)
        {



            sql.OpenConection();

            SqlDataReader dr = sql.DataReader(@"
        SELECT ps.PermissionName
        FROM UserPermissions us
        	JOIN tblUser u ON us.UserID = u.EmployeeID
        JOIN Permissions ps ON us.PermissionID = ps.PermissionID
               WHERE u.EmployeeID = @UserID",
            new SqlParameter("@UserID", SqlDbType.NVarChar) { Value = CommonClass.EmployeeIDRPT });


            while (dr.Read())
            {
                string permissionName = dr["PermissionName"].ToString();
                if (permissionName.Contains("ViewPersonalInformation"))

                {
                    hasView = true;
                }
               
            }
            dr.Close();
            if (hasView == false)
            {

///***/
                //EmpIDRPT = CommonClass.EmployeeID;
                //// TODO: This line of code loads data into the 'Delmon.DataTable1' table. You can move, or remove it, as needed.
                //this.dataTable2TableAdapter.Fill(this.delmon.DataTable2, EmpIDRPT);
                //// reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                //this.reportViewer1.RefreshReport();
                ///****/

                EmpIDRPT = CommonClass.EmployeeIDRPT;
                EmployeeName = CommonClass.LoginEmployeeName;

                SqlParameter paramEmployeeID = new SqlParameter("@EmployeeID", SqlDbType.NVarChar);
                paramEmployeeID.Value = EmpIDRPT;

                DataTable employeeVisaTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(sql.ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
    VISAJobList.FileNumber,
    VISA.IssueDateEN,
    visa.VisaNumber,
    Companies1.COMPName_EN AS ReservedToCompanyName,
    Companies2.COMPName_EN AS VisaCompanyName,
    CONCAT(Employees.FirstName, ' ', Employees.SecondName, ' ', Employees.ThirdName, ' ', Employees.LastName) AS 'FullName',
    Countries.NationalityName,
    JOBS.JobTitleEN,
    Agencies.AgenceName,
    Agencies.LicenseNumber,
    Documents.Number AS 'Passport',
   (
    SELECT TOP 1 CONCAT(DepartmentHead.FirstName, ' ', DepartmentHead.LastName)
    FROM DEPARTMENTS Dept
    JOIN Employees DepartmentHead ON Dept.DeptHeadID = DepartmentHead.EmployeeID
    WHERE Dept.COMPID = Companies1.COMPID
    AND Dept.DEPTID = Employees.DeptID
    ORDER BY Dept.DEPTID
) AS 'DivisionHead',

	( SELECT TOP 1 CONCAT(FirstName, ' ', SecondName, ' ', ThirdName, ' ', LastName)
         FROM Employees  
        JOIN Companies ON Employees.EmployeeID = Companies1.General_Manager
        WHERE DEPARTMENTS.COMPID = Companies1.COMPID
    ) AS 'GeneralManager'
	
    
FROM 
    Employees
    JOIN VISAJobList ON VISAJobList.EmployeeID = Employees.EmployeeID
    JOIN visa ON VISA.VisaNumber = VISAJobList.VISANumber
    JOIN Companies Companies1 ON Companies1.COMPID = VISAJobList.ReservedTo
    JOIN Companies Companies2 ON Companies2.COMPID = VISA.ComapnyID
    JOIN Consulates ON VISAJobList.ConsulateID = Consulates.ConsulateID
    JOIN Documents ON Employees.EmployeeID = Documents.CR_ID
    JOIN DocumentType ON Documents.DocTypeID = DocumentType.DocType_ID AND DocumentType.DocType_ID = 1
    JOIN JOBS ON VISAJobList.JobID = JOBS.JobID
    JOIN DEPARTMENTS ON Employees.DeptID = DEPARTMENTS.DEPTID
    JOIN (SELECT COMPID, General_Manager AS EmployeeID FROM Companies) DepartmentGM ON DepartmentGM.COMPID = DEPARTMENTS.COMPID
    JOIN DeptTypes ON DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID
    JOIN WorkLocations ON DEPARTMENTS.WorkLoctionID = WorkLocations.WorkID
    JOIN Countries ON Employees.NationalityID = Countries.CountryId
    JOIN Agencies ON VISAJobList.AgencyID = Agencies.AgencID
WHERE 
  Employees.EmployeeID = @EmployeeID;";




                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeID", EmpIDRPT); // set the employee ID parameter
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(employeeVisaTable);
                    connection.Close();
                }

                ReportDataSource dataSource = new ReportDataSource("DataSet3", employeeVisaTable);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(dataSource);
                this.reportViewer1.RefreshReport();









                sql.CloseConnection();



            }
        }

    }
}
