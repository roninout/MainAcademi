using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number: ");
            double numb1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            double numb2 = Double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"Select the arithmetic operation:
            1. Multiplication
            2. Divide 
            3. Addition 
            4. Subtraction
            5. Exponentiation ");
            Console.ResetColor();

            Calculator(numb1, numb2, int.Parse(Console.ReadLine()));

            Console.ReadKey();
        }

        #region calculator
        // Implement option input (1,2,3,4,5)
        //     and input of  two or one numbers
        //  Perform calculations and output the result
        static void Calculator(double n1, double n2, int op)
        {
            string descr = "";
            double result = 0.0;

            Console.ForegroundColor = ConsoleColor.Green;

            switch (op)
            {
                case 1:
                    descr = "Multiplication";
                    result = n1 * n2; 
                    break;
                case 2:
                    descr = "Divide";
                    result = n1 / n2;
                    break;
                case 3:
                    descr = "Addition";
                    result = n1 + n2;
                    break;
                case 4:
                    descr = "Subtraction";
                    result = n1 - n2;
                    break;
                case 5:
                    descr = "Exponentiation";
                    result = Math.Pow(n1, n2);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    descr = "Something went wrong!!!";
                    break;
            }

            Console.WriteLine($"{descr} - result: {result}");
        }
        #endregion
    }
}
