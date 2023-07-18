
namespace Delmon_Managment_System.Forms
{
    partial class PrintingFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.VisaReq = new System.Windows.Forms.TabPage();
            this.cmbReservedTo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSelect = new System.Windows.Forms.CheckBox();
            this.cbVISAStamped = new System.Windows.Forms.CheckBox();
            this.cbVISAExpiredAfterStamped = new System.Windows.Forms.CheckBox();
            this.cbNotused = new System.Windows.Forms.CheckBox();
            this.cbRefunded = new System.Windows.Forms.CheckBox();
            this.cbReserved = new System.Windows.Forms.CheckBox();
            this.cbExpired = new System.Windows.Forms.CheckBox();
            this.cbUnderProcess = new System.Windows.Forms.CheckBox();
            this.cbUsed = new System.Windows.Forms.CheckBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.Emp = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbcandidates2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPersonalStatusStatus = new System.Windows.Forms.ComboBox();
            this.cmbcomp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFullname = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblusertype = new System.Windows.Forms.Label();
            this.delmon = new Delmon_Managment_System.Delmon();
            this.tabControl1.SuspendLayout();
            this.VisaReq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.Emp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delmon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.VisaReq);
            this.tabControl1.Controls.Add(this.Emp);
            this.tabControl1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1317, 1049);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // VisaReq
            // 
            this.VisaReq.Controls.Add(this.cmbReservedTo);
            this.VisaReq.Controls.Add(this.label5);
            this.VisaReq.Controls.Add(this.dataGridView4);
            this.VisaReq.Controls.Add(this.dataGridView2);
            this.VisaReq.Controls.Add(this.button3);
            this.VisaReq.Controls.Add(this.groupBox2);
            this.VisaReq.Controls.Add(this.cmbCompany);
            this.VisaReq.Controls.Add(this.label2);
            this.VisaReq.Controls.Add(this.button1);
            this.VisaReq.Controls.Add(this.label1);
            this.VisaReq.Controls.Add(this.dtpto);
            this.VisaReq.Controls.Add(this.label16);
            this.VisaReq.Controls.Add(this.dtpfrom);
            this.VisaReq.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.VisaReq.Location = new System.Drawing.Point(4, 26);
            this.VisaReq.Name = "VisaReq";
            this.VisaReq.Padding = new System.Windows.Forms.Padding(3);
            this.VisaReq.Size = new System.Drawing.Size(1309, 1019);
            this.VisaReq.TabIndex = 0;
            this.VisaReq.Text = "Visa";
            this.VisaReq.UseVisualStyleBackColor = true;
            this.VisaReq.Click += new System.EventHandler(this.VisaReq_Click);
            // 
            // cmbReservedTo
            // 
            this.cmbReservedTo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbReservedTo.FormattingEnabled = true;
            this.cmbReservedTo.Location = new System.Drawing.Point(332, 155);
            this.cmbReservedTo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReservedTo.Name = "cmbReservedTo";
            this.cmbReservedTo.Size = new System.Drawing.Size(161, 25);
            this.cmbReservedTo.TabIndex = 145;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label5.Location = new System.Drawing.Point(329, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 146;
            this.label5.Text = "ReservedTo";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(33, 603);
            this.dataGridView4.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView4.Name = "dataGridView4";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView4.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView4.Size = new System.Drawing.Size(1249, 276);
            this.dataGridView4.TabIndex = 144;
            this.dataGridView4.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(33, 270);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Size = new System.Drawing.Size(1249, 310);
            this.dataGridView2.TabIndex = 143;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(729, 206);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 36);
            this.button3.TabIndex = 142;
            this.button3.Text = "Display";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSelect);
            this.groupBox2.Controls.Add(this.cbVISAStamped);
            this.groupBox2.Controls.Add(this.cbVISAExpiredAfterStamped);
            this.groupBox2.Controls.Add(this.cbNotused);
            this.groupBox2.Controls.Add(this.cbRefunded);
            this.groupBox2.Controls.Add(this.cbReserved);
            this.groupBox2.Controls.Add(this.cbExpired);
            this.groupBox2.Controls.Add(this.cbUnderProcess);
            this.groupBox2.Controls.Add(this.cbUsed);
            this.groupBox2.Location = new System.Drawing.Point(332, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 104);
            this.groupBox2.TabIndex = 141;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visa Status";
            // 
            // cbSelect
            // 
            this.cbSelect.AutoSize = true;
            this.cbSelect.Location = new System.Drawing.Point(11, 29);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(96, 21);
            this.cbSelect.TabIndex = 141;
            this.cbSelect.Text = "Select All";
            this.cbSelect.UseVisualStyleBackColor = true;
            this.cbSelect.CheckedChanged += new System.EventHandler(this.cbSelect_CheckedChanged);
            // 
            // cbVISAStamped
            // 
            this.cbVISAStamped.AutoSize = true;
            this.cbVISAStamped.Location = new System.Drawing.Point(355, 74);
            this.cbVISAStamped.Name = "cbVISAStamped";
            this.cbVISAStamped.Size = new System.Drawing.Size(131, 21);
            this.cbVISAStamped.TabIndex = 136;
            this.cbVISAStamped.Text = "VISA Stamped";
            this.cbVISAStamped.UseVisualStyleBackColor = true;
            this.cbVISAStamped.CheckedChanged += new System.EventHandler(this.cbVISAStamped_CheckedChanged);
            // 
            // cbVISAExpiredAfterStamped
            // 
            this.cbVISAExpiredAfterStamped.AutoSize = true;
            this.cbVISAExpiredAfterStamped.Location = new System.Drawing.Point(11, 74);
            this.cbVISAExpiredAfterStamped.Name = "cbVISAExpiredAfterStamped";
            this.cbVISAExpiredAfterStamped.Size = new System.Drawing.Size(232, 21);
            this.cbVISAExpiredAfterStamped.TabIndex = 140;
            this.cbVISAExpiredAfterStamped.Text = "VISA Expired After Stamped";
            this.cbVISAExpiredAfterStamped.UseVisualStyleBackColor = true;
            this.cbVISAExpiredAfterStamped.CheckedChanged += new System.EventHandler(this.cbVISAExpiredAfterStamped_CheckedChanged);
            // 
            // cbNotused
            // 
            this.cbNotused.AutoSize = true;
            this.cbNotused.Location = new System.Drawing.Point(355, 29);
            this.cbNotused.Name = "cbNotused";
            this.cbNotused.Size = new System.Drawing.Size(93, 21);
            this.cbNotused.TabIndex = 133;
            this.cbNotused.Text = "Not Used";
            this.cbNotused.UseVisualStyleBackColor = true;
            this.cbNotused.CheckedChanged += new System.EventHandler(this.cbNotused_CheckedChanged);
            // 
            // cbRefunded
            // 
            this.cbRefunded.AutoSize = true;
            this.cbRefunded.Location = new System.Drawing.Point(146, 29);
            this.cbRefunded.Name = "cbRefunded";
            this.cbRefunded.Size = new System.Drawing.Size(97, 21);
            this.cbRefunded.TabIndex = 139;
            this.cbRefunded.Text = "Refunded";
            this.cbRefunded.UseVisualStyleBackColor = true;
            this.cbRefunded.CheckedChanged += new System.EventHandler(this.cbRefunded_CheckedChanged);
            // 
            // cbReserved
            // 
            this.cbReserved.AutoSize = true;
            this.cbReserved.Location = new System.Drawing.Point(492, 28);
            this.cbReserved.Name = "cbReserved";
            this.cbReserved.Size = new System.Drawing.Size(97, 21);
            this.cbReserved.TabIndex = 134;
            this.cbReserved.Text = "Reserved";
            this.cbReserved.UseVisualStyleBackColor = true;
            this.cbReserved.CheckedChanged += new System.EventHandler(this.cbReserved_CheckedChanged);
            // 
            // cbExpired
            // 
            this.cbExpired.AutoSize = true;
            this.cbExpired.Location = new System.Drawing.Point(260, 28);
            this.cbExpired.Name = "cbExpired";
            this.cbExpired.Size = new System.Drawing.Size(83, 21);
            this.cbExpired.TabIndex = 138;
            this.cbExpired.Text = "Expired";
            this.cbExpired.UseVisualStyleBackColor = true;
            this.cbExpired.CheckedChanged += new System.EventHandler(this.cbExpired_CheckedChanged);
            // 
            // cbUnderProcess
            // 
            this.cbUnderProcess.AutoSize = true;
            this.cbUnderProcess.Location = new System.Drawing.Point(492, 74);
            this.cbUnderProcess.Name = "cbUnderProcess";
            this.cbUnderProcess.Size = new System.Drawing.Size(136, 21);
            this.cbUnderProcess.TabIndex = 135;
            this.cbUnderProcess.Text = "Under Process";
            this.cbUnderProcess.UseVisualStyleBackColor = true;
            this.cbUnderProcess.CheckedChanged += new System.EventHandler(this.cbUnderProcess_CheckedChanged);
            // 
            // cbUsed
            // 
            this.cbUsed.AutoSize = true;
            this.cbUsed.Location = new System.Drawing.Point(260, 74);
            this.cbUsed.Name = "cbUsed";
            this.cbUsed.Size = new System.Drawing.Size(64, 21);
            this.cbUsed.TabIndex = 137;
            this.cbUsed.Text = "Used";
            this.cbUsed.UseVisualStyleBackColor = true;
            this.cbUsed.CheckedChanged += new System.EventHandler(this.cbUsed_CheckedChanged);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(524, 155);
            this.cmbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(170, 25);
            this.cmbCompany.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label2.Location = new System.Drawing.Point(521, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 116;
            this.label2.Text = "Company";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(813, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 36);
            this.button1.TabIndex = 111;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label1.Location = new System.Drawing.Point(521, 196);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 109;
            this.label1.Text = "To:";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(524, 217);
            this.dtpto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(170, 25);
            this.dtpto.TabIndex = 110;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label16.Location = new System.Drawing.Point(332, 196);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 17);
            this.label16.TabIndex = 107;
            this.label16.Text = "From:";
            // 
            // dtpfrom
            // 
            this.dtpfrom.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrom.Location = new System.Drawing.Point(335, 217);
            this.dtpfrom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(158, 25);
            this.dtpfrom.TabIndex = 108;
            // 
            // Emp
            // 
            this.Emp.Controls.Add(this.dataGridView3);
            this.Emp.Controls.Add(this.dataGridView1);
            this.Emp.Controls.Add(this.button4);
            this.Emp.Controls.Add(this.cmbcandidates2);
            this.Emp.Controls.Add(this.label8);
            this.Emp.Controls.Add(this.cmbPersonalStatusStatus);
            this.Emp.Controls.Add(this.cmbcomp);
            this.Emp.Controls.Add(this.label3);
            this.Emp.Controls.Add(this.label4);
            this.Emp.Controls.Add(this.button2);
            this.Emp.Controls.Add(this.label6);
            this.Emp.Controls.Add(this.FromDate);
            this.Emp.Controls.Add(this.label7);
            this.Emp.Controls.Add(this.todate);
            this.Emp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Emp.Location = new System.Drawing.Point(4, 26);
            this.Emp.Name = "Emp";
            this.Emp.Padding = new System.Windows.Forms.Padding(3);
            this.Emp.Size = new System.Drawing.Size(1309, 1019);
            this.Emp.TabIndex = 1;
            this.Emp.Text = "Candidates";
            this.Emp.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(268, 247);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.Name = "dataGridView3";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView3.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView3.Size = new System.Drawing.Size(827, 268);
            this.dataGridView3.TabIndex = 146;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView3_CellFormatting);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(268, 523);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(827, 277);
            this.dataGridView1.TabIndex = 144;
            this.dataGridView1.Visible = false;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(718, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 36);
            this.button4.TabIndex = 143;
            this.button4.Text = "Display";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmbcandidates2
            // 
            this.cmbcandidates2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbcandidates2.FormattingEnabled = true;
            this.cmbcandidates2.Location = new System.Drawing.Point(458, 33);
            this.cmbcandidates2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcandidates2.Name = "cmbcandidates2";
            this.cmbcandidates2.Size = new System.Drawing.Size(259, 25);
            this.cmbcandidates2.TabIndex = 130;
            this.cmbcandidates2.SelectedIndexChanged += new System.EventHandler(this.cmbcandidates2_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label8.Location = new System.Drawing.Point(455, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 129;
            this.label8.Text = "Candidate Name";
            // 
            // cmbPersonalStatusStatus
            // 
            this.cmbPersonalStatusStatus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbPersonalStatusStatus.FormattingEnabled = true;
            this.cmbPersonalStatusStatus.Location = new System.Drawing.Point(458, 90);
            this.cmbPersonalStatusStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPersonalStatusStatus.Name = "cmbPersonalStatusStatus";
            this.cmbPersonalStatusStatus.Size = new System.Drawing.Size(259, 25);
            this.cmbPersonalStatusStatus.TabIndex = 128;
            this.cmbPersonalStatusStatus.SelectedIndexChanged += new System.EventHandler(this.cmbPersonalStatusStatus_SelectedIndexChanged);
            // 
            // cmbcomp
            // 
            this.cmbcomp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbcomp.FormattingEnabled = true;
            this.cmbcomp.Location = new System.Drawing.Point(458, 144);
            this.cmbcomp.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcomp.Name = "cmbcomp";
            this.cmbcomp.Size = new System.Drawing.Size(259, 25);
            this.cmbcomp.TabIndex = 124;
            this.cmbcomp.SelectedIndexChanged += new System.EventHandler(this.cmbcomp_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label3.Location = new System.Drawing.Point(455, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 125;
            this.label3.Text = "Company";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label4.Location = new System.Drawing.Point(455, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 17);
            this.label4.TabIndex = 123;
            this.label4.Text = "Candidate Status";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(827, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 36);
            this.button2.TabIndex = 121;
            this.button2.Text = "Print";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label6.Location = new System.Drawing.Point(534, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 119;
            this.label6.Text = "To:";
            // 
            // FromDate
            // 
            this.FromDate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDate.Location = new System.Drawing.Point(378, 191);
            this.FromDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(121, 25);
            this.FromDate.TabIndex = 120;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label7.Location = new System.Drawing.Point(323, 193);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 117;
            this.label7.Text = "From:";
            // 
            // todate
            // 
            this.todate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.todate.Location = new System.Drawing.Point(589, 190);
            this.todate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(121, 25);
            this.todate.TabIndex = 118;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFullname);
            this.groupBox1.Controls.Add(this.lblPC);
            this.groupBox1.Controls.Add(this.lbldatetime);
            this.groupBox1.Controls.Add(this.lblemail);
            this.groupBox1.Controls.Add(this.lblusername);
            this.groupBox1.Controls.Add(this.lblusertype);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(1373, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 242);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Info";
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblFullname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblFullname.Location = new System.Drawing.Point(7, 58);
            this.lblFullname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(80, 17);
            this.lblFullname.TabIndex = 104;
            this.lblFullname.Text = "Full Name";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblPC.Location = new System.Drawing.Point(7, 128);
            this.lblPC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(27, 17);
            this.lblPC.TabIndex = 103;
            this.lblPC.Text = "Pc";
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lbldatetime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lbldatetime.Location = new System.Drawing.Point(7, 156);
            this.lbldatetime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(77, 17);
            this.lbldatetime.TabIndex = 102;
            this.lbldatetime.Text = "Date&Time";
            this.lbldatetime.Visible = false;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblemail.Location = new System.Drawing.Point(7, 83);
            this.lblemail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(48, 17);
            this.lblemail.TabIndex = 101;
            this.lblemail.Text = "Email";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusername.Location = new System.Drawing.Point(7, 34);
            this.lblusername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(85, 17);
            this.lblusername.TabIndex = 99;
            this.lblusername.Text = "UserName";
            // 
            // lblusertype
            // 
            this.lblusertype.AutoSize = true;
            this.lblusertype.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblusertype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusertype.Location = new System.Drawing.Point(7, 106);
            this.lblusertype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblusertype.Name = "lblusertype";
            this.lblusertype.Size = new System.Drawing.Size(78, 17);
            this.lblusertype.TabIndex = 100;
            this.lblusertype.Text = "UserType";
            // 
            // delmon
            // 
            this.delmon.DataSetName = "Delmon";
            this.delmon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PrintingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1692, 1061);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrintingFrm";
            this.Text = "Request Forms";
            this.Load += new System.EventHandler(this.PrintingFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.VisaReq.ResumeLayout(false);
            this.VisaReq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Emp.ResumeLayout(false);
            this.Emp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delmon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage VisaReq;
        private System.Windows.Forms.TabPage Emp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpto;
        public System.Windows.Forms.Label lblFullname;
        public System.Windows.Forms.Label lblPC;
        public System.Windows.Forms.Label lbldatetime;
        private System.Windows.Forms.Label lblemail;
        public System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblusertype;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label2;
        private Delmon delmon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.ComboBox cmbPersonalStatusStatus;
        private System.Windows.Forms.ComboBox cmbcomp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbcandidates2;
        private System.Windows.Forms.CheckBox cbExpired;
        private System.Windows.Forms.CheckBox cbUsed;
        private System.Windows.Forms.CheckBox cbVISAStamped;
        private System.Windows.Forms.CheckBox cbUnderProcess;
        private System.Windows.Forms.CheckBox cbReserved;
        private System.Windows.Forms.CheckBox cbNotused;
        private System.Windows.Forms.CheckBox cbRefunded;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSelect;
        private System.Windows.Forms.CheckBox cbVISAExpiredAfterStamped;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.ComboBox cmbReservedTo;
        private System.Windows.Forms.Label label5;
    }
}