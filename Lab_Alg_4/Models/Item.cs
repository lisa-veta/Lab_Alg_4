using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_4.Models
{
    public class Item
    {
        public int Id { get; }
        public int Content { get; }

        public ItemSort ItemSort
        {
            get => default;
            set
            {
            }
        }

        public Item(int ind, int content)
        {
            Id = ind;
            Content = content;
        }
    }
}
