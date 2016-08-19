using System.Collections.Generic;
using System.Linq;
using BooksEditor.Domain;

namespace BooksEditor.Repository
{
    internal static class AuthorDB
    {
        private static readonly object SyncObject = new object();
        private static readonly IList<Author> Values;

        static AuthorDB()
        {
            Values = new List<Author>
            {
                new Author { Id = 1, FirstName = "Jeffrey", LastName = "Richter"},
                new Author { Id = 2, FirstName = "Martin", LastName = "Fowler"},
                new Author { Id = 3, FirstName = "Kent", LastName = "Beck"},
                new Author { Id = 4, FirstName = "John", LastName = "Brant"},
                new Author { Id = 5, FirstName = "William", LastName = "Opdyke"},
                new Author { Id = 6, FirstName = "Don", LastName = "Roberts"},
                new Author { Id = 7, FirstName = "Erich", LastName = "Gamma"}
            };
        }

        public static void Add(Author author)
        {
            lock (SyncObject)
            {
                author.Id = Values.Max(p => p.Id) + 1;
                Values.Add(author);
            }
        }

        public static void Save(Author author)
        {
            lock (SyncObject)
            {
                var bookDB = Values.First(b => b.Id == author.Id);

                bookDB.FirstName = author.FirstName;
                bookDB.LastName = author.LastName;
            }
        }

        public static IEnumerable<Author> GetAll()
        {
            return Values;
        }

        public static void Remove(Author author)
        {
            lock (SyncObject)
            {
                Values.Remove(author);
            }
        }
    }
}
