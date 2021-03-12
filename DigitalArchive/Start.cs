using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace DigitalArchive
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            SQLiteConnection sys_conn;
            sys_conn = Globals.sys_Conn;
            lblCurrentCat.Text = "No Catalogue opened";
            //add in code to read data from digarch.dacat
            // if no data not used before some data required

            Catalogue curCat = new Catalogue(GetLatestCatalogue());
            
            lblCurrentCat.Text = "Current Catalogue: " + curCat.catName;
            

        }


        static void InsertData(SQLiteConnection conn, string SQLstr )
        {
            //update cataloge with data
            /*
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable
               (Col1, Col2) VALUES('Test Text ', 1); ";
           sqlite_cmd.ExecuteNonQuery();
            */
        }

        static void SetLatestCatalogue(string catNum, string catName)
        {
            // update tblAppSystemb(no where clause as only one line should be in use)
            string sqlu = "UPDATE tblAppSystem SET LastCatalogue = '" + catNum + "'; ";
            // insert tblCatsOpened
            string sqli = "INSERT INTO tblCatsOpened (catUUID, catName, catDateOpened, catPath) " +
                "VALUES ('" + catNum + "','" + catName + "','" + DateTime.Now + "','\test\');";

            using (SQLiteConnection conn = new SQLiteConnection(Globals.connApp))
            {
                conn.Open();
                using (SQLiteCommand sql_cmd = new SQLiteCommand(sqlu + sqli, conn))
                {
                    sql_cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

            /*
            SQLiteCommand sql_cmd;
            sql_cmd = conn.CreateCommand();
            sql_cmd.CommandText = sqlu + sqli;
            sql_cmd.ExecuteNonQuery();
            */

            /*
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";
            */
        }

        static string GetLatestCatalogue()
        {   //get the name of the most recently opened catalogue

            string catName = null;
            try
            {
                string sqlt = "SELECT LastCatalogue FROM tblAppSystem;";
                using (SQLiteConnection conn = new SQLiteConnection(Globals.connApp))
                {
                    conn.Open();
                    using (SQLiteCommand sql_cmd = new SQLiteCommand(sqlt, conn))
                    {
                        SQLiteDataReader sqlRead;
                        sqlRead = sql_cmd.ExecuteReader();
                        while (sqlRead.Read())
                        {
                            catName = sqlRead.GetString(sqlRead.GetOrdinal("LastCatalogue"));
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
                /*
                DialogResult dlgResult = MessageBox.Show(ex.Message, "Latest Catalogue not found", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                catName = null;
                */
            }


            return catName;

        }

        
        static SQLiteConnection LoadLatestCatalogue()
        {

            //find the latest Catalogue
            string catName = GetLatestCatalogue();

            SQLiteConnection cat_conn;
            // Create a new database connection:
            cat_conn = new SQLiteConnection(Globals.connCat);
            // Open the connection:
            try
            {
                cat_conn.Open();
                cat_conn.Close();
            }
            catch (Exception ex)
            {
                DialogResult dlgResult = MessageBox.Show(ex.Message + catName, "Load Catalogue not found", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return cat_conn;




        }

        public void GetCatalogue()
        {
            //link app to an existing catalogue
            try
            {
                string filePath;
                using (OpenFileDialog catFile = new OpenFileDialog())
                {
                    catFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //"c:\\";
                    catFile.Filter = "dacat files (*.dacat)|*.dacat|All files (*.*)|*.*";
                    catFile.FilterIndex = 2;
                    catFile.RestoreDirectory = true;
                    if (catFile.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = catFile.FileName;

                        try
                        {
                            Catalogue testCat = new Catalogue(filePath);

                        }
                        catch (Exception ex)
                        {
                            DialogResult dlgResult = MessageBox.Show(ex.Message + filePath, "Load Catalogue not found",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        finally
                        {
                            lblCurrentCat.Text = Globals.curCatName;
                        }

                        // if it is then store path and name locally

                        // add data to digarch.dacat to update with latest catalogue


                    }

                }



            }
            catch (Exception e)
            {

            }

        }


        private void btnGetGuid_Click(object sender, EventArgs e)
        {
            string CatUUID;
            try
            {
                throw new NotImplementedException();            }
            catch(NotImplementedException notImp)
            {
                DialogResult dlgResult = MessageBox.Show("Are you sure you want to create a new catalogue?", notImp.Message,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes && txtCatDesc.TextLength > 5 && txtCatName.TextLength > 5)
                {
                    CatUUID = System.Guid.NewGuid().ToString() + ".dacat";
                    lblGuid.Text = CatUUID;
                    //SQLiteConnection.CreateFile(CatName);
                    SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + CatUUID + "; Version = 3; Compress = True;");
                    dbConn.Open();
                    string sql = "CREATE TABLE tblCatalogue(catName       VARCHAR(120) UNIQUE NOT NULL, " +
                           "catUUID       VARCHAR(255)  UNIQUE  NOT NULL, " +
                           "catCreated    DATE          NOT NULL UNIQUE, " +
                           "catDesc       VARCHAR(255) UNIQUE NOT NULL, " +
                           "catVersion    VARCHAR(10)  UNIQUE NOT NULL, " +
                           "catLastUpdate DATE          UNIQUE NOT NULL " +
                           "); ";
                    sql += "CREATE TABLE tblItems (" +
                          "itemID INTEGER       PRIMARY KEY ASC AUTOINCREMENT NOT NULL UNIQUE, " +
                          "itemAdded DATETIME      NOT NULL, " +
                          "itemAddedBy    VARCHAR(50)  NOT NULL, " +
                          "itemName       VARCHAR(255) NOT NULL, " +
                          "itemPath       VARCHAR(255) NOT NULL, " +
                          "itemChecksum   VARCHAR(150) NOT NULL, " +
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
                        "logCatVersion VARCHAR(10)   NOT NULL " +
                        "); ";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConn);
                    command.ExecuteNonQuery();
                    sql = "INSERT INTO tblCatalogue VALUES ('" + txtCatName.Text + 
                        "', '" + CatUUID + "', '" + DateTime.Now + 
                        "', '" + txtCatDesc.Text + "', '1.0', '" + DateTime.Now + "'); ";
                    sql += "INSERT INTO tbllkpMetaFormat (metaTitle)" +
                        "VALUES ('TYPE OF FILE'), ('NAME'), ('SIZE'), ('CREATED'), ('MODIFIED'), ('READ ONLY'), ('LOCATION'), " +
                        "('READ-ONLY'), ('HIDDEN'), ('DATE TAKEN'), ('KEYWORDS');";
                    command = new SQLiteCommand(sql, dbConn);
                    command.ExecuteNonQuery();
                    dbConn.Close();
                    // add data to digarch.dacat to update with latest catalogue
                    SetLatestCatalogue(CatUUID, txtCatName.Text);

                    // update info on screen
                    lblGuid.Text = "Catalogue " + CatUUID + " has been created";
                    lblCurrentCat.Text = "Current Catalogue: " + txtCatName.Text;

                }
                else
                {
                    lblGuid.Text = "you must enter a name and description > 5 characters";
                }

            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "User: " + Globals.usersName;
        }

        private void btnUsersName_Click(object sender, EventArgs e)
        {
            // this needs a bit more validatyion etc
            Globals.usersName = txtUsersName.Text;
        }

        private void btnConnectCat_Click(object sender, EventArgs e)
        {
            //change to a different catalogue
            GetCatalogue();
        }
    }
}

