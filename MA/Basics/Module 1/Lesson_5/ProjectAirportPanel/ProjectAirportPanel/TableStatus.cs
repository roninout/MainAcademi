using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAirportPanel
{
    // тип таблицы
    public enum TableStatus
    {
        Arrival,        // вылет
        ArrivalEdit,    // вылет - редактирование
        Departure,      // прилет
        DepartureEdit   // прилет - редактирование
    }
}
