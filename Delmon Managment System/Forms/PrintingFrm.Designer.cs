
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.VisaReq = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPC = new System.Windows.Forms.Label();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblusertype = new System.Windows.Forms.Label();
            this.JobReq = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabControl1.SuspendLayout();
            this.VisaReq.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.VisaReq);
            this.tabControl1.Controls.Add(this.JobReq);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1545, 1049);
            this.tabControl1.TabIndex = 0;
            // 
            // VisaReq
            // 
            this.VisaReq.Controls.Add(this.reportViewer1);
            this.VisaReq.Controls.Add(this.button1);
            this.VisaReq.Controls.Add(this.label1);
            this.VisaReq.Controls.Add(this.dateTimePicker3);
            this.VisaReq.Controls.Add(this.label16);
            this.VisaReq.Controls.Add(this.dateTimePicker1);
            this.VisaReq.Controls.Add(this.groupBox1);
            this.VisaReq.Location = new System.Drawing.Point(4, 26);
            this.VisaReq.Name = "VisaReq";
            this.VisaReq.Padding = new System.Windows.Forms.Padding(3);
            this.VisaReq.Size = new System.Drawing.Size(1537, 1019);
            this.VisaReq.TabIndex = 0;
            this.VisaReq.Text = "Visa";
            this.VisaReq.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(407, 26);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 17);
            this.label16.TabIndex = 107;
            this.label16.Text = "Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(455, 21);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 22);
            this.dateTimePicker1.TabIndex = 108;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPC);
            this.groupBox1.Controls.Add(this.lbldatetime);
            this.groupBox1.Controls.Add(this.lblemail);
            this.groupBox1.Controls.Add(this.lblusername);
            this.groupBox1.Controls.Add(this.lblusertype);
            this.groupBox1.Location = new System.Drawing.Point(1326, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 162);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Info";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblPC.Location = new System.Drawing.Point(4, 89);
            this.lblPC.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(22, 17);
            this.lblPC.TabIndex = 97;
            this.lblPC.Text = "Pc";
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatetime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lbldatetime.Location = new System.Drawing.Point(4, 118);
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
            this.lblemail.Location = new System.Drawing.Point(4, 40);
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
            this.lblusername.Location = new System.Drawing.Point(4, 18);
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
            this.lblusertype.Location = new System.Drawing.Point(4, 65);
            this.lblusertype.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblusertype.Name = "lblusertype";
            this.lblusertype.Size = new System.Drawing.Size(64, 17);
            this.lblusertype.TabIndex = 94;
            this.lblusertype.Text = "UserType";
            // 
            // JobReq
            // 
            this.JobReq.Location = new System.Drawing.Point(4, 26);
            this.JobReq.Name = "JobReq";
            this.JobReq.Padding = new System.Windows.Forms.Padding(3);
            this.JobReq.Size = new System.Drawing.Size(1537, 1019);
            this.JobReq.TabIndex = 1;
            this.JobReq.Text = "Temp";
            this.JobReq.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(586, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 109;
            this.label1.Text = "To:";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Enabled = false;
            this.dateTimePicker3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(621, 20);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(121, 22);
            this.dateTimePicker3.TabIndex = 110;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(759, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 36);
            this.button1.TabIndex = 111;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(32, 71);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1288, 935);
            this.reportViewer1.TabIndex = 112;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage VisaReq;
        private System.Windows.Forms.TabPage JobReq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lbldatetime;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblusertype;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}