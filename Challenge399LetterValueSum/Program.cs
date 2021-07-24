using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge399LetterValueSum
{
    class Program
    {
        static int LetterSum(string word)
        {
            int result = word.ToCharArray().Select(c => (int)c - 96).Sum();
            return result;
        }

        static void Challenge()
        {
            List<(string, int)> tests = new()
            {
                ("", 0),
                ("a", 1),
                ("z", 26),
                ("cab", 6),
                ("excellent", 100),
                ("microspectrophotometries", 317)
            };

            tests.ForEach(t => Console.WriteLine($"LetterSum({ t.Item1 }) => { t.Item2 } | Actual Ooutput: { LetterSum(t.Item1) } " +
                $"{ (t.Item2 == LetterSum(t.Item1) ? "Passed" : "Failed") }"));
        }
        
        static List<(string, int)> CreateWordList()
        {
            List<(string, int)> wordList = new();
            string line;
            using (StreamReader sr = new("wordlist.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    wordList.Add((line, LetterSum(line)));
                }
            }

            return wordList;
        }

        static void BonusChallenge()
        {
            List<(string, int)> wordList = CreateWordList();

            // Bonus Challenge 1
            string bonusChallengeOne = wordList.Where(w => w.Item2 == 319).Select(w => w.Item1).FirstOrDefault();
            Console.WriteLine($"Bonus Challenge 1: { bonusChallengeOne }");

            // Bonus Challenge 2
            int bonusChallengeTwo = wordList.Where(w => w.Item2 % 2 == 1).Count();
            Console.WriteLine($"Bonus Challenge 2: { bonusChallengeTwo }");

            // Bonus Challenge 3
            var bonusChallenge3 = wordList
                .GroupBy(w => w.Item2)
                .Select(g => new
                {
                    Score = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(w => w.Count)
                .FirstOrDefault();
            Console.WriteLine($"Bonus Challenge 3: { bonusChallenge3.Score } { bonusChallenge3.Count }");
        }

        static void Main(string[] args)
        {
            Challenge();
            BonusChallenge();
            Console.ReadLine();
        }
    }
}
