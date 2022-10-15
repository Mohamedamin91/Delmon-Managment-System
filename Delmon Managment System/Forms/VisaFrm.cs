﻿using Ninject.Activation;
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

namespace Delmon_Managment_System.Forms
{
    public partial class VisaFrm : Form
    {

        SQLCONNECTION SQLCONN = new SQLCONNECTION();
        int Totatvisa = 0;
        int i = 0;


        public VisaFrm()
        {


            InitializeComponent();

            Application.CurrentCulture = new CultureInfo("ar-SA");
            ExpiryDateHijriPicker.Format = DateTimePickerFormat.Custom;






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
            cmbStatus.DataSource = SQLCONN.ShowDataInGridViewORCombobox("select statusid,status from status ");



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

                //  CountryID = int.Parse(dr["CountryId"].ToString());
                if (dr.HasRows)
                {
                    MessageBox.Show("This 'VISA NUMBER'  Already Exists. !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStatus.Enabled = cmbJob.Enabled = cmbConsulate.Enabled = false;

                }
                else
                {
                    SqlParameter paramVisanumber = new SqlParameter("@C1", SqlDbType.Int);
                    paramVisanumber.Value = Visanumtxt.Text;
                    SqlParameter paramstatusID = new SqlParameter("@C2", SqlDbType.NVarChar);
                    paramstatusID.Value = cmbStatus.SelectedValue;
                    SqlParameter ParamConsulate = new SqlParameter("@C3", SqlDbType.NVarChar);
                    ParamConsulate.Value = cmbConsulate.SelectedValue;
                    SqlParameter paramJob = new SqlParameter("@C4", SqlDbType.NVarChar);
                    paramJob.Value = cmbJob.SelectedValue;


                    dr.Dispose();
                    dr.Close();

                    Totatvisa = int.Parse(TotalVisastxt.Text);
                    if (i < Totatvisa)

                    {
                        dr.Dispose();
                        dr.Close();
                        if (DialogResult.Yes == MessageBox.Show("Do You Want to perform this operation ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            SQLCONN.ExecuteQueries("insert into VISAJobList (VisaNumber,statusid,ConsulateID,JobID) " +
                                " values (@C1,@C2,@C3,@C4) ",
                                paramVisanumber, paramstatusID, ParamConsulate, paramJob);

                            MessageBox.Show("Operation has been done successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox("Select * From VISAJobList ");
                            i = i + 1;


                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        MessageBox.Show("You have exceeded the number allowed to issue visas for Visa No: " + Visanumtxt.Text + " ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TotalVisastxt.Enabled = false;
                    }


                }

                SQLCONN.CloseConnection();
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
                            ClearTextBoxes();

                        }
                        else
                        {
                            //  SQLCONN.CloseConnection();
                        }

                    }
                   
                      
                    
                
                dr.Dispose();
                dr.Close();
                SQLCONN.CloseConnection();
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
                msg.From = new MailAddress("m.amin@delmon.com.sa");
                msg.To.Add("waleed@delmon.com.sa");
                msg.Subject = "Test";
                msg.Body = "Hello";

                SmtpClient smt = new SmtpClient();
                smt.Host = "mail.delmon-its.com.sa";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "dgsqlserver@delmon-its.com.sa";
                ntcd.Password = "Ram73763@";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);

                MessageBox.Show("Your Mail is sended");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}



