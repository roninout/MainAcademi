using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Box
    {

        public (int x, int y) Point { get; set; } = (x: 0, y: 0);
        public int Width { get; set; }
        public int Height { get; set; }
        public char Symbol { get; set; }
        public string Message { get; set; }

        public Box((int x, int y) point, int height, int width, char symbol)
        {
            Point = point;
            Width = width;
            Height = height;
            Symbol = symbol;
        }

        public void Draw()
        {

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.SetCursorPosition(Point.x + j, Point.y + i);
                    if (j == 0 || j == Width - 1)
                        Console.Write(Symbol);
                    else if
                       (i == 0 || i == Height - 1)
                        Console.Write(Symbol);
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }


        //2.  Implement public Draw() method
        //to define start position, width and height, symbol, message  according to properties
        //Use Math.Min() and Math.Max() methods
        //Use draw() to draw the box with message

        //3.  Implement private method draw() with parameters 
        //for start position, width and height, symbol, message
        //Change the message in the method to return the Box square
        //Use Console.SetCursorPosition() method
        //Trim the message if necessary


    }
}
