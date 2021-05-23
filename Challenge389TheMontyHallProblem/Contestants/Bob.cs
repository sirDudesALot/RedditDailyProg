using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public class Bob : Contestant, IContestant
    {
        override public string Name { get => "Bob"; }

        public void GenerateFirstChoice(int totalDoors)
        {
            FirstChoice = 1;
        }

        public void GenerateSecondChoice(int hostsChoice)
        {
            SecondChoice = hostsChoice;
        }
    }
}
