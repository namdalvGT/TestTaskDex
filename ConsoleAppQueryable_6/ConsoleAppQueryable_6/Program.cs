using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQueryable_6
{
    class Program
    {
       
        static void Main(string[] args)
        {
            MainClass manClass = new MainClass();
        }

        class MainClass
        {
            public ObservableCollection<Person> PersonCollection;
            public MainClass()
            {
                PersonCollection = GetPersonCollection();

                //Выборка по алфавиту
                var alfavit = PersonCollection.OrderBy(x=>x.Name);
                Console.WriteLine("\nВыборка по алфавиту");
                foreach (var selected in alfavit)
                {
                    Console.WriteLine($"{selected.Id} - {selected.Name} - {selected.Birthdate.ToShortDateString()} - {selected.Online}");
                }
                //--------------------------

                //Выборка по году рождения
                var vozrast = PersonCollection.Where(x => x.Birthdate.Date.Year>=1963 && x.Birthdate.Date.Year<=1980).OrderBy(x=>x.Birthdate);
                Console.WriteLine("\nВыборка по возрасту");
                foreach (var selected in vozrast)
                {
                    Console.WriteLine($"{selected.Id} - {selected.Name} - {selected.Birthdate.ToShortDateString()} - {selected.Online}");
                }

                var sum = PersonCollection.Sum(x=>x.Id);
                Console.WriteLine($"\nСумма ID:{sum}");
                var min = PersonCollection.Min(x => x.Id);
                Console.WriteLine($"\nМинимум ID:{min}");
                var max = PersonCollection.Max(x => x.Id);
                Console.WriteLine($"\nМаксимум ID:{max}");

                Console.WriteLine("\nГрупирование");
                var group = from i in alfavit
                    group i by i.Name;

                foreach (IGrouping<string,Person> g in group)
                {
                    Console.WriteLine(g.Key);
                    foreach (var selected in g)
                    {
                        Console.WriteLine($"{selected.Id} - {selected.Name} - {selected.Birthdate.ToShortDateString()} - {selected.Online}");
                    }
                }

                Console.ReadKey();
            }


            public ObservableCollection<Person> GetPersonCollection()
            {

                string names = " Аарон Абрам Аваз Августин Авраам Агап Агапит Агат Агафон Адам Адриан Азамат" +
                               " Азат Азиз Аид Айдар Айрат Акакий Аким Алан Александр Алексей Али Алик Алим" +
                               " Алихан Алишер Алмаз Альберт Амир Амирам Анар Анастасий Анатолий Анвар Ангел" +
                               " Андрей Анзор Антон Анфим Арам Аристарх Аркадий Арман Армен Арсен Арсений Арслан" +
                               " Артём Артемий Артур Архип Аскар Аслан Асхан Асхат Ахмет Ашот Бахрам Бенджамин " +
                               " Блез Богдан Борис Борислав Бронислав Булат Вадим Валентин Валерий Вальдемар" +
                               " Вардан Василий Вениамин Виктор Вильгельм Вит Виталий Влад Владимир Владислав" +
                               " Владлен Влас Всеволод Вячеслав Гавриил Гамлет Гарри Геннадий Генри Генрих" +
                               " Георгий Герасим Герман Германн Глеб Гордей Григорий Густав Давид Давлат" +
                               " Дамир Дана Даниил Данил Данис Данислав Даниэль Данияр Дарий Даурен Демид" +
                               " Демьян Денис Джамал Джан Джеймс Джереми (Иеремия) Джозеф Джонатан Дик Дин" +
                               " Динар Дино Дмитрий Добрыня Доминик Евгений Евдоким Евсей Евстахий" +
                               " Егор Елисей Емельян Еремей Ефим Ефрем Ждан" +
                               " Жерар Жигер Закир Заур Захар Зенон Зигмунд" +
                               " Зиновий Зураб Зуфар Ибрагим Иван Игнат" +
                               " Игнатий Игорь Иероним Иисус Ильгиз" +
                               " Ильнур Ильшат Илья Ильяс Имран Иннокентий" +
                               " Ираклий Исаак Исаакий Исидор Искандер Ислам Исмаил Итан";
                string[] namesSplit = names.Split(new char[] { ' ' }, StringSplitOptions.None);
                Random random = new Random();
                bool r = false;
                var collection = new ObservableCollection<Person>();
                for (int i = 0; i < 101; i++)
                {
                    if (r) { r = false; }
                    else
                    {
                        r = true;
                    }
                    collection.Add(new Person() { Id = i, Name = namesSplit[random.Next(minValue: 1, maxValue: 80)], Birthdate = DateTime.Now.AddMonths(-random.Next(1,1000)), Online = r });

                }

                return new ObservableCollection<Person>(collection);
            }


            public class Person
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public DateTime Birthdate { get; set; }
                public bool Online { get; set; }
            }


        }



    }
}
