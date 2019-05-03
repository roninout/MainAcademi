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
            var str_a = Console.ReadLine();

            try
            {
                int b = (int)uint.Parse(str_a);
            }
            catch (FormatException)
            {

                Console.WriteLine("You entered incorrect name {0}", str_a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
