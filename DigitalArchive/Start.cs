﻿using System;
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

        /*
         * J Vincent
         * Main Form - most (all?) functions originate here
         * 
         * 
         * 
         * 
         */

        //used to help validation in new catalogue subform
        //once they are all true, the catalogue can be created
        Boolean bNewCatNameOK = false;
        Boolean bNewCatDescOK = false;
        Boolean bNewCatPathOK = false;



        public MainForm()
        {
            InitializeComponent();

            toolStripMessage.Text = "";
            toolStripCurCat.Text = "No Catalogue opened";
            this.Text = "Digital Archive";
            //add in code to read data from digarch.dacat
            string curCatID;
            // if no data not used before some data required
            if (Globals.OpenArgs.Length != 0)
            {
                // is there a catalogue in the command line to open app
                curCatID = Globals.OpenArgs[0];
            }
            else
            {   // get the latest used catalogue from digarch.dacat
                curCatID = GetLatestCatalogue();
            }


            if (curCatID != null)
            {
                Catalogue curCat = new Catalogue(curCatID);
                toolStripCurCat.Text = "Current Catalogue: " + Globals.curCatName;
                this.Text = "Digital Archive " + Globals.curCatName;
                if (Globals.curCatDesc != null)
                {
                    PopulateTreeView();
                }

            }

            //get most 5 recent catalogues
            GetRecentCatalogues();


        }

        protected void GetRecentCatalogues()
        {
            /*
             * J Vincent
             * Add upto 5 most recent unique catalogues to drop down menu
             * 
             */

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
                        string curID = sqlRead.GetString(sqlRead.GetOrdinal("catUUID"));
                        subItem[i].Click += delegate { CatPrevMenuItemClick(curID); };
                        recCur.DropDownItems.Add(subItem[i]); // this adds the items to the drop down menu
                        i++;
                    }

                }
                conn.Close();
            }

        }

        protected void CatPrevMenuItemClick(string catID)
        {
            //load previous selected previous catalogue - but only if its available
            Catalogue curCat = new Catalogue(catID);
            if (curCat.catName == null)
            {
                toolStripCurCat.Text = "Catalogue not found";
                this.Text = "Digital Archive";
            }
            else
            {
                toolStripCurCat.Text = "Current Catalogue: " + curCat.catName;
                this.Text = "Digital Archive " + Globals.curCatName;

            }
            PopulateTreeView();

        }



        static void InsertData(SQLiteConnection conn, string SQLstr)
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
                            if (!sqlRead.IsDBNull(0)) catName = sqlRead.GetString(sqlRead.GetOrdinal("LastCatalogue"));
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return catName;

        }


        static SQLiteConnection LoadLatestCatalogue()
        {   // not needed

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
            //link app to an existing catalogue chosen by the user
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
                            //populate globals with catalogue details
                            Catalogue testCat = new Catalogue(filePath);
                            //update list of recent catalogues
                            GetRecentCatalogues();

                        }
                        catch (Exception ex)
                        {
                            DialogResult dlgResult = MessageBox.Show(ex.Message + filePath, "Load Catalogue not found",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        finally
                        {
                            toolStripCurCat.Text = "Current Catalogue: " + Globals.curCatName;
                            this.Text = "Digital Archive " + Globals.curCatName;
                        }

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
             * J Vincent
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
                treeViewCat.ExpandAll();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void treeViewCat_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            /*
             * J Vincent
             * This populates the tree view with the files in the folder
             * 
             * it needs to be compared with the details of files stored in the catalogue
             * and highlight any discrepenacies
             * and hide the DACAT folder
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
                        //if its the DACAT folder ignore
                        if (di.Name != "DACAT")
                        {

                            try
                            {
                                //keep the directory's full path in the tag for use later
                                node.Tag = dir;

                                //if the directory has sub directories add the place holder
                                if (di.GetDirectories().Count() > 0)
                                    node.Nodes.Add(null, "...", 0, 0);

                                foreach (var file in di.GetFiles())
                                {
                                    //check if file is already in db
                                    string fileDets = file.DirectoryName;
                                    int checkRes = CheckSum.CheckCheckSum(fileDets, file.Name);
                                    TreeNode n;
                                    switch (checkRes)
                                    {
                                        case 0: //not in db
                                            n = new TreeNode(file.Name, 4, 4);
                                            break;
                                        case 1: //in db, checksum wrong
                                            n = new TreeNode(file.Name, 5, 5);
                                            break;
                                        case 2: //in db, all ok
                                            n = new TreeNode(file.Name, 6, 6);
                                            break;
                                        default:
                                            n = new TreeNode(file.Name, 4, 4);
                                            break;

                                    }
                                    n.Tag = CheckSum.itemID;
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
                    }
                    //add files of rootdirectory
                    DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
                    foreach (var file in rootDir.GetFiles())
                    {
                        //check if file is already in db
                        string fileDets = file.DirectoryName;
                        int checkRes = CheckSum.CheckCheckSum(fileDets, file.Name);
                        TreeNode n;
                        switch (checkRes)
                        {
                            case 0: //not in db
                                n = new TreeNode(file.Name, 4, 4);
                                break;
                            case 1: //in db, checksum wrong
                                n = new TreeNode(file.Name, 5, 5);
                                break;
                            case 2: //in db, all ok
                                n = new TreeNode(file.Name, 6, 6);
                                break;
                            default:
                                n = new TreeNode(file.Name, 4, 4);
                                break;

                        }
                        n.Tag = CheckSum.itemID;
                        e.Node.Nodes.Add(n);

                    }

                    //add missing files to treeview - these are files in the database that aren't in the folder
                    List<int> missing = Catalogue.MissingItems();
                    foreach (int missingFile in missing)
                    {
                        string[] filenames = Catalogue.GetFileName(missingFile);
                        TreeNode n;
                        n = new TreeNode(filenames[0], 7, 7);
                        n.Tag = missingFile;
                        e.Node.Nodes.Add(n);
                    }
                    treeViewCat.ExpandAll();

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
            //show user name in bottom bar
            toolStripUserName.Text = "User: " + Globals.usersName;
        }

        private void btnUsersName_Click(object sender, EventArgs e)
        {
            /*
             * J Vincent
             * Change  username used on App
             */

            try
            {
                this.toolStripMessage.Text = "User Name must be between 3 and 15 characters";

                // this needs a bit more validation etc
                if (txtUsersName.Text.Length > 2 && txtUsersName.Text.Length < 16)
                {
                    Globals.SetUserName(txtUsersName.Text);
                    toolStripUserName.Text = "User: " + Globals.usersName;
                    this.toolStripMessage.Text = "User Name updated";
                }
                else
                {
                    this.toolStripMessage.Text = "User Name must be between 3 and 15 characters";
                }
                //hide the sub form
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


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void addCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // makes new catalogue subform visible when option slected in drop down
            pnlNewCat.Visible = true;
            lblLotsOfInfo.Visible = false;
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


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this will give the user the opportunity to edit the catalogue name and description

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
            //make the username subform visible
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
            //hide the username subform without making any changes
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
            nodeDets = "Selected: (" + treeViewCat.SelectedNode.Tag + ") " + treeViewCat.SelectedNode.Text;
            toolStripMessage.Text = nodeDets;
            // need to do somthing with this
        }

        private string GetCatalogueLoc()
        {
            //Used in new catalogue subform open dialog to get location of new catalogue
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
            // new catalogue subform open dialog to get location of new catalogue
            txtFilePath.Text = GetCatalogueLoc();
        }

        private void lblFilePath_Click(object sender, EventArgs e)
        {
            // new catalogue subform open dialog to get location of new catalogue
            txtFilePath.Text = GetCatalogueLoc();
        }

        private void btnGetGuid_Click(object sender, EventArgs e)
        {
            //create new cataloge then make new catalogue subform invisible and update information on show
            string msg;
            NewCatalogue nc = new NewCatalogue(txtFilePath.Text, txtCatName.Text, txtCatDesc.Text);
            msg = nc.retMessage;
            txtFilePath.Text = null;
            txtCatName.Text = null;
            txtCatDesc.Text = null;
            pnlNewCat.Visible = false;
            lblLotsOfInfo.Visible = true;
            toolStripMessage.Text = msg;
            PopulateTreeView();
            //update the recent files menu
            GetRecentCatalogues();
            //show current catalogue
            LabelCurrentCat = Globals.curCatName;
        }

        private void txtFilePath_Click(object sender, EventArgs e)
        {
            // new catalogue subform open dialog to get location of new catalogue
            txtFilePath.Text = GetCatalogueLoc();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //cancel new catalogue subform without making any changes.
            txtFilePath.Text = null;
            txtCatName.Text = null;
            txtCatDesc.Text = null;
            pnlNewCat.Visible = false;
            lblLotsOfInfo.Visible = true;
            toolStripMessage.Text = null;

        }

        private void txtCatName_Validating(object sender, CancelEventArgs e)
        {
            // validate for new catalogue subform
            if (txtCatName.Text.Length < 5 || txtCatName.Text.Length > 120)
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
            // validate for new catalogue subform
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
            // validate for new catalogue subform
            if (txtFilePath.Text.Length > 4)
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
            // validate for change user name subform
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

        private void btnGetGuid_Enable()
        {
            //once all new catalogue fields are validated, create button is enabled
            if (bNewCatPathOK == true && bNewCatNameOK == true && bNewCatDescOK == true)
            {
                btnGetGuid.Enabled = true;
            }
            else
            {
                btnGetGuid.Enabled = false;
            }
        }


        private void btnScanChanges_Click(object sender, EventArgs e)
        {
            //scan for any changes between actual files and info stored in catalogue
            PopulateTreeView();


        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // import data into catalogue
            // all files must be within this file structure (they can be copied in)
            // user needs to create a new catalogue for other areas

            //iterate throiugh each file in the tree view
            foreach (TreeNode nodeTop in treeViewCat.Nodes)
            {
                //test to see if node.text is a valid directory
                //options for all files in current structure (except DACAT folder!)
                if (nodeTop.Text != "DACAT")
                {
                    CaptureFileInfo(nodeTop);

                }
            }
            //have any updates occurred

            if (filesUpdated > 0)
            {
                toolStripMessage.Text = filesUpdated + " files imported";
                filesUpdated = 0;
                PopulateTreeView();

            }
            else
            {
                toolStripMessage.Text = "There were no new files to import";
            }

        }

        static int filesUpdated = 0;
        private void CaptureFileInfo(TreeNode nodeTop)
        {

            ReadFileInfo fileInfo = new ReadFileInfo();


            foreach (TreeNode nodeSub in nodeTop.Nodes)
            {

                fileInfo.GetFileInfo(nodeSub.FullPath);
                int alreadyHere = CheckSum.CheckCheckSum(fileInfo.fileLocation, fileInfo.fileName);
                if ((fileInfo.fileSystem == false && fileInfo.fileDir == false && alreadyHere == 0))
                {
                    if (fileInfo.fileName != null)
                    {
                        CatalogueItemMetaUpdate intoCat = new CatalogueItemMetaUpdate();
                        //add file information to tbl Items
                        intoCat.AddItem(fileInfo.fileName, fileInfo.fileLocation, fileInfo.fileHash, fileInfo.fileOwner);
                        //get ItemID
                        int myItemID = intoCat.itemID;
                        //add meta data to tblMetaItems for each metaTitle if available
                        if (fileInfo.fileMetaType != null) intoCat.AddMetaItem(myItemID, true, "TYPE OF FILE", "string", fileInfo.fileMetaType);
                        if (fileInfo.fileName != null) intoCat.AddMetaItem(myItemID, true, "NAME", "string", fileInfo.fileName);
                        if (fileInfo.fileMetaSize != null) intoCat.AddMetaItem(myItemID, true, "SIZE", "INT", fileInfo.fileMetaSize);
                        if (fileInfo.fileMetaDateCreated != null) intoCat.AddMetaItem(myItemID, true, "CREATED", "DateTime", fileInfo.fileMetaDateCreated);
                        if (fileInfo.fileMetaDateModified != null) intoCat.AddMetaItem(myItemID, true, "MODIFIED", "DateTime", fileInfo.fileMetaDateModified);
                        if (fileInfo.fileMetaReadOnly != null) intoCat.AddMetaItem(myItemID, true, "READ ONLY", "Boolean", fileInfo.fileMetaReadOnly);
                        if (fileInfo.fileLocation != null) intoCat.AddMetaItem(myItemID, true, "LOCATION", "string", fileInfo.fileLocation);
                        if (fileInfo.fileMetaHidden != null) intoCat.AddMetaItem(myItemID, true, "HIDDEN", "Boolean", fileInfo.fileMetaHidden);
                        if (fileInfo.fileMetaDateTaken != null) intoCat.AddMetaItem(myItemID, true, "DATE TAKEN", "DateTime", fileInfo.fileMetaDateTaken);
                        if (fileInfo.fileMetaKeyword != null) intoCat.AddMetaItem(myItemID, true, "KEYWORDS", "string", fileInfo.fileMetaKeyword);
                        //update catalogue latest version
                        intoCat.SetCatalogueVer();
                        //update change log
                        ChangeLog.Main("New File Added: " + fileInfo.fileName, myItemID);
                        filesUpdated++;

                    }

                }
                //recursively call this method again until entire tree covered
                CaptureFileInfo(nodeSub);

            }

            //or selected files in current structure
            //later

        }

        private void treeViewCat_Leave(object sender, EventArgs e)
        {
            lblLotsOfInfo.Visible = false;
        }

        private void scanForChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateTreeView();
        }
    }
}

