using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_4.Models
{
    public class BubbleSort
    {
        public List<List<int>> ItemsSort = new List<List<int>>(); 
        public void DoBubbleSort(int[] vector)
        {
            int temp;
            for (int i = 0; i < vector.Length - 1; i++)
            {
                for (int j = 0; j < vector.Length - i - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        temp = vector[j];
                        vector[j] = vector[j + 1];
                        vector[j + 1] = temp;
                        int[] mass1 = (int[])vector.Clone();
                        List<int> list1 = mass1.ToList();
                        ItemsSort.Add(list1);
                    }
                }
            }
        }
    }
}
