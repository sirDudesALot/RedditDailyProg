namespace Challenge389TheMontyHallProblem
{
    public interface IContestant
    {
        string Name { get;  }
        int FirstChoice { get; set; }
        int SecondChoice { get; set; }
        int TotalGamesPlayed { get; set; }
        int TotalWins { get; set; }
        decimal WinPercentage { get; }

        void GenerateFirstChoice(int totalDoors);
        void GenerateSecondChoice(int hostsChoice);
        void IncrementTotals(bool wonGame);
    }
}