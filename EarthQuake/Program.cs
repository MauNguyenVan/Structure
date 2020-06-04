using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EarthQuake
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DateTime dt = DateTime.Now;
            DateTime endDate = new DateTime(2020, 12, 30);
            if(dt>endDate)
            {
                MessageBox.Show("Out of date, please contact with author to active","EarthQuake" );
               return;
            }    
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
