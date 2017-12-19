using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class ProjectsForm : Form
    {
        private TimeTracker timeTracker;
        private List<Project> projects;

        public ProjectsForm(TimeTracker timetracker, List<Project> projects)
        {
            timeTracker = timetracker;
            this.projects = projects;

            InitializeComponent();
            // TODO fill grid
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            //Project selectedProject = projectsGrid. TODO
            //timeTracker.ActivateProject(selectedProject);
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
