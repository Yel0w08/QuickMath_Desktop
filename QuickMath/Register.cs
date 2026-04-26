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
    public partial class RegisterForm : Form
    {
        public int totalNumberOfMathDone = 0;
        public int totalNumberOfAdditionDone = 0;
        public int totalNumberOfSubtractionDone = 0;
        float Coins = 0; // Initialize coins to 0 for new users
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            int XP = 0; // Initialize XP to 0 for new users

            var SaveData = new
            {
                XP = XP,
                UserName = UsernameIntupt.Text,
                coins = Coins,
                Difficulty_Insane_addition_unlocked = false,
            Difficulty_Hard_addition_unlocked = false,
                totalNumberOfMathDone = 0,
                totalNumberOfAdditionDone = 0,
                totalNumberOfSubtractionDone = 0
            };

            string jsonString = JsonSerializer.Serialize(SaveData);
            string fileName = "QuickMath_UserData.json";
            File.WriteAllText(fileName, jsonString);
            this.Close();
        }

        private void SkipRegisterButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
