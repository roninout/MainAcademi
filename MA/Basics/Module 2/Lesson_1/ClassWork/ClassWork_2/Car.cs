using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_2
{
    class Car
    {
        public string color;

        public Car()
        {
        }

        public Car(string color)
        {
            this.color = color;
        }

        ~Car()
        {
            Console.WriteLine("Destroy car ...");
        }
    }
}
