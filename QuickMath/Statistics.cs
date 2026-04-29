using QuickMath.Services;

namespace QuickMath;

public partial class Statistics : Form
{
    private readonly ScoreService _scoreService;
    private readonly UserSession _userSession;

    public Statistics(ScoreService scoreService, UserSession userSession)
    {
        _scoreService = scoreService;
        _userSession = userSession;
        InitializeComponent();
        LoadStats();
        VersionLabel.Text = $"v{AppInfo.Version} | By {AppInfo.Author} | {AppInfo.Name}";
    }

    private void LoadStats()
    {
        var stats = _scoreService.GetStatistics(_userSession.CurrentUserId);

        StatsTreeView.Nodes[3].Nodes[0].Text = $"XP: {stats.XP}";
        StatsTreeView.Nodes[3].Nodes[1].Text = $"Username: {stats.UserName}";
        StatsTreeView.Nodes[0].Nodes[0].Text = $"Total Math done: {stats.TotalMathDone}";
        StatsTreeView.Nodes[0].Nodes[1].Text = $"Total Addition done: {stats.TotalAdditionDone}";
        StatsTreeView.Nodes[0].Nodes[2].Text = $"Total Subtraction done: {stats.TotalSubtractionDone}";
        StatsTreeView.Nodes[1].Nodes[0].Text = $"Total coins spent: {stats.TotalCoinsSpent:0.##}";
        StatsTreeView.Nodes[1].Nodes[1].Text = $"Total coins earned: {stats.TotalCoinsEarned:0.##}";
        StatsTreeView.Nodes[2].Nodes[0].Nodes[0].Text = $"Red Star: {stats.RedStars}";
        StatsTreeView.Nodes[2].Nodes[0].Nodes[1].Text = $"Blue Star: {stats.BlueStars}";
        StatsTreeView.Nodes[2].Nodes[0].Nodes[2].Text = $"Yellow Star: {stats.YellowStars}";
        StatsTreeView.Nodes[2].Nodes[0].Nodes[3].Text = $"Purple Star: {stats.PurpleStars}";
        StatsTreeView.Nodes[2].Nodes[1].Text = $"Dark Matter: {stats.DarkMatter}";
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
    }

    private void Statistics_Load(object sender, EventArgs e)
    {
    }
}
