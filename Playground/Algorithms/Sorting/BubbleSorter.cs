using Algorithms.Sorting.Contracts;

namespace Algorithms.Sorting
{
    public class BubbleSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            for (int lastIndex = arr.Length - 1; lastIndex >= 0; lastIndex--)
            {
                var sorted = true;

                for (int i = 0; i < lastIndex; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        sorted = false;
                        var temp = arr[i];

                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }

                if (sorted)
                {
                    return;
                }
            }
        }
    }
}
