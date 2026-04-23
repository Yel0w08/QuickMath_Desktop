using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuickMath
{
    public partial class Form1 : Form
    {
        private int result;
        public int XP; //public stuff

        public Form1()
        {
            InitializeComponent();
            AutoLoadUserData();
            InitializeGUI();
            ResetGUI();

        }

        private void InitializeGUI()
        {
            GrettingLabel.Text = $"Welcome back {UserData_UserName} !";
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
            else if (TypeOfMath.SelectedItem.ToString() == "addition"){DifficultySelect.Show();}
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //start_button
        {



            if (TypeOfMath.SelectedItem == string.Empty) { }//why dont it work
            else if (TypeOfMath.SelectedItem.ToString() == "addition")
            {
                LockGUI();
                StartMath_addition();
            
            }
            else if (TypeOfMath.SelectedItem.ToString() == "subtraction")
            {
                LockGUI();
                //StartMath_subtraction();
            }
            else if (TypeOfMath.SelectedItem.ToString() == "multiplication")
            {
                LockGUI();

            }
            else if (TypeOfMath.SelectedItem.ToString() == "division")
            {

                LockGUI();

            }
            else { MessageBox.Show("Please select a math operation before starting !"); }//to chekc if thez intput isint null 

        }

        public async Task StartMath_addition()
        {

            int min_number_addition = 1;
            int max_number_addition = 100;

          

            if (DifficultySelect.SelectedItem == "default (1 - 100)")
            {min_number_addition = 1; max_number_addition = 100;}


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
            }
        }



        void ResetGUI()
        {
            DifficultySelect.Hide();


        }

        void ReLoadGUI()
        {

            XPpointLabel.Text = XP.ToString();
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
                UserName = UserData_UserName
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
                UserData_UserName = doc.RootElement.GetProperty("UserName").GetString();
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
                XP += 10;
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

        }
    }
}
