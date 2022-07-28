using Algorithms.Sorting.Contracts;

namespace Algorithms.Sorting
{
    public class HeapSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            var root = this.ToTree(arr);
            this.BuildMaxHeap(root);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = root.Value;
                Heapify(root);
            }
        }

        private Node ToTree(int[] arr, int index = 0)
        {
            if (index >= arr.Length)
            {
                return null;
            }

            var current = new Node() { Value = arr[index] };
            index *= 2;

            current.FirstChild = ToTree(arr, ++index);
            current.SecondChild = ToTree(arr, ++index);

            return current;
        }

        private void BuildMaxHeap(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.BuildMaxHeap(node.FirstChild);
            this.BuildMaxHeap(node.SecondChild);

            var current = node.Value;

            if (node.BiggestChild == null || current >= node.BiggestChild.Value)
            {
                return;
            }

            node.Value = node.BiggestChild.Value;
            node.BiggestChild.Value = current;

            this.Sink(node.BiggestChild, current);
        }

        private void Sink(Node node, int value)
        {
            var biggestChild = node.BiggestChild;

            if (biggestChild == null)
            {
                return;
            }

            if (biggestChild.Value >= value)
            {
                node.Value = biggestChild.Value;
                biggestChild.Value = value;

                return;
            }

            this.Sink(biggestChild, value);
        }

        private bool Heapify(Node node)
        {
            if (node.BiggestChild == null)
            {
                return true;
            }

            node.Value = node.BiggestChild.Value;

            if (this.Heapify(node.BiggestChild))
            {
                node.RemoveBiggestChild();
            };

            return false;
        }

        private class Node
        {
            public int Value { get; set; }
            public Node FirstChild { get; set; }
            public Node SecondChild { get; set; }

            public Node BiggestChild => FirstChild == null || SecondChild?.Value > FirstChild.Value ? SecondChild : FirstChild;

            public void RemoveBiggestChild()
            {
                if (BiggestChild == FirstChild)
                {
                    FirstChild = null;
                    return;
                }

                SecondChild = null;
            }
        }
    }
}
