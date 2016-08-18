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


    }
}
