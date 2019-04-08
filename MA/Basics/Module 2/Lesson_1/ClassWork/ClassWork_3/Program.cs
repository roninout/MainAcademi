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
            var intArr = new[] { 0, 1, 2 };
            var strArr = new[] { "Hello", "Array", null };
            var nullableIntArr = new[] { 0, (int?)1, 2};

            Console.WriteLine(intArr.GetType());
            Console.WriteLine(strArr.GetType());
            Console.WriteLine(nullableIntArr.GetType());

            Console.WriteLine(nullableIntArr.GetLength(0));
        }
    }
}
