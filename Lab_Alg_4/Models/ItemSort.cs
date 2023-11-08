using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_4.Models
{
    public class ItemSort
    {
        public int positionFrom;
        public int positionTo;
        public List<int> elements;
        public ItemSort(List<int> elements)
        {
            this.elements = elements;
        }
        public ItemSort(int positionFrom, int positionTo, List<int> elements)
        {
            this.positionFrom = positionFrom;
            this.positionTo = positionTo;
            this.elements = elements;
        }
    }
}
