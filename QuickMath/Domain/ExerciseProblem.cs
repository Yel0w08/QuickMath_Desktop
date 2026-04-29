namespace QuickMath.Domain;

/// <summary>
/// In-memory representation of the current math exercise shown by the UI.
/// </summary>
public sealed class ExerciseProblem
{
    /// <summary>
    /// Operation used to compute the expected answer.
    /// </summary>
    public MathOperation Operation { get; init; }

    /// <summary>
    /// Difficulty that shaped the operand range and rewards.
    /// </summary>
    public DifficultyLevel Difficulty { get; init; }

    /// <summary>
    /// First generated operand.
    /// </summary>
    public int LeftOperand { get; init; }

    /// <summary>
    /// Second generated operand.
    /// </summary>
    public int RightOperand { get; init; }

    /// <summary>
    /// Correct answer persisted when the attempt is submitted.
    /// </summary>
    public int ExpectedAnswer { get; init; }
}
