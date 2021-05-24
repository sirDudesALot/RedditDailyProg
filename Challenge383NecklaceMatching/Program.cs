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
            for(int ix = pivot; ix < necklace.Length; ix++)
            {
                output.Append(necklace[ix]);
            }
            for(int ix = 0; ix < pivot; ix++)
            {
                output.Append(necklace[ix]);
            }
            return output.ToString();
        }

        static void TestPivotNecklace()
        {
            Console.WriteLine(PivotNecklace("TestString", 4));
        }

        static bool SameNecklace(string necklaceOne, string necklaceTwo)
        {
            bool necklacesSame = false;

            if(necklaceOne.Length == necklaceTwo.Length)
            {
                if(necklaceOne.Length == 0)
                {
                    necklacesSame = true;
                }
                else
                {
                    int pos = 0;
                    while(!necklacesSame && pos < necklaceTwo.Length)
                    {
                        if(necklaceOne[0] == necklaceTwo[pos])
                        {
                            if(PivotNecklace(necklaceTwo, pos) == necklaceOne)
                            {
                                necklacesSame = true;
                            }
                        }
                        pos++;
                    }
                }
            }

            return necklacesSame;
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

        static void Main(string[] args)
        {
            Challnege();
            //TestPivotNecklace();
            Console.ReadLine();
        }
    }
}
