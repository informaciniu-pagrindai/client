using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class LogInForm : Form
    {
        public bool IsLoggedIn;
        public AspNetUsers LoggedInUser { get; set; }

        ApplicationDbContext context = new ApplicationDbContext();
        List<Project> projects = new List<Project>();
        List<AspNetUsers> users = new List<AspNetUsers>();

        private TimeTracker timeTracker;

        public LogInForm(TimeTracker timeTracker)
        {
            this.timeTracker = timeTracker;
            IsLoggedIn = false;

            //ProjectsRepository ProjectRepository = new ProjectsRepository(context);
            //AspNetUsersRepository UserRepository = new AspNetUsersRepository(context);
            //projects = ProjectRepository.GetAll();
            //users = UserRepository.GetAll();

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
                    MessageBox.Show("Password cannot be empty!");
                }
            }
            else
            {
                MessageBox.Show("Invalid e-mail!");
            }
        }

        public void showLoggingstate(bool logging)
        {
            if (logging)
            {
                logInButton.Text = "Logging in..";
                logInButton.Enabled = false;
            }
            else
            {
                logInButton.Text = "Log in";
                logInButton.Enabled = true;
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

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x3D) || (src[1] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        public bool VerifyUser()
        {
            var user = users.Find(x => emailTextbox.Text.Equals(x.Email));
            if (user == null)
            {
                MessageBox.Show("User does not exist");
                return false;
            }
            LoggedInUser = user;
            //   PasswordHash.ValidatePassword(pwdTextbox.Text, user.PasswordHash);
            //  PasswordVerificationResult passwordVerRes = new PasswordHasher().VerifyHashedPassword(user.PasswordHash, pwdTextbox.Text);
            IsLoggedIn = true;   // VerifyHashedPassword(user.PasswordHash, pwdTextbox.Text);
            return IsLoggedIn;
        }
        public AspNetUsers GetUser()
        {
            return LoggedInUser;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            // TODO Open browser to website register page
        }
    }
}
