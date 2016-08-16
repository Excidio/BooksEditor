using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using BooksEditor.Domain;
using BooksEditor.MVC.Models;

namespace BooksEditor.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Book, BookModel>();
                cfg.CreateMap<BookModel, Book>();
                cfg.CreateMap<Author, AuthorModel>();
                cfg.CreateMap<AuthorModel, Author>();
            });
        }
    }
}
