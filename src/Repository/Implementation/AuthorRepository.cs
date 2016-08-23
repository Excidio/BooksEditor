using System.Linq;
using BooksEditor.Domain;
using BooksEditor.Repository.Interfaces;

namespace BooksEditor.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        public void Add(Author author)
        {
            AuthorDB.Add(author);
        }

        public void Save(Author author)
        {
            AuthorDB.Save(author);
        }

        public void Remove(Author author)
        {
            AuthorDB.Remove(author);
        }

        public Author FindOne(int id)
        {
            return AuthorDB.GetAll().FirstOrDefault(a => a.Id == id);
        }

        public Author FindOne(string firstName, string lastName)
        {
            return AuthorDB.GetAll().FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);
        }
    }
}
