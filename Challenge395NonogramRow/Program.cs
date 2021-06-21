using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge395NonogramRow
{
    class Program
    {
        public static StringBuilder PrintArray(int[] arrayToPrint)
        {
            StringBuilder sb = new("[");
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                sb.Append($"{arrayToPrint[i]}, ");
            }
            sb.Append("]");
            return sb;
        }

        public static bool DoArraysMatch(int[] firstArray, int[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static int[] ExtendArray(int[] arrayToExtend, int numberToAppend)
        {
            int[] newArray = new int[arrayToExtend.Length + 1];
            for (int i = 0; i < arrayToExtend.Length; i++)
            {
                newArray[i] = arrayToExtend[i];
            }
            newArray[newArray.Length - 1] = numberToAppend;
            return newArray;
        }

        public static int[] NonogramRow(int[] nonogramArr)
        {
            int[] result = Array.Empty<int>();
            int count = 0;
            int prevNumber = 0;
            for(int i = 0; i < nonogramArr.Length; i++)
            {
                if(nonogramArr[i] == 1)
                {
                    count++;
                } 
                else if(prevNumber == 1)
                {
                    result = ExtendArray(result, count);
                    count = 0;
                }
                prevNumber = nonogramArr[i];
            }
            if(prevNumber == 1)
            {
                result = ExtendArray(result, count);
            }
            return result;
        }

        static void Main(string[] args)
        {
            List<Tuple<int[], int[]>> tests = new()
            {
                new Tuple<int[], int[]>(Array.Empty<int>(), Array.Empty<int>()),
                new Tuple<int[], int[]>(new int[] { 0, 0, 0, 0, 0 }, Array.Empty<int>()),
                new Tuple<int[], int[]>(new int[] { 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 }, new int[] { 5, 4 }),
                new Tuple<int[], int[]>(new int[] { 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0 }, new int[] { 2, 1, 3 }),
                new Tuple<int[], int[]>(new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1 }, new int[] { 2, 1, 3 }),
                new Tuple<int[], int[]>(new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })

            };

            tests.ForEach(t => Console.WriteLine($" { PrintArray(t.Item1) } => { PrintArray(t.Item2) } " +
                $"{ (DoArraysMatch(t.Item2, NonogramRow(t.Item1)) ? "Pass" : "Fail")} | Actual Output: { PrintArray(NonogramRow(t.Item1)) }"));

            Console.ReadLine();
        }
    }
}

