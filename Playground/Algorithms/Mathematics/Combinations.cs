namespace Algorithms.General
{
    public class Combinations
    {
        public int[][] GetCombinations(int[] arr, int startIndex = 0)
        {
            if (startIndex == arr.Length)
            {
                return new int[][] { };
            }

            var resultIndex = 0;
            var result = new int[(int)Math.Pow(2, arr.Length - startIndex) - 1][];

            var current = arr[startIndex];
            result[resultIndex] = new int[] { current };

            var combinations = this.GetCombinations(arr, ++startIndex);

            for (int j = 0; j < combinations.Length; j++)
            {
                result[++resultIndex] = combinations[j];
                result[++resultIndex] = this.Add(combinations[j], current);
            }

            return result;
        }

        private int[] Add(int[] arr, int number)
        {
            var result = new int[arr.Length + 1];
            result[0] = number;

            for (int i = 0; i < arr.Length; i++)
            {
                result[i + 1] = arr[i];
            }

            return result;
        }
    }
}
