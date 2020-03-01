using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ConsoleAppSerialization_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(){Id = 1,FullName = "Иванов Иван Иванови",Age = 30,childrens = new Children(){Id = 1,FullName = "Иванова Екатерина Ивановна",Age = 7}};


            var serilization = JsonConvert.SerializeObject(person);
            Console.WriteLine("*****Serialize***********");
            Console.WriteLine($"{serilization}");
            Console.WriteLine();
            

            var desetilization = JsonConvert.DeserializeObject<Person>(serilization);
            Console.WriteLine("*****Deserialize***********");
            Console.WriteLine($"{desetilization.Id} - {desetilization.FullName} - {desetilization.Age} \n" +
                              $"Дети: {desetilization.childrens.Id} - {desetilization.childrens.FullName} -{desetilization.childrens.Age}" );
            Console.WriteLine();
            

            Console.ReadKey();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Children childrens { get; set; }

    }

    class Children
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
    }

    

}
