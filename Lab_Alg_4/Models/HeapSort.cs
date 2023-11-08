﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_4.Models
{
    public class HeapSort
    {
        public List<ItemSort> ItemsSort = new List<ItemSort>();
        public void DoHeapSort(List<Item> items)
        {
            int n = items.Count;
            for (int i = n / 2; i >= 0; i--)
                MaxHeapify(items, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(items, 0, i);
                MaxHeapify(items, i, 0);
            }
        }

        private void MaxHeapify(List<Item> items, int n, int ind)
        {
            int largest = ind;
            int indLeft = ind * 2 + 1;
            int indRight = ind * 2 + 2;
            if (indLeft < n && items[indLeft].Content > items[largest].Content)
                largest = indLeft;
            if (indRight < n && items[indRight].Content > items[largest].Content)
                largest = indRight;
            if (largest != ind)
            {
                Swap(items, ind, largest);
                MaxHeapify(items, n, largest);
            }
        }

        private void Swap(List<Item> items, int a, int b)
        {
            Item box = items[a];
            items[a] = items[b];
            items[b] = box;
            ItemsSort.Add(new ItemSort(items[a].Id, items[b].Id, Copyer.CopyListItem(items)));
        }
    }
}