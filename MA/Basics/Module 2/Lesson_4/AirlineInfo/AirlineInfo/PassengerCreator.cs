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

        //public Passenger this[int index]
        //{
        //    get
        //    {
        //        return Passengers[index];
        //    }
        //    set
        //    {
        //        Passengers[index] = value;
        //    }
        //}
    }
}
