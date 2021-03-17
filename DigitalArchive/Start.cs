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
                PopulateTreeView();

            }

            //get most 5 recent catalogues
            string sql = "SELECT catName, catUUID, catDateOpened FROM tblCatsOpened GROUP BY catUUID ORDER BY catDateOpened DESC LIMIT 5";
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
            PopulateTreeView();

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

        public void PopulateTreeView()
        {
            /*
             * 
             * 
             * 
             */

            treeViewCat.ImageList = mainImageList; // this needs to be populated with appropriate images

            try
            {
                //clear treeview first
                treeViewCat.Nodes.Clear();

                //get new path from selection of catalogue
                string catPath;
                //catPath = "D:\\Public\\Photos\\Cosmeston"; // this value will need to be set from catalogue path
                catPath = Globals.curCatPath;
                if (catPath == null) catPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                List<string> list = new List<string>();

                list.Add(catPath);
                string[] items = list.ToArray();

                foreach (string item in items)
                {
                    DriveInfo di = new DriveInfo(item);
                    int itemImage;

                    switch (di.DriveType)    //set the drive's icon
                    {
                        case DriveType.CDRom:
                            itemImage = 3;
                            break;
                        case DriveType.Network:
                            itemImage = 6;
                            break;
                        case DriveType.NoRootDirectory:
                            itemImage = 8;
                            break;
                        case DriveType.Fixed:
                            itemImage = 0;
                            break;
                        default:
                            itemImage = 2;
                            break;
                    }

                    //TreeNode node = new TreeNode(drive.Substring(0, 1), itemImage, itemImage);
                    TreeNode node = new TreeNode(item.ToString(), itemImage, itemImage);
                    node.Tag = item;

                    if (di.IsReady == true)
                        node.Nodes.Add("...");

                    treeViewCat.Nodes.Add(node);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void treeViewCat_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            /*
             * 
             * 
             * 
             * 
             * 
             */

            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 1, 2);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);

                            foreach (var file in di.GetFiles())
                            {
                                TreeNode n = new TreeNode(file.Name, 4, 4);
                                node.Nodes.Add(n);
                            }

                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 3;
                            node.SelectedImageIndex = 3;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                    //add files of rootdirectory
                    DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
                    foreach (var file in rootDir.GetFiles())
                    {
                        TreeNode n = new TreeNode(file.Name, 4, 4);
                        e.Node.Nodes.Add(n);
                    }

                }
            }
        }

        List<TreeNode> getFolderNodes(string dir, bool expanded)
        {
            /*
             * 
             * https://stackoverflow.com/questions/34464800/c-sharp-how-to-use-treeview-to-list-the-directories-and-subdirectories-without-s
             * 16/3/21
             * 
             */

            var dirs = Directory.GetDirectories(dir).ToArray();
            var nodes = new List<TreeNode>();
            
            foreach (string d in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                TreeNode tn = new TreeNode(di.Name);
                tn.Tag = di;
                int subCount = 0;
                try { subCount = Directory.GetDirectories(d).Count(); }
                catch { /* ignore accessdenied */  }
                if (subCount > 0) tn.Nodes.Add("...");
                if (expanded) tn.Expand();   //  **
                nodes.Add(tn);
            }
            return nodes;
        }

        List<TreeNode> getAllFolderNodes(string dir)
        {
            /*
             * 
             * https://stackoverflow.com/questions/34464800/c-sharp-how-to-use-treeview-to-list-the-directories-and-subdirectories-without-s
             * 16/3/21
             * 
             */

            var dirs = Directory.GetDirectories(dir).ToArray();
            var nodes = new List<TreeNode>();
            foreach (string d in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                TreeNode tn = new TreeNode(di.Name);
                tn.Tag = di;
                int subCount = 0;
                try { subCount = Directory.GetDirectories(d).Count(); }
                catch { /* ignore accessdenied */  }
                if (subCount > 0)
                {
                    var subNodes = getAllFolderNodes(di.FullName);
                    tn.Nodes.AddRange(subNodes.ToArray());
                }
                nodes.Add(tn);
            }
            return nodes;
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
            PopulateTreeView();

        }

        private void btnNewCat_Click(object sender, EventArgs e)
        {
            new NewCat().ShowDialog();

            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void addCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new NewCat().ShowDialog();
            pnlNewCat.Visible = true;
        }

        private void openCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCatalogue();
            PopulateTreeView();

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

        private void treeViewCat_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeDets;
            nodeDets = treeViewCat.SelectedNode.Text;

            // need to do somthing with this


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


        private void btnGetFolder_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = GetCatalogueLoc();
        }

        private void lblFilePath_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = GetCatalogueLoc();
        }

        private void btnGetGuid_Click(object sender, EventArgs e)
        {
            string msg;
            NewCatalogue nc = new NewCatalogue(txtFilePath.Text, txtCatName.Text, txtCatDesc.Text);
            msg = nc.retMessage;
            txtFilePath.Text = null;
            txtCatName.Text = null;
            txtCatDesc.Text = null;
            pnlNewCat.Visible = false;
            toolStripMessage.Text = msg;
            PopulateTreeView();
            //update the recent files menu

            LabelCurrentCat = Globals.curCatName;
        }

        private void txtFilePath_Click(object sender, EventArgs e)
        {
            txtFilePath.Text = GetCatalogueLoc();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtFilePath.Text = null;
            txtCatName.Text = null;
            txtCatDesc.Text = null;
            pnlNewCat.Visible = false;
            toolStripMessage.Text = null;

        }

        private void txtCatName_Validating(object sender, CancelEventArgs e)
        {
            if(txtCatName.Text.Length < 5 || txtCatName.Text.Length > 120)
            {
                epName.SetError(txtCatName, "Name must be between 5 and 120 characters");
                bNewCatNameOK = false;

            }
            else
            {
                epName.SetError(txtCatName, String.Empty);
                bNewCatNameOK = true;
            }
            btnGetGuid_Enable();
        }

        private void txtCatDesc_Validating(object sender, CancelEventArgs e)
        {
            if (txtCatDesc.Text.Length < 10 || txtCatDesc.Text.Length > 255)
            {
                epName.SetError(txtCatDesc, "Name must be between 10 and 255 characters");
                bNewCatDescOK = false;

            }
            else
            {
                epName.SetError(txtCatDesc, String.Empty);
                bNewCatDescOK = true;
            }
            btnGetGuid_Enable();

        }

        private void txtFilePath_Validating(object sender, CancelEventArgs e)
        {
            if(txtFilePath.Text.Length > 4)
            {

                DirectoryInfo di = new DirectoryInfo(txtFilePath.Text);
                if (di.Exists)
                {
                    epName.SetError(txtFilePath, String.Empty);
                    bNewCatPathOK = true;
                }
                else
                {
                    epName.SetError(txtFilePath, "File Path doesn't exist");
                    bNewCatPathOK = false;

                }
            }
            btnGetGuid_Enable();

        }

        private void txtUsersName_Validating(object sender, CancelEventArgs e)
        {
            {
                if (txtUsersName.Text.Length < 3 || txtUsersName.Text.Length > 15)
                {
                    epName.SetError(txtUsersName, "Name must be between 10 and 255 characters");
                }
                else
                {
                    epName.SetError(txtUsersName, String.Empty);
                }

            }

        }

        Boolean bNewCatNameOK = false;
        Boolean bNewCatDescOK = false;
        Boolean bNewCatPathOK = false;

        

        private void btnGetGuid_Enable()
        {
            if(bNewCatPathOK==true && bNewCatNameOK==true && bNewCatDescOK == true)
            {
                btnGetGuid.Enabled = true;
            }
            else
            {
                btnGetGuid.Enabled = false;
            }
        }

        private void txtCatDesc_Validated(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            ReadFileInfo fileInfo = new ReadFileInfo();
            fileInfo.GetFileInfo("");
        }
    }
}

