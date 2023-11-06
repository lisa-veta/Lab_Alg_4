using Lab_Alg_4.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_Alg_4.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand StartWorkFractal => new CommandDelegate(param =>
        {
            SetDataWindow dragonFractalWindow = new SetDataWindow();
            SetDataViewModel dragonFractalViewModel = new SetDataViewModel();
            dragonFractalWindow.DataContext = dragonFractalViewModel;
            dragonFractalWindow.ShowDialog();
        });
    }
}
