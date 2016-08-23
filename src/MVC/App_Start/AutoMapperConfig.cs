using AutoMapper;
using BooksEditor.Domain;
using BooksEditor.MVC.Models;

namespace BooksEditor.MVC
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookModel>();
                cfg.CreateMap<BookModel, Book>();
                cfg.CreateMap<Author, AuthorModel>();
                cfg.CreateMap<AuthorModel, Author>();
            });
        }
    }
}