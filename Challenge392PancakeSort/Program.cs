using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge392PancakeSort
{
    class Program
    {
        private static int[] _arr;

        public static string PrintArray(int[] arrToPrint)
        {
            StringBuilder sb = new("[");
            for(int i = 0; i < arrToPrint.Length; i++)
            {
                sb.Append($"{ arrToPrint[i] }{ (i < arrToPrint.Length -1 ? "," : "") } ");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static bool AreArraysEqual(int[] testArray)
        {
            if(_arr.Length != testArray.Length)
            {
                return false;
            }
            else
            {
                for(int i = 0; i < _arr.Length; i++)
                {
                    if(_arr[i] != testArray[i])
                    {
                        return false;
                    }    
                }
                return true;
            }
        }

        public static void CreateArr(int[] arrayFrom)
        {
            _arr = new int[arrayFrom.Length];
            for(int i = 0; i < arrayFrom.Length; i++)
            {
                _arr[i] = arrayFrom[i];
            }
        }

        public static void FlipFront(int numbersToFlip)
        {
            int j = 0, k = numbersToFlip-1;
            int temp;
            while(j < k)
            {
                temp = _arr[j];
                _arr[j] = _arr[k];
                _arr[k] = temp;
                j++;
                k--;
            }
        }

        public static void WarmUp()
        {
            List<Tuple<int[], int[], int>> tests = new()
            {
                new(new int[] { 0, 1, 2, 3, 4 }, new int[] { 1, 0, 2, 3, 4 }, 2),
                new(new int[] { 0, 1, 2, 3, 4 }, new int[] { 2, 1, 0, 3, 4 }, 3),
                new(new int[] { 0, 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1, 0 }, 5),
                new(new int[] { 1, 2, 2, 2 }, new int[] { 2, 2, 1, 2 }, 3)
            };

            Console.WriteLine(PrintArray(tests[0].Item1));

            tests.ForEach(t =>
                {
                    CreateArr(t.Item1);
                    FlipFront(t.Item3);
                    Console.WriteLine($" { PrintArray(t.Item1) } Flipfront({ t.Item3 }) => { PrintArray(t.Item2) } | " +
                        $"Actual: { PrintArray(_arr) } { (AreArraysEqual(t.Item2) ? "Passed" : "Failed")}");
                });

            Console.WriteLine(PrintArray(tests[0].Item1));

        }

        static void Main(string[] args)
        {
            WarmUp();
            Console.ReadLine();
        }
    }
}
