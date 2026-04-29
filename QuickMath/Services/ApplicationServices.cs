namespace QuickMath.Services;

/// <summary>
/// Small composition root object passed to forms so they depend on services, not repositories.
/// </summary>
public sealed class ApplicationServices
{
    /// <summary>
    /// Creates the service bundle used by the WinForms application.
    /// </summary>
    public ApplicationServices(
        UserService userService,
        MathEngineService mathEngineService,
        ScoreService scoreService,
        ShopService shopService,
        UserSession userSession)
    {
        UserService = userService;
        MathEngineService = mathEngineService;
        ScoreService = scoreService;
        ShopService = shopService;
        UserSession = userSession;
    }

    /// <summary>
    /// Handles profile lifecycle and refresh operations.
    /// </summary>
    public UserService UserService { get; }

    /// <summary>
    /// Creates and validates math exercises.
    /// </summary>
    public MathEngineService MathEngineService { get; }

    /// <summary>
    /// Returns aggregated player statistics.
    /// </summary>
    public ScoreService ScoreService { get; }

    /// <summary>
    /// Exposes shop catalog and purchase operations.
    /// </summary>
    public ShopService ShopService { get; }

    /// <summary>
    /// Holds the current mono-user session snapshot.
    /// </summary>
    public UserSession UserSession { get; }
}
