using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public abstract class Contestant
    {
        public abstract string Name { get; }
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

        public virtual void IncrementTotals(bool wonGame)
        {
            TotalGamesPlayed++;
            if(wonGame)
            {
                TotalWins++;
            }
        }
    }
}
