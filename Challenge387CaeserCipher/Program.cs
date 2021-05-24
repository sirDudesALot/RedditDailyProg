using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge387CaeserCipher
{
    class Program
    {
        private const string _lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";

        static List<Tuple<char, int>> GetLetterScoreList()
        {
            List<Tuple<char, int>> letterScoreList = new()
            {
                new('a', 3),
                new('b', -1),
                new('c', 1),
                new('d', 1),
                new('e', 4),
                new('f', 0),
                new('g', 0),
                new('h', 2),
                new('i', 2),
                new('j', -5),
                new('k', -2),
                new('l', 1),
                new('m', 0),
                new('n', 2),
                new('o', 3),
                new('p', 0),
                new('q', -6),
                new('r', 2),
                new('s', 2),
                new('t', 3),
                new('u', 1),
                new('v', -1),
                new('w', 0),
                new('x', -5),
                new('y', 0),
                new('z', -7)
            };
            return letterScoreList;
        }

        static void TestCaeserChar()
        {
            List<Tuple<char, int>> toTest = new();
            toTest.Add(new('a', 0));
            toTest.Add(new('a', 1));
            toTest.Add(new('a', 25));
            toTest.Add(new('a', 26));
            toTest.Add(new('a', 24));
            toTest.Add(new('A', 0));

            toTest.ForEach(t => Console.WriteLine($"f({ t.Item1 }, { t.Item2 }) => { CaeserChar(t.Item1, t.Item2) }"));
        }

        static char CaeserChar(char letter, int shift)
        {
            int pos = _lowerCaseLetters.IndexOf(letter);
            string lettersToUse = _lowerCaseLetters;
            if (pos == -1)
            {
                lettersToUse = _lowerCaseLetters.ToUpper();
                pos = lettersToUse.IndexOf(letter);
            }

            if (pos > -1)
            {
                pos = (pos + shift) % 26;
                return lettersToUse[pos];
            }
            else
            {
                return letter;
            }

        }

        static string Caesar(string originalStr, int shift)
        {
            StringBuilder output = new();
            foreach (var c in originalStr)
            {
                output.Append(CaeserChar(c, shift));
            }
            return output.ToString();
        }

        static void Challenge()
        {
            List<Tuple<string, int, string>> values = new();
            values.Add(new("a", 1, "b"));
            values.Add(new("abcz", 1, "bcda"));
            values.Add(new("irk", 13, "vex"));
            values.Add(new("fusion", 6, "layout"));
            values.Add(new("dailyprogrammer", 6, "jgorevxumxgsskx"));
            values.Add(new("jgorevxumxgsskx", 20, "dailyprogrammer"));
            values.Add(new("%", 1, "%"));

            values.ForEach(t => Console.WriteLine($"f({ t.Item1 }, { t.Item2 }) => { Caesar(t.Item1, t.Item2) }. " +
                $"{ Caesar(t.Item1, t.Item2) == t.Item3 }"));
        }

        static void OptionalBonusOne()
        {
            List<Tuple<string, int, string>> values = new();
            values.Add(new("Daily Programmer!", 6, "Jgore Vxumxgsskx!"));

            values.ForEach(t => Console.WriteLine($"f({ t.Item1 }, { t.Item2 }) => { Caesar(t.Item1, t.Item2) }. " +
                $"{ Caesar(t.Item1, t.Item2) == t.Item3 }"));
        }

        static List<string> GenerateAllPossibleOrigText(string originalText)
        {
            List<string> results = new();
            for (int ix = 0; ix < 26; ix++)
            {
                results.Add(Caesar(originalText, ix));
            }
            return results;
        }

        static int GetLetterScore(char letter)
        {
            int score = 0;
            List<Tuple<char,int>> letterScoreList = GetLetterScoreList();
            var results =
                from lsr in letterScoreList
                where lsr.Item1 == letter || lsr.Item1.ToString().ToUpper()[0] == letter
                select lsr;
            if(results.Count() > 0)
            {
                score = results.First().Item2;
            }
            return score;
        }

        static int GetStringScore(string str)
        {
            int score = 0;
            foreach(var c in str)
            {
                score += GetLetterScore(c);
            }
            return score;
        }

        static string DecodeText(string textToDecode)
        {
            List<Tuple<string, int>> results = new();
            foreach(var poss in GenerateAllPossibleOrigText(textToDecode))
            {
                results.Add(new(poss, GetStringScore(poss)));
            }
            string topResult =
                (from r in results
                 orderby r.Item2 descending
                 select r).First().Item1;
            return topResult;
        }

        static void OptionalBonusTwo()
        {
            List<string> values = new()
            {
                "Zol abyulk tl puav h ulda.",
                "Tfdv ef wlikyvi, wfi uvrky rnrzkj pfl rcc nzky erjkp, szx, gfzekp kvvky.",
                "Qv wzlmz bw uiqvbiqv iqz - axmml dmtwkqbg, i aeittwe " +
                    "vmmla bw jmib qba eqvoa nwzbg - bpzmm bquma mdmzg amkwvl, zqopb?"
            };
            values.ForEach(t => Console.WriteLine($" { t } => { DecodeText(t) }"));
        }

        static void Main(string[] args)
        {
            //TestCaeserChar();
            Challenge();
            Console.WriteLine();
            OptionalBonusOne();
            Console.WriteLine();
            OptionalBonusTwo();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
