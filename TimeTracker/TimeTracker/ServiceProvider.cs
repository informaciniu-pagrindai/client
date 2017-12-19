using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    /// <summary>
    /// Provides connection to remote service server and exchanges data with it
    /// </summary>
    class ServiceProvider
    {
        public string userlogin = null;
        public string userpass = null;
        public string activeproject = null;

        private TimeTracker timeTracker;
        private SQLiteConnection dbConn;
        private string sessionToken = null;

        private Action loginSuccessCallback;
        private Action<string> loginFailCallback;

        public ServiceProvider(TimeTracker parent, SQLiteConnection dbConnection)
        {
            timeTracker = parent;
            dbConn = dbConnection;
        }
        public void ReadLoginDataFromDB()
        {
            // Retrieve last login data
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM UserData", dbConn))
            using (SQLiteDataReader dreader = command.ExecuteReader())
            {
                if (dreader.HasRows)
                {
                    dreader.Read();
                    userlogin = ReadNullableString(dreader, "login");
                    userpass = ReadNullableString(dreader, "pass");
                    activeproject = ReadNullableString(dreader, "activeProject");
                }
                else
                {
                    // Database corrupt TODO: recreate db
                    throw new InvalidOperationException("Database user data corrupt");
                }
            }
        }

        public bool LoginDataValid()
        {
            if ((userlogin != null) && (userpass != null))
            {
                // TODO verify email and password hash corectness
                return true;
            }
            return false;
        }

        public void TryLogin(Action successCallback, Action<string> failCallback)
        {
            if (LoginDataValid())
            {
                loginSuccessCallback = successCallback;
                loginFailCallback = failCallback;
                // TODO connect to server..

                if (false) // TODO move to web response callback
                {
                    // Failure
                    loginFailCallback("Invalid e-mail or password");
                }
                else
                {
                    sessionToken = "...";

                    // Update db record
                    string sql = "UPDATE UserData SET login = '" + userlogin +
                        "', pass = '" + userpass + "' WHERE UserDataID = 'default';";
                    using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
                    {
                        command.ExecuteNonQuery();
                    }

                    loginSuccessCallback();
                }
            }
            else
            {
                loginFailCallback("Invalid e-mail or password");
            }
        }

        public void UpdateUserProjects()
        {
            // TODO Request and update local db
        }
        public List<Project> GetUserProjects()
        {
            List<Project> projs = new List<Project>();
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM UserProjects", dbConn))
            using (SQLiteDataReader dreader = command.ExecuteReader())
            {
                while (dreader.Read())
                {
                    string id = dreader.GetString(dreader.GetOrdinal("projectID"));
                    string title = dreader.GetString(dreader.GetOrdinal("title"));
                    string rolename = ReadNullableString(dreader, "roleName");
                    Project proj = new Project(id, title, rolename);
                    projs.Add(proj);
                }
            }
            return projs;
        }

        private string ReadNullableString(SQLiteDataReader reader, string columnName)
        {
            int col = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(col))
                return null;
            else
                return reader.GetString(col);
        }
    }
}
