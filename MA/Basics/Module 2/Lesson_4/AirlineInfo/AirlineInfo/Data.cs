using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    static class Data
    {
        public static int maxArrivalFlight = 0;
        public static int maxDepartureFlight = 0;
        public static int maxPassengers = 0;

        #region data Fly
        internal static List<string> flightNumber = new List<string>()
        { "KC 406","PQ 7119","LO 8312","PS 5673","LH 2545","LH 2544","QU 4440", "PS 354", "LH 1494", "PS 472"};
        internal static List<string> cityPort = new List<string>()
        { "Алматы", "Шарм-Эль-Шейх", "Таллинн", "Мюнхен", "Афины", "Франкфурт", "Цюрих" };
        internal static List<string> airline = new List<string>()
        { "Air Astana", "Sky Up Airlines", "LOT Polish Airlines", "Ukraine International Airlines", "Lufthansa", "Azur Air Ukraine" };
        internal static List<string> terminal = new List<string>()
        { "A", "B", "C", "D"};
        internal static List<string> gate = new List<string>()
        { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3", "D1", "D2", "D3"};
        #endregion

        #region data passenger
        internal static List<string> firstNameMale = new List<string>()
        { "Mohammed","Porter","Chad","Fidel","Faustino"};
        internal static List<string> secondNameMale = new List<string>()
        { "Woodham","Hilger","Heyer","Dorsey","Sweatt"};
        internal static List<string> firstNameFemale = new List<string>()
        { "Alexandra","Bari","Awilda","Patrica","Ellie"};
        internal static List<string> secondNameFemale = new List<string>()
        { "Barrientez","Lazar","Marson","Blackledge","Baumer"};
        internal static List<string> passportId = new List<string>()
        { "CH 123456","QW 132447","DF 345678","JK 135286","PQ 102938", "AS 416587","DG 764556","JH 653076","MN 852700","CX 336629"};
        internal static List<string> nationality = new List<string>()
        { "Afghan","Belgian","Brazilian","Chinese","Cuban", "Ethiopian","Iranian","Nambian","Serbian","Ukranian"};

        #endregion

        #region init data
        public static Flight[] InitArrivalFlight()
        {
            Flight[] flights = new Flight[maxArrivalFlight];
            for (int i = 0; i < maxArrivalFlight; i++)
                flights[i] = new ArrivalFlight();
            return flights;
        }

        public static Flight[] InitDepartureFlight()
        {
            Flight[] flights = new Flight[maxDepartureFlight];
            for (int i = 0; i < maxDepartureFlight; i++)
                flights[i] = new DepartureFlight();
            return flights;
        }
        #endregion

        public static Func<DateTime> RandomDayFunc(Random gen)
        {
            DateTime start = new DateTime(1960, 1, 1);
            //Random gen = new Random();
            int range = ((TimeSpan)(DateTime.Today - start)).Days;
            return () => start.AddDays(gen.Next(range));
        }
    }
}
