using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEquivalence_8
{
    class Program
    {

        class Person
        {
            public  string FullName { get; set; }
            public DateTime? BirthDate { get; set; }
            public string PlaceOfBirth { get; set; }
            public string PassportId { get; set; }


            public override bool Equals(object obj)
            {

                if (obj == null){return false;}
                if (!(obj is Person)){return false;}

                var person = (Person)obj;
                if (person.FullName!= FullName)
                {
                    return false;
                }

                if (BirthDate != null && person.BirthDate!=BirthDate.Value)
                {
                    return false;
                }

                if (person.PlaceOfBirth!=PlaceOfBirth)
                {
                    return false;
                }

                if (person.PassportId!= PassportId)
                {
                    return false;
                }

                return true; ;
            }

            public  int GetHashCode(object obj)
            {
                if (obj == null){return 0;}if (!(obj is Person)){return 0;}

                var person = (Person) obj;
                if (person.FullName.Contains("Масляков"))
                {
                    return 777;
                }

                
                return base.GetHashCode();
            }
        }

        static void Main(string[] args)
        {
            Person person1= new Person(){FullName = "Якубович Леонид Аркадьевич",BirthDate = new  DateTime(year:1954, month:02,day:05),PlaceOfBirth = "Москва",PassportId="44555445455"};
            Person person2 = new Person() { FullName = "Якубович Леонид Аркадьевич", BirthDate = new DateTime(year: 1954, month: 02, day: 05), PlaceOfBirth = "Москва", PassportId = "44555445455" };
            Person person3 = new Person() { FullName = "Масляков Александр Васильевич", /*BirthDate = new DateTime(year: 1940, month: 02, day: 05),*/ PlaceOfBirth = "Москва", PassportId = "123456789" };

            Console.WriteLine(person1.Equals(person2));
            Console.WriteLine(person1.Equals(person3));

            Console.WriteLine(person1.GetHashCode());
            Console.WriteLine(person1.GetHashCode(person3));
            Console.ReadKey();

        }
    }
}
