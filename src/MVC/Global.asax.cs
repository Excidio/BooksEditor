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

                string userName = null;
                                         cfg.CreateMap<Book, BookModel>();
                                         //.ForMember(d => d.UserName,
                                         //    opt => opt.MapFrom(src => userName)
                                         //);
            });
        }
    }
}
