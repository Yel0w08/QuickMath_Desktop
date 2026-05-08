using QuickMath.Services.DataManager;

namespace QuickMath
{
    public partial class RegisterForm : Form
    {
        public int totalNumberOfMathDone = 0;
        public int totalNumberOfAdditionDone = 0;
        public int totalNumberOfSubtractionDone = 0;
        public string UserData_UserName = "Player";
        float Coins = 0;

        public RegisterForm()
        {
            InitializeComponent();
            UsernameIntupt.Text = Environment.UserName;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            UserData_UserName = UsernameIntupt.Text;
            SaveDataLocal();
            this.Close();
        }

        private void SkipRegisterButton_Click(object sender, EventArgs e)
        {
            UserData_UserName = Environment.UserName;
            SaveDataLocal();
            this.Close();
        }

        private void SaveDataLocal()
        {
            var data = UserDataModel.CreateDefault(UserData_UserName);
            data.coins = Coins;
            data.totalNumberOfMathDone = totalNumberOfMathDone;
            data.totalNumberOfAdditionDone = totalNumberOfAdditionDone;
            data.totalNumberOfSubtractionDone = totalNumberOfSubtractionDone;

            DataManagerService.Save(data, FileConfig.SaveFileName);
        }

        // Designer-wired empty handlers
        private void label1_Click(object sender, EventArgs e) { }
        private void UsernameIntupt_TextChanged(object sender, EventArgs e) { }
        private void RegisterForm_Load(object sender, EventArgs e) { }
    }
}
