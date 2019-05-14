using System;

namespace AirlineInfo
{
    abstract class Flight : IComparable
    {
        #region properties
        protected static Random random = new Random();
        private string flightNumber;
        private string cityPort;
        private string airline;
        private string terminal;
        private string gate;

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
        public string Gate
        {
            get => gate;
            set => gate = value.Substring(0, Math.Min(value.Length, (int)Columns.colGate));
        }                            // gate
        public FlightStatus FlightStatus { get; set; }   // статус
        #endregion

        #region constructor
        public Flight()
        {
            DateTime = DateTime.Now.AddMinutes(random.Next(-500, 500));
            FlightNumber = Data.flightNumber[random.Next(Data.flightNumber.Count)];
            CityPort = Data.cityPort[random.Next(Data.cityPort.Count)];
            Airline = Data.airline[random.Next(Data.airline.Count)];
            Terminal = Data.terminal[random.Next(Data.terminal.Count)];
            Gate = Data.gate[random.Next(Data.gate.Count)];
            FlightStatus = (FlightStatus)random.Next(Enum.GetNames(typeof(FlightStatus)).Length);
        }
        #endregion

        #region methods
        // отображение
        public abstract void Show();

        // редактирование
        public abstract void Edit(Columns columns, int selectType);

        // сортировка по времени
        public int CompareTo(object obj)
        {
            return obj is Flight ? this.DateTime.CompareTo(((Flight)obj).DateTime) : -1;
        }


        #endregion
    }
}
