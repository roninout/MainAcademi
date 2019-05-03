using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_5
{
    class Bird : ICloneable
    {
        public Bird(string genus)
        {
            Genus = genus;
        }

        public string Genus { get; private set; }

        public object Clone()
        {
            return new Bird(Genus);
        }

        void dfdfdf( int s, string str = "sdsd")
        { }
    }
}
