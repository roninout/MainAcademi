using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_2
{
    class Program
    {
        struct Flight
        {
            public string city;
            public string flight_number;
            public char trminal;
            
            public void Show()
            {
                Console.WriteLine($"{flight_number + "   | "    }{  "    " + city + "    " }{ "    " + trminal + "    "}");
            }
        }

        enum city { kyiv , yokyo , hoho, jo ,go}
        enum flight_number   {  A , c ,d ,}
        enum trminal { C, B ,A}

        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Random random = new Random();
                Flight[] flight = new Flight[3];

                    for (int k = 0; k < flight.Length; k++)
                    {
                        int City = random.Next(1, 4);

                        flight[k].city = Convert.ToString((city)City);
                        int Flight_number = random.Next(0, 5);
                        flight[k].flight_number = Convert.ToString((flight_number)Flight_number);
                        int trm = random.Next(1, 4);
                        flight[k].trminal = Convert.ToChar((trminal)trm);
                        //Console.WriteLine($"{flight[k].flight_number + "   | "    }{  "    " + flight[k].city + "    " }{ "    " + flight[k].trminal + "    "}");
                        flight[k].Show();
                    }

      
                Console.WriteLine("{ 0 }" + "|" + "{ 1 }" + "|" + "{ 2 }");
                int choose = int.Parse(Console.ReadLine()); // 0


                ShowEditInfo(flight[choose]);
            }

            public static void ShowEditInfo(Flight flight)
            {
                    Console.WriteLine("Выберите действие");
                    Console.WriteLine("0. Назад");
                    Console.WriteLine("1. Город");
                    Console.WriteLine("2. Номер");
                    Console.WriteLine("3. Терминал");

                    //flight[choose].trminal;
                    int choose2 = int.Parse(Console.ReadLine());

                    switch (choose2)
                    {
                        case 0:
                            flight.Show();
                            break;
                        case 1:
                            break;
                        case 2:
                            Console.Write($"Измените город (старое название: { flight[choose2].city}) на : ");
                            flight[choose2].city = Console.ReadLine();
                            Console.WriteLine($"Новое название города: { flight[choose2].city}.\nДля продолжения нажмите...");
                            Console.ReadKey();
                    
                        break;
                        case 3:
                            break;
                    }

                flight.Show();
            }
        }


    }
}
