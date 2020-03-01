using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGenericType_10
{
    class Program
    {
        static void Main(string[] args)
        {

            var person1 = new Person<int>() { Id = 1, FullName = "Иванов Иван Иванович" };

            var ListPerson = new HashSet<Person<int>>();

            AddOrThrow(ListPerson, person1);
            AddOrThrow(ListPerson, person1);
            Console.ReadKey();
        }

        public static void AddOrThrow<T>(HashSet<T> hash, T item)
        {
            if (!hash.Add(item))
                throw new ValueExistingException();
        }


        class Person<T>
        {

            public T Id { get; set; } 
            public string FullName { get; set; }
        }

        [Serializable]
        private class ValueExistingException : Exception
        {
            public ValueExistingException()
            {
            }

            public ValueExistingException(string message) : base(message)
            {
            }

            public ValueExistingException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ValueExistingException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
