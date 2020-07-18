using System;
using System.Collections.Generic;

namespace QuickSortSolution
{
    class Program
    {
        public static int ChoosePivot(List<long> a, int l, int r)
        {
            return l;
        }

        public static int Partition(List<long> a, int l, int r)
        {
            var i = l+1;
            var p = a[l];

            for (var j = l + 1;j<=r; j++)
            {
                if (a[j] < p) {
                    (a[i], a[j]) = (a[j], a[i]); 
                    i++;

                }
            }
            (a[l], a[i-1]) = (a[i-1], a[l]);
            return i - 1;
        }
        public static void QuickSort(List<long> a, int l, int r)
        {

            if (l >= r)
            {
                return;
            }

            var i = ChoosePivot(a, l, r);

            (a[l], a[i]) = (a[i], a[l]);
            var j = Partition(a, l, r);
            QuickSort(a, l, j - 1);
            QuickSort(a, j + 1, r);
        }

        static void Main(string[] args)
        {
            List<long> test = new List<long>() { 2, 1, 1000, 3, 6, 5, 0, 234,  4, 67, 45, 22, };

            QuickSort(test, 0, test.Count - 1);

            foreach (var el in test)
            {
                Console.WriteLine(el);
            }
        }
    }
}
