using System;
using System.Threading;

namespace Hello_Console_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@"Please,  type the number:
                    1.  f(a,b) = |a-b| (unary)
                    2.  f(a) = a (binary)
                    3.  music
                    4.  morse sos
          
                    ");
                    try
                    {
                        a = (int)uint.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                My_strings();
                                Console.WriteLine(string.Empty);
                                break;
                            case 2:
                                My_Binary();
                                Console.WriteLine(string.Empty);
                                break;
                            case 3:
                                My_music();
                                Console.WriteLine(string.Empty);
                                break;
                            case 4:
                                Morse_code();
                                Console.WriteLine(string.Empty);
                                break;
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error" + e.Message);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #region ToFromBinary
        static void My_Binary()
        {
            char[] binArray, fixBinArray;
            string result = String.Empty;
            int input, saveInput;

            //Implement positive integer variable input
            Console.WriteLine("Введите положительное число: ");
            input = saveInput = Int32.Parse(Console.ReadLine());

            // проверка на положительное число
            if (input < 0) return;

            //Present it like binary string
            while (input > 0)
            {
                result += input % 2; //Use modulus operator to obtain the remainder  (n % 2)               
                input = input / 2;   //and divide variable by 2 in the loop
            }

            //Use the ToCharArray() method to transform string to chararray
            int rank = result.Length / 4 + 1; // количество разрядов
            result = result.PadRight(rank * 4, '0'); // умножаем на 4-е 0-ка
            binArray = result.ToCharArray();
            string fixString = binArray[0].ToString(); // строка дополняемая пробелами

            for (int i = 1; i < binArray.Length; i++)
            {
                if (i % 4 == 0)       // добавляем пробелы в разрядах
                    fixString += " ";
                fixString += binArray[i];
            }

            //and Array.Reverse() method
            fixBinArray = fixString.ToCharArray(); // строку в чары
            Array.Reverse(fixBinArray); // переворачиваем
            result = new string(fixBinArray); // и опять в строку
            Console.WriteLine($" Результат преобразования: {saveInput} = {result}");
        }

        //For ToBinary String recursion
        static void GetBinary(int a, ref string str)
        {
            if (a > 1) GetBinary(a / 2, ref str);
            str += (a % 2).ToString();
        }

        #endregion

        #region ToFromUnary
        static void My_strings()
        {
            //Declare int and string variables for decimal and binary presentations
            //int a, b;
            //Console.WriteLine("Enter position number: ");
            //Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("Enter first positive number: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            int a = (int)uint.Parse(Console.ReadLine());

            Console.WriteLine("Enter second positive number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;

            int b = (int)uint.Parse(Console.ReadLine());

            string aStr = string.Empty, bStr = string.Empty;

            for (int i = 0; i < a; i++)
                aStr += "1";

            for (int i = 0; i < b; i++)
                bStr += "1";

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"aSTr: {aStr}");
            Console.WriteLine($"bSTr: {bStr}");
            Console.WriteLine();
            Console.WriteLine($"Unary result: {new string('1', Math.Abs(aStr.Length - bStr.Length))}");

            Console.WriteLine();


            //Implement two positive integer variables input

            //To present each of them in the form of unary string use for loop

            //Use concatenation of these two strings 
            //Note it is necessary to use some symbol ( for example “#”) to separate

            //Check the numbers on the equality 0
            //Realize the  algorithm for replacing '1#1' to '#' by using the for loop 
            //Delete the '#' from algorithm result

            //Output the result 
        }
        #endregion

        #region My_music
        static void My_music()
        {
            //HappyBirthday
            Thread.Sleep(2000);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }
        #endregion

        #region Morse
        static void Morse_code()
        {
            Console.WriteLine();
            //Create string variable for 'sos'
            string word = "sos";

            //Use string array for Morse code
            string[,] Dictionary_arr = new string[,] { { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },
            { ".-   ", "-... ", "-.-. ", "-..  ", ".    ", "..-. ", "--.  ", ".... ", "..   ", ".--- ", "-.-  ", ".-.. ", "--   ", "-.   ", "---  ", ".--. ", "--.- ", ".-.  ", "...  ", "-    ", "..-  ", "...- ", ".--  ", "-..- ", "-.-- ", "--.. ", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." }};

            //Use ToCharArray() method for string to copy charecters to Unicode character array
            char[] wordChar = word.ToLower().ToCharArray();
            char[] morseChar = null;

            //Use foreach loop for character array in which
            foreach (char sosCharItem in wordChar)     // проходим по буквам слова
            {
                morseChar = FindMorseSimbol(Dictionary_arr, sosCharItem.ToString());
                if (morseChar != null)                // проверка на отсутсвие символа
                {
                    Console.Write($"{sosCharItem} "); // выводим символы на экран
                    Console.WriteLine(morseChar);     // не понятно?????
                    PlayMorseChar(morseChar);         // проигрываем морзе символ
                }
            }
        }

        // поиск морзе-символов по букве 
        private static char[] FindMorseSimbol(string[,] Dictionary_arr, string simbol)
        {
            char[] result = null;
            //int rows = Dictionary_arr.GetUpperBound(0) + 1;
            //int columns = Dictionary_arr.Length / rows;
            for (int i = 0; i < Dictionary_arr.GetUpperBound(1) + 1; i++)
            {
                if (Dictionary_arr[0, i] == simbol)
                    result = Dictionary_arr[1, i].ToCharArray();
            }
            return result;
        }

        // проигрываем морзе символ
        private static void PlayMorseChar(char[] morseChar)
        {
            foreach (char morseCharItem in morseChar)
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
        #endregion
    }
}
