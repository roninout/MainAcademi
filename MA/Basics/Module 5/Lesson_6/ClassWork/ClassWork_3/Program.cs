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
            string s = "Hello Extension Methods! String Extension.";
            int i = s.WordCount();

            Console.WriteLine($"Word count: {i}");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
