using BooksEditor.Domain;

namespace BooksEditor.Services.Interfaces
{
    public interface IAuthorService
    {
        void Add(Author author);

        void Save(Author author);

        void Remove(Author author);
    }
}
