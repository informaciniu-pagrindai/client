using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class HistoryForm : Form
    {
        private TimeTracker timeTracker;
        private List<ProjectAction> history;

        public HistoryForm(TimeTracker timetracker, List<ProjectAction> history)
        {
            timeTracker = timetracker;
            this.history = history;

            InitializeComponent();
            // TODO fill grid
        }
    }
}