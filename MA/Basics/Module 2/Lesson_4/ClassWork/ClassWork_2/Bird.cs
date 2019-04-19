using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_2
{
    public class Bird
    {

        public string Genus { get; private set; }

        public Bird()
        {
            Genus = "bird";
        }

        public Bird(string genus)
        {
            Genus = genus;
        }

        public void Fly() { }
        public virtual void Voice()
        {
            Console.WriteLine("Bird is  signed...");
        }

    }

    class Duck : Bird
    {
        public Duck(string genus) : base(genus)
        {

        }

        public void Swim() { }

        public override void Voice()
        {
            //base.Voice();
            Console.WriteLine("Duck says krya-krya");
        }


    }

    public class Chicken : Bird
    {
        public override void Voice()
        {
            Console.WriteLine("Chicken says ko-ko");
        }
    }
}
