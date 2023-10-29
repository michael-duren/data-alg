using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Lib
{
    public static class ArrayExtensions
    {
        public static void QuickSort(this int[] arr)
        {
            Qs(arr, 0, arr.Length - 1);
        }

        private static void Qs(int[] arr, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            int pivotIdx = Partition(arr, lo, hi);

            Qs(arr, lo, pivotIdx - 1);
            Qs(arr, pivotIdx + 1, hi);
        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[hi];

            int idx = lo - 1;

            for (int i = lo; i < hi; i++)
            {
                if (arr[i] <= pivot)
                {
                    idx++;
                    (arr[idx], arr[i]) = (arr[i], arr[idx]);
                }
            }

            idx++;
            arr[hi] = arr[idx];
            arr[idx] = pivot;

            return idx;
        }
    }
}
