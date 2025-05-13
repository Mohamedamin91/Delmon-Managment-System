using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class FrmJobsNew : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();

        public FrmJobsNew()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmJobsNew_Load(object sender, EventArgs e)
        {
            //SQLCONN.OpenConection();


            ////cmbworkfield.ValueMember = "Work_Field_ID";
            ////cmbworkfield.DisplayMember = "Work_Field_Name";
            ////cmbworkfield.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Work_Field_ID,Work_Field_Name FROM WorkFields");


            ////cmbjobgrade.ValueMember = "Job_Grade_ID";
            ////cmbjobgrade.DisplayMember = "Job_Grade_Name";
            ////cmbjobgrade.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT Job_Grade_ID,Job_Grade_Name FROM JobGrades");

            //SQLCONN.CloseConnection();

        }

        private void JobTitleENtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                jobtitleartxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                JobTitleENtxt.Text = textInfo.ToTitleCase(JobTitleENtxt.Text);
            }
        }

        private void jobtitleartxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Descriptiontxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                jobtitleartxt.Text = textInfo.ToTitleCase(jobtitleartxt.Text);
            }
        }

        private void Descriptiontxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  cmbworkfield.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                Descriptiontxt.Text = textInfo.ToTitleCase(Descriptiontxt.Text);
            }
        }

        private void cmbworkfield_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  cmbjobgrade.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
              //  cmbworkfield.Text = textInfo.ToTitleCase(cmbworkfield.Text);
            }
        }

        private void cmbjobgrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mintxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                //cmbjobgrade.Text = textInfo.ToTitleCase(cmbjobgrade.Text);
            }
        }

        private void mintxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                maxtxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                mintxt.Text = textInfo.ToTitleCase(mintxt.Text);
            }
        }
        public void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
        //    cmbjobgrade.SelectedIndex = cmbworkfield.SelectedIndex = -1;
            jobtitleartxt.Text = JobTitleENtxt.Text = Descriptiontxt.Text = mintxt.Text = maxtxt.Text = "";
        }

        private void addbtn_Click(object sender, EventArgs e)
        {

            if (JobTitleENtxt.Text == "")
            {
                MessageBox.Show("Please insert 'JobTitleEN' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (jobtitleartxt.Text == "")
            {
                MessageBox.Show("Please insert 'JobTitleAR' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Descriptiontxt.Text == "")
            {
                MessageBox.Show("Please insert 'Description' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (mintxt.Text == "")
            {
                MessageBox.Show("Please insert 'Min Salary' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (maxtxt.Text == "")
            {
                MessageBox.Show("Please insert 'Max Salary' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SqlParameter paramjobtitleEN = new SqlParameter("@C1", SqlDbType.NVarChar);
                paramjobtitleEN.Value = JobTitleENtxt.Text;
                SqlParameter paramjobtitleAR = new SqlParameter("@C2", SqlDbType.NVarChar);
                paramjobtitleAR.Value = jobtitleartxt.Text;
                SqlParameter ParamDescription = new SqlParameter("@C3", SqlDbType.NVarChar);
                ParamDescription.Value = Descriptiontxt.Text;

                SqlParameter paramminsalary = new SqlParameter("@C6", SqlDbType.NVarChar);
                paramminsalary.Value = mintxt.Text;
                SqlParameter parammaxsalary = new SqlParameter("@C7", SqlDbType.NVarChar);
                parammaxsalary.Value = maxtxt.Text;



                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  * from jobs where " +
                     " JobTitleEN=  @C1 and    JobTitleAR =  @C2 ", paramjobtitleEN, paramjobtitleAR);
                dr.Read();

                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Job'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    dr.Dispose();
                    dr.Close();
                    SQLCONN.ExecuteQueries("insert into jobs (  [JobTitleEN] ,[JobTitleAR],[JobDescription],[MinSalary],[MaxSalary]) values (@C1,@C2,@C3,@C6,@C7)",
                                                   paramjobtitleEN, paramjobtitleAR, ParamDescription, paramminsalary, parammaxsalary);
                    MessageBox.Show("Record saved Successfully");
                    //dr = SQLCONN.DataReader("SELECT PI_ID FROM PersonalInformation WHERE PI_ID = (SELECT MAX(PI_ID) FROM PersonalInformation)");
                    //dr.Read();
                    //PI_ID = int.Parse(dr["PI_ID"].ToString());
                    dr.Dispose();
                    dr.Close();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Please Fill the missing fields  ");

                }
                SQLCONN.CloseConnection();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


