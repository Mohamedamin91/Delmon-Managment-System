
namespace Delmon_Managment_System.Forms
{
    partial class AssetFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetFrm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtsapid = new System.Windows.Forms.TextBox();
            this.AssetIDTXT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Assetmodeltxt = new System.Windows.Forms.TextBox();
            this.updatebtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbbrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblprovide = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbdeviceatt = new System.Windows.Forms.ComboBox();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.seratchassettxt = new System.Windows.Forms.TextBox();
            this.btnnew = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblFullname = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.lbldatetime = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1425, 855);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtSN);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtsapid);
            this.tabPage1.Controls.Add(this.AssetIDTXT);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.Assetmodeltxt);
            this.tabPage1.Controls.Add(this.updatebtn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbbrand);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbtype);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.seratchassettxt);
            this.tabPage1.Controls.Add(this.btnnew);
            this.tabPage1.Controls.Add(this.deletebtn);
            this.tabPage1.Controls.Add(this.addbtn);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1417, 825);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Asset";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label5.Location = new System.Drawing.Point(25, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 165;
            this.label5.Text = "SN";
            // 
            // txtSN
            // 
            this.txtSN.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtSN.Location = new System.Drawing.Point(143, 151);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(274, 25);
            this.txtSN.TabIndex = 164;
            this.txtSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSN_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label9.Location = new System.Drawing.Point(22, 121);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 17);
            this.label9.TabIndex = 163;
            this.label9.Text = "SAP Asset ID";
            // 
            // txtsapid
            // 
            this.txtsapid.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtsapid.Location = new System.Drawing.Point(143, 113);
            this.txtsapid.Name = "txtsapid";
            this.txtsapid.Size = new System.Drawing.Size(274, 25);
            this.txtsapid.TabIndex = 160;
            this.txtsapid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsapid_KeyDown);
            // 
            // AssetIDTXT
            // 
            this.AssetIDTXT.Enabled = false;
            this.AssetIDTXT.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.AssetIDTXT.Location = new System.Drawing.Point(143, 75);
            this.AssetIDTXT.Name = "AssetIDTXT";
            this.AssetIDTXT.Size = new System.Drawing.Size(274, 25);
            this.AssetIDTXT.TabIndex = 157;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label4.Location = new System.Drawing.Point(25, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 156;
            this.label4.Text = "Asset ID";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Assetmodeltxt
            // 
            this.Assetmodeltxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Assetmodeltxt.Location = new System.Drawing.Point(142, 290);
            this.Assetmodeltxt.Margin = new System.Windows.Forms.Padding(4);
            this.Assetmodeltxt.Name = "Assetmodeltxt";
            this.Assetmodeltxt.Size = new System.Drawing.Size(275, 25);
            this.Assetmodeltxt.TabIndex = 155;
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.White;
            this.updatebtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatebtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.updatebtn.ForeColor = System.Drawing.Color.Firebrick;
            this.updatebtn.Location = new System.Drawing.Point(236, 342);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(70, 26);
            this.updatebtn.TabIndex = 154;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Visible = false;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label3.Location = new System.Drawing.Point(22, 296);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 153;
            this.label3.Text = "Asset Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label2.Location = new System.Drawing.Point(22, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 151;
            this.label2.Text = "Asset Brand";
            // 
            // cmbbrand
            // 
            this.cmbbrand.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbbrand.FormattingEnabled = true;
            this.cmbbrand.Location = new System.Drawing.Point(142, 248);
            this.cmbbrand.Margin = new System.Windows.Forms.Padding(4);
            this.cmbbrand.Name = "cmbbrand";
            this.cmbbrand.Size = new System.Drawing.Size(275, 25);
            this.cmbbrand.TabIndex = 150;
            this.cmbbrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbbrand_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label1.Location = new System.Drawing.Point(22, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 149;
            this.label1.Text = "Asset Type";
            // 
            // cmbtype
            // 
            this.cmbtype.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Location = new System.Drawing.Point(142, 195);
            this.cmbtype.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(275, 25);
            this.cmbtype.TabIndex = 148;
            this.cmbtype.SelectionChangeCommitted += new System.EventHandler(this.cmbtype_SelectionChangeCommitted);
            this.cmbtype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbtype_KeyDown);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(11, 392);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1399, 426);
            this.tabControl2.TabIndex = 146;
            this.tabControl2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl2_MouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.lblprovide);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.dataGridView5);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.cmbdeviceatt);
            this.tabPage3.Controls.Add(this.txtvalue);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1391, 396);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Device Details";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // lblprovide
            // 
            this.lblprovide.AutoSize = true;
            this.lblprovide.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblprovide.ForeColor = System.Drawing.Color.DarkRed;
            this.lblprovide.Location = new System.Drawing.Point(-3, 120);
            this.lblprovide.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblprovide.Name = "lblprovide";
            this.lblprovide.Size = new System.Drawing.Size(221, 17);
            this.lblprovide.TabIndex = 154;
            this.lblprovide.Text = "*Provide (Yes or No) as Value";
            this.lblprovide.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.button1.ForeColor = System.Drawing.Color.Firebrick;
            this.button1.Location = new System.Drawing.Point(495, 111);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 35);
            this.button1.TabIndex = 153;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.button2.ForeColor = System.Drawing.Color.Firebrick;
            this.button2.Location = new System.Drawing.Point(224, 111);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 35);
            this.button2.TabIndex = 151;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.button3.ForeColor = System.Drawing.Color.Firebrick;
            this.button3.Location = new System.Drawing.Point(365, 111);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 35);
            this.button3.TabIndex = 152;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(16, 154);
            this.dataGridView5.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(590, 217);
            this.dataGridView5.TabIndex = 150;
            this.dataGridView5.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView5_CellClick);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label21.Location = new System.Drawing.Point(33, 68);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(117, 17);
            this.label21.TabIndex = 149;
            this.label21.Text = "Amount / Value";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label22.Location = new System.Drawing.Point(33, 20);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(126, 17);
            this.label22.TabIndex = 147;
            this.label22.Text = "Device Attribute";
            // 
            // cmbdeviceatt
            // 
            this.cmbdeviceatt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbdeviceatt.FormattingEnabled = true;
            this.cmbdeviceatt.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbdeviceatt.Location = new System.Drawing.Point(172, 22);
            this.cmbdeviceatt.Margin = new System.Windows.Forms.Padding(4);
            this.cmbdeviceatt.Name = "cmbdeviceatt";
            this.cmbdeviceatt.Size = new System.Drawing.Size(197, 25);
            this.cmbdeviceatt.TabIndex = 146;
            // 
            // txtvalue
            // 
            this.txtvalue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtvalue.Location = new System.Drawing.Point(172, 68);
            this.txtvalue.Margin = new System.Windows.Forms.Padding(4);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(275, 25);
            this.txtvalue.TabIndex = 148;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(458, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 145;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label10.Location = new System.Drawing.Point(478, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 17);
            this.label10.TabIndex = 144;
            this.label10.Text = "Search";
            // 
            // seratchassettxt
            // 
            this.seratchassettxt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.seratchassettxt.Location = new System.Drawing.Point(546, 33);
            this.seratchassettxt.Name = "seratchassettxt";
            this.seratchassettxt.Size = new System.Drawing.Size(498, 25);
            this.seratchassettxt.TabIndex = 143;
            this.seratchassettxt.TextChanged += new System.EventHandler(this.seratchassettxt_TextChanged);
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnnew.ForeColor = System.Drawing.Color.Firebrick;
            this.btnnew.Location = new System.Drawing.Point(74, 342);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(70, 26);
            this.btnnew.TabIndex = 142;
            this.btnnew.Text = "New";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.BackColor = System.Drawing.Color.White;
            this.deletebtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletebtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.deletebtn.ForeColor = System.Drawing.Color.Firebrick;
            this.deletebtn.Location = new System.Drawing.Point(324, 342);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(70, 26);
            this.deletebtn.TabIndex = 141;
            this.deletebtn.Text = "Delete";
            this.deletebtn.UseVisualStyleBackColor = false;
            this.deletebtn.Visible = false;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.White;
            this.addbtn.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.addbtn.ForeColor = System.Drawing.Color.Firebrick;
            this.addbtn.Location = new System.Drawing.Point(153, 342);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(70, 26);
            this.addbtn.TabIndex = 139;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Visible = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(455, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(955, 304);
            this.dataGridView1.TabIndex = 58;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1417, 825);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblFullname
            // 
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblFullname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblFullname.Location = new System.Drawing.Point(1449, 131);
            this.lblFullname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(80, 17);
            this.lblFullname.TabIndex = 160;
            this.lblFullname.Text = "Full Name";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblPC.Location = new System.Drawing.Point(1449, 221);
            this.lblPC.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(27, 17);
            this.lblPC.TabIndex = 159;
            this.lblPC.Text = "Pc";
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lbldatetime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lbldatetime.Location = new System.Drawing.Point(1449, 165);
            this.lbldatetime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(77, 17);
            this.lbldatetime.TabIndex = 158;
            this.lbldatetime.Text = "Date&Time";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblemail.Location = new System.Drawing.Point(1449, 194);
            this.lblemail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(48, 17);
            this.lblemail.TabIndex = 157;
            this.lblemail.Text = "Email";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblusername.Location = new System.Drawing.Point(1449, 101);
            this.lblusername.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(85, 17);
            this.lblusername.TabIndex = 156;
            this.lblusername.Text = "UserName";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AssetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1574, 853);
            this.Controls.Add(this.lblFullname);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblPC);
            this.Controls.Add(this.lbldatetime);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.lblemail);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AssetFrm";
            this.Text = "AssetFrm";
            this.Load += new System.EventHandler(this.AssetFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox seratchassettxt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblprovide;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbdeviceatt;
        private System.Windows.Forms.TextBox txtvalue;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbbrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.TextBox Assetmodeltxt;
        public System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lbldatetime;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtsapid;
        private System.Windows.Forms.TextBox AssetIDTXT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSN;
    }
}