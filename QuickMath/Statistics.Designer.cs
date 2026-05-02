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
            TreeNode treeNode19 = new TreeNode("Total XP");
            TreeNode treeNode20 = new TreeNode("Username");
            TreeNode treeNode21 = new TreeNode("Player", new TreeNode[] { treeNode19, treeNode20 });
            StatsTreeView = new TreeView();
            OpenInfoButton = new MaterialSkin.Controls.MaterialButton();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // StatsTreeView
            // 
            StatsTreeView.Location = new Point(6, 102);
            StatsTreeView.Margin = new Padding(3, 2, 3, 2);
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
            treeNode19.Name = "Total XP";
            treeNode19.Text = "Total XP";
            treeNode20.Name = "Username";
            treeNode20.Text = "Username";
            treeNode21.Name = "Player";
            treeNode21.Text = "Player";
            StatsTreeView.Nodes.AddRange(new TreeNode[] { treeNode8, treeNode11, treeNode18, treeNode21 });
            StatsTreeView.Size = new Size(402, 345);
            StatsTreeView.TabIndex = 0;
            StatsTreeView.AfterSelect += treeView1_AfterSelect;
            // 
            // OpenInfoButton
            // 
            OpenInfoButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OpenInfoButton.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Title;
            OpenInfoButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            OpenInfoButton.Depth = 0;
            OpenInfoButton.Font = new Font("Segoe UI", 8F);
            OpenInfoButton.HighEmphasis = true;
            OpenInfoButton.Icon = null;
            OpenInfoButton.Location = new Point(339, 455);
            OpenInfoButton.Margin = new Padding(4, 6, 4, 6);
            OpenInfoButton.MouseState = MaterialSkin.MouseState.HOVER;
            OpenInfoButton.Name = "OpenInfoButton";
            OpenInfoButton.NoAccentTextColor = Color.Empty;
            OpenInfoButton.Size = new Size(69, 36);
            OpenInfoButton.TabIndex = 1;
            OpenInfoButton.Text = "About";
            OpenInfoButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            OpenInfoButton.UseAccentColor = false;
            OpenInfoButton.UseVisualStyleBackColor = true;
            OpenInfoButton.Click += OpenInfoButton_Click;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.BackColor = SystemColors.ActiveCaptionText;
            materialButton1.CharacterCasing = MaterialSkin.Controls.MaterialButton.CharacterCasingEnum.Normal;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.Font = new Font("Segoe UI", 8F);
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(7, 455);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(324, 36);
            materialButton1.TabIndex = 2;
            materialButton1.Text = "🚧 Work in progress 🚧";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = false;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 500);
            Controls.Add(materialButton1);
            Controls.Add(OpenInfoButton);
            Controls.Add(StatsTreeView);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Statistics";
            Text = "Statistics";
            Load += Statistics_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TreeView StatsTreeView;
        private MaterialSkin.Controls.MaterialButton OpenInfoButton;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}