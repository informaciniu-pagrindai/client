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
            foreach (Project proj in projects)
            {
                int rowid = projectsGrid.Rows.Add();
                projectsGrid.Rows[rowid].Tag = proj;
                projectsGrid.Rows[rowid].Cells[0].Value = proj.Title;
                projectsGrid.Rows[rowid].Cells[1].Value = proj.RoleName;
                StringBuilder sb = new StringBuilder();
                foreach (ProjectAction act in proj.Actions)
                {
                    sb.Append(act.Name);
                    sb.Append("; ");
                }
                projectsGrid.Rows[rowid].Cells[2].Value = sb.ToString();
            }
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (projectsGrid.SelectedRows.Count >= 1)
            {
                Project selectedProject = (Project)projectsGrid.SelectedRows[0].Tag;
                timeTracker.ActivateProject(selectedProject);
                Close();
            }
            else
            {
                MessageBox.Show("Project not selected!", "Caption",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void projectsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Project selectedProject = (Project)projectsGrid.Rows[e.RowIndex].Tag;
            timeTracker.ActivateProject(selectedProject);
            Close();
        }
    }
}
