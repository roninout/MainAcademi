using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirportPanel
{
    // рейс
    public struct Flight
    {
        public DateTime dateTime;            // время
        public string flightNumber;          // номер рейса
        public string cityPort;              // назначения
        public string airline;               // перевозчик
        public string terminal;              // терминал
        public string gate;                  // gate
        public FlightStatus flightStatus;    // статус

        // конструктор
        public Flight(string flightNumber, DateTime dateTime, string cityPort, string airline, string terminal, string gate, FlightStatus flightStatus)
        {
            this.flightNumber = flightNumber;
            this.dateTime = dateTime;
            this.cityPort = cityPort;
            this.airline = airline;
            this.terminal = terminal;
            this.gate = gate;
            this.flightStatus = flightStatus;
        }
    }
}
