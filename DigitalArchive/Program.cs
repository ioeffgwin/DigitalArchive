using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace DigitalArchive
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Globals.OpenArgs = args;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //test to see if first use

            // Open the connection:
            try
            {
                SQLiteConnection sys_Conn = new SQLiteConnection(Globals.connApp);
                sys_Conn.Open();
                string sqlt = "SELECT userName FROM tblAppSystem;";
                SQLiteDataReader sqlRead;
                SQLiteCommand sql_cmd;
                sql_cmd = sys_Conn.CreateCommand();
                sql_cmd.CommandText = sqlt;

                sqlRead = sql_cmd.ExecuteReader();
                while (sqlRead.Read())
                {
                    Globals.usersName = sqlRead.GetString(0);
                }
                sys_Conn.Close();
            }
            catch (Exception)
            {
                //no sys database - run first use screen. Get UserName from PC.
                string myName = Environment.UserName;
                Globals.usersName = myName;
                FirstUse(myName);
            }

            Application.Run(new MainForm());

        }

        static void FirstUse(string userName)
        {
            SQLiteConnection sys_Conn = new SQLiteConnection(Globals.connApp + " New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sys_Conn.Open();
                //return sys_Conn;

                string sysName = System.Guid.NewGuid().ToString();

                //first time app is used system db needs to be created 

                string sql = "CREATE TABLE tblAppSystem ( " +
                "UUID          TEXT (255)    UNIQUE ON CONFLICT ROLLBACK NOT NULL, " +
                "AppInstalled  DATETIME         NOT NULL, " +
                "LastCatalogue TEXT (40), " +
                "userName      VARCHAR (15) NOT NULL " +
                "); " +
                "CREATE TABLE tblCatsOpened ( " +
                "catsOpenedID  INTEGER    PRIMARY KEY ASC AUTOINCREMENT UNIQUE NOT NULL, " +
                "catUUID       TEXT (255)  NOT NULL, " +
                "catName       TEXT (120) NOT NULL, " +
                "catDateOpened DATETIME       NOT NULL, " +
                "catPath       TEXT (255) NOT NULL " +
                "); " +
                "CREATE TABLE tblChangeLog ( " +
                "logID         INTEGER      PRIMARY KEY ASC AUTOINCREMENT UNIQUE NOT NULL, " +
                "logCatUUID    TEXT (255)    NOT NULL, " +
                "logItemID     INTEGER      NOT NULL, " +
                "logDateTime   DATETIME     NOT NULL, " +
                "logChangeDets TEXT (1024)  NOT NULL, " +
                "logChangedBY  VARCHAR (15) NOT NULL " +
                "); " +
                "INSERT INTO tblAppSystem (UUID, AppInstalled, userName)" +
                "VALUES ('" + sysName + "', '" + DateTime.Now + "', '" + userName + "');";
                SQLiteCommand command = new SQLiteCommand(sql, sys_Conn);
                command.ExecuteNonQuery();
                sys_Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
