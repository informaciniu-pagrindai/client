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

        private SQLiteConnection dbConn;
        private string sessionToken = null;

        public ServiceProvider(SQLiteConnection dbConnection)
        {
            dbConn = dbConnection;

            // Retrieve last login data
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM UserData", dbConn);
            SQLiteDataReader dreader = command.ExecuteReader();
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

        public bool LoginDataValid()
        {
            if ((userlogin != null) && (userpass != null))
            {
                // TODO verify email and password hash corectness
                return true;
            }
            return false;
        }

        public bool TryConnect() // TODO return reason
        {
            if (LoginDataValid())
            {
                // TODO connect to server..

                if (false)
                {
                    // Failure
                    return false;
                }
                else
                {
                    sessionToken = "";

                    // Update db record
                    SQLiteCommand command = new SQLiteCommand( "UPDATE UserData SET login = '" +
                        userlogin + "', pass = '" + userpass + "' WHERE UserDataID = 'default';", dbConn);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
            else
            {
                return false;
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
    }
}
