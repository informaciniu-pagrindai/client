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
        public List<string> shortcuts { get; set; }

        public Project(string id, string title)
        {
            Id = id;
            Title = title;
            shortcuts = new List<string>();
        }
    }
}
