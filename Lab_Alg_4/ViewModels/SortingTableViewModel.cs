using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_Alg_4.ViewModels
{
    public class SortingTableViewModel: BaseViewModel
    {

        private bool _isEnabledComb = true;

        public bool IsEnabledComb
        {
            get { return _isEnabledComb; }
            set
            {
                OnPropertyChanged();
            }
        }

        private List<string> _sortingAlgorithms = new List<string> { "Bubble Sort", "Heap Sort", "Shell Sort", "Quick Sort" };
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

        private DataTable selectedTable = new DataTable();
        public DataTable SelectedTable
        {
            get { return selectedTable; }
            set
            {
                selectedTable = value;
                OnPropertyChanged(nameof(SelectedTable));
            }
        }

        public ICommand Start => new CommandDelegate(param =>
        {
            SortElements.Clear();
            SetDictElement(OriginalListElements);
            FieldDefinition(IndElements);
            _isEnabledComb = false;
            StartDraw();
        });

        public ICommand Finish => new CommandDelegate(param =>
        {
            _isEnabledComb = true;
            SortElements.Clear();
            FieldDefinition(IndElements);
        });
    }
}
