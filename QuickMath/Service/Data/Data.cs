using System;

namespace QuickMath.Service.Data
{
    public class Data
    {
        public void Initialize()
        {
            InitializeUserData();
        }
        private int result;

        public int XP;
        public float coins;

        public int totalNumberOfMathDone;
        public int totalNumberOfAdditionDone;
        public int totalNumberOfSubtractionDone;

        public bool Difficulty_Insane_addition_unlocked = false;
        public bool Difficulty_Hard_addition_unlocked = false;
        public bool Difficulty_Hard_subtraction_unlocked = false;
        public bool Difficulty_Insane_subtraction_unlocked = false;

        public int NumberOfXpGivenForAddition = 10;
        public int NumberOfXpGivenForSubtraction = 10;

        public void InitializeUserData()
        {
            XP = 0;
            coins = 0;

            totalNumberOfMathDone = 0;
            totalNumberOfAdditionDone = 0;
            totalNumberOfSubtractionDone = 0;

            Difficulty_Insane_addition_unlocked = false;
            Difficulty_Hard_addition_unlocked = false;
            Difficulty_Hard_subtraction_unlocked = false;
            Difficulty_Insane_subtraction_unlocked = false;
        }
        public void InitializeStats()
        {
            totalNumberOfMathDone = 0;
            totalNumberOfAdditionDone = 0;
            totalNumberOfSubtractionDone = 0;
        }
  public void initializeDifficultyUnlocks()
        {
            Difficulty_Insane_addition_unlocked = false;
            Difficulty_Hard_addition_unlocked = false;
            Difficulty_Hard_subtraction_unlocked = false;
            Difficulty_Insane_subtraction_unlocked = false;
        }
        public void InitializeEverything()
        {
            InitializeUserData();
            InitializeStats();
            initializeDifficultyUnlocks();
        }
    }
}