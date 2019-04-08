using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4
{
    class Indexed_student
    {
        public static int stud_cnt = 8;
        private string[] stud_list = new string[stud_cnt];

        public Indexed_student()
        {
            for (int j = 0; j < stud_cnt; j++)
            {
                stud_list[j] = "C# student " + j;
            }
        }

        public string this[int index_var]
        {
            get
            {
                string temp;
                if (index_var >= 0 && index_var <= stud_cnt - 1)
                {
                    temp = stud_list[index_var];
                }
                else
                {
                    temp = "";
                }
                return (temp);
            }
            set
            {
                if (index_var >= 0 && index_var <= stud_cnt)
                {
                    stud_list[index_var] = value;
                }
            }
        }
    }
}
