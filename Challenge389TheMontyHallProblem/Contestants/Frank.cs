using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public class Frank : Contestant, IContestant
    {
        override public string Name { get => "Frank"; }

        public void GenerateFirstChoice(int totalDoors)
        {
            FirstChoice = 1;
        }

        public void GenerateSecondChoice(int hostsChoice)
        {
            if(hostsChoice == 2)
            {
                SecondChoice = 2;
            }
        }
    }
}
