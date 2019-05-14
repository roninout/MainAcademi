using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo.Flights
{
    class FlightCreator
    {
        //public static int MaxArrivalFlight { get; set; } = 0;
        //public static int MaxDepartureFlight { get; set; } = 0;

        public static int MaxFlight { get; set; } = 0;

        public static List<Flight> ArrivalFlights;
        public static List<Flight> DepartureFlights;

        public FlightCreator(int maxFlight)
        {
            MaxFlight = maxFlight;
        }

        public List<Flight> InitArrivalFlight()
        {
            ArrivalFlights = new List<Flight>(MaxFlight);
            for (int i = 0; i < MaxFlight; i++)
                ArrivalFlights.Add(new ArrivalFlight());
            return ArrivalFlights;
        }

        public List<Flight> InitDepartureFlight()
        {
            DepartureFlights = new List<Flight>(MaxFlight);
            for (int i = 0; i < MaxFlight; i++)
                DepartureFlights.Add(new DepartureFlight());
            return DepartureFlights;
        }
    }
}
