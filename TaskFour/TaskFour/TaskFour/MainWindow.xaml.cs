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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;
using ViewModel.Interfaces;


namespace TaskFour
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public void ShowPopup(string message)
        {
            MessageBox.Show(message);
        }


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainViewModel mainViewModel = (MainViewModel)DataContext;
            mainViewModel.MainWindow = this;
        }
    }
}