using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class ProjectAction
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }

        public ProjectAction(string id, string name, string shortcut)
        {
            Id = id;
            Name = name;
            Shortcut = shortcut;
        }
    }
}
