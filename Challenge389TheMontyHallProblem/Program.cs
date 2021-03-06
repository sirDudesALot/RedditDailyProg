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

        static void RunGame(IContestant contestant, int timesToRun)
        {
            Game g = new(contestant);
            for(int ix = 0; ix < timesToRun; ix++)
            {
                g.RunGame();
                //Console.WriteLine(g.GenerateOutput());
            }
            Console.WriteLine($"{ contestant.Name }: Games Played: { contestant.TotalGamesPlayed }. Wins: { contestant.TotalWins }. Win Percentage: { contestant.WinPercentage }%.");

        }

        static void Main(string[] args)
        {
            //TestGenerateWinningDoor(100000);
            //TestGenerateHostsChoice();

            List<IContestant> contestants= new();
            contestants.Add(new Alice());
            contestants.Add(new Bob());
            contestants.Add(new Carol());
            contestants.Add(new Dave());
            contestants.Add(new Erin());
            contestants.Add(new Frank());
            contestants.Add(new Gina());

            contestants.ForEach(c => RunGame(c, 100));

            Console.ReadLine();
        }
    }
}
