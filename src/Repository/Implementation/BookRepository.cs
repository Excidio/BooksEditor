using System.Collections.Generic;
using System.Linq;
using BooksEditor.Domain;
using BooksEditor.Repository.Interfaces;

namespace BooksEditor.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private static readonly BookAuthorRepository BookAuthorRepository = new BookAuthorRepository();

        public void Add(Book book)
        {
            BookDB.Add(book);
            BookAuthorRepository.UpdateAuthors(book);
        }

        public void Save(Book book)
        {
            BookDB.Save(book);
            BookAuthorRepository.UpdateAuthors(book);
        }

        public IEnumerable<Book> FindAll()
        {
            return BookDB.GetAll();
        }

        public IEnumerable<Book> FindAllWithRelated()
        {
            var books = BookDB.GetAll().ToList();
            foreach (var book in books)
            {
                book.Authors = BookAuthorRepository.GetAuthors(book);
            }

            return books;
        }

        public void Remove(int id)
        {
            var book = BookDB.GetAll().First(b => b.Id == id);

            BookDB.Remove(book);
            BookAuthorRepository.RemoveAuthors(book);
        }
    }
}
