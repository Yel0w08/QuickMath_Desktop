namespace QuickMath
{
    partial class Shop
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
            TreeNode treeNode1 = new TreeNode("Hard Difficulty");
            TreeNode treeNode2 = new TreeNode("Insane Difficulty");
            TreeNode treeNode3 = new TreeNode("Addition", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Difficulty", new TreeNode[] { treeNode3 });
            TreeNode treeNode5 = new TreeNode("Special");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shop));
            button1 = new Button();
            Nshop_Label = new Label();
            Total_Shop_Label = new Label();
            shopItem1 = new CheckBox();
            Shop_Select_Category = new ComboBox();
            shopItem2 = new CheckBox();
            shopItem3 = new CheckBox();
            shopItem4 = new CheckBox();
            shopItem5 = new CheckBox();
            Cart = new TreeView();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(694, 398);
            button1.Name = "button1";
            button1.Size = new Size(94, 40);
            button1.TabIndex = 1;
            button1.Text = "buy";
            button1.UseVisualStyleBackColor = true;
            // 
            // Nshop_Label
            // 
            Nshop_Label.AutoSize = true;
            Nshop_Label.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Nshop_Label.Location = new Point(12, 9);
            Nshop_Label.Name = "Nshop_Label";
            Nshop_Label.Size = new Size(72, 27);
            Nshop_Label.TabIndex = 2;
            Nshop_Label.Text = "NShop";
            // 
            // Total_Shop_Label
            // 
            Total_Shop_Label.AutoSize = true;
            Total_Shop_Label.Location = new Point(548, 350);
            Total_Shop_Label.Name = "Total_Shop_Label";
            Total_Shop_Label.Size = new Size(56, 20);
            Total_Shop_Label.TabIndex = 3;
            Total_Shop_Label.Text = "Total =";
            // 
            // shopItem1
            // 
            shopItem1.AutoSize = true;
            shopItem1.Location = new Point(12, 98);
            shopItem1.Name = "shopItem1";
            shopItem1.Size = new Size(101, 24);
            shopItem1.TabIndex = 4;
            shopItem1.Text = "shopItem1";
            shopItem1.UseVisualStyleBackColor = true;
            // 
            // Shop_Select_Category
            // 
            Shop_Select_Category.FormattingEnabled = true;
            Shop_Select_Category.Items.AddRange(new object[] { "Difficulty", "Special" });
            Shop_Select_Category.Location = new Point(12, 64);
            Shop_Select_Category.Name = "Shop_Select_Category";
            Shop_Select_Category.Size = new Size(150, 28);
            Shop_Select_Category.TabIndex = 5;
            Shop_Select_Category.SelectedIndexChanged += Shop_Select_Category_SelectedIndexChanged;
            // 
            // shopItem2
            // 
            shopItem2.AutoSize = true;
            shopItem2.Location = new Point(12, 127);
            shopItem2.Name = "shopItem2";
            shopItem2.Size = new Size(101, 24);
            shopItem2.TabIndex = 6;
            shopItem2.Text = "shopItem2";
            shopItem2.UseVisualStyleBackColor = true;
            // 
            // shopItem3
            // 
            shopItem3.AutoSize = true;
            shopItem3.Location = new Point(12, 157);
            shopItem3.Name = "shopItem3";
            shopItem3.Size = new Size(101, 24);
            shopItem3.TabIndex = 7;
            shopItem3.Text = "shopItem3";
            shopItem3.UseVisualStyleBackColor = true;
            // 
            // shopItem4
            // 
            shopItem4.AutoSize = true;
            shopItem4.Location = new Point(12, 187);
            shopItem4.Name = "shopItem4";
            shopItem4.Size = new Size(101, 24);
            shopItem4.TabIndex = 8;
            shopItem4.Text = "shopItem4";
            shopItem4.UseVisualStyleBackColor = true;
            // 
            // shopItem5
            // 
            shopItem5.AutoSize = true;
            shopItem5.Location = new Point(12, 217);
            shopItem5.Name = "shopItem5";
            shopItem5.Size = new Size(101, 24);
            shopItem5.TabIndex = 9;
            shopItem5.Text = "shopItem5";
            shopItem5.UseVisualStyleBackColor = true;
            // 
            // Cart
            // 
            Cart.Location = new Point(190, 60);
            Cart.Name = "Cart";
            treeNode1.Name = "hardDifficulty";
            treeNode1.Text = "Hard Difficulty";
            treeNode2.Name = "insaneDifficulty";
            treeNode2.Text = "Insane Difficulty";
            treeNode3.Name = "Addition";
            treeNode3.Text = "Addition";
            treeNode4.Name = "Difficulty";
            treeNode4.Text = "Difficulty";
            treeNode5.Name = "Special";
            treeNode5.Text = "Special";
            Cart.Nodes.AddRange(new TreeNode[] { treeNode4, treeNode5 });
            Cart.Size = new Size(237, 121);
            Cart.TabIndex = 10;
            // 
            // Shop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Cart);
            Controls.Add(shopItem5);
            Controls.Add(shopItem4);
            Controls.Add(shopItem3);
            Controls.Add(shopItem2);
            Controls.Add(Shop_Select_Category);
            Controls.Add(shopItem1);
            Controls.Add(Total_Shop_Label);
            Controls.Add(Nshop_Label);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Shop";
            Text = "Shop";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Label Nshop_Label;
        private Label Total_Shop_Label;
        private CheckBox shopItem1;
        private ComboBox Shop_Select_Category;
        private CheckBox shopItem2;
        private CheckBox shopItem3;
        private CheckBox shopItem4;
        private CheckBox shopItem5;
        private TreeView Cart;
    }
}