namespace QuickMath.Infrastructure.Data;

/// <summary>
/// Contains the idempotent SQL schema and seed script executed on local startup.
/// </summary>
internal static class SqlScripts
{
    public const string InitialSchema = """
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'qm')
BEGIN
    EXEC('CREATE SCHEMA qm');
END;

IF OBJECT_ID('qm.Users', 'U') IS NULL
BEGIN
    CREATE TABLE qm.Users
    (
        UserId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserName NVARCHAR(100) NOT NULL,
        XP INT NOT NULL CONSTRAINT DF_Users_XP DEFAULT (0),
        Coins DECIMAL(12,2) NOT NULL CONSTRAINT DF_Users_Coins DEFAULT (0),
        IsActive BIT NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT (0),
        CreatedUtc DATETIME2(0) NOT NULL CONSTRAINT DF_Users_CreatedUtc DEFAULT (SYSUTCDATETIME()),
        LastPlayedUtc DATETIME2(0) NOT NULL CONSTRAINT DF_Users_LastPlayedUtc DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT UQ_Users_UserName UNIQUE (UserName)
    );
END;

IF OBJECT_ID('qm.MathOperations', 'U') IS NULL
BEGIN
    CREATE TABLE qm.MathOperations
    (
        OperationId INT NOT NULL PRIMARY KEY,
        OperationCode NVARCHAR(50) NOT NULL,
        DisplayName NVARCHAR(50) NOT NULL,
        CONSTRAINT UQ_MathOperations_Code UNIQUE (OperationCode)
    );
END;

IF OBJECT_ID('qm.DifficultyLevels', 'U') IS NULL
BEGIN
    CREATE TABLE qm.DifficultyLevels
    (
        DifficultyLevelId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        OperationId INT NOT NULL,
        DifficultyCode NVARCHAR(50) NOT NULL,
        DisplayName NVARCHAR(50) NOT NULL,
        MinOperand INT NOT NULL,
        MaxOperand INT NOT NULL,
        RewardXp INT NOT NULL,
        RewardCoins DECIMAL(12,2) NOT NULL,
        RequiredItemCode NVARCHAR(100) NULL,
        CONSTRAINT FK_DifficultyLevels_Operation FOREIGN KEY (OperationId) REFERENCES qm.MathOperations(OperationId),
        CONSTRAINT UQ_DifficultyLevels_Operation_Code UNIQUE (OperationId, DifficultyCode)
    );
END;

IF OBJECT_ID('qm.ShopCategories', 'U') IS NULL
BEGIN
    CREATE TABLE qm.ShopCategories
    (
        ShopCategoryId INT NOT NULL PRIMARY KEY,
        CategoryCode NVARCHAR(50) NOT NULL,
        DisplayName NVARCHAR(50) NOT NULL,
        CONSTRAINT UQ_ShopCategories_Code UNIQUE (CategoryCode)
    );
END;

IF OBJECT_ID('qm.ShopItems', 'U') IS NULL
BEGIN
    CREATE TABLE qm.ShopItems
    (
        ShopItemId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ShopCategoryId INT NOT NULL,
        ItemCode NVARCHAR(100) NOT NULL,
        DisplayName NVARCHAR(120) NOT NULL,
        PriceCoins DECIMAL(12,2) NOT NULL,
        IsRepeatable BIT NOT NULL,
        MinimumXpRequired INT NOT NULL CONSTRAINT DF_ShopItems_MinimumXp DEFAULT (0),
        CONSTRAINT FK_ShopItems_Category FOREIGN KEY (ShopCategoryId) REFERENCES qm.ShopCategories(ShopCategoryId),
        CONSTRAINT UQ_ShopItems_Code UNIQUE (ItemCode)
    );
END;

IF OBJECT_ID('qm.UserInventory', 'U') IS NULL
BEGIN
    CREATE TABLE qm.UserInventory
    (
        UserInventoryId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserId INT NOT NULL,
        ShopItemId INT NOT NULL,
        Quantity INT NOT NULL,
        AcquiredUtc DATETIME2(0) NOT NULL CONSTRAINT DF_UserInventory_AcquiredUtc DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_UserInventory_User FOREIGN KEY (UserId) REFERENCES qm.Users(UserId),
        CONSTRAINT FK_UserInventory_ShopItem FOREIGN KEY (ShopItemId) REFERENCES qm.ShopItems(ShopItemId),
        CONSTRAINT UQ_UserInventory_User_Item UNIQUE (UserId, ShopItemId)
    );
END;

IF OBJECT_ID('qm.ExerciseAttempts', 'U') IS NULL
BEGIN
    CREATE TABLE qm.ExerciseAttempts
    (
        ExerciseAttemptId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserId INT NOT NULL,
        OperationId INT NOT NULL,
        DifficultyLevelId INT NOT NULL,
        LeftOperand INT NOT NULL,
        RightOperand INT NOT NULL,
        ExpectedAnswer INT NOT NULL,
        SubmittedAnswer INT NOT NULL,
        IsCorrect BIT NOT NULL,
        AwardedXp INT NOT NULL,
        AwardedCoins DECIMAL(12,2) NOT NULL,
        AttemptedUtc DATETIME2(0) NOT NULL CONSTRAINT DF_ExerciseAttempts_AttemptedUtc DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_ExerciseAttempts_User FOREIGN KEY (UserId) REFERENCES qm.Users(UserId),
        CONSTRAINT FK_ExerciseAttempts_Operation FOREIGN KEY (OperationId) REFERENCES qm.MathOperations(OperationId),
        CONSTRAINT FK_ExerciseAttempts_Difficulty FOREIGN KEY (DifficultyLevelId) REFERENCES qm.DifficultyLevels(DifficultyLevelId)
    );
END;

IF OBJECT_ID('qm.CoinLedger', 'U') IS NULL
BEGIN
    CREATE TABLE qm.CoinLedger
    (
        CoinLedgerId BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        UserId INT NOT NULL,
        Amount DECIMAL(12,2) NOT NULL,
        EntryType NVARCHAR(50) NOT NULL,
        ReferenceCode NVARCHAR(100) NULL,
        CreatedUtc DATETIME2(0) NOT NULL CONSTRAINT DF_CoinLedger_CreatedUtc DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_CoinLedger_User FOREIGN KEY (UserId) REFERENCES qm.Users(UserId)
    );
END;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_ExerciseAttempts_User_AttemptedUtc' AND object_id = OBJECT_ID('qm.ExerciseAttempts'))
BEGIN
    CREATE INDEX IX_ExerciseAttempts_User_AttemptedUtc ON qm.ExerciseAttempts(UserId, AttemptedUtc DESC);
END;

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_CoinLedger_User_CreatedUtc' AND object_id = OBJECT_ID('qm.CoinLedger'))
BEGIN
    CREATE INDEX IX_CoinLedger_User_CreatedUtc ON qm.CoinLedger(UserId, CreatedUtc DESC);
END;

MERGE qm.MathOperations AS target
USING (VALUES
    (1, N'addition', N'Addition'),
    (2, N'subtraction', N'Subtraction')
) AS source (OperationId, OperationCode, DisplayName)
ON target.OperationId = source.OperationId
WHEN MATCHED THEN
    UPDATE SET OperationCode = source.OperationCode, DisplayName = source.DisplayName
WHEN NOT MATCHED THEN
    INSERT (OperationId, OperationCode, DisplayName)
    VALUES (source.OperationId, source.OperationCode, source.DisplayName);

MERGE qm.ShopCategories AS target
USING (VALUES
    (1, N'difficulty', N'Difficulty'),
    (2, N'stars', N'Stars')
) AS source (ShopCategoryId, CategoryCode, DisplayName)
ON target.ShopCategoryId = source.ShopCategoryId
WHEN MATCHED THEN
    UPDATE SET CategoryCode = source.CategoryCode, DisplayName = source.DisplayName
WHEN NOT MATCHED THEN
    INSERT (ShopCategoryId, CategoryCode, DisplayName)
    VALUES (source.ShopCategoryId, source.CategoryCode, source.DisplayName);

MERGE qm.DifficultyLevels AS target
USING (VALUES
    (1, N'easyplusplus', N'easy++', 1, 10, 1, CAST(0.25 AS DECIMAL(12,2)), NULL),
    (1, N'easy', N'easy', 1, 50, 5, CAST(0.50 AS DECIMAL(12,2)), NULL),
    (1, N'medium', N'medium', 1, 100, 10, CAST(1.00 AS DECIMAL(12,2)), NULL),
    (1, N'hard', N'hard', 50, 500, 20, CAST(2.00 AS DECIMAL(12,2)), N'addition-hard'),
    (1, N'insane', N'insane', 100, 1000, 40, CAST(4.00 AS DECIMAL(12,2)), N'addition-insane'),
    (2, N'easyplusplus', N'easy++', 1, 10, 2, CAST(0.50 AS DECIMAL(12,2)), NULL),
    (2, N'easy', N'easy', 1, 50, 10, CAST(1.00 AS DECIMAL(12,2)), NULL),
    (2, N'medium', N'medium', 1, 100, 15, CAST(1.50 AS DECIMAL(12,2)), NULL),
    (2, N'hard', N'hard', 50, 500, 20, CAST(2.00 AS DECIMAL(12,2)), N'subtraction-hard'),
    (2, N'insane', N'insane', 100, 1000, 40, CAST(4.00 AS DECIMAL(12,2)), N'subtraction-insane')
) AS source (OperationId, DifficultyCode, DisplayName, MinOperand, MaxOperand, RewardXp, RewardCoins, RequiredItemCode)
ON target.OperationId = source.OperationId AND target.DifficultyCode = source.DifficultyCode
WHEN MATCHED THEN UPDATE SET
    DisplayName = source.DisplayName,
    MinOperand = source.MinOperand,
    MaxOperand = source.MaxOperand,
    RewardXp = source.RewardXp,
    RewardCoins = source.RewardCoins,
    RequiredItemCode = source.RequiredItemCode
WHEN NOT MATCHED THEN
    INSERT (OperationId, DifficultyCode, DisplayName, MinOperand, MaxOperand, RewardXp, RewardCoins, RequiredItemCode)
    VALUES (source.OperationId, source.DifficultyCode, source.DisplayName, source.MinOperand, source.MaxOperand, source.RewardXp, source.RewardCoins, source.RequiredItemCode);

MERGE qm.ShopItems AS target
USING (VALUES
    (1, N'addition-hard', N'Hard Difficulty for addition', CAST(5.00 AS DECIMAL(12,2)), 0, 0),
    (1, N'addition-insane', N'Insane Difficulty for addition', CAST(10.00 AS DECIMAL(12,2)), 0, 0),
    (1, N'subtraction-hard', N'Hard Difficulty for subtraction', CAST(5.00 AS DECIMAL(12,2)), 0, 0),
    (1, N'subtraction-insane', N'Insane Difficulty for subtraction', CAST(10.00 AS DECIMAL(12,2)), 0, 0),
    (2, N'red-star', N'Red Star', CAST(100.00 AS DECIMAL(12,2)), 1, 100),
    (2, N'blue-star', N'Blue Star', CAST(100.00 AS DECIMAL(12,2)), 1, 100),
    (2, N'yellow-star', N'Yellow Star', CAST(150.00 AS DECIMAL(12,2)), 1, 100),
    (2, N'purple-star', N'Purple Star', CAST(150.00 AS DECIMAL(12,2)), 1, 100),
    (2, N'dark-matter', N'Dark Matter', CAST(1000.00 AS DECIMAL(12,2)), 1, 100)
) AS source (ShopCategoryId, ItemCode, DisplayName, PriceCoins, IsRepeatable, MinimumXpRequired)
ON target.ItemCode = source.ItemCode
WHEN MATCHED THEN UPDATE SET
    ShopCategoryId = source.ShopCategoryId,
    DisplayName = source.DisplayName,
    PriceCoins = source.PriceCoins,
    IsRepeatable = source.IsRepeatable,
    MinimumXpRequired = source.MinimumXpRequired
WHEN NOT MATCHED THEN
    INSERT (ShopCategoryId, ItemCode, DisplayName, PriceCoins, IsRepeatable, MinimumXpRequired)
    VALUES (source.ShopCategoryId, source.ItemCode, source.DisplayName, source.PriceCoins, source.IsRepeatable, source.MinimumXpRequired);
""";
}
