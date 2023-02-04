using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
    public partial class VisaOfferLTR : Form
    {
        int EmpIDRPT;
        public VisaOfferLTR()
        {
            InitializeComponent();
        }

        private void VisaOfferLTR_Load(object sender, EventArgs e)
        {
            EmpIDRPT = CommonClass.EmployeeID;
            // TODO: This line of code loads data into the 'Delmon.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable2TableAdapter.Fill(this.delmon.DataTable2, EmpIDRPT);
            // reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
