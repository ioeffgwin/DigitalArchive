
namespace DigitalArchive
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button btnGetFolder;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtUsersName = new System.Windows.Forms.TextBox();
            this.lblUsersName = new System.Windows.Forms.Label();
            this.btnUsersName = new System.Windows.Forms.Button();
            this.lblGuid = new System.Windows.Forms.Label();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanForChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanForDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripCurCat = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancelUsersName = new System.Windows.Forms.Button();
            this.treeViewCat = new System.Windows.Forms.TreeView();
            this.mainImageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlNewCat = new System.Windows.Forms.Panel();
            this.lblNewCat = new System.Windows.Forms.Label();
            this.btnCancelNew = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblCatDesc = new System.Windows.Forms.Label();
            this.lblCatName = new System.Windows.Forms.Label();
            this.txtCatDesc = new System.Windows.Forms.TextBox();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.btnGetGuid = new System.Windows.Forms.Button();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnScanChanges = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblLotsOfInfo = new System.Windows.Forms.Label();
            this.pnlKeywords = new System.Windows.Forms.Panel();
            this.btnKeywordsCancels = new System.Windows.Forms.Button();
            this.btnKeywords = new System.Windows.Forms.Button();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.lblKeywords = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.picViewer = new System.Windows.Forms.PictureBox();
            this.pnlPicView = new System.Windows.Forms.Panel();
            this.toolStripVersion = new System.Windows.Forms.ToolStripStatusLabel();
            btnGetFolder = new System.Windows.Forms.Button();
            this.mnuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlNewCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            this.pnlKeywords.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewer)).BeginInit();
            this.pnlPicView.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetFolder
            // 
            btnGetFolder.Location = new System.Drawing.Point(639, 68);
            btnGetFolder.Name = "btnGetFolder";
            btnGetFolder.Size = new System.Drawing.Size(33, 32);
            btnGetFolder.TabIndex = 23;
            btnGetFolder.Text = "...";
            btnGetFolder.UseVisualStyleBackColor = true;
            btnGetFolder.Click += new System.EventHandler(this.btnGetFolder_Click);
            // 
            // txtUsersName
            // 
            this.txtUsersName.Location = new System.Drawing.Point(752, 5);
            this.txtUsersName.Name = "txtUsersName";
            this.txtUsersName.Size = new System.Drawing.Size(323, 26);
            this.txtUsersName.TabIndex = 8;
            this.txtUsersName.Visible = false;
            this.txtUsersName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsersName_Validating);
            // 
            // lblUsersName
            // 
            this.lblUsersName.AutoSize = true;
            this.lblUsersName.Location = new System.Drawing.Point(588, 8);
            this.lblUsersName.Name = "lblUsersName";
            this.lblUsersName.Size = new System.Drawing.Size(157, 20);
            this.lblUsersName.TabIndex = 9;
            this.lblUsersName.Text = "Change Users Name";
            this.lblUsersName.Visible = false;
            this.lblUsersName.Click += new System.EventHandler(this.lblUsersName_Click);
            // 
            // btnUsersName
            // 
            this.btnUsersName.Location = new System.Drawing.Point(1116, 1);
            this.btnUsersName.Name = "btnUsersName";
            this.btnUsersName.Size = new System.Drawing.Size(75, 30);
            this.btnUsersName.TabIndex = 10;
            this.btnUsersName.Text = "OK";
            this.btnUsersName.UseVisualStyleBackColor = true;
            this.btnUsersName.Visible = false;
            this.btnUsersName.Click += new System.EventHandler(this.btnUsersName_Click);
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(251, 230);
            this.lblGuid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(0, 20);
            this.lblGuid.TabIndex = 13;
            // 
            // mnuStrip
            // 
            this.mnuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.toolStripMenuItem1});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(1200, 33);
            this.mnuStrip.TabIndex = 14;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editUserNameToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(118, 29);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // editUserNameToolStripMenuItem
            // 
            this.editUserNameToolStripMenuItem.Name = "editUserNameToolStripMenuItem";
            this.editUserNameToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.editUserNameToolStripMenuItem.Text = "Edit User Name";
            this.editUserNameToolStripMenuItem.Click += new System.EventHandler(this.editUserNameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(236, 34);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCatalogueToolStripMenuItem,
            this.openCatalogueToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.editCatalogueToolStripMenuItem,
            this.importContentToolStripMenuItem,
            this.scanForChangesToolStripMenuItem,
            this.scanForDuplicatesToolStripMenuItem,
            this.keywordsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(108, 29);
            this.toolStripMenuItem1.Text = "Catalogue";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // addCatalogueToolStripMenuItem
            // 
            this.addCatalogueToolStripMenuItem.Name = "addCatalogueToolStripMenuItem";
            this.addCatalogueToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.addCatalogueToolStripMenuItem.Text = "New Catalogue";
            this.addCatalogueToolStripMenuItem.Click += new System.EventHandler(this.addCatalogueToolStripMenuItem_Click);
            // 
            // openCatalogueToolStripMenuItem
            // 
            this.openCatalogueToolStripMenuItem.Name = "openCatalogueToolStripMenuItem";
            this.openCatalogueToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.openCatalogueToolStripMenuItem.Text = "Open Catalogue";
            this.openCatalogueToolStripMenuItem.Click += new System.EventHandler(this.openCatalogueToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            this.openRecentToolStripMenuItem.Click += new System.EventHandler(this.openRecentToolStripMenuItem_Click);
            // 
            // editCatalogueToolStripMenuItem
            // 
            this.editCatalogueToolStripMenuItem.Name = "editCatalogueToolStripMenuItem";
            this.editCatalogueToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.editCatalogueToolStripMenuItem.Text = "Edit Catalogue";
            // 
            // importContentToolStripMenuItem
            // 
            this.importContentToolStripMenuItem.Name = "importContentToolStripMenuItem";
            this.importContentToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.importContentToolStripMenuItem.Text = "Import Content";
            this.importContentToolStripMenuItem.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // scanForChangesToolStripMenuItem
            // 
            this.scanForChangesToolStripMenuItem.Name = "scanForChangesToolStripMenuItem";
            this.scanForChangesToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.scanForChangesToolStripMenuItem.Text = "Scan for Changes";
            this.scanForChangesToolStripMenuItem.Click += new System.EventHandler(this.scanForChangesToolStripMenuItem_Click);
            // 
            // scanForDuplicatesToolStripMenuItem
            // 
            this.scanForDuplicatesToolStripMenuItem.Name = "scanForDuplicatesToolStripMenuItem";
            this.scanForDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.scanForDuplicatesToolStripMenuItem.Text = "Scan for Duplicates";
            // 
            // keywordsToolStripMenuItem
            // 
            this.keywordsToolStripMenuItem.Name = "keywordsToolStripMenuItem";
            this.keywordsToolStripMenuItem.Size = new System.Drawing.Size(266, 34);
            this.keywordsToolStripMenuItem.Text = "Keywords";
            this.keywordsToolStripMenuItem.Click += new System.EventHandler(this.keywordsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUserName,
            this.toolStripCurCat,
            this.toolStripMessage,
            this.toolStripVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 32);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripUserName
            // 
            this.toolStripUserName.Name = "toolStripUserName";
            this.toolStripUserName.Size = new System.Drawing.Size(179, 25);
            this.toolStripUserName.Text = "toolStripStatusLabel1";
            // 
            // toolStripCurCat
            // 
            this.toolStripCurCat.Name = "toolStripCurCat";
            this.toolStripCurCat.Size = new System.Drawing.Size(179, 25);
            this.toolStripCurCat.Text = "toolStripStatusLabel2";
            // 
            // toolStripMessage
            // 
            this.toolStripMessage.Name = "toolStripMessage";
            this.toolStripMessage.Size = new System.Drawing.Size(179, 25);
            this.toolStripMessage.Text = "toolStripStatusLabel3";
            // 
            // btnCancelUsersName
            // 
            this.btnCancelUsersName.BackColor = System.Drawing.SystemColors.Menu;
            this.btnCancelUsersName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancelUsersName.Font = new System.Drawing.Font("Aharoni", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancelUsersName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelUsersName.Location = new System.Drawing.Point(555, 1);
            this.btnCancelUsersName.Name = "btnCancelUsersName";
            this.btnCancelUsersName.Size = new System.Drawing.Size(31, 30);
            this.btnCancelUsersName.TabIndex = 16;
            this.btnCancelUsersName.Text = "X";
            this.btnCancelUsersName.UseVisualStyleBackColor = false;
            this.btnCancelUsersName.Visible = false;
            this.btnCancelUsersName.Click += new System.EventHandler(this.btnCancelUsersName_Click);
            // 
            // treeViewCat
            // 
            this.treeViewCat.Location = new System.Drawing.Point(5, 78);
            this.treeViewCat.Name = "treeViewCat";
            this.treeViewCat.Size = new System.Drawing.Size(330, 579);
            this.treeViewCat.TabIndex = 17;
            this.treeViewCat.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewCat_BeforeExpand);
            this.treeViewCat.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCat_AfterSelect);
            this.treeViewCat.DoubleClick += new System.EventHandler(this.treeViewCat_DoubleClick);
            this.treeViewCat.Leave += new System.EventHandler(this.treeViewCat_Leave);
            // 
            // mainImageList
            // 
            this.mainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList.ImageStream")));
            this.mainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mainImageList.Images.SetKeyName(0, "digarchive16.png");
            this.mainImageList.Images.SetKeyName(1, "FolderOpened_16x.png");
            this.mainImageList.Images.SetKeyName(2, "FolderClosed_16x.png");
            this.mainImageList.Images.SetKeyName(3, "Lock_16x.png");
            this.mainImageList.Images.SetKeyName(4, "Note_16x.png");
            this.mainImageList.Images.SetKeyName(5, "Note_R16x.png");
            this.mainImageList.Images.SetKeyName(6, "Note_G16x.png");
            this.mainImageList.Images.SetKeyName(7, "");
            // 
            // pnlNewCat
            // 
            this.pnlNewCat.Controls.Add(this.lblNewCat);
            this.pnlNewCat.Controls.Add(this.btnCancelNew);
            this.pnlNewCat.Controls.Add(btnGetFolder);
            this.pnlNewCat.Controls.Add(this.lblFilePath);
            this.pnlNewCat.Controls.Add(this.txtFilePath);
            this.pnlNewCat.Controls.Add(this.lblCatDesc);
            this.pnlNewCat.Controls.Add(this.lblCatName);
            this.pnlNewCat.Controls.Add(this.txtCatDesc);
            this.pnlNewCat.Controls.Add(this.txtCatName);
            this.pnlNewCat.Controls.Add(this.btnGetGuid);
            this.pnlNewCat.Controls.Add(this.lblGuid);
            this.pnlNewCat.Location = new System.Drawing.Point(349, 40);
            this.pnlNewCat.Name = "pnlNewCat";
            this.pnlNewCat.Size = new System.Drawing.Size(771, 453);
            this.pnlNewCat.TabIndex = 18;
            this.pnlNewCat.Visible = false;
            // 
            // lblNewCat
            // 
            this.lblNewCat.AutoSize = true;
            this.lblNewCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCat.Location = new System.Drawing.Point(8, 21);
            this.lblNewCat.Name = "lblNewCat";
            this.lblNewCat.Size = new System.Drawing.Size(247, 29);
            this.lblNewCat.TabIndex = 25;
            this.lblNewCat.Text = "Create new catalogue";
            // 
            // btnCancelNew
            // 
            this.btnCancelNew.Location = new System.Drawing.Point(367, 284);
            this.btnCancelNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelNew.Name = "btnCancelNew";
            this.btnCancelNew.Size = new System.Drawing.Size(201, 35);
            this.btnCancelNew.TabIndex = 24;
            this.btnCancelNew.Text = "cancel";
            this.btnCancelNew.UseVisualStyleBackColor = true;
            this.btnCancelNew.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(22, 74);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(119, 20);
            this.lblFilePath.TabIndex = 22;
            this.lblFilePath.Text = "Select Location";
            this.lblFilePath.Click += new System.EventHandler(this.lblFilePath_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(151, 71);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(483, 26);
            this.txtFilePath.TabIndex = 21;
            this.txtFilePath.Click += new System.EventHandler(this.txtFilePath_Click);
            this.txtFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilePath_Validating);
            // 
            // lblCatDesc
            // 
            this.lblCatDesc.AutoSize = true;
            this.lblCatDesc.Location = new System.Drawing.Point(52, 166);
            this.lblCatDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCatDesc.Name = "lblCatDesc";
            this.lblCatDesc.Size = new System.Drawing.Size(89, 20);
            this.lblCatDesc.TabIndex = 19;
            this.lblCatDesc.Text = "Description";
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.Location = new System.Drawing.Point(13, 121);
            this.lblCatName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(128, 20);
            this.lblCatName.TabIndex = 18;
            this.lblCatName.Text = "Catalogue Name";
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.Location = new System.Drawing.Point(151, 165);
            this.txtCatDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCatDesc.Multiline = true;
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(564, 90);
            this.txtCatDesc.TabIndex = 17;
            this.txtCatDesc.Validating += new System.ComponentModel.CancelEventHandler(this.txtCatDesc_Validating);
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(151, 118);
            this.txtCatName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(199, 26);
            this.txtCatName.TabIndex = 16;
            this.txtCatName.Validating += new System.ComponentModel.CancelEventHandler(this.txtCatName_Validating);
            // 
            // btnGetGuid
            // 
            this.btnGetGuid.Enabled = false;
            this.btnGetGuid.Location = new System.Drawing.Point(149, 284);
            this.btnGetGuid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetGuid.Name = "btnGetGuid";
            this.btnGetGuid.Size = new System.Drawing.Size(201, 35);
            this.btnGetGuid.TabIndex = 15;
            this.btnGetGuid.Text = "Creat New Catalogue";
            this.btnGetGuid.UseVisualStyleBackColor = true;
            this.btnGetGuid.Click += new System.EventHandler(this.btnGetGuid_Click);
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // btnScanChanges
            // 
            this.btnScanChanges.Location = new System.Drawing.Point(5, 36);
            this.btnScanChanges.Name = "btnScanChanges";
            this.btnScanChanges.Size = new System.Drawing.Size(168, 35);
            this.btnScanChanges.TabIndex = 19;
            this.btnScanChanges.Text = "Scan for Changes";
            this.btnScanChanges.UseVisualStyleBackColor = true;
            this.btnScanChanges.Click += new System.EventHandler(this.btnScanChanges_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(179, 36);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(146, 35);
            this.btnImport.TabIndex = 21;
            this.btnImport.Text = "Import New";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblLotsOfInfo
            // 
            this.lblLotsOfInfo.AutoSize = true;
            this.lblLotsOfInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotsOfInfo.Location = new System.Drawing.Point(349, 40);
            this.lblLotsOfInfo.Name = "lblLotsOfInfo";
            this.lblLotsOfInfo.Size = new System.Drawing.Size(462, 32);
            this.lblLotsOfInfo.TabIndex = 22;
            this.lblLotsOfInfo.Text = "File Info for Current File will go here";
            // 
            // pnlKeywords
            // 
            this.pnlKeywords.Controls.Add(this.btnKeywordsCancels);
            this.pnlKeywords.Controls.Add(this.btnKeywords);
            this.pnlKeywords.Controls.Add(this.txtKeywords);
            this.pnlKeywords.Controls.Add(this.lblKeywords);
            this.pnlKeywords.Location = new System.Drawing.Point(349, 505);
            this.pnlKeywords.Name = "pnlKeywords";
            this.pnlKeywords.Size = new System.Drawing.Size(771, 100);
            this.pnlKeywords.TabIndex = 23;
            this.pnlKeywords.Visible = false;
            // 
            // btnKeywordsCancels
            // 
            this.btnKeywordsCancels.Location = new System.Drawing.Point(367, 48);
            this.btnKeywordsCancels.Name = "btnKeywordsCancels";
            this.btnKeywordsCancels.Size = new System.Drawing.Size(201, 31);
            this.btnKeywordsCancels.TabIndex = 3;
            this.btnKeywordsCancels.Text = "cancel";
            this.btnKeywordsCancels.UseVisualStyleBackColor = true;
            this.btnKeywordsCancels.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKeywords
            // 
            this.btnKeywords.Location = new System.Drawing.Point(149, 48);
            this.btnKeywords.Name = "btnKeywords";
            this.btnKeywords.Size = new System.Drawing.Size(201, 31);
            this.btnKeywords.TabIndex = 2;
            this.btnKeywords.Text = "Add Keywords";
            this.btnKeywords.UseVisualStyleBackColor = true;
            this.btnKeywords.Click += new System.EventHandler(this.btnKeywords_Click);
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(151, 15);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(564, 26);
            this.txtKeywords.TabIndex = 1;
            // 
            // lblKeywords
            // 
            this.lblKeywords.AutoSize = true;
            this.lblKeywords.Location = new System.Drawing.Point(64, 15);
            this.lblKeywords.Name = "lblKeywords";
            this.lblKeywords.Size = new System.Drawing.Size(77, 20);
            this.lblKeywords.TabIndex = 0;
            this.lblKeywords.Text = "Keywords";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(428, 617);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(770, 40);
            this.pnlSearch.TabIndex = 24;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(562, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(201, 31);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(69, 7);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(119, 20);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "keyword search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(198, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(358, 26);
            this.txtSearch.TabIndex = 0;
            // 
            // picViewer
            // 
            this.picViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picViewer.Location = new System.Drawing.Point(0, 0);
            this.picViewer.Name = "picViewer";
            this.picViewer.Size = new System.Drawing.Size(828, 568);
            this.picViewer.TabIndex = 25;
            this.picViewer.TabStop = false;
            // 
            // pnlPicView
            // 
            this.pnlPicView.Controls.Add(this.picViewer);
            this.pnlPicView.Location = new System.Drawing.Point(349, 36);
            this.pnlPicView.Name = "pnlPicView";
            this.pnlPicView.Size = new System.Drawing.Size(828, 568);
            this.pnlPicView.TabIndex = 26;
            this.pnlPicView.Visible = false;
            // 
            // toolStripVersion
            // 
            this.toolStripVersion.Name = "toolStripVersion";
            this.toolStripVersion.Size = new System.Drawing.Size(179, 25);
            this.toolStripVersion.Text = "toolStripStatusLabel4";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.pnlPicView);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlKeywords);
            this.Controls.Add(this.lblLotsOfInfo);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnScanChanges);
            this.Controls.Add(this.pnlNewCat);
            this.Controls.Add(this.treeViewCat);
            this.Controls.Add(this.btnCancelUsersName);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnUsersName);
            this.Controls.Add(this.lblUsersName);
            this.Controls.Add(this.txtUsersName);
            this.Controls.Add(this.mnuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Digital Archive";
            this.Load += new System.EventHandler(this.Main_Load);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlNewCat.ResumeLayout(false);
            this.pnlNewCat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            this.pnlKeywords.ResumeLayout(false);
            this.pnlKeywords.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewer)).EndInit();
            this.pnlPicView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUsersName;
        private System.Windows.Forms.Label lblUsersName;
        private System.Windows.Forms.Button btnUsersName;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addCatalogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCatalogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCurCat;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editUserNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editCatalogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMessage;
        private System.Windows.Forms.Button btnCancelUsersName;
        private System.Windows.Forms.TreeView treeViewCat;
        private System.Windows.Forms.ImageList mainImageList;
        private System.Windows.Forms.Panel pnlNewCat;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblCatDesc;
        private System.Windows.Forms.Label lblCatName;
        private System.Windows.Forms.TextBox txtCatDesc;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.Button btnGetGuid;
        private System.Windows.Forms.Button btnCancelNew;
        private System.Windows.Forms.Label lblNewCat;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.Button btnScanChanges;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ToolStripMenuItem importContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanForChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanForDuplicatesToolStripMenuItem;
        private System.Windows.Forms.Label lblLotsOfInfo;
        private System.Windows.Forms.ToolStripMenuItem keywordsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlKeywords;
        private System.Windows.Forms.Label lblKeywords;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Button btnKeywordsCancels;
        private System.Windows.Forms.Button btnKeywords;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlPicView;
        private System.Windows.Forms.PictureBox picViewer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripVersion;
    }
}

