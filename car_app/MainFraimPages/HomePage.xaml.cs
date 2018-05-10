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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            MainWindow.newEquipmentList = MainWindow.DataBase.newEquipment.ToList();

        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Source = new Uri(@"MainFraimPages\AddCarPage.xaml", UriKind.RelativeOrAbsolute);
            MainWindow.NavBlock.Text += ">Добавить машину";
        }
        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            
            var query = from car in MainWindow.newEquipmentList
                        orderby car.intGarageRoom
                        select  new MyEquipment { Garage=car.intGarageRoom,
                                      Manufacturer =car.TablesManufacturer.strName,
                                      Model=car.TablesModel.strName,
                                      Manuf_Year=car.strManufYear,
                                      Number=car.strSerialNo,
                                      Last_met=car.intLastMetered,
                                      Total_met=car.intTotalMetered };
            CarsList.ItemsSource = query.ToList();
        }

        private void CarsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            MyEquipment selected = (MyEquipment)CarsList.SelectedItem;
            MainWindow.selectedNewEquipment=new newEquipment();
            foreach (var item in MainWindow.newEquipmentList)
            {
                if (item.strSerialNo == selected.Number)
                {
                    MainWindow.selectedNewEquipment = item;
                    break;
                }
            }
            MainWindow.selectedRoomEquipment = new List<newEquipment>();
            foreach (var item in MainWindow.newEquipmentList)
            {
                if (item.intGarageRoom == selected.Garage)
                {
                    MainWindow.selectedRoomEquipment.Add(item);
                }
            }
            MainWindow.MainFrame.Source = new Uri(@"MainFraimPages\CarInfo.xaml", UriKind.RelativeOrAbsolute);

        }
    }
}
