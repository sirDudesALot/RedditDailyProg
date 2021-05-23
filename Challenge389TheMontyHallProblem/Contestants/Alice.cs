using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public class Alice : Contestant, IContestant
    {
        override public string Name { get => "Alice"; }

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
