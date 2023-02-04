
namespace Delmon_Managment_System
{
    partial class VisaOfferLTR
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.delmon = new Delmon_Managment_System.Delmon();
            this.delmonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable2TableAdapter = new Delmon_Managment_System.DelmonTableAdapters.DataTable2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.delmon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delmonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet3";
            reportDataSource1.Value = this.dataTable2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Delmon_Managment_System.VisaRequest.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1135, 633);
            this.reportViewer1.TabIndex = 0;
            // 
            // delmon
            // 
            this.delmon.DataSetName = "Delmon";
            this.delmon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // delmonBindingSource
            // 
            this.delmonBindingSource.DataSource = this.delmon;
            this.delmonBindingSource.Position = 0;
            // 
            // dataTable2BindingSource
            // 
            this.dataTable2BindingSource.DataMember = "DataTable2";
            this.dataTable2BindingSource.DataSource = this.delmon;
            // 
            // dataTable2TableAdapter
            // 
            this.dataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // VisaOfferLTR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 633);
            this.Controls.Add(this.reportViewer1);
            this.Name = "VisaOfferLTR";
            this.Text = "VisaOfferLTR";
            this.Load += new System.EventHandler(this.VisaOfferLTR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.delmon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delmonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource delmonBindingSource;
        private Delmon delmon;
        private System.Windows.Forms.BindingSource dataTable2BindingSource;
        private DelmonTableAdapters.DataTable2TableAdapter dataTable2TableAdapter;
    }
}