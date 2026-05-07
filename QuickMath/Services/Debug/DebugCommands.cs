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
}
