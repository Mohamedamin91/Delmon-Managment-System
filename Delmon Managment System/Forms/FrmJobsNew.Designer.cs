
namespace Delmon_Managment_System.Forms
{
    partial class FrmJobsNew
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
            this.lbl = new System.Windows.Forms.Label();
            this.JobTitleENtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.jobtitleartxt = new System.Windows.Forms.TextBox();
            this.Descriptiontxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbworkfield = new System.Windows.Forms.ComboBox();
            this.cmbjobgrade = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mintxt = new System.Windows.Forms.TextBox();
            this.maxtxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Black;
            this.lbl.Location = new System.Drawing.Point(18, 154);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(76, 16);
            this.lbl.TabIndex = 21;
            this.lbl.Text = "Description";
            // 
            // JobTitleENtxt
            // 
            this.JobTitleENtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JobTitleENtxt.Location = new System.Drawing.Point(21, 75);
            this.JobTitleENtxt.Name = "JobTitleENtxt";
            this.JobTitleENtxt.Size = new System.Drawing.Size(278, 22);
            this.JobTitleENtxt.TabIndex = 20;
            this.JobTitleENtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JobTitleENtxt_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Job Title (AR)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Job Title (EN)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(91, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Add New Job";
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.Red;
            this.addbtn.FlatAppearance.BorderSize = 0;
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Location = new System.Drawing.Point(49, 373);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(210, 37);
            this.addbtn.TabIndex = 11;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // jobtitleartxt
            // 
            this.jobtitleartxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobtitleartxt.Location = new System.Drawing.Point(21, 124);
            this.jobtitleartxt.Name = "jobtitleartxt";
            this.jobtitleartxt.Size = new System.Drawing.Size(278, 22);
            this.jobtitleartxt.TabIndex = 22;
            this.jobtitleartxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jobtitleartxt_KeyDown);
            // 
            // Descriptiontxt
            // 
            this.Descriptiontxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descriptiontxt.Location = new System.Drawing.Point(21, 173);
            this.Descriptiontxt.Multiline = true;
            this.Descriptiontxt.Name = "Descriptiontxt";
            this.Descriptiontxt.Size = new System.Drawing.Size(278, 70);
            this.Descriptiontxt.TabIndex = 23;
            this.Descriptiontxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Descriptiontxt_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Work Field";
            // 
            // cmbworkfield
            // 
            this.cmbworkfield.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbworkfield.FormattingEnabled = true;
            this.cmbworkfield.Location = new System.Drawing.Point(21, 265);
            this.cmbworkfield.Name = "cmbworkfield";
            this.cmbworkfield.Size = new System.Drawing.Size(117, 24);
            this.cmbworkfield.TabIndex = 25;
            this.cmbworkfield.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbworkfield_KeyDown);
            // 
            // cmbjobgrade
            // 
            this.cmbjobgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbjobgrade.FormattingEnabled = true;
            this.cmbjobgrade.Location = new System.Drawing.Point(178, 265);
            this.cmbjobgrade.Name = "cmbjobgrade";
            this.cmbjobgrade.Size = new System.Drawing.Size(121, 24);
            this.cmbjobgrade.TabIndex = 27;
            this.cmbjobgrade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbjobgrade_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(175, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Job Grade";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(18, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Min Salary";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(175, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Max Salary";
            // 
            // mintxt
            // 
            this.mintxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mintxt.Location = new System.Drawing.Point(21, 320);
            this.mintxt.Name = "mintxt";
            this.mintxt.Size = new System.Drawing.Size(117, 22);
            this.mintxt.TabIndex = 30;
            this.mintxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mintxt_KeyDown);
            // 
            // maxtxt
            // 
            this.maxtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxtxt.Location = new System.Drawing.Point(178, 320);
            this.maxtxt.Name = "maxtxt";
            this.maxtxt.Size = new System.Drawing.Size(121, 22);
            this.maxtxt.TabIndex = 31;
            // 
            // FrmJobsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(311, 422);
            this.Controls.Add(this.maxtxt);
            this.Controls.Add(this.mintxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbjobgrade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbworkfield);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Descriptiontxt);
            this.Controls.Add(this.jobtitleartxt);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.JobTitleENtxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addbtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmJobsNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmJobsNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox JobTitleENtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox jobtitleartxt;
        private System.Windows.Forms.TextBox Descriptiontxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbworkfield;
        private System.Windows.Forms.ComboBox cmbjobgrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mintxt;
        private System.Windows.Forms.TextBox maxtxt;
    }
}