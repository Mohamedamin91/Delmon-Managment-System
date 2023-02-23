using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delmon_Managment_System
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // Create a new font with your desired properties
           // Font appFont = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);

            // Set the default font for all controls in the application
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMainMenu());

        }
       
    }
}
