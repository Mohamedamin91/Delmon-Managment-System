﻿
namespace Delmon_Managment_System.Forms
{
    partial class VisaFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisaFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.Visanumtxt = new System.Windows.Forms.TextBox();
            this.TotalVisastxt = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RemarksTxt = new System.Windows.Forms.TextBox();
            this.IssueDateENTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.expairENDATEtxt = new System.Windows.Forms.TextBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Remaininglbl = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ExpiaryHijritxt = new System.Windows.Forms.TextBox();
            this.issuhijritxt = new System.Windows.Forms.TextBox();
            this.ReceviedPicker = new System.Windows.Forms.DateTimePicker();
            this.Findbtn = new System.Windows.Forms.Button();
            this.groupbox = new System.Windows.Forms.GroupBox();
            this.ChkUsedbx = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label27 = new System.Windows.Forms.Label();
            this.Searchtxt = new System.Windows.Forms.TextBox();
            this.lblexpire = new System.Windows.Forms.Label();
            this.txtvisa = new System.Windows.Forms.Label();
            this.picVisa = new System.Windows.Forms.PictureBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.btnwexpire = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCRNumber = new System.Windows.Forms.TextBox();
            this.txtsponserID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label44 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.VisaFileNumberID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbcandidates = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbConsulate = new System.Windows.Forms.ComboBox();
            this.cmbJob = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnnewJob = new System.Windows.Forms.Button();
            this.cmbAgency = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbcandidates2 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbReservedTo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label1.Location = new System.Drawing.Point(7, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visa Number";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label25.Location = new System.Drawing.Point(1, 174);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(176, 17);
            this.label25.TabIndex = 1;
            this.label25.Text = " Date Hijri (dd/MM/yyyy)";
            // 
            // Visanumtxt
            // 
            this.Visanumtxt.Enabled = false;
            this.Visanumtxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Visanumtxt.Location = new System.Drawing.Point(185, 55);
            this.Visanumtxt.Margin = new System.Windows.Forms.Padding(4);
            this.Visanumtxt.Name = "Visanumtxt";
            this.Visanumtxt.Size = new System.Drawing.Size(154, 25);
            this.Visanumtxt.TabIndex = 3;
            this.Visanumtxt.TextChanged += new System.EventHandler(this.Visanumtxt_TextChanged);
            this.Visanumtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Visanumtxt_KeyDown);
            this.Visanumtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Visanumtxt_KeyPress);
            this.Visanumtxt.Leave += new System.EventHandler(this.Visanumtxt_Leave);
            // 
            // TotalVisastxt
            // 
            this.TotalVisastxt.Enabled = false;
            this.TotalVisastxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.TotalVisastxt.Location = new System.Drawing.Point(185, 288);
            this.TotalVisastxt.Margin = new System.Windows.Forms.Padding(4);
            this.TotalVisastxt.Name = "TotalVisastxt";
            this.TotalVisastxt.Size = new System.Drawing.Size(116, 25);
            this.TotalVisastxt.TabIndex = 4;
            this.TotalVisastxt.TextChanged += new System.EventHandler(this.TotalVisastxt_TextChanged);
            this.TotalVisastxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TotalVisastxt_KeyDown);
            this.TotalVisastxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TotalVisastxt_KeyPress);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBtn.BackColor = System.Drawing.Color.White;
            this.AddBtn.Enabled = false;
            this.AddBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.AddBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
            this.AddBtn.Location = new System.Drawing.Point(550, 680);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(63, 28);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Visible = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label3.Location = new System.Drawing.Point(319, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Expiry Date Hijri";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label7.Location = new System.Drawing.Point(7, 201);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Issue Date EN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label9.Location = new System.Drawing.Point(7, 239);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Remarks";
            // 
            // RemarksTxt
            // 
            this.RemarksTxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.RemarksTxt.Location = new System.Drawing.Point(185, 222);
            this.RemarksTxt.Margin = new System.Windows.Forms.Padding(4);
            this.RemarksTxt.Multiline = true;
            this.RemarksTxt.Name = "RemarksTxt";
            this.RemarksTxt.Size = new System.Drawing.Size(481, 53);
            this.RemarksTxt.TabIndex = 23;
            this.RemarksTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.RemarksTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RemarksTxt_KeyDown);
            // 
            // IssueDateENTxt
            // 
            this.IssueDateENTxt.Enabled = false;
            this.IssueDateENTxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.IssueDateENTxt.Location = new System.Drawing.Point(185, 195);
            this.IssueDateENTxt.Margin = new System.Windows.Forms.Padding(4);
            this.IssueDateENTxt.Multiline = true;
            this.IssueDateENTxt.Name = "IssueDateENTxt";
            this.IssueDateENTxt.Size = new System.Drawing.Size(112, 23);
            this.IssueDateENTxt.TabIndex = 26;
            this.IssueDateENTxt.TextChanged += new System.EventHandler(this.IssueDateENTxt_TextChanged);
            this.IssueDateENTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IssueDateENTxt_KeyDown);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(2324, 383);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 45);
            this.button1.TabIndex = 42;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // expairENDATEtxt
            // 
            this.expairENDATEtxt.Enabled = false;
            this.expairENDATEtxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.expairENDATEtxt.Location = new System.Drawing.Point(456, 188);
            this.expairENDATEtxt.Margin = new System.Windows.Forms.Padding(4);
            this.expairENDATEtxt.Multiline = true;
            this.expairENDATEtxt.Name = "expairENDATEtxt";
            this.expairENDATEtxt.Size = new System.Drawing.Size(112, 23);
            this.expairENDATEtxt.TabIndex = 32;
            this.expairENDATEtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.expairENDATEtxt_KeyDown);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Enabled = false;
            this.cmbCompany.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(185, 82);
            this.cmbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(481, 25);
            this.cmbCompany.TabIndex = 34;
            this.cmbCompany.DropDown += new System.EventHandler(this.cmbCompany_DropDown);
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            this.cmbCompany.SelectionChangeCommitted += new System.EventHandler(this.cmbCompany_SelectionChangeCommitted);
            this.cmbCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCompany_KeyDown);
            this.cmbCompany.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbCompany_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label2.Location = new System.Drawing.Point(7, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Company";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label10.Location = new System.Drawing.Point(7, 288);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 17);
            this.label10.TabIndex = 41;
            this.label10.Text = "Total Jobs";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label12.Location = new System.Drawing.Point(7, 146);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 17);
            this.label12.TabIndex = 38;
            this.label12.Text = "Recived Date";
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinish.BackColor = System.Drawing.Color.White;
            this.btnFinish.Enabled = false;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFinish.FlatAppearance.BorderSize = 0;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnFinish.ForeColor = System.Drawing.Color.Firebrick;
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.Location = new System.Drawing.Point(647, 680);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(63, 28);
            this.btnFinish.TabIndex = 41;
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(320, 137);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 17);
            this.label11.TabIndex = 43;
            this.label11.Text = "Remaining days";
            // 
            // Remaininglbl
            // 
            this.Remaininglbl.AutoSize = true;
            this.Remaininglbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Remaininglbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Remaininglbl.Location = new System.Drawing.Point(456, 135);
            this.Remaininglbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Remaininglbl.Name = "Remaininglbl";
            this.Remaininglbl.Size = new System.Drawing.Size(13, 17);
            this.Remaininglbl.TabIndex = 44;
            this.Remaininglbl.Text = "!";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnNew.ForeColor = System.Drawing.Color.Firebrick;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(414, 53);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 27);
            this.btnNew.TabIndex = 82;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBtn.BackColor = System.Drawing.Color.White;
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DeleteBtn.FlatAppearance.BorderSize = 0;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.Image")));
            this.DeleteBtn.Location = new System.Drawing.Point(833, 680);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(67, 28);
            this.DeleteBtn.TabIndex = 84;
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Visible = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label6.Location = new System.Drawing.Point(319, 192);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Expiry Date EN";
            // 
            // ExpiaryHijritxt
            // 
            this.ExpiaryHijritxt.Enabled = false;
            this.ExpiaryHijritxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.ExpiaryHijritxt.Location = new System.Drawing.Point(456, 157);
            this.ExpiaryHijritxt.Margin = new System.Windows.Forms.Padding(4);
            this.ExpiaryHijritxt.Multiline = true;
            this.ExpiaryHijritxt.Name = "ExpiaryHijritxt";
            this.ExpiaryHijritxt.Size = new System.Drawing.Size(112, 23);
            this.ExpiaryHijritxt.TabIndex = 31;
            this.ExpiaryHijritxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExpiaryHijritxt_KeyDown);
            // 
            // issuhijritxt
            // 
            this.issuhijritxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.issuhijritxt.ForeColor = System.Drawing.Color.Black;
            this.issuhijritxt.Location = new System.Drawing.Point(185, 165);
            this.issuhijritxt.Margin = new System.Windows.Forms.Padding(4);
            this.issuhijritxt.Name = "issuhijritxt";
            this.issuhijritxt.Size = new System.Drawing.Size(112, 25);
            this.issuhijritxt.TabIndex = 33;
            this.issuhijritxt.TextChanged += new System.EventHandler(this.issuhijritxt_TextChanged);
            this.issuhijritxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.issuhijritxt_DragEnter);
            this.issuhijritxt.Enter += new System.EventHandler(this.issuhijritxt_Enter);
            this.issuhijritxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.issuhijritxt_KeyDown);
            this.issuhijritxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.issuhijritxt_KeyPress);
            this.issuhijritxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.issuhijritxt_KeyUp);
            this.issuhijritxt.Leave += new System.EventHandler(this.issuhijritxt_Leave);
            this.issuhijritxt.MouseEnter += new System.EventHandler(this.issuhijritxt_MouseEnter);
            // 
            // ReceviedPicker
            // 
            this.ReceviedPicker.Enabled = false;
            this.ReceviedPicker.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.ReceviedPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ReceviedPicker.Location = new System.Drawing.Point(185, 137);
            this.ReceviedPicker.Margin = new System.Windows.Forms.Padding(4);
            this.ReceviedPicker.Name = "ReceviedPicker";
            this.ReceviedPicker.Size = new System.Drawing.Size(112, 25);
            this.ReceviedPicker.TabIndex = 40;
            this.ReceviedPicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReceviedPicker_KeyDown);
            // 
            // Findbtn
            // 
            this.Findbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Findbtn.BackColor = System.Drawing.Color.White;
            this.Findbtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.Findbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Findbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Findbtn.ForeColor = System.Drawing.Color.Firebrick;
            this.Findbtn.Location = new System.Drawing.Point(1292, 678);
            this.Findbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Findbtn.Name = "Findbtn";
            this.Findbtn.Size = new System.Drawing.Size(54, 27);
            this.Findbtn.TabIndex = 86;
            this.Findbtn.Text = "Find";
            this.Findbtn.UseVisualStyleBackColor = false;
            this.Findbtn.Visible = false;
            this.Findbtn.Click += new System.EventHandler(this.Findbtn_Click);
            // 
            // groupbox
            // 
            this.groupbox.Controls.Add(this.ChkUsedbx);
            this.groupbox.Controls.Add(this.dataGridView1);
            this.groupbox.Controls.Add(this.label27);
            this.groupbox.Controls.Add(this.Searchtxt);
            this.groupbox.Controls.Add(this.lblexpire);
            this.groupbox.Controls.Add(this.txtvisa);
            this.groupbox.Controls.Add(this.picVisa);
            this.groupbox.Controls.Add(this.dataGridView3);
            this.groupbox.Controls.Add(this.btnwexpire);
            this.groupbox.Controls.Add(this.label18);
            this.groupbox.Controls.Add(this.txtCRNumber);
            this.groupbox.Controls.Add(this.txtsponserID);
            this.groupbox.Controls.Add(this.label17);
            this.groupbox.Controls.Add(this.RemarksTxt);
            this.groupbox.Controls.Add(this.label1);
            this.groupbox.Controls.Add(this.label10);
            this.groupbox.Controls.Add(this.label25);
            this.groupbox.Controls.Add(this.Visanumtxt);
            this.groupbox.Controls.Add(this.TotalVisastxt);
            this.groupbox.Controls.Add(this.btnNew);
            this.groupbox.Controls.Add(this.label3);
            this.groupbox.Controls.Add(this.label7);
            this.groupbox.Controls.Add(this.label6);
            this.groupbox.Controls.Add(this.label9);
            this.groupbox.Controls.Add(this.IssueDateENTxt);
            this.groupbox.Controls.Add(this.ExpiaryHijritxt);
            this.groupbox.Controls.Add(this.issuhijritxt);
            this.groupbox.Controls.Add(this.expairENDATEtxt);
            this.groupbox.Controls.Add(this.cmbCompany);
            this.groupbox.Controls.Add(this.label2);
            this.groupbox.Controls.Add(this.label12);
            this.groupbox.Controls.Add(this.ReceviedPicker);
            this.groupbox.Controls.Add(this.label11);
            this.groupbox.Controls.Add(this.Remaininglbl);
            this.groupbox.Enabled = false;
            this.groupbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.groupbox.Location = new System.Drawing.Point(12, 8);
            this.groupbox.Name = "groupbox";
            this.groupbox.Size = new System.Drawing.Size(1619, 328);
            this.groupbox.TabIndex = 89;
            this.groupbox.TabStop = false;
            this.groupbox.Text = "Visa Info";
            this.groupbox.Enter += new System.EventHandler(this.groupBox2_Enter_1);
            // 
            // ChkUsedbx
            // 
            this.ChkUsedbx.AutoSize = true;
            this.ChkUsedbx.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkUsedbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.ChkUsedbx.Location = new System.Drawing.Point(674, 20);
            this.ChkUsedbx.Name = "ChkUsedbx";
            this.ChkUsedbx.Size = new System.Drawing.Size(153, 18);
            this.ChkUsedbx.TabIndex = 185;
            this.ChkUsedbx.Text = "Check used one also !";
            this.ChkUsedbx.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(674, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(627, 265);
            this.dataGridView1.TabIndex = 184;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(7, 32);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 17);
            this.label27.TabIndex = 183;
            this.label27.Text = "Search";
            // 
            // Searchtxt
            // 
            this.Searchtxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Searchtxt.Location = new System.Drawing.Point(186, 25);
            this.Searchtxt.Margin = new System.Windows.Forms.Padding(4);
            this.Searchtxt.Name = "Searchtxt";
            this.Searchtxt.Size = new System.Drawing.Size(154, 25);
            this.Searchtxt.TabIndex = 182;
            this.Searchtxt.TextChanged += new System.EventHandler(this.Searchtxt_TextChanged);
            // 
            // lblexpire
            // 
            this.lblexpire.AutoSize = true;
            this.lblexpire.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexpire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblexpire.Location = new System.Drawing.Point(1308, 271);
            this.lblexpire.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblexpire.Name = "lblexpire";
            this.lblexpire.Size = new System.Drawing.Size(235, 15);
            this.lblexpire.TabIndex = 181;
            this.lblexpire.Text = "*Visas that expire within one month";
            this.lblexpire.Visible = false;
            // 
            // txtvisa
            // 
            this.txtvisa.AutoSize = true;
            this.txtvisa.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvisa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.txtvisa.Location = new System.Drawing.Point(364, 60);
            this.txtvisa.Name = "txtvisa";
            this.txtvisa.Size = new System.Drawing.Size(35, 15);
            this.txtvisa.TabIndex = 180;
            this.txtvisa.Text = "Text";
            this.txtvisa.Visible = false;
            // 
            // picVisa
            // 
            this.picVisa.Image = ((System.Drawing.Image)(resources.GetObject("picVisa.Image")));
            this.picVisa.Location = new System.Drawing.Point(346, 59);
            this.picVisa.Name = "picVisa";
            this.picVisa.Size = new System.Drawing.Size(18, 18);
            this.picVisa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVisa.TabIndex = 179;
            this.picVisa.TabStop = false;
            this.picVisa.Click += new System.EventHandler(this.picVisa_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1311, 42);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView3.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView3.Size = new System.Drawing.Size(257, 225);
            this.dataGridView3.TabIndex = 105;
            this.dataGridView3.Visible = false;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellDoubleClick);
            // 
            // btnwexpire
            // 
            this.btnwexpire.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnwexpire.BackColor = System.Drawing.Color.White;
            this.btnwexpire.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnwexpire.FlatAppearance.BorderSize = 0;
            this.btnwexpire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnwexpire.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnwexpire.ForeColor = System.Drawing.Color.Firebrick;
            this.btnwexpire.Image = ((System.Drawing.Image)(resources.GetObject("btnwexpire.Image")));
            this.btnwexpire.Location = new System.Drawing.Point(342, 23);
            this.btnwexpire.Margin = new System.Windows.Forms.Padding(4);
            this.btnwexpire.Name = "btnwexpire";
            this.btnwexpire.Size = new System.Drawing.Size(30, 29);
            this.btnwexpire.TabIndex = 104;
            this.btnwexpire.UseVisualStyleBackColor = false;
            this.btnwexpire.Click += new System.EventHandler(this.btnwexpire_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label18.Location = new System.Drawing.Point(320, 114);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 17);
            this.label18.TabIndex = 90;
            this.label18.Text = "CR Number";
            // 
            // txtCRNumber
            // 
            this.txtCRNumber.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtCRNumber.Location = new System.Drawing.Point(456, 111);
            this.txtCRNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtCRNumber.Multiline = true;
            this.txtCRNumber.Name = "txtCRNumber";
            this.txtCRNumber.ReadOnly = true;
            this.txtCRNumber.Size = new System.Drawing.Size(112, 23);
            this.txtCRNumber.TabIndex = 89;
            // 
            // txtsponserID
            // 
            this.txtsponserID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtsponserID.Location = new System.Drawing.Point(185, 111);
            this.txtsponserID.Margin = new System.Windows.Forms.Padding(4);
            this.txtsponserID.Multiline = true;
            this.txtsponserID.Name = "txtsponserID";
            this.txtsponserID.ReadOnly = true;
            this.txtsponserID.Size = new System.Drawing.Size(112, 23);
            this.txtsponserID.TabIndex = 88;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label17.Location = new System.Drawing.Point(7, 120);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 17);
            this.label17.TabIndex = 87;
            this.label17.Text = "Sponser ID";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnUpdate.ForeColor = System.Drawing.Color.Firebrick;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(737, 680);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 28);
            this.btnUpdate.TabIndex = 91;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.button3.ForeColor = System.Drawing.Color.Firebrick;
            this.button3.Location = new System.Drawing.Point(924, 678);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 32);
            this.button3.TabIndex = 97;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lbldatetime.ForeColor = System.Drawing.Color.Firebrick;
            this.lbldatetime.Location = new System.Drawing.Point(1127, 769);
            this.lbldatetime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(77, 17);
            this.lbldatetime.TabIndex = 96;
            this.lbldatetime.Text = "Date&Time";
            this.lbldatetime.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(674, 26);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Size = new System.Drawing.Size(629, 190);
            this.dataGridView2.TabIndex = 83;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label44.Location = new System.Drawing.Point(7, 101);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(113, 17);
            this.label44.TabIndex = 37;
            this.label44.Text = "Consulate City";
            this.label44.Click += new System.EventHandler(this.label4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label8.Location = new System.Drawing.Point(7, 130);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "Visa Job";
            // 
            // VisaFileNumberID
            // 
            this.VisaFileNumberID.Enabled = false;
            this.VisaFileNumberID.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.VisaFileNumberID.Location = new System.Drawing.Point(180, 26);
            this.VisaFileNumberID.Margin = new System.Windows.Forms.Padding(4);
            this.VisaFileNumberID.Name = "VisaFileNumberID";
            this.VisaFileNumberID.Size = new System.Drawing.Size(116, 25);
            this.VisaFileNumberID.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label5.Location = new System.Drawing.Point(7, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Status";
            // 
            // cmbcandidates
            // 
            this.cmbcandidates.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbcandidates.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbcandidates.Enabled = false;
            this.cmbcandidates.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbcandidates.FormattingEnabled = true;
            this.cmbcandidates.Location = new System.Drawing.Point(180, 233);
            this.cmbcandidates.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcandidates.Name = "cmbcandidates";
            this.cmbcandidates.Size = new System.Drawing.Size(277, 25);
            this.cmbcandidates.TabIndex = 44;
            this.cmbcandidates.DropDown += new System.EventHandler(this.cmbcandidates_DropDown);
            this.cmbcandidates.Click += new System.EventHandler(this.cmbcandidates_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label4.Location = new System.Drawing.Point(7, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "File Number";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label13.Location = new System.Drawing.Point(7, 241);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 45;
            this.label13.Text = "Candidate";
            // 
            // cmbConsulate
            // 
            this.cmbConsulate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbConsulate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbConsulate.Enabled = false;
            this.cmbConsulate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbConsulate.FormattingEnabled = true;
            this.cmbConsulate.Location = new System.Drawing.Point(180, 100);
            this.cmbConsulate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbConsulate.Name = "cmbConsulate";
            this.cmbConsulate.Size = new System.Drawing.Size(155, 25);
            this.cmbConsulate.TabIndex = 36;
            this.cmbConsulate.DropDown += new System.EventHandler(this.cmbConsulate_DropDown);
            this.cmbConsulate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbConsulate_KeyDown);
            this.cmbConsulate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbConsulate_KeyPress);
            this.cmbConsulate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbConsulate_MouseDown);
            // 
            // cmbJob
            // 
            this.cmbJob.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbJob.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbJob.Enabled = false;
            this.cmbJob.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbJob.FormattingEnabled = true;
            this.cmbJob.Location = new System.Drawing.Point(180, 129);
            this.cmbJob.Margin = new System.Windows.Forms.Padding(4);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.Size = new System.Drawing.Size(278, 25);
            this.cmbJob.TabIndex = 38;
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbStatus.Enabled = false;
            this.cmbStatus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(180, 163);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(277, 25);
            this.cmbStatus.TabIndex = 42;
            this.cmbStatus.DropDown += new System.EventHandler(this.cmbStatus_DropDown);
            this.cmbStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbStatus_MouseDown);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssign.BackColor = System.Drawing.Color.White;
            this.btnAssign.Enabled = false;
            this.btnAssign.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAssign.FlatAppearance.BorderSize = 0;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnAssign.ForeColor = System.Drawing.Color.Firebrick;
            this.btnAssign.Image = ((System.Drawing.Image)(resources.GetObject("btnAssign.Image")));
            this.btnAssign.Location = new System.Drawing.Point(465, 233);
            this.btnAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(43, 25);
            this.btnAssign.TabIndex = 83;
            this.btnAssign.UseVisualStyleBackColor = false;
            this.btnAssign.Visible = false;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnnewJob
            // 
            this.btnnewJob.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnnewJob.BackColor = System.Drawing.Color.White;
            this.btnnewJob.Enabled = false;
            this.btnnewJob.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnnewJob.FlatAppearance.BorderSize = 0;
            this.btnnewJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnewJob.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnnewJob.ForeColor = System.Drawing.Color.Firebrick;
            this.btnnewJob.Image = ((System.Drawing.Image)(resources.GetObject("btnnewJob.Image")));
            this.btnnewJob.Location = new System.Drawing.Point(459, 127);
            this.btnnewJob.Margin = new System.Windows.Forms.Padding(4);
            this.btnnewJob.Name = "btnnewJob";
            this.btnnewJob.Size = new System.Drawing.Size(51, 32);
            this.btnnewJob.TabIndex = 84;
            this.btnnewJob.UseVisualStyleBackColor = false;
            this.btnnewJob.Click += new System.EventHandler(this.btnnewJob_Click);
            // 
            // cmbAgency
            // 
            this.cmbAgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbAgency.Enabled = false;
            this.cmbAgency.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbAgency.FormattingEnabled = true;
            this.cmbAgency.Location = new System.Drawing.Point(180, 196);
            this.cmbAgency.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAgency.Name = "cmbAgency";
            this.cmbAgency.Size = new System.Drawing.Size(277, 25);
            this.cmbAgency.TabIndex = 85;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label14.Location = new System.Drawing.Point(7, 197);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 17);
            this.label14.TabIndex = 86;
            this.label14.Text = "Agency";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.button2.ForeColor = System.Drawing.Color.Firebrick;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(459, 196);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 29);
            this.button2.TabIndex = 87;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label15.Location = new System.Drawing.Point(7, 272);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 17);
            this.label15.TabIndex = 88;
            this.label15.Text = "Selected Candidate";
            // 
            // cmbcandidates2
            // 
            this.cmbcandidates2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbcandidates2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbcandidates2.Enabled = false;
            this.cmbcandidates2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbcandidates2.FormattingEnabled = true;
            this.cmbcandidates2.Location = new System.Drawing.Point(180, 269);
            this.cmbcandidates2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcandidates2.Name = "cmbcandidates2";
            this.cmbcandidates2.Size = new System.Drawing.Size(277, 25);
            this.cmbcandidates2.TabIndex = 89;
            this.cmbcandidates2.Click += new System.EventHandler(this.cmbcandidates2_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label16.Location = new System.Drawing.Point(7, 66);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 17);
            this.label16.TabIndex = 88;
            this.label16.Text = "Reserved To";
            // 
            // cmbReservedTo
            // 
            this.cmbReservedTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReservedTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbReservedTo.Enabled = false;
            this.cmbReservedTo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbReservedTo.FormattingEnabled = true;
            this.cmbReservedTo.Location = new System.Drawing.Point(180, 61);
            this.cmbReservedTo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReservedTo.Name = "cmbReservedTo";
            this.cmbReservedTo.Size = new System.Drawing.Size(322, 25);
            this.cmbReservedTo.TabIndex = 87;
            this.cmbReservedTo.DropDown += new System.EventHandler(this.cmbReservedTo_DropDown);
            this.cmbReservedTo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbReservedTo_MouseDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbReservedTo);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.cmbcandidates2);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.cmbAgency);
            this.groupBox3.Controls.Add(this.btnnewJob);
            this.groupBox3.Controls.Add(this.btnAssign);
            this.groupBox3.Controls.Add(this.cmbStatus);
            this.groupBox3.Controls.Add(this.cmbJob);
            this.groupBox3.Controls.Add(this.cmbConsulate);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbcandidates);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.VisaFileNumberID);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label44);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.groupBox3.Location = new System.Drawing.Point(12, 338);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1619, 333);
            this.groupBox3.TabIndex = 90;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visa JobList";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // VisaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1643, 813);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbldatetime);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupbox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.Findbtn);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VisaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.VisaFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisaFrm_KeyUp);
            this.groupbox.ResumeLayout(false);
            this.groupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox Visanumtxt;
        private System.Windows.Forms.TextBox TotalVisastxt;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RemarksTxt;
        private System.Windows.Forms.TextBox IssueDateENTxt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox expairENDATEtxt;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Remaininglbl;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ExpiaryHijritxt;
        private System.Windows.Forms.TextBox issuhijritxt;
        private System.Windows.Forms.DateTimePicker ReceviedPicker;
        private System.Windows.Forms.Button Findbtn;
        private System.Windows.Forms.GroupBox groupbox;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtsponserID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCRNumber;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label lbldatetime;
        private System.Windows.Forms.Button btnwexpire;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label txtvisa;
        private System.Windows.Forms.PictureBox picVisa;
        private System.Windows.Forms.Label lblexpire;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox Searchtxt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox ChkUsedbx;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox VisaFileNumberID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbcandidates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbConsulate;
        private System.Windows.Forms.ComboBox cmbJob;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnnewJob;
        private System.Windows.Forms.ComboBox cmbAgency;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbcandidates2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbReservedTo;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}