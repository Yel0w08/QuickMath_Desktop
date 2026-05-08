namespace QuickMath.Services
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Debug
    }

    public static class AppLogger
    {
        private static readonly string LogFilePath;
        private static readonly object Lock = new();
        private static LogLevel _minimumLevel = LogLevel.Debug;

        static AppLogger()
        {
            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "QuickMath_Desktop"
            );
            Directory.CreateDirectory(folder);
            LogFilePath = Path.Combine(folder, "QuickMath.log");
        }

        public static void Info(string message) => Write(LogLevel.Info, message);
        public static void Warning(string message) => Write(LogLevel.Warning, message);
        public static void Error(string message) => Write(LogLevel.Error, message);
        public static void Debug(string message) => Write(LogLevel.Debug, message);

        public static void Error(Exception ex, string context = "")
        {
            string msg = string.IsNullOrEmpty(context) ? ex.Message : $"{context}: {ex.Message}";
            Write(LogLevel.Error, $"{msg}\n{ex.StackTrace}");
        }

        private static void Write(LogLevel level, string message)
        {
            if (level < _minimumLevel)
                return;

            lock (Lock)
            {
                try
                {
                    string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level,-7}] {message}";
                    File.AppendAllText(LogFilePath, line + Environment.NewLine);

                    // Keep log under 1MB — trim oldest half
                    var fileInfo = new FileInfo(LogFilePath);
                    if (fileInfo.Exists && fileInfo.Length > 1_048_576)
                    {
                        var lines = File.ReadAllLines(LogFilePath).ToList();
                        int half = lines.Count / 2;
                        File.WriteAllLines(LogFilePath, lines.Skip(half));
                    }
                }
                catch
                {
                    // Logger must never crash the app
                }
            }
        }

        public static string[] ReadAll() =>
            File.Exists(LogFilePath) ? File.ReadAllLines(LogFilePath) : Array.Empty<string>();

        public static string[] ReadLast(int count)
        {
            var all = ReadAll();
            return all.Skip(Math.Max(0, all.Length - count)).ToArray();
        }

        public static string[] Filter(LogLevel level)
        {
            string tag = $"[{level,-7}]";
            return ReadAll().Where(l => l.Contains(tag)).ToArray();
        }

        public static void Clear()
        {
            lock (Lock)
            {
                try { File.WriteAllText(LogFilePath, ""); }
                catch { }
            }
        }

        public static void SetMinimumLevel(string level)
        {
            level = level.Trim().ToLower();
            _minimumLevel = level switch
            {
                "info" => LogLevel.Info,
                "warning" => LogLevel.Warning,
                "error" => LogLevel.Error,
                "debug" => LogLevel.Debug,
                _ => LogLevel.Debug
            };
        }
    }
}
