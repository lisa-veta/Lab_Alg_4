using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_4.Models
{
    public class HeapSort
    {
        public List<ItemSort> ItemsSort = new List<ItemSort>();
        public void DoHeapSort(int[] vector)
        {
            int n = vector.Length;
            for (int i = n / 2; i >= 0; i--)
                MaxHeapify(vector, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(vector, 0, i);
                MaxHeapify(vector, i, 0);
            }
        }

        private void MaxHeapify(int[] vector, int n, int ind)
        {
            int largest = ind;
            int indLeft = ind * 2 + 1;
            int indRight = ind * 2 + 2;
            if (indLeft < n && vector[indLeft] > vector[largest])
                largest = indLeft;
            if (indRight < n && vector[indRight] > vector[largest])
                largest = indRight;
            if (largest != ind)
            {
                Swap(vector, ind, largest);
                MaxHeapify(vector, n, largest);
            }
        }

        private void Swap(int[] vector, int a, int b)
        {
            int box = vector[a];
            vector[a] = vector[b];
            vector[b] = box;
            ItemsSort.Add(new ItemSort(vector.ToList<int>()));
        }
    }
}
