using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BooksEditor.Domain;
using BooksEditor.MVC.Models;
using BooksEditor.Repository.Interfaces;
using BooksEditor.Services.Interfaces;

namespace BooksEditor.MVC.Controllers
{
    public class BookController : ApiController
    {
        private readonly IAuthorService _authorService;
        private readonly IBookRepository _bookRepository;

        public BookController(IAuthorService authorService, IBookRepository bookRepository)
        {
            _authorService = authorService;
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookModel> GetAll()
        {
            return Mapper.Map<IEnumerable<BookModel>>(_bookRepository.FindAllWithRelated());
        }

        public void Save([FromBody]BookModel model)
        {
            if (ModelState.IsValid)
            {
                var book = Mapper.Map<Book>(model);
                foreach (var author in book.Authors)
                {
                    _authorService.SaveOrAdd(author);
                }

                _bookRepository.Save(book);
            }
        }
    }
}