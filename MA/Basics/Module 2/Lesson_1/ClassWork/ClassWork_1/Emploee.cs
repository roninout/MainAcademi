using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_1
{
    class Emploee
    {
        public static int EmpCount;
        public string FirstName;
        public string LastName;
        public string rank;

        public Emploee()
        {
            EmpCount++;
        }

        public Emploee(string first, string last, string rank)
        {
            this.FirstName = first;
            this.LastName = last;
            this.rank = rank;
            EmpCount++;
        }
    }
}
