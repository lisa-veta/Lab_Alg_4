using Lab_Alg_4.Models;
using Lab_Alg_4.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml;

namespace Lab_Alg_4.ViewModels
{
    public  class SortingAlgViewModel : BaseViewModel
    {

        private List<string> _sortingAlgorithms = new List<string> { "Bubble Sort", "Heap Sort", "Shell Sort","Quick Sort" };
        public ObservableCollection<string> Movements { get; set; } = new ObservableCollection<string>();
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

        //private string _movements;
        //public string Movements
        //{
        //    get { return _movements; }
        //    set
        //    {
        //        _movements = value;
        //        OnPropertyChanged();
        //    }
        //}

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
        private List<ItemSort> SortElements = new List<ItemSort>();

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
            SortElements.Clear();
            Movements.Clear();
            SetDictElement(OriginalListElements);
            FieldDefinition(IndElements, null, true);
            _isEnabledComb = false;
            StartDraw();
            _isEnabledComb = true;
        });

        public ICommand Finish => new CommandDelegate(param =>
        {
            Movements.Clear();
            GetMovements(SortElements);
            SortElements.Clear();
            FieldDefinition(IndElements, null, true);
            _isEnabledComb = true;
        });

        private void StartDraw()
        {
            switch(CurrentAlg)
            {
                case "Bubble Sort":
                    BubbleSort bubbleSort = new BubbleSort();
                    bubbleSort.DoBubbleSort(IndElements);
                    SortElements = bubbleSort.ItemsSort;
                    MoveRectangle(SortElements);
                    break;
                case "Heap Sort":
                    HeapSort heapSort = new HeapSort();
                    heapSort.DoHeapSort(IndElements);
                    SortElements = heapSort.ItemsSort;
                    MoveRectangle(SortElements);
                    break;
                case "Shell Sort":
                    ShellSort shellSort = new ShellSort();
                    shellSort.DoShellSort(IndElements);
                    SortElements = shellSort.ItemsSort;
                    MoveRectangle(SortElements);
                    break;
                case "Quick Sort":
                    QuickSort quickSort = new QuickSort();
                    quickSort.DoQuickSort(IndElements,0,IndElements.Count-1);
                    SortElements = quickSort.listItems;
                    MoveRectangle(SortElements);
                    break;
                default:
                    break;
            }
        }

        public void FieldDefinition(List<Item> list, ItemSort settings = null, bool flag = false)
        {
            MainCanvas.Children.Clear();
            double RingWidth = 600/40 - 2;
            double ringHeight = 425 / 40;
            double seter = 0;
            int count = 0;
            int pivotCount = 0;
            int quickCount = 0;
            foreach (Item item in list)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
                textBlock.Text = item.Content.ToString();
                textBlock.FontSize = 10;
                Rectangle rect = new Rectangle();
                rect.Width = RingWidth;
                rect.Height = ringHeight * Math.Abs(item.Content);
                if (item.Content == 0)
                {
                    rect.Height = ringHeight;
                }

                if (item.Content < 0)
                {
                    Canvas.SetLeft(textBlock, seter);
                    Canvas.SetBottom(textBlock, -200 + item.Content* ringHeight - 10);
                    MainCanvas.Children.Add(textBlock);
                    Canvas.SetBottom(rect, -200 + item.Content * ringHeight);
                }
                else if (item.Content == 0)
                {
                    Canvas.SetLeft(textBlock, seter);
                    Canvas.SetBottom(textBlock, -195);
                    MainCanvas.Children.Add(textBlock);
                    Canvas.SetBottom(rect, -205);
                }
                else
                {
                    Canvas.SetLeft(textBlock, seter);
                    Canvas.SetBottom(textBlock, -200 + item.Content * ringHeight);
                    MainCanvas.Children.Add(textBlock);
                    Canvas.SetBottom(rect, -200);
                }

                Canvas.SetLeft(rect, seter);
                seter += RingWidth + 2;
                if (settings != null && (item.Id == settings.positionFrom || item.Id == settings.positionTo))
                {
                    count += 1;
                    quickCount += 1;
                    rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#5555FF");
                    rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom("#5555FF");
                }
                else
                {
                    rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3EFF");
                    rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3EFF");
                }
                if (settings != null && (item.Id == settings.pivotIndex) && CurrentAlg == "Quick Sort")
                {
                    pivotCount += 1;
                    rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#008000");
                    rect.Stroke = (SolidColorBrush)new BrushConverter().ConvertFrom("#008000");
                }

                rect.StrokeThickness = 1;
                rect.RadiusX = 10;
                rect.RadiusY = 10;
                MainCanvas.Children.Add(rect);
                if (settings != null && ((settings.comment != null && quickCount == 4)||(settings.comment != null && pivotCount==1)||(settings.comment != null && settings.pivotIndex == item.Id))&& CurrentAlg == "Quick Sort")
                {
                    Movements.Add(settings.comment);
                    quickCount = 0;
                    pivotCount = 0;
                }
            }
            IsEnabledComb = flag;
        }
        private async void MoveRectangle(List<ItemSort> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                IsEnabledComb = false;
                FieldDefinition(list[i].elements, list[i]);
                await Task.Delay(1010 - Slider);
            }
            IsEnabledComb = true;
            FieldDefinition(IndElements, null, true);
        }

        private void GetMovements(List<ItemSort> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int count = 0;
                foreach (Item item in list[i].elements)
                {
                    if (list[i] != null && (item.Id == list[i].positionFrom || item.Id == list[i].positionTo))
                    {
                        count += 1;
                    }
                    if (list[i] != null && list[i].comment != null && count == 2)
                    {
                        Movements.Add(list[i].comment);
                        count = 0;
                    }
                }
            }
        }

        public Views.SortingAlgWindow SortingAlgWindow
        {
            get => default;
            set
            {
            }
        }

        public CommandDelegate CommandDelegate
        {
            get => default;
            set
            {
            }
        }

        public HeapSort HeapSort
        {
            get => default;
            set
            {
            }
        }

        public QuickSort QuickSort
        {
            get => default;
            set
            {
            }
        }

        public ShellSort ShellSort
        {
            get => default;
            set
            {
            }
        }

        public BubbleSort BubbleSort
        {
            get => default;
            set
            {
            }
        }

        public BubbleSort BubbleSort1
        {
            get => default;
            set
            {
            }
        }
    }
}
