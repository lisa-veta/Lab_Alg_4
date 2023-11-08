using Lab_Alg_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab_Alg_4.ViewModels
{
    public  class SortingAlgViewModel : BaseViewModel
    {
        private List<string> _sortingAlgorithms = new List<string> { "Bubble Sort", "Heap Sort","Quick Sort" };
        public List<string> ListOfAlgorithms
        {
            get { return _sortingAlgorithms; }
            set 
            { 
                _sortingAlgorithms = value;
                OnPropertyChanged();
            }
        }

        private string _currentAlg;
        public string CurrentAlg
        {
            get { return _currentAlg; }
            set
            {
                _currentAlg = value;
                SetDictElement(OriginalListElements);
                FieldDefinition(IndElements);
                OnPropertyChanged();
            }
        }

        private string _sequenceNum;
        public string SequenceNum
        {
            get { return _sequenceNum; }
            set
            {
                _sequenceNum = value;
                OnPropertyChanged();
            }
        }

        private string _movements;
        public string Movements
        {
            get { return _movements; }
            set
            {
                _movements = value;
                OnPropertyChanged();
            }
        }

        private int _slider = 500;
        public int Slider
        {
            get { return _slider; }
            set
            {
                _slider = value;
                OnPropertyChanged();
            }
        }

        private Canvas _mainCanvas = new Canvas();
        public Canvas MainCanvas
        {
            get { return _mainCanvas; }
            set
            {
                _mainCanvas = value;
                OnPropertyChanged();
            }
        }

        public List<int> OriginalListElements = new List<int>();

        private List<Item> IndElements = new List<Item>();

        public List<Item> SetDictElement(List<int> listElement)
        {
            List<Item> result = new List<Item>();
            int ind = 0;
            foreach (int item in listElement)
            {
                result.Add(new Item(ind, item));
                ind++;
            }
            IndElements = result;
            return IndElements;
        }

        private double _setPosition;
        public double Position
        {
            get { return _setPosition; }
            set
            {
                _setPosition = 3;
                OnPropertyChanged();
            }
        }

        private bool _isEnabledComb = true;

        public bool IsEnabledComb
        {
            get { return _isEnabledComb; }
            set
            {
                OnPropertyChanged();
            }
        }
    


        public ICommand Start => new CommandDelegate(param =>
        {
            SetDictElement(OriginalListElements);
            FieldDefinition(IndElements);
            StartDraw();
        });

        private void StartDraw()
        {
            switch(CurrentAlg)
            {
                case "Bubble Sort":
                    BubbleSort bubbleSort = new BubbleSort();
                    bubbleSort.DoBubbleSort(IndElements);
                    MoveRectangle(bubbleSort.ItemsSort);
                    break;
                case "Heap Sort":
                    HeapSort heapSort = new HeapSort();
                    heapSort.DoHeapSort(IndElements);
                    MoveRectangle(heapSort.ItemsSort);
                    break;
                case "Quick Sort":
                    QuickSort quickSort = new QuickSort();
                    quickSort.DoQuickSort(IndElements,0,IndElements.Count-1);
                    MoveRectangle(quickSort.listItems);
                    break;
                default:
                    break;
            }
        }

        public void FieldDefinition(List<Item> list, ItemSort settings = null)
        {
            MainCanvas.Children.Clear();
            double RingWidth = 600/40 - 2;
            double ringHeight = 425 / 40;
            double seter = 0;
            foreach(Item item in list)
            {
                Rectangle rect = new Rectangle();
                rect.Width = RingWidth;
                rect.Height = ringHeight * Math.Abs(item.Content);
                if (item.Content < 0)
                {
                    Canvas.SetBottom(rect, -200 + item.Content * ringHeight);
                }
                else
                {
                    Canvas.SetBottom(rect, -200);
                }
                Canvas.SetLeft(rect, seter);
                seter += RingWidth + 2;
                if(settings != null && (item.Id == settings.positionFrom || item.Id == settings.positionTo))
                {
                    rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#5555FF");
                    rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom("#5555FF");
                }
                else 
                {
                    rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3EFF");
                    rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3EFF");
                }
                rect.StrokeThickness = 1;
                rect.RadiusX = 10;
                rect.RadiusY = 10;

                MainCanvas.Children.Add(rect);
            }
        }

        private async void MoveRectangle(List<ItemSort> list)
        {
            
            for (int i = 0; i < list.Count; i++)
            {
                IsEnabledComb = false;
                FieldDefinition(list[i].elements, list[i]);
                await Task.Delay(1010 - Slider);
            }
        }

    }
}
