using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] @array = new int[10]; //{ 3, 6, 2, 8, 1, 9, 34, 78, 159 };

            int temp = 0;
            Random random = new Random();

            for (int i = 0; i < @array.Length; i++)
                @array[i] = random.Next(100);

            //Array.Sort(@array);

            for (int i = 0; i < @array.Length; i++)
            {
                for (int j = 0; j < @array.Length - 1; j++)
                {
                    if (@array[j] > @array[j + 1])
                    {
                        temp = @array[j + 1];
                        @array[j + 1] = @array[j];
                        @array[j] = temp;
                    }
                }
            }

            foreach (var item in @array)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
