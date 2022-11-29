using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace Delmon_Managment_System.Forms
{
    public partial class VisaFrm : Form
    {

        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int Totatvisa = 0;
        int i = 0;
        int VisaNumberID = 0;
        int FileNumberID = 0;
        int TotalVisa = 0;
        string IssueDateHijri = "";
        string ExpiryDateHijri = "";
        string IssueDateEN;
        string ExpiryDateENP = "";
        CultureInfo SA = new CultureInfo("ar-SA");
        CultureInfo US = new CultureInfo("en-US");





        public VisaFrm()
        {


            InitializeComponent();





            cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbConsulate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbConsulate.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbJob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbJob.AutoCompleteSource = AutoCompleteSource.ListItems;







        }

        void ChangeEnabled(bool enabled)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = enabled;
            }
            Visanumtxt.Enabled = true;
            dataGridView1.Enabled = dataGridView2.Enabled = true;
            label1.Enabled = true;
            this.ActiveControl = Visanumtxt;
            btnNew.Enabled = Findbtn.Enabled = true;
            issuhijritxt.SelectedText = "yyyy-MM-dd";
            ExpiaryHijritxt.Enabled = IssueDateENTxt.Enabled = expairENDATEtxt.Enabled = false;



        }
        private void VisaFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
            //    AddBtn.Visible = DeleteBtn.Visible = btnFinish.Visible = Findbtn.Visible = true;
            //btnNew.Visible = Findbtn.Visible = true;

            SQLCONN.OpenConection();
            this.ActiveControl = Visanumtxt;


            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT COMPID,COMPName_EN FROM Companies");


            cmbJob.ValueMember = "JobID";
            cmbJob.DisplayMember = "JobTitleEN";
            cmbJob.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT JobID,JobTitleEN FROM JOBS");

            cmbConsulate.ValueMember = "Consulates.ConsulateID";
            cmbConsulate.DisplayMember = "ConsulateCity";
            cmbConsulate.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId");

            cmbStatus.ValueMember = "statusid";
            cmbStatus.DisplayMember = "status";
            cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select statusid,status  from Visastatus where RefrenceID =1 or RefrenceID = 0 order by statusid");


            cmbcandidates.ValueMember = "PI_ID";
            cmbcandidates.DisplayMember = "Name";
            cmbcandidates.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT PersonalInformation.PI_ID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[PersonalInformation] ,EmploymentHistory where PersonalInformation.PI_ID = EmploymentHistory.PI_ID and EmploymentHistory.EmploymentStatusID = 23");
            cmbcandidates.Text = "Select";
            SQLCONN.CloseConnection();




        }
        private void LoadTheme()
        {
            //foreach (Control btns in this.Controls)
            //{
            //    if (btns.GetType() == typeof(Button))
            //    {
            //        Button btn = (Button)btns;
            //        btn.BackColor = ThemeColor.PrimaryColor;
            //        btn.ForeColor = Color.White;
            //        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            //    }
            //}
            // label4.ForeColor = ThemeColor.SecondaryColor;
            //  label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void visasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void IssueDateHijriPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void IssueDateENPicker_ValueChanged(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-US");

        }

        private void ExpiryDateHijriPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            //    (textBox2.Text) = ConvertDateCalendar(Convert.ToDateTime(textBox3.Text), "Gregorian", "en-US");

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void issuhijritxt_Leave(object sender, EventArgs e)
        {

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

            ReceviedPicker.Value = DateTime.Now;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = false;
            i = 0;
            Remaininglbl.Text = "";
            issuhijritxt.Text = "yyyy-MM-dd";

        }


        private void AddBtn_Click(object sender, EventArgs e)
        {


            if (TotalVisastxt.Text == "")
            {
                MessageBox.Show("Please insert 'TOTAL JOBS' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TotalVisastxt.BackColor = Color.Red;
                btnNew.Visible = true;


            }
            else if (cmbCompany.Text == "Select")
            {
                MessageBox.Show("Please Select ' Company ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNew.Visible = true;


            }
            else if (issuhijritxt.Text == "")
            {
                MessageBox.Show("Please insert ' Issue hijri date ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNew.Visible = true;


            }
            else if (cmbConsulate.Text == "Select")
            {
                MessageBox.Show("Please Select ' Consulate ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNew.Visible = true;


            }
            else if (cmbJob.Text == "Select")
            {
                MessageBox.Show("Please Select ' Job ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNew.Visible = true;


            }
            else
            {
                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  VisaNumber from Visa where  VisaNumber= " + Visanumtxt.Text + "  ");
                dr.Read();

                if (dr.HasRows)
                {
                    MessageBox.Show("This 'VISA NUMBER'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = false;

                }
                else
                {
                    dr.Dispose();
                    dr.Close();

                    dr = SQLCONN.DataReader("select  VisaNumber from VISAJobList where  VisaNumber= " + Visanumtxt.Text + "  ");
                    dr.Read();
                    if (dr.HasRows)
                    {
                        dr.Dispose();
                        dr.Close();

                        SqlParameter paramVisanumber = new SqlParameter("@C1", SqlDbType.Int);
                        paramVisanumber.Value = Visanumtxt.Text;
                        SqlParameter paramstatusID = new SqlParameter("@C2", SqlDbType.NVarChar);
                        paramstatusID.Value = cmbStatus.SelectedValue;
                        SqlParameter ParamConsulate = new SqlParameter("@C3", SqlDbType.NVarChar);
                        ParamConsulate.Value = cmbConsulate.SelectedValue;
                        SqlParameter paramJob = new SqlParameter("@C4", SqlDbType.NVarChar);
                        paramJob.Value = cmbJob.SelectedValue;



                        Totatvisa = int.Parse(TotalVisastxt.Text);
                        if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            for (i = 0; i < Totatvisa; i++)

                            {
                                dr.Dispose();
                                dr.Close();

                                SQLCONN.ExecuteQueries("insert into VISAJobList (VisaNumber,statusid,ConsulateID,JobID) " +
                                    " values (@C1,@C2,@C3,@C4) ",
                                    paramVisanumber, paramstatusID, ParamConsulate, paramJob);

                            }
                            MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISAJobList where visanumber=" + Visanumtxt.Text + " ");
                            TotalVisastxt.Text = "";
                            cmbConsulate.Text = "Select";
                            cmbJob.Text = "Select";
                            cmbStatus.Text = "Select";
                        }


                        TotalVisastxt.Enabled = true;
                    }
                    else
                    {

                        dr.Dispose();
                        dr.Close();

                        SqlParameter paramVisanumber = new SqlParameter("@C1", SqlDbType.Int);
                        paramVisanumber.Value = Visanumtxt.Text;
                        SqlParameter paramstatusID = new SqlParameter("@C2", SqlDbType.NVarChar);
                        paramstatusID.Value = cmbStatus.SelectedValue;
                        SqlParameter ParamConsulate = new SqlParameter("@C3", SqlDbType.NVarChar);
                        ParamConsulate.Value = cmbConsulate.SelectedValue;
                        SqlParameter paramJob = new SqlParameter("@C4", SqlDbType.NVarChar);
                        paramJob.Value = cmbJob.SelectedValue;



                        Totatvisa = int.Parse(TotalVisastxt.Text);
                        if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            for (i = 0; i < Totatvisa; i++)

                            {
                                dr.Dispose();
                                dr.Close();

                                SQLCONN.ExecuteQueries("insert into VISAJobList (VisaNumber,statusid,ConsulateID,JobID) " +
                                    " values (@C1,@C2,@C3,@C4) ",
                                    paramVisanumber, paramstatusID, ParamConsulate, paramJob);

                            }
                            MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISAJobList where visanumber=" + Visanumtxt.Text + " ");
                            TotalVisastxt.Text = "";
                            cmbConsulate.Text = "Select";
                            cmbJob.Text = "Select";
                            cmbStatus.Text = "Select";
                        }


                        TotalVisastxt.Enabled = true;


                    }

                    SQLCONN.CloseConnection();
                    // VisaFrm_Load(sender, e);

                }
            }








        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmbJob_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void issuhijritxt_Enter(object sender, EventArgs e)
        {


            IssueDateHijri = SA.DateTimeFormat.ShortDatePattern;

            if (issuhijritxt.Text == "yyyy-MM-dd")
            {
                issuhijritxt.Text = "";
                issuhijritxt.ForeColor = Color.Black;
            }



        }



        private void issuhijritxt_TextChanged(object sender, EventArgs e)
        {

            IssueDateHijri = SA.DateTimeFormat.ShortDatePattern;
            if (issuhijritxt.Text == "yyyy-MM-dd")
            {
                issuhijritxt.Text = "";
                issuhijritxt.ForeColor = Color.Black;
            }
        }

        private void issuhijritxt_MouseEnter(object sender, EventArgs e)
        {


        }

        private void issuhijritxt_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Visanumtxt_TextChanged(object sender, EventArgs e)
        {
            Visanumtxt.BackColor = Color.White;
            SQLCONN.OpenConection();
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from visa where  VisaNumber LIKE '%" + Visanumtxt.Text + "%'");
            SQLCONN.CloseConnection();
            //this.dataGridView1.Columns[2].Visible = false;
            //this.dataGridView1.Columns[4].Visible = false;
            //this.dataGridView1.Columns[5].Visible = false;
            //this.dataGridView1.Columns[6].Visible = false;
            //this.dataGridView1.Columns[8].Visible = false;


            dataGridView1.Visible = true;
        }

        private void Visanumtxt_Leave(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {


            if (Visanumtxt.Text == "")
            {
                MessageBox.Show("Please insert 'VISA NUMBER' first !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Visanumtxt.BackColor = Color.Red;

            }
            else
            {

                SQLCONN.OpenConection();
                SqlDataReader dr = SQLCONN.DataReader("select  VisaNumber from Visa where  VisaNumber= " + Visanumtxt.Text + "  ");
                dr.Read();
                if (dr.HasRows)
                {
                    MessageBox.Show("This 'VISA NUMBER'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    SqlParameter paramVisanumber = new SqlParameter("@C1", SqlDbType.Int);
                    paramVisanumber.Value = Visanumtxt.Text;
                    SqlParameter paramcomapany = new SqlParameter("@C2", SqlDbType.Int);
                    paramcomapany.Value = cmbCompany.SelectedValue;
                  
                    SqlParameter paramRecevidDate = new SqlParameter("@C3", SqlDbType.Date);
                    paramRecevidDate.Value = ReceviedPicker.Value;
                    SqlParameter paramIssHIJriDate = new SqlParameter("@C4", SqlDbType.NVarChar);
                    paramIssHIJriDate.Value = issuhijritxt.Text;
                    SqlParameter paramIssueDateEN = new SqlParameter("@C5", SqlDbType.NVarChar);
                    paramIssueDateEN.Value = IssueDateEN;
                    SqlParameter paramExpiryDateHijri = new SqlParameter("@C6", SqlDbType.NVarChar);
                    paramExpiryDateHijri.Value = ExpiaryHijritxt.Text;
                    SqlParameter paramExpiryDateEN = new SqlParameter("@C7", SqlDbType.NVarChar);
                    paramExpiryDateEN.Value = ExpiryDateENP;
                  
                    SqlParameter paramTotalVisas = new SqlParameter("@C8", SqlDbType.NVarChar);

                    SqlParameter paramRemarks = new SqlParameter("@C9", SqlDbType.NVarChar);
                    paramRemarks.Value = RemarksTxt.Text;
                    dr.Dispose();
                    dr.Close();

                    dr = SQLCONN.DataReader("SELECT count (FileNumber)  FROM  VISAJobList WHERE VISANumber= '" + Visanumtxt.Text + "'");
                    dr.Read();
                    if (dr.HasRows)
                    {
                        TotalVisa = dr.GetInt32(0);
                    }
                    paramTotalVisas.Value = TotalVisa;
                    dr.Dispose();
                    dr.Close();

                    if (DialogResult.Yes == MessageBox.Show("Do You Want to submit this info for Visa No :  " + Visanumtxt.Text + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SQLCONN.ExecuteQueries("insert into VISA (VisaNumber,ComapnyID,ReceviedDate,IssueDateEN,ExpiryDateEN,TotalVisas,Remarks,ExpiryDateHijri,IssueDateHijri) " +
                            " values (@C1,@C2,@C3,@C5,@C7,@C8,@C9,@C6,@C4) ",
                            paramVisanumber, paramcomapany, paramRecevidDate, paramIssueDateEN, paramExpiryDateEN, paramTotalVisas, paramRemarks, paramExpiryDateHijri, paramIssHIJriDate);
                        MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Dispose();
                        dr.Close();
                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISA where visanumber=" + Visanumtxt.Text + " ");

                        SQLCONN.CloseConnection();
                        VisaFrm_Load(sender, e);
                        TotalVisastxt.Enabled = false;
                        AddBtn.Visible = btnFinish.Visible = DeleteBtn.Visible = Findbtn.Visible = false;
                        btnNew.Visible = Findbtn.Visible = true;
                        issuhijritxt.Text = ExpiaryHijritxt.Text = IssueDateENTxt.Text = expairENDATEtxt.Text = "";

                    }
                    else
                    {
                        AddBtn.Visible = btnFinish.Visible = DeleteBtn.Visible = Findbtn.Visible = true;
                        btnNew.Visible = Findbtn.Visible = false;
                    }

                }

            }







        }

        private void VisaFrm_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void issuhijritxt_KeyUp(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                if (issuhijritxt.Text != "")
                {

                    if (issuhijritxt.SelectedText.Contains("/") == true)

                    {
                        MessageBox.Show("Please type date in format : " + "yyyy-MM-dd" + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IssueDateEN = US.DateTimeFormat.ShortDatePattern;



                        /*calculate issu hijir and milaidy  date**/

                        string a = issuhijritxt.Text.Trim();
                        a = issuhijritxt.Text.TrimStart();
                        a = issuhijritxt.Text.TrimEnd();
                        DateTime toGegorian = DateTime.ParseExact(a, "yyyy-MM-dd", SA);
                        DateTime b = DateTime.ParseExact(a, "yyyy-MM-dd", null);


                        DateTime b2 = DateTime.ParseExact(a, "yyyy-MM-dd", null);
                        DateTime dtNOW = DateTime.Now;
                        dtNOW.ToString("yyyy-MM-dd");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("yyyy-MM-dd");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(708);
                        ExpiryDateHijri = b2.ToString("yyyy-MM-dd");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("yyyy-MM-dd");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(708);
                        ExpiryDateENP = toGegorian.ToString("yyyy-MM-dd");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = DateTime.ParseExact(ExpiryDateENP, "yyyy-MM-dd", null);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                        Remaininglbl.Text = numberOfDays.ToString();



                    }





                }

                else { }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (issuhijritxt.Text != "")
                {

                    if (issuhijritxt.SelectedText.Contains("/") == true)

                    {
                        MessageBox.Show("Please type date in format : " + "yyyy-MM-dd" + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        IssueDateEN = US.DateTimeFormat.ShortDatePattern;



                        /*calculate issu hijir and milaidy  date**/

                        string a = issuhijritxt.Text.Trim();
                        a = issuhijritxt.Text.TrimStart();
                        a = issuhijritxt.Text.TrimEnd();
                        DateTime toGegorian = DateTime.ParseExact(a, "yyyy-MM-dd", SA);
                        DateTime b = DateTime.ParseExact(a, "yyyy-MM-dd", null);


                        DateTime b2 = DateTime.ParseExact(a, "yyyy-MM-dd", null);
                        DateTime dtNOW = DateTime.Now;
                        dtNOW.ToString("yyyy-MM-dd");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("yyyy-MM-dd");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(708);
                        ExpiryDateHijri = b2.ToString("yyyy-MM-dd");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("yyyy-MM-dd");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(708);
                        ExpiryDateENP = toGegorian.ToString("yyyy-MM-dd");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = DateTime.ParseExact(ExpiryDateENP, "yyyy-MM-dd", null);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                        Remaininglbl.Text = numberOfDays.ToString();


                    }
                }

                else { }
            }
        }

        private void issuhijritxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (issuhijritxt.Text != "")
                {

                    if (issuhijritxt.SelectedText.Contains("/") == true)
                    {
                        MessageBox.Show("Please type date in format : " + "yyyy-MM-dd" + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {


                        IssueDateEN = US.DateTimeFormat.ShortDatePattern;



                        /*calculate issu hijir and milaidy  date**/

                        string a = issuhijritxt.Text.Trim();
                        a = issuhijritxt.Text.TrimStart();
                        a = issuhijritxt.Text.TrimEnd();
                        DateTime toGegorian = DateTime.ParseExact(a, "yyyy-MM-dd", SA);
                        DateTime b = DateTime.ParseExact(a, "yyyy-MM-dd",null);


                        DateTime b2 = DateTime.ParseExact(a, "yyyy-MM-dd", null);
                        DateTime dtNOW = DateTime.Now;
                        dtNOW.ToString("yyyy-MM-dd");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("yyyy-MM-dd");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(729);
                        ExpiryDateHijri = b2.ToString("yyyy-MM-dd");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("yyyy-MM-dd");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(709);
                        ExpiryDateENP = toGegorian.ToString("yyyy-MM-dd");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = DateTime.ParseExact(ExpiryDateENP, "yyyy-MM-dd",null);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                        Remaininglbl.Text = numberOfDays.ToString();



                    }
                }

                else { }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (issuhijritxt.Text != "")
                {

                    if (issuhijritxt.SelectedText.Contains("/") == true)

                    {
                        MessageBox.Show("Please type date in format : " + "yyyy-MM-dd" + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IssueDateEN = US.DateTimeFormat.ShortDatePattern;



                        /*calculate issu hijir and milaidy  date**/

                        string a = issuhijritxt.Text.Trim();
                        a = issuhijritxt.Text.TrimStart();
                        a = issuhijritxt.Text.TrimEnd();
                        var toGegorian = DateTime.ParseExact(a, "yyyy-MM-dd", SA);
                        DateTime b = Convert.ToDateTime(a);


                        DateTime b2 = Convert.ToDateTime(a);
                        DateTime dtNOW = DateTime.Now;
                        dtNOW.ToString("yyyy-MM-dd");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("yyyy-MM-dd");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(708);
                        ExpiryDateHijri = b2.ToString("yyyy-MM-dd");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("yyyy-MM-dd");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(708);
                        ExpiryDateENP = toGegorian.ToString("yyyy-MM-dd");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = Convert.ToDateTime(ExpiryDateENP);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                        Remaininglbl.Text = numberOfDays.ToString();

                    }
                }

                else { }
            }
            if (e.KeyCode == Keys.Enter)
            {
                RemarksTxt.Focus();
                e.Handled = true;
            }
        }

        private void TotalVisastxt_TextChanged(object sender, EventArgs e)
        {
            TotalVisastxt.BackColor = Color.White;
            cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("dgsqlserver@delmon-its.com.sa");
                msg.To.Add("m.amin@delmon.com.sa");
                msg.Subject = "Test";
                msg.Body = "Hello";

                SmtpClient smt = new SmtpClient();
                smt.Host = "mail.delmon-its.com.sa";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "dgsqlserver@delmon-its.com.sa";
                ntcd.Password = "PAbx9DeBn8";
                smt.Credentials = ntcd;
                smt.EnableSsl = false;
                smt.Port = 587;
                smt.Send(msg);

                MessageBox.Show("Your Mail was sended");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void candidatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddBtn.Visible = DeleteBtn.Visible = btnFinish.Visible = true;
            btnNew.Visible = Findbtn.Visible = false;
            ClearTextBoxes();
            VisaFrm_Load(sender, e);
            ChangeEnabled(true);
            Visanumtxt.BackColor = Color.White;
            TotalVisastxt.BackColor = Color.White;
            cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = true;



        }

        private void FileNumber_TextChanged(object sender, EventArgs e)
        {
            //SQLCONN.OpenConection();
            //dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from VISAJobList where filenumber LIKE '" + FileNumber.Text + "%'");
            //SQLCONN.CloseConnection();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }



        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramFilenumber = new SqlParameter("@C1", SqlDbType.Int);
            paramFilenumber.Value = FileNumberID;

            if (FileNumberID == 0)
            {
                MessageBox.Show("Please select visa number first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete  VISAJobList where filenumber=@C1", paramFilenumber);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([filenumber]) from[VISAJobList] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[VISAJobList]', RESEED, @max)");
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from VISAJobList ");
                    SQLCONN.CloseConnection();
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }

        private void FileNumber_TextChanged_1(object sender, EventArgs e)
        {
            //SQLCONN.OpenConection();
            //dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from VISAJobList where filenumber LIKE '" + FileNumber.Text + "%'");
            //SQLCONN.CloseConnection();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Findbtn_Click(object sender, EventArgs e)
        {
            ChangeEnabled(false);
            dataGridView1.DataSource = dataGridView2.DataSource = null;
            ClearTextBoxes();

        }

        private void IssueDateENTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void TotalVisastxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Charchters are not allowed " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

            }
        }

        private void Visanumtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Charchters are not allowed " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

            }
        }

        private void issuhijritxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '-'))

            {
                e.Handled = true;
                MessageBox.Show(" this Charchter '/' was not allowed please use '-' ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

            }
        }

        private void Visanumtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCompany.Focus();
                e.Handled = true;
            }
        }

        private void cmbCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReceviedPicker.Focus();
                e.Handled = true;
            }
        }

        private void ReceviedPicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                issuhijritxt.Focus();
                e.Handled = true;
            }
        }

        private void ExpiaryHijritxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IssueDateENTxt.Focus();
                e.Handled = true;
            }
        }

        private void IssueDateENTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                expairENDATEtxt.Focus();
                e.Handled = true;
            }
        }

        private void expairENDATEtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RemarksTxt.Focus();
                e.Handled = true;
            }
        }

        private void RemarksTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TotalVisastxt.Focus();
                e.Handled = true;
            }
        }

        private void TotalVisastxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbConsulate.Focus();
                e.Handled = true;
            }
        }

        private void cmbConsulate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbJob.Focus();
                e.Handled = true;
            }
        }

        private void cmbJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbStatus.Focus();
                e.Handled = true;
            }
        }

        private void cmbcandidates_SelectedIndexChanged(object sender, EventArgs e)
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

                        FileNumberID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                        cmbConsulate.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString());
                        cmbJob.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
                        cmbStatus.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
                        VisaFileNumberID.Text = FileNumberID.ToString();

                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Visible = true;


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
              VisaNumberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
              cmbCompany.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
              ReceviedPicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
             issuhijritxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
             IssueDateENTxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
             ExpiaryHijritxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
             expairENDATEtxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
             TotalVisastxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
             RemarksTxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
             dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISAJobList where visanumber=" + VisaNumberID + " ");

                    }
                      Visanumtxt.Text = VisaNumberID.ToString();


                    ///*calculate the */

                    string a = issuhijritxt.Text.Trim();
                    a = issuhijritxt.Text.TrimStart();
                    a = issuhijritxt.Text.TrimEnd();
                    DateTime toGegorian = DateTime.ParseExact(a, "yyyy-MM-dd", SA);
                    DateTime b = DateTime.ParseExact(a, "yyyy-MM-dd", null);


                    DateTime b2 = DateTime.ParseExact(a, "yyyy-MM-dd", null);
                    DateTime dtNOW = DateTime.Now;
                    dtNOW.ToString("yyyy-MM-dd");

                    issuhijritxt.Text = b.ToString("f");
                    IssueDateHijri = b.Date.ToString("yyyy-MM-dd");
                    issuhijritxt.Text = IssueDateHijri.ToString();
                    /*calculate expairy hiri date**/


                    b2 = b2.Date.AddDays(709);
                    ExpiryDateHijri = b2.ToString("yyyy-MM-dd");
                    ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                    /*calculate issu milaidy  date**/
                    IssueDateEN = toGegorian.ToString();
                    IssueDateEN = toGegorian.ToString("yyyy-MM-dd");
                    IssueDateENTxt.Text = IssueDateEN;





                    ///*calculate expairy milaidy date**/
                    toGegorian = toGegorian.AddDays(709);
                    ExpiryDateENP = toGegorian.ToString("yyyy-MM-dd");
                    expairENDATEtxt.Text = ExpiryDateENP;


                    ///*calculate the */

                    DateTime futurDate = DateTime.ParseExact(ExpiryDateENP, "yyyy-MM-dd", null);
                    var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);

                    if (numberOfDays <= 0)
                    {
                        Remaininglbl.Text = "Expired";

                    }
                    else
                    {
                        Remaininglbl.Text = numberOfDays.ToString();

                    }



                    ///*calculate the */


                }
            }

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            
            SqlParameter paramPID = new SqlParameter("@C1", SqlDbType.Int);
            paramPID.Value = cmbcandidates.SelectedValue;

            SqlParameter paramFilenumber = new SqlParameter("@C2", SqlDbType.Int);
            paramFilenumber.Value = FileNumberID;
            MessageBox.Show(FileNumberID.ToString());
            MessageBox.Show(cmbcandidates.SelectedValue.ToString());



            if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                SQLCONN.OpenConection();
                SQLCONN.ExecuteQueries("update  VISAJobList set PI_ID=@C1 where FileNumber=@C2",
                                              paramPID, paramFilenumber);
                MessageBox.Show("File Number Has been Assign Successfully   ");
                VisaFileNumberID.Text = "";
                cmbcandidates.Text = "Select";

                
                dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISAJobList where visanumber=" + VisaNumberID + " ");
                // ClearTextBoxes();
                SQLCONN.CloseConnection();
                
            }
            else
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnnewJob_Click(object sender, EventArgs e)
        {
            FrmJobsNew frmJobs = new FrmJobsNew();
            this.Hide();
            frmJobs.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
 

            SqlParameter paramRecevidDate = new SqlParameter("@C3", SqlDbType.Date);
            paramRecevidDate.Value = ReceviedPicker.Value;
        
            SqlParameter paramIssHIJriDate = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramIssHIJriDate.Value = issuhijritxt.Text;
           
            SqlParameter paramVisaID = new SqlParameter("@id", SqlDbType.Int);
            paramVisaID.Value = VisaNumberID;




            if (VisaNumberID != 0)
            {

                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("update visa set ReceviedDate=@C3,IssueDateHijri=@C4 where VisaNumber=@id",
                      paramRecevidDate, paramIssHIJriDate, paramVisaID);
                        MessageBox.Show("Record Updated Successfully");
                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from visa where VisaNumber = '" + VisaNumberID + "'");
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



