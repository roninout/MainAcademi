using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_1
{
    class StringMatrix
    {
        public static int Size1 { get; set; } = 2;
        public static int Size2 { get; set; } = 3;

        private string[,] strMatrix = new string[Size1, Size2];

        public StringMatrix()
        {
        }

        public StringMatrix(string[,] strMatrix)
        {
            this.strMatrix = strMatrix;
        }

        public string this[int x, int y]
        {
            get { return strMatrix[x, y]; }
            set { strMatrix[x, y] = value; }
        }

        public static StringMatrix operator +(StringMatrix tbl1, StringMatrix tbl2)
        {
            StringMatrix res_str_matrix = new StringMatrix();

            for (int i = 0; i < Size1; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    res_str_matrix[i, j] = tbl1[i, j] + tbl2[i, j];
                }
            }
            return res_str_matrix;
        }

        public static StringMatrix operator ++(StringMatrix tbl1)
        {
            StringMatrix _resStringMatrix = new StringMatrix();

            for (int i = 0; i < Size1; i++)
            {
                for (int j = 0; j < Size2 - 1; j++)
                {
                    _resStringMatrix[i, j] = tbl1[i, j] + " " + tbl1[i, j + 1];
                    _resStringMatrix[i, Size2 - 1] = tbl1[i, Size2 - 1] + " " + tbl1[i, 0];
                }
            }
            return _resStringMatrix;
        }
    }
}
