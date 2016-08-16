using System.Collections.Generic;
using BooksEditor.Domain;
using BooksEditor.Repository.Interfaces;

namespace BooksEditor.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        public void Add(Book book)
        {
            BookDB.Add(book);
        }

        public void Save(Book book)
        {
            BookDB.Save(book);
        }

        public IEnumerable<Book> FindAll()
        {
            return BookDB.FindAll();
        }

        public void Remove(Book book)
        {
            BookDB.Remove(book);
        }
    }
}
