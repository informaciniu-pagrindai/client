using System.Windows.Forms;

namespace TimeTracker
{
    public partial class ShortcutEditFrom : Form
    {
        private TimeTracker timeTracker;
        private ProjectActionType action;
        private Keys shortcut; 

        public ShortcutEditFrom(TimeTracker parent, ProjectActionType targetAction)
        {
            timeTracker = parent;
            action = targetAction;
            shortcut = action.Shortcut;

            InitializeComponent();

            actionLabel.Text += action.Name;
            shortcutBox.Text = shortcut.ToString();
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void confirmBtn_Click(object sender, System.EventArgs e)
        {
            if (shortcut != Keys.None)
            {
                timeTracker.SetActionShortcut(action, shortcut);
                Close();
            }
            else
            {
                MessageBox.Show("Nepasirinkta kombinacija");
            }
        }

        private void shortcutBox_Enter(object sender, System.EventArgs e)
        {
            shortcutBox.Text = "";
        }

        private void shortcutBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void shortcutBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
            if ( (e.Modifiers != Keys.None) &&
                (!(e.Shift && (e.KeyCode == Keys.ShiftKey)) && !(e.Control && (e.KeyCode == Keys.ControlKey)) && !(e.Alt && (e.KeyCode == Keys.Menu))))
            {
                shortcut = e.KeyData;
                shortcutBox.Text = e.Modifiers.ToString() + " + " + e.KeyCode.ToString();
                confirmBtn.Focus();
            }
            else
                shortcutBox.Text = "";
        }

        private void shortcutBox_Leave(object sender, System.EventArgs e)
        {
            shortcutBox.Text = (shortcut & Keys.Modifiers).ToString() + " + " + (shortcut & Keys.KeyCode).ToString();
        }
    }
}
