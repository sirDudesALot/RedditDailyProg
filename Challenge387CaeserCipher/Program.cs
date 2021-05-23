using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge387CaeserCipher
{
    class Program
    {
        private const string _lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";

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
            if(pos == -1)
            {
                lettersToUse = _lowerCaseLetters.ToUpper();
                pos = lettersToUse.IndexOf(letter);
            }

            if(pos > -1)
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
            foreach(var c in originalStr)
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
                $"{ Caesar(t.Item1, t.Item2)==t.Item3 }"));
        }

        static void OptionalBonusOne()
        {
            List<Tuple<string, int, string>> values = new();
            values.Add(new("Daily Programmer!", 6, "Jgore Vxumxgsskx!"));

            values.ForEach(t => Console.WriteLine($"f({ t.Item1 }, { t.Item2 }) => { Caesar(t.Item1, t.Item2) }. " +
                $"{ Caesar(t.Item1, t.Item2) == t.Item3 }"));
        }

        static void Main(string[] args)
        {
            //TestCaeserChar();
            Challenge();
            Console.WriteLine();
            OptionalBonusOne();
            Console.ReadLine();
        }
    }
}
