using System;
using System.Collections.Generic;

namespace Challenge393MakingChange
{
    class Program
    {
        private static readonly List<int> _denominations = new List<int>()
        {
            500, 
            100,
            25,
            10,
            5,
            1
        };

        static int Change(int changeToGive)
        {
            int totalCoins = 0;
            foreach(var d in _denominations)
            {
                while(changeToGive >= d)
                {
                    totalCoins++;
                    changeToGive -= d;
                }
            }
            return totalCoins;
        }

        static void Main(string[] args)
        {
            List<Tuple<int,int>> tests = new();
            tests.Add(new(0, 0));
            tests.Add(new(12, 3));
            tests.Add(new(468, 11));
            tests.Add(new(123456, 254));
            tests.ForEach(t => Console.WriteLine($"Change({ t.Item1 }) => { t.Item2 } { Change(t.Item1) == t.Item2 }"));

            Console.ReadLine();
        }
    }
}
