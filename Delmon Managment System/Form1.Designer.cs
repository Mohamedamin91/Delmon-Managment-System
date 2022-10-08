
namespace Delmon_Managment_System
{
    partial class FormMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnprinting = new System.Windows.Forms.Button();
            this.btnemployee = new System.Windows.Forms.Button();
            this.btnvisa = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.BTNcLOSE = new System.Windows.Forms.Button();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMinum = new System.Windows.Forms.Button();
            this.panelLogo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(45, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "DELMON";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.btnNotifications);
            this.panelMenu.Controls.Add(this.btnBilling);
            this.panelMenu.Controls.Add(this.btnprinting);
            this.panelMenu.Controls.Add(this.btnemployee);
            this.panelMenu.Controls.Add(this.btnvisa);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 581);
            this.panelMenu.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 382);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(200, 60);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "  Setting";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnNotifications
            // 
            this.btnNotifications.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNotifications.FlatAppearance.BorderSize = 0;
            this.btnNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotifications.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNotifications.Image = ((System.Drawing.Image)(resources.GetObject("btnNotifications.Image")));
            this.btnNotifications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotifications.Location = new System.Drawing.Point(0, 322);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnNotifications.Size = new System.Drawing.Size(200, 60);
            this.btnNotifications.TabIndex = 5;
            this.btnNotifications.Text = "  Notifications";
            this.btnNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotifications.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNotifications.UseVisualStyleBackColor = true;
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBilling.FlatAppearance.BorderSize = 0;
            this.btnBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilling.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBilling.Image = ((System.Drawing.Image)(resources.GetObject("btnBilling.Image")));
            this.btnBilling.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilling.Location = new System.Drawing.Point(0, 262);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnBilling.Size = new System.Drawing.Size(200, 60);
            this.btnBilling.TabIndex = 4;
            this.btnBilling.Text = "  Bills";
            this.btnBilling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilling.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnprinting
            // 
            this.btnprinting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnprinting.FlatAppearance.BorderSize = 0;
            this.btnprinting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprinting.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnprinting.Image = ((System.Drawing.Image)(resources.GetObject("btnprinting.Image")));
            this.btnprinting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprinting.Location = new System.Drawing.Point(0, 202);
            this.btnprinting.Name = "btnprinting";
            this.btnprinting.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnprinting.Size = new System.Drawing.Size(200, 60);
            this.btnprinting.TabIndex = 3;
            this.btnprinting.Text = "  Printing";
            this.btnprinting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprinting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprinting.UseVisualStyleBackColor = true;
            this.btnprinting.Click += new System.EventHandler(this.btnprinting_Click);
            // 
            // btnemployee
            // 
            this.btnemployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnemployee.FlatAppearance.BorderSize = 0;
            this.btnemployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnemployee.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnemployee.Image = ((System.Drawing.Image)(resources.GetObject("btnemployee.Image")));
            this.btnemployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnemployee.Location = new System.Drawing.Point(0, 142);
            this.btnemployee.Name = "btnemployee";
            this.btnemployee.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnemployee.Size = new System.Drawing.Size(200, 60);
            this.btnemployee.TabIndex = 2;
            this.btnemployee.Text = "  Employee";
            this.btnemployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnemployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnemployee.UseVisualStyleBackColor = true;
            this.btnemployee.Click += new System.EventHandler(this.btnemployee_Click);
            // 
            // btnvisa
            // 
            this.btnvisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnvisa.FlatAppearance.BorderSize = 0;
            this.btnvisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvisa.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnvisa.Image = ((System.Drawing.Image)(resources.GetObject("btnvisa.Image")));
            this.btnvisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnvisa.Location = new System.Drawing.Point(0, 80);
            this.btnvisa.Name = "btnvisa";
            this.btnvisa.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnvisa.Size = new System.Drawing.Size(200, 62);
            this.btnvisa.TabIndex = 1;
            this.btnvisa.Text = "  Visa";
            this.btnvisa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnvisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnvisa.UseVisualStyleBackColor = true;
            this.btnvisa.Click += new System.EventHandler(this.btnvisa_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnMinum);
            this.panelTitleBar.Controls.Add(this.button1);
            this.panelTitleBar.Controls.Add(this.BTNcLOSE);
            this.panelTitleBar.Controls.Add(this.btnCloseChildForm);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(884, 80);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // BTNcLOSE
            // 
            this.BTNcLOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNcLOSE.FlatAppearance.BorderSize = 0;
            this.BTNcLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcLOSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcLOSE.ForeColor = System.Drawing.Color.White;
            this.BTNcLOSE.Location = new System.Drawing.Point(841, 3);
            this.BTNcLOSE.Name = "BTNcLOSE";
            this.BTNcLOSE.Size = new System.Drawing.Size(43, 24);
            this.BTNcLOSE.TabIndex = 1;
            this.BTNcLOSE.Text = "O";
            this.BTNcLOSE.UseVisualStyleBackColor = true;
            this.BTNcLOSE.Click += new System.EventHandler(this.BTNcLOSE_Click);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseChildForm.Image")));
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 10);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(55, 54);
            this.btnCloseChildForm.TabIndex = 0;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(416, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(75, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HOME";
            // 
            // panelDesktopPanel
            // 
            this.panelDesktopPanel.BackColor = System.Drawing.Color.White;
            this.panelDesktopPanel.Controls.Add(this.pictureBox1);
            this.panelDesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPanel.Location = new System.Drawing.Point(200, 80);
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            this.panelDesktopPanel.Size = new System.Drawing.Size(884, 501);
            this.panelDesktopPanel.TabIndex = 2;
            this.panelDesktopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktopPanel_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(562, 182);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(589, 420);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(811, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "O";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMinum
            // 
            this.btnMinum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinum.FlatAppearance.BorderSize = 0;
            this.btnMinum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinum.ForeColor = System.Drawing.Color.White;
            this.btnMinum.Location = new System.Drawing.Point(775, 3);
            this.btnMinum.Name = "btnMinum";
            this.btnMinum.Size = new System.Drawing.Size(43, 24);
            this.btnMinum.TabIndex = 3;
            this.btnMinum.Text = "O";
            this.btnMinum.UseVisualStyleBackColor = true;
            this.btnMinum.Click += new System.EventHandler(this.btnMinum_Click_1);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 581);
            this.Controls.Add(this.panelDesktopPanel);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "FormMainMenu";
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnemployee;
        private System.Windows.Forms.Button btnvisa;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Button btnprinting;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDesktopPanel;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTNcLOSE;
        private System.Windows.Forms.Button btnMinum;
        private System.Windows.Forms.Button button1;
    }
}

