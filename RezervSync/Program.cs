using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RezervSync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if(!CommonControls.c_NetFrameworkVersion.CheckVersion(3.5f))return;            
           
            SplashScreen.Show(true);  

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());            
        }
    }
}