using Algorithms.Sorting.Contracts;

namespace Algorithms.Sorting
{
    public class QuickSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            this.Sort(arr, 0, arr.Length - 1);
        }

        private void Sort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var lastBigger = null as int?;

            for (int i = start; i < end; i++)
            {
                if (lastBigger.HasValue && arr[i] < arr[end])
                {
                    this.Swap(arr, lastBigger.Value, i);
                    lastBigger++;
                }
                else if (!lastBigger.HasValue && arr[i] >= arr[end])
                {
                    lastBigger = i;
                }
            }

            lastBigger ??= end;
            this.Swap(arr, end, lastBigger.Value);

            this.Sort(arr, lastBigger.Value + 1, end);
            this.Sort(arr, start, lastBigger.Value - 1);
        }

        private void Swap(int[] arr, int index1, int index2)
        {
            var temp = arr[index1];

            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
