namespace QuickMath
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = $"About {AppInfo.Name}";
            this.labelProductName.Text = AppInfo.Name;
            this.labelVersion.Text = $"App version: {AppInfo.Version}";
            this.labelCopyright.Text = $"{AppInfo.Author}";
            this.labelCompanyName.Text = AppInfo.Name;
            this.textBoxDescription.Text = "Offline Windows application for training mental math.";
        }

        private void logoPictureBox_Click(object sender, EventArgs e) { }
    }
}
