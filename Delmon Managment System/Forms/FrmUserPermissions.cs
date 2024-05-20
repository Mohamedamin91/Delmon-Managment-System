using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class FrmUserPermissions : Form

    {
        SQLCONNECTION SQLCONN = new SQLCONNECTION();

        public FrmUserPermissions()
        {
            InitializeComponent();
        }

        private void FrmUserPermissions_Load(object sender, EventArgs e)
        {
            SQLCONN.OpenConection();

            //MessageBox.Show(CommonClass.UserPermissionID.ToString());
            dataGridView1.DataSource = SQLCONN.ShowDataInGridViewORCombobox
           (@" SELECT  [PermissionID] 'ID' 
      ,[PermissionName] 'Name'
  FROM[DelmonGroupDB].[dbo].[Permissions] ");
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[0].Width = 50;

            SQLCONN.CloseConnection();
        }
    }
}
