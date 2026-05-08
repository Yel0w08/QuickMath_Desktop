namespace QuickMath.Services.Debug
{
    /// <summary>
    /// Improved Debug Service with command registry pattern.
    /// Easy to add new commands - just implement IDebugCommand and register it.
    /// </summary>
    public class DebugService
    {
        private static readonly IDebugLogger Logger = new ConsoleDebugLogger();
        private readonly Dictionary<string, IDebugCommand> _commands = new();
        private readonly QuickMath _form;
        private bool _isRunning;

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public DebugService(QuickMath form)
        {
            _form = form;

#if DEBUG
          
            AllocConsole();
            RegisterCommands();
            StartConsoleThread();
            Logger.LogSuccess($"DebugService initialized with {_commands.Count} commands");
#endif
        }

        /// <summary>
        /// Register all debug commands here
        /// </summary>
        private void RegisterCommands()
        {
            // Economy commands
            Register(new GiveCoinsCommand(_form));
            Register(new GiveXPCommand(_form));
            Register(new SetCoinsCommand(_form));
            Register(new SetXPCommand(_form));

            // Unlock commands
            Register(new UnlockAllCommand(_form));
            Register(new UnlockAdditionCommand(_form));
            Register(new UnlockSubtractionCommand(_form));

            // Game state commands
            Register(new ReloadUserDataCommand(_form));
            Register(new SaveUserDataCommand(_form));
            Register(new ResetStatsCommand(_form));
            Register(new ReloadGUICommand(_form));

            // System commands
            Register(new ClearCommand());
            Register(new HelpCommand(this));
            Register(new ExitCommand());

            // Logging commands
            Register(new LogCommand());
            Register(new LogFilterCommand());
            Register(new LogClearCommand());

            // Inspection commands
            Register(new InspectCommand(_form));

            // Tool commands
            Register(new FormCommand(_form));
            Register(new MathTestCommand(_form));
        }

        /// <summary>
        /// Register a new debug command
        /// </summary>
        public void Register(IDebugCommand command)
        {
            _commands[command.Name.ToLower()] = command;
        }

        /// <summary>
        /// Get all registered commands (useful for auto-completion)
        /// </summary>
        public IEnumerable<string> GetCommandNames() => _commands.Keys;

        /// <summary>
        /// Get command by name
        /// </summary>
        public IDebugCommand GetCommand(string name) => 
            _commands.TryGetValue(name.ToLower(), out var cmd) ? cmd : null;

        /// <summary>
        /// Process a debug command
        /// </summary>
        public void ProcessCommand(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return;

            var parts = input.Trim().Split(new[] { ' ' }, 2);
            string cmdName = parts[0].ToLower();
            string args = parts.Length > 1 ? parts[1] : "";

            var command = GetCommand(cmdName);
            if (command != null)
            {
                try
                {
                    command.Execute(args, Logger);
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Command failed: {ex.Message}");
                }
            }
            else
            {
                Logger.LogError($"Unknown command: '{cmdName}'. Type 'help' for available commands.");
            }
        }

        /// <summary>
        /// Start the console input thread
        /// </summary>
        private void StartConsoleThread()
        {
            Thread consoleThread = new(() => ConsoleLoop())
            {
                IsBackground = true,
                Name = "DebugConsole"
            };
            consoleThread.Start();
        }

        /// <summary>
        /// Main console input loop
        /// </summary>
        private void ConsoleLoop()
        {
            _isRunning = true;
            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║   QuickMath Debug Console Ready        ║");
            Console.WriteLine("║   Type 'help' for available commands   ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            while (_isRunning)
            {
                try
                {
                    Console.Write("> ");
                    string input = ReadLineWithAutoCompletion();
                    
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        ProcessCommand(input);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Console error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Read console input with Tab auto-completion
        /// </summary>
        private string ReadLineWithAutoCompletion()
        {
            string input = "";
            var commands = GetCommandNames().OrderBy(c => c).ToList();

            while (true)
            {
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input;
                }
                else if (key.Key == ConsoleKey.Tab)
                {
                    // Auto-complete with Tab
                    var matches = commands.Where(c => c.StartsWith(input, StringComparison.OrdinalIgnoreCase)).ToList();
                    
                    if (matches.Count == 1)
                    {
                        string completion = matches[0].Substring(input.Length);
                        Console.Write(completion + " ");
                        input = matches[0] + " ";
                    }
                    else if (matches.Count > 1)
                    {
                        Console.WriteLine();
                        foreach (var match in matches.Take(5))
                        {
                            Console.WriteLine($"  {match}");
                        }
                        if (matches.Count > 5)
                            Console.WriteLine($"  ... and {matches.Count - 5} more");
                        Console.Write("> " + input);
                    }
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input[..^1];
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    input += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
        }

        /// <summary>
        /// Stop the debug console
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
        }

        /// <summary>
        /// Static logging method for use throughout the app
        /// </summary>
        public static void Log(string message) => Logger.Log(message);
    }
}
