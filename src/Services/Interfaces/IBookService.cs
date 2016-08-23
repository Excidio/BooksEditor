using System.Collections.Generic;
using BooksEditor.Domain;

namespace BooksEditor.Services.Interfaces
{
    public interface IBookService
    {
        void SaveOrAdd(Book book);

        IEnumerable<Book> FindAllWithRelated();

        void Remove(int id);

        bool IsValidIsbn(string isbn);
    }
}
