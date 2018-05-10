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
using System.Threading;

namespace car_app.MainFraimPages
{
    /// <summary>
    /// Логика взаимодействия для AddCarPage.xaml
    /// </summary>
    public partial class AddCarPage : Page
    {
        public AddCarPage()
        {
            InitializeComponent();
            MainWindow.ManufacturerList = MainWindow.DataBase.TablesManufacturer.ToList();
            var query = from manuf in MainWindow.ManufacturerList
                        orderby manuf.strName
                        select  manuf.strName;
            List<string> helpList = query.ToList();
            helpList.Add("Выберете");          
            Manufacturer.ItemsSource = helpList;
            Manufacturer.SelectedIndex = helpList.Count - 1;
            Manufacturer.Text = "Выберете";

            MainWindow.ModelList = MainWindow.DataBase.TablesModel.ToList();

            query = from modl in MainWindow.ModelList
                    orderby modl.strName
                    select modl.strName;
            helpList = query.ToList();
            helpList.Add("Выберете");
            Model.ItemsSource = helpList;
            Model.SelectedIndex = helpList.Count - 1;

            MainWindow.PrefixList = MainWindow.DataBase.TablesSNPrefix.ToList();
            query = from pref in MainWindow.PrefixList
                    orderby pref.strPrefix
                    select pref.strPrefix;
            helpList = query.ToList();
            helpList.Add("Выберете");
            Prefix.ItemsSource = helpList;
            Prefix.SelectedIndex = helpList.Count - 1;

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.Source = new Uri(@"MainFraimPages\HomePage.xaml", UriKind.RelativeOrAbsolute);
            MainWindow.NavBlock.Text = "Главная";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            newEquipment addingEquipment = new newEquipment();  
            //проверка номера гаража          
            if(!String.IsNullOrEmpty(RoomNumber.Text))
            {
                addingEquipment.intGarageRoom=RoomNumber.Text;
            }
            else
            {
                AddToStatusInFo("Введите номер гаража!");
                goto spotWhereNothingHappens;
            }
            //провера производителя
            if (Manufacturer.Text != "Выберете")
            {
                foreach (var item in MainWindow.ManufacturerList)
                {
                    if (item.strName == Manufacturer.Text)
                    {
                        addingEquipment.intManufacturerID = item.intManufacturerID;
                        break;
                    }
                }    
            }
            else
            {
                AddToStatusInFo("Выберете производителя!");
                goto spotWhereNothingHappens;
            }
            //проверка модели
            if (Model.Text != "Выберете")
            {
                foreach (var item in MainWindow.ModelList)
                {
                    if (item.strName == Model.Text)
                    {
                        addingEquipment.intModelID = item.intModelID;
                        break;
                    }
                }
            }
            else
            {
                AddToStatusInFo("Выберете модель!");
                goto spotWhereNothingHappens;
            }
            //проверка года выпуска
            int year;
            Int32.TryParse(Year.Text, out year);
            if (Int32.TryParse(Year.Text, out year)&&year>1900&&year<DateTime.Now.Year)
            {
                addingEquipment.strManufYear = Year.Text;
            }
            else
            {
                AddToStatusInFo("Введите коррекный год выпуска!");
                goto spotWhereNothingHappens;
            }

            //проверка префикса
            if (Prefix.Text != "Выберете")
            {
                foreach (var item in MainWindow.PrefixList)
                {
                    if (item.strPrefix == Prefix.Text)
                    {
                        addingEquipment.intSNPrefixID = item.intSNPrefixID;
                        break;
                    }
                }
            }
            else
            {
                AddToStatusInFo("Выберете префикс!");
                goto spotWhereNothingHappens;
            }

            //проверка серийного номера
            if (String.IsNullOrEmpty(Serial.Text))
            {
                AddToStatusInFo("Введите серийный номер!");
                goto spotWhereNothingHappens;
            }
            else
            {
                foreach (var item in MainWindow.newEquipmentList)
                {
                    if (item.strSerialNo == Serial.Text)
                    {
                        AddToStatusInFo("Такой серийный номер уже существует!");
                        goto spotWhereNothingHappens;
                    }
                }
                addingEquipment.strSerialNo = Serial.Text;
            }
            //проверка моточасов
            double lMoto;
            double tMoto;
            if (!Double.TryParse(LastMeter.Text,out lMoto))
            {
                AddToStatusInFo("В последние моточасы введено не число!");
                goto spotWhereNothingHappens;
            }   
            if (!Double.TryParse(TotalMeter.Text, out tMoto))
            {
                AddToStatusInFo("В общие моточасы введено не число!");
                goto spotWhereNothingHappens;
            }
            if (lMoto > tMoto)
            {
                AddToStatusInFo("Последние моточасы не могут быть больше всех моточасов!");
                goto spotWhereNothingHappens;
            }
            addingEquipment.intLastMetered = lMoto;
            addingEquipment.intTotalMetered = tMoto;

            addingEquipment.bitActive = (bool)IsActive.IsChecked;
            addingEquipment.bitKTG = (bool)IsKTG.IsChecked;
            addingEquipment.bitPreservation = (bool)IsPreserved.IsChecked;
            addingEquipment.bitMeter = (bool)IsMetered.IsChecked;

            addingEquipment.bitMethodAmortization = (bool)AmortType.IsChecked;

            //проверка стоимости
            double price;
            if (Double.TryParse(Price.Text, out price) &&price>0)
            {
                addingEquipment.floatFullPrice = price;
            }
            else
            {
                AddToStatusInFo("Введите коррекную стоимость машины!");
                goto spotWhereNothingHappens;
            }
            //проверка срока службы
            int lCycle;
            if (Int32.TryParse(LifeCycle.Text, out lCycle) &&  lCycle > 0)
            {
                addingEquipment.intServiceLife = lCycle;
            }
            else
            {
                AddToStatusInFo("Введите коррекный срок службы машины!");
                goto spotWhereNothingHappens;
            }

            MainWindow.DataBase.newEquipment.Add(addingEquipment);
            MainWindow.DataBase.SaveChanges();
            MainWindow.MainFrame.Source = new Uri(@"MainFraimPages\EverithingIsGood.xaml", UriKind.RelativeOrAbsolute);
            
        spotWhereNothingHappens:;
        }

        private void AddToStatusInFo(string error)
        {
            StatsInfo.Foreground = new SolidColorBrush(Colors.Red);
            StatsInfo.Content = error;
        }
    }
}