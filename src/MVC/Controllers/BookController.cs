using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BooksEditor.Domain;
using BooksEditor.MVC.Models;
using BooksEditor.Services.Interfaces;

namespace BooksEditor.MVC.Controllers
{
    public class BookController : ApiController
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public BookController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public IEnumerable<BookModel> GetAll()
        {
            return Mapper.Map<IEnumerable<BookModel>>(_bookService.FindAllWithRelated());
        }

        public HttpResponseMessage Post([FromBody] BookModel model)
        {
            if (ModelState.IsValid)
            {
                if (_bookService.IsValidIsbn(model.ISBN))
                {
                    var book = Mapper.Map<Book>(model);
                    foreach (var author in book.Authors)
                    {
                        _authorService.SaveOrAdd(author);
                    }

                    _bookService.SaveOrAdd(book);

                    return Request.CreateResponse(HttpStatusCode.Accepted, new { book.Id });
                }

                ModelState.AddModelError("model.ISBN", "Incorect ISBN.");
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        public void Delete(int id)
        {
            _bookService.Remove(id);
        }
    }
}