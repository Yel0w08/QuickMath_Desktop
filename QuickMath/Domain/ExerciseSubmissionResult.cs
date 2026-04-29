namespace QuickMath.Domain;

/// <summary>
/// Result returned after an exercise attempt is stored and rewarded.
/// </summary>
public sealed class ExerciseSubmissionResult
{
    /// <summary>
    /// Indicates whether the submitted answer matched the expected one.
    /// </summary>
    public bool IsCorrect { get; init; }

    /// <summary>
    /// Experience granted for the attempt.
    /// </summary>
    public int AwardedXp { get; init; }

    /// <summary>
    /// Coins granted for the attempt.
    /// </summary>
    public decimal AwardedCoins { get; init; }

    /// <summary>
    /// Fresh player snapshot after the transaction completes.
    /// </summary>
    public UserProfile UpdatedUser { get; init; } = new();
}
