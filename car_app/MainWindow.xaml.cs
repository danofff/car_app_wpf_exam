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

namespace car_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainFrame;
        public static TextBlock NavBlock;
        public static car_db DataBase;
        public static List<newEquipment> newEquipmentList;
        public static List<TablesManufacturer> ManufacturerList;
        public static List<TablesModel> ModelList;
        public static List<TablesSNPrefix> PrefixList;
        public static newEquipment selectedNewEquipment;
        public static List<newEquipment> selectedRoomEquipment;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame = MFraim;
            MainFrame.Source = new Uri(@"MainFraimPages\HomePage.xaml", UriKind.RelativeOrAbsolute);
            NavBlock = BreadCrumb;
            DataBase = new car_db();           
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri(@"MainFraimPages\HomePage.xaml", UriKind.RelativeOrAbsolute);
            NavBlock.Text = "Главная";
        }

        private void CarList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri(@"MainFraimPages\HomePage.xaml", UriKind.RelativeOrAbsolute);
            NavBlock.Text = "Главная";
        }
    }
}
