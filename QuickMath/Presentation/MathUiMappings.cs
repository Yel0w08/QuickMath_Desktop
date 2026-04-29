using QuickMath.Domain;

namespace QuickMath.Presentation;

/// <summary>
/// Centralizes all UI-to-domain mappings used by the main exercise form.
/// </summary>
internal static class MathUiMappings
{
    public const string AdditionLabel = "addition";
    public const string SubtractionLabel = "subtraction";
    public const string ComingSoonLabel = "more coming !";
    public const string MediumDifficultyLabel = "medium";

    /// <summary>
    /// Converts the operation label displayed in the combo box to the domain enum.
    /// </summary>
    public static MathOperation ParseOperation(string? uiValue) => uiValue switch
    {
        AdditionLabel => MathOperation.Addition,
        SubtractionLabel => MathOperation.Subtraction,
        _ => throw new InvalidOperationException("Please select a supported math operation."),
    };

    /// <summary>
    /// Converts the difficulty label displayed in the combo box to the domain enum.
    /// </summary>
    public static DifficultyLevel ParseDifficulty(string? uiValue) => uiValue switch
    {
        "easy++" => DifficultyLevel.EasyPlusPlus,
        "easy" => DifficultyLevel.Easy,
        MediumDifficultyLabel => DifficultyLevel.Medium,
        "hard" => DifficultyLevel.Hard,
        "insane" => DifficultyLevel.Insane,
        _ => throw new InvalidOperationException("Please select a difficulty."),
    };

    /// <summary>
    /// Formats the exercise exactly as it should appear in the UI.
    /// </summary>
    public static string FormatProblem(ExerciseProblem problem) => problem.Operation switch
    {
        MathOperation.Addition => $"{problem.LeftOperand} + {problem.RightOperand}",
        MathOperation.Subtraction => $"{problem.LeftOperand} - {problem.RightOperand}",
        _ => throw new ArgumentOutOfRangeException(nameof(problem)),
    };
}
