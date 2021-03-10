
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
            this.btnGetGuid = new System.Windows.Forms.Button();
            this.lblGuid = new System.Windows.Forms.Label();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.txtCatDesc = new System.Windows.Forms.TextBox();
            this.lblCatName = new System.Windows.Forms.Label();
            this.lblCatDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetGuid
            // 
            this.btnGetGuid.Location = new System.Drawing.Point(106, 55);
            this.btnGetGuid.Name = "btnGetGuid";
            this.btnGetGuid.Size = new System.Drawing.Size(134, 23);
            this.btnGetGuid.TabIndex = 0;
            this.btnGetGuid.Text = "Creat New Catalogue";
            this.btnGetGuid.UseVisualStyleBackColor = true;
            this.btnGetGuid.Click += new System.EventHandler(this.btnGetGuid_Click);
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(103, 171);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(0, 13);
            this.lblGuid.TabIndex = 1;
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(106, 94);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(134, 20);
            this.txtCatName.TabIndex = 2;
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.Location = new System.Drawing.Point(106, 133);
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(377, 20);
            this.txtCatDesc.TabIndex = 3;
            this.txtCatDesc.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.Location = new System.Drawing.Point(14, 94);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(86, 13);
            this.lblCatName.TabIndex = 4;
            this.lblCatName.Text = "Catalogue Name";
            this.lblCatName.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblCatDesc
            // 
            this.lblCatDesc.AutoSize = true;
            this.lblCatDesc.Location = new System.Drawing.Point(40, 133);
            this.lblCatDesc.Name = "lblCatDesc";
            this.lblCatDesc.Size = new System.Drawing.Size(60, 13);
            this.lblCatDesc.TabIndex = 5;
            this.lblCatDesc.Text = "Description";
            this.lblCatDesc.Click += new System.EventHandler(this.lblCatDesc_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCatDesc);
            this.Controls.Add(this.lblCatName);
            this.Controls.Add(this.txtCatDesc);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.lblGuid);
            this.Controls.Add(this.btnGetGuid);
            this.Name = "Main";
            this.Text = "Main";
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
    }
}

