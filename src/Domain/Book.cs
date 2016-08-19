using System;
using System.Collections.Generic;

namespace BooksEditor.Domain
{
    public class Book
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public int NumberOfPages { get; set; }

        public string PublishingHouse { get; set; }

        public int PublishingYear { get; set; }

        public string ISBN { get; set; }

        /// <summary>
        /// Image in base64
        /// </summary>
        public string Image { get; set; }

        public IEnumerable<Author> Authors { get; set; }
    }
}
