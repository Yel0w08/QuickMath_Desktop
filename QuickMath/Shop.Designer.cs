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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shop));
            shop_Buy_Button = new Button();
            Nshop_Label = new Label();
            Total_Shop_Label = new Label();
            shopItem1 = new CheckBox();
            Shop_Select_Category = new ComboBox();
            shopItem2 = new CheckBox();
            shopItem3 = new CheckBox();
            shopItem4 = new CheckBox();
            shopItem5 = new CheckBox();
            CartListBox = new ListBox();
            MoneyInAccountLabel = new Label();
            SuspendLayout();
            // 
            // shop_Buy_Button
            // 
            shop_Buy_Button.Location = new Point(585, 398);
            shop_Buy_Button.Name = "shop_Buy_Button";
            shop_Buy_Button.Size = new Size(203, 40);
            shop_Buy_Button.TabIndex = 1;
            shop_Buy_Button.Text = "buy";
            shop_Buy_Button.UseVisualStyleBackColor = true;
            shop_Buy_Button.Click += Shop_buy_button;
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
            Total_Shop_Label.BackColor = Color.Aquamarine;
            Total_Shop_Label.Location = new Point(585, 375);
            Total_Shop_Label.Name = "Total_Shop_Label";
            Total_Shop_Label.Size = new Size(200, 20);
            Total_Shop_Label.TabIndex = 3;
            Total_Shop_Label.Text = "Total = 0                                 ";
            // 
            // shopItem1
            // 
            shopItem1.AutoSize = true;
            shopItem1.Location = new Point(12, 110);
            shopItem1.Name = "shopItem1";
            shopItem1.Size = new Size(101, 24);
            shopItem1.TabIndex = 4;
            shopItem1.Text = "shopItem1";
            shopItem1.UseVisualStyleBackColor = true;
            shopItem1.CheckedChanged += shopItem1_CheckedChanged;
            // 
            // Shop_Select_Category
            // 
            Shop_Select_Category.FormattingEnabled = true;
            Shop_Select_Category.Items.AddRange(new object[] { "Difficulty", "Stars" });
            Shop_Select_Category.Location = new Point(12, 76);
            Shop_Select_Category.Name = "Shop_Select_Category";
            Shop_Select_Category.Size = new Size(150, 28);
            Shop_Select_Category.TabIndex = 5;
            Shop_Select_Category.SelectedIndexChanged += Shop_Select_Category_SelectedIndexChanged;
            // 
            // shopItem2
            // 
            shopItem2.AutoSize = true;
            shopItem2.Location = new Point(12, 140);
            shopItem2.Name = "shopItem2";
            shopItem2.Size = new Size(101, 24);
            shopItem2.TabIndex = 6;
            shopItem2.Text = "shopItem2";
            shopItem2.UseVisualStyleBackColor = true;
            shopItem2.CheckedChanged += shopItem2_CheckedChanged_1;
            // 
            // shopItem3
            // 
            shopItem3.AutoSize = true;
            shopItem3.Location = new Point(12, 170);
            shopItem3.Name = "shopItem3";
            shopItem3.Size = new Size(101, 24);
            shopItem3.TabIndex = 7;
            shopItem3.Text = "shopItem3";
            shopItem3.UseVisualStyleBackColor = true;
            shopItem3.CheckedChanged += shopItem3_CheckedChanged;
            // 
            // shopItem4
            // 
            shopItem4.AutoSize = true;
            shopItem4.Location = new Point(12, 200);
            shopItem4.Name = "shopItem4";
            shopItem4.Size = new Size(101, 24);
            shopItem4.TabIndex = 8;
            shopItem4.Text = "shopItem4";
            shopItem4.UseVisualStyleBackColor = true;
            shopItem4.CheckedChanged += shopItem4_CheckedChanged;
            // 
            // shopItem5
            // 
            shopItem5.AutoSize = true;
            shopItem5.Location = new Point(12, 230);
            shopItem5.Name = "shopItem5";
            shopItem5.Size = new Size(101, 24);
            shopItem5.TabIndex = 9;
            shopItem5.Text = "shopItem5";
            shopItem5.UseVisualStyleBackColor = true;
            shopItem5.CheckedChanged += shopItem5_CheckedChanged;
            // 
            // CartListBox
            // 
            CartListBox.Font = new Font("Segoe UI", 8F);
            CartListBox.FormattingEnabled = true;
            CartListBox.Location = new Point(585, 18);
            CartListBox.Name = "CartListBox";
            CartListBox.Size = new Size(203, 344);
            CartListBox.TabIndex = 10;
            CartListBox.SelectedIndexChanged += CartListBox_SelectedIndexChanged;
            // 
            // MoneyInAccountLabel
            // 
            MoneyInAccountLabel.AutoSize = true;
            MoneyInAccountLabel.Location = new Point(12, 36);
            MoneyInAccountLabel.Name = "MoneyInAccountLabel";
            MoneyInAccountLabel.Size = new Size(80, 20);
            MoneyInAccountLabel.TabIndex = 11;
            MoneyInAccountLabel.Text = "Money = 0";
            // 
            // Shop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MoneyInAccountLabel);
            Controls.Add(CartListBox);
            Controls.Add(shopItem5);
            Controls.Add(shopItem4);
            Controls.Add(shopItem3);
            Controls.Add(shopItem2);
            Controls.Add(Shop_Select_Category);
            Controls.Add(shopItem1);
            Controls.Add(Total_Shop_Label);
            Controls.Add(Nshop_Label);
            Controls.Add(shop_Buy_Button);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Shop";
            Text = "Shop";
            Load += Shop_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button shop_Buy_Button;
        private Label Nshop_Label;
        private Label Total_Shop_Label;
        private CheckBox shopItem1;
        private ComboBox Shop_Select_Category;
        private CheckBox shopItem2;
        private CheckBox shopItem3;
        private CheckBox shopItem4;
        private CheckBox shopItem5;
        private ListBox CartListBox;
        private Label MoneyInAccountLabel;
    }
}
