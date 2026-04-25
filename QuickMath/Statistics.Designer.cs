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
            TreeNode treeNode1 = new TreeNode("Total");
            TreeNode treeNode2 = new TreeNode("Total");
            TreeNode treeNode3 = new TreeNode("easy");
            TreeNode treeNode4 = new TreeNode("medium");
            TreeNode treeNode5 = new TreeNode("Hard");
            TreeNode treeNode6 = new TreeNode("Incsane");
            TreeNode treeNode7 = new TreeNode("Additions", new TreeNode[] { treeNode2, treeNode3, treeNode4, treeNode5, treeNode6 });
            TreeNode treeNode8 = new TreeNode("Math", new TreeNode[] { treeNode1, treeNode7 });
            TreeNode treeNode9 = new TreeNode("Total coins spent");
            TreeNode treeNode10 = new TreeNode("Total coins earn");
            TreeNode treeNode11 = new TreeNode("Economy", new TreeNode[] { treeNode9, treeNode10 });
            TreeNode treeNode12 = new TreeNode("Red Star");
            TreeNode treeNode13 = new TreeNode("Blu star");
            TreeNode treeNode14 = new TreeNode("Yellow Star");
            TreeNode treeNode15 = new TreeNode("Purpule Star");
            TreeNode treeNode16 = new TreeNode("Stars", new TreeNode[] { treeNode12, treeNode13, treeNode14, treeNode15 });
            TreeNode treeNode17 = new TreeNode("Dark Matter");
            TreeNode treeNode18 = new TreeNode("Special", new TreeNode[] { treeNode16, treeNode17 });
            StatsTreeView = new TreeView();
            SuspendLayout();
            // 
            // StatsTreeView
            // 
            StatsTreeView.Location = new Point(12, 12);
            StatsTreeView.Name = "StatsTreeView";
            treeNode1.Name = "Total";
            treeNode1.Text = "Total";
            treeNode2.Name = "Total";
            treeNode2.Text = "Total";
            treeNode3.Name = "easy";
            treeNode3.Text = "easy";
            treeNode4.Name = "medium";
            treeNode4.Text = "medium";
            treeNode5.Name = "Hard";
            treeNode5.Text = "Hard";
            treeNode6.Name = "Incsane";
            treeNode6.Text = "Incsane";
            treeNode7.Name = "additions";
            treeNode7.Text = "Additions";
            treeNode8.Name = "Math";
            treeNode8.Text = "Math";
            treeNode9.Name = "Total coins spent";
            treeNode9.Text = "Total coins spent";
            treeNode10.Name = "Total coins earn";
            treeNode10.Text = "Total coins earn";
            treeNode11.Name = "Economy";
            treeNode11.Text = "Economy";
            treeNode12.Name = "Red Star";
            treeNode12.Text = "Red Star";
            treeNode13.Name = "Blu star";
            treeNode13.Text = "Blu star";
            treeNode14.Name = "Yellow Star";
            treeNode14.Text = "Yellow Star";
            treeNode15.Name = "Purpule Star";
            treeNode15.Text = "Purpule Star";
            treeNode16.Name = "Stars";
            treeNode16.Text = "Stars";
            treeNode17.Name = "Dark Matter";
            treeNode17.Text = "Dark Matter";
            treeNode18.Name = "Special";
            treeNode18.Text = "Special";
            StatsTreeView.Nodes.AddRange(new TreeNode[] { treeNode8, treeNode11, treeNode18 });
            StatsTreeView.Size = new Size(358, 426);
            StatsTreeView.TabIndex = 0;
            StatsTreeView.AfterSelect += treeView1_AfterSelect;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 453);
            Controls.Add(StatsTreeView);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Statistics";
            Text = "Statistics";
            Load += Statistics_Load;
            ResumeLayout(false);
        }

        #endregion

        private TreeView StatsTreeView;
    }
}