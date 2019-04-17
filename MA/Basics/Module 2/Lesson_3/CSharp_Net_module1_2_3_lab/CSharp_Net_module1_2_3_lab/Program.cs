using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            Money money1 = new Money(10 , CurrencyTypes.EU);
            Money money2 = new Money(308, CurrencyTypes.EU);

            // 11) do operations
            // add 2 objects of Money
            Console.WriteLine($"add 2 objects of Money: ");
            Console.WriteLine($"money1 {money1.Amount} + money2 {money2.Amount} = {(money1 + money2).Amount}");
            Console.WriteLine();

            // add 1st object of Money and double
            Console.WriteLine($"add 1st object of Money and double:");
            double dValue = 5.67;
            Console.WriteLine($"money1 {money1.Amount} + double {dValue} = {(money1 + dValue).Amount}");
            Console.WriteLine();

            // decrease 2nd object of Money by 1
            Console.WriteLine($"decrease 2nd object of Money by 1:");
            Console.WriteLine($"money2 {money2.Amount} = {(--money2).Amount}");
            Console.WriteLine();

            // increase 1st object of Money
            Console.WriteLine($"increase 1st object of Money:");
            Console.WriteLine($"money1 {money1.Amount} * money2 {money2.Amount} = {(money1 * money2).Amount}");
            Console.WriteLine();

            // compare 2 objects of Money
            Console.WriteLine($"compare 2 objects of Money:");
            Console.WriteLine($"money1 {money1.Amount} > money2 {money2.Amount} = {money1 > money2}");
            Console.WriteLine($"money1 {money1.Amount} < money2 {money2.Amount} = {money1 < money2}");
            Console.WriteLine();

            // compare 2nd object of Money and string
            Console.WriteLine($"increase 1st object of Money:");
            string sValue = "48";
            Console.WriteLine($"money2 {money2.Amount} > strValue {sValue} ? {money2 > sValue} ");
            Console.WriteLine($"money2 {money2.Amount} < strValue {sValue} ? {money2 < sValue} ");
            Console.WriteLine();

            // check CurrencyType of every object
            Console.WriteLine($"check CurrencyType of every object:");
            Console.WriteLine(money1 ? "true" : "false");
            Console.WriteLine(money2 ? "true" : "false");
            Console.WriteLine();

            // convert 1st object of Money to string
            Console.WriteLine($"convert 1st object of Money to string:");
            Console.WriteLine($"money1 {(string)money1}");
            Console.WriteLine();

            Console.ReadKey();

        }
    }
}
