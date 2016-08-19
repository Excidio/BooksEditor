using Microsoft.Practices.Unity;

namespace BooksEditor.Policy
{
    public class WebsitePolicy
    {
        public void Init(UnityContainer container)
        {
            RepositoriesPolicy.Init(container);
            ServicesPolicy.Init(container);
        }
    }
}
