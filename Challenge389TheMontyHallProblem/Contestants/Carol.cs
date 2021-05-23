using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public class Carol : Contestant, IContestant
    {
        override public string Name { get => "Carol"; }

        public void GenerateFirstChoice(int totalDoors)
        {
            Random r = new();
            FirstChoice = r.Next(1, totalDoors + 1);
        }

        public void GenerateSecondChoice(int hostsChoice)
        {
            Random r = new();
            if(r.Next(1,3) < 2)
            {
                SecondChoice = FirstChoice;
            }
            else
            {
                SecondChoice = hostsChoice;
            }
        }
    }
}
