namespace QuickMath.Services.Debug
{
    /// <summary>
    /// Interface for all debug commands. Implement this to add new debug commands.
    /// </summary>
    public interface IDebugCommand
    {
        /// <summary>
        /// The command name (e.g., "give_coins")
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Short description shown in help
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Parameter description (e.g., "[amount]") or empty if no parameters
        /// </summary>
        string Parameters { get; }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="args">Command arguments (everything after the command name)</param>
        /// <param name="logger">Logger for output</param>
        void Execute(string args, IDebugLogger logger);
    }

    /// <summary>
    /// Logger interface for debug output
    /// </summary>
    public interface IDebugLogger
    {
        void Log(string message);
        void LogError(string message);
        void LogSuccess(string message);
        void LogWarning(string message);
    }

    /// <summary>
    /// Console-based logger for debug output
    /// </summary>
    public class ConsoleDebugLogger : IDebugLogger
    {
        public void Log(string message)
        {
#if DEBUG
            Console.WriteLine($"[DEBUG] {DateTime.Now:HH:mm:ss} — {message}");
#endif
        }

        public void LogError(string message)
        {
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {DateTime.Now:HH:mm:ss} — {message}");
            Console.ResetColor();
#endif
        }

        public void LogSuccess(string message)
        {
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[OK] {DateTime.Now:HH:mm:ss} — {message}");
            Console.ResetColor();
#endif
        }

        public void LogWarning(string message)
        {
#if DEBUG
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] {DateTime.Now:HH:mm:ss} — {message}");
            Console.ResetColor();
#endif
        }
    }
}
