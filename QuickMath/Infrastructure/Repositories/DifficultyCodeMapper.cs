using QuickMath.Domain;

namespace QuickMath.Infrastructure.Repositories;

internal static class DifficultyCodeMapper
{
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
