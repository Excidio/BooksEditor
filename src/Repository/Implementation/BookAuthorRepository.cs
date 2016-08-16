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
    }
}
