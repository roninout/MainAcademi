using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new UserCollection<int> { 1, 2, 3 };

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(collection.Contains(2));

            // Delay.
            Console.ReadKey();
        }
    }
}
