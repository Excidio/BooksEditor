using System;
using System.Collections.Generic;
using System.Linq;
using BooksEditor.Domain;

namespace BooksEditor.Repository
{
    internal static class BookDB
    {
        private static readonly IList<Book> Values;

        static BookDB()
        {
            Values = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Header = "CLR via C#, 4 edition",
                    ISBN = "978-5-496-00433-6",
                    NumberOfPages = 896,
                    PublishingYear = 2012,
                    PublishingHouse = "O’Reilly Media, Inc"
                },
                new Book
                {
                    Id = 2,
                    Header = "Refactoring: Improving the Design of Existing Code",
                    ISBN = "978-5-93286-045-8",
                    NumberOfPages = 432,
                    PublishingYear = 2008,
                    PublishingHouse = "Addison Wesley Longman, Inc."
                }
            };
        }

        public static void Add(Book book)
        {
            book.Id = GetLastID() + 1;
            Values.Add(book);
        }

        public static void Save(Book book)
        {
            var bookDB = Values.First(b => b.Id == book.Id);

            bookDB.Header = book.Header;
            bookDB.ISBN = book.ISBN;
            bookDB.NumberOfPages = book.NumberOfPages;
            bookDB.PublishingYear = book.PublishingYear;
            bookDB.PublishingHouse = book.PublishingHouse;
        }

        public static IEnumerable<Book> GetAll()
        {
            return Values;
        }

        public static void Remove(Book book)
        {
            Values.Remove(book);
        }

        private static int GetLastID()
        {
            return Values.Max(p => p.Id);
        }
    }
}
