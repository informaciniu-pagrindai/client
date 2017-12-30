using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace TimeTracker
{
    public class TimeTracker : ApplicationContext
    {
        SQLiteConnection dbConn;
        private ServiceProvider service;
        private TimeController timctrl;
        private ShortcutHandler schandl;

        private MainFormUI mainForm = null;
        private LogInForm loginForm = null;

        Assembly _assembly;
        Icon icon;
        NotifyIcon notifyIcon;
        System.ComponentModel.Container components;

        // User state vars
        private bool loginResult = false;
        private Project activeProject = null;

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

            service = new ServiceProvider(this, dbConn);
            timctrl = new TimeController(this);
            schandl = new ShortcutHandler(this); // TODO dispose propoerly

            ShowLoginForm();

            // Auto-login if saved data is available
            service.ReadLoginDataFromDB();
            if (service.LoginDataValid())
            {
                loginForm.showLoggingstate(true);
                service.TryLogin(loginSuccessCallback, loginFailCallback);
            }
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
            service.userlogin = email;
            service.userpass = password;
            service.TryLogin(loginSuccessCallback, loginFailCallback);

            // TODO Fetch user project list
            
            ShowMainForm();
        }
        public void LogOut()
        {
            loginResult = false;
            activeProject = null;
            if (mainForm != null)
            {
                mainForm.Close();
            }
            ShowLoginForm();
        }

        public void loginSuccessCallback()
        {
            loginResult = true;
            loginForm.Close();

            ShowMainForm();
            service.UpdateUserProjects(); // send request
        }
        public void loginFailCallback(string reason)
        {
            loginForm.showLoggingstate(false);
        }

        public void ActivateProject(Project project)
        {
            if (project == null)
            {
                schandl.ClearShortcuts();
            }
            else
            {
                service.UpdateActionTypes(project);
                schandl.RegisterShortcuts(project);
            }
            activeProject = project;
            if (mainForm != null)
            {
                mainForm.ActivateProject(project);
            }
        }

        public void SetActionShortcut(ProjectActionType action, string newShortcut)
        {
            service.SetActionShortcut(action, newShortcut);
            service.UpdateActionTypes(activeProject); // Assume action is for active project
            schandl.RegisterShortcuts(activeProject);
            mainForm.UpdateProjectShortcuts();
        }

        public List<Project> GetUserProjects()
        {
            return service.GetUserProjects();
        }
        public List<ProjectAction> GetActionHistory()
        {
            return service.GetActionHistory(activeProject);
        }

        public void HandleActionEvent(ProjectActionType action)
        {
            Console.WriteLine("Ation event: " + action.Id);
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
            if (!loginResult) // Closed / exited
            {
                ExitThread();
            }
        }
        private void ShowMainForm()
        {
            if (mainForm == null)
            {
                mainForm = new MainFormUI(this);
                mainForm.Closed += mainForm_Closed;
                mainForm.Show();
            }
            else { mainForm.Activate(); }
        }
        void mainForm_Closed(object sender, EventArgs e) { mainForm = null; }



        // Application tray
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
