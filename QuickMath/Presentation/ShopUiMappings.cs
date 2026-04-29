using QuickMath.Domain;

namespace QuickMath.Presentation;

/// <summary>
/// Centralizes shop-specific UI labels so categories can evolve without scattering strings.
/// </summary>
internal static class ShopUiMappings
{
    public const string DifficultyCategoryLabel = "Difficulty";
    public const string StarsCategoryLabel = "Stars";

    /// <summary>
    /// Maps a shop combo-box label to its domain category.
    /// </summary>
    public static ShopCategory ParseCategory(string? uiValue) => uiValue switch
    {
        StarsCategoryLabel => ShopCategory.Stars,
        _ => ShopCategory.Difficulty,
    };
}
