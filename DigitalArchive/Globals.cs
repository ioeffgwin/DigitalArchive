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
        public static SQLiteConnection sys_Conn;

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
                    Random rnd = new Random();
                    Globals.usersName = uName + rnd.Next(11111, 99999).ToString();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ZZCreateSysConnection()
        {
            string myPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SQLiteConnection sys_conn;
            // Create a new database connection:
            sys_conn = new SQLiteConnection("Data Source=" +
                "digarch.dacat; Version = 3; Compress = True; ");
            // Open the connection:
            try
            {
                sys_conn.Open();
            }
            catch (Exception ex)
            {
                DialogResult dlgResult = MessageBox.Show("Sys DB not found", ex.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Globals.sys_Conn = sys_conn;
            }

        }



    }


}
