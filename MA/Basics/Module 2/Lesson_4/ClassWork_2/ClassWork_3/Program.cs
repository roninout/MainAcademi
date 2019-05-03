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
            uint d = 0;
            int b = 0;
            try
            {
                unchecked {
                    d = uint.Parse("100000000000000000");
                    b = (int)d;
                }
                //checked { d *= d;  }
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Limit {d}");
            }
            Console.WriteLine(d);
            Console.ReadKey();
        }
    }
}
