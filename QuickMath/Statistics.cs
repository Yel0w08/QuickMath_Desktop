using System.Text.Json;

namespace QuickMath
{
    public partial class Statistics : Form
    {
        int XP;
        float coins;
        string UserData_UserName;
        bool Difficulty_Insane_addition_unlocked;
        bool Difficulty_Hard_addition_unlocked;
        bool Difficulty_Insane_subtraction_unlocked;
        bool Difficulty_Hard_subtraction_unlocked;
        public int totalNumberOfMathDone;
        public int totalNumberOfAdditionDone;
        public int totalNumberOfSubtractionDone;

        // TreeView node indices (must match designer layout)
        // Math[0] → Total[0], Additions[1]
        // Economy[1] → Total coins spent[0], Total coins earn[1]
        // Special[2] → Stars[0] → Red Star[0], Blu star[1], Yellow Star[2], Purpule Star[3]
        //             → Dark Matter[1]
        // Player[3] → Total XP[0], Username[1]

        public Statistics()
        {
            InitializeComponent();
            LoadUserData();
        }

        void LoadStats()
        {
            // Player section
            StatsTreeView.Nodes[3].Nodes[0].Text = $"XP: {XP}";
            StatsTreeView.Nodes[3].Nodes[1].Text = $"Username: {UserData_UserName}";

            // Math section
            StatsTreeView.Nodes[0].Nodes[0].Text = $"Total Math done: {totalNumberOfMathDone}";
            StatsTreeView.Nodes[0].Nodes[1].Text = $"Total Addition done: {totalNumberOfAdditionDone}";

            // Economy section
            StatsTreeView.Nodes[1].Nodes[0].Text = $"Total coins: {coins}";
        }

        void LoadUserData()
        {
            if (!File.Exists(FileConfig.SaveFileName))
            {
                RegisterForm form2 = new RegisterForm();
                form2.ShowDialog();
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

            LoadStats();
        }

        // Designer-wired empty handlers
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) { }
        private void Statistics_Load(object sender, EventArgs e) { }

        private void AboutButtonOpenPopup_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBoxForm = new AboutBox1();
            aboutBoxForm.ShowDialog();
        }
    }
}
