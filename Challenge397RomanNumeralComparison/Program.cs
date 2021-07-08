using System;
using System.Collections.Generic;

namespace Challenge397RomanNumeralComparison
{
    class Program
    {
        private static Dictionary<char, int> _numerals = new Dictionary<char, int>()
        {
            { 'M', 1000 },
            { 'D', 500 },
            { 'C', 100 },
            { 'L', 50 },
            { 'X', 10 },
            { 'V', 5 },
            { 'I', 1 }
        };

        public static int LookupCharValue(char numeral)
        {
            return _numerals[numeral];
        }

        public static int LookupStringValue(string numerals)
        {
            int stringValue = 0;
            foreach(char n in numerals)
            {
                stringValue += LookupCharValue(n);
            }
            return stringValue;
        }

        public static bool NumCompare(string numberOne, string numberTwo)
        {
            return LookupStringValue(numberOne) < LookupStringValue(numberTwo);
        }

        static void Main(string[] args)
        {
            List<Tuple<string, string, bool>> tests = new()
            {
                new("I", "I", false),
                new("I", "II", true),
                new("II", "I", false),
                new("V", "IIII", false),
                new("MDCLXV", "MDCLXVI", true),
                new("MM", "MDCCCCLXXXXVIIII", false)
            };

            tests.ForEach(t => Console.WriteLine($"numcompare({t.Item1}, {t.Item2} => " +
                $"{ t.Item3} | { NumCompare(t.Item1, t.Item2) } | {( t.Item3 == NumCompare(t.Item1, t.Item2) ? "Passed" : "Failed")}"));
            Console.ReadLine();
        }
    }
}
