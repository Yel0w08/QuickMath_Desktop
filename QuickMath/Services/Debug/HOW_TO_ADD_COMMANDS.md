# How to Add New Debug Commands

This guide explains how to easily add new debug commands to QuickMath Desktop.

## Overview

The new debug system uses a **Command Pattern** with easy extensibility. To add a new command, you just need to:

1. Create a class implementing `IDebugCommand`
2. Register it in `DebugService.RegisterCommands()`

That's it! No need to modify any other code.

## Example: Adding a "give_all" Command

### Step 1: Create the Command Class

Add this to `Services/Debug/DebugCommands.cs`:

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

### Step 2: Register the Command

In `DebugService.cs`, add this line in `RegisterCommands()`:

```csharp
private void RegisterCommands()
{
    // ... existing commands ...
    
    // My new command
    Register(new GiveAllCommand(_form));
}
```

### Step 3: Test It

Run the app in Debug mode and type in the console:
```
> give_all 100 50
```

You should see:
```
[OK] 14:32:15 — Added 100 coins and 50 XP
```

## IDebugCommand Interface

Every command must implement this interface:

```csharp
public interface IDebugCommand
{
    string Name { get; }              // Command name (lowercase)
    string Description { get; }       // Description for help
    string Parameters { get; }        // Parameter description
    void Execute(string args, IDebugLogger logger);
}
```

### Properties Explained

- **Name**: The command name users type (e.g., "give_coins")
- **Description**: Short description shown in help menu
- **Parameters**: Shows what parameters are needed (e.g., "[amount]" or "[coins] [xp]")
- **Execute**: The method that runs when the command is called

## IDebugLogger Interface

Use the logger to output messages:

```csharp
logger.Log(message);           // Regular info
logger.LogError(message);      // Red error
logger.LogSuccess(message);    // Green success
logger.LogWarning(message);    // Yellow warning
```

## Tips for Writing Commands

### 1. Always Validate Input

```csharp
if (string.IsNullOrWhiteSpace(args))
{
    logger.LogError("Usage: command_name [parameter]");
    return;
}

if (!int.TryParse(args, out int value))
{
    logger.LogError($"Invalid value: {args}");
    return;
}
```

### 2. Use Form.Invoke() for UI Operations

If your command modifies the UI, wrap the call in `Form.Invoke()`:

```csharp
_form.Invoke(() => _form.ReLoadGUI());
```

### 3. Provide Feedback

Always tell the user what happened:

```csharp
logger.LogSuccess($"Added {amount} coins. Total: {_form.coins}");
```

### 4. Group Related Commands

Create separate commands for similar operations:

```csharp
"give_coins"      // Give coins
"set_coins"       // Set coins to exact value
"give_xp"         // Give XP
"set_xp"          // Set XP to exact value
```

## Current Available Commands

### Economy
- `give_coins [amount]` - Add coins
- `give_xp [amount]` - Add XP
- `set_coins [amount]` - Set coins to value
- `set_xp [amount]` - Set XP to value

### Unlock
- `unlock_all` - Unlock all difficulties
- `unlock_addition` - Unlock addition difficulties
- `unlock_subtraction` - Unlock subtraction difficulties

### Game State
- `reload_userdata` - Reload save file
- `save_userdata` - Force save
- `reset_stats` - Reset all statistics
- `reload_gui` - Refresh UI elements

### System
- `help` - Show available commands
- `clear` - Clear console
- `exit` - Close console

## Auto-completion

The console supports Tab auto-completion:
- Type `giv` and press Tab → auto-completes to one of: `give_coins`, `give_xp`
- Type `unl` and press Tab → auto-completes to `unlock_all` (if unique)

## Example: Adding a Command with Multiple Parameters

```csharp
public class SetDifficultiesCommand : IDebugCommand
{
    private readonly QuickMath _form;

    public string Name => "set_difficulties";
    public string Description => "Set difficulty unlock status";
    public string Parameters => "[addition_hard] [addition_insane] [subtraction_hard] [subtraction_insane]";

    public SetDifficultiesCommand(QuickMath form) => _form = form;

    public void Execute(string args, IDebugLogger logger)
    {
        var parts = args.Split(' ');
        if (parts.Length != 4)
        {
            logger.LogError("Usage: set_difficulties [0/1] [0/1] [0/1] [0/1]");
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

Then register it:
```csharp
Register(new SetDifficultiesCommand(_form));
```

## Troubleshooting

**Debug console doesn't appear:**
- Make sure you're running in Debug mode (not Release)
- Check that `#if DEBUG` is properly used

**Command not found:**
- Make sure you registered it in `RegisterCommands()`
- Check command name matches exactly (case-insensitive but must exist)

**Command fails with error:**
- Check the error message in console
- Validate all input parameters
- Make sure Form.Invoke() is used for UI operations

## Advanced: Accessing Game State

You can access any public field or method on the form:

```csharp
public class PrintStatsCommand : IDebugCommand
{
    private readonly QuickMath _form;
    
    public string Name => "print_stats";
    public string Description => "Print current statistics";
    public string Parameters => "";
    
    public PrintStatsCommand(QuickMath form) => _form = form;
    
    public void Execute(string args, IDebugLogger logger)
    {
        logger.Log($"XP: {_form.XP}");
        logger.Log($"Coins: {_form.coins}");
        logger.Log($"Total Math Done: {_form.totalNumberOfMathDone}");
        logger.Log($"Addition Done: {_form.totalNumberOfAdditionDone}");
        logger.Log($"Subtraction Done: {_form.totalNumberOfSubtractionDone}");
    }
}
```

---

**Happy debugging! 🐛**
