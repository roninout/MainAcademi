using System;
using System.Threading;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, IMorse_crypt
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;

        #region constructor
        //Implement Morse_matrix constructor with the int parameter for offset
        public Morse_matrix(int offset_key = 0)
        {
            this.offset_key = offset_key;
            fd(Alphabet.Dictionary_arr);
            sd();
        }

        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        public Morse_matrix(string[,] dict_arr, int offset_key = 0) : this(offset_key)
        {
            fd(Alphabet.Dictionary_arr);
            sd();
        }
        #endregion

        //Use fd(Alphabet.Dictionary_arr) and sd() methods
        // заполняем матрицу
        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size1; ii++)
                for (int jj = 0; jj < Size_2; jj++)
                    this[ii, jj] = Dict_arr[ii, jj];
        }

        //Use fd(Dict_arr) and sd() methods
        // смещаем одну колонку в матрице с ключем смещения
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
            string result = String.Empty;
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    if (Char.Parse(this[0, j]) == word[i])
                        result += this[1, j].ToString();
                }
            }
            return result;
        }

        //Realize decrypt() with string array parameter
        //Use indexers
        public string decrypt(string[] signal)
        {
            string result = string.Empty;
            for (int i = 0; i < signal.Length; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    if (signal[i] == this[1, j])
                        result += this[0, j];
                }
            }
            return result;
        }

        //Implement Res_beep() method with string parameter to beep the string
        public void Res_beep(string rslt)
        {
            foreach (char morseCharItem in rslt.ToCharArray())
            {
                switch (morseCharItem)
                {
                    case '.':
                        Console.Beep(1000, 250); //Implement Console.Beep(1000, 250) for '.'
                        Thread.Sleep(50); //Use Thread.Sleep(50) to separate sounds
                        break;
                    case '-':
                        Console.Beep(1000, 750); // and Console.Beep(1000, 750) for '-'
                        Thread.Sleep(50); //Use Thread.Sleep(50) to separate sounds
                        break;
                    case ' ':
                        Thread.Sleep(50); //Use Thread.Sleep(50) to separate sounds
                        break;
                    default:
                        break;
                }
            }
        }

    }
}

