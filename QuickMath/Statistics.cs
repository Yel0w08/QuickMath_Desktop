using static QuickMath.AppInfo;
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

    public partial class Statistics : MaterialSkin.Controls.MaterialForm
    {

        int XP;
        float coins;
        string UserData_UserName;
        bool Difficulty_Insane_addition_unlocked;
        bool Difficulty_Hard_addition_unlocked;
        public int totalNumberOfMathDone;
        public int totalNumberOfAdditionDone;
        public int totalNumberOfSubtractionDone;
        public bool Difficulty_Insane_subtraction_unlocked;
        public bool Difficulty_Hard_subtraction_unlocked;
        public Statistics()
        {
            InitializeComponent();
            LoadUserData();
            MaterialSkin.MaterialSkinManager.Instance.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
        }

        void LoadStats()
        {

            StatsTreeView.Nodes[3].Nodes[0].Text = $"XP: {XP.ToString()}";
            StatsTreeView.Nodes[3].Nodes[1].Text = $"Username: {UserData_UserName}";
            StatsTreeView.Nodes[0].Nodes[0].Text = $"Total Math done: {totalNumberOfMathDone}";
            StatsTreeView.Nodes[0].Nodes[0].Text = $"Total Math done: {totalNumberOfMathDone}";
            StatsTreeView.Nodes[0].Nodes[1].Text = $"Total Addtiton done: {totalNumberOfAdditionDone}";
        }
        void LoadUserData()
        {

            string fileName = "QuickMath_UserData.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                var doc = JsonDocument.Parse(jsonString);

                if (doc.RootElement.TryGetProperty("XP", out var xpProp))
                    XP = xpProp.GetInt32();

                if (doc.RootElement.TryGetProperty("coins", out var coinsProp))
                    coins = coinsProp.GetSingle();

                if (doc.RootElement.TryGetProperty("UserName", out var userNameProp))
                    UserData_UserName = userNameProp.GetString();

                if (UserData_UserName == string.Empty || UserData_UserName == null)
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

            }
            LoadStats();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Statistics_Load(object sender, EventArgs e)
        {

        }

        private void OpenInfoButton_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBoxForm = new AboutBox1();
            aboutBoxForm.ShowDialog();
        }
    }
}
