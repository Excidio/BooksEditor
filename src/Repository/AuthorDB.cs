using System.Collections.Generic;
using System.Linq;
using BooksEditor.Domain;

namespace BooksEditor.Repository
{
    internal static class AuthorDB
    {
        private static IList<Author> Values { get; set; }

        static AuthorDB()
        {
            Values = new List<Author>
            {
                new Author
                {
                    FirstName = "aaa",
                    LastName = "bbb"
                }
            };
        }

        public static void Add(Author book)
        {
            book.Id = GetLastID() + 1;
            Values.Add(book);
        }

        public static void Save(Author book)
        {
            var bookDB = Values.First(b => b.Id == book.Id);

            bookDB.FirstName = book.FirstName;
            bookDB.LastName = book.LastName;
        }

        public static void Remove(Author book)
        {
            Values.Remove(book);
        }

        private static int GetLastID()
        {
            return Values.Max(p => p.Id);
        }
    }
}
