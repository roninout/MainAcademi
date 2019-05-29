using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 6;

            int val = 44;

            int[] a = new int[5];

            try

            {

                a[index] = val;

            }

            catch (IndexOutOfRangeException e)

            {

                Console.Write("Index out of bounds ");

            }

            Console.Write("Remaining program");

        }

    }
}
