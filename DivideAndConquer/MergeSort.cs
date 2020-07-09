using System;
using System.Collections.Generic;

namespace MergeSortSolution
{
    class Program
    {
        public static List<int> MergeSort(List<int> p)
        {
            if (p.Count <= 1)
            {
                return p;
            }

            int middle = p.Count / 2;
            var left = p.GetRange(0, middle);
            var right = p.GetRange(middle, p.Count - middle);
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        public static List<int> Merge(List<int> left, List<int> right)
        {
            int indxLeft = 0;
            int indxRight = 0;

            List<int> result = new List<int>();

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
                    indxRight++;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<int> test = new List<int>() { 1, 2, 3, 6, 5, 4, 0 };
            var result = MergeSort(test);
            foreach (var item in result)
            {
                Console.Write($"{item} ", item);
            }
        }
    }
}
