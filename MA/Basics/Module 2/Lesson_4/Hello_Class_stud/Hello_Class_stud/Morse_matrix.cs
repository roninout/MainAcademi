using System;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, IMorse_crypt
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;
        private string[,] Dict_arr;

        #region constructor
        //Implement Morse_matrix constructor with the int parameter for offset
        public Morse_matrix(int offset_key = 0)
        {
            this.offset_key = offset_key;
        }

        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        public Morse_matrix(string[,] dict_arr, int offset_key = 0) : this(offset_key)
        {
            Dict_arr = dict_arr;
        }
        #endregion

        //Use fd(Alphabet.Dictionary_arr) and sd() methods
        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size1; ii++)
                for (int jj = 0; jj < Size_2; jj++)
                    this[ii, jj] = Dict_arr[ii, jj];
        }

        //Use fd(Dict_arr) and sd() methods
        private void sd()
        {
            int off = Size_2 - offset_key;
            for (int jj = 0; jj < off; jj++)
                this[1, jj] = this[1, jj + offset_key];
            for (int jj = off; jj < Size_2; jj++)
                this[1, jj] = this[1, jj - off];
        }

        //Implement Morse_matrix operator +


        //Realize crypt() with string parameter
        //Use indexers
        public string crypt(string word)
        {
            throw new NotImplementedException();
        }

        //Realize decrypt() with string array parameter
        //Use indexers
        public string decrypt(string[] sos)
        {
            throw new NotImplementedException();
        }

        //Implement Res_beep() method with string parameter to beep the string
        public void Res_beep(string rslt)
        {

        }

    }
}

