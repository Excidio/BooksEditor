using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace BooksEditor.Policy
{
    public class WebsitePolicy
    {
        public void Init()
        {
            var container = new UnityContainer();

            RepositoriesPolicy.Init(container);
            ServicesPolicy.Init(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
