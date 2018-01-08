using System;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class LogInForm : Form
    {
        private TimeTracker timeTracker;

        public LogInForm(TimeTracker timeTracker)
        {
            this.timeTracker = timeTracker;
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (VerifyEmail(emailTextbox.Text))
            {
                if (pwdTextbox.Text.Length > 0)
                {
                    showLoggingstate(true);
                    timeTracker.TryLogin(emailTextbox.Text, pwdTextbox.Text);
                }
                else
                {
                    MessageBox.Show("Neįvestas slaptažodis!");
                }
            }
            else
            {
                MessageBox.Show("Neteisingas e-paštas!");
            }
        }

        public void showLoggingstate(bool logging)
        {
            if (logging)
            {
                logInButton.Text = "Jungiamasi..";
                logInButton.Enabled = false;
                emailTextbox.Enabled = false;
                pwdTextbox.Enabled = false;
            }
            else
            {
                logInButton.Text = "Prisijungti";
                logInButton.Enabled = true;
                emailTextbox.Enabled = true;
                pwdTextbox.Enabled = true;
                emailTextbox.Focus();
            }
        }

        public void LoginFailCallback(string message)
        {
            // Restore state
            showLoggingstate(false);
            pwdTextbox.Text = "";

            // Show reason
            MessageBox.Show(message);
        }

        public static bool VerifyEmail(string email)
        {
            // TODO !!!
            return true;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            // TODO Open browser to website register page
        }
    }
}
