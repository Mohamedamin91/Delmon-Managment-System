
namespace Delmon_Managment_System.Forms
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Employeetxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Updatebtn = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPersonalStatusStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.firstnametxt = new System.Windows.Forms.TextBox();
            this.secondnametxt = new System.Windows.Forms.TextBox();
            this.thirdnametxt = new System.Windows.Forms.TextBox();
            this.lastnametxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbcontact = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDocuments = new System.Windows.Forms.ComboBox();
            this.Contacttxt = new System.Windows.Forms.TextBox();
            this.Doctxt = new System.Windows.Forms.TextBox();
            this.UplodeBTN = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabContact = new System.Windows.Forms.TabPage();
            this.btndeletecontact = new System.Windows.Forms.Button();
            this.btnaddcontact = new System.Windows.Forms.Button();
            this.btnupdatecontat = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.tabDoc = new System.Windows.Forms.TabPage();
            this.btndeletedoc = new System.Windows.Forms.Button();
            this.btnaUplodedoc = new System.Windows.Forms.Button();
            this.btnupdatedoc = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.EmploymentHistory = new System.Windows.Forms.TabPage();
            this.btnaddhitory = new System.Windows.Forms.Button();
            this.btnnewhistory = new System.Windows.Forms.Button();
            this.btndeletehistory = new System.Windows.Forms.Button();
            this.btnupdatehistory = new System.Windows.Forms.Button();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbempdepthistory = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbEmployJobHistory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.insurence = new System.Windows.Forms.TabPage();
            this.btnNew = new System.Windows.Forms.Button();
            this.cmbMartialStatus = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.EmploymentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // Employeetxt
            // 
            this.Employeetxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Employeetxt.Location = new System.Drawing.Point(198, 50);
            this.Employeetxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Employeetxt.Name = "Employeetxt";
            this.Employeetxt.Size = new System.Drawing.Size(178, 25);
            this.Employeetxt.TabIndex = 102;
            this.Employeetxt.TextChanged += new System.EventHandler(this.Employeetxt_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(45, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 17);
            this.label10.TabIndex = 101;
            this.label10.Text = "Employee Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(820, 50);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(507, 331);
            this.dataGridView1.TabIndex = 88;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Location = new System.Drawing.Point(304, 307);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(87, 51);
            this.AddBtn.TabIndex = 87;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1899, 25);
            this.menuStrip1.TabIndex = 108;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visasToolStripMenuItem,
            this.candidatesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 19);
            this.fileToolStripMenuItem.Text = "Visa";
            // 
            // visasToolStripMenuItem
            // 
            this.visasToolStripMenuItem.Name = "visasToolStripMenuItem";
            this.visasToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.visasToolStripMenuItem.Text = "Visas";
            // 
            // candidatesToolStripMenuItem
            // 
            this.candidatesToolStripMenuItem.Name = "candidatesToolStripMenuItem";
            this.candidatesToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.candidatesToolStripMenuItem.Text = "Employee";
            // 
            // Updatebtn
            // 
            this.Updatebtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Updatebtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Updatebtn.Location = new System.Drawing.Point(399, 307);
            this.Updatebtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(87, 51);
            this.Updatebtn.TabIndex = 109;
            this.Updatebtn.Text = "Update";
            this.Updatebtn.UseVisualStyleBackColor = true;
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBTN.Location = new System.Drawing.Point(493, 307);
            this.DeleteBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(87, 51);
            this.DeleteBTN.TabIndex = 110;
            this.DeleteBTN.Text = "Delete";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 111;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 113;
            this.label1.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(416, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 115;
            this.label3.Text = "Second Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 117;
            this.label6.Text = "Third Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(416, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 119;
            this.label14.Text = "Last Name";
            // 
            // cmbPersonalStatusStatus
            // 
            this.cmbPersonalStatusStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPersonalStatusStatus.FormattingEnabled = true;
            this.cmbPersonalStatusStatus.Location = new System.Drawing.Point(114, 22);
            this.cmbPersonalStatusStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPersonalStatusStatus.Name = "cmbPersonalStatusStatus";
            this.cmbPersonalStatusStatus.Size = new System.Drawing.Size(179, 25);
            this.cmbPersonalStatusStatus.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 85;
            this.label5.Text = " Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 121;
            this.label2.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(197, 192);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(179, 25);
            this.cmbGender.TabIndex = 120;
            this.cmbGender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGender_KeyDown);
            // 
            // firstnametxt
            // 
            this.firstnametxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnametxt.Location = new System.Drawing.Point(197, 110);
            this.firstnametxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.firstnametxt.Name = "firstnametxt";
            this.firstnametxt.Size = new System.Drawing.Size(179, 25);
            this.firstnametxt.TabIndex = 122;
            this.firstnametxt.TextChanged += new System.EventHandler(this.firstnametxt_TextChanged);
            this.firstnametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.firstnametxt_KeyDown);
            // 
            // secondnametxt
            // 
            this.secondnametxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondnametxt.Location = new System.Drawing.Point(593, 110);
            this.secondnametxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.secondnametxt.Name = "secondnametxt";
            this.secondnametxt.Size = new System.Drawing.Size(179, 25);
            this.secondnametxt.TabIndex = 123;
            this.secondnametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secondnametxt_KeyDown_1);
            // 
            // thirdnametxt
            // 
            this.thirdnametxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thirdnametxt.Location = new System.Drawing.Point(197, 152);
            this.thirdnametxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.thirdnametxt.Name = "thirdnametxt";
            this.thirdnametxt.Size = new System.Drawing.Size(179, 25);
            this.thirdnametxt.TabIndex = 124;
            this.thirdnametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thirdnametxt_KeyDown_1);
            // 
            // lastnametxt
            // 
            this.lastnametxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnametxt.Location = new System.Drawing.Point(593, 150);
            this.lastnametxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lastnametxt.Name = "lastnametxt";
            this.lastnametxt.Size = new System.Drawing.Size(179, 25);
            this.lastnametxt.TabIndex = 125;
            this.lastnametxt.TextChanged += new System.EventHandler(this.lastnametxt_TextChanged);
            this.lastnametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lastnametxt_KeyDown_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 127;
            this.label4.Text = "Contact Type";
            // 
            // cmbcontact
            // 
            this.cmbcontact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcontact.FormattingEnabled = true;
            this.cmbcontact.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbcontact.Location = new System.Drawing.Point(166, 22);
            this.cmbcontact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbcontact.Name = "cmbcontact";
            this.cmbcontact.Size = new System.Drawing.Size(373, 25);
            this.cmbcontact.TabIndex = 126;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 129;
            this.label7.Text = "Document Type";
            // 
            // cmbDocuments
            // 
            this.cmbDocuments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDocuments.FormattingEnabled = true;
            this.cmbDocuments.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbDocuments.Location = new System.Drawing.Point(180, 29);
            this.cmbDocuments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDocuments.Name = "cmbDocuments";
            this.cmbDocuments.Size = new System.Drawing.Size(283, 25);
            this.cmbDocuments.TabIndex = 128;
            // 
            // Contacttxt
            // 
            this.Contacttxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contacttxt.Location = new System.Drawing.Point(166, 67);
            this.Contacttxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Contacttxt.Name = "Contacttxt";
            this.Contacttxt.Size = new System.Drawing.Size(373, 25);
            this.Contacttxt.TabIndex = 130;
            // 
            // Doctxt
            // 
            this.Doctxt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doctxt.Location = new System.Drawing.Point(180, 93);
            this.Doctxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Doctxt.Name = "Doctxt";
            this.Doctxt.Size = new System.Drawing.Size(509, 25);
            this.Doctxt.TabIndex = 131;
            // 
            // UplodeBTN
            // 
            this.UplodeBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UplodeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UplodeBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UplodeBTN.Location = new System.Drawing.Point(710, 160);
            this.UplodeBTN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UplodeBTN.Name = "UplodeBTN";
            this.UplodeBTN.Size = new System.Drawing.Size(101, 42);
            this.UplodeBTN.TabIndex = 133;
            this.UplodeBTN.Text = "Add";
            this.UplodeBTN.UseVisualStyleBackColor = true;
            this.UplodeBTN.Click += new System.EventHandler(this.UplodeBTN_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabContact);
            this.tabControl1.Controls.Add(this.tabDoc);
            this.tabControl1.Controls.Add(this.EmploymentHistory);
            this.tabControl1.Controls.Add(this.insurence);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(14, 515);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1053, 692);
            this.tabControl1.TabIndex = 135;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // tabContact
            // 
            this.tabContact.Controls.Add(this.btndeletecontact);
            this.tabContact.Controls.Add(this.btnaddcontact);
            this.tabContact.Controls.Add(this.btnupdatecontat);
            this.tabContact.Controls.Add(this.dataGridView2);
            this.tabContact.Controls.Add(this.label8);
            this.tabContact.Controls.Add(this.label4);
            this.tabContact.Controls.Add(this.cmbcontact);
            this.tabContact.Controls.Add(this.Contacttxt);
            this.tabContact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabContact.Location = new System.Drawing.Point(4, 26);
            this.tabContact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabContact.Name = "tabContact";
            this.tabContact.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabContact.Size = new System.Drawing.Size(1045, 662);
            this.tabContact.TabIndex = 0;
            this.tabContact.Text = "Contact";
            this.tabContact.UseVisualStyleBackColor = true;
            this.tabContact.Click += new System.EventHandler(this.tabContact_Click);
            // 
            // btndeletecontact
            // 
            this.btndeletecontact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndeletecontact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletecontact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeletecontact.Location = new System.Drawing.Point(827, 73);
            this.btndeletecontact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndeletecontact.Name = "btndeletecontact";
            this.btndeletecontact.Size = new System.Drawing.Size(101, 42);
            this.btndeletecontact.TabIndex = 136;
            this.btndeletecontact.Text = "Delete";
            this.btndeletecontact.UseVisualStyleBackColor = true;
            this.btndeletecontact.Click += new System.EventHandler(this.btndeletecontact_Click);
            // 
            // btnaddcontact
            // 
            this.btnaddcontact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnaddcontact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddcontact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddcontact.Location = new System.Drawing.Point(610, 73);
            this.btnaddcontact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnaddcontact.Name = "btnaddcontact";
            this.btnaddcontact.Size = new System.Drawing.Size(101, 42);
            this.btnaddcontact.TabIndex = 134;
            this.btnaddcontact.Text = "Add";
            this.btnaddcontact.UseVisualStyleBackColor = true;
            this.btnaddcontact.Click += new System.EventHandler(this.btnaddcontact_Click);
            // 
            // btnupdatecontat
            // 
            this.btnupdatecontat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnupdatecontat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatecontat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdatecontat.Location = new System.Drawing.Point(719, 73);
            this.btnupdatecontat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnupdatecontat.Name = "btnupdatecontat";
            this.btnupdatecontat.Size = new System.Drawing.Size(101, 42);
            this.btnupdatecontat.TabIndex = 135;
            this.btnupdatecontat.Text = "Update";
            this.btnupdatecontat.UseVisualStyleBackColor = true;
            this.btnupdatecontat.Click += new System.EventHandler(this.btnupdatecontat_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Location = new System.Drawing.Point(17, 153);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.Size = new System.Drawing.Size(623, 299);
            this.dataGridView2.TabIndex = 132;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 131;
            this.label8.Text = "Contact";
            // 
            // tabDoc
            // 
            this.tabDoc.Controls.Add(this.btndeletedoc);
            this.tabDoc.Controls.Add(this.btnaUplodedoc);
            this.tabDoc.Controls.Add(this.btnupdatedoc);
            this.tabDoc.Controls.Add(this.label9);
            this.tabDoc.Controls.Add(this.dataGridView3);
            this.tabDoc.Controls.Add(this.label7);
            this.tabDoc.Controls.Add(this.UplodeBTN);
            this.tabDoc.Controls.Add(this.cmbDocuments);
            this.tabDoc.Controls.Add(this.Doctxt);
            this.tabDoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDoc.Location = new System.Drawing.Point(4, 29);
            this.tabDoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDoc.Name = "tabDoc";
            this.tabDoc.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDoc.Size = new System.Drawing.Size(1045, 659);
            this.tabDoc.TabIndex = 1;
            this.tabDoc.Text = "Document";
            this.tabDoc.UseVisualStyleBackColor = true;
            this.tabDoc.Click += new System.EventHandler(this.tabDoc_Click);
            // 
            // btndeletedoc
            // 
            this.btndeletedoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndeletedoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletedoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeletedoc.Location = new System.Drawing.Point(927, 160);
            this.btndeletedoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndeletedoc.Name = "btndeletedoc";
            this.btndeletedoc.Size = new System.Drawing.Size(101, 42);
            this.btndeletedoc.TabIndex = 139;
            this.btndeletedoc.Text = "Delete";
            this.btndeletedoc.UseVisualStyleBackColor = true;
            this.btndeletedoc.Click += new System.EventHandler(this.btndeletedoc_Click);
            // 
            // btnaUplodedoc
            // 
            this.btnaUplodedoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnaUplodedoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaUplodedoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaUplodedoc.Location = new System.Drawing.Point(710, 93);
            this.btnaUplodedoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnaUplodedoc.Name = "btnaUplodedoc";
            this.btnaUplodedoc.Size = new System.Drawing.Size(101, 42);
            this.btnaUplodedoc.TabIndex = 137;
            this.btnaUplodedoc.Text = "Uplode";
            this.btnaUplodedoc.UseVisualStyleBackColor = true;
            this.btnaUplodedoc.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnupdatedoc
            // 
            this.btnupdatedoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnupdatedoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatedoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdatedoc.Location = new System.Drawing.Point(818, 160);
            this.btnupdatedoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnupdatedoc.Name = "btnupdatedoc";
            this.btnupdatedoc.Size = new System.Drawing.Size(101, 42);
            this.btnupdatedoc.TabIndex = 138;
            this.btnupdatedoc.Text = "Update";
            this.btnupdatedoc.UseVisualStyleBackColor = true;
            this.btnupdatedoc.Click += new System.EventHandler(this.btnupdatedoc_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(33, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 135;
            this.label9.Text = "Document";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(180, 160);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(510, 228);
            this.dataGridView3.TabIndex = 134;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView3_RowHeaderMouseClick);
            // 
            // EmploymentHistory
            // 
            this.EmploymentHistory.Controls.Add(this.btnaddhitory);
            this.EmploymentHistory.Controls.Add(this.btnnewhistory);
            this.EmploymentHistory.Controls.Add(this.btndeletehistory);
            this.EmploymentHistory.Controls.Add(this.btnupdatehistory);
            this.EmploymentHistory.Controls.Add(this.EndDatePicker);
            this.EmploymentHistory.Controls.Add(this.label15);
            this.EmploymentHistory.Controls.Add(this.StartDatePicker);
            this.EmploymentHistory.Controls.Add(this.label13);
            this.EmploymentHistory.Controls.Add(this.cmbempdepthistory);
            this.EmploymentHistory.Controls.Add(this.label12);
            this.EmploymentHistory.Controls.Add(this.cmbEmployJobHistory);
            this.EmploymentHistory.Controls.Add(this.label11);
            this.EmploymentHistory.Controls.Add(this.dataGridView4);
            this.EmploymentHistory.Controls.Add(this.cmbPersonalStatusStatus);
            this.EmploymentHistory.Controls.Add(this.label5);
            this.EmploymentHistory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmploymentHistory.Location = new System.Drawing.Point(4, 26);
            this.EmploymentHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EmploymentHistory.Name = "EmploymentHistory";
            this.EmploymentHistory.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EmploymentHistory.Size = new System.Drawing.Size(1045, 662);
            this.EmploymentHistory.TabIndex = 2;
            this.EmploymentHistory.Text = "Employment History";
            this.EmploymentHistory.UseVisualStyleBackColor = true;
            // 
            // btnaddhitory
            // 
            this.btnaddhitory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnaddhitory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddhitory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddhitory.Location = new System.Drawing.Point(271, 159);
            this.btnaddhitory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnaddhitory.Name = "btnaddhitory";
            this.btnaddhitory.Size = new System.Drawing.Size(87, 51);
            this.btnaddhitory.TabIndex = 140;
            this.btnaddhitory.Text = "Add";
            this.btnaddhitory.UseVisualStyleBackColor = true;
            this.btnaddhitory.Click += new System.EventHandler(this.btnaddhitory_Click);
            // 
            // btnnewhistory
            // 
            this.btnnewhistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnnewhistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnewhistory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnewhistory.Location = new System.Drawing.Point(176, 159);
            this.btnnewhistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnnewhistory.Name = "btnnewhistory";
            this.btnnewhistory.Size = new System.Drawing.Size(87, 51);
            this.btnnewhistory.TabIndex = 145;
            this.btnnewhistory.Text = "New";
            this.btnnewhistory.UseVisualStyleBackColor = true;
            // 
            // btndeletehistory
            // 
            this.btndeletehistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndeletehistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletehistory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeletehistory.Location = new System.Drawing.Point(460, 159);
            this.btndeletehistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndeletehistory.Name = "btndeletehistory";
            this.btndeletehistory.Size = new System.Drawing.Size(87, 51);
            this.btndeletehistory.TabIndex = 144;
            this.btndeletehistory.Text = "Delete";
            this.btndeletehistory.UseVisualStyleBackColor = true;
            this.btndeletehistory.Click += new System.EventHandler(this.btndeletehistory_Click);
            // 
            // btnupdatehistory
            // 
            this.btnupdatehistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnupdatehistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatehistory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdatehistory.Location = new System.Drawing.Point(365, 159);
            this.btnupdatehistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnupdatehistory.Name = "btnupdatehistory";
            this.btnupdatehistory.Size = new System.Drawing.Size(87, 51);
            this.btnupdatehistory.TabIndex = 143;
            this.btnupdatehistory.Text = "Update";
            this.btnupdatehistory.UseVisualStyleBackColor = true;
            this.btnupdatehistory.Click += new System.EventHandler(this.btnupdatehistory_Click);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(355, 71);
            this.EndDatePicker.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(149, 25);
            this.EndDatePicker.TabIndex = 141;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(307, 77);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 17);
            this.label15.TabIndex = 140;
            this.label15.Text = "End ";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(114, 73);
            this.StartDatePicker.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(149, 25);
            this.StartDatePicker.TabIndex = 139;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(28, 78);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 17);
            this.label13.TabIndex = 138;
            this.label13.Text = "Start ";
            // 
            // cmbempdepthistory
            // 
            this.cmbempdepthistory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbempdepthistory.FormattingEnabled = true;
            this.cmbempdepthistory.Location = new System.Drawing.Point(777, 22);
            this.cmbempdepthistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbempdepthistory.Name = "cmbempdepthistory";
            this.cmbempdepthistory.Size = new System.Drawing.Size(179, 25);
            this.cmbempdepthistory.TabIndex = 136;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(660, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 17);
            this.label12.TabIndex = 137;
            this.label12.Text = "Department";
            // 
            // cmbEmployJobHistory
            // 
            this.cmbEmployJobHistory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmployJobHistory.FormattingEnabled = true;
            this.cmbEmployJobHistory.Location = new System.Drawing.Point(355, 22);
            this.cmbEmployJobHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEmployJobHistory.Name = "cmbEmployJobHistory";
            this.cmbEmployJobHistory.Size = new System.Drawing.Size(298, 25);
            this.cmbEmployJobHistory.TabIndex = 134;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(307, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 17);
            this.label11.TabIndex = 135;
            this.label11.Text = "Job";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(7, 231);
            this.dataGridView4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(826, 250);
            this.dataGridView4.TabIndex = 133;
            this.dataGridView4.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellClick);
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // insurence
            // 
            this.insurence.Location = new System.Drawing.Point(4, 29);
            this.insurence.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insurence.Name = "insurence";
            this.insurence.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insurence.Size = new System.Drawing.Size(1045, 659);
            this.insurence.TabIndex = 3;
            this.insurence.Text = "Insurence";
            this.insurence.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(210, 307);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 51);
            this.btnNew.TabIndex = 137;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cmbMartialStatus
            // 
            this.cmbMartialStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMartialStatus.FormattingEnabled = true;
            this.cmbMartialStatus.Items.AddRange(new object[] {
            "Single",
            "Marriage"});
            this.cmbMartialStatus.Location = new System.Drawing.Point(593, 192);
            this.cmbMartialStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMartialStatus.Name = "cmbMartialStatus";
            this.cmbMartialStatus.Size = new System.Drawing.Size(179, 25);
            this.cmbMartialStatus.TabIndex = 138;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(416, 192);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 17);
            this.label16.TabIndex = 139;
            this.label16.Text = "Martial Status";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1899, 1041);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbMartialStatus);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lastnametxt);
            this.Controls.Add(this.thirdnametxt);
            this.Controls.Add(this.secondnametxt);
            this.Controls.Add(this.firstnametxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Updatebtn);
            this.Controls.Add(this.Employeetxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EmployeeForm";
            this.Text = "Personal Information";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EmployeeForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabContact.ResumeLayout(false);
            this.tabContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabDoc.ResumeLayout(false);
            this.tabDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.EmploymentHistory.ResumeLayout(false);
            this.EmploymentHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Employeetxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem candidatesToolStripMenuItem;
        private System.Windows.Forms.Button Updatebtn;
        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbPersonalStatusStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.TextBox firstnametxt;
        private System.Windows.Forms.TextBox secondnametxt;
        private System.Windows.Forms.TextBox thirdnametxt;
        private System.Windows.Forms.TextBox lastnametxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbcontact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDocuments;
        private System.Windows.Forms.TextBox Contacttxt;
        private System.Windows.Forms.TextBox Doctxt;
        private System.Windows.Forms.Button UplodeBTN;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabContact;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabDoc;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnaddcontact;
        private System.Windows.Forms.Button btnupdatecontat;
        private System.Windows.Forms.Button btndeletecontact;
        private System.Windows.Forms.Button btndeletedoc;
        private System.Windows.Forms.Button btnaUplodedoc;
        private System.Windows.Forms.Button btnupdatedoc;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TabPage EmploymentHistory;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.TabPage insurence;
        private System.Windows.Forms.ComboBox cmbempdepthistory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbEmployJobHistory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnnewhistory;
        private System.Windows.Forms.Button btndeletehistory;
        private System.Windows.Forms.Button btnupdatehistory;
        private System.Windows.Forms.ComboBox cmbMartialStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnaddhitory;
    }
}