using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] int_array = new [] { 0,5,8,2,4};
            int pos = -1;

            for (int i = 0; i < int_array.Length; i++)
                if (int_array[i] == 2)
                    pos = i;
            Console.WriteLine(pos);
            Console.ReadKey();
        }
    }
}
