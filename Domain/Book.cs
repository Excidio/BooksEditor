using System;
using System.Collections.Generic;

namespace BooksEditor.Domain
{
    public class Book
    {
        public string Header { get; set; }

        public int NumberOfPages { get; set; }

        public string PublishingHouse { get; set; }

        public DateTime PublishDate { get; set; }

        public string ISBN { get; set; }

        //public string Image { get; set; } TODO: Add image

        public IEnumerable<Author> Authors { get; set; }
    }
}
