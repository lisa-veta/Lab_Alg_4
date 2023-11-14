using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_Alg_4.Views
{
    /// <summary>
    /// Логика взаимодействия для SetDataWindow.xaml
    /// </summary>
    public partial class SetDataWindow : Window
    {
        public SetDataWindow()
        {
            InitializeComponent();
        }

        public ViewModels.SetDataViewModel SetDataViewModel
        {
            get => default;
            set
            {
            }
        }
    }
}
