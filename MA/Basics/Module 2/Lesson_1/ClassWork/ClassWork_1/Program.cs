using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Emploee p = new Emploee("Valery", "Lode", "first");
            Console.WriteLine($"First name = {p.FirstName}, last name = {p.LastName} rank = {p.rank}");
            Console.WriteLine(Emploee.EmpCount);
        }
    }
}
