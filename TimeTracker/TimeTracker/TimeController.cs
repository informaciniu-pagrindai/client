using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class TimeController
    {
        private TimeTracker timeTracker;

        public TimeController(TimeTracker parent)
        {
            timeTracker = parent;
        }
    }
}
