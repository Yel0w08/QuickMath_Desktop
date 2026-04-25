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
        public int total = 0;
        public Shop()
        {
            InitializeComponent();
            ShopItems_HideList();
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
                ShopItems_ShowList(2);
                //shopItem1.ForeColor = Color.Blue;
                //shopItem2.ForeColor = Color.Orange;
                shopItem1.Text = "Hard Difficulty for addition 5 ∑∑";
                shopItem2.Text = "Insane Difficulty for addition 5 ∑∑";
            }
            else if (Shop_Select_Category.SelectedItem.ToString() == "Special")
            {

                ShopItems_ShowList(2);
                ShopItems_ClearList();
                shopItem1.Text = "Red Star";
                shopItem2.Text = "Blu Star";

            }
            else
            {
                ShopItems_ClearList();
            }

            UpdateCart();
        }
        void ShopItems_ClearList()
        {
            shopItem1.Text = "";
            shopItem2.Text = "";
            shopItem3.Text = "";
            shopItem4.Text = "";
            shopItem5.Text = "";
            shopItem1.ForeColor = Color.Black;
            shopItem2.ForeColor = Color.Black;
            shopItem3.ForeColor = Color.Black;
            shopItem4.ForeColor = Color.Black;
            shopItem5.ForeColor = Color.Black;

        }
        void ShopItems_HideList()
        {
            shopItem1.Visible = false;
            shopItem2.Visible = false;
            shopItem3.Visible = false;
            shopItem4.Visible = false;
            shopItem5.Visible = false;

        }
        void ShopItems_ShowList(int ItemShowNumber)
        {
            if (ItemShowNumber >= 1) { shopItem1.Visible = true; }
            if (ItemShowNumber >= 2) { shopItem1.Visible = true; shopItem2.Visible = true; }
            if (ItemShowNumber >= 3) { shopItem1.Visible = true; shopItem2.Visible = true; shopItem3.Visible = true; }
            if (ItemShowNumber >= 4) { shopItem1.Visible = true; shopItem2.Visible = true; shopItem3.Visible = true; shopItem4.Visible = true; }
            if (ItemShowNumber >= 5) { shopItem1.Visible = true; shopItem2.Visible = true; shopItem3.Visible = true; shopItem4.Visible = true; shopItem5.Visible = true; }

        }

        private void shopItem1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCart();
        }
        void UpdateCart()
        {
            CartListBox.Items.Clear();
            total = 0;
            if (shopItem1.Checked == true) { CartListBox.Items.Add(shopItem1.Text); total += 0; }
            if (shopItem2.Checked == true) { CartListBox.Items.Add(shopItem2.Text); total += 0; }
            if (shopItem3.Checked == true) {  CartListBox.Items.Add(shopItem3.Text); total += 0; }
            if (shopItem4.Checked == true) { CartListBox.Items.Add(shopItem4.Text); total += 0; }
            if (shopItem5.Checked == true) { CartListBox.Items.Add(shopItem5.Text); total += 0; }
        }

        private void CartListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void shopItem2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCart();
        }

        private void shopItem3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCart();
        }

        private void shopItem4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCart();
        }

        private void shopItem5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCart();
        }
    }
}
