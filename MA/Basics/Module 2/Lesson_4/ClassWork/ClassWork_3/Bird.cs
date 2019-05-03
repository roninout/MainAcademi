using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_3
{
    class Bird : IBird
    {
        public Bird()
        {
            Genus = "bird";
        }

        public string Genus { get; private set; }

        public virtual void Voice()
        {
            Console.WriteLine("Bird is singing...");
        }
    }
}
