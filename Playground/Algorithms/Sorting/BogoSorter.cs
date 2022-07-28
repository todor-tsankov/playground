using Algorithms.Sorting.Contracts;

namespace Algorithms.Sorting
{
    public class BogoSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            var sorted = false;
            var random = new Random(); 

            while (!sorted)
            {
                var firstIndex = random.Next(arr.Length);
                var secondIndex = random.Next(arr.Length);

                var temp = arr[firstIndex];

                arr[firstIndex] = arr[secondIndex];
                arr[secondIndex] = temp;

                sorted = this.IsSorted(arr);
            }
        }

        private bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
