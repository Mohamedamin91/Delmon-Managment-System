using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Delmon_Managment_System
{
    public partial class FormMainMenu : Form
    {


        SQLCONNECTION sqlconn = new SQLCONNECTION();

        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public FormMainMenu()
        {
            InitializeComponent();
            Font newFont = new Font("Times New Roman", 12);

            // Loop through all controls on the form and change their font properties
            foreach (Control control in Controls)
            {
                control.Font = newFont;
            }
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                       btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                  //  previousBtn.BackColor = Color.FromArgb(53, 52, 141);
                    previousBtn.BackColor = Color.White;
                    previousBtn.ForeColor = Color.FromArgb(53, 52, 141);
                 //   previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        public void ShowNotification()
        {
            PopupNotifier Popup = new PopupNotifier();
            Popup.BodyColor = Color.White; // Change this to the desired color
            Popup.HeaderColor = Color.Firebrick; // Change this to the desired color
            Popup.BorderColor = Color.White; // Change this to the desired color
            Popup.TitleColor = Color.DarkBlue; // Change this to the desired color
            Popup.TitleText = "You have new notification - VISAS Expired Soon";
            Popup.ContentText = "Kindly check the Visa screen - Expired Button";
            Popup.Image = Properties.Resources.Delmonlogo2;
            Popup.TitleFont = new Font(Popup.TitleFont.FontFamily, Popup.TitleFont.Size + 1); // Adjust the size increase (2 in this example)
            Popup.ContentFont = new Font(Popup.ContentFont.FontFamily, Popup.ContentFont.Size + 4); // Adjust the size increase (2 in this example)
            Popup.Popup();

          

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlconn.OpenConection();
            SqlDataReader dr=sqlconn.DataReader(@"SELECT
    visa.VisaNumber,
    visa.ExpiryDateEN AS ExpiryDate
FROM
    Visa
INNER JOIN
    VISAJobList ON Visa.VisaNumber = VISAJobList.VisaNumber
WHERE
    VISAJobList.StatusID != 6
    and DATEDIFF(MONTH, GETDATE(), CONVERT(DATE, visa.ExpiryDateEN, 103)) <= 1
    AND CONVERT(DATE, visa.ExpiryDateEN, 103) > GETDATE() -- Check if the visa has not yet expired with one /M
GROUP BY
    visa.VisaNumber, visa.ExpiryDateEN;");
            if (dr.HasRows)
            {
                ShowNotification();
            }
            sqlconn.CloseConnection();
            panelTitleBar.BackColor = Color.Firebrick;
          //  panelTitleBar.BackColor = Color.FromArgb(235, 45, 46);
            lblTitle.BackColor = Color.Firebrick;
            lblusername.Text = CommonClass.LoginUserName;
            lblusertype.Text = CommonClass.Usertype;
            lblemail.Text = CommonClass.Email;
            lblFullname.Text = CommonClass.LoginEmployeeName;
            lblPC.Text = Environment.MachineName;
            this.timer1.Interval = 1000;
            timer1.Start();

        }

        private void btnvisa_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;

            //if (lblusertype.Text == "Admin")
            //{
                OpenChildForm(new Forms.VisaFrm(), sender);
            //}
            //else
            //{
            //    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
         }

        private void btnemployee_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;

            OpenChildForm(new Forms.EmployeeForm(), sender);

        }

        private void btnprinting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.PrintingFrm(), sender);

        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BillsFrm(), sender);

        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new Forms.NotificationFrm(), sender);

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.SettingFrm(), sender);

        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(178,34,34);
            lblTitle.BackColor = Color.FromArgb(178,34,34);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelDesktopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BTNcLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinum_Click_1(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.StartPosition = FormStartPosition.CenterParent; // Center the form on the screen
            }
            else
                this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent; // Center the form on the screen


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            //if (lblusertype.Text == "Admin")
            //{
                OpenChildForm(new Forms.SettingFrm(), sender);
            //}
            //else 
            //{
            //    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          //  this.lbldatetime.Text = DateTime.Now.ToString("dd-MMM-yyyy  hh:mm:ss tt");

        }

        private void btnBilling_Click_1(object sender, EventArgs e)
        {
            //if (lblusertype.Text != "Admin")
            //{

            //    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            //}
            //else
            //{
              OpenChildForm(new Forms.BillsFrm(), sender);
            //}

        }

        private void btnprinting_Click_1(object sender, EventArgs e)
        {
            if (lblusertype.Text != "Admin")
            {

                MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {
                OpenChildForm(new Forms.PrintingFrm(), sender);
            }

        }

        private void btnemployee_Click_1(object sender, EventArgs e)
        {
            //if (lblusertype.Text != "Admin")
            //{

            //    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            //}
            //else
            //{
            //    groupBox1.Visible = false;

                OpenChildForm(new Forms.EmployeeForm(), sender);
            //}
        }

        private void btnvisa_Click_1(object sender, EventArgs e)
        {
            //groupBox1.Visible = false;

            //if (lblusertype.Text == "Admin")
            //{
               OpenChildForm(new Forms.VisaFrm(), sender);
            //}
            //else
            //{
            //    MessageBox.Show("Sorry This Section for Admin Only  !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AssetFrm(), sender);

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.SettingFrm(), sender);

        }

        private void btnNotifications_Click_1(object sender, EventArgs e)
        {
          //  OpenChildForm(new Forms.NotificationFrm(), sender);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Restart();

        }
    }
}
