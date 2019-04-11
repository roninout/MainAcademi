using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Hello_fact_advstud
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define parameters to calculate the factorial of
            //Call fact() method to calculate
            Console.WriteLine(fact(20));
            Console.ReadKey();
        }

        //Create fact() method  with parameter to calculate factorial
        static BigInteger fact(int n)
        {
            //Use ternary operator
            return (n <= 1) ? 1 : n * fact(n - 1);
        }
        

    }



}
