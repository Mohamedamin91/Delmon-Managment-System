
namespace Delmon_Managment_System.Forms
{
    partial class FrmMoreinfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMoreinfo));
            this.label3 = new System.Windows.Forms.Label();
            this.lblphone = new System.Windows.Forms.Label();
            this.closebtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbldepartment = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.piccompany = new System.Windows.Forms.PictureBox();
            this.picdept = new System.Windows.Forms.PictureBox();
            this.picemail = new System.Windows.Forms.PictureBox();
            this.picphone = new System.Windows.Forms.PictureBox();
            this.txtcomp = new System.Windows.Forms.Label();
            this.txtdept = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.Label();
            this.txtphone = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picdept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picemail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picphone)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label3.Location = new System.Drawing.Point(1, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 161;
            this.label3.Text = "Phone:";
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblphone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblphone.Location = new System.Drawing.Point(108, 115);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(125, 17);
            this.lblphone.TabIndex = 159;
            this.lblphone.Text = "End User Phone";
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.Firebrick;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.closebtn.ForeColor = System.Drawing.Color.White;
            this.closebtn.Location = new System.Drawing.Point(-5, 176);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(483, 37);
            this.closebtn.TabIndex = 158;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtphone);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.txtdept);
            this.groupBox1.Controls.Add(this.txtcomp);
            this.groupBox1.Controls.Add(this.picphone);
            this.groupBox1.Controls.Add(this.picemail);
            this.groupBox1.Controls.Add(this.picdept);
            this.groupBox1.Controls.Add(this.piccompany);
            this.groupBox1.Controls.Add(this.lblCompany);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbldepartment);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblemail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblphone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 147);
            this.groupBox1.TabIndex = 162;
            this.groupBox1.TabStop = false;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblCompany.Location = new System.Drawing.Point(108, 16);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(147, 17);
            this.lblCompany.TabIndex = 166;
            this.lblCompany.Text = "End User Company";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label5.Location = new System.Drawing.Point(1, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 167;
            this.label5.Text = "Company:";
            // 
            // lbldepartment
            // 
            this.lbldepartment.AutoSize = true;
            this.lbldepartment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lbldepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lbldepartment.Location = new System.Drawing.Point(108, 49);
            this.lbldepartment.Name = "lbldepartment";
            this.lbldepartment.Size = new System.Drawing.Size(165, 17);
            this.lbldepartment.TabIndex = 164;
            this.lbldepartment.Text = "End User Department";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label7.Location = new System.Drawing.Point(1, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 165;
            this.label7.Text = "Department";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblemail.Location = new System.Drawing.Point(108, 82);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(119, 17);
            this.lblemail.TabIndex = 162;
            this.lblemail.Text = "End User Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label2.Location = new System.Drawing.Point(1, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 163;
            this.label2.Text = "Email:";
            // 
            // piccompany
            // 
            this.piccompany.Image = ((System.Drawing.Image)(resources.GetObject("piccompany.Image")));
            this.piccompany.Location = new System.Drawing.Point(340, 10);
            this.piccompany.Name = "piccompany";
            this.piccompany.Size = new System.Drawing.Size(25, 25);
            this.piccompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.piccompany.TabIndex = 168;
            this.piccompany.TabStop = false;
            this.piccompany.Click += new System.EventHandler(this.piccompany_Click);
            // 
            // picdept
            // 
            this.picdept.Image = ((System.Drawing.Image)(resources.GetObject("picdept.Image")));
            this.picdept.Location = new System.Drawing.Point(340, 42);
            this.picdept.Name = "picdept";
            this.picdept.Size = new System.Drawing.Size(25, 25);
            this.picdept.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picdept.TabIndex = 169;
            this.picdept.TabStop = false;
            this.picdept.Click += new System.EventHandler(this.picdept_Click);
            // 
            // picemail
            // 
            this.picemail.Image = ((System.Drawing.Image)(resources.GetObject("picemail.Image")));
            this.picemail.Location = new System.Drawing.Point(340, 76);
            this.picemail.Name = "picemail";
            this.picemail.Size = new System.Drawing.Size(25, 25);
            this.picemail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picemail.TabIndex = 170;
            this.picemail.TabStop = false;
            this.picemail.Click += new System.EventHandler(this.picemail_Click);
            // 
            // picphone
            // 
            this.picphone.Image = ((System.Drawing.Image)(resources.GetObject("picphone.Image")));
            this.picphone.Location = new System.Drawing.Point(340, 107);
            this.picphone.Name = "picphone";
            this.picphone.Size = new System.Drawing.Size(25, 25);
            this.picphone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picphone.TabIndex = 171;
            this.picphone.TabStop = false;
            this.picphone.Click += new System.EventHandler(this.picphone_Click);
            // 
            // txtcomp
            // 
            this.txtcomp.AutoSize = true;
            this.txtcomp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.txtcomp.Location = new System.Drawing.Point(381, 16);
            this.txtcomp.Name = "txtcomp";
            this.txtcomp.Size = new System.Drawing.Size(35, 15);
            this.txtcomp.TabIndex = 172;
            this.txtcomp.Text = "Text";
            this.txtcomp.Visible = false;
            // 
            // txtdept
            // 
            this.txtdept.AutoSize = true;
            this.txtdept.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.txtdept.Location = new System.Drawing.Point(381, 50);
            this.txtdept.Name = "txtdept";
            this.txtdept.Size = new System.Drawing.Size(35, 15);
            this.txtdept.TabIndex = 173;
            this.txtdept.Text = "Text";
            this.txtdept.Visible = false;
            // 
            // txtemail
            // 
            this.txtemail.AutoSize = true;
            this.txtemail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.txtemail.Location = new System.Drawing.Point(381, 82);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(35, 15);
            this.txtemail.TabIndex = 174;
            this.txtemail.Text = "Text";
            this.txtemail.Visible = false;
            // 
            // txtphone
            // 
            this.txtphone.AutoSize = true;
            this.txtphone.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.txtphone.Location = new System.Drawing.Point(381, 115);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(35, 15);
            this.txtphone.TabIndex = 175;
            this.txtphone.Text = "Text";
            this.txtphone.Visible = false;
            // 
            // FrmMoreinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(481, 213);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.closebtn);
            this.Name = "FrmMoreinfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "More Info";
            this.Load += new System.EventHandler(this.FrmMoreinfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piccompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picdept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picemail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picphone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbldepartment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtphone;
        private System.Windows.Forms.Label txtemail;
        private System.Windows.Forms.Label txtdept;
        private System.Windows.Forms.Label txtcomp;
        private System.Windows.Forms.PictureBox picphone;
        private System.Windows.Forms.PictureBox picemail;
        private System.Windows.Forms.PictureBox picdept;
        private System.Windows.Forms.PictureBox piccompany;
    }
}