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


        public VisaFrm()
        {


            InitializeComponent();

            Application.CurrentCulture = new CultureInfo("ar-SA");
            ExpiryDateHijriPicker.Format = DateTimePickerFormat.Custom;
            cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbConsulate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbConsulate.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbJob.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbJob.AutoCompleteSource = AutoCompleteSource.ListItems;







        }


        private void VisaFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
         
       

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



            SQLCONN.CloseConnection();




        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label4.ForeColor = ThemeColor.SecondaryColor;
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
            IssueDateENPicker.Value = DateTime.Now;
            ExpiryDateENPicker.Value = DateTime.Now;
            ReceviedPicker.Value = DateTime.Now;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = false;
            i = 0;
            Remaininglbl.Text = "";
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {

            if (TotalVisastxt.Text != "")
            {
                cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = true;
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
                        MessageBox.Show("This 'VISA NUMBER'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = false;
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
                        }


                        TotalVisastxt.Enabled = false;


                    }

                    SQLCONN.CloseConnection();
                    VisaFrm_Load(sender, e);

                }







            }
            else
            {
                MessageBox.Show("Please insert 'TOTAL VISA' !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TotalVisastxt.BackColor = Color.Red;
                cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = false;

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
            if (issuhijritxt.Text == "dd/MM/yyyy")
            {
                issuhijritxt.Text = "";
                issuhijritxt.ForeColor = Color.Black;
            }



        }



        private void issuhijritxt_TextChanged(object sender, EventArgs e)
        {
            Application.CurrentCulture = new CultureInfo("ar-SA");
            IssueDateHijriPicker.Format = DateTimePickerFormat.Custom;
            if (issuhijritxt.Text == "dd/MM/yyyy")
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
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from visa where  VisaNumber LIKE '" + Visanumtxt.Text + "%'");
            SQLCONN.CloseConnection();
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[6].Visible = false;
            this.dataGridView1.Columns[8].Visible = false;


            dataGridView1.Visible = true;
        }

        private void Visanumtxt_Leave(object sender, EventArgs e)
        {
         
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (Visanumtxt.Text != "")
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
                    SqlParameter paramIssueDateEN = new SqlParameter("@C5", SqlDbType.Date);
                    paramIssueDateEN.Value = IssueDateENPicker.Value;
                    SqlParameter paramExpiryDateHijri = new SqlParameter("@C6", SqlDbType.NVarChar);
                    paramExpiryDateHijri.Value = ExpiaryHijritxt.Text;
                    SqlParameter paramExpiryDateEN = new SqlParameter("@C7", SqlDbType.Date);
                    paramExpiryDateEN.Value = ExpiryDateENPicker.Value;
                    SqlParameter paramTotalVisas = new SqlParameter("@C8", SqlDbType.NVarChar);
                    paramTotalVisas.Value = TotalVisastxt.Text;
                    SqlParameter paramRemarks = new SqlParameter("@C9", SqlDbType.NVarChar);
                    paramRemarks.Value = RemarksTxt.Text;
                    dr.Dispose();
                    dr.Close();
                 
                        if (DialogResult.Yes == MessageBox.Show("Do You Want to submit this info for Visa No :  " + Visanumtxt.Text + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            SQLCONN.ExecuteQueries("insert into VISA (VisaNumber,ComapnyID,ReceviedDate,IssueDateEN,ExpiryDateEN,TotalVisas,Remarks,ExpiryDateHijri,IssueDateHijri) " +
                                " values (@C1,@C2,@C3,@C5,@C7,@C8,@C9,@C6,@C4) ",
                                paramVisanumber, paramcomapany, paramRecevidDate, paramIssueDateEN, paramExpiryDateEN, paramTotalVisas, paramRemarks, paramExpiryDateHijri, paramIssHIJriDate);
                            //   SQLCONN.CloseConnection();
                            MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISA where visanumber=" + Visanumtxt.Text + " ");


                        }
                        else
                        {
                            //  SQLCONN.CloseConnection();
                        }

                    }
                   
                      
                    
                
                dr.Dispose();
                dr.Close();
                SQLCONN.CloseConnection();
                ClearTextBoxes();
                VisaFrm_Load(sender, e);
                TotalVisastxt.Enabled = false;

            }
            else 
            {
                MessageBox.Show("Please insert 'VISA NUMBER' first !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Visanumtxt.BackColor = Color.Red;

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




                    /*calculate issu hijir and milaidy  date**/

                    string a = issuhijritxt.Text.Trim();
                    DateTime b = Convert.ToDateTime(a);
                    DateTime dtNOW =DateTime.Now;
                    dtNOW.ToString("yyyy-MM-dd");

                    issuhijritxt.Text = b.ToString("f");
                    IssueDateHijriPicker.Value = b.Date;
                    issuhijritxt.Text = IssueDateHijriPicker.Value.ToString("dd-MM-yyyy");
                    /*calculate expairy hiri date**/

                    this.ExpiryDateHijriPicker.Value = b.Date.AddDays(708);
                    ExpiryDateHijriPicker.Value.ToString("dd-MM-yyyy");
                    ExpiaryHijritxt.Text = ExpiryDateHijriPicker.Value.ToString("dd-MM-yyyy");


                    /*calculate issu milaidy  date**/
                    IssueDateENPicker.Value = b;
                    IssueDateENPicker.Value.ToString("yyyy-MM-dd");
                    IssueDateENTxt.Text = IssueDateENPicker.Text;

                    /*calculate expairy milaidy date**/
                    this.ExpiryDateENPicker.Value = IssueDateENPicker.Value.AddDays(708);
                    expairENDATEtxt.Text = ExpiryDateENPicker.Text;


                    /*calculate the */

                     DateTime futurDate = Convert.ToDateTime(ExpiryDateENPicker.Value);
                     var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                    Remaininglbl.Text = numberOfDays.ToString();


                }

                else { }
            }
           else  if (e.KeyCode == Keys.Tab)
            {
                if (issuhijritxt.Text != "")
                {

                    /*calculate issu hijir and milaidy  date**/

                    string a = issuhijritxt.Text.Trim();
                    DateTime b = Convert.ToDateTime(a);
                    DateTime dtNOW = DateTime.Now;
                    dtNOW.ToString("yyyy-MM-dd");

                    issuhijritxt.Text = b.ToString("f");
                    IssueDateHijriPicker.Value = b.Date;
                    issuhijritxt.Text = IssueDateHijriPicker.Value.ToString("dd-MM-yyyy");
                    /*calculate expairy hiri date**/

                    this.ExpiryDateHijriPicker.Value = b.Date.AddDays(708);
                    ExpiryDateHijriPicker.Value.ToString("dd-MM-yyyy");
                    ExpiaryHijritxt.Text = ExpiryDateHijriPicker.Value.ToString("dd-MM-yyyy");


                    /*calculate issu milaidy  date**/
                    IssueDateENPicker.Value = b;
                    IssueDateENPicker.Value.ToString("yyyy-MM-dd");
                    IssueDateENTxt.Text = IssueDateENPicker.Text;

                    /*calculate expairy milaidy date**/
                    this.ExpiryDateENPicker.Value = IssueDateENPicker.Value.AddDays(708);
                    expairENDATEtxt.Text = ExpiryDateENPicker.Text;


                    /*calculate the */

                    DateTime futurDate = Convert.ToDateTime(ExpiryDateENPicker.Value);
                    var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                    Remaininglbl.Text = numberOfDays.ToString();
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




                    /*calculate issu hijir and milaidy  date**/

                    string a = issuhijritxt.Text.Trim();
                    DateTime b = Convert.ToDateTime(a);
                    DateTime dtNOW = DateTime.Now;
                    dtNOW.ToString("yyyy-MM-dd");

                    issuhijritxt.Text = b.ToString("f");
                    IssueDateHijriPicker.Value = b.Date;
                    issuhijritxt.Text = IssueDateHijriPicker.Value.ToString("dd-MM-yyyy");
                    /*calculate expairy hiri date**/

                    this.ExpiryDateHijriPicker.Value = b.Date.AddDays(708);
                    ExpiryDateHijriPicker.Value.ToString("dd-MM-yyyy");
                    ExpiaryHijritxt.Text = ExpiryDateHijriPicker.Value.ToString("dd-MM-yyyy");


                    /*calculate issu milaidy  date**/
                    IssueDateENPicker.Value = b;
                    IssueDateENPicker.Value.ToString("yyyy-MM-dd");
                    IssueDateENTxt.Text = IssueDateENPicker.Text;

                    /*calculate expairy milaidy date**/
                    this.ExpiryDateENPicker.Value = IssueDateENPicker.Value.AddDays(708);
                    expairENDATEtxt.Text = ExpiryDateENPicker.Text;


                    /*calculate the */

                    DateTime futurDate = Convert.ToDateTime(ExpiryDateENPicker.Value);
                    var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                    Remaininglbl.Text = numberOfDays.ToString();


                }

                else { }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (issuhijritxt.Text != "")
                {

                    /*calculate issu hijir and milaidy  date**/

                    string a = issuhijritxt.Text.Trim();
                    DateTime b = Convert.ToDateTime(a);
                    DateTime dtNOW = DateTime.Now;
                    dtNOW.ToString("yyyy-MM-dd");

                    issuhijritxt.Text = b.ToString("f");
                    IssueDateHijriPicker.Value = b.Date;
                    issuhijritxt.Text = IssueDateHijriPicker.Value.ToString("dd-MM-yyyy");
                    /*calculate expairy hiri date**/

                    this.ExpiryDateHijriPicker.Value = b.Date.AddDays(708);
                    ExpiryDateHijriPicker.Value.ToString("dd-MM-yyyy");
                    ExpiaryHijritxt.Text = ExpiryDateHijriPicker.Value.ToString("dd-MM-yyyy");


                    /*calculate issu milaidy  date**/
                    IssueDateENPicker.Value = b;
                    IssueDateENPicker.Value.ToString("yyyy-MM-dd");
                    IssueDateENTxt.Text = IssueDateENPicker.Text;

                    /*calculate expairy milaidy date**/
                    this.ExpiryDateENPicker.Value = IssueDateENPicker.Value.AddDays(708);
                    expairENDATEtxt.Text = ExpiryDateENPicker.Text;


                    /*calculate the */

                    DateTime futurDate = Convert.ToDateTime(ExpiryDateENPicker.Value);
                    var numberOfDays = Math.Round((futurDate - dtNOW).TotalDays);



                    Remaininglbl.Text = numberOfDays.ToString();
                }

                else { }
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
            AddBtn.Visible = btnFinish.Visible = true;
          //  btnNew.Visible = false;
            ClearTextBoxes();
           
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
                        cmbCompany.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        ReceviedPicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                        issuhijritxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                        IssueDateENPicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                        ExpiaryHijritxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        ExpiryDateENPicker.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                        TotalVisastxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                        RemarksTxt.Text = (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());  
                    
                      
                        dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISAJobList where visanumber=" + VisaNumberID + " ");




                    }
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.Visible = true;
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


                    }
                }
            }
        }
   


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            SqlParameter paramFilenumber = new SqlParameter("@C1", SqlDbType.Int);
            paramFilenumber.Value = FileNumberID;


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

        private void FileNumber_TextChanged_1(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();
            dataGridView2.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select * from VISAJobList where filenumber LIKE '" + FileNumber.Text + "%'");
            SQLCONN.CloseConnection();
        }
    }
}



