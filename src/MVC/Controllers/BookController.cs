using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BooksEditor.Domain;
using BooksEditor.MVC.Models;
using BooksEditor.Repository.Implementation;
using BooksEditor.Repository.Interfaces;

namespace BooksEditor.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(/*IBookRepository bookRepository*/)
        {
            _bookRepository = new BookRepository();//bookRepository;
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
                _bookRepository.Add(ModelToEntity(model));
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
                _bookRepository.Save(ModelToEntity(model));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Remove(BookModel model)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Remove(ModelToEntity(model));
            }

            return RedirectToAction("Index");
        }

        private static Book ModelToEntity(BookModel model)
        {
            return Mapper.Map<Book>(model);
        }
    }
}