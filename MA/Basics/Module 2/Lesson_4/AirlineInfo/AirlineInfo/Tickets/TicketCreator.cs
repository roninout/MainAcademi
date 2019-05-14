using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo.Tickets
{
    class TicketCreator
    {
        public static List<Ticket> Tickets;
        public static int MaxTickets { get; set; } = 0;

        public TicketCreator(int maxTickets)
        {
            MaxTickets = maxTickets;
            InitTickets();
        }

        // наполняем List билетами
        private List<Ticket> InitTickets()
        {
            Tickets = new List<Ticket>(MaxTickets);
            for (int i = 0; i < MaxTickets; i++)
                Tickets.Add(new Ticket());
            return Tickets;
        }

        //добавляем пассажиров в билеты
        public static void AddPassengersToTickets()
        {
            foreach (var item in Tickets)
                item.InitTicketPassenger();
        }


    }
}
