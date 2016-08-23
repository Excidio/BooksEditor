using System;
using BooksEditor.Domain;
using BooksEditor.Repository.Interfaces;
using BooksEditor.Services.Interfaces;

namespace BooksEditor.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void SaveOrAdd(Author author)
        {
            if (author.Id == 0)
            {
                Add(author);
            }
            else
            {
                Save(author);
            }
        }

        private void Add(Author author)
        {
            var authorDB = _authorRepository.FindOne(author.FirstName, author.LastName);
            if (authorDB == null)
            {
                _authorRepository.Add(author);
            }
            else
            {
                author.Id = authorDB.Id;
            }
        }

        private void Save(Author author)
        {
            ValidateAuthor(author.Id);
            _authorRepository.Save(author);
        }

        private void ValidateAuthor(int id)
        {
            var author = _authorRepository.FindOne(id);
            if (author == null)
            {
                throw new ApplicationException($"Author with ID: {id} isn't found.");
            }
        }
    }
}
