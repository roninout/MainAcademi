using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Indexed_student indexed_student = new Indexed_student();

            for (int i = 0; i < Indexed_student.stud_cnt; i++)
            {
                Console.WriteLine(indexed_student[i]);
            }
            Console.WriteLine(Indexed_student.stud_cnt);
        }
    }
}
