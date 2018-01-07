
using System.Windows.Forms;

namespace TimeTracker
{
    public class ProjectActionType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Keys Shortcut { get; set; }

        public ProjectActionType(string id, string name, Keys shortcut)
        {
            Id = id;
            Name = name;
            Shortcut = shortcut;
        }
    }
}
