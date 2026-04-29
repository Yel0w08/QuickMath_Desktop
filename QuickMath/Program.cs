using QuickMath.Infrastructure.Data;
using QuickMath.Infrastructure.Repositories;
using QuickMath.Services;

namespace QuickMath;

/// <summary>
/// Desktop application entry point and local composition root.
/// </summary>
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        try
        {
            var appServices = BuildServices();
            if (!EnsureUserRegistration(appServices))
            {
                return;
            }

            Application.Run(new QuickMath(appServices));
        }
        catch (Exception exception)
        {
            MessageBox.Show(
                exception.Message,
                "QuickMath startup error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private static ApplicationServices BuildServices()
    {
        // Dependency wiring stays here so the WinForms layer only receives
        // fully built service objects and never knows how SQL components are created.
        var userSession = new UserSession();
        var connectionFactory = new SqlConnectionFactory();
        var initializer = new DatabaseInitializer(connectionFactory);
        initializer.Initialize();

        var userRepository = new UserRepository(connectionFactory);
        var exerciseRepository = new ExerciseRepository(connectionFactory);
        var scoreRepository = new ScoreRepository(connectionFactory);
        var shopRepository = new ShopRepository(connectionFactory);

        var userService = new UserService(userRepository, userSession);
        var mathEngineService = new MathEngineService(exerciseRepository);
        var scoreService = new ScoreService(scoreRepository);
        var shopService = new ShopService(shopRepository, userSession);

        return new ApplicationServices(
            userService,
            mathEngineService,
            scoreService,
            shopService,
            userSession);
    }

    private static bool EnsureUserRegistration(ApplicationServices appServices)
    {
        if (!appServices.UserService.HasRegisteredUsers())
        {
            // First launch must produce a persisted user before the main form
            // can start, otherwise the session layer has nothing to load.
            using var registerForm = new RegisterForm(appServices.UserService);
            if (registerForm.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
        }

        appServices.UserService.EnsureActiveUser();
        return true;
    }
}
