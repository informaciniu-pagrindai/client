using System.Windows.Forms;

namespace TimeTracker
{
    public partial class ShortcutEditFrom : Form
    {
        private TimeTracker timeTracker;
        private ProjectActionType action;

        public ShortcutEditFrom(TimeTracker parent, ProjectActionType targetAction)
        {
            timeTracker = parent;
            action = targetAction;

            InitializeComponent();

            actionLabel.Text += action.Name;
            if (action.Shortcut != null)
                shortcutBox.Text = action.Shortcut;
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void confirmBtn_Click(object sender, System.EventArgs e)
        {
            // TODO verify keys
            timeTracker.SetActionShortcut(action, shortcutBox.Text);
            Close();
        }
    }
}
