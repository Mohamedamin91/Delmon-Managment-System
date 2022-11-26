
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbJob = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cmbConsulate = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Remaininglbl = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ExpiaryHijritxt = new System.Windows.Forms.TextBox();
            this.issuhijritxt = new System.Windows.Forms.TextBox();
            this.ReceviedPicker = new System.Windows.Forms.DateTimePicker();
            this.Findbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbcandidates = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VisaFileNumberID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visa Number";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(20, 153);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(95, 17);
            this.label25.TabIndex = 1;
            this.label25.Text = "Issue Date Hijri";
            // 
            // Visanumtxt
            // 
            this.Visanumtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Visanumtxt.Location = new System.Drawing.Point(158, 41);
            this.Visanumtxt.Margin = new System.Windows.Forms.Padding(4);
            this.Visanumtxt.Name = "Visanumtxt";
            this.Visanumtxt.Size = new System.Drawing.Size(154, 26);
            this.Visanumtxt.TabIndex = 3;
            this.Visanumtxt.TextChanged += new System.EventHandler(this.Visanumtxt_TextChanged);
            this.Visanumtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Visanumtxt_KeyDown);
            this.Visanumtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Visanumtxt_KeyPress);
            this.Visanumtxt.Leave += new System.EventHandler(this.Visanumtxt_Leave);
            // 
            // TotalVisastxt
            // 
            this.TotalVisastxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalVisastxt.Location = new System.Drawing.Point(159, 448);
            this.TotalVisastxt.Margin = new System.Windows.Forms.Padding(4);
            this.TotalVisastxt.Name = "TotalVisastxt";
            this.TotalVisastxt.Size = new System.Drawing.Size(116, 26);
            this.TotalVisastxt.TabIndex = 4;
            this.TotalVisastxt.TextChanged += new System.EventHandler(this.TotalVisastxt_TextChanged);
            this.TotalVisastxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TotalVisastxt_KeyDown);
            this.TotalVisastxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TotalVisastxt_KeyPress);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBtn.BackColor = System.Drawing.Color.Firebrick;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(717, 802);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(66, 36);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Visible = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1623, 29);
            this.panel1.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1623, 24);
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
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(545, 45);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 123;
            this.dataGridView1.Size = new System.Drawing.Size(523, 251);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Expiry Date Hijri";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 227);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Issue Date EN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 339);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Remarks";
            // 
            // RemarksTxt
            // 
            this.RemarksTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemarksTxt.Location = new System.Drawing.Point(158, 339);
            this.RemarksTxt.Margin = new System.Windows.Forms.Padding(4);
            this.RemarksTxt.Multiline = true;
            this.RemarksTxt.Name = "RemarksTxt";
            this.RemarksTxt.Size = new System.Drawing.Size(203, 89);
            this.RemarksTxt.TabIndex = 23;
            this.RemarksTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.RemarksTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RemarksTxt_KeyDown);
            // 
            // IssueDateENTxt
            // 
            this.IssueDateENTxt.Enabled = false;
            this.IssueDateENTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IssueDateENTxt.Location = new System.Drawing.Point(158, 227);
            this.IssueDateENTxt.Margin = new System.Windows.Forms.Padding(4);
            this.IssueDateENTxt.Multiline = true;
            this.IssueDateENTxt.Name = "IssueDateENTxt";
            this.IssueDateENTxt.Size = new System.Drawing.Size(112, 25);
            this.IssueDateENTxt.TabIndex = 26;
            this.IssueDateENTxt.TextChanged += new System.EventHandler(this.IssueDateENTxt_TextChanged);
            this.IssueDateENTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IssueDateENTxt_KeyDown);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(2314, 439);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 51);
            this.button1.TabIndex = 42;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // expairENDATEtxt
            // 
            this.expairENDATEtxt.Enabled = false;
            this.expairENDATEtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expairENDATEtxt.Location = new System.Drawing.Point(158, 270);
            this.expairENDATEtxt.Margin = new System.Windows.Forms.Padding(4);
            this.expairENDATEtxt.Multiline = true;
            this.expairENDATEtxt.Name = "expairENDATEtxt";
            this.expairENDATEtxt.Size = new System.Drawing.Size(112, 25);
            this.expairENDATEtxt.TabIndex = 32;
            this.expairENDATEtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.expairENDATEtxt_KeyDown);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(158, 79);
            this.cmbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(322, 25);
            this.cmbCompany.TabIndex = 34;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            this.cmbCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCompany_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Company";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 608);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Enabled = false;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(158, 608);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(182, 25);
            this.cmbStatus.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 448);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 41;
            this.label10.Text = "Total Jobs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 555);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "Job";
            // 
            // cmbJob
            // 
            this.cmbJob.Enabled = false;
            this.cmbJob.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJob.FormattingEnabled = true;
            this.cmbJob.Location = new System.Drawing.Point(158, 554);
            this.cmbJob.Margin = new System.Windows.Forms.Padding(4);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.Size = new System.Drawing.Size(278, 25);
            this.cmbJob.TabIndex = 38;
            this.cmbJob.SelectedIndexChanged += new System.EventHandler(this.cmbJob_SelectedIndexChanged);
            this.cmbJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbJob_KeyDown);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(17, 502);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(90, 17);
            this.label44.TabIndex = 37;
            this.label44.Text = "Consulate City";
            this.label44.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbConsulate
            // 
            this.cmbConsulate.Enabled = false;
            this.cmbConsulate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConsulate.FormattingEnabled = true;
            this.cmbConsulate.Location = new System.Drawing.Point(158, 495);
            this.cmbConsulate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbConsulate.Name = "cmbConsulate";
            this.cmbConsulate.Size = new System.Drawing.Size(155, 25);
            this.cmbConsulate.TabIndex = 36;
            this.cmbConsulate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbConsulate_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 116);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 17);
            this.label12.TabIndex = 38;
            this.label12.Text = "Recived Date";
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinish.BackColor = System.Drawing.Color.Firebrick;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(938, 802);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(66, 36);
            this.btnFinish.TabIndex = 41;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(20, 302);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 17);
            this.label11.TabIndex = 43;
            this.label11.Text = "Remaining days";
            // 
            // Remaininglbl
            // 
            this.Remaininglbl.AutoSize = true;
            this.Remaininglbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remaininglbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Remaininglbl.Location = new System.Drawing.Point(157, 308);
            this.Remaininglbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Remaininglbl.Name = "Remaininglbl";
            this.Remaininglbl.Size = new System.Drawing.Size(12, 17);
            this.Remaininglbl.TabIndex = 44;
            this.Remaininglbl.Text = "!";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.BackColor = System.Drawing.Color.Firebrick;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(497, 802);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 36);
            this.btnNew.TabIndex = 82;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(545, 321);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 123;
            this.dataGridView2.Size = new System.Drawing.Size(523, 251);
            this.dataGridView2.TabIndex = 83;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBtn.BackColor = System.Drawing.Color.Firebrick;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Location = new System.Drawing.Point(828, 802);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(66, 36);
            this.DeleteBtn.TabIndex = 84;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Visible = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 265);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Expiry Date EN";
            // 
            // ExpiaryHijritxt
            // 
            this.ExpiaryHijritxt.Enabled = false;
            this.ExpiaryHijritxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpiaryHijritxt.Location = new System.Drawing.Point(158, 190);
            this.ExpiaryHijritxt.Margin = new System.Windows.Forms.Padding(4);
            this.ExpiaryHijritxt.Multiline = true;
            this.ExpiaryHijritxt.Name = "ExpiaryHijritxt";
            this.ExpiaryHijritxt.Size = new System.Drawing.Size(112, 25);
            this.ExpiaryHijritxt.TabIndex = 31;
            this.ExpiaryHijritxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExpiaryHijritxt_KeyDown);
            // 
            // issuhijritxt
            // 
            this.issuhijritxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issuhijritxt.ForeColor = System.Drawing.Color.Gray;
            this.issuhijritxt.Location = new System.Drawing.Point(158, 153);
            this.issuhijritxt.Margin = new System.Windows.Forms.Padding(4);
            this.issuhijritxt.Name = "issuhijritxt";
            this.issuhijritxt.Size = new System.Drawing.Size(112, 26);
            this.issuhijritxt.TabIndex = 33;
            this.issuhijritxt.Text = "dd-MM-yyyy";
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
            this.ReceviedPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceviedPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ReceviedPicker.Location = new System.Drawing.Point(158, 116);
            this.ReceviedPicker.Margin = new System.Windows.Forms.Padding(4);
            this.ReceviedPicker.Name = "ReceviedPicker";
            this.ReceviedPicker.Size = new System.Drawing.Size(112, 26);
            this.ReceviedPicker.TabIndex = 40;
            this.ReceviedPicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReceviedPicker_KeyDown);
            // 
            // Findbtn
            // 
            this.Findbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Findbtn.BackColor = System.Drawing.Color.Firebrick;
            this.Findbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Findbtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Findbtn.ForeColor = System.Drawing.Color.White;
            this.Findbtn.Location = new System.Drawing.Point(607, 802);
            this.Findbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Findbtn.Name = "Findbtn";
            this.Findbtn.Size = new System.Drawing.Size(66, 36);
            this.Findbtn.TabIndex = 86;
            this.Findbtn.Text = "Find";
            this.Findbtn.UseVisualStyleBackColor = false;
            this.Findbtn.Click += new System.EventHandler(this.Findbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAssign);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbcandidates);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.VisaFileNumberID);
            this.groupBox1.Location = new System.Drawing.Point(560, 590);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 186);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assign Visa";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(151, 124);
            this.btnAssign.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(66, 36);
            this.btnAssign.TabIndex = 83;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(35, 72);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 45;
            this.label13.Text = "Candidate";
            // 
            // cmbcandidates
            // 
            this.cmbcandidates.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcandidates.FormattingEnabled = true;
            this.cmbcandidates.Location = new System.Drawing.Point(151, 72);
            this.cmbcandidates.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcandidates.Name = "cmbcandidates";
            this.cmbcandidates.Size = new System.Drawing.Size(182, 25);
            this.cmbcandidates.TabIndex = 44;
            this.cmbcandidates.SelectedIndexChanged += new System.EventHandler(this.cmbcandidates_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "File Number";
            // 
            // VisaFileNumberID
            // 
            this.VisaFileNumberID.Enabled = false;
            this.VisaFileNumberID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisaFileNumberID.Location = new System.Drawing.Point(151, 29);
            this.VisaFileNumberID.Margin = new System.Windows.Forms.Padding(4);
            this.VisaFileNumberID.Name = "VisaFileNumberID";
            this.VisaFileNumberID.Size = new System.Drawing.Size(116, 25);
            this.VisaFileNumberID.TabIndex = 42;
            // 
            // VisaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1623, 928);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TotalVisastxt);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbConsulate);
            this.Controls.Add(this.Findbtn);
            this.Controls.Add(this.cmbJob);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.expairENDATEtxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.Remaininglbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.ReceviedPicker);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.issuhijritxt);
            this.Controls.Add(this.ExpiaryHijritxt);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VisaFrm";
            this.Text = "Visa";
            this.Load += new System.EventHandler(this.VisaFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VisaFrm_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbJob;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox cmbConsulate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Remaininglbl;
        private System.Windows.Forms.ToolStripMenuItem candidatesToolStripMenuItem;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ExpiaryHijritxt;
        private System.Windows.Forms.TextBox issuhijritxt;
        private System.Windows.Forms.DateTimePicker ReceviedPicker;
        private System.Windows.Forms.Button Findbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbcandidates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VisaFileNumberID;
        private System.Windows.Forms.Button btnAssign;
    }
}