using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuickMath
{
    public partial class RegisterForm : Form
    {
        public int totalNumberOfMathDone = 0;
        public int totalNumberOfAdditionDone = 0;
        public int totalNumberOfSubtractionDone = 0;
        public string UserData_UserName;
        float Coins = 0; 
        public RegisterForm()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            UserData_UserName = UsernameIntupt.Text.ToString();
            SaveDataLocal();
            this.Close();
        }

        private void SaveDataLocal()
        {
            int XP = 0; // Initialize XP to 0 for new users

            var SaveData = new
            {
                XP = XP,
                UserName = UserData_UserName,
                coins = Coins,
                Difficulty_Insane_addition_unlocked = false,
                Difficulty_Hard_addition_unlocked = false,
                totalNumberOfMathDone = totalNumberOfMathDone,
                totalNumberOfAdditionDone = totalNumberOfAdditionDone,
                totalNumberOfSubtractionDone = totalNumberOfSubtractionDone,
                RedStarNumber = 0,
                BluStarNumber = 0,
                YellowStarNumber = 0,
                PurpleStarNumber = 0,
                DarkMatterNumber = 0,
                                
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(SaveData, options);
            string fileName = "QuickMath_UserData.json";
            File.WriteAllText(fileName, jsonString);
        }

        private void SkipRegisterButton_Click(object sender, EventArgs e)
        {
            UserData_UserName = Environment.UserName;

            SaveDataLocal();
            this.Close();
          


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
