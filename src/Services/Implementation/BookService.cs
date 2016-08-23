using System.Collections.Generic;
using BooksEditor.Domain;
using BooksEditor.Repository.Interfaces;
using BooksEditor.Services.Interfaces;

namespace BooksEditor.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void SaveOrAdd(Book book)
        {
            if (book.Id == 0)
            {
                _bookRepository.Add(book);
            }
            else
            {
                _bookRepository.Save(book);
            }
        }

        public IEnumerable<Book> FindAllWithRelated()
        {
            return _bookRepository.FindAllWithRelated();
        }

        public void Remove(int id)
        {
            _bookRepository.Remove(id);
        }

        public bool IsValidIsbn(string isbn)
        {
            return Isbn.TryValidate(isbn);
        }
    }
}
