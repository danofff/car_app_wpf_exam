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

namespace car_app.MainFraimPages
{
    /// <summary>
    /// Логика взаимодействия для EverithingIsGoodxaml.xaml
    /// </summary>
    public partial class EverithingIsGoodxaml : Page
    {
        public EverithingIsGoodxaml()
        {
            InitializeComponent();
        }

        private void AddMore_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Source = new Uri(@"MainFraimPages\AddCarPage.xaml", UriKind.RelativeOrAbsolute);
            MainWindow.NavBlock.Text = "Главная>Добавить машину";
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Source = new Uri(@"MainFraimPages\HomePage.xaml", UriKind.RelativeOrAbsolute);
            MainWindow.NavBlock.Text = "Главная";
        }
    }
}
