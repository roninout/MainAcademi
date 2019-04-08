using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
           Car car = new Car("Red");
            car = null;
            //Console.WriteLine(car.color);
            Car car2 = new Car("Blue");
            Console.WriteLine(car2.color);
        }
    }
}
