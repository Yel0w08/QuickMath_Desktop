using System.Text.Json;

namespace QuickMath
{
    public partial class RegisterForm : Form
    {
        public int totalNumberOfMathDone = 0;
        public int totalNumberOfAdditionDone = 0;
        public int totalNumberOfSubtractionDone = 0;
        public string UserData_UserName = "Player";
        float Coins = 0;

        public RegisterForm()
        {
            InitializeComponent();
            UsernameIntupt.Text = Environment.UserName;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            UserData_UserName = UsernameIntupt.Text;
            SaveDataLocal();
            this.Close();
        }

        private void SkipRegisterButton_Click(object sender, EventArgs e)
        {
            UserData_UserName = Environment.UserName;
            SaveDataLocal();
            this.Close();
        }

        private void SaveDataLocal()
        {
            var SaveData = new
            {
                XP = 0,
                UserName = UserData_UserName,
                coins = Coins,
                Difficulty_Insane_addition_unlocked = false,
                Difficulty_Hard_addition_unlocked = false,
                Difficulty_Insane_subtraction_unlocked = false,
                Difficulty_Hard_subtraction_unlocked = false,
                totalNumberOfMathDone = totalNumberOfMathDone,
                totalNumberOfAdditionDone = totalNumberOfAdditionDone,
                totalNumberOfSubtractionDone = totalNumberOfSubtractionDone,
                RedStarNumber = 0,
                BlueStarNumber = 0,
                YellowStarNumber = 0,
                PurpleStarNumber = 0,
                DarkMatterNumber = 0,
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(SaveData, options);
            File.WriteAllText(FileConfig.SaveFileName, jsonString);
        }

        // Designer-wired empty handlers
        private void label1_Click(object sender, EventArgs e) { }
        private void UsernameIntupt_TextChanged(object sender, EventArgs e) { }
        private void RegisterForm_Load(object sender, EventArgs e) { }
    }
}
