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
            string comments="";
            if (startInd >= endInd)
            {
                return;
            }
            comments = $"\nОпределяется опорный элемент Pivot \"{items[endInd].Content}\" \n";
            List<Item> itemsTemp = new List<Item>();
            for(int i = startInd; i < endInd; i++)
            {
                itemsTemp.Add(items[i]);
            }
            listItems.Add(new ItemSort(items[endInd].Id, Copyer.CopyListItem(items), itemsTemp, comments));
            int pivot = Partition(items, startInd, endInd, comments, itemsTemp);
            //comments = $"\nОпределяется опорный элемент Pivot \"{items[pivot].Content}\" \n";
            //listItems.Add(new ItemSort(pivot, Copyer.CopyListItem(items), comments));
            DoQuickSort(items, startInd, pivot - 1);
            DoQuickSort(items, pivot + 1, endInd);
        }

        public int Partition(List<Item> items, int startInd, int endInd, string comments, List<Item> itemsTemp)
        {
            Item pivot = items[endInd];
            int pivott = items[endInd].Content;
            int position = startInd - 1;
            for (int i = startInd; i <= endInd; i++)
            {
                if (items[i].Content < pivot.Content)
                {
                    position++;
                    comments = $"Элемент {i}({items[i].Content}) < опорного({pivot.Content}) => меняется c {items[position].Content}";
                    listItems.Add(new ItemSort(items[endInd].Id, items[i].Id, items[position].Id, Copyer.CopyListItem(items), itemsTemp));
                    Swap(items, i, position);
                    listItems.Add(new ItemSort(items[endInd].Id, items[i].Id, items[position].Id, Copyer.CopyListItem(items), itemsTemp, comments));
                }
            }
            position++;
            listItems.Add(new ItemSort(items[position].Id, items[endInd].Id, items[position].Id, Copyer.CopyListItem(items), itemsTemp));
            items[endInd] = items[position];
            items[position] = pivot;
            comments = $"Pivot {pivott} на правильную позицию {position}";
            listItems.Add(new ItemSort(items[position].Id,  items[endInd].Id, items[position].Id, Copyer.CopyListItem(items), itemsTemp, comments));

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