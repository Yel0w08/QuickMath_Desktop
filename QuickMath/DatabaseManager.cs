using System;
using System.IO;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Text.Json;

namespace QuickMath
{
    public static class DatabaseManager
    {
        private static string DbPath =>
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "QuickMath",
                "QuickMath.db"
            );

        private static string ConnectionString => $"Data Source={DbPath}";

        public static void Initialize()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(DbPath)!);

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open(); 

            connection.Execute(@"
        CREATE TABLE IF NOT EXISTS UserData (
            Id INTEGER PRIMARY KEY CHECK (Id = 1),
            UserName TEXT NOT NULL DEFAULT '',
            XP INTEGER NOT NULL DEFAULT 0,
            Coins REAL NOT NULL DEFAULT 0,
            TotalMathDone INTEGER NOT NULL DEFAULT 0,
            TotalAdditionDone INTEGER NOT NULL DEFAULT 0,
            TotalSubtractionDone INTEGER NOT NULL DEFAULT 0,
            Difficulty_Hard_addition_unlocked INTEGER NOT NULL DEFAULT 0,
            Difficulty_Insane_addition_unlocked INTEGER NOT NULL DEFAULT 0,
            Difficulty_Hard_subtraction_unlocked INTEGER NOT NULL DEFAULT 0,
            Difficulty_Insane_subtraction_unlocked INTEGER NOT NULL DEFAULT 0,
            RedStarNumber INTEGER NOT NULL DEFAULT 0,
            BluStarNumber INTEGER NOT NULL DEFAULT 0,
            YellowStarNumber INTEGER NOT NULL DEFAULT 0,
            PurpleStarNumber INTEGER NOT NULL DEFAULT 0,
            DarkMatterNumber INTEGER NOT NULL DEFAULT 0
        );
    ");
        }
        public static void MigrateJsonToDatabase()
        {
             try
            {
                string json = File.ReadAllText("QuickMath_UserData.json");

                var data = JsonSerializer.Deserialize<UserData>(json);

                if (data != null)
                {
                    DatabaseManager.Save(data);
                }

                File.Delete("QuickMath_UserData.json");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error migrating to the new save file system : " + ex.Message);
            }
        }
        public static UserData Load()
        {
            using var connection = new SqliteConnection(ConnectionString);

            var data = connection.QueryFirstOrDefault<UserData>(
                "SELECT * FROM UserData WHERE Id = 1"
            );

            return data ?? new UserData();
        }

        public static void Save(UserData data)
        {
            using var connection = new SqliteConnection(ConnectionString);

            connection.Execute(@"
                INSERT OR REPLACE INTO UserData (
                    Id,
                    UserName, XP, Coins,
                    TotalMathDone, TotalAdditionDone, TotalSubtractionDone,
                    Difficulty_Hard_addition_unlocked, Difficulty_Insane_addition_unlocked,
                    Difficulty_Hard_subtraction_unlocked, Difficulty_Insane_subtraction_unlocked,
                    RedStarNumber, BluStarNumber, YellowStarNumber, PurpleStarNumber, DarkMatterNumber
                ) VALUES (
                    1,
                    @UserName, @XP, @Coins,
                    @TotalMathDone, @TotalAdditionDone, @TotalSubtractionDone,
                    @Difficulty_Hard_addition_unlocked, @Difficulty_Insane_addition_unlocked,
                    @Difficulty_Hard_subtraction_unlocked, @Difficulty_Insane_subtraction_unlocked,
                    @RedStarNumber, @BluStarNumber, @YellowStarNumber, @PurpleStarNumber, @DarkMatterNumber
                );
            ", data);
        }

        public static bool Exists()
        {
            using var connection = new SqliteConnection(ConnectionString);

            var count = connection.ExecuteScalar<int>(
                "SELECT COUNT(*) FROM UserData WHERE Id = 1"
            );

            return count > 0;
        }
    }
}