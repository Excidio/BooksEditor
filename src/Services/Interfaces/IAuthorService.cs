using BooksEditor.Domain;

namespace BooksEditor.Services.Interfaces
{
    public interface IAuthorService
    {
        void SaveOrAdd(Author author);
    }
}
