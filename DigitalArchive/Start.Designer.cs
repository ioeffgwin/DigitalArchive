
namespace DigitalArchive
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.txtUsersName = new System.Windows.Forms.TextBox();
            this.lblUsersName = new System.Windows.Forms.Label();
            this.btnUsersName = new System.Windows.Forms.Button();
            this.lblGuid = new System.Windows.Forms.Label();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripCurCat = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsersName
            // 
            this.txtUsersName.Location = new System.Drawing.Point(758, 468);
            this.txtUsersName.Name = "txtUsersName";
            this.txtUsersName.Size = new System.Drawing.Size(323, 26);
            this.txtUsersName.TabIndex = 8;
            // 
            // lblUsersName
            // 
            this.lblUsersName.AutoSize = true;
            this.lblUsersName.Location = new System.Drawing.Point(622, 471);
            this.lblUsersName.Name = "lblUsersName";
            this.lblUsersName.Size = new System.Drawing.Size(130, 20);
            this.lblUsersName.TabIndex = 9;
            this.lblUsersName.Text = "Add Users Name";
            // 
            // btnUsersName
            // 
            this.btnUsersName.Location = new System.Drawing.Point(1087, 468);
            this.btnUsersName.Name = "btnUsersName";
            this.btnUsersName.Size = new System.Drawing.Size(75, 26);
            this.btnUsersName.TabIndex = 10;
            this.btnUsersName.Text = "User Name";
            this.btnUsersName.UseVisualStyleBackColor = true;
            this.btnUsersName.Click += new System.EventHandler(this.btnUsersName_Click);
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(600, 336);
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
            this.toolStripMenuItem1,
            this.editToolStripMenuItem});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(1200, 33);
            this.mnuStrip.TabIndex = 14;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCatalogueToolStripMenuItem,
            this.openCatalogueToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(108, 29);
            this.toolStripMenuItem1.Text = "Catalogue";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // addCatalogueToolStripMenuItem
            // 
            this.addCatalogueToolStripMenuItem.Name = "addCatalogueToolStripMenuItem";
            this.addCatalogueToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.addCatalogueToolStripMenuItem.Text = "New Catalogue";
            this.addCatalogueToolStripMenuItem.Click += new System.EventHandler(this.addCatalogueToolStripMenuItem_Click);
            // 
            // openCatalogueToolStripMenuItem
            // 
            this.openCatalogueToolStripMenuItem.Name = "openCatalogueToolStripMenuItem";
            this.openCatalogueToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openCatalogueToolStripMenuItem.Text = "Open Catalogue";
            this.openCatalogueToolStripMenuItem.Click += new System.EventHandler(this.openCatalogueToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUserName,
            this.toolStripCurCat});
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblGuid);
            this.Controls.Add(this.btnUsersName);
            this.Controls.Add(this.lblUsersName);
            this.Controls.Add(this.txtUsersName);
            this.Controls.Add(this.mnuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Digital Archive";
            this.Load += new System.EventHandler(this.Main_Load);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCurCat;
    }
}

