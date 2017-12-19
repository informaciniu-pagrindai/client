using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class Project
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string RoleName { get; set; }
        public List<ProjectAction> Actions { get; set; }

        public Project(string id, string title, string roleName)
        {
            Id = id;
            Title = title;
            RoleName = roleName;
            Actions = new List<ProjectAction>();
        }
    }
}
