
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.VisaReq = new System.Windows.Forms.TabPage();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFullname = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblusertype = new System.Windows.Forms.Label();
            this.Emp = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
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
            this.delmon = new Delmon_Managment_System.Delmon();
            this.tabControl1.SuspendLayout();
            this.VisaReq.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Emp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delmon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.VisaReq);
            this.tabControl1.Controls.Add(this.Emp);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1545, 1049);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // VisaReq
            // 
            this.VisaReq.Controls.Add(this.cmbCompany);
            this.VisaReq.Controls.Add(this.label2);
            this.VisaReq.Controls.Add(this.cmbStatus);
            this.VisaReq.Controls.Add(this.label5);
            this.VisaReq.Controls.Add(this.reportViewer1);
            this.VisaReq.Controls.Add(this.button1);
            this.VisaReq.Controls.Add(this.label1);
            this.VisaReq.Controls.Add(this.dtpto);
            this.VisaReq.Controls.Add(this.label16);
            this.VisaReq.Controls.Add(this.dtpfrom);
            this.VisaReq.Controls.Add(this.groupBox1);
            this.VisaReq.Location = new System.Drawing.Point(4, 26);
            this.VisaReq.Name = "VisaReq";
            this.VisaReq.Padding = new System.Windows.Forms.Padding(3);
            this.VisaReq.Size = new System.Drawing.Size(1537, 1019);
            this.VisaReq.TabIndex = 0;
            this.VisaReq.Text = "Visa";
            this.VisaReq.UseVisualStyleBackColor = true;
            this.VisaReq.Click += new System.EventHandler(this.VisaReq_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(645, 26);
            this.cmbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(322, 23);
            this.cmbCompany.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(579, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 116;
            this.label2.Text = "Company";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(344, 26);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(179, 23);
            this.cmbStatus.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(270, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 114;
            this.label5.Text = "Visa Status";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Delmon_Managment_System.VisaReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 106);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1288, 935);
            this.reportViewer1.TabIndex = 112;
            this.reportViewer1.Visible = false;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(784, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 36);
            this.button1.TabIndex = 111;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(590, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 109;
            this.label1.Text = "To:";
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(645, 71);
            this.dtpto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(121, 22);
            this.dtpto.TabIndex = 110;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(341, 76);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 15);
            this.label16.TabIndex = 107;
            this.label16.Text = "From:";
            // 
            // dtpfrom
            // 
            this.dtpfrom.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrom.Location = new System.Drawing.Point(402, 71);
            this.dtpfrom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(121, 22);
            this.dtpfrom.TabIndex = 108;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFullname);
            this.groupBox1.Controls.Add(this.lblPC);
            this.groupBox1.Controls.Add(this.lbldatetime);
            this.groupBox1.Controls.Add(this.lblemail);
            this.groupBox1.Controls.Add(this.lblusername);
            this.groupBox1.Controls.Add(this.lblusertype);
            this.groupBox1.Location = new System.Drawing.Point(1326, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 189);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Info";
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblFullname.Location = new System.Drawing.Point(7, 58);
            this.lblFullname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(63, 15);
            this.lblFullname.TabIndex = 104;
            this.lblFullname.Text = "Full Name";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblPC.Location = new System.Drawing.Point(7, 128);
            this.lblPC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(21, 15);
            this.lblPC.TabIndex = 103;
            this.lblPC.Text = "Pc";
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatetime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lbldatetime.Location = new System.Drawing.Point(7, 156);
            this.lbldatetime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(60, 15);
            this.lbldatetime.TabIndex = 102;
            this.lbldatetime.Text = "Date&Time";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblemail.Location = new System.Drawing.Point(7, 83);
            this.lblemail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(38, 15);
            this.lblemail.TabIndex = 101;
            this.lblemail.Text = "Email";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusername.Location = new System.Drawing.Point(7, 34);
            this.lblusername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(64, 15);
            this.lblusername.TabIndex = 99;
            this.lblusername.Text = "UserName";
            // 
            // lblusertype
            // 
            this.lblusertype.AutoSize = true;
            this.lblusertype.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusertype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusertype.Location = new System.Drawing.Point(7, 106);
            this.lblusertype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblusertype.Name = "lblusertype";
            this.lblusertype.Size = new System.Drawing.Size(58, 15);
            this.lblusertype.TabIndex = 100;
            this.lblusertype.Text = "UserType";
            // 
            // Emp
            // 
            this.Emp.Controls.Add(this.reportViewer2);
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
            this.Emp.Location = new System.Drawing.Point(4, 26);
            this.Emp.Name = "Emp";
            this.Emp.Padding = new System.Windows.Forms.Padding(3);
            this.Emp.Size = new System.Drawing.Size(1537, 1019);
            this.Emp.TabIndex = 1;
            this.Emp.Text = "Candidates";
            this.Emp.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Delmon_Managment_System.CandidateReport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(56, 139);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1461, 533);
            this.reportViewer2.TabIndex = 131;
            this.reportViewer2.Visible = false;
            // 
            // cmbcandidates2
            // 
            this.cmbcandidates2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcandidates2.FormattingEnabled = true;
            this.cmbcandidates2.Location = new System.Drawing.Point(249, 38);
            this.cmbcandidates2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcandidates2.Name = "cmbcandidates2";
            this.cmbcandidates2.Size = new System.Drawing.Size(243, 23);
            this.cmbcandidates2.TabIndex = 130;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(134, 43);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 129;
            this.label8.Text = "Candidate Name";
            // 
            // cmbPersonalStatusStatus
            // 
            this.cmbPersonalStatusStatus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPersonalStatusStatus.FormattingEnabled = true;
            this.cmbPersonalStatusStatus.Location = new System.Drawing.Point(622, 35);
            this.cmbPersonalStatusStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPersonalStatusStatus.Name = "cmbPersonalStatusStatus";
            this.cmbPersonalStatusStatus.Size = new System.Drawing.Size(206, 23);
            this.cmbPersonalStatusStatus.TabIndex = 128;
            // 
            // cmbcomp
            // 
            this.cmbcomp.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcomp.FormattingEnabled = true;
            this.cmbcomp.Location = new System.Drawing.Point(917, 34);
            this.cmbcomp.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcomp.Name = "cmbcomp";
            this.cmbcomp.Size = new System.Drawing.Size(322, 23);
            this.cmbcomp.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(851, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 125;
            this.label3.Text = "Company";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(517, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 123;
            this.label4.Text = "Candidate Status";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(977, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 36);
            this.button2.TabIndex = 121;
            this.button2.Text = "Print";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(701, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 15);
            this.label6.TabIndex = 119;
            this.label6.Text = "To:";
            // 
            // FromDate
            // 
            this.FromDate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDate.Location = new System.Drawing.Point(499, 74);
            this.FromDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(121, 22);
            this.FromDate.TabIndex = 120;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(452, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 117;
            this.label7.Text = "From:";
            // 
            // todate
            // 
            this.todate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.todate.Location = new System.Drawing.Point(756, 74);
            this.todate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(121, 22);
            this.todate.TabIndex = 118;
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
            this.ClientSize = new System.Drawing.Size(1557, 1061);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PrintingFrm";
            this.Text = "Request Forms";
            this.Load += new System.EventHandler(this.PrintingFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.VisaReq.ResumeLayout(false);
            this.VisaReq.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Emp.ResumeLayout(false);
            this.Emp.PerformLayout();
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
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
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
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}