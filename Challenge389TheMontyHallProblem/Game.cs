using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge389TheMontyHallProblem
{
    public class Game
    {
        public int TotalDoors { get; set; }
        public int WinningDoor { get; set; }
        public int HostsDoor { get; set; }
        public IContestant Contestant { get; set; }

        private Random _r = new();

        public Game(IContestant contestant, int totalDoors = 3)
        {
            TotalDoors = totalDoors;
            Contestant = contestant;
        }

        private int GenerateWinningDoor()
        {
            return _r.Next(1, TotalDoors + 1);
        }

        public int GenerateHostsDoor(int contestantsChoice)
        {
            if(contestantsChoice==WinningDoor)
            {
                int output = 0;
                do
                {
                    output = _r.Next(1, TotalDoors + 1);
                } while (output == contestantsChoice);
                return output;
            }
            else
            {
                return WinningDoor;
            }
        }

        public string GenerateOutput()
        {
            StringBuilder output = new();
            output.Append($"Winning Door: { WinningDoor }. ");
            output.Append($"Contestants First Choice: { Contestant.FirstChoice }. ");
            output.Append($"Hosts Choice: { HostsDoor }. ");
            output.Append($"Contestants Second Choice: { Contestant.SecondChoice }. ");

            if (Contestant.SecondChoice == WinningDoor)
            {
                output.Append($"Contestant Wins");
            }
            else
            {
                output.Append($"Contestant Loses");
            }

            return output.ToString();
        }

        public bool RunGame()
        {
            WinningDoor = GenerateWinningDoor();
            Contestant.GenerateFirstChoice(TotalDoors);
            HostsDoor = GenerateHostsDoor(Contestant.FirstChoice);
            Contestant.GenerateSecondChoice(HostsDoor);

            if(Contestant.SecondChoice == WinningDoor)
            {
                Contestant.IncrementTotals(true);
                return true;
            }
            else
            {
                Contestant.IncrementTotals(false);
                return false;
            }
        }
    }
}
