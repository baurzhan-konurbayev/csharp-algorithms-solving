using System;
using System.Collections.Generic;

namespace CountInversions
{
    class Program
    {
        public static (long, List<long>) SortCount(List<long> p)
        {
            if (p.Count <= 1)
            {
                return (0, p);
            }

            int middle = p.Count / 2;
            var left = p.GetRange(0, middle);
            var right = p.GetRange(middle, p.Count - middle);
            long leftCount = 0;
            long rightCount = 0;

            (leftCount, left) = SortCount(left);
            (rightCount, right) = SortCount(right);
            var result = MergeCount(left, right);
            return (result.Item1 + leftCount + rightCount, result.Item2);
        }

        public static (long, List<long>) MergeCount(List<long> left, List<long> right)
        {
            int indxLeft = 0;
            int indxRight = 0;

            long countSplit = 0;
            List<long> result = new List<long>();


            for (int i = 0;  i < left.Count + right.Count;  i++)
            {
                if (indxRight >= right.Count || (indxLeft < left.Count && left[indxLeft]<= right[indxRight]))
                {
                    result.Add(left[indxLeft]);
                    indxLeft++;
                }
                else
                {
                    result.Add(right[indxRight]);
                    countSplit += left.Count - indxLeft;
                    indxRight++;
                }
            }
            return (countSplit, result);
        }
        static void Main(string[] args)
        {
            List<long> test = new List<long>() { 1, 2, 3, 6, 5, 4, 0 };

            var result = SortCount(test);

            Console.WriteLine($"result is {result.Item1}");

        }
    }
}
