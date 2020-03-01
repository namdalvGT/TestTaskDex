using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConversion_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string FullName = "Иванов Иван";
            Console.WriteLine("*******с помощью оператора == ********");
            Person person_1 = new Person();

            if (FullName.GetType() == person_1.GetType())//проверяет на основе типов перменных
            {
                Console.WriteLine("Невозможно преобразовать тестовый тип в класс Person");
            }
            else
            {
                string[] split = FullName.Split(new char[] { ' ' }, StringSplitOptions.None);
                if (split.Length > 1)
                {
                    person_1.LastName = split[0];
                    person_1.FirstName = split[1];

                    Console.WriteLine($"Фамилия:{person_1.LastName} Имя:{person_1.FirstName} ");
                }
                else
                {
                    Console.WriteLine("Необходимо указать фамилию и имя ");
                }

            }

            //----------------------------------------------------------------------
            Console.WriteLine("*******с помощью Equals********");
            Person person_2 = new Person();

            if (FullName.Equals(person_2))//проверят равен ли данный элемент сравниваемому,возврощает True/False
            {
                Console.WriteLine("Невозможно преобразовать тестовый тип в класс Person");
            }
            else
            {
                string[] split = FullName.Split(new char[] { ' ' }, StringSplitOptions.None);
                if (split.Length > 1)
                {
                    person_1.LastName = split[0];
                    person_1.FirstName = split[1];

                    Console.WriteLine($"Фамилия:{person_1.LastName} Имя:{person_1.FirstName} ");
                }
                else
                {
                    Console.WriteLine("Необходимо указать фамилию и имя ");
                }

            }

            Console.ReadKey();
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
    }
}
