namespace CrossWordCraft
{
    partial class ProceedingForm
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
            this.labelVariantsCount = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.Frame = new System.Windows.Forms.Panel();
            this.labelDepth = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.CurrentDepthBar = new System.Windows.Forms.ProgressBar();
            this.ProgressValueBar = new System.Windows.Forms.ProgressBar();
            this.labelOperationsCount = new System.Windows.Forms.Label();
            this.labelOperation = new System.Windows.Forms.Label();
            this.Frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelVariantsCount
            // 
            this.labelVariantsCount.AutoSize = true;
            this.labelVariantsCount.Location = new System.Drawing.Point(8, 8);
            this.labelVariantsCount.Name = "labelVariantsCount";
            this.labelVariantsCount.Size = new System.Drawing.Size(122, 13);
            this.labelVariantsCount.TabIndex = 1;
            this.labelVariantsCount.Text = "Количество вариантов";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(99, 171);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(86, 34);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Завершить...";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // Frame
            // 
            this.Frame.BackColor = System.Drawing.Color.White;
            this.Frame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Frame.Controls.Add(this.labelOperation);
            this.Frame.Controls.Add(this.labelDepth);
            this.Frame.Controls.Add(this.labelProgress);
            this.Frame.Controls.Add(this.CurrentDepthBar);
            this.Frame.Controls.Add(this.ProgressValueBar);
            this.Frame.Controls.Add(this.labelOperationsCount);
            this.Frame.Controls.Add(this.buttonStop);
            this.Frame.Controls.Add(this.labelVariantsCount);
            this.Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame.Location = new System.Drawing.Point(0, 0);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(287, 218);
            this.Frame.TabIndex = 4;
            // 
            // labelDepth
            // 
            this.labelDepth.AutoSize = true;
            this.labelDepth.Location = new System.Drawing.Point(8, 118);
            this.labelDepth.Name = "labelDepth";
            this.labelDepth.Size = new System.Drawing.Size(105, 13);
            this.labelDepth.TabIndex = 8;
            this.labelDepth.Text = "Текущий вариант...";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(8, 75);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(101, 13);
            this.labelProgress.TabIndex = 7;
            this.labelProgress.Text = "Полный перебор...";
            // 
            // CurrentDepthBar
            // 
            this.CurrentDepthBar.Location = new System.Drawing.Point(11, 134);
            this.CurrentDepthBar.Name = "CurrentDepthBar";
            this.CurrentDepthBar.Size = new System.Drawing.Size(263, 24);
            this.CurrentDepthBar.TabIndex = 6;
            // 
            // ProgressValueBar
            // 
            this.ProgressValueBar.Location = new System.Drawing.Point(11, 91);
            this.ProgressValueBar.Name = "ProgressValueBar";
            this.ProgressValueBar.Size = new System.Drawing.Size(263, 24);
            this.ProgressValueBar.TabIndex = 5;
            // 
            // labelOperationsCount
            // 
            this.labelOperationsCount.AutoSize = true;
            this.labelOperationsCount.Location = new System.Drawing.Point(8, 30);
            this.labelOperationsCount.Name = "labelOperationsCount";
            this.labelOperationsCount.Size = new System.Drawing.Size(117, 13);
            this.labelOperationsCount.TabIndex = 4;
            this.labelOperationsCount.Text = "Количество операций";
            // 
            // labelOperation
            // 
            this.labelOperation.AutoSize = true;
            this.labelOperation.Location = new System.Drawing.Point(8, 53);
            this.labelOperation.Name = "labelOperation";
            this.labelOperation.Size = new System.Drawing.Size(103, 13);
            this.labelOperation.TabIndex = 9;
            this.labelOperation.Text = "Текущая операция";
            // 
            // ProceedingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 218);
            this.Controls.Add(this.Frame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProceedingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceeding";
            this.TopMost = true;
            this.Frame.ResumeLayout(false);
            this.Frame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelVariantsCount;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Panel Frame;
        private System.Windows.Forms.Label labelOperationsCount;
        private System.Windows.Forms.ProgressBar CurrentDepthBar;
        private System.Windows.Forms.ProgressBar ProgressValueBar;
        private System.Windows.Forms.Label labelDepth;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label labelOperation;
    }
}