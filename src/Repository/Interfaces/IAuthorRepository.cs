using BooksEditor.Domain;

namespace BooksEditor.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        void Add(Author author);

        void Save(Author author);

        Author FindOne(int id);

        Author FindOne(string firstName, string lastName);
    }
}
