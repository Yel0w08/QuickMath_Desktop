namespace QuickMath.Domain;

public sealed class ExerciseSubmissionResult
{
    public bool IsCorrect { get; init; }
    public int AwardedXp { get; init; }
    public decimal AwardedCoins { get; init; }
    public UserProfile UpdatedUser { get; init; } = new();
}
