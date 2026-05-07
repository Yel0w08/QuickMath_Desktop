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
            TreeNode treeNode43 = new TreeNode("Total");
            TreeNode treeNode44 = new TreeNode("Total");
            TreeNode treeNode45 = new TreeNode("easy");
            TreeNode treeNode46 = new TreeNode("medium");
            TreeNode treeNode47 = new TreeNode("Hard");
            TreeNode treeNode48 = new TreeNode("Incsane");
            TreeNode treeNode49 = new TreeNode("Additions", new TreeNode[] { treeNode44, treeNode45, treeNode46, treeNode47, treeNode48 });
            TreeNode treeNode50 = new TreeNode("Math", new TreeNode[] { treeNode43, treeNode49 });
            TreeNode treeNode51 = new TreeNode("Total coins spent");
            TreeNode treeNode52 = new TreeNode("Total coins earn");
            TreeNode treeNode53 = new TreeNode("Economy", new TreeNode[] { treeNode51, treeNode52 });
            TreeNode treeNode54 = new TreeNode("Red Star");
            TreeNode treeNode55 = new TreeNode("Blu star");
            TreeNode treeNode56 = new TreeNode("Yellow Star");
            TreeNode treeNode57 = new TreeNode("Purpule Star");
            TreeNode treeNode58 = new TreeNode("Stars", new TreeNode[] { treeNode54, treeNode55, treeNode56, treeNode57 });
            TreeNode treeNode59 = new TreeNode("Dark Matter");
            TreeNode treeNode60 = new TreeNode("Special", new TreeNode[] { treeNode58, treeNode59 });
            TreeNode treeNode61 = new TreeNode("Total XP");
            TreeNode treeNode62 = new TreeNode("Username");
            TreeNode treeNode63 = new TreeNode("Player", new TreeNode[] { treeNode61, treeNode62 });
            StatsTreeView = new TreeView();
            AboutButtonOpenPopup = new Button();
            SuspendLayout();
            // 
            // StatsTreeView
            // 
            StatsTreeView.Location = new Point(12, 11);
            StatsTreeView.Margin = new Padding(3, 2, 3, 2);
            StatsTreeView.Name = "StatsTreeView";
            treeNode43.Name = "Total";
            treeNode43.Text = "Total";
            treeNode44.Name = "Total";
            treeNode44.Text = "Total";
            treeNode45.Name = "easy";
            treeNode45.Text = "easy";
            treeNode46.Name = "medium";
            treeNode46.Text = "medium";
            treeNode47.Name = "Hard";
            treeNode47.Text = "Hard";
            treeNode48.Name = "Incsane";
            treeNode48.Text = "Incsane";
            treeNode49.Name = "additions";
            treeNode49.Text = "Additions";
            treeNode50.Name = "Math";
            treeNode50.Text = "Math";
            treeNode51.Name = "Total coins spent";
            treeNode51.Text = "Total coins spent";
            treeNode52.Name = "Total coins earn";
            treeNode52.Text = "Total coins earn";
            treeNode53.Name = "Economy";
            treeNode53.Text = "Economy";
            treeNode54.Name = "Red Star";
            treeNode54.Text = "Red Star";
            treeNode55.Name = "Blu star";
            treeNode55.Text = "Blu star";
            treeNode56.Name = "Yellow Star";
            treeNode56.Text = "Yellow Star";
            treeNode57.Name = "Purpule Star";
            treeNode57.Text = "Purpule Star";
            treeNode58.Name = "Stars";
            treeNode58.Text = "Stars";
            treeNode59.Name = "Dark Matter";
            treeNode59.Text = "Dark Matter";
            treeNode60.Name = "Special";
            treeNode60.Text = "Special";
            treeNode61.Name = "Total XP";
            treeNode61.Text = "Total XP";
            treeNode62.Name = "Username";
            treeNode62.Text = "Username";
            treeNode63.Name = "Player";
            treeNode63.Text = "Player";
            StatsTreeView.Nodes.AddRange(new TreeNode[] { treeNode50, treeNode53, treeNode60, treeNode63 });
            StatsTreeView.Size = new Size(389, 377);
            StatsTreeView.TabIndex = 0;
            StatsTreeView.AfterSelect += treeView1_AfterSelect;
            // 
            // AboutButtonOpenPopup
            // 
            AboutButtonOpenPopup.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AboutButtonOpenPopup.ForeColor = SystemColors.ActiveCaptionText;
            AboutButtonOpenPopup.Location = new Point(12, 393);
            AboutButtonOpenPopup.Name = "AboutButtonOpenPopup";
            AboutButtonOpenPopup.Size = new Size(389, 26);
            AboutButtonOpenPopup.TabIndex = 1;
            AboutButtonOpenPopup.Text = "About ";
            AboutButtonOpenPopup.UseVisualStyleBackColor = true;
            AboutButtonOpenPopup.Click += AboutButtonOpenPopup_Click;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 431);
            Controls.Add(AboutButtonOpenPopup);
            Controls.Add(StatsTreeView);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Statistics";
            Text = "Statistics";
            Load += Statistics_Load;
            ResumeLayout(false);
        }

        #endregion
        private TreeView StatsTreeView;
        private Button AboutButtonOpenPopup;
    }
}