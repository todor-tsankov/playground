using Algorithms.Sorting.Contracts;

namespace Algorithms.Sorting
{
    public class RadixSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            var values = new int[arr.Length][];

            var possitiveQueues = new Queue<int[]>[10];
            var negativeQueues = new Queue<int[]>[10];

            for (int i = 0; i <= 9; i++)
            {
                possitiveQueues[i] = new Queue<int[]>();
                negativeQueues[i] = new Queue<int[]>();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                values[i] = new int[] { arr[i], arr[i] };
            }

            var finished = false;

            while (!finished)
            {
                finished = true;

                for (int i = 0; i < values.Length; i++)
                {
                    var currentPair = values[i];
                    var queueIndex = currentPair[1] % 10;
                    currentPair[1] /= 10;

                    if (currentPair[1] != 0)
                    {
                        finished = false;
                    }

                    if (queueIndex >= 0)
                    {
                        possitiveQueues[queueIndex].Enqueue(currentPair);
                        continue;
                    }

                    negativeQueues[queueIndex * -1].Enqueue(currentPair);
                }

                var arrIndex = EmptyQueues(values, negativeQueues, 0);
                EmptyQueues(values, possitiveQueues, arrIndex);
            }

            for (int i = 0; i < values.Length; i++)
            {
                arr[i] = values[i][0];
            }
        }

        private int EmptyQueues(int[][] values, Queue<int[]>[] queues, int valuesIndex)
        {
            for (int i = 0; i < queues.Length - 1; i++)
            {
                var currentQueue = queues[i];
                while (currentQueue.Count > 0)
                {
                    values[valuesIndex++] = currentQueue.Dequeue();
                }
            }

            return valuesIndex;
        }
    }
}
