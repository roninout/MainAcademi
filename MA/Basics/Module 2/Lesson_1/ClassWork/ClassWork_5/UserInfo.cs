using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_5
{
    abstract class UserInfo
    {
        protected string Usr_name;
        protected byte Usr_nmbr;

        protected UserInfo(string usr_name, byte usr_nmbr)
        {
            Usr_name = usr_name;
            Usr_nmbr = usr_nmbr;
        }

        public abstract string User_Info();
    }
}
