using System;
using System.Collections.Generic;
using BooksEditor.Domain;

namespace BooksEditor.Repository
{
    internal static class BookDB
    {
        public static IEnumerable<Book> Books { get; set; }

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
    }
}
