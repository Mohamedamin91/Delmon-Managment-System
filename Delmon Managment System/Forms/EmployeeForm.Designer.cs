
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
            this.cmbMartialStatus = new System.Windows.Forms.ComboBox();
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
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.insurence = new System.Windows.Forms.TabPage();
            this.btnNew = new System.Windows.Forms.Button();
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
            this.Employeetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Employeetxt.Location = new System.Drawing.Point(170, 38);
            this.Employeetxt.Name = "Employeetxt";
            this.Employeetxt.Size = new System.Drawing.Size(153, 26);
            this.Employeetxt.TabIndex = 102;
            this.Employeetxt.TextChanged += new System.EventHandler(this.Employeetxt_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(39, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 20);
            this.label10.TabIndex = 101;
            this.label10.Text = "Employee Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(703, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(435, 253);
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
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Location = new System.Drawing.Point(250, 219);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 39);
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
            this.menuStrip1.Size = new System.Drawing.Size(1628, 24);
            this.menuStrip1.TabIndex = 108;
            this.menuStrip1.Text = "menuStrip1";
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
            this.Updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Updatebtn.Location = new System.Drawing.Point(331, 219);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(75, 39);
            this.Updatebtn.TabIndex = 109;
            this.Updatebtn.Text = "Update";
            this.Updatebtn.UseVisualStyleBackColor = true;
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBTN.Location = new System.Drawing.Point(412, 219);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(75, 39);
            this.DeleteBTN.TabIndex = 110;
            this.DeleteBTN.Text = "Delete";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 111;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 113;
            this.label1.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 115;
            this.label3.Text = "Second Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 117;
            this.label6.Text = "Third Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(357, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 20);
            this.label14.TabIndex = 119;
            this.label14.Text = "Last Name";
            // 
            // cmbMartialStatus
            // 
            this.cmbMartialStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMartialStatus.FormattingEnabled = true;
            this.cmbMartialStatus.Items.AddRange(new object[] {
            "Marriage",
            "Divorce",
            "Widowed",
            "Single"});
            this.cmbMartialStatus.Location = new System.Drawing.Point(508, 151);
            this.cmbMartialStatus.Name = "cmbMartialStatus";
            this.cmbMartialStatus.Size = new System.Drawing.Size(154, 28);
            this.cmbMartialStatus.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(357, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 85;
            this.label5.Text = "Martial Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 121;
            this.label2.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(169, 147);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(154, 28);
            this.cmbGender.TabIndex = 120;
            this.cmbGender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGender_KeyDown);
            // 
            // firstnametxt
            // 
            this.firstnametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnametxt.Location = new System.Drawing.Point(169, 84);
            this.firstnametxt.Name = "firstnametxt";
            this.firstnametxt.Size = new System.Drawing.Size(154, 26);
            this.firstnametxt.TabIndex = 122;
            this.firstnametxt.TextChanged += new System.EventHandler(this.firstnametxt_TextChanged);
            this.firstnametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.firstnametxt_KeyDown);
            // 
            // secondnametxt
            // 
            this.secondnametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondnametxt.Location = new System.Drawing.Point(508, 84);
            this.secondnametxt.Name = "secondnametxt";
            this.secondnametxt.Size = new System.Drawing.Size(154, 26);
            this.secondnametxt.TabIndex = 123;
            this.secondnametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secondnametxt_KeyDown_1);
            // 
            // thirdnametxt
            // 
            this.thirdnametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thirdnametxt.Location = new System.Drawing.Point(169, 116);
            this.thirdnametxt.Name = "thirdnametxt";
            this.thirdnametxt.Size = new System.Drawing.Size(154, 26);
            this.thirdnametxt.TabIndex = 124;
            this.thirdnametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thirdnametxt_KeyDown_1);
            // 
            // lastnametxt
            // 
            this.lastnametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnametxt.Location = new System.Drawing.Point(508, 119);
            this.lastnametxt.Name = "lastnametxt";
            this.lastnametxt.Size = new System.Drawing.Size(154, 26);
            this.lastnametxt.TabIndex = 125;
            this.lastnametxt.TextChanged += new System.EventHandler(this.lastnametxt_TextChanged);
            this.lastnametxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lastnametxt_KeyDown_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 127;
            this.label4.Text = "Contact Type";
            // 
            // cmbcontact
            // 
            this.cmbcontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcontact.FormattingEnabled = true;
            this.cmbcontact.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbcontact.Location = new System.Drawing.Point(142, 17);
            this.cmbcontact.Name = "cmbcontact";
            this.cmbcontact.Size = new System.Drawing.Size(320, 28);
            this.cmbcontact.TabIndex = 126;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 129;
            this.label7.Text = "Document Type";
            // 
            // cmbDocuments
            // 
            this.cmbDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDocuments.FormattingEnabled = true;
            this.cmbDocuments.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbDocuments.Location = new System.Drawing.Point(150, 24);
            this.cmbDocuments.Name = "cmbDocuments";
            this.cmbDocuments.Size = new System.Drawing.Size(243, 28);
            this.cmbDocuments.TabIndex = 128;
            // 
            // Contacttxt
            // 
            this.Contacttxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contacttxt.Location = new System.Drawing.Point(142, 51);
            this.Contacttxt.Name = "Contacttxt";
            this.Contacttxt.Size = new System.Drawing.Size(320, 26);
            this.Contacttxt.TabIndex = 130;
            // 
            // Doctxt
            // 
            this.Doctxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doctxt.Location = new System.Drawing.Point(150, 73);
            this.Doctxt.Name = "Doctxt";
            this.Doctxt.Size = new System.Drawing.Size(437, 26);
            this.Doctxt.TabIndex = 131;
            // 
            // UplodeBTN
            // 
            this.UplodeBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UplodeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UplodeBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UplodeBTN.Location = new System.Drawing.Point(604, 124);
            this.UplodeBTN.Name = "UplodeBTN";
            this.UplodeBTN.Size = new System.Drawing.Size(87, 32);
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
            this.tabControl1.Location = new System.Drawing.Point(12, 363);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(903, 529);
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
            this.tabContact.Location = new System.Drawing.Point(4, 22);
            this.tabContact.Name = "tabContact";
            this.tabContact.Padding = new System.Windows.Forms.Padding(3);
            this.tabContact.Size = new System.Drawing.Size(895, 503);
            this.tabContact.TabIndex = 0;
            this.tabContact.Text = "Contact";
            this.tabContact.UseVisualStyleBackColor = true;
            this.tabContact.Click += new System.EventHandler(this.tabContact_Click);
            // 
            // btndeletecontact
            // 
            this.btndeletecontact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndeletecontact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletecontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeletecontact.Location = new System.Drawing.Point(709, 54);
            this.btndeletecontact.Name = "btndeletecontact";
            this.btndeletecontact.Size = new System.Drawing.Size(87, 32);
            this.btndeletecontact.TabIndex = 136;
            this.btndeletecontact.Text = "Delete";
            this.btndeletecontact.UseVisualStyleBackColor = true;
            this.btndeletecontact.Click += new System.EventHandler(this.btndeletecontact_Click);
            // 
            // btnaddcontact
            // 
            this.btnaddcontact.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnaddcontact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddcontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddcontact.Location = new System.Drawing.Point(523, 54);
            this.btnaddcontact.Name = "btnaddcontact";
            this.btnaddcontact.Size = new System.Drawing.Size(87, 32);
            this.btnaddcontact.TabIndex = 134;
            this.btnaddcontact.Text = "Add";
            this.btnaddcontact.UseVisualStyleBackColor = true;
            this.btnaddcontact.Click += new System.EventHandler(this.btnaddcontact_Click);
            // 
            // btnupdatecontat
            // 
            this.btnupdatecontat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnupdatecontat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatecontat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdatecontat.Location = new System.Drawing.Point(616, 54);
            this.btnupdatecontat.Name = "btnupdatecontat";
            this.btnupdatecontat.Size = new System.Drawing.Size(87, 32);
            this.btnupdatecontat.TabIndex = 135;
            this.btnupdatecontat.Text = "Update";
            this.btnupdatecontat.UseVisualStyleBackColor = true;
            this.btnupdatecontat.Click += new System.EventHandler(this.btnupdatecontat_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(15, 117);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(534, 229);
            this.dataGridView2.TabIndex = 132;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
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
            this.tabDoc.Location = new System.Drawing.Point(4, 22);
            this.tabDoc.Name = "tabDoc";
            this.tabDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoc.Size = new System.Drawing.Size(895, 503);
            this.tabDoc.TabIndex = 1;
            this.tabDoc.Text = "Document";
            this.tabDoc.UseVisualStyleBackColor = true;
            this.tabDoc.Click += new System.EventHandler(this.tabDoc_Click);
            // 
            // btndeletedoc
            // 
            this.btndeletedoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndeletedoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletedoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeletedoc.Location = new System.Drawing.Point(790, 124);
            this.btndeletedoc.Name = "btndeletedoc";
            this.btndeletedoc.Size = new System.Drawing.Size(87, 32);
            this.btndeletedoc.TabIndex = 139;
            this.btndeletedoc.Text = "Delete";
            this.btndeletedoc.UseVisualStyleBackColor = true;
            this.btndeletedoc.Click += new System.EventHandler(this.btndeletedoc_Click);
            // 
            // btnaUplodedoc
            // 
            this.btnaUplodedoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnaUplodedoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaUplodedoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaUplodedoc.Location = new System.Drawing.Point(604, 73);
            this.btnaUplodedoc.Name = "btnaUplodedoc";
            this.btnaUplodedoc.Size = new System.Drawing.Size(87, 32);
            this.btnaUplodedoc.TabIndex = 137;
            this.btnaUplodedoc.Text = "Uplode";
            this.btnaUplodedoc.UseVisualStyleBackColor = true;
            this.btnaUplodedoc.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnupdatedoc
            // 
            this.btnupdatedoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnupdatedoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatedoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdatedoc.Location = new System.Drawing.Point(697, 124);
            this.btnupdatedoc.Name = "btnupdatedoc";
            this.btnupdatedoc.Size = new System.Drawing.Size(87, 32);
            this.btnupdatedoc.TabIndex = 138;
            this.btnupdatedoc.Text = "Update";
            this.btnupdatedoc.UseVisualStyleBackColor = true;
            this.btnupdatedoc.Click += new System.EventHandler(this.btnupdatedoc_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 135;
            this.label9.Text = "Document";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(150, 124);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(437, 174);
            this.dataGridView3.TabIndex = 134;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView3_RowHeaderMouseClick);
            // 
            // EmploymentHistory
            // 
            this.EmploymentHistory.Controls.Add(this.dataGridView4);
            this.EmploymentHistory.Location = new System.Drawing.Point(4, 22);
            this.EmploymentHistory.Name = "EmploymentHistory";
            this.EmploymentHistory.Padding = new System.Windows.Forms.Padding(3);
            this.EmploymentHistory.Size = new System.Drawing.Size(895, 503);
            this.EmploymentHistory.TabIndex = 2;
            this.EmploymentHistory.Text = "Employment History";
            this.EmploymentHistory.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(3, 6);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(708, 294);
            this.dataGridView4.TabIndex = 133;
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // insurence
            // 
            this.insurence.Location = new System.Drawing.Point(4, 22);
            this.insurence.Name = "insurence";
            this.insurence.Padding = new System.Windows.Forms.Padding(3);
            this.insurence.Size = new System.Drawing.Size(895, 503);
            this.insurence.TabIndex = 3;
            this.insurence.Text = "Insurence";
            this.insurence.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(169, 219);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 39);
            this.btnNew.TabIndex = 137;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1628, 796);
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
            this.Controls.Add(this.Updatebtn);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Employeetxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbMartialStatus);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AddBtn);
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
        private System.Windows.Forms.ComboBox cmbMartialStatus;
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
    }
}