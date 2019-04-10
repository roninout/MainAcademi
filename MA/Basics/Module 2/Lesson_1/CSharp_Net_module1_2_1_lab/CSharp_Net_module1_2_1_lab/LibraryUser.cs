using System;

namespace CSharp_Net_module1_2_1_lab
{
    // 2) declare class LibraryUser, it implements ILibraryUser
    class LibraryUser : ILibraryUser
    {
        #region field
        // 4) declare field (bookList) as a string array
        private string[] bookList;
        private static int idIterator = 0;
        #endregion

        #region indexer
        // 5) declare indexer BookList for array bookList
        public string this[int index]
        {
            get
            {
                return bookList[index];
            }
            set
            {
                bookList[index] = value;
            }
        }

        //public string this[string name]
        //{
        //    get
        //    {
        //        foreach (var item in bookList)
        //        {
        //            if (item == name)
        //                return item;
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        for (int i = 0; i < bookList.Length; i++)
        //        {
        //            if (bookList[i] == name)
        //            {
        //                bookList[i] = value;
        //                break;
        //            }
        //        }
        //    }
        //}

        #endregion

        #region properties
        // 3) declare properties: FirstName (read only), LastName (read only), 
        // Id (read only), Phone (get and set), BookLimit (read only)
        public string FirstName { get; }
        public string LastName { get; }
        public int Id { get; }
        public string Phone { get; set; }
        public int BookLimit { get; }
        #endregion

        #region constructors
        // 6) declare constructors: default and parameter
        public LibraryUser()
        {
            bookList = new string[] { };
            FirstName = "Alex";
            LastName = "Malex";
            Phone = "+380668774716";
            BookLimit = 2;
            Id = ++idIterator;
        }

        public LibraryUser(string firstName, string lastName, string phone, int bookLimit)
        {
            bookList = new string[] { };
            FirstName = firstName;
            LastName = lastName;
            Id = ++idIterator;
            Phone = phone;
            BookLimit = bookLimit;
        }

        #endregion

        #region methods
        // 7) declare methods:
        //AddBook() – add new book to array bookList
        public void AddBook(string name)
        {
            if (bookList.Length < BookLimit)
            {
                Array.Resize(ref bookList, bookList.Length + 1);
                bookList[bookList.Length - 1] = name;
            }
            else
            {
                Console.WriteLine("...to many books");
            }
        }

        //BookInfo() – returns book info by index
        public string BookInfo(int index)
        {
            return bookList[index];
        }

        //BooksCout() – returns current count of books
        public int BooksCount()
        {
            return bookList.Length;
        }

        //RemoveBook() – remove book from array bookList
        public void RemoveBook(string name)
        {
            // создаем новый массив на единицу меньше основного
            string[] resultArray = new string[bookList.Length - 1];
            // индекс удаляемого элемента
            int removeIndex = Array.IndexOf(bookList, name);

            // если индекс существует
            if (removeIndex == -1) return;

            // копируем до найденго индекса
            for (int i = 0; i < removeIndex; i++)
                resultArray[i] = bookList[i];

            // копируем после найденго индекса
            for (int i = removeIndex; i < resultArray.Length; i++)
                resultArray[i] = bookList[i + 1];

            // и переназначаем ссылку
            bookList = resultArray;
        }
        #endregion

    }
}