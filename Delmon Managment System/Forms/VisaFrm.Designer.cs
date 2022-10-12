
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
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.Visanumtxt = new System.Windows.Forms.TextBox();
            this.TotalVisastxt = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IssueDateHijriPicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ExpiryDateHijriPicker = new System.Windows.Forms.DateTimePicker();
            this.ExpiryDateENPicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.IssueDateENPicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RemarksTxt = new System.Windows.Forms.TextBox();
            this.IssueDateENTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ExpiaryHijritxt = new System.Windows.Forms.TextBox();
            this.expairENDATEtxt = new System.Windows.Forms.TextBox();
            this.issuhijritxt = new System.Windows.Forms.TextBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BorderIDtxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.INDVVIsanumtxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbJob = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cmbConsulate = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ReceviedPicker = new System.Windows.Forms.DateTimePicker();
            this.btnFinish = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visa Number";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 115);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 13);
            this.label25.TabIndex = 1;
            this.label25.Text = "Issue Date Hijri";
            // 
            // Visanumtxt
            // 
            this.Visanumtxt.Location = new System.Drawing.Point(99, 35);
            this.Visanumtxt.Name = "Visanumtxt";
            this.Visanumtxt.Size = new System.Drawing.Size(134, 20);
            this.Visanumtxt.TabIndex = 3;
            this.Visanumtxt.TextChanged += new System.EventHandler(this.Visanumtxt_TextChanged);
            this.Visanumtxt.Leave += new System.EventHandler(this.Visanumtxt_Leave);
            // 
            // TotalVisastxt
            // 
            this.TotalVisastxt.Location = new System.Drawing.Point(103, 207);
            this.TotalVisastxt.Name = "TotalVisastxt";
            this.TotalVisastxt.Size = new System.Drawing.Size(100, 20);
            this.TotalVisastxt.TabIndex = 4;
            this.TotalVisastxt.TextChanged += new System.EventHandler(this.TotalVisastxt_TextChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Location = new System.Drawing.Point(1055, 309);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 39);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Indv.Visa";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 22);
            this.panel1.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visasToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "Visa";
            // 
            // visasToolStripMenuItem
            // 
            this.visasToolStripMenuItem.Name = "visasToolStripMenuItem";
            this.visasToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.visasToolStripMenuItem.Text = "Visas";
            this.visasToolStripMenuItem.Click += new System.EventHandler(this.visasToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 430);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1030, 188);
            this.dataGridView1.TabIndex = 9;
            // 
            // IssueDateHijriPicker
            // 
            this.IssueDateHijriPicker.CustomFormat = "";
            this.IssueDateHijriPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.IssueDateHijriPicker.Location = new System.Drawing.Point(114, 19);
            this.IssueDateHijriPicker.Name = "IssueDateHijriPicker";
            this.IssueDateHijriPicker.Size = new System.Drawing.Size(100, 20);
            this.IssueDateHijriPicker.TabIndex = 15;
            this.IssueDateHijriPicker.Visible = false;
            this.IssueDateHijriPicker.ValueChanged += new System.EventHandler(this.IssueDateHijriPicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Expiry Date Hijri";
            // 
            // ExpiryDateHijriPicker
            // 
            this.ExpiryDateHijriPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ExpiryDateHijriPicker.Location = new System.Drawing.Point(114, 48);
            this.ExpiryDateHijriPicker.Name = "ExpiryDateHijriPicker";
            this.ExpiryDateHijriPicker.Size = new System.Drawing.Size(100, 20);
            this.ExpiryDateHijriPicker.TabIndex = 17;
            this.ExpiryDateHijriPicker.Visible = false;
            this.ExpiryDateHijriPicker.ValueChanged += new System.EventHandler(this.ExpiryDateHijriPicker_ValueChanged);
            // 
            // ExpiryDateENPicker
            // 
            this.ExpiryDateENPicker.Enabled = false;
            this.ExpiryDateENPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ExpiryDateENPicker.Location = new System.Drawing.Point(433, 146);
            this.ExpiryDateENPicker.Name = "ExpiryDateENPicker";
            this.ExpiryDateENPicker.Size = new System.Drawing.Size(171, 20);
            this.ExpiryDateENPicker.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Expiry Date EN";
            // 
            // IssueDateENPicker
            // 
            this.IssueDateENPicker.Enabled = false;
            this.IssueDateENPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.IssueDateENPicker.Location = new System.Drawing.Point(99, 147);
            this.IssueDateENPicker.Name = "IssueDateENPicker";
            this.IssueDateENPicker.Size = new System.Drawing.Size(134, 20);
            this.IssueDateENPicker.TabIndex = 19;
            this.IssueDateENPicker.ValueChanged += new System.EventHandler(this.IssueDateENPicker_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Issue Date EN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(337, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Remarks";
            // 
            // RemarksTxt
            // 
            this.RemarksTxt.Location = new System.Drawing.Point(433, 207);
            this.RemarksTxt.Multiline = true;
            this.RemarksTxt.Name = "RemarksTxt";
            this.RemarksTxt.Size = new System.Drawing.Size(264, 74);
            this.RemarksTxt.TabIndex = 23;
            this.RemarksTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // IssueDateENTxt
            // 
            this.IssueDateENTxt.Location = new System.Drawing.Point(103, 147);
            this.IssueDateENTxt.Multiline = true;
            this.IssueDateENTxt.Name = "IssueDateENTxt";
            this.IssueDateENTxt.Size = new System.Drawing.Size(126, 18);
            this.IssueDateENTxt.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IssueDateHijriPicker);
            this.groupBox1.Controls.Add(this.ExpiryDateHijriPicker);
            this.groupBox1.Location = new System.Drawing.Point(852, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 190);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // ExpiaryHijritxt
            // 
            this.ExpiaryHijritxt.Enabled = false;
            this.ExpiaryHijritxt.Location = new System.Drawing.Point(433, 115);
            this.ExpiaryHijritxt.Multiline = true;
            this.ExpiaryHijritxt.Name = "ExpiaryHijritxt";
            this.ExpiaryHijritxt.Size = new System.Drawing.Size(171, 20);
            this.ExpiaryHijritxt.TabIndex = 31;
            // 
            // expairENDATEtxt
            // 
            this.expairENDATEtxt.Location = new System.Drawing.Point(433, 146);
            this.expairENDATEtxt.Multiline = true;
            this.expairENDATEtxt.Name = "expairENDATEtxt";
            this.expairENDATEtxt.Size = new System.Drawing.Size(171, 20);
            this.expairENDATEtxt.TabIndex = 32;
            // 
            // issuhijritxt
            // 
            this.issuhijritxt.ForeColor = System.Drawing.Color.Gray;
            this.issuhijritxt.Location = new System.Drawing.Point(99, 115);
            this.issuhijritxt.Name = "issuhijritxt";
            this.issuhijritxt.Size = new System.Drawing.Size(134, 20);
            this.issuhijritxt.TabIndex = 33;
            this.issuhijritxt.Text = "dd/MM/yyyy";
            this.issuhijritxt.TextChanged += new System.EventHandler(this.issuhijritxt_TextChanged);
            this.issuhijritxt.DragEnter += new System.Windows.Forms.DragEventHandler(this.issuhijritxt_DragEnter);
            this.issuhijritxt.Enter += new System.EventHandler(this.issuhijritxt_Enter);
            this.issuhijritxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.issuhijritxt_KeyDown);
            this.issuhijritxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.issuhijritxt_KeyUp);
            this.issuhijritxt.Leave += new System.EventHandler(this.issuhijritxt_Leave);
            this.issuhijritxt.MouseEnter += new System.EventHandler(this.issuhijritxt_MouseEnter);
            // 
            // cmbCompany
            // 
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(433, 34);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(225, 21);
            this.cmbCompany.TabIndex = 34;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Company";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.BorderIDtxt);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.INDVVIsanumtxt);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbJob);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.cmbConsulate);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(103, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(937, 71);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(708, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Border ID";
            // 
            // BorderIDtxt
            // 
            this.BorderIDtxt.Location = new System.Drawing.Point(766, 23);
            this.BorderIDtxt.Name = "BorderIDtxt";
            this.BorderIDtxt.Size = new System.Drawing.Size(136, 20);
            this.BorderIDtxt.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Visa Number";
            // 
            // INDVVIsanumtxt
            // 
            this.INDVVIsanumtxt.Enabled = false;
            this.INDVVIsanumtxt.Location = new System.Drawing.Point(100, 22);
            this.INDVVIsanumtxt.Name = "INDVVIsanumtxt";
            this.INDVVIsanumtxt.Size = new System.Drawing.Size(113, 20);
            this.INDVVIsanumtxt.TabIndex = 40;
            this.INDVVIsanumtxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(506, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Job";
            // 
            // cmbJob
            // 
            this.cmbJob.FormattingEnabled = true;
            this.cmbJob.Location = new System.Drawing.Point(536, 23);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.Size = new System.Drawing.Size(157, 21);
            this.cmbJob.TabIndex = 38;
            this.cmbJob.SelectedIndexChanged += new System.EventHandler(this.cmbJob_SelectedIndexChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(232, 27);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(74, 13);
            this.label44.TabIndex = 37;
            this.label44.Text = "Consulate City";
            this.label44.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbConsulate
            // 
            this.cmbConsulate.FormattingEnabled = true;
            this.cmbConsulate.Location = new System.Drawing.Point(330, 22);
            this.cmbConsulate.Name = "cmbConsulate";
            this.cmbConsulate.Size = new System.Drawing.Size(133, 21);
            this.cmbConsulate.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Recived Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 39;
            this.label4.Text = "Total Visas";
            // 
            // ReceviedPicker
            // 
            this.ReceviedPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ReceviedPicker.Location = new System.Drawing.Point(99, 70);
            this.ReceviedPicker.Name = "ReceviedPicker";
            this.ReceviedPicker.Size = new System.Drawing.Size(134, 20);
            this.ReceviedPicker.TabIndex = 40;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Location = new System.Drawing.Point(1055, 579);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 39);
            this.btnFinish.TabIndex = 41;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // VisaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1244, 715);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.ReceviedPicker);
            this.Controls.Add(this.IssueDateENPicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ExpiryDateENPicker);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.issuhijritxt);
            this.Controls.Add(this.expairENDATEtxt);
            this.Controls.Add(this.ExpiaryHijritxt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IssueDateENTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RemarksTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.TotalVisastxt);
            this.Controls.Add(this.Visanumtxt);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VisaFrm";
            this.Text = "Visas";
            this.Load += new System.EventHandler(this.VisaFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisaFrm_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox Visanumtxt;
        private System.Windows.Forms.TextBox TotalVisastxt;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visasToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker IssueDateHijriPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ExpiryDateHijriPicker;
        private System.Windows.Forms.DateTimePicker ExpiryDateENPicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker IssueDateENPicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RemarksTxt;
        private System.Windows.Forms.TextBox IssueDateENTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox ExpiaryHijritxt;
        private System.Windows.Forms.TextBox expairENDATEtxt;
        private System.Windows.Forms.TextBox issuhijritxt;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox INDVVIsanumtxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbJob;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox cmbConsulate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox BorderIDtxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ReceviedPicker;
        private System.Windows.Forms.Button btnFinish;
    }
}