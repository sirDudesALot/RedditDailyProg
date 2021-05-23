using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public class Gina : Contestant, IContestant
    {
        override public string Name { get => "Gina"; }

        private bool _useAliceMethod = true;

        public void GenerateFirstChoice(int totalDoors)
        {
            FirstChoice = 1;
        }

        public void GenerateSecondChoice(int hostsChoice)
        {
            if(_useAliceMethod)
            {
                SecondChoice = 1;
            }
            else
            {
                SecondChoice = hostsChoice;
            }
        }

        override public void IncrementTotals(bool wonGame)
        {
            TotalGamesPlayed++;
            if(wonGame)
            {
                TotalWins++;
            }
            else
            {
                _useAliceMethod = !_useAliceMethod;
            }
        }


    }
}
