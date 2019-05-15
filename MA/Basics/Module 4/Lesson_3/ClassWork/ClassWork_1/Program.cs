using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_1
{
    class Program
    {
        public delegate T SampleGenericDelegate<out T>(); //cov
        static void Main(string[] args)
        {
            SampleGenericDelegate<string> dString = () => " ";
            SampleGenericDelegate<object> dObject = dString;

            Action<int, object> aDel1 = (a, str) => Console.WriteLine(str.ToString() + a);

            Action<int, string> aDel2 = aDel1;

            Func<int, string> fDel1 = (a) => { return Convert.ToString(a); };
            Func<int, object> fDel2 = fDel1;
        }
    }
}
