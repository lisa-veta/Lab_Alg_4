using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;

namespace Lab_Alg_4.Models
{
    public class QuickSort
    {
        public List<ItemSort> listItems = new List<ItemSort>();
        public void DoQuickSort(List<Item> items, int startInd, int endInd)
        {
            if (startInd >= endInd)
            {
                return;
            }
            int pivot = Partition(items, startInd, endInd);
            listItems.Add(new ItemSort(pivot, Copyer.CopyListItem(items)));
            DoQuickSort(items, startInd, pivot - 1);
            DoQuickSort(items, pivot + 1, endInd);
        }

        public int Partition(List<Item> items, int startInd, int endInd)
        {
            Item pivot = items[endInd];
            int position = startInd - 1;
            for (int i = startInd; i <= endInd; i++)
            {
                if (items[i].Content < pivot.Content)
                {
                    position++;

                    listItems.Add(new ItemSort(items[i].Id, items[position].Id, Copyer.CopyListItem(items)));
                    Swap(items, i, position);
                    listItems.Add(new ItemSort(items[i].Id, items[position].Id, Copyer.CopyListItem(items)));
                }
            }
            position++;
            listItems.Add(new ItemSort(items[endInd].Id, items[position].Id, Copyer.CopyListItem(items)));
            items[endInd] = items[position];
            items[position] = pivot;
            listItems.Add(new ItemSort(items[endInd].Id, items[position].Id, Copyer.CopyListItem(items)));

            return position;
        }

        public void Swap(List<Item> items, int ind1, int ind2)
        {
            Item box = items[ind1];
            items[ind1] = items[ind2];
            items[ind2] = box;
        }
    }
}