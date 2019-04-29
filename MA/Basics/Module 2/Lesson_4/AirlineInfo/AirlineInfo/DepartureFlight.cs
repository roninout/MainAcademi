using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    class DepartureFlight : IDepartureFlight
    {
        #region properties
        static Random random = new Random();
        private string flightNumber;
        private string cityPort;
        private string airline;
        private string terminal;

        public DateTime DateTime { get; set; }          // время
        public string FlightNumber
        {
            get => flightNumber;
            set => flightNumber = value.Substring(0, Math.Min(value.Length, (int)Columns.colFlightNumber));
        }                   // номер рейса
        public string CityPort
        {
            get => cityPort;
            set => cityPort = value.Substring(0, Math.Min(value.Length, (int)Columns.colCityPort));
        }                       // назначения
        public string Airline
        {
            get => airline;
            set => airline = value.Substring(0, Math.Min(value.Length, (int)Columns.colAirline));
        }                        // перевозчик
        public string Terminal
        {
            get => terminal;
            set => terminal = value.Substring(0, Math.Min(value.Length, (int)Columns.colTerminal));
        }                        // терминал
        public FlightStatus FlightStatus { get; set; }   // статус
        #endregion

        #region constructor
        public DepartureFlight()
        {
            DateTime = DateTime.Now.AddMinutes(random.Next(0, 500));
            FlightNumber = Data.flightNumber[random.Next(Data.flightNumber.Count)];
            CityPort = Data.cityPort[random.Next(Data.cityPort.Count)];
            Airline = Data.airline[random.Next(Data.airline.Count)];
            Terminal = Data.terminal[random.Next(Data.terminal.Count)];
            FlightStatus = (FlightStatus)random.Next(Enum.GetNames(typeof(FlightStatus)).Length);
        }

        public DepartureFlight(DateTime dateTime, string flightNumber, string cityPort, string airline, string terminal, FlightStatus flightStatus)
        {
            DateTime = dateTime;
            FlightNumber = flightNumber;
            CityPort = cityPort;
            Airline = airline;
            Terminal = terminal;
            FlightStatus = flightStatus;
        }
        #endregion

        #region methods
        // отображение ПРИЛЁТ-ов
        public void Show()
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
        public void Edit(Columns columns, int selectType)
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
    #endregion
}
