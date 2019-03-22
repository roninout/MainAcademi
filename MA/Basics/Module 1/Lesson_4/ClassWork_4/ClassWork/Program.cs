using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] int_array = new int[5];

            int_array[0] = 1;
            int_array[1] = 2;
            int_array[2] = 3;
            // int_array[5] = 4; error

            foreach (var item in int_array)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
