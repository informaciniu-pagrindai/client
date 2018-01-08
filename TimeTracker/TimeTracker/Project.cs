using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker
{
    public class Project
    {
        public string Id { get; set; }
        public string Title { get; set; }
        [NotMapped]
        public string RoleName { get; set; }
        public List<ProjectActionType> ActionTypes { get; set; }

        public Project(string id, string title, string roleName)
        {
            Id = id;
            Title = title;
            RoleName = roleName;
            ActionTypes = new List<ProjectActionType>();
        }
        public Project()
        {
        }
    }
}
