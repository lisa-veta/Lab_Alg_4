using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_4.Models
{
    public static class Copyer
    {
        public static List<Item> CopyListItem(List<Item> list)
        {
            List<Item> copy = new List<Item>();
            foreach (Item item in list) 
            {
                copy.Add(new Item(item.Id, item.Content));
            }
            return copy;
        }
    }
}
