using System.Collections.Generic;
using BooksEditor.Domain;

namespace BooksEditor.Repository
{
    internal static class BookAuthorDB
    {
        private static readonly IList<BookAuthor> Values;

        static BookAuthorDB()
        {
            Values = new List<BookAuthor>
            {
                new BookAuthor { BookId = 1, AuthorId = 1 },
                new BookAuthor { BookId = 2, AuthorId = 2 },
                new BookAuthor { BookId = 2, AuthorId = 3 },
                new BookAuthor { BookId = 2, AuthorId = 4 },
                new BookAuthor { BookId = 2, AuthorId = 5 },
                new BookAuthor { BookId = 2, AuthorId = 6 },
                new BookAuthor { BookId = 2, AuthorId = 7 }
            };
        }

        public static void Add(BookAuthor value)
        {
            Values.Add(value);
        }

        public static IEnumerable<BookAuthor> GetAll()
        {
            return Values;
        }

        public static void Remove(BookAuthor value)
        {
            //Values.First(b => b.AuthorId == value.BookId);
            Values.Remove(value);
        }
    }
}
