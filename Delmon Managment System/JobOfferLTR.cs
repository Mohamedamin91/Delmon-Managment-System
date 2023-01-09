using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
    public partial class JobOfferLTR : Form
    {
        int EmpIDRPT;
        public JobOfferLTR()
        { 
            InitializeComponent();
        }

        private void JobOfferLTR_Load(object sender, EventArgs e)
        {
            EmpIDRPT = CommonClass.EmployeeID;
            // TODO: This line of code loads data into the 'Delmon.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.Delmon.DataTable1,EmpIDRPT);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
