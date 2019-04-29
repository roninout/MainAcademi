using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    // Статус рейса
    public enum FlightStatus
    {
        ChekIn,         // регистрация
        GateClosed,     // гейт закрыт
        Arrived,        // прибыл
        DepartedAt,     // отправляется в ...
        Unknown,        // неизвестен
        Canceled,       // отменен
        ExpectedAt,     // ожидается в ...
        Delayed,        // задерживается
        InFlight        // в полёте
    }
}
