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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // First locate and load/create user data
            string datapath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "ISTimeTracker");
            if (!Directory.Exists(datapath))
                Directory.CreateDirectory(datapath);
            string dbpath = Path.Combine(datapath, "userdata.sqlite");
            string connstring = "Data Source=" + dbpath + ";Version=3;";
            SQLiteConnection dbconn = new SQLiteConnection(connstring);
            if (!File.Exists(dbpath))
            {
                // Initialise a new database
                string ddl = null;
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    StreamReader tstream = new StreamReader(
                        assembly.GetManifestResourceStream("TimeTracker.resources.createTables.ddl"));
                    ddl = tstream.ReadToEnd();
                }
                catch
                {
                    MessageBox.Show("Error accessing resources!", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                
                dbconn.Open(); // Create the database
                SQLiteCommand command = new SQLiteCommand(dbconn);
                command.CommandText = ddl;
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO UserData VALUES('default', NULL, NULL, NULL);";
            }
            else
            {
                dbconn.Open();
            }
            ServiceProvider service = new ServiceProvider(dbconn);
            Application.Run(new LogInForm(service.LoginDataValid()));

            dbconn.Close();
        }
    }
}
