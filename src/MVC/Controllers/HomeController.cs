using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BooksEditor.MVC.Models;
using BooksEditor.Repository;

namespace BooksEditor.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(/*IBookRepository bookRepository*/)
        {
            _bookRepository = new BookRepository();//bookRepository;
        }

        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<BookModel>>(_bookRepository.FindAll());

            return View(model);
        }
    }
}