using Algorithms.Sorting.Contracts;

namespace Algorithms.Sorting
{
    public class MergeSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            var result = this.Sort(arr, 0, arr.Length - 1);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = result[i];
            }
        }

        private int[] Sort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return new int[] { arr[start] };
            }

            var middle = (start + end) / 2;

            if ((start + end) % 2 != 0)
            {
                middle++;
            }

            var left = this.Sort(arr, start, middle - 1);
            var right = this.Sort(arr, middle, end);

            return this.Merge(left, right);
        }

        private int[] Merge(int[] arr1, int[] arr2)
        {
            var totalElements = arr1.Length + arr2.Length;
            var result = new int[totalElements];

            var index1 = 0;
            var index2 = 0;

            for (int i = 0; i < totalElements; i++)
            {
                if (index2 == arr2.Length || (index1 < arr1.Length && arr1[index1] < arr2[index2]))
                {
                    result[i] = arr1[index1++];
                    continue;
                }

                result[i] = arr2[index2++];
            }

            return result;
        }
    }
}
