# QuickMath Debug System - Complete Guide

## Overview

The new Debug System is a professional, extensible command-based console that runs alongside your game in Debug mode. It allows developers and testers to quickly modify game state, unlock features, and test scenarios.

**Key Features:**
- ✅ Easy to add new commands
- ✅ Tab auto-completion
- ✅ Colored console output (Error, Success, Warning)
- ✅ Only active in DEBUG builds (automatically disabled in Release)
- ✅ Thread-safe console input
- ✅ Organized command help system

## Architecture

### File Structure

```
QuickMath/Services/Debug/
├── IDebugCommand.cs          # Interfaces (IDebugCommand, IDebugLogger)
├── ConsoleDebugLogger.cs     # Logger implementation
├── DebugService.cs           # Main service (command registry, console loop)
├── DebugCommands.cs          # All command implementations
├── HOW_TO_ADD_COMMANDS.md    # Developer guide
└── README.md                 # This file
```

### Architecture Diagram

```
┌─────────────────────────────────────────────────┐
│            DebugService                         │
│  (Singleton per Form)                           │
├─────────────────────────────────────────────────┤
│                                                 │
│  Command Registry:                              │
│  - give_coins → GiveCoinsCommand                │
│  - give_xp → GiveXPCommand                      │
│  - unlock_all → UnlockAllCommand                │
│  - ... etc                                      │
│                                                 │
│  ConsoleLoop()                                  │
│  - Reads user input (Thread.Background)         │
│  - Supports Tab auto-completion                 │
│  - Calls ProcessCommand()                       │
│                                                 │
└────────────┬────────────────────────────────────┘
             │
             ├─ Calls ProcessCommand(string input)
             │
             ├─ Splits input into [command] [args]
             │
             ├─ Looks up command in registry
             │
             └─ Calls Command.Execute(args, logger)
                         │
                         └─ Command uses logger to output
                            (LogSuccess, LogError, etc.)
```

## How It Works

### 1. Initialization

When the main form loads in DEBUG mode:

```csharp
public QuickMath()
{
    InitializeComponent();
    
    // Initialize debug service (only active in DEBUG mode)
    var debugService = new DebugService(this);
    
    // ... rest of initialization
}
```

### 2. Console Starts

The DebugService:
- ✅ Allocates a console window
- ✅ Registers all commands
- ✅ Starts a background thread for console input
- ✅ Displays a welcome message with help information

### 3. User Enters Command

User types in console and presses Enter:
```
> give_coins 100
```

### 4. Command Processing

1. Console thread intercepts the input
2. DebugService splits it: `["give_coins", "100"]`
3. Looks up "give_coins" in command registry
4. Calls `GiveCoinsCommand.Execute("100", logger)`
5. Command updates game state and logs result

### 5. Output

Console shows:
```
[OK] 14:32:15 — Added 100 coins. Total: 150
```

## Quick Start: Using Debug Console

### Enable Debug Console

1. Run the game in Visual Studio with Debug mode (F5)
2. A console window appears alongside the game

### Available Commands

Type `help` in the console to see all commands:

```
ECONOMY
  give_coins [amount]    Add coins
  give_xp [amount]       Add XP
  set_coins [amount]     Set coins to value
  set_xp [amount]        Set XP to value

UNLOCK
  unlock_all             Unlock all difficulties
  unlock_addition        Unlock addition difficulties
  unlock_subtraction     Unlock subtraction difficulties

GAME STATE
  reload_userdata        Reload save file
  save_userdata          Force save
  reset_stats            Reset all statistics
  reload_gui             Refresh UI elements

SYSTEM
  help                   Show this help message
  clear                  Clear console
  exit                   Close console
```

### Example Commands

```bash
# Add 500 coins
> give_coins 500

# Set XP to 1000
> set_xp 1000

# Unlock all difficulties
> unlock_all

# Reload user data from file
> reload_userdata

# Clear the screen
> clear

# Close debug console
> exit
```

### Tab Auto-completion

Start typing and press Tab:
```
> giv[TAB]
> give_coins  # Auto-completed!

> unl[TAB]
> unlock_all  # Auto-completed!
```

If multiple matches exist, they're all shown:
```
> un[TAB]
  unlock_all
  unlock_addition
  unlock_subtraction
> un
```

## Adding New Commands

### Quick Guide

1. Create a class implementing `IDebugCommand` in `DebugCommands.cs`
2. Implement the interface properties and `Execute` method
3. Register it in `DebugService.RegisterCommands()`

### Example: Adding "give_all" Command

**Step 1:** Add to `DebugCommands.cs`:

```csharp
public class GiveAllCommand : IDebugCommand
{
    private readonly QuickMath _form;

    public string Name => "give_all";
    public string Description => "Give both coins and XP";
    public string Parameters => "[coins] [xp]";

    public GiveAllCommand(QuickMath form) => _form = form;

    public void Execute(string args, IDebugLogger logger)
    {
        if (string.IsNullOrWhiteSpace(args))
        {
            logger.LogError("Usage: give_all [coins] [xp]");
            return;
        }

        var parts = args.Split(' ');
        if (parts.Length != 2)
        {
            logger.LogError("Usage: give_all [coins] [xp]");
            return;
        }

        if (float.TryParse(parts[0], out float coins) && int.TryParse(parts[1], out int xp))
        {
            _form.coins += coins;
            _form.XP += xp;
            logger.LogSuccess($"Added {coins} coins and {xp} XP");
        }
        else
        {
            logger.LogError("Invalid parameters");
        }
    }
}
```

**Step 2:** Register in `DebugService.cs`:

```csharp
private void RegisterCommands()
{
    // ... existing commands ...
    Register(new GiveAllCommand(_form));
}
```

**Step 3:** Test it:

```
> give_all 100 50
[OK] 14:32:15 — Added 100 coins and 50 XP
```

See `HOW_TO_ADD_COMMANDS.md` for more detailed examples and patterns.

## Design Patterns Used

### 1. Command Pattern
Each debug command is a separate class implementing `IDebugCommand`, making it easy to add new commands without modifying existing code.

### 2. Registry Pattern
Commands are registered in a dictionary, allowing dynamic lookup and execution.

### 3. Strategy Pattern
Logger interface allows different logging strategies (could swap ConsoleDebugLogger with FileDebugLogger, etc.).

### 4. Dependency Injection
Commands receive the form and logger as constructor parameters, reducing coupling.

## Code Examples

### Example 1: Simple Value Setter

```csharp
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
```

### Example 2: UI Modification (Requires Form.Invoke)

```csharp
public class ReloadGUICommand : IDebugCommand
{
    private readonly QuickMath _form;

    public string Name => "reload_gui";
    public string Description => "Reload the GUI";
    public string Parameters => "";

    public ReloadGUICommand(QuickMath form) => _form = form;

    public void Execute(string args, IDebugLogger logger)
    {
        // Use Form.Invoke for thread-safe UI updates
        _form.Invoke(() => _form.ReLoadGUI());
        logger.LogSuccess("GUI reloaded");
    }
}
```

### Example 3: Multi-Parameter Command

```csharp
public class SetDifficultiesCommand : IDebugCommand
{
    private readonly QuickMath _form;

    public string Name => "set_difficulties";
    public string Description => "Set difficulty unlock status";
    public string Parameters => "[hard_add] [insane_add] [hard_sub] [insane_sub]";

    public SetDifficultiesCommand(QuickMath form) => _form = form;

    public void Execute(string args, IDebugLogger logger)
    {
        var parts = args.Split(' ');
        if (parts.Length != 4)
        {
            logger.LogError($"Usage: {Name} {Parameters}");
            return;
        }

        try
        {
            _form.Difficulty_Hard_addition_unlocked = parts[0] == "1";
            _form.Difficulty_Insane_addition_unlocked = parts[1] == "1";
            _form.Difficulty_Hard_subtraction_unlocked = parts[2] == "1";
            _form.Difficulty_Insane_subtraction_unlocked = parts[3] == "1";
            
            logger.LogSuccess("Difficulty settings updated");
        }
        catch (Exception ex)
        {
            logger.LogError($"Failed to set difficulties: {ex.Message}");
        }
    }
}
```

## Logger Usage

### Available Methods

```csharp
logger.Log(message);           // White text - regular info
logger.LogSuccess(message);    // Green text - success feedback
logger.LogError(message);      // Red text - error feedback  
logger.LogWarning(message);    // Yellow text - warning feedback
```

### Examples

```csharp
logger.Log("Processing command...");
logger.LogSuccess("Command executed successfully!");
logger.LogError("Invalid input parameter");
logger.LogWarning("This action may have side effects");
```

## Best Practices

### 1. Always Validate Input

```csharp
if (string.IsNullOrWhiteSpace(args))
{
    logger.LogError($"Usage: {Name} {Parameters}");
    return;
}
```

### 2. Use Try-Catch for Risky Operations

```csharp
try
{
    _form.Invoke(() => _form.ReLoadGUI());
    logger.LogSuccess("GUI reloaded");
}
catch (Exception ex)
{
    logger.LogError($"Failed to reload GUI: {ex.Message}");
}
```

### 3. Provide Feedback

```csharp
// Good - shows before and after
logger.LogSuccess($"Added {amount} coins. Total: {_form.coins}");

// Bad - no context
logger.LogSuccess("Done");
```

### 4. Use Consistent Naming

- Commands: lowercase with underscores (`give_coins`, `unlock_all`)
- Classes: PascalCase with "Command" suffix (`GiveCoinsCommand`)
- Parameters: descriptive (`[amount]`, `[coins] [xp]`)

### 5. Group Related Commands

Create separate commands for similar operations:
- `give_coins` / `set_coins` (related: both manage coins)
- `give_xp` / `set_xp` (related: both manage XP)
- `unlock_all` / `unlock_addition` / `unlock_subtraction` (related: all unlock)

## Removing Commands

Simply don't register them in `RegisterCommands()`:

```csharp
private void RegisterCommands()
{
    // These will be available
    Register(new GiveCoinsCommand(_form));
    Register(new GiveXPCommand(_form));
    
    // This one won't be available (commented out)
    // Register(new UnusedCommand(_form));
}
```

Or delete the command class entirely if never used.

## Testing New Commands

1. Build and run the app in Debug mode
2. Type `help` in console to verify command appears
3. Test with valid input: `command_name valid_args`
4. Test with invalid input: `command_name invalid_args`
5. Verify error message is helpful

## Troubleshooting

### Debug Console Not Appearing

**Problem:** Console window doesn't appear when running Debug build

**Solutions:**
- Make sure you're running Debug build (F5 in Visual Studio)
- Check that `#if DEBUG` preprocessing is correct
- Verify `AllocConsole()` call succeeds

### Command Not Found

**Problem:** Command exists but shows "Unknown command"

**Solutions:**
- Check command name matches exactly (case doesn't matter for lookup, but Name property matters)
- Verify it's registered in `RegisterCommands()`
- Use `help` to list all available commands

### Auto-completion Not Working

**Problem:** Tab key doesn't auto-complete

**Solutions:**
- Make sure console window has focus
- Verify command name starts with typed text
- Type more characters if multiple matches exist

### "Error: form.Invoke() failed"

**Problem:** UI operation throws error

**Solutions:**
- Use `form.Invoke()` for ALL UI operations from background thread
- Wrap in try-catch to catch marshal exceptions
- Make sure the form is still alive (check if form is closed)

### Command Changes Don't Appear

**Problem:** Added new command but it doesn't show up

**Solutions:**
- Did you register it in `RegisterCommands()`?
- Did you rebuild the project (Ctrl+Shift+B)?
- Did you stop and restart the debug session?

## Performance Considerations

### Console Loop
- Runs on background thread (doesn't block game)
- Low CPU usage (awaits input)
- Safe for multi-threaded game state access

### Command Execution
- Most commands execute instantly
- UI operations use `Form.Invoke()` for thread safety
- No blocking operations in console thread

## Security Notes

### Only Available in Debug

The entire debug system is wrapped in `#if DEBUG`, so:
- ✅ Removed from Release builds
- ✅ No overhead in production
- ✅ No security risk from exposed debug commands

### What Debug Console Can Do

- ✅ Modify any public field on Form1
- ✅ Call any public method on Form1
- ✅ Access game state (XP, coins, unlocks)
- ✅ Force save/load operations

This is intentional for development/testing. Never expose this in production!

## Future Enhancements

Possible improvements:
- [ ] Command history (up/down arrow keys)
- [ ] File-based logging of commands
- [ ] Remote debug console (socket-based)
- [ ] Command macros/scripting
- [ ] Real-time value inspection
- [ ] Game state snapshots
- [ ] Command undo/redo

## Summary

The new Debug System makes it incredibly easy to:
- ✅ Add new debug commands (5 lines of code)
- ✅ Test game features quickly
- ✅ Modify game state instantly
- ✅ Verify implementation changes

All while keeping the code clean, organized, and secure!

---

**Happy debugging! 🐛**

For more details, see `HOW_TO_ADD_COMMANDS.md`
