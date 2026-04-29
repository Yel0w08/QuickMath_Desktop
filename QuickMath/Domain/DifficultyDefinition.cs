namespace QuickMath.Domain;

public sealed class DifficultyDefinition
{
    public MathOperation Operation { get; init; }
    public DifficultyLevel Difficulty { get; init; }
    public int MinOperand { get; init; }
    public int MaxOperand { get; init; }
    public int RewardXp { get; init; }
    public decimal RewardCoins { get; init; }
    public string? RequiredItemCode { get; init; }
    public bool IsUnlocked { get; init; }
}
