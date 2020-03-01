using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppIComparable_7
{

        public class Figure: IComparable<Figure>
        {
            public string Area { get; set; }

            public int CompareTo(Figure p) => string.Compare("20",p.Area, StringComparison.Ordinal);
        };

        class Triangle : Figure
        {
            double sideA, sideB, sideC;   // Стороны треугольника

            // Конструктор
            public Triangle(double triangleSideA, double triangleSideB, double triangleSideC)
            {
                SideA = triangleSideA;
                SideB = triangleSideB;
                SideC = triangleSideC;
                AreaMethod();
            }

            // Свойство, проверяем значение на отрицательность.
            // Если значение отрицательное меняем его на аналогичное положительное.
            public double SideA
            {
                get { return sideA; }
                set { sideA = value < 0 ? -value : value; }
            }

            public double SideB
            {
                get { return sideB; }
                set { sideB = value < 0 ? -value : value; }
            }

            public double SideC
            {
                get { return sideC; }
                set { sideC = value < 0 ? -value : value; }
            }

            // Метод для вычисления площади треугольника
            public  void AreaMethod()
            {
                double semPer = (sideA + sideB + sideC) / 2;
                this.Area= Math.Sqrt(semPer * (semPer - sideA) * (semPer - sideB) * (semPer - sideC)).ToString();
            }

           
    }

        class Square : Figure
        {
            double side;   // Сторона квадрата

            // Конструктор
            public Square(double squareSide)
            {
                Side = squareSide;
                AreaMethod();
            }

            // Свойство, проверяем значение на отрицательность.
            public double Side
            {
                get { return side; }
                set { side = value < 0 ? -value : value; }
            }

            // Метод для вычисления площади квадрата
            public  void AreaMethod()
            {
                this.Area= (side * side).ToString();
            }
        }

        class Circle : Figure
        {
            double side;
            
            // Конструктор
            public Circle(double sideCircle)
            {
                Side = sideCircle;
                AreaMethod();
            }

            // Свойство, проверяем значение на отрицательность.
            public double Side
            {
                get { return side; }
                set { side = value < 0 ? -value : value; }
            }

            // Метод для вычисления площади круга
            public void AreaMethod()
            {
                this.Area=(3.1415 * side *2).ToString();
            }
        }

        class Program
        {
            static void Main()
            {
                Int32 i = 20;
                Figure figure1 = new Triangle(4,5,6);
                var result1 = figure1.CompareTo(figure1);
                Console.WriteLine($"Площадь треугольника:{figure1.Area}  Результат: {result1}");
                Figure figure2 = new Square(5);
                var result2 = figure1.CompareTo(figure2);
                Console.WriteLine($"Площадь квадрата:{figure2.Area}  Результат: {result2}");
                Figure figure3 = new Circle(2);
                var result3 = figure1.CompareTo(figure3);
                Console.WriteLine($"Площадь круга:{figure3.Area}  Результат: {result3}");

                var list = new List<Figure>();
                for (int j = 0; j < 3; j++)
                {

                    list.Add(new Triangle(j+1, 5, 6));
                    list.Add(new Circle(j+10));
                    list.Add(new Square(j+2));
                    list.Add(new Triangle(4, j+2, 4));

                }

                Console.WriteLine("*****Сортировка по убыванию****");
                var sorted = list.ToArray().OrderByDescending(x => Convert.ToDecimal(x.Area));
                foreach (var selected in sorted)
                {
                    Console.WriteLine($"{selected.Area}");
                }
                Console.ReadKey();

                
            }
        }


}
