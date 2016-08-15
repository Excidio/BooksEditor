using System.Collections.Generic;
using BooksEditor.Domain;

namespace BooksEditor.Repository
{
    public class BookRepository : IBookRepository
    {
        public void Add(Book book)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Book book)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Book> FindAll()
        {
            return BookDB.Books;
        }

        public void Remove(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}
