using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_1
{
    class StringColumn
    {
        public const int Size2 = 36;
        private string[] _strColumn = new string[Size2];

        public StringColumn()
        {
            for (int i = 0; i < Size2; i++)
            {
                this[i] = null;
            }
        }

        public string this[int x]
        {
            get { return _strColumn[x]; }
            set { _strColumn[x] = value; }
        }

        public static StringMatrix operator +(StringMatrix tbl1, StringColumn tbl2)
        {
            StringMatrix _resStringMatrix = new StringMatrix();

            for (int i = 0; i < StringMatrix.Size1; i++)
            {
                for (int j = 0; j < StringMatrix.Size2; j++)
                {
                    _resStringMatrix[i, j] = tbl1[i, j] + tbl2[j];
                }
            }
            return _resStringMatrix;
        }
    }
}
