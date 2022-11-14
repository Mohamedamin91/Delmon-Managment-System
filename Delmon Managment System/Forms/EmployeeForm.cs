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
using System.Text.RegularExpressions;


namespace Delmon_Managment_System.Forms
{
    public partial class EmployeeForm : Form
    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        OpenFileDialog opf = new OpenFileDialog();
        int EMPID = 0;
        int PI_ID = 0;
        static Regex validate_emailaddress = email_validation();



        public EmployeeForm()
        {

            InitializeComponent();
            //cmbCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbCountry.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbJob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbJob.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbReportto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbReportto.AutoCompleteSource = AutoCompleteSource.ListItems;


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

            func(Controls);
            cmbGender.Text = cmbMartialStatus.Text = "";
        //    dataGridView1.DataSource = null;



        }
        public static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }



        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = firstnametxt;

            AddBtn.Visible = DeleteBTN.Visible = Updatebtn.Visible = false;
            btnNew.Visible = true;



            SQLCONN.OpenConection();


            cmbDocuments.ValueMember = "DocType_ID";
            cmbDocuments.DisplayMember = "Doc_Type";
            cmbDocuments.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT DocType_ID,Doc_Type FROM DocumentType");

            cmbcontact.ValueMember = "ContTypeID";
            cmbcontact.DisplayMember = "ContType";
            cmbcontact.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT ContTypeID ,ContType FROM ContactTypes ");

            //cmbReferredBy.ValueMember = "empid";
            //cmbReferredBy.DisplayMember = "EmpName";
            //cmbReferredBy.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT empid,EmpName FROM PersonalInformation ");

            //cmbStatus.ValueMember = "statusid";
            //cmbStatus.DisplayMember = "status";
            //cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select statusid,status from visastatus where RefrenceID=2  ");


            //cmbCountry.ValueMember = "CountryId";
            //cmbCountry.DisplayMember = "CountryName";
            //cmbCountry.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select CountryId,CountryName from Countries ");

            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from PersonalInformation order by PI_ID desc ");


            SQLCONN.CloseConnection();

        }

        private void Employeetxt_TextChanged(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from PersonalInformation where firstname LIKE '" + Employeetxt.Text + "%' or  secondname LIKE '" + Employeetxt.Text + "%' or thirdname LIKE '" + Employeetxt.Text + "%' or lastname LIKE '" + Employeetxt.Text + "%'");
            SQLCONN.CloseConnection();
            tabControl1.Enabled = true;
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

                        EMPID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        lastnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        cmbGender.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                        //PI_ID = EMPID;
                        //dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CandidateID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] ,[PI_ID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and PI_ID =  " + PI_ID + " ");
                        //dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[P_Id] ,[name],[documentValue] ,[url] ,[last_update] ,[DocumentType].Doc_Type ,[RefrenceID]FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and P_Id =  " + PI_ID + " ");
                        AddBtn.Visible = false;
                        btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
                    }
                }
            }

        }


        private void Updatebtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramfirstname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramfirstname.Value = firstnametxt.Text;
            SqlParameter paramsecondname = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramsecondname.Value = secondnametxt.Text;
            SqlParameter Paramthirdname = new SqlParameter("@C3", SqlDbType.NVarChar);
            Paramthirdname.Value = thirdnametxt.Text;
            SqlParameter paramlastname = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramlastname.Value = lastnametxt.Text;
            SqlParameter paramGender = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramGender.Value = cmbGender.SelectedItem;
            SqlParameter paramMartialStatus = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramMartialStatus.Value = cmbMartialStatus.SelectedItem;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.Int);
            paramPID.Value = EMPID;




            if (EMPID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("update PersonalInformation set firstname=@C1,secondname=@C2,thirdname=@C3,lastname=@C4,gender=@C5," +
                        "MartialStatus=@C6 where PI_ID=@id",
                                                   paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus, paramPID);
                    MessageBox.Show("Record Updated Successfully");
                    tabControl1.Enabled = true;
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from PersonalInformation where PI_ID = '" + EMPID + "'");
                    SQLCONN.CloseConnection();


                }
                else
                {
                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
                tabControl1.Enabled = false;
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.Int);
            paramPID.Value = EMPID;



            if (EMPID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from PersonalInformation where PI_ID=@id", paramPID);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([PI_ID]) from[PersonalInformation] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[PersonalInformation]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");
                    SQLCONN.CloseConnection();
                    ClearTextBoxes();
                    dataGridView1.DataSource = null;



                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramfirstname = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramfirstname.Value = firstnametxt.Text;
            SqlParameter paramsecondname = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramsecondname.Value = secondnametxt.Text;
            SqlParameter Paramthirdname = new SqlParameter("@C3", SqlDbType.NVarChar);
            Paramthirdname.Value = thirdnametxt.Text;
            SqlParameter paramlastname = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramlastname.Value = lastnametxt.Text;
            SqlParameter paramGender = new SqlParameter("@C5", SqlDbType.NVarChar);
            paramGender.Value = cmbGender.SelectedItem;
            SqlParameter paramMartialStatus = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramMartialStatus.Value = cmbMartialStatus.SelectedItem;


            SqlParameter paramPID = new SqlParameter("@id", SqlDbType.Int);
            paramPID.Value = EMPID;




            if (firstnametxt.Text != "" && lastnametxt.Text != "" && thirdnametxt.Text != "" && lastnametxt.Text != "")
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  * from PersonalInformation where " +
                     " firstname=  @C1 and    SecondName =  @C2 and thirdname = @C3  and lastname = @C4", paramfirstname, paramsecondname, Paramthirdname, paramlastname);
                dr.Read();


                if (dr.HasRows)
                {
                    MessageBox.Show("This 'Name'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                else if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    dr.Dispose();
                    dr.Close();
                    SQLCONN.ExecuteQueries("insert into PersonalInformation ( firstname,secondname,thirdname,lastname,Gender," +
                        "MartialStatus) values (@C1,@C2,@C3,@C4,@C5,@C6)",
                                                   paramfirstname, paramsecondname, Paramthirdname, paramlastname, paramGender, paramMartialStatus);
                    MessageBox.Show("Record saved Successfully");
                    dr = SQLCONN.DataReader("SELECT PI_ID FROM PersonalInformation WHERE PI_ID = (SELECT MAX(PI_ID) FROM PersonalInformation)");
                    dr.Read();
                    PI_ID = int.Parse(dr["PI_ID"].ToString());
                    dr.Dispose();
                    dr.Close();
                    tabControl1.Enabled = true;
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from PersonalInformation order by pi_id ");
                //    ClearTextBoxes();

                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Fill the missing fields  ");
                tabControl1.Enabled = false;
            }
            SQLCONN.CloseConnection();
        }

        private void furstnametxt_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                secondnametxt.Focus();
                e.Handled = true;
            }
        }

        private void secondnametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thirdnametxt.Focus();
                e.Handled = true;
            }
        }

        private void EmployeeForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void thirdnametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lastnametxt.Focus();
                e.Handled = true;
            }

        }

        private void lastnametxt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbMartialStatus.Focus();
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void lastnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstnametxt_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                secondnametxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                firstnametxt.Text = textInfo.ToTitleCase(firstnametxt.Text);
            }
        }

        private void secondnametxt_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                thirdnametxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                secondnametxt.Text = textInfo.ToTitleCase(secondnametxt.Text);
            }
        }

        private void thirdnametxt_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                lastnametxt.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                thirdnametxt.Text = textInfo.ToTitleCase(thirdnametxt.Text);
            }
        }

        private void lastnametxt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                cmbGender.Focus();
                e.Handled = true;
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                lastnametxt.Text = textInfo.ToTitleCase(lastnametxt.Text);
            }
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
        }

        private void UplodeBTN_Click(object sender, EventArgs e)
        {
            string filename = System.IO.Path.GetFileName(opf.FileName);
            string nameOFfile = opf.SafeFileName;


            SqlParameter paramfilename = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramfilename.Value = "\\Document\\" + filename;
            SqlParameter paramnameOFfile = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramnameOFfile.Value = nameOFfile;
            SqlParameter paramPID = new SqlParameter("@C2", SqlDbType.Int);
            paramPID.Value = PI_ID;
            SqlParameter paramDocType = new SqlParameter("@C3", SqlDbType.Int);
            paramDocType.Value = cmbDocuments.SelectedValue;
            SqlParameter paramRefrenceID = new SqlParameter("@C4", SqlDbType.Int);
            paramRefrenceID.Value = 2;


            try
            {

                if (filename == null)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        //we already define our connection globaly. We are just calling the object of connection.
                        SQLCONN.OpenConection();
                        SQLCONN.ExecuteQueries("insert into Documents (documentValue,name,P_Id,DocTypeID,RefrenceID)values(@C0,@C1,@C2,@C3,@C4)", paramfilename, paramnameOFfile, paramPID, paramDocType, paramRefrenceID);
                        string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        System.IO.File.Copy(opf.FileName, path + "\\Document\\" + filename);
                        dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from Documents where P_Id =  " + PI_ID + " ");
                        SQLCONN.CloseConnection();
                        MessageBox.Show("Document Saved.");
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabDoc_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {




            //To where your opendialog box get starting location. My initial directory location is desktop.
            opf.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            opf.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            opf.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            opf.FilterIndex = 1;
            try
            {
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (opf.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(opf.FileName);
                        Doctxt.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnaddcontact_Click(object sender, EventArgs e)
        {
            SqlParameter paramContactType = new SqlParameter("@C1", SqlDbType.Int);
            paramContactType.Value = cmbcontact.SelectedValue;
            SqlParameter paramContact = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramContact.Value = Contacttxt.Text;
            SqlParameter paramRefrenceID = new SqlParameter("@C3", SqlDbType.Int);
            paramRefrenceID.Value = 2;
            SqlParameter paramPID = new SqlParameter("@C4", SqlDbType.Int);
            paramPID.Value = PI_ID;


            if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {

                SQLCONN.OpenConection();
                if ((int)cmbcontact.SelectedValue == 2)
                {
                    if (validate_emailaddress.IsMatch(Contacttxt.Text) != true)
                    {
                        MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Contacttxt.Focus();
                        return;
                    }
                    else
                    {
                    }
                }
                SQLCONN.ExecuteQueries("insert into Contacts ( ContTypeID,ContValue,RefrenceID,PI_ID) values (@C1,@C2,@C3,@C4)",
                                               paramContactType, paramContact, paramRefrenceID, paramPID);
                MessageBox.Show("Record saved Successfully");

                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CandidateID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] ,[PI_ID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and PI_ID =  " + PI_ID + " ");
               // ClearTextBoxes();
                SQLCONN.CloseConnection();

            }
            else
            {

            }

        }

        private void btndeletecontact_Click(object sender, EventArgs e)
        {
            SqlParameter paramPID = new SqlParameter("@ID", SqlDbType.Int);
            paramPID.Value = PI_ID;
            if (PI_ID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from Contacts where Contact_ID=@ID", paramPID);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max(Contact_ID) from[Contacts] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[Contacts]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");
                    SQLCONN.CloseConnection();
                    PI_ID = EMPID;
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CandidateID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] ,[PI_ID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID  ");
                    ClearTextBoxes();
                    cmbcontact.Text = "Select";
                    //    ClearTextBoxes();



                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
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

                        PI_ID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Contacttxt.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                        cmbcontact.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                        //firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();     
                        //cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


                    }
                }
            }

        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
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

                        PI_ID = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Doctxt.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbDocuments.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();



                        //firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                        //secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                        //cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


                    }
                }
            }
        }

        private void btndeletedoc_Click(object sender, EventArgs e)
        {
            SqlParameter paramPID = new SqlParameter("@ID", SqlDbType.Int);
            paramPID.Value = PI_ID;
            if (PI_ID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from Documents where Doc_id=@ID", paramPID);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max(P_ID) from[Documents] if @max IS NULL SET @max = 0 DBCC CHECKIDENT('[Documents]', RESEED, @max)");
                    MessageBox.Show("Record Deleted Successfully");
                    SQLCONN.CloseConnection();
                    ClearTextBoxes();
                    cmbDocuments.Text = "Select";
                    PI_ID = EMPID;
                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[P_Id] ,[name],[documentValue] ,[url] ,[last_update] ,[DocumentType].Doc_Type ,[RefrenceID]FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and P_Id =  " + PI_ID + " ");


                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void btnupdatecontat_Click(object sender, EventArgs e)
        {
            SqlParameter paramContactType = new SqlParameter("@C1", SqlDbType.Int);
            paramContactType.Value = cmbcontact.SelectedValue;
            SqlParameter paramContact = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramContact.Value = Contacttxt.Text;
            SqlParameter paramRefrenceID = new SqlParameter("@C3", SqlDbType.Int);
            paramRefrenceID.Value = 2;
            SqlParameter paramPID = new SqlParameter("@C4", SqlDbType.Int);
            paramPID.Value = PI_ID;


            if (PI_ID != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("update  Contacts set ContTypeID=@C1,ContValue=@C2 where Contact_ID=@C4",
                                                   paramContactType, paramContact, paramPID);
                    MessageBox.Show("Record Updated Successfully");

                    PI_ID = EMPID;
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CandidateID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] ,[PI_ID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and PI_ID =  " + PI_ID + " ");
                 // ClearTextBoxes();
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

        private void tabContact_Click(object sender, EventArgs e)
        {

        }

        private void btnupdatedoc_Click(object sender, EventArgs e)
        {
            string filename = System.IO.Path.GetFileName(opf.FileName);
            string nameOFfile = opf.SafeFileName;


            SqlParameter paramfilename = new SqlParameter("@C0", SqlDbType.NVarChar);
            paramfilename.Value = "\\Document\\" + filename;
            SqlParameter paramnameOFfile = new SqlParameter("@C1", SqlDbType.NVarChar);
            paramnameOFfile.Value = nameOFfile;
            SqlParameter paramPID = new SqlParameter("@C2", SqlDbType.Int);
            paramPID.Value = PI_ID;
            SqlParameter paramDocType = new SqlParameter("@C3", SqlDbType.Int);
            paramDocType.Value = cmbDocuments.SelectedValue;
            SqlParameter paramRefrenceID = new SqlParameter("@C4", SqlDbType.Int);
            paramRefrenceID.Value = 2;


            if (PI_ID != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {

                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("update  Documents set documentValue=@C0,name=@C1,DocTypeID=@C3 where Doc_id = @C2", paramfilename, paramnameOFfile, paramDocType, paramPID);


                    MessageBox.Show("Record Updated Successfully");
                    PI_ID = EMPID;
                    dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[P_Id] ,[name],[documentValue] ,[url] ,[last_update] ,[DocumentType].Doc_Type ,[RefrenceID]FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and P_Id =  " + PI_ID + " ");
               //    ClearTextBoxes();
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

        private void firstnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddBtn.Visible  = true;
            btnNew.Visible  = DeleteBTN.Visible = Updatebtn.Visible =false;
            ClearTextBoxes();
           // EmployeeForm_Load(sender, e);
            this.ActiveControl = firstnametxt;


        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
              PI_ID = EMPID;
          
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CandidateID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] ,[PI_ID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and PI_ID =  " + PI_ID + " ");

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[P_Id] ,[name],[documentValue] ,[url] ,[last_update] ,[DocumentType].Doc_Type ,[RefrenceID]FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and P_Id =  " + PI_ID + " ");

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                dataGridView4.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT [PI_ID],StatusTBL.StatusValue,[JOBS].JobTitleEN, DeptTypes.Dept_Type_Name,[StartDate],[EndDate] FROM[DelmonGroupDB].[dbo].[EmploymentHistory], JOBS, DEPARTMENTS, StatusTBL, DeptTypes where StatusTBL.StatusID = EmploymentHistory.EmploymentStatusID and DEPARTMENTS.DEPTID = EmploymentHistory.DeptID  and DEPARTMENTS.DeptName = DeptTypes.Dept_Type_ID and JOBS.JobID = EmploymentHistory.JobID  and PI_ID =  " + PI_ID + " ");

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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

                        EMPID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        lastnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        cmbGender.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        AddBtn.Visible = false;
                        btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
                        //PI_ID = EMPID;
                        //dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CandidateID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] ,[PI_ID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and PI_ID =  " + PI_ID + " ");
                        //dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[P_Id] ,[name],[documentValue] ,[url] ,[last_update] ,[DocumentType].Doc_Type ,[RefrenceID]FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and P_Id =  " + PI_ID + " ");

                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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

                        EMPID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        lastnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        cmbGender.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        AddBtn.Visible = false;
                        btnNew.Visible = DeleteBTN.Visible = Updatebtn.Visible = true;
                        //PI_ID = EMPID;
                        //dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT  [Contact_ID] ,[CandidateID]  ,ContactTypes.ContType ,[ContValue] ,[RefrenceID] ,[PI_ID] FROM [DelmonGroupDB].[dbo].[Contacts],[DelmonGroupDB].[dbo].[ContactTypes] where Contacts.ContTypeID = ContactTypes.ContTypeID and PI_ID =  " + PI_ID + " ");
                        //dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT   [Doc_id] ,[P_Id] ,[name],[documentValue] ,[url] ,[last_update] ,[DocumentType].Doc_Type ,[RefrenceID]FROM [DelmonGroupDB].[dbo].[Documents], DocumentType where DocumentType.DocType_ID = Documents.DocTypeID  and P_Id =  " + PI_ID + " ");

                    }
                }
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

                        PI_ID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Contacttxt.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                        cmbcontact.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();

                        //firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();     
                        //cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


                    }
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

                        PI_ID = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Doctxt.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmbDocuments.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();



                        //firstnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                        //secondnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //thirdnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                        //cmbMartialStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


                    }
                }
            }
        }
    }
}
    

  

