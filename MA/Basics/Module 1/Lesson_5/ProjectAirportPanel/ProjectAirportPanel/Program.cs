using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirportPanel
{
    class Program
    {
        static void Main(string[] args)
        {
            Flight[] arrivalflights = CreateArrivalFlights();
            Flight[] departureflights = CreateDepartureFlights();

            string menuSelect = String.Empty;

            while (menuSelect != "exit")
            {
                menuSelect = Console.ReadLine().ToLower();

                switch (menuSelect)
                {
                    case "1":
                        DisplayTable(TableStatus.Arrival, arrivalflights);
                        break;
                    case "2":
                        DisplayTable(TableStatus.Departure, departureflights);
                        break;
                    default:
                        break;
                }
            }



            //Console.WriteLine("Hello World!");
            Console.ReadKey();
            

        }

        // создание рейсов ВЫЛЕТ-ов
        public static Flight[] CreateArrivalFlights()
        {
            Flight[] flights = new Flight[5];

            flights[0] = new Flight("KC 406",  new DateTime(2015, 7, 20), "Алматы", "Air Astana", "D", "D4", FlightStatus.Arrived);
            flights[1] = new Flight("PQ 7119", new DateTime(2015, 7, 20), "Шарм-Эль-Шейх", "Sky Up Airlines", "F", "F2", FlightStatus.Arrived);
            flights[2] = new Flight("LO 8312", new DateTime(2015, 7, 20), "Таллинн", "LOT Polish Airlines", "D", "D10", FlightStatus.Arrived);
            flights[3] = new Flight("PS 5673", new DateTime(2015, 7, 20), "Шарм-Эль-Шейх", "Ukraine International Airlines", "D", "D11", FlightStatus.Arrived);
            flights[4] = new Flight("LH 2545", new DateTime(2015, 7, 20), "Мюнхен", "Lufthansa", "D", "D8", FlightStatus.Arrived);

            return flights;
        }

        // создание рейсов ПРИЛЁТ-ов
        public static Flight[] CreateDepartureFlights()
        {
            Flight[] flights = new Flight[5];
            flights[0] = new Flight("LH 2544", new DateTime(2015, 7, 20), "Мюнхен", "Lufthansa", "D", "", FlightStatus.Canceled);
            flights[1] = new Flight("QU 4440", new DateTime(2015, 7, 20), "Шарм-Эль-Шейх", "Azur Air Ukraine", "F", "", FlightStatus.ChekIn);
            flights[2] = new Flight("PS 354", new DateTime(2015, 7, 20), "Афины", "Ukraine International Airlines", "D", "", FlightStatus.Delayed);
            flights[3] = new Flight("LH 1494", new DateTime(2015, 7, 20), "Франкфурт", "Lufthansa", "D", "", FlightStatus.DepartedAt);
            flights[4] = new Flight("PS 472", new DateTime(2015, 7, 20), "Цюрих", "Ukraine International Airlines", "D", "", FlightStatus.ExpectedAt);

            return flights;
        }

        // отображаем таблицу выбранного типа
        public static void DisplayTable(TableStatus tableStatus, Flight[] flight)
        {
            switch (tableStatus)
            {
                case TableStatus.Arrival:
                    DisplayArrivalTable(flight);
                    break;
                case TableStatus.ArrivalEdit:
                    break;
                case TableStatus.Departure:
                    DisplayDepartureTable(flight);
                    break;
                case TableStatus.DepartureEdit:
                    break;
                default:
                    break;
            }
        }

        // отображение табло ВЫЛЕТ-ов
        public static void DisplayArrivalTable(Flight[] flight)
        {
            Console.WriteLine("Рейс     Время       Назначение      Перевозчик      Терминал        Гейт        Статус");
            foreach (var item in flight)
            {
                Console.WriteLine($"{item.flightNumber}     {item.dateTime}       {item.cityPort}      {item.airline}      {item.terminal}        {item.gate}        {item.flightStatus}");
            }            
        }

        // отображение табло ПРИЛЁТ-ов
        public static void DisplayDepartureTable(Flight[] flight)
        {
            Console.WriteLine("Рейс     Время       Назначение      Перевозчик      Терминал        Статус");
            foreach (var item in flight)
            {
                Console.WriteLine($"{item.flightNumber}     {item.dateTime}       {item.cityPort}      {item.airline}      {item.terminal}        {item.flightStatus}");
            }
        }
    }
}
