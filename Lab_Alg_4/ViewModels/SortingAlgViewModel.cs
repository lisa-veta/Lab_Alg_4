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
        private List<string> _sortingAlgorithms = new List<string> { "Bubble Sort", "Heap Sort" };
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
                FieldDefinition(MyList);
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

        public List<int> MyList = new List<int>();

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
            
            FieldDefinition(MyList);
            StartDraw();
        });

        private void StartDraw()
        {
            switch(CurrentAlg)
            {
                case "Bubble Sort":
                    BubbleSort bubbleSort = new BubbleSort();
                    bubbleSort.DoBubbleSort(MyList.ToArray());
                    MoveRectangle(bubbleSort.ItemsSort);
                    break;
                case "Heap Sort":
                    HeapSort heapSort = new HeapSort();
                    heapSort.DoHeapSort(MyList.ToArray());
                    MoveRectangle(heapSort.ItemsSort);
                    break;
                default:
                    break;
            }
        }

        public void FieldDefinition(List<int> list)
        {
            MainCanvas.Children.Clear();
            double RingWidth = 600/40 - 2;
            double ringHeight = 425 / 40;
            double seter = 0;
            foreach(int i in list)
            {
                Rectangle rect = new Rectangle();
                rect.Width = RingWidth;
                rect.Height = ringHeight * Math.Abs(i);
                if (i < 0)
                {
                    Canvas.SetBottom(rect, -200 + i* ringHeight);
                }
                else
                {
                    Canvas.SetBottom(rect, -200);
                }
                Canvas.SetLeft(rect, seter);
                seter += RingWidth + 2;
                rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3EFF");
                rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3EFF");
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
                FieldDefinition(list[i].elements);
                await Task.Delay(1010 - Slider);
            }
        }

    }
}
