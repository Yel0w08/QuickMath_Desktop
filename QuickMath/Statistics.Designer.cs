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
            TreeNode treeNode2 = new TreeNode("Additions");
            TreeNode treeNode3 = new TreeNode("Sustraction");
            TreeNode treeNode4 = new TreeNode("Math", new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            TreeNode treeNode5 = new TreeNode("Total coins spent");
            TreeNode treeNode6 = new TreeNode("Total coins earn");
            TreeNode treeNode7 = new TreeNode("Economy", new TreeNode[] { treeNode5, treeNode6 });
            TreeNode treeNode8 = new TreeNode("Red Star");
            TreeNode treeNode9 = new TreeNode("Blu star");
            TreeNode treeNode10 = new TreeNode("Yellow Star");
            TreeNode treeNode11 = new TreeNode("Purpule Star");
            TreeNode treeNode12 = new TreeNode("Stars", new TreeNode[] { treeNode8, treeNode9, treeNode10, treeNode11 });
            TreeNode treeNode13 = new TreeNode("Dark Matter");
            TreeNode treeNode14 = new TreeNode("Special", new TreeNode[] { treeNode12, treeNode13 });
            TreeNode treeNode15 = new TreeNode("Total XP");
            TreeNode treeNode16 = new TreeNode("Username");
            TreeNode treeNode17 = new TreeNode("Player", new TreeNode[] { treeNode15, treeNode16 });
            StatsTreeView = new TreeView();
            VersionLabel = new Label();
            tabControl1 = new TabControl();
            stats = new TabPage();
            App = new TabPage();
            tabControl1.SuspendLayout();
            stats.SuspendLayout();
            SuspendLayout();
            // 
            // StatsTreeView
            // 
            StatsTreeView.Location = new Point(3, 5);
            StatsTreeView.Margin = new Padding(3, 2, 3, 2);
            StatsTreeView.Name = "StatsTreeView";
            treeNode1.Name = "Total";
            treeNode1.Text = "Total";
            treeNode2.Name = "additions";
            treeNode2.Text = "Additions";
            treeNode3.Name = "Soustrations";
            treeNode3.Text = "Sustraction";
            treeNode4.Name = "Math";
            treeNode4.Text = "Math";
            treeNode5.Name = "Total coins spent";
            treeNode5.Text = "Total coins spent";
            treeNode6.Name = "Total coins earn";
            treeNode6.Text = "Total coins earn";
            treeNode7.Name = "Economy";
            treeNode7.Text = "Economy";
            treeNode8.Name = "Red Star";
            treeNode8.Text = "Red Star";
            treeNode9.Name = "Blu star";
            treeNode9.Text = "Blu star";
            treeNode10.Name = "Yellow Star";
            treeNode10.Text = "Yellow Star";
            treeNode11.Name = "Purpule Star";
            treeNode11.Text = "Purpule Star";
            treeNode12.Name = "Stars";
            treeNode12.Text = "Stars";
            treeNode13.Name = "Dark Matter";
            treeNode13.Text = "Dark Matter";
            treeNode14.Name = "Special";
            treeNode14.Text = "Special";
            treeNode15.Name = "Total XP";
            treeNode15.Text = "Total XP";
            treeNode16.Name = "Username";
            treeNode16.Text = "Username";
            treeNode17.Name = "Player";
            treeNode17.Text = "Player";
            StatsTreeView.Nodes.AddRange(new TreeNode[] { treeNode4, treeNode7, treeNode14, treeNode17 });
            StatsTreeView.Size = new Size(307, 270);
            StatsTreeView.TabIndex = 0;
            StatsTreeView.AfterSelect += treeView1_AfterSelect;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new Point(10, 318);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(34, 15);
            VersionLabel.TabIndex = 1;
            VersionLabel.Text = "Build";
            VersionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(stats);
            tabControl1.Controls.Add(App);
            tabControl1.Location = new Point(10, 7);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(321, 308);
            tabControl1.TabIndex = 2;
            // 
            // stats
            // 
            stats.Controls.Add(StatsTreeView);
            stats.Location = new Point(4, 24);
            stats.Name = "stats";
            stats.Padding = new Padding(3);
            stats.Size = new Size(313, 280);
            stats.TabIndex = 0;
            stats.Text = "stats";
            stats.UseVisualStyleBackColor = true;
            // 
            // App
            // 
            App.Location = new Point(4, 24);
            App.Name = "App";
            App.Padding = new Padding(3);
            App.Size = new Size(313, 280);
            App.TabIndex = 1;
            App.Text = "App";
            App.UseVisualStyleBackColor = true;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 340);
            Controls.Add(tabControl1);
            Controls.Add(VersionLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Statistics";
            Text = "Statistics";
            Load += Statistics_Load;
            tabControl1.ResumeLayout(false);
            stats.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView StatsTreeView;
        private Label VersionLabel;
        private TabControl tabControl1;
        private TabPage stats;
        private TabPage App;
    }
}