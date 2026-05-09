# QuickMath Desktop Development Roadmap

**Project Version:** 0.3.0 | **Last Updated:** May 7, 2026 | **Status:** Active Development

---

## Quick Overview

QuickMath Desktop is a Windows Forms-based mental math training application. This document outlines everything that needs to be done, roughly how to do it, and in what order. The project has working core features but requires significant improvements to be production-ready.

**Current State:** 70% feature complete, but 40% technical debt

---

## Phase 1: Critical Fixes (MUST DO - 1-2 weeks)

These issues must be fixed before any new releases. They affect data integrity and app balance.

### 1. Fix File Extension Mismatch (CRITICAL - Do First!)

**Problem:**

- `Form1.cs` saves user data as `.qms` files
- `Shop.cs` reads/writes `.json` files
- Result: Shop purchases aren't saved; data corruption

**What to Do:**

1. Open `Shop.cs` and find all instances of `.json`
2. Replace with `.qms` (same format as Form1)
3. Test by:
   - Starting a new game
   - Buying an item in the shop
   - Closing and reopening the app
   - Verify the purchase persists

**How to Implement:**

```
In Shop.cs, change:
- Line ~100: string filename = Path.Combine(..., "QuickMath_UserData.json");
To:
- string filename = Path.Combine(..., "QuickMath_UserData.qms");
```

**Time Estimate:** 30 minutes  
**Impact:** Critical - Blocks save/load functionality  
**Difficulty:** Very Easy

---

### 2. Remove/Secure Debug Mode

**Problem:**

- `public bool DebugMode = false;` in Form1.cs and Shop.cs
- If set to `true`, grants infinite XP/coins
- Ships with this public flag

**What to Do:**

1. Remove the public `DebugMode` boolean fields

2. If debug features needed, use conditional compilation instead:
   
   ```csharp
   #if DEBUG
       // Debug-only code here
   #endif
   ```

3. Or use an environment variable check instead of public field

**How to Implement:**

- Search for `DebugMode` in both Form1.cs and Shop.cs
- Remove the field declarations
- Comment out any code that uses it (probably none)
- Rebuild and test

**Time Estimate:** 30 minutes  
**Impact:** High - Security/balance issue  
**Difficulty:** Very Easy

---

### 3. Add Basic Error Handling for File I/O

**Problem:**

- No try-catch around `AutoLoadUserData()` and `saveUserData_Local()`
- Corrupted JSON file crashes the entire app
- No data backup mechanism

**What to Do:**

1. Wrap all file I/O in try-catch blocks
2. Create automatic backup before saving
3. Show user-friendly error messages
4. Load from backup if current file is corrupted

**How to Implement:**

```csharp
// In Form1.cs AutoLoadUserData() method:
try
{
    if (File.Exists(filename))
    {
        // Create backup first
        string backupFile = filename + ".backup";
        File.Copy(filename, backupFile, overwrite: true);

        // Load file
        string jsonContent = File.ReadAllText(filename);
        // ... rest of code
    }
}
catch (Exception ex)
{
    MessageBox.Show(
        $"Error loading save file. Backed up to: {filename}.backup\n" +
        $"Starting fresh. Error: {ex.Message}",
        "Save File Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
    );
    // Initialize with default values
}
```

**Locations to Update:**

- Form1.cs: `AutoLoadUserData()` method
- Form1.cs: `saveUserData_Local()` method
- Shop.cs: Save method
- Statistics.cs: Load method

**Time Estimate:** 2-3 hours  
**Impact:** High - Prevents data loss  
**Difficulty:** Easy

---

## Phase 2: Architecture Improvements (2-3 weeks)

These improvements make the code maintainable and testable. Do Phase 1 first.

### 4. Extract Data Persistence Layer

**Problem:**

- UserData loading code duplicated in 3 files (Form1, Shop, Statistics)
- Each form manually parses JSON
- Changes must be made in 3 places
- Increases chance of sync bugs

**What to Do:**

1. Create new class: `UserDataRepository.cs`
2. Move all JSON load/save logic there
3. All forms call this one class instead
4. Add basic validation

**How to Implement:**

```csharp
// Create new file: QuickMath/Services/UserDataRepository.cs
public class UserDataRepository
{
    private readonly string _filePath;

    public UserDataRepository(string savePath)
    {
        _filePath = Path.Combine(savePath, "QuickMath_UserData.qms");
    }

    public UserData LoadUserData()
    {
        try
        {
            if (!File.Exists(_filePath))
                return GetDefaultUserData();

            string json = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<UserData>(json);
            return data ?? GetDefaultUserData();
        }
        catch
        {
            // Handle error, return default
            return GetDefaultUserData();
        }
    }

    public void SaveUserData(UserData data)
    {
        try
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to save: {ex.Message}");
        }
    }

    private UserData GetDefaultUserData()
    {
        return new UserData { XP = 0, coins = 0, UserName = "Player" };
    }
}
```

**Then in Form1.cs:**

```csharp
private UserDataRepository _dataRepository;

// In Form1_Load:
_dataRepository = new UserDataRepository(Application.LocalUserAppDataPath);
var userData = _dataRepository.LoadUserData();
// Apply loaded data to form fields
```

**Benefits:**

- Single source of truth for data access
- Easier to add versioning/migration
- Easier to test
- Forms only care about UI logic

**Time Estimate:** 4-6 hours  
**Impact:** Medium - Prevents sync bugs  
**Difficulty:** Medium

---

### 5. Create Configuration System

**Problem:**

- XP rewards hardcoded throughout Form1.cs
- Coin amounts hardcoded
- Difficulty ranges hardcoded
- Can't balance game without recompiling

**What to Do:**

1. Create `GameConfig.cs` with all constants
2. Use enums for difficulty levels and math types
3. Data-driven approach instead of magic numbers

**How to Implement:**

```csharp
// Create: QuickMath/Config/GameConfig.cs
public static class GameConfig
{
    public enum MathType { Addition, Subtraction, Multiplication, Division }
    public enum Difficulty { EasyPlus, Easy, Medium, Hard, Insane }

    public static class AdditionRewards
    {
        public static readonly Dictionary<Difficulty, (int xp, float coins)> Rewards = 
            new()
            {
                { Difficulty.EasyPlus, (1, 0.25f) },
                { Difficulty.Easy, (5, 0.5f) },
                { Difficulty.Medium, (10, 1f) },
                { Difficulty.Hard, (20, 2f) },
                { Difficulty.Insane, (40, 4f) }
            };
    }

    public static class ShopPrices
    {
        public const int HardAddition = 5;
        public const int InsaneAddition = 10;
        public const int HardSubtraction = 10;
        public const int InsaneSubtraction = 20;
    }

    public static class DifficultyRanges
    {
        public static (int min, int max) GetAdditionRange(Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.EasyPlus => (1, 10),
                Difficulty.Easy => (1, 50),
                Difficulty.Medium => (1, 100),
                Difficulty.Hard => (50, 500),
                Difficulty.Insane => (100, 1000),
                _ => (1, 10)
            };
        }
        // Similar methods for other operations
    }
}
```

**Then in Form1.cs:**

```csharp
// Instead of:
int xpAward = 10;  // Magic number

// Use:
var reward = GameConfig.AdditionRewards.Rewards[GameConfig.Difficulty.Medium];
int xpAward = reward.xp;
float coinAward = reward.coins;
```

**Benefits:**

- All game balance in one place
- Easy to adjust without touching game logic
- Type-safe enums instead of string comparisons
- Easier to understand code intent

**Time Estimate:** 3-4 hours  
**Impact:** High - Enables easy balancing  
**Difficulty:** Easy

---

### 6. Extract Game Logic

**Problem:**

- Form1.cs has 420 lines mixing UI, game logic, and data persistence
- Hard to test math generation
- Hard to reuse logic if we make multiplayer version

**What to Do:**

1. Create `GameEngine.cs` for all math generation
2. Create `RewardCalculator.cs` for XP/coin calculation
3. Forms become thin UI layers

**How to Implement:**

```csharp
// Create: QuickMath/GameEngine.cs
public class GameEngine
{
    private readonly Random _random = new();

    public (int operand1, int operand2) GenerateAdditionProblem(GameConfig.Difficulty difficulty)
    {
        var (min, max) = GameConfig.DifficultyRanges.GetAdditionRange(difficulty);
        int op1 = _random.Next(min, max + 1);
        int op2 = _random.Next(min, max + 1);
        return (op1, op2);
    }

    public bool ValidateAnswer(int operand1, int operand2, int userAnswer, GameConfig.MathType type)
    {
        int correct = type switch
        {
            GameConfig.MathType.Addition => operand1 + operand2,
            GameConfig.MathType.Subtraction => operand1 - operand2,
            _ => 0
        };
        return userAnswer == correct;
    }
}

// Create: QuickMath/RewardCalculator.cs
public class RewardCalculator
{
    public (int xp, float coins) CalculateReward(GameConfig.MathType type, GameConfig.Difficulty difficulty)
    {
        return type switch
        {
            GameConfig.MathType.Addition => GameConfig.AdditionRewards.Rewards[difficulty],
            GameConfig.MathType.Subtraction => GameConfig.SubtractionRewards.Rewards[difficulty],
            _ => (0, 0f)
        };
    }
}
```

**Then in Form1.cs:**

```csharp
private GameEngine _gameEngine = new();
private RewardCalculator _rewardCalculator = new();

private void StartMath_addition()
{
    var (op1, op2) = _gameEngine.GenerateAdditionProblem(difficulty);
    CurrentProblem = $"{op1} + {op2} = ?";
    CurrentAnswer = op1 + op2;
}

private void CheckAnswer()
{
    if (_gameEngine.ValidateAnswer(CurrentOperand1, CurrentOperand2, userInput, type))
    {
        var (xp, coins) = _rewardCalculator.CalculateReward(type, difficulty);
        AwardReward(xp, coins);
    }
}
```

**Benefits:**

- Unit testable logic
- Reusable in other forms
- Easier to debug math generation
- Clear separation: Form = UI, Engine = Logic

**Time Estimate:** 6-8 hours  
**Impact:** High - Enables testing  
**Difficulty:** Medium

---

### 7. Fix and Complete Shop System

**Problem:**

- Star cosmetics data saved but not displayed
- Only Red Star tracked in save file
- Blue/Yellow/Purple/DarkMatter stars lost after purchase

**What to Do:**

1. Ensure all 5 cosmetic items tracked in save file
2. Add display in main Form1 (e.g., show star count)
3. Verify purchases persist across app restart

**How to Implement:**

```csharp
// In UserData.cs model, ensure these fields exist:
public int RedStarNumber { get; set; }
public int BlueStarNumber { get; set; }
public int YellowStarNumber { get; set; }
public int PurpleStarNumber { get; set; }
public int DarkMatterNumber { get; set; }

// In Shop.cs purchase logic:
if (itemName.Contains("Red Star"))
    userData.RedStarNumber += quantity;
else if (itemName.Contains("Blue Star"))
    userData.BlueStarNumber += quantity;
// ... etc

// Save updated data
_dataRepository.SaveUserData(userData);

// In Form1.cs, add label to display cosmetics:
labelCosmetics.Text = $"⭐ Red: {userData.RedStarNumber} Blue: {userData.BlueStarNumber}";
```

**Time Estimate:** 3-4 hours  
**Impact:** Medium - Completes feature  
**Difficulty:** Easy

---

## Phase 3: Feature Completion (3-4 weeks)

These add new content. Do Phase 1 & 2 first.

### 8. Implement Multiplication & Division

**Problem:**

- UI mentions multiplication and division
- Only shows "coming soon" (GUI locked)
- No implementation at all

**What to Do:**

1. Add game logic for multiplication and division
2. Define difficulty levels and ranges
3. Define XP/coin rewards
4. Test each operation

**How to Implement:**

```csharp
// In GameConfig.cs, add:
public static class MultiplicationRewards
{
    public static readonly Dictionary<Difficulty, (int xp, float coins)> Rewards = 
        new()
        {
            { Difficulty.EasyPlus, (2, 0.5f) },    // 1-10 × 1-10
            { Difficulty.Easy, (5, 1f) },          // 1-12 × 1-12
            { Difficulty.Medium, (12, 2f) },       // 1-20 × 1-20
            { Difficulty.Hard, (25, 4f) },         // 10-50 × 10-50
            { Difficulty.Insane, (50, 8f) }        // 50-100 × 50-100
        };
}

// In GameEngine.cs, add:
public (int operand1, int operand2) GenerateMultiplicationProblem(Difficulty difficulty)
{
    var (min, max) = GameConfig.DifficultyRanges.GetMultiplicationRange(difficulty);
    int op1 = _random.Next(min, max + 1);
    int op2 = _random.Next(min, max + 1);
    return (op1, op2);
}

// In Form1.cs StartMath_multiplication():
else if (TypeOfMath.SelectedItem == "multiplication")
{
    var difficulty = GetSelectedDifficulty();
    if (!UserHasUnlock(MathType.Multiplication, difficulty))
        return;  // Show message if locked

    var (op1, op2) = _gameEngine.GenerateMultiplicationProblem(difficulty);
    CurrentProblem = $"{op1} × {op2} = ?";
    CurrentAnswer = op1 * op2;
    CurrentOperand1 = op1;
    CurrentOperand2 = op2;
    CurrentMathType = MathType.Multiplication;
    UnlockGUI();
}
```

**Time Estimate:** 8-10 hours  
**Impact:** High - Doubles content  
**Difficulty:** Medium

---

### 9. Implement Achievement System

**Problem:**

- Statistics form has space for achievements
- No achievement logic implemented
- No rewards for milestones

**What to Do:**

1. Define achievement milestones (e.g., "Solve 100 problems")
2. Create achievement checker
3. Add UI to display earned achievements
4. Add rewards (cosmetics, XP bonuses)

**How to Implement:**

```csharp
// Create: QuickMath/Achievements/Achievement.cs
public class Achievement
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsUnlocked { get; set; }
    public DateTime? UnlockedDate { get; set; }
}

// Create: QuickMath/Achievements/AchievementChecker.cs
public class AchievementChecker
{
    public List<Achievement> CheckAchievements(UserData userData)
    {
        var achievements = new List<Achievement>();

        achievements.Add(new Achievement
        {
            Id = "first_problem",
            Name = "First Step",
            Description = "Solve your first math problem",
            IsUnlocked = userData.TotalNumberOfMathDone >= 1
        });

        achievements.Add(new Achievement
        {
            Id = "hundred_problems",
            Name = "Century",
            Description = "Solve 100 math problems",
            IsUnlocked = userData.TotalNumberOfMathDone >= 100
        });

        achievements.Add(new Achievement
        {
            Id = "thousand_xp",
            Name = "XP Master",
            Description = "Earn 1000 XP",
            IsUnlocked = userData.XP >= 1000
        });

        // More achievements...

        return achievements;
    }
}

// In Statistics.cs, display achievements:
var checker = new AchievementChecker();
var achievements = checker.CheckAchievements(userData);

foreach (var achievement in achievements)
{
    if (achievement.IsUnlocked)
    {
        treeViewStats.Nodes.Add(new TreeNode($"✓ {achievement.Name}"));
    }
}
```

**Time Estimate:** 6-8 hours  
**Impact:** Medium - Adds engagement  
**Difficulty:** Medium

---

### 10. Implement Leaderboard (Optional - Future)

**Problem:**

- Not mentioned in current code
- Would require backend/database
- Out of scope for offline app unless local-only

**What to Do:**

1. If online: Design API endpoints, create backend
2. If local: Just track top 10 local scores
3. Display in new form

**Note:** This depends on whether QuickMath Desktop should be online or remain offline.

**Time Estimate:** 12-15 hours (if online), 4-5 hours (if local-only)  
**Impact:** Medium - Adds social element  
**Difficulty:** Hard (online) / Easy (local)

---

## Phase 4: Polish & Testing (2-3 weeks)

Final preparations before production release.

### 11. Write Unit Tests

**Problem:**

- No automated tests
- No regression prevention
- Can't refactor safely

**What to Do:**

1. Create test project: `QuickMath.Tests`
2. Write tests for game logic
3. Write tests for data persistence
4. Aim for 80%+ code coverage

**How to Implement:**

```csharp
// Create: QuickMath.Tests/GameEngineTests.cs
using NUnit.Framework;

[TestFixture]
public class GameEngineTests
{
    private GameEngine _engine;

    [SetUp]
    public void Setup()
    {
        _engine = new GameEngine();
    }

    [Test]
    public void GenerateAdditionProblem_ReturnsValidNumbers()
    {
        var (op1, op2) = _engine.GenerateAdditionProblem(Difficulty.Easy);

        Assert.That(op1, Is.GreaterThanOrEqualTo(1));
        Assert.That(op1, Is.LessThanOrEqualTo(50));
        Assert.That(op2, Is.GreaterThanOrEqualTo(1));
        Assert.That(op2, Is.LessThanOrEqualTo(50));
    }

    [Test]
    public void ValidateAnswer_CorrectAnswer_ReturnsTrue()
    {
        bool result = _engine.ValidateAnswer(5, 3, 8, MathType.Addition);
        Assert.IsTrue(result);
    }

    [Test]
    public void ValidateAnswer_WrongAnswer_ReturnsFalse()
    {
        bool result = _engine.ValidateAnswer(5, 3, 7, MathType.Addition);
        Assert.IsFalse(result);
    }
}
```

**Time Estimate:** 8-12 hours  
**Impact:** High - Prevents bugs  
**Difficulty:** Medium

---

### 12. UI/UX Improvements

**Problem:**

- Fixed pixel-perfect layout (not responsive)
- No animations or transitions
- Limited visual feedback

**What to Do:**

1. Make forms responsive to window size
2. Add smooth transitions
3. Add success/error animations
4. Improve button feedback

**How to Implement:**

- Use TableLayoutPanel for responsive layout
- Add visual effects on correct/incorrect answers
- Add color transitions (green for correct, red for incorrect)
- Smooth XP/coin counter animations

**Time Estimate:** 10-12 hours  
**Impact:** Medium - Improves feel  
**Difficulty:** Medium

---

### 13. Add Comprehensive Documentation

**Problem:**

- No XML documentation
- No developer guide
- No contribution guidelines

**What to Do:**

1. Add XML comments to all public methods
2. Create ARCHITECTURE.md
3. Create CONTRIBUTING.md
4. Create SETUP.md for developers

**Example:**

```csharp
/// <summary>
/// Generates an addition problem with the specified difficulty level.
/// </summary>
/// <param name="difficulty">The difficulty level determining the number range.</param>
/// <returns>A tuple containing two operands for the addition problem.</returns>
public (int operand1, int operand2) GenerateAdditionProblem(Difficulty difficulty)
{
    // Implementation...
}
```

**Time Estimate:** 4-5 hours  
**Impact:** Medium - Helps contributions  
**Difficulty:** Easy

---

### 14. Performance Optimization

**Problem:**

- App startup could be slower
- JSON serialization on every save
- Unused dependencies (AngouriMath, LiteDB)

**What to Do:**

1. Remove unused NuGet packages
2. Profile startup time
3. Consider lazy loading for cosmetics
4. Optimize JSON serialization

**How to Implement:**

```csharp
// In QuickMath.csproj, remove:
<PackageReference Include="AngouriMath" Version="1.4.0" />
<PackageReference Include="LiteDB" Version="5.0.21" />

// Profile startup using diagnostics:
var stopwatch = Stopwatch.StartNew();
var userData = _dataRepository.LoadUserData();
stopwatch.Stop();
Debug.WriteLine($"Load time: {stopwatch.ElapsedMilliseconds}ms");
```

**Time Estimate:** 4-6 hours  
**Impact:** Low - Marginal improvement  
**Difficulty:** Medium

---

## Implementation Timeline

### Recommended Order (Don't Skip Phase 1!)

```
Week 1-2: Phase 1 - CRITICAL FIXES
  - Day 1: Fix file extension mismatch
  - Day 1: Remove debug mode
  - Days 2-3: Add error handling

Week 3-4: Phase 2 - ARCHITECTURE
  - Days 1-2: Extract data repository
  - Day 2: Create config system
  - Days 3-4: Extract game logic
  - Day 4: Complete shop system

Week 5-7: Phase 3 - FEATURES
  - Days 1-2: Implement multiplication/division
  - Days 3-4: Implement achievements

Week 8-10: Phase 4 - TESTING & POLISH
  - Days 1-2: Write unit tests
  - Days 3-4: UI improvements
  - Day 5: Documentation
  - Day 5: Performance optimization

TOTAL: ~10 weeks (rough estimate)
```

---

## Quick Reference: Things to Delete (Dead Code)

These files can be safely deleted after Phase 2:

- `UserData.cs` (replaced by repository pattern)
- `SaveUserDataJson.cs` (placeholder, no code)
- `AppData/ShopItem.cs` (empty placeholder)
- `Services/ShopService.cs` (empty)
- `Services/ShopServices.cs` (empty, duplicate)

---

## Testing Checklist

Before each release, verify:

- [ ] Can create new user account
- [ ] Can play addition/subtraction
- [ ] XP and coins award correctly
- [ ] Can unlock difficulties in shop
- [ ] Shop purchases persist after restart
- [ ] Statistics display correct totals
- [ ] Update checker works
- [ ] No crashes on corrupted save file
- [ ] Cosmetics persist after purchase
- [ ] All game math is correct

---

## Common Questions

**Q: How do I run the app?**
A: Open Visual Studio, build the project, press F5 to debug.

**Q: Where is the user data saved?**
A: In `%LOCALAPPDATA%\QuickMath_Desktop\` as `.qms` files.

**Q: Can I test without phase 1 fixes?**
A: No! Phase 1 fixes critical bugs that lose player data.

**Q: Should I do all features in phase 3?**
A: No, complete Phase 1 and 2 first, then pick features by priority.

**Q: How do I know what to work on next?**
A: Follow the numbered list above. Each builds on the previous.

---

## Getting Help

- Review the [Project Analysis Report] for detailed code locations
- Check existing code for patterns and conventions
- Test manually after each significant change
- Commit frequently with descriptive messages

---
