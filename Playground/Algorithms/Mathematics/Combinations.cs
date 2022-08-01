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
            var result = new int[this.Length(arr.Length - startIndex)][];

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

        public int Length(int numberOfElements)
        {
            var result = 0;
            var permutations = this.Factorial(numberOfElements);

            for (int i = 1; i <= numberOfElements; i++)
            {
                result += permutations / (this.Factorial(i) * this.Factorial(numberOfElements - i));
            }

            return result;
        }

        private int Factorial(int number)
        {
            var result = 1;

            for (int i = number; i > 1; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}
