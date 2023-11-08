using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;

namespace Lab_Alg_4.Models
{
    public class QuickSort
    {
        public List<List<int>> listItems = new List<List<int>>();
        public void DoQuickSort(int[] vector, int startInd, int endInd)
        {
            // int startInd = 0;
            // int endInd = vector.Length - 1;
            
            if (startInd >= endInd)
            {
                return;
            }
            int pivot = Partition(vector, startInd, endInd);
            DoQuickSort(vector, startInd, pivot - 1);
            DoQuickSort(vector, pivot + 1, endInd);
        }

        public int Partition(int[] vector, int startInd, int endInd)
        {
            int pivot = vector[endInd];
            int position = startInd - 1;
            for (int i = startInd; i <= endInd; i++)
            {
                if (vector[i] < pivot)
                {
                    position++;
                    Swap(vector, i, position);
                }
            }
            position++;
            vector[endInd] = vector[position];
            vector[position] = pivot;
            return position;
        }

        public void Swap(int[] vector, int ind1, int ind2)
        {
            int box = vector[ind1];
            vector[ind1] = vector[ind2];
            vector[ind2] = box;
            int[] updatedElements = (int[])vector.Clone();
            List<int> updateNewList = updatedElements.ToList();
            listItems.Add(updateNewList);
        }
    }
}