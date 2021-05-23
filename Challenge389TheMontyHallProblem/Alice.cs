using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public class Alice : IContestant
    {
        public int TotalGamesPlayed { get; set; } = 0;
        public int TotalWins { get; set; } = 0;
        public int FirstChoice { get; set; }
        public int SecondChoice { get; set; }
        public decimal WinPercentage
        {
            get
            {
                return ((decimal)TotalWins / (decimal)TotalGamesPlayed) * 100.00M;
            }
        }

        public void GenerateFirstChoice(int totalDoors)
        {
            FirstChoice = 1;
        }

        public void GenerateSecondChoice(int hostsChoice)
        {
            SecondChoice = 1;
        }
    }
}
