using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class MainFormUI : Form
    {
        ApplicationDbContext context = new ApplicationDbContext();
        List<Project> projects = new List<Project>();
      //  List<AspNetUsers> users = new List<AspNetUsers>();
        List<ProjectMembers> projectMembers = new List<ProjectMembers>();
        //LogInForm LoginForm = new LogInForm(false);
        public AspNetUsers currentUser { get; set; }

        private TimeTracker timeTracker;
        private HistoryForm historyForm = null;
        private ProjectsForm projectsForm = null;
        //private ShortcutsForm shortcutsForm = null;

        public MainFormUI(TimeTracker timetracker)
        {
            timeTracker = timetracker;
            InitializeComponent();

            //ProjectsRepository ProjectRepository = new ProjectsRepository(context);
            //AspNetUsersRepository UserRepository = new AspNetUsersRepository(context);
            //ProjectMembersRepository ProjectMemberRepository = new ProjectMembersRepository(context);

            //projects = ProjectRepository.GetAll();
            //users = UserRepository.GetAll();
            //projectMembers = ProjectMemberRepository.GetAll();

            //currentUser = LoginForm.GetUser();

            // TEMP HACK
            stateGBox.Enabled = true;
            shortcutGBox.Enabled = true;
        }

        public void ActivateProject(Project project)
        {
            curProjNameLabel.Text = project.Title;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            timeTracker.LogOut();
        }

        private void curProjNameLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open project select window
            List<Project> projects = timeTracker.GetUserProjects();
            if (projectsForm == null)
            {
                projectsForm = new ProjectsForm(timeTracker, projects);
                projectsForm.Closed += projectsForm_Closed;
                projectsForm.Show();
            }
            else { projectsForm.Activate(); }
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            // Open action history window
            List<ProjectAction> actions = timeTracker.GetActionHistory();
            if (historyForm == null)
            {
                historyForm = new HistoryForm(timeTracker, actions);
                historyForm.Closed += historyForm_Closed;
                historyForm.Show();
            }
            else { historyForm.Activate(); }
        }

        private void shortcutsEditBtn_Click(object sender, EventArgs e)
        {
            // Open shortcut edit window
            /*if (shortcutsForm == null)
            {
                shortcutsForm = new ShortcutsForm();
                shortcutsForm.Closed += shortcutsForm_Closed;
                shortcutsForm.Show();
            }
            else { shortcutsForm.Activate(); }*/
        }

        void projectsForm_Closed(object sender, EventArgs e)
        {
            projectsForm = null;
        }
        void historyForm_Closed(object sender, EventArgs e)
        {
            historyForm = null;
        }
        void shortcutsForm_Closed(object sender, EventArgs e)
        {
            //shortcutsForm = null;
        }
    }
}
