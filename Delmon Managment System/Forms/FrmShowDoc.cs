using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System.Forms
{
    public partial class FrmShowDoc : Form
    {
        string FilePath;

        public FrmShowDoc()
        {
            InitializeComponent();
        }

        private void FrmShowDoc_Load(object sender, EventArgs e)
        {
            string fileName = CommonClass.DocPath;

            string relativePath = @"Document\" + fileName;
            string currentDirectory = Directory.GetCurrentDirectory();
            string rootDirectory = Directory.GetParent(Directory.GetParent(currentDirectory).FullName).FullName;
            string absolutePath = Path.Combine(rootDirectory, relativePath);

            try
            {
                if (File.Exists(absolutePath))
                {
                    DocWebBrowser.Navigate(absolutePath);
                }
                else
                {
                    MessageBox.Show("File not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }







            //FilePath = CommonClass.DocPath;
            //string absolutePath = Path.Combine(Application.StartupPath, FilePath);

            //DocWebBrowser.Navigate(absolutePath);





        }
    }
}
