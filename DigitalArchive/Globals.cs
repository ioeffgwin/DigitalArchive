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
        //if digarch.dacat exists get details and set as globals
        public static string usersName;
        public static string curCatUUID;
        public static string curCatName;
        public static string curCatDesc;
        public static string connApp = "Data Source=digarch.dacat; Version = 3; ";
        public static string connCat = "Data Source=" + Globals.curCatUUID + "; Version = 3; ";

        //set changes to those fields that can have changes
        // tblAppSystem.LastCatalogue (update whenever catalogue loaded)
        // tblAppSystem.UserName - should have not must have
        // tblCatsOpened - update whenever a catalogue is opened (for logging)
        // tblChangeLog - changes made to any catalogue via this app. also log file in each catalogue





        public static void SetUserName(string uName)
        {
            try
            {
                //update db

                if (uName != null || uName.Length < 5)
                {
                    Globals.usersName = uName;
                }
                else
                {
                    //change at somepoint to force atual name but otherwise will add random 5 digits
                    //Random rnd = new Random();
                    //Globals.usersName = uName + rnd.Next(11111, 99999).ToString();

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
