using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_5
{
    class UserGroup : UserInfo
    {
        string Group;

        public UserGroup(string UserGroup, string Usr_name, byte Usr_nmbr) : base(Usr_name, Usr_nmbr)
        {
            Group = UserGroup;
        }

        public override string User_Info()
        {
            return Group + " " + Usr_name + " " + Usr_nmbr;
        }
    }
}
