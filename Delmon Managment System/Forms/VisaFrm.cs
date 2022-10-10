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

namespace Delmon_Managment_System.Forms
{
    public partial class VisaFrm : Form
    {
        public VisaFrm()
        {
            InitializeComponent();
            Application.CurrentCulture = new CultureInfo("ar-SA");
            IssueDateHijriPicker.Format = DateTimePickerFormat.Custom;
            Application.CurrentCulture = new CultureInfo("ar-SA");
            ExpiryDateHijriPicker.Format = DateTimePickerFormat.Custom;

            //Application.CurrentCulture = new CultureInfo("en-US");
            //IssueDateENPicker.Format = DateTimePickerFormat.Custom;
            //Application.CurrentCulture = new CultureInfo("en-US");
            //ExpiryDateENPicker.Format = DateTimePickerFormat.Custom;


            //     IssueDateHijriPicker.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;
        }

        private void VisaFrm_Load(object sender, EventArgs e)
        {
            LoadTheme();
          //  issueHijritxt.Text = "dd/MM/yyyy .....";

          //  (textBox2.Text) = ConvertDateCalendar(Convert.ToDateTime(textBox3.Text), "Gregorian", "en-US");




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
            //label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void visasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    
        private void IssueDateHijriPicker_ValueChanged(object sender, EventArgs e)
        {
         //   CultureInfo ci = new CultureInfo("en-US");


           

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
            if (issuhijritxt.Text != "")
            {
                /*calculate issu hijir and milaidy  date**/

                string a = issuhijritxt.Text.Trim();
                DateTime b = Convert.ToDateTime(a);
                issuhijritxt.Text = b.ToShortDateString();
                IssueDateENPicker.Value = b;
                IssueDateENPicker.Value.ToString("yyyy/MM/dd");
                IssueDateENTxt.Text = IssueDateENPicker.Text;

                /*calculate expairy en date**/
                this.ExpiryDateENPicker.Value = IssueDateENPicker.Value.AddYears(2);
                expairENDATEtxt.Text = ExpiryDateENPicker.Text;

                /*calculate expairy hiri date**/


                this.ExpiryDateHijriPicker.Value = IssueDateHijriPicker.Value.AddYears(2);
                ExpiryDateHijriPicker.Value.ToString("yyyy/MM/dd");
                ExpiaryHijritxt.Text = ExpiryDateHijriPicker.Value.ToString("yyyy/MM/dd");
            }
            else { }
            
          










        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

