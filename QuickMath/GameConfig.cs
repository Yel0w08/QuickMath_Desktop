namespace QuickMath
{
    public enum MathOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public enum Difficulty
    {
        EasyPlus,
        Easy,
        Medium,
        Hard,
        Insane
    }

    public static class AdditionConfig
    {
        public static readonly Dictionary<Difficulty, (int min, int max, int xp, float coins)> Levels = new()
        {
            { Difficulty.EasyPlus, (1, 10, 1, 0.25f) },
            { Difficulty.Easy,     (1, 50, 5, 0.5f) },
            { Difficulty.Medium,   (1, 100, 10, 1f) },
            { Difficulty.Hard,     (50, 500, 20, 2f) },
            { Difficulty.Insane,   (100, 1000, 40, 4f) },
        };
    }

    public static class SubtractionConfig
    {
        public static readonly Dictionary<Difficulty, (int min, int max, int xp, float coins)> Levels = new()
        {
            { Difficulty.EasyPlus, (1, 10, 2, 0.5f) },
            { Difficulty.Easy,     (1, 50, 10, 1f) },
            { Difficulty.Medium,   (1, 100, 15, 1.5f) },
            { Difficulty.Hard,     (50, 500, 20, 2f) },
            { Difficulty.Insane,   (100, 1000, 40, 4f) },
        };
    }

    public static class ShopConfig
    {
        public const int HardAdditionPrice = 5;
        public const int InsaneAdditionPrice = 10;
        public const int HardSubtractionPrice = 10;
        public const int InsaneSubtractionPrice = 20;

        public const int RedStarPrice = 100;
        public const int BlueStarPrice = 100;
        public const int YellowStarPrice = 150;
        public const int PurpleStarPrice = 150;
        public const int DarkMatterPrice = 1000;

        public const int StarsMinXp = 100;
    }

    public static class FileConfig
    {
        public const string SaveFileName = "QuickMath_UserData.qms";
        public const string GitHubRepo = "Yel0w08/QuickMath_Desktop";
        public const string GitHubUserAgent = "QuickMath-Desktop";
    }
}
