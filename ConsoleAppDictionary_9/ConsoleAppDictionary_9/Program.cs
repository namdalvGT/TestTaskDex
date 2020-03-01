using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDictionary_9
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<Person,string> workDirectory = new Dictionary<Person,string>
            {
                { new Person {FullName = "Якубович Леонид Аркадьевич",BirthDate = new  DateTime(year:1954, month:02,day:05),PlaceOfBirth = "Москва",PassportId="12345"},"Первый канал"},
                { new Person() { FullName = "Васильева Наталья Петровна", BirthDate = new DateTime(year: 1954, month: 02, day: 05), PlaceOfBirth = "Тирасполь", PassportId = "6789"},"Школа №5"},
                { new Person() { FullName = "Федотов Александр Васильевич", BirthDate = new DateTime(year: 1940, month: 02, day: 05), PlaceOfBirth = "Кишинев", PassportId = "101112" },"Медецинский центр"}
            
            };

            Console.WriteLine("*********Справочник места работы*************");
            Console.WriteLine("Укажите ФИО");
            var FullName = Console.ReadLine();
            Console.WriteLine("Укажите дату рожедния");
            var BirthDate = Console.ReadLine();
            Console.WriteLine("Укажите Место рождения");
            var PlaceOfBirth = Console.ReadLine();
            Console.WriteLine("Укажите номер паспорта");
            var PassportId = Console.ReadLine();

            var Validate = Validatinon(FullName, BirthDate, PlaceOfBirth, PassportId);
            if (!Validate.r)
            {
                var search = workDirectory.ToArray().Where(x => x.Key.FullName.Trim().ToUpper().Contains(FullName.Trim().ToUpper())
                                                                && x.Key.BirthDate.Value.Date == Convert.ToDateTime(BirthDate).Date
                                                                && x.Key.PlaceOfBirth.Trim().ToUpper().Contains(PlaceOfBirth.Trim().ToUpper())
                                                                && x.Key.PassportId.Trim().ToUpper().Contains(PassportId.Trim().ToUpper()));

                if (search.Any())
                {
                    Console.WriteLine($"Текущее место работы:{search.FirstOrDefault().Value}");
                }
                else
                {
                    Console.WriteLine($"Работник \"{FullName}\" не найден в базе");
                }
            }
            else
            {
                Console.WriteLine("********Внимание******\n"+
                                  $"{Validate.Message}");
            }

            Console.ReadLine();


        }

        public static Validate Validatinon(string FulllName, string BirthDate, string PlaceOfBirth, string PassportId)
        {
            Validate validate = new Validate();

            if (string.IsNullOrEmpty(FulllName))
            {
                validate.r = true;
                validate.Message+= "\n- Не указали ФИО";
            }

            if (string.IsNullOrEmpty(BirthDate) )
            {
                validate.r = true;
                validate.Message += "\n- Не указали дату рождения";
            }

            try
            {
                DateTime date = Convert.ToDateTime(BirthDate);
            }
            catch (Exception e)
            {
                validate.r = true;
                validate.Message += "\n- Дата рождения, не соостветвует формату даты";
            }

            if (string.IsNullOrEmpty(PlaceOfBirth))
            {
                validate.r = true;
                validate.Message += "\n- Не указали место рождения";
            }

            if (string.IsNullOrEmpty(PassportId))
            {
                validate.r = true;
                validate.Message += "\n- Не указали номер паспорта";
            }
            
            return validate;
        }

        class Person
        {
            public string FullName { get; set; }
            public DateTime? BirthDate { get; set; }
            public string PlaceOfBirth { get; set; }
            public string PassportId { get; set; }
        }

        internal class Validate
        {
            public bool r { get; set; }
            public string Message { get; set; }
        }
    }
}
