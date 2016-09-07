namespace CrossWordCraft
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.Backgroud = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.linkLabelCodingCraft = new System.Windows.Forms.LinkLabel();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Backgroud)).BeginInit();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Backgroud
            // 
            this.Backgroud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Backgroud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Backgroud.Image = ((System.Drawing.Image)(resources.GetObject("Backgroud.Image")));
            this.Backgroud.Location = new System.Drawing.Point(0, 0);
            this.Backgroud.Name = "Backgroud";
            this.Backgroud.Size = new System.Drawing.Size(512, 256);
            this.Backgroud.TabIndex = 0;
            this.Backgroud.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Silver;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(430, 191);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 31);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // linkLabelCodingCraft
            // 
            this.linkLabelCodingCraft.AutoSize = true;
            this.linkLabelCodingCraft.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelCodingCraft.Location = new System.Drawing.Point(100, 51);
            this.linkLabelCodingCraft.Name = "linkLabelCodingCraft";
            this.linkLabelCodingCraft.Size = new System.Drawing.Size(74, 13);
            this.linkLabelCodingCraft.TabIndex = 16;
            this.linkLabelCodingCraft.TabStop = true;
            this.linkLabelCodingCraft.Text = "anton.fadin@gmail.com";
            this.linkLabelCodingCraft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCodingCraft_LinkClicked);
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.Color.Silver;
            this.InfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoPanel.Controls.Add(this.labelDescription);
            this.InfoPanel.Controls.Add(this.labelCopyright);
            this.InfoPanel.Controls.Add(this.labelVersion);
            this.InfoPanel.Controls.Add(this.labelProductName);
            this.InfoPanel.Controls.Add(this.linkLabelCodingCraft);
            this.InfoPanel.Location = new System.Drawing.Point(317, 108);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(183, 77);
            this.InfoPanel.TabIndex = 17;
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(3, 27);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(72, 13);
            this.labelProductName.TabIndex = 17;
            this.labelProductName.Text = "ProductName";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(100, 27);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 18;
            this.labelVersion.Text = "Version";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(3, 51);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(51, 13);
            this.labelCopyright.TabIndex = 19;
            this.labelCopyright.Text = "Copyright";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 3);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 20;
            this.labelDescription.Text = "Description";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 256);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.Backgroud);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            ((System.ComponentModel.ISupportInitialize)(this.Backgroud)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Backgroud;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.LinkLabel linkLabelCodingCraft;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelDescription;
    }
}