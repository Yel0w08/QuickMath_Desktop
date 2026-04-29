namespace QuickMath
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DatabaseManager.Initialize();
            DatabaseManager.Load();
            if (!DatabaseManager.Exists() && File.Exists("QuickMath_UserData.json"))
            {
                DatabaseManager.MigrateJsonToDatabase();
            }
            Application.Run(new QuickMath());

         

        }
    }
}