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

namespace Catering
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MainF.Content = new Authentication();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            //Close_art.Visibility = Visibility.Visible;
            //Open.Visibility = Visibility.Hidden;
        }

        private void Close_art_Click(object sender, RoutedEventArgs e)
        {
            //Close_art.Visibility = Visibility.Hidden;
            //Open.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // NavigationService.Navigate(new Cook());
            Manager f = new Manager();
            f.Show();
        }
    }
}
