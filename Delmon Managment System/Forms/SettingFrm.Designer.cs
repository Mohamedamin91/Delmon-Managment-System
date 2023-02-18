
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.userTap = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.jobsTap = new System.Windows.Forms.TabPage();
            this.agenciesTap = new System.Windows.Forms.TabPage();
            this.notificationsTap = new System.Windows.Forms.TabPage();
            this.isactivecheck = new System.Windows.Forms.CheckBox();
            this.updatebtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Generatebtn = new System.Windows.Forms.Button();
            this.cmbemployee = new System.Windows.Forms.ComboBox();
            this.cmbusertype = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPC = new System.Windows.Forms.Label();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblusertype = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.userTap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.userTap);
            this.tabControl1.Controls.Add(this.jobsTap);
            this.tabControl1.Controls.Add(this.agenciesTap);
            this.tabControl1.Controls.Add(this.notificationsTap);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1025, 446);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // userTap
            // 
            this.userTap.Controls.Add(this.cmbusertype);
            this.userTap.Controls.Add(this.label3);
            this.userTap.Controls.Add(this.cmbemployee);
            this.userTap.Controls.Add(this.Generatebtn);
            this.userTap.Controls.Add(this.passwordtxt);
            this.userTap.Controls.Add(this.label5);
            this.userTap.Controls.Add(this.dataGridView1);
            this.userTap.Controls.Add(this.deletebtn);
            this.userTap.Controls.Add(this.updatebtn);
            this.userTap.Controls.Add(this.isactivecheck);
            this.userTap.Controls.Add(this.label4);
            this.userTap.Controls.Add(this.usernametxt);
            this.userTap.Controls.Add(this.label2);
            this.userTap.Controls.Add(this.addbtn);
            this.userTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTap.Location = new System.Drawing.Point(4, 27);
            this.userTap.Name = "userTap";
            this.userTap.Padding = new System.Windows.Forms.Padding(3);
            this.userTap.Size = new System.Drawing.Size(1017, 415);
            this.userTap.TabIndex = 0;
            this.userTap.Text = "Users";
            this.userTap.UseVisualStyleBackColor = true;
            this.userTap.Click += new System.EventHandler(this.userTap_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "Employee";
            // 
            // usernametxt
            // 
            this.usernametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernametxt.Location = new System.Drawing.Point(9, 166);
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(249, 22);
            this.usernametxt.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "UserName";
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.addbtn.FlatAppearance.BorderSize = 0;
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Location = new System.Drawing.Point(30, 303);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(70, 26);
            this.addbtn.TabIndex = 44;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // jobsTap
            // 
            this.jobsTap.Location = new System.Drawing.Point(4, 22);
            this.jobsTap.Name = "jobsTap";
            this.jobsTap.Padding = new System.Windows.Forms.Padding(3);
            this.jobsTap.Size = new System.Drawing.Size(1017, 330);
            this.jobsTap.TabIndex = 1;
            this.jobsTap.Text = "Jobs";
            this.jobsTap.UseVisualStyleBackColor = true;
            // 
            // agenciesTap
            // 
            this.agenciesTap.Location = new System.Drawing.Point(4, 22);
            this.agenciesTap.Name = "agenciesTap";
            this.agenciesTap.Size = new System.Drawing.Size(1003, 671);
            this.agenciesTap.TabIndex = 2;
            this.agenciesTap.Text = "Agencies";
            this.agenciesTap.UseVisualStyleBackColor = true;
            // 
            // notificationsTap
            // 
            this.notificationsTap.Location = new System.Drawing.Point(4, 22);
            this.notificationsTap.Name = "notificationsTap";
            this.notificationsTap.Size = new System.Drawing.Size(1017, 330);
            this.notificationsTap.TabIndex = 3;
            this.notificationsTap.Text = "Notifications";
            this.notificationsTap.UseVisualStyleBackColor = true;
            // 
            // isactivecheck
            // 
            this.isactivecheck.AutoSize = true;
            this.isactivecheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isactivecheck.Location = new System.Drawing.Point(9, 259);
            this.isactivecheck.Name = "isactivecheck";
            this.isactivecheck.Size = new System.Drawing.Size(74, 20);
            this.isactivecheck.TabIndex = 54;
            this.isactivecheck.Text = "IsActive";
            this.isactivecheck.UseVisualStyleBackColor = true;
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.Firebrick;
            this.updatebtn.FlatAppearance.BorderSize = 0;
            this.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatebtn.ForeColor = System.Drawing.Color.White;
            this.updatebtn.Location = new System.Drawing.Point(140, 303);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(70, 26);
            this.updatebtn.TabIndex = 55;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.BackColor = System.Drawing.Color.Firebrick;
            this.deletebtn.FlatAppearance.BorderSize = 0;
            this.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletebtn.ForeColor = System.Drawing.Color.White;
            this.deletebtn.Location = new System.Drawing.Point(242, 303);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(70, 26);
            this.deletebtn.TabIndex = 56;
            this.deletebtn.Text = "Delete";
            this.deletebtn.UseVisualStyleBackColor = false;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(491, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(502, 269);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // passwordtxt
            // 
            this.passwordtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtxt.Location = new System.Drawing.Point(9, 220);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(249, 22);
            this.passwordtxt.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 58;
            this.label5.Text = "Password";
            // 
            // Generatebtn
            // 
            this.Generatebtn.BackColor = System.Drawing.Color.Navy;
            this.Generatebtn.FlatAppearance.BorderSize = 0;
            this.Generatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Generatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Generatebtn.ForeColor = System.Drawing.Color.White;
            this.Generatebtn.Location = new System.Drawing.Point(279, 216);
            this.Generatebtn.Name = "Generatebtn";
            this.Generatebtn.Size = new System.Drawing.Size(133, 26);
            this.Generatebtn.TabIndex = 60;
            this.Generatebtn.Text = "Generate Password";
            this.Generatebtn.UseVisualStyleBackColor = false;
            this.Generatebtn.Click += new System.EventHandler(this.Generatebtn_Click);
            // 
            // cmbemployee
            // 
            this.cmbemployee.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbemployee.FormattingEnabled = true;
            this.cmbemployee.Location = new System.Drawing.Point(10, 46);
            this.cmbemployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbemployee.Name = "cmbemployee";
            this.cmbemployee.Size = new System.Drawing.Size(257, 25);
            this.cmbemployee.TabIndex = 135;
            // 
            // cmbusertype
            // 
            this.cmbusertype.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbusertype.FormattingEnabled = true;
            this.cmbusertype.Location = new System.Drawing.Point(10, 105);
            this.cmbusertype.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbusertype.Name = "cmbusertype";
            this.cmbusertype.Size = new System.Drawing.Size(257, 25);
            this.cmbusertype.TabIndex = 137;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 136;
            this.label3.Text = "User type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPC);
            this.groupBox1.Controls.Add(this.lbldatetime);
            this.groupBox1.Controls.Add(this.lblemail);
            this.groupBox1.Controls.Add(this.lblusername);
            this.groupBox1.Controls.Add(this.lblusertype);
            this.groupBox1.Location = new System.Drawing.Point(1055, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 145);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Info";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblPC.Location = new System.Drawing.Point(2, 89);
            this.lblPC.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(22, 17);
            this.lblPC.TabIndex = 98;
            this.lblPC.Text = "Pc";
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatetime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lbldatetime.Location = new System.Drawing.Point(2, 114);
            this.lbldatetime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(68, 17);
            this.lbldatetime.TabIndex = 96;
            this.lbldatetime.Text = "Date&Time";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblemail.Location = new System.Drawing.Point(2, 40);
            this.lblemail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(42, 17);
            this.lblemail.TabIndex = 95;
            this.lblemail.Text = "Email";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusername.Location = new System.Drawing.Point(2, 18);
            this.lblusername.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(71, 17);
            this.lblusername.TabIndex = 92;
            this.lblusername.Text = "UserName";
            // 
            // lblusertype
            // 
            this.lblusertype.AutoSize = true;
            this.lblusertype.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusertype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusertype.Location = new System.Drawing.Point(2, 64);
            this.lblusertype.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblusertype.Name = "lblusertype";
            this.lblusertype.Size = new System.Drawing.Size(64, 17);
            this.lblusertype.TabIndex = 94;
            this.lblusertype.Text = "UserType";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SettingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1259, 715);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingFrm";
            this.Text = "Setting ";
            this.Load += new System.EventHandler(this.SettingFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.userTap.ResumeLayout(false);
            this.userTap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage userTap;
        private System.Windows.Forms.TabPage jobsTap;
        private System.Windows.Forms.TabPage agenciesTap;
        private System.Windows.Forms.TabPage notificationsTap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.CheckBox isactivecheck;
        private System.Windows.Forms.Button Generatebtn;
        private System.Windows.Forms.ComboBox cmbemployee;
        private System.Windows.Forms.ComboBox cmbusertype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lbldatetime;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblusertype;
        private System.Windows.Forms.Timer timer1;
    }
}