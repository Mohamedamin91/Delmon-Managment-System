
namespace Delmon_Managment_System.Forms
{
    partial class BillsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillsFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFullname = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblusertype = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.RemarksTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbservice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbemployee = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbworkfield = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtsubscription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmetersn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtaccountno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1239, 635);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btn);
            this.tabPage1.Controls.Add(this.btnUpdate);
            this.tabPage1.Controls.Add(this.DeleteBtn);
            this.tabPage1.Controls.Add(this.AddBtn);
            this.tabPage1.Controls.Add(this.cmbCompany);
            this.tabPage1.Controls.Add(this.RemarksTxt);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbservice);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbemployee);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.cmbworkfield);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.cmbDepartment);
            this.tabPage1.Controls.Add(this.txtsubscription);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtmetersn);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtaccountno);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1231, 605);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ElectrcityBills";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 192;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(41, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(249, 25);
            this.txtSearch.TabIndex = 191;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(41, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 190;
            this.label6.Text = "Search";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFullname);
            this.groupBox1.Controls.Add(this.lblPC);
            this.groupBox1.Controls.Add(this.lbldatetime);
            this.groupBox1.Controls.Add(this.lblemail);
            this.groupBox1.Controls.Add(this.lblusername);
            this.groupBox1.Controls.Add(this.lblusertype);
            this.groupBox1.Location = new System.Drawing.Point(145, 560);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 37);
            this.groupBox1.TabIndex = 189;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblFullname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblFullname.Location = new System.Drawing.Point(186, 16);
            this.lblFullname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(80, 17);
            this.lblFullname.TabIndex = 99;
            this.lblFullname.Text = "Full Name";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblPC.Location = new System.Drawing.Point(353, 14);
            this.lblPC.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(27, 17);
            this.lblPC.TabIndex = 98;
            this.lblPC.Text = "Pc";
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lbldatetime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lbldatetime.Location = new System.Drawing.Point(537, 16);
            this.lbldatetime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(77, 17);
            this.lbldatetime.TabIndex = 96;
            this.lbldatetime.Text = "Date&Time";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblemail.Location = new System.Drawing.Point(436, 14);
            this.lblemail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(48, 17);
            this.lblemail.TabIndex = 95;
            this.lblemail.Text = "Email";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusername.Location = new System.Drawing.Point(45, 14);
            this.lblusername.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(85, 17);
            this.lblusername.TabIndex = 92;
            this.lblusername.Text = "UserName";
            // 
            // lblusertype
            // 
            this.lblusertype.AutoSize = true;
            this.lblusertype.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusertype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusertype.Location = new System.Drawing.Point(772, 21);
            this.lblusertype.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblusertype.Name = "lblusertype";
            this.lblusertype.Size = new System.Drawing.Size(72, 17);
            this.lblusertype.TabIndex = 94;
            this.lblusertype.Text = "UserType";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 188;
            this.label1.Text = "Owner";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(643, 8);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(580, 377);
            this.dataGridView1.TabIndex = 187;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btn
            // 
            this.btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn.BackColor = System.Drawing.Color.White;
            this.btn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btn.ForeColor = System.Drawing.Color.Firebrick;
            this.btn.Location = new System.Drawing.Point(158, 529);
            this.btn.Margin = new System.Windows.Forms.Padding(4);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(63, 28);
            this.btn.TabIndex = 186;
            this.btn.Text = "New";
            this.btn.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnUpdate.ForeColor = System.Drawing.Color.Firebrick;
            this.btnUpdate.Location = new System.Drawing.Point(250, 529);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 28);
            this.btnUpdate.TabIndex = 185;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBtn.BackColor = System.Drawing.Color.White;
            this.DeleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.DeleteBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.DeleteBtn.Location = new System.Drawing.Point(346, 529);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(67, 28);
            this.DeleteBtn.TabIndex = 184;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBtn.BackColor = System.Drawing.Color.White;
            this.AddBtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.AddBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.AddBtn.Location = new System.Drawing.Point(63, 529);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(63, 28);
            this.AddBtn.TabIndex = 183;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(41, 207);
            this.cmbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(537, 25);
            this.cmbCompany.TabIndex = 181;
            this.cmbCompany.SelectionChangeCommitted += new System.EventHandler(this.cmbCompany_SelectionChangeCommitted);
            // 
            // RemarksTxt
            // 
            this.RemarksTxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.RemarksTxt.Location = new System.Drawing.Point(41, 425);
            this.RemarksTxt.Margin = new System.Windows.Forms.Padding(4);
            this.RemarksTxt.Multiline = true;
            this.RemarksTxt.Name = "RemarksTxt";
            this.RemarksTxt.Size = new System.Drawing.Size(540, 74);
            this.RemarksTxt.TabIndex = 179;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label9.Location = new System.Drawing.Point(44, 404);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 180;
            this.label9.Text = "Notes";
            // 
            // cmbservice
            // 
            this.cmbservice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbservice.FormattingEnabled = true;
            this.cmbservice.Location = new System.Drawing.Point(329, 343);
            this.cmbservice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbservice.Name = "cmbservice";
            this.cmbservice.Size = new System.Drawing.Size(249, 25);
            this.cmbservice.TabIndex = 178;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(326, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 177;
            this.label4.Text = "Service";
            // 
            // cmbemployee
            // 
            this.cmbemployee.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbemployee.FormattingEnabled = true;
            this.cmbemployee.Location = new System.Drawing.Point(44, 343);
            this.cmbemployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbemployee.Name = "cmbemployee";
            this.cmbemployee.Size = new System.Drawing.Size(249, 25);
            this.cmbemployee.TabIndex = 174;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(326, 251);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 17);
            this.label21.TabIndex = 169;
            this.label21.Text = "Work Location";
            // 
            // cmbworkfield
            // 
            this.cmbworkfield.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbworkfield.FormattingEnabled = true;
            this.cmbworkfield.Location = new System.Drawing.Point(329, 270);
            this.cmbworkfield.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbworkfield.Name = "cmbworkfield";
            this.cmbworkfield.Size = new System.Drawing.Size(249, 25);
            this.cmbworkfield.TabIndex = 170;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(41, 322);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(157, 17);
            this.label27.TabIndex = 173;
            this.label27.Text = "Head Of Department";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(41, 251);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(98, 17);
            this.label28.TabIndex = 171;
            this.label28.Text = "Departname";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(41, 270);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(249, 25);
            this.cmbDepartment.TabIndex = 172;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // txtsubscription
            // 
            this.txtsubscription.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtsubscription.Location = new System.Drawing.Point(340, 90);
            this.txtsubscription.Name = "txtsubscription";
            this.txtsubscription.Size = new System.Drawing.Size(249, 25);
            this.txtsubscription.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(337, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "SubscriptionNo";
            // 
            // txtmetersn
            // 
            this.txtmetersn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtmetersn.Location = new System.Drawing.Point(38, 144);
            this.txtmetersn.Name = "txtmetersn";
            this.txtmetersn.Size = new System.Drawing.Size(249, 25);
            this.txtmetersn.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(38, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 62;
            this.label5.Text = "MeterSN";
            // 
            // txtaccountno
            // 
            this.txtaccountno.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtaccountno.Location = new System.Drawing.Point(38, 90);
            this.txtaccountno.Name = "txtaccountno";
            this.txtaccountno.Size = new System.Drawing.Size(249, 25);
            this.txtaccountno.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(38, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 60;
            this.label2.Text = "AccountNo";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1231, 605);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CommunicationsBills";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1231, 605);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BillsPaymentStatus";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1231, 605);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "BillsForm";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BillsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1269, 638);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BillsFrm";
            this.Text = "Bills";
            this.Load += new System.EventHandler(this.BillsFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtsubscription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmetersn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtaccountno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbservice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbemployee;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.ComboBox cmbworkfield;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        public System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.TextBox RemarksTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lbldatetime;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblusertype;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}