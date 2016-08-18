using BooksEditor.Repository.Implementation;
using BooksEditor.Repository.Interfaces;
using Microsoft.Practices.Unity;

namespace BooksEditor.Policy
{
    internal class RepositoriesPolicy
    {
        public static void Init(IUnityContainer container)
        {
            container.RegisterType<IAuthorRepository, AuthorRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBookRepository, BookRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
