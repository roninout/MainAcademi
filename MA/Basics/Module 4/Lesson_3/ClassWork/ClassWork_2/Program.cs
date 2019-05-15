using System;
using System.Collections;
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
            ArrayList myArrayList = new ArrayList();

            myArrayList.Add(1);
            myArrayList.Add("Two");
            myArrayList.Add(3);
            myArrayList.Add(4.5f);

            var firstElement = (int)myArrayList[0];
            var secondElement = (string)myArrayList[1];
            var thirdElement = (int)myArrayList[2];
            var fourthElement = (float)myArrayList[3];

        }
    }
}
