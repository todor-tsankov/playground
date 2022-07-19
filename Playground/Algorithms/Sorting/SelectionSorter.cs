using Algorithms.Sorting.Contracts;

namespace Algorithms.Sorting
{
    public class SelectionSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                var temp = arr[i];

                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
    }
}
