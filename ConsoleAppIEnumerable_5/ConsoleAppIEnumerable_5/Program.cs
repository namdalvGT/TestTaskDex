using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppIEnumerable_5
{
    class Program
    {
        public class Cars 
        {
            Car [] cars = new Car[2]
            {
                new Car {Name = "Легковая"},
                new Car(){Name = "Грузовая"}, 
            };
            public IEnumerator<Car> GetEnumerator()
            {
                return new CarsEnumerator(cars);
            }

        }

        class CarsEnumerator : IEnumerator<Car>
        {
            Car [] cars;
            int position = -1;

            public CarsEnumerator(Car[] cars)
            {
                this.cars = cars;
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (position < cars.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                position = -1;
            }

            public Car Current
            {
                get
                {
                    if (position == -1 || position >= cars.Length)
                        throw new InvalidOperationException();
                    return cars[position];
                }

            }

            object IEnumerator.Current => Current;
        }

        public class Car
        {
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("********Foreach*******");
            Cars cars = new Cars();
            foreach (var car in cars)
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("********While*******");
            var cars2 = new Cars().GetEnumerator();
            while (cars2.MoveNext())
            {
                Car car = cars2.Current;
                if (car != null) Console.WriteLine(car.Name);
            }

            Console.Read();
        }





    }
}
