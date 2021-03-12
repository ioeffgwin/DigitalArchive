
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
            this.btnGetGuid = new System.Windows.Forms.Button();
            this.lblGuid = new System.Windows.Forms.Label();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.txtCatDesc = new System.Windows.Forms.TextBox();
            this.lblCatName = new System.Windows.Forms.Label();
            this.lblCatDesc = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblCurrentCat = new System.Windows.Forms.Label();
            this.txtUsersName = new System.Windows.Forms.TextBox();
            this.lblUsersName = new System.Windows.Forms.Label();
            this.btnUsersName = new System.Windows.Forms.Button();
            this.btnConnectCat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetGuid
            // 
            this.btnGetGuid.Location = new System.Drawing.Point(159, 85);
            this.btnGetGuid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetGuid.Name = "btnGetGuid";
            this.btnGetGuid.Size = new System.Drawing.Size(201, 35);
            this.btnGetGuid.TabIndex = 0;
            this.btnGetGuid.Text = "Creat New Catalogue";
            this.btnGetGuid.UseVisualStyleBackColor = true;
            this.btnGetGuid.Click += new System.EventHandler(this.btnGetGuid_Click);
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(154, 263);
            this.lblGuid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(0, 20);
            this.lblGuid.TabIndex = 1;
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(159, 145);
            this.txtCatName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(199, 26);
            this.txtCatName.TabIndex = 2;
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.Location = new System.Drawing.Point(159, 205);
            this.txtCatDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(564, 26);
            this.txtCatDesc.TabIndex = 3;
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.Location = new System.Drawing.Point(21, 145);
            this.lblCatName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(128, 20);
            this.lblCatName.TabIndex = 4;
            this.lblCatName.Text = "Catalogue Name";
            // 
            // lblCatDesc
            // 
            this.lblCatDesc.AutoSize = true;
            this.lblCatDesc.Location = new System.Drawing.Point(60, 205);
            this.lblCatDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCatDesc.Name = "lblCatDesc";
            this.lblCatDesc.Size = new System.Drawing.Size(89, 20);
            this.lblCatDesc.TabIndex = 5;
            this.lblCatDesc.Text = "Description";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(105, 670);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(84, 20);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "user name";
            // 
            // lblCurrentCat
            // 
            this.lblCurrentCat.AutoSize = true;
            this.lblCurrentCat.Location = new System.Drawing.Point(890, 669);
            this.lblCurrentCat.Name = "lblCurrentCat";
            this.lblCurrentCat.Size = new System.Drawing.Size(139, 20);
            this.lblCurrentCat.TabIndex = 7;
            this.lblCurrentCat.Text = "Current Catalogue";
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
            // btnConnectCat
            // 
            this.btnConnectCat.Location = new System.Drawing.Point(158, 42);
            this.btnConnectCat.Name = "btnConnectCat";
            this.btnConnectCat.Size = new System.Drawing.Size(201, 31);
            this.btnConnectCat.TabIndex = 11;
            this.btnConnectCat.Text = "Connect to Catalogue";
            this.btnConnectCat.UseVisualStyleBackColor = true;
            this.btnConnectCat.Click += new System.EventHandler(this.btnConnectCat_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnConnectCat);
            this.Controls.Add(this.btnUsersName);
            this.Controls.Add(this.lblUsersName);
            this.Controls.Add(this.txtUsersName);
            this.Controls.Add(this.lblCurrentCat);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblCatDesc);
            this.Controls.Add(this.lblCatName);
            this.Controls.Add(this.txtCatDesc);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.lblGuid);
            this.Controls.Add(this.btnGetGuid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetGuid;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.TextBox txtCatDesc;
        private System.Windows.Forms.Label lblCatName;
        private System.Windows.Forms.Label lblCatDesc;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblCurrentCat;
        private System.Windows.Forms.TextBox txtUsersName;
        private System.Windows.Forms.Label lblUsersName;
        private System.Windows.Forms.Button btnUsersName;
        private System.Windows.Forms.Button btnConnectCat;
    }
}

