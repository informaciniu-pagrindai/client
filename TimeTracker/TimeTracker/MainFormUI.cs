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
        private Project activeProject = null;
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
        }

        public void ActivateProject(Project project)
        {
            activeProject = project;
            curProjNameLabel.Text = project.Title;
            UpdateProjectShortcuts();
            stateGBox.Enabled = true;
            shortcutGBox.Enabled = true;
        }
        public void UpdateProjectShortcuts()
        {
            // Fill quick action list
            actionDGrid.Rows.Clear();
            foreach (ProjectActionType act in activeProject.ActionTypes)
            {
                int rowid = actionDGrid.Rows.Add();
                actionDGrid.Rows[rowid].Tag = act;
                actionDGrid.Rows[rowid].Cells[0].Value = act.Name;
                if (act.Shortcut == Keys.None)
                    actionDGrid.Rows[rowid].Cells[1].Value = "Nėra";
                else
                    actionDGrid.Rows[rowid].Cells[1].Value = (act.Shortcut & Keys.Modifiers).ToString() + " + " + (act.Shortcut & Keys.KeyCode).ToString(); ;
            }
        }
        public void updateCurrentAction(ProjectAction action)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            if (action == null)
            {
                dataGridView1.Rows[0].Cells[0].Value = "Nėra";
            }
            else
            {
                dataGridView1.Rows[0].Cells[0].Value = action.Type.Name;
                dataGridView1.Rows[0].Cells[1].Value = action.StartTime;
            }
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
            // Open shortcut edit dialog
            if (actionDGrid.SelectedRows.Count > 0)
            {
                ProjectActionType action = (ProjectActionType)actionDGrid.SelectedRows[0].Tag;
                using (var sform = new ShortcutEditFrom(timeTracker, action))
                {
                    sform.ShowDialog(this);
                }
            }
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

        private void actionDGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                ProjectActionType act = (ProjectActionType)senderGrid.Rows[e.RowIndex].Tag;
                timeTracker.HandleActionEvent(act);
            }
        }
    }
}
