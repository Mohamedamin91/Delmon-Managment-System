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
    public partial class EmployeeForm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int EMPID = 0;
       

        public EmployeeForm()
        {
     
            InitializeComponent();
            cmbCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCountry.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbJob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbJob.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbReportto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbReportto.AutoCompleteSource = AutoCompleteSource.ListItems;


        }




        private void EmployeeForm_Load(object sender, EventArgs e)
        {
          




            SQLCONN.OpenConection();


            cmbReportto.ValueMember = "empid";
            cmbReportto.DisplayMember = "EmpName";
            cmbReportto.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT empid,EmpName FROM PersonalInformation");
          
            cmbJob.ValueMember = "JobID";
            cmbJob.DisplayMember = "JobTitleEN";
            cmbJob.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT JobID,JobTitleEN FROM JOBS ");

            cmbReferredBy.ValueMember = "empid";
            cmbReferredBy.DisplayMember = "EmpName";
            cmbReferredBy.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT empid,EmpName FROM PersonalInformation ");

            cmbStatus.ValueMember = "statusid";
            cmbStatus.DisplayMember = "status";
            cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select statusid,status from visastatus where RefrenceID=2  ");
           

            cmbCountry.ValueMember = "CountryId";
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select CountryId,CountryName from Countries ");
       


            SQLCONN.CloseConnection();

        }

        private void Employeetxt_TextChanged(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from PersonalInformation where empname LIKE '" + Employeetxt.Text + "%'");
            SQLCONN.CloseConnection();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        //   MessageBox.Show("ogg");       
                    }
                    else
                    {

                        EMPID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        Employeetxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbJob.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        //txt_Name1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //txt_Name1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //txt_Name1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //txt_Name1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                }
            }

        }
       

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramempname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramempname.Value = Employeetxt.Text;
            SqlParameter paramjoiningdate = new SqlParameter("@C2", SqlDbType.Date);
            paramjoiningdate.Value = JoinigDatePicker.Value;
            SqlParameter Paramjob  = new SqlParameter("@C3", SqlDbType.NVarChar);
            Paramjob.Value = cmbJob.SelectedText;
            SqlParameter paramDepartment = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramDepartment.Value = cmbDepartment.SelectedValue;
            SqlParameter paramReportto = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramReportto.Value = cmbReportto.SelectedValue;
            SqlParameter paramstatusID = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramstatusID.Value = cmbStatus.SelectedValue;
            SqlParameter ParamBOD = new SqlParameter("@C7", SqlDbType.Date);
            ParamBOD.Value = BODPicker.Value;
            SqlParameter paramReferredby = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramReferredby.Value = cmbReferredBy.SelectedValue;
            SqlParameter paramEXYears= new SqlParameter("@C9", SqlDbType.NVarChar);
            paramEXYears.Value = ExperinceYearstxt.Text;
            SqlParameter paramCountry = new SqlParameter("@C10", SqlDbType.NVarChar);
            paramCountry.Value = cmbCountry.SelectedValue;
            SqlParameter paramRemarks = new SqlParameter("@C12", SqlDbType.NVarChar);
            paramRemarks.Value = RemarksTxt.Text;

            SqlParameter paramEMPID = new SqlParameter("@id", SqlDbType.Int);
            paramEMPID.Value = EMPID;




            if (Employeetxt.Text != "")
            {
               
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("update Employee set EmpName=@C1,JoiningDate=@C2,jobid=@C3,DEPTID=@C4,reportto=@C5," +
                        "statusid=@C6,bod=@C7,ReferredBy=@C8,ExperinceYears=@C9,CountryID=@C10,Remarks=@C11 where empid=@id",
                                                   paramempname, paramjoiningdate,Paramjob,paramDepartment,paramReportto,paramstatusID,ParamBOD,paramReferredby,
                                                paramEXYears,paramCountry, paramRemarks);
                                    MessageBox.Show("Record Updated Successfully");
                     dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Employee where empname = '" + Employeetxt.Text + "'");
                    SQLCONN.CloseConnection();


                }
                else
                {
                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            SqlParameter paramEMPID = new SqlParameter("@id", SqlDbType.Int);
            paramEMPID.Value = EMPID;




            if (Employeetxt.Text != "")
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from Employee where empid=@id");
                    MessageBox.Show("Record Deleted Successfully");
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Employee ");
                    SQLCONN.CloseConnection();


                }
                else
                {
                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramempname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramempname.Value = Employeetxt.Text;
            SqlParameter paramjoiningdate = new SqlParameter("@C2", SqlDbType.Date);
            paramjoiningdate.Value = JoinigDatePicker.Value;
            SqlParameter Paramjob = new SqlParameter("@C3", SqlDbType.NVarChar);
            Paramjob.Value = cmbJob.SelectedText;
            SqlParameter paramDepartment = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramDepartment.Value = cmbDepartment.SelectedValue;
            SqlParameter paramReportto = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramReportto.Value = cmbReportto.SelectedValue;
            SqlParameter paramstatusID = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramstatusID.Value = cmbStatus.SelectedValue;
            SqlParameter ParamBOD = new SqlParameter("@C7", SqlDbType.Date);
            ParamBOD.Value = BODPicker.Value;
            SqlParameter paramReferredby = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramReferredby.Value = cmbReferredBy.SelectedValue;
            SqlParameter paramEXYears = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramEXYears.Value = ExperinceYearstxt.Text;
            SqlParameter paramCountry = new SqlParameter("@C10", SqlDbType.NVarChar);
            paramCountry.Value = cmbCountry.SelectedValue;
            SqlParameter paramRemarks = new SqlParameter("@C12", SqlDbType.NVarChar);
            paramRemarks.Value = RemarksTxt.Text;

            SqlParameter paramEMPID = new SqlParameter("@id", SqlDbType.Int);
            paramEMPID.Value = EMPID;




            if (Employeetxt.Text != "")
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("insert into Employee ( EmpName,JoiningDate,jobid,DEPTID,reportto," +
                        "statusid,bod,ReferredBy,ExperinceYears,CountryID,Remarks) values (@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8,@C9,@C10,@C11)",
                                                   paramempname, paramjoiningdate, Paramjob, paramDepartment, paramReportto, paramstatusID, ParamBOD, paramReferredby,
                                                paramEXYears, paramCountry, paramRemarks);
                    MessageBox.Show("Record saved Successfully");
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Employee ");
                    SQLCONN.CloseConnection();


                }
                else
                {
                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }
    }
}
