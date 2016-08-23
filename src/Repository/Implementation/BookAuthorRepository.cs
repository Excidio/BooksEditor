using System.Collections.Generic;
using System.Linq;
using BooksEditor.Domain;

namespace BooksEditor.Repository.Implementation
{
    internal class BookAuthorRepository
    {
        public IEnumerable<Author> GetAuthors(Book book)
        {
            var authorsId = BookAuthorDB.GetAll().Where(ba => ba.BookId == book.Id).Select(ba => ba.AuthorId);

            return AuthorDB.GetAll().Where(a => authorsId.Contains(a.Id));
        }

        public void UpdateAuthors(Book book)
        {
            var bookAuthors = BookAuthorDB.GetAll().Where(ba => ba.BookId == book.Id).ToArray();

            Remove(book, bookAuthors);
            Add(book, bookAuthors);
        }

        private static void Add(Book book, IEnumerable<BookAuthor> bookAuthors)
        {
            foreach (var author in book.Authors.Where(a => bookAuthors.All(ba => ba.AuthorId != a.Id)).ToList())
            {
                BookAuthorDB.Add(new BookAuthor { AuthorId = author.Id, BookId = book.Id });
            }
        }

        private static void Remove(Book book, IEnumerable<BookAuthor> bookAuthors)
        {
            foreach (var bookAuthor in bookAuthors.Where(ba => book.Authors.All(a => ba.AuthorId != a.Id)).ToList())
            {
                BookAuthorDB.Remove(bookAuthor);
            }
        }
    }
}
