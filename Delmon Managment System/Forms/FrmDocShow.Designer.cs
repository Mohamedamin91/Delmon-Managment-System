
namespace Delmon_Managment_System.Forms
{
    partial class FrmDocShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocShow));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbdoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnshow = new System.Windows.Forms.Button();
            this.btnuplode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.docissueplacepicker = new System.Windows.Forms.DateTimePicker();
            this.docexpirefatepicker = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(188, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Companies Documents ";
            // 
            // cmbdoc
            // 
            this.cmbdoc.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbdoc.FormattingEnabled = true;
            this.cmbdoc.Location = new System.Drawing.Point(37, 151);
            this.cmbdoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbdoc.Name = "cmbdoc";
            this.cmbdoc.Size = new System.Drawing.Size(368, 25);
            this.cmbdoc.TabIndex = 137;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(37, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 136;
            this.label4.Text = "Document Type";
            // 
            // txtpath
            // 
            this.txtpath.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtpath.Location = new System.Drawing.Point(37, 466);
            this.txtpath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(375, 25);
            this.txtpath.TabIndex = 139;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(37, 432);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 138;
            this.label2.Text = "Path";
            // 
            // btnshow
            // 
            this.btnshow.BackColor = System.Drawing.Color.Firebrick;
            this.btnshow.FlatAppearance.BorderSize = 0;
            this.btnshow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnshow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnshow.ForeColor = System.Drawing.Color.White;
            this.btnshow.Location = new System.Drawing.Point(295, 788);
            this.btnshow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(93, 40);
            this.btnshow.TabIndex = 140;
            this.btnshow.Text = "Show";
            this.btnshow.UseVisualStyleBackColor = false;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnuplode
            // 
            this.btnuplode.BackColor = System.Drawing.Color.Firebrick;
            this.btnuplode.FlatAppearance.BorderSize = 0;
            this.btnuplode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnuplode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnuplode.ForeColor = System.Drawing.Color.White;
            this.btnuplode.Location = new System.Drawing.Point(420, 454);
            this.btnuplode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnuplode.Name = "btnuplode";
            this.btnuplode.Size = new System.Drawing.Size(101, 37);
            this.btnuplode.TabIndex = 141;
            this.btnuplode.Text = "Select File";
            this.btnuplode.UseVisualStyleBackColor = false;
            this.btnuplode.Click += new System.EventHandler(this.btnuplode_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(38, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 142;
            this.label3.Text = "Company name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtCompanyName.Location = new System.Drawing.Point(37, 73);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(368, 25);
            this.txtCompanyName.TabIndex = 143;
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.Firebrick;
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(140, 788);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(93, 40);
            this.btnadd.TabIndex = 144;
            this.btnadd.Text = "Save";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // docissueplacepicker
            // 
            this.docissueplacepicker.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.docissueplacepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.docissueplacepicker.Location = new System.Drawing.Point(37, 309);
            this.docissueplacepicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.docissueplacepicker.Name = "docissueplacepicker";
            this.docissueplacepicker.Size = new System.Drawing.Size(367, 25);
            this.docissueplacepicker.TabIndex = 151;
            // 
            // docexpirefatepicker
            // 
            this.docexpirefatepicker.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.docexpirefatepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.docexpirefatepicker.Location = new System.Drawing.Point(37, 388);
            this.docexpirefatepicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.docexpirefatepicker.Name = "docexpirefatepicker";
            this.docexpirefatepicker.Size = new System.Drawing.Size(368, 25);
            this.docexpirefatepicker.TabIndex = 150;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label19.Location = new System.Drawing.Point(37, 275);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 17);
            this.label19.TabIndex = 149;
            this.label19.Text = "IssueDate";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label18.Location = new System.Drawing.Point(37, 354);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 17);
            this.label18.TabIndex = 148;
            this.label18.Text = "ExpireDate";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 538);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(499, 224);
            this.dataGridView1.TabIndex = 155;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtFilename
            // 
            this.txtFilename.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtFilename.Location = new System.Drawing.Point(37, 221);
            this.txtFilename.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(367, 25);
            this.txtFilename.TabIndex = 157;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(37, 190);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 156;
            this.label5.Text = "FileName";
            // 
            // FrmDocShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 872);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.docissueplacepicker);
            this.Controls.Add(this.docexpirefatepicker);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnuplode);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbdoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmDocShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmDocShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbdoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btnuplode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DateTimePicker docissueplacepicker;
        private System.Windows.Forms.DateTimePicker docexpirefatepicker;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label5;
    }
}