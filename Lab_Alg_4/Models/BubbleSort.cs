using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_4.Models
{
    public class BubbleSort
    {
        public List<ItemSort> ItemsSort = new List<ItemSort>(); 
        public void DoBubbleSort(List<Item> items)
        {
            Item temp;
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = 0; j < items.Count - i - 1; j++)
                {
                    if (items[j].Content > items[j + 1].Content)
                    {
                        ItemsSort.Add(new ItemSort(items[j].Id, items[j + 1].Id, Copyer.CopyListItem(items)));
                        temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        ItemsSort.Add(new ItemSort(items[j].Id, items[j + 1].Id, Copyer.CopyListItem(items)));
                    }
                }
            }
        }
    }
}
