using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace DigitalArchive
{
    public class Catalogue
    {
        /*
         * J Vincent
         * Opens catalogue and sets global variables for use
         * 
         * 
         * 
         * 
         */

        public string catUUID; //40 
        public string catName; //120
        public string catDesc; //255
        public string catVer; //18
        public string catPath; //255
        public string catDateCreated; //datetime really
        public string catDateLastUpdate; //datetime really

        public Catalogue(string catPathFull)
        {
            //check if path is valid

            if (File.Exists(catPathFull))
            {
                try
                {
                    string sql = "SELECT catName, catUUID, catCreated, catDesc, catVersion, catLastUpdate FROM tblCatalogue LIMIT 1";
                    SQLiteConnection cat_Conn = new SQLiteConnection("Data Source=" + catPathFull + "; Version = 3; Compress = True;");
                    cat_Conn.Open();
                    SQLiteDataReader sqlRead;
                    SQLiteCommand sql_cmd;
                    sql_cmd = cat_Conn.CreateCommand();
                    sql_cmd.CommandText = sql;

                    //get details of current catalogue to use 
                    sqlRead = sql_cmd.ExecuteReader();
                    while (sqlRead.Read())
                    {
                        this.catUUID = catPathFull;//sqlRead.GetString(sqlRead.GetOrdinal("catUUID"));
                        this.catName = sqlRead.GetString(sqlRead.GetOrdinal("catName"));
                        this.catDesc = sqlRead.GetString(sqlRead.GetOrdinal("catDesc"));
                        this.catVer = sqlRead.GetString(sqlRead.GetOrdinal("catVersion"));
                        this.catDateCreated = sqlRead.GetString(sqlRead.GetOrdinal("catCreated"));
                        this.catDateLastUpdate = sqlRead.GetString(sqlRead.GetOrdinal("catLastUpdate"));
                        this.catPath = Path.GetDirectoryName(this.catUUID).Replace("\\DACAT", "");

                    }
                    cat_Conn.Close();
                    //update app to know what the most recent catalogue is
                    // also add to list of opened catalogues
                    SetLatestCatalogue();
                }
                catch (Exception e)
                {
                    //let user know chosen catalogue not valid
                    Globals.curCatName = "Catalogue not found.";
                    throw e;
                }
                finally
                {
                    //set global variables
                    Globals.curCatUUID = this.catUUID;
                    Globals.curCatName = this.catName;
                    Globals.curCatDesc = this.catDesc;
                    Globals.curCatPath = this.catPath;
                    Globals.curCatVer = this.catVer;
                    Globals.connCat = "Data Source=" + Globals.curCatUUID + "; Version = 3; ";

                }

            }
            else
            {
                Globals.curCatName = "Catalogue not found.";

            }

        }


        public void SetLatestCatalogue()
        {
            /*
             * J Vincent
             * Update app to know what most recent catalogue is and into log of opened catalogues
             * 
             * 
             * 
             */
            // update tblAppSystemb(there is no Where clause as only one line should be in use)
            string sqlu = "UPDATE tblAppSystem SET LastCatalogue = '" + this.catUUID + "'; ";
            // insert tblCatsOpened
            string sqli = "INSERT INTO tblCatsOpened (catUUID, catName, catDateOpened, catPath) " +
                "VALUES ('" + this.catUUID + "','" + this.catName + "','" + DateTime.Now + "','" + this.catPath + "');";

            using (SQLiteConnection conn = new SQLiteConnection(Globals.connApp))
            {
                conn.Open();
                using (SQLiteCommand sql_cmd = new SQLiteCommand(sqlu + sqli, conn))
                {
                    sql_cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static List<int> MissingItems()
        {
            /*
             * J Vincent
             * Identify items in catalogue database that are missing from folders 
             * return as list of itemID from tblItems
             * 
             * 
             */

            int fileID;
            string fileName;
            string filePath;
            List<int> missingFiles = new List<int>();

            //go through tblItems check if exist as real file
            string sql = "SELECT itemID, itemName, itemPath FROM tblItems;";
            using (SQLiteConnection conn = new SQLiteConnection(Globals.connCat))
            {
                conn.Open();
                using (SQLiteCommand sql_cmd = new SQLiteCommand(sql, conn))
                {
                    SQLiteDataReader sqlRead;
                    sqlRead = sql_cmd.ExecuteReader();
                    while (sqlRead.Read())
                    {
                        fileID = sqlRead.GetInt32(0);
                        fileName = sqlRead.GetString(1);
                        filePath = sqlRead.GetString(2);
                        if (File.Exists(Globals.curCatPath + filePath + "\\" + fileName) == false)
                        {
                            missingFiles.Add(fileID);
                        }
                    }
                }
                conn.Close();

                return missingFiles;

            }



        }
        public static string[] GetFileName(int itemID)
        {
            string[] fName = new string[2];
            //go through tblItems check if exist as real file
            string sql = "SELECT itemName, itemPath FROM tblItems WHERE itemID =" + itemID + ";";
            using (SQLiteConnection conn = new SQLiteConnection(Globals.connCat))
            {
                conn.Open();
                using (SQLiteCommand sql_cmd = new SQLiteCommand(sql, conn))
                {
                    SQLiteDataReader sqlRead;
                    sqlRead = sql_cmd.ExecuteReader();
                    while (sqlRead.Read())
                    {
                        fName[0] = sqlRead.GetString(0);
                        fName[1] = sqlRead.GetString(1);
                    }
                }
                conn.Close();



                return fName;
            }


        }

    }
}
