namespace CrossWordCraft
{
    partial class ContentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.labelVariants = new System.Windows.Forms.Label();
            this.MaxVariantsCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxVariantsCountcheckBox = new System.Windows.Forms.CheckBox();
            this.labelVariant = new System.Windows.Forms.Label();
            this.VariantsScrollBar = new System.Windows.Forms.HScrollBar();
            this.splitter = new System.Windows.Forms.Splitter();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.PropertiesListView = new System.Windows.Forms.ListView();
            this.IndexColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PropertyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxVariantsCountNumericUpDown)).BeginInit();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultPanel
            // 
            this.ResultPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ResultPanel.Controls.Add(this.labelVariants);
            this.ResultPanel.Controls.Add(this.MaxVariantsCountNumericUpDown);
            this.ResultPanel.Controls.Add(this.MaxVariantsCountcheckBox);
            this.ResultPanel.Controls.Add(this.labelVariant);
            this.ResultPanel.Controls.Add(this.VariantsScrollBar);
            this.ResultPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResultPanel.Location = new System.Drawing.Point(0, 352);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(307, 90);
            this.ResultPanel.TabIndex = 0;
            // 
            // labelVariants
            // 
            this.labelVariants.AutoSize = true;
            this.labelVariants.Location = new System.Drawing.Point(160, 11);
            this.labelVariants.Name = "labelVariants";
            this.labelVariants.Size = new System.Drawing.Size(60, 13);
            this.labelVariants.TabIndex = 4;
            this.labelVariants.Text = "вариантов";
            // 
            // MaxVariantsCountNumericUpDown
            // 
            this.MaxVariantsCountNumericUpDown.Location = new System.Drawing.Point(115, 10);
            this.MaxVariantsCountNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MaxVariantsCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxVariantsCountNumericUpDown.Name = "MaxVariantsCountNumericUpDown";
            this.MaxVariantsCountNumericUpDown.Size = new System.Drawing.Size(39, 20);
            this.MaxVariantsCountNumericUpDown.TabIndex = 3;
            this.MaxVariantsCountNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // MaxVariantsCountcheckBox
            // 
            this.MaxVariantsCountcheckBox.AutoSize = true;
            this.MaxVariantsCountcheckBox.Checked = true;
            this.MaxVariantsCountcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MaxVariantsCountcheckBox.Location = new System.Drawing.Point(7, 10);
            this.MaxVariantsCountcheckBox.Name = "MaxVariantsCountcheckBox";
            this.MaxVariantsCountcheckBox.Size = new System.Drawing.Size(104, 17);
            this.MaxVariantsCountcheckBox.TabIndex = 2;
            this.MaxVariantsCountcheckBox.Text = "Искать первые";
            this.MaxVariantsCountcheckBox.UseVisualStyleBackColor = true;
            this.MaxVariantsCountcheckBox.CheckedChanged += new System.EventHandler(this.MaxVariantsCountcheckBox_CheckedChanged);
            // 
            // labelVariant
            // 
            this.labelVariant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVariant.AutoSize = true;
            this.labelVariant.Location = new System.Drawing.Point(1, 35);
            this.labelVariant.Name = "labelVariant";
            this.labelVariant.Size = new System.Drawing.Size(90, 13);
            this.labelVariant.TabIndex = 1;
            this.labelVariant.Text = "Выбор варианта";
            // 
            // VariantsScrollBar
            // 
            this.VariantsScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VariantsScrollBar.LargeChange = 1;
            this.VariantsScrollBar.Location = new System.Drawing.Point(0, 51);
            this.VariantsScrollBar.Maximum = 0;
            this.VariantsScrollBar.Name = "VariantsScrollBar";
            this.VariantsScrollBar.Size = new System.Drawing.Size(303, 35);
            this.VariantsScrollBar.TabIndex = 0;
            this.VariantsScrollBar.ValueChanged += new System.EventHandler(this.VariantSelected);
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.Location = new System.Drawing.Point(0, 350);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(307, 2);
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            // 
            // ContentPanel
            // 
            this.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ContentPanel.Controls.Add(this.PropertiesListView);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(307, 350);
            this.ContentPanel.TabIndex = 2;
            // 
            // PropertiesListView
            // 
            this.PropertiesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IndexColumnHeader,
            this.PropertyColumnHeader,
            this.ValueColumnHeader});
            this.PropertiesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertiesListView.FullRowSelect = true;
            this.PropertiesListView.GridLines = true;
            this.PropertiesListView.Location = new System.Drawing.Point(0, 0);
            this.PropertiesListView.Name = "PropertiesListView";
            this.PropertiesListView.Size = new System.Drawing.Size(303, 346);
            this.PropertiesListView.TabIndex = 0;
            this.PropertiesListView.UseCompatibleStateImageBehavior = false;
            this.PropertiesListView.View = System.Windows.Forms.View.Details;
            // 
            // IndexColumnHeader
            // 
            this.IndexColumnHeader.Text = "";
            this.IndexColumnHeader.Width = 24;
            // 
            // PropertyColumnHeader
            // 
            this.PropertyColumnHeader.Text = "Свойство";
            this.PropertyColumnHeader.Width = 200;
            // 
            // ValueColumnHeader
            // 
            this.ValueColumnHeader.Text = "Значение";
            // 
            // ContentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.ResultPanel);
            this.Name = "ContentControl";
            this.Size = new System.Drawing.Size(307, 442);
            this.ResultPanel.ResumeLayout(false);
            this.ResultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxVariantsCountNumericUpDown)).EndInit();
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ResultPanel;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.ListView PropertiesListView;
        private System.Windows.Forms.ColumnHeader PropertyColumnHeader;
        private System.Windows.Forms.ColumnHeader ValueColumnHeader;
        private System.Windows.Forms.ColumnHeader IndexColumnHeader;
        private System.Windows.Forms.HScrollBar VariantsScrollBar;
        private System.Windows.Forms.Label labelVariant;
        private System.Windows.Forms.CheckBox MaxVariantsCountcheckBox;
        private System.Windows.Forms.NumericUpDown MaxVariantsCountNumericUpDown;
        private System.Windows.Forms.Label labelVariants;

    }
}
