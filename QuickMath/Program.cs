using QuickMath.Infrastructure.Data;
using QuickMath.Infrastructure.Repositories;
using QuickMath.Services;

namespace QuickMath;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        try
        {
            var appServices = BuildServices();
            EnsureUserRegistration(appServices);
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

    private static void EnsureUserRegistration(ApplicationServices appServices)
    {
        if (!appServices.UserService.HasRegisteredUsers())
        {
            using var registerForm = new RegisterForm(appServices.UserService);
            registerForm.ShowDialog();
        }

        appServices.UserService.EnsureActiveUser();
    }
}
