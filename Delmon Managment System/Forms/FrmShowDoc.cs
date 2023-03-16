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
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string documentFolder = Path.Combine(documentsPath, "Documents");

            // Get the actual file name from the full path
            string[] fileNameParts = fileName.Split('\\');
            string actualFileName = fileNameParts[fileNameParts.Length - 1];

            // Combine the document folder and actual file name
            string filePath = Path.Combine(documentFolder, actualFileName);

            try
            {
                if (File.Exists(filePath))
                {
                    DocWebBrowser.Navigate(filePath);
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
