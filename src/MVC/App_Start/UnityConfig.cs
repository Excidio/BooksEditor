using Microsoft.Practices.Unity;
using System.Web.Http;
using BooksEditor.Policy;
using Unity.WebApi;

namespace BooksEditor.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            new WebsitePolicy().Init(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}