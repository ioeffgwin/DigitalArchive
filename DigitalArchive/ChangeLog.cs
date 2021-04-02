using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


namespace DigitalArchive
{
    public class ChangeLog
    {

        /* J Vincent
         * update logs for any changes made
         * update app and catalogue DB
         * each time a chnage is made the catalogue version changes.
         * This enables different versions of a catalogue to be compared
         * 
         */

        public static void Main(string logUpdate, int itemID)
        {
            /*
             * J Vincent
             * 
             * string logupdate - max 1024 chars Give resume of the update
             * int itemID - item id in the catalogue
             * also global.usersname
             * global.catuuid
             * global.catver
             * 
             */

            try
            {
                string sqli;
                //Update App
                using (SQLiteConnection app_conn = new SQLiteConnection(Globals.connApp))
                {

                    app_conn.Open();

                    sqli = "INSERT INTO tblChangeLog (logCatUUID, logItemID, logDateTime, logChangedBy, logChangeDets) " +
                        "VALUES (@curCatUUID, @curItemID, @curDateNow, @curUserName, @curLogUpdate);";
                    using (SQLiteCommand sql_cmd = new SQLiteCommand(sqli, app_conn))
                    {
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curCatUUID", Globals.curCatUUID));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curItemID", itemID));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curDateNow", DateTime.Now));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curUserName", Globals.usersName));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curLogUpdate", logUpdate));
                        sql_cmd.ExecuteNonQuery();

                    }
                    app_conn.Close();
                }

                //Update Catalogue
                using (SQLiteConnection cat_conn = new SQLiteConnection(Globals.connCat))
                {


                    cat_conn.Open();

                    sqli = "INSERT INTO tblChangeLog (logItemID, logDateTime, logChangedBy, logChangeDets, logCatVersion )" +
                        "VALUES (@curItemID, @curDateNow, @curUserName, @curLogUpdate, @curCatVer); ";
                    using (SQLiteCommand sql_cmd = new SQLiteCommand(sqli, cat_conn))
                    {
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curCatUUID", Globals.curCatUUID));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curItemID", itemID));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curDateNow", DateTime.Now));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curUserName", Globals.usersName));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curLogUpdate", logUpdate));
                        sql_cmd.Parameters.Add(new SQLiteParameter("@curCatVer", Globals.curCatVer));
                        sql_cmd.ExecuteNonQuery();
                    }
                    cat_conn.Close();
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GetChangeLog(string AppOrCat)
        {
            /*
             * J Vincent
             * open new form showing change log for either current Catalogue or the  Application
             * Any changes to catalogue are recorded in the catalogue database and the application database
             * so any changes that have been made can be seen
             * important for a catalogue that may be shared by many people
             * (not to be used for finger pointing though - we all make mistakes)
             * The catalogue version changes each time a change is made, so if different copies can be compared
             * 
             */

            //Change logs show the date and version of the catalogue, the user making the change and details of the change made


        }




    }
}
