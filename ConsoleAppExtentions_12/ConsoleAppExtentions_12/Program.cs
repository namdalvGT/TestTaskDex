using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExtentions_12
{
    class Program
    {
        static void Main(string[] args)
        {
            var second = 10;
            var timespan = second.SecondCount();
            Console.WriteLine(timespan);
            Console.ReadKey();

        }
    }

    public static class IntExtensions
    {
        public static TimeSpan SecondCount(this int count)
        {
            
            return TimeSpan.FromSeconds(count);
        }
    }
}

