namespace QuickMath.Services;

public sealed class ApplicationServices
{
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

    public UserService UserService { get; }
    public MathEngineService MathEngineService { get; }
    public ScoreService ScoreService { get; }
    public ShopService ShopService { get; }
    public UserSession UserSession { get; }
}
