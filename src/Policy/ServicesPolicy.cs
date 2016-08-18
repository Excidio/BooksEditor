using BooksEditor.Services.Implementation;
using BooksEditor.Services.Interfaces;
using Microsoft.Practices.Unity;

namespace BooksEditor.Policy
{
    internal class ServicesPolicy
    {
        public static void Init(IUnityContainer container)
        {
            container.RegisterType<IAuthorService, AuthorService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBookService, BookService>(new ContainerControlledLifetimeManager());
        }
    }
}
