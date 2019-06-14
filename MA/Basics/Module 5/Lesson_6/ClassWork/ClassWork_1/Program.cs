using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleLinq();

            Console.ReadKey();
        }

        private static void SimpleLinq()
        {
            int[] numbers = new int[5] { 0, 1, 2, 3, 4 };

            var numQuery = from num in numbers
                           where (num % 2) == 0
                           select num;

            foreach (var num in numQuery)
            {
                Console.WriteLine("{0, 1}", num);
            }
        }
    }
}
