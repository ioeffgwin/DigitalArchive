using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;


namespace DigitalArchive
{
    public class Globals
    {
        /*
         * J Vincent
         * Global variables used through the app
         * Info taken from digarch.dacat db
         * and current catalogue.dacat db
         * 
         * 
         */

        public static string usersName;
        public static string curCatUUID;
        public static string curCatName;
        public static string curCatDesc;
        public static string curCatPath;
        public static string curCatVer;
        public static string[] OpenArgs; // used if app opened by double clicking on existing catalogue
        public static string connApp = "Data Source=digarch.dacat; Version = 3; ";
        public static string connCat = "Data Source=" + Globals.curCatUUID + "; Version = 3; ";

        //set changes to those fields that can have changes
        // tblAppSystem.LastCatalogue (update whenever catalogue loaded)
        // tblAppSystem.UserName - should have not must have
        // tblCatsOpened - update whenever a catalogue is opened (for logging)
        // tblChangeLog - changes made to any catalogue via this app. also log file in each catalogue

        public static void SetUserName(string uName)
        {
            /*
             * J Vincent
             * user name set automatically on creation of app
             * this allows username for app to be changed later
             * 
             */

            try
            {
                //update db

                if (uName != null || uName.Length < 5)
                {
                    Globals.usersName = uName;
                }
                else
                {
                    //defaults user name from PC
                    Globals.usersName = Environment.UserName; 
                }

                //update app DB
                // update tblAppSystemb(no where clause as only one line should be in use)
                string sqlu = "UPDATE tblAppSystem SET userName = '" + Globals.usersName + "'; ";
                using (SQLiteConnection conn = new SQLiteConnection(Globals.connApp))
                {
                    conn.Open();
                    using (SQLiteCommand sql_cmd = new SQLiteCommand(sqlu, conn))
                    {
                        sql_cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }


}
