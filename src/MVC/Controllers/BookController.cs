using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BooksEditor.Domain;
using BooksEditor.MVC.Helpers;
using BooksEditor.MVC.Models;
using BooksEditor.Repository.Interfaces;

namespace BooksEditor.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<BookModel>>(_bookRepository.FindAll()));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookModel model)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Add(Mapper.Map<Book>(model));
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return PartialView(Mapper.Map<BookModel>(_bookRepository.FindAllWithRelated().First(p => p.Id == id)));
        }

        [HttpPost]
        public ActionResult Edit(BookModel model, HttpPostedFileBase imageData)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Book>(model);
                entity.Image = FileHelper.ConvertToByteArray(imageData);

                _bookRepository.Save(entity);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove(BookModel model)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Remove(Mapper.Map<Book>(model));
            }

            return RedirectToAction("Index");
        }
    }
}