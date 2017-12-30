using System;
using System.Collections.Generic;
using System.Text;
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
            foreach (var act in history)
            {
                int rowid = historyGrid.Rows.Add();
                historyGrid.Rows[rowid].Tag = act;
                historyGrid.Rows[rowid].Cells[0].Value = act.Type.Name;
                historyGrid.Rows[rowid].Cells[1].Value = act.StartTime;
                if (act.EndTime != DateTime.MinValue)
                    historyGrid.Rows[rowid].Cells[2].Value = act.EndTime;
            }
        }
    }
}
