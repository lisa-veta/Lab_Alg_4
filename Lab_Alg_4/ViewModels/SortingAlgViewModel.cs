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

        private List<string> _sortingAlgorithms;
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

        private int _slider;
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

        private List<int> list = new List<int>(){20, 10, 8, 15, 5, 1, -5};

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

        public ICommand Start => new CommandDelegate(param =>
        {
            FieldDefinition();
            StartDraw();
        });

        private void StartDraw()
        {
            switch(CurrentAlg)
            {
                case "Bubble Sort":
                    BubbleSort bubbleSort = new BubbleSort();
                    bubbleSort.DoBubbleSort(new int[] {20, 10, 8, 15, 5, 1, -5});
                    break;
                default:
                    break;
            }
        }

        private void FieldDefinition()
        {

            MainCanvas.Children.Clear();
            double RingWidth = MainCanvas.Width/40 - 2;
            double ringHeight = MainCanvas.Height / 30;
            double seter = 0;
            foreach(int i in list)
            {
                Rectangle rect = new Rectangle();
                rect.Width = RingWidth;
                rect.Height = ringHeight * Math.Abs(i);
                if (i < 0)
                {
                    Canvas.SetBottom(rect, 200 - i);
                }
                else
                {
                    Canvas.SetBottom(rect, 200);
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
    }
}
