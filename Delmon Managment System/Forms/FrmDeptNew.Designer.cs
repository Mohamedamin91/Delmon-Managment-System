
namespace Delmon_Managment_System.Forms
{
    partial class FrmDeptNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeptNew));
            this.txtDepttypeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDepttypeName
            // 
            this.txtDepttypeName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtDepttypeName.Location = new System.Drawing.Point(39, 95);
            this.txtDepttypeName.Multiline = true;
            this.txtDepttypeName.Name = "txtDepttypeName";
            this.txtDepttypeName.Size = new System.Drawing.Size(193, 24);
            this.txtDepttypeName.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Department Type Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Add New Department Type";
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.addbtn.FlatAppearance.BorderSize = 0;
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Location = new System.Drawing.Point(79, 137);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(101, 28);
            this.addbtn.TabIndex = 28;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // FrmDeptNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(267, 189);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.txtDepttypeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeptNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDeptNew_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDepttypeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addbtn;
    }
}