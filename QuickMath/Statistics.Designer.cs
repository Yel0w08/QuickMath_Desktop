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
            TreeNode treeNode1 = new TreeNode("Username");
            TreeNode treeNode2 = new TreeNode("XP");
            TreeNode treeNode3 = new TreeNode("Current coins");
            TreeNode treeNode4 = new TreeNode("Player", new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            TreeNode treeNode5 = new TreeNode("Total attempts");
            TreeNode treeNode6 = new TreeNode("Correct answers");
            TreeNode treeNode7 = new TreeNode("Practice", new TreeNode[] { treeNode5, treeNode6 });
            TreeNode treeNode8 = new TreeNode("Additions");
            TreeNode treeNode9 = new TreeNode("Subtractions");
            TreeNode treeNode10 = new TreeNode("Operations", new TreeNode[] { treeNode8, treeNode9 });
            TreeNode treeNode11 = new TreeNode("Coins earned");
            TreeNode treeNode12 = new TreeNode("Coins spent");
            TreeNode treeNode13 = new TreeNode("Net coins");
            TreeNode treeNode14 = new TreeNode("Average XP per correct answer");
            TreeNode treeNode15 = new TreeNode("Average coins per correct answer");
            TreeNode treeNode16 = new TreeNode("Economy", new TreeNode[] { treeNode11, treeNode12, treeNode13, treeNode14, treeNode15 });
            TreeNode treeNode17 = new TreeNode("Difficulty unlocks");
            TreeNode treeNode18 = new TreeNode("Red Star");
            TreeNode treeNode19 = new TreeNode("Blue Star");
            TreeNode treeNode20 = new TreeNode("Yellow Star");
            TreeNode treeNode21 = new TreeNode("Purple Star");
            TreeNode treeNode22 = new TreeNode("Dark Matter");
            TreeNode treeNode23 = new TreeNode("Total collectibles");
            TreeNode treeNode24 = new TreeNode("Collection", new TreeNode[] { treeNode17, treeNode18, treeNode19, treeNode20, treeNode21, treeNode22, treeNode23 });
            StatsTreeView = new TreeView();
            VersionLabel = new Label();
            tabControl1 = new TabControl();
            stats = new TabPage();
            App = new TabPage();
            OverviewTextBox = new RichTextBox();
            tabControl1.SuspendLayout();
            stats.SuspendLayout();
            App.SuspendLayout();
            SuspendLayout();
            // 
            // StatsTreeView
            // 
            StatsTreeView.Location = new Point(3, 5);
            StatsTreeView.Margin = new Padding(3, 2, 3, 2);
            StatsTreeView.Name = "StatsTreeView";
            treeNode1.Name = "Username";
            treeNode1.Text = "Username";
            treeNode2.Name = "XP";
            treeNode2.Text = "XP";
            treeNode3.Name = "CurrentCoins";
            treeNode3.Text = "Current coins";
            treeNode4.Name = "Player";
            treeNode4.Text = "Player";
            treeNode5.Name = "TotalAttempts";
            treeNode5.Text = "Total attempts";
            treeNode6.Name = "CorrectAnswers";
            treeNode6.Text = "Correct answers";
            treeNode7.Name = "Practice";
            treeNode7.Text = "Practice";
            treeNode8.Name = "Additions";
            treeNode8.Text = "Additions";
            treeNode9.Name = "Subtractions";
            treeNode9.Text = "Subtractions";
            treeNode10.Name = "Operations";
            treeNode10.Text = "Operations";
            treeNode11.Name = "CoinsEarned";
            treeNode11.Text = "Coins earned";
            treeNode12.Name = "CoinsSpent";
            treeNode12.Text = "Coins spent";
            treeNode13.Name = "NetCoins";
            treeNode13.Text = "Net coins";
            treeNode14.Name = "AverageXp";
            treeNode14.Text = "Average XP per correct answer";
            treeNode15.Name = "AverageCoins";
            treeNode15.Text = "Average coins per correct answer";
            treeNode16.Name = "Economy";
            treeNode16.Text = "Economy";
            treeNode17.Name = "DifficultyUnlocks";
            treeNode17.Text = "Difficulty unlocks";
            treeNode18.Name = "RedStar";
            treeNode18.Text = "Red Star";
            treeNode19.Name = "BlueStar";
            treeNode19.Text = "Blue Star";
            treeNode20.Name = "YellowStar";
            treeNode20.Text = "Yellow Star";
            treeNode21.Name = "PurpleStar";
            treeNode21.Text = "Purple Star";
            treeNode22.Name = "DarkMatter";
            treeNode22.Text = "Dark Matter";
            treeNode23.Name = "TotalCollectibles";
            treeNode23.Text = "Total collectibles";
            treeNode24.Name = "Collection";
            treeNode24.Text = "Collection";
            StatsTreeView.Nodes.AddRange(new TreeNode[] { treeNode4, treeNode7, treeNode10, treeNode16, treeNode24 });
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
            App.Text = "overview";
            App.UseVisualStyleBackColor = true;
            // 
            // OverviewTextBox
            // 
            OverviewTextBox.BackColor = SystemColors.Window;
            OverviewTextBox.BorderStyle = BorderStyle.None;
            OverviewTextBox.Dock = DockStyle.Fill;
            OverviewTextBox.Location = new Point(3, 3);
            OverviewTextBox.Name = "OverviewTextBox";
            OverviewTextBox.ReadOnly = true;
            OverviewTextBox.Size = new Size(307, 274);
            OverviewTextBox.TabIndex = 0;
            OverviewTextBox.Text = "";
            App.Controls.Add(OverviewTextBox);
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
            App.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView StatsTreeView;
        private Label VersionLabel;
        private TabControl tabControl1;
        private TabPage stats;
        private TabPage App;
        private RichTextBox OverviewTextBox;
    }
}
