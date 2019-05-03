using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4
{
    interface IEBook : IAppDomainSetup, IAsyncResult
    {
        int Pages { get; }
        int Publish(string str="fdfdf", int s)

    }
}
