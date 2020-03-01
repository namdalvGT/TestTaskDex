using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClone_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************Глубокое***********************");
            School schcol = new School() { Name = "Школа №5",Type = "Средняя школа",director = new Director(){FullName = "Петрова Светлана Ивановна",Birthdate = new DateTime(1970,02,22)}};
            School schcol2 = new School();
            schcol2 = (School) schcol.Clone();
            schcol2.Name = "Школа №12";
            schcol2.director.FullName = "Мельник Любовь Семеновна";
            schcol2.director.Birthdate = new DateTime(1963, 07, 01);
            Console.Write($"Наименование: {schcol.Name},{schcol.Type} - Директор:{schcol.director.FullName} - {schcol.director.Birthdate.ToShortDateString()}\n");
            Console.Write($"Наименование: {schcol2.Name},{schcol2.Type} - Директор:{schcol2.director.FullName} - {schcol2.director.Birthdate.ToShortDateString()}\n");

            Console.WriteLine("***************Поверхностное***********************");
            School schco3 = new School() { Name = "Школа №5", Type = "Средняя школа", director = new Director() { FullName = "Петрова Светлана Ивановна", Birthdate = new DateTime(1970, 02, 22) } };
            School schcol4 = new School();
            schcol4 = (School)schco3.CloneMember();
            schcol4.Name = "Школа №12";
            schcol4.director.FullName = "Мельник Любовь Семеновна";
            schcol4.director.Birthdate = new DateTime(1963, 07, 01);
            Console.Write($"Наименование: {schco3.Name},{schco3.Type} - Директор:{schco3.director.FullName} - {schco3.director.Birthdate.ToShortDateString()}\n");
            Console.Write($"Наименование: {schcol4.Name},{schcol4.Type} - Директор:{schcol4.director.FullName} - {schcol4.director.Birthdate.ToShortDateString()}\n");


            Console.ReadKey();


        }
    }

    public interface ICloneable
    {
        object Clone();
    }

    class School : ICloneable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Director director { get; set; }

        public object Clone()
        {
            Director director = new Director();
            return  new  School {Name=this.Name,Type=this.Type,director = director};
        }


        public object CloneMember()
        {
            return this.MemberwiseClone();
        }

    }

    class Director
    {
        public string FullName { get; set; }//полное имя
        public DateTime Birthdate { get; set; }//дата рождения
    }


}
