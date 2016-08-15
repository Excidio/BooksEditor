using System.Collections.Generic;
using BooksEditor.Domain;

namespace BooksEditor.Repository
{
    public interface IBookRepository
    {
        void Add(Book book);

        void Save(Book book);

        IEnumerable<Book> FindAll();

        void Remove(Book book);
    }
}
