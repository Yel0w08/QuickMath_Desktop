namespace QuickMath
{
    public static class LiveAppData
    {
        public static UserData Current { get; private set; } = new UserData();

        public static void Load()
        {
            Current = DatabaseManager.Load();
        }

        public static void Save()
        {
            DatabaseManager.Save(Current);
        }
    }
}