using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {
            Challenge();
            Console.ReadLine();
        }
    }
}
