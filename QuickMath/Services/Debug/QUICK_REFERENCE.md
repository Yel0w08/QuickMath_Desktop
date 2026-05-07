# Debug System - Quick Reference Card

## Files Structure

```
QuickMath/Services/Debug/
├── IDebugCommand.cs          # Interfaces and logger
├── DebugService.cs           # Main service with command registry
├── DebugCommands.cs          # All command implementations
├── README.md                 # Full documentation
├── HOW_TO_ADD_COMMANDS.md    # Developer guide
└── QUICK_REFERENCE.md        # This file
```

## Current Commands (12 Total)

### Economy (4 commands)
```
give_coins [amount]    Add coins
give_xp [amount]       Add XP  
set_coins [amount]     Set coins to value
set_xp [amount]        Set XP to value
```

### Unlock (3 commands)
```
unlock_all             Unlock all difficulties
unlock_addition        Unlock addition only
unlock_subtraction     Unlock subtraction only
```

### Game State (4 commands)
```
reload_userdata        Reload save file
save_userdata          Force save
reset_stats            Reset statistics to 0
reload_gui             Refresh UI elements
```

### System (3 commands)
```
help                   Show all commands
clear                  Clear console
exit                   Close debug console
```

## Add New Command in 3 Steps

### 1. Create Class (in DebugCommands.cs)
```csharp
public class MyCommand : IDebugCommand
{
    private readonly QuickMath _form;
    
    public string Name => "my_command";
    public string Description => "What it does";
    public string Parameters => "[parameter]";
    
    public MyCommand(QuickMath form) => _form = form;
    
    public void Execute(string args, IDebugLogger logger)
    {
        // Your code here
        logger.LogSuccess("Done!");
    }
}
```

### 2. Register (in DebugService.RegisterCommands)
```csharp
Register(new MyCommand(_form));
```

### 3. Test
```
> my_command test_value
```

## Logger Methods

```csharp
logger.Log(message);           // Regular info
logger.LogSuccess(message);    // Green - success
logger.LogError(message);      // Red - error
logger.LogWarning(message);    // Yellow - warning
```

## Common Patterns

### Validate Input
```csharp
if (string.IsNullOrWhiteSpace(args))
{
    logger.LogError($"Usage: {Name} {Parameters}");
    return;
}

if (!int.TryParse(args, out int value))
{
    logger.LogError($"Invalid value: {args}");
    return;
}
```

### UI Operations
```csharp
// Always use Form.Invoke for thread safety
_form.Invoke(() => _form.ReLoadGUI());
logger.LogSuccess("UI reloaded");
```

### Provide Feedback
```csharp
// Good - shows context
logger.LogSuccess($"Added {amount}. Total: {_form.coins}");

// Bad - no context
logger.LogSuccess("Done");
```

## Example Commands

### Simple Value Add
```csharp
public class GiveCoinsCommand : IDebugCommand
{
    private readonly QuickMath _form;
    public string Name => "give_coins";
    public string Description => "Add coins";
    public string Parameters => "[amount]";
    
    public GiveCoinsCommand(QuickMath form) => _form = form;
    
    public void Execute(string args, IDebugLogger logger)
    {
        if (float.TryParse(args, out float amount))
        {
            _form.coins += amount;
            logger.LogSuccess($"Added {amount} coins");
        }
        else logger.LogError("Invalid amount");
    }
}
```

### Multi-Parameter
```csharp
public class MyMultiCommand : IDebugCommand
{
    public string Name => "multi";
    public string Description => "Does something";
    public string Parameters => "[param1] [param2]";
    
    public void Execute(string args, IDebugLogger logger)
    {
        var parts = args.Split(' ');
        if (parts.Length != 2)
        {
            logger.LogError($"Usage: {Name} {Parameters}");
            return;
        }
        
        // Use parts[0] and parts[1]
    }
}
```

## Environment

- ✅ Only active in **DEBUG** builds (automatically disabled in Release)
- ✅ Runs in **background thread** (doesn't block game)
- ✅ Thread-safe console input with **Tab auto-completion**
- ✅ **12 commands** pre-implemented
- ✅ **Easy to extend** - add new commands without modifying existing code

## Usage Examples

```bash
# Add 500 coins
> give_coins 500
[OK] 14:32:15 — Added 500 coins. Total: 1050

# Set XP to 1000
> set_xp 1000
[OK] 14:32:16 — XP set to 1000

# Unlock everything
> unlock_all
[OK] 14:32:17 — All difficulty levels unlocked

# Tab completion
> giv[TAB] → give_coins
> unl[TAB] → shows: unlock_all, unlock_addition, unlock_subtraction

# Show help
> help
# Displays all commands with descriptions

# Close console
> exit
```

## Tips & Tricks

### Auto-completion
- Type partial command name + Tab
- If unique: auto-completes
- If multiple: shows all options

### View All Commands
```bash
> help
```

### Find Specific Commands
```bash
> unl[TAB]
  unlock_all
  unlock_addition
  unlock_subtraction
```

### Reset Everything
```bash
> set_xp 0
> set_coins 0
> reset_stats
```

### Test Feature Quickly
```bash
> unlock_all
> set_coins 999
> set_xp 999
# Now test the shop!
```

## Access Form Fields

All public fields on Form1 are accessible:
```csharp
_form.XP
_form.coins
_form.totalNumberOfMathDone
_form.Difficulty_Hard_addition_unlocked
// ... etc
```

## Call Form Methods

Any public method on Form1:
```csharp
_form.AutoLoadUserData()          // Reload save
_form.saveUserData_Local_form1()  // Force save
_form.ReLoadGUI()                 // Refresh UI
_form.Invoke(...)                 // Call on UI thread
```

## Troubleshooting

| Problem | Solution |
|---------|----------|
| Console not appearing | Run Debug build (F5), not Release |
| Command not found | Check registration in RegisterCommands() |
| Tab not auto-completing | Focus console, type more characters |
| UI crashes | Use Form.Invoke() for UI operations |
| Changes don't appear | Rebuild project (Ctrl+Shift+B) |

## File Locations

- New commands: `QuickMath/Services/Debug/DebugCommands.cs`
- Register commands: `QuickMath/Services/Debug/DebugService.cs` (RegisterCommands method)
- Interfaces: `QuickMath/Services/Debug/IDebugCommand.cs`
- Documentation: `QuickMath/Services/Debug/README.md`

## Before Production

✅ Debug system is **automatically disabled** in Release builds
✅ No code changes needed
✅ No performance impact in production
✅ 100% safe to ship!

---

**Start here:** Open `README.md` in `Services/Debug/` folder for full documentation
