using AirlineInfo.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    class Passenger
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public Sex Sex { get; set; }
        public FlyClass FlyClass { get; set; }
        public string FlightNumber { get; set; }
        public string Price { get; set; }
        public string ArrivalPort { get; set; }
        public string DeparturePort { get; set; }

        protected static Random random = new Random();

        public Passenger()
        {
            Sex = (Sex)random.Next(Enum.GetNames(typeof(Sex)).Length);
            if (Sex == Sex.Male)
            {
                FirstName = Data.firstNameMale[random.Next(Data.firstNameMale.Count)];
                SecondName = Data.secondNameMale[random.Next(Data.secondNameMale.Count)];
            }
            else
            {
                FirstName = Data.firstNameFemale[random.Next(Data.firstNameFemale.Count)];
                SecondName = Data.secondNameFemale[random.Next(Data.secondNameFemale.Count)];
            }
            Nationality = Data.nationality[random.Next(Data.nationality.Count)];
            Passport = Data.passportId[random.Next(Data.passportId.Count)];
            DateOfBirthday = Data.RandomDayFunc(random)();
            FlyClass = (FlyClass)random.Next(Enum.GetNames(typeof(FlyClass)).Length);
            FlightNumber = Flights.FlightCreator.ArrivalFlights[0]. Data.flightNumber[random.Next(Data.flightNumber.Count)];
            ArrivalPort = GetTicket().ArrivalFlight.CityPort;
            DeparturePort = GetTicket().DepartureFlight.CityPort;
            Price = GetTicket().Price.ToString();
        }

        // отображение
        public void Show()
        {
            int linesize = (int)Columns.colNumb + (int)Columns.colFirstName + (int)Columns.colSecondName + (int)Columns.colSex + 10;
            int headerTable = 33;

            Console.SetCursorPosition(linesize, 0);
            Console.WriteLine(new string('-', headerTable));
            Console.ForegroundColor = Sex == Sex.Male ? ConsoleColor.Blue : ConsoleColor.Magenta;

            Console.SetCursorPosition(linesize, 1);
            Console.WriteLine($"|Sex:            {Sex}".PadRight(headerTable - 1, ' ') + "|");
            Console.ResetColor();

            Console.SetCursorPosition(linesize, 2);
            Console.WriteLine(new string('-', headerTable));

            Console.SetCursorPosition(linesize, 3);
            Console.WriteLine($"|First Name:     {FirstName}".PadRight(headerTable - 1, ' ') + "|");

            Console.SetCursorPosition(linesize, 4);
            Console.WriteLine($"|Second Name:    {SecondName}".PadRight(headerTable - 1, ' ') + "|");

            Console.SetCursorPosition(linesize, 5);
            Console.WriteLine($"|Nationality:    {Nationality}".PadRight(headerTable - 1, ' ') + "|");

            Console.SetCursorPosition(linesize, 6);
            Console.WriteLine($"|Passport:       {Passport}".PadRight(headerTable - 1, ' ') + "|");

            Console.SetCursorPosition(linesize, 7);
            Console.WriteLine($"|DateOfBirthday: {DateOfBirthday:d}".PadRight(headerTable - 1, ' ') + "|");

            Console.SetCursorPosition(linesize, 8);
            Console.WriteLine($"|FlightNumber:   {FlightNumber}".PadRight(headerTable - 1, ' ') + "|");

            Console.SetCursorPosition(linesize, 9);
            Console.WriteLine($"|FlyClass:       {FlyClass}".PadRight(headerTable - 1, ' ') + "|");

            Console.SetCursorPosition(linesize, 10);
            Console.WriteLine(new string('-', headerTable));
        }

        // отображаем имена всех пользователей
        public void ShowPassengersNames(int count, int select)
        {
            if (count == select)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write(
                $"{count.ToString().PadRight((int)Columns.colNumb, ' ')}" +
                $"{FirstName.PadRight((int)Columns.colFirstName, ' ')}" +
                $"{SecondName.PadRight((int)Columns.colSecondName, ' ')}"
                );
            Console.ForegroundColor = Sex == Sex.Male ? ConsoleColor.Blue : ConsoleColor.Magenta;
            Console.Write($"{Sex.ToString().PadRight((int)Columns.colSex, ' ')}");
            Console.ResetColor();
            Console.WriteLine("|");
        }

        private Ticket GetTicket()
        {
            var result = from ticket in TicketCreator.Tickets
                             where ticket.ArrivalFlight.FlightNumber == FlightNumber
                             select ticket;
            return result.First();
        }

    }

    enum Sex
    {
        Male,
        Female
    }

    enum FlyClass
    {
        Business,
        Economy
    }
}
