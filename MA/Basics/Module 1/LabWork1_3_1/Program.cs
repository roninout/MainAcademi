using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MyMax = 200;

            Random random = new Random();
            // random.Next(MaxValue) returns a 32-bit signed integer that is greater than or equal to 0 and less than MaxValue
            int Guess_number = random.Next(MyMax) + 1;
            // implement input of number and comparison result message in the while circle with  comparison condition



            // работа на зантии -------------------------------------------------------------------------------------------------

            //Console.WriteLine(7 % 3);

            //Console.WriteLine(-7 % 3);

            // объяснение отрицательного значения деления от остатка
            //int a = -7;
            //int b = 3;
            //Console.WriteLine(a - (a/b) *b);
            

            //int i = 0, j = 0;
            //i = i++;
            //Console.WriteLine(i);

            //i = 0;
            //j = 0;
            //i = ++i;
            //Console.WriteLine(i);

            //Console.WriteLine((int)0xFFFE);

            //for (int i = 0; i <= 5; i++)
			//{
            //    Console.WriteLine(i & 0xFFFE);
			//}

            //Console.WriteLine(short.MaxValue);

            //Console.WriteLine(ushort.MaxValue);


            System.Diagnostics.Stopwatch tm = new System.Diagnostics.Stopwatch();
            tm.Start();

            byte pow = 1 << 5;
            tm.Stop();

            Console.WriteLine($"Left-shift time = {tm.Elapsed.TotalMilliseconds}");

            tm.Reset();

            tm.Start();

            byte mathPow = (byte)Math.Pow(2, 5);
            tm.Stop();

            Console.WriteLine($"Math time = {tm.Elapsed.TotalMilliseconds}");

            // ------------------------------------------------------------------------------------------------------------------
            Console.ReadKey();
              
        }
    }
}
