using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.InitPerson();

            Person.SortedPersons();

            Person.SortedGroups();

            Person.JoinQuery();

            Person.GroupJoinQuery();

            Person.LeftOuterQuery();

            Console.ReadKey();

        }


    }
}
