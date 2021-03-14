
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtUsersName = new System.Windows.Forms.TextBox();
            this.lblUsersName = new System.Windows.Forms.Label();
            this.btnUsersName = new System.Windows.Forms.Button();
            this.lblGuid = new System.Windows.Forms.Label();
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripCurCat = new System.Windows.Forms.ToolStripStatusLabel();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editCatalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancelUsersName = new System.Windows.Forms.Button();
            this.mnuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsersName
            // 
            this.txtUsersName.Location = new System.Drawing.Point(787, 5);
            this.txtUsersName.Name = "txtUsersName";
            this.txtUsersName.Size = new System.Drawing.Size(323, 26);
            this.txtUsersName.TabIndex = 8;
            this.txtUsersName.Visible = false;
            // 
            // lblUsersName
            // 
            this.lblUsersName.AutoSize = true;
            this.lblUsersName.Location = new System.Drawing.Point(624, 8);
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
            this.applicationToolStripMenuItem,
            this.toolStripMenuItem1});
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
            this.editCatalogueToolStripMenuItem});
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
            this.openRecentToolStripMenuItem.Click += new System.EventHandler(this.openRecentToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUserName,
            this.toolStripCurCat,
            this.toolStripMessage});
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
            this.editUserNameToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.editUserNameToolStripMenuItem.Text = "Edit User Name";
            this.editUserNameToolStripMenuItem.Click += new System.EventHandler(this.editUserNameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // editCatalogueToolStripMenuItem
            // 
            this.editCatalogueToolStripMenuItem.Name = "editCatalogueToolStripMenuItem";
            this.editCatalogueToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.editCatalogueToolStripMenuItem.Text = "Edit Catalogue";
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
            this.btnCancelUsersName.Location = new System.Drawing.Point(591, 1);
            this.btnCancelUsersName.Name = "btnCancelUsersName";
            this.btnCancelUsersName.Size = new System.Drawing.Size(31, 30);
            this.btnCancelUsersName.TabIndex = 16;
            this.btnCancelUsersName.Text = "X";
            this.btnCancelUsersName.UseVisualStyleBackColor = false;
            this.btnCancelUsersName.Visible = false;
            this.btnCancelUsersName.Click += new System.EventHandler(this.btnCancelUsersName_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnCancelUsersName);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblGuid);
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
    }
}

