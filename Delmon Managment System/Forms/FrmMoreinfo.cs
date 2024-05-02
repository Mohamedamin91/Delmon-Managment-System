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
    public partial class FrmMoreinfo : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        SqlDataReader dr;

        public FrmMoreinfo()
        {
            InitializeComponent();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMoreinfo_Load(object sender, EventArgs e)
        {
            SqlParameter paramEnduserID= new SqlParameter("@C0", SqlDbType.NVarChar);
            paramEnduserID.Value = CommonClass.EndUserID;
            try
            {
                SQLCONN.OpenConection();
                dr = SQLCONN.DataReader(@"
SELECT Companies.COMPName_EN,
       DeptTypes.Dept_Type_Name,
       MAX(CASE WHEN ContactTypes.ContTypeID = 1 THEN Contacts.ContValue END) AS Phone,
       MAX(CASE WHEN ContactTypes.ContTypeID = 2 THEN Contacts.ContValue END) AS Email
FROM Employees
JOIN Companies ON Employees.COMPID = Companies.COMPID
JOIN DEPARTMENTS ON Employees.DeptID = DEPARTMENTS.DEPTID
JOIN DeptTypes ON DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID
JOIN Contacts ON Employees.EmployeeID = Contacts.CR_ID
JOIN ContactTypes ON Contacts.ContTypeID = ContactTypes.ContTypeID
WHERE Contacts.RefrenceID = 2
  AND Employees.EmployeeID = @C0
GROUP BY Companies.COMPName_EN, DeptTypes.Dept_Type_Name;", paramEnduserID);
                if (dr.HasRows)
                {
                    lblEmployeeID.Text = CommonClass.EndUserID.ToString();
                    dr.Read();
                   
                    if (dr["COMPName_EN"] == DBNull.Value)
                    {
                        lblCompany.Text = "There is no company for this Enduser";
                    }
                    else
                    {
                        lblCompany.Text = dr["COMPName_EN"].ToString();
                    }
                    if (dr["Dept_Type_Name"] == DBNull.Value)
                    {
                        lbldepartment.Text = "There is no department for this Enduser";

                    }
                    else {

                        lbldepartment.Text = dr["Dept_Type_Name"].ToString();
                    }

                    if (dr["Phone"] == DBNull.Value)
                    {
                        lblphone.Text = "There is no Phone for this Enduser !";

                    }
                    else
                    {

                        lblphone.Text = dr["Phone"].ToString();
                    }

                    if (dr["Email"] == DBNull.Value)
                    {
                        lblemail.Text = "There is no Email for this Enduser !";

                    }
                    else
                    {

                        lblemail.Text = dr["Email"].ToString();
                    }

                    
                 
                }
                else 
                {
                
                
                }
                SQLCONN.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
       

        }

        private void piccompany_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblCompany.Text);
            //txtcomp.Visible = true;
            //txtdept.Visible = false;
            //txtphone.Visible = false;
            txtemail.Visible = false;
           // txtcomp.Text = "Copied !";
           

        }

        private void picdept_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lbldepartment.Text);
         //   txtcomp.Visible = false;
         //   txtdept.Visible = true;
            txtphone.Visible = false;
            txtemail.Visible = false;
          //  txtdept.Text = "Copied !";
        }

        private void picemail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblemail.Text);
            //txtcomp.Visible = false;
            //txtdept.Visible = false;
            txtphone.Visible = false;
            txtemail.Visible = true;
            txtemail.Text = "Copied !";
        }

        private void picphone_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblphone.Text);
            //txtcomp.Visible = false;
            //txtdept.Visible = false;
            txtphone.Visible = true;
            txtemail.Visible = false; txtphone.Text = "Copied !";
        }
    }
}
