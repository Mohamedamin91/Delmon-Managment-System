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
using Tulpep.NotificationWindow;

namespace Delmon_Managment_System.Forms
{
    public partial class VisaFrm : Form
    {

        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int Totatvisa = 0;
        int i = 0;
        int Companyid = 0;
        int VisaNumberID = 0;
        int FileNumberID = 0;
        int TotalVisa = 0;
        string IssueDateHijri = "";
        string ExpiryDateHijri = "";
        string IssueDateEN;
        string ExpiryDateENP = "";
        CultureInfo SA = new CultureInfo("ar-SA");
        CultureInfo US = new CultureInfo("en-US");
        FrmLogin frmLogin = new FrmLogin();
       // System.Timers.Timer tmr = null;
        SqlParameter paramcomapany = new SqlParameter("@Comp", SqlDbType.Int);
        SqlParameter paramReservedTo = new SqlParameter("@CompReservedTo", SqlDbType.Int);










        public VisaFrm()
        {


            InitializeComponent();
          //  cmbJob.KeyDown += new KeyEventHandler(cmbJob_KeyDown);
         //   this.timer1.Interval = 1000;
        //    timer1.Start();



            //  Font newFont = new Font("Times New Roman", 12);

            // Loop through all controls on the form and change their font properties
        //    foreach (Control control in Controls)
            //{
         // //      control.Font = newFont;
//}


            //cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbConsulate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbConsulate.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            ////cmbJob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cmbJob.AutoCompleteSource = AutoCompleteSource.ListItems;







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
            ExpiaryHijritxt.Enabled = IssueDateENTxt.Enabled = expairENDATEtxt.Enabled = false;



        }

        private void VisaFrm_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            timer1.Start();


            // cmbConsulate.Text = cmbJob.Text = cmbStatus.Text = cmbcandidates.Text = cmbcandidates2.Text = cmbAgency.Text = "Select";

            //lblusername.Text = CommonClass.LoginUserName;
            //lblusertype.Text = CommonClass.Usertype;
            //lblemail.Text = CommonClass.Email;
            //lblFullname.Text = CommonClass.LoginEmployeeName;
            //lblPC.Text = Environment.MachineName;





            AddBtn.Visible = DeleteBtn.Visible = btnFinish.Visible = Findbtn.Visible = true;
            btnNew.Visible = Findbtn.Visible = true;

            this.ActiveControl = Visanumtxt;




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

        }



        private void AddBtn_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show(cmbCompany.SelectedValue.ToString());

            if (TotalVisastxt.Text == "")
            {
                MessageBox.Show("Please insert 'TOTAL JOBS' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TotalVisastxt.BackColor = Color.Red;
                btnNew.Visible = true;


            }
            else if (cmbCompany.Text == "Select" || cmbCompany.Text=="")
            {
                MessageBox.Show("Please Select ' Company ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNew.Visible = true;


            }
            else if (issuhijritxt.Text == "" || issuhijritxt.Text == "")
            {
                MessageBox.Show("Please insert ' Issue hijri date ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNew.Visible = true;


            }
            else if (cmbConsulate.Text == "Select" || cmbConsulate.Text == "" )
            {
                MessageBox.Show("Please Select ' Consulate ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNew.Visible = true;


            }
            else if (cmbJob.Text == "Select" || cmbJob.Text == "" )
            {
                MessageBox.Show("Please Select ' Job ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnNew.Visible = true;


            }
            else if (cmbStatus.Text == "Select" || cmbStatus.Text == "")
            {
                MessageBox.Show("Please Select ' Visa status ' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                        SqlParameter paramAgency = new SqlParameter("@C5", SqlDbType.NVarChar);


                        if (cmbAgency.Text == "Select" || cmbAgency.Text == "")
                        {
                            cmbAgency.SelectedValue = 0;
                            paramAgency.Value = 0;
                        }
                        else
                        {
                            paramAgency.Value = cmbAgency.SelectedValue;

                        }

                        SqlParameter paramCandidate = new SqlParameter("@cand", SqlDbType.NVarChar);
                        if (cmbcandidates.Text == "Select" || cmbcandidates.Text == "")
                        {
                            cmbcandidates.SelectedValue = 0;
                            paramCandidate.Value = 0;

                        }
                        else
                        {
                            paramCandidate.Value = cmbcandidates.SelectedValue;

                        }

                        if (cmbReservedTo.Text == "Select" || cmbReservedTo.Text == "")
                        {
                            cmbReservedTo.SelectedValue = 0;
                            paramReservedTo.Value = 0;

                        }
                        else
                        {
                            paramReservedTo.Value = cmbReservedTo.SelectedValue;

                        }





                        //SqlParameter paramRequiredJob = new SqlParameter("@C5", SqlDbType.NVarChar);
                        //paramRequiredJob.Value = CmbReqierdJob.SelectedValue;


                        Totatvisa = int.Parse(TotalVisastxt.Text);
                        if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            for (i = 0; i < Totatvisa; i++)

                            {
                                dr.Dispose();
                                dr.Close();

                                SQLCONN.ExecuteQueries("insert into VISAJobList (VisaNumber,statusid,ConsulateID,JobID,ReservedTo,AgencyID,EmployeeID) " +
                                    " values (@C1,@C2,@C3,@C4,@CompReservedTo,@C5,@cand) ",
                                    paramVisanumber, paramstatusID, ParamConsulate, paramJob, paramReservedTo, paramCandidate);

                            }
                            MessageBox.Show("Jobs has been added successfully to Visa", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISAJobList where visanumber =" + Visanumtxt.Text + " ");
                            TotalVisastxt.Text = "";
                            cmbConsulate.Text = "Select";
                            cmbJob.Text = "Select";
                            cmbStatus.Text = "Select";
                            //  CmbReqierdJob.Text = "Select";
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
                        SqlParameter paramAgency = new SqlParameter("@C5", SqlDbType.NVarChar);
                        if (cmbAgency.Text == "Select" || cmbAgency.Text == "")
                        {
                            cmbAgency.SelectedValue = 0;
                            paramAgency.Value = 0;
                        }
                        else 
                        {
                            paramAgency.Value = cmbAgency.SelectedValue;

                        }
                        SqlParameter paramCandidate = new SqlParameter("@cand", SqlDbType.Int);
                        if (cmbcandidates.Text == "Select" || cmbcandidates.Text == "")
                        {
                            cmbcandidates.SelectedValue = 0;
                            paramCandidate.Value = 0;

                        }
                        else
                        {
                            paramCandidate.Value = cmbcandidates.SelectedValue;

                        }


                        if (cmbReservedTo.Text == "Select" || cmbReservedTo.Text == "")
                        {
                            cmbReservedTo.SelectedValue = 0;
                            paramReservedTo.Value = 0;

                        }
                        else
                        {
                            paramReservedTo.Value = cmbReservedTo.SelectedValue;

                        }







                        Totatvisa = int.Parse(TotalVisastxt.Text);
                        if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            for (i = 0; i < Totatvisa; i++)

                            {
                                dr.Dispose();
                                dr.Close();

                                SQLCONN.ExecuteQueries("insert into VISAJobList (VisaNumber,statusid,ConsulateID,JobID,AgencyID,ReservedTo,EmployeeID) " +
                                    " values (@C1,@C2,@C3,@C4,@C5,@CompReservedTo,@cand) ",
                                    paramVisanumber, paramstatusID, ParamConsulate, paramJob, paramAgency, paramReservedTo, paramCandidate);

                            }
                            MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Enable button 2 after button 1 is clicked
                            btnFinish.Enabled = true;

                            // Show a message to the user if necessary
                         //  MessageBox.Show("Please click Finish Button after clicking Add Button", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            btnFinish.PerformClick();
                            btnFinish.Enabled = false;
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
            //if (issuhijritxt.Text == "yyyy-MM-dd")
            //{
            //    issuhijritxt.Text = "";
            //    issuhijritxt.ForeColor = Color.Black;
            //}
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
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT  [VisaNumber]
      ,[ComapnyID]
      ,[ReceviedDate]
      ,[IssueDateHijri]
      ,[IssueDateEN]
      ,[ExpiryDateHijri]
      ,[ExpiryDateEN]
      ,[TotalVisas]
      ,[Remarks]
      ,[UserID]
      ,[DatetimeLOG]
      ,[CRNumber]
      ,[ID_Number]
       FROM [DelmonGroupDB].[dbo].[VISA], [Companies] where Companies.COMPID=VISA.ComapnyID and VisaNumber LIKE '%" + Visanumtxt.Text + "%'");
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

                    paramcomapany.Value = cmbCompany.SelectedValue;
                    Companyid = (int)cmbCompany.SelectedValue;

                    SqlParameter paramRecevidDate = new SqlParameter("@C3", SqlDbType.Date);
                    paramRecevidDate.Value = ReceviedPicker.Value;
                    SqlParameter paramIssHIJriDate = new SqlParameter("@C4", SqlDbType.NVarChar);
                    paramIssHIJriDate.Value = issuhijritxt.Text;
                    SqlParameter paramIssueDateEN = new SqlParameter("@C5", SqlDbType.NVarChar);
                    paramIssueDateEN.Value = IssueDateENTxt.Text;
                    SqlParameter paramExpiryDateHijri = new SqlParameter("@C6", SqlDbType.NVarChar);
                    paramExpiryDateHijri.Value = ExpiaryHijritxt.Text;
                    SqlParameter paramExpiryDateEN = new SqlParameter("@C7", SqlDbType.NVarChar);
                    paramExpiryDateEN.Value = expairENDATEtxt.Text;

                    SqlParameter paramTotalVisas = new SqlParameter("@C8", SqlDbType.NVarChar);
                    paramTotalVisas.Value = TotalVisastxt.Text;
                    SqlParameter paramRemarks = new SqlParameter("@C9", SqlDbType.NVarChar);
                    paramRemarks.Value = RemarksTxt.Text;


                    SqlParameter paramUserID = new SqlParameter("@C10", SqlDbType.NVarChar);
                    paramUserID.Value = CommonClass.UserID;
                    SqlParameter paramDateTimeLOG = new SqlParameter("@C11", SqlDbType.NVarChar);
                    paramDateTimeLOG.Value = lbldatetime.Text;


                    SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
                    paramuser.Value = CommonClass.LoginUserName;
                    //SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
                    //paramdatetimeLOG.Value = lbldatetime.Text;
                    SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
                    parampc.Value = Environment.MachineName;







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
                        SQLCONN.ExecuteQueries("insert into VISA (VisaNumber,ComapnyID,ReceviedDate,IssueDateEN,ExpiryDateEN,TotalVisas,Remarks,ExpiryDateHijri,IssueDateHijri,UserID,DatetimeLOG) " +
                            " values (@C1,@Comp,@C3,@C5,@C7,@C8,@C9,@C6,@C4,@C10,@C11) ",
                            paramVisanumber, paramcomapany, paramRecevidDate, paramIssueDateEN, paramExpiryDateEN, paramTotalVisas, paramRemarks, paramExpiryDateHijri, paramIssHIJriDate, paramUserID, paramDateTimeLOG);
                        MessageBox.Show("Visa has been Saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (Logvalueid, logvalue ,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES (@C1, 'Visa Info' ,'#','#',@C11,@pc,@user,'Insert')", paramVisanumber, paramDateTimeLOG, parampc, paramuser);


                        dr.Dispose();
                        dr.Close();
                        dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT [VisaNumber]
      ,[ComapnyID]
      ,[ReceviedDate]
      ,[IssueDateHijri]
      ,[IssueDateEN]
      ,[ExpiryDateHijri]
      ,[ExpiryDateEN]
      ,[TotalVisas]
      ,[Remarks]
      ,[UserID]
      ,[DatetimeLOG]
      ,[CRNumber]
      ,[ID_Number]
       FROM[DelmonGroupDB].[dbo].[VISA], [Companies] where Companies.COMPID = VISA.ComapnyID and  visanumber =" + Visanumtxt.Text + " ");

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
                        MessageBox.Show("Please type date in format : " + "dd/MM/yyyy" + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IssueDateEN = US.DateTimeFormat.ShortDatePattern;



                        /*calculate issu hijir and milaidy  date**/

                        string a = issuhijritxt.Text.Trim();
                        a = issuhijritxt.Text.TrimStart();
                        a = issuhijritxt.Text.TrimEnd();
                        DateTime toGegorian = DateTime.ParseExact(a, "dd/MM/yyyy", SA);
                        DateTime b = DateTime.ParseExact(a, "dd/MM/yyyy", null);


                        DateTime b2 = DateTime.ParseExact(a, "dd/MM/yyyy", null);
                        DateTime dtNOW = DateTime.Now;
                        dtNOW.ToString("dd/MM/yyyy");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("dd/MM/yyyy");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(708);
                        ExpiryDateHijri = b2.ToString("dd/MM/yyyy");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("dd/MM/yyyy");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(708);
                        ExpiryDateENP = toGegorian.ToString("dd/MM/yyyy");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = DateTime.ParseExact(ExpiryDateENP, "dd/MM/yyyy", null);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                        if (numberOfDays <= 0)
                        {
                            Remaininglbl.Text = "Expired";

                        }
                        else
                        {
                            Remaininglbl.Text = numberOfDays.ToString();

                        }


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
                        MessageBox.Show("Please type date in format : " + "dd/MM/yyyy" + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        IssueDateEN = US.DateTimeFormat.ShortDatePattern;



                        /*calculate issu hijir and milaidy  date**/

                        string a = issuhijritxt.Text.Trim();
                        a = issuhijritxt.Text.TrimStart();
                        a = issuhijritxt.Text.TrimEnd();
                        DateTime toGegorian = DateTime.ParseExact(a, "dd/MM/yyyy", SA);
                        DateTime b = DateTime.ParseExact(a, "dd/MM/yyyy", null);


                        DateTime b2 = DateTime.ParseExact(a, "dd/MM/yyyy", null);
                        DateTime dtNOW = DateTime.Now;
                        dtNOW.ToString("dd/MM/yyyy");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("dd/MM/yyyy");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(708);
                        ExpiryDateHijri = b2.ToString("dd/MM/yyyy");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("dd/MM/yyyy");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(708);
                        ExpiryDateENP = toGegorian.ToString("dd/MM/yyyy");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = DateTime.ParseExact(ExpiryDateENP, "dd/MM/yyyy", null);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                        if (numberOfDays <= 0)
                        {
                            Remaininglbl.Text = "Expired";

                        }
                        else
                        {
                            Remaininglbl.Text = numberOfDays.ToString();

                        }

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

                    if (issuhijritxt.SelectedText.Contains("-") == true)
                    {
                        MessageBox.Show("Please type date in format : " + "dd/MM/yyyy" + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {


                        IssueDateEN = US.DateTimeFormat.ShortDatePattern;



                        /*calculate issu hijir and milaidy  date**/

                        string a = issuhijritxt.Text.Trim();
                        a = issuhijritxt.Text.TrimStart();
                        a = issuhijritxt.Text.TrimEnd();
                        DateTime toGegorian = DateTime.ParseExact(a, "dd/MM/yyyy", SA);
                        DateTime b = DateTime.ParseExact(a, "dd/MM/yyyy", null);


                        DateTime b2 = DateTime.ParseExact(a, "dd/MM/yyyy", null);
                        DateTime dtNOW = DateTime.Now;
                        dtNOW.ToString("dd/MM/yyyy");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("dd/MM/yyyy");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(729);
                        ExpiryDateHijri = b2.ToString("dd/MM/yyyy");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("dd/MM/yyyy");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(709);
                        ExpiryDateENP = toGegorian.ToString("dd/MM/yyyy");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = DateTime.ParseExact(ExpiryDateENP, "dd/MM/yyyy", null);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                        if (numberOfDays <= 0)
                        {
                            Remaininglbl.Text = "Expired";

                        }
                        else
                        {
                            Remaininglbl.Text = numberOfDays.ToString();

                        }


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
                        MessageBox.Show("Please type date in format : " + "dd/MM/yyyy" + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        IssueDateEN = US.DateTimeFormat.ShortDatePattern;



                        /*calculate issu hijir and milaidy  date**/

                        string a = issuhijritxt.Text.Trim();
                        a = issuhijritxt.Text.TrimStart();
                        a = issuhijritxt.Text.TrimEnd();
                        var toGegorian = DateTime.ParseExact(a, "dd/MM/yyyy", SA);
                        DateTime b = Convert.ToDateTime(a);


                        DateTime b2 = Convert.ToDateTime(a);
                        DateTime dtNOW = DateTime.Now;
                        dtNOW.ToString("dd/MM/yyyy");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("dd/MM/yyyy");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(708);
                        ExpiryDateHijri = b2.ToString("dd/MM/yyyy");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("dd/MM/yyyy");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(708);
                        ExpiryDateENP = toGegorian.ToString("dd/MM/yyyy");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = Convert.ToDateTime(ExpiryDateENP);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);

                        if (numberOfDays <= 0)
                        {
                            Remaininglbl.Text = "Expired";

                        }
                        else
                        {
                            Remaininglbl.Text = numberOfDays.ToString();

                        }


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
            btnUpdate.Visible = AddBtn.Visible = DeleteBtn.Visible = btnFinish.Visible = true;
            btnNew.Visible = Findbtn.Visible = false;
            ClearTextBoxes();
            VisaFrm_Load(sender, e);
            ChangeEnabled(true);
            Visanumtxt.BackColor = Color.White;
            TotalVisastxt.BackColor = Color.White;
            cmbReservedTo.Enabled = cmbCompany.Enabled = cmbcandidates.Enabled = cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = cmbAgency.Enabled = true;
           txtCRNumber.Enabled= txtsponserID.Enabled= TotalVisastxt.Enabled = RemarksTxt.Enabled = true;
            ReceviedPicker.Enabled = true;
            // set the hint text for the TextBox control
            Visanumtxt.Focus();
            //issuhijritxt.Text = "yyyy-MM-dd";

            // set the color of the hint text
            // issuhijritxt.ForeColor = Color.Gray;




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

            SqlParameter paramuser = new SqlParameter("@user", SqlDbType.NVarChar);
            paramuser.Value = CommonClass.LoginUserName;
            SqlParameter paramdatetimeLOG = new SqlParameter("@datetime", SqlDbType.NVarChar);
            paramdatetimeLOG.Value = lbldatetime.Text;
            SqlParameter parampc = new SqlParameter("@pc", SqlDbType.NVarChar);
            parampc.Value = Environment.MachineName;

            if (FileNumberID == 0)
            {
                MessageBox.Show("Please select visa number first ! " + "", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SQLCONN.OpenConection();
                    SQLCONN.ExecuteQueries("delete from  VISAJobList where filenumber=@C1", paramFilenumber);
                    SQLCONN.ExecuteQueries(" declare @max int select @max = max([filenumber]) from[VISAJobList] if @max IS NULL    SET @max = 0 DBCC CHECKIDENT('[VISAJobList]', RESEED, @max)");
                    dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from VISAJobList ");
                    SQLCONN.CloseConnection();
                    MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SQLCONN.ExecuteQueries("INSERT INTO EmployeeLog (EmployeeId, logvalue ,Oldvalue,newvalue,logdatetime,PCNAME,UserId,type) VALUES (@C1, 'Visa Info' ,'#','#',@C11,@pc,@user,'Delete')", paramFilenumber, paramdatetimeLOG, parampc, paramuser);



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
            (e.KeyChar != '/'))

            {
                e.Handled = true;
                MessageBox.Show(" this Charchter '-' was not allowed please use '/' ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void cmbcandidates_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
            SQLCONN.OpenConection();

            string query = "SELECT COMPID,COMPName_EN FROM Companies";
            cmbReservedTo.ValueMember = "COMPID";
            cmbReservedTo.DisplayMember = "COMPName_EN";
            cmbReservedTo.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);

            cmbcandidates2.ValueMember = "EmployeeID";
            cmbcandidates2.DisplayMember = "Name";
            cmbcandidates2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees]       order by EmployeeID");
            cmbcandidates.ValueMember = "EmployeeID";
            cmbcandidates.DisplayMember = "Name";
            cmbcandidates.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees] , StatusTBL where Employees.EmploymentStatusID = StatusTBL.StatusID and RefrenceID=2 and StatusTBL.StatusID = 23 order by EmployeeID");
            string query4 = "select statusid,status  from Visastatus where RefrenceID =1 or RefrenceID = 0 order by statusid";
            cmbStatus.ValueMember = "statusid";
            cmbStatus.DisplayMember = "status";
            cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query4);
            string query2 = "SELECT JobID, JobTitleEN FROM JOBS";

            cmbJob.ValueMember = "JobID";
            cmbJob.DisplayMember = "JobTitleEN";
            cmbJob.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query2);
            cmbAgency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAgency.ValueMember = "AgencID";
            cmbAgency.DisplayMember = "AgenceName";
            cmbAgency.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select AgencID,AgenceName  from Agencies /*order by AgencID*/ ");
            string query3 = "select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId";
            cmbConsulate.ValueMember = "Consulates.ConsulateID";
            cmbConsulate.DisplayMember = "ConsulateCity";
            cmbConsulate.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query3);



         






            if (e.RowIndex == -1) return;

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


                        //  MessageBox.Show(dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());                      



                        object cell5Value = rw.Cells[5].Value;
                        object cell6Value = rw.Cells[6].Value;
                        object cell7Value = rw.Cells[7].Value;
                        if (cell5Value != null && cell5Value != DBNull.Value && !string.IsNullOrEmpty(cell5Value.ToString()))
                        {

                            cmbcandidates.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());
                            cmbcandidates2.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());

                        }

                        if (cell6Value != null && cell6Value != DBNull.Value && !string.IsNullOrEmpty(cell6Value.ToString()))
                        {
                            cmbAgency.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString());

                        }

                        if (cell7Value != null && cell7Value != DBNull.Value && !string.IsNullOrEmpty(cell7Value.ToString()))
                        {
                            cmbReservedTo.SelectedValue = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString());

                        }
                        else
                        {
                            cmbcandidates.Text = "Select";
                            cmbcandidates2.Text = "Select";
                            cmbAgency.SelectedValue = 0;
                            cmbReservedTo.SelectedValue = 0;

                        }



                        /*update job consule for Mr.saleem/Amin*/
                            if (CommonClass.EmployeeID == 179 || CommonClass.EmployeeID ==248)
                            {

                            VisaFileNumberID.Text = FileNumberID.ToString();
                            cmbConsulate.Enabled = cmbJob.Enabled = true;
                            cmbReservedTo.Enabled = cmbStatus.Enabled = cmbcandidates.Enabled = cmbAgency.Enabled = true;
                            btnnewJob.Enabled = false;
                            btnUpdate.Visible = true;
                        }
                        else
                        {
                            VisaFileNumberID.Text = FileNumberID.ToString();
                            cmbConsulate.Enabled = cmbJob.Enabled = false;
                            cmbReservedTo.Enabled = cmbStatus.Enabled = cmbcandidates.Enabled = cmbAgency.Enabled = true;
                            btnnewJob.Enabled = false;
                            btnUpdate.Visible = true;
                        }




                    }
                }
            }
            SQLCONN.CloseConnection();
        }
    
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView3.Visible = false;
            if (e.RowIndex == -1) return;

            dataGridView2.Visible = true;

            SQLCONN.OpenConection();
            string query = "SELECT COMPID,COMPName_EN FROM Companies";
            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
            SQLCONN.CloseConnection();

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
                        object cell2Value = rw.Cells[2].Value;
                        object cell3Value = rw.Cells[3].Value;
                        object cell4Value = rw.Cells[4].Value;
                        object cell5Value = rw.Cells[5].Value;
                        object cell6Value = rw.Cells[6].Value;
                        if (cell2Value != null && cell2Value != DBNull.Value && !string.IsNullOrEmpty(cell2Value.ToString()))
                        {
                            ReceviedPicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                        }
                        if (cell3Value != null && cell3Value != DBNull.Value && !string.IsNullOrEmpty(cell3Value.ToString()))
                        {
                            issuhijritxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                        }
                        if (cell4Value != null && cell4Value != DBNull.Value && !string.IsNullOrEmpty(cell4Value.ToString()))
                        {
                            IssueDateENTxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                        }
                        if (cell5Value != null && cell5Value != DBNull.Value && !string.IsNullOrEmpty(cell5Value.ToString()))
                        {
                            ExpiaryHijritxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        }
                        if (cell6Value != null && cell6Value != DBNull.Value && !string.IsNullOrEmpty(cell6Value.ToString()))
                        {
                            expairENDATEtxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                        }


                        VisaNumberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        cmbCompany.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
         
                        TotalVisastxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                        RemarksTxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                        txtCRNumber.Text = (dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString());
                        txtsponserID.Text = (dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString());

                        dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISAJobList where visanumber=" + VisaNumberID + " ");

                    }
                      Visanumtxt.Text = VisaNumberID.ToString();

                 



                    ///*calculate the */

                    string a = issuhijritxt.Text.Trim();
                    a = issuhijritxt.Text.TrimStart();
                    a = issuhijritxt.Text.TrimEnd();
                    DateTime toGegorian;
                    DateTime b, b2, dtNOW;
                  //  MessageBox.Show(a);
                    if (a != "" && a != null)
                    {
                         toGegorian = DateTime.ParseExact(a, "dd/MM/yyyy", SA);
                         b = DateTime.ParseExact(a, "dd/MM/yyyy", null);


                          b2 = DateTime.ParseExact(a, "dd/MM/yyyy", null);
                         dtNOW = DateTime.Now;
                        dtNOW.ToString("dd/MM/yyyy");

                        issuhijritxt.Text = b.ToString("f");
                        IssueDateHijri = b.Date.ToString("dd/MM/yyyy");
                        issuhijritxt.Text = IssueDateHijri.ToString();
                        /*calculate expairy hiri date**/


                        b2 = b2.Date.AddDays(709);
                        ExpiryDateHijri = b2.ToString("dd/MM/yyyy");
                        ExpiaryHijritxt.Text = ExpiryDateHijri.ToString();


                        /*calculate issu milaidy  date**/
                        IssueDateEN = toGegorian.ToString();
                        IssueDateEN = toGegorian.ToString("dd/MM/yyyy");
                        IssueDateENTxt.Text = IssueDateEN;





                        ///*calculate expairy milaidy date**/
                        toGegorian = toGegorian.AddDays(709);
                        ExpiryDateENP = toGegorian.ToString("dd/MM/yyyy");
                        expairENDATEtxt.Text = ExpiryDateENP;


                        ///*calculate the */

                        DateTime futurDate = DateTime.ParseExact(ExpiryDateENP, "dd/MM/yyyy", null);
                        var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);

                        if (numberOfDays <= 0)
                        {
                            Remaininglbl.Text = "Expired";

                        }
                        else
                        {
                            Remaininglbl.Text = numberOfDays.ToString();

                        }
                    }
                    else 
                    {
                         toGegorian = DateTime.Now;
                        b = DateTime.Now; b2 = DateTime.Now; dtNOW = DateTime.Now;
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
            SqlParameter paramAgency = new SqlParameter("@C3", SqlDbType.NVarChar);
            paramAgency.Value = cmbAgency.SelectedValue;
         



            if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                SQLCONN.OpenConection();
                SQLCONN.ExecuteQueries("update  VISAJobList set EmployeeID=@C1,AgencyID=@C3 where FileNumber=@C2",
                                              paramPID, paramFilenumber,paramAgency);
                MessageBox.Show("File Number / Agency Has been Assigned Successfully   ");
                VisaFileNumberID.Text = "";
                //cmbcandidates.Text = "Select";
                //cmbAgency.Text = "Select";


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
           // this.Hide();
            frmJobs.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
       

            SqlParameter paramRecevidDate = new SqlParameter("@C1", SqlDbType.Date);
            paramRecevidDate.Value = ReceviedPicker.Value;
        
            SqlParameter paramIssHIJriDate = new SqlParameter("@C2", SqlDbType.NVarChar);
            paramIssHIJriDate.Value = issuhijritxt.Text;

       

           
            SqlParameter paramVisaID = new SqlParameter("@id", SqlDbType.Int);
            paramVisaID.Value = VisaNumberID;

            SqlParameter paramFileNumberID = new SqlParameter("@FileNumberid", SqlDbType.Int);
            paramFileNumberID.Value = FileNumberID;



            SqlParameter paramVisanumber = new SqlParameter("@C3", SqlDbType.Int);
            paramVisanumber.Value = Visanumtxt.Text;
            SqlParameter paramstatusID = new SqlParameter("@C4", SqlDbType.NVarChar);
            paramstatusID.Value = cmbStatus.SelectedValue;
            SqlParameter ParamConsulate = new SqlParameter("@C5", SqlDbType.NVarChar);
            ParamConsulate.Value = cmbConsulate.SelectedValue;
            SqlParameter paramJob = new SqlParameter("@C6", SqlDbType.NVarChar);
            paramJob.Value = cmbJob.SelectedValue;
            SqlParameter paramAgency = new SqlParameter("@C7", SqlDbType.NVarChar);
            paramAgency.Value = cmbAgency.SelectedValue;
            SqlParameter paramCandidate = new SqlParameter("@C8", SqlDbType.NVarChar);
            paramCandidate.Value = cmbcandidates.SelectedValue;
            SqlParameter paramCandidate2 = new SqlParameter("@C9", SqlDbType.NVarChar);
            paramCandidate2.Value = cmbcandidates2.SelectedValue;

            paramReservedTo.Value = cmbReservedTo.SelectedValue;









            if (VisaNumberID != 0 & FileNumberID != 0)
            {

               
         
                if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {


                    SQLCONN.OpenConection();


                    /**logtable */
                    DataTable originalData = new DataTable();
                    string connectionString = SQLCONN.ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM VISAJobList WHERE FileNumber = @FileNumberid";
                        SqlDataAdapter da = new SqlDataAdapter(sql, connection);
                        da.SelectCommand.Parameters.AddWithValue("@FileNumberid", FileNumberID);
                        originalData = new DataTable();
                        da.Fill(originalData);
                    }
                    if ((int)cmbcandidates.SelectedIndex == -1)
                    {

                        SQLCONN.ExecuteQueries("update VISAJobList set StatusID=@C4,[EmployeeID]=@C9,AgencyID=@C7 ,[ConsulateID] = @C5,[JobID] = @C6 ,ReservedTo=@CompReservedTo where FileNumber=@FileNumberid",
                       paramstatusID, paramCandidate2, paramAgency, ParamConsulate, paramJob, paramReservedTo, paramFileNumberID);

                    }
                    else
                    {
                        SQLCONN.ExecuteQueries("update VISAJobList set StatusID=@C4,[EmployeeID]=@C8,AgencyID=@C7 ,[ConsulateID] = @C5,[JobID] = @C6 ,ReservedTo=@CompReservedTo where FileNumber=@FileNumberid",
                     paramstatusID, paramCandidate, paramAgency, ParamConsulate, paramJob, paramReservedTo, paramFileNumberID);

                    }

                       MessageBox.Show("Record Updated Successfully");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM VISAJobList WHERE FileNumber = @FileNumberid";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        adapter.SelectCommand.Parameters.AddWithValue("@FileNumberid", FileNumberID);
                        DataTable updatedData = new DataTable();
                        adapter.Fill(updatedData);

                        // Compare the two DataTables and find the changed columns
                        List<string> changedColumns = new List<string>();
                        foreach (DataColumn column in originalData.Columns)
                        {
                            object originalValue = originalData.Rows[0][column.ColumnName];
                            object updatedValue = updatedData.Rows[0][column.ColumnName];
                            if (!Equals(originalValue, updatedValue) && (originalValue != null || updatedData != null))
                            {
                                changedColumns.Add(column.ColumnName);
                            }
                        }

                        // Insert the changes into the log table
                        if (changedColumns.Count > 0)
                        {
                            using (SqlCommand command = new SqlCommand("INSERT INTO EmployeeLog (Logvalueid, logvalue, OldValue, NewValue,logdatetime,PCNAME,UserId,type) VALUES (@FileNumberid, @ColumnName, @OldValue, @NewValue,@datetime,@pc,@user,@type)", connection))
                            {
                                command.Parameters.AddWithValue("@FileNumberid", FileNumberID);
                                foreach (string columnName in changedColumns)
                                {
                                    object originalValue = originalData.Rows[0][columnName];
                                    object updatedValue = updatedData.Rows[0][columnName];
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@FileNumberid", FileNumberID +" - " + "Visa");
                                    command.Parameters.AddWithValue("@ColumnName", columnName);
                                    command.Parameters.AddWithValue("@OldValue", originalValue);
                                    command.Parameters.AddWithValue("@NewValue", updatedValue);
                                    command.Parameters.AddWithValue("@datetime", lbldatetime.Text);
                                    command.Parameters.AddWithValue("@pc", Environment.MachineName);
                                    command.Parameters.AddWithValue("@user", CommonClass.LoginUserName);
                                    command.Parameters.AddWithValue("@type", "Update");
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }



                    dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from VISAJobList where FileNumber = '" + FileNumberID + "'");
                    SQLCONN.CloseConnection();
                    /**logtable */


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

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void CmbReqierdJob_KeyDown(object sender, KeyEventArgs e)
        {

            //CmbReqierdJob.ValueMember = "JobID";
            //CmbReqierdJob.DisplayMember = "JobTitleEN";
            //CmbReqierdJob.DataSource = SQLCONN.ShowDataInGridViewORCombobox("SELECT JobID,JobTitleEN FROM JOBS");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbldatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAgencyNew frmAgency = new FrmAgencyNew();
            // this.Hide();
            frmAgency.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmbAgency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                string searchText = cmbAgency.Text.Trim();

                if (!string.IsNullOrEmpty(searchText))
                {
                    foreach (var item in cmbAgency.Items)
                    {
                        if (item.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase))
                        {
                            cmbAgency.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private void cmbAgency_TextChanged(object sender, EventArgs e)
        {
        }
        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCompany_SelectionChangeCommitted(object sender, EventArgs e)
        {

          SQLCONN.OpenConection();
          SqlDataReader  dr = SQLCONN.DataReader("SELECT ID_Number,CRNumber FROM [DelmonGroupDB].[dbo].[Companies] where  COMPID=" + cmbCompany.SelectedValue +" ");
            if (dr.Read())
            {
                txtsponserID.Text = dr["ID_Number"].ToString();
                txtCRNumber.Text = dr["CRNumber"].ToString();
            }
            SQLCONN.CloseConnection();   
        }

        private void button3_Click(object sender, EventArgs e)
        {


          


        }

        private void cmbcandidates2_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbcandidates_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbcandidates_DropDown(object sender, EventArgs e)
        {
            cmbcandidates.DropDownStyle = ComboBoxStyle.DropDownList;
            SQLCONN.OpenConection();
            cmbcandidates.ValueMember = "EmployeeID";
            cmbcandidates.DisplayMember = "Name";
            cmbcandidates.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees] , StatusTBL where Employees.EmploymentStatusID = StatusTBL.StatusID and RefrenceID=2 and StatusTBL.StatusID = 23 order by EmployeeID");
            cmbcandidates.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();
        }

        private void cmbJob_DropDown(object sender, EventArgs e)
        {
            cmbJob.DropDownStyle = ComboBoxStyle.DropDownList;

            string query2 = "SELECT JobID, JobTitleEN FROM JOBS";
            SQLCONN.OpenConection();

            cmbJob.ValueMember = "JobID";
            cmbJob.DisplayMember = "JobTitleEN";
            cmbJob.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query2);
          //  cmbJob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
          //  cmbJob.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();

        }

        private void cmbAgency_DropDown(object sender, EventArgs e)
        {
            cmbAgency.DropDownStyle = ComboBoxStyle.DropDownList;

            SQLCONN.OpenConection();
            cmbAgency.ValueMember = "AgencID";
            cmbAgency.DisplayMember = "AgenceName";
            cmbAgency.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select AgencID,AgenceName  from Agencies /*order by AgencID*/ ");
          //  cmbAgency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
         //   cmbAgency.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();


        }

        private void cmbStatus_DropDown(object sender, EventArgs e)
        {
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            SQLCONN.OpenConection();
            string query4 = "select statusid,status  from Visastatus where RefrenceID =1 or RefrenceID = 0 order by statusid";

            cmbStatus.ValueMember = "statusid";
            cmbStatus.DisplayMember = "status";
            cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query4);
           // cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           // cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();
        }

        private void cmbConsulate_DropDown(object sender, EventArgs e)
        {
            cmbConsulate.DropDownStyle = ComboBoxStyle.DropDownList;

            SQLCONN.OpenConection();

            string query3 = "select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId";

            cmbConsulate.ValueMember = "Consulates.ConsulateID";
            cmbConsulate.DisplayMember = "ConsulateCity";
            cmbConsulate.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query3);
           // cmbConsulate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           // cmbConsulate.AutoCompleteSource = AutoCompleteSource.ListItems;

            SQLCONN.CloseConnection();

        }

        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            cmbCompany.DropDownStyle = ComboBoxStyle.DropDown;
            SQLCONN.OpenConection();
            string query = "SELECT COMPID,COMPName_EN FROM Companies";
            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
            // cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();




        }

        private void cmbReservedTo_DropDown(object sender, EventArgs e)
        {
            cmbReservedTo.DropDownStyle = ComboBoxStyle.DropDown;
            SQLCONN.OpenConection();
            string query = "SELECT COMPID,COMPName_EN FROM Companies";
            cmbReservedTo.ValueMember = "COMPID";
            cmbReservedTo.DisplayMember = "COMPName_EN";
            cmbReservedTo.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
            // cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();
        }

        private void cmbCompany_MouseDown(object sender, MouseEventArgs e)
        {
            cmbCompany.DropDownStyle = ComboBoxStyle.DropDown;
            SQLCONN.OpenConection();
            string query = "SELECT COMPID,COMPName_EN FROM Companies";
            cmbCompany.ValueMember = "COMPID";
            cmbCompany.DisplayMember = "COMPName_EN";
            cmbCompany.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
            // cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();


        }

        private void cmbReservedTo_MouseDown(object sender, MouseEventArgs e)
        {
            cmbReservedTo.DropDownStyle = ComboBoxStyle.DropDown;
            SQLCONN.OpenConection();
            string query = "SELECT COMPID,COMPName_EN FROM Companies";
            cmbReservedTo.ValueMember = "COMPID";
            cmbReservedTo.DisplayMember = "COMPName_EN";
            cmbReservedTo.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query);
            // cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();
        }

        private void cmbConsulate_MouseDown(object sender, MouseEventArgs e)
        {
            cmbConsulate.DropDownStyle = ComboBoxStyle.DropDownList;

            SQLCONN.OpenConection();

            string query3 = "select Consulates.ConsulateID,ConsulateCity from Countries,Consulates where Countries.CountryId = Consulates.CountryId";

            cmbConsulate.ValueMember = "Consulates.ConsulateID";
            cmbConsulate.DisplayMember = "ConsulateCity";
            cmbConsulate.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query3);
            // cmbConsulate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // cmbConsulate.AutoCompleteSource = AutoCompleteSource.ListItems;

            SQLCONN.CloseConnection();
        }

        private void cmbJob_MouseDown(object sender, MouseEventArgs e)
        {
            cmbJob.DropDownStyle = ComboBoxStyle.DropDownList;

            string query2 = "SELECT JobID, JobTitleEN FROM JOBS";
            SQLCONN.OpenConection();

            cmbJob.ValueMember = "JobID";
            cmbJob.DisplayMember = "JobTitleEN";
            cmbJob.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query2);
            //  cmbJob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //  cmbJob.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();
        }

        private void cmbStatus_MouseDown(object sender, MouseEventArgs e)
        {
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            SQLCONN.OpenConection();
            string query4 = "select statusid,status  from Visastatus where RefrenceID =1 or RefrenceID = 0 order by statusid";

            cmbStatus.ValueMember = "statusid";
            cmbStatus.DisplayMember = "status";
            cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox(query4);
            // cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();
        }

        private void cmbAgency_MouseDown(object sender, MouseEventArgs e)
        {
            cmbAgency.DropDownStyle = ComboBoxStyle.DropDownList;

            SQLCONN.OpenConection();
            cmbAgency.ValueMember = "AgencID";
            cmbAgency.DisplayMember = "AgenceName";
            cmbAgency.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select AgencID,AgenceName  from Agencies /*order by AgencID*/ ");
            //  cmbAgency.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //   cmbAgency.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();

        }

        private void cmbcandidates_MouseDown(object sender, MouseEventArgs e)
        {
            cmbcandidates.DropDownStyle = ComboBoxStyle.DropDownList;
            SQLCONN.OpenConection();
            cmbcandidates.ValueMember = "EmployeeID";
            cmbcandidates.DisplayMember = "Name";
            cmbcandidates.DataSource = SQLCONN.ShowDataInGridViewORCombobox("  SELECT Employees.EmployeeID, RTRIM(LTRIM(CONCAT(COALESCE(FirstName + ' ', ''), COALESCE([SecondName] + ' ', '') ,COALESCE(ThirdName + ' ', ''), COALESCE(Lastname, '')))) AS Name  FROM [DelmonGroupDB].[dbo].[Employees] , StatusTBL where Employees.EmploymentStatusID = StatusTBL.StatusID and RefrenceID=2 and StatusTBL.StatusID = 23 order by EmployeeID");
            cmbcandidates.AutoCompleteSource = AutoCompleteSource.ListItems;
            SQLCONN.CloseConnection();
        }

        private void btnwexpire_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            SQLCONN.OpenConection();
            dataGridView3.DataSource = SQLCONN.ShowDataInGridViewORCombobox(@"SELECT
    visa.VisaNumber,
    ExpiryDateEN as ExpiryDate
FROM
    Visa, VISAJobList
WHERE
    VISAJobList.StatusID != 6
    AND DATEDIFF(MONTH, GETDATE(), CONVERT(DATE, ExpiryDateEN, 103)) <= 1
    AND CONVERT(DATE, ExpiryDateEN, 103) > GETDATE() -- Check if the visa has not yet expired
GROUP BY
    visa.VisaNumber, ExpiryDateEN;");
            SQLCONN.CloseConnection();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            foreach (DataGridViewRow rw in this.dataGridView3.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                  VisaNumberID = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                 }
                    Visanumtxt.Text = VisaNumberID.ToString();    
                }
            }

        }
    }
    





