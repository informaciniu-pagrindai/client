using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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
        public AspNetUsers connectedUser = null;

        private TimeTracker timeTracker;
        private SQLiteConnection dbConn;
        private ApplicationDbContext remotedb;
        private string sessionToken = null;

        private Action loginSuccessCallback;
        private Action<string> loginFailCallback;

        List<AspNetUsers> users = new List<AspNetUsers>();
        List<Project> userProjects = new List<Project>();
        // For local action indexing
        private int localActIndex;

        public ServiceProvider(TimeTracker parent, SQLiteConnection dbConnection, ApplicationDbContext remoteDB)
        {
            timeTracker = parent;
            dbConn = dbConnection;
            remotedb = remoteDB;

            // Find last local entry index
            using (SQLiteCommand command = new SQLiteCommand("SELECT actionID FROM Actions WHERE actionID LIKE '\\_%' ESCAPE '\\'", dbConn))
            using (SQLiteDataReader dreader = command.ExecuteReader())
            {
                if (dreader.HasRows)
                {
                    dreader.Read();
                    string idstr = ReadNullableString(dreader, "actionID");
                    localActIndex = 1; // TODO parse index from ID string
                }
                else
                {
                    localActIndex = 0;
                }
            }
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

        private bool VerifyUser()
        {
            AspNetUsersRepository UserRepository = new AspNetUsersRepository(remotedb);
            users = UserRepository.GetAll();

            var user = users.Find(x => userlogin.Equals(x.Email));
            connectedUser = user;
            //PasswordHash.ValidatePassword(userpass, user.PasswordHash);
            //PasswordVerificationResult passwordVerRes = new PasswordHasher().VerifyHashedPassword(user.PasswordHash, pwdTextbox.Text);
            //VerifyHashedPassword(user.PasswordHash, userpass);

            return user != null;
        }

        public void TryLogin(Action successCallback, Action<string> failCallback)
        {
            if (LoginDataValid())
            {
                loginSuccessCallback = successCallback;
                loginFailCallback = failCallback;

                if (!VerifyUser()) // TODO move to web response callback
                {
                    // Failure
                    string sql = "UPDATE UserData SET login = '" + userlogin +
                        "', pass = NULL WHERE UserDataID = 'default';";
                    using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
                    {
                        command.ExecuteNonQuery();
                    }
                    loginFailCallback("Neteisingas e-paštas ar slaptažodis");
                }
                else
                {
                    sessionToken = "..."; // HACK

                    // Update db record, TODO: if "remember" is checked
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
            ProjectMembersRepository ProjectMembersRepo = new ProjectMembersRepository(remotedb);
            ProjectsRepository ProjectsRepo = new ProjectsRepository(remotedb);

            ProjectActionsRepository ProjectsActionsRepo = new ProjectActionsRepository(remotedb);
            RegisteredActionsRepository RegisteredActionsRepo = new RegisteredActionsRepository(remotedb);

            List<ProjectActions> allProjectActions = ProjectsActionsRepo.GetAll();
            List<RegisteredActions> allRegisteredActions = RegisteredActionsRepo.GetAll();

            List<Project> allProjects = ProjectsRepo.GetAll();
            List<ProjectMembers> allProjectsMembers = ProjectMembersRepo.GetAll();

            List<ProjectMembers> projectsIds = allProjectsMembers.FindAll(x => connectedUser.Id.Equals(x.UserId));

            List<ProjectActions> availableProjectsActions = new List<ProjectActions>();
            foreach (Project proj in allProjects)
            {
                foreach (ProjectMembers projMemb in projectsIds)
                {
                    if (proj.Id.Equals(projMemb.ProjectId))
                    {
                        List<ProjectActions> templist = allProjectActions.FindAll(x => proj.Id.Equals(x.ProjectId));
                        availableProjectsActions.AddRange(templist);

                        string rolename = "FIXME";
                        string sql = "UPDATE UserProjects SET 'title'='" + proj.Title + "', 'roleName'='" + rolename + "' WHERE 'projectID'='" + proj.Id + "';" +
                          "INSERT OR IGNORE INTO UserProjects (projectID, title, roleName) VALUES('" + proj.Id + "', '" + proj.Title + "', '" + rolename + "');";
                        using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
                        {
                            command.ExecuteNonQuery();
                        }
                        // TODO remove untouched projects (and thus child entries)
                    }
                }
            }

            foreach (ProjectActions pa in availableProjectsActions)
            {
                string sql = "UPDATE ActionTypes SET 'name'='" + pa.Description + "', 'actionTypeID'='" + pa.Id + "' WHERE 'fk_project'='" + pa.ProjectId + "';" + 
                    "INSERT OR IGNORE INTO ActionTypes (actionTypeID, fk_project, name) VALUES('" + pa.Id + "', '" + pa.ProjectId + "', '" + pa.Description + "');";
                using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
                {
                    command.ExecuteNonQuery();
                }
            }

         //   List<ProjectActions> test = availableProjectsActions;
         //   List<Project> userProjects = allProjects.FindAll(x => connectedUser.Id.Equals(x.))

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

        public void SetActiveProject(Project project)
        {
            string sql = "UPDATE UserData SET fk_activeProject = '" + project.Id + "' WHERE UserDataID = 'default';";
            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
            {
                command.ExecuteNonQuery();
            }
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
                    Keys shortcut = (Keys)dreader.GetInt32(dreader.GetOrdinal("shortcut"));
                    var act = new ProjectActionType(id, name, shortcut);
                    project.ActionTypes.Add(act);
                }
            }
        }
        public void SetActionShortcut(ProjectActionType action, Keys newShortcut)
        {
            string sql = "UPDATE ActionTypes SET shortcut='" + (int)newShortcut
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

                        var act = new ProjectAction(id, acttype, starttime, endtime);
                        acts.Add(act);
                    }
                }
            }
            return acts;
        }

        public ProjectAction CreateLocalAction(ProjectActionType type, DateTime startTime)
        {
            string actid = "_act" + localActIndex++;
            var act = new ProjectAction(actid, type, startTime, DateTime.MinValue);
            int starttime = ToUnixTimestamp(startTime);

            string sql = "INSERT INTO Actions ('actionID','fk_actionType','isLocal','startTime','endTime','modified') VALUES ('"
                + actid + "','" + type.Id + "',1 ,'" + starttime + "',0 ,1);";
            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
            {
                command.ExecuteNonQuery();
            }
            return act;
        }

        public void UpdateAction(ProjectAction action)
        {
            int starttime = ToUnixTimestamp(action.StartTime);
            int endtime = ToUnixTimestamp(action.EndTime);

            string sql = "UPDATE Actions SET 'startTime'=" + starttime +
                ",'endTime'=" + endtime + ",'modified'=1 WHERE actionID='"+action.Id+"';";
            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
            {
                command.ExecuteNonQuery();
            }
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
        /// <param name="dtime">Any DateTime</param>
        /// <returns>The given DateTime in Unix timestamp format</returns>
        public static int ToUnixTimestamp(DateTime dtime)
        {
            return (int)Math.Truncate((dtime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }

        /// <summary>
        /// Converts a given Unix timestamp into DateTime
        /// </summary>
        /// <param name="unixTime">Unix timestamp</param>
        /// <returns>The given Unix timestamp in DateTime format</returns>
        public static DateTime ToDateTime(int unixTime)
        {
            return new DateTime(1970, 1, 1).AddSeconds(unixTime);
        }
    }
}
