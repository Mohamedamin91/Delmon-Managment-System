using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
    public partial class VersionFrm : Form
    {
        public VersionFrm()
        {
            InitializeComponent();
        }

        private void VersionFrm_Load(object sender, EventArgs e)
        {
            //lblnewver.Hide();
            //lblfornew.Hide();
        }
        private void checkupdate()
        {
            //var urlVersion = "\\192.168.1.15\\Software\\Delmon HR update\\version.txt";
            //var newVersion = (new WebClient().DownloadString(urlVersion));
            //var currentVersion = Application.ProductVersion.ToString();
            //newVersion = newVersion.Replace(".", "");
            //currentVersion = currentVersion.Replace(".", "");
            //if (Convert.ToInt32(newVersion) > Convert.ToInt32(currentVersion))
            //{
            //    lblheader.Text = "A new version is avaliablie , Kindly update";
            //    lblnewver.Text = (new WebClient().DownloadString(urlVersion));
            //    updatebtn.Enabled = true;
            //    lblnewver.Show();
            //    lblfornew.Show();


            //}
            //else {
            //    lblheader.Text = "The version is up to date";
            //    updatebtn.Enabled = true;
            //    lblnewver.Hide();
            //    lblfornew.Hide();
            //}
        
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            //WebClient web = new WebClient();
            //web.DownloadFileCompleted += web_DownloadFileCompleted;
            //web.DownloadFileAsync(new Uri ("Server link"),"path");
        }
        private void web_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
           // initScript();
                
                
          }
        private void initScript() 
        {
            //string path = Application.StartupPath+ @"\bat";
            //Process p = new Process();
            //p.StartInfo.FileName = path;
            //p.StartInfo.Arguments = "";
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.CreateNoWindow = true;
            //p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.Verb = "runas";
            //p.Start();
            //Environment.Exit(1);

        }
        private void bw_updateChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            checkupdate();
        }

        private void bw_updateChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
         //   bw_updateChecker.RunWorkerAsync();
        }

       
    }
}
