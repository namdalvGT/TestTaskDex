using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosoleAppOOP_1
{

    public class Main
    {
        public Main()
        {
            Cars cars = new Cars();
            Console.WriteLine("*****************Автомобили******************");
            cars.InsertedInfo(cars.GetAutoInfo());


            Moto moto = new Moto();
            Console.WriteLine("*****************Мотоциклы******************");
            moto.InsertedInfo(moto.GetMotoInfo());
            Console.ReadKey();
        }

        public class Cars 
        {

            public ObservableCollection<AutoInfo> GetAutoInfo()
            {
                var list = new ObservableCollection<AutoInfo>();

                list.Add(new AutoInfo(){Id = 1,Brand = "Toyota",Model = "Avensis Verso",HorsePower = 120,Year = 2001});
                list.Add(new AutoInfo(){Id = 2,Brand = "Volkswagen",Model = "GOLF MK2",HorsePower = 70,Year = 1988});
                list.Add(new AutoInfo(){Id = 3,Brand = "Nissan ",Model = "Primera ",HorsePower = 80,Year = 1993});

                return list;
            }

            #region [1] Сущности

            public class AutoInfo
            {
                public int Id { get; set; }
                public string Brand { get; set; }
                public string Model { get; set; }
                public int Year { get; set; }
                public float HorsePower { get; set; }

            }

            #endregion
            
            public void InsertedInfo(ObservableCollection<AutoInfo> autoInfoList)
            {
                if (autoInfoList.Any())
                {
                    foreach (var autoInfo in autoInfoList)
                    {
                        DisplayAutoInfo(autoInfo);
                    }

                    Console.WriteLine("Готово");
                }
                else
                {
                    Console.WriteLine("Список пуст.");
                }
            }

            public void DisplayAutoInfo(AutoInfo autoInfo)
            {

                Console.WriteLine(
                    $"Id:{autoInfo.Id}\nМарка:{autoInfo.Brand}\nМодель:{autoInfo.Model}\nГод выпуска:{autoInfo.Year}\nЛС:{autoInfo.HorsePower}\n");
            }

        }

        public class Moto : Cars
        {
          public ObservableCollection<AutoInfo> GetMotoInfo()
            {
                var list = new ObservableCollection<AutoInfo>();

                list.Add(new AutoInfo(){Id = 1,Brand = "Motomax", Model = "CBR 250", HorsePower = 150,Year = 2017});
                list.Add(new AutoInfo(){Id = 2,Brand = "Gherakl", Model = "F3 Sport 350cc", HorsePower = 50,Year = 2019});
                list.Add(new AutoInfo(){Id = 3,Brand = "Урал ", Model = "M72. K750.m61", HorsePower = 80,Year = 1990});

                return list;
            }

          

        }
    }

}
