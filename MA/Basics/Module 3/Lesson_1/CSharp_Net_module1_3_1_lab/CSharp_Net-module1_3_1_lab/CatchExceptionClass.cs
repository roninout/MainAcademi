using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_3_1_lab
{
    class CatchExceptionClass
    {
        public void CatchExceptionMethod()
        {
            try
            {
                MyArray ma = new MyArray();

                // 3) replace second elevent of array by 0

                int[] arr = new int[4] { 1, 4, 8, 5 };
                ma.Assign(arr, 4);

            }

            // 8) catch all other exceptions here
            catch (Exception ex)
            {
                // 9) print System.Exception properties:
                // HelpLink, Message, Source, StackTrace, TargetSite
                Console.WriteLine("Exception: " + ex.GetType().FullName);
                Console.WriteLine("HelpLink: " + ex.HelpLink);
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Source: " + ex.Source);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("TargetSite: " + ex.TargetSite);

            }
            // 10) add finally block, print some message
            // explain features of block finally
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}
