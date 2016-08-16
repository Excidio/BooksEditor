using System;
using System.ComponentModel.DataAnnotations;

namespace BooksEditor.MVC.Models
{
    public class BookModel
    {
        [Required]
        [MaxLength(30, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string Header { get; set; }

        [Range(0, 10000, ErrorMessage = "The {0} must be between {1} and {2}.")]
        public int NumberOfPages { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string PublishingHouse { get; set; }

        [Range(typeof(DateTime), "01/01/1800", "06/06/2079")]
        public DateTime PublishDate { get; set; }

        [Required]
        public string ISBN { get; set; }

        //public string Image { get; set; } TODO: Add image

        //public IEnumerable<AuthorModel> Authors { get; set; }
    }
}
