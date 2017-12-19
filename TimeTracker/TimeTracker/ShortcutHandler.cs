using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class ShortcutHandler
    {
        private TimeTracker timeTracker;
        private Project activeProject = null;

        public ShortcutHandler(TimeTracker parent)
        {
            timeTracker = parent;
        }

        public void RegisterShortcuts(Project project)
        {
            activeProject = project;
            foreach (ProjectAction act in project.Actions)
            {
                if (act.Shortcut != null)
                {
                    // Register hotkey
                    //string[] keys = act.Shortcut.Split();
                }
            }
        }
        public void ClearShortcuts()
        {
            activeProject = null;
            // TODO unregister
        }
    }
}
