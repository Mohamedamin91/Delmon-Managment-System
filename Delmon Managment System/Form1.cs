using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
    public partial class FormMainMenu : Form
    {
        
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public FormMainMenu()
        {
            InitializeComponent();
           
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
                    //   Color color = SelectThemeColor();
                    //   Color color = Color.FromArgb(178,34,34);
                       Color color = Color.White;
                    //currentButton = (Button)btnSender;
                    //currentButton.BackColor = color;
                    //currentButton.ForeColor = Color.White;
                    //currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //panelTitleBar.BackColor = color;
                    //lblTitle.BackColor = color;
                  //  panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                  //  ThemeColor.PrimaryColor = color;
                  //  ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
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
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        private void Form1_Load(object sender, EventArgs e)
        {
            panelTitleBar.BackColor = Color.FromArgb(235, 45, 46);
            lblTitle.BackColor = Color.FromArgb(235, 45, 46);
          
        }

        private void btnvisa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.VisaFrm(), sender);
         }

        private void btnemployee_Click(object sender, EventArgs e)
        {
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
            OpenChildForm(new Forms.NotificationFrm(), sender);

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
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinum_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.SettingFrm(), sender);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }
    }
}
