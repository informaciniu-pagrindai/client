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

        // For local action indexing
        private int localActIndex = 0;

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
                    var proj = new Project(id, title, rolename);
                    UpdateActionTypes(proj);
                    projs.Add(proj);
                }
            }
            return projs;
        }

        public void UpdateActionTypes(Project project)
        {
            string sql = "SELECT * FROM ActionTypes WHERE fk_project='" + project.Id + "';";
            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
            using (SQLiteDataReader dreader = command.ExecuteReader())
            {
                project.ActionTypes.Clear();
                while (dreader.Read())
                {
                    string id = dreader.GetString(dreader.GetOrdinal("actionTypeID"));
                    string name = dreader.GetString(dreader.GetOrdinal("name"));
                    string shortcut = ReadNullableString(dreader, "shortcut");
                    var act = new ProjectActionType(id, name, shortcut);
                    project.ActionTypes.Add(act);
                }
            }
        }
        public void SetActionShortcut(ProjectActionType action, string newShortcut)
        {
            string sql = "UPDATE ActionTypes SET shortcut='" + newShortcut
                + "' WHERE actionTypeID='" + action.Id + "';";
            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<ProjectAction> GetActionHistory(Project targetProject)
        {
            List<ProjectAction> acts = new List<ProjectAction>();
            foreach (var acttype in targetProject.ActionTypes)
            {
                string sql = "SELECT * FROM Actions WHERE fk_actionType='" + acttype.Id + "';";
                using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
                using (SQLiteDataReader dreader = command.ExecuteReader())
                {
                    while (dreader.Read())
                    {
                        string id = dreader.GetString(dreader.GetOrdinal("actionID"));
                        bool islocal = dreader.GetBoolean(dreader.GetOrdinal("isLocal"));
                        DateTime starttime = ToDateTime(dreader.GetInt32(dreader.GetOrdinal("startTime")));
                        DateTime endtime;
                        int etcol = dreader.GetOrdinal("endTime");
                        if (dreader.IsDBNull(etcol))
                            endtime = DateTime.MinValue;
                        else
                            endtime = ToDateTime(dreader.GetInt32(etcol));
                        bool ismodified = dreader.GetBoolean(dreader.GetOrdinal("modified"));

                        var act = new ProjectAction(id, acttype, DateTime.MinValue, DateTime.MaxValue);
                        acts.Add(act);
                    }
                }
            }
            return acts;
        }
        public ProjectAction AddAction(ProjectActionType type, DateTime startTime)
        {
            string actid = "_act" + localActIndex;
            var act = new ProjectAction(actid, type, startTime, DateTime.MinValue);
            int starttime = 0; // TODO convert start time to target format

            string sql = "INSERT INTO Actions ('actionID','fk_actionType','isLocal','startTime','endTime','modified') VALUES ('"
                + actid + "','" + type.Id + "','true','" + starttime + "',NULL,'true');";
            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
            {
                command.ExecuteNonQuery();
            }
            return act;
        }

        private string ReadNullableString(SQLiteDataReader reader, string columnName)
        {
            int col = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(col))
                return null;
            else
                return reader.GetString(col);
        }

         /// <summary>
         /// Converts a given DateTime into a Unix timestamp
         /// </summary>
         /// <param name="value">Any DateTime</param>
         /// <returns>The given DateTime in Unix timestamp format</returns>
        public static int ToUnixTimestamp(DateTime value)
        {
            return (int)Math.Truncate((value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }

        public static DateTime ToDateTime(int unixTime) // TODO
        {
            return new DateTime(1970, 1, 1);
        }
    }
}
