using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge389TheMontyHallProblem
{
    class Program
    {
        static void TestGenerateWinningDoor(int timesToTest=100)
        {
            List<int> results = new();
            IContestant contestant = new Alice();
            for (int ix = 0; ix < timesToTest; ix++)
            {
                Game g = new(contestant);
                g.RunGame();
                results.Add(g.WinningDoor);
            }

            int totalOnes =
                (from r in results
                 where r == 1
                 select r).Count();

            int totalTwos =
                (from r in results
                 where r == 2
                 select r).Count();

            int totalThrees =
                (from r in results
                 where r == 3
                 select r).Count();

            Console.WriteLine($"Total Doors: { results.Count }.");
            Console.WriteLine($"Total Ones: { totalOnes }. Total Twos: { totalTwos }. Total Threes: { totalThrees }.");
        }

        static void TestGenerateHostsChoice(int timesToTest=100)
        {
            IContestant contestant = new Alice();
            for(int ix = 0; ix < timesToTest; ix++)
            {
                Game g = new(contestant);
                g.RunGame();
                int contestantsChoice = 1;
                int hostsChoice = g.GenerateHostsDoor(contestantsChoice);
                Console.WriteLine($"Contestants Choice: { contestantsChoice }. Hosts Choice: { hostsChoice }. Winning Door { g.WinningDoor }.");
            }
        }

        static void Main(string[] args)
        {
            //TestGenerateWinningDoor(100000);
            //TestGenerateHostsChoice();

            IContestant contestant = new Alice();
            Game g = new(contestant);
            for(int ix=0; ix<100; ix++)
            {
                g.RunGame();
                //Console.WriteLine(g.GenerateOutput());
            }

            Console.WriteLine($"Alice: Games Played: { contestant.TotalGamesPlayed }. Wins: { contestant.TotalWins }. Win Percentage: { contestant.WinPercentage }%.");
            Console.ReadLine();
        }
    }
}
