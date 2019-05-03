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
            try
            {
                do
                {
                    Console.WriteLine(@"Please, type the number:
                                        1. ToMorse");
                    var str_a = Console.ReadLine();
                    try
                    {
                        var a = (int)uint.Parse(str_a);
                        switch (a)
                        {
                            case 1:
                                Console.WriteLine();
                                break;
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Your entered incorrect number {str_a}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Press Spacebar to exit");
                } while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey(); 
        }
    }
}
