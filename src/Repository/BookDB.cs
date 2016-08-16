using System;
using System.Collections.Generic;
using System.Linq;
using BooksEditor.Domain;

namespace BooksEditor.Repository
{
    internal static class BookDB
    {
        private static IList<Book> Books { get; set; }

        static BookDB()
        {
            Books = new List<Book>
            {
                new Book
                {
                    Header = "123",
                    ISBN = "111",
                    NumberOfPages = 100,
                    PublishDate = new DateTime(2016, 01, 01),
                    PublishingHouse = "no",
                    Authors = new List<Author>
                    {
                        new Author { FirstName = "aaa", LastName = "bbb"}
                    }
                }
            };
        }

        public static void Add(Book book)
        {
            book.Id = GetLastID() + 1;
            Books.Add(book);
        }

        public static void Save(Book book)
        {
            var bookDB = Books.First(b => b.Id == book.Id);

            bookDB.Header = book.Header;
            bookDB.ISBN = book.ISBN;
            bookDB.NumberOfPages = book.NumberOfPages;
            bookDB.PublishDate = book.PublishDate;
            bookDB.PublishingHouse = book.PublishingHouse;
        }

        public static IEnumerable<Book> FindAll()
        {
            return Books;
        }

        public static void Remove(Book book)
        {
            Books.Remove(book);
        }

        private static int GetLastID()
        {
            return Books.Max(p => p.Id);
        }
    }
}
