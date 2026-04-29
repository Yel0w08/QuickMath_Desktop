using QuickMath.Domain;

namespace QuickMath.Infrastructure.Repositories;

/// <summary>
/// Maps domain difficulty enums to their persisted SQL codes.
/// </summary>
internal static class DifficultyCodeMapper
{
    /// <summary>
    /// Converts a domain difficulty into the normalized SQL code used in lookup queries.
    /// </summary>
    public static string ToCode(DifficultyLevel difficulty) => difficulty switch
    {
        DifficultyLevel.EasyPlusPlus => "easyplusplus",
        DifficultyLevel.Easy => "easy",
        DifficultyLevel.Medium => "medium",
        DifficultyLevel.Hard => "hard",
        DifficultyLevel.Insane => "insane",
        _ => throw new ArgumentOutOfRangeException(nameof(difficulty)),
    };
}
