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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            toolStripMessage.Text = "";
            toolStripCurCat.Text = "No Catalogue opened";
            //add in code to read data from digarch.dacat
            string curCatID;
            // if no data not used before some data required
            if (Globals.OpenArgs.Length != 0)
            {
                curCatID = Globals.OpenArgs[0];
            }
            else
            {
                curCatID = GetLatestCatalogue();
            }


            if (curCatID!=null)
            {
                Catalogue curCat = new Catalogue(curCatID);
                toolStripCurCat.Text = "Current Catalogue: " + Globals.curCatName;
            }

            //get most 5 recent catalogues
            string sql = "SELECT catName, catUUID, catDateOpened FROM tblCatsOpened ORDER BY catDateOpened DESC LIMIT 5";
            using (SQLiteConnection conn = new SQLiteConnection(Globals.connApp))
            {
                conn.Open();
                using (SQLiteCommand sql_cmd = new SQLiteCommand(sql, conn))
                {

                    //var mnu = mnuStrip.Items[0];
                    MenuItem addDevice = new MenuItem("Previous Catalogues");
                    ToolStripMenuItem recCur = openRecentToolStripMenuItem;
                    SQLiteDataReader sqlRead;
                    sqlRead = sql_cmd.ExecuteReader();
                    int i = 0;
                    ToolStripMenuItem[] subItem = new ToolStripMenuItem[5];
                    while (sqlRead.Read())
                    {
                        subItem[i] = new ToolStripMenuItem();
                        subItem[i].Name = "mnuPrevCat" + i.ToString();
                        subItem[i].Tag = sqlRead.GetString(sqlRead.GetOrdinal("catName"));

                        subItem[i].Text = sqlRead.GetString(sqlRead.GetOrdinal("catName")) + " | " + sqlRead.GetString(sqlRead.GetOrdinal("catDateOpened"));
                        //subItem[i].Text = sqlRead.GetString(sqlRead.GetOrdinal("catUUID"));
                        string curID = sqlRead.GetString(sqlRead.GetOrdinal("catUUID"));
                        subItem[i].Click += delegate { CatPrevMenuItemClick(curID); };
                       //subItem[i].Click += new EventHandler(CatPrevMenuItemClick(sqlRead.GetString(sqlRead.GetOrdinal("catUUID"))));
                            
                        recCur.DropDownItems.Add(subItem[i]); // this adds the stuff
                        i++;
                     
                        //if (!sqlRead.IsDBNull(0)) catName = sqlRead.GetString(sqlRead.GetOrdinal("catName"));
                    }
                    
                }
                conn.Close();
            }



        }

        protected void CatPrevMenuItemClick(string catID)
        {
            Catalogue curCat = new Catalogue(catID);
            if(curCat.catName == null)
            {
                toolStripCurCat.Text = "Catalogue not found";
            }
            else
            {
                toolStripCurCat.Text = "Current Catalogue: " + curCat.catName;

            }

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
                            if(!sqlRead.IsDBNull(0)) catName = sqlRead.GetString(sqlRead.GetOrdinal("LastCatalogue"));
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
                    catFile.FilterIndex = 1;
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
                            toolStripCurCat.Text = "Current Catalogue: " + Globals.curCatName;
                        }

                        // if it is then store path and name locally

                        // add data to digarch.dacat to update with latest catalogue


                    }

                }



            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public string LabelCurrentCat
        {
            get
            {
                return this.toolStripCurCat.Text;
            }
            set
            {
                this.toolStripCurCat.Text = value;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            toolStripUserName.Text = "User: " + Globals.usersName;
        }

        private void btnUsersName_Click(object sender, EventArgs e)
        {
            try
            {
                this.toolStripMessage.Text = "User Name must be between 3 and 15 characters";

                // this needs a bit more validatyion etc
                if (txtUsersName.Text.Length > 2 && txtUsersName.Text.Length <16)
                {


                    Globals.SetUserName(txtUsersName.Text);
                    toolStripUserName.Text = "User: " + Globals.usersName;
                    // update app tables
                    SQLiteConnection sys_Conn = new SQLiteConnection(Globals.connApp + " New = True; Compress = True; ");
                    sys_Conn.Open();

                    // update tblAppSystemb(no where clause as only one line should be in use)
                    string sql = "UPDATE tblAppSystem SET username = '" + txtUsersName.Text + "';";
                    SQLiteCommand command = new SQLiteCommand(sql, sys_Conn);
                    command.ExecuteNonQuery();
                    sys_Conn.Close();
                    this.toolStripMessage.Text = "User Name updated";

                }
                else
                {
                    this.toolStripMessage.Text = "User Name must be between 3 and 15 characters";
                }

                this.lblUsersName.Visible = false;
                this.txtUsersName.Visible = false;
                this.btnUsersName.Visible = false;
                this.btnCancelUsersName.Visible = false;
            }
            catch (Exception ex)
            {
                this.lblUsersName.Visible = false;
                this.txtUsersName.Visible = false;
                this.btnUsersName.Visible = false;
                this.btnCancelUsersName.Visible = false;


                throw ex;
            }

        }

        private void btnConnectCat_Click(object sender, EventArgs e)
        {
            //change to a different catalogue
            GetCatalogue();
        }

        private void btnNewCat_Click(object sender, EventArgs e)
        {
            new NewCat().Show();

            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void addCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewCat().Show();
         
        }

        private void openCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCatalogue();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    ReadFileInfo.ReadFiles();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void openRecentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblUsersName_Click(object sender, EventArgs e)
        {

        }

        private void editUserNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtUsersName.Text = Globals.usersName;
            this.lblUsersName.Visible = true;
            this.txtUsersName.Visible = true;
            this.btnUsersName.Visible = true;
            this.btnCancelUsersName.Visible = true;
            this.txtUsersName.Focus();
            this.toolStripMessage.Text = "User Name must be between 3 and 15 characters";

        }

        private void btnCancelUsersName_Click(object sender, EventArgs e)
        {
            this.txtUsersName.Text = null;
            this.lblUsersName.Visible = false;
            this.txtUsersName.Visible = false;
            this.btnUsersName.Visible = false;
            this.btnCancelUsersName.Visible = false;
            this.toolStripMessage.Text = "";

        }
    }
}

