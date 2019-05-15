using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // covariant
            IEnumerable<string> strings = new List<string>();
            IEnumerable<object> objects = strings;

            // contrvariant
            IEqualityComparer<BaseClass> baseObj = new BaseComparer();
            IEqualityComparer<DeriverClass> derObj = baseObj;

            Console.ReadKey();

        }
    }

    class BaseClass { }
    class DeriverClass : BaseClass { }
    class BaseComparer : IEqualityComparer<BaseClass>
    {
        public bool Equals(BaseClass x, BaseClass y)
        {
            return x == y;
        }

        public int GetHashCode(BaseClass obj)
        {
            return obj.GetHashCode();
        }
    }

}
