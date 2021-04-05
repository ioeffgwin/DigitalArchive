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
using System.IO;

namespace DigitalArchive
{
    public partial class NewCat : Form
    {
        public NewCat()
        {
            InitializeComponent();
        }

        private void btnGetGuid_Click(object sender, EventArgs e)
        {
            {
                string CatUUID;
                try
                {
                    throw new NotImplementedException();
                }
                catch (NotImplementedException notImp)
                {
                    DialogResult dlgResult = MessageBox.Show("Are you sure you want to create a new catalogue?", notImp.Message,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    Boolean bName = false;
                    Boolean bDesc = false;
                    Boolean bDir = false;

                    //check the chosen directory is OK
                    DirectoryInfo di = new DirectoryInfo(txtFilePath.Text);
                    if (di.Exists) bDir = true;
                    if (txtCatName.TextLength > 5 && txtCatName.TextLength < 121) bName = true;
                    if (txtCatDesc.TextLength > 10 && txtCatDesc.TextLength < 256) bDesc = true;

                    if (dlgResult == DialogResult.Yes && bDir == true && bName == true && bDesc == true)
                    {
                        //create unique file name for catalogue
                        string myGuid = System.Guid.NewGuid().ToString();
                        //create DACAT folder for catalogue to sit in
                        Directory.CreateDirectory(txtFilePath.Text + "\\DACAT");
                        //create readme.txt with instructions not to delete!
                        File.WriteAllText(txtFilePath.Text + "\\DACAT\\" + txtCatName.Text.Replace(' ', '_') + "ReadMe.txt", DateTime.Today.ToString() + "\r\nDigital Archive: " + txtCatName.Text + "\r\nDo not delete the catalogue file " + myGuid + ".dacat ");
                        //full path for catalogue
                        CatUUID = txtFilePath.Text + "\\DACAT\\" + myGuid + ".dacat";
                        //create cataloge and connection
                        using (SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + CatUUID + "; Version = 3; Compress = True;"))
                        {

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
                                "logCatVersion VARCHAR(16)   NOT NULL " +
                                "); ";
                            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
                            {
                                command.ExecuteNonQuery();

                            }
                            //Insert startup information into tables
                            sql = "INSERT INTO tblCatalogue VALUES (@catName, " +
                                "@catUUID, @catCreated, @catDesc, @catVer, @catAmended);";
                            //these are the types of Metadata we want to store (keywords can be added)
                            sql += "INSERT INTO tbllkpMetaFormat (metaTitle)" +
                                "VALUES ('TYPE OF FILE'), ('NAME'), ('SIZE'), ('CREATED'), ('MODIFIED'), ('READ ONLY'), ('LOCATION'), " +
                                "('READ-ONLY'), ('HIDDEN'), ('DATE TAKEN'), ('KEYWORDS');";
                            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
                            {
                                command.Parameters.Add(new SQLiteParameter("@catName", txtCatName.Text));
                                command.Parameters.Add(new SQLiteParameter("@catUUID", CatUUID));
                                command.Parameters.Add(new SQLiteParameter("@catCreated", DateTime.Now));
                                command.Parameters.Add(new SQLiteParameter("@catDesc", txtCatDesc.Text));
                                command.Parameters.Add(new SQLiteParameter("@catVer", "1.0"));
                                command.Parameters.Add(new SQLiteParameter("@catAmended", DateTime.Now));

                                command.ExecuteNonQuery();
                            }
                            dbConn.Close();
                        }
                        // add data to digarch.dacat to update with latest catalogue
                        Catalogue curCat = new Catalogue(CatUUID);

                        // update info on screen
                        lblGuid.Text = "Catalogue " + curCat.catUUID + " has been created";

                        //MainForm.LabelCurrentCat = "Current Catalogue: " + Globals.curCatName;

                        //close form
                        this.Close();
                    }
                    else
                    {
                        lblGuid.Text = "You must choose a location for the catalogue \r\nand enter a name between 5 and 120 characters \r\nand description between 10 and 255 characters";
                    }

                }

            }
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            txtFilePath.Text = GetCatalogueLoc();

        }

        private string GetCatalogueLoc()
        {
            txtFilePath.Text = "click here to select location";
            string filePath = "";
            using (FolderBrowserDialog getFilePath = new FolderBrowserDialog())
            {
                DialogResult result = getFilePath.ShowDialog();
                getFilePath.Description = "Select location of the new catalogue";
                getFilePath.RootFolder = Environment.SpecialFolder.MyDocuments;

                if (result == DialogResult.OK)
                {
                    filePath = getFilePath.SelectedPath;
                }

            }

            return filePath;

        }

        private void lblFilePath_Click(object sender, EventArgs e)
        {

            /*
            using (OpenFileDialog openFilePath = new OpenFileDialog())
            {
                openFilePath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFilePath.Filter = "dacat files (*.dacat)|*.dacat|All files (*.*)|*.*";
                openFilePath.FilterIndex = 2;
                openFilePath.RestoreDirectory = true;
                openFilePath.Title = "Select location of the new catalogue";
               

                if (openFilePath.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFilePath.FileName;
                }

            }
            */
            txtFilePath.Text = GetCatalogueLoc();

        }

        private void btnGetFolder_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = GetCatalogueLoc();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilePath_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

