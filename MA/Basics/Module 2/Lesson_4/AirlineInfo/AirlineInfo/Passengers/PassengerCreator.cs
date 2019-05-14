using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    class PassengerCreator
    {
        public static List<Passenger> Passengers;
        public static int MaxPassengers { get; set; } = 0;

        public PassengerCreator(int maxPassengers)
        {
            MaxPassengers = maxPassengers;
            InitPassengers();
            //Tickets.TicketCreator.AddPassengersToTickets();
        }

        // наполняем List пользователями
        private List<Passenger> InitPassengers()
        {
            Passengers = new List<Passenger>(MaxPassengers);
            for (int i = 0; i < MaxPassengers; i++)
                Passengers.Add(new Passenger());
            return Passengers;
        }

        // поиск пассажира
        public int FindPassenger()
        {
            int linesize = (int)Columns.colNumb + (int)Columns.colFirstName + (int)Columns.colSecondName + (int)Columns.colSex + 27;
            Passenger passenger = null;
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(linesize - 17, 12);
            Console.WriteLine($"Поиск пассажира:");
            Console.ResetColor();
            Console.SetCursorPosition(linesize - 17, 13);
            Console.WriteLine($"1 - имя:");
            Console.SetCursorPosition(linesize - 17, 14);
            Console.WriteLine($"2 - фамилия:");
            Console.SetCursorPosition(linesize - 17, 15);
            Console.WriteLine($"3 - номер рейса:");
            Console.SetCursorPosition(linesize - 17, 16);
            Console.WriteLine($"4 - по цене:");
            Console.SetCursorPosition(linesize - 17, 17);
            Console.WriteLine($"5 - паспорт:");
            Console.SetCursorPosition(linesize - 17, 18);
            Console.WriteLine($"6 - arrival port:");
            Console.SetCursorPosition(linesize - 17, 19);
            Console.WriteLine($"7 - departure port:");
            Console.SetCursorPosition(linesize - 17, 21);
            string select = Console.ReadLine();
            Console.SetCursorPosition(linesize - 17, 22);
            Console.WriteLine($"Введите запрос: ");
            Console.SetCursorPosition(linesize - 17, 23);
            string param = Console.ReadLine();

            switch (select)
            {
                case "1":
                    passenger = GetPassenger(param, FindTypes.FirstName);
                    break;
                case "2":
                    passenger = GetPassenger(param, FindTypes.SecondName);
                    break;
                case "3":
                    passenger = GetPassenger(param, FindTypes.FlightNumber);
                    break;
                case "4":
                    passenger = GetPassenger(param, FindTypes.Price);
                    break;
                case "5":
                    passenger = GetPassenger(param, FindTypes.Passport);
                    break;
                case "6":
                    passenger = GetPassenger(param, FindTypes.ArrivalPort);
                    break;
                case "7":
                    passenger = GetPassenger(param, FindTypes.DeparturePort);
                    break;
                default:
                    break;
            }
            return Passengers.IndexOf(passenger);
        }

        // добавление пассажира
        public void AddPassenger()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Создать нового пассажира?");
            Console.ResetColor();
            Console.WriteLine("Нажмите ENTER для создания");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
                Passengers.Add(new Passenger());
        }

        // редактирование пассажира
        public void EditPassenger(string index)
        {
            Passenger passenger = GetPassenger(index);
            int linesize = (int)Columns.colNumb + (int)Columns.colFirstName + (int)Columns.colSecondName + (int)Columns.colSex + 27;
            int fieldsCount = 7;
            string[] fields = new string[fieldsCount];

            for (int i = 0; i < fieldsCount; i++)
            {
                Console.SetCursorPosition(linesize, i + 3);
                Console.ForegroundColor = ConsoleColor.Red;
                fields[i] = Console.ReadLine();
                Console.ResetColor();
            }

            Console.SetCursorPosition(linesize - 17, fieldsCount + 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Нажмите ENTER для сохранения");
            Console.ResetColor();
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                try
                {
                    passenger.FirstName = fields[0];
                    passenger.SecondName = fields[1];
                    passenger.Nationality = fields[2];
                    passenger.Passport = fields[3];
                    passenger.DateOfBirthday = DateTime.Parse(fields[4]);
                    passenger.FlightNumber = fields[5];
                    passenger.FlyClass = (FlyClass)int.Parse(fields[6]);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(linesize - 17, fieldsCount + 7);
                    Console.WriteLine("Были введены некорректные данные");
                    Console.SetCursorPosition(linesize - 17, fieldsCount + 8);
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        // удаление пассажира
        public void DelPassenger(string index)
        {
            Passenger passenger = GetPassenger(index);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Вы действительно хотите удалить пассажира: {passenger.FirstName} {passenger.SecondName}?");
            Console.ResetColor();
            Console.WriteLine("Нажмите ENTER для");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
                Passengers.Remove(passenger);
        }

        #region Find passenger
        public Passenger GetPassenger(string param, FindTypes findTypes = FindTypes.Index)
        {
            try
            {
                switch (findTypes)
                {
                    case FindTypes.Index:
                        return Passengers[int.Parse(param) - 1];
                    case FindTypes.FirstName:
                        var firstName = from passenger in Passengers
                                        where passenger.FirstName.ToLower() == param.ToLower()
                                        select passenger;
                        return firstName.First();
                    case FindTypes.SecondName:
                        var secondName = from passenger in Passengers
                                         where passenger.SecondName.ToLower() == param.ToLower()
                                         select passenger;
                        return secondName.First();
                    case FindTypes.FlightNumber:
                        var flightNumber = from passenger in Passengers
                                           where passenger.FlightNumber.ToLower() == param.ToLower()
                                           select passenger;
                        return flightNumber.First();
                    case FindTypes.Price:
                        var price = from passenger in Passengers
                                    where passenger.Price.ToLower() == param.ToLower()
                                    select passenger;
                        return price.First();
                    case FindTypes.Passport:
                        var passport = from passenger in Passengers
                                       where passenger.Passport.ToLower() == param.ToLower()
                                       select passenger;
                        return passport.First();
                    case FindTypes.ArrivalPort:
                        var arrivalPort = from passenger in Passengers
                                          where passenger.ArrivalPort.ToLower() == param.ToLower()
                                          select passenger;
                        return arrivalPort.First();
                    case FindTypes.DeparturePort:
                        var departurePort = from passenger in Passengers
                                            where passenger.DeparturePort.ToLower() == param.ToLower()
                                            select passenger;
                        return departurePort.First();
                    default:
                        return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
