namespace QuickMath.Services.Debug
{
    // ==================== ECONOMY COMMANDS ====================

    public class GiveCoinsCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "give_coins";
        public string Description => "Add coins to the player";
        public string Parameters => "[amount]";

        public GiveCoinsCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            if (string.IsNullOrWhiteSpace(args))
            {
                logger.LogError("Usage: give_coins [amount]");
                return;
            }

            if (float.TryParse(args, out float amount))
            {
                _form.coins += amount;
                logger.LogSuccess($"Added {amount} coins. Total: {_form.coins}");
            }
            else
            {
                logger.LogError($"Invalid amount: {args}");
            }
        }
    }

    public class GiveXPCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "give_xp";
        public string Description => "Add XP to the player";
        public string Parameters => "[amount]";

        public GiveXPCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            if (string.IsNullOrWhiteSpace(args))
            {
                logger.LogError("Usage: give_xp [amount]");
                return;
            }

            if (int.TryParse(args, out int amount))
            {
                _form.XP += amount;
                logger.LogSuccess($"Added {amount} XP. Total: {_form.XP}");
            }
            else
            {
                logger.LogError($"Invalid amount: {args}");
            }
        }
    }

    public class SetCoinsCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "set_coins";
        public string Description => "Set coins to a specific value";
        public string Parameters => "[amount]";

        public SetCoinsCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            if (string.IsNullOrWhiteSpace(args))
            {
                logger.LogError("Usage: set_coins [amount]");
                return;
            }

            if (float.TryParse(args, out float amount))
            {
                _form.coins = amount;
                logger.LogSuccess($"Coins set to {amount}");
            }
            else
            {
                logger.LogError($"Invalid amount: {args}");
            }
        }
    }

    public class SetXPCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "set_xp";
        public string Description => "Set XP to a specific value";
        public string Parameters => "[amount]";

        public SetXPCommand(QuickMath form) => _form = form;

       

            public void Execute(string args, IDebugLogger logger)
        {
            if (string.IsNullOrWhiteSpace(args))
            {
                logger.LogError("Usage: set_xp [amount]");
                return;
            }

            if (int.TryParse(args, out int amount))
            {
                _form.XP = amount;
                logger.LogSuccess($"XP set to {amount}");
            }
            else
            {
                logger.LogError($"Invalid amount: {args}");
            }
        }
    }


    // ==================== UNLOCK COMMANDS ====================

    public class UnlockAllCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "unlock_all";
        public string Description => "Unlock all difficulty levels";
        public string Parameters => "";

        public UnlockAllCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            _form.Difficulty_Hard_addition_unlocked = true;
            _form.Difficulty_Insane_addition_unlocked = true;
            _form.Difficulty_Hard_subtraction_unlocked = true;
            _form.Difficulty_Insane_subtraction_unlocked = true;
            logger.LogSuccess("All difficulty levels unlocked");
        }
    }

    public class UnlockAdditionCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "unlock_addition";
        public string Description => "Unlock all addition difficulty levels";
        public string Parameters => "";

        public UnlockAdditionCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            _form.Difficulty_Hard_addition_unlocked = true;
            _form.Difficulty_Insane_addition_unlocked = true;
            logger.LogSuccess("All addition difficulty levels unlocked");
        }
    }

    public class UnlockSubtractionCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "unlock_subtraction";
        public string Description => "Unlock all subtraction difficulty levels";
        public string Parameters => "";

        public UnlockSubtractionCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            _form.Difficulty_Hard_subtraction_unlocked = true;
            _form.Difficulty_Insane_subtraction_unlocked = true;
            logger.LogSuccess("All subtraction difficulty levels unlocked");
        }
    }

    // ==================== GAME STATE COMMANDS ====================

    public class ReloadUserDataCommand : IDebugCommand
    {

        private readonly QuickMath _form;


        public string Name => "reload_userdata";
        public string Description => "Reload user data from save file";
        public string Parameters => "";

        public ReloadUserDataCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            _form.Invoke(() => _form.AutoLoadUserData());
            logger.LogSuccess("User data reloaded");
        }
    }

        public class SaveUserDataCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "save_userdata";
        public string Description => "Force save user data";
        public string Parameters => "";

        public SaveUserDataCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            _form.Invoke(() => _form.saveUserData_Local_form1());
            logger.LogSuccess("User data saved");
        }
    }

    public class ResetStatsCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "reset_stats";
        public string Description => "Reset all statistics to zero";
        public string Parameters => "";

        public ResetStatsCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            _form.totalNumberOfMathDone = 0;
            _form.totalNumberOfAdditionDone = 0;
            _form.totalNumberOfSubtractionDone = 0;
            logger.LogSuccess("Statistics reset to zero");
        }
    }

    public class ReloadGUICommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "reload_gui";
        public string Description => "Reload the GUI (refresh UI elements)";
        public string Parameters => "";

        public ReloadGUICommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
            _form.Invoke(() => _form.ReLoadGUI());
            logger.LogSuccess("GUI reloaded");
        }
    }

    // ==================== SYSTEM COMMANDS ====================

    public class ClearCommand : IDebugCommand
    {
        public string Name => "clear";
        public string Description => "Clear the console screen";
        public string Parameters => "";

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            Console.Clear();
#endif
        }
    }

    public class HelpCommand : IDebugCommand
    {
        private readonly DebugService? _service;

        public string Name => "help";
        public string Description => "Show this help message";
        public string Parameters => "";

        public HelpCommand(DebugService service) => _service = service;

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            if (_service == null)
                return;

            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         QuickMath Debug Console - Available Commands          ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════════╣");

            var commands = _service.GetCommandNames().OrderBy(c => c);

            var categories = new Dictionary<string, List<IDebugCommand>>();

            foreach (var cmd in commands)
            {
                var command = _service.GetCommand(cmd);
                if (command != null)
                {
                    string category = GetCategory(command.Name);
                    if (!categories.ContainsKey(category))
                        categories[category] = new List<IDebugCommand>();
                    categories[category].Add(command);
                }
            }

            foreach (var category in categories.Keys.OrderBy(c => c))
            {
                Console.WriteLine($"║ {category,-60} ║");
                Console.WriteLine("╟────────────────────────────────────────────────────────────────╢");

                foreach (var cmd in categories[category])
                {
                    string signature = $"  {cmd.Name} {cmd.Parameters}".PadRight(30);
                    string description = cmd.Description;
                    Console.WriteLine($"║ {signature} {description,-32} ║");
                }

                Console.WriteLine("╠════════════════════════════════════════════════════════════════╣");
            }

            Console.WriteLine("║ Type 'exit' to close the debug console                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
#endif
        }

        private string GetCategory(string commandName)
        {
            return commandName switch
            {
                "give_coins" or "give_xp" or "set_coins" or "set_xp" => "ECONOMY",
                "unlock_all" or "unlock_addition" or "unlock_subtraction" => "UNLOCK",
                "reload_userdata" or "save_userdata" or "reset_stats" or "reload_gui" => "GAME STATE",
                "clear" or "help" or "exit" => "SYSTEM",
                "log" or "log_filter" or "log_clear" => "LOGGING",
                "inspect" => "INSPECTION",
                "form" or "math_test" => "TOOLS",
                _ => "OTHER"
            };
        }
    }

    public class ExitCommand : IDebugCommand
    {
        public string Name => "exit";
        public string Description => "Close the debug console";
        public string Parameters => "";

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            logger.LogWarning("Debug console closing...");
            Application.Exit();
#endif
        }
    }

    // ==================== LOGGING COMMANDS ====================

    public class LogCommand : IDebugCommand
    {
        public string Name => "log";
        public string Description => "Show recent log entries";
        public string Parameters => "[count=10]";

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            int count = 10;
            if (!string.IsNullOrWhiteSpace(args))
                int.TryParse(args, out count);

            var lines = AppLogger.ReadLast(count);
            if (lines.Length == 0)
            {
                logger.LogWarning("No log entries found");
                return;
            }

            foreach (var line in lines)
                Console.WriteLine($"  {line}");

            logger.LogSuccess($"Displayed {lines.Length} log entries");
#endif
        }
    }

    public class LogFilterCommand : IDebugCommand
    {
        public string Name => "log_filter";
        public string Description => "Set minimum log level (Info, Warning, Error, Debug)";
        public string Parameters => "[level]";

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            if (string.IsNullOrWhiteSpace(args))
            {
                logger.LogError("Usage: log_filter [Info|Warning|Error|Debug]");
                return;
            }

            string level = args.Trim();
            AppLogger.SetMinimumLevel(level);
            logger.LogSuccess($"Log filter set to {level}");
#endif
        }
    }

    public class LogClearCommand : IDebugCommand
    {
        public string Name => "log_clear";
        public string Description => "Clear all log entries";
        public string Parameters => "";

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            AppLogger.Clear();
            logger.LogSuccess("Log file cleared");
#endif
        }
    }

    // ==================== INSPECTION COMMAND ====================

    public class InspectCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "inspect";
        public string Description => "Inspect current player state";
        public string Parameters => "";

        public InspectCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║           Player State Inspection           ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine($"║ XP:              {_form.XP,-18} ║");
            Console.WriteLine($"║ Coins:           {_form.coins,-18} ║");
            Console.WriteLine($"║ Username:        {_form.UserData_UserName,-18} ║");
            Console.WriteLine($"║ Math Done:       {_form.totalNumberOfMathDone,-18} ║");
            Console.WriteLine($"║ Additions:       {_form.totalNumberOfAdditionDone,-18} ║");
            Console.WriteLine($"║ Subtractions:    {_form.totalNumberOfSubtractionDone,-18} ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine($"║ Hard Add:        {_form.Difficulty_Hard_addition_unlocked,-18} ║");
            Console.WriteLine($"║ Insane Add:      {_form.Difficulty_Insane_addition_unlocked,-18} ║");
            Console.WriteLine($"║ Hard Sub:        {_form.Difficulty_Hard_subtraction_unlocked,-18} ║");
            Console.WriteLine($"║ Insane Sub:      {_form.Difficulty_Insane_subtraction_unlocked,-18} ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine($"║ Red Stars:       {_form.RedStarNumber,-18} ║");
            Console.WriteLine($"║ Blue Stars:      {_form.BlueStarNumber,-18} ║");
            Console.WriteLine($"║ Yellow Stars:    {_form.YellowStarNumber,-18} ║");
            Console.WriteLine($"║ Purple Stars:    {_form.PurpleStarNumber,-18} ║");
            Console.WriteLine($"║ Dark Matter:     {_form.DarkMatterNumber,-18} ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
            Console.WriteLine();

            logger.LogSuccess("Inspection complete");
#endif
        }
    }

    // ==================== FORM COMMAND ====================

    public class FormCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "form";
        public string Description => "Open a game form (shop, stats, about)";
        public string Parameters => "[shop|stats|about]";

        public FormCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            if (string.IsNullOrWhiteSpace(args))
            {
                logger.LogError("Usage: form [shop|stats|about]");
                return;
            }

            string target = args.Trim().ToLower();

            switch (target)
            {
                case "shop":
                    _form.Invoke(() =>
                    {
                        Shop shopForm = new Shop();
                        shopForm.ShowDialog();
                    });
                    logger.LogSuccess("Shop form opened");
                    break;

                case "stats":
                    _form.Invoke(() =>
                    {
                        Statistics statsForm = new Statistics();
                        statsForm.ShowDialog();
                    });
                    logger.LogSuccess("Statistics form opened");
                    break;

                case "about":
                    _form.Invoke(() =>
                    {
                        AboutBox1 aboutForm = new AboutBox1();
                        aboutForm.ShowDialog();
                    });
                    logger.LogSuccess("About form opened");
                    break;

                default:
                    logger.LogError($"Unknown form: {target}. Use shop, stats, or about");
                    break;
            }
#endif
        }
    }

    // ==================== MATH TEST COMMAND ====================

    public class MathTestCommand : IDebugCommand
    {
        private readonly QuickMath _form;

        public string Name => "math_test";
        public string Description => "Generate N test problems and log their answers";
        public string Parameters => "[count=5]";

        public MathTestCommand(QuickMath form) => _form = form;

        public void Execute(string args, IDebugLogger logger)
        {
#if DEBUG
            int count = 5;
            if (!string.IsNullOrWhiteSpace(args))
                int.TryParse(args, out count);

            if (count < 1 || count > 100)
            {
                logger.LogError("Count must be between 1 and 100");
                return;
            }

            string currentDifficulty = "Easy";
            _form.Invoke(() =>
            {
                currentDifficulty = _form.DifficultySelect?.SelectedItem?.ToString() ?? "Easy";
            });

            Console.WriteLine();
            Console.WriteLine($"╔══════════════════════════════════════════════╗");
            Console.WriteLine($"║  Math Test ({count} problems, {currentDifficulty})       ║");
            Console.WriteLine($"╠══════════════════════════════════════════════╣");

            var rng = new Random();
            int correct = 0;

            for (int i = 0; i < count; i++)
            {
                bool isAddition = rng.Next(2) == 0;
                (int a, int b) = GenerateOperands(currentDifficulty, isAddition, rng);
                int answer = isAddition ? a + b : a - b;
                string op = isAddition ? "+" : "-";

                Console.WriteLine($"║  {i + 1,2}. {a,3} {op} {b,3} = {answer,-5}                ║");
                correct++;
            }

            Console.WriteLine($"╠══════════════════════════════════════════════╣");
            Console.WriteLine($"║  All {count} problems generated (for reference)  ║");
            Console.WriteLine($"╚══════════════════════════════════════════════╝");
            Console.WriteLine();

            logger.LogSuccess($"Generated {count} math test problems");
#endif
        }

        private static (int, int) GenerateOperands(string difficulty, bool addition, Random rng)
        {
            int min = 1, max = 10;

            switch (difficulty.ToLower())
            {
                case "hard":
                    min = 20; max = 100;
                    break;
                case "insane":
                    min = 100; max = 500;
                    break;
                default:
                    min = 1; max = 10;
                    break;
            }

            int a = rng.Next(min, max + 1);
            int b = rng.Next(min, max + 1);

            if (!addition && b > a)
                (a, b) = (b, a);

            return (a, b);
        }
    }
}
