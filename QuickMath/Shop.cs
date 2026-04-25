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
                
            }
            else if (Shop_Select_Category.SelectedItem.ToString() == "Special")
            {
              
            }
        }
    }
}
