using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Data.maxArrivalFlight = 5;
            Data.maxDepartureFlight = 8;
            Data.InitArrivalFlight();
            Data.InitDepartureFlight();

            string menuSelect = String.Empty;

            while (menuSelect != "0")
            {
                Table.DisplayMainMenu();
                menuSelect = Console.ReadLine().ToLower();

                switch (menuSelect)
                {
                    case "1":
                        Table.DisplayFlightsTable(Data.arrivalFlights);
                        break;
                    case "2":
                        Table.DisplayFlightsTable(Data.departureFlights);
                        break;
                    case "3":
                        Table.DisplayEditTable(Data.arrivalFlights);
                        break;
                    case "4":
                        Table.DisplayEditTable(Data.departureFlights);
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
