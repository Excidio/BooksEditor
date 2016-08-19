using System;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using BooksEditor.Domain;
using BooksEditor.MVC.Models;
using BooksEditor.Policy;

namespace BooksEditor.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private WebsitePolicy _websitePolicy;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            _websitePolicy = new WebsitePolicy();
            _websitePolicy.Init();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookModel>();
                cfg.CreateMap<BookModel, Book>();
                cfg.CreateMap<Author, AuthorModel>();
                cfg.CreateMap<AuthorModel, Author>();
            });
        }
    }
}
