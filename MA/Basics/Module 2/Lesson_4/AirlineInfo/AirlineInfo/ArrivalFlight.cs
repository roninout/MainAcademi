using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    class ArrivalFlight : Flight, IArrivalFlight
    {
        // редактирование ВЫЛЕТ-ов
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
                case Columns.colGate:
                    Gate = Console.ReadLine();
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
