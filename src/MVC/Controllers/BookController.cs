using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BooksEditor.Domain;
using BooksEditor.MVC.Models;
using BooksEditor.Repository.Interfaces;

namespace BooksEditor.MVC.Controllers
{
    public class BookController : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookModel> GetAll()
        {
            return Mapper.Map<IEnumerable<BookModel>>(_bookRepository.FindAll());
        }

        public void Save([FromBody]BookModel model)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Save(Mapper.Map<Book>(model));
            }
        }
    }
}