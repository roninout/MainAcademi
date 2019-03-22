using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            int[,] arr1 = {{ 1, 2, 3 }, { 4, 5, 6 }};
            int[,] arr2 = {{ 1, 2, 3 }, { 4, 5, 6 }};

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    if (arr1[i, j] != arr2[i, j])
                        flag = false;
                }
            }
            Console.WriteLine(flag);
            Console.ReadKey();
        }
    }
}
