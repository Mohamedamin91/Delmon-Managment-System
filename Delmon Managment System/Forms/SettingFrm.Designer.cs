﻿
namespace Delmon_Managment_System.Forms
{
    partial class SettingFrm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.userTap = new System.Windows.Forms.TabPage();
            this.jobsTap = new System.Windows.Forms.TabPage();
            this.agenciesTap = new System.Windows.Forms.TabPage();
            this.notificationsTap = new System.Windows.Forms.TabPage();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LicenseNumbertxt = new System.Windows.Forms.TextBox();
            this.AgencyNametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.userTap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.userTap);
            this.tabControl1.Controls.Add(this.jobsTap);
            this.tabControl1.Controls.Add(this.agenciesTap);
            this.tabControl1.Controls.Add(this.notificationsTap);
            this.tabControl1.Location = new System.Drawing.Point(1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(966, 803);
            this.tabControl1.TabIndex = 0;
            // 
            // userTap
            // 
            this.userTap.Controls.Add(this.cmbCity);
            this.userTap.Controls.Add(this.label5);
            this.userTap.Controls.Add(this.cmbCountry);
            this.userTap.Controls.Add(this.label4);
            this.userTap.Controls.Add(this.LicenseNumbertxt);
            this.userTap.Controls.Add(this.AgencyNametxt);
            this.userTap.Controls.Add(this.label3);
            this.userTap.Controls.Add(this.label2);
            this.userTap.Controls.Add(this.label1);
            this.userTap.Controls.Add(this.addbtn);
            this.userTap.Location = new System.Drawing.Point(4, 22);
            this.userTap.Name = "userTap";
            this.userTap.Padding = new System.Windows.Forms.Padding(3);
            this.userTap.Size = new System.Drawing.Size(958, 777);
            this.userTap.TabIndex = 0;
            this.userTap.Text = "Users";
            this.userTap.UseVisualStyleBackColor = true;
            // 
            // jobsTap
            // 
            this.jobsTap.Location = new System.Drawing.Point(4, 22);
            this.jobsTap.Name = "jobsTap";
            this.jobsTap.Padding = new System.Windows.Forms.Padding(3);
            this.jobsTap.Size = new System.Drawing.Size(958, 777);
            this.jobsTap.TabIndex = 1;
            this.jobsTap.Text = "Jobs";
            this.jobsTap.UseVisualStyleBackColor = true;
            // 
            // agenciesTap
            // 
            this.agenciesTap.Location = new System.Drawing.Point(4, 22);
            this.agenciesTap.Name = "agenciesTap";
            this.agenciesTap.Size = new System.Drawing.Size(958, 777);
            this.agenciesTap.TabIndex = 2;
            this.agenciesTap.Text = "Agencies";
            this.agenciesTap.UseVisualStyleBackColor = true;
            // 
            // notificationsTap
            // 
            this.notificationsTap.Location = new System.Drawing.Point(4, 22);
            this.notificationsTap.Name = "notificationsTap";
            this.notificationsTap.Size = new System.Drawing.Size(958, 777);
            this.notificationsTap.TabIndex = 3;
            this.notificationsTap.Text = "Notifications";
            this.notificationsTap.UseVisualStyleBackColor = true;
            // 
            // cmbCity
            // 
            this.cmbCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(258, 205);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(128, 24);
            this.cmbCity.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(258, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 52;
            this.label5.Text = "City";
            // 
            // cmbCountry
            // 
            this.cmbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(258, 159);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(249, 24);
            this.cmbCountry.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(258, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "Employee";
            // 
            // LicenseNumbertxt
            // 
            this.LicenseNumbertxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LicenseNumbertxt.Location = new System.Drawing.Point(261, 256);
            this.LicenseNumbertxt.Name = "LicenseNumbertxt";
            this.LicenseNumbertxt.Size = new System.Drawing.Size(103, 22);
            this.LicenseNumbertxt.TabIndex = 49;
            // 
            // AgencyNametxt
            // 
            this.AgencyNametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgencyNametxt.Location = new System.Drawing.Point(258, 108);
            this.AgencyNametxt.Name = "AgencyNametxt";
            this.AgencyNametxt.Size = new System.Drawing.Size(249, 22);
            this.AgencyNametxt.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(258, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "License Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(255, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "Agency Name (EN/AR)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(364, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 24);
            this.label1.TabIndex = 45;
            this.label1.Text = "User";
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.addbtn.FlatAppearance.BorderSize = 0;
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Location = new System.Drawing.Point(261, 297);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(246, 37);
            this.addbtn.TabIndex = 44;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = false;
            // 
            // SettingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(966, 799);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingFrm";
            this.Text = "Setting ";
            this.Load += new System.EventHandler(this.SettingFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.userTap.ResumeLayout(false);
            this.userTap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage userTap;
        private System.Windows.Forms.TabPage jobsTap;
        private System.Windows.Forms.TabPage agenciesTap;
        private System.Windows.Forms.TabPage notificationsTap;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LicenseNumbertxt;
        private System.Windows.Forms.TextBox AgencyNametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addbtn;
    }
}