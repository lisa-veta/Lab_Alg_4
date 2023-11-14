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

        public ItemSort ItemSort
        {
            get => default;
            set
            {
            }
        }

        public void DoBubbleSort(List<Item> items)
        {
            string comment = "Сортировка пузырьком\n";
            bool flag = true;
            Item temp;
            for (int i = 0; i < items.Count - 1; i++)
            {
                comment += $"\nРассматриваем массив от начала до {items.Count - i} элемента\n";
                flag = true;
                for (int j = 0; j < items.Count - i - 1; j++)
                {
                    if (items[j].Content > items[j + 1].Content)
                    {
                        if (flag)
                        {
                            comment += $"{items[j].Content} > {items[j + 1].Content} меняем их местами";
                            ItemsSort.Add(new ItemSort(items[j].Id, items[j + 1].Id, Copyer.CopyListItem(items), comment));
                            flag = false;
                        }
                        else
                        {
                            comment = $"{items[j].Content} > {items[j + 1].Content} меняем их местами";
                            ItemsSort.Add(new ItemSort(items[j].Id, items[j + 1].Id, Copyer.CopyListItem(items), comment));
                        }
                        temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        ItemsSort.Add(new ItemSort(items[j].Id, items[j + 1].Id, Copyer.CopyListItem(items)));
                        comment = "";
                    }
                }
                comment = $"\nПередвинули максимальный элемент\nна позицию {items.Count - i}\n";
            }
        }
    }
}
