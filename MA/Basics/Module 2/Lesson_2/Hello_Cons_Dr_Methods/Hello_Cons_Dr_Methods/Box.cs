using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Box
    {
        #region fields
        (int x, int y) point;
        int width;
        int height;
        #endregion

        #region properties
        public (int x, int y) Point
        {
            get
            {
                return point;
            }
            set
            {
                    point = (0, 0);
                if (value.x > 0)
                    point.x = value.x;
                if (value.y > 0)
                    point.y = value.y;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value < 3 ? 3 : value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value < 3 ? 3 : value;
            }
        }
        public char Symbol { get; set; }
        public string Message { get; set; } = String.Empty;
        #endregion

        #region constructor
        public Box()
        {
            Point = (x: 0, y: 0);
            Width = 10;
            Height = 10;
            Symbol = '*';
        }

        public Box((int x, int y) point, int width, int height, char symbol)
        {
            Point = point;
            Width = width;
            Height = height;
            Symbol = symbol;
        }
        #endregion

        #region methods
        //2.  Implement public Draw() method
        //to define start position, width and height, symbol, message  according to properties
        //Use Math.Min() and Math.Max() methods
        //Use draw() to draw the box with message
        public void Draw()
        {
            draw(Point, Height, Width, Symbol, Message);
        }

        //3.  Implement private method draw() with parameters 
        //for start position, width and height, symbol, message
        //Change the message in the method to return the Box square
        //Use Console.SetCursorPosition() method
        //Trim the message if necessary

        // private method draw() with parameters
        private void draw((int x, int y) point, int height, int width, char symbol, string message)
        {
            string[] box = InitEmptyBox(height, width, symbol);
            InsertMessageToBox(box, message);
            for (int i = 0; i < box.Length; i++)
            {
                Console.SetCursorPosition(point.x, point.y + i);
                Console.WriteLine(box[i]);
            }
        }

        // метод формирует прямоугольник, но не отображает
        private string[] InitEmptyBox(int height, int width, char symbol)
        {
            // создаём массив строк
            string[] result = new string[height];
            // первая строчка
            result[0] = new string(symbol, width);
            // середина
            for (int i = 1; i < result.Length - 1; i++)
                result[i] = $"{symbol}{new string(' ', width - 2)}{symbol}";
            // последняя строка
            result[height - 1] = new string(symbol, width);

            return result;
        }

        // метод вставляет сообщение в прямоугольник
        private void InsertMessageToBox(string[] box, string message)
        {
            if (message.Length < 1) message = "!";                                                                                              // заменяем пустой message надписью !

            string trimMessage = message.Substring(0, Math.Min(message.Length, box[0].Length - 2));                                             // если сообщение длинее нашей рамки - обрезаем его
            int middle = box.Length / 2;                                                                                                        // находим середину по вертикали
            char symbol = box[0][0];                                                                                                            // определяем символ
            int emptySymbolsCountLeft = (box[0].Length - trimMessage.Length - 2)/2;                                                             // количество пробелов слева
            int emptySymbolsCountRight = (box[0].Length - trimMessage.Length - 2) % 2 == 0 ? emptySymbolsCountLeft : emptySymbolsCountLeft + 1; // количество пробелов справа
            box[middle] = $"{symbol}{new string(' ', emptySymbolsCountLeft)}{trimMessage}{new string(' ', emptySymbolsCountRight)}{symbol}";    // заменяем строку строкой с собщением посередине
        }
        #endregion

        #region stuff
        //private void draw((int x, int y) point, int height, int width, char symbol, string message)
        //{
        //    string trimMessage = message.Substring(0, Math.Min(message.Length, width - 2));

        //    for (int i = 0; i < height; i++)
        //    {
        //        for (int j = 0; j < width; j++)
        //        {
        //            Console.SetCursorPosition(point.x + j, point.y + i);
        //            if (j == 0 || j == width - 1)
        //                Console.Write(symbol);
        //            else if
        //                (i == 0 || i == height - 1)
        //                Console.Write(symbol);
        //            else
        //                Console.Write(' ');
        //        }
        //        Console.WriteLine();
        //    }
        //}
        #endregion
    }
}
