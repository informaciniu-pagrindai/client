using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class RegisteredActions
    {
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; } //get { return this.EndTime} set { EndTime = DateTime.MinValue
        public string ProjectActionId { get; set; }
        public string ProjectMemberId { get; set; }
        public int Duration { get; set; }
    }
}
