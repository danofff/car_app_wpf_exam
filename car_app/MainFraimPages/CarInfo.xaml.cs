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
    /// Логика взаимодействия для CarInfo.xaml
    /// </summary>
    public partial class CarInfo : Page
    {
        public CarInfo()
        {
            InitializeComponent();
            MainWindow.NavBlock.Text += ">Информация о машине";
            SelectedCar.Content = MainWindow.selectedNewEquipment.intGarageRoom + "/" + MainWindow.selectedNewEquipment.strSerialNo;
            CurrentDate.Content = String.Format(@"{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
            ManufacturerTB.Text = MainWindow.selectedNewEquipment.TablesManufacturer.strName;
            ModelTB.Text = MainWindow.selectedNewEquipment.TablesModel.strName;
            YearTB.Text = MainWindow.selectedNewEquipment.strManufYear;
            SerialTB.Text = MainWindow.selectedNewEquipment.strSerialNo;
            InDayTB.Text = MainWindow.selectedNewEquipment.intlimitDay.ToString();
            InWeekTB.Text = MainWindow.selectedNewEquipment.intlimitWeek.ToString();
            if (MainWindow.selectedNewEquipment.bitActive)
            {
                IsActive.Text = "Активная; ";
                IsActive.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                IsActive.Text = "Не активная; ";
                IsActive.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (MainWindow.selectedNewEquipment.bitKTG)
            {
                IsKTG.Text = "Учавствует в расчете КТГ; ";
                IsKTG.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                IsKTG.Text = "Не учавствует в расчете КТГ; ";
                IsKTG.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (MainWindow.selectedNewEquipment.bitMeter)
            {
                IsMeter.Text = "Учавствует в расчете моточасов; ";
                IsMeter.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                IsMeter.Text = "Не учавствует в расчете моточасов; ";
                IsMeter.Foreground = new SolidColorBrush(Colors.Red);
            }

            var query = from car in MainWindow.selectedRoomEquipment
                        orderby car.strSerialNo
                        select new 
                        {
                            Number = car.strSerialNo,
                            Garage = car.intGarageRoom,
                            Date = car.LastDate,                          
                            Metered = car.intLastMetered,
                            Total_met = car.intTotalMetered
                        };
            GarageList.ItemsSource = query.ToList();
        } 
    }
}
