﻿using System.Collections.Generic;
using BooksEditor.Domain;

namespace BooksEditor.Repository.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book book);

        void Save(Book book);

        IEnumerable<Book> FindAll();

        IEnumerable<Book> FindAllWithRelated();

        void Remove(int id);
    }
}
