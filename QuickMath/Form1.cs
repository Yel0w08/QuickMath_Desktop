using QuickMath.Services.Debug;
using System.Text.Json;

namespace QuickMath
{
    public partial class QuickMath : Form
    {
        private int result;

        public int XP;
        public float coins;
        public int totalNumberOfMathDone;
        public int totalNumberOfAdditionDone;
        public int totalNumberOfSubtractionDone;

        public bool Difficulty_Insane_addition_unlocked = false;
        public bool Difficulty_Hard_addition_unlocked = false;
        public bool Difficulty_Hard_subtraction_unlocked = false;
        public bool Difficulty_Insane_subtraction_unlocked = false;

        public int NumberOfXpGivenForAddition = 10;
        public int NumberOfXpGivenForSubtraction = 10;

        // Star cosmetics (shared with Shop for save/load consistency)
        public int RedStarNumber;
        public int BlueStarNumber;
        public int YellowStarNumber;
        public int PurpleStarNumber;
        public int DarkMatterNumber;

        public QuickMath()
        {
            InitializeComponent();

            var debugService = new DebugService(this);

            AutoLoadUserData();
            InitializeGUI();
            CheckForUpdates();

           DebugService.Log("App started");
        }

        // ── Update Checker ──────────────────────────────────────────────

        private async Task CheckForUpdates()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", FileConfig.GitHubUserAgent);

                string url = $"https://api.github.com/repos/{FileConfig.GitHubRepo}/releases/latest";
                string json = await client.GetStringAsync(url);
                var doc = JsonDocument.Parse(json);
                string latestVersion = doc.RootElement.GetProperty("tag_name").GetString();

                if (latestVersion != AppInfo.Version)
                {
                    MessageBox.Show(
                        $"New version available: {latestVersion}!\nCurrent version: {AppInfo.Version}"
                    );
                }
            }
            catch { }
        }

        // ── GUI Init ────────────────────────────────────────────────────

        private string UserData_UserName;

        private void InitializeGUI()
        {
            GrettingLabel.Text = $"Welcome back {UserData_UserName}!";
            GrettingLabel.ForeColor = Color.Black;
        }

        // ── Math Type Selection ─────────────────────────────────────────

        private void TypeOfMath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeOfMath.SelectedItem == string.Empty) { }
            else if (TypeOfMath.SelectedItem == "more coming !")
            {
                MessageBox.Show("More math operations will be added in the future!");
                TypeOfMath.Text = "";
            }
            else if (TypeOfMath.SelectedItem.ToString() == "addition")
            {
                DifficultySelect.Show();
                StartMath_addition();
            }
            else if (TypeOfMath.SelectedItem.ToString() == "subtraction")
            {
                DifficultySelect.Show();
                StartMath_subtraction();
            }
        }

        private void StartMath()
        {
            if (TypeOfMath.SelectedItem is null)
            {
                MessageBox.Show("Please select a math operation before starting!");
                return;
            }

            string selected = TypeOfMath.SelectedItem.ToString();

            if (selected == "addition")
            {
                StartMath_addition();
                DifficultySelect.Enabled = true;
            }
            else if (selected == "subtraction")
            {
                StartMath_subtraction();
            }
            else if (selected == "multiplication" || selected == "division")
            {
                LockGUI();
            }
            else
            {
                MessageBox.Show("Please select a math operation before starting!");
            }
        }

        // ── Addition ────────────────────────────────────────────────────

        public async Task StartMath_addition()
        {
            DebugService.Log("Starting addition math problem...");

            DifficultySelect.Enabled = true;

            var level = GetAdditionLevel(DifficultySelect.SelectedItem?.ToString());

            if (level.min == 0 && level.max == 0) return;

            Random random = new Random();
            int random_1 = random.Next(level.min, level.max + 1);
            int random_2 = random.Next(level.min, level.max + 1);
            result = random_1 + random_2;

            NumberOfXpGivenForAddition = level.xp;
            coins += level.coins;

            MathToResolveText.Text = $"{random_1} + {random_2}";
            CheckAnswer(result);

           DebugService.Log($"Addition problem: {random_1}+{random_2} diff={DifficultySelect.SelectedItem}");
        }

        private (int min, int max, int xp, float coins) GetAdditionLevel(string difficulty)
        {
            return difficulty switch
            {
                "easy++" => AdditionConfig.Levels[Difficulty.EasyPlus],
                "easy" => AdditionConfig.Levels[Difficulty.Easy],
                "medium" => AdditionConfig.Levels[Difficulty.Medium],
                "hard" when Difficulty_Hard_addition_unlocked => AdditionConfig.Levels[Difficulty.Hard],
                "hard" => ShowLocked("addition"),
                "insane" when Difficulty_Insane_addition_unlocked => AdditionConfig.Levels[Difficulty.Insane],
                "insane" => ShowLocked("addition"),
                _ => AdditionConfig.Levels[Difficulty.Medium]
            };
        }

        // ── Subtraction ─────────────────────────────────────────────────

        public async Task StartMath_subtraction()
        {
            DebugService.Log("Starting subtraction math problem...");

            DifficultySelect.Enabled = true;

            var level = GetSubtractionLevel(DifficultySelect.SelectedItem?.ToString());

            if (level.min == 0 && level.max == 0) return;

            Random random = new Random();
            int random_1 = random.Next(level.min, level.max + 1);
            int random_2 = random.Next(level.min, level.max + 1);
            result = random_1 - random_2;

            NumberOfXpGivenForSubtraction = level.xp;
            coins += level.coins;

            MathToResolveText.Text = $"{random_1} - {random_2}";
            CheckAnswer(result);
        }

        private (int min, int max, int xp, float coins) GetSubtractionLevel(string difficulty)
        {
            return difficulty switch
            {
                "easy++" => SubtractionConfig.Levels[Difficulty.EasyPlus],
                "easy" => SubtractionConfig.Levels[Difficulty.Easy],
                "medium" => SubtractionConfig.Levels[Difficulty.Medium],
                "hard" when Difficulty_Hard_subtraction_unlocked => SubtractionConfig.Levels[Difficulty.Hard],
                "hard" => ShowLocked("subtraction"),
                "insane" when Difficulty_Insane_subtraction_unlocked => SubtractionConfig.Levels[Difficulty.Insane],
                "insane" => ShowLocked("subtraction"),
                _ => SubtractionConfig.Levels[Difficulty.Medium]
            };
        }

        private (int min, int max, int xp, float coins) ShowLocked(string operation)
        {
            MessageBox.Show($"You need to unlock this difficulty in the shop first!");
            DifficultySelect.SelectedItem = "medium";
            return (0, 0, 0, 0);
        }

        // ── Answer Checking ─────────────────────────────────────────────

        private void CheckAnswer(int correctResult)
        {
            if (MathUserIntupt.Text == correctResult.ToString())
            {
                totalNumberOfMathDone++;

                string selected = TypeOfMath.SelectedItem?.ToString();
                if (selected == "addition")
                    totalNumberOfAdditionDone++;
                else if (selected == "subtraction")
                    totalNumberOfSubtractionDone++;
            }
        }

        // ── GUI Controls ────────────────────────────────────────────────

        void ResetGUI()
        {
            DifficultySelect.Enabled = false;
        }

        public void ReLoadGUI()
        {
            XPpointLabel.Text = XP.ToString();
            CoinsLabel.Text = coins.ToString();
            saveUserData_Local_form1();
        }

        private void UnlockGUI()
        {
            TypeOfMath.Enabled = true;
            DifficultySelect.Enabled = true;
        }

        private void LockGUI()
        {
            TypeOfMath.Enabled = false;
            DifficultySelect.Enabled = false;
        }

        // ── Event Handlers (Designer-wired) ─────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            DebugService.Log("Main Form loaded");
        }

        private void MathUserIntupt_TextChanged(object sender, EventArgs e)
        {
            if (MathUserIntupt.Text == result.ToString())
            {
                XP += NumberOfXpGivenForAddition;
               DebugService.Log($"Correct answer! XP={XP} coins={coins}");
                ReLoadGUI();
                MathUserIntupt.Text = string.Empty;

                string selected = TypeOfMath.SelectedItem?.ToString();
                if (selected == "addition")
                    StartMath_addition();
                else if (selected == "subtraction")
                    StartMath_subtraction();
            }
        }

        private void Verify_button_Click(object sender, EventArgs e)
        {
            CheckAnswer(result);
        }

        private void Difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = TypeOfMath.SelectedItem?.ToString();
            if (selected == "addition")
                StartMath_addition();
            else if (selected == "subtraction")
                StartMath_subtraction();
        }

        private void OpenShopButton_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.ShowDialog();
            AutoLoadUserData();
        }

        private void statistic_button_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics();
            statistics.ShowDialog();
            AutoLoadUserData();
        }

        private void ReSetButton_Click(object sender, EventArgs e)
        {
            StartMath();
        }

        // Designer-wired empty handlers (must keep for designer compatibility)
        private void MathToResolveText_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void MinimumRandomNumber_intupt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        // ── Save / Load ─────────────────────────────────────────────────

        public void saveUserData_Local_form1()
        {
            var SaveData = new
            {
                XP,
                coins,
                UserName = UserData_UserName,
                Difficulty_Insane_addition_unlocked,
                Difficulty_Hard_addition_unlocked,
                Difficulty_Insane_subtraction_unlocked,
                Difficulty_Hard_subtraction_unlocked,
                totalNumberOfMathDone,
                totalNumberOfAdditionDone,
                totalNumberOfSubtractionDone,
                RedStarNumber,
                BlueStarNumber,
                YellowStarNumber,
                PurpleStarNumber,
                DarkMatterNumber
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(SaveData, options);
            File.WriteAllText(FileConfig.SaveFileName, jsonString);
           DebugService.Log($"User data saved — XP={XP} coins={coins} math={totalNumberOfMathDone}");
            DebugService.Log("User data saved");
        }

        public void AutoLoadUserData()
        {
            DebugService.Log("Loading user data...");

            if (!File.Exists(FileConfig.SaveFileName))
            {
                RegisterForm form2 = new RegisterForm();
                form2.ShowDialog();
                DebugService.Log("User data file not found, showing registration form");
                return;
            }

            string jsonString = File.ReadAllText(FileConfig.SaveFileName);
            var doc = JsonDocument.Parse(jsonString);

            if (doc.RootElement.TryGetProperty("XP", out var xpProp))
                XP = xpProp.GetInt32();

            if (doc.RootElement.TryGetProperty("coins", out var coinsProp))
                coins = coinsProp.GetSingle();

            if (doc.RootElement.TryGetProperty("UserName", out var userNameProp))
                UserData_UserName = userNameProp.GetString();

           DebugService.Log($"User data loaded — user: {UserData_UserName}");

            if (string.IsNullOrEmpty(UserData_UserName))
            {
                RegisterForm form2 = new RegisterForm();
                form2.ShowDialog();
                return;
            }

            if (doc.RootElement.TryGetProperty("Difficulty_Insane_addition_unlocked", out var insaneAdd))
                Difficulty_Insane_addition_unlocked = insaneAdd.GetBoolean();

            if (doc.RootElement.TryGetProperty("Difficulty_Hard_addition_unlocked", out var hardAdd))
                Difficulty_Hard_addition_unlocked = hardAdd.GetBoolean();

            if (doc.RootElement.TryGetProperty("Difficulty_Hard_subtraction_unlocked", out var hardSub))
                Difficulty_Hard_subtraction_unlocked = hardSub.GetBoolean();

            if (doc.RootElement.TryGetProperty("Difficulty_Insane_subtraction_unlocked", out var insaneSub))
                Difficulty_Insane_subtraction_unlocked = insaneSub.GetBoolean();

            if (doc.RootElement.TryGetProperty("totalNumberOfMathDone", out var totalMath))
                totalNumberOfMathDone = totalMath.GetInt32();

            if (doc.RootElement.TryGetProperty("totalNumberOfAdditionDone", out var totalAdd))
                totalNumberOfAdditionDone = totalAdd.GetInt32();

            if (doc.RootElement.TryGetProperty("totalNumberOfSubtractionDone", out var totalSub))
                totalNumberOfSubtractionDone = totalSub.GetInt32();

            if (doc.RootElement.TryGetProperty("RedStarNumber", out var redStar))
                RedStarNumber = redStar.GetInt32();

            if (doc.RootElement.TryGetProperty("BlueStarNumber", out var blueStar))
                BlueStarNumber = blueStar.GetInt32();

            if (doc.RootElement.TryGetProperty("YellowStarNumber", out var yellowStar))
                YellowStarNumber = yellowStar.GetInt32();

            if (doc.RootElement.TryGetProperty("PurpleStarNumber", out var purpleStar))
                PurpleStarNumber = purpleStar.GetInt32();

            if (doc.RootElement.TryGetProperty("DarkMatterNumber", out var darkMatter))
                DarkMatterNumber = darkMatter.GetInt32();

            DebugService.Log("User data loaded successfully");
            InitializeGUI();
            ReLoadGUI();
        }
    }
}
