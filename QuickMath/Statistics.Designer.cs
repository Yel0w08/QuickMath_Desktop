namespace QuickMath
{
    partial class Statistics
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
            TreeViewStats = new TreeView();
            SuspendLayout();
            // 
            // TreeViewStats
            // 
            TreeViewStats.Location = new Point(12, 12);
            TreeViewStats.Name = "TreeViewStats";
            TreeViewStats.Size = new Size(776, 426);
            TreeViewStats.TabIndex = 0;
            TreeViewStats.AfterSelect += treeView1_AfterSelect;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TreeViewStats);
            Name = "Statistics";
            Text = "Statistics";
            ResumeLayout(false);
        }

        #endregion

        private TreeView TreeViewStats;
    }
}