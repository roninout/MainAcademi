using AirlineInfo.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo.Tickets
{
    class Ticket
    {
        public Passenger Passenger { get; set; }
        public Flight ArrivalFlight { get; set; }
        public Flight DepartureFlight { get; set; }
        public decimal Price { get; set; }
        public FlyClass FlyClass { get; set; }

        protected static Random random = new Random();

        #region Constructor
        public Ticket()
        {
            //Passenger = PassengerCreator.Passengers[random.Next(PassengerCreator.Passengers.Count)];

            ArrivalFlight = FlightCreator.ArrivalFlights[random.Next(FlightCreator.ArrivalFlights.Count)];
            DepartureFlight = FlightCreator.DepartureFlights[random.Next(FlightCreator.DepartureFlights.Count)];
            FlyClass = (FlyClass)random.Next(Enum.GetNames(typeof(FlyClass)).Length);
            Price = FlyClass == FlyClass.Economy ? random.Next(12, 85) : random.Next(90, 125);
        }
        #endregion

        // отображаем
        public void Show(int count, int select)
        {
            Console.Write(
                $"{count.ToString().PadRight((int)Columns.colNumb, ' ')}" +
                $"{Passenger.FirstName.PadRight((int)Columns.colFirstName, ' ')}" +
                $"{Passenger.SecondName.PadRight((int)Columns.colSecondName, ' ')}" +
                $"{ArrivalFlight.CityPort.PadRight((int)Columns.colCityPort, ' ')}" +
                $"{DepartureFlight.CityPort.PadRight((int)Columns.colCityPort, ' ')}");
            if (FlyClass == FlyClass.Business)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.Write($"{FlyClass.ToString().PadRight((int)Columns.colFlightStatus, ' ')}");
            Console.ResetColor();
            Console.WriteLine($"{Price.ToString("$ 0.00").PadRight((int)Columns.colPrice, ' ')}|");
        }

        // инициализация пассажирами в билетах
        public void InitTicketPassenger()
        {
            Passenger = PassengerCreator.Passengers[random.Next(PassengerCreator.Passengers.Count)];
        }
    }
}
