namespace QuickMath.Domain;

public sealed class UserStatistics
{
    public string UserName { get; init; } = string.Empty;
    public int XP { get; init; }
    public decimal Coins { get; init; }
    public int TotalMathDone { get; init; }
    public int TotalAdditionDone { get; init; }
    public int TotalSubtractionDone { get; init; }
    public decimal TotalCoinsSpent { get; init; }
    public decimal TotalCoinsEarned { get; init; }
    public int RedStars { get; init; }
    public int BlueStars { get; init; }
    public int YellowStars { get; init; }
    public int PurpleStars { get; init; }
    public int DarkMatter { get; init; }
}
