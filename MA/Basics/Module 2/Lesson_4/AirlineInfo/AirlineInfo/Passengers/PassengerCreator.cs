using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    class PassengerCreator
    {
        public List<Passenger> Passengers;
        public int MaxPassengers { get; set; } = 0;

        public PassengerCreator(int maxPassengers)
        {
            this.MaxPassengers = maxPassengers;
            InitPassengers();
        }

        private List<Passenger> InitPassengers()
        {
            Passengers = new List<Passenger>(MaxPassengers);
            for (int i = 0; i < MaxPassengers; i++)
                Passengers.Add(new Passenger());
            return Passengers;
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
                                        where passenger.FirstName == param
                                        select passenger;
                        return firstName.First();
                    case FindTypes.SecondName:
                        var secondName = from passenger in Passengers
                                         where passenger.SecondName == param
                                         select passenger;
                        return secondName.First();
                    case FindTypes.FlightNumber:
                        var flightNumber = from passenger in Passengers
                                           where passenger.FlightNumber == param
                                           select passenger;
                        return flightNumber.First();
                    case FindTypes.Price:
                        var price = from passenger in Passengers
                                    where passenger.Price == param
                                    select passenger;
                        return price.First();
                    case FindTypes.Passport:
                        var passport = from passenger in Passengers
                                       where passenger.Passport == param
                                       select passenger;
                        return passport.First();
                    case FindTypes.ArrivalPort:
                        var arrivalPort = from passenger in Passengers
                                          where passenger.ArrivalPort == param
                                          select passenger;
                        return arrivalPort.First();
                    case FindTypes.DeparturePort:
                        var departurePort = from passenger in Passengers
                                            where passenger.DeparturePort == param
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

        public void SetPassenger(string param, FindTypes findTypes = FindTypes.Index)
        {
            Passenger passengerResult = null;
            try
            {
                switch (findTypes)
                {
                    case FindTypes.Index:
                        Passengers[int.Parse(param)] = null;
                        break;
                    case FindTypes.FirstName:
                        var firstName = from passenger in Passengers
                                        where passenger.FirstName == param
                                        select passenger;
                        passengerResult = firstName.First();
                        break;
                    case FindTypes.SecondName:
                        var secondName = from passenger in Passengers
                                         where passenger.SecondName == param
                                         select passenger;
                        passengerResult = secondName.First();
                        break;
                    case FindTypes.FlightNumber:
                        var flightNumber = from passenger in Passengers
                                           where passenger.FlightNumber == param
                                           select passenger;
                        passengerResult = flightNumber.First();
                        break;
                    case FindTypes.Price:
                        var price = from passenger in Passengers
                                    where passenger.Price == param
                                    select passenger;
                        passengerResult = price.First();
                        break;
                    case FindTypes.Passport:
                        var passport = from passenger in Passengers
                                       where passenger.Passport == param
                                       select passenger;
                        passengerResult = passport.First();
                        break;
                    case FindTypes.ArrivalPort:
                        var arrivalPort = from passenger in Passengers
                                          where passenger.ArrivalPort == param
                                          select passenger;
                        passengerResult = arrivalPort.First();
                        break;
                    case FindTypes.DeparturePort:
                        var departurePort = from passenger in Passengers
                                            where passenger.DeparturePort == param
                                            select passenger;
                        passengerResult = departurePort.First();
                        break;
                    default:
                        passengerResult = null;
                        break;
                }
            }
            catch (Exception)
            {
                passengerResult = null;
            }
        }
        #endregion
    }
}
