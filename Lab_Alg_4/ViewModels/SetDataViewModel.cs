using Lab_Alg_4.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab_Alg_4.ViewModels
{
    public class SetDataViewModel : BaseViewModel
    {
        public ObservableCollection<SetDataViewModel> Items { get; } = new ObservableCollection<SetDataViewModel>();

        private string _newElement;
        public string NewElement
        {
            get { return _newElement; }
            set
            {
                _newElement = value;
                OnPropertyChanged();
            }
        }
        public ICommand CreateElem => new CommandDelegate(param =>
        {
            Items.Add(new SetDataViewModel());
        });

        public ICommand RemoveElem => new CommandDelegate(param =>
        {
            if (Items.Count > 0)
            {
                Items.RemoveAt(Items.Count - 1);
            }
            return;
        });

        public ICommand CreateMas => new CommandDelegate(param =>
        {
            List<int> ints = new List<int>();
            foreach(var item in Items)
            {
                if (int.TryParse(item._newElement, out int num) && int.Parse(item._newElement) <= 20 && int.Parse(item._newElement) >= -20)
                {
                    ints.Add(num);
                }
                else
                {
                    MessageBox.Show("Некорректные данные, числа должны быть от -20 до 20");
                    return;
                }
            }
            if (Items == null)
            {
                MessageBox.Show("Данные не заполнены до конца");
                return;
            }
            SortingAlgWindow dragonFractalWindow = new SortingAlgWindow();
            SortingAlgViewModel dragonFractalViewModel = new SortingAlgViewModel();
            dragonFractalViewModel.MyList = ints;
            dragonFractalWindow.DataContext = dragonFractalViewModel;
            dragonFractalViewModel.FieldDefinition(ints);
            dragonFractalWindow.ShowDialog();
        });
    }
}
