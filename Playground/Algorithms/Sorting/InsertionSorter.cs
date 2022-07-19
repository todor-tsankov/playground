using Algorithms.Sorting.Contracts;

namespace Algorithms.Sorting
{
    public class InsertionSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        var temp = arr[j];

                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
