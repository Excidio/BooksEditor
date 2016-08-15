using System;
using System.Collections.Generic;
using BooksEditor.Domain;

namespace BooksEditor.MVC.Models
{
    public class BookModel
    {
        public string Header { get; set; }

        public int NumberOfPages { get; set; }

        public string PublishingHouse { get; set; }

        public DateTime PublishDate { get; set; }

        public string ISBN { get; set; }

        //public string Image { get; set; } TODO: Add image

        //public IEnumerable<AuthorModel> Authors { get; set; }
    }
}
