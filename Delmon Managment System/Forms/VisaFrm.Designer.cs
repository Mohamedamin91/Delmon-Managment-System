
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisaFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.Visanumtxt = new System.Windows.Forms.TextBox();
            this.TotalVisastxt = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbJob = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cmbConsulate = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ReceviedPicker = new System.Windows.Forms.DateTimePicker();
            this.btnFinish = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Remaininglbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.FileNumber = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visa Number";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 163);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 13);
            this.label25.TabIndex = 1;
            this.label25.Text = "Issue Date Hijri";
            // 
            // Visanumtxt
            // 
            this.Visanumtxt.Location = new System.Drawing.Point(100, 83);
            this.Visanumtxt.Name = "Visanumtxt";
            this.Visanumtxt.Size = new System.Drawing.Size(134, 20);
            this.Visanumtxt.TabIndex = 3;
            this.Visanumtxt.TextChanged += new System.EventHandler(this.Visanumtxt_TextChanged);
            this.Visanumtxt.Leave += new System.EventHandler(this.Visanumtxt_Leave);
            // 
            // TotalVisastxt
            // 
            this.TotalVisastxt.Location = new System.Drawing.Point(284, 30);
            this.TotalVisastxt.Name = "TotalVisastxt";
            this.TotalVisastxt.Size = new System.Drawing.Size(100, 20);
            this.TotalVisastxt.TabIndex = 4;
            this.TotalVisastxt.TextChanged += new System.EventHandler(this.TotalVisastxt_TextChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Location = new System.Drawing.Point(896, 245);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 39);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Visible = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1299, 22);
            this.panel1.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1299, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visasToolStripMenuItem,
            this.candidatesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "Visa";
            // 
            // visasToolStripMenuItem
            // 
            this.visasToolStripMenuItem.Name = "visasToolStripMenuItem";
            this.visasToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.visasToolStripMenuItem.Text = "Visas";
            this.visasToolStripMenuItem.Click += new System.EventHandler(this.visasToolStripMenuItem_Click);
            // 
            // candidatesToolStripMenuItem
            // 
            this.candidatesToolStripMenuItem.Name = "candidatesToolStripMenuItem";
            this.candidatesToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.candidatesToolStripMenuItem.Text = "Employee";
            this.candidatesToolStripMenuItem.Click += new System.EventHandler(this.candidatesToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 448);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(919, 296);
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
            this.label3.Location = new System.Drawing.Point(336, 166);
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
            this.ExpiryDateENPicker.Location = new System.Drawing.Point(434, 194);
            this.ExpiryDateENPicker.Name = "ExpiryDateENPicker";
            this.ExpiryDateENPicker.Size = new System.Drawing.Size(171, 20);
            this.ExpiryDateENPicker.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Expiry Date EN";
            // 
            // IssueDateENPicker
            // 
            this.IssueDateENPicker.Enabled = false;
            this.IssueDateENPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.IssueDateENPicker.Location = new System.Drawing.Point(100, 195);
            this.IssueDateENPicker.Name = "IssueDateENPicker";
            this.IssueDateENPicker.Size = new System.Drawing.Size(134, 20);
            this.IssueDateENPicker.TabIndex = 19;
            this.IssueDateENPicker.ValueChanged += new System.EventHandler(this.IssueDateENPicker_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Issue Date EN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(338, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Remarks";
            // 
            // RemarksTxt
            // 
            this.RemarksTxt.Location = new System.Drawing.Point(434, 250);
            this.RemarksTxt.Multiline = true;
            this.RemarksTxt.Name = "RemarksTxt";
            this.RemarksTxt.Size = new System.Drawing.Size(305, 74);
            this.RemarksTxt.TabIndex = 23;
            this.RemarksTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // IssueDateENTxt
            // 
            this.IssueDateENTxt.Location = new System.Drawing.Point(104, 195);
            this.IssueDateENTxt.Multiline = true;
            this.IssueDateENTxt.Name = "IssueDateENTxt";
            this.IssueDateENTxt.Size = new System.Drawing.Size(126, 18);
            this.IssueDateENTxt.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IssueDateHijriPicker);
            this.groupBox1.Controls.Add(this.ExpiryDateHijriPicker);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(853, 64);
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
            this.ExpiaryHijritxt.Location = new System.Drawing.Point(434, 163);
            this.ExpiaryHijritxt.Multiline = true;
            this.ExpiaryHijritxt.Name = "ExpiaryHijritxt";
            this.ExpiaryHijritxt.Size = new System.Drawing.Size(171, 20);
            this.ExpiaryHijritxt.TabIndex = 31;
            // 
            // expairENDATEtxt
            // 
            this.expairENDATEtxt.Location = new System.Drawing.Point(434, 194);
            this.expairENDATEtxt.Multiline = true;
            this.expairENDATEtxt.Name = "expairENDATEtxt";
            this.expairENDATEtxt.Size = new System.Drawing.Size(171, 20);
            this.expairENDATEtxt.TabIndex = 32;
            // 
            // issuhijritxt
            // 
            this.issuhijritxt.ForeColor = System.Drawing.Color.Gray;
            this.issuhijritxt.Location = new System.Drawing.Point(100, 163);
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
            this.cmbCompany.Location = new System.Drawing.Point(434, 82);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(305, 21);
            this.cmbCompany.TabIndex = 34;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Company";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.FileNumber);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbStatus);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbJob);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.cmbConsulate);
            this.groupBox2.Controls.Add(this.TotalVisastxt);
            this.groupBox2.Location = new System.Drawing.Point(15, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1015, 72);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(822, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Enabled = false;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(876, 30);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(129, 21);
            this.cmbStatus.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(211, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Total Jobs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(619, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Job";
            // 
            // cmbJob
            // 
            this.cmbJob.Enabled = false;
            this.cmbJob.FormattingEnabled = true;
            this.cmbJob.Location = new System.Drawing.Point(651, 30);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.Size = new System.Drawing.Size(157, 21);
            this.cmbJob.TabIndex = 38;
            this.cmbJob.SelectedIndexChanged += new System.EventHandler(this.cmbJob_SelectedIndexChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(390, 33);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(74, 13);
            this.label44.TabIndex = 37;
            this.label44.Text = "Consulate City";
            this.label44.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbConsulate
            // 
            this.cmbConsulate.Enabled = false;
            this.cmbConsulate.FormattingEnabled = true;
            this.cmbConsulate.Location = new System.Drawing.Point(470, 30);
            this.cmbConsulate.Name = "cmbConsulate";
            this.cmbConsulate.Size = new System.Drawing.Size(133, 21);
            this.cmbConsulate.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Recived Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 18);
            this.label4.TabIndex = 39;
            this.label4.Text = "Visa Job List";
            // 
            // ReceviedPicker
            // 
            this.ReceviedPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ReceviedPicker.Location = new System.Drawing.Point(100, 118);
            this.ReceviedPicker.Name = "ReceviedPicker";
            this.ReceviedPicker.Size = new System.Drawing.Size(134, 20);
            this.ReceviedPicker.TabIndex = 40;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Location = new System.Drawing.Point(896, 460);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 39);
            this.btnFinish.TabIndex = 41;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(139, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 42;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(13, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 16);
            this.label11.TabIndex = 43;
            this.label11.Text = "Remaining days";
            // 
            // Remaininglbl
            // 
            this.Remaininglbl.AutoSize = true;
            this.Remaininglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remaininglbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Remaininglbl.Location = new System.Drawing.Point(181, 250);
            this.Remaininglbl.Name = "Remaininglbl";
            this.Remaininglbl.Size = new System.Drawing.Size(12, 16);
            this.Remaininglbl.TabIndex = 44;
            this.Remaininglbl.Text = "!";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 25);
            this.label13.TabIndex = 81;
            this.label13.Text = "Visa";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(910, 47);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 39);
            this.btnNew.TabIndex = 82;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "File Number";
            // 
            // FileNumber
            // 
            this.FileNumber.Location = new System.Drawing.Point(101, 27);
            this.FileNumber.Name = "FileNumber";
            this.FileNumber.Size = new System.Drawing.Size(100, 20);
            this.FileNumber.TabIndex = 44;
            this.FileNumber.TextChanged += new System.EventHandler(this.FileNumber_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 84;
            this.pictureBox2.TabStop = false;
            // 
            // VisaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1299, 685);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Remaininglbl);
            this.Controls.Add(this.label11);
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
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.Visanumtxt);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VisaFrm";
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox Visanumtxt;
        private System.Windows.Forms.TextBox TotalVisastxt;
        private System.Windows.Forms.Button AddBtn;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbJob;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox cmbConsulate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ReceviedPicker;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Remaininglbl;
        private System.Windows.Forms.ToolStripMenuItem candidatesToolStripMenuItem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox FileNumber;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}