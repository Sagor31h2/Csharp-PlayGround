using System;
using System.Collections.Generic;
using System.Linq;

namespace Lamda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);

            foreach (var num in evenNumbers)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
           

            List<Dog> dogs = new List<Dog>() {
         new Dog { Name = "Rex", Age = 4 },
         new Dog { Name = "Sean", Age = 0 },
         new Dog { Name = "Stacy", Age = 3 }
      };
            var newDogsList = dogs.Select(x => new { Age = x.Age, FirstLetter = x.Name[0] });
            foreach (var item in newDogsList)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }

        class Dog
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
