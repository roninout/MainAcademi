using System;

namespace AirlineInfo
{
    class DepartureFlight : Flight, IDepartureFlight
    {
        public DepartureFlight() : base()
        {
            DateTime = DateTime.Now.AddMinutes(random.Next(0, 500));
        }

        // отображение ПРИЛЁТ-ов
        public override void Show()
        {
            Console.WriteLine(
            $"{FlightNumber.PadRight((int)Columns.colFlightNumber, ' ')}" +
            $"{DateTime.ToString("HH:mm").PadRight((int)Columns.colDateTime, ' ')}" +
            $"{CityPort.PadRight((int)Columns.colCityPort, ' ')}" +
            $"{Airline.PadRight((int)Columns.colAirline, ' ')}" +
            $"{Terminal.PadRight((int)Columns.colTerminal, ' ')}" +
            $"{FlightStatus.ToString().PadRight((int)Columns.colDevFlightStatus, ' ')}"
            );
        }

        // редактирование ПРИЛЁТ-ов
        public override void Edit(Columns columns, int selectType)
        {
            switch (columns)
            {
                case Columns.colFlightNumber:
                    FlightNumber = Console.ReadLine();
                    break;
                case Columns.colDateTime:
                    DateTime = DateTime.Parse(Console.ReadLine());
                    break;
                case Columns.colCityPort:
                    CityPort = Console.ReadLine();
                    break;
                case Columns.colAirline:
                    Airline = Console.ReadLine();
                    break;
                case Columns.colTerminal:
                    Terminal = Console.ReadLine();
                    break;
                case Columns.colFlightStatus:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"Для изменения СТАТУСА выберите следующие варианты:
    0 -  регистрация
    1 - гейт закрыт
    2 - прибыл
    3 - отправляется в ...
    4 - неизвестен
    5 - отменен
    6 - ожидается в ...
    7 - задерживается
    8 - в полёте");
                    FlightStatus = (FlightStatus)int.Parse(Console.ReadLine());
                    break;
                default:
                    break;
            }
            Console.Clear();
        }
    }
}
