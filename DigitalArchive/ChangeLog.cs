using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


namespace DigitalArchive
{
    class ChangeLog
    {

    /* J Vincent
     * update logs for any changes made
     * update app and catalogue DB
     * each time a chnage is made the catalogue version changes.
     * This enables different versions of a catalogue to be compared
     * 
     */

        public void AddToLog(string logUpdate, int itemID)
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
                SQLiteConnection app_conn = new SQLiteConnection(Globals.connApp);
                app_conn.Open();

                sqli = "INSERT INTO tblChangeLog (logCatUUID, logItemID, logDateTime, logChangedBy, logChangeDets) " +
                    "VALUES ('" + Globals.curCatUUID + "'," + itemID + ",'" + DateTime.Now + "','" + Globals.usersName + "','" + logUpdate + "');";
                SQLiteCommand sql_cmd;
                sql_cmd = app_conn.CreateCommand();
                sql_cmd.CommandText = sqli;
                sql_cmd.ExecuteNonQuery();
                app_conn.Close();

                //Update Catalogue
                SQLiteConnection cat_conn = new SQLiteConnection(Globals.connCat);
                cat_conn.Open();

                sqli = "INSERT INTO tblChangeLog (logItemID, logDateTime, logChangedBy, logChangeDets, logCatVersion )" +
                    "VALUES (" + itemID + ", '" + DateTime.Now + "', '" + Globals.usersName + "', '" + logUpdate + "', '" + Globals.curCatVer + "');";
                //sql_cmd already declared
                sql_cmd = cat_conn.CreateCommand();
                sql_cmd.CommandText = sqli;
                sql_cmd.ExecuteNonQuery();
                cat_conn.Close();



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
