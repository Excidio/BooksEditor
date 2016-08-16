﻿using System;
using BooksEditor.Domain;
using BooksEditor.Repository.Implementation;
using BooksEditor.Repository.Interfaces;
using BooksEditor.Services.Interfaces;

namespace BooksEditor.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(/*IBookRepository bookRepository*/)
        {
            _authorRepository = new AuthorRepository();//bookRepository;
        }

        public void Add(Author author)
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

        public void Save(Author author)
        {
            ValidateAuthor(author.Id);
            _authorRepository.Save(author);
        }

        public void Remove(Author author)
        {
            ValidateAuthor(author.Id);
            _authorRepository.Remove(author);
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