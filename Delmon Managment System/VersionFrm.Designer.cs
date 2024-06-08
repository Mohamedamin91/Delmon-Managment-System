
namespace Delmon_Managment_System
{
    partial class VersionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionFrm));
            this.lblheader = new System.Windows.Forms.Label();
            this.updatebtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblforcurrent = new System.Windows.Forms.Label();
            this.lblfornew = new System.Windows.Forms.Label();
            this.lblCurrentver = new System.Windows.Forms.Label();
            this.lblnewver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblheader
            // 
            this.lblheader.AutoSize = true;
            this.lblheader.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.lblheader.Location = new System.Drawing.Point(46, 125);
            this.lblheader.Name = "lblheader";
            this.lblheader.Size = new System.Drawing.Size(259, 44);
            this.lblheader.TabIndex = 34;
            this.lblheader.Text = "A new version is avaliablie ,\r\nKindly update.\r\n";
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.Firebrick;
            this.updatebtn.Enabled = false;
            this.updatebtn.FlatAppearance.BorderSize = 0;
            this.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatebtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.updatebtn.ForeColor = System.Drawing.Color.White;
            this.updatebtn.Location = new System.Drawing.Point(-9, 312);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(367, 32);
            this.updatebtn.TabIndex = 35;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(115, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // lblforcurrent
            // 
            this.lblforcurrent.AutoSize = true;
            this.lblforcurrent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblforcurrent.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblforcurrent.Location = new System.Drawing.Point(34, 210);
            this.lblforcurrent.Name = "lblforcurrent";
            this.lblforcurrent.Size = new System.Drawing.Size(130, 17);
            this.lblforcurrent.TabIndex = 37;
            this.lblforcurrent.Text = "Current Version:";
            // 
            // lblfornew
            // 
            this.lblfornew.AutoSize = true;
            this.lblfornew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblfornew.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblfornew.Location = new System.Drawing.Point(34, 242);
            this.lblfornew.Name = "lblfornew";
            this.lblfornew.Size = new System.Drawing.Size(174, 17);
            this.lblfornew.TabIndex = 38;
            this.lblfornew.Text = "New Version avaliable:";
            // 
            // lblCurrentver
            // 
            this.lblCurrentver.AutoSize = true;
            this.lblCurrentver.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblCurrentver.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentver.Location = new System.Drawing.Point(238, 210);
            this.lblCurrentver.Name = "lblCurrentver";
            this.lblCurrentver.Size = new System.Drawing.Size(45, 17);
            this.lblCurrentver.TabIndex = 39;
            this.lblCurrentver.Text = "1.0.0";
            // 
            // lblnewver
            // 
            this.lblnewver.AutoSize = true;
            this.lblnewver.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.lblnewver.ForeColor = System.Drawing.Color.Black;
            this.lblnewver.Location = new System.Drawing.Point(238, 242);
            this.lblnewver.Name = "lblnewver";
            this.lblnewver.Size = new System.Drawing.Size(45, 17);
            this.lblnewver.TabIndex = 40;
            this.lblnewver.Text = "1.0.0";
            // 
            // VersionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(357, 347);
            this.Controls.Add(this.lblnewver);
            this.Controls.Add(this.lblCurrentver);
            this.Controls.Add(this.lblfornew);
            this.Controls.Add(this.lblforcurrent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.lblheader);
            this.MaximizeBox = false;
            this.Name = "VersionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VersionFrm";
            this.Load += new System.EventHandler(this.VersionFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblheader;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblforcurrent;
        private System.Windows.Forms.Label lblfornew;
        private System.Windows.Forms.Label lblCurrentver;
        private System.Windows.Forms.Label lblnewver;
    }
}