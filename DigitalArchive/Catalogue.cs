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
        // Jeff Vincent v1.0
        public string catUUID; //40 
        public string catName; //120
        public string catDesc; //255
        public string catVer; //10
        public string catDateCreated; //datetime really
        public string catDateLastUpdate; //datetime really

        public Catalogue(string catPath)
        {
            //check if path is valid

            //get details of current catalogue to use 

            if (File.Exists(catPath))
                {
                try
                {
                    string sql = "SELECT catName, catUUID, catCreated, catDesc, catVersion, catLastUpdate FROM tblCatalogue LIMIT 1";
                    SQLiteConnection cat_Conn = new SQLiteConnection("Data Source=" + catPath + "; Version = 3; Compress = True;");
                    cat_Conn.Open();
                    SQLiteDataReader sqlRead;
                    SQLiteCommand sql_cmd;
                    sql_cmd = cat_Conn.CreateCommand();
                    sql_cmd.CommandText = sql;

                    sqlRead = sql_cmd.ExecuteReader();
                    while (sqlRead.Read())
                    {
                        this.catUUID = sqlRead.GetString(sqlRead.GetOrdinal("catUUID"));
                        this.catName = sqlRead.GetString(sqlRead.GetOrdinal("catName"));
                        this.catDesc = sqlRead.GetString(sqlRead.GetOrdinal("catDesc"));
                        this.catVer = sqlRead.GetString(sqlRead.GetOrdinal("catVersion"));
                        this.catDateCreated = sqlRead.GetString(sqlRead.GetOrdinal("catCreated"));
                        this.catDateLastUpdate = sqlRead.GetString(sqlRead.GetOrdinal("catLastUpdate"));
                    }
                    cat_Conn.Close();
                }
                catch (Exception e)
                {
                    Globals.curCatName = "Catalogue not found.";
                    throw e;
                }
                finally
                {
                    Globals.curCatUUID = this.catUUID;
                    Globals.curCatName = this.catName;
                    Globals.curCatDesc = this.catDesc;
                
                }

            }
            else
            {
                Globals.curCatName = "Catalogue not found.";

            }

        }




        public void setCatalogueVer(string newVersion)
        { //change Cat Version (and last changed date)
            try
            {
                SQLiteConnection cat_conn = new SQLiteConnection(Globals.connCat);
                cat_conn.Open();
                // update tblAppSystemb(no where clause as only one line should be in use)
                string sqlu = "UPDATE tblCatalogue SET CatVersion = '" + newVersion + "', catLastUpdate = '" + DateTime.Now + "'; ";
                SQLiteCommand sql_cmd;
                sql_cmd = cat_conn.CreateCommand();
                sql_cmd.CommandText = sqlu;
                sql_cmd.ExecuteNonQuery();
                cat_conn.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void setCatalogueLastUpdate()
        { //change Cat last changed date
            try
            {
                SQLiteConnection cat_conn = new SQLiteConnection(Globals.connCat);
                cat_conn.Open();
                // update tblAppSystemb(no where clause as only one line should be in use)
                string sqlu = "UPDATE tblCatalogue SET catLastUpdate = '" + DateTime.Now + "'; ";
                SQLiteCommand sql_cmd;
                sql_cmd = cat_conn.CreateCommand();
                sql_cmd.CommandText = sqlu;
                sql_cmd.ExecuteNonQuery();
                cat_conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        //get items

        //meta data

        //changelog



    }
}
