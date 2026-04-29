using System.Collections.Generic;
using QuickMath.Services;
using QuickMath.Presentation;

namespace QuickMath;

/// <summary>
/// Read-only statistics dialog backed by aggregated SQL queries.
/// </summary>
public partial class Statistics : Form
{
    private readonly ScoreService _scoreService;
    private readonly UserSession _userSession;
    private Dictionary<string, TreeNode>? _nodesByName;

    /// <summary>
    /// Builds the dialog with the score service and the active user session.
    /// </summary>
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
        // The statistics model is already aggregated by the repository, so the
        // form only maps values to the existing tree structure.
        var stats = _scoreService.GetStatistics(_userSession.CurrentUserId);

        SetNodeText(StatisticsNodeKeys.Username, $"Username: {stats.UserName}");
        SetNodeText(StatisticsNodeKeys.Xp, $"XP: {stats.XP}");
        SetNodeText(StatisticsNodeKeys.CurrentCoins, $"Current coins: {stats.Coins:0.##}");

        SetNodeText(StatisticsNodeKeys.TotalAttempts, $"Total attempts: {stats.TotalAttempts}");
        SetNodeText(StatisticsNodeKeys.CorrectAnswers, $"Correct answers: {stats.TotalMathDone}");

        SetNodeText(StatisticsNodeKeys.Additions, $"Additions: {stats.TotalAdditionDone}");
        SetNodeText(StatisticsNodeKeys.Subtractions, $"Subtractions: {stats.TotalSubtractionDone}");

        SetNodeText(StatisticsNodeKeys.CoinsEarned, $"Coins earned: {stats.TotalCoinsEarned:0.##}");
        SetNodeText(StatisticsNodeKeys.CoinsSpent, $"Coins spent: {stats.TotalCoinsSpent:0.##}");
        SetNodeText(StatisticsNodeKeys.NetCoins, $"Net coins: {stats.NetCoins:0.##}");
        SetNodeText(StatisticsNodeKeys.AverageXp, $"Average XP per correct answer: {stats.AverageXpPerCorrectAnswer:0.##}");
        SetNodeText(StatisticsNodeKeys.AverageCoins, $"Average coins per correct answer: {stats.AverageCoinsPerCorrectAnswer:0.##}");

        SetNodeText(StatisticsNodeKeys.DifficultyUnlocks, $"Difficulty unlocks: {stats.DifficultyUnlocksOwned}");
        SetNodeText(StatisticsNodeKeys.RedStar, $"Red Star: {stats.RedStars}");
        SetNodeText(StatisticsNodeKeys.BlueStar, $"Blue Star: {stats.BlueStars}");
        SetNodeText(StatisticsNodeKeys.YellowStar, $"Yellow Star: {stats.YellowStars}");
        SetNodeText(StatisticsNodeKeys.PurpleStar, $"Purple Star: {stats.PurpleStars}");
        SetNodeText(StatisticsNodeKeys.DarkMatter, $"Dark Matter: {stats.DarkMatter}");
        SetNodeText(StatisticsNodeKeys.TotalCollectibles, $"Total collectibles: {stats.TotalCollectibles}");

        OverviewTextBox.Text = BuildOverview(stats);
        StatsTreeView.ExpandAll();
    }

    private static string BuildOverview(Domain.UserStatistics stats)
    {
        return $@"Profile
Username: {stats.UserName}
XP: {stats.XP}
Current coins: {stats.Coins:0.##}

Practice
Total attempts: {stats.TotalAttempts}
Correct answers: {stats.TotalMathDone}

Operations
Additions solved: {stats.TotalAdditionDone}
Subtractions solved: {stats.TotalSubtractionDone}

Economy
Coins earned: {stats.TotalCoinsEarned:0.##}
Coins spent: {stats.TotalCoinsSpent:0.##}
Net coins from activity: {stats.NetCoins:0.##}
Average XP per correct answer: {stats.AverageXpPerCorrectAnswer:0.##}
Average coins per correct answer: {stats.AverageCoinsPerCorrectAnswer:0.##}

Collection
Difficulty unlocks owned: {stats.DifficultyUnlocksOwned}
Red stars: {stats.RedStars}
Blue stars: {stats.BlueStars}
Yellow stars: {stats.YellowStars}
Purple stars: {stats.PurpleStars}
Dark matter: {stats.DarkMatter}
Total collectibles: {stats.TotalCollectibles}
";
    }

    private void SetNodeText(string nodeName, string text)
    {
        _nodesByName ??= BuildNodeLookup();
        if (_nodesByName.TryGetValue(nodeName, out var node))
        {
            node.Text = text;
        }
    }

    private Dictionary<string, TreeNode> BuildNodeLookup()
    {
        var nodes = new Dictionary<string, TreeNode>(StringComparer.Ordinal);

        foreach (TreeNode rootNode in StatsTreeView.Nodes)
        {
            AddNodeAndChildren(nodes, rootNode);
        }

        return nodes;
    }

    private static void AddNodeAndChildren(IDictionary<string, TreeNode> nodes, TreeNode node)
    {
        nodes[node.Name] = node;

        foreach (TreeNode childNode in node.Nodes)
        {
            AddNodeAndChildren(nodes, childNode);
        }
    }

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
    }

    private void Statistics_Load(object sender, EventArgs e)
    {
    }
}
