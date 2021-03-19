using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Data.SQLite;


namespace DigitalArchive
{
    public class CheckSum
    {
        /*
         * J Vincent
         * return checksum of file
         * stored to check fixity of file 
         * check file exists first
         * SHA256 returned as byte[] (stored as BLOB(32) in SQLite)
         * 
         */
        public static byte[] Main(String filePath)
        {
            string checkfile = filePath;
            byte[] hashValue = default;
            //check file valid
            if (File.Exists(checkfile))
            {
                using (SHA256 mySHA256 = SHA256.Create())
                {
                    try
                    {
                        FileStream fileStream = new FileStream(checkfile, FileMode.Open);
                        // Be sure it's positioned to the beginning of the stream.
                        fileStream.Position = 0;
                        // Compute the hash of the fileStream.
                        hashValue = mySHA256.ComputeHash(fileStream);
                        // Close the file.
                        fileStream.Close();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            return hashValue;
        }

        public static Boolean CheckCheckSum(String filePath)
        {
            /*
             * J Vincent
             * check checksum of file compared to value stored in DB
             */

            Boolean checkOK = default;
            byte[] check1 = Main(filePath);
            byte[] check2;
            {
                int myItemID = 0;
                SQLiteConnection cat_conn = new SQLiteConnection(Globals.connCat);
                cat_conn.Open();

                string sql = "SELECT FROM tblItems itemChecksum WHERE itemName = '" + itemName + "' " +
                    "AND itemPath = '" + itemPath + "';";

                SQLiteDataReader sqlRead;
                SQLiteCommand sql_cmd;
                sql_cmd = cat_conn.CreateCommand();
                sql_cmd.CommandText = sql;

                sqlRead = sql_cmd.ExecuteReader();
                while (sqlRead.Read())
                {
                    check2 = sqlRead.GetBytes(0);
                }
                cat_conn.Close();

            if (check1 == check2)
            {
                checkOK = true;
            }


            return checkOK;
        }

    }
}
