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
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateSysConnection();
            //add in code to read data from digarch.db
            // if no data not used before some data required

            InsertData(sqlite_conn);
            ReadData(sqlite_conn);


        }

        static SQLiteConnection CreateSysConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=" +
                "digarch.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
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

        static void ReadData(SQLiteConnection conn)
        {
            /*
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";
            */
        }

        private void btnGetGuid_Click(object sender, EventArgs e)
        {
            string CatName;
            try
            {
                throw new NotImplementedException();            }
            catch(NotImplementedException notImp)
            {
                DialogResult dlgResult = MessageBox.Show("Are you sure you want to create a new catalogue?", notImp.Message,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes && txtCatDesc.TextLength > 5 && txtCatName.TextLength > 5)
                {
                    CatName = System.Guid.NewGuid().ToString() + ".db";
                    lblGuid.Text = CatName;
                    //SQLiteConnection.CreateFile(CatName);
                    SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + CatName + "; Version = 3");
                    dbConn.Open();
                    string sql = "CREATE TABLE tblCatalogue(catName       VARCHAR(120) UNIQUE NOT NULL, " +
                           "catUUID       VARCHAR(40)  UNIQUE  NOT NULL, " +
                           "catCreated    DATE          NOT NULL UNIQUE, " +
                           "catDesc       VARCHAR(255) UNIQUE NOT NULL, " +
                           "catVersion    VARCHAR(10)  UNIQUE NOT NULL, " +
                           "catLastUpdate DATE          UNIQUE NOT NULL);";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConn);
                    command.ExecuteNonQuery();
                    sql = "CREATE TABLE tblItems (" +
                          "itemID INTEGER       PRIMARY KEY ASC AUTOINCREMENT NOT NULL UNIQUE, " +
                          "itemAdded DATETIME      NOT NULL, " +
                          "itemAddedBy    VARCHAR(50)  NOT NULL, " +
                          "itemName       VARCHAR(255) NOT NULL, " +
                          "itemPath       VARCHAR(255) NOT NULL, " +
                          "itemChecksum   VARCHAR(150) NOT NULL, " +
                          "itemLastChange DATETIME NOT NULL);   ";
                    command = new SQLiteCommand(sql, dbConn);
                    command.ExecuteNonQuery();

                    sql = "INSERT INTO tblCatalogue VALUES ('" + txtCatName.Text + "', '" + CatName + "', '" + DateTime.Today + "', '" + txtCatDesc.Text + "', '1.0', '" + DateTime.Now + "')";
                    command = new SQLiteCommand(sql, dbConn);
                    command.ExecuteNonQuery();
                    dbConn.Close();
                    // add data to digarch.db to update with latest catalogue
                    lblGuid.Text = "Catalogue " + CatName + " has been created";
                }
                else
                {
                    lblGuid.Text = "ypu must enter a name and description > 5 characters";
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCatDesc_Click(object sender, EventArgs e)
        {

        }
    }
}

