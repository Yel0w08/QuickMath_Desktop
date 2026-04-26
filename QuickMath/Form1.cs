using System.Text.Json;

namespace QuickMath
{
    public partial class QuickMath : Form
    {
        private int result;
        public int XP; //public stuff
        public float coins;
        public int totalNumberOfMathDone;
        public int totalNumberOfAdditionDone;
        public int totalNumberOfSubtractionDone;
        public bool DebugMode = false; // turn thath shi off before sending it to the prod!!
        public bool Difficulty_Insane_addition_unlocked = false;
        public bool Difficulty_Hard_addition_unlocked = false;

        public int NumberOfXpGivenForAddition = 10; //XP given for each correct answer for addition.



        public QuickMath()

        {
            InitializeComponent();
            if (DebugMode == true)
            {
                GrettingLabel.Text = $"DEBUG MODE ON | Saves are diabled";
                GrettingLabel.ForeColor = Color.Red;

            }
            else
            {
                AutoLoadUserData();
                InitializeGUI();

            }
            ResetGUI();

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
            else if (TypeOfMath.SelectedItem.ToString() == "addition") { DifficultySelect.Show(); }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //start_button
        {



            if (TypeOfMath.SelectedItem == string.Empty) { }//why dont it work
            else if (TypeOfMath.SelectedItem == "addition")
            {
                LockGUI();
                StartMath_addition();

            }
            else if (TypeOfMath.SelectedItem == "subtraction")
            {
                LockGUI();
                //StartMath_subtraction();
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

            int min_number_addition = 1;
            int max_number_addition = 100;



            if (DifficultySelect.SelectedItem == "medium (1 - 100)")
            {
                min_number_addition = 1; max_number_addition = 100; NumberOfXpGivenForAddition = 10; coins += 1;
            }

            else if (DifficultySelect.SelectedItem == "easy (1 - 50)")
            {
                min_number_addition = 1; max_number_addition = 50; NumberOfXpGivenForAddition = 5; coins += 5 / 10;
            }

            else if (DifficultySelect.SelectedItem == "easy++ (1 - 10)")
            {
                min_number_addition = 1; max_number_addition = 10; NumberOfXpGivenForAddition = 1; coins += 5 / 20;
            }

            else if (DifficultySelect.SelectedItem == "hard (50 - 500)")
            {
                if (Difficulty_Hard_addition_unlocked == false)
                {
                    MessageBox.Show("You need to unlock this difficulty in the shop first !");
                    DifficultySelect.SelectedItem = "medium (1 - 100)";
                    return;
                }
                min_number_addition = 50; max_number_addition = 500; NumberOfXpGivenForAddition = 20; coins += 2;
            }

            else if (DifficultySelect.SelectedItem == "insane (100 - 1000)")
            {
                if (Difficulty_Insane_addition_unlocked == false)
                {
                    MessageBox.Show("You need to unlock this difficulty in the shop first !");
                    DifficultySelect.SelectedItem = "medium (1 - 100)";
                    return;
                }
                min_number_addition = 100; max_number_addition = 1000; NumberOfXpGivenForAddition = 40; coins += 4;
            }

            Random random = new Random();
            int random_1 = random.Next(min_number_addition, max_number_addition);
            int random_2 = random.Next(min_number_addition, max_number_addition);
            result = random_1 + random_2;
            MathToResolveText.Text = $"{random_1} + {random_2}";

            CheckAwser(result);











        }



        private void CheckAwser(int result)
        {
            if (MathUserIntupt.Text == result.ToString())
            {
                DoAwserIsCorect = true;
                totalNumberOfMathDone++;

            }
        }



        void ResetGUI()
        {
            DifficultySelect.Hide();


        }


        void ReLoadGUI()
        {

            XPpointLabel.Text = XP.ToString();

            CoinsLabel.Text = coins.ToString();
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
                XP = XP,
                coins = coins,
                UserName = UserData_UserName,
                Difficulty_Insane_addition_unlocked = Difficulty_Insane_addition_unlocked,
                Difficulty_Hard_addition_unlocked = Difficulty_Hard_addition_unlocked,
                totalNumberOfMathDone = totalNumberOfMathDone,
                totalNumberOfSubtractionDone = totalNumberOfSubtractionDone,
                totalNumberOfAdditionDone = totalNumberOfAdditionDone

            };

            string jsonString = JsonSerializer.Serialize(SaveData);
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
                XP = doc.RootElement.GetProperty("XP").GetInt32();
                coins = doc.RootElement.GetProperty("coins").GetInt32();
                UserData_UserName = doc.RootElement.GetProperty("UserName").GetString();
                Difficulty_Insane_addition_unlocked = doc.RootElement.GetProperty("Difficulty_Insane_addition_unlocked").GetBoolean();
                Difficulty_Hard_addition_unlocked = doc.RootElement.GetProperty("Difficulty_Hard_addition_unlocked").GetBoolean();
                totalNumberOfMathDone = doc.RootElement.GetProperty("totalNumberOfMathDone").GetInt32();
                totalNumberOfAdditionDone = doc.RootElement.GetProperty("totalNumberOfAdditionDone").GetInt32();
                totalNumberOfSubtractionDone = doc.RootElement.GetProperty("totalNumberOfSubtractionDone").GetInt32();
                InitializeGUI();
                ReLoadGUI();
            }
            else if (!File.Exists(fileName))
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
                XP += NumberOfXpGivenForAddition;
                ReLoadGUI();
                MathUserIntupt.Text = string.Empty;
                StartMath_addition();
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
            StartMath_addition();

        }

        private void OpenShopButton_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.ShowDialog();
        }

        private void statistic_button_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics();   
            statistics.ShowDialog();
            AutoLoadUserData();
        }
    }
}
