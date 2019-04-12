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
            StringMatrix stringMatrix1 = new StringMatrix(new string[,] { { "0", "1" }, { "3", "4" } });
            StringMatrix stringMatrix2 = new StringMatrix(new string[,] { { "a", "b" }, { "c", "d" } });

            StringMatrix matrix = stringMatrix1 + stringMatrix2;
            Console.WriteLine(matrix);

            stringMatrix1 += stringMatrix2;
            Console.WriteLine(stringMatrix1);

            Console.ReadKey(); 
        }
    }
}
