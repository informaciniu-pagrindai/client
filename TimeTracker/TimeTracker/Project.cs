using System.Collections.Generic;

namespace TimeTracker
{
    public class Project
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string RoleName { get; set; }
        public List<ProjectActionType> ActionTypes { get; set; }

        public Project(string id, string title, string roleName)
        {
            Id = id;
            Title = title;
            RoleName = roleName;
            ActionTypes = new List<ProjectActionType>();
        }
    }
}
