using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public class TimeTracker : ApplicationContext
    {
        SQLiteConnection dbConn;
        private ServiceProvider service;
        private TimeController timctrl;
        private ProjectController projctrl;

        private MainFormUI mainForm;
        private LogInForm loginForm;

        Assembly _assembly;
        Icon icon;
        NotifyIcon notifyIcon;
        System.ComponentModel.Container components;
        
        private bool loginResult = false;

        public TimeTracker(string dataPath)
        {
            // Load resources
            _assembly = Assembly.GetExecutingAssembly();
            icon = new Icon(_assembly.GetManifestResourceStream("TimeTracker.resources.clock.ico"));

            if (!Directory.Exists(dataPath))
                Directory.CreateDirectory(dataPath);
            string dbpath = Path.Combine(dataPath, "userdata.sqlite");

            // Connect to database
            try
            {
                dbConn = ConnectToDatabase(dbpath);
            }
            catch
            {
                MessageBox.Show("Error accessing database!", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            InitializeContext();

            ServiceProvider service = new ServiceProvider(dbConn);
            ShowLoginForm();
        }

        private void InitializeContext()
        {
            components = new System.ComponentModel.Container();
            notifyIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = icon,
                Text = "Time Tracker",
                Visible = true
            };
            notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            notifyIcon.ContextMenuStrip.Closing += ContextMenuStrip_Closing;
            notifyIcon.DoubleClick += showMainMenu_Click;
        }

        private SQLiteConnection ConnectToDatabase(string path)
        {
            string connstring = "Data Source=" + path + ";Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connstring);
            if (!File.Exists(path))
            {
                // Initialise a new database
                StreamReader tstream = new StreamReader(
                    _assembly.GetManifestResourceStream("TimeTracker.resources.createTables.ddl"));
                string ddl = tstream.ReadToEnd();

                conn.Open(); // Also creates the file
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = ddl;
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO UserData VALUES('default', NULL, NULL, NULL);";
                command.ExecuteNonQuery();
            }
            else
            {
                // Open the existing one
                conn.Open();
            }
            return conn;
        }

        public void TryLogin(string email, string password)
        {
            // Begin async login
            // TODO !!!
            //loginForm.LoginFailCallback("Invalid e-mail or password");

            // HACK: bypass login
            loginResult = true;
            loginForm.Close();
        }

        private void ShowLoginForm()
        {
            if (loginForm == null)
            {
                loginForm = new LogInForm(this);
                loginForm.Closed += loginForm_Closed;
                loginForm.Show();
            }
            else { loginForm.Activate(); }
        }
        void loginForm_Closed(object sender, EventArgs e)
        {
            loginForm = null;
            if (loginResult) // Logged in successfully
            {
                ShowMainForm();
            }
            else // Closed / exited
            {
                ExitThread();
            }
        }

        private void ShowMainForm()
        {
            if (mainForm == null)
            {
                mainForm = new MainFormUI();
                mainForm.Closed += mainForm_Closed;
                mainForm.Show();
            }
            else { mainForm.Activate(); }
        }
        void mainForm_Closed(object sender, EventArgs e) { mainForm = null; }


        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;

            // TODO add current action label
            // TODO add direct action switching
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripButton("Show main menu", null, showMainMenu_Click));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripButton("Exit", null, exitItem_Click));
            notifyIcon.ContextMenuStrip.ShowCheckMargin = false;
            notifyIcon.ContextMenuStrip.ShowImageMargin = false;
        }
        private void ContextMenuStrip_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            notifyIcon.ContextMenuStrip.Items.Clear();
        }

        private void showMainMenu_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }
        private void exitItem_Click(object sender, EventArgs e)
        {
            ExitThread();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) { components.Dispose(); }
        }

        protected override void ExitThreadCore()
        {
            if (mainForm != null) { mainForm.Close(); }
            dbConn.Close();
            notifyIcon.Visible = false; // should remove lingering tray icon!
            base.ExitThreadCore();
        }
    }
}
