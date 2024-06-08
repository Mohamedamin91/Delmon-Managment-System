
namespace Delmon_Managment_System.Forms
{
    partial class FrmNewModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewModel));
            this.label1 = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbbrand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(52)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(108, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Add New Model";
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.addbtn.FlatAppearance.BorderSize = 0;
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Location = new System.Drawing.Point(-2, 293);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(367, 32);
            this.addbtn.TabIndex = 32;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label2.Location = new System.Drawing.Point(32, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 155;
            this.label2.Text = "Asset Brand";
            // 
            // cmbbrand
            // 
            this.cmbbrand.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbbrand.FormattingEnabled = true;
            this.cmbbrand.Location = new System.Drawing.Point(35, 150);
            this.cmbbrand.Margin = new System.Windows.Forms.Padding(4);
            this.cmbbrand.Name = "cmbbrand";
            this.cmbbrand.Size = new System.Drawing.Size(291, 25);
            this.cmbbrand.TabIndex = 154;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label3.Location = new System.Drawing.Point(32, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 153;
            this.label3.Text = "Asset Type";
            // 
            // cmbtype
            // 
            this.cmbtype.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Location = new System.Drawing.Point(35, 93);
            this.cmbtype.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(291, 25);
            this.cmbtype.TabIndex = 152;
            this.cmbtype.SelectionChangeCommitted += new System.EventHandler(this.cmbtype_SelectionChangeCommitted);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.label21.Location = new System.Drawing.Point(32, 195);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 17);
            this.label21.TabIndex = 156;
            this.label21.Text = "Model name";
            // 
            // txtvalue
            // 
            this.txtvalue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.txtvalue.Location = new System.Drawing.Point(35, 216);
            this.txtvalue.Margin = new System.Windows.Forms.Padding(4);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(300, 25);
            this.txtvalue.TabIndex = 157;
            // 
            // FrmNewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 327);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbbrand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbtype);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNewModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNewModel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNewModel_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNewModel_FormClosed);
            this.Load += new System.EventHandler(this.frmNewModel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbbrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtvalue;
    }
}