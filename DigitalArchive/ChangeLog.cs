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
     * 
     * 
     */

        public void AddToLog(string Update, int itemID)
        {   
            /*
             * string update - max 1024 chars Give resume of the update
             * int itemID - item id in the catalogue
             * also global.usersname
             * global.catuuid
             * global.catver
             * 
             */

            string sql;
            //Update App
            sql = "tblChangeLog INSERT logCatUUID, logItemID, logDateTime, logChangedBy, logChangeDets";

            //Update Catalogue
            sql = "tblChangeLog INSERT logItemID, logDateTime, logChangedBy, logChangeDets, logCatVersion";

            //Change catalogue version number
            sql = "tblCatalogue catVersion, catLastUpdate";

        }


    }
}
