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

        public ViewModels.SortingAlgViewModel SortingAlgViewModel
        {
            get => default;
            set
            {
            }
        }

        public ItemSort ItemSort
        {
            get => default;
            set
            {
            }
        }

        public void DoHeapSort(List<Item> items)
        {
            if (ItemsSort.Count == 0)
                ItemsSort.Add(new ItemSort(-100, -100, Copyer.CopyListItem(items), $"Представляем массив в виде бинарного дерева," +
                    $"\nу которого младшие узлы меньше родительского.\n" +
                    $"Для сортировки нужно поддерживать это свойство\n " +
                    $"дерева. Когда это происходит, то корень дерева \n" +
                    $"фиксируется в конце массива, а на его место\n встает самый левый лист. " +
                    $"И идет снова колибровка дерева по его свойству.\n Так производится сортировка."));
            int n = items.Count;
            for (int i = n / 2; i >= 0; i--)
                MaxHeapify(items, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(items, 0, i);
                MaxHeapify(items, i, 0);
            }
            ItemsSort.Add(new ItemSort(-100, -100, Copyer.CopyListItem(items), "Сортировка окончена."));
        }

        private void MaxHeapify(List<Item> items, int n, int ind)
        {
            ItemsSort.Add(new ItemSort(-100, -100, Copyer.CopyListItem(items), "Проверяем свойства дерева. Дочерние узлы\nдолжны быть меньше родительских."));
            int largest = ind;
            int indLeft = ind * 2 + 1;
            int indRight = ind * 2 + 2;
            if (indLeft < n && items[indLeft].Content > items[largest].Content)
            {
                largest = indLeft;
                ItemsSort.Add(new ItemSort(-100, -100, Copyer.CopyListItem(items), $"Левый узел {items[indLeft].Content} оказался больше\nсвоего родителя {items[largest].Content}."));
            }
            if (indRight < n && items[indRight].Content > items[largest].Content)
            {
                largest = indRight;
                ItemsSort.Add(new ItemSort(-100, -100, Copyer.CopyListItem(items), $"Правый узел {items[indRight].Content} оказался больше\nсвоего родителя {items[largest].Content}."));
            }
            if (largest != ind)
            {
                Swap(items, ind, largest);
                MaxHeapify(items, n, largest);
            }
        }

        private void Swap(List<Item> items, int a, int b)
        {
            ItemsSort.Add(new ItemSort(items[a].Id, items[b].Id, Copyer.CopyListItem(items), $"Меняем местами элементы {items[b].Content} и {items[a].Content}."));
            Item box = items[a];
            items[a] = items[b];
            items[b] = box;
            ItemsSort.Add(new ItemSort(items[a].Id, items[b].Id, Copyer.CopyListItem(items), $"Элементы {items[b].Content} и {items[a].Content} поменялись местами."));
        }
    }
}
