using System;

namespace TimeTracker
{
    public class ProjectAction
    {
        public string Id { get; set; }
        public ProjectActionType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsLocal { get; set; }
        public bool IsModified { get; set; }

        public ProjectAction(string id, ProjectActionType type, DateTime startTime, DateTime endTime,
            bool isLocal = true, bool isModified = true)
        {
            Id = id;
            Type = type;
            StartTime = startTime;
            EndTime = endTime;
            IsLocal = isLocal;
            IsModified = isModified;
        }
    }
}
