using QuickMath.Services.Debug;
using QuickMath.Services.DataManager;

namespace QuickMath
{
    public partial class Shop : Form
    {
        public int total = 0;
        public string UserData_UserName;
        public int XP;
        public float userCoins;
        public bool Difficulty_Insane_addition_unlocked;
        public bool Difficulty_Hard_addition_unlocked;
        public bool Difficulty_Insane_subtraction_unlocked;
        public bool Difficulty_Hard_subtraction_unlocked;
        public int RedStarNumber;
        public int BlueStarNumber;
        public int YellowStarNumber;
        public int PurpleStarNumber;
        public int DarkMatterNumber;

        // Stats totals (shared with Form1 for save/load consistency)
        public int totalNumberOfMathDone;
        public int totalNumberOfAdditionDone;
        public int totalNumberOfSubtractionDone;

        public Shop()
        {
            InitializeComponent();
            ShopItems_HideList();
            ShopItems_ClearList();

            AutoLoadUserData();
            ReLoadGUI();

            DebugService.Log("Shop opened");
        }

        public class ShopItem
        {

            public string Name { get; set; } = "";
            public int Price { get; set; }
            public string Description { get; set; } = "";
        }

        // ── Category Selection ──────────────────────────────────────────

        private void Shop_Select_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = Shop_Select_Category.SelectedItem?.ToString();

            if (category == "Difficulty")
            {
                ShopItems_ClearList();
                ShopItems_ShowList(2);

                if (Difficulty_Hard_addition_unlocked)
                {
                    shopItem1.ForeColor = Color.Green;
                    shopItem1.Text = "Hard Difficulty for addition (Owned)";
                    shopItem1.Enabled = false;
                }
                else
                {
                    shopItem1.Text = "Hard Difficulty for addition";
                    shopItem2.Enabled = true;
                }

                if (Difficulty_Insane_addition_unlocked)
                {
                    shopItem2.ForeColor = Color.Green;
                    shopItem2.Text = "Insane Difficulty for addition (Owned)";
                    shopItem2.Enabled = false;
                }
                else
                {
                    shopItem2.Enabled = true;
                    shopItem2.Text = "Insane Difficulty for addition";
                }
            }
            else if (category == "Stars")
            {
                if (XP < ShopConfig.StarsMinXp)
                {
                    int needed = ShopConfig.StarsMinXp - XP;
                    MessageBox.Show($"You need at least {ShopConfig.StarsMinXp} XP to unlock Stars. You need {needed} more XP.");
                }
                else
                {
                    ShopItems_ShowList(2);
                    ShopItems_ClearList();
                    shopItem1.Text = "Red Star";
                    shopItem2.Text = "Blue Star";
                    shopItem3.Text = "Yellow Star";
                    shopItem4.Text = "Purple Star";
                    shopItem5.Text = "Dark Matter";
                }
            }
            else
            {
                ShopItems_ClearList();
            }

            UpdateCart();
        }

        // ── Shop Item Visibility ────────────────────────────────────────

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

        void ShopItems_ResetChecked()
        {
            shopItem1.Checked = false;
            shopItem2.Checked = false;
            shopItem3.Checked = false;
            shopItem4.Checked = false;
            shopItem5.Checked = false;
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
            if (ItemShowNumber >= 1) shopItem1.Visible = true;
            if (ItemShowNumber >= 2) { shopItem1.Visible = true; shopItem2.Visible = true; }
            if (ItemShowNumber >= 3) { shopItem1.Visible = true; shopItem2.Visible = true; shopItem3.Visible = true; }
            if (ItemShowNumber >= 4) { shopItem1.Visible = true; shopItem2.Visible = true; shopItem3.Visible = true; shopItem4.Visible = true; }
            if (ItemShowNumber >= 5) { shopItem1.Visible = true; shopItem2.Visible = true; shopItem3.Visible = true; shopItem4.Visible = true; shopItem5.Visible = true; }
        }

        // ── Cart System ─────────────────────────────────────────────────

        void UpdateCart()
        {
            CartListBox.Items.Clear();
            total = 0;

            AddToCartIfChecked(shopItem1);
            AddToCartIfChecked(shopItem2);
            AddToCartIfChecked(shopItem3);
            AddToCartIfChecked(shopItem4);
            AddToCartIfChecked(shopItem5);

            ReLoadGUI();
        }

        void AddToCartIfChecked(CheckBox item)
        {
            if (item.Checked)
            {
                int price = GetItemPrice(item.Text);
                CartListBox.Items.Add($"{item.Text} [{price}]");
                total += price;
            }
        }

        // ── Item Prices ─────────────────────────────────────────────────

        static int GetItemPrice(string itemName)
        {
            return itemName switch
            {
                "Hard Difficulty for addition" => ShopConfig.HardAdditionPrice,
                "Insane Difficulty for addition" => ShopConfig.InsaneAdditionPrice,
                "Hard Difficulty for subtraction" => ShopConfig.HardSubtractionPrice,
                "Insane Difficulty for subtraction" => ShopConfig.InsaneSubtractionPrice,
                "Red Star" => ShopConfig.RedStarPrice,
                "Blue Star" => ShopConfig.BlueStarPrice,
                "Yellow Star" => ShopConfig.YellowStarPrice,
                "Purple Star" => ShopConfig.PurpleStarPrice,
                "Dark Matter" => ShopConfig.DarkMatterPrice,
                _ => 0
            };
        }

        // ── Purchase ────────────────────────────────────────────────────

        private void Shop_buy_button(object sender, EventArgs e)
        {
            BuyTheCart(total);
        }

        void BuyTheCart(int total)
        {
            if (total == 0)
            {
                MessageBox.Show("Your cart is empty!");
                return;
            }

            if (userCoins < total)
            {
                int needed = total - (int)userCoins;
                MessageBox.Show($"Not enough ∑∑! You need {needed} more ∑∑");
                return;
            }

            userCoins -= total;

            // Process each checked item
            if (shopItem1.Checked)
            {
                if (shopItem1.Text == "Hard Difficulty for addition") Difficulty_Hard_addition_unlocked = true;
                else if (shopItem1.Text == "Hard Difficulty for subtraction") Difficulty_Hard_subtraction_unlocked = true;
                else if (shopItem1.Text == "Red Star") RedStarNumber++;
                else if (shopItem1.Text == "Blue Star") BlueStarNumber++;
                else if (shopItem1.Text == "Yellow Star") YellowStarNumber++;
                else if (shopItem1.Text == "Purple Star") PurpleStarNumber++;
                else if (shopItem1.Text == "Dark Matter") DarkMatterNumber++;
            }

            if (shopItem2.Checked)
            {
                if (shopItem2.Text == "Insane Difficulty for addition") Difficulty_Insane_addition_unlocked = true;
                else if (shopItem2.Text == "Insane Difficulty for subtraction") Difficulty_Insane_subtraction_unlocked = true;
                else if (shopItem2.Text == "Red Star") RedStarNumber++;
                else if (shopItem2.Text == "Blue Star") BlueStarNumber++;
                else if (shopItem2.Text == "Yellow Star") YellowStarNumber++;
                else if (shopItem2.Text == "Purple Star") PurpleStarNumber++;
                else if (shopItem2.Text == "Dark Matter") DarkMatterNumber++;
            }

            if (shopItem3.Checked)
            {
                if (shopItem3.Text == "Red Star") RedStarNumber++;
                else if (shopItem3.Text == "Blue Star") BlueStarNumber++;
                else if (shopItem3.Text == "Yellow Star") YellowStarNumber++;
                else if (shopItem3.Text == "Purple Star") PurpleStarNumber++;
                else if (shopItem3.Text == "Dark Matter") DarkMatterNumber++;
            }

            if (shopItem4.Checked)
            {
                if (shopItem4.Text == "Red Star") RedStarNumber++;
                else if (shopItem4.Text == "Blue Star") BlueStarNumber++;
                else if (shopItem4.Text == "Yellow Star") YellowStarNumber++;
                else if (shopItem4.Text == "Purple Star") PurpleStarNumber++;
                else if (shopItem4.Text == "Dark Matter") DarkMatterNumber++;
            }

            if (shopItem5.Checked)
            {
                if (shopItem5.Text == "Red Star") RedStarNumber++;
                else if (shopItem5.Text == "Blue Star") BlueStarNumber++;
                else if (shopItem5.Text == "Yellow Star") YellowStarNumber++;
                else if (shopItem5.Text == "Purple Star") PurpleStarNumber++;
                else if (shopItem5.Text == "Dark Matter") DarkMatterNumber++;
            }

            MessageBox.Show($"You bought {CartListBox.Items.Count} items for a total of {total} ∑∑!");
           DebugService.Log($"Shop purchase — items={CartListBox.Items.Count} total={total}");
            saveUserData_Local();
            CartListBox.Items.Clear();
            ShopItems_ResetChecked();
            ReLoadGUI();
            AutoLoadUserData();
        }

        // ── CheckBox Events ─────────────────────────────────────────────

        private void shopItem1_CheckedChanged(object sender, EventArgs e) { UpdateCart(); }
        private void shopItem2_CheckedChanged_1(object sender, EventArgs e) { UpdateCart(); }

        // ── GUI ─────────────────────────────────────────────────────────

        void ReLoadGUI()
        {
            Total_Shop_Label.Text = $"Total = {total} ∑∑";
            MoneyInAccountLabel.Text = $"Money = {userCoins} ∑∑";
        }

        // ── Save / Load ─────────────────────────────────────────────────

        void AutoLoadUserData()
        {
            var data = DataManagerService.LoadOrCreate(FileConfig.SaveFileName);

            UserData_UserName = data.UserName;

            if (string.IsNullOrEmpty(UserData_UserName))
            {
                RegisterForm form2 = new RegisterForm();
                form2.ShowDialog();
                return;
            }

            XP = data.XP;
            userCoins = data.coins;
            Difficulty_Insane_addition_unlocked = data.Difficulty_Insane_addition_unlocked;
            Difficulty_Hard_addition_unlocked = data.Difficulty_Hard_addition_unlocked;
            Difficulty_Insane_subtraction_unlocked = data.Difficulty_Insane_subtraction_unlocked;
            Difficulty_Hard_subtraction_unlocked = data.Difficulty_Hard_subtraction_unlocked;
            RedStarNumber = data.RedStarNumber;
            BlueStarNumber = data.BlueStarNumber;
            YellowStarNumber = data.YellowStarNumber;
            PurpleStarNumber = data.PurpleStarNumber;
            DarkMatterNumber = data.DarkMatterNumber;
            totalNumberOfMathDone = data.totalNumberOfMathDone;
            totalNumberOfAdditionDone = data.totalNumberOfAdditionDone;
            totalNumberOfSubtractionDone = data.totalNumberOfSubtractionDone;

            ReLoadGUI();
        }

        private void saveUserData_Local()
        {
            var data = new UserDataModel
            {
                XP = XP,
                coins = userCoins,
                UserName = UserData_UserName,
                Difficulty_Insane_addition_unlocked = Difficulty_Insane_addition_unlocked,
                Difficulty_Hard_addition_unlocked = Difficulty_Hard_addition_unlocked,
                Difficulty_Insane_subtraction_unlocked = Difficulty_Insane_subtraction_unlocked,
                Difficulty_Hard_subtraction_unlocked = Difficulty_Hard_subtraction_unlocked,
                totalNumberOfMathDone = totalNumberOfMathDone,
                totalNumberOfAdditionDone = totalNumberOfAdditionDone,
                totalNumberOfSubtractionDone = totalNumberOfSubtractionDone,
                RedStarNumber = RedStarNumber,
                BlueStarNumber = BlueStarNumber,
                YellowStarNumber = YellowStarNumber,
                PurpleStarNumber = PurpleStarNumber,
                DarkMatterNumber = DarkMatterNumber
            };

            DataManagerService.Save(data, FileConfig.SaveFileName);
            DebugService.Log($"Shop saved — coins={userCoins} redStar={RedStarNumber}");
        }

        // Designer-wired empty handlers
        private void CartListBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Shop_Load(object sender, EventArgs e) { }
    }
}
