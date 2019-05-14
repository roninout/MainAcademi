using AirlineInfo.Flights;
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
            var arrivalFlights = new FlightCreator(5).InitArrivalFlight();
            var departureFlights = new FlightCreator(10).InitDepartureFlight();
            var ticketCreator = new Tickets.TicketCreator(20);
            var passengerCreator = new PassengerCreator(10);

            string menuSelect = String.Empty;

            Table.DisplayMainMenu();
            while (menuSelect != "0")
            {
                menuSelect = Console.ReadLine().ToLower();

                switch (menuSelect)
                {
                    case "1":
                        Table.DisplayFlightsTable(arrivalFlights);
                        Table.DisplayMainMenu();
                        break;
                    case "2":
                        Table.DisplayFlightsTable(departureFlights);
                        Table.DisplayMainMenu();
                        break;
                    case "3":
                        Table.DisplayPassengerMenu(passengerCreator);
                        Console.Clear();
                        Table.DisplayMainMenu();
                        break;
                    case "4":
                        Table.DisplayEditTable(arrivalFlights);
                        Table.DisplayMainMenu();
                        break;
                    case "5":
                        Table.DisplayEditTable(departureFlights);
                        Table.DisplayMainMenu();
                        break;
                    case "6":
                        Table.DisplayTicketsMenu(ticketCreator);
                        Console.Clear();
                        Table.DisplayMainMenu();
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
