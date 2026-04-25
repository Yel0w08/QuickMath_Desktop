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

    public partial class Statistics : Form
    {

        int XP;
        float coins;
        string UserData_UserName;
        bool Difficulty_Insane_addition_unlocked;
        bool Difficulty_Hard_addition_unlocked;

        public Statistics()
        {
            InitializeComponent();
            LoadUserData();
        }

        void LoadStats()
        {

            //i will put the code here tomorow 
        }
        void LoadUserData()
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
                LoadStats();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }
    }
}
