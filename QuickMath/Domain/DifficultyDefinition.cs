namespace QuickMath.Domain;

/// <summary>
/// Describes the gameplay and reward rules attached to one difficulty level.
/// </summary>
public sealed class DifficultyDefinition
{
    /// <summary>
    /// Operation for which the definition applies.
    /// </summary>
    public MathOperation Operation { get; init; }

    /// <summary>
    /// Difficulty key for the selected operation.
    /// </summary>
    public DifficultyLevel Difficulty { get; init; }

    /// <summary>
    /// Inclusive minimum operand generated for the exercise.
    /// </summary>
    public int MinOperand { get; init; }

    /// <summary>
    /// Inclusive maximum operand generated for the exercise.
    /// </summary>
    public int MaxOperand { get; init; }

    /// <summary>
    /// Experience granted when the answer is correct.
    /// </summary>
    public int RewardXp { get; init; }

    /// <summary>
    /// Coins granted when the answer is correct.
    /// </summary>
    public decimal RewardCoins { get; init; }

    /// <summary>
    /// Optional item code required to unlock the difficulty.
    /// </summary>
    public string? RequiredItemCode { get; init; }

    /// <summary>
    /// Indicates whether the current user can play this difficulty.
    /// </summary>
    public bool IsUnlocked { get; init; }
}
