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
            string genus = "Duck";
            //Duck duck = new Duck(genus);

            //duck.Fly();
            //duck.Swim();
            //duck.Voice();

            Bird bird = new Bird();
            bird.Voice();
            bird = new Duck(genus);
            bird.Voice();
            bird = new Chicken();
            bird.Voice();

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
