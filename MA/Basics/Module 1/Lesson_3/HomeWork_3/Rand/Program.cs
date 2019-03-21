using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rand
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MyMax = 5;
            int count = 1;

            Random random = new Random();
            Console.WriteLine("Угадайте число в диапазоне от 0 до 5!");

            Console.WriteLine("Сделайте свой выбор: ");
            int userNumber = Int32.Parse(Console.ReadLine());
            while (true)
            {
                // random.Next(MaxValue) returns a 32-bit signed integer that is greater than or equal to 0 and less than MaxValue
                int Guess_number = random.Next(MyMax) + 1;
                // implement input of number and comparison result message in the while circle with  comparison condition
                Console.WriteLine($"Количество попыток: {count}");
                Console.WriteLine($"My - {Guess_number}, your - {userNumber}. ");
                if (Guess_number == userNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Very nice");
                    Console.ResetColor();
                    Console.WriteLine("Любая кнопка для выхода....");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Maybe next time");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Может еще разок? Для выхода введи Exit");
                Console.ResetColor();

                string choise = Console.ReadLine();
                if (choise.ToUpper() == "EXIT") break;
                userNumber = Int32.Parse(choise);
                count++;
                Console.Clear();
            }
        }
    }
}
