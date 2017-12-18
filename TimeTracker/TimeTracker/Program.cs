using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string datapath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "ISTimeTracker");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationContext applicationContext = new TimeTracker(datapath);
            Application.Run(applicationContext);
        }
    }
}
