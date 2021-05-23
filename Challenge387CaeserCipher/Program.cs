using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge387CaeserCipher
{
    class Program
    {
        private const int _asciiOffset = 97;

        static void TestWarmup()
        {
            List<Tuple<char, int>> toTest = new();
            toTest.Add(new('a', 0));
            toTest.Add(new('a', 1));
            toTest.Add(new('a', 25));
            toTest.Add(new('a', 26));
            toTest.Add(new('a', 24));

            toTest.ForEach(t => Console.WriteLine($"f({ t.Item1 }, { t.Item2 }) => { Warmup(t.Item1, t.Item2) }"));
        }

        static char Warmup(char letter, int shift)
        {
            int ascii = (int)letter;
            ascii = ascii - _asciiOffset;
            ascii = ascii + shift;
            ascii = ascii % 26;
            ascii = ascii + _asciiOffset;
            return (char)(ascii);
        }

        static string Caesar(string originalStr, int shift)
        {
            StringBuilder output = new();
            foreach(var c in originalStr)
            {
                output.Append(Warmup(c, shift));
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

            values.ForEach(t => Console.WriteLine($"f({ t.Item1 }, { t.Item2 }) => { Caesar(t.Item1, t.Item2) }. " +
                $"{ Caesar(t.Item1, t.Item2)==t.Item3 }"));
        }

        static void Main(string[] args)
        {
            //TestWarmup();
            Challenge();
            Console.ReadLine();
        }
    }
}
