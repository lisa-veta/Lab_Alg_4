using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_4.Models
{
    public class ShellSort
    {

        public List<ItemSort> ItemsSort = new List<ItemSort>();
        public void DoShellSort(List<Item> items)
        {
            Item temp;
            int d = items.Count / 2;
            string comments = $"Находим диапазон сравнения:\n" +
                $"длина массива / 2 = {items.Count} / 2 = {d}\n" +
                $"Будем сравнивать элементы,\n" +
                $"находящиеся на расстоянии {d}";
            bool flag = true;
            while (d >= 1)
            {
                for (int i = d; i < items.Count; i++)
                {
                    int j = i;
                    while ((j >= d) && (items[j - d].Content > items[j].Content))
                    {
                        if (flag)
                        {
                            ItemsSort.Add(new ItemSort(items[j].Id, items[j - d].Id, Copyer.CopyListItem(items), comments));
                            flag = false;
                        }
                        else
                        {
                            comments = $"{j - d} и {j} элементы:\n" +
                                $"{items[j - d].Content} > {items[j].Content}, меняем их местами";
                            ItemsSort.Add(new ItemSort(items[j].Id, items[j - d].Id, Copyer.CopyListItem(items), comments));
                        }
                        temp = items[j];
                        items[j] = items[j - d];
                        items[j - d] = temp;
                        ItemsSort.Add(new ItemSort(items[j].Id, items[j - d].Id, Copyer.CopyListItem(items)));
                        j = j - d;
                    }
                }
                comments = $"Сортировка с диапазоном {d} закончена\n" +
                    $"Новый диапазон: {d} / 2 = {d/2}";
                flag = true;
                d = d / 2;
            }
        }


    }
}
