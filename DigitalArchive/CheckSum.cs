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
        public static int itemID;
        public static string Main(String filePath)
        {
            string checkfile = filePath;
            byte[] hashValue = default;
            string retVal = null;
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

                        retVal = CheckSum.ChecksumToStr(hashValue);

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            return retVal;
        }

        static string ChecksumToStr(byte[] hashVal)
        {
            /*
             * J Vincent
             * convert hash byte[] value to string
             * so it can be stored in db
             * in comparison hash byte[] will also need to be converted to string
             * 
             */

            string retVal;
            //convert hash to string
            var strHash = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < hashVal.Length; i++)
            {
                strHash.Append(hashVal[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            retVal = strHash.ToString();


            return retVal;
        }

        public static int CheckCheckSum(string fileDir, String fileName)
        {
            /*
             * J Vincent
             * check checksum of file compared to value stored in DB
             * return 0 not in db (black icon)
             * return 1 in db but checksum different (red icon)
             * return 2 in db and checksum ok (green icon)
             * 
             */
            int checkOK = 0;
            if (fileDir != null)
            {

                string check1 = Main(fileDir + "\\" + fileName);
                string check2 = default;
                string filePath = null;
                if (fileDir != null) filePath = fileDir.Replace(Globals.curCatPath, "");
                {
                    SQLiteConnection cat_conn = new SQLiteConnection(Globals.connCat);
                    cat_conn.Open();

                    string sql = "SELECT itemChecksum, itemID FROM tblItems WHERE itemName = '" + fileName + "' " +
                        "AND itemPath = '" + filePath + "';";

                    SQLiteDataReader sqlRead;
                    SQLiteCommand sql_cmd;
                    sql_cmd = cat_conn.CreateCommand();
                    sql_cmd.CommandText = sql;

                    sqlRead = sql_cmd.ExecuteReader();
                    while (sqlRead.Read())
                    {
                        check2 = sqlRead.GetString(0);
                        itemID = sqlRead.GetInt32(1);

                        checkOK = 1;
                    }
                    cat_conn.Close();

                    if (check1 == check2 && check1 != null)
                    {
                        checkOK = 2;
                    }
                }
            }
            if (checkOK == 1) ChangeLog.Main("Checksum different: " + fileName, itemID);
            return checkOK;
            
        }

    }
}
