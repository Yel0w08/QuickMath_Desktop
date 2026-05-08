using System.Text.Json.Serialization;

namespace QuickMath.Services.DataManager
{
    public class UserDataModel
    {
        // ── Player ──────────────────────────────────────────────
        public int XP { get; set; }
        public float coins { get; set; }
        public string UserName { get; set; } = "Player";

        // ── Statistics ──────────────────────────────────────────
        public int totalNumberOfMathDone { get; set; }
        public int totalNumberOfAdditionDone { get; set; }
        public int totalNumberOfSubtractionDone { get; set; }

        // ── Difficulty Unlocks ──────────────────────────────────
        public bool Difficulty_Insane_addition_unlocked { get; set; }
        public bool Difficulty_Hard_addition_unlocked { get; set; }
        public bool Difficulty_Insane_subtraction_unlocked { get; set; }
        public bool Difficulty_Hard_subtraction_unlocked { get; set; }

        // ── Star Cosmetics ──────────────────────────────────────
        public int RedStarNumber { get; set; }
        public int BlueStarNumber { get; set; }
        public int YellowStarNumber { get; set; }
        public int PurpleStarNumber { get; set; }
        public int DarkMatterNumber { get; set; }

        // ── Helper ──────────────────────────────────────────────

        [JsonIgnore]
        public int TotalStars =>
            RedStarNumber + BlueStarNumber + YellowStarNumber +
            PurpleStarNumber + DarkMatterNumber;

        public static UserDataModel CreateDefault(string username)
        {
            return new UserDataModel
            {
                XP = 0,
                coins = 0,
                UserName = username,
                Difficulty_Insane_addition_unlocked = false,
                Difficulty_Hard_addition_unlocked = false,
                Difficulty_Insane_subtraction_unlocked = false,
                Difficulty_Hard_subtraction_unlocked = false,
                totalNumberOfMathDone = 0,
                totalNumberOfAdditionDone = 0,
                totalNumberOfSubtractionDone = 0,
                RedStarNumber = 0,
                BlueStarNumber = 0,
                YellowStarNumber = 0,
                PurpleStarNumber = 0,
                DarkMatterNumber = 0
            };
        }
    }
}
