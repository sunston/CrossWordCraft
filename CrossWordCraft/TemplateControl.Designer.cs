namespace CrossWordCraft
{
    partial class TemplateControl
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
            this.ToolBoxPanel = new System.Windows.Forms.Panel();
            this.HeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.GridPanel = new DoubleBufferedPanel();
            this.ToolBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBoxPanel
            // 
            this.ToolBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ToolBoxPanel.Controls.Add(this.HeightNumericUpDown);
            this.ToolBoxPanel.Controls.Add(this.HeightLabel);
            this.ToolBoxPanel.Controls.Add(this.WidthNumericUpDown);
            this.ToolBoxPanel.Controls.Add(this.WidthLabel);
            this.ToolBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolBoxPanel.Name = "ToolBoxPanel";
            this.ToolBoxPanel.Size = new System.Drawing.Size(641, 32);
            this.ToolBoxPanel.TabIndex = 0;
            // 
            // HeightNumericUpDown
            // 
            this.HeightNumericUpDown.Location = new System.Drawing.Point(158, 5);
            this.HeightNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.HeightNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HeightNumericUpDown.Name = "HeightNumericUpDown";
            this.HeightNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.HeightNumericUpDown.TabIndex = 3;
            this.HeightNumericUpDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.HeightNumericUpDown.ValueChanged += new System.EventHandler(this.HeightNumericUpDown_ValueChanged);
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(107, 7);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(45, 13);
            this.HeightLabel.TabIndex = 2;
            this.HeightLabel.Text = "Высота";
            // 
            // WidthNumericUpDown
            // 
            this.WidthNumericUpDown.Location = new System.Drawing.Point(55, 5);
            this.WidthNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.WidthNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.WidthNumericUpDown.Name = "WidthNumericUpDown";
            this.WidthNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.WidthNumericUpDown.TabIndex = 1;
            this.WidthNumericUpDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.WidthNumericUpDown.ValueChanged += new System.EventHandler(this.WidthNumericUpDown_ValueChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(3, 5);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(46, 13);
            this.WidthLabel.TabIndex = 0;
            this.WidthLabel.Text = "Ширина";
            // 
            // GridPanel
            // 
            this.GridPanel.AutoScroll = true;
            this.GridPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.Location = new System.Drawing.Point(0, 32);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(641, 473);
            this.GridPanel.TabIndex = 1;
            // 
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.ToolBoxPanel);
            this.Name = "Template";
            this.Size = new System.Drawing.Size(641, 505);
            this.ToolBoxPanel.ResumeLayout(false);
            this.ToolBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedPanel GridPanel;
        private System.Windows.Forms.Panel ToolBoxPanel;
        private System.Windows.Forms.NumericUpDown HeightNumericUpDown;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.NumericUpDown WidthNumericUpDown;
        private System.Windows.Forms.Label WidthLabel;
    }
}
