using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;


namespace DigitalArchive
{
    public class NewCatalogue 
    {

        /*
         * J Vincent
         * 
         * Create New Catalogue
         * Creates new catalogue in DACAT sub folder at chosen location
         * with Name and Description
         * Creates databas structure and populates with required info
         * 
         * 
         */

        public String retMessage;

        public NewCatalogue(string catPath, string catName, string catDesc)
        {
            {
                string CatUUID;
                try
                {
                    throw new NotImplementedException();
                }
                catch (NotImplementedException notImp)
                {
                    Boolean bName = false;
                    Boolean bDesc = false;
                    Boolean bDir = false;

                    //check the chosen directory is OK
                    DirectoryInfo di = new DirectoryInfo(catPath);
                    if (di.Exists) bDir = true;
                    if (catName.Length > 5 && catName.Length < 121) bName = true;
                    if (catDesc.Length > 10 && catDesc.Length < 256) bDesc = true;

                    if (bDir == true && bName == true && bDesc == true)
                    {
                        //create unique file name for catalogue
                        string myGuid = System.Guid.NewGuid().ToString();
                        //create DACAT folder for catalogue to sit in
                        Directory.CreateDirectory(catPath + "\\DACAT");
                        //create readme.txt with instructions not to delete!
                        File.WriteAllText(catPath + "\\DACAT\\" + catName.Replace(' ', '_') + "_ReadMe.txt", DateTime.Today.ToString() + "\r\nDigital Archive: " + catName + "\r\nDo not delete the catalogue file " + myGuid + ".dacat ");
                        //full path for catalogue
                        CatUUID = catPath + "\\DACAT\\" + myGuid + ".dacat";
                        //create cataloge and connection
                        SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + CatUUID + "; Version = 3; Compress = True;");
                        dbConn.Open();
                        //populate the database with tables
                        string sql = "CREATE TABLE tblCatalogue(catName       VARCHAR(120) UNIQUE NOT NULL, " +
                               "catUUID       VARCHAR(255)  UNIQUE  NOT NULL, " +
                               "catCreated    DATETIME          NOT NULL UNIQUE, " +
                               "catDesc       VARCHAR(255) UNIQUE NOT NULL, " +
                               "catVersion    VARCHAR(18)  UNIQUE NOT NULL, " +
                               "catLastUpdate DATETIME          UNIQUE NOT NULL " +
                               "); ";
                        sql += "CREATE TABLE tblItems (" +
                              "itemID INTEGER       PRIMARY KEY ASC AUTOINCREMENT NOT NULL UNIQUE, " +
                              "itemAdded DATETIME      NOT NULL, " +
                              "itemAddedBy    VARCHAR(50)  NOT NULL, " +
                              "itemName       VARCHAR(255) NOT NULL, " +
                              "itemPath       VARCHAR(255) NOT NULL, " +
                              "itemChecksum   BLOB(32) NOT NULL, " +
                              "itemLastChange DATETIME NOT NULL, " +
                              "itemOwner      VARCHAR(128), " +
                              "itemCopyright  BOOLEAN NOT NULL DEFAULT(0), " +
                              "itemGDPR       BOOLEAN NOT NULL DEFAULT(0) " +
                              ");   ";
                        sql += "CREATE TABLE tbllkpMetaFormat(metaTitle VARCHAR(255) UNIQUE PRIMARY KEY ASC);";
                        sql += "CREATE TABLE tblItemMeta(metaID     INTEGER       PRIMARY KEY ASC AUTOINCREMENT UNIQUE NOT NULL, " +
                              "itemID     INTEGER       REFERENCES tblItems(itemID) NOT NULL, " +
                              "metaOrig   BOOLEAN       NOT NULL DEFAULT(0), " +
                              "metaTitle  VARCHAR(255) NOT NULL REFERENCES tbllkpMetaFormat(metaTitle), " +
                              "metaFormat VARCHAR(50)  NOT NULL, " +
                              "metaData   VARCHAR(255) NOT NULL " +
                              "); ";
                        sql += "CREATE TABLE tblChangeLog ( " +
                            "logID INTEGER        PRIMARY KEY ASC AUTOINCREMENT UNIQUE NOT NULL, " +
                            "logItemID INTEGER        NOT NULL, " +
                            "logDateTime   DATETIME NOT NULL, " +
                            "logChangedBy VARCHAR(15)  NOT NULL, " +
                            "logChangeDets VARCHAR(1024) NOT NULL, " +
                            "logCatVersion VARCHAR(16)   NOT NULL " +
                            "); ";
                        SQLiteCommand command = new SQLiteCommand(sql, dbConn);
                        command.ExecuteNonQuery();
                        DateTime theDate = DateTime.Now;
                        string newVersion = theDate.ToString("yyyyMMddHHmmssFFF");
                        //Insert startup information into tables
                        sql = "INSERT INTO tblCatalogue VALUES ('" + catName +
                            "', '" + CatUUID + "', '" + DateTime.Now +
                            "', '" + catDesc + "', '"+newVersion+"', '" + theDate + "'); ";
                        //these are the types of Metadata we want to store (keywords can be added)
                        sql += "INSERT INTO tbllkpMetaFormat (metaTitle)" +
                            "VALUES ('TYPE OF FILE'), ('NAME'), ('SIZE'), ('CREATED'), ('MODIFIED'), ('READ ONLY'), ('LOCATION'), " +
                            "('HIDDEN'), ('DATE TAKEN'), ('KEYWORDS');";
                        command = new SQLiteCommand(sql, dbConn);
                        command.ExecuteNonQuery();
                        dbConn.Close();
                        // add data to digarch.dacat to update with latest catalogue
                        Catalogue curCat = new Catalogue(CatUUID);

                        // update info on screen
                        this.retMessage = "Catalogue " + curCat.catUUID + " has been created";

                        
                    }
                    else
                    {
                        this.retMessage = "You must choose a location for the catalogue \r\nand enter a name between 5 and 120 characters \r\nand description between 10 and 255 characters";
                    }

                }

            }
        }

    }
}
