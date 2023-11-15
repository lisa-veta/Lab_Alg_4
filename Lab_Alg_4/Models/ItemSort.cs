using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Serialization;

namespace Lab_Alg_4.Models
{
    public class ItemSort
    {
        public int positionFrom;
        public int positionTo;
        public List<Item> elements;
        public string comment;
        public int pivotIndex;
        public ItemSort(List<Item> elements)
        {
            this.elements = elements;
        }
        public ItemSort(int positionFrom, int positionTo, List<Item> elements, string comment = null)
        {
            this.positionFrom = positionFrom;
            this.positionTo = positionTo;
            this.elements = elements;
            this.comment = comment;
        }

        public ItemSort(int pivotInd, int positionFrom, int positionTo, List<Item> elements, string comment = null)
        {
            this.pivotIndex = pivotInd;
            this.positionFrom = positionFrom;
            this.positionTo = positionTo;
            this.elements = elements;
            this.comment = comment;
        }

        public ItemSort(int pivot, List<Item> elements, string comment = null)
        {
            this.pivotIndex = pivot;
            this.elements = elements;
            this.comment = comment;
        }
    }
}
