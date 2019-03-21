using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите значение вычисляемого факториала: ");
            Console.WriteLine($"Результат: { Factorial_calculation(int.Parse(Console.ReadLine()))}");
            Console.ReadKey();
        }

        #region Factorial
        // Implement input of the number
        // Implement input the for circle to calculate factorial of the number
        // Output the result
        static BigInteger Factorial_calculation(int n)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n; ++i)
                result *= i;
            return result;
        }
        #endregion
    }
}
