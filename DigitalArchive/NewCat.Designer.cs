
namespace DigitalArchive
{
    partial class NewCat
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
            System.Windows.Forms.Button btnGetFolder;
            this.lblCatDesc = new System.Windows.Forms.Label();
            this.lblCatName = new System.Windows.Forms.Label();
            this.txtCatDesc = new System.Windows.Forms.TextBox();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.btnGetGuid = new System.Windows.Forms.Button();
            this.lblGuid = new System.Windows.Forms.Label();
            this.opnFileLocation = new System.Windows.Forms.OpenFileDialog();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.brwFolderLoc = new System.Windows.Forms.FolderBrowserDialog();
            btnGetFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetFolder
            // 
            btnGetFolder.Location = new System.Drawing.Point(675, 145);
            btnGetFolder.Name = "btnGetFolder";
            btnGetFolder.Size = new System.Drawing.Size(33, 32);
            btnGetFolder.TabIndex = 14;
            btnGetFolder.Text = "...";
            btnGetFolder.UseVisualStyleBackColor = true;
            btnGetFolder.Click += new System.EventHandler(this.btnGetFolder_Click);
            // 
            // lblCatDesc
            // 
            this.lblCatDesc.AutoSize = true;
            this.lblCatDesc.Location = new System.Drawing.Point(88, 272);
            this.lblCatDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCatDesc.Name = "lblCatDesc";
            this.lblCatDesc.Size = new System.Drawing.Size(89, 20);
            this.lblCatDesc.TabIndex = 10;
            this.lblCatDesc.Text = "Description";
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.Location = new System.Drawing.Point(49, 212);
            this.lblCatName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(128, 20);
            this.lblCatName.TabIndex = 9;
            this.lblCatName.Text = "Catalogue Name";
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.Location = new System.Drawing.Point(187, 272);
            this.txtCatDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(564, 26);
            this.txtCatDesc.TabIndex = 8;
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(187, 212);
            this.txtCatName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(199, 26);
            this.txtCatName.TabIndex = 7;
            // 
            // btnGetGuid
            // 
            this.btnGetGuid.Location = new System.Drawing.Point(185, 336);
            this.btnGetGuid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetGuid.Name = "btnGetGuid";
            this.btnGetGuid.Size = new System.Drawing.Size(201, 35);
            this.btnGetGuid.TabIndex = 6;
            this.btnGetGuid.Text = "Creat New Catalogue";
            this.btnGetGuid.UseVisualStyleBackColor = true;
            this.btnGetGuid.Click += new System.EventHandler(this.btnGetGuid_Click);
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(183, 173);
            this.lblGuid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(0, 20);
            this.lblGuid.TabIndex = 11;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(187, 147);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(483, 26);
            this.txtFilePath.TabIndex = 12;
            this.txtFilePath.Click += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(58, 150);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(119, 20);
            this.lblFilePath.TabIndex = 13;
            this.lblFilePath.Text = "Select Location";
            this.lblFilePath.Click += new System.EventHandler(this.lblFilePath_Click);
            // 
            // NewCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(btnGetFolder);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblGuid);
            this.Controls.Add(this.lblCatDesc);
            this.Controls.Add(this.lblCatName);
            this.Controls.Add(this.txtCatDesc);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.btnGetGuid);
            this.Name = "NewCat";
            this.Text = "NewCat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCatDesc;
        private System.Windows.Forms.Label lblCatName;
        private System.Windows.Forms.TextBox txtCatDesc;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.Button btnGetGuid;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.OpenFileDialog opnFileLocation;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.FolderBrowserDialog brwFolderLoc;
    }
}