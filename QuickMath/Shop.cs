using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace QuickMath
{


    public partial class Shop : Form
    {
        public int total = 0;
        public string UserData_UserName;
        public int XP;
        public float userCoins;
        public Shop()
        {
            InitializeComponent();
            ShopItems_HideList();
            ShopItems_ClearList();
            AutoLoadUserData();
            ReLoadGUI();
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
                shopItem1.Text = "Hard Difficulty for addition";
                shopItem2.Text = "Insane Difficulty for addition";
            }
            else if (Shop_Select_Category.SelectedItem.ToString() == "Stars")
                if (XP <= 100)
                { 
                    MessageBox.Show("You need at least 100 XP to unlock Stars, you need at least " + (100 - XP) + " more XP.");
                    Shop_Select_Category.Items.Remove("Stars");
                    Shop_Select_Category.Items.Add("Stars");
                }
            else if (XP >= 100)
                {

                    {

                        ShopItems_ShowList(2);
                        ShopItems_ClearList();
                        shopItem1.Text = "Red Star";
                        shopItem2.Text = "Blu Star";
                        shopItem3.Text = "Yellow Star";
                        shopItem4.Text = "Purpule Star";
                        shopItem5.Text = "Dark Matter";


                    }
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

            if (shopItem1.Checked == true) { CartListBox.Items.Add(shopItem1.Text); total += GetItemPrice(shopItem1.Text); }
            if (shopItem2.Checked == true) { CartListBox.Items.Add(shopItem2.Text); total += GetItemPrice(shopItem2.Text); }
            if (shopItem3.Checked == true) { CartListBox.Items.Add(shopItem3.Text); total += GetItemPrice(shopItem3.Text); }
            if (shopItem4.Checked == true) { CartListBox.Items.Add(shopItem4.Text); total += GetItemPrice(shopItem4.Text); }
            if (shopItem5.Checked == true) { CartListBox.Items.Add(shopItem5.Text); total += GetItemPrice(shopItem5.Text); }
            ReLoadGUI();
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

        private void Shop_Load(object sender, EventArgs e)
        {

        }
        void AutoLoadUserData()
        {
            string fileName = "QuickMath_UserData.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                var doc = JsonDocument.Parse(jsonString);
                XP = doc.RootElement.GetProperty("XP").GetInt32();
                userCoins = doc.RootElement.GetProperty("coins").GetInt32();
                UserData_UserName = doc.RootElement.GetProperty("UserName").GetString();
                ReLoadGUI();
            }
            
        }
        void ReLoadGUI()
        {
            Total_Shop_Label.Text = "Total = " + total.ToString();
            MoneyInAccountLabel.Text = "Money = " + userCoins.ToString() + " ∑∑";
        }

private Dictionary<string, int> itemPrices = new Dictionary<string, int>
{
    { "Hard Difficulty for addition", 5 },
    { "Insane Difficulty for addition", 10 },
    { "Red Star", 100 },
    { "Blu Star", 100 },
    { "Yellow Star", 150 },
    { "Purple Star", 150 },
    { "Dark Matter", 1000 },
};

    int GetItemPrice(string itemName)
        {
            if (itemPrices.ContainsKey(itemName))
            return itemPrices[itemName];
            return 0;
        }
    }
}
