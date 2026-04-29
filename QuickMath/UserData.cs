namespace QuickMath
{
    public class UserData
    {
        public string UserName { get; set; } = "";
        public int XP { get; set; }
        public float Coins { get; set; }

        public int TotalMathDone { get; set; }
        public int TotalAdditionDone { get; set; }
        public int TotalSubtractionDone { get; set; }

        public bool Difficulty_Hard_addition_unlocked { get; set; }
        public bool Difficulty_Insane_addition_unlocked { get; set; }
        public bool Difficulty_Hard_subtraction_unlocked { get; set; }
        public bool Difficulty_Insane_subtraction_unlocked { get; set; }

        public int RedStarNumber { get; set; }
        public int BluStarNumber { get; set; }
        public int YellowStarNumber { get; set; }
        public int PurpleStarNumber { get; set; }
        public int DarkMatterNumber { get; set; }
    }
}