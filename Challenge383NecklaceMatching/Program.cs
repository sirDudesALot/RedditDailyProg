using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge383NecklaceMatching
{
    class Program
    {
        static string PivotNecklace(string necklace, int pivot)
        {
            StringBuilder output = new();
            for (int ix = pivot; ix < necklace.Length; ix++)
            {
                output.Append(necklace[ix]);
            }
            for (int ix = 0; ix < pivot; ix++)
            {
                output.Append(necklace[ix]);
            }
            return output.ToString();
        }

        static bool SameNecklace(string necklaceOne, string necklaceTwo)
        {
            bool sameNecklace = false;

            if (necklaceOne.Length == necklaceTwo.Length)
            {
                if (necklaceOne.Length == 0)
                {
                    sameNecklace = true;
                }
                else
                {
                    int pos = 0;
                    while (!sameNecklace && pos < necklaceTwo.Length)
                    {
                        if (necklaceOne[0] == necklaceTwo[pos])
                        {
                            if (PivotNecklace(necklaceTwo, pos) == necklaceOne)
                            {
                                sameNecklace = true;
                            }
                        }
                        pos++;
                    }
                }
            }

            return sameNecklace;
        }

        static void Challnege()
        {
            List<Tuple<string, string>> valuesToTest = new()
            {
                new("nicole", "icolen"),
                new("nicole", "lenico"),
                new("nicole", "coneli"),
                new("aabaaaaabaab", "aabaabaabaaa"),
                new("abc", "cba"),
                new("xxyyy", "xxxyy"),
                new("xyxxz", "xxyxz"),
                new("x", "x"),
                new("x", "xx"),
                new("x", ""),
                new("", "")
            };
            valuesToTest.ForEach(v => Console.WriteLine($"{ v.Item1 }, { v.Item2 } => { SameNecklace(v.Item1, v.Item2) }"));
        }

        static int Repeats(string str)
        {
            if (str.Length == 0)
            {
                return 1;
            }
            else
            {
                int pos = 0;
                StringBuilder wordToFind = new();
                wordToFind.Append(str[pos]);
                pos++;
                while (pos < str.Length && str[pos] != wordToFind[0])
                {
                    wordToFind.Append(str[pos]);
                    pos++;
                }
                int count = 0;
                pos = 0;
                while ((pos = str.IndexOf(wordToFind.ToString(), pos)) != -1)
                {
                    count++;
                    pos += wordToFind.Length;
                }
                return count;
            }
        }

        static void OptionalBonusOne()
        {
            List<Tuple<string, int>> valuesToTest = new()
            {
                new("abc", 1),
                new("abcabcabc", 3),
                new("abcabcabcx", 1),
                new("aaaaaa", 6),
                new("a", 1),
                new("", 1)
            };
            valuesToTest.ForEach(v => Console.WriteLine($" { v.Item1 } => { Repeats(v.Item1) }(={ v.Item2 }) { Repeats(v.Item1) == v.Item2 }"));
        }

        static void Main(string[] args)
        {
            Challnege();
            Console.WriteLine();
            OptionalBonusOne();
            Console.ReadLine();
        }
    }
}
