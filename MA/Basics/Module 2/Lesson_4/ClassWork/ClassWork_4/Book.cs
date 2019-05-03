using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_4
{
    class Book : IPrintedBook, IEBook
    {
        public int Pages { get; private set; }

        public Book(int pages)
        {
            Pages = pages;
        }

        public void Publish()
        {
            Console.WriteLine("Book is publishing...");
        }
    }
}
