namespace QuickMath.Domain;

public sealed class ExerciseProblem
{
    public MathOperation Operation { get; init; }
    public DifficultyLevel Difficulty { get; init; }
    public int LeftOperand { get; init; }
    public int RightOperand { get; init; }
    public int ExpectedAnswer { get; init; }
}
