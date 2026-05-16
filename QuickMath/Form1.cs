using QuickMath.Service.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using QuickMath.Service;
namespace QuickMath
{
    public partial class QuickMath : Form
    {
        private int result;
        //public int XP; //public stuff
        //public float coins;
        //public int totalNumberOfMathDone;
        //public int totalNumberOfAdditionDone;
        //public int totalNumberOfSubtractionDone;
        //public bool Difficulty_Insane_addition_unlocked = false;
        //public bool Difficulty_Hard_addition_unlocked = false;
        //public bool Difficulty_Hard_subtraction_unlocked = false;
        //public bool Difficulty_Insane_subtraction_unlocked = false;
        //public int NumberOfXpGivenForAddition = 10;
        //public int NumberOfXpGivenForSubtraction = 10;//XP given for each correct answer for subtraction.
        private Data Data = new Data();


        public QuickMath()

        {
            Data.InitializeEverything();
            InitializeComponent();
#if DEBUG

            GrettingLabel.Text = $"QMX - DEBUG";
            GrettingLabel.ForeColor = Color.Red;
#endif



            
                AutoLoadUserData();
                InitializeGUI();

            
            CheckForUpdates();
        }


        private async Task CheckForUpdates()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "QuickMath-Desktop");

                string url = "https://api.github.com/repos/Yel0w08/QuickMath_Desktop/releases/latest";
                string json = await client.GetStringAsync(url);
                var doc = JsonDocument.Parse(json);
                string latestVersion = doc.RootElement.GetProperty("tag_name").GetString();

                if (latestVersion != AppInfo.Version)
                {
                    MessageBox.Show($"New version available : {latestVersion} !\nCurrent version : {AppInfo.Version}");
                }
            }
            catch { } // No Wifi ? allright then..
        }
        private void InitializeGUI()
        {
            GrettingLabel.Text = $"Welcome back {UserData_UserName} !"; GrettingLabel.ForeColor = Color.Black;


        }

        bool DoAwserIsCorect;
        string UserData_UserName;
        private void MathToResolveText_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TypeOfMath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeOfMath.SelectedItem == string.Empty) { }//why dont it work
            else if (TypeOfMath.SelectedItem == "more coming !") { MessageBox.Show("More math operations will be added in the future !"); TypeOfMath.Text = ""; } //tell the user more is coming if selecter more is coming....
            else if (TypeOfMath.SelectedItem.ToString() == "addition") { DifficultySelect.Show(); StartMath_addition(); }
            else if (TypeOfMath.SelectedItem.ToString() == "subtraction") { DifficultySelect.Show(); StartMath_subtraction(); }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //start_button
        {
            StartMath();

        }

        private void StartMath()
        {
            if (TypeOfMath.SelectedItem == string.Empty) { }//why dont it work
            else if (TypeOfMath.SelectedItem == "addition")
            {

                StartMath_addition();
                DifficultySelect.Enabled = true;

            }
            else if (TypeOfMath.SelectedItem == "subtraction")
            {

                StartMath_subtraction();
            }
            else if (TypeOfMath.SelectedItem == "multiplication")
            {
                LockGUI();

            }
            else if (TypeOfMath.SelectedItem == "division")
            {

                LockGUI();

            }
            else if (TypeOfMath.SelectedItem == null) { MessageBox.Show("Please select a math operation before starting !"); }
            else { MessageBox.Show("Please select a math operation before starting !"); }//to chekc if thez intput isint null 
        }

        public async Task StartMath_addition()
        {

            DifficultySelect.Enabled = true;
            int min_number_addition = 1;
            int max_number_addition = 100;



            if (DifficultySelect.SelectedItem == "medium")
            {
                min_number_addition = 1; max_number_addition = 100; Data.NumberOfXpGivenForAddition = 10; Data.coins += 1;
            }

            else if (DifficultySelect.SelectedItem == "easy")
            {
                min_number_addition = 1; max_number_addition = 50; Data.NumberOfXpGivenForAddition = 5; Data.coins += 0.5f;
            }

            else if (DifficultySelect.SelectedItem == "easy++")
            {
                min_number_addition = 1; max_number_addition = 10; Data.NumberOfXpGivenForAddition = 1; Data.coins += 0.25f;
            }

            else if (DifficultySelect.SelectedItem == "hard")
            {
                if (Data.Difficulty_Hard_addition_unlocked == false)
                {
                    MessageBox.Show("You need to unlock this difficulty in the shop first !");
                    DifficultySelect.SelectedItem = "medium";
                    return;
                }
                min_number_addition = 50; max_number_addition = 500; Data.NumberOfXpGivenForAddition = 20; Data.coins += 2;
            }

            else if (DifficultySelect.SelectedItem == "insane")
            {
                if (Data.Difficulty_Insane_addition_unlocked == false)
                {
                    MessageBox.Show("You need to unlock this difficulty in the shop first !");
                    DifficultySelect.SelectedItem = "medium";
                    return;
                }
                min_number_addition = 100; max_number_addition = 1000; Data.NumberOfXpGivenForAddition = 40; Data.coins += 4;
            }

            Random random = new Random();
            int random_1 = random.Next(min_number_addition, max_number_addition);
            int random_2 = random.Next(min_number_addition, max_number_addition);
            result = random_1 + random_2;
            MathToResolveText.Text = $"{random_1} + {random_2}";

            CheckAwser(result);











        }
        public async Task StartMath_subtraction()
        {

            DifficultySelect.Enabled = true;
            int min_number_addition = 1;
            int max_number_addition = 100;



            if (DifficultySelect.SelectedItem == "medium")
            {
                min_number_addition = 1; max_number_addition = 100; Data.NumberOfXpGivenForSubtraction = 15; Data.coins += 1.5f;
            }

            else if (DifficultySelect.SelectedItem == "easy")
            {
                min_number_addition = 1; max_number_addition = 50; Data.NumberOfXpGivenForSubtraction = 10; Data.coins += 1f;
            }

            else if (DifficultySelect.SelectedItem == "easy++")
            {
                min_number_addition = 1; max_number_addition = 10; Data.NumberOfXpGivenForSubtraction = 2; Data.coins += 0.5f;
            }

            else if (DifficultySelect.SelectedItem == "hard")
            {

                if (Data.Difficulty_Hard_subtraction_unlocked == false)
                {
                    MessageBox.Show("You need to unlock this difficulty in the shop first !");
                    DifficultySelect.SelectedItem = "medium (1 - 100)";
                    return;
                }
                min_number_addition = 50; max_number_addition = 500; Data.NumberOfXpGivenForSubtraction = 20; Data.coins += 2;
            }

            else if (DifficultySelect.SelectedItem == "insane")
            {
                if (Data.Difficulty_Insane_subtraction_unlocked == false)
                {
                    MessageBox.Show("You need to unlock this difficulty in the shop first !");
                    DifficultySelect.SelectedItem = "medium (1 - 100)";
                    return;
                }
                min_number_addition = 100; max_number_addition = 1000; Data.NumberOfXpGivenForSubtraction = 40; Data.coins += 4;
            }

            Random random = new Random();
            int random_1 = random.Next(min_number_addition, max_number_addition);
            int random_2 = random.Next(min_number_addition, max_number_addition);
            result = random_1 - random_2;
            MathToResolveText.Text = $"{random_1} - {random_2}";

            CheckAwser(result);
        }


        private void CheckAwser(int result)
        {
            if (MathUserIntupt.Text == result.ToString())
            {
                DoAwserIsCorect = true;
                Data.totalNumberOfMathDone++;
                if (TypeOfMath.SelectedItem.ToString() == "addition") { Data.totalNumberOfAdditionDone++; }
                else if (TypeOfMath.SelectedItem.ToString() == "subtraction") { Data.totalNumberOfSubtractionDone++; }
            }
        }



        void ResetGUI()
        {
            DifficultySelect.Enabled = false;


        }


        void ReLoadGUI()
        {

            XPpointLabel.Text = Data.XP.ToString();

            CoinsLabel.Text = Data.coins.ToString();
            saveUserData_Local();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            UnlockGUI();

        }

        private void saveUserData_Local()
        {
            var SaveData = new
            {
                XP = Data.XP,
                coins = Data.coins,
                UserName = UserData_UserName,
                totalNumberOfMathDone = Data.totalNumberOfMathDone,
                totalNumberOfSubtractionDone = Data.totalNumberOfSubtractionDone,
                totalNumberOfAdditionDone = Data.totalNumberOfAdditionDone

            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(SaveData, options);
            string fileName = "QuickMath_UserData.json";
            File.WriteAllText(fileName, jsonString);
        }

        void AutoLoadUserData()
        {
            string fileName = "QuickMath_UserData.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                var doc = JsonDocument.Parse(jsonString);

                if (doc.RootElement.TryGetProperty("XP", out var xpProp))
                    Data.XP = xpProp.GetInt32();

                if (doc.RootElement.TryGetProperty("coins", out var coinsProp))
                    Data.coins = coinsProp.GetSingle();

                if (doc.RootElement.TryGetProperty("UserName", out var userNameProp))
                    UserData_UserName = userNameProp.GetString();

                if (UserData_UserName == string.Empty || UserData_UserName == null)
                {
                    RegisterForm form2 = new RegisterForm();
                    form2.ShowDialog();
                    return;
                }

                if (doc.RootElement.TryGetProperty("Difficulty_Insane_addition_unlocked", out var insaneAdd))
                    Data.Difficulty_Insane_addition_unlocked = insaneAdd.GetBoolean();

                if (doc.RootElement.TryGetProperty("Difficulty_Hard_addition_unlocked", out var hardAdd))
                    Data.Difficulty_Hard_addition_unlocked = hardAdd.GetBoolean();

                if (doc.RootElement.TryGetProperty("Difficulty_Hard_subtraction_unlocked", out var hardSub))
                    Data.Difficulty_Hard_subtraction_unlocked = hardSub.GetBoolean();

                if (doc.RootElement.TryGetProperty("Difficulty_Insane_subtraction_unlocked", out var insaneSub))
                    Data.Difficulty_Insane_subtraction_unlocked = insaneSub.GetBoolean();

                if (doc.RootElement.TryGetProperty("totalNumberOfMathDone", out var totalMath))
                    Data.totalNumberOfMathDone = totalMath.GetInt32();

                if (doc.RootElement.TryGetProperty("totalNumberOfAdditionDone", out var totalAdd))
                    Data.totalNumberOfAdditionDone = totalAdd.GetInt32();

                if (doc.RootElement.TryGetProperty("totalNumberOfSubtractionDone", out var totalSub))
                    Data.totalNumberOfSubtractionDone = totalSub.GetInt32();

                InitializeGUI();
                ReLoadGUI();
            }
            else
            {
                RegisterForm form2 = new RegisterForm();
                form2.ShowDialog();
            }
        }

        private void MathUserIntupt_TextChanged(object sender, EventArgs e)
        {
            if (MathUserIntupt.Text == result.ToString())
            {
                DoAwserIsCorect = true;
                Data.XP += Data.NumberOfXpGivenForAddition;
                ReLoadGUI();
                MathUserIntupt.Text = string.Empty;


                if (TypeOfMath.SelectedItem.ToString() == "addition") StartMath_addition();
                else if (TypeOfMath.SelectedItem.ToString() == "subtraction") StartMath_subtraction();
            }
        }

        private void Verify_button_Click(object sender, EventArgs e)
        {
            CheckAwser(result);
        }

        private void MinimumRandomNumber_intupt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeOfMath.SelectedItem?.ToString() == "addition") StartMath_addition();
            else if (TypeOfMath.SelectedItem?.ToString() == "subtraction") StartMath_subtraction();
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
    }
}
