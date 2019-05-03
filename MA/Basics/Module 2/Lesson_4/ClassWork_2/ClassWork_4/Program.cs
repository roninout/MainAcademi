using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ClassWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NonCls.NonCls();
            }
            catch (RuntimeWrappedException)
            {
                Console.WriteLine("NON CLS");
            }
            catch (Exception)
            {
                Console.WriteLine("CLS");
            }
            Console.ReadKey();
        }
    }
}
