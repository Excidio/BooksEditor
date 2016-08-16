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
            throw new System.NotImplementedException();
        }

        public Author FindOne(string firstName, string lastName)
        {
            throw new System.NotImplementedException();
        }
    }
}
