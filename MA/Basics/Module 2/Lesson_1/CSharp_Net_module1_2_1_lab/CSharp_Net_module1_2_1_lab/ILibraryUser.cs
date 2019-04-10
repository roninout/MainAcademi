using System;
using System.Linq;

namespace CSharp_Net_module1_2_1_lab
{
    // 1) declare interface ILibraryUser
    // declare method's signature for methods of class LibraryUser
    interface ILibraryUser
    {
        //add new book to array bookList
        void AddBook(string name);
        // remove book from array bookList
        void RemoveBook(string name);
        // returns book info by index
        string BookInfo(int index);
        // returns current count of books
        int BooksCount();
    }
}
