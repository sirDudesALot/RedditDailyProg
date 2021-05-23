using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public class Erin : Contestant, IContestant
    {
        override public string Name { get => "Erin"; }

        public void GenerateFirstChoice(int totalDoors)
        {
            Random r = new();
            FirstChoice = r.Next(1, totalDoors + 1);
        }

        public void GenerateSecondChoice(int hostsChoice)
        {
            SecondChoice = hostsChoice;
        }
    }
}
