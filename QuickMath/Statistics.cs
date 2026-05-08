using QuickMath.Services.Debug;
using QuickMath.Services.DataManager;

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

        // Star cosmetics
        int RedStarNumber;
        int BlueStarNumber;
        int YellowStarNumber;
        int PurpleStarNumber;
        int DarkMatterNumber;

        // TreeView node indices (must match designer layout)
        // Math[0]        → Total[0], Additions[1]
        // Economy[1]     → Total coins spent[0], Total coins earn[1]
        // Special[2]     → Stars[0], Dark Matter[1]
        //   Stars[0]     → Red Star[0], Blu star[1], Yellow Star[2], Purpule Star[3]
        // Player[3]      → Total XP[0], Username[1]

        public Statistics()
        {
            InitializeComponent();
         
            LoadUserData();
           DebugService.Log("Statistics opened");
        }

        void LoadStats()
        {
            // ── Player section ──────────────────────────────────────────
            StatsTreeView.Nodes[3].Nodes[0].Text = $"XP: {XP}";
            StatsTreeView.Nodes[3].Nodes[1].Text = $"Username: {UserData_UserName}";

            // ── Math section ────────────────────────────────────────────
            StatsTreeView.Nodes[0].Nodes[0].Text = $"Total Math done: {totalNumberOfMathDone}";
            StatsTreeView.Nodes[0].Nodes[1].Text = $"Addition: {totalNumberOfAdditionDone}";

            // Show subtraction in the Additions > Total subnode
            StatsTreeView.Nodes[0].Nodes[1].Nodes[0].Text = $"Subtraction: {totalNumberOfSubtractionDone}";

            // ── Economy section ─────────────────────────────────────────
            StatsTreeView.Nodes[1].Nodes[0].Text = $"Current coins: {coins}";

            // ── Special section (Stars) ─────────────────────────────────
            StatsTreeView.Nodes[2].Nodes[0].Nodes[0].Text = $"Red Star: {RedStarNumber}";
            StatsTreeView.Nodes[2].Nodes[0].Nodes[1].Text = $"Blue Star: {BlueStarNumber}";
            StatsTreeView.Nodes[2].Nodes[0].Nodes[2].Text = $"Yellow Star: {YellowStarNumber}";
            StatsTreeView.Nodes[2].Nodes[0].Nodes[3].Text = $"Purple Star: {PurpleStarNumber}";
            StatsTreeView.Nodes[2].Nodes[1].Text = $"Dark Matter: {DarkMatterNumber}";

            // ── Difficulty unlocks ──────────────────────────────────────
            StatsTreeView.Nodes[1].Nodes[1].Text = $"Addition Hard: {Difficulty_Hard_addition_unlocked}";
        }

        void LoadUserData()
        {
            var data = DataManagerService.LoadOrCreate(FileConfig.SaveFileName);

            UserData_UserName = data.UserName;

            if (string.IsNullOrEmpty(UserData_UserName))
            {
                RegisterForm form2 = new RegisterForm();
                form2.ShowDialog();
                return;
            }

            XP = data.XP;
            coins = data.coins;
            Difficulty_Insane_addition_unlocked = data.Difficulty_Insane_addition_unlocked;
            Difficulty_Hard_addition_unlocked = data.Difficulty_Hard_addition_unlocked;
            Difficulty_Insane_subtraction_unlocked = data.Difficulty_Insane_subtraction_unlocked;
            Difficulty_Hard_subtraction_unlocked = data.Difficulty_Hard_subtraction_unlocked;
            totalNumberOfMathDone = data.totalNumberOfMathDone;
            totalNumberOfAdditionDone = data.totalNumberOfAdditionDone;
            totalNumberOfSubtractionDone = data.totalNumberOfSubtractionDone;
            RedStarNumber = data.RedStarNumber;
            BlueStarNumber = data.BlueStarNumber;
            YellowStarNumber = data.YellowStarNumber;
            PurpleStarNumber = data.PurpleStarNumber;
            DarkMatterNumber = data.DarkMatterNumber;

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
