
namespace TimeTracker
{
    public class ProjectActionType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }

        public ProjectActionType(string id, string name, string shortcut)
        {
            Id = id;
            Name = name;
            Shortcut = shortcut;
        }
    }
}
