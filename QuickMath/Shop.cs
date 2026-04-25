using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickMath
{


    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
            ShopItems_ClearList();
        }

        public class ShopItem
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
        }

        private void Shop_Select_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Shop_Select_Category.SelectedItem.ToString() == "Difficulty")
            {
                ShopItems_ClearList();
                shopItem1.Text = "Hard Difficulty for addition 5 ∑∑";
                shopItem2.Text = "Insane Difficulty for addition 5 ∑∑";
            }
            else if (Shop_Select_Category.SelectedItem.ToString() == "Special")
            {
                ShopItems_ClearList();
                shopItem1.Text = "Red Star";
                shopItem2.Text = "Blu Star";

            }
            else { 
                ShopItems_ClearList();
            }


        }
        void ShopItems_ClearList()
        {
            shopItem1.Text = "";
            shopItem2.Text = "";
            shopItem3.Text = "";
            shopItem4.Text = "";
            shopItem5.Text = "";
        }
    }
}
